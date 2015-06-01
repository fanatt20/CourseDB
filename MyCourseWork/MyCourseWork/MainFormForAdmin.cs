using MyCourseWork.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCourseWork
{
    public partial class MainFormForAdmin : Form
    {
        #region Constants
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
        public enum ActionTabs
        {
            AddMember = 0,
            AddContract = 1,
            Absence = 2,
        }
        #endregion
        public enum MainInfoCategories
        {
            Contracts = 0,
            Positions,
            Humans,
            Comunications,
            UserDefined
        }
        public enum Operand
        {
            PickFromValue = 0,
            LessThan,
            MoreThen,
            LessOrEqualThan,
            MoreOrEqualThan,
            Equal,
            NotEqual

        }
        public enum Days
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7

        }

        private Dictionary<Operand, string> _operands = new Dictionary<Operand, string> { 
                                                            { Operand.Equal, "=" },              { Operand.NotEqual, "<>" },
                                                            { Operand.MoreThen, ">" },           { Operand.LessThan, "<" },
                                                            { Operand.MoreOrEqualThan, ">=" },   { Operand.LessOrEqualThan, "<=" } };

        Dictionary<MainInfoCategories, string[]> _mainInfoCategories = new Dictionary<MainInfoCategories, string[]> {
                                                            { MainInfoCategories.Contracts, new string[]        { "Все" , "Действующие" , "Не действующие контракты" } },
                                                            { MainInfoCategories.Positions, new string[]        { "Все" , "Свободные" , "Требующие полставки" , "Закрытые" } },
                                                            { MainInfoCategories.Humans, new string []          { "Все люди" , "Работники" , "Не работающие" } },
                                                            { MainInfoCategories.Comunications, new string []   { "Все люди" , "Работники" , "Не работающие" } }
            };
        Dictionary<Days, string> _days = new Dictionary<Days, string>{
                                {Days.Monday     ,"Понедельник"},
                                {Days.Tuesday    ,"Вторник"},
                                {Days.Wednesday  ,"Среда"},
                                {Days.Thursday   ,"Четверг"},
                                {Days.Friday     ,"Пятница"},
                                {Days.Saturday   ,"Суббота"},
                                {Days.Sunday     ,"Воскресенье"},
        };

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
                    select = userDefinedQuery[(string)selectCategoryValueListBox.SelectedValue];
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

            dataGridView2.AllowUserToAddRows = false;
            mainInfoDataGrid.DataSource = bindingSource1;
            mainInfoDataGrid.ReadOnly = true;
            mainInfoSqlPage.Hide();
            addMemberComunicationDataGrid.AllowUserToAddRows = false;
            mainInfoDataGrid.AllowUserToAddRows = false;
            string begin = new TimeSpan(9, 0, 0).ToString();
            string end = new TimeSpan(17, 0, 0).ToString();
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



        private string SimpleFilter(string columnName, Operand operand, string value)
        {
            return string.Join(" ", "[", columnName, "]", _operands[operand], "'", value, "'");
        }

        private string InFilter(string columnName, string[] values)
        {
            var filter = String.Empty;
            bool isFirst = true;
            foreach (var value in values)
            {
                if (!isFirst)
                {
                    filter += " OR ";
                }
                else
                {
                    isFirst = false;
                }
                if (string.IsNullOrEmpty(value))
                    filter += "[" + columnName + @"] IS NULL ";
                else
                    filter += "[" + columnName + @"]='" + value + @"'";

            }
            return filter;
        }

        private void filterButton_Click(object sender, EventArgs e)
        {

            var index = filterColumnComboBox.SelectedIndex;
            var columnName = filterColumnComboBox.SelectedItem.ToString();
            if (index < 0)
            {
                UserNotification.Info("Выберите столбец");
                return;
            }
            var filter = String.Empty;
            if (!String.IsNullOrEmpty(bindingSource1.Filter))
                filter = bindingSource1.Filter + "AND (";
            else
                filter = "(";
            switch ((Operand)filterOperationComboBox.SelectedIndex)
            {
                case Operand.PickFromValue:
                    if (filterValueCheckedListBox.CheckedItems.Contains(DBNull.Value))
                    {
                        filterValueCheckedListBox.SetItemChecked(filterValueCheckedListBox.Items.IndexOf(DBNull.Value), false);
                        filter += "[" + columnName + "] IS NULL" + ((filterValueCheckedListBox.CheckedItems.Count != 0) ? " OR " : "");
                    }
                    filter += InFilter(columnName, filterValueCheckedListBox.CheckedItems.Cast<string>().ToArray());
                    break;
                default:
                    filter += SimpleFilter(columnName, (Operand)filterOperationComboBox.SelectedIndex, filterCompareTextBox.Text);
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



        private void mainInfoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {



            selectCategoryValueListBox.Items.Clear();
            var mainInfoCategory = (MainInfoCategories)(sender as ComboBox).SelectedIndex;
            if (_mainInfoCategories.ContainsKey(mainInfoCategory))
                selectCategoryValueListBox.Items.AddRange(_mainInfoCategories[mainInfoCategory]);
            else
                if (mainInfoCategory == MainInfoCategories.UserDefined)
                    if (userDefinedQuery.Keys.Count != 0)
                        foreach (var key in userDefinedQuery.Keys)
                            selectCategoryValueListBox.Items.Add(key);

                    else
                        throw new NotSupportedException("MainInfo Categories does not contain category: " + (sender as ComboBox).SelectedText);


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
                    var department = new VacantDepartment(reader.GetInt32(5), reader.GetString(1));
                    if (!vacantDepartments.Contains(department))
                        vacantDepartments.Add(department);
                    var position = new VacantPosition((int)reader[4], (Decimal)reader[2], (string)reader[0], new PositionState((int)reader[7], (string)(reader[6])));
                    if (!department.VacantPositions.Contains(position))
                        department.AddToDepartment(position);
                }
                reader.Close();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM [Сотрудники] WHERE EndAtPractically IS NULL AND [Дата Подписания контракта] IS NULL", connection);
                var dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;


            }
            catch (Exception ex)
            {
                UserNotification.Error(ex.Message);
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

            switch ((ActionTabs)(sender as TabControl).SelectedIndex)
            {
                case ActionTabs.AddMember:
                    FillActionAddMemberPage();
                    break;
                case ActionTabs.AddContract:
                    FillActionAddContractPage();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid Tab index");

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
            insertInHuman.Parameters.AddWithValue("Name", String.IsNullOrEmpty(addMemebrNameTextBox.Text) ? null : addMemebrNameTextBox.Text);
            insertInHuman.Parameters.AddWithValue("Surname", String.IsNullOrEmpty(addMemeberSurnameTextBox.Text) ? null : addMemeberSurnameTextBox.Text);
            insertInHuman.Parameters.AddWithValue("Patronimyc", addMemebrPatronimycTextBox.Text);
            insertInHuman.Parameters.AddWithValue("Birthday", addMemberBirthdayDatePicker.Value);
            insertInHuman.Parameters.AddWithValue("MedicalCard", addMemberMedicalCardTextBox.Text);
            insertInHuman.Parameters.AddWithValue("Education", addMemeberEducationRichTextBox.Text);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
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

        private void contractDepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            contractPositionComboBox.Items.Clear();
            var comboBox = sender as ComboBox;
            foreach (var position in (comboBox.SelectedItem as VacantDepartment).VacantPositions)
            {
                contractPositionComboBox.Items.Add(position);

            }
            if (contractPositionComboBox.Items.Count > 0)
            {
                contractPositionComboBox.SelectedIndex = 0;
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

        private void absentFromDepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contractAddNew_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count != 1 && dataGridView2.SelectedCells.Count != 13)
                UserNotification.Warn("Выберите строку");
            else
            {
                SqlTransaction trans = null;
                try
                {
                    var selectedHuman = (dataGridView2.SelectedRows.Count == 1) ? dataGridView2.SelectedRows[0].Cells["HumanID"].Value :
                                                                                    dataGridView2["HumanID", dataGridView2.SelectedCells[0].RowIndex].Value;
                    var insertIntoContracts = connection.CreateCommand();
                    insertIntoContracts.CommandText = "Insert into Contracts  values (@HumanID,@IDPosition,@Salary,@DateOfSigning,@EndAt,NULL,NULL)";
                    insertIntoContracts.Parameters.AddWithValue("HumanID", selectedHuman);
                    insertIntoContracts.Parameters.AddWithValue("IDPosition", (contractPositionComboBox.SelectedItem as VacantPosition).ID);
                    if (Decimal.Parse(contractSalaryTextBox.Text) > Decimal.Parse(salaryLabel.Text.Replace("<=", "")))
                        throw new ArgumentOutOfRangeException();
                    insertIntoContracts.Parameters.AddWithValue("Salary", Decimal.Parse(contractSalaryTextBox.Text));
                    insertIntoContracts.Parameters.AddWithValue("DateOfSigning", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                    insertIntoContracts.Parameters.AddWithValue("EndAt", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));

                    connection.Open();
                    trans = connection.BeginTransaction();


                    insertIntoContracts.Transaction = trans;
                    insertIntoContracts.ExecuteNonQuery();

                    var update = connection.CreateCommand();
                    update.Transaction = trans;
                    update.CommandText = "UPDATE Positions Set PositionStateID = " + ((contractPositionComboBox.SelectedItem as VacantPosition).State.GetPossibleStates().Count - (contractTypeSelector.SelectedItem as PositionState).ID).ToString() +
                        "  where IDPosition = " + (contractPositionComboBox.SelectedItem as VacantPosition).ID.ToString();
                    update.ExecuteNonQuery();
                    var selectCurrentContractID = connection.CreateCommand();
                    selectCurrentContractID.CommandText = "Select TOP(1)ContractID from Contracts order by ContractID desc ";
                    selectCurrentContractID.Transaction = trans;
                    var index = (int)selectCurrentContractID.ExecuteScalar();
                    var insertIntoShcudele = connection.CreateCommand();
                    insertIntoShcudele.Transaction = trans;
                    insertIntoShcudele.CommandText = "Insert into MembersSchedule values";
                    var value = String.Empty;
                    var firstColumn = true;

                    foreach (var column in contractSchudeleDataGridView.Columns.Cast<DataGridViewColumn>())
                    {
                        if (firstColumn)
                            firstColumn = false;
                        else
                        {
                            string begin = "NULL";
                            string end = "NULL";
                            TimeSpan buffer;
                            if (contractSchudeleDataGridView[column.Name, 0].Value != null)
                                if (TimeSpan.TryParse((string)contractSchudeleDataGridView[column.Name, 0].Value, out buffer))
                                    begin = "'" + buffer.ToString() + "'";
                            if (contractSchudeleDataGridView[column.Name, 1].Value != null)
                                if (TimeSpan.TryParse((string)contractSchudeleDataGridView[column.Name, 1].Value, out buffer))
                                    end = "'" + buffer.ToString() + "'";
                            value = String.Join(" ", "(", index, ",'", column.HeaderText, "',", begin, ",", end, "),");
                        }
                        insertIntoShcudele.CommandText += " " + value;
                    }
                    insertIntoShcudele.CommandText = insertIntoShcudele.CommandText.Remove(insertIntoShcudele.CommandText.Length - 1);
                    insertIntoShcudele.ExecuteNonQuery();


                    trans.Commit();
                }
                catch (Exception ex)
                {
                    if (trans != null) trans.Rollback();
                    UserNotification.Error(ex.Message);
                }
                finally { connection.Close(); }
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            var grid = sender as DataGridView;

        }

        private void mainFormTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillActionAddMemberPage();
        }
    }
}
