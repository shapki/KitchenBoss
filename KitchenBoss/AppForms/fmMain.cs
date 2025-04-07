using System.Linq;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
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

        private void fmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            fmLogin loginForm = new fmLogin();
            loginForm.Show();
        }

        private void logoutButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
