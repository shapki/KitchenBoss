using KitchenBoss.AppModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    internal static class Program
    {
        public static KitchenBossModel oldContext = new KitchenBossModel();
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
                MessageBox.Show("В базе данных нет пользователей. Необходимо создать хотя-бы первого пользователя (менеджера).", "Первоначальная настройка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fmUserControl userControlForm = new fmUserControl();
                userControlForm.ShowDialog();
            }

            Application.EnableVisualStyles();
            Application.Run(new fmLogin());
        }
    }
}
