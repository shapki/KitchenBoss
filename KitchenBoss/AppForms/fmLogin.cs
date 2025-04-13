using KitchenBoss.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    public partial class fmLogin : Form
    {
        private bool _showingPassword = true;

        public fmLogin()
        {
            InitializeComponent();
        }

        private void showPasswordPictureBox_Click(object sender, EventArgs e)
        {
            ChangePasswordCharsVisibility();
        }

        private void ChangePasswordCharsVisibility()
        {
            _showingPassword = !_showingPassword;
            passwordTextBox.UseSystemPasswordChar = _showingPassword;
            showPasswordPictureBox.Image = _showingPassword
                ? Resources.regular_eye_x20
                : Resources.regular_eye_DISMISS_x20;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string loginInput = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(loginInput) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Ищем сотрудника по телефону или email
                System.Linq.Expressions.Expression<Func<AppModels.Employee, bool>> predicate = emp => emp.PhoneNumber == loginInput || emp.Email == loginInput;

                var employee = Program.context.Employees.FirstOrDefault(predicate);

                if (employee == null)
                {
                    MessageBox.Show("Неверный логин или пароль.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ищем пользователя по EmployeeID
                var user = Program.context.Users.FirstOrDefault(u => u.EmployeeID == employee.EmployeeID);

                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Хешируем введённый пароль
                string salt = user.PasswordSalt.ToString();
                string hashedPassword = HashPassword(password, salt);

                if (Convert.ToBase64String(user.PasswordHash) == hashedPassword)
                {
                    // Открываем главную форму
                    fmMain mainForm = new fmMain(employee.EmployeeID);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подключении к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CloseFormEvent();
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

        private void CloseFormEvent(FormClosingEventArgs e)
        {
            this.FormClosing -= fmLogin_FormClosing;

            DialogResult result = MessageBox.Show("Вы действительно хотите выйти\nиз приложения?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                foreach (Form openForm in Application.OpenForms.Cast<Form>().ToArray())
                    openForm.Close();
            else
            {
                e.Cancel = true;
                this.FormClosing += fmLogin_FormClosing;
            }
        }

        private void CloseFormEvent()
        {
            this.FormClosing -= fmLogin_FormClosing;

            DialogResult result = MessageBox.Show("Вы действительно хотите выйти\nиз приложения?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                foreach (Form openForm in Application.OpenForms.Cast<Form>().ToArray())
                    openForm.Close();
        }

        private void fmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseFormEvent(e);
        }

        private void usernameTextBox_Enter(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "Телефон или почта")
            {
                usernameTextBox.Text = "";
                usernameTextBox.ForeColor = Color.FromArgb(30, 30, 30);
            }
        }

        private void usernameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                usernameTextBox.Text = "Телефон или почта";
                usernameTextBox.ForeColor = Color.FromArgb(150, 150, 150);
            }
        }
    }
}