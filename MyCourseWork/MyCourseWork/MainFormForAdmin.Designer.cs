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
            this.mainInfoFilterPage = new System.Windows.Forms.TabPage();
            this.filterCompareTextBox = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.filterValueCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.filterOperationComboBox = new System.Windows.Forms.ComboBox();
            this.filterColumnComboBox = new System.Windows.Forms.ComboBox();
            this.mainActionPage = new System.Windows.Forms.TabPage();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainFormTab
            // 
            this.mainFormTab.Controls.Add(this.mainInfoPage);
            this.mainFormTab.Controls.Add(this.mainActionPage);
            this.mainFormTab.Location = new System.Drawing.Point(12, 12);
            this.mainFormTab.Name = "mainFormTab";
            this.mainFormTab.SelectedIndex = 0;
            this.mainFormTab.Size = new System.Drawing.Size(975, 518);
            this.mainFormTab.TabIndex = 0;
            // 
            // mainInfoPage
            // 
            this.mainInfoPage.Controls.Add(this.infoPageSplitContainer);
            this.mainInfoPage.Location = new System.Drawing.Point(4, 25);
            this.mainInfoPage.Name = "mainInfoPage";
            this.mainInfoPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainInfoPage.Size = new System.Drawing.Size(967, 489);
            this.mainInfoPage.TabIndex = 0;
            this.mainInfoPage.Text = "Информация";
            this.mainInfoPage.UseVisualStyleBackColor = true;
            // 
            // infoPageSplitContainer
            // 
            this.infoPageSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoPageSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.infoPageSplitContainer.Name = "infoPageSplitContainer";
            // 
            // infoPageSplitContainer.Panel1
            // 
            this.infoPageSplitContainer.Panel1.Controls.Add(this.mainInfoDataGrid);
            // 
            // infoPageSplitContainer.Panel2
            // 
            this.infoPageSplitContainer.Panel2.Controls.Add(this.mainInfoTab);
            this.infoPageSplitContainer.Size = new System.Drawing.Size(961, 483);
            this.infoPageSplitContainer.SplitterDistance = 665;
            this.infoPageSplitContainer.TabIndex = 0;
            // 
            // mainInfoDataGrid
            // 
            this.mainInfoDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainInfoDataGrid.Location = new System.Drawing.Point(3, 3);
            this.mainInfoDataGrid.Name = "mainInfoDataGrid";
            this.mainInfoDataGrid.RowTemplate.Height = 24;
            this.mainInfoDataGrid.Size = new System.Drawing.Size(659, 477);
            this.mainInfoDataGrid.TabIndex = 0;
            // 
            // mainInfoTab
            // 
            this.mainInfoTab.Controls.Add(this.mainInfoSelectPage);
            this.mainInfoTab.Controls.Add(this.mainInfoFilterPage);
            this.mainInfoTab.Location = new System.Drawing.Point(3, 3);
            this.mainInfoTab.Name = "mainInfoTab";
            this.mainInfoTab.SelectedIndex = 0;
            this.mainInfoTab.Size = new System.Drawing.Size(289, 477);
            this.mainInfoTab.TabIndex = 0;
            // 
            // mainInfoSelectPage
            // 
            this.mainInfoSelectPage.Controls.Add(this.button1);
            this.mainInfoSelectPage.Location = new System.Drawing.Point(4, 25);
            this.mainInfoSelectPage.Name = "mainInfoSelectPage";
            this.mainInfoSelectPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainInfoSelectPage.Size = new System.Drawing.Size(281, 448);
            this.mainInfoSelectPage.TabIndex = 0;
            this.mainInfoSelectPage.Text = "Выбрать";
            this.mainInfoSelectPage.UseVisualStyleBackColor = true;
            // 
            // mainInfoFilterPage
            // 
            this.mainInfoFilterPage.Controls.Add(this.filterCompareTextBox);
            this.mainInfoFilterPage.Controls.Add(this.filterButton);
            this.mainInfoFilterPage.Controls.Add(this.filterValueCheckedListBox);
            this.mainInfoFilterPage.Controls.Add(this.filterOperationComboBox);
            this.mainInfoFilterPage.Controls.Add(this.filterColumnComboBox);
            this.mainInfoFilterPage.Location = new System.Drawing.Point(4, 25);
            this.mainInfoFilterPage.Name = "mainInfoFilterPage";
            this.mainInfoFilterPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainInfoFilterPage.Size = new System.Drawing.Size(281, 448);
            this.mainInfoFilterPage.TabIndex = 1;
            this.mainInfoFilterPage.Text = "Фильтровать";
            this.mainInfoFilterPage.UseVisualStyleBackColor = true;
            // 
            // filterCompareTextBox
            // 
            this.filterCompareTextBox.Location = new System.Drawing.Point(81, 172);
            this.filterCompareTextBox.Name = "filterCompareTextBox";
            this.filterCompareTextBox.Size = new System.Drawing.Size(194, 22);
            this.filterCompareTextBox.TabIndex = 4;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(3, 397);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(272, 45);
            this.filterButton.TabIndex = 3;
            this.filterButton.Text = "Фильтровать";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // filterValueCheckedListBox
            // 
            this.filterValueCheckedListBox.FormattingEnabled = true;
            this.filterValueCheckedListBox.Location = new System.Drawing.Point(59, 212);
            this.filterValueCheckedListBox.Name = "filterValueCheckedListBox";
            this.filterValueCheckedListBox.Size = new System.Drawing.Size(216, 174);
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
            this.filterOperationComboBox.Location = new System.Drawing.Point(81, 100);
            this.filterOperationComboBox.Name = "filterOperationComboBox";
            this.filterOperationComboBox.Size = new System.Drawing.Size(194, 24);
            this.filterOperationComboBox.TabIndex = 1;
            // 
            // filterColumnComboBox
            // 
            this.filterColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterColumnComboBox.FormattingEnabled = true;
            this.filterColumnComboBox.Location = new System.Drawing.Point(81, 39);
            this.filterColumnComboBox.Name = "filterColumnComboBox";
            this.filterColumnComboBox.Size = new System.Drawing.Size(194, 24);
            this.filterColumnComboBox.TabIndex = 0;
            this.filterColumnComboBox.SelectedIndexChanged += new System.EventHandler(this.filterColumnComboBox_SelectedIndexChanged);
            // 
            // mainActionPage
            // 
            this.mainActionPage.Location = new System.Drawing.Point(4, 25);
            this.mainActionPage.Name = "mainActionPage";
            this.mainActionPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainActionPage.Size = new System.Drawing.Size(967, 489);
            this.mainActionPage.TabIndex = 1;
            this.mainActionPage.Text = "Действия";
            this.mainActionPage.UseVisualStyleBackColor = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainFormForAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 542);
            this.Controls.Add(this.mainFormTab);
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
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
        private System.Windows.Forms.Button button1;

    }
}