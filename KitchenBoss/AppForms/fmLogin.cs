using KitchenBoss.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    /// <summary>
    /// PKGH Форма для авторизации пользователя.
    /// </summary>
    public partial class fmLogin : Form
    {
        private bool _isShowingPassword = true;

        public fmLogin()
        {
            InitializeComponent();
        }

        private void showPasswordPictureBox_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
        }

        /// <summary>
        /// PKGH Изменение видимости символов в текстовом поле пароля.
        /// </summary>
        private void TogglePasswordVisibility()
        {
            _isShowingPassword = !_isShowingPassword;
            passwordTextBox.UseSystemPasswordChar = _isShowingPassword;
            showPasswordPictureBox.Image = _isShowingPassword
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
                var employee = Program.context.Employees
                    .FirstOrDefault(emp => emp.PhoneNumber == loginInput || emp.Email == loginInput);

                if (employee == null)
                {
                    MessageBox.Show("Неверный логин или пароль.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = Program.context.Users.FirstOrDefault(u => u.EmployeeID == employee.EmployeeID);
                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string salt = user.PasswordSalt.ToString();
                string hashedPassword = HashPassword(password, salt);

                if (Convert.ToBase64String(user.PasswordHash) == hashedPassword)
                {
                    OpenMainForm(employee.EmployeeID);
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

        /// <summary>
        /// PKGH Открытие главной формы приложения.
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника.</param>
        private void OpenMainForm(int employeeId)
        {
            var mainForm = new fmMain(employeeId);
            mainForm.Show();
            this.Hide();
        }

        /// <summary>
        /// PKGH Хеширование пароля с использованием соли.
        /// </summary>
        /// <param name="password">Пароль для хэширования.</param>
        /// <param name="salt">Соль для усиления безопасности.</param>
        /// <returns>Хэшированный пароль в формате Base64.</returns>
        private string HashPassword(string password, string salt)
        {
            string passwordWithSalt = salt + password;
            using (var sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(passwordWithSalt);
                byte[] hashBytes = sha512.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CloseLoginForm();
        }

        private void CloseLoginForm()
        {
            this.FormClosing -= fmLogin_FormClosing;
            DialogResult result = MessageBox.Show(
                "Вы действительно хотите выйти из приложения?",
                "Внимание",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                foreach (Form openForm in Application.OpenForms.Cast<Form>().ToArray())
                {
                    openForm.Close();
                }
            }
            else
            {
                this.FormClosing += fmLogin_FormClosing;
            }
        }

        private void fmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            HandleFormClosing(e);
        }

        /// <summary>
        /// PKGH Обработка запроса на закрытие формы.
        /// </summary>
        private void HandleFormClosing(FormClosingEventArgs e)
        {
            this.FormClosing -= fmLogin_FormClosing;
            DialogResult result = MessageBox.Show(
                "Вы действительно хотите выйти из приложения?",
                "Внимание",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                foreach (Form openForm in Application.OpenForms.Cast<Form>().ToArray())
                {
                    openForm.Close();
                }
            }
            else
            {
                e.Cancel = true;
                this.FormClosing += fmLogin_FormClosing;
            }
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

        private void recoveryLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var recoveryForm = new fmPasswordRecovery())
            {
                if (recoveryForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(
                        "Пароль успешно изменен. Теперь вы можете войти с новым паролем.",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }
    }
}