using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using HtmlAgilityPack;

namespace Парсер_e1.ru
{
    static class Core
    {
        static object locker = new object();
        public static List<Job> ParseMainPage(string url)
        {
            waitInterval();
            List<Job> jobs = new List<Job>();
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                //reader для правильности кодировки
                System.IO.StreamReader reader = new System.IO.StreamReader(resp.GetResponseStream(), Encoding.UTF8);
                string jscript = reader.ReadToEnd();
                reader.Close();
                jscript = Regex.Match(jscript, "<div id=\"ra-content\">[\\s\\S]*?<script>[\\s\\S]*?var LIST =(.*);[\\s\\S]*?</script>").Result("$1");
                object jsObject = new JavaScriptSerializer().Deserialize(jscript, typeof(object));
                object[] jsJobs = (object[])((jsObject as System.Collections.Generic.Dictionary<string, object>).ElementAt(0).Value);
                if (jsJobs.Length == 0) return new List<Job>();
                foreach (Dictionary<string, object> jsJob in jsJobs)
                {
                    jobs.Add(ParseJobPage(jsJob));
                }
            }
            catch (Exception e) { System.Windows.Forms.MessageBox.Show("ошибка парсинга http страницы\n"+e.Message+"\n\n"+e.StackTrace); }
            return jobs;
        }

        static Job ParseJobPage(Dictionary<string, object> jsJob)
        {
            Job job = new Job();

            job.httpID = getFromDictionaryKey<int>(jsJob, "id");
            job.header = getFromDictionaryKey<string>(jsJob, "header");
            job.price = getFromDictionaryKey<string>(jsJob, "salary");
            job.company = getFromDictionaryKey<string>(jsJob, "company", "title");
            job.adress = getFromDictionaryKey<string>(jsJob, "contact", "address");
            job.article = getFromDictionaryKey<string>(jsJob, "description");  //fix it избавиться от html мусора
            job.nameEmployer = getFromDictionaryKey<string>(jsJob, "contact", "name");
            job.site = getFromDictionaryKey<string>(jsJob, "contact", "url");

            //2 реквизита указаны на другой http странице
            waitInterval();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://rabota.e1.ru/api/v1/vacancies/"+ job.httpID+"?fields=contact");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            //reader для правильности кодировки
            System.IO.StreamReader reader = new System.IO.StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            string jscript = reader.ReadToEnd();
            reader.Close();
            object jsObject = new JavaScriptSerializer().Deserialize<object>(jscript);
            jsObject = getFromDictionaryKey<object>(jsObject, "vacancies","0","contact");
            job.phone = "";
            foreach (object phone in getFromDictionaryKey<object[]>(jsObject, "phones"))
            {
               job.phone+=getFromDictionaryKey<string>(phone,"phone")+"\r\n";
            }
            job.eMail = getFromDictionaryKey<string>(jsObject, "email");


            return job;
        }

        /// <summary>
        /// Извлекает значение из многоуровнего Dictionary
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="dictionary">словарь</param>
        /// <param name="key">путь к значению в словаре</param>
        /// <returns></returns>
        static Type getFromDictionaryKey<Type>(object dictionary, params string[] key)
        {
            try
            {
                if (key.Length > 1)
                {
                    string[] tempKey = new string[key.Length - 1];
                    for (int i = 1; i < key.Length; i++)
                    {
                        tempKey[i - 1] = key[i];
                    }
                    //находим вложенный словарь
                    object TempDict = getFromDictionaryKey<object>(dictionary, key[0]);
                    return getFromDictionaryKey<Type>(TempDict, tempKey);
                }
                Type temp = default(Type);
                if (dictionary.GetType() == typeof(Dictionary<string, object>))
                {
                    temp = (Type)((Dictionary<string, object>)dictionary)[key[0]];// (Type)dictionary[key[0]];
                }
                if (dictionary.GetType() == typeof(object[]))
                {
                    temp = (Type)((object[])dictionary)[Convert.ToInt32(key[0])];
                }
                if (typeof(Type) == typeof(string))
                {
                    string text = System.Text.RegularExpressions.Regex.Replace((object)temp as string, "<br>", "\r\n");
                    text = System.Text.RegularExpressions.Regex.Replace((object)text as string, "<p>", "\r\n");
                    text = System.Text.RegularExpressions.Regex.Replace((object)text as string, "<li>", "- ");
                    text = System.Text.RegularExpressions.Regex.Replace((object)text as string, "</li>", "\r\n");
                    text = System.Text.RegularExpressions.Regex.Replace((object)text as string, "<h\\d>", "\r\n");
                    text = System.Text.RegularExpressions.Regex.Replace((object)text as string, "</h\\d>", "\r\n");
                    text = System.Text.RegularExpressions.Regex.Replace((object)text as string, "</?.*?>", "");
                    text = HtmlAgilityPack.HtmlEntity.DeEntitize(text);
                    return (Type)((object)text);
                }
                return temp;
            }
            catch
            {
                if (typeof(Type) == typeof(string))
                {
                    return (Type)((object)string.Empty);
                }
                return default(Type);
            }
        }
        /// <summary>
        /// Использует Options.cs для синхронизации потоков
        /// (для ограничения частоты http запросов)
        /// </summary>
        static void waitInterval()
        {
            while (true)
            {
                lock (locker)
                {
                    if ((DateTime.Now - Options.lastHttpRequest).TotalMilliseconds < Options.intervalParse)
                    {
                        System.Threading.Thread.Sleep(50);
                        continue;
                    }
                    Options.lastHttpRequest = DateTime.Now;
                    break;
                }
            }
        }
    }
}
