namespace MyCourseWork
{
    partial class MainFormForAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainFormTab = new System.Windows.Forms.TabControl();
            this.mainInfoPage = new System.Windows.Forms.TabPage();
            this.infoPageSplitContainer = new System.Windows.Forms.SplitContainer();
            this.mainInfoDataGrid = new System.Windows.Forms.DataGridView();
            this.mainInfoTab = new System.Windows.Forms.TabControl();
            this.mainInfoSelectPage = new System.Windows.Forms.TabPage();
            this.selectCategoryValueListBox = new System.Windows.Forms.ListBox();
            this.selectCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.mainInfoFilterPage = new System.Windows.Forms.TabPage();
            this.filterCompareTextBox = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.filterValueCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.filterOperationComboBox = new System.Windows.Forms.ComboBox();
            this.filterColumnComboBox = new System.Windows.Forms.ComboBox();
            this.mainInfoSqlPage = new System.Windows.Forms.TabPage();
            this.sqlExcecuteButton = new System.Windows.Forms.Button();
            this.sqlAddToCollectionButton = new System.Windows.Forms.Button();
            this.queryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.mainActionPage = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.actionsAddMemberPage = new System.Windows.Forms.TabPage();
            this.actionsAddContract = new System.Windows.Forms.TabPage();
            this.actionsHolidayPage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.courseWorkSecondVariantDataSet = new MyCourseWork.CourseWorkSecondVariantDataSet();
            this.absenceRegisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.absenceRegisterTableAdapter = new MyCourseWork.CourseWorkSecondVariantDataSetTableAdapters.AbsenceRegisterTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.addMemebrNameTextBox = new System.Windows.Forms.TextBox();
            this.addMemeberSurnameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addMemebrPatronimycTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addMemberBirthdayDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.addMemeberEducationRichTextBox = new System.Windows.Forms.RichTextBox();
            this.addMemberMedicalCardTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.addMemberComunicationDataGrid = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addMemberResetButton = new System.Windows.Forms.Button();
            this.addMemberSubmitButton = new System.Windows.Forms.Button();
            this.mainFormTab.SuspendLayout();
            this.mainInfoPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoPageSplitContainer)).BeginInit();
            this.infoPageSplitContainer.Panel1.SuspendLayout();
            this.infoPageSplitContainer.Panel2.SuspendLayout();
            this.infoPageSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainInfoDataGrid)).BeginInit();
            this.mainInfoTab.SuspendLayout();
            this.mainInfoSelectPage.SuspendLayout();
            this.mainInfoFilterPage.SuspendLayout();
            this.mainInfoSqlPage.SuspendLayout();
            this.mainActionPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.actionsAddMemberPage.SuspendLayout();
            this.actionsHolidayPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseWorkSecondVariantDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.absenceRegisterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addMemberComunicationDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // mainFormTab
            // 
            this.mainFormTab.Controls.Add(this.mainInfoPage);
            this.mainFormTab.Controls.Add(this.mainActionPage);
            this.mainFormTab.Location = new System.Drawing.Point(9, 10);
            this.mainFormTab.Margin = new System.Windows.Forms.Padding(2);
            this.mainFormTab.Name = "mainFormTab";
            this.mainFormTab.SelectedIndex = 0;
            this.mainFormTab.Size = new System.Drawing.Size(974, 421);
            this.mainFormTab.TabIndex = 0;
            this.mainFormTab.SelectedIndexChanged += new System.EventHandler(this.mainFormTab_TabIndexChanged);
            // 
            // mainInfoPage
            // 
            this.mainInfoPage.Controls.Add(this.infoPageSplitContainer);
            this.mainInfoPage.Location = new System.Drawing.Point(4, 22);
            this.mainInfoPage.Margin = new System.Windows.Forms.Padding(2);
            this.mainInfoPage.Name = "mainInfoPage";
            this.mainInfoPage.Padding = new System.Windows.Forms.Padding(2);
            this.mainInfoPage.Size = new System.Drawing.Size(966, 395);
            this.mainInfoPage.TabIndex = 0;
            this.mainInfoPage.Text = "Информация";
            this.mainInfoPage.UseVisualStyleBackColor = true;
            // 
            // infoPageSplitContainer
            // 
            this.infoPageSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoPageSplitContainer.Location = new System.Drawing.Point(2, 2);
            this.infoPageSplitContainer.Margin = new System.Windows.Forms.Padding(2);
            this.infoPageSplitContainer.Name = "infoPageSplitContainer";
            // 
            // infoPageSplitContainer.Panel1
            // 
            this.infoPageSplitContainer.Panel1.Controls.Add(this.mainInfoDataGrid);
            // 
            // infoPageSplitContainer.Panel2
            // 
            this.infoPageSplitContainer.Panel2.Controls.Add(this.mainInfoTab);
            this.infoPageSplitContainer.Size = new System.Drawing.Size(962, 391);
            this.infoPageSplitContainer.SplitterDistance = 726;
            this.infoPageSplitContainer.SplitterWidth = 3;
            this.infoPageSplitContainer.TabIndex = 0;
            // 
            // mainInfoDataGrid
            // 
            this.mainInfoDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainInfoDataGrid.Location = new System.Drawing.Point(2, 2);
            this.mainInfoDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.mainInfoDataGrid.Name = "mainInfoDataGrid";
            this.mainInfoDataGrid.RowTemplate.Height = 24;
            this.mainInfoDataGrid.Size = new System.Drawing.Size(722, 388);
            this.mainInfoDataGrid.TabIndex = 0;
            // 
            // mainInfoTab
            // 
            this.mainInfoTab.Controls.Add(this.mainInfoSelectPage);
            this.mainInfoTab.Controls.Add(this.mainInfoFilterPage);
            this.mainInfoTab.Controls.Add(this.mainInfoSqlPage);
            this.mainInfoTab.Location = new System.Drawing.Point(2, 2);
            this.mainInfoTab.Margin = new System.Windows.Forms.Padding(2);
            this.mainInfoTab.Name = "mainInfoTab";
            this.mainInfoTab.SelectedIndex = 0;
            this.mainInfoTab.Size = new System.Drawing.Size(229, 388);
            this.mainInfoTab.TabIndex = 0;
            // 
            // mainInfoSelectPage
            // 
            this.mainInfoSelectPage.Controls.Add(this.selectCategoryValueListBox);
            this.mainInfoSelectPage.Controls.Add(this.selectCategoryComboBox);
            this.mainInfoSelectPage.Controls.Add(this.selectButton);
            this.mainInfoSelectPage.Location = new System.Drawing.Point(4, 22);
            this.mainInfoSelectPage.Margin = new System.Windows.Forms.Padding(2);
            this.mainInfoSelectPage.Name = "mainInfoSelectPage";
            this.mainInfoSelectPage.Padding = new System.Windows.Forms.Padding(2);
            this.mainInfoSelectPage.Size = new System.Drawing.Size(221, 362);
            this.mainInfoSelectPage.TabIndex = 0;
            this.mainInfoSelectPage.Text = "Выбрать";
            this.mainInfoSelectPage.UseVisualStyleBackColor = true;
            // 
            // selectCategoryValueListBox
            // 
            this.selectCategoryValueListBox.FormattingEnabled = true;
            this.selectCategoryValueListBox.Location = new System.Drawing.Point(5, 32);
            this.selectCategoryValueListBox.Name = "selectCategoryValueListBox";
            this.selectCategoryValueListBox.Size = new System.Drawing.Size(211, 251);
            this.selectCategoryValueListBox.TabIndex = 2;
            // 
            // selectCategoryComboBox
            // 
            this.selectCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectCategoryComboBox.FormattingEnabled = true;
            this.selectCategoryComboBox.Items.AddRange(new object[] {
            "Контракты",
            "Позиции",
            "Связи",
            "Люди",
            "Определенные пользователем"});
            this.selectCategoryComboBox.Location = new System.Drawing.Point(5, 5);
            this.selectCategoryComboBox.Name = "selectCategoryComboBox";
            this.selectCategoryComboBox.Size = new System.Drawing.Size(211, 21);
            this.selectCategoryComboBox.TabIndex = 1;
            this.selectCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.mainInfoComboBox_SelectedIndexChanged);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(5, 295);
            this.selectButton.Margin = new System.Windows.Forms.Padding(2);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(211, 63);
            this.selectButton.TabIndex = 0;
            this.selectButton.Text = "Выбрать";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainInfoFilterPage
            // 
            this.mainInfoFilterPage.Controls.Add(this.filterCompareTextBox);
            this.mainInfoFilterPage.Controls.Add(this.filterButton);
            this.mainInfoFilterPage.Controls.Add(this.filterValueCheckedListBox);
            this.mainInfoFilterPage.Controls.Add(this.filterOperationComboBox);
            this.mainInfoFilterPage.Controls.Add(this.filterColumnComboBox);
            this.mainInfoFilterPage.Location = new System.Drawing.Point(4, 22);
            this.mainInfoFilterPage.Margin = new System.Windows.Forms.Padding(2);
            this.mainInfoFilterPage.Name = "mainInfoFilterPage";
            this.mainInfoFilterPage.Padding = new System.Windows.Forms.Padding(2);
            this.mainInfoFilterPage.Size = new System.Drawing.Size(221, 362);
            this.mainInfoFilterPage.TabIndex = 1;
            this.mainInfoFilterPage.Text = "Фильтровать";
            this.mainInfoFilterPage.UseVisualStyleBackColor = true;
            // 
            // filterCompareTextBox
            // 
            this.filterCompareTextBox.Location = new System.Drawing.Point(61, 140);
            this.filterCompareTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.filterCompareTextBox.Name = "filterCompareTextBox";
            this.filterCompareTextBox.Size = new System.Drawing.Size(146, 20);
            this.filterCompareTextBox.TabIndex = 4;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(4, 300);
            this.filterButton.Margin = new System.Windows.Forms.Padding(2);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(213, 58);
            this.filterButton.TabIndex = 3;
            this.filterButton.Text = "Фильтровать";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // filterValueCheckedListBox
            // 
            this.filterValueCheckedListBox.FormattingEnabled = true;
            this.filterValueCheckedListBox.Location = new System.Drawing.Point(44, 172);
            this.filterValueCheckedListBox.Margin = new System.Windows.Forms.Padding(2);
            this.filterValueCheckedListBox.Name = "filterValueCheckedListBox";
            this.filterValueCheckedListBox.Size = new System.Drawing.Size(163, 124);
            this.filterValueCheckedListBox.TabIndex = 2;
            // 
            // filterOperationComboBox
            // 
            this.filterOperationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterOperationComboBox.FormattingEnabled = true;
            this.filterOperationComboBox.Items.AddRange(new object[] {
            "Выбрать значения",
            "Больше чем",
            "Меньше чем",
            "Больше либо равно",
            "Меньше либо равно",
            "Равно"});
            this.filterOperationComboBox.Location = new System.Drawing.Point(61, 81);
            this.filterOperationComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.filterOperationComboBox.Name = "filterOperationComboBox";
            this.filterOperationComboBox.Size = new System.Drawing.Size(146, 21);
            this.filterOperationComboBox.TabIndex = 1;
            // 
            // filterColumnComboBox
            // 
            this.filterColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterColumnComboBox.FormattingEnabled = true;
            this.filterColumnComboBox.Location = new System.Drawing.Point(61, 32);
            this.filterColumnComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.filterColumnComboBox.Name = "filterColumnComboBox";
            this.filterColumnComboBox.Size = new System.Drawing.Size(146, 21);
            this.filterColumnComboBox.TabIndex = 0;
            this.filterColumnComboBox.SelectedIndexChanged += new System.EventHandler(this.filterColumnComboBox_SelectedIndexChanged);
            // 
            // mainInfoSqlPage
            // 
            this.mainInfoSqlPage.Controls.Add(this.sqlExcecuteButton);
            this.mainInfoSqlPage.Controls.Add(this.sqlAddToCollectionButton);
            this.mainInfoSqlPage.Controls.Add(this.queryRichTextBox);
            this.mainInfoSqlPage.Location = new System.Drawing.Point(4, 22);
            this.mainInfoSqlPage.Name = "mainInfoSqlPage";
            this.mainInfoSqlPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainInfoSqlPage.Size = new System.Drawing.Size(221, 362);
            this.mainInfoSqlPage.TabIndex = 2;
            this.mainInfoSqlPage.Text = "SQL";
            this.mainInfoSqlPage.UseVisualStyleBackColor = true;
            // 
            // sqlExcecuteButton
            // 
            this.sqlExcecuteButton.Location = new System.Drawing.Point(5, 322);
            this.sqlExcecuteButton.Margin = new System.Windows.Forms.Padding(2);
            this.sqlExcecuteButton.Name = "sqlExcecuteButton";
            this.sqlExcecuteButton.Size = new System.Drawing.Size(210, 37);
            this.sqlExcecuteButton.TabIndex = 4;
            this.sqlExcecuteButton.Text = "Выполнить запрос";
            this.sqlExcecuteButton.UseVisualStyleBackColor = true;
            this.sqlExcecuteButton.Click += new System.EventHandler(this.sqlExcecuteButton_Click);
            // 
            // sqlAddToCollectionButton
            // 
            this.sqlAddToCollectionButton.Location = new System.Drawing.Point(5, 280);
            this.sqlAddToCollectionButton.Margin = new System.Windows.Forms.Padding(2);
            this.sqlAddToCollectionButton.Name = "sqlAddToCollectionButton";
            this.sqlAddToCollectionButton.Size = new System.Drawing.Size(210, 37);
            this.sqlAddToCollectionButton.TabIndex = 3;
            this.sqlAddToCollectionButton.Text = "Добавить в коллекцию";
            this.sqlAddToCollectionButton.UseVisualStyleBackColor = true;
            this.sqlAddToCollectionButton.Click += new System.EventHandler(this.sqlAddToCollectionButton_Click);
            // 
            // queryRichTextBox
            // 
            this.queryRichTextBox.Location = new System.Drawing.Point(3, 6);
            this.queryRichTextBox.Name = "queryRichTextBox";
            this.queryRichTextBox.Size = new System.Drawing.Size(212, 268);
            this.queryRichTextBox.TabIndex = 2;
            this.queryRichTextBox.Text = "";
            // 
            // mainActionPage
            // 
            this.mainActionPage.Controls.Add(this.tabControl1);
            this.mainActionPage.Location = new System.Drawing.Point(4, 22);
            this.mainActionPage.Margin = new System.Windows.Forms.Padding(2);
            this.mainActionPage.Name = "mainActionPage";
            this.mainActionPage.Padding = new System.Windows.Forms.Padding(2);
            this.mainActionPage.Size = new System.Drawing.Size(966, 395);
            this.mainActionPage.TabIndex = 1;
            this.mainActionPage.Text = "Действия";
            this.mainActionPage.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.actionsAddMemberPage);
            this.tabControl1.Controls.Add(this.actionsAddContract);
            this.tabControl1.Controls.Add(this.actionsHolidayPage);
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(956, 385);
            this.tabControl1.TabIndex = 0;
            // 
            // actionsAddMemberPage
            // 
            this.actionsAddMemberPage.Controls.Add(this.addMemberSubmitButton);
            this.actionsAddMemberPage.Controls.Add(this.addMemberResetButton);
            this.actionsAddMemberPage.Controls.Add(this.label7);
            this.actionsAddMemberPage.Controls.Add(this.addMemberComunicationDataGrid);
            this.actionsAddMemberPage.Controls.Add(this.label6);
            this.actionsAddMemberPage.Controls.Add(this.label5);
            this.actionsAddMemberPage.Controls.Add(this.addMemberMedicalCardTextBox);
            this.actionsAddMemberPage.Controls.Add(this.addMemeberEducationRichTextBox);
            this.actionsAddMemberPage.Controls.Add(this.label4);
            this.actionsAddMemberPage.Controls.Add(this.addMemberBirthdayDatePicker);
            this.actionsAddMemberPage.Controls.Add(this.addMemebrPatronimycTextBox);
            this.actionsAddMemberPage.Controls.Add(this.label3);
            this.actionsAddMemberPage.Controls.Add(this.addMemeberSurnameTextBox);
            this.actionsAddMemberPage.Controls.Add(this.label2);
            this.actionsAddMemberPage.Controls.Add(this.addMemebrNameTextBox);
            this.actionsAddMemberPage.Controls.Add(this.label1);
            this.actionsAddMemberPage.Location = new System.Drawing.Point(4, 22);
            this.actionsAddMemberPage.Name = "actionsAddMemberPage";
            this.actionsAddMemberPage.Padding = new System.Windows.Forms.Padding(3);
            this.actionsAddMemberPage.Size = new System.Drawing.Size(948, 359);
            this.actionsAddMemberPage.TabIndex = 0;
            this.actionsAddMemberPage.Text = "Добавитть человека в систему";
            this.actionsAddMemberPage.UseVisualStyleBackColor = true;
            // 
            // actionsAddContract
            // 
            this.actionsAddContract.Location = new System.Drawing.Point(4, 22);
            this.actionsAddContract.Name = "actionsAddContract";
            this.actionsAddContract.Padding = new System.Windows.Forms.Padding(3);
            this.actionsAddContract.Size = new System.Drawing.Size(948, 359);
            this.actionsAddContract.TabIndex = 1;
            this.actionsAddContract.Text = "Добавить контракт";
            this.actionsAddContract.UseVisualStyleBackColor = true;
            // 
            // actionsHolidayPage
            // 
            this.actionsHolidayPage.Controls.Add(this.dataGridView1);
            this.actionsHolidayPage.Location = new System.Drawing.Point(4, 22);
            this.actionsHolidayPage.Name = "actionsHolidayPage";
            this.actionsHolidayPage.Padding = new System.Windows.Forms.Padding(3);
            this.actionsHolidayPage.Size = new System.Drawing.Size(948, 359);
            this.actionsHolidayPage.TabIndex = 2;
            this.actionsHolidayPage.Text = "Отпускии и пропуски";
            this.actionsHolidayPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(936, 347);
            this.dataGridView1.TabIndex = 0;
            // 
            // courseWorkSecondVariantDataSet
            // 
            this.courseWorkSecondVariantDataSet.DataSetName = "CourseWorkSecondVariantDataSet";
            this.courseWorkSecondVariantDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // absenceRegisterBindingSource
            // 
            this.absenceRegisterBindingSource.DataMember = "AbsenceRegister";
            this.absenceRegisterBindingSource.DataSource = this.courseWorkSecondVariantDataSet;
            // 
            // absenceRegisterTableAdapter
            // 
            this.absenceRegisterTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // addMemebrNameTextBox
            // 
            this.addMemebrNameTextBox.Location = new System.Drawing.Point(132, 19);
            this.addMemebrNameTextBox.Name = "addMemebrNameTextBox";
            this.addMemebrNameTextBox.Size = new System.Drawing.Size(204, 20);
            this.addMemebrNameTextBox.TabIndex = 1;
            // 
            // addMemeberSurnameTextBox
            // 
            this.addMemeberSurnameTextBox.Location = new System.Drawing.Point(132, 45);
            this.addMemeberSurnameTextBox.Name = "addMemeberSurnameTextBox";
            this.addMemeberSurnameTextBox.Size = new System.Drawing.Size(204, 20);
            this.addMemeberSurnameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // addMemebrPatronimycTextBox
            // 
            this.addMemebrPatronimycTextBox.Location = new System.Drawing.Point(132, 71);
            this.addMemebrPatronimycTextBox.Name = "addMemebrPatronimycTextBox";
            this.addMemebrPatronimycTextBox.Size = new System.Drawing.Size(204, 20);
            this.addMemebrPatronimycTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // addMemberBirthdayDatePicker
            // 
            this.addMemberBirthdayDatePicker.Location = new System.Drawing.Point(132, 97);
            this.addMemberBirthdayDatePicker.Name = "addMemberBirthdayDatePicker";
            this.addMemberBirthdayDatePicker.Size = new System.Drawing.Size(204, 20);
            this.addMemberBirthdayDatePicker.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // addMemeberEducationRichTextBox
            // 
            this.addMemeberEducationRichTextBox.Location = new System.Drawing.Point(132, 149);
            this.addMemeberEducationRichTextBox.Name = "addMemeberEducationRichTextBox";
            this.addMemeberEducationRichTextBox.Size = new System.Drawing.Size(204, 204);
            this.addMemeberEducationRichTextBox.TabIndex = 8;
            this.addMemeberEducationRichTextBox.Text = "";
            // 
            // addMemberMedicalCardTextBox
            // 
            this.addMemberMedicalCardTextBox.Location = new System.Drawing.Point(132, 123);
            this.addMemberMedicalCardTextBox.Name = "addMemberMedicalCardTextBox";
            this.addMemberMedicalCardTextBox.Size = new System.Drawing.Size(204, 20);
            this.addMemberMedicalCardTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // addMemberComunicationDataGrid
            // 
            this.addMemberComunicationDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addMemberComunicationDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Value});
            this.addMemberComunicationDataGrid.Location = new System.Drawing.Point(616, 19);
            this.addMemberComunicationDataGrid.Name = "addMemberComunicationDataGrid";
            this.addMemberComunicationDataGrid.Size = new System.Drawing.Size(236, 220);
            this.addMemberComunicationDataGrid.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(575, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "label7";
            // 
            // Type
            // 
            this.Type.Frozen = true;
            this.Type.HeaderText = "Тип";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Value
            // 
            this.Value.HeaderText = "Значение";
            this.Value.Name = "Value";
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // addMemberResetButton
            // 
            this.addMemberResetButton.Location = new System.Drawing.Point(569, 289);
            this.addMemberResetButton.Name = "addMemberResetButton";
            this.addMemberResetButton.Size = new System.Drawing.Size(112, 40);
            this.addMemberResetButton.TabIndex = 14;
            this.addMemberResetButton.Text = "Отменить";
            this.addMemberResetButton.UseVisualStyleBackColor = true;
            // 
            // addMemberSubmitButton
            // 
            this.addMemberSubmitButton.Location = new System.Drawing.Point(748, 294);
            this.addMemberSubmitButton.Name = "addMemberSubmitButton";
            this.addMemberSubmitButton.Size = new System.Drawing.Size(125, 34);
            this.addMemberSubmitButton.TabIndex = 15;
            this.addMemberSubmitButton.Text = "Добавить";
            this.addMemberSubmitButton.UseVisualStyleBackColor = true;
            this.addMemberSubmitButton.Click += new System.EventHandler(this.addMemberSubmitButton_Click);
            // 
            // MainFormForAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 440);
            this.Controls.Add(this.mainFormTab);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFormForAdmin";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainFormForAdmin_Load);
            this.mainFormTab.ResumeLayout(false);
            this.mainInfoPage.ResumeLayout(false);
            this.infoPageSplitContainer.Panel1.ResumeLayout(false);
            this.infoPageSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoPageSplitContainer)).EndInit();
            this.infoPageSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainInfoDataGrid)).EndInit();
            this.mainInfoTab.ResumeLayout(false);
            this.mainInfoSelectPage.ResumeLayout(false);
            this.mainInfoFilterPage.ResumeLayout(false);
            this.mainInfoFilterPage.PerformLayout();
            this.mainInfoSqlPage.ResumeLayout(false);
            this.mainActionPage.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.actionsAddMemberPage.ResumeLayout(false);
            this.actionsAddMemberPage.PerformLayout();
            this.actionsHolidayPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseWorkSecondVariantDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.absenceRegisterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addMemberComunicationDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainFormTab;
        private System.Windows.Forms.TabPage mainInfoPage;
        private System.Windows.Forms.SplitContainer infoPageSplitContainer;
        private System.Windows.Forms.DataGridView mainInfoDataGrid;
        private System.Windows.Forms.TabPage mainActionPage;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TabControl mainInfoTab;
        private System.Windows.Forms.TabPage mainInfoSelectPage;
        private System.Windows.Forms.TabPage mainInfoFilterPage;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.CheckedListBox filterValueCheckedListBox;
        private System.Windows.Forms.ComboBox filterOperationComboBox;
        private System.Windows.Forms.ComboBox filterColumnComboBox;
        private System.Windows.Forms.TextBox filterCompareTextBox;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.ComboBox selectCategoryComboBox;
        private System.Windows.Forms.TabPage mainInfoSqlPage;
        private System.Windows.Forms.RichTextBox queryRichTextBox;
        private System.Windows.Forms.ListBox selectCategoryValueListBox;
        private System.Windows.Forms.Button sqlExcecuteButton;
        private System.Windows.Forms.Button sqlAddToCollectionButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage actionsAddMemberPage;
        private System.Windows.Forms.TabPage actionsAddContract;
        private System.Windows.Forms.TabPage actionsHolidayPage;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CourseWorkSecondVariantDataSet courseWorkSecondVariantDataSet;
        private System.Windows.Forms.BindingSource absenceRegisterBindingSource;
        private CourseWorkSecondVariantDataSetTableAdapters.AbsenceRegisterTableAdapter absenceRegisterTableAdapter;
        private System.Windows.Forms.TextBox addMemebrPatronimycTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addMemeberSurnameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addMemebrNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView addMemberComunicationDataGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addMemberMedicalCardTextBox;
        private System.Windows.Forms.RichTextBox addMemeberEducationRichTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker addMemberBirthdayDatePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button addMemberSubmitButton;
        private System.Windows.Forms.Button addMemberResetButton;

    }
}