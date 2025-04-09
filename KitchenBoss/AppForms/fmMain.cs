using System;
using System.Linq;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    /// <summary>
    /// TODO: Подогнать под требования
    /// TODO: Написать код для кнопок-переходов к другим формам
    /// TODO: Написать summary-комментарии
    /// </summary>
    public partial class fmMain : Form
    {
        public fmMain(string username)
        {
            InitializeComponent();
            string employeeFullNameAndPosition = GetEmployeeFullNameAndPosition(username);
            loginAndPositionLabel.Text = employeeFullNameAndPosition;

            string position = GetUserPosition(username);

            userControlButton.Enabled = (position == "Менеджер");
        }

        private string GetEmployeeFullNameAndPosition(string username)
        {
            try
            {
                using (var context = Program.context)
                {
                    var user = context.Users.FirstOrDefault(u => u.Username == username);
                    var result = $"ФИО: Пользователь не найден\nДоступ: Должность не найдена";

                    if (user != null)
                    {
                        var employee = context.Employees.FirstOrDefault(e => e.EmployeeID == user.EmployeeID);

                        if (employee != null)
                        {
                            string fullName = $"{employee.FirstName} {employee.LastName}";

                            if (user.Position != null)
                                result = $"ФИО: {fullName}\nДоступ: {user.Position.PositionName}";
                            else
                                result = $"ФИО: {fullName}\nДоступ: Должность не найдена";
                        }
                        else
                            result = $"ФИО: Сотрудник не найден\nДоступ: Должность не найдена";
                    }

                    return result;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Ошибка при получении данных сотрудника: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Ошибка";
            }
        }

        private string GetUserPosition(string username)
        {
            try
            {
                using (var context = Program.context)
                {
                    var user = context.Users.FirstOrDefault(u => u.Username == username);

                    if (user != null && user.Position != null)
                    {
                        return user.Position.PositionName;
                    }

                    return string.Empty;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Ошибка при получении должности пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public static void CloseSpecificForms()
        {
            var formsToClose = new[]
            {
                typeof(fmUserControl),
                typeof(fmClients),
                typeof(fmDishes),
                typeof(fmEmployees)
            };

            Form[] openForms = Application.OpenForms.Cast<Form>().ToArray();

            foreach (Form openForm in openForms)
                if (formsToClose.Contains(openForm.GetType()))
                    openForm.Close();
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
                e.Cancel = true;
        }

        private void fmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogoutAndReturnToLogin(e);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            LogoutAndReturnToLogin();
        }

        private void employeesButton_Click(object sender, System.EventArgs e)
        {
            fmEmployees employeesForm = new fmEmployees();
            employeesForm.Show();
        }

        private void userControlButton_Click(object sender, System.EventArgs e)
        {
            fmUserControl userControlForm = new fmUserControl();
            userControlForm.Show();
        }

        private void dishesButton_Click(object sender, System.EventArgs e)
        {
            fmDishes dishesForm = new fmDishes();
            dishesForm.Show();
        }

        private void clientsButton_Click(object sender, System.EventArgs e)
        {
            fmClients clientsForm = new fmClients();
            clientsForm.Show();
        }
    }
}
