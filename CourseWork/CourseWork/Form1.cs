using System;
using System.Collections;
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
using System.Reflection;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        private SqlConnection connectionToDataBase;
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
                globalInfoDatagrid.Columns.Add(reader.GetName(i), reader.GetName(i));

            var list = new List<object>();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    list.Add(reader[i]);
                globalInfoDatagrid.Rows.Add(list.ToArray());
                list.Clear();
            }

        }

        public Dictionary<int, dynamic> GetColumnCollection(int index, DataGridView table)
        {
            var result = new Dictionary<int, dynamic>();
            for (int i = 0; i < table.Rows.Count - _uncommitedRow; i++)
                if (table.Rows[i].Cells[index].Value != DBNull.Value)
                    result.Add(i, table.Rows[i].Cells[index].Value);
                else
                    result.Add(i, null);
            return result;
        }


        private DataTable ReadFromSqlDataReader(SqlDataReader reader, string name)
        {
            var table = new DataTable(name);
            for (int i = 0; i < reader.FieldCount; i++)
                table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));


            while (reader.Read())
            {
                var row = table.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                    row[i] = reader[i];
                table.Rows.Add(row);
            }

            return table;
        }

        private void HideMainTabPagesForGuest()
        {
            infoPage.Hide();
            insertPage.Hide();
            adminPage.Hide();

        }
        private void ShowMainTabPagesForAdmin()
        {
            infoPage.Show();
            insertPage.Show();
            adminPage.Show();
        }


        #endregion

        RoleInDB userRole = RoleInDB.Nothing;
        public Form1()
        {
            InitializeComponent();
            HideMainTabPagesForGuest();
            globalInfoDatagrid.Columns.CollectionChanged += Columns_CollectionChanged;
            Columns_CollectionChanged(null, EventArgs.Empty);
            filtersColumnSelector.SelectedIndexChanged += filtersColumnSelector_SelectedIndexChanged;
        }

        void connectionToDataBase_StateChange(object sender, StateChangeEventArgs e)
        {
            switch (e.CurrentState)
            {
                case ConnectionState.Open:
                    ShowMainTabPagesForAdmin();
                    break;
            }
        }

        void filtersColumnSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = filtersColumnSelector.SelectedIndex;
            filtersCheckedListBox.Items.Clear();
            dynamic cellValue = "";
            for (int i = 0; i < globalInfoDatagrid.Rows.Count - _uncommitedRow; i++)
            {
                if (globalInfoDatagrid.Rows[i].Cells[selectedIndex].Value != null)
                    cellValue = globalInfoDatagrid.Rows[i].Cells[selectedIndex].Value;
                else cellValue = _emptyCell;

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

        private void selectGlobalInfoButton_Click(object sender, EventArgs e)
        {
            try
            {

                connectionToDataBase.Open();
                //var cmd = new SqlCommand(@"SELECT sysobjects.Name AS [Name]," + Environment.NewLine +
                //                        @"CASE PERMISSIONS(OBJECT_ID(sysobjects.Name))&1 WHEN 1 THEN 1 ELSE 0 END AS [Select]," + Environment.NewLine +
                //                        @"CASE PERMISSIONS(OBJECT_ID(sysobjects.Name))&2 WHEN 2 THEN 1 ELSE 0 END AS [Update]," + Environment.NewLine +
                //                        @"CASE PERMISSIONS(OBJECT_ID(sysobjects.Name))&8 WHEN 8 THEN 1 ELSE 0 END AS [Insert]," + Environment.NewLine +
                //                        @"CASE PERMISSIONS(OBJECT_ID(sysobjects.Name))&16 WHEN 16 THEN 1 ELSE 0 END AS [Delete]" + Environment.NewLine +
                //                        @"FROM sysobjects" + Environment.NewLine +
                //                        @"WHERE xtype = 'U'", connectionToDataBase);
                var cmd = new SqlCommand("select * from Positions", connectionToDataBase);
                var reader = cmd.ExecuteReader();

                globalInfoDatagrid.Columns.Clear();
                globalInfoDatagrid.DataSource = ReadFromSqlDataReader(reader, "FirstQuery");

            }
            finally
            {
                connectionToDataBase.Close();
            }


        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (filtersColumnSelector.SelectedIndex >= 0)
            {
                var columnType = globalInfoDatagrid.Columns[filtersColumnSelector.SelectedIndex].ValueType;
                var columnIndex = filtersColumnSelector.SelectedIndex;
                var column = from keyValuePair in GetColumnCollection(columnIndex, globalInfoDatagrid) select keyValuePair;
                dynamic newInctance = "";
                try
                {
                    newInctance = Activator.CreateInstance(columnType);
                }
                catch (MissingMethodException) { }

                dynamic convertedFilterTextBox = newInctance;
                if (!String.IsNullOrEmpty(filterTextBox.Text))
                    try
                    {

                        convertedFilterTextBox = TypeDescriptor.GetConverter(columnType).ConvertFromString(filterTextBox.Text.ToUpper());
                    }
                    catch (NotSupportedException exc)
                    {
                        MessageBox.Show(exc.Message);
                    }


                switch (filtersTypeSelector.SelectedIndex)
                {
                    default:
                    case _filterByValue:
                        column = from keyValuePair in column
                                 where filtersCheckedListBox.CheckedItems.Contains(keyValuePair.Value ?? _emptyCell)
                                 select keyValuePair;
                        break;
                    case _filterMoreThan:
                        if (columnType == typeof(string))
                            column = from keyValuePair in column
                                     where (keyValuePair.Value ?? newInctance).CompareTo(convertedFilterTextBox) < 0
                                     select keyValuePair;
                        else
                            column = from keyValuePair in column
                                     where (keyValuePair.Value ?? newInctance).CompareTo(convertedFilterTextBox) > 0
                                     select keyValuePair;
                        break;
                    case _filterMoreThanOrEqual:
                        if (columnType == typeof(string))
                            column = from keyValuePair in column
                                     where (keyValuePair.Value ?? newInctance).CompareTo(convertedFilterTextBox) <= 0
                                     select keyValuePair;
                        else
                            column = from keyValuePair in column
                                     where (keyValuePair.Value ?? newInctance).CompareTo(convertedFilterTextBox) >= 0
                                     select keyValuePair;
                        break;

                    case _filterLessThan:
                        if (columnType == typeof(string))
                            column = from keyValuePair in column
                                     where (keyValuePair.Value ?? newInctance).CompareTo(convertedFilterTextBox) > 0
                                     select keyValuePair;
                        else
                            column = from keyValuePair in column
                                     where (keyValuePair.Value ?? newInctance).CompareTo(convertedFilterTextBox) < 0
                                     select keyValuePair;
                        break;

                    case _filterLessThanOrEqual:
                        if (columnType == typeof(string))
                            column = from keyValuePair in column
                                     where (keyValuePair.Value ?? newInctance).CompareTo(convertedFilterTextBox) >= 0
                                     select keyValuePair;
                        else
                            column = from keyValuePair in column
                                     where (keyValuePair.Value ?? newInctance).CompareTo(convertedFilterTextBox) <= 0
                                     select keyValuePair;
                        break;

                    case _filerEqual:
                        column = from keyValuePair in column
                                 where (keyValuePair.Value ?? newInctance).CompareTo(convertedFilterTextBox) == 0
                                 select keyValuePair;
                        break;
                }

                var values = from keyValue in column select keyValue.Value;

                foreach (var row in globalInfoDatagrid.Rows.Cast<DataGridViewRow>())
                {
                    if (!values.Contains(row.Cells[columnIndex].Value) && !row.IsNewRow)
                        globalInfoDatagrid.Rows.Remove(row);

                }
                if (values.Count() != (globalInfoDatagrid.Rows.Count - _uncommitedRow))
                    filterButton_Click(null, EventArgs.Empty);
                else
                    filtersColumnSelector_SelectedIndexChanged(null, EventArgs.Empty);
            }
            else MessageBox.Show("Выберите столбец");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var sqlStringBuilder = new SqlConnectionStringBuilder()
            {
                UserID = loginTextBox.Text,
                Password = passwordTextBox.Text,
                IntegratedSecurity = false,
                DataSource = @"VNZK\SQLEXPRESS",
                Pooling = true
            };
            connectionToDataBase = new SqlConnection(sqlStringBuilder.ConnectionString);
            connectionToDataBase.StateChange += connectionToDataBase_StateChange;

            try
            {
                connectionToDataBase.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { connectionToDataBase.Close(); }
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
