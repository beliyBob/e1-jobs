namespace Парсер_e1.ru
{
    partial class Form_Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkedListBoxEducation = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxExp = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkedListBoxEmploy = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkedListBoxTimeJob = new System.Windows.Forms.CheckedListBox();
            this.comboBoxCompanySize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPriceType = new System.Windows.Forms.ComboBox();
            this.checkBoxOnlyPay = new System.Windows.Forms.CheckBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBoxRubrics = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkedListBoxRaion2 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxRaion1 = new System.Windows.Forms.CheckedListBox();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.listBoxParamSet = new System.Windows.Forms.ListBox();
            this.checkBoxUpdate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownUpdate = new System.Windows.Forms.NumericUpDown();
            this.textBoxParamSetName = new System.Windows.Forms.TextBox();
            this.buttonParamSetAdd = new System.Windows.Forms.Button();
            this.buttonParamSetShow = new System.Windows.Forms.Button();
            this.buttonParamSetSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonParamSetDelete = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUpdate)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(357, 391);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkedListBoxEducation);
            this.tabPage1.Controls.Add(this.checkedListBoxExp);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.checkedListBoxEmploy);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.checkedListBoxTimeJob);
            this.tabPage1.Controls.Add(this.comboBoxCompanySize);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.radioButton3);
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.comboBoxPriceType);
            this.tabPage1.Controls.Add(this.checkBoxOnlyPay);
            this.tabPage1.Controls.Add(this.textBoxPrice);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(349, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основное";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxEducation
            // 
            this.checkedListBoxEducation.CheckOnClick = true;
            this.checkedListBoxEducation.FormattingEnabled = true;
            this.checkedListBoxEducation.Items.AddRange(new object[] {
            "Неполное среднее",
            "Среднее",
            "Среднее-специальное",
            "Неполное высшее",
            "Высшее",
            "Студент очник",
            "Студент Заочник"});
            this.checkedListBoxEducation.Location = new System.Drawing.Point(10, 250);
            this.checkedListBoxEducation.Name = "checkedListBoxEducation";
            this.checkedListBoxEducation.Size = new System.Drawing.Size(139, 109);
            this.checkedListBoxEducation.TabIndex = 17;
            this.checkedListBoxEducation.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            // 
            // checkedListBoxExp
            // 
            this.checkedListBoxExp.CheckOnClick = true;
            this.checkedListBoxExp.FormattingEnabled = true;
            this.checkedListBoxExp.Items.AddRange(new object[] {
            "Без опыта",
            "До 1 года",
            "1-3 года",
            "3-5 лет",
            "Более 5 лет"});
            this.checkedListBoxExp.Location = new System.Drawing.Point(165, 250);
            this.checkedListBoxExp.Name = "checkedListBoxExp";
            this.checkedListBoxExp.Size = new System.Drawing.Size(106, 79);
            this.checkedListBoxExp.TabIndex = 16;
            this.checkedListBoxExp.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Образование";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(162, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Стаж работы";
            // 
            // checkedListBoxEmploy
            // 
            this.checkedListBoxEmploy.CheckOnClick = true;
            this.checkedListBoxEmploy.FormattingEnabled = true;
            this.checkedListBoxEmploy.Items.AddRange(new object[] {
            "Полная занятость",
            "Частичная занятость",
            "Работа вахтовым методом",
            "Временная работа / freelance",
            "Стажировка"});
            this.checkedListBoxEmploy.Location = new System.Drawing.Point(165, 141);
            this.checkedListBoxEmploy.Name = "checkedListBoxEmploy";
            this.checkedListBoxEmploy.Size = new System.Drawing.Size(176, 79);
            this.checkedListBoxEmploy.TabIndex = 13;
            this.checkedListBoxEmploy.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(162, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Тип занятости";
            // 
            // checkedListBoxTimeJob
            // 
            this.checkedListBoxTimeJob.CheckOnClick = true;
            this.checkedListBoxTimeJob.FormattingEnabled = true;
            this.checkedListBoxTimeJob.Items.AddRange(new object[] {
            "Полный рабочий день",
            "Удаленная работа",
            "Гибкий график",
            "Сменный график"});
            this.checkedListBoxTimeJob.Location = new System.Drawing.Point(10, 157);
            this.checkedListBoxTimeJob.Name = "checkedListBoxTimeJob";
            this.checkedListBoxTimeJob.Size = new System.Drawing.Size(139, 64);
            this.checkedListBoxTimeJob.TabIndex = 11;
            this.checkedListBoxTimeJob.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            this.checkedListBoxTimeJob.MouseLeave += new System.EventHandler(this.checkedListBox1_MouseLeave);
            // 
            // comboBoxCompanySize
            // 
            this.comboBoxCompanySize.FormattingEnabled = true;
            this.comboBoxCompanySize.Items.AddRange(new object[] {
            "Любой",
            "Менее 10",
            "10-50",
            "51-100",
            "101-300",
            "Свыше 300"});
            this.comboBoxCompanySize.Location = new System.Drawing.Point(10, 117);
            this.comboBoxCompanySize.Name = "comboBoxCompanySize";
            this.comboBoxCompanySize.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCompanySize.TabIndex = 10;
            this.comboBoxCompanySize.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            this.comboBoxCompanySize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "График работы";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Размер компании";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(203, 81);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(125, 17);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.Text = "Кадровые агенства";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(57, 81);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(140, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Text = "Прямые работодатели";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 81);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(44, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Все";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Работодатели";
            // 
            // comboBoxPriceType
            // 
            this.comboBoxPriceType.FormattingEnabled = true;
            this.comboBoxPriceType.Items.AddRange(new object[] {
            "Рублей",
            "Рублей в час",
            "Рублей за смену",
            "Долларов",
            "Евро",
            "Гривен",
            "Бел. рублей",
            "Тенге"});
            this.comboBoxPriceType.Location = new System.Drawing.Point(104, 24);
            this.comboBoxPriceType.Name = "comboBoxPriceType";
            this.comboBoxPriceType.Size = new System.Drawing.Size(111, 21);
            this.comboBoxPriceType.TabIndex = 3;
            this.comboBoxPriceType.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            this.comboBoxPriceType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // checkBoxOnlyPay
            // 
            this.checkBoxOnlyPay.AutoSize = true;
            this.checkBoxOnlyPay.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxOnlyPay.Location = new System.Drawing.Point(10, 44);
            this.checkBoxOnlyPay.Name = "checkBoxOnlyPay";
            this.checkBoxOnlyPay.Size = new System.Drawing.Size(184, 17);
            this.checkBoxOnlyPay.TabIndex = 2;
            this.checkBoxOnlyPay.Text = "Только с указанной зарплатой";
            this.checkBoxOnlyPay.UseVisualStyleBackColor = true;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(10, 24);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(87, 20);
            this.textBoxPrice.TabIndex = 1;
            this.textBoxPrice.TextChanged += new System.EventHandler(this.textBoxPrice_TextChanged);
            this.textBoxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrice_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Зарплата от";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxRubrics);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(349, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Рубрики";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxRubrics
            // 
            this.listBoxRubrics.FormattingEnabled = true;
            this.listBoxRubrics.Location = new System.Drawing.Point(7, 7);
            this.listBoxRubrics.Name = "listBoxRubrics";
            this.listBoxRubrics.Size = new System.Drawing.Size(336, 147);
            this.listBoxRubrics.TabIndex = 2;
            this.listBoxRubrics.SelectedIndexChanged += new System.EventHandler(this.ListBoxRubric_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.comboBoxCity);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(349, 365);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Районы";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkedListBoxRaion2);
            this.panel1.Controls.Add(this.checkedListBoxRaion1);
            this.panel1.Location = new System.Drawing.Point(18, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 313);
            this.panel1.TabIndex = 2;
            // 
            // checkedListBoxRaion2
            // 
            this.checkedListBoxRaion2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxRaion2.CheckOnClick = true;
            this.checkedListBoxRaion2.FormattingEnabled = true;
            this.checkedListBoxRaion2.Items.AddRange(new object[] {
            "Втузгородок",
            "ЖБИ",
            "Синие Камни",
            "Сибирский",
            "Парковый",
            "Автовокзал",
            "Ботанический",
            "Чермет",
            "Елизавет",
            "Шинный",
            "Уктус",
            "Химмаш",
            "Лечебный",
            "Птицефабрика",
            "Компрессорный",
            "Кольцово"});
            this.checkedListBoxRaion2.Location = new System.Drawing.Point(145, 18);
            this.checkedListBoxRaion2.Name = "checkedListBoxRaion2";
            this.checkedListBoxRaion2.Size = new System.Drawing.Size(131, 270);
            this.checkedListBoxRaion2.TabIndex = 1;
            this.checkedListBoxRaion2.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            // 
            // checkedListBoxRaion1
            // 
            this.checkedListBoxRaion1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxRaion1.CheckOnClick = true;
            this.checkedListBoxRaion1.FormattingEnabled = true;
            this.checkedListBoxRaion1.Items.AddRange(new object[] {
            "Уралмаш",
            "Эльмаш",
            "Веер",
            "Сортировка",
            "Заречный",
            "Вокзальный",
            "Пионерский",
            "Шарташ",
            "Центр",
            "Виз",
            "Юго-западный",
            "Широкая Речка",
            "Лиственный",
            "Мичуринский",
            "Академический",
            "Европейский",
            "УНЦ"});
            this.checkedListBoxRaion1.Location = new System.Drawing.Point(21, 18);
            this.checkedListBoxRaion1.Name = "checkedListBoxRaion1";
            this.checkedListBoxRaion1.Size = new System.Drawing.Size(135, 270);
            this.checkedListBoxRaion1.TabIndex = 0;
            this.checkedListBoxRaion1.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Items.AddRange(new object[] {
            "Екатеринбург",
            "Верхняя Пышма",
            "Асбест",
            "Оренбург",
            "Пермь",
            "Все города"});
            this.comboBoxCity.Location = new System.Drawing.Point(18, 17);
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCity.TabIndex = 1;
            this.comboBoxCity.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            this.comboBoxCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // listBoxParamSet
            // 
            this.listBoxParamSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxParamSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxParamSet.FormattingEnabled = true;
            this.listBoxParamSet.HorizontalScrollbar = true;
            this.listBoxParamSet.Location = new System.Drawing.Point(12, 13);
            this.listBoxParamSet.Name = "listBoxParamSet";
            this.listBoxParamSet.Size = new System.Drawing.Size(236, 186);
            this.listBoxParamSet.TabIndex = 3;
            this.listBoxParamSet.SelectedIndexChanged += new System.EventHandler(this.listBoxParamSet_SelectedIndexChanged);
            // 
            // checkBoxUpdate
            // 
            this.checkBoxUpdate.AutoSize = true;
            this.checkBoxUpdate.Checked = true;
            this.checkBoxUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUpdate.Location = new System.Drawing.Point(171, 41);
            this.checkBoxUpdate.Name = "checkBoxUpdate";
            this.checkBoxUpdate.Size = new System.Drawing.Size(88, 17);
            this.checkBoxUpdate.TabIndex = 4;
            this.checkBoxUpdate.Text = "Обновление";
            this.checkBoxUpdate.UseVisualStyleBackColor = true;
            this.checkBoxUpdate.CheckedChanged += new System.EventHandler(this.checkBox1Update_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Период обновления (минут)";
            // 
            // numericUpDownUpdate
            // 
            this.numericUpDownUpdate.Location = new System.Drawing.Point(161, 21);
            this.numericUpDownUpdate.Name = "numericUpDownUpdate";
            this.numericUpDownUpdate.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownUpdate.TabIndex = 6;
            this.numericUpDownUpdate.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // textBoxParamSetName
            // 
            this.textBoxParamSetName.Location = new System.Drawing.Point(3, 20);
            this.textBoxParamSetName.Name = "textBoxParamSetName";
            this.textBoxParamSetName.Size = new System.Drawing.Size(134, 20);
            this.textBoxParamSetName.TabIndex = 7;
            // 
            // buttonParamSetAdd
            // 
            this.buttonParamSetAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonParamSetAdd.Location = new System.Drawing.Point(12, 206);
            this.buttonParamSetAdd.Name = "buttonParamSetAdd";
            this.buttonParamSetAdd.Size = new System.Drawing.Size(236, 23);
            this.buttonParamSetAdd.TabIndex = 8;
            this.buttonParamSetAdd.Text = "Новый набор";
            this.buttonParamSetAdd.UseVisualStyleBackColor = true;
            this.buttonParamSetAdd.Click += new System.EventHandler(this.buttonAddParamSet_Click);
            // 
            // buttonParamSetShow
            // 
            this.buttonParamSetShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonParamSetShow.Enabled = false;
            this.buttonParamSetShow.Location = new System.Drawing.Point(13, 236);
            this.buttonParamSetShow.Name = "buttonParamSetShow";
            this.buttonParamSetShow.Size = new System.Drawing.Size(235, 23);
            this.buttonParamSetShow.TabIndex = 9;
            this.buttonParamSetShow.Text = "Показать данные";
            this.buttonParamSetShow.UseVisualStyleBackColor = true;
            this.buttonParamSetShow.Click += new System.EventHandler(this.buttonParamSetShow_Click);
            // 
            // buttonParamSetSave
            // 
            this.buttonParamSetSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonParamSetSave.Enabled = false;
            this.buttonParamSetSave.Location = new System.Drawing.Point(13, 294);
            this.buttonParamSetSave.Name = "buttonParamSetSave";
            this.buttonParamSetSave.Size = new System.Drawing.Size(236, 44);
            this.buttonParamSetSave.TabIndex = 10;
            this.buttonParamSetSave.Text = "Сохранить набор  \r\nи начать парсинг";
            this.buttonParamSetSave.UseVisualStyleBackColor = true;
            this.buttonParamSetSave.Click += new System.EventHandler(this.buttonParamSetSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Имя нового набора";
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Controls.Add(this.tabControl1);
            this.panelMain.Controls.Add(this.textBoxParamSetName);
            this.panelMain.Controls.Add(this.checkBoxUpdate);
            this.panelMain.Controls.Add(this.label10);
            this.panelMain.Controls.Add(this.numericUpDownUpdate);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Enabled = false;
            this.panelMain.Location = new System.Drawing.Point(254, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(367, 460);
            this.panelMain.TabIndex = 12;
            // 
            // buttonOptions
            // 
            this.buttonOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOptions.Location = new System.Drawing.Point(12, 444);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(236, 23);
            this.buttonOptions.TabIndex = 13;
            this.buttonOptions.Text = "Настройки соединения";
            this.buttonOptions.UseVisualStyleBackColor = true;
            this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 10);
            this.label1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonParamSetDelete
            // 
            this.buttonParamSetDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonParamSetDelete.Enabled = false;
            this.buttonParamSetDelete.Location = new System.Drawing.Point(13, 265);
            this.buttonParamSetDelete.Name = "buttonParamSetDelete";
            this.buttonParamSetDelete.Size = new System.Drawing.Size(235, 23);
            this.buttonParamSetDelete.TabIndex = 15;
            this.buttonParamSetDelete.Text = "Удалить набор данных";
            this.buttonParamSetDelete.UseVisualStyleBackColor = true;
            this.buttonParamSetDelete.Click += new System.EventHandler(this.buttonParamSetDelete_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 472);
            this.Controls.Add(this.buttonParamSetDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOptions);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.buttonParamSetSave);
            this.Controls.Add(this.buttonParamSetShow);
            this.Controls.Add(this.buttonParamSetAdd);
            this.Controls.Add(this.listBoxParamSet);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Парсер rabota.e1.ru";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUpdate)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBoxParamSet;
        private System.Windows.Forms.CheckBox checkBoxUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownUpdate;
        private System.Windows.Forms.ComboBox comboBoxPriceType;
        private System.Windows.Forms.CheckBox checkBoxOnlyPay;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox checkedListBoxEmploy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox checkedListBoxTimeJob;
        private System.Windows.Forms.ComboBox comboBoxCompanySize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBoxParamSetName;
        private System.Windows.Forms.CheckedListBox checkedListBoxEducation;
        private System.Windows.Forms.CheckedListBox checkedListBoxExp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox checkedListBoxRaion1;
        private System.Windows.Forms.CheckedListBox checkedListBoxRaion2;
        private System.Windows.Forms.Button buttonParamSetAdd;
        private System.Windows.Forms.Button buttonParamSetShow;
        private System.Windows.Forms.Button buttonParamSetSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxRubrics;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonParamSetDelete;
    }
}

