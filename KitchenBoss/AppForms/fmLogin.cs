using KitchenBoss.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    /// <summary>
    /// TODO: Подогнать под требования
    /// TODO: Написать summary-комментарии
    /// </summary>
    public partial class fmLogin : Form
    {
        private bool _showingPassword = true;

        public fmLogin()
        {
            InitializeComponent();
            HelpButtonClicked += HelpButton_Click;
        }

        private void HelpButton_Click(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("KitchenBoss - это приложение, предназначенное для автоматизации ключевых бизнес-процессов в ресторане." +
                "\nПриложение позволяет управлять:" +
                "\n• Меню и ингредиентами" +
                "\n• Сотрудниками и должностями" +
                "\n• Заказами и статусами" +
                "\n• Клиентами и столиками" +
                "\n• Финансовыми операциями (частично)", "KitchenBoss - Информация", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                e.Cancel = true;
        }

        private void showPasswordPictureBox_Click(object sender, EventArgs e)
        {
            ChangePasswordCharsVisibility();
        }

        private void ChangePasswordCharsVisibility()
        {
            _showingPassword = !_showingPassword;
            passwordTextBox.UseSystemPasswordChar = _showingPassword;

            if (_showingPassword)
                showPasswordPictureBox.Image = Resources.regular_eye_DISMISS_x20;
            else
                showPasswordPictureBox.Image = Resources.regular_eye_x20;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = Program.context.Users.FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    MessageBox.Show("Неверный логин или пароль.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string salt = user.PasswordSalt.ToString();
                string hashedPassword = HashPassword(password, salt);

                if (Convert.ToBase64String(user.PasswordHash) == hashedPassword)
                {
                    fmMain mainForm = new fmMain(username);
                    mainForm.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Неверный логин или пароль.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
