using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
namespace Парсер_e1.ru
{
    public class ParamSet
    {
        public string name="";
        public bool isUpdate;
        public decimal updateInterval=0;
        public int price=0;
        public int priceType=0;
        public bool onlyPay;
        public int employer=0;
        public int companySize=0;
        public byte[] timeJob=new byte[16];
        public byte[] employment = new byte[16];
        public byte[] education = new byte[16];
        public byte[] expierence = new byte[16];
        public int city = 0;
        public byte[] raion1 = new byte[16];
        public byte[] raion2 = new byte[16];
        public byte[] rubric = new byte[16];

        private int _paramSetId;
        public int paramSetId
        {
            get
            {
                return _paramSetId;
            }
        }
        private int countJobs=0;
        private string status = "";
        private bool isDelete = false;
        private static object locker = new object();
        private static object delLocker = new object();
        private AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        public System.Threading.Thread thread;

        public void AddToBD()
        {
            SqlConnection connect = new SqlConnection(Парсер_e1.ru.Properties.Settings.Default.dbConnectionString);
            string query = "INSERT INTO ParamSet" +
            "(ParamSet, isUpdate, intervalUpdate, Price, PriceType, OnlyPay, Employer, CompanySize, TimeJob, Employment, Education, Expierence, Rubric, Raion1, Raion2,City) " +
            "OUTPUT INSERTED.ParamSetID "+
            "VALUES(@ParamSet, @isUpdate, @intervalUpdate, @Price, @PriceType, @OnlyPay, @Employer, @CompanySize, @TimeJob, @Employment, @Education, @Expierence, @Rubric, @Raion1, @Raion2,@City)";
            SqlCommand command = new SqlCommand(query, connect);
            command.Parameters.AddRange(new object[16]{
                new SqlParameter("@ParamSet",name),
                new SqlParameter("@isUpdate",isUpdate),
                new SqlParameter("@intervalUpdate",updateInterval),
                new SqlParameter("@Price",price),
                new SqlParameter("@PriceType",priceType),
                new SqlParameter("@OnlyPay",onlyPay),
                new SqlParameter("@Employer",employer),
                new SqlParameter("@CompanySize",companySize),
                new SqlParameter("@TimeJob",timeJob),
                new SqlParameter("@Employment",employment),
                new SqlParameter("@Education",education),
                new SqlParameter("@Expierence",expierence),
                new SqlParameter("@Rubric",rubric),
                new SqlParameter("@Raion1",raion1),
                new SqlParameter("@Raion2",raion2),
                new SqlParameter("@City",city)
            });

            connect.Open();
            SqlDataReader sqlReader = command.ExecuteReader();
            sqlReader.Read();
            this._paramSetId= (int)sqlReader.GetValue(0);
            this.countJobs = 0;
            statusUpdate(false, true, false, this);
            connect.Close();
            thread = new Thread(update);
            thread.IsBackground = true;
            thread.Start(new object[] { this, true });
        }
        public void AssyncDelFromDB()
        {
            Thread thr = new Thread(DelFromDB);
            thr.IsBackground=true;
            thr.Start();
        }
        private void DelFromDB()
        {
            isDelete = true;
            autoResetEvent.Set();
            try
            {
                thread.Join();
            }
            catch { }
            lock (locker)
            {
                SqlConnection connect = new SqlConnection(Парсер_e1.ru.Properties.Settings.Default.dbConnectionString);
                connect.Open();
                SqlTransaction transact = connect.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                SqlCommand command = new SqlCommand(@"DELETE FROM Jobs
                WHERE (ParamSetId = @ParamSetId)", connect);
                command.Parameters.AddWithValue("@ParamSetId", _paramSetId);
                command.Transaction = transact;
                command.ExecuteNonQuery();
                command.CommandText = @"DELETE FROM ParamSet
                WHERE (ParamSetId = @ParamSetId)";
                command.ExecuteNonQuery();
                transact.Commit();
                connect.Close();
            }
        }
        public static List<ParamSet> LoadFromDB()
        {
            List<ParamSet> sets = new List<ParamSet>();

            SqlConnection connect = new SqlConnection(Парсер_e1.ru.Properties.Settings.Default.dbConnectionString);
            string query = "SELECT ParamSet, isUpdate, intervalUpdate, Price, PriceType," +
            "OnlyPay, Employer, CompanySize, TimeJob, Employment, Education, Expierence, Rubric, Raion1, Raion2, City, ParamSetId " +
            "FROM ParamSet";
            SqlCommand command = new SqlCommand(query, connect);
            connect.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ParamSet set = new ParamSet();
                set.name = (string)reader["ParamSet"];
                set.isUpdate = (bool)reader["isUpdate"];
                set.updateInterval = (decimal)reader["intervalUpdate"];
                set.price = (int)reader["Price"];
                set.priceType = (int)reader["PriceType"];
                set.onlyPay = (bool)reader["OnlyPay"];
                set.employer = (int)reader["Employer"];
                set.companySize = (int)reader["CompanySize"];
                set.timeJob = (byte[])reader["TimeJob"];
                set.employment = (byte[])reader["Employment"];
                set.education = (byte[])reader["Education"];
                set.expierence = (byte[])reader["Expierence"];
                set.rubric = (byte[])reader["Rubric"];
                set.raion1 = (byte[])reader["Raion1"];
                set.raion2 = (byte[])reader["Raion2"];
                set.city = (int)reader["City"];
                set._paramSetId = (int)reader["ParamSetId"];

                SqlConnection connect2 = new SqlConnection(Парсер_e1.ru.Properties.Settings.Default.dbConnectionString);
                string nullquery = "Select COUNT(*) FROM Jobs WHERE ParamSetId=@ParamSetId";
                SqlCommand nullcommand = new SqlCommand(nullquery, connect2);
                nullcommand.Parameters.Add(new SqlParameter("@ParamSetId", set._paramSetId));
                connect2.Open();
                set.countJobs = (int)nullcommand.ExecuteScalar();

                //для наборов параметров без пропарсенных работ
                nullquery = "Select * FROM Jobs WHERE ParamSetId=@ParamSetId";
               // nullcommand = new SqlCommand(nullquery, connect2);
                nullcommand.CommandText = nullquery;
                SqlDataReader nullreader = nullcommand.ExecuteReader();
                if (!nullreader.HasRows)
                {
                    set.thread = new Thread(update);
                    set.thread.IsBackground = true;
                    set.thread.Start(new object[] { set, true });
                    sets.Add(set);
                    continue;
                }
                //для пропарсенных
                if (set.isUpdate)
                {
                    set.thread = new Thread(update);
                    set.thread.IsBackground = true;
                    set.thread.Start(new object[] { set, false });
                }
                sets.Add(set);
                connect2.Close();
            }
            connect.Close();
            return sets;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param">
        /// new object[]{ParamSet, bool}, где
        /// ParamSet - набор параметров для парсинга/обновления работ.
        /// bool - является ли ParamSet только что созданным
        /// </param>
        static void update(object param)
        {
            ParamSet set = (ParamSet)(param as object[])[0];
            bool isNew = (bool)(param as object[])[1];

            while (true)
            {
                //stop - всё необходимое пропарсилось
                bool stop = false;
                SqlConnection connect = new SqlConnection(Парсер_e1.ru.Properties.Settings.Default.dbConnectionString);
                connect.Open();
                int currentMainJob = 0;
                while (true)
                {
                    List<Job> jobs = Core.ParseMainPage(convertToUrl(currentMainJob++, set));
                    if (jobs.Count == 0) { stop = true; break; }
                    lock (locker)
                    {
                        if (set.isDelete) return;
                        foreach (Job job in jobs)
                        {
                           /* string queryif = "SELECT * FROM Jobs WHERE HttpID=" + job.httpID;
                            SqlConnection connect2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True;User Instance=True");
                            SqlCommand comif = new SqlCommand(queryif, connect2);
                            connect2.Open();
                            SqlDataReader reader = comif.ExecuteReader();
                            if (reader.Read()) { stop = true; }
                            connect2.Close();*/

                            if (stop == false)
                            {
                                string query = "INSERT INTO Jobs" +
                                 "(HttpID, ParamSetId, Header, Price, Company, Adress, Article, NameEmployer, Phone, E_mail, Site)" +
                                "VALUES(@HttpID, @ParamSetId, @Header, @Price, @Company, @Adress, @Article, @NameEmployer, @Phone, @E_mail, @Site)";
                                SqlCommand command = new SqlCommand(query, connect);
                                command.Parameters.AddRange(new object[11]{
                            new SqlParameter("@HttpId",job.httpID),
                            new SqlParameter("@ParamSetId",set._paramSetId),
                            new SqlParameter("@Header",job.header),
                            new SqlParameter("@Price",job.price),
                            new SqlParameter("@Company",job.company),
                            new SqlParameter("@Adress",job.adress),
                            new SqlParameter("@Article",job.article),
                            new SqlParameter("@NameEmployer",job.nameEmployer),
                            new SqlParameter("@Phone",job.phone),
                            new SqlParameter("@E_mail",job.eMail),
                            new SqlParameter("@Site",job.site) });
                                try
                                {
                                    command.ExecuteNonQuery();
                                    statusUpdate(stop, isNew, true, set);
                                }
                                catch (Exception e) { stop = true; MessageBox.Show(e.Message); }
                            }
                            else { break; }
                        }
                    }
                    if (stop) break;
                }
                connect.Close();
                if (isNew)
                {
                    if (set.isUpdate == false)
                    {
                        statusUpdate(true, false, false, set);
                        return;
                    }
                    else isNew = false;
                }
                if (stop)
                {
                    if (set.isUpdate)
                    {
                        stop = false; isNew = false;
                        statusUpdate(false, false, false, set);
                    }
                    else return;
                }
                //sleep, который прерывается удалением объекта ParamSet
                set.autoResetEvent.WaitOne((int)(set.updateInterval * 60 * 1000));
                if (set.isDelete) return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentMain">номер страницы результатов на сайте, что состоит из 50 объявлений</param>
        /// <param name="set"></param>
        /// <returns></returns>
        static string convertToUrl(int currentMain,ParamSet set)
        {
            string url="http://rabota.e1.ru/vacancy?q=&search_type=simple&";
            try { url += "salary=" + set.price.ToString() + "&"; }
            catch { }
            if (set.onlyPay)
            {                
                url += "is_notempty_salary=on&";
            }
            switch (set.priceType)
            {
                case 0: { url += "currency=299&"; break; }
                case 1: { url += "currency=300&"; break; }
                case 2: { url += "currency=2996&"; break; }
                case 3: { url += "currency=301&"; break; }
                case 4: { url += "currency=303&"; break; }
                case 5: { url += "currency=2997&"; break; }
                case 6: { url += "currency=2999&"; break; }
                case 7: { url += "currency=2998&"; break; }
            }
            BitArray bits = new BitArray(set.rubric);
            for (int i = 0; i < Rubrics.hashRubrics.Count; i++)
            {
                byte[] byb = new byte[80];
                if (bits.Get(i) == true)
                {
                    url += "rubric%5B%5D="+Rubrics.hashRubrics[i]+"&";

                }
            }
            switch (set.employer)
            {
                case 2: { url += "employer_group=direct&"; break; }
                case 3: { url += "employer_group=hr&"; break; }
            }
            if (set.companySize != 0)
            {
                url += "employees=" + set.companySize.ToString() + "&";
            }
            if (new BitArray(set.timeJob).Get(0)) url += "schedule%5B%5D=305&";
            if (new BitArray(set.timeJob).Get(1)) url += "schedule%5B%5D=306&";
            if (new BitArray(set.timeJob).Get(2)) url += "schedule%5B%5D=308&";
            if (new BitArray(set.timeJob).Get(3)) url += "schedule%5B%5D=307&";
            if (new BitArray(set.employment).Get(0)) url += "working_type%5B%5D=309&";
            if (new BitArray(set.employment).Get(1)) url += "working_type%5B%5D=310&";
            if (new BitArray(set.employment).Get(2)) url += "working_type%5B%5D=462&";
            if (new BitArray(set.employment).Get(3)) url += "working_type%5B%5D=312&";
            if (new BitArray(set.employment).Get(4)) url += "working_type%5B%5D=311&";
            if (new BitArray(set.expierence).Get(0)) url += "work_length%5B%5D=3000&";
            if (new BitArray(set.expierence).Get(1)) url += "work_length%5B%5D=3001&";
            if (new BitArray(set.expierence).Get(2)) url += "work_length%5B%5D=3002&";
            if (new BitArray(set.expierence).Get(3)) url += "work_length%5B%5D=3003&";
            if (new BitArray(set.expierence).Get(4)) url += "work_length%5B%5D=3004&";
            if (new BitArray(set.education).Get(0)) url += "education%5B%5D=383&";
            if (new BitArray(set.education).Get(1)) url += "education%5B%5D=384&";
            if (new BitArray(set.education).Get(2)) url += "education%5B%5D=385&";
            if (new BitArray(set.education).Get(3)) url += "education%5B%5D=386&";
            if (new BitArray(set.education).Get(4)) url += "education%5B%5D=387&";
            if (new BitArray(set.education).Get(5)) url += "education%5B%5D=3088&";
            if (new BitArray(set.education).Get(6)) url += "education%5B%5D=3108&";
            switch (set.city)
            {
                case 0: { url += "city_id%5B%5D=994&"; break; }
                case 1: { url += "city_id%5B%5D=997&"; break; }
                case 2: { url += "city_id%5B%5D=995&"; break; }
                case 3: { url += "city_id%5B%5D=846&"; break; }
                case 4: { url += "city_id%5B%5D=876&"; break; }
            }
            #region raion
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258351&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258271&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258361&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258151&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258221&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258181&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258301&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258471&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258281&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258381&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258311&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258171&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258451&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258441&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258461&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258421&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258251&";
            if (new BitArray(set.raion1).Get(0)) url += "wish_districts%5B%5D=258261&";

            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258341&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258191&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258431&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258331&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258321&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258161&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258401&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258291&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258131&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258411&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258211&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258371&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258201&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258391&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258241&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258141&";
            if (new BitArray(set.raion2).Get(0)) url += "wish_districts%5B%5D=258231&";
            #endregion
            url += "order_by=orderby_date&order_dir=desc&limit=50";
                if (currentMain == 0)
                {
                    return url;
                }
                url += "&offset=" + (currentMain * 50).ToString();
            return url;
        }
        static void statusUpdate(bool isStop,bool isNew,bool incrementJob,ParamSet set)
        {
            set.status = "";
            if (isStop)
            {
                set.status += " - " + set.countJobs.ToString() + " Вакансий";
                return;
            }
            set.status = "(";
            if (incrementJob) set.countJobs++;

            if (isNew) { set.status += "Запущен"; }
            else { set.status += "Обновляется"; }

            set.status+= " - " + set.countJobs.ToString()+" Вакансий)";
        }
        public override string ToString()
        {
            return name + status;
        }
    }
}
