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
        const byte _filterPickFromValue = 0;
        const byte _filterPickMoreThan = 1;
        const byte _filterPickLessThan = 2;
        const byte _filterPickMoreOrEqual = 3;
        const byte _filterPickLessOrEqual = 4;
        const byte _filtePickerEqual = 5;
        SqlDataAdapter adapter;
        DataTable set = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            adapter.SelectCommand = new SqlCommand(queryRichTextBox.Text, connection);

            try
            {
                connection.Open();
                set.Clear();
                adapter.Fill(set);
                bindingSource1.RemoveFilter();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                connection.Close();
            }

            FillFilterColumnComboBox();
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


    }
}
