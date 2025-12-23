using System;
using System.Windows.Forms;

namespace BOM_Builder
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmMenu"] != null)
            {
                Application.OpenForms["frmMenu"].Activate();
            }
            else
            {
                frmMenu form = new frmMenu();
                form.Show();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
