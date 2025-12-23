using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOM_Builder.Controllers;
using BOM_Builder.Models;

namespace BOM_Builder.Views
{
    public partial class frmEditComponentsBom : Form
    {
        ConfiguracionController configuracionController = new ConfiguracionController();

        public frmEditComponentsBom()
        {
            InitializeComponent();
        }

        private void FrmEditComponentsBom_Load(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string combination = string.Empty;
            string typeMaterial = string.Empty;
            string error = string.Empty;
            long idCombination = 0;

            try
            {
                if (ValidationFields(out error))
                {
                    combination = txtCombinacion.Text;

                    if (rbtnAL.Checked)
                    {
                        typeMaterial = "AL";
                    }
                    else
                    {
                        typeMaterial = "AN";
                    }

                    idCombination = configuracionController.GetIdCombinationBOM(combination.ToUpper(), typeMaterial, out error);

                    if (idCombination > 0 && error == "")
                    {
                        FillGridResult(idCombination, typeMaterial, out error);
                    }
                    else
                    {
                        MessageBox.Show("El modelo no ha sido encontrado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            if (error != "")
            {
                MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string combination = string.Empty;
            string typeMaterial = string.Empty;
            string error = string.Empty;
            long idCombination = 0;

            try
            {
                if (ValidationFields(out error))
                {
                    combination = txtCombinacion.Text;

                    if (rbtnAL.Checked)
                    {
                        typeMaterial = "AL";
                    }
                    else
                    {
                        typeMaterial = "AN";
                    }

                    idCombination = configuracionController.GetIdCombinationBOM(combination.ToUpper(), typeMaterial, out error);

                    if (idCombination > 0 && error == "")
                    {
                        UpdateComponents(idCombination, combination.ToUpper(), out error);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            if (error != "")
            {
                MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearInterface();
            }
            else
            {
                MessageBox.Show("Se actualizo de manera correcta el registro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInterface();
            }
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            string finish_material = string.Empty;
            string error = string.Empty;

            try
            {
                if (rbtnAL.Checked)
                {
                    finish_material = "AL";
                }

                if (rbtnAN.Checked)
                {
                    finish_material = "AN";
                }

                if (!string.IsNullOrEmpty(txtFilter.Text))
                {
                    dgvListComponentsNews.CurrentCell = null;

                    foreach (DataGridViewRow item in dgvListComponentsNews.Rows)
                    {
                        item.Visible = false;
                    }

                    foreach (DataGridViewRow itemRows in dgvListComponentsNews.Rows)
                    {
                        if ((itemRows.Cells["Itemno"].Value.ToString().ToUpper().IndexOf(txtFilter.Text.ToUpper())) == 0)
                        {
                            itemRows.Visible = true;
                        }
                    }
                }
                else
                {
                    dgvListComponentsNews.CurrentCell = null;

                    foreach (DataGridViewRow item in dgvListComponentsNews.Rows)
                    {
                        item.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        private bool ValidationFields(out string errorMethod)
        {
            string error = string.Empty;
            bool state = false;

            try
            {
                if (string.IsNullOrEmpty(txtCombinacion.Text))
                {
                    error = "Campo de combinación es obligatorio." + Environment.NewLine;
                }

                if (!rbtnAL.Checked)
                {
                    if (!rbtnAN.Checked)
                    {
                        error += "Debe al menos elegir un tipo de componente AL o AN." + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            if (error != "")
            {
                errorMethod = error;
                state = false;
            }
            else
            {
                errorMethod = "";
                state = true;
            }

            return state;
        }

        private void ClearInterface()
        {
            txtCombinacion.Text = "";
            txtCombinacion.Focus();
            rbtnAL.Checked = false;
            rbtnAN.Checked = false;
            txtFilter.Text = "";
            dgvListComponents.Rows.Clear();
            dgvListComponents.Refresh();
            dgvListComponents.DataSource = null;
            dgvListComponentsNews.Rows.Clear();
            dgvListComponentsNews.Refresh();
            dgvListComponentsNews.DataSource = null;
        }

        public void ClearDataGrid()
        {
            //MessageBox.Show("Entre al ClearDataGrid");
            dgvListComponents.Rows.Clear();
            dgvListComponents.Refresh();
            dgvListComponents.DataSource = null;

            dgvListComponentsNews.Rows.Clear();
            dgvListComponentsNews.Refresh();
            dgvListComponentsNews.DataSource = null;
            //MessageBox.Show("Pase clearDataGrid");
        }

        //!
        private void FillGridResult(long id, string typeMaterial, out string errorMethod)
        {
            List<NM_Detalle_Combinaciones_ComponentesModel> dataList = new List<NM_Detalle_Combinaciones_ComponentesModel>();
            List<ArinvtModel> data_list = new List<ArinvtModel>();
            string error = string.Empty;

            try
            {
                dataList = configuracionController.GetListComponents(id, out error);
                dataList = dataList.OrderBy(x => x.Linea).ToList();

                if (dataList != null)
                {
                    data_list = configuracionController.GetInfoComponents(typeMaterial, out error);

                    //MessageBox.Show("cantidad de data_list: " + dataList.Count);
                    if (dataList.Count > 0 && data_list.Count != 0)
                    {
                        //MessageBox.Show("Entre al if del datalis.count");
                        ClearDataGrid();

                        foreach (var item in dataList)
                        {
                            dgvListComponents.Rows.Add(item.Id, item.IdComponentes,item.Linea, item.Itemno, item.Class, item.Nombre_Componente, 1, true);
                        }

                        foreach (var item in data_list)
                        {
                            if (!item.Descrip1.Contains("TRAMO"))
                            {
                                dgvListComponentsNews.Rows.Add(0, item.Id, item.Itemno, item.Class, item.Descrip1, 1, false);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show($"Error: {error}");
            }

            errorMethod = error;
        }

        private void UpdateComponents(long idCombination, string combination, out string errorMethod)
        {
            List<NM_Detalle_Combinaciones_ComponentesModel> dataList = new List<NM_Detalle_Combinaciones_ComponentesModel>();
            NM_Detalle_Combinaciones_ComponentesModel dataModel = new NM_Detalle_Combinaciones_ComponentesModel();
            List<NM_Detalle_Combinaciones_ComponentesModel> dataListNews = new List<NM_Detalle_Combinaciones_ComponentesModel>();
            NM_Detalle_Combinaciones_ComponentesModel dataModelNews = new NM_Detalle_Combinaciones_ComponentesModel();
            DataGridViewRowCollection rowCollection = dgvListComponents.Rows;
            DataGridViewRowCollection rowCollections = dgvListComponentsNews.Rows;
            string error = string.Empty;
            int qty_material = 0;
            bool state = false;

            try
            {
                foreach (DataGridViewRow item in rowCollection)
                {
                    if (!Convert.ToBoolean(item.Cells["Apply"].Value))
                    {
                        dataModel = new NM_Detalle_Combinaciones_ComponentesModel
                        {
                            Id = Convert.ToInt32(item.Cells["Id"].Value),
                            IdComponentes = Convert.ToInt32(item.Cells["IdComponent"].Value),
                            Itemno = Convert.ToString(item.Cells["Itemo"].Value),
                            Nombre_Componente = Convert.ToString(item.Cells["Description"].Value),
                            Class = Convert.ToString(item.Cells["Class"].Value)
                        };

                        dataList.Add(dataModel);
                    }
                }

                foreach (DataGridViewRow item in rowCollections)
                {
                    if (Convert.ToBoolean(item.Cells["Applys"].Value))
                    {
                        qty_material = Convert.ToInt32(item.Cells["Qtys"].Value);

                        if (qty_material > 1)
                        {
                            for (int i = 0; i < qty_material; i++)
                            {
                                dataModelNews = new NM_Detalle_Combinaciones_ComponentesModel
                                {
                                    Id = Convert.ToInt32(item.Cells["IdC"].Value),
                                    IdComponentes = Convert.ToInt32(item.Cells["IdComponents"].Value),
                                    Itemno = Convert.ToString(item.Cells["Itemno"].Value),
                                    Nombre_Componente = Convert.ToString(item.Cells["Descriptions"].Value),
                                    Class = Convert.ToString(item.Cells["Classes"].Value)
                                };

                                dataListNews.Add(dataModelNews);
                            }
                        }
                        else
                        {
                            dataModelNews = new NM_Detalle_Combinaciones_ComponentesModel
                            {
                                Id = Convert.ToInt32(item.Cells["IdC"].Value),
                                IdComponentes = Convert.ToInt32(item.Cells["IdComponents"].Value),
                                Itemno = Convert.ToString(item.Cells["Itemno"].Value),
                                Nombre_Componente = Convert.ToString(item.Cells["Descriptions"].Value),
                                Class = Convert.ToString(item.Cells["Classes"].Value)
                            };

                            dataListNews.Add(dataModelNews);
                        }
                    }
                }

                if (dataList.Count != 0 || dataListNews.Count != 0)
                {
                    // Update de componentes
                    if (dataList.Count == dataListNews.Count)
                    {
                        DialogResult result = MessageBox.Show("¿Esta seguro de realizar la actualización?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (result == DialogResult.Yes)
                        {
                            state = configuracionController.UpdateComponentsBOM(idCombination, combination, dataList.OrderBy(x => x.Itemno).ToList(), dataListNews.OrderBy(x => x.Itemno).ToList(), out error);
                        }
                    }
                    // Delete de componentes
                    else if (dataList.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("¿Esta seguro de realizar la eliminación del componente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (result == DialogResult.Yes)
                        {
                            state = configuracionController.DeleteComponentsBOM( dataList.OrderBy(x => x.Itemno).ToList(),  out error);
                        }
                    }
                    // Agregar de componentes
                    else if (dataListNews.Count > 0)
                    {
                        DialogResult result = MessageBox.Show("¿Esta seguro de agregar el componente?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (result == DialogResult.Yes)
                        {
                            state = configuracionController.AddComponentsBOM(dataListNews.OrderBy(x => x.Itemno).ToList(), idCombination, out error);

                            if (error == "")
                            {
                                error += "Añadiste un nuevo componente, necesitas añadir sus formulas ahora.";
                            }
                        }
                    }
                    else
                    {
                        error += ". Debe tener la misma cantidad de elementos a actualizar en ambas tablas";
                    }
                }
                else
                {
                    error += ". Debe elegir al menos un componente para actualizar el modelo pre-ensamblado";
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
        }
    }
}
