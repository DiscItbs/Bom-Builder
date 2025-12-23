using BOM_Builder.BL;
using BOM_Builder.Controllers;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOM_Builder.Views
{
    public partial class frmGeneratorBoms : Form
    {
        GeneratorController generatorController = new GeneratorController();
        AssemblyBomController assemblyBomController = new AssemblyBomController();
        GeneratorBomsComponents generatorBomsComponents = new GeneratorBomsComponents();
        List<ComponenteModel> data_list_component = new List<ComponenteModel>();
        Regex regex = new Regex("^[0-9]*$");
        bool activeCreate = false;

        public frmGeneratorBoms()
        {
            InitializeComponent();
        }

        private void FrmGeneratorBoms_Load(object sender, EventArgs e)
        {
            string error = string.Empty;
            btnGenerateBom.Enabled = false;
            activeCreate = false;
            LoadModels(out error);
            LoadClasses(out error);
            btnGenerateBom.Enabled = true;
            if (error != "")
            {
                MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            string finishes = string.Empty;
            string model = string.Empty;
            string code = string.Empty;
            bool success = false;
            int id = 0;
            int idClass = 0;

            try
            {
                success = Int32.TryParse(cmbListadoModelos.SelectedValue.ToString(), out id);

                if (success && id > 0)
                {
                    success = Int32.TryParse(cmbClasses.SelectedValue.ToString(), out idClass);

                    if (success && id > 0)
                    {
                        finishes = cmbClasses.Text.ToString();

                        if (finishes != "AN")
                        {
                            finishes = "AL";
                        }
                    }

                    if (finishes == "")
                    {
                        MessageBox.Show("Debe eligir una clase para continuar con la busqueda de submodelos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    GetListModelAssembly(id, finishes, out error);
                }

                if (error != "")
                {
                    MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(error, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPreviewBom_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            string model = string.Empty;
            string finishes = string.Empty;
            string model_assembly = string.Empty;
            string sub_model_assembly = string.Empty;
            int totalCantidad = 0;
            double totalMedida = 0;
            double totalPerfil = 0;
            double totalTotal = 0;
            BomForm form = new BomForm();
            
            //double large = 0;
            //double width = 0;
            //int qty = 0;
            int cycle = 0;
            int idClass = 0;
            bool success = false;
            int id = 0;

            try
            {
                //if (ValidationFields())
                //{
                    success = Int32.TryParse(cmbClasses.SelectedValue.ToString(), out idClass);

                    if (success && idClass > 0)
                    {
                        finishes = cmbClasses.Text.ToString();

                        if (finishes != "AN")
                        {
                            finishes = "AL";
                        }
                    }


                //Largo
                if (string.IsNullOrEmpty(txtLarge.Text))
                {
                    form.Largo = 0;
                }
                else
                {
                    form.Largo = Convert.ToInt32(txtLarge.Text);
                }
                //Ancho
                if (string.IsNullOrEmpty(txtWidth.Text))
                {
                    form.Ancho = 0;
                }
                else
                {
                    form.Ancho = Convert.ToInt32(txtWidth.Text);
                }
                //Cantidad
                if (string.IsNullOrEmpty(txtQty.Text))
                {
                    form.Cantidad = 0;
                }
                else
                {
                    form.Cantidad = Convert.ToInt32(txtQty.Text);
                }
                //Horizontal
                if (string.IsNullOrEmpty(tb_Horizontal.Text))
                {
                    form.Horizontal = 0;
                }
                else
                {
                    form.Horizontal = Convert.ToInt32(tb_Horizontal.Text);
                }
                //Vertical
                if (string.IsNullOrEmpty(tb_Vertical.Text))
                {
                    form.Vertical = 0;
                }
                else
                {
                    form.Vertical = Convert.ToInt32(tb_Vertical.Text);
                }
                //Raniras
                if (string.IsNullOrEmpty(tb_Ranuras.Text))
                {
                    form.Ranuras = 0;
                }
                else
                {
                    form.Ranuras = Convert.ToInt32(tb_Ranuras.Text);
                }
                //Diametro
                if (string.IsNullOrEmpty(tb_Diametro.Text))
                {
                    form.Diametro = 0;
                }
                else
                {
                    form.Diametro = Convert.ToInt32(tb_Diametro.Text);
                }
                //Pies
                if (string.IsNullOrEmpty(tb_Pies.Text))
                {
                    form.Pies = 0;
                }
                else
                {
                    form.Pies = Convert.ToInt32(tb_Pies.Text);
                }

                cycle = Convert.ToInt32(txtCycle.Text);

                    model_assembly = cmbModelosEnsamblados.Text;
                    sub_model_assembly = ""; //cmbSubModelo.Text;

                    if (sub_model_assembly != "")
                    {
                        //data_list_component = generatorBomsComponents.GetComponents(sub_model_assembly, large, width, qty, finishes, out error);
                        data_list_component = generatorBomsComponents.GetComponents(sub_model_assembly, form, finishes, out error,
                                                                                    ref totalCantidad,ref totalMedida, ref totalPerfil);
                    }
                    else
                    {
                        //data_list_component = generatorBomsComponents.GetComponents(model_assembly, large, width, qty, finishes, out error);
                        data_list_component = generatorBomsComponents.GetComponents(model_assembly, form, finishes, out error,
                                                                                    ref totalCantidad, ref totalMedida, ref totalPerfil);
                    }

                    if (error == "")
                    {
                        if (data_list_component.Count != 0)
                        {
                            FillDgvPreviewComponents(ref data_list_component, out error);
                            totalTotal = totalCantidad + totalMedida + totalPerfil;
                            lblTotalCantidad.Text = totalCantidad.ToString();
                            lblTotalMedida.Text = totalMedida.ToString();
                            lblTotalPerfil.Text = totalPerfil.ToString();
                            lblTotal.Text = totalTotal.ToString();
                            btnGenerateBom.Enabled = true;
                            activeCreate = true;
                            
                        }
                    }
                //}

                if (error != "")
                {
                    MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(error, "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGenerateBom_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            string finishes = string.Empty;
            string model = string.Empty;
            string model_assembly = string.Empty;
            string sub_model_assembly = string.Empty;
            string mfg_cell = string.Empty;
            string base_name = string.Empty;
            string classes = string.Empty;
            BomForm form = new BomForm();
            int cycle = 0;
            int idClass = 0;
            bool success = false;
            int id = 0;

            try
            {
                if (!activeCreate)
                {
                    MessageBox.Show(
                    "Debes previsualizar el BOM antes de generarlo.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                    return;
                }
                if (ValidationFields())
                {
                    success = Int32.TryParse(cmbClasses.SelectedValue.ToString(), out idClass);

                    if (success && idClass > 0)
                    {
                        classes = cmbClasses.Text.ToString();

                        if (classes != "AN")
                        {
                            finishes = "AL";
                        }
                        else
                        {
                            finishes = "AN";
                        }
                    }

                    if (!string.IsNullOrEmpty(txtLarge.Text))
                        form.Largo = Convert.ToInt32(txtLarge.Text);
                    else
                        form.Largo = 0;
                    if (!string.IsNullOrEmpty(txtWidth.Text))
                        form.Ancho = Convert.ToInt32(txtWidth.Text);
                    else
                        form.Ancho = 0;
                    form.Cantidad = 1;
                    if (!string.IsNullOrEmpty(tb_Horizontal.Text))
                        form.Horizontal = Convert.ToInt32(tb_Horizontal.Text);
                    else
                        form.Horizontal = 0;
                    if (!string.IsNullOrEmpty(tb_Vertical.Text))
                        form.Vertical = Convert.ToInt32(tb_Vertical.Text);
                    else
                        form.Vertical = 0;
                    if (!string.IsNullOrEmpty(tb_Ranuras.Text))
                        form.Ranuras = Convert.ToInt32(tb_Ranuras.Text);
                    else
                        form.Ranuras = 0;
                    if (!string.IsNullOrEmpty(tb_Diametro.Text))
                        form.Diametro = Convert.ToInt32(tb_Diametro.Text);
                    else
                        form.Diametro = 0;
                    if (!string.IsNullOrEmpty(tb_Pies.Text))
                        form.Pies = Convert.ToInt32(tb_Pies.Text);
                    else
                        form.Pies = 0;

                    cycle = Convert.ToInt32(txtCycle.Text);

                    base_name = cmbListadoModelos.Text;
                    model_assembly = cmbModelosEnsamblados.Text;
                    sub_model_assembly = "";// cmbSubModelo.Text;
                    
                    if (error == "")
                    {
                        if (sub_model_assembly != "")
                        {
                            assemblyBomController.GetInformationBom(base_name.ToUpper(), ref data_list_component, sub_model_assembly, form, cycle, mfg_cell, finishes, classes, out error);
                        }
                        else
                        {
                            mfg_cell = GetMfgCell(cmbModelosEnsamblados.Text, out error);

                            if (mfg_cell != "")
                            {
                                assemblyBomController.GetInformationBom(base_name.ToUpper(), ref data_list_component, model_assembly, form, cycle, mfg_cell, finishes, classes, out error);
                            }
                            else
                            {
                                MessageBox.Show(string.Format("El modelo {0} no contiene mfgcell",model_assembly));
                            }
                        }
                    }
                }

                if (error != "")
                {
                    MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //else
                //{
                //    MessageBox.Show("Se genero, correctamente el BOM, con los parametros enviados correctamente.", "Proceso exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    ClearForm();
                //}
            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(error, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GetMfgCell(string model, out string errorMethod)
        {
            string error = string.Empty;
            bool success = false;
            int id = 0;
            string mfg_cell = string.Empty;

            try
            {
                //success = Int32.TryParse(text, out id);

                if (!string.IsNullOrEmpty(model))
                {
                    mfg_cell = generatorController.GetMfgCell(model, out error);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
            return mfg_cell;
        }

        private void LoadModels(out string errorMethod)
        {
            List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
            string error = string.Empty;
            data_list = generatorController.GetListModel(out error);

            if (data_list.Count != 0)
            {
                cmbListadoModelos.DataSource = data_list;
                cmbListadoModelos.DisplayMember = "Name_Model";
                cmbListadoModelos.ValueMember = "Id_L1";
                cmbListadoModelos.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                error = "No hay datos que mostrar, para el listado de modelos.";
            }

            errorMethod = error;
        }

        private void LoadClasses(out string errorMethod)
        {
            List<ArinvtModel> data_list = new List<ArinvtModel>();
            List<ArinvtModel> data_list_class = new List<ArinvtModel>();
            ArinvtModel data_model = new ArinvtModel();
            string error = string.Empty;
            data_list = generatorController.GetListClasses(out error);

            if (data_list.Count != 0)
            {
                for (int i = 0; i < data_list.Count; i++)
                {
                    if (data_list[i].Class == "AN" || data_list[i].Class == "BD" || data_list[i].Class == "BR" || data_list[i].Class == "PE" || data_list[i].Class == "NG" || data_list[i].Class == "SA")
                    {
                        data_model = new ArinvtModel();
                        data_model.Class = data_list[i].Class;
                        data_model.Id = data_list[i].Id;
                        data_list_class.Add(data_model);
                    }
                    else if (data_list[i].Id == 0)
                    {
                        data_model = new ArinvtModel();
                        data_model.Class = data_list[i].Class;
                        data_model.Id = data_list[i].Id;
                        data_list_class.Add(data_model);
                    }
                }

                cmbClasses.DataSource = data_list_class;
                cmbClasses.DisplayMember = "Class";
                cmbClasses.ValueMember = "Id";
                cmbClasses.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                error = "No hay datos que mostrar, para el listado de modelos.";
            }

            errorMethod = error;
        }

        private void GetListModelAssembly(int id, string finishes, out string errorMethod)
        {
            List<NM_CombinacionesModel> data_list = new List<NM_CombinacionesModel>();
            string error = string.Empty;
            string id_listado_bom = string.Empty;

            data_list = generatorController.GetListModelAssembly(id, finishes, out error);

            if (data_list.Count != 0)
            {
                cmbModelosEnsamblados.DataSource = data_list;
                cmbModelosEnsamblados.DisplayMember = "Combinacion";
                cmbModelosEnsamblados.ValueMember = "Id";
                cmbModelosEnsamblados.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                error = "No hay datos que mostrar, para el listado de modelos.";
            }

            errorMethod = error;
        }

        //!
        private void FillDgvPreviewComponents(ref List<ComponenteModel> dataListComponent, out string errorMetohd)
        {
            string error = string.Empty;

            try
            {
                ClearGrids();
                dataListComponent = dataListComponent.OrderBy(x => x.Linea).ToList();

                foreach (var item in dataListComponent)
                {
                    if (item != null)
                    {
                        dgvListComponents.Rows.Add(item.Numero_Parte, item.nombre, item.cantidad.ToString("N0"), item.medida.ToString("N7"), 
                                                   item.total_perfil.ToString("N7"), item.Peso_Kg.ToString("N7"),item.Seccion,item.Linea,item.Descripcion);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMetohd = error;
        }

        private void ClearForm()
        {
            string error = string.Empty;
            txtCycle.Text = "120";
            txtLarge.Text = "";
            txtQty.Text = "1";
            txtWidth.Text = "";
            tb_Horizontal.Text = "";
            tb_Vertical.Text = "";
            tb_Ranuras.Text = "";
            txtLarge.Focus();
            ClearGrids();
            LoadModels(out error);
            cmbModelosEnsamblados.DataSource = null;
            cmbModelosEnsamblados.Items.Clear();
        }

        private void ClearGrids()
        {
            dgvListComponents.Rows.Clear();
            dgvListComponents.Refresh();
            dgvListComponents.DataSource = null;
        }

        private void CmbListadoModelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string error = string.Empty;
            string code = string.Empty;
            bool success = false;
            int id = 0;

            try
            {
                success = Int32.TryParse(cmbListadoModelos.SelectedValue.ToString(), out id);

                if (success && id > 0)
                {
                    //FIllListModel(id);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidationFields()
        {
            string error = string.Empty;

            //if (!string.IsNullOrEmpty(txtLarge.Text))
            //{
            //    if (regex.IsMatch(txtLarge.Text))
            //    {
            //        if (Convert.ToDouble(txtLarge.Text) < 0)
            //        {
            //            error = "El valor de largo debe ser mayor a 0." + Environment.NewLine;
            //        }
            //        //else
            //        //{
            //        //    error = "";
            //        //}
            //    }
            //    else
            //    {
            //        error = "Verique que el campo de largo sea correcto." + Environment.NewLine;
            //    }
            //}
            //else
            //{
            //    error = "El campo largo no puede estar vacío." + Environment.NewLine;
            //}

            //if (!string.IsNullOrEmpty(txtWidth.Text))
            //{
            //    if (regex.IsMatch(txtWidth.Text))
            //    {
            //        if (Convert.ToDouble(txtWidth.Text) <= 0)
            //        {
            //            error = error + "El valor de ancho debe ser mayor a 0." + Environment.NewLine;
            //        }
            //        //else
            //        //{
            //        //    error = error + "";
            //        //}
            //    }
            //    else
            //    {
            //        error = error + "Verique que el campo de ancho sea correcto." + Environment.NewLine;
            //    }
            //}
            //else
            //{
            //    error = error + "El campo ancho no puede estar vacío." + Environment.NewLine;
            //}

            if (!string.IsNullOrEmpty(txtQty.Text))
            {
                if (regex.IsMatch(txtQty.Text))
                {
                    if (Convert.ToDouble(txtQty.Text) <= 0)
                    {
                        error = error + "El valor de cantidad de BOM´s debe ser mayor a 0." + Environment.NewLine;
                    }
                    //else
                    //{
                    //    error = error + "";
                    //}
                }
                else
                {
                    error = error + "Verique que el campo de cantidad de BOM´s sea correcto." + Environment.NewLine;
                }
            }
            else
            {
                error = error + "El campo cantidad de BOM´s no puede estar vacío." + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(txtCycle.Text))
            {
                if (regex.IsMatch(txtCycle.Text))
                {
                    if (Convert.ToDouble(txtCycle.Text) <= 0)
                    {
                        error = "El valor de cycle time debe ser mayor a 0." + Environment.NewLine;
                    }
                    //else
                    //{
                    //    error = "";
                    //}
                }
                else
                {
                    error = "Verique que el cycle time sea correcto." + Environment.NewLine;
                }
            }
            else
            {
                error = "El campo cycle time no puede estar vacío." + Environment.NewLine;
            }

            if (error != "")
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
