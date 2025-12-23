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
    public partial class frmBuscarFormulas : Form
    {
        SQLServer sql = new SQLServer();
        List<NM_Formula> formulas = new List<NM_Formula>();
        List<NM_Condicional> validaciones = new List<NM_Condicional>();
        public frmBuscarFormulas()
        {
            InitializeComponent();
            _Init_();
        }

        public void _Init_()
        {
            FillDGVFormulas();
            FillDGVCondicionales();
            DisableAllColumnsRB();
            rb_tipo_simple.Checked = true;
        }

        public void FillDGVFormulas(List<NM_Formula> formulas = null)
        {
            if(formulas==null || formulas.Count==0)
            {
                this.formulas = sql.GetGeneralFormulas("SELECT * FROM NM_Formulas");
                this.formulas = this.formulas.OrderBy(x => x.NombreFormula).ToList();
                formulas = this.formulas;
            }

            dgv_Formulas.Rows.Clear();

            foreach (NM_Formula formula in formulas)
            {
                dgv_Formulas.Rows.Add(formula.Id, formula.NombreFormula, formula.Tipo, formula.Formula, formula.FechaCreacion);
            }
        }

        public void FillDGVCondicionales(List<NM_Condicional> condicionales = null)
        {
            if(condicionales==null || condicionales.Count==0)
            {
                this.validaciones = sql.GetCondicionales();
                this.validaciones = this.validaciones.OrderBy(x => x.NombreCondicional).ToList();
                condicionales = this.validaciones;
            }

            dgv_Condicionales.Rows.Clear();

            foreach (NM_Condicional condicional in condicionales)
            {
                dgv_Condicionales.Rows.Add(Convert.ToInt32(condicional.Id), condicional.NombreCondicional, condicional.Condicional, condicional.Verdadero, condicional.Falso);
            }
        }

        public void DisableAllColumnsRB()
        {
            rb_Columna_Nombre.Enabled = false;
            rb_Columna_Formula.Enabled = false;
            rb_Columna_Condicional.Enabled = false;
            rb_Columna_Verdadero.Enabled = false;
            rb_Columna_Falso.Enabled = false;
            rb_Columna_Todos.Enabled = false;
        }

        public void EnableAllColumnsRB()
        {
            rb_Columna_Nombre.Enabled = true;
            rb_Columna_Formula.Enabled = true;
            rb_Columna_Condicional.Enabled = true;
            rb_Columna_Verdadero.Enabled = true;
            rb_Columna_Falso.Enabled = true;
            rb_Columna_Todos.Enabled = true;
        }

        public void EnableSimpleColumnsRB()
        {
            rb_Columna_Nombre.Enabled = true;
            rb_Columna_Formula.Enabled = true;
            rb_Columna_Condicional.Enabled = false;
            rb_Columna_Verdadero.Enabled = false;
            rb_Columna_Falso.Enabled = false;
            rb_Columna_Todos.Enabled = true;
        }

        public void EnableCondicionalColumnsRB()
        {
            rb_Columna_Nombre.Enabled = true;
            rb_Columna_Formula.Enabled = false;
            rb_Columna_Condicional.Enabled = true;
            rb_Columna_Verdadero.Enabled = true;
            rb_Columna_Falso.Enabled = true;
            rb_Columna_Todos.Enabled = true;
        }

        public void EnableTipoFormulaRB()
        {
            rb_tipo_simple.Enabled = true;
            rb_tipo_Condicional.Enabled = true;
        }
        public void DisableTipoFormulaRB()
        {
            rb_tipo_simple.Enabled = false;
            rb_tipo_Condicional.Enabled = false;
        }

        private void btn_BuscarFormula_Click(object sender, EventArgs e)
        {
            
            //Busqueda por ID
            if (rb_busquedaId.Checked)
            {
                BusquedaId();
            }
            //Busqueda por formula
            else
            {
                BusquedaFormula();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FillDGVFormulas();
            FillDGVCondicionales();
            tb_formula.Text = string.Empty;
        }

        private void rb_busquedaId_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_busquedaId.Checked)
            {
                rb_tipo_simple.Checked = true;
                DisableAllColumnsRB();
            }
            else
            {
                EnableAllColumnsRB();
            }
        }

        private void rb_tipo_simple_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_tipo_simple.Checked && rb_busquedaId.Checked == false)
            {
                EnableSimpleColumnsRB();
                tabControl_Formulas_Condicionales.SelectedTab = tab_Formulas;
            }
        }

        private void rb_tipo_Condicional_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_tipo_Condicional.Checked && rb_busquedaId.Checked == false)
            {
                EnableCondicionalColumnsRB();
                tabControl_Formulas_Condicionales.SelectedTab = tab_Condicionales;
            }
        }

        private void rb_busqueda_formula_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_busqueda_formula.Checked)
            {
                EnableSimpleColumnsRB();
                rb_tipo_simple.Checked = true;
            }
            else
            {
                rb_tipo_simple.Checked = false;
            }
        }

        public bool ValidarIds(List<string> ids)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            

            foreach(var id in ids)
            {
                if(!regex.IsMatch(id))
                {
                    return false;
                }
            }

            return true;
        }

        #region BUSQUEDAS

        public void BusquedaId()
        {
            List<NM_Formula> formulas = new List<NM_Formula>();
            List<NM_Condicional> condicionales = new List<NM_Condicional>();
            List<string> ids = tb_formula.Text.Split('%').ToList();

            if(!tb_formula.Text.Equals(string.Empty))
            {
                if (ValidarIds(ids))
                {
                    if (rb_tipo_simple.Checked)
                    {
                        //formulas = (from formula in this.formulas where formula.Id == Convert.ToInt32(tb_formula.Text) select formula).ToList();
                        formulas = sql.GetFormulasIn(ids);

                        if (formulas.Count > 0)
                        {
                            FillDGVFormulas(formulas);
                        }
                        else
                        {
                            MessageBox.Show("No se encontro el ID", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        condicionales = (from condicional in this.validaciones where condicional.Id.ToString() == tb_formula.Text select condicional).ToList();
                        if (condicionales.Count > 0)
                        {
                            FillDGVCondicionales(condicionales);
                        }
                        else
                        {
                            MessageBox.Show("No se encontro el ID", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El ID solo puede contener numeros", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                FillDGVFormulas();
            }
        }

        public void BusquedaFormula()
        {
            List<NM_Formula> formulas = new List<NM_Formula>();
            List<NM_Formula> formulasAux = new List<NM_Formula>();
            List<NM_Condicional> condicionales = new List<NM_Condicional>();
            List<string> columns = new List<string>() { "NombreCondicional", "Condicional", "Verdadero", "Falso" };


            if (rb_tipo_simple.Checked)
            {
                if(rb_Columna_Nombre.Checked)
                {
                    formulas = sql.GetFormulasLike("NombreFormula", tb_formula.Text);
                }
                else if (rb_Columna_Formula.Checked)
                {
                    formulas = sql.GetFormulasLike("Formula", tb_formula.Text);
                }
                else if(rb_Columna_Todos.Checked)
                {
                    formulas = sql.GetFormulasLikeTwoColumns("NombreFormula", "Formula", tb_formula.Text);
                }

                if(formulas.Count>0)
                {
                    tabControl_Formulas_Condicionales.SelectedTab = tab_Formulas;
                    FillDGVFormulas(formulas);
                }
                else
                {
                    MessageBox.Show("No se encontro ningun registro con ese criterio", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if(rb_Columna_Nombre.Checked)
                {
                    condicionales = sql.GetCondicionalesLike("NombreCondicional",tb_formula.Text);
                }
                else if(rb_Columna_Condicional.Checked)
                {
                    condicionales = sql.GetCondicionalesLike("Condicional", tb_formula.Text);
                }
                else if(rb_Columna_Verdadero.Checked)
                {
                    condicionales = sql.GetCondicionalesLike("Verdadero", tb_formula.Text);
                }
                else if (rb_Columna_Falso.Checked)
                {
                    condicionales = sql.GetCondicionalesLike("Falso", tb_formula.Text);
                }
                else if (rb_Columna_Todos.Checked)
                {
                    condicionales = sql.GetCondicionalesLikeMoreColumns(columns, tb_formula.Text);
                }

                if (condicionales.Count > 0)
                {
                    tabControl_Formulas_Condicionales.SelectedTab = tab_Condicionales;
                    FillDGVCondicionales(condicionales);
                }
                else
                {
                    MessageBox.Show("No se encontro ningun registro con ese criterio", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        #endregion

        
    }
}
