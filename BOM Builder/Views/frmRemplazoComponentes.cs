using BOM_Builder.Controllers;
using BOM_Builder.DL;
using BOM_Builder.Models;
using IQMS.Entities.Lib.Labels;
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
    public partial class frmRemplazoComponentes : Form
    {
        SQLServer sql = new SQLServer();
        Conexion oracle = new Conexion();
        ConfiguracionDL conf = new ConfiguracionDL();
        public frmRemplazoComponentes()
        {
            InitializeComponent();
            _Init_();
        }

        public void _Init_()
        {
            string error = string.Empty;
            List<ArinvtModel> arinvts = conf.GetListComponents(out error);
            cbComponenteOrig.DataSource = arinvts.Select(x => x.Itemno).ToList();
        }

        private void btn_Buscar_Componente_Click(object sender, EventArgs e)
        {
            string componente = cbComponenteOrig.Text;//txt_Componente.Text;
            List<string> boms = new List<string>();
            bool chAl = chbAN.Checked;
            bool chAN = chbAL.Checked;
            dgvBoms.Rows.Clear();

            boms = sql.GetBomsFromComponents(componente);

            if(boms.Count>0)
            {
                foreach(var bom in boms)
                {
                    dgvBoms.Rows.Add(bom, "False");
                }
            }
            else
            {
                MessageBox.Show("No se han encontrado coincidencias con ese componente.\nVerifica el nombre del componente",
                    "AVISO!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void btnQuitarSeleccion_Click(object sender, EventArgs e)
        {
            if (dgvBoms.Rows.Count > 0)
            {
                for (int i = 0; i < dgvBoms.Rows.Count; i++)
                {
                    dgvBoms.Rows[i].Cells["SeleccionarBom"].Value = true;
                }
            }
        }

        private void btn_RemplazarComponente_Click(object sender, EventArgs e)
        {
            List<string> bomsSelected = CountBom();
            string message = string.Format("Se han seleccionado: {0} BOMs para ser modificado su componente,\n" +
                                           " ¿esta seguro que desea actualizarlos?", bomsSelected.Count.ToString());
            string componenteOrigen = string.Empty;
            string componenteDestino = string.Empty;
            bool chAl = chbAN.Checked;
            bool chAN = chbAL.Checked;
            string idAL = string.Empty;
            string idAN = string.Empty;
            List<string> idsBom = new List<string>();
            NM_ComponentesModel componente = new NM_ComponentesModel();
            

            if(!string.IsNullOrEmpty(txtDestino.Text))
            {
                if (bomsSelected.Count > 0 && !string.IsNullOrEmpty(cbComponenteOrig.Text))
                {
                    componenteOrigen = cbComponenteOrig.Text.ToUpper();
                    componenteDestino = txtDestino.Text.ToUpper();

                    componente = oracle.GetComponente(componenteDestino);//sql.GetComponente(componenteDestino);

                    if(componente.Codigo!=null && componente.Id_Arinvt!=null)
                    {
                        var result = MessageBox.Show(message, "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            if(chAl || chAN)
                            {
                                foreach (var bom in bomsSelected)
                                {
                                    idAL = sql.GetIdCombinacionByName(bom, "AL");
                                    idAN = sql.GetIdCombinacionByName(bom, "AN");

                                    if (chbAL.Checked)
                                    {
                                        sql.UpdateComponentes(componenteDestino, idAL, componenteOrigen);
                                    }
                                    if (chbAN.Checked)
                                    {
                                        sql.UpdateComponentes(componenteDestino, idAN, componenteOrigen);
                                    }
                                }
                                MessageBox.Show("Actualizado con exito!");
                                LlenarDGV();
                            }
                            else
                            {
                                MessageBox.Show("No se ha seleccionado ningun tipo de componente (AL o AN)");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Compruebe el componente destino");
                    }
                }
                else
                {
                    MessageBox.Show("No hay BOMs seleccionados o el campo del componente esta vacio");
                }
            }
            else
            {
                MessageBox.Show("El Componente destino no ha puede estar vacio");
            }
            
        }

        public List<string> CountBom()
        {
            List<string> bomsSelected = new List<string>();

            if (dgvBoms.Rows.Count > 0)
            {
                for (int i = 0; i < dgvBoms.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvBoms.Rows[i].Cells["SeleccionarBom"].Value) == true)
                    {
                        bomsSelected.Add(dgvBoms.Rows[i].Cells["NombreBom"].Value.ToString());
                    }
                }
            }

            return bomsSelected;
        }

        public void LlenarDGV()
        {
            string componente = cbComponenteOrig.Text;
            List<string> boms = new List<string>();
            boms = sql.GetBomsFromComponents(componente);

            if (boms.Count > 0)
            {
                foreach (var bom in boms)
                {
                    dgvBoms.Rows.Add(bom, "False");
                }
            }
        }

    }
}
