using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    /// <summary>
    /// PKGH Форма для восстановления пароля пользователя.
    /// </summary>
    public partial class fmPasswordRecovery : Form
    {
        private string _tempCode;
        private int? _employeeId;
        private bool _isShowingNewPassword = false;
        private bool _isShowingConfirmPassword = false;

        public fmPasswordRecovery()
        {
            InitializeComponent();
            InitializeFormControls();
        }

        /// <summary>
        /// PKGH Инициализация элементы управления формы.
        /// </summary>
        private void InitializeFormControls()
        {
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
            btnCancel.Size = new Size(340, 36);
            btnCancel.Location = new Point(30, 195);
            Size = new Size(416, 287);
        }

        /// <summary>
        /// PKGH Переключение видимости пароля в текстовом поле.
        /// </summary>
        /// <param name="passwordBox">Текстовое поле для ввода пароля.</param>
        /// <param name="eyeIcon">Иконка для отображения состояния видимости пароля.</param>
        /// <param name="isShowingPassword">Флаг, указывающий текущее состояние видимости пароля.</param>
        private void TogglePasswordVisibility(TextBox passwordBox, PictureBox eyeIcon, ref bool isShowingPassword)
        {
            isShowingPassword = !isShowingPassword;
            passwordBox.UseSystemPasswordChar = !isShowingPassword;
            eyeIcon.Image = isShowingPassword
                ? KitchenBoss.Properties.Resources.regular_eye_DISMISS_x20
                : KitchenBoss.Properties.Resources.regular_eye_x20;
        }

        /// <summary>
        /// PKGH Обработка отправки кода подтверждения на email или телефон.
        /// </summary>
        private void btnSendCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmailAndPhone.Text))
            {
                MessageBox.Show("Введите email или номер телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var employee = Program.context.Employees
                    .FirstOrDefault(emp => emp.Email == txtEmailAndPhone.Text.Trim() ||
                                         emp.PhoneNumber == txtEmailAndPhone.Text.Trim());

                if (employee == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _employeeId = employee.EmployeeID;
                var random = new Random();
                _tempCode = random.Next(100000, 999999).ToString();

                MessageBox.Show($"Демо-режим: код для восстановления - {_tempCode}",
                    "Код восстановления", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pnlCodeVerification.Visible = true;
                btnSendCode.Enabled = false;
                btnCancel.Location = new Point(30, 350);
                Size = new Size(416, 439);
                txtCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// PKGH Проверка введенного кода подтверждения.
        /// </summary>
        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtCode.Text != _tempCode)
            {
                MessageBox.Show("Неверный код подтверждения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            pnlPasswordChange.Visible = true;
            pnlCodeVerification.Visible = false;
            btnCancel.Size = new Size(160, 36);
            txtNewPassword.Focus();
        }

        /// <summary>
        /// PKGH Сохранение нового пароля пользователя.
        /// </summary>
        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Введите новый пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = Program.context)
                {
                    var user = context.Users.FirstOrDefault(u => u.EmployeeID == _employeeId);
                    if (user == null)
                    {
                        MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newSalt = Guid.NewGuid();
                    string hashedPassword = HashPassword(txtNewPassword.Text, newSalt.ToString());
                    user.PasswordHash = Convert.FromBase64String(hashedPassword);
                    user.PasswordSalt = newSalt;
                    context.SaveChanges();

                    MessageBox.Show("Пароль успешно изменен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении пароля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            using (var sha512 = System.Security.Cryptography.SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(passwordWithSalt);
                byte[] hashBytes = sha512.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void pictureBoxNewPassword_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(txtNewPassword, pictureBoxNewPassword, ref _isShowingNewPassword);
        }

        private void pictureBoxConfirmPassword_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(txtConfirmPassword, pictureBoxConfirmPassword, ref _isShowingConfirmPassword);
        }

        private void txtEmailAndPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSendCode.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void txtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSavePassword.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSavePassword.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnVerify.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}