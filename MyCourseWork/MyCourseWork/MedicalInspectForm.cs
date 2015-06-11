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
    public partial class MedicalInspectForm : Form
    {
        private int humanID;
        private SqlConnection connection;
        public MedicalInspectForm(int humanID, SqlConnection connection)
        {
            this.humanID = humanID;
            this.connection = connection;
            InitializeComponent();
            FillMedicalInspectForm();

        }

        private void FillMedicalInspectForm()
        {
            try
            {
                connection.Open();
                var cmd = "select [Дата прохождения],[Состояние],[Комментарий] from [Меодосмотр] where HumanId=" + humanID;
                var adapter = new SqlDataAdapter(cmd, connection);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                var selectStates = connection.CreateCommand();
                selectStates.CommandText = "select * from MedicalStates";
                using (SqlDataReader reader = selectStates.ExecuteReader())
                {
                    comboBox1.Items.Clear();
                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        var state = new MedicalState(reader.GetInt32(0), reader.GetString(1));
                        comboBox1.Items.Add(state);
                        listBox1.Items.Add(state);
                    }
                }
            }
            finally
            {
                connection.Close();
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Close();
                connection.Open();
                var insert = connection.CreateCommand();
                insert.CommandText = @"Insert into MedicalInspectRegister values (@HumanID,@StateID,@DatePass,@Comment)";
                insert.Parameters.AddWithValue("HumanId", humanID);
                insert.Parameters.AddWithValue("StateID", (comboBox1.SelectedItem as MedicalState).Id);
                insert.Parameters.AddWithValue("@DatePass", monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd"));
                insert.Parameters.AddWithValue("@Comment", richTextBox1.Text);

                insert.ExecuteNonQuery();

                UserNotification.Info("Успешно добавленно!");
            }
            catch (Exception ex)
            {
                UserNotification.Error(ex.Message);

            }
            finally
            {
                connection.Close();
            }
            FillMedicalInspectForm();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                var insert = connection.CreateCommand();
                insert.CommandText = "Insert into MedicalStates values (@State)";
                insert.Parameters.AddWithValue("State", textBox1.Text);
                insert.ExecuteNonQuery();
                UserNotification.Info("Состояние успешно добавлено!");
            }
            catch (Exception ex)
            {
                UserNotification.Error(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            FillMedicalInspectForm();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (monthCalendar1.SelectionRange.Start != monthCalendar1.SelectionRange.End)
                monthCalendar1.SetDate(monthCalendar1.SelectionRange.Start);
        }

        public class MedicalState
        {
            public int Id { get; private set; }
            public string Name { get; private set; }
            public MedicalState(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public override string ToString()
            {
                return Name;
            }
        }
    }
}
