using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Парсер_e1.ru
{
    public partial class Form_ReaderFromDB : Form
    {
        ParamSet paramSet;
        string search="";
        public Form_ReaderFromDB(ParamSet paramSet)
        {
            InitializeComponent();
            this.paramSet = paramSet;
        }
        
        private void Form_ReaderFromDB_Load(object sender, EventArgs e)
        {
            jobsTableAdapter.Fill(dbDataSet.Jobs, paramSet.paramSetId,search);
            textBoxEmail.Visible = !(textBoxEmail.Text == "");
            this.Text = paramSet.name + ": " + dataGridView1.RowCount.ToString() + " Объявлений";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            jobsTableAdapter.Fill(dbDataSet.Jobs, paramSet.paramSetId, textBox2.Text);
            this.Text = paramSet.name + ": " + dataGridView1.RowCount.ToString() + "Объявлений";
           // jobsTableAdapter.Fill(dbDataSet.Jobs, paramSet.paramSetId, search);
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBoxEmail.Visible = !(textBoxEmail.Text == "");
        }

        private void linkLabelSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabelSite.Text.IndexOf("http")==0)
                System.Diagnostics.Process.Start(linkLabelSite.Text);
            else
                System.Diagnostics.Process.Start("http://" + linkLabelSite.Text);
        }
    }
}
