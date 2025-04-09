using KitchenBoss.AppModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    /// <summary>
    /// TODO: Подогнать под требования
    /// TODO: Написать код для вывода изменяемого списка должностей
    /// TODO: Написать summary-комментарии
    /// </summary>
    public partial class fmEmployees : Form
    {
        private bool isChanged = false;
        private readonly List<EmployeeViewModel> deletedEmployees = new List<EmployeeViewModel>();

        public fmEmployees()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadData();
        }

        private void SetupDataGridView()
        {
            employeesDgv.AutoGenerateColumns = false;
            employeesDgv.AllowUserToAddRows = true;

            var employeeIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "EmployeeID",
                HeaderText = "ID",
                DataPropertyName = "EmployeeID",
                Visible = false
            };
            employeesDgv.Columns.Add(employeeIdColumn);

            var nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "ФИО",
                DataPropertyName = "FullName"
            };
            employeesDgv.Columns.Add(nameColumn);

            var positionColumn = new DataGridViewComboBoxColumn
            {
                Name = "PositionID",
                HeaderText = "Должность",
                DataPropertyName = "PositionID"
            };
            employeesDgv.Columns.Add(positionColumn);

            var hireDateColumn = new DataGridViewTextBoxColumn
            {
                Name = "HireDate",
                HeaderText = "Дата найма",
                DataPropertyName = "HireDate"
            };
            hireDateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";
            employeesDgv.Columns.Add(hireDateColumn);

            var salaryColumn = new DataGridViewTextBoxColumn
            {
                Name = "Salary",
                HeaderText = "Зарплата",
                DataPropertyName = "Salary"
            };
            salaryColumn.DefaultCellStyle.Format = "N2";
            salaryColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("ru-RU");
            employeesDgv.Columns.Add(salaryColumn);

            var emailColumn = new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email"
            };
            employeesDgv.Columns.Add(emailColumn);

            var phoneColumn = new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                HeaderText = "Телефон",
                DataPropertyName = "PhoneNumber"
            };
            employeesDgv.Columns.Add(phoneColumn);
        }

        private int GenerateNewEmployeeID()
        {
            using (var context = Program.context)
            {
                return context.Employees.Any() ? context.Employees.Max(e => e.EmployeeID) + 1 : 1;
            }
        }

        private void LoadData()
        {
            using (var context = Program.context)
            {
                var positions = context.Positions.ToList();
                var positionColumn = (DataGridViewComboBoxColumn)employeesDgv.Columns["PositionID"];
                foreach (var position in positions)
                {
                    positionColumn.Items.Add(new ComboboxItem
                    {
                        Text = position.PositionName,
                        Value = position.PositionID
                    });
                }
                positionColumn.DisplayMember = "Text";
                positionColumn.ValueMember = "Value";

                var employees = context.Employees
                    .Include(e => e.Position)
                    .ToList()
                    .Select(e => new EmployeeViewModel
                    {
                        EmployeeID = e.EmployeeID,
                        FullName = $"{e.FirstName} {e.LastName}",
                        PositionID = e.PositionID,
                        HireDate = e.HireDate,
                        Salary = e.Salary,
                        Email = e.Email,
                        PhoneNumber = e.PhoneNumber
                    }).ToList();

                employeesDgv.DataSource = new BindingList<EmployeeViewModel>(employees);
            }
        }

        private void employeesDgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException || e.Exception is ArgumentException)
                e.Cancel = true;
        }

        private void employeesDgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (employeesDgv.IsCurrentCellDirty && employeesDgv.CurrentCell is DataGridViewComboBoxCell)
            {
                employeesDgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                isChanged = true;
                saveButton.Enabled = true;
            }
        }

        private void employeesDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            isChanged = true;
            saveButton.Enabled = true;
        }

        private void employeesDgv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            isChanged = true;
            saveButton.Enabled = true;
        }

        private void positionsButton_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            using (var context = Program.context)
            {
                try
                {
                    foreach (DataGridViewRow row in employeesDgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
                        var employee = context.Employees.Find(employeeId);

                        if (employee != null)
                        {
                            var fullName = row.Cells["FullName"].Value.ToString().Split(' ');
                            employee.FirstName = fullName[0];
                            employee.LastName = fullName.Length > 1 ? fullName[1] : "";

                            object positionValue = row.Cells["PositionID"].Value;
                            if (positionValue is ComboboxItem comboboxItem)
                            {
                                employee.PositionID = (int)comboboxItem.Value;
                            }
                            else if (positionValue is int intValue)
                            {
                                employee.PositionID = intValue;
                            }
                            else
                            {
                                throw new InvalidOperationException("Неверный тип значения для PositionID");
                            }

                            employee.HireDate = Convert.ToDateTime(row.Cells["HireDate"].Value);
                            employee.Salary = decimal.Parse(row.Cells["Salary"].Value?.ToString()?.Replace(" ", "") ?? "0");
                            employee.Email = row.Cells["Email"].Value?.ToString();
                            employee.PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString();
                        }
                        else
                        {
                            var fullName = row.Cells["FullName"].Value.ToString().Split(' ');
                            var positionValue = row.Cells["PositionID"].Value;
                            int positionId;

                            if (positionValue is ComboboxItem comboboxItem)
                            {
                                positionId = (int)comboboxItem.Value;
                            }
                            else if (positionValue is int intValue)
                            {
                                positionId = intValue;
                            }
                            else
                            {
                                throw new InvalidOperationException("Неверный тип значения для PositionID");
                            }

                            var newEmployee = new Employee
                            {
                                FirstName = fullName[0],
                                LastName = fullName.Length > 1 ? fullName[1] : "",
                                PositionID = positionId,
                                HireDate = Convert.ToDateTime(row.Cells["HireDate"].Value),
                                Salary = decimal.Parse(row.Cells["Salary"].Value?.ToString()?.Replace(" ", "") ?? "0"),
                                Email = row.Cells["Email"].Value?.ToString(),
                                PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString()
                            };

                            context.Employees.Add(newEmployee);
                        }
                    }

                    foreach (var deletedEmployee in deletedEmployees)
                    {
                        var employee = context.Employees.Find(deletedEmployee.EmployeeID);
                        if (employee != null)
                        {
                            context.Employees.Remove(employee);
                        }
                    }

                    deletedEmployees.Clear();

                    context.SaveChanges();
                    isChanged = false;
                    saveButton.Enabled = false;

                    MessageBox.Show("Данные успешно сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateData()
        {
            foreach (DataGridViewRow row in employeesDgv.Rows)
            {
                if (row.IsNewRow) continue;

                var fullName = row.Cells["FullName"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(fullName) || fullName.Split(' ').Length != 2)
                {
                    MessageBox.Show("В поле ФИО должно быть ровно 2 слова (Имя и Фамилия)", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(row.Cells["PositionID"].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells["HireDate"].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells["Salary"].Value?.ToString()))
                {
                    MessageBox.Show("Первые 4 столбца не могут быть пустыми", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(row.Cells["Email"].Value?.ToString()) &&
                    string.IsNullOrWhiteSpace(row.Cells["PhoneNumber"].Value?.ToString()))
                {
                    MessageBox.Show("Должен быть заполнен хотя бы один контакт (Email или Телефон)", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void employeesDgv_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (employeesDgv.Columns["PositionID"] is DataGridViewComboBoxColumn positionColumn && positionColumn.Items.Count > 0)
            {
                e.Row.Cells["PositionID"].Value = ((ComboboxItem)positionColumn.Items[0]).Value;
            }
        }

        private void employeesDgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.IsNewRow)
            {
                var employee = e.Row.DataBoundItem as EmployeeViewModel;
                if (employee != null)
                {
                    if (employee.EmployeeID > 0)
                    {
                        deletedEmployees.Add(employee);
                        isChanged = true;
                        saveButton.Enabled = true;
                    }

                    ((BindingList<EmployeeViewModel>)employeesDgv.DataSource).Remove(employee);
                }
            }
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public int PositionID { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }   
}