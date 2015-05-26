using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Common;

namespace MyCourseWork
{
    public partial class MainFormForAdmin : Form
    {
        #region Constants
        //Filter column selector ComboBox
        const byte _filterPickFromValue = 0;
        const byte _filterPickMoreThan = 1;
        const byte _filterPickLessThan = 2;
        const byte _filterPickMoreOrEqual = 3;
        const byte _filterPickLessOrEqual = 4;
        const byte _filtePickerEqual = 5;

        //Select category ComboBox
        const byte _selectContracts = 0;
        const byte _selectPositions = 1;
        const byte _selectComunication = 2;
        const byte _selectHuman = 3;
        const byte _selectUserDefined = 4;
        const byte _selectSchudele = 5;
        //select value category listBox
        const byte _selectAll = 0;
        const byte _selectWorkers = 1;
        const byte _selectNotWorkers = 2;
        const byte _selectAllPosition = 0;
        const byte _selectVacantPostion = 1;
        const byte _selectHalfTimePosition = 2;
        const byte _selectClosedPosition = 3;
        #endregion
        Dictionary<string, string> userDefinedQuery = new Dictionary<string, string>();
        SqlDataAdapter adapter;
        DataTable set = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            var select = String.Empty;
            var valueOfCategory = selectCategoryValueListBox.SelectedIndex;
            switch (selectCategoryComboBox.SelectedIndex)
            {
                case _selectContracts:
                    select = "SELECT * FROM [Все контракты] ";
                    switch (valueOfCategory)
                    {
                        default:
                        case _selectAll:

                            break;
                        case _selectWorkers:
                            select += " WHERE [Фактическое окончание] IS NULL ";
                            break;
                        case _selectNotWorkers:
                            select += " WHERE [Фактическое окончание] IS NOT NULL ";
                            break;
                    }
                    break;
                case _selectPositions:
                    select = "SELECT * FROM [Позиции] ";
                    switch (valueOfCategory)
                    {
                        default:
                        case _selectAllPosition:
                            break;
                        case _selectHalfTimePosition:
                            select += " WHERE [Состояние позиции] = [Требуется полставки] ";
                            break;
                        case _selectVacantPostion:
                            select += " WHERE [Состояние позиции] = [Вакантная позиция] ";
                            break;
                        case _selectClosedPosition:
                            select += " WHERE [Состояние позиции] = [Закрытая позиция] ";
                            break;
                    }
                    break;
                case _selectComunication:
                    select = "SELECT * FROM [Связи с людьми] ";
                    switch (valueOfCategory)
                    {
                        default:
                        case _selectAll:

                            break;
                        case _selectWorkers:
                            select += " WHERE [Является работником] =1 ";
                            break;
                        case _selectNotWorkers:
                            select += " WHERE [Является работником] =0 ";
                            break;
                    }
                    break;
                case _selectHuman:
                    select = "SELECT * FROM [Сотрудники]";
                    switch (valueOfCategory)
                    {
                        default:
                        case _selectAll:

                            break;
                        case _selectWorkers:
                            select += " WHERE [Зарплата] IS NOT NULL ";
                            break;
                        case _selectNotWorkers:
                            select += " WHERE [Зарплата] IS NULL ";
                            break;
                    }
                    break;
                case _selectUserDefined:
                    select = (string)userDefinedQuery[selectCategoryValueListBox.SelectedItem];
                    break;
            }
            adapter.SelectCommand = new SqlCommand(select, connection);
            try
            {
                connection.Open();
                set.Clear();
                adapter.Fill(set);
                bindingSource1.RemoveFilter();
                FillFilterColumnComboBox();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        private SqlConnection connection;
        public MainFormForAdmin(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            adapter = new SqlDataAdapter();
            bindingSource1.DataSource = set;

            mainInfoDataGrid.DataSource = bindingSource1;
        }
        private Dictionary<int, dynamic> ReadColumnFromDataGridview(int index, DataGridView table)
        {
            var result = new Dictionary<int, dynamic>();
            for (var i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i].Cells[index].Value == DBNull.Value)
                    result.Add(i, null);
                else
                    result.Add(i, table.Rows[i].Cells[index].Value);
            }
            return result;

        }
        private void FillFilterColumnComboBox()
        {
            foreach (var column in mainInfoDataGrid.Columns.Cast<DataGridViewColumn>())
                if (!filterColumnComboBox.Items.Contains(column.HeaderText))
                    filterColumnComboBox.Items.Add(column.HeaderText);
        }
        private void FillFilterValueCheckedListBox()
        {

            filterValueCheckedListBox.Items.Clear();
            var index = filterColumnComboBox.SelectedIndex;
            dynamic defaultValue = null;
            try
            {
                defaultValue = Activator.CreateInstance(mainInfoDataGrid.Columns[index].ValueType);

            }
            catch (MissingMethodException) { }

            var cells = from keyValue in ReadColumnFromDataGridview(index, mainInfoDataGrid) select keyValue.Value;
            foreach (var cellValue in cells.Distinct())
                filterValueCheckedListBox.Items.Add(cellValue ?? DBNull.Value);

        }
        private void ReadToDataGridViewFromSQLReader(DataGridView table, SqlDataReader reader)
        {
            table.Columns.Clear();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                table.Columns.Add(reader.GetName(i), reader.GetName(i));
                table.Columns[i].ValueType = reader.GetFieldType(i);
            }
            var row = new object[reader.FieldCount];
            while (reader.Read())
            {
                reader.GetValues(row);
                table.Rows.Add(row);
            }
        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
        void filterColumnComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFilterValueCheckedListBox();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveFilter();
            var index = filterColumnComboBox.SelectedIndex;
            var filter = String.Empty;
            var columnName = mainInfoDataGrid.Columns[index].Name;
            switch (filterOperationComboBox.SelectedIndex)
            {
                default:
                case _filterPickFromValue:
                    foreach (var selectedItem in filterValueCheckedListBox.CheckedItems)
                        filter += columnName + @"='" + selectedItem.ToString() + @"' OR ";
                    filter = filter.Remove(filter.LastIndexOf("OR"), 2);
                    break;
                case _filterPickMoreOrEqual:
                    filter += columnName + @">='" + filterCompareTextBox.Text + @"'";
                    break;
                case _filterPickMoreThan:
                    filter += columnName + @">'" + filterCompareTextBox.Text + @"'";
                    break;
                case _filterPickLessThan:
                    filter += columnName + @"<'" + filterCompareTextBox.Text + @"'";
                    break;
                case _filterPickLessOrEqual:
                    filter += columnName + @"<='" + filterCompareTextBox.Text + @"'";
                    break;
                case _filtePickerEqual:
                    filter += columnName + @"='" + filterCompareTextBox.Text + @"'";
                    break;
            }

