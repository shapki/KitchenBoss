using System.Windows.Forms;

namespace KitchenBoss.AppForms
{
    public partial class fmMain : Form
    {
        public fmMain(string username)
        {
            InitializeComponent();
        }

        private void fmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            fmLogin loginForm = new fmLogin();
            loginForm.Show();
        }
    }
}
