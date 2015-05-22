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
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.Common;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        #region Constants
        //Filter ComboBox Constatnts
        const byte _filterByValue = 0;
        const byte _filterMoreThan = 1;
        const byte _filterMoreThanOrEqual = 2;
        const byte _filterLessThan = 3;
        const byte _filterLessThanOrEqual = 4;
        const byte _filerEqual = 5;
        //Select global info ComboBox  constants
        const byte _categoryHuman = 0;
        const byte _categoryContracts = 1;
        const byte _categoryMedicalInspect = 2;
        const byte _categoryAbsence = 3;
        //for CheckBox in filters
        const string _emptyCell = "EmptyCell";
        //for datagridview 
        const byte _uncommitedRow = 1;
        #endregion
        #region User functions
        private void ReadToDataGridViewFromSqlDataReader(SqlDataReader reader)
        {
            globalInfoDatagrid.Columns.Clear();
            globalInfoDatagrid.Rows.Clear();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                globalInfoDatagrid.Columns.Add(reader.GetName(i), reader.GetName(i));
            }
            DataGridViewRow row = new DataGridViewRow();
            while (reader.Read())
            {


                globalInfoDatagrid.Rows.Add(reader[0], reader[1], reader[2], reader[3]);

            }

        }

        private Dictionary<int, T> GetColumnCollection<T>(int index, DataGridView table)
        {
            var result = new Dictionary<int, T>();
            for (int i = 0; i < table.Rows.Count-_uncommitedRow; i++)
                result.Add(i, (T)table.Rows[i].Cells[index].Value);
            return result;
        }


        #endregion

        RoleInDB userRole = RoleInDB.Nothing;
        public Form1()
        {
            InitializeComponent();

            globalInfoDatagrid.Columns.CollectionChanged += Columns_CollectionChanged;
            Columns_CollectionChanged(null, EventArgs.Empty);
            filtersColumnSelector.SelectedIndexChanged += filtersColumnSelector_SelectedIndexChanged;
        }

        void filtersColumnSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = filtersColumnSelector.SelectedIndex;
            filtersCheckedListBox.Items.Clear();
            var cellValue = "";
            for (int i = 0; i < globalInfoDatagrid.Rows.Count - _uncommitedRow; i++)
            {
                cellValue = (string)globalInfoDatagrid.Rows[i].Cells[selectedIndex].Value ?? _emptyCell;

                if (!filtersCheckedListBox.Items.Contains(cellValue))
                    filtersCheckedListBox.Items.Add(cellValue);
            }

        }

        void Columns_CollectionChanged(object sender, EventArgs e)
        {

            filtersColumnSelector.Items.Clear();
            foreach (DataGridViewColumn name in globalInfoDatagrid.Columns)
            {
                filtersColumnSelector.Items.Add(name.Name);

            }
        }

        private void schudeleAllowChangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            schudeleDataGrid.ReadOnly = !schudeleDataGrid.ReadOnly;
        }

        private void staffAllowChangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            globalInfoDatagrid.ReadOnly = !globalInfoDatagrid.ReadOnly;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void selectGlobalInfoButton_Click(object sender, EventArgs e)
        {
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (filtersColumnSelector.SelectedIndex >= 0)
            {
                var column = from keyValuePair in GetColumnCollection<string>(filtersColumnSelector.SelectedIndex, globalInfoDatagrid) select keyValuePair;

                switch (filtersTypeSelector.SelectedIndex)
                {
                    default:
                    case _filterByValue:
                        column = from keyValuePair in column
                                 where filtersCheckedListBox.CheckedItems.Contains(keyValuePair.Value ?? _emptyCell)
                                 select keyValuePair;
                        break;
                    case _filterMoreThan:
                        column = from keyValuePair in column
                                 where (keyValuePair.Value ?? _emptyCell).CompareTo(filterTextBox.Text) > 0
                                 select keyValuePair;
                        break;
                    case _filterMoreThanOrEqual:
                        column = from keyValuePair in column
                                 where (keyValuePair.Value ?? _emptyCell).CompareTo(filterTextBox.Text) >= 0
                                 select keyValuePair;
                        break;
                    case _filterLessThan:
                        column = from keyValuePair in column
                                 where (keyValuePair.Value ?? _emptyCell).CompareTo(filterTextBox.Text) < 0
                                 select keyValuePair;
                        break;
                    case _filterLessThanOrEqual:
                        column = from keyValuePair in column
                                 where (keyValuePair.Value ?? _emptyCell).CompareTo(filterTextBox.Text) <= 0
                                 select keyValuePair;
                        break;
                    case _filerEqual:
                        column = from keyValuePair in column
                                 where (keyValuePair.Value ?? _emptyCell).CompareTo(filterTextBox.Text) == 0
                                 select keyValuePair;
                        break;
                }

                var keys = from keyValue in column select keyValue.Key;

                for (int i = 0; i < globalInfoDatagrid.Rows.Count - _uncommitedRow; i++)
                    if (!keys.Contains(i))
                        globalInfoDatagrid.Rows.RemoveAt(i);

                if (keys.Count() != (globalInfoDatagrid.Rows.Count - _uncommitedRow))
                    filterButton_Click(null, EventArgs.Empty);
            }
            else MessageBox.Show("Выбирите столбец");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var connect = new SqlConnection(@"Data Source=VNZK\SQLEXPRESS;Initial Catalog=CourseWork;Integrated Security=false;" +
                                             "User ID=" + loginTextBox.Text + ";" +
                                             "Password=" + passwordTextBox.Text + ";");
            try
            {
                connect.Open();
                MessageBox.Show(connect.Database);
                SqlCommand cmd = new SqlCommand("EXEC sp_tables;", connect);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                ReadToDataGridViewFromSqlDataReader(sqlDataReader);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { connect.Close(); }
        }

        private void cathegoryInfoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataInfoCheckedListBox.Items.Clear();
            switch (cathegoryInfoComboBox.SelectedIndex)
            {

                case _categoryHuman:
                    dataInfoCheckedListBox.Items.Add("Номер человека");
                    dataInfoCheckedListBox.Items.Add("Имя");
                    dataInfoCheckedListBox.Items.Add("Фамилия");
                    dataInfoCheckedListBox.Items.Add("Отчество");
                    dataInfoCheckedListBox.Items.Add("Дата рождения");
                    dataInfoCheckedListBox.Items.Add("Медицинская карта");
                    break;
                case _categoryContracts:
                    dataInfoCheckedListBox.Items.Add("Номер контракта");
                    dataInfoCheckedListBox.Items.Add("Должность");
                    dataInfoCheckedListBox.Items.Add("Отдел");
                    dataInfoCheckedListBox.Items.Add("Зарплата");
                    dataInfoCheckedListBox.Items.Add("Состояние контракта");
                    dataInfoCheckedListBox.Items.Add("Дата подписания");
                    dataInfoCheckedListBox.Items.Add("Дата завершения контракта");
                    break;
                case _categoryMedicalInspect:
                    dataInfoCheckedListBox.Items.Add("Дата прохождения медосмотра");
                    dataInfoCheckedListBox.Items.Add("Состояние проходившего");
                    dataInfoCheckedListBox.Items.Add("Заметки после осмотра");
                    break;
                case _categoryAbsence:
                    dataInfoCheckedListBox.Items.Add("Отсутсвовал с");
                    dataInfoCheckedListBox.Items.Add("Отстутствовал по");
                    dataInfoCheckedListBox.Items.Add("Причина");
                    break;

            }

        }
    }
}
