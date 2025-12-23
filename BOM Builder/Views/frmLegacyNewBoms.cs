using BOM_Builder.Controllers;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOM_Builder.Views
{
    public partial class frmLegacyNewBoms : Form
    {
        Conexion oracle = new Conexion();
        SQLServer sql = new SQLServer();
        DataTable legacyTable = new DataTable();
        List<NM_CombinacionesModel> boms;

        public frmLegacyNewBoms()
        {
            InitializeComponent();
            FillDgvLegacy();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dgvLegacy.Rows.Count > 0)
            {
                for (int i = 0; i < dgvLegacy.Rows.Count; i++)
                {
                    dgvLegacy.Rows[i].Cells["Approved"].Value = true;
                }
            }
        }

        private void btnUnselectLegacy_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas seguro de deseleccionar todos las casillas?", "Aviso", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if(dialog == DialogResult.Yes)
            {
                if (dgvLegacy.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvLegacy.Rows.Count; i++)
                    {
                        dgvLegacy.Rows[i].Cells["Approved"].Value = false;
                    }
                }
            }
        }
        //!
        public void FillDgvLegacy()
        {
            boms = sql.GetBoms();
            
            if(boms.Count>0)
            {
                dgvLegacy.DataSource = boms;
                dgvLegacy.Columns["Id"].Visible = false;
                dgvLegacy.Columns["Combinacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvLegacy.Columns["Approved"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dgvLegacy.Columns["Phantom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
        }

        private void btnUpdateLegacy_Click(object sender, EventArgs e)
        {
            UpdateApproved();
        }

        public void UpdateApproved()
        {
            List<NM_CombinacionesModel> legacyListOld = sql.GetBoms();
            List<NM_CombinacionesModel> legacyListDgv = GetDgvLegacy();
            List<NM_CombinacionesModel> legacyListUpdate = new List<NM_CombinacionesModel>();
            List<NM_CombinacionesModel> PhantomListUpdate = new List<NM_CombinacionesModel>();

            for (int i = 0; i < legacyListDgv.Count; i++)
            {
                for (int j = 0; j < legacyListOld.Count; j++)
                {
                    if (legacyListDgv[i].Id == legacyListOld[j].Id)
                    {
                        if (legacyListDgv[i].Approved != legacyListOld[j].Approved)
                        {
                            legacyListUpdate.Add(legacyListDgv[i]);
                        }
                        if (legacyListDgv[i].Phantom != legacyListOld[j].Phantom)
                        {
                            PhantomListUpdate.Add(legacyListDgv[i]);
                        }
                    }
                }
            }
            if (legacyListUpdate.Count > 0)
            {
                sql.UpdateCombinacionesApproved(legacyListUpdate);
                oracle.UpdateLegacy(legacyListUpdate);
                
            }
            if(PhantomListUpdate.Count>0)
            {
                sql.UpdateCombinacionesPhantom(PhantomListUpdate);
                oracle.UpdatePhantom(PhantomListUpdate);
            }
            FillDgvLegacy();
        }


        public List<NM_CombinacionesModel> GetDgvLegacy()
        {
            List<NM_CombinacionesModel> boms = new List<NM_CombinacionesModel>();
            NM_CombinacionesModel bom;
            txtFilterLegacy.Text = string.Empty;

            if (dgvLegacy.Rows.Count>0)
            {
                for (int i = 0; i < dgvLegacy.Rows.Count; i++)
                {
                    bom = new NM_CombinacionesModel();
                    bom.Id = Convert.ToInt32(dgvLegacy.Rows[i].Cells["Id"].Value);
                    bom.Combinacion = dgvLegacy.Rows[i].Cells["Combinacion"].Value.ToString();
                    bom.Approved = Convert.ToBoolean(dgvLegacy.Rows[i].Cells["Approved"].Value);
                    bom.Phantom = Convert.ToBoolean(dgvLegacy.Rows[i].Cells["Phantom"].Value);
                    boms.Add(bom);
                }
            }
            return boms;
        }

        private void txtFilterLegacy_TextChanged(object sender, EventArgs e)
        {
            FillDgvWithFilter(txtFilterLegacy.Text.ToUpper());
        }

        public void FillDgvWithFilter(string textContain)
        {
            List<NM_CombinacionesModel> filterBoms = new List<NM_CombinacionesModel>();

            foreach (var bom in boms)
            {
                if(bom.Combinacion.Contains(textContain))
                {
                    filterBoms.Add(bom);
                }
            }
            dgvLegacy.DataSource = filterBoms;
        }

        private void btnSelectAllPhantom_Click(object sender, EventArgs e)
        {
            if (dgvLegacy.Rows.Count > 0)
            {
                for (int i = 0; i < dgvLegacy.Rows.Count; i++)
                {
                    dgvLegacy.Rows[i].Cells["Phantom"].Value = true;
                }
            }
        }

        private void btnUnselectPhantom_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Estas seguro de deseleccionar todos las casillas?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                if (dgvLegacy.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvLegacy.Rows.Count; i++)
                    {
                        dgvLegacy.Rows[i].Cells["Phantom"].Value = false;
                    }
                }
            }
        }
    }
}
