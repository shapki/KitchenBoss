using KitchenBoss.AppModels;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    internal static class Program
    {
        public static KitchenBossModel context = new KitchenBossModel();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.Assert(context.Database.Exists(), "Не удаётся установить соединение с базой данных");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fmLogin());
        }
    }
}