            try
            {
                bindingSource1.Filter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void mainInfoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectCategoryValueListBox.Items.Clear();
            switch ((sender as ComboBox).SelectedIndex)
            {
                case _selectContracts:
                    selectCategoryValueListBox.Items.Add("Все");
                    selectCategoryValueListBox.Items.Add("Действующие");
                    selectCategoryValueListBox.Items.Add("Не действующие контракты");
                    break;
                case _selectPositions:
                    selectCategoryValueListBox.Items.Add("Все");
                    selectCategoryValueListBox.Items.Add("Свободные");
                    selectCategoryValueListBox.Items.Add("Требующие полставки");
                    selectCategoryValueListBox.Items.Add("Закрытые");
                    break;
                case _selectComunication:
                    selectCategoryValueListBox.Items.Add("Все люди");
                    selectCategoryValueListBox.Items.Add("Работники");
                    selectCategoryValueListBox.Items.Add("Не работающие");
                    break;
                case _selectHuman:
                    selectCategoryValueListBox.Items.Add("Все люди");
                    selectCategoryValueListBox.Items.Add("Работники");
                    selectCategoryValueListBox.Items.Add("Не работающие");
                    break;
                case _selectUserDefined:
                    foreach (var key in userDefinedQuery.Keys)
                        selectCategoryValueListBox.Items.Add(key);
                    break;
                case _selectSchudele:

                    break;
            }
        }
    }
}
