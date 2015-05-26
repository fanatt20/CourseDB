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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormForAdmin));
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
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
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
            this.mainFormTab.Size = new System.Drawing.Size(781, 421);
            this.mainFormTab.TabIndex = 0;
            this.mainFormTab.TabIndexChanged += new System.EventHandler(this.mainFormTab_TabIndexChanged);
            // 
            // mainInfoPage
            // 
            this.mainInfoPage.Controls.Add(this.infoPageSplitContainer);
            this.mainInfoPage.Location = new System.Drawing.Point(4, 22);
            this.mainInfoPage.Margin = new System.Windows.Forms.Padding(2);
            this.mainInfoPage.Name = "mainInfoPage";
            this.mainInfoPage.Padding = new System.Windows.Forms.Padding(2);
            this.mainInfoPage.Size = new System.Drawing.Size(773, 395);
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
            this.infoPageSplitContainer.Size = new System.Drawing.Size(769, 391);
            this.infoPageSplitContainer.SplitterDistance = 531;
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
            this.mainInfoDataGrid.Size = new System.Drawing.Size(533, 388);
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
            this.mainInfoTab.Size = new System.Drawing.Size(217, 388);
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
            this.mainInfoSelectPage.Size = new System.Drawing.Size(209, 362);
            this.mainInfoSelectPage.TabIndex = 0;
            this.mainInfoSelectPage.Text = "Выбрать";
            this.mainInfoSelectPage.UseVisualStyleBackColor = true;
            // 
            // selectCategoryValueListBox
            // 
            this.selectCategoryValueListBox.FormattingEnabled = true;
            this.selectCategoryValueListBox.Location = new System.Drawing.Point(5, 32);
            this.selectCategoryValueListBox.Name = "selectCategoryValueListBox";
            this.selectCategoryValueListBox.Size = new System.Drawing.Size(199, 251);
            this.selectCategoryValueListBox.TabIndex = 2;
            // 
            // selectCategoryComboBox
            // 
            this.selectCategoryComboBox.FormattingEnabled = true;
            this.selectCategoryComboBox.Items.AddRange(new object[] {
            "Контракты",
            "Позиции",
            "Связи",
            "Люди",
            "Определенные пользователем"});
            this.selectCategoryComboBox.Location = new System.Drawing.Point(5, 5);
            this.selectCategoryComboBox.Name = "selectCategoryComboBox";
            this.selectCategoryComboBox.Size = new System.Drawing.Size(199, 21);
            this.selectCategoryComboBox.TabIndex = 1;
            this.selectCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.mainInfoComboBox_SelectedIndexChanged);
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(5, 295);
            this.selectButton.Margin = new System.Windows.Forms.Padding(2);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(199, 63);
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
            this.mainInfoFilterPage.Size = new System.Drawing.Size(209, 362);
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
            this.filterButton.Location = new System.Drawing.Point(2, 323);
            this.filterButton.Margin = new System.Windows.Forms.Padding(2);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(204, 37);
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
            this.mainInfoSqlPage.Size = new System.Drawing.Size(209, 362);
            this.mainInfoSqlPage.TabIndex = 2;
            this.mainInfoSqlPage.Text = "SQL";
            this.mainInfoSqlPage.UseVisualStyleBackColor = true;
            // 
            // sqlExcecuteButton
            // 
            this.sqlExcecuteButton.Location = new System.Drawing.Point(5, 322);
            this.sqlExcecuteButton.Margin = new System.Windows.Forms.Padding(2);
            this.sqlExcecuteButton.Name = "sqlExcecuteButton";
            this.sqlExcecuteButton.Size = new System.Drawing.Size(200, 37);
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
            this.sqlAddToCollectionButton.Size = new System.Drawing.Size(200, 37);
            this.sqlAddToCollectionButton.TabIndex = 3;
            this.sqlAddToCollectionButton.Text = "Добавить в коллекцию";
            this.sqlAddToCollectionButton.UseVisualStyleBackColor = true;
            this.sqlAddToCollectionButton.Click += new System.EventHandler(this.sqlAddToCollectionButton_Click);
            // 
            // queryRichTextBox
            // 
            this.queryRichTextBox.Location = new System.Drawing.Point(3, 6);
            this.queryRichTextBox.Name = "queryRichTextBox";
            this.queryRichTextBox.Size = new System.Drawing.Size(204, 268);
            this.queryRichTextBox.TabIndex = 2;
            this.queryRichTextBox.Text = "";
            // 
            // mainActionPage
            // 
            this.mainActionPage.Controls.Add(this.bindingNavigator1);
            this.mainActionPage.Location = new System.Drawing.Point(4, 22);
            this.mainActionPage.Margin = new System.Windows.Forms.Padding(2);
            this.mainActionPage.Name = "mainActionPage";
            this.mainActionPage.Padding = new System.Windows.Forms.Padding(2);
            this.mainActionPage.Size = new System.Drawing.Size(773, 395);
            this.mainActionPage.TabIndex = 1;
            this.mainActionPage.Text = "Действия";
            this.mainActionPage.UseVisualStyleBackColor = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.bindingSource2;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripLabel2,
            this.toolStripComboBox2});
            this.bindingNavigator1.Location = new System.Drawing.Point(2, 2);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(769, 25);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(88, 22);
            this.toolStripLabel1.Text = "Выбрать отдел";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(117, 22);
            this.toolStripLabel2.Text = "Выбрать должность";
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 25);
            // 
            // MainFormForAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 440);
            this.Controls.Add(this.mainFormTab);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFormForAdmin";
            this.Text = "MainForm";
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
            this.mainActionPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
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
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.BindingSource bindingSource2;

    }
}