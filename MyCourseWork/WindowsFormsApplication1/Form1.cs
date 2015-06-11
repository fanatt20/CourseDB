using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.Отсутствия' table. You can move, or remove it, as needed.
            this.ОтсутствияTableAdapter.Fill(this.DataSet2.Отсутствия);
            // TODO: This line of code loads data into the 'DataSet1.Рассписание' table. You can move, or remove it, as needed.
            this.РассписаниеTableAdapter.Fill(this.DataSet1.Рассписание);


            this.reportViewer1.RefreshReport();
        }
    }
}
