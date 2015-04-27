using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Парсер_e1.ru
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            comboBoxPriceType.SelectedItem = comboBoxPriceType.Items[0];
            comboBoxCompanySize.SelectedItem = comboBoxCompanySize.Items[0];
            comboBoxCity.SelectedItem = comboBoxCity.Items[0];
            #region рубрики
            foreach (Dictionary<string,string> table in Rubrics.data())
            {
                listBoxRubrics.Items.Add(table["Каталог рубрик"]);
                CheckedListBox rubric = new CheckedListBox();
                rubric.Size = new Size(336,202);
                rubric.Location = new Point(7,161);
                rubric.BorderStyle = System.Windows.Forms.BorderStyle.None;
                rubric.CheckOnClick = true;
                rubric.Name = (string)table["Каталог рубрик"];
                rubric.Visible = false;
                foreach (KeyValuePair<string,string> entry in table)
                {
                    rubric.Items.Add(entry.Key);
                }
                rubric.Items.Remove("Каталог рубрик");
                rubric.ItemCheck += checkRubricBox_ItemCheck;
                tabPage2.Controls.Add(rubric);
            }
            #endregion
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            listBoxParamSet.Items.AddRange(ParamSet.LoadFromDB().ToArray());
        }

        #region добавить/сохранить/удалить/показать набор данных

        #region доп.функции

        private byte[] convertToByte(CheckedListBox checkedListBox)
        {
            // int i = 0;
            byte[] by = new byte[16];
            BitArray bits = new BitArray(128);
            foreach (int selItem in checkedListBox.CheckedIndices)
            {
                bits.Set(selItem, true);
                //i += (int)Math.Pow(2, selItem);
            }
            bits.CopyTo(by, 0);
            return by;
        }
        private void convertFromByte(CheckedListBox checkedListBox, byte[] bytes)
        {
            BitArray bits = new BitArray(bytes);
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (bits.Get(i))
                    checkedListBox.SetItemChecked(i, true);
                else
                    checkedListBox.SetItemChecked(i, false);
            }
        }

        private byte[] RubricToByte()
        {
            //перебирает все listCheckBox на tabPage2, конвертирует их значение в байт-результат

            int i = 0;
            byte[] by = new byte[80];
            BitArray bits = new BitArray(640);
            foreach (Control box in tabPage2.Controls)
            {
                if (box.GetType() == typeof(CheckedListBox))
                {
                    CheckedListBox checkBox = (CheckedListBox)box;
                    foreach (int selItem in checkBox.CheckedIndices)
                    {
                        bits.Set(selItem + i, true);
                    }
                    i += checkBox.Items.Count;
                }
            }
            bits.CopyTo(by, 0);
            return by;
        }
        private void RubricFromByte(byte[] bytes)
        {
            //перебирает все listCheckBox на tabPage2, 
            //выдаёт им значения согласно входному параметру

            int j = 0;
            foreach (Control box in tabPage2.Controls)
            {
                if (box.GetType() == typeof(CheckedListBox))
                {
                    CheckedListBox checkBox = (CheckedListBox)box;
                    BitArray bits = new BitArray(bytes);
                    for (int i = 0; i < checkBox.Items.Count; i++)
                    {
                        if (bits.Get(i + j))
                            checkBox.SetItemChecked(i, true);
                        else
                            checkBox.SetItemChecked(i, false);
                    }
                    j += checkBox.Items.Count;
                }
            }
        }

        private void checkedListBoxToFalse(CheckedListBox checkedListBox)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, false);
            }
        }

        #endregion

        private void buttonAddParamSet_Click(object sender, EventArgs e)
        {
            panelMain.Enabled = true;
            buttonParamSetSave.Enabled = true;
            textBoxParamSetName.Text = "Новый набор";
            label1.Focus();
        }

        private void buttonParamSetSave_Click(object sender, EventArgs e)
        {
            foreach (object ob in listBoxParamSet.Items)
            {
                if ((ob as ParamSet).name == textBoxParamSetName.Text)
                {
                    MessageBox.Show("уже есть набор параметров с заданным именем");
                    return;
                }
            }
            ParamSet paramSet = new ParamSet();

            paramSet.name = textBoxParamSetName.Text;
            paramSet.isUpdate = checkBoxUpdate.Checked;
            paramSet.updateInterval = numericUpDownUpdate.Value;
            int.TryParse(textBoxPrice.Text, out paramSet.price);
            paramSet.priceType = comboBoxPriceType.SelectedIndex;
            paramSet.onlyPay = checkBoxOnlyPay.Checked;
            if (radioButton1.Checked) paramSet.employer = 1;
            if (radioButton2.Checked) paramSet.employer = 2;
            if (radioButton3.Checked) paramSet.employer = 3;
            paramSet.companySize = comboBoxCompanySize.SelectedIndex;
            paramSet.timeJob = convertToByte(checkedListBoxTimeJob);
            paramSet.employment = convertToByte(checkedListBoxEmploy);
            paramSet.education = convertToByte(checkedListBoxEducation);
            paramSet.expierence = convertToByte(checkedListBoxExp);
            paramSet.rubric = RubricToByte();
            if (comboBoxCity.SelectedIndex == 0)
            {
                paramSet.raion1 = convertToByte(checkedListBoxRaion1);
                paramSet.raion2 = convertToByte(checkedListBoxRaion2);
            }
            paramSet.city = comboBoxCity.SelectedIndex;
            try
            {
                paramSet.AddToBD();
            }
            catch { MessageBox.Show("Ошибки в подключении к БД"); return; }
            listBoxParamSet.Items.Add(paramSet);
            listBoxParamSet.SelectedIndex = listBoxParamSet.Items.IndexOf(paramSet);

            textBoxParamSetName.Text = ""; 
            checkBoxUpdate.Checked = true;
            numericUpDownUpdate.Value = 5;
            textBoxPrice.Text = "";
            comboBoxPriceType.SelectedIndex = 0;
            checkBoxOnlyPay.Checked = false;
            radioButton1.Checked = true;
            comboBoxCompanySize.SelectedIndex = 0;
            checkedListBoxToFalse(checkedListBoxTimeJob);
            checkedListBoxToFalse(checkedListBoxEmploy);
            checkedListBoxToFalse(checkedListBoxEducation);
            checkedListBoxToFalse(checkedListBoxExp);
            checkedListBoxToFalse(checkedListBoxRaion1);
            checkedListBoxToFalse(checkedListBoxRaion2);
            foreach (object checkedListBox in tabPage2.Controls)
            {
                if (checkedListBox.GetType() == typeof(CheckedListBox))
                    checkedListBoxToFalse((CheckedListBox)checkedListBox);
            }
            comboBoxCity.SelectedIndex = 0;

            panelMain.Enabled = false;
            buttonParamSetSave.Enabled = false;
            label1.Focus();
        }

        private void buttonParamSetShow_Click(object sender, EventArgs e)
        {
            ParamSet set = (ParamSet)listBoxParamSet.SelectedItem;
            new Form_ReaderFromDB(set).ShowDialog();
        }

        private void buttonParamSetDelete_Click(object sender, EventArgs e)
        {
            ParamSet Temp = (ParamSet)listBoxParamSet.SelectedItem;
            listBoxParamSet.Items.Remove(Temp);
            Temp.AssyncDelFromDB();
        }

        #endregion

        private void listBoxParamSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxParamSet.SelectedIndex != -1)
            {
                buttonParamSetShow.Enabled = true;
                buttonParamSetDelete.Enabled = true;
            }
            else
            {
                buttonParamSetShow.Enabled = false;
                buttonParamSetDelete.Enabled = false;
            }
        }

        private void checkBox1Update_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownUpdate.Enabled = checkBoxUpdate.Checked;
            label2.Enabled = checkBoxUpdate.Checked;
        }

        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                if (comboBox.Name == "comboBoxCity")
                    if (comboBox.SelectedIndex != 0)
                        panel1.Visible = false;
                    else panel1.Visible = true;
            }
            label1.Focus();
            CheckedListBox ch = sender as CheckedListBox;
            if (ch != null)
            { ch.SelectedItem = null; }
        }

        private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            new FormOptions().ShowDialog();
            label1.Select();
        }

        #region рубрик-обработчики   
        private static bool changeByProgram = false;
        private void ListBoxRubric_SelectedIndexChanged(object sender, EventArgs e)
        {
           // bool allChecked = true;
            foreach (Control check in tabPage2.Controls)
            {
                if (check.GetType() == typeof(CheckedListBox))
                {
                    check.Visible = false;
                }
            }
            CheckedListBox visibleBox = (CheckedListBox)tabPage2.Controls[listBoxRubrics.SelectedItem.ToString()];
            visibleBox.Visible = true;
/*
            for (int i = 0; i < visibleBox.Items.Count; i++)
            {
                if (visibleBox.GetItemChecked(i) == false)
                {
                    allChecked = false;
                    break;
                };
            }
            checkBoxRubricAll.Checked = allChecked;*/
        }
        private void checkRubricBox_ItemCheck(object sender, EventArgs e)
        {
            if (changeByProgram) return;
            changeByProgram = true;
            CheckedListBox checkBox = (CheckedListBox)sender;
            checkBox.SetItemChecked(checkBox.SelectedIndex, !checkBox.GetItemChecked(checkBox.SelectedIndex));
            if (checkBox.SelectedIndex == 0)
            {
                for (int i = 1; i < checkBox.Items.Count; i++)
                {
                    checkBox.SetItemChecked(i, checkBox.GetItemChecked(0));
                }
                changeByProgram = false;
                return;
            }
            bool allCheck = true;
            for (int i = 1; i < checkBox.Items.Count; i++)
            {
                if (checkBox.GetItemChecked(i) == false)
                {
                    allCheck = false; break;
                }
            }
            checkBox.SetItemChecked(0,allCheck);
            changeByProgram = false;
        }
        #endregion

        private void checkedListBox1_MouseLeave(object sender, EventArgs e)
        {
            int i = 5;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            List<object> temp = new List<object>();
            int maxWidth = 0;
            int indexTemp = listBoxParamSet.SelectedIndex;
            int count = listBoxParamSet.Items.Count;
            for (int i = 0; i < count; i++)
            {
               int width= (int)System.Drawing.Graphics.FromHwnd(Handle).MeasureString(listBoxParamSet.Items[i].ToString(), listBoxParamSet.Font).Width;
               if (maxWidth < width) maxWidth = width;
              //  list.Add((ParamSet)listBoxParamSet.Items[i]);
                temp.Add(listBoxParamSet.Items[i]);
                //SendMessage(new HandleRef(listBoxParamSet, listBoxParamSet.Handle), 386, i, 0);
            }
            listBoxParamSet.HorizontalExtent = maxWidth;
            for (int i = 0; i < count; i++)
            {
                listBoxParamSet.Items.RemoveAt(0);
            }
                listBoxParamSet.Items.AddRange(temp.ToArray());
                listBoxParamSet.SelectedIndex=indexTemp;
               // SendMessage(new HandleRef(listBoxParamSet, listBoxParamSet.Handle), 385, i, ((ParamSet)listBoxParamSet.Items[i]).ToString());
         //   }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b'))
                e.Handled = true;
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {           
            int i = 0;
            if(!int.TryParse(textBoxPrice.Text,out i)) 
                textBoxPrice.Text="";
            checkBoxOnlyPay.Checked = (textBoxPrice.Text != "");
        }
    }
}
