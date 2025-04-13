using System;
using System.Linq;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    public partial class fmMain : Form
    {
        private int _employeeID; // Для хранения ID сотрудника

        public fmMain(int employeeID)
        {
            InitializeComponent();
            _employeeID = employeeID; // Сохраняем EmployeeID

            // Получаем ФИО и должность сотрудника
            string employeeFullNameAndPosition = GetEmployeeFullNameAndPosition(_employeeID);
            loginAndPositionLabel.Text = employeeFullNameAndPosition;

            // Определяем права доступа на основе должности
            string position = GetUserPosition(_employeeID);
            userControlButton.Enabled = (position == "Менеджер");
        }

        private string GetEmployeeFullNameAndPosition(int employeeID)
        {
            try
            {
                using (var context = Program.context)
                {
                    var employee = context.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);
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

        private string GetUserPosition(int employeeID)
        {
            try
            {
                using (var context = Program.context)
                {
                    var employee = context.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);
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

        public static void CloseSpecificForms()
        {
            var formsToClose = new[]
            {
                typeof(fmDishes),
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
            fmTableViewer employeesForm = new fmTableViewer();
            employeesForm.Show();
        }

        private void userControlButton_Click(object sender, EventArgs e)
        {
            //fmUserControl userControlForm = new fmUserControl();
            //userControlForm.Show();
            fmTableViewer userControlForm = new fmTableViewer(false, false, false, null, null, false, true);
            userControlForm.Show();
        }

        private void dishesButton_Click(object sender, EventArgs e)
        {
            fmDishes dishesForm = new fmDishes();
            dishesForm.Show();
        }

        private void clientsButton_Click(object sender, EventArgs e)
        {
            fmTableViewer clientsForm = new fmTableViewer(false, true);
            clientsForm.Show();
        }

        private void ordersButton_Click(object sender, EventArgs e)
        {
            fmTableViewer ordersForm = new fmTableViewer(false, false, true);
            ordersForm.Show();
        }

        private void tablesButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}