using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyCourseWork
{
    public partial class loginForm : Form
    {
        private SqlConnection connection;
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginLoginButton_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                UserID = loginLoginTextBox.Text,
                Password = loginPasswordTextBox.Text,
                IntegratedSecurity = false,
                DataSource = @"VNZK\SQLEXPRESS",
                Pooling = true
            };
            connection = new SqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                var newform = new MainFormForAdmin(connection);
                this.Hide();
                newform.Show();
                newform.FormClosed += newform_FormClosed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { connection.Close(); }

        }

        void newform_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void loginLoginButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 || e.KeyChar == (char)Keys.Enter)
                loginLoginButton.PerformClick();
        }
    }
}
