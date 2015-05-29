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
        //actionTab indexes
        const byte _actionAddMember = 0;
        const byte _actionAddContract = 1;
        const byte _actionAbsence = 2;
        #endregion
        Dictionary<string, string> userDefinedQuery = new Dictionary<string, string>();
        SqlDataAdapter adapter;
        BindingSource holidayTable;
        List<VacantDepartment> vacantDepartments = new List<VacantDepartment>();

        private SqlConnection connection;
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
                            select += @" WHERE [Состояние позиции] = 'Требуется полставки' ";
                            break;
                        case _selectVacantPostion:
                            select += @" WHERE [Состояние позиции] = 'Вакантная позиция' ";
                            break;
                        case _selectClosedPosition:
                            select += @" WHERE [Состояние позиции] = 'Закрытая позиция' ";
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
                    select = userDefinedQuery[(string)selectCategoryValueListBox.SelectedItem];
                    break;
            }
            ExecuteSelectCommand(select);

        }

        private void ExecuteSelectCommand(string command)
        {
            var str = command.ToUpper();
            var ilegal = str.Contains("INSERT ") || str.Contains("DROP ") ||
                str.Contains("DELETE") || str.Contains("CREATE ") ||
                str.Contains("USE ") || str.Contains("GRANT ") ||
                str.Contains("REVOKE ") || str.Contains("TRIGGER ") ||
                str.Contains("UPDATE ") || str.Contains("TABLE ") ||
                str.Contains("ALTER ");

            if (ilegal)
            {
                MessageBox.Show("Не надо так...");
            }
            else
            {
                adapter.SelectCommand = new SqlCommand(command, connection);
                try
                {
                    DataTable set = new DataTable();
                    connection.Open();
                    set.Clear();
                    set.Columns.Clear();
                    adapter.Fill(set);
                    bindingSource1.DataSource = set;
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

        }
        public MainFormForAdmin(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            adapter = new SqlDataAdapter();
            filterOperationComboBox.SelectedIndex = 0;

            mainInfoDataGrid.DataSource = bindingSource1;
            mainInfoDataGrid.ReadOnly = true;
            mainInfoSqlPage.Hide();
            addMemberComunicationDataGrid.AllowUserToAddRows = false;
            TimeSpan begin = new TimeSpan(9, 0, 0);
            TimeSpan end = new TimeSpan(17, 0, 0);
            contractSchudeleDataGridView.Rows.Add("Начало", begin, begin, begin, begin, begin, null, null);
            contractSchudeleDataGridView.Rows.Add("Конец", end, end, end, end, end, null, null);
            contractSchudeleDataGridView.AllowUserToAddRows = false;
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
            filterColumnComboBox.Items.Clear();
            foreach (var column in mainInfoDataGrid.Columns.Cast<DataGridViewColumn>())
                if (!filterColumnComboBox.Items.Contains(column.HeaderText))
                    filterColumnComboBox.Items.Add(column.HeaderText);
            if (filterColumnComboBox.Items.Count != 0)
                filterColumnComboBox.SelectedIndex = 0;
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

            var index = filterColumnComboBox.SelectedIndex;
            if (index >= 0)
            {
                var filter = String.Empty;
                if (!String.IsNullOrEmpty(bindingSource1.Filter))
                    filter = bindingSource1.Filter + "AND (";
                else
                    filter = "(";

                var columnName = "[" + mainInfoDataGrid.Columns[index].Name + "]";
                switch (filterOperationComboBox.SelectedIndex)
                {
                    default:
                    case _filterPickFromValue:
                        foreach (var selectedItem in filterValueCheckedListBox.CheckedItems)
                            if (!String.IsNullOrEmpty(selectedItem.ToString()))
                                filter += columnName + @"='" + selectedItem.ToString() + @"' OR ";
                            else filter += columnName + @" IS NULL OR ";
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
                    bindingSource1.Filter = filter + ")";
                }
                catch (Exception ex)
                {
                    bindingSource1.Filter = bindingSource1.Filter.Remove(bindingSource1.Filter.Length - filter.Length - 1);
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Выберите столбец");

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

        private void sqlExcecuteButton_Click(object sender, EventArgs e)
        {
            ExecuteSelectCommand(queryRichTextBox.Text);
        }


        private void sqlAddToCollectionButton_Click(object sender, EventArgs e)
        {
            var name = new AddUserQueryToCollection(userDefinedQuery.Add, queryRichTextBox.Text);
            name.Show();
        }

        private void FillActionAddMemberPage()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select Name from ComunicationType", connection);
                var reader = cmd.ExecuteReader();
                addMemberComunicationDataGrid.Rows.Clear();
                while (reader.Read())
                    addMemberComunicationDataGrid.Rows.Add(reader[0], String.Empty);

            }
            finally { connection.Close(); }
        }
        private void FillActionAddContractPage()
        {
            var selectVacantPositions = connection.CreateCommand();
            selectVacantPositions.CommandText = "Select * from [Свободные позиции]";
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                reader = selectVacantPositions.ExecuteReader();

                while (reader.Read())
                {
                    var department = new VacantDepartment((int)reader[5], (string)reader[1]);
                    if (!vacantDepartments.Contains(department))
                        vacantDepartments.Add(department);
                    var position = new VacantPosition((int)reader[4], (Decimal)reader[2], (string)reader[0], new PositionState((int)reader[7], (string)(reader[6])));
                    if (!department.VacantPositions.Contains(position))
                        department.AddToDepartment(position);
                }
            }
            finally
            {
                connection.Close();
            }
            foreach (var department in vacantDepartments)
                contractDepartmentComboBox.Items.Add(department);
            contractDepartmentComboBox.SelectedIndex = 0;
        }



        private void ActionsPage_TabIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case _actionAddMember:
                    FillActionAddMemberPage();
                    break;
                case _actionAddContract:
                    FillActionAddContractPage();
                    break;

            }

        }
        private void MainFormForAdmin_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "courseWorkSecondVariantDataSet.AbsenceRegister". При необходимости она может быть перемещена или удалена.
            this.absenceRegisterTableAdapter.Fill(this.courseWorkSecondVariantDataSet.AbsenceRegister);

        }

        private void addMemberSubmitButton_Click(object sender, EventArgs e)
        {
            var insertInHuman = connection.CreateCommand();
            insertInHuman.CommandText = @"Insert into Human values(@Name,@Surname,@Patronimyc,@Birthday,@MedicalCard,@Education)";
            insertInHuman.Parameters.AddWithValue("Name", (dynamic)addMemebrNameTextBox.Text ?? (dynamic)DBNull.Value);
            insertInHuman.Parameters.AddWithValue("Surname", (dynamic)addMemeberSurnameTextBox.Text ?? (dynamic)DBNull.Value);
            insertInHuman.Parameters.AddWithValue("Patronimyc", (dynamic)addMemebrPatronimycTextBox.Text ?? (dynamic)DBNull.Value);
            insertInHuman.Parameters.AddWithValue("Birthday", (dynamic)addMemberBirthdayDatePicker.Value ?? (dynamic)DBNull.Value);
            insertInHuman.Parameters.AddWithValue("MedicalCard", (dynamic)addMemberMedicalCardTextBox.Text ?? (dynamic)DBNull.Value);
            insertInHuman.Parameters.AddWithValue("Education", (dynamic)addMemeberEducationRichTextBox.Text ?? (dynamic)DBNull.Value);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.RepeatableRead);
                insertInHuman.Transaction = transaction;
                insertInHuman.ExecuteNonQuery();
                var selectCurrentHumanID = connection.CreateCommand();
                selectCurrentHumanID.CommandText = "Select TOP(1)HumanID from Human order by HumanID desc ";
                selectCurrentHumanID.Transaction = transaction;
                var index = (int)selectCurrentHumanID.ExecuteScalar();
                var InsertIntoComunicationCmd = "Insert into Comunications values ";
                foreach (var item in addMemberComunicationDataGrid.Rows.Cast<DataGridViewRow>())
                {
                    if (!item.IsNewRow && !String.IsNullOrEmpty(item.Cells[0].Value.ToString()) && !String.IsNullOrEmpty(item.Cells[1].Value.ToString()))
                        InsertIntoComunicationCmd += @"(' " + index + @"','" + item.Index + @"','" + item.Cells[1].Value.ToString() + @"'),";
                }
                InsertIntoComunicationCmd = InsertIntoComunicationCmd.Remove(InsertIntoComunicationCmd.Length - 1);
                var insertIntoComunication = connection.CreateCommand();
                insertIntoComunication.CommandText = InsertIntoComunicationCmd;
                insertIntoComunication.Transaction = transaction;
                insertIntoComunication.ExecuteNonQuery();
                transaction.Commit();
                MessageBox.Show("Запись успешно добавлена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (transaction != null) transaction.Rollback();

            }
            finally
            {
                connection.Close();
            }

        }
        private void FillContractHumanSelectorTree()
        {


        }

        private void contractDepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            contractPositionComboBox.Items.Clear();
            var comboBox = sender as ComboBox;
            foreach (var position in (comboBox.SelectedItem as VacantDepartment).VacantPositions)
            {
                contractPositionComboBox.Items.Add(position);

            }
        }

        private void contractPositionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedPosition = comboBox.SelectedItem as VacantPosition;
            salaryLabel.Text = "<=" + selectedPosition.MaxSalary.ToString();
            if (!salaryLabel.Visible)
                salaryLabel.Visible = true;
            contractTypeSelector.Items.Clear();
            foreach (var state in selectedPosition.State.GetPossibleStates())
            {
                contractTypeSelector.Items.Add(state);
            }
        }
    }
}
