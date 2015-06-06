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
using MyCourseWork.Utils;

namespace MyCourseWork
{
    public partial class AddRequirements : Form
    {
        SqlConnection connect;
        public AddRequirements( SqlConnection connection)
        {
            InitializeComponent();
            connect = connection;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                var command = connect.CreateCommand();
                command.CommandText="Insert into Requirements values (@req)";
                command.Parameters.AddWithValue("req", textBox1.Text);
                command.ExecuteNonQuery();

                UserNotification.Info("Требование успешно добавлено");
            }
            catch (Exception ex) { UserNotification.Error(ex.Message); }
            finally { connect.Close(); }

        }
    }
}
