using KitchenBoss.AppModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    public partial class fmUserControl : Form
    {
        private List<User> _usersList;
        private List<Employee> _employeesList;
        private List<Position> _positionsList;
        private const string PasswordPlaceholder = "*****";

        public fmUserControl()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            LoadEmployees();
            LoadPositions();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                _usersList = Program.context?.Users
                    .Include(u => u.Employee)
                    .Include(u => u.Position)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке пользователей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            usersDgv.Rows.Clear();

            if (_usersList != null)
            {
                foreach (var user in _usersList)
                {
                    usersDgv.Rows.Add(
                        user.Username,
                        PasswordPlaceholder, // Отображаем пароль как *****
                        user.Employee,
                        user.Position,
                        user
                    );
                }
            }

            UpdateEmployeeComboBox();
            UpdatePositionComboBox();
        }

        private void LoadEmployees()
        {
            try
            {
                _employeesList = Program.context?.Employees.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сотрудников: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateEmployeeComboBox();
        }

        private void LoadPositions()
        {
            try
            {
                _positionsList = Program.context?.Positions.ToList();

                UpdatePositionComboBox();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке должностей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void UpdateEmployeeComboBox()
        {
            try
            {
                var assignedEmployeeIds = _usersList?.Where(u => u.EmployeeID != null).Select(u => u.EmployeeID).ToList();
                List<Employee> availableEmployees = _employeesList?.Where(e => assignedEmployeeIds != null && !assignedEmployeeIds.Contains(e.EmployeeID)).ToList();

                DataGridViewComboBoxColumn employeeColumn = (DataGridViewComboBoxColumn)usersDgv.Columns["employee"];

                if (availableEmployees != null && availableEmployees.Any())
                {
                    employeeColumn.DataSource = availableEmployees;
                    employeeColumn.DisplayMember = "FirstName";
                    employeeColumn.ValueMember = "EmployeeID";
                }
                else
                {
                    employeeColumn.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении ComboBox сотрудников: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePositionComboBox()
        {
            try
            {
                DataGridViewComboBoxColumn positionColumn = (DataGridViewComboBoxColumn)usersDgv.Columns["position"];
                if (_positionsList == null || !_positionsList.Any())
                {
                    MessageBox.Show("Список должностей пуст!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                positionColumn.DataSource = _positionsList;
                positionColumn.DisplayMember = "PositionName";
                positionColumn.ValueMember = "PositionID";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении ComboBox должностей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.context == null)
                {
                    MessageBox.Show("Контекст базы данных не инициализирован.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow row in usersDgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    string username = row.Cells["username"].Value?.ToString();
                    string password = row.Cells["password"].Value?.ToString();

                    int? employeeId = null;
                    int? positionId = null;

                    if (row.Cells["employee"].Value != null && row.Cells["employee"].Value != DBNull.Value)
                    {
                        if (row.Cells["employee"].Value is int empId)
                        {
                            employeeId = empId;
                        }
                        else
                        {
                            MessageBox.Show("Некорректный тип данных для сотрудника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не выбран сотрудник.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }


                    if (row.Cells["position"].Value != null && row.Cells["position"].Value != DBNull.Value)
                    {
                        if (row.Cells["position"].Value is int posId)
                        {
                            positionId = posId;
                        }
                        else
                        {
                            MessageBox.Show("Некорректный тип данных для должности.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не выбран уровень доступа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }



                    User existingUser = row.Cells[usersDgv.Columns.Count - 1].Value as User;

                    if (existingUser == null)
                    {
                        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || !employeeId.HasValue || !positionId.HasValue)
                        {
                            MessageBox.Show("Пожалуйста, заполните все поля для нового пользователя.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }

                        var newSalt = Guid.NewGuid();
                        string hashedPassword = HashPassword(password, newSalt.ToString());

                        var newUser = new User
                        {
                            Username = username,
                            PasswordHash = Convert.FromBase64String(hashedPassword),
                            PasswordSalt = newSalt,
                            EmployeeID = employeeId.Value,
                            PositionID = positionId.Value
                        };

                        Program.context.Users.Add(newUser);
                    }
                    else
                    {
                        if (existingUser.Username != username)
                        {
                            existingUser.Username = username;
                        }
                        if (password != PasswordPlaceholder && !string.IsNullOrEmpty(password))
                        {
                            var newSalt = Guid.NewGuid();
                            string hashedPassword = HashPassword(password, newSalt.ToString());

                            existingUser.PasswordHash = Convert.FromBase64String(hashedPassword);
                            existingUser.PasswordSalt = newSalt;
                        }
                    }
                }

                Program.context.SaveChanges();
                MessageBox.Show("Изменения успешно сохранены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                saveButton.Enabled = false;
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password, string salt)
        {
            string passwordWithSalt = salt + password;
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(passwordWithSalt);
                byte[] hashBytes = sha512.ComputeHash(bytes);

                return Convert.ToBase64String(hashBytes);
            }
        }


        private void usersDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                saveButton.Enabled = true;
        }

        private void usersDgv_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            saveButton.Enabled = true;
        }

        private void usersDgv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            saveButton.Enabled = true;
            try
            {
                if (Program.context == null)
                {
                    MessageBox.Show("Контекст базы данных не инициализирован.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                User deletedUser = e.Row.Cells[usersDgv.Columns.Count - 1].Value as User;

                if (deletedUser != null)
                {
                    Program.context.Users.Remove(deletedUser);
                    Program.context.SaveChanges();

                    MessageBox.Show("Пользователь успешно удален.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    saveButton.Enabled = false;
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usersDgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            saveButton.Enabled = true;
        }
    }
}
