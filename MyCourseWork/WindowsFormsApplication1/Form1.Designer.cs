namespace WindowsFormsApplication1
{
    partial class Form1
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.РассписаниеBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new WindowsFormsApplication1.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.РассписаниеTableAdapter = new WindowsFormsApplication1.DataSet1TableAdapters.РассписаниеTableAdapter();
            this.DataSet2 = new WindowsFormsApplication1.DataSet2();
            this.ОтсутствияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ОтсутствияTableAdapter = new WindowsFormsApplication1.DataSet2TableAdapters.ОтсутствияTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.РассписаниеBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ОтсутствияBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // РассписаниеBindingSource
            // 
            this.РассписаниеBindingSource.DataMember = "Рассписание";
            this.РассписаниеBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ОтсутствияBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(754, 325);
            this.reportViewer1.TabIndex = 0;
            // 
            // РассписаниеTableAdapter
            // 
            this.РассписаниеTableAdapter.ClearBeforeFill = true;
            // 
            // DataSet2
            // 
            this.DataSet2.DataSetName = "DataSet2";
            this.DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ОтсутствияBindingSource
            // 
            this.ОтсутствияBindingSource.DataMember = "Отсутствия";
            this.ОтсутствияBindingSource.DataSource = this.DataSet2;
            // 
            // ОтсутствияTableAdapter
            // 
            this.ОтсутствияTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 325);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.РассписаниеBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ОтсутствияBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource РассписаниеBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.РассписаниеTableAdapter РассписаниеTableAdapter;
        private System.Windows.Forms.BindingSource ОтсутствияBindingSource;
        private DataSet2 DataSet2;
        private DataSet2TableAdapters.ОтсутствияTableAdapter ОтсутствияTableAdapter;


    }
}

