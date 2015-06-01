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
using System.Configuration;
using MyCourseWork.Utils;

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
            var connectionStringTemplate = ConfigurationManager.ConnectionStrings["MainDb"];
            if (connectionStringTemplate == null || string.IsNullOrEmpty(connectionStringTemplate.ConnectionString))
            {
                UserNotification.Error("Connection string is not defined. Please contact system administrator for further information");

            }
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionStringTemplate.ConnectionString)
            {
                UserID = loginLoginTextBox.Text,
                Password = loginPasswordTextBox.Text,
            };
            connection = new SqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                var newform = new MainFormForAdmin(connection);
                this.Hide();
                //loginLoginTextBox.Text = String.Empty;
                //loginPasswordTextBox.Text = String.Empty;
                newform.Show();
                newform.FormClosed += newform_FormClosed;
            }
            catch (Exception ex)
            {
                UserNotification.Error(ex.Message);
            }
            finally { connection.Close(); }

        }

        void newform_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = sender as MainFormForAdmin;
            if (form !=null)
            {
                form.FormClosed -= newform_FormClosed;
            }
            this.Show();
        }

        private void loginLoginButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 || e.KeyChar == (char)Keys.Enter)
                loginLoginButton.PerformClick();
        }
    }
}
