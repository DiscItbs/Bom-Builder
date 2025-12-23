using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOM_Builder.Controllers;
using BOM_Builder.DL;
using BOM_Builder.Models;
using BOM_Builder.Views;

namespace BOM_Builder
{
    public partial class frmMenu : Form
    {
        Conexion con = new Conexion();
        SQLServer sql = new SQLServer();
        ConfiguracionDL dl = new ConfiguracionDL();
        public frmMenu()
        {
            InitializeComponent();
        }

        
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmConfigurationGlobal"] != null)
            {
                Application.OpenForms["frmConfigurationGlobal"].Activate();
            }
            else
            {
                frmConfigurationGlobal form = new frmConfigurationGlobal();
                form.Show();
            }
        }

        private void btnDifusoresPerimentrales_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmGeneratorBoms"] != null)
            {
                Application.OpenForms["frmGeneratorBoms"].Activate();
            }
            else
            {
                frmGeneratorBoms form = new frmGeneratorBoms();
                form.Show();
            }
        }

        private void btnLegacyForm_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frmLegacyNewBoms"] != null)
            {
                Application.OpenForms["frmLegacyNewBoms"].Activate();
            }
            else
            {
                frmLegacyNewBoms form = new frmLegacyNewBoms();
                form.Show();
            }
        }

        private void btnTestCon_Click(object sender, EventArgs e)
        {
            try
            {
                string error = string.Empty;
                //con.select("Select * from arinvt", "id");
                //sql.Select("select * from NM_Formulas", "id");
                dl.GetListComponents("AL", out error);
                MessageBox.Show("Success");
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
