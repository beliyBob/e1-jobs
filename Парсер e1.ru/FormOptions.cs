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
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value=(decimal)Options.intervalParse/1000;
        }

        private void FormOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options.intervalParse = (int)(numericUpDown1.Value * 1000);
        }
    }
}
