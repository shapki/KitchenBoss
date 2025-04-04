using KitchenBoss.Properties;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    // TODO:
    // главную форму, в которой будет header и у самой формы будут свойства, которые надо будет наследовать другими формами проекта
    public partial class fmLogin : Form
    {
        private bool _showingPassword = false;
        private Timer _delayTimer;

        public fmLogin()
        {
            InitializeComponent();
            Icon = Resources.chef_hat;
            HelpButtonClicked += HelpButton_Click;

            _delayTimer = new Timer();
            _delayTimer.Interval = 2000;
            _delayTimer.Tick += DelayTimer_Tick;
            _delayTimer.Start();
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

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            _delayTimer.Stop();
            _delayTimer.Dispose();
            _delayTimer = null;

            CheckIfUsersTableIsEmpty();
        }

        private void CheckIfUsersTableIsEmpty()
        {
            try
            {
                using (var context = Program.context)
                {
                    int userCount = context.Users.Count();

                    if (userCount == 0)
                    {
                        DialogResult result = MessageBox.Show("В базе данных нет пользователей.\nНеобходимо создать хотя-бы менеджера.\n\nПерейти к созданию?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            fmUserControl formUserControl = new fmUserControl();
                            formUserControl.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подключении к базе данных или выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
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
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
