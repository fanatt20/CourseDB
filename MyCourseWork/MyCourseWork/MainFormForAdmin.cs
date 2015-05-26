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

namespace MyCourseWork
{
    public partial class MainFormForAdmin : Form
    {
        const byte _uncommitedRow = 1;
        const byte _filterPickFromValue = 0;
        const byte _filterPickMoreThan = 1;
        const byte _filterPickLessThan = 2;
        const byte _filterPickMoreOrEqual = 3;
        const byte _filterPickLessOrEqual = 4;
        const byte _filtePickerEqual = 5;


        private SqlConnection connection;
        public MainFormForAdmin(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;

            mainInfoDataGrid.Columns.Add("C1", "C1");
            mainInfoDataGrid.Columns.Add("C2", "C2");
            mainInfoDataGrid.Columns[0].ValueType = typeof(string);
            mainInfoDataGrid.Columns[1].ValueType = typeof(string);
            mainInfoDataGrid.Rows.Add("HELLO", "My");
            mainInfoDataGrid.Rows.Add("Dear", "Friend");
            mainInfoDataGrid.Rows.Add("Dear", "Friend");
            mainInfoDataGrid.Rows.Add("Dear2", "Friend1");
            mainInfoDataGrid.Rows.Add("Dear3", "Friend4");
            //mainInfoDataGrid.DataSource = (new List<string> { "HELLO", "My", "Dear", "Friend" }).ToArray();
        }
        private Dictionary<int, dynamic> ReadColumnFromDataGridview(int index, DataGridView table)
        {
            var result = new Dictionary<int, dynamic>();
            for (var i = 0; i < table.Rows.Count ; i++)
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
                        dynamic defaultValue = String.Empty;
                        try
                        {
                            defaultValue = Activator.CreateInstance(mainInfoDataGrid.Columns[index].ValueType);

                        }
                        catch (MissingMethodException) { }
            
            var cells = from keyValue in ReadColumnFromDataGridview(index,mainInfoDataGrid) select keyValue.Value;
            foreach (var cellValue in cells.Distinct())
                if (!DBNull.Value.Equals(cellValue))
                    filterValueCheckedListBox.Items.Add(cellValue ?? defaultValue);
                else
                    if (!cells.Contains(null))
                        filterValueCheckedListBox.Items.Add(defaultValue);
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
        void filterColumnComboBox_SelectedIndexChanged(object sender, EventArgs e) { FillFilterValueCheckedListBox(); }

        private void filterButton_Click(object sender, EventArgs e)
        {
            var index = filterColumnComboBox.SelectedIndex;
            var column = from keyValue in ReadColumnFromDataGridview(index, mainInfoDataGrid) select keyValue;
            var columnType = mainInfoDataGrid.Columns[index].ValueType;
            dynamic newInstance = String.Empty;
            dynamic compareValue = String.Empty;
            try
            {
                if (filterOperationComboBox.SelectedIndex > 0)
                    compareValue = TypeDescriptor.GetConverter(columnType).ConvertFromString(filterCompareTextBox.Text);
                newInstance = Activator.CreateInstance(columnType);

            }
            catch (MissingMethodException) { }


            bool columnTypeIsString = columnType == typeof(string);

            switch (filterOperationComboBox.SelectedIndex)
            {
                case _filterPickFromValue:
                    column = from keyValue in column
                             where filterValueCheckedListBox.Items.Contains(keyValue.Value ?? newInstance)
                             select keyValue;
                    break;
                case _filterPickMoreThan:
                    if (columnTypeIsString)
                        column = from keyValue in column
                                 where (keyValue.Value ?? newInstance).CompareTo(compareValue) < 0
                                 select keyValue;
                    else
                        column = from keyValue in column
                                 where (keyValue.Value ?? newInstance).CompareTo(compareValue) > 0
                                 select keyValue;
                    break;
                case _filterPickMoreOrEqual:
                    if (columnTypeIsString)
                        column = from keyValue in column
                                 where (keyValue.Value ?? newInstance).CompareTo(compareValue) <= 0
                                 select keyValue;
                    else
                        column = from keyValue in column
                                 where (keyValue.Value ?? newInstance).CompareTo(compareValue) >= 0
                                 select keyValue;
                    break;
                case _filterPickLessThan:
                    if (columnTypeIsString)
                        column = from keyValue in column
                                 where (keyValue.Value ?? newInstance).CompareTo(compareValue) > 0
                                 select keyValue;
                    else
                        column = from keyValue in column
                                 where (keyValue.Value ?? newInstance).CompareTo(compareValue) < 0
                                 select keyValue;
                    break;
                case _filterPickLessOrEqual:
                    if (columnTypeIsString)
                        column = from keyValue in column
                                 where (keyValue.Value ?? newInstance).CompareTo(compareValue) >= 0
                                 select keyValue;
                    else
                        column = from keyValue in column
                                 where (keyValue.Value ?? newInstance).CompareTo(compareValue) <= 0
                                 select keyValue;
                    break;
                case _filtePickerEqual:
                    column = from keyValue in column
                             where (keyValue.Value ?? newInstance).CompareTo(compareValue) == 0
                             select keyValue;
                    break;
            }
                        var values= from keyValue in column select keyValue.Value;
                     

                        foreach (var row in mainInfoDataGrid.Rows.Cast<DataGridViewRow>())
                        {
                            if (DBNull.Value.Equals(row.Cells[index].Value))
                            {
                                if (!values.Contains(null))
                                    mainInfoDataGrid.Rows.Remove(row);
                            }
                            else if (!row.IsNewRow && !values.Contains(row.Cells[index].Value))
                                mainInfoDataGrid.Rows.Remove(row);
                        }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillFilterColumnComboBox();
        }
    }
}
