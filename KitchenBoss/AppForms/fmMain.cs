using System;
using System.Linq;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    /// <summary>
    /// PKGH Главная форма.
    /// </summary>
    public partial class fmMain : Form
    {
        private int _employeeId;

        public fmMain(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId; // Сохраняем ID сотрудника
            InitializeEmployeeInfo();
            ConfigureAccessRights();
        }

        /// <summary>
        /// PKGH Инициализация информации о сотруднике на форме.
        /// </summary>
        private void InitializeEmployeeInfo()
        {
            string employeeFullNameAndPosition = GetEmployeeFullNameAndPosition(_employeeId);
            loginAndPositionLabel.Text = employeeFullNameAndPosition;
        }

        /// <summary>
        /// PKGH Настройка прав доступа на основе должности сотрудника.
        /// </summary>
        private void ConfigureAccessRights()
        {
            string position = GetUserPosition(_employeeId);
            userControlButton.Enabled = (position == "Менеджер");
            clientsButton.Enabled = (position != "Повар" || position != "Повар-стажер");
        }

        /// <summary>
        /// PKGH Получение ФИО и должности сотрудника.
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника.</param>
        /// <returns>Строка с ФИО и должностью сотрудника.</returns>
        private string GetEmployeeFullNameAndPosition(int employeeId)
        {
            try
            {
                using (var context = Program.context)
                {
                    var employee = context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
                    if (employee == null)
                    {
                        return "Сотрудник не найден\nДоступ: Не определён";
                    }

                    var position = context.Positions.FirstOrDefault(p => p.PositionID == employee.PositionID);
                    string fullName = $"{employee.FirstName} {employee.LastName}";
                    string positionName = position?.PositionName ?? "Не определена";
                    return $"ФИО: {fullName}\nДоступ: {positionName}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении данных сотрудника: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Ошибка";
            }
        }

        /// <summary>
        /// PKGH Получение должности сотрудника.
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника.</param>
        /// <returns>Название должности сотрудника.</returns>
        private string GetUserPosition(int employeeId)
        {
            try
            {
                using (var context = Program.context)
                {
                    var employee = context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
                    if (employee == null)
                    {
                        return string.Empty;
                    }

                    var position = context.Positions.FirstOrDefault(p => p.PositionID == employee.PositionID);
                    return position?.PositionName ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении должности пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        /// <summary>
        /// PKGH Закрытие определённых форм.
        /// </summary>
        public static void CloseSpecificForms()
        {
            var formsToClose = new[]
            {
                typeof(fmTableViewer)
            };

            foreach (Form openForm in Application.OpenForms.Cast<Form>().ToArray())
            {
                if (formsToClose.Contains(openForm.GetType()))
                {
                    openForm.Close();
                }
            }
        }

        private void LogoutAndReturnToLogin()
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                CloseSpecificForms();
                this.Hide();
                fmLogin loginForm = new fmLogin();
                loginForm.Show();
            }
        }

        private void LogoutAndReturnToLogin(FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                CloseSpecificForms();
                fmLogin loginForm = new fmLogin();
                loginForm.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void fmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogoutAndReturnToLogin(e);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            LogoutAndReturnToLogin();
        }

        private void employeesButton_Click(object sender, EventArgs e)
        {
            fmTableViewer employeesForm = new fmTableViewer(employeeId: _employeeId);
            employeesForm.Show();
        }

        private void userControlButton_Click(object sender, EventArgs e)
        {
            fmTableViewer userControlForm = new fmTableViewer(userControlMode: true, employeeId: _employeeId);
            userControlForm.Show();
        }

        private void dishesButton_Click(object sender, EventArgs e)
        {
            fmTableViewer dishesForm = new fmTableViewer(dishesMode: true, employeeId: _employeeId);
            dishesForm.Show();
        }

        private void clientsButton_Click(object sender, EventArgs e)
        {
            fmTableViewer clientsForm = new fmTableViewer(customerMode: true, employeeId: _employeeId);
            clientsForm.Show();
        }

        private void ordersButton_Click(object sender, EventArgs e)
        {
            fmTableViewer ordersForm = new fmTableViewer(ordersMode: true, employeeId: _employeeId);
            ordersForm.Show();
        }

        private void tablesButton_Click(object sender, EventArgs e)
        {
            fmTableViewer tableForm = new fmTableViewer(tablesMode: true, employeeId: _employeeId);
            tableForm.Show();
        }
    }
}