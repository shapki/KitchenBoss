using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    /// <summary>
    /// TODO: Подогнать под требования
    /// TODO: Написать summary-комментарии
    /// </summary>
    public partial class fmPasswordRecovery : Form
    {
        private string _tempCode;
        private int? _employeeId;
        private bool _showingNewPassword = false;
        private bool _showingConfirmPassword = false;

        public fmPasswordRecovery()
        {
            InitializeComponent();

            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
            btnCancel.Size = new Size(340, 36);
            btnCancel.Location = new Point(30, 195);
            Size = new Size(416, 287);
        }

        private void TogglePasswordVisibility(TextBox passwordBox, PictureBox eyeIcon, ref bool showingPassword)
        {
            showingPassword = !showingPassword;
            passwordBox.UseSystemPasswordChar = !showingPassword;
            eyeIcon.Image = showingPassword
                ? KitchenBoss.Properties.Resources.regular_eye_DISMISS_x20
                : KitchenBoss.Properties.Resources.regular_eye_x20;
        }

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
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении пароля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pictureBoxNewPassword_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(txtNewPassword, pictureBoxNewPassword, ref _showingNewPassword);
        }

        private void pictureBoxConfirmPassword_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility(txtConfirmPassword, pictureBoxConfirmPassword, ref _showingConfirmPassword);
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