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
    public partial class frmEditFormulaBom : Form
    {
        ConfiguracionController ConfiguracionController = new ConfiguracionController();
        FormuladorController FormuladorController = new FormuladorController();
        List<NM_Detalle_Combinacion_Componentes_FormulasModel> DataListCompFor = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
        SQLServer sql = new SQLServer();
        private string idCombinacion = string.Empty;
        private string idDetalleComp = string.Empty;
        NM_Detalle_Combinacion_Componentes_FormulasModel currentEdit = new NM_Detalle_Combinacion_Componentes_FormulasModel();

        public frmEditFormulaBom()
        {
            InitializeComponent();
        }

        private void FrmEditFormulaBom_Load(object sender, EventArgs e)
        {
            btnAsocias.Enabled = true;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BuscarFormulasModelo();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            bool state = false;

            try
            {
                if (DataListCompFor.Count > 0)
                {
                    state = ConfiguracionController.UpdateFormulasComponent(DataListCompFor, out error);

                    if (error == "")
                    {
                        MessageBox.Show("Se realizo la actualización de manera correcta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Falta asociar las formulas a los componentes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        private void DgvCombinacionesFormulas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string error = string.Empty;
            DataGridViewRow currentRow = new DataGridViewRow();


            int index = 0;

            try
            {
                if (dgvCombinacionesFormulas.Columns[e.ColumnIndex].Name == "SelectEdit")
                {
                    bool check = Convert.ToBoolean(dgvCombinacionesFormulas.Rows[e.RowIndex].Cells[4].Value);

                    if (!check)
                    {
                        btnAsocias.Visible = true;
                        dgvCombinacionesFormulas.Rows[e.RowIndex].Cells[4].Value = true;
                        FillFormulasComboboxByIndex(currentRow);
                    }
                    else
                    {
                        dgvCombinacionesFormulas.Rows[e.RowIndex].Cells[4].Value = false;

                        if (!CheckEnables())
                        {
                            btnAsocias.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        private void BtnAsocias_Click(object sender, EventArgs e)
        {
            UpdateFormulasFromCombo();
        }

        //private void DgvFormulasToAssociate_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    int id = 0;
        //    string formula = string.Empty;
        //    string error = string.Empty;
        //    string name = string.Empty;

        //    try
        //    {
        //        if (dgvFormulasToAssociate.Columns[e.ColumnIndex].Name == "ConditionalQty1")
        //        {
        //            id = Convert.ToInt32(this.dgvFormulasToAssociate[e.ColumnIndex, e.RowIndex].Value.ToString());

        //            if (id > 0)
        //            {
        //                if (trvShowConditional.Nodes.Count > 0)
        //                {
        //                    trvShowConditional.Nodes[0].Remove();
        //                    trvShowConditional.ResetText();
        //                    trvShowConditional.Nodes.Clear();
        //                }

        //                CreateTreeConditionals(id);
        //            }
        //            else
        //            {
        //                trvShowConditional.ResetText();
        //            }
        //        }

        //        if (dgvFormulasToAssociate.Columns[e.ColumnIndex].Name == "ConditionalMd1")
        //        {
        //            id = Convert.ToInt32(this.dgvFormulasToAssociate[e.ColumnIndex, e.RowIndex].Value.ToString());

        //            if (id > 0)
        //            {
        //                if (trvShowConditional.Nodes.Count > 0)
        //                {
        //                    trvShowConditional.Nodes[0].Remove();
        //                    trvShowConditional.ResetText();
        //                }

        //                CreateTreeConditionals(id);
        //            }
        //            else
        //            {
        //                trvShowConditional.Nodes[0].Remove();
        //                trvShowConditional.ResetText();
        //                trvShowConditional.Nodes.Clear();
        //            }
        //        }

        //        if (dgvFormulasToAssociate.Columns[e.ColumnIndex].Name == "ConditionalTotal1")
        //        {
        //            id = Convert.ToInt32(this.dgvFormulasToAssociate[e.ColumnIndex, e.RowIndex].Value.ToString());

        //            if (id > 0)
        //            {
        //                if (trvShowConditional.Nodes.Count > 0)
        //                {
        //                    trvShowConditional.Nodes[0].Remove();
        //                    trvShowConditional.ResetText();
        //                }

        //                CreateTreeConditionals(id);
        //            }
        //            else
        //            {
        //                trvShowConditional.Nodes[0].Remove();
        //                trvShowConditional.ResetText();
        //                trvShowConditional.Nodes.Clear();
        //            }
        //        }

        //        if (dgvFormulasToAssociate.Columns[e.ColumnIndex].Name == "FormulaQty1")
        //        {
        //            id = Convert.ToInt32(this.dgvFormulasToAssociate[e.ColumnIndex, e.RowIndex].Value.ToString());

        //            if (id > 0)
        //            {
        //                formula = ConfiguracionController.GetFormula(id, out error);

        //                if (error == "")
        //                {
        //                    txtShowFormulas.Text = formula;
        //                }
        //            }
        //            else
        //            {
        //                txtShowFormulas.Text = "";
        //            }
        //        }

        //        if (dgvFormulasToAssociate.Columns[e.ColumnIndex].Name == "FormulaMd1")
        //        {
        //            id = Convert.ToInt32(this.dgvFormulasToAssociate[e.ColumnIndex, e.RowIndex].Value.ToString());

        //            if (id > 0)
        //            {
        //                formula = ConfiguracionController.GetFormula(id, out error);

        //                if (error == "")
        //                {
        //                    txtShowFormulas.Text = formula;
        //                }
        //            }
        //            else
        //            {
        //                txtShowFormulas.Text = formula;
        //            }
        //        }

        //        if (dgvFormulasToAssociate.Columns[e.ColumnIndex].Name == "FormulaTotal1")
        //        {
        //            id = Convert.ToInt32(this.dgvFormulasToAssociate[e.ColumnIndex, e.RowIndex].Value.ToString());

        //            if (id > 0)
        //            {
        //                formula = ConfiguracionController.GetFormula(id, out error);

        //                if (error == "")
        //                {
        //                    txtShowFormulas.Text = formula;
        //                }
        //            }
        //            else
        //            {
        //                txtShowFormulas.Text = formula;
        //            }
        //        }

        //        if (dgvFormulasToAssociate.Columns[e.ColumnIndex].Name == "FormulaPeso1")
        //        {
        //            id = Convert.ToInt32(this.dgvFormulasToAssociate[e.ColumnIndex, e.RowIndex].Value.ToString());

        //            if (id > 0)
        //            {
        //                formula = ConfiguracionController.GetFormula(id, out error);

        //                if (error == "")
        //                {
        //                    txtShowFormulas.Text = formula;
        //                }
        //            }
        //            else
        //            {
        //                txtShowFormulas.Text = formula;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex.Message;
        //    }
        //}

        public void BuscarFormulasModelo()
        {
            string combination = string.Empty;
            string typeMaterial = string.Empty;
            string error = string.Empty;

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

                    FillGridResult(combination.ToUpper(), typeMaterial, out error);
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
        //!
        public void FillFormulasComboboxByIndex(DataGridViewRow row)
        {
            List<NM_CondicionalMaster> master = sql.GetMasterCondicional();
            List<NM_Condicional> condicionales = sql.GetCondicionales();
            List<NM_Formula> formulas = sql.GetGeneralFormulas("SELECT * from NM_Formulas");
            List<string> duo = JoinListConditional(master, condicionales);
            formulas.Insert(0, new NM_Formula { Id=0,NombreFormula="",Tipo="",Formula="",FechaCreacion=""});

            DataGridViewComboBoxCell condicionalQty = row.Cells["ConditionalQty1"] as DataGridViewComboBoxCell;
            condicionalQty.DataSource = duo;
            DataGridViewComboBoxCell condicionalMd = row.Cells["ConditionalMd1"] as DataGridViewComboBoxCell;
            condicionalMd.DataSource = duo;
            DataGridViewComboBoxCell formulaQty = row.Cells["FormulaQty1"] as DataGridViewComboBoxCell;
            formulaQty.DataSource = (from formula in formulas where formula.Tipo != "total" select formula.NombreFormula).ToList();
            DataGridViewComboBoxCell formulaMd = row.Cells["FormulaMd1"] as DataGridViewComboBoxCell;
            formulaMd.DataSource = (from formula in formulas where formula.Tipo != "total" select formula.NombreFormula).ToList();
            DataGridViewComboBoxCell formulaTotal = row.Cells["FormulaTotal1"] as DataGridViewComboBoxCell;
            duo = (from formula in formulas where formula.Tipo == "total" select formula.NombreFormula).ToList();
            duo.Insert(0, "");
            formulaTotal.DataSource = duo;
        }

        public List<string> JoinListConditional(List<NM_CondicionalMaster> masters, List<NM_Condicional> condicionales)
        {
            List<string> duo = new List<string>();

            duo.Add("** CONDICIONALES SIMPLES **");
            duo.Add("");

            foreach (var condicional in condicionales)
            {
                duo.Add(condicional.NombreCondicional);
            }

            duo.Add("");
            duo.Add("** CONDICIONALES MASTER **");
            duo.Add("");

            foreach (var master in masters)
            {
                duo.Add(master.Nombre);
            }

            return duo;
        }

        //!
        private void FillGridResult(string combination, string typeMaterial, out string errorMethod)
        {
            List<NM_Detalle_Combinacion_Componentes_FormulasModel> dataList = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
            string error = string.Empty;

            try
            {
                dataList = ConfiguracionController.GetListComponentsFormulas(combination, typeMaterial, out error);
                dataList = dataList.OrderBy(x => x.Linea).ToList();

                if (dataList != null)
                {

                    if (dataList.Count > 0)
                    {
                        ClearDataGrid();

                        foreach (var item in dataList)
                        {
                            dgvCombinacionesFormulas.Rows.Add(item.Linea,item.Id, item.IdDetalleForComp, item.IdCombinacion, item.IdComponente,"Editar", 
                                                              item.Itemno, item.Descripcion, item.NombreCondicionalQty, item.NombreCondicionalMd,
                                                              item.NombreFormulaQty, item.NombreFormulaMd, item.NombreFormulaTotal,
                                                              item.NombreFormulaPeso, item.Seccion,item.Descripcion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            errorMethod = error;
        }


        public void ClearDataGrid()
        {
            dgvCombinacionesFormulas.Rows.Clear();
            dgvCombinacionesFormulas.Refresh();
            dgvCombinacionesFormulas.DataSource = null;

            //dgvFormulasToAssociate.Rows.Clear();
            //dgvFormulasToAssociate.Refresh();
            //dgvFormulasToAssociate.DataSource = null;
        }

        public void ClearCombo()
        {
            cb_CondicionalesCantidad.DataSource = null;
            cb_CondicionalesMedida.DataSource = null;
            cb_FormulaCantidad.DataSource = null;
            cb_FormulaMedida.DataSource = null;
            cb_FormulaTotal.DataSource = null;
            cb_FormulaPeso.DataSource = null;
            tb_NumeroParte.Text = string.Empty;
            txt_Seccion.Text = string.Empty;
            txt_Linea.Text = string.Empty;
            txt_Descripcion.Text = string.Empty;
            txtShowFormulas.Text = string.Empty;
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

        //public void FillFormulasGrid(out string errorMethod)
        //{
        //    List<NM_Formula> data_list = new List<NM_Formula>();
        //    List<NM_Formula> data_list_qty = new List<NM_Formula>();
        //    NM_Formula data_model_qty = new NM_Formula();
        //    List<NM_Formula> data_list_md = new List<NM_Formula>();
        //    NM_Formula data_model_md = new NM_Formula();
        //    List<NM_Formula> data_list_total = new List<NM_Formula>();
        //    NM_Formula data_model_total = new NM_Formula();
        //    List<NM_Formula> data_list_total_peso = new List<NM_Formula>();
        //    NM_Formula data_model_total_peso = new NM_Formula();
        //    List<NM_CondicionalMaster> data_list_conditionals = new List<NM_CondicionalMaster>();
        //    List<NM_CondicionalMaster> data_list_conditionals_temps = new List<NM_CondicionalMaster>();
        //    NM_CondicionalMaster data_model_conditionals_temps = new NM_CondicionalMaster();
        //    List<NM_CondicionalMaster> data_list_conditionals_temps_qty = new List<NM_CondicionalMaster>();
        //    NM_CondicionalMaster data_model_conditionals_temps_qty = new NM_CondicionalMaster();
        //    List<NM_CondicionalMaster> data_list_conditionals_temps_md = new List<NM_CondicionalMaster>();
        //    NM_CondicionalMaster data_model_conditionals_temps_md = new NM_CondicionalMaster();
        //    List<NM_CondicionalMaster> data_list_conditionals_temps_total = new List<NM_CondicionalMaster>();
        //    NM_CondicionalMaster data_model_conditionals_temps_total = new NM_CondicionalMaster();
        //    string error = string.Empty;

        //    try
        //    {
        //        data_list = FormuladorController.GetListFormulas(out error);
        //        data_list_conditionals = ConfiguracionController.GetListConditionals(out error);

        //        if (data_list.Count != 0)
        //        {
        //            for (int i = 0; i < data_list.Count; i++)
        //            {
        //                if (data_list[i].Tipo == "qty")
        //                {
        //                    data_model_qty = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
        //                    data_list_qty.Add(data_model_qty);
        //                }
        //                else if (data_list[i].Tipo == "md")
        //                {
        //                    data_model_md = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
        //                    data_list_md.Add(data_model_md);
        //                }
        //                else if (data_list[i].Tipo == "total")
        //                {
        //                    data_model_total = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
        //                    data_list_total.Add(data_model_total);
        //                }
        //                else if (data_list[i].Tipo == "peso")
        //                {
        //                    data_model_total_peso = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
        //                    data_list_total_peso.Add(data_model_total_peso);
        //                }
        //                else
        //                {
        //                    data_model_qty = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
        //                    data_list_qty.Add(data_model_qty);

        //                    data_model_md = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
        //                    data_list_md.Add(data_model_md);

        //                    data_model_total = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
        //                    data_list_total.Add(data_model_total);

        //                    data_model_total_peso = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
        //                    data_list_total_peso.Add(data_model_total_peso);
        //                }
        //            }

        //            if (data_list_qty.Count != 0)
        //            {
        //                foreach (DataGridViewRow row in dgvFormulasToAssociate.Rows)
        //                {
        //                    DataGridViewComboBoxCell viewRowQty = row.Cells["FormulaQty1"] as DataGridViewComboBoxCell;
        //                    viewRowQty.DataSource = data_list_qty;
        //                    viewRowQty.ValueMember = "Id";
        //                    viewRowQty.DisplayMember = "NombreFormula";
        //                }
        //            }

        //            if (data_list_md.Count != 0)
        //            {
        //                foreach (DataGridViewRow row in dgvFormulasToAssociate.Rows)
        //                {
        //                    DataGridViewComboBoxCell viewRowMd = row.Cells["FormulaMd1"] as DataGridViewComboBoxCell;
        //                    viewRowMd.DataSource = data_list_md;
        //                    viewRowMd.ValueMember = "Id";
        //                    viewRowMd.DisplayMember = "NombreFormula";
        //                }
        //            }

        //            if (data_list_total.Count != 0)
        //            {
        //                foreach (DataGridViewRow row in dgvFormulasToAssociate.Rows)
        //                {
        //                    DataGridViewComboBoxCell viewRowTotal = row.Cells["FormulaTotal1"] as DataGridViewComboBoxCell;
        //                    viewRowTotal.DataSource = data_list_total;
        //                    viewRowTotal.ValueMember = "Id";
        //                    viewRowTotal.DisplayMember = "NombreFormula";
        //                }
        //            }

        //            if (data_list_total_peso.Count != 0)
        //            {
        //                foreach (DataGridViewRow row in dgvFormulasToAssociate.Rows)
        //                {
        //                    DataGridViewComboBoxCell viewRowTotalPeso = row.Cells["FormulaPeso1"] as DataGridViewComboBoxCell;
        //                    viewRowTotalPeso.DataSource = data_list_total_peso;
        //                    viewRowTotalPeso.ValueMember = "Id";
        //                    viewRowTotalPeso.DisplayMember = "NombreFormula";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            error += "No se han capturado formulas de ningun tipo.";
        //        }

        //        if (data_list_conditionals.Count > 0)
        //        {
        //            for (int i = 0; i < data_list_conditionals.Count; i++)
        //            {
        //                if (!data_list_conditionals[i].Nombre.Contains("condicional hijo"))
        //                {
        //                    data_model_conditionals_temps_qty = new NM_CondicionalMaster();
        //                    data_model_conditionals_temps_md = new NM_CondicionalMaster();

        //                    if (data_list_conditionals[i].Tipo != null)
        //                    {
        //                        if (data_list_conditionals[i].Tipo.Contains("Cantidad"))
        //                        {
        //                            data_model_conditionals_temps_qty.IdCondicionalMaster = data_list_conditionals[i].Id;
        //                            data_model_conditionals_temps_qty.Nombre = data_list_conditionals[i].Nombre.ToUpper();
        //                            data_list_conditionals_temps_qty.Add(data_model_conditionals_temps_qty);
        //                        }
        //                        else if (data_list_conditionals[i].Tipo.Contains("Medida"))
        //                        {
        //                            data_model_conditionals_temps_md.IdCondicionalMaster = data_list_conditionals[i].Id;
        //                            data_model_conditionals_temps_md.Nombre = data_list_conditionals[i].Nombre.ToUpper();
        //                            data_list_conditionals_temps_md.Add(data_model_conditionals_temps_md);
        //                        }
        //                        else if (data_list_conditionals[i].Tipo.Contains("Total"))
        //                        {
        //                            data_model_conditionals_temps_total.IdCondicionalMaster = data_list_conditionals[i].Id;
        //                            data_model_conditionals_temps_total.Nombre = data_list_conditionals[i].Nombre.ToUpper();
        //                            data_list_conditionals_temps_total.Add(data_model_conditionals_temps_md);
        //                        }
        //                        else if (data_list_conditionals[i].Tipo.Contains("Base"))
        //                        {
        //                            data_model_conditionals_temps_qty.IdCondicionalMaster = data_list_conditionals[i].Id;
        //                            data_model_conditionals_temps_qty.Nombre = data_list_conditionals[i].Nombre.ToUpper();
        //                            data_list_conditionals_temps_qty.Add(data_model_conditionals_temps_qty);

        //                            data_model_conditionals_temps_md.IdCondicionalMaster = data_list_conditionals[i].Id;
        //                            data_model_conditionals_temps_md.Nombre = data_list_conditionals[i].Nombre.ToUpper();
        //                            data_list_conditionals_temps_md.Add(data_model_conditionals_temps_md);
        //                        }
        //                    }
        //                }
        //            }

        //            foreach (DataGridViewRow row in dgvFormulasToAssociate.Rows)
        //            {
        //                DataGridViewComboBoxCell viewRowConditionalQty = row.Cells["ConditionalQty1"] as DataGridViewComboBoxCell;
        //                viewRowConditionalQty.DataSource = data_list_conditionals_temps_qty;
        //                viewRowConditionalQty.ValueMember = "IdCondicionalMaster";
        //                viewRowConditionalQty.DisplayMember = "Nombre";
        //            }

        //            foreach (DataGridViewRow row in dgvFormulasToAssociate.Rows)
        //            {
        //                DataGridViewComboBoxCell viewRowConditionalMd = row.Cells["ConditionalMd1"] as DataGridViewComboBoxCell;
        //                viewRowConditionalMd.DataSource = data_list_conditionals_temps_md;
        //                viewRowConditionalMd.ValueMember = "IdCondicionalMaster";
        //                viewRowConditionalMd.DisplayMember = "Nombre";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex.Message;
        //    }

        //    errorMethod = error;
        //}

        public void GetListFormulas()
        {
            List<NM_Formula> data_list = new List<NM_Formula>();
            List<NM_Formula> data_list_qty = new List<NM_Formula>();
            NM_Formula data_model_qty = new NM_Formula();
            List<NM_Formula> data_list_md = new List<NM_Formula>();
            NM_Formula data_model_md = new NM_Formula();
            List<NM_Formula> data_list_total = new List<NM_Formula>();
            NM_Formula data_model_total = new NM_Formula();
            List<NM_Formula> data_list_total_peso = new List<NM_Formula>();
            NM_Formula data_model_total_peso = new NM_Formula();
            List<NM_CondicionalMaster> data_list_conditionals = new List<NM_CondicionalMaster>();
            List<NM_CondicionalMaster> data_list_conditionals_temps = new List<NM_CondicionalMaster>();
            NM_CondicionalMaster data_model_conditionals_temps = new NM_CondicionalMaster();
            List<NM_CondicionalMaster> data_list_conditionals_temps_qty = new List<NM_CondicionalMaster>();
            NM_CondicionalMaster data_model_conditionals_temps_qty = new NM_CondicionalMaster();
            List<NM_CondicionalMaster> data_list_conditionals_temps_md = new List<NM_CondicionalMaster>();
            NM_CondicionalMaster data_model_conditionals_temps_md = new NM_CondicionalMaster();
            List<NM_CondicionalMaster> data_list_conditionals_temps_total = new List<NM_CondicionalMaster>();
            NM_CondicionalMaster data_model_conditionals_temps_total = new NM_CondicionalMaster();
            string error = string.Empty;

            try
            {
                data_list = FormuladorController.GetListFormulas(out error);
                data_list_conditionals = ConfiguracionController.GetListConditionals(out error);

                if (data_list.Count != 0)
                {
                    for (int i = 0; i < data_list.Count; i++)
                    {
                        if (data_list[i].Tipo == "qty")
                        {
                            data_model_qty = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
                            data_list_qty.Add(data_model_qty);
                        }
                        else if (data_list[i].Tipo == "md")
                        {
                            data_model_md = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
                            data_list_md.Add(data_model_md);
                        }
                        else if (data_list[i].Tipo == "total")
                        {
                            data_model_total = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
                            data_list_total.Add(data_model_total);
                        }
                        else if (data_list[i].Tipo == "peso")
                        {
                            data_model_total_peso = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
                            data_list_total_peso.Add(data_model_total_peso);
                        }
                        else
                        {
                            data_model_qty = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
                            data_list_qty.Add(data_model_qty);

                            data_model_md = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
                            data_list_md.Add(data_model_md);

                            data_model_total = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
                            data_list_total.Add(data_model_total);

                            data_model_total_peso = new NM_Formula { Id = data_list[i].Id, NombreFormula = data_list[i].NombreFormula.ToUpper() };
                            data_list_total_peso.Add(data_model_total_peso);
                        }
                    }
                }
                else
                {
                    error += "No se han capturado formulas de ningun tipo.";
                }

                if (data_list_conditionals.Count > 0)
                {
                    for (int i = 0; i < data_list_conditionals.Count; i++)
                    {
                        if (!data_list_conditionals[i].Nombre.Contains("condicional hijo"))
                        {
                            data_model_conditionals_temps_qty = new NM_CondicionalMaster();
                            data_model_conditionals_temps_md = new NM_CondicionalMaster();

                            if (data_list_conditionals[i].Tipo != null)
                            {
                                if (data_list_conditionals[i].Tipo.Contains("Cantidad"))
                                {
                                    data_model_conditionals_temps_qty.IdCondicionalMaster = data_list_conditionals[i].Id;
                                    data_model_conditionals_temps_qty.Nombre = data_list_conditionals[i].Nombre.ToUpper();
                                    data_list_conditionals_temps_qty.Add(data_model_conditionals_temps_qty);
                                }
                                else if (data_list_conditionals[i].Tipo.Contains("Medida"))
                                {
                                    data_model_conditionals_temps_md.IdCondicionalMaster = data_list_conditionals[i].Id;
                                    data_model_conditionals_temps_md.Nombre = data_list_conditionals[i].Nombre.ToUpper();
                                    data_list_conditionals_temps_md.Add(data_model_conditionals_temps_md);
                                }
                                else if (data_list_conditionals[i].Tipo.Contains("Total"))
                                {
                                    data_model_conditionals_temps_total.IdCondicionalMaster = data_list_conditionals[i].Id;
                                    data_model_conditionals_temps_total.Nombre = data_list_conditionals[i].Nombre.ToUpper();
                                    data_list_conditionals_temps_total.Add(data_model_conditionals_temps_md);
                                }
                                else if (data_list_conditionals[i].Tipo.Contains("Base"))
                                {
                                    data_model_conditionals_temps_qty.IdCondicionalMaster = data_list_conditionals[i].Id;
                                    data_model_conditionals_temps_qty.Nombre = data_list_conditionals[i].Nombre.ToUpper();
                                    data_list_conditionals_temps_qty.Add(data_model_conditionals_temps_qty);

                                    data_model_conditionals_temps_md.IdCondicionalMaster = data_list_conditionals[i].Id;
                                    data_model_conditionals_temps_md.Nombre = data_list_conditionals[i].Nombre.ToUpper();
                                    data_list_conditionals_temps_md.Add(data_model_conditionals_temps_md);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        public void Clear()
        {
            txtCombinacion.Text = "";
            rbtnAL.Checked = false;
            rbtnAN.Checked = false;
            ClearDataGrid();
            DataListCompFor = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
            txtCombinacion.Focus();
            txtShowFormulas.Text = "";
        }

        public void CreateTreeConditionals(int id)
        {
            List<ConditionalsModel> data_list = new List<ConditionalsModel>();
            string error = string.Empty;

            try
            {
                data_list = ConfiguracionController.GetListConditionals(id, out error);

                if (error == "" && data_list.Count > 0)
                {
                    for (int i = 0; i < data_list.Count; i++)
                    {
                        if (data_list[i].Nombre.Contains("CS"))
                        {
                            BuildTreeCondicionalSimple(data_list);
                        }
                        else
                        {
                            BuildTreeCondicionalMaster(data_list);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        public void BuildTreeCondicionalSimple(List<ConditionalsModel> dataList)
        {
            ConditionalsModel conditionalsModel = new ConditionalsModel();
            string error = string.Empty;

            try
            {
                for (int i = 0; i < dataList.Count; i++)
                {
                    conditionalsModel = ConfiguracionController.GetConditionals(dataList[i].Id, out error);

                    if (error == "" && conditionalsModel != null)
                    {
                        TreeNode treeNodeParent = new TreeNode(conditionalsModel.Nombre.ToUpper() + " ---> " + conditionalsModel.Condicional);
                        treeNodeParent.ForeColor = Color.DarkBlue;
                        TreeNode treeNodeChild1 = new TreeNode("Valor en Verdadero --> " + conditionalsModel.Verdadero);
                        treeNodeChild1.ForeColor = Color.Green;
                        TreeNode treeNodeChild2 = new TreeNode("Valor en falso --> " + conditionalsModel.Falso);
                        treeNodeChild2.ForeColor = Color.Red;
                        TreeNode[] treeNodes = new TreeNode[] { treeNodeChild1, treeNodeChild2 };
                        treeNodeParent = new TreeNode(conditionalsModel.Nombre.ToUpper() + " ---> " + conditionalsModel.Condicional, treeNodes);
                        treeNodeParent.ExpandAll();
                        trvShowConditional.Nodes.Add(treeNodeParent);
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        public void BuildTreeCondicionalMaster(List<ConditionalsModel> dataList)
        {
            ConditionalsModel conditionalsModel = new ConditionalsModel();
            string error = string.Empty;
            TreeNode child = new TreeNode();
            TreeNode treeNodeParent = null;
            TreeNode treeNodeChild2 = null;
            TreeNode treeNodeChild1 = null;

            try
            {
                foreach (var item in dataList)
                {
                    if (treeNodeParent == null)
                    {
                        treeNodeParent = new TreeNode(item.Nombre.ToUpper().Replace("CM", "") + " ----> " + item.Condicional);
                        treeNodeParent.ForeColor = Color.DarkBlue;
                    }
                    else
                    {
                        conditionalsModel = ConfiguracionController.GetConditionals(item.IdElemento, out error);

                        if (item.Posicion != "")
                        {
                            treeNodeParent = new TreeNode("condicional ---> ".ToUpper() + conditionalsModel.Condicional);
                            treeNodeParent.ForeColor = Color.DarkSeaGreen;

                            if (item.Posicion == "Falso")
                            {
                                treeNodeChild2 = new TreeNode("Valor en falso --> " + conditionalsModel.Falso);
                                treeNodeChild2.ForeColor = Color.Red;
                                treeNodeChild1 = new TreeNode("Valor en Verdadero --> " + conditionalsModel.Verdadero);
                                treeNodeChild1.ForeColor = Color.Green;
                            }
                            else
                            {
                                treeNodeChild2 = new TreeNode("Valor en falso --> " + conditionalsModel.Falso);
                                treeNodeChild2.ForeColor = Color.Red;
                                treeNodeChild1 = new TreeNode("Valor en Verdadero --> " + conditionalsModel.Verdadero);
                                treeNodeChild1.ForeColor = Color.Green;
                            }

                            TreeNode[] treeNodes = new TreeNode[] { treeNodeChild1, treeNodeChild2 };
                            treeNodeParent = new TreeNode("condicional ---> ".ToUpper() + conditionalsModel.Condicional, treeNodes);
                        }
                    }

                    treeNodeParent.ExpandAll();
                    trvShowConditional.Nodes.Add(treeNodeParent);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        public void UpdateFormulasFromCombo()
        {
            string update = string.Empty;

            string condicionalQty = cb_CondicionalesCantidad.Text;
            string condicionalMd = cb_CondicionalesMedida.Text;
            string formulaQty = cb_FormulaCantidad.Text;
            string formulaMd = cb_FormulaMedida.Text;
            string formulaTotal = cb_FormulaTotal.Text;
            string formulaPeso = cb_FormulaPeso.Text;
            string seccion = txt_Seccion.Text;
            string linea = txt_Linea.Text;
            string descripcion = txt_Descripcion.Text;
            string id = string.Empty;
            int opt = 1;

            if (!string.IsNullOrEmpty(condicionalQty) && !string.IsNullOrEmpty(formulaQty))
            {
                MessageBox.Show("Solo puede seleccionarse una formula o condicional en el calculo de cantidad");
            }
            else if (!string.IsNullOrEmpty(condicionalMd) && !string.IsNullOrEmpty(formulaMd))
            {
                MessageBox.Show("Solo puede seleccionarse una formula o condicional en el calculo de la medida");
            }
            else
            {
                while(opt<7)
                {
                    switch (opt)
                    {
                        case 1:
                            //CONDICIONALES
                            if (!string.Equals(condicionalQty, currentEdit.NombreCondicionalQty))
                            {
                                if (!string.IsNullOrEmpty(condicionalQty) && !string.Equals(condicionalQty, "** CONDICIONALES MASTER **") && !string.Equals(condicionalQty, "** CONDICIONALES SIMPLES **"))
                                {
                                    id = FindIdByName(condicionalQty, "Condicional");
                                    string[] split = id.Split('|');
                                    //Condicional Simple
                                    if (string.Equals(split[1], "Condicional"))
                                    {
                                        update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaQty = '0', IdCompuestoQty = '',IdCondicionalQty = '{0}'," +
                                                               " TypeConditionalQty = 'C' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", split[0], idCombinacion, idDetalleComp);
                                    }
                                    //Condicional Master
                                    else
                                    {
                                        update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaQty = '0', IdCondicionalQty = '{0}', TypeConditionalQty = 'M', " +
                                                               "IdCompuestoQty = '{1}' WHERE IdCombinacion = '{2}' AND IdDetalleComp = '{3}'", split[0], split[1], idCombinacion, idDetalleComp);
                                    }

                                    sql.ExecuteQuery(update);
                                }
                                else
                                {
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdCondicionalQty = '0', TypeConditionalQty = '', " +
                                                                   "IdCompuestoQty = '' WHERE IdCombinacion = '{0}' AND IdDetalleComp = '{1}'", idCombinacion, idDetalleComp);
                                    sql.ExecuteQuery(update);
                                }
                            }
                            opt++;
                            break;

                        case 2:
                            if (!string.Equals(condicionalMd, currentEdit.NombreCondicionalMd))
                            {
                                if (!string.IsNullOrEmpty(condicionalMd) && !string.Equals(condicionalQty, "** CONDICIONALES MASTER **") && !string.Equals(condicionalQty, "** CONDICIONALES SIMPLES **"))
                                {
                                    id = FindIdByName(condicionalMd, "Condicional");
                                    string[] split = id.Split('|');
                                    if (string.Equals(split[1], "Condicional"))
                                    {
                                        update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaMd = '0', IdCompuestoMd = '',IdCondicionalMd = '{0}'," +
                                                               " TypeConditionalQty = 'C' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", split[0], idCombinacion, idDetalleComp);
                                    }
                                    else
                                    {
                                        update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaMd = '0', IdCondicionalMd = '{0}', TypeConditionalMd = 'M', IdCompuestoMd = '{1}' " +
                                                               "WHERE IdCombinacion = '{2}' AND IdDetalleComp = '{3}'", split[0], split[1], idCombinacion, idDetalleComp);
                                    }

                                    sql.ExecuteQuery(update);
                                }
                                else
                                {
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdCondicionalMd = '0', TypeConditionalMd = '', IdCompuestoMd = '0' " +
                                                               "WHERE IdCombinacion = '{0}' AND IdDetalleComp = '{1}'", idCombinacion, idDetalleComp);
                                    sql.ExecuteQuery(update);
                                }
                            }
                            opt++;
                            break;

                        case 3:
                            //FORMULAS
                            if (!string.Equals(formulaQty, currentEdit.NombreFormulaQty))
                            {
                                if (!string.IsNullOrEmpty(formulaQty))
                                {
                                    id = FindIdByName(formulaQty, "Formula");
                                    string[] split = id.Split('|');
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdCompuestoQty = '',IdCondicionalQty = '0'," +
                                                           " TypeConditionalQty = '', IdFormulaQty = '{0}' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", split[0], idCombinacion, idDetalleComp);
                                }
                                else
                                {
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaQty = '0' WHERE IdCombinacion = '{0}' AND IdDetalleComp = '{1}'", idCombinacion, idDetalleComp);

                                }
                                sql.ExecuteQuery(update);
                            }
                            if (!string.Equals(formulaMd, currentEdit.NombreFormulaMd))
                            {
                                if (!string.IsNullOrEmpty(formulaMd))
                                {
                                    id = FindIdByName(formulaMd, "Formula");
                                    string[] split = id.Split('|');
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdCondicionalMd = '0', IdCompuestoMd = '' ," +
                                                           " TypeConditionalQty = '', IdFormulaMd = '{0}' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", split[0], idCombinacion, idDetalleComp);
                                }
                                else
                                {
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaQty = '0' WHERE IdCombinacion = '{0}' AND IdDetalleComp = '{1}'", idCombinacion, idDetalleComp);

                                }

                                sql.ExecuteQuery(update);
                            }
                            opt++;
                            break;

                        case 4:
                            //TOTAL
                            if (!string.Equals(formulaTotal, currentEdit.NombreFormulaTotal))
                            {
                                if (!string.IsNullOrEmpty(formulaTotal))
                                {
                                    id = FindIdByName(formulaTotal, "Formula");
                                    string[] split = id.Split('|');
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaTotal = '{0}' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", split[0], idCombinacion, idDetalleComp);

                                    
                                }
                                else
                                {
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaTotal = '0' WHERE IdCombinacion = '{0}' AND IdDetalleComp = '{1}'", idCombinacion, idDetalleComp);
                                }
                                sql.ExecuteQuery(update);
                            }
                            opt++;
                            break;

                        case 5:
                            //PESO
                            if (!string.Equals(formulaPeso, currentEdit.NombreFormulaPeso))
                            {
                                if (!string.IsNullOrEmpty(formulaPeso))
                                {
                                    id = FindIdByName(formulaPeso, "Formula");
                                    string[] split = id.Split('|');
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaPeso = '{0}' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", split[0], idCombinacion, idDetalleComp);

                                }
                                else
                                {
                                    update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaPeso = '0' WHERE IdCombinacion = '{0}' AND IdDetalleComp = '{1}'", idCombinacion, idDetalleComp);
                                }
                                sql.ExecuteQuery(update);
                            }
                            opt++;
                            break;

                        case 6:
                            //SECCION, LINEA Y TOTAL
                            if (!string.Equals(seccion, currentEdit.Seccion))
                            {
                                update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET Seccion = '{0}' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", seccion, idCombinacion, idDetalleComp);

                                sql.ExecuteQuery(update);
                            }
                            if (!string.Equals(linea, currentEdit.Linea))
                            {
                                update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET Linea = '{0}' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", linea, idCombinacion, idDetalleComp);

                                sql.ExecuteQuery(update);
                            }
                            if (!string.Equals(descripcion, currentEdit.Descripcion))
                            {
                                update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET Descripcion = '{0}' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", descripcion, idCombinacion, idDetalleComp);

                                sql.ExecuteQuery(update);
                            }
                            opt++;
                            break;
                    }
                }
            }

            ClearCombo();
            BuscarFormulasModelo();
        }

        //public void UpdateFormulas()
        //{
        //    DataGridViewRow currentRow = new DataGridViewRow();
        //    string condicionalQty = string.Empty;
        //    string condicionalMd = string.Empty;
        //    string formulaQty = string.Empty;
        //    string formulaMd = string.Empty;
        //    string formulaTotal = string.Empty;
        //    string update = string.Empty;
        //    string id = string.Empty;
        //    string idCompuesto = string.Empty;
        //    string idModelo = string.Empty;
        //    string idDetalleComp = string.Empty;
        //    string referencia = string.Empty;

        //    for (int i=0;i<dgvFormulasToAssociate.Rows.Count;i++)
        //    {
        //        try
        //        {
        //            currentRow = dgvFormulasToAssociate.Rows[i] as DataGridViewRow;
        //            condicionalQty = Convert.ToString(currentRow.Cells["ConditionalQty1"].Value);
        //            condicionalMd = Convert.ToString(currentRow.Cells["ConditionalMd1"].Value);
        //            formulaQty = Convert.ToString(currentRow.Cells["FormulaQty1"].Value);
        //            formulaMd =  Convert.ToString(currentRow.Cells["FormulaMd1"].Value);
        //            formulaTotal = Convert.ToString(currentRow.Cells["FormulaTotal1"].Value);
        //            idModelo = Convert.ToString(currentRow.Cells["modeloBom"].Value);
        //            idDetalleComp = Convert.ToString(currentRow.Cells["IdDetalleComp1"].Value);
        //            referencia = Convert.ToString(currentRow.Cells["Id_Reference"].Value);


        //            if (!string.IsNullOrEmpty(condicionalQty) || !string.IsNullOrEmpty(condicionalMd) || !string.IsNullOrEmpty(formulaQty) ||
        //               !string.IsNullOrEmpty(formulaMd) || !string.IsNullOrEmpty(formulaTotal))
        //            {

        //                if(!string.IsNullOrEmpty(condicionalQty) && !string.IsNullOrEmpty(formulaQty))
        //                {
        //                    MessageBox.Show("Solo puede seleccionarse una formula o condicional en el calculo de cantidad");
        //                }
        //                else
        //                {
        //                    //CONDICIONALES
        //                    if (!string.IsNullOrEmpty(condicionalQty))
        //                    {
        //                        id = FindIdByName(condicionalQty, "Condicional");
        //                        string[] split = id.Split('|');
        //                        //Condicional Simple
        //                        if (string.Equals(split[1], "Condicional"))
        //                        {
        //                            update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaQty = '0', IdCompuestoQty = '',IdCondicionalQty = '{0}'," +
        //                                                   " TypeConditionalQty = 'C' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", split[0], idModelo, idDetalleComp);
        //                        }
        //                        //Condicional Master
        //                        else
        //                        {
        //                            update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaQty = '0', IdCondicionalQty = '{0}', TypeConditionalQty = 'M', " +
        //                                                   "IdCompuestoQty = '{1}' WHERE IdCombinacion = '{2}' AND IdDetalleComp = '{3}'", split[0], split[1], idModelo, idDetalleComp);
        //                        }

        //                        sql.ExecuteQuery(update);
        //                    }
        //                    if (!string.IsNullOrEmpty(condicionalMd))
        //                    {
        //                        id = FindIdByName(condicionalMd, "Condicional");
        //                        string[] split = id.Split('|');
        //                        if (string.Equals(split[1], "Condicional"))
        //                        {
        //                            update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaMd = '0', IdCompuestoMd = '',IdCondicionalMd = '{0}'," +
        //                                                   " TypeConditionalQty = 'C' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", split[0], idModelo, idDetalleComp);
        //                        }
        //                        else
        //                        {
        //                            update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaMd = '0', IdCondicionalMd = '{0}', TypeConditionalMd = 'M', IdCompuestoMd = '{1}' " +
        //                                                   "WHERE IdCombinacion = '{2}' AND IdDetalleComp = '{3}'", split[0], split[1], idModelo, idDetalleComp);
        //                        }

        //                        sql.ExecuteQuery(update);
        //                    }
        //                    //FORMULAS
        //                    if (!string.IsNullOrEmpty(formulaQty))
        //                    {
        //                        id = FindIdByName(formulaQty, "Formula");
        //                        string[] split = id.Split('|');
        //                        update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdCompuestoQty = '',IdCondicionalQty = '0'," +
        //                                               " TypeConditionalQty = '', IdFormulaQty = '{0}' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", split[0], idModelo, idDetalleComp);

        //                        sql.ExecuteQuery(update);
        //                    }
        //                    if (!string.IsNullOrEmpty(formulaMd))
        //                    {
        //                        id = FindIdByName(formulaMd, "Formula");
        //                        string[] split = id.Split('|');
        //                        update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdCondicionalQty = '0', IdCompuestoQty = '' ," +
        //                                               " TypeConditionalQty = '', IdFormulaMd = '{0}' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", split[0], idModelo, idDetalleComp);

        //                        sql.ExecuteQuery(update);
        //                    }

        //                    //TOTAL
        //                    if (!string.IsNullOrEmpty(formulaTotal))
        //                    {
        //                        id = FindIdByName(formulaTotal, "Formula");
        //                        string[] split = id.Split('|');
        //                        update = string.Format("UPDATE NM_Detalle_Combinacion_Componentes_Formulas SET IdFormulaTotal = '{0}' WHERE IdCombinacion = '{1}' AND IdDetalleComp = '{2}'", split[0], idModelo, idDetalleComp);

        //                        sql.ExecuteQuery(update);
        //                    }

        //                    dgvCombinacionesFormulas.Rows[Convert.ToInt32(referencia)].Cells[4].Value = false;
        //                    dgvFormulasToAssociate.Rows.Remove(currentRow);
        //                }
                        
        //            }
        //        }
        //        catch(Exception e)
        //        {
        //            string message = e.Message;
        //        }
        //    }
        //}

        //public void Uncheck()
        //{
        //    for(int i = 0;i<dgvFormulasToAssociate.Rows.Count;i++)
        //    {
        //        dgvCombinacionesFormulas.Rows[i].Cells[4].Value = false;
        //    }
        //}

        public string FindIdByName(string name, string type)
        {
            string id = string.Empty;
            List<string> aux = new List<string>();
            List<int> auxInt = new List<int>();
            NM_CondicionalMaster cond = new NM_CondicionalMaster();

            if (string.Equals(type,"Condicional"))
            {
                List<NM_CondicionalMaster> master = sql.GetMasterCondicional();
                List<NM_Condicional> condicionales = sql.GetCondicionales();
                aux = (from condicional in condicionales where condicional.NombreCondicional == name select condicional.Id.ToString()).ToList();
                
                if(aux.Count>0)
                {
                    id = aux[0];
                    id += "|Condicional";
                }
                else
                {
                    cond = (from condicional in master where condicional.Nombre == name select condicional).ToList()[0];
                    id = cond.IdCondicionalMaster + "|" + cond.IdCompuesto + "|CondicionalMaster";
                }
            }
            else
            {
                List<NM_Formula> formulas = sql.GetGeneralFormulas("SELECT * from NM_Formulas");
                id = (from formula in formulas where formula.NombreFormula == name select formula.Id).ToList()[0].ToString();
                id += "|Formula";
            }

            return id;
        }

        public bool CheckEnables()
        {
            for(int i =0;i<dgvCombinacionesFormulas.Rows.Count;i++)
            {
                if(Convert.ToBoolean(dgvCombinacionesFormulas.Rows[i].Cells[4].Value))
                {
                    return true;
                }
            }
            return false;
        }

        //public void RemoveElementByIndex(int index)
        //{
        //    for(int i = 0;i<dgvFormulasToAssociate.Rows.Count;i++)
        //    {
        //        if(Convert.ToInt32(dgvFormulasToAssociate.Rows[i].Cells[0].Value)==index)
        //        {
        //            dgvFormulasToAssociate.Rows.RemoveAt(i);
        //            return;
        //        }
        //    }
            
        //}

        //private void dgvFormulasToAssociate_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        //{
        //    int id = 0;
        //    string formula = string.Empty;
        //    string error = string.Empty;
        //    var ev = e as DataGridViewCellEventArgs;
        //    string name = string.Empty;
        //    ComboBox combo = sender as ComboBox;

        //    try
        //    {
        //        if(dgvFormulasToAssociate.IsCurrentCellDirty)
        //        {
        //            DataGridViewCell current = dgvFormulasToAssociate.CurrentCell;

        //            if (dgvFormulasToAssociate.Columns[current.ColumnIndex].Name == "ConditionalQty1")
        //            {
        //                //id = Convert.ToInt32(this.dgvFormulasToAssociate[ev.ColumnIndex, ev.RowIndex].Value.ToString());
        //                name = current.EditedFormattedValue.ToString();

        //                id = Convert.ToInt32(FindIdByName(name, "Condicional").Split('|')[0]);

        //                if (id > 0)
        //                {
        //                    if (trvShowConditional.Nodes.Count > 0)
        //                    {
        //                        trvShowConditional.Nodes[0].Remove();
        //                        trvShowConditional.ResetText();
        //                        trvShowConditional.Nodes.Clear();
        //                    }

        //                    CreateTreeConditionals(id);
        //                }
        //                else
        //                {
        //                    trvShowConditional.ResetText();
        //                }
        //            }

        //            if (dgvFormulasToAssociate.Columns[ev.ColumnIndex].Name == "ConditionalMd1")
        //            {
        //                id = Convert.ToInt32(this.dgvFormulasToAssociate[ev.ColumnIndex, ev.RowIndex].Value.ToString());

        //                if (id > 0)
        //                {
        //                    if (trvShowConditional.Nodes.Count > 0)
        //                    {
        //                        trvShowConditional.Nodes[0].Remove();
        //                        trvShowConditional.ResetText();
        //                    }

        //                    CreateTreeConditionals(id);
        //                }
        //                else
        //                {
        //                    trvShowConditional.Nodes[0].Remove();
        //                    trvShowConditional.ResetText();
        //                    trvShowConditional.Nodes.Clear();
        //                }
        //            }

        //            if (dgvFormulasToAssociate.Columns[ev.ColumnIndex].Name == "ConditionalTotal1")
        //            {
        //                id = Convert.ToInt32(this.dgvFormulasToAssociate[ev.ColumnIndex, ev.RowIndex].Value.ToString());

        //                if (id > 0)
        //                {
        //                    if (trvShowConditional.Nodes.Count > 0)
        //                    {
        //                        trvShowConditional.Nodes[0].Remove();
        //                        trvShowConditional.ResetText();
        //                    }

        //                    CreateTreeConditionals(id);
        //                }
        //                else
        //                {
        //                    trvShowConditional.Nodes[0].Remove();
        //                    trvShowConditional.ResetText();
        //                    trvShowConditional.Nodes.Clear();
        //                }
        //            }

        //            if (dgvFormulasToAssociate.Columns[ev.ColumnIndex].Name == "FormulaQty1")
        //            {
        //                id = Convert.ToInt32(this.dgvFormulasToAssociate[ev.ColumnIndex, ev.RowIndex].Value.ToString());

        //                if (id > 0)
        //                {
        //                    formula = ConfiguracionController.GetFormula(id, out error);

        //                    if (error == "")
        //                    {
        //                        txtShowFormulas.Text = formula;
        //                    }
        //                }
        //                else
        //                {
        //                    txtShowFormulas.Text = "";
        //                }
        //            }

        //            if (dgvFormulasToAssociate.Columns[ev.ColumnIndex].Name == "FormulaMd1")
        //            {
        //                id = Convert.ToInt32(this.dgvFormulasToAssociate[ev.ColumnIndex, ev.RowIndex].Value.ToString());

        //                if (id > 0)
        //                {
        //                    formula = ConfiguracionController.GetFormula(id, out error);

        //                    if (error == "")
        //                    {
        //                        txtShowFormulas.Text = formula;
        //                    }
        //                }
        //                else
        //                {
        //                    txtShowFormulas.Text = formula;
        //                }
        //            }

        //            if (dgvFormulasToAssociate.Columns[ev.ColumnIndex].Name == "FormulaTotal1")
        //            {
        //                id = Convert.ToInt32(this.dgvFormulasToAssociate[ev.ColumnIndex, ev.RowIndex].Value.ToString());

        //                if (id > 0)
        //                {
        //                    formula = ConfiguracionController.GetFormula(id, out error);

        //                    if (error == "")
        //                    {
        //                        txtShowFormulas.Text = formula;
        //                    }
        //                }
        //                else
        //                {
        //                    txtShowFormulas.Text = formula;
        //                }
        //            }

        //            if (dgvFormulasToAssociate.Columns[ev.ColumnIndex].Name == "FormulaPeso1")
        //            {
        //                id = Convert.ToInt32(this.dgvFormulasToAssociate[ev.ColumnIndex, ev.RowIndex].Value.ToString());

        //                if (id > 0)
        //                {
        //                    formula = ConfiguracionController.GetFormula(id, out error);

        //                    if (error == "")
        //                    {
        //                        txtShowFormulas.Text = formula;
        //                    }
        //                }
        //                else
        //                {
        //                    txtShowFormulas.Text = formula;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        error = ex.Message;
        //    }
        //}

        private void dgvCombinacionesFormulas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvCombinacionesFormulas.Columns[e.ColumnIndex].Name.Equals("Editar"))
            {
                btnAsocias.Visible = true;
                List<NM_CondicionalMaster> master = sql.GetMasterCondicional();
                List<NM_Condicional> condicionales = sql.GetCondicionales();
                List<NM_Formula> formulas = sql.GetGeneralFormulas("SELECT * from NM_Formulas");
                List<string> duo = JoinListConditional(master, condicionales);
                formulas.Insert(0, new NM_Formula { Id = 0, NombreFormula = "", Tipo = "", Formula = "", FechaCreacion = "" });

                cb_CondicionalesCantidad.DataSource = duo;
                cb_CondicionalesMedida.DataSource = duo.ToList();
                cb_FormulaCantidad.DataSource = (from formula in formulas where formula.Tipo != "total" select formula.NombreFormula).ToList();
                cb_FormulaMedida.DataSource = (from formula in formulas where formula.Tipo != "total" select formula.NombreFormula).ToList();
                duo = (from formula in formulas where formula.Tipo == "total" select formula.NombreFormula).ToList();
                duo.Insert(0, "");
                cb_FormulaTotal.DataSource = duo;
                cb_FormulaPeso.DataSource = (from formula in formulas where formula.Tipo == "peso" select formula.NombreFormula).ToList();

                tb_NumeroParte.Text = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["ItemnoComponent"].Value.ToString();
                cb_CondicionalesCantidad.Text = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["ConditionalQty"].Value.ToString();
                if(!string.IsNullOrEmpty(cb_CondicionalesCantidad.Text))
                    cb_CondicionalesCantidad.AutoCompleteMode = AutoCompleteMode.Suggest;

                cb_CondicionalesMedida.Text = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["ConditionalMd"].Value.ToString();
                if (!string.IsNullOrEmpty(cb_CondicionalesMedida.Text))
                    cb_CondicionalesMedida.AutoCompleteMode = AutoCompleteMode.Suggest;

                cb_FormulaCantidad.Text = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["FormulaQty"].Value.ToString();
                if (!string.IsNullOrEmpty(cb_FormulaCantidad.Text))
                    cb_FormulaCantidad.AutoCompleteMode = AutoCompleteMode.Suggest;

                cb_FormulaMedida.Text = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["FormulaMd"].Value.ToString();
                if (!string.IsNullOrEmpty(cb_FormulaMedida.Text))
                    cb_FormulaMedida.AutoCompleteMode = AutoCompleteMode.Suggest;

                cb_FormulaTotal.Text = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["FormulaTotal"].Value.ToString();
                if (!string.IsNullOrEmpty(cb_FormulaTotal.Text))
                    cb_FormulaTotal.AutoCompleteMode = AutoCompleteMode.Suggest;
                
                cb_FormulaPeso.Text = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["FormulaPeso"].Value.ToString();
                if (!string.IsNullOrEmpty(cb_FormulaPeso.Text))
                    cb_FormulaPeso.AutoCompleteMode = AutoCompleteMode.Suggest;

                txt_Seccion.Text = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["Seccion"].Value.ToString();

                txt_Linea.Text = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["Linea"].Value.ToString();

                txt_Descripcion.Text = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();

                currentEdit.NombreCondicionalQty = cb_CondicionalesCantidad.Text;
                currentEdit.NombreCondicionalMd = cb_CondicionalesMedida.Text;
                currentEdit.NombreFormulaQty = cb_FormulaCantidad.Text;
                currentEdit.NombreFormulaMd = cb_FormulaMedida.Text;
                currentEdit.NombreFormulaTotal = cb_FormulaTotal.Text;
                currentEdit.NombreFormulaPeso = cb_FormulaPeso.Text;
                currentEdit.Seccion = txt_Seccion.Text;
                currentEdit.Linea = Convert.ToInt32(txt_Linea.Text);
                currentEdit.Descripcion = txt_Descripcion.Text;

                idCombinacion = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["IdCombinacion_"].Value.ToString();
                idDetalleComp = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["IdDetalleForCom"].Value.ToString();
            }
        }

        public void ShowFormula(string nombreComponente)
        {
            if (!string.IsNullOrEmpty(nombreComponente))
            {
                string QUERY = string.Format("SELECT Formula FROM NM_Formulas WHERE NombreFormula = '{0}'", nombreComponente);
                string formula = sql.Select(QUERY, "Formula");
                txtShowFormulas.Text = formula;
            }
        }

        public TreeNode AddNodoCondicional(TreeNode node, NM_Condicional condicional)
        {
            if (node.Nodes.Count > 0)
            {
                node.Nodes.Remove(node.FirstNode);
            }
            node.Nodes.Add("Condicional - " + condicional.Condicional);
            TreeNode nodoCondicional = node.FirstNode;
            nodoCondicional.Tag = "Condicional";
            TreeNode verdadero = new TreeNode();
            TreeNode falso = new TreeNode();
            nodoCondicional.ForeColor = Color.Blue;
            nodoCondicional.Nodes.Add("Verdadero");
            nodoCondicional.Nodes.Add("Falso");
            nodoCondicional.Name = "Condicional - " + condicional.Condicional;

            verdadero = nodoCondicional.Nodes[0];
            falso = nodoCondicional.Nodes[1];

            verdadero.ForeColor = Color.Green;
            falso.ForeColor = Color.Red;

            verdadero.Nodes.Add(condicional.Verdadero);
            falso.Nodes.Add(condicional.Falso);
            return nodoCondicional;
        }

        public TreeNode AddNodo(TreeNode node, NM_Condicional condicional)
        {
            TreeNode _node = new TreeNode();
            node.Nodes[0].Remove();

            return _node;
        }

        public TreeNode AddRoot(NM_Condicional condicional)
        {
            trvShowConditional.Nodes.Add("Raiz", "Raiz - " + condicional.Condicional);
            TreeNode raiz = trvShowConditional.Nodes[0];
            NM_CondicionalMaster master = new NM_CondicionalMaster();
            raiz.Tag = condicional.Id;
            raiz.ForeColor = Color.Blue;
            raiz.Name = "Raiz - " + condicional.Condicional;
            raiz.Nodes.Add("Verdadero", "Verdadero");
            raiz.Nodes.Add("Falso", "Falso");

            TreeNode verdadero = raiz.Nodes[0];
            verdadero.ForeColor = Color.Green;
            TreeNode falso = raiz.Nodes[1];
            falso.ForeColor = Color.Red;

            verdadero.Nodes.Add(condicional.Verdadero);
            falso.Nodes.Add(condicional.Falso);

            TreeNode valorVerdadero = verdadero.Nodes[0];
            TreeNode valorFalso = falso.Nodes[0];

            raiz.ExpandAll();
            return raiz;
        }

        public void ShowCondicional(string nameCondicional)
        {
            if(!string.IsNullOrEmpty(nameCondicional) )
            {
                string id = FindIdByName(nameCondicional, "Condicional");
                string[] split = id.Split('|');

                if (string.Equals(split[1], "Condicional"))
                {
                    NM_Condicional condicional = sql.GetCondicional(split[0]);
                    trvShowConditional.Nodes.Clear();
                    AddRoot(condicional);
                }
                else
                {
                    GetCondicionalesFromMaster(split[0],nameCondicional);
                }
            }
        }

        public void GetCondicionalesFromMaster(string idMaster, string nameCondicional)
        {
            NM_CondicionalMaster _master = sql.GetCondicionalMasterById(idMaster,nameCondicional);
            List<NM_CondicionalMaster> masters = sql.GetElementsMasterCondicional(idMaster, _master.IdCompuesto, _master.Nombre).OrderBy(x=>x.Nivel).ToList();
            List<NM_Condicional> condicionales = new List<NM_Condicional>();
            List<NM_CondicionalMaster> mastersAux = new List<NM_CondicionalMaster>();
            TreeNode[] arrayMaster = new TreeNode[] { };
            NM_Condicional condicional;
            TreeNode _base = new TreeNode();
            TreeNode currentNode = new TreeNode();
            TreeNode Verdadero = new TreeNode();
            TreeNode Falso = new TreeNode();
            TreeNode nodoAuxiliar = new TreeNode();
            List<TreeNode> listas = new List<TreeNode>();
            int level = 2;
            string nodoPadre = string.Empty;

            trvShowConditional.Nodes.Clear();

            foreach(var master in masters)
            {
                if (string.Equals(master.Tipo, "Raiz"))
                {
                    condicional = new NM_Condicional();
                    condicional = sql.GetCondicional(master.IdElemento.ToString());
                    currentNode = AddRoot(condicional);
                    _base = currentNode;
                    Verdadero = currentNode.FirstNode;
                    Falso = currentNode.LastNode;
                    master.IsUsed = true;
                }
                else if (string.Equals(master.Tipo, "Condicional"))
                {
                    if (string.Equals(master.Posicion, "Verdadero"))
                    {
                        condicional = new NM_Condicional();
                        condicional = sql.GetCondicional(master.IdElemento.ToString());

                        if(!string.IsNullOrEmpty(master.NodoPadre))
                        {
                            nodoAuxiliar = trvShowConditional.Nodes.Find(master.NodoPadre, true)[0];
                            AddNodoCondicional(nodoAuxiliar.FirstNode, condicional);
                        }
                        else
                        {
                            nodoAuxiliar = AddNodoCondicional(Verdadero, condicional);
                            mastersAux = (from list in masters where list.IsUsed == false && list.Nivel.ToString() == level.ToString() select list).ToList();
                            if (mastersAux.Count > 0)
                            {
                                Verdadero = currentNode.FirstNode;
                                Falso = currentNode.LastNode;
                            }
                            else
                            {
                                Verdadero = nodoAuxiliar.FirstNode;
                                Falso = nodoAuxiliar.LastNode;
                                level += 2;
                            }
                        }
                        master.IsUsed = true;
                        
                    }
                    else
                    {
                        condicional = new NM_Condicional();
                        condicional = sql.GetCondicional(master.IdElemento.ToString());

                        if (!string.IsNullOrEmpty(master.NodoPadre))
                        {
                            try
                            {
                                nodoAuxiliar = trvShowConditional.Nodes.Find(master.NodoPadre, true)[0];
                                AddNodoCondicional(nodoAuxiliar.LastNode, condicional);
                            }
                            catch (Exception ex) { }
                            
                        }
                        else
                        {
                            nodoAuxiliar = AddNodoCondicional(Falso, condicional);
                            mastersAux = (from list in masters where list.IsUsed == false && list.Nivel.ToString() == level.ToString() select list).ToList();
                            if (mastersAux.Count > 0)
                            {
                                Verdadero = currentNode.FirstNode;
                                Falso = currentNode.LastNode;
                            }
                            else
                            {
                                Verdadero = nodoAuxiliar.FirstNode;
                                Falso = nodoAuxiliar.LastNode;
                                level += 2;
                            }
                        }
                        master.IsUsed = true;
                    }
                }

                
            }
            _base.ExpandAll();
        }

        private void cb_FormulaTotal_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowFormula(cb_FormulaTotal.Text);
        }

        private void cb_FormulaCantidad_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowFormula(cb_FormulaCantidad.Text);
        }

        private void cb_FormulaMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowFormula(cb_FormulaMedida.Text);
        }

        private void cb_FormulaPeso_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowFormula(cb_FormulaPeso.Text);
        }

        private void cb_CondicionalesCantidad_SelectedValueChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cb_CondicionalesCantidad.Text) && !string.Equals(cb_CondicionalesCantidad.Text, "** CONDICIONALES MASTER **")
                && !string.Equals(cb_CondicionalesCantidad.Text, "** CONDICIONALES SIMPLES **"))
            {
                ShowCondicional(cb_CondicionalesCantidad.Text);
            }
        }

        private void cb_CondicionalesMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cb_CondicionalesMedida.Text) && !string.Equals(cb_CondicionalesMedida.Text, "** CONDICIONALES MASTER **")
                && !string.Equals(cb_CondicionalesMedida.Text, "** CONDICIONALES SIMPLES **"))
            {
                ShowCondicional(cb_CondicionalesMedida.Text);
            }
        }

        private void btnEliminarBom_Click(object sender, EventArgs e)
        {
            string combinacion = txtCombinacion.Text;
            string finish_material = string.Empty;
            string idCombinacion = string.Empty;
            bool deleteCombinacion = false;
            bool deleteDetalleFormulas = false;
            bool deleteDetalleComponentes = false;

            if (rbtnAL.Checked)
            {
                finish_material = "AL";
            }

            if (rbtnAN.Checked)
            {
                finish_material = "AN";
            }

            idCombinacion = sql.GetIdCombinacion(combinacion, finish_material);

            if (!string.IsNullOrEmpty(idCombinacion))
            {
                var result = MessageBox.Show("¿Esta seguro que desea eliminar este modelo?", "AVISO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    deleteDetalleComponentes = sql.DeleteNM_Detalle_Combinaciones_Componentes(idCombinacion);
                    deleteDetalleFormulas = sql.DeleteNM_Detalle_Combinacion_Componentes_Formulas(idCombinacion);
                    deleteCombinacion = sql.DeleteNM_Combinacion(idCombinacion);

                    if (deleteCombinacion && deleteDetalleComponentes && deleteDetalleFormulas)
                    {
                        MessageBox.Show("El BOM se ha borrado con exito!");
                    }
                    ClearCombo();
                    ClearDataGrid();
                }
            }
        }
    }
}
