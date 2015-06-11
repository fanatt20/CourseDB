using MyCourseWork.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MyCourseWork
{

    public partial class MainFormForAdmin : Form
    {
        #region Constants
        //select value category listBox
        const byte _selectAll = 0;
        const byte _selectWorkers = 1;
        const byte _selectNotWorkers = 2;
        const byte _selectAllPosition = 0;
        const byte _selectVacantPostion = 1;
        const byte _selectHalfTimePosition = 2;
        const byte _selectClosedPosition = 3;
        //actionTab indexes
        const byte _holidaySelected = 2;
        public enum ActionTabs
        {
            AddMember = 0,
            AddContract,
            Absence,
            Dissmis,
            AddPosition,
            AddInspect
        }
        public enum MainInfoCategories
        {
            Contracts = 0,
            Positions,
            Humans,
            Comunications,
            Shucdele,
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

        private Dictionary<MainInfoCategories, string[]> _mainInfoCategories = new Dictionary<MainInfoCategories, string[]> {
                                                            { MainInfoCategories.Contracts, new string[]        { "Все" , "Действующие" , "Не действующие" } },
                                                            { MainInfoCategories.Positions, new string[]        { "Все" , "Свободные" , "Требующие полставки" , "Закрытые" } },
                                                            { MainInfoCategories.Humans, new string []          { "Все" , "Работники" , "Не работающие" } },
                                                            { MainInfoCategories.Comunications, new string []   { "Все" , "Работники" , "Не работающие" } },
                                                            { MainInfoCategories.Shucdele, new string[]         { "Все" , "Действующие", "Не действующие" }}
            };
        private Dictionary<Days, string> _days = new Dictionary<Days, string>{
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
        List<Department> vacantDepartments = new List<Department>();
        List<Department> absentDepartments = new List<Department>();
        List<Department> wholeDepartments = new List<Department>();
        #endregion



        private SqlConnection connection;
        private BindingSource dissmisBindigSource = new BindingSource();
        private BindingSource medicalInspectSource = new BindingSource();

        public MainFormForAdmin(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            adapter = new SqlDataAdapter();

            filterOperationComboBox.SelectedIndex = 0;
            dataGridView3.DataSource = holidayManSource;
            mainInfoDataGrid.DataSource = bindingSource1;
            dataGridView4.DataSource = dissmisBindigSource;
            medicalInspectDataGrid.DataSource = medicalInspectSource;

            dataGridView3.AllowUserToAddRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView4.AllowUserToAddRows = false;
            addMemberComunicationDataGrid.AllowUserToAddRows = false;
            mainInfoDataGrid.AllowUserToAddRows = false;
            contractSchudeleDataGridView.AllowUserToAddRows = false;



            string begin = new TimeSpan(9, 0, 0).ToString();
            string end = new TimeSpan(17, 0, 0).ToString();
            contractSchudeleDataGridView.Rows.Add("Начало", begin, begin, begin, begin, begin, null, null);
            contractSchudeleDataGridView.Rows.Add("Конец", end, end, end, end, end, null, null);
            ApplyInterfaceByUserRole(SelectUserRoles());


        }

        private void selectButtom_Click(object sender, EventArgs e)
        {

            var select = String.Empty;
            var valueOfCategory = selectCategoryValueListBox.SelectedIndex;
            switch ((MainInfoCategories)selectCategoryComboBox.SelectedIndex)
            {
                case MainInfoCategories.Contracts:
                    select = "SELECT * FROM [Все контракты] ";
                    switch (valueOfCategory)
                    {
                        default:
                        case _selectAll:
                            select += " ";
                            break;
                        case _selectWorkers:
                            select += " WHERE [Фактическое окончание] IS NULL ";
                            break;
                        case _selectNotWorkers:
                            select += " WHERE [Фактическое окончание] IS NOT NULL ";
                            break;
                    }
                    break;
                case MainInfoCategories.Positions:
                    select = "SELECT * FROM [Позиции] ";
                    switch (valueOfCategory)
                    {
                        default:
                        case _selectAllPosition:
                            select += " ";
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
                case MainInfoCategories.Comunications:
                    select = "SELECT * FROM [Связи с людьми] ";
                    switch (valueOfCategory)
                    {
                        default:
                        case _selectAll:
                            select += " ";
                            break;
                        case _selectWorkers:
                            select += " WHERE [Является работником] =1 ";
                            break;
                        case _selectNotWorkers:
                            select += " WHERE [Является работником] =0 ";
                            break;
                    }
                    break;
                case MainInfoCategories.Humans:
                    select = "SELECT * FROM [Сотрудники]";
                    switch (valueOfCategory)
                    {
                        default:
                        case _selectAll:
                            select += " ";
                            break;
                        case _selectWorkers:
                            select += " WHERE [Зарплата] IS NOT NULL ";
                            break;
                        case _selectNotWorkers:
                            select += " WHERE [Зарплата] IS NULL ";
                            break;
                    }
                    break;
                case MainInfoCategories.Shucdele:
                    select = "SELECT * FROM [Рассписание] ";
                    switch (valueOfCategory)
                    {
                        default:
                        case _selectAll:
                            select += " ";
                            break;
                        case _selectWorkers:
                            select += " WHERE [Является работником] =1 ";
                            break;
                        case _selectNotWorkers:
                            select += " WHERE [Является работником] =0 ";
                            break;
                    }
                    break;
                case MainInfoCategories.UserDefined:
                    if (valueOfCategory >= 0)
                        select += userDefinedQuery.ElementAt(valueOfCategory).Value;
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

        private List<string> SelectUserRoles()
        {
            var select = connection.CreateCommand();
            select.CommandText = @"select name from sys.database_principals dp  where dp.[type] = 'R' and is_member(name) = 1";
            var result = new List<string>();
            try
            {
                var reader = select.ExecuteReader();
                while (reader.Read())
                    result.Add(reader.GetString(0));
            }
            finally
            {
                connection.Close();
            }
            return result;

        }

        private void ApplyInterfaceByUserRole(List<string> roles)
        {
            if (!roles.Contains("db_datareader"))
                mainInfoPage.Dispose();
            if (!roles.Contains("db_datawriter"))
                actionPage.Dispose();
            if (!roles.Contains("db_ddladmin"))
                mainInfoSqlPage.Dispose();
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
            name.ShowDialog();
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
                vacantDepartments.Clear();
                while (reader.Read())
                {
                    var department = new Department(reader.GetInt32(5), reader.GetString(1));
                    if (!vacantDepartments.Contains(department))
                        vacantDepartments.Add(department);
                    var position = new Position((int)reader[4], (Decimal)reader[2], (string)reader[0], new PositionState((int)reader[7], (string)(reader[6])));
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

        private void FillAbsencePage()
        {

            try
            {
                connection.Open();
                adapter.SelectCommand = new SqlCommand("SELECT * FROM [Сотрудники] WHERE [Дата Подписания контракта] IS NOT NULL AND [EndAtPractically] IS NULL", connection);
                var dt = new DataTable();
                adapter.Fill(dt);
                holidayManSource.DataSource = dt;
                var reasons = new SqlCommand("Select Reason,IDAbsenceReason from AbsenceReason", connection);
                var reader = reasons.ExecuteReader();
                absentFromReasonComboBox.Items.Clear();
                absentToReasonComboBox.Items.Clear();

                while (reader.Read())
                {
                    absentFromReasonComboBox.Items.Add(reader.GetString(0));
                    if (reader.GetInt32(1) != _holidaySelected)
                        absentToReasonComboBox.Items.Add(reader.GetString(0));
                }
                reader.Close();
                adapter.SelectCommand = new SqlCommand("Select * from [Не закрытые отсутствия]", connection);
                var dt2 = new DataTable();
                adapter.Fill(dt2);
                dataGridView1.DataSource = dt2;
            }
            catch (Exception ex)
            {
                UserNotification.Error(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            foreach (var row in dataGridView3.Rows.Cast<DataGridViewRow>())
                if (!absentFromDepartmentComboBox.Items.Contains(row.Cells["Отдел"].Value))
                    absentFromDepartmentComboBox.Items.Add(row.Cells["Отдел"].Value);

            dateTimePicker2.Hide();
            label23.Hide();


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
                case ActionTabs.Absence:
                    FillAbsencePage();
                    break;
                case ActionTabs.Dissmis:
                    FillDissmisPage();
                    break;
                case ActionTabs.AddPosition:
                    FillAddPositionPage();
                    break;
                case ActionTabs.AddInspect:
                    FillMedicalInspectPage();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid Tab index");

            }

        }

        private void FillMedicalInspectPage()
        {
            try
            {
                connection.Open();
                var adapter = new SqlDataAdapter("Select * from [Сотрудники] where EndAtPractically Is NULL AND [Дата Подписания контракта] IS NOT NULL", connection);
                var dt = new DataTable();
                adapter.Fill(dt);

                medicalInspectSource.DataSource = dt;
            }
            catch (Exception ex)
            {
                UserNotification.Error(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            {
                medicalInspectDataGrid.Columns["Education"].Visible = false;
                medicalInspectDataGrid.Columns["EndAtPractically"].Visible = false;
                medicalInspectDataGrid.Columns["HumanID"].Visible = false;
                medicalInspectDataGrid.Columns["Дата Подписания контракта"].Visible = false;
                medicalInspectDataGrid.Columns["Состояние позиции"].Visible = false;
                medicalInspectDataGrid.Columns["Официальное окончание"].Visible = false;
                medicalInspectDataGrid.Columns["Зарплата"].Visible = false;
            }

            var departments = from row in medicalInspectDataGrid.Rows.Cast<DataGridViewRow>() select row.Cells["Отдел"].Value;
            medicalInspectDepartmentSelector.Items.Clear();
            foreach (var department in departments.Distinct())
                medicalInspectDepartmentSelector.Items.Add(department);
        }

        private void FillAddPositionPage()
        {

            var selectReq = connection.CreateCommand();
            selectReq.CommandText = "Select * from Requirements";
            var selectDepartments = connection.CreateCommand();
            selectDepartments.CommandText = "Select * from Departments";
            try
            {
                connection.Open();
                var reader = selectReq.ExecuteReader();
                checkedListBox1.Items.Clear();
                while (reader.Read())
                {
                    checkedListBox1.Items.Add(new Requirement(reader.GetString(1), reader.GetInt32(0)));
                }
                reader.Close();
                reader = selectDepartments.ExecuteReader();
                comboBox4.Items.Clear();
                while (reader.Read())
                {
                    comboBox4.Items.Add(new Department(reader.GetInt32(0), reader.GetString(1)));
                }

            }
            finally
            {
                connection.Close();
            }



        }

        private void FillDissmisPage()
        {
            var selectWorkers = connection.CreateCommand();
            selectWorkers.CommandText = "Select * from [Сотрудники] where EndAtPractically Is NULL";
            try
            {
                connection.Open();
                var adapter = new SqlDataAdapter("Select * from [Сотрудники] where EndAtPractically Is NULL AND [Дата Подписания контракта] IS NOT NULL", connection);
                var dt = new DataTable();
                adapter.Fill(dt);

                dissmisBindigSource.DataSource = dt;
            }
            catch (Exception ex)
            {
                UserNotification.Error(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            var departments = from row in dataGridView4.Rows.Cast<DataGridViewRow>() select row.Cells["Отдел"].Value;
            foreach (var department in departments.Distinct())
                comboBox1.Items.Add(department);
        }
        private bool CommunicationsGridIsNotEmpty()
        {
            foreach (var row in addMemberComunicationDataGrid.Rows.Cast<DataGridViewRow>())
            {
                if (!row.IsNewRow && !String.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()) && !String.IsNullOrWhiteSpace(row.Cells[1].Value.ToString()))
                    return true;
            }
            return false;

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
                if (CommunicationsGridIsNotEmpty())
                {
                    var InsertIntoComunicationCmd = "Insert into Comunications values ";
                    foreach (var item in addMemberComunicationDataGrid.Rows.Cast<DataGridViewRow>())
                    {
                        if (!item.IsNewRow && !String.IsNullOrWhiteSpace(item.Cells[1].Value.ToString()))
                            InsertIntoComunicationCmd += @"(' " + index + @"','" + item.Index + @"','" + item.Cells[1].Value.ToString() + @"'),";
                    }
                    InsertIntoComunicationCmd = InsertIntoComunicationCmd.Remove(InsertIntoComunicationCmd.Length - 1);
                    var insertIntoComunication = connection.CreateCommand();
                    insertIntoComunication.CommandText = InsertIntoComunicationCmd;
                    insertIntoComunication.Transaction = transaction;
                    insertIntoComunication.ExecuteNonQuery();
                }
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
            foreach (var position in (comboBox.SelectedItem as Department).VacantPositions)
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
            var selectedPosition = comboBox.SelectedItem as Position;
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
            holidayManSource.Filter = "[Отдел] = '" + absentFromDepartmentComboBox.SelectedItem + "'";
            foreach (var row in dataGridView3.Rows.Cast<DataGridViewRow>())
                if (row.Cells["Отдел"].Value == absentFromDepartmentComboBox.SelectedItem)
                    if (!absentFromPositionComboBox.Items.Contains(row.Cells["Должность"].Value))
                        absentFromPositionComboBox.Items.Add(row.Cells["Должность"].Value);

        }

        private void contractAddNew_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 1)
                UserNotification.Warn("Выберите одну строку");
            else
            {
                SqlTransaction trans = null;
                try
                {
                    var selectedHuman =  dataGridView2.SelectedRows[0].Cells["HumanID"].Value;
                                                                                    
                    var insertIntoContracts = connection.CreateCommand();
                    insertIntoContracts.CommandText = "Insert into Contracts  values (@HumanID,@IDPosition,@Salary,@DateOfSigning,@EndAt,NULL)";
                    insertIntoContracts.Parameters.AddWithValue("HumanID", selectedHuman);
                    insertIntoContracts.Parameters.AddWithValue("IDPosition", (contractPositionComboBox.SelectedItem as Position).ID);
                    if (Decimal.Parse(contractSalaryTextBox.Text) > Decimal.Parse(salaryLabel.Text.Replace("<=", "")))
                        throw new ArgumentOutOfRangeException("Слишком большая зарплата");
                    if (Decimal.Parse(contractSalaryTextBox.Text) < 0)
                        throw new ArgumentOutOfRangeException("Зарплата не может быть меньше нуля");
                    insertIntoContracts.Parameters.AddWithValue("Salary", Decimal.Parse(contractSalaryTextBox.Text));
                    insertIntoContracts.Parameters.AddWithValue("DateOfSigning", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                    insertIntoContracts.Parameters.AddWithValue("EndAt", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));

                    connection.Open();
                    trans = connection.BeginTransaction();


                    insertIntoContracts.Transaction = trans;
                    insertIntoContracts.ExecuteNonQuery();

                    var update = connection.CreateCommand();
                    update.Transaction = trans;
                    update.CommandText = "UPDATE Positions Set PositionStateID = " + ((contractPositionComboBox.SelectedItem as Position).State.GetPossibleStates().Count - (contractTypeSelector.SelectedItem as PositionState).ID).ToString() +
                        "  where IDPosition = " + (contractPositionComboBox.SelectedItem as Position).ID.ToString();
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
                    UserNotification.Info("Контракт успешно составлен!");
                }
                catch (Exception ex)
                {
                    if (trans != null) trans.Rollback();
                    UserNotification.Error(ex.Message);
                }
                finally { connection.Close(); }
                FillActionAddContractPage();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            var grid = sender as DataGridView;

        }

        private void mainFormTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!actionPage.IsDisposed)
                FillActionAddMemberPage();
            if (!reportPage.IsDisposed)
                reportViewer1.Refresh();


        }

        private void absentFromPositionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            holidayManSource.Filter = "[Отдел] = '" + absentFromDepartmentComboBox.SelectedItem + "' AND [Должность] = '" + absentFromPositionComboBox.SelectedItem + "'";
        }

        private void absenceAddToRegister_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedCells.Count != 1 && dataGridView3.SelectedCells.Count != 13)
            {
                UserNotification.Warn("Выбирете строку");
            }
            else
            {

                var selectedHuman = (dataGridView3.SelectedRows.Count == 1) ? dataGridView3.SelectedRows[0].Cells["HumanID"].Value :
                                                                                         dataGridView3["HumanID", dataGridView3.SelectedCells[0].RowIndex].Value;
                var insert = connection.CreateCommand();
                if (absentFromReasonComboBox.Items.Count == 4)
                    insert.CommandText = "Insert Into AbsenceRegister Values (" + selectedHuman + "," +
                        ((absentFromReasonComboBox.SelectedIndex == -1) ? 0 : absentFromReasonComboBox.SelectedIndex) +
                        ",'" + DateTime.Now.Date.ToString("yyy-MM-dd") + "'," +
                        ((absentFromReasonComboBox.SelectedIndex == _holidaySelected) ? ("'" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "'") : "NULL") + ")";
                try
                {
                    connection.Open();
                    insert.ExecuteNonQuery();
                    UserNotification.Info("Успешно добавленно.");
                }
                catch (Exception ex)
                {
                    UserNotification.Error(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                FillAbsencePage();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView3.SelectedCells.Count != 1 && dataGridView3.SelectedCells.Count != 13)
            {
                UserNotification.Warn("Выбирете строку");
            }
            else
            {
                var command = connection.CreateCommand();
                command.CommandText = "Update  [Не закрытые отсутствия] set EndAt= '" + absentToDatePicker.Value.Date.ToString("yyyy-MM-dd") +
                    "', [IDAbsenceReason] = " + ((absentFromReasonComboBox.SelectedIndex == 0 || absentFromReasonComboBox.SelectedIndex == 1) ? absentFromReasonComboBox.SelectedIndex : absentFromReasonComboBox.SelectedIndex + 1) +
                    " where [HumanID] = '" + dataGridView1["HumanID", dataGridView1.SelectedCells[0].RowIndex].Value + "'" +
                    " AND [Начиная с] = '" + dataGridView1["Начиная с", dataGridView1.SelectedCells[0].RowIndex].Value + "'";
                try
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() == 1)
                        UserNotification.Info("Успешно добавленно.");
                }
                catch (Exception ex)
                {
                    UserNotification.Error(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                FillAbsencePage();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1 || dataGridView1.SelectedCells.Count == 13)
            {
                absentToReasonComboBox.SelectedItem = dataGridView1["Причина отсутствия", dataGridView1.SelectedCells[0].RowIndex].Value;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var positions = from row in dataGridView4.Rows.Cast<DataGridViewRow>() where row.Cells["Отдел"].Value == comboBox1.SelectedItem select row.Cells["Должность"].Value;
            foreach (var position in positions.Distinct())
                comboBox2.Items.Add(position);
            dissmisBindigSource.Filter = "[Отдел]='" + comboBox1.SelectedItem + "'";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dissmisBindigSource.Filter = "[Отдел]='" + comboBox1.SelectedItem + "' and [Позиция]='" + comboBox2.SelectedItem + "'";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedCells.Count != 1 && dataGridView4.SelectedCells.Count != 13)
            {
                UserNotification.Warn("Выбирете строку");
            }
            else
            {

                var selectedHuman = (dataGridView4.SelectedRows.Count == 1) ? dataGridView4.SelectedRows[0].Cells["HumanID"].Value :
                                                                                         dataGridView4["HumanID", dataGridView4.SelectedCells[0].RowIndex].Value;
                var selectPostion = connection.CreateCommand();
                selectPostion.CommandText = "Select IDPosition from Contracts where EndAtPractically IS NULL AND HumanID=" + selectedHuman;
                var update = connection.CreateCommand();
                update.CommandText = "update Contracts set EndAtPractically='" + DateTime.Now.Date.ToString("yyy-MM-dd") + "' where EndAtPractically IS NULL AND HumanID=" + selectedHuman;
                var selectPositionState = connection.CreateCommand();
                selectPositionState.CommandText = "Select PositionStateID from Positions where IDPosition=@PositionID";
                var selectOtherContractsWithThisPosition = connection.CreateCommand();
                selectOtherContractsWithThisPosition.CommandText = "Select * from Contracts where IDPosition=@PositionID AND EndAtPractically IS NOT NULL ";
                SqlTransaction trans = null;
                try
                {

                    connection.Open();
                    trans = connection.BeginTransaction();
                    selectPostion.Transaction = trans;
                    var positionId = (int)selectPostion.ExecuteScalar();
                    selectPositionState.Transaction = trans;
                    selectPositionState.Parameters.AddWithValue("PositionID", positionId);
                    var positionState = (int)selectPositionState.ExecuteScalar();
                    update.Transaction = trans;
                    update.ExecuteNonQuery();

                    selectOtherContractsWithThisPosition.Transaction = trans;
                    selectOtherContractsWithThisPosition.Parameters.AddWithValue("PositionID", positionId);
                    var reader = selectOtherContractsWithThisPosition.ExecuteReader();
                    if (!reader.HasRows && positionId == 0)
                        positionState += 1;
                    reader.Close();

                    update.CommandText = "update Positions set PositionStateID = " + (positionState + 1) + " where IDPosition = " + positionId;
                    update.ExecuteNonQuery();
                    trans.Commit();
                    UserNotification.Info("Успешно уволен.");
                }
                catch (Exception ex)
                {
                    if (trans != null) trans.Rollback();
                    UserNotification.Error(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                FillDissmisPage();
            }
        }

        private void MainFormForAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet11.Рассписание' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'dataSet1.Рассписание' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'dataSet1.Рассписание' table. You can move, or remove it, as needed.
            try
            {
                using (Stream stream = new FileStream("UserDefinedQuery", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    userDefinedQuery = (Dictionary<string, string>)(new BinaryFormatter()).Deserialize(stream);

                }

            }
            catch { }

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void absentFromReasonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox) != null)
                if ((sender as ComboBox).SelectedIndex == _holidaySelected)
                {
                    dateTimePicker2.Show();
                    label23.Show();
                }
                else
                {
                    dateTimePicker2.Hide();
                    label23.Hide();
                }

        }

        private void MainFormForAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var stream = Stream.Synchronized(new FileStream("UserDefinedQuery",
    FileMode.OpenOrCreate, FileAccess.Write,
    FileShare.Write, 4096, true)))
                (new BinaryFormatter()).Serialize(stream, userDefinedQuery);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var addReq = new AddRequirements(connection);
            addReq.ShowDialog();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;
            try
            {
                var insertInPositions = connection.CreateCommand();
                insertInPositions.CommandText = @"Insert into Positions values(@PositionState,@Department,@Name,@SalaryMax,@Duties)";
                insertInPositions.Parameters.AddWithValue("Name", String.IsNullOrEmpty(textBox1.Text) ? null : textBox1.Text);
                Decimal.Parse(textBox2.Text);
                insertInPositions.Parameters.AddWithValue("SalaryMax", Decimal.Parse(textBox2.Text));
                insertInPositions.Parameters.AddWithValue("Department", (comboBox4.SelectedItem == null) ? null : (dynamic)(comboBox4.SelectedItem as Department).ID);
                insertInPositions.Parameters.AddWithValue("PositionState", (comboBox3.SelectedIndex == -1) ? null : (dynamic)comboBox3.SelectedIndex + 1);
                insertInPositions.Parameters.AddWithValue("Duties", richTextBox1.Text);



                connection.Open();
                transaction = connection.BeginTransaction();
                insertInPositions.Transaction = transaction;
                insertInPositions.ExecuteNonQuery();
                var selectCurrentPositionID = connection.CreateCommand();
                selectCurrentPositionID.CommandText = "Select TOP(1)IDPosition from Positions order by IDPosition desc";
                selectCurrentPositionID.Transaction = transaction;
                var index = (int)selectCurrentPositionID.ExecuteScalar();
                var InsertIntoPositionRequarementsCmd = "Insert into PositionRequirements values ";

                foreach (var item in checkedListBox1.SelectedItems.Cast<Requirement>())
                {
                    InsertIntoPositionRequarementsCmd += "(" + item.Index + "," + index + "),";

                }
                InsertIntoPositionRequarementsCmd = InsertIntoPositionRequarementsCmd.Remove(InsertIntoPositionRequarementsCmd.Length - 1);
                var insertIntoComunication = connection.CreateCommand();
                insertIntoComunication.CommandText = InsertIntoPositionRequarementsCmd;
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

        private void medicalInspectDepartmentSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var positions = from row in medicalInspectDataGrid.Rows.Cast<DataGridViewRow>() 
                            where row.Cells["Отдел"].Value == medicalInspectDepartmentSelector.SelectedItem select row.Cells["Должность"].Value;
            foreach (var position in positions.Distinct())
                medicalInspectPositionSelector.Items.Add(position);

            medicalInspectSource.Filter = "[Отдел]='" + medicalInspectDepartmentSelector.SelectedItem + "'";
        }

        private void medicalInspectDataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            var index = (int)(sender as DataGridView).SelectedRows[0].Cells["HumanID"].Value;
            MedicalInspectForm view = new MedicalInspectForm(index, connection);
            view.ShowDialog();

        }

        private void medicalInspectPositionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

            medicalInspectSource.Filter = "[Отдел]='" + medicalInspectDepartmentSelector.SelectedItem + 
                "' and [Позиция]='"+medicalInspectPositionSelector.SelectedItem+"'";
        }

    }
    public class Requirement : IEquatable<Requirement>
    {
        public string Name { get; private set; }
        public int Index { get; private set; }
        public Requirement(string name, int index)
        {
            Name = name;
            Index = index;

        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(Requirement other)
        {
            return Index == other.Index;
        }
    }

}
