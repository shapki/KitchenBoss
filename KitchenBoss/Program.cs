using KitchenBoss.AppModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    internal static class Program
    {
        public static KitchenBossModel context { get { return new KitchenBossModel(); } }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.Assert(context.Database.Exists(), "Не удаётся установить соединение с базой данных");

            if (!context.Users.Any())
            {
                MessageBox.Show("В базе данных нет пользователей. Для менеджера \"ivan@gmail.com\" был создан пароль \"admin123\". Не забудьте его сменить!", "Первоначальная настройка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fmTableViewer tbl = new fmTableViewer();
                tbl.CreateUser("admin123", 1);
                context.SaveChanges();

                //MessageBox.Show("В базе данных нет пользователей. Необходимо создать менеджера!", "Первоначальная настройка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //fmTableViewer userControlForm = new fmTableViewer(false, false, false, null, null, false, true, true);
                //userControlForm.ShowDialog();
            }

            Application.EnableVisualStyles();
            Application.Run(new fmLogin());
        }
    }
}
