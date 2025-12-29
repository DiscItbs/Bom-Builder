using BOM_Builder.Controllers;
using BOM_Builder.Models;
using Simpro.Expr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOM_Builder.Views
{
  public partial class frmConfigurationGlobal : Form
  {
    #region VARIABLES GLOBALES

    ConfiguracionController configuracion_controller = new ConfiguracionController();
    FormuladorController formulador_controller = new FormuladorController();
    SQLServer sql = new SQLServer();
    Conexion conexion = new Conexion();
    EvaluacionFormulasController eval = new EvaluacionFormulasController();
    CondicionalesController con = new CondicionalesController();
    List<NM_CondicionalMaster> nodos = new List<NM_CondicionalMaster>();
    string idMaster = string.Empty;
    List<ArinvtModel> data_list_arinvt = new List<ArinvtModel>();
    GeneratorController generatorController = new GeneratorController();
    string idCombinacion = string.Empty;
    string idDetalleComp = string.Empty;
    FormulasUtilitiesController formulasUtilities = new FormulasUtilitiesController();
    NM_Detalle_Combinacion_Componentes_FormulasModel currentEdit = new NM_Detalle_Combinacion_Componentes_FormulasModel();
    string idCondicionalMaster = string.Empty;
    string idNombreCondicionalMaster = string.Empty;
    string idCompuestoCondicionalMaster = string.Empty;
    string idCondicional = string.Empty;
    string nombreCondicional = string.Empty;
    bool masterFlag = false;
    int indexRowClonDest = 0;

    // Sequence Management Variables
    private decimal? selectedSequenceId = null;
    private decimal? selectedProccessId = null;
    private bool isEditMode = false;

    #endregion

    #region CODIGO GENERADO NATIVAMENTE

    public frmConfigurationGlobal()
    {
      InitializeComponent();
      _Init_();
      OnLoad();
    }

    private void FrmConfigurationGlobal_Load(object sender, EventArgs e)
    {
      /// Remover el focus del dgv
      if (dgvModeloL0.RowCount > 0 && dgvModeloL0.ColumnCount > 0)
      {
        dgvModeloL0.CurrentCell = this.dgvModeloL0[0, 0];
        this.dgvModeloL0.CurrentCell.Selected = false;
      }

      if (dgvListMaterials.RowCount > 0 && dgvListMaterials.ColumnCount > 0)
      {
        dgvListMaterials.CurrentCell = this.dgvListMaterials[0, 0];
        this.dgvListMaterials.CurrentCell.Selected = false;
      }

      if (dgvModeloL1.RowCount > 0 && dgvModeloL1.ColumnCount > 0)
      {
        dgvModeloL1.CurrentCell = this.dgvModeloL1[0, 0];
        this.dgvListMaterials.CurrentCell.Selected = false;
      }

      btnCreatePreAssembly.Enabled = false;
    }

    #endregion

    #region CODIGO GENERAL

    public void OnLoad()
    {
      LoadModelosL0();
      FIllModelL0();
      LoadListMaterials();
      LoadListMaterialsCombo();
      GetInfoCombosMaterials();
      LoadMfg();
      LoadModels();
      LoadDGVCondicionalesMaster();
      LoadNMSecuencias();
      LoadSecuenceDetails();
      LoadFamilys();
      LoadDetallesSecuencesDetail();
    }

    private void _Init_()
    {
      LoadTipoFormula();
      LoadDGVFormulas();
      LoadDGVCondicionales();
      LoadCbTipoCondicional();
      FillCBFamilia();
      FillCBFamiliaDestino();
      tv_Condicional.ExpandAll();
      dgvProcessList.SelectionChanged += dgvProcessList_SelectionChanged;
      dgvListRelaExistentes.SelectionChanged += dgvListRelaExistentes_SelectionChanged;
      dgvListRelaExistentes.KeyDown += dgvListRelaExistentes_KeyDown;
      dgvListRelaExistentes.CellDoubleClick += dgvListRelaExistentes_CellDoubleClick;
      txtSecuenceBOM.KeyPress += txtSecuenceBOM_KeyPress;
    }

    public void ClearDataGrid()
    {
      dgvListComponents.Rows.Clear();
      dgvListComponents.Refresh();
      dgvListComponents.DataSource = null;

      dgvCombinacionesFormulas.Rows.Clear();
      dgvCombinacionesFormulas.Refresh();
      dgvCombinacionesFormulas.DataSource = null;
    }

    public void ClearFields()
    {
      cb_TipoFormula.SelectedIndex = 0;
      txt_Formula.Text = "";
      txt_NombreFormula.Text = "";
    }

    #endregion

    #region TAB MATERIALES

    private void BtnSaveMaterial_Click(object sender, EventArgs e)
    {
      string error = string.Empty;
      string name_material = string.Empty;
      string description_material = string.Empty;
      string temporal_name = string.Empty;
      string temporal_description = string.Empty;
      bool success = false;
      int id = 0;

      try
      {
        if (dgvListMaterials.Rows.Count > 0)
        {
          id = Convert.ToInt32(dgvListMaterials.Rows[dgvListMaterials.CurrentRow.Index].Cells["IdMaterial"].Value.ToString());
          temporal_name = dgvListMaterials.Rows[dgvListMaterials.CurrentRow.Index].Cells["NameMaterial"].Value.ToString();
          temporal_description = dgvListMaterials.Rows[dgvListMaterials.CurrentRow.Index].Cells["DescriptionMaterial"].Value.ToString();
        }

        name_material = txtNameMaterial.Text;
        description_material = txtDescriptionMaterial.Text;

        if (!string.IsNullOrEmpty(name_material))
        {
          if (id == 0 || id == 1)
          {
            if (name_material == temporal_name && description_material == temporal_description)
            {
              success = configuracion_controller.UpdateMaterial(id, name_material, description_material, out error);

              if (error == "")
              {
                error += "Se actualizo de manera correcta, el registro.";
              }
            }
            else
            {
              success = configuracion_controller.CreateMaterial(name_material, description_material, out error);

              if (error == "")
              {
                error += "Se dio de alta correctamente el registro.";
              }
            }
          }
          else if (id > 1)
          {
            success = configuracion_controller.UpdateMaterial(id, name_material, description_material, out error);

            if (error == "")
            {
              error += "Se actualizo de manera correcta, el registro.";
            }
          }
        }
        else
        {
          error += "El campo nombre es obligatorio.";
        }

        if (success)
        {
          MessageBox.Show(error, "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          ClearTabConfigurationInitial();
        }
        else
        {
          MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnEditMaterial_Click(object sender, EventArgs e)
    {
      string error = string.Empty;
      int id = 0;

      try
      {
        id = id = Convert.ToInt32(dgvListMaterials.Rows[dgvListMaterials.CurrentRow.Index].Cells["IdMaterial"].Value.ToString());
        txtNameMaterial.Text = dgvListMaterials.Rows[dgvListMaterials.CurrentRow.Index].Cells["NameMaterial"].Value.ToString();
        txtDescriptionMaterial.Text = dgvListMaterials.Rows[dgvListMaterials.CurrentRow.Index].Cells["DescriptionMaterial"].Value.ToString();
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnDeleteMaterial_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection rows = dgvListMaterials.SelectedRows;
      string error = string.Empty;
      int id = 0;
      bool success = false;

      try
      {
        id = id = Convert.ToInt32(dgvListMaterials.Rows[dgvListMaterials.CurrentRow.Index].Cells["IdMaterial"].Value.ToString());

        DialogResult result = MessageBox.Show("¿Seguro que desea eliminar el registro.?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

        if (result == DialogResult.Yes)
        {
          if (id > 0)
          {
            success = configuracion_controller.DeleteMaterial(id, out error);
          }
        }

        if (error == "" && success)
        {
          MessageBox.Show("Se elimino correctamente el registro.", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          ClearTabConfigurationInitial();
        }
        else
        {
          MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void CmbChoiceMaterial_SelectedIndexChanged(object sender, EventArgs e)
    {
      string error = string.Empty;
      bool success = false;
      int id = 0;

      try
      {
        success = Int32.TryParse(cmbChoiceMaterial.SelectedValue.ToString(), out id);

        if (success && id > 0)
        {
          dgvListSubMaterials.Rows.Clear();
          dgvListSubMaterials.Refresh();
          dgvListSubMaterials.DataSource = null;
          LoadListSubMaterials(id);
        }
        else
        {
          dgvListSubMaterials.Rows.Clear();
          dgvListSubMaterials.Refresh();
          dgvListSubMaterials.DataSource = null;
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnSaveSubMaterial_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection rows = dgvListSubMaterials.SelectedRows;
      string error = string.Empty;
      string name_material = string.Empty;
      string description_material = string.Empty;
      string temporal_name = string.Empty;
      string temporal_description = string.Empty;
      bool success = false;
      int id_Material = 0;
      int id = 0;

      try
      {
        id = Convert.ToInt32(cmbChoiceMaterial.SelectedValue);

        if (id > 0)
        {
          if (dgvListSubMaterials.Rows.Count > 0)
          {
            id_Material = Convert.ToInt32(dgvListSubMaterials.Rows[dgvListSubMaterials.CurrentRow.Index].Cells["IdSubMaterial"].Value.ToString());
            temporal_name = dgvListSubMaterials.Rows[dgvListSubMaterials.CurrentRow.Index].Cells["NameSubMaterial"].Value.ToString();
            temporal_description = dgvListSubMaterials.Rows[dgvListSubMaterials.CurrentRow.Index].Cells["DescriptionSubMaterial"].Value.ToString();
          }

          if (id_Material == 0 || id_Material == 1)
          {
            if (!string.IsNullOrEmpty(txtNameSubMaterial.Text))
            {
              name_material = txtNameSubMaterial.Text;
              description_material = txtDescriptionSubMaterial.Text;

              if (temporal_name == name_material && temporal_description == description_material)
              {
                success = configuracion_controller.UpdateSubMaterial(id_Material, name_material.ToUpper(), description_material.ToUpper(), out error);

                if (error == "")
                {
                  error += "Se actualizo de manera correcta, el registro.";
                }
              }
              else
              {
                success = configuracion_controller.CreateSubMaterial(id, name_material.ToUpper(), description_material.ToUpper(), out error);

                if (error == "")
                {
                  error += "Se dio de alta correctamente el registro.";
                }
              }
            }
            else
            {
              error += "El nombre del material es obligatorio.";
            }
          }
          else if (id_Material > 1)
          {
            if (!string.IsNullOrEmpty(txtNameSubMaterial.Text))
            {
              name_material = txtNameSubMaterial.Text;
              description_material = txtDescriptionSubMaterial.Text;

              if (temporal_name == name_material || temporal_description == description_material)
              {
                success = configuracion_controller.UpdateSubMaterial(id_Material, name_material.ToUpper(), description_material.ToUpper(), out error);

                if (error == "")
                {
                  error += "Se actualizo de manera correcta, el registro.";
                }
              }
              else
              {
                success = configuracion_controller.CreateSubMaterial(id, name_material.ToUpper(), description_material.ToUpper(), out error);

                if (error == "")
                {
                  error += "Se dio de alta correctamente el registro.";
                }
              }
            }
          }
        }
        else
        {
          error += "Debe elegir un material base.";
        }

        if (success)
        {
          MessageBox.Show(error, "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          ClearTabConfigurationInitial();
        }
        else
        {
          MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnEditSubtMaterial_Click(object sender, EventArgs e)
    {
      string error = string.Empty;
      int id = 0;

      try
      {
        id = Convert.ToInt32(dgvListSubMaterials.Rows[dgvListSubMaterials.CurrentRow.Index].Cells["IdSubMaterial"].Value.ToString());
        txtNameSubMaterial.Text = dgvListSubMaterials.Rows[dgvListSubMaterials.CurrentRow.Index].Cells["NameSubMaterial"].Value.ToString();
        txtDescriptionSubMaterial.Text = dgvListSubMaterials.Rows[dgvListSubMaterials.CurrentRow.Index].Cells["DescriptionSubMaterial"].Value.ToString();
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnDeleteSubMaterial_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection rows = dgvListSubMaterials.SelectedRows;
      string error = string.Empty;
      int id = 0;
      bool success = false;

      try
      {
        id = id = Convert.ToInt32(dgvListSubMaterials.Rows[dgvListSubMaterials.CurrentRow.Index].Cells["IdSubMaterial"].Value.ToString());

        DialogResult result = MessageBox.Show("¿Seguro que desea eliminar el registro.?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

        if (result == DialogResult.Yes)
        {
          if (id > 0)
          {
            success = configuracion_controller.DeleteSubMaterial(id, out error);
          }
        }

        if (error == "" && success)
        {
          MessageBox.Show("Se elimino correctamente el registro.", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          ClearTabConfigurationInitial();
        }
        else
        {
          MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public void LoadListMaterials()
    {
      List<NM_MaterialesModel> data_list = new List<NM_MaterialesModel>();
      data_list = configuracion_controller.GetListMaterials();

      if (data_list.Count != 0 || data_list != null)
      {
        foreach (var item in data_list)
        {
          dgvListMaterials.Rows.Add(item.Id, item.Nombre_Material, item.Descripcion_Material);
        }
      }
    }

    public void LoadListMaterialsCombo()
    {
      string error;
      List<NM_MaterialesModel> data_list = new List<NM_MaterialesModel>();
      data_list = configuracion_controller.GetListMaterialsCombo();

      //if (data_list.Count != 0 || data_list != null)
      try
      {
        if (data_list.Any())
        {
          var filterData = data_list.
              OrderBy(n => n.Nombre_Material).
              Where(d => d.Nombre_Material != "Seleccione una opcion...")
              .ToList();
          filterData.Insert(0, new NM_MaterialesModel
          {
            Id = -1,
            Nombre_Material = "Seleccione una opción..."
          });

          cmbChoiceMaterial.DataSource = filterData;
          cmbChoiceMaterial.DisplayMember = "Nombre_Material";
          cmbChoiceMaterial.ValueMember = "Id";
          cmbChoiceMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
        }

      }
      catch (Exception e)
      {
        error = "Error en LoadListMateriaslsCombo" + e.Message;
      }
      /*
      List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
      string error = string.Empty;

      try
      {
          data_list = configuracion_controller.GetListModelL0WithSubNivel(out error);

          if (data_list.Count > 0)
          {

              var filterData = data_list.OrderBy(n => n.Name_Model).Where(n => n.Name_Model != "Seleccione una opción...").ToList();
              filterData.Insert(0, new NM_ModelosLModel
                      {   Id_L0 = -1, 
                          Name_Model = "Seleccione una opción"
                      });
              cmbModeloL0.DataSource = filterData;
              cmbModeloL0.DisplayMember = "Name_Model";
              cmbModeloL0.ValueMember = "Id_L0";
              cmbModeloL0.DropDownStyle = ComboBoxStyle.DropDownList;

              //private void OrderData()
              //{
              //string error = string.Empty;
              //List<NM_ModelosLModel> data = configuracion_controller.GetListModelL0WithSubNivel(out error);
              //var filterData = data.OrderBy(n => n.Name_Model).Where(n => n.Name_Model != "Seleccione una opción...").ToList();
              //filterData.Insert(0, new NM_ModelosLModel
              //{ Id_L0 = -1, Name_Model = "Seleccione una opción"
              //}); cb_Familias.DataSource = filterData; cb_Familias.DisplayMember = "Name_Model";
              //cb_Familias.ValueMember = "Id_L0";
              //cb_Familias.DropDownStyle = ComboBoxStyle.DropDownList;
              //}

              /// Rellena el combo box de los modelos en el tab de bom x componente
              //cmbListModelL0.DataSource = data_list;
              //cmbListModelL0.DisplayMember = "Name_Model";
              //cmbListModelL0.ValueMember = "Id_L0";
              //cmbListModelL0.DropDownStyle = ComboBoxStyle.DropDownList;
              //cmbListModelL0.DropDownWidth = 300;
          }
      }
      catch (Exception ex)
      {
          error = ex.Message;
      }
      */

    }

    public void LoadListSubMaterials(int id)
    {
      List<NM_SubMaterialesModel> data_list = new List<NM_SubMaterialesModel>();
      data_list = configuracion_controller.GetLisSubtMaterials(id);

      if (data_list.Count != 0 || data_list != null)
      {
        foreach (var item in data_list)
        {
          dgvListSubMaterials.Rows.Add(item.Id, item.Id_Material_Base, item.Material_Base, item.Nombre_Material, item.Descripcion_Material);
        }
      }

      /// Remover el focus del dgv
      if (dgvListSubMaterials.RowCount > 0 && dgvListSubMaterials.ColumnCount > 0)
      {
        dgvListSubMaterials.CurrentCell = this.dgvListSubMaterials[0, 0];
        this.dgvListSubMaterials.CurrentCell.Selected = false;
      }
    }

    public void ClearTabConfigurationInitial()
    {
      txtNameMaterial.Text = "";
      txtNameSubMaterial.Text = "";

      txtDescriptionMaterial.Text = "";
      txtDescriptionSubMaterial.Text = "";

      dgvListMaterials.Rows.Clear();
      dgvListMaterials.Refresh();
      dgvListMaterials.DataSource = null;

      dgvListSubMaterials.Rows.Clear();
      dgvListSubMaterials.Refresh();
      dgvListSubMaterials.DataSource = null;

      LoadListMaterials();
      LoadListMaterialsCombo();
      GetInfoCombosMaterials();
    }

    #endregion

    #region TAB CONTROL DE MODELOS

    private void BtnCrearModelo0_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection rows = dgvModeloL0.SelectedRows;
      string error = string.Empty;
      string name_model = string.Empty;
      string descripcion_model = string.Empty;
      string description_large = string.Empty;
      string description_english = string.Empty;
      string temporal_name = string.Empty;
      string temporal_description = string.Empty;
      string apply = string.Empty;
      int id_model_l0 = 0;
      bool is_create = false;

      try
      {
        id_model_l0 = Convert.ToInt32(dgvModeloL0.Rows[dgvModeloL0.CurrentRow.Index].Cells["IdModeloL0"].Value.ToString());
        temporal_name = dgvModeloL0.Rows[dgvModeloL0.CurrentRow.Index].Cells["NombreModeloL0"].Value.ToString();
        temporal_description = dgvModeloL0.Rows[dgvModeloL0.CurrentRow.Index].Cells["DescripcionModeloL0"].Value.ToString();

        if (id_model_l0 == 0 || id_model_l0 == 1)
        {
          if (!string.IsNullOrEmpty(txtNombreL0.Text))
          {
            name_model = txtNombreL0.Text;
            descripcion_model = txtDescripcionL0.Text;
            description_large = txtLargeDescription.Text;
            description_english = txtEnglishDescription.Text;

            if (temporal_name == name_model && temporal_description == descripcion_model)
            {
              is_create = configuracion_controller.UpdateModelL0(id_model_l0, name_model.ToUpper(), descripcion_model.ToUpper(), description_large.ToUpper(), description_english.ToUpper(), out error);

              if (error == "")
              {
                error += "Se actualizo de manera correcta, el registro.";
              }
            }
            else
            {
              is_create = configuracion_controller.CreateModelL0(name_model.ToUpper(), descripcion_model.ToUpper(), description_large.ToUpper(), description_english.ToUpper(), out error);
              error += "Se dio de alta correctamente el registro.";
            }
          }
          else
          {
            error += "El nombre del modelo es obligatorio.";
          }
        }
        else if (id_model_l0 > 1)
        {
          if (!string.IsNullOrEmpty(txtNombreL0.Text))
          {
            name_model = txtNombreL0.Text;
            descripcion_model = txtDescripcionL0.Text;
            description_large = txtLargeDescription.Text;
            description_english = txtEnglishDescription.Text;

            is_create = configuracion_controller.UpdateModelL0(id_model_l0, name_model.ToUpper(), descripcion_model.ToUpper(), description_large.ToUpper(), description_english.ToUpper(), out error);
            error += "Se actualizo de manera correcta, el registro.";
          }
          else
          {
            error += "El nombre del modelo es obligatorio.";
          }
        }

        if (is_create)
        {
          MessageBox.Show(error, "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          ClearTabModels();
          LoadModelosL0();
          FIllModelL0();
        }
        else
        {
          MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
        cmbListModelL0.DataBindings.Clear();
        cb_Familias.DataBindings.Clear();
        FIllModelL0();
        FillCBFamilia();
      }
    }

    private void BtnEditarModelo0_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection rows = dgvModeloL0.SelectedRows;
      string error = string.Empty;
      string name_model = string.Empty;
      string descripcion_model = string.Empty;
      string descripcion_large = string.Empty;
      string descripcion_english = string.Empty;
      int id_model_l0 = 0;

      try
      {
        id_model_l0 = Convert.ToInt32(dgvModeloL0.Rows[dgvModeloL0.CurrentRow.Index].Cells["IdModeloL0"].Value.ToString());
        name_model = dgvModeloL0.Rows[dgvModeloL0.CurrentRow.Index].Cells["NombreModeloL0"].Value.ToString();
        descripcion_model = dgvModeloL0.Rows[dgvModeloL0.CurrentRow.Index].Cells["DescripcionModeloL0"].Value.ToString();
        descripcion_large = dgvModeloL0.Rows[dgvModeloL0.CurrentRow.Index].Cells["LargeDescription"].Value.ToString();
        descripcion_english = dgvModeloL0.Rows[dgvModeloL0.CurrentRow.Index].Cells["EnglishDescription"].Value.ToString();

        txtNombreL0.Text = name_model;
        txtDescripcionL0.Text = descripcion_model;
        txtLargeDescription.Text = descripcion_large;
        txtEnglishDescription.Text = descripcion_english;
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnEliminarModelo0_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection rows = dgvModeloL0.SelectedRows;
      string error = string.Empty;
      bool is_create = false;
      int id_model_l0 = 0;

      try
      {
        id_model_l0 = Convert.ToInt32(dgvModeloL0.Rows[dgvModeloL0.CurrentRow.Index].Cells["IdModeloL0"].Value.ToString());

        DialogResult result = MessageBox.Show("¿Seguro que desea eliminar el registro.?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

        if (result == DialogResult.Yes)
        {
          if (id_model_l0 > 0)
          {
            is_create = configuracion_controller.DeleteModelL0(id_model_l0, out error);
          }
        }

        if (error == "" && is_create)
        {
          MessageBox.Show("Se elimino correctamente el registro.", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          ClearTabModels();
          LoadModelosL0();
        }
        else
        {
          MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void CmbModeloL0_SelectedIndexChanged(object sender, EventArgs e)
    {
      int id_model_l0 = 0;
      bool success = false;
      success = Int32.TryParse(cmbModeloL0.SelectedValue.ToString(), out id_model_l0);
      cmbChoiceMaterial.DropDownStyle = ComboBoxStyle.DropDownList;

      // Configuración para el scrollbar
      cmbChoiceMaterial.MaxDropDownItems = 10; // Máximo de items visibles
      cmbChoiceMaterial.IntegralHeight = false; // Desactiva el ajuste automático de altura
      cmbChoiceMaterial.DropDownHeight = 200; // Altura fija en píxeles

      if (success)
      {
        if (id_model_l0 > 0)
        {
          LoadModelosL1(id_model_l0);
        }
      }
    }

    private void BtnCrearL1_Click(object sender, EventArgs e)
    {
      string error = string.Empty;
      string name_model = string.Empty;
      string descripcion_model = string.Empty;
      string temporal_name = string.Empty;
      string temporal_description = string.Empty;
      string apply = string.Empty;
      string mfg = string.Empty;
      string centroTrabajo = string.Empty;
      int id_model_l1 = 0;
      bool is_create = false;
      int id_model_l0 = 0;

      try
      {
        mfg = cmbMfgCell.SelectedValue.ToString();

        if (mfg != "0")
        {
          id_model_l0 = Convert.ToInt32(cmbModeloL0.SelectedValue.ToString());

          if (dgvModeloL1.Rows.Count > 0)
          {
            id_model_l1 = Convert.ToInt32(dgvModeloL1.Rows[dgvModeloL1.CurrentRow.Index].Cells["IdModelo"].Value.ToString());
            temporal_name = dgvModeloL1.Rows[dgvModeloL1.CurrentRow.Index].Cells["NombreModelo"].Value.ToString();
            temporal_description = dgvModeloL1.Rows[dgvModeloL1.CurrentRow.Index].Cells["DescripcionModelo"].Value.ToString();
          }

          if (id_model_l1 == 0 || id_model_l1 == 1)
          {
            if (!string.IsNullOrEmpty(txtNombreL1.Text))
            {
              name_model = txtNombreL1.Text;
              descripcion_model = txtDescripcionL1.Text;
              centroTrabajo = cmbMfgCell.Text;

              if (temporal_name == name_model && temporal_description == descripcion_model)
              {
                apply = "0";

                is_create = configuracion_controller.UpdateModelL1(id_model_l1, name_model.ToUpper(), descripcion_model.ToUpper(), apply, mfg, centroTrabajo, out error);
                error += "Se actualizo de manera correcta, el registro.";
              }
              else
              {
                apply = "0";

                is_create = configuracion_controller.CreateModelL1(id_model_l0, name_model.ToUpper(), descripcion_model.ToUpper(), apply, mfg, centroTrabajo, out error);
                error += "Se dio de alta correctamente el registro.";
              }
            }
            else
            {
              error += "El nombre del modelo es obligatorio.";
            }
          }
          else if (id_model_l1 > 1)
          {
            if (!string.IsNullOrEmpty(txtNombreL1.Text))
            {
              name_model = txtNombreL1.Text;
              descripcion_model = txtDescripcionL1.Text;
              centroTrabajo = cmbMfgCell.Text;

              apply = "0";

              if (temporal_name == name_model && temporal_description == descripcion_model)
              {
                apply = "0";

                is_create = configuracion_controller.UpdateModelL1(id_model_l1, name_model.ToUpper(), descripcion_model.ToUpper(), apply, mfg, centroTrabajo, out error);
                error += "Se actualizo de manera correcta, el registro.";
              }
              else
              {
                apply = "0";

                is_create = configuracion_controller.CreateModelL1(id_model_l0, name_model.ToUpper(), descripcion_model.ToUpper(), apply, mfg, centroTrabajo, out error);
                error += "Se dio de alta correctamente el registro.";
              }
            }
            else
            {
              error += "El nombre del modelo es obligatorio.";
            }
          }
        }
        else
        {
          error += "Eliga un centro de trabajo valido";
        }

        if (is_create)
        {
          MessageBox.Show(error, "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          //ClearTabModels();
          ClearFormModelL1();
          LoadModelosL1(id_model_l0);
        }
        else
        {
          MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnEditarL1_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection rows = dgvModeloL1.SelectedRows;
      string error = string.Empty;
      string name_model = string.Empty;
      string descripcion_model = string.Empty;
      string centroTrabajo = string.Empty;
      int id_model_l1 = 0;

      try
      {
        id_model_l1 = Convert.ToInt32(dgvModeloL1.Rows[dgvModeloL1.CurrentRow.Index].Cells["IdModelo"].Value.ToString());
        name_model = dgvModeloL1.Rows[dgvModeloL1.CurrentRow.Index].Cells["NombreModelo"].Value.ToString();
        descripcion_model = dgvModeloL1.Rows[dgvModeloL1.CurrentRow.Index].Cells["DescripcionModelo"].Value.ToString();
        centroTrabajo = dgvModeloL1.Rows[dgvModeloL1.CurrentRow.Index].Cells["DescripcionExt"].Value.ToString();


        txtNombreL1.Text = name_model;
        txtDescripcionL1.Text = descripcion_model;
        cmbMfgCell.Text = centroTrabajo;
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnEliminarL1_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection rows = dgvModeloL1.SelectedRows;
      string error = string.Empty;
      bool is_create = false;
      int id_model_l1 = 0;
      int id_model_l0 = 0;

      try
      {
        id_model_l1 = Convert.ToInt32(dgvModeloL1.Rows[dgvModeloL1.CurrentRow.Index].Cells["IdModelo"].Value.ToString());

        DialogResult result = MessageBox.Show("¿Seguro que desea eliminar el registro.?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

        if (result == DialogResult.Yes)
        {
          if (id_model_l1 > 0)
          {
            is_create = configuracion_controller.DeleteModelL1(id_model_l1, out error);
          }
        }

        if (error == "" && is_create)
        {
          MessageBox.Show("Se elimino correctamente el registro.", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          //ClearTabModels();
          id_model_l0 = Convert.ToInt32(cmbModeloL0.SelectedValue.ToString());
          LoadModelosL1(id_model_l0);
          ClearFormModelL1();
        }
        else
        {
          MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void ClearTabModels()
    {
      txtNombreL0.Text = "";
      txtDescripcionL0.Text = "";

      dgvModeloL0.Rows.Clear();
      dgvModeloL0.Refresh();
      dgvModeloL0.DataSource = null;

      txtNombreL1.Text = "";
      txtDescripcionL1.Text = "";

      dgvModeloL1.Rows.Clear();
      dgvModeloL1.Refresh();
      dgvModeloL1.DataSource = null;
    }

    public void ClearModelL1()
    {
      dgvModeloL1.Rows.Clear();
      dgvModeloL1.Refresh();
      dgvModeloL1.DataSource = null;

    }

    public void ClearFormModelL1()
    {
      cmbModeloL0.SelectedIndex = 0;
      txtNombreL1.Text = string.Empty;
      txtDescripcionL1.Text = string.Empty;
      cmbMfgCell.SelectedIndex = 0;
    }

    public void LoadMfg()
    {
      List<WorkCenterModel> data_list = new List<WorkCenterModel>();
      string error = string.Empty;

      try
      {
        data_list = configuracion_controller.GetWorkCenters();

        if (data_list.Count > 0)
        {
          var filterData = data_list.OrderBy(x => x.Cntr_Desc)
              .Where(n => n.Cntr_Desc != "Seleccione una opción...")
              .ToList();
          filterData.Insert(0, new WorkCenterModel
          {
            Mfg_Cell = "-1",
            Cntr_Desc = "Seleccione una opción..."
          });

          cmbMfgCell.DataSource = filterData;
          cmbMfgCell.DisplayMember = "Cntr_Desc";
          cmbMfgCell.ValueMember = "Mfg_Cell";
          cmbMfgCell.DropDownStyle = ComboBoxStyle.DropDownList;
          //cmbMfgCell.DropDownWidth = 500;

          cbCentroTrabajo.DataSource = filterData;
          cbCentroTrabajo.DisplayMember = "Cntr_Desc";
          cbCentroTrabajo.ValueMember = "Mfg_Cell";
          cbCentroTrabajo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
      }
    }

    int DropDownWidth(ComboBox myCombo)
    {
      int maxWidth = 0;
      int temp = 0;
      Label label1 = new Label();

      foreach (var obj in myCombo.Items)
      {
        label1.Text = obj.ToString();
        temp = label1.PreferredWidth;
        if (temp > maxWidth)
        {
          maxWidth = temp;
        }
      }
      label1.Dispose();
      return maxWidth;
    }


    private void LoadModelosL0()
    {
      List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
      string error = string.Empty;

      try
      {
        data_list = configuracion_controller.GetListModelL0(out error);

        if (data_list.Count > 0)
        {
          foreach (var item in data_list)
          {
            dgvModeloL0.Rows.Add(item.Id_L0, item.Name_Model, item.Description_Model, item.Description_Large, item.Description_English);
          }
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
      }
    }

    private void LoadModelosL1(int id)
    {
      List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
      List<WorkCenterModel> centrosDeTrabajo = new List<WorkCenterModel>();
      string error = string.Empty;
      string descripcionExt = string.Empty;

      try
      {
        dgvModeloL1.Rows.Clear();
        dgvModeloL1.Refresh();
        dgvModeloL1.DataSource = null;

        data_list = configuracion_controller.GetListModelL1(id, out error);
        centrosDeTrabajo = configuracion_controller.GetWorkCenters();

        if (data_list.Count > 0)
        {
          foreach (var item in data_list)
          {
            try
            {
              //descripcionExt = (from desc in modelos where desc.Mfg_Cell == item.Mfg_Cell select desc).ToList()[0].Cntr_Desc;
              var test = (from desc in centrosDeTrabajo where desc.Mfg_Cell == item.Mfg_Cell select desc).ToList();
            }
            catch (Exception) { }
            dgvModeloL1.Rows.Add(item.Id_L1, item.Name_Model, item.Description_Model, item.Secuence);
          }
        }

        /// Remover el focus del dgv
        if (dgvModeloL1.RowCount > 0 && dgvModeloL1.ColumnCount > 0)
        {
          dgvModeloL1.CurrentCell = this.dgvModeloL1[0, 0];
          this.dgvModeloL1.CurrentCell.Selected = false;
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
      }
    }

    private void FIllModelL0()
    {
      List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
      //data_list = data_list.Clear();
      string error = string.Empty;

      try
      {
        data_list = configuracion_controller.GetListModelL0WithSubNivel(out error);

        if (data_list.Count > 0)
        {

          var filterData = data_list.OrderBy(n => n.Name_Model).Where(n => n.Name_Model != "Seleccione una opción...").ToList();
          filterData.Insert(0, new NM_ModelosLModel
          {
            Id_L0 = -1,
            Name_Model = "Seleccione una opción..."
          });
          cmbModeloL0.DataSource = filterData;
          cmbModeloL0.DisplayMember = "Name_Model";
          cmbModeloL0.ValueMember = "Id_L0";
          cmbModeloL0.DropDownStyle = ComboBoxStyle.DropDownList;

          //private void OrderData()
          //{
          //string error = string.Empty;
          //List<NM_ModelosLModel> data = configuracion_controller.GetListModelL0WithSubNivel(out error);
          //var filterData = data.OrderBy(n => n.Name_Model).Where(n => n.Name_Model != "Seleccione una opción...").ToList();
          //filterData.Insert(0, new NM_ModelosLModel
          //{ Id_L0 = -1, Name_Model = "Seleccione una opción"
          //}); cb_Familias.DataSource = filterData; cb_Familias.DisplayMember = "Name_Model";
          //cb_Familias.ValueMember = "Id_L0";
          //cb_Familias.DropDownStyle = ComboBoxStyle.DropDownList;
          //}

          /// Rellena el combo box de los modelos en el tab de bom x componente
          cmbListModelL0.DataSource = filterData;
          cmbListModelL0.DisplayMember = "Name_Model";
          cmbListModelL0.ValueMember = "Id_L0";
          cmbListModelL0.DropDownStyle = ComboBoxStyle.DropDownList;
          cmbListModelL0.DropDownWidth = 300;
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
      }
    }

    #endregion

    #region TAB PARA CREAR BOM DE PRE ENSAMBLE

    private void CmbListModelL0_SelectedIndexChanged(object sender, EventArgs e)
    {
      string error = string.Empty;
      string code = string.Empty;
      bool success = false;
      int id = 0;

      try
      {
        success = Int32.TryParse(cmbListModelL0.SelectedValue.ToString(), out id);
        ResetTabPreAssembly();

        if (success && id > 0)
        {
          lblSubNivelBomsL1.Visible = true;
          cmbListModelL1.Visible = true;
          FIllListModelL1(id);
          txtPreviewCombination.Text = "";
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private async void CmbListModelL1_SelectedIndexChanged(object sender, EventArgs e)
    {
      List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
      string error = string.Empty;
      string code = string.Empty;
      bool success = false;
      int id = 0;

      try
      {
        success = Int32.TryParse(cmbListModelL1.SelectedValue.ToString(), out id);

        if (success && id > 0)
        {
          data_list = configuracion_controller.GetListModelL2WithSubNivel(id, out error);

          if (data_list.Count > 1)
          {
            //gpbAgregados.Visible = true;
            gpbAcabados.Visible = true;
            btnSearch.Visible = true;
            btnCreatePreAssembly.Visible = true;
            lblPreviewCombination.Visible = true;
            txtPreviewCombination.Visible = true;
            lblFilter.Visible = true;
            txtFilter.Visible = true;
          }
          else
          {
            //gpbAgregados.Visible = true;
            gpbAcabados.Visible = true;
            btnSearch.Visible = true;
            btnCreatePreAssembly.Visible = true;
            lblPreviewCombination.Visible = true;
            txtPreviewCombination.Visible = true;
            lblFilter.Visible = true;
            txtFilter.Visible = true;

            code = cmbListModelL1.Text;
            txtPreviewCombination.Text = code;
            txtPreviewCombination.Focus();
          }
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnBuscarComponetes_Click(object sender, EventArgs e)
    {
      string error = string.Empty;
      string finish_material = string.Empty;
      bool apply_three_finishes = false;

      try
      {
        if (rbnAl.Checked)
        {
          finish_material = "AL";
        }

        if (rbnAn.Checked)
        {
          finish_material = "AN";
        }

        if (finish_material != "")
        {
          FillGridListComponents(finish_material);
          btnCreatePreAssembly.Enabled = true;
        }
        else if (apply_three_finishes)
        {
          FillGridListComponents();
          btnCreatePreAssembly.Enabled = true;
        }
        else
        {
          MessageBox.Show("El campo de acabado es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return;
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error + " " + ex.InnerException, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TxtFilter_TextChanged(object sender, EventArgs e)
    {
      string finish_material = string.Empty;
      string error = string.Empty;
      bool apply_three_finishes = false;

      try
      {
        if (rbnAl.Checked)
        {
          finish_material = "AL";
        }

        if (rbnAn.Checked)
        {
          finish_material = "AN";
        }

        if (!string.IsNullOrEmpty(txtFilter.Text))
        {
          dgvListComponents.CurrentCell = null;

          foreach (DataGridViewRow item in dgvListComponents.Rows)
          {
            item.Visible = false;
          }

          foreach (DataGridViewRow itemRows in dgvListComponents.Rows)
          {
            if ((itemRows.Cells["Itemo"].Value.ToString().ToUpper().IndexOf(txtFilter.Text.ToUpper())) == 0)
            {
              itemRows.Visible = true;
              //break; /// Con el break arroja un solo resultado
            }
          }
        }
        else if (apply_three_finishes)
        {
          FillGridListComponents();
          btnCreatePreAssembly.Enabled = true;
        }
        else
        {
          dgvListComponents.CurrentCell = null;

          foreach (DataGridViewRow item in dgvListComponents.Rows)
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

    private void BtnCrearPreEnsamble_Click(object sender, EventArgs e)
    {
      List<NM_Detalle_Combinaciones_ComponentesModel> data_list = new List<NM_Detalle_Combinaciones_ComponentesModel>();
      NM_Detalle_Combinaciones_ComponentesModel data_model = new NM_Detalle_Combinaciones_ComponentesModel();
      DataGridViewRowCollection rowCollection = dgvListComponents.Rows;
      string error = string.Empty;
      bool is_exist = false;
      bool is_create = false;
      bool success_l0 = false;
      string finishes = string.Empty;
      string combination = string.Empty;
      int id_l0 = 0;
      bool apply_three_finishes = false;
      int qty_material = 0;

      try
      {
        success_l0 = Int32.TryParse(cmbListModelL0.SelectedValue.ToString(), out id_l0);

        if (success_l0)
        {
          if (rbnAn.Checked)
          {
            finishes = "AN";
          }

          if (rbnAl.Checked)
          {
            finishes = "AL";
          }

          if (finishes != "")
          {
            foreach (DataGridViewRow item in rowCollection)
            {
              if (Convert.ToBoolean(item.Cells["Apply"].Value))
              {
                qty_material = Convert.ToInt32(item.Cells["Qty"].Value);

                if (qty_material > 1)
                {
                  for (int i = 0; i < qty_material; i++)
                  {
                    data_model = new NM_Detalle_Combinaciones_ComponentesModel { IdComponentes = Convert.ToInt32(item.Cells["IdComponent"].Value), Itemno = Convert.ToString(item.Cells["Itemo"].Value), Nombre_Componente = Convert.ToString(item.Cells["Description"].Value), Class = Convert.ToString(item.Cells["Class"].Value) };
                    data_list.Add(data_model);
                  }
                }
                else
                {
                  data_model = new NM_Detalle_Combinaciones_ComponentesModel { IdComponentes = Convert.ToInt32(item.Cells["IdComponent"].Value), Itemno = Convert.ToString(item.Cells["Itemo"].Value), Nombre_Componente = Convert.ToString(item.Cells["Description"].Value), Class = Convert.ToString(item.Cells["Class"].Value) };
                  data_list.Add(data_model);
                }
              }
            }

            if (data_list.Count != 0)
            {
              combination = txtPreviewCombination.Text;

              if (combination != "")
              {
                DialogResult result = MessageBox.Show("¿Es correcta la combinación de bom a crear.?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                  is_exist = configuracion_controller.VerifyExistence(combination, finishes, out error);

                  if (!is_exist)
                  {
                    is_create = configuracion_controller.CreateModelComponents(id_l0, combination, finishes, data_list, out error);
                  }
                  else
                  {
                    error += "Esta combinación con el mismo acabado ya existe.";
                  }
                }
              }
              else
              {
                error += "El campo de preview es obligatorio.";
              }
            }
            else
            {
              error += "Debe elegir al menos un componente para crear el modelo pre-ensamblado";
            }
          }
          else if (apply_three_finishes)
          {
            foreach (DataGridViewRow item in rowCollection)
            {
              if (Convert.ToBoolean(item.Cells["Apply"].Value))
              {
                data_model = new NM_Detalle_Combinaciones_ComponentesModel { IdComponentes = Convert.ToInt32(item.Cells["IdComponent"].Value), Itemno = Convert.ToString(item.Cells["Itemo"].Value), Nombre_Componente = Convert.ToString(item.Cells["Description"].Value), Class = Convert.ToString(item.Cells["Class"].Value) };
                data_list.Add(data_model);

                if (Convert.ToInt32(item.Cells["Qty"].Value) > 1)
                {
                  data_model = new NM_Detalle_Combinaciones_ComponentesModel { IdComponentes = Convert.ToInt32(item.Cells["IdComponent"].Value), Itemno = Convert.ToString(item.Cells["Itemo"].Value), Nombre_Componente = Convert.ToString(item.Cells["Description"].Value), Class = Convert.ToString(item.Cells["Class"].Value) };
                  data_list.Add(data_model);
                }
              }
            }

            for (int i = 0; i < data_list.Count; i++)
            {
              if (data_list[i].Itemno.Contains("AL"))
              {

              }
              else if (data_list[i].Itemno.Contains("AN"))
              {

              }
              else if (data_list[i].Itemno.Contains("AC"))
              {

              }
            }
          }
          else
          {
            error += "Debe elegir al un tipo de acabado y/o en su defecto aplicar los tres acabados.";
          }
        }
        else
        {
          error += "EL modelo base no es valido.";
        }

        if (error == "")
        {
          MessageBox.Show("Se ha creado correctamente el modelo pre-ensamblado.", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          lblSubNivelBomsL1.Visible = false;
          cmbListModelL1.Visible = false;
          ResetTabPreAssembly();
        }
        else
        {
          MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public void FillGridListComponents(string finishes)
    {
      List<ArinvtModel> data_list = new List<ArinvtModel>();
      string error = string.Empty;

      data_list = configuracion_controller.GetInfoComponents(finishes, out error);

      if (data_list.Count != 0)
      {
        data_list_arinvt = data_list;

        ClearDataGrid();

        foreach (var item in data_list)
        {
          if (!item.Descrip1.Contains("TRAMO"))
          {
            dgvListComponents.Rows.Add(item.Id, item.Itemno, item.Class, item.Descrip1, 1);
          }
        }
      }
    }

    public void FillGridListComponents()
    {
      List<ArinvtModel> data_list = new List<ArinvtModel>();
      string error = string.Empty;

      data_list = configuracion_controller.GetInfoComponents(out error);

      if (data_list.Count != 0)
      {
        ClearDataGrid();

        foreach (var item in data_list)
        {
          if (!item.Descrip1.Contains("TRAMO"))
          {
            dgvListComponents.Rows.Add(item.Id, item.Itemno, item.Class, item.Descrip1, 1);
          }
        }
      }
    }

    public void ResetTabPreAssembly()
    {
      ClearDataGrid();
      gpbAcabados.Visible = false;
      gpbAgregados.Visible = false;
      btnSearch.Visible = false;
      btnCreatePreAssembly.Visible = false;
      lblPreviewCombination.Visible = false;
      txtPreviewCombination.Text = "";
      txtPreviewCombination.Visible = false;
      lblFilter.Visible = false;
      txtFilter.Text = "";
      txtFilter.Visible = false;
      GetInfoCombosMaterials();
    }

    private void FIllListModelL1(int id)
    {
      List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
      string error = string.Empty;

      try
      {
        data_list = configuracion_controller.GetListModelL1WithSubNivel(id, out error);

        if (data_list.Count > 0)
        {
          var filterData = data_list
              .OrderBy(m => m.Name_Model)
              .Where(m => m.Name_Model != "Seleccione una opción...")
              .ToList();

          filterData.Insert(0, new NM_ModelosLModel
          {
            Id_L1 = -1,
            Name_Model = "Seleccione una opción..."
          });

          cmbListModelL1.DataSource = filterData;
          cmbListModelL1.DisplayMember = "Name_Model";
          cmbListModelL1.ValueMember = "Id_L1";
          cmbListModelL1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
      }
    }

    public void GetInfoCombosMaterials()
    {
      List<NM_MaterialesModel> data_list_materials = new List<NM_MaterialesModel>();
      List<NM_SubMaterialesModel> data_list_submaterials = new List<NM_SubMaterialesModel>();
      List<NM_SubMaterialesModel> data_list_submaterials_01 = new List<NM_SubMaterialesModel>();
      List<NM_SubMaterialesModel> data_list_submaterials_02 = new List<NM_SubMaterialesModel>();
      List<NM_SubMaterialesModel> data_list_submaterials_03 = new List<NM_SubMaterialesModel>();
      List<NM_SubMaterialesModel> data_list_submaterials_04 = new List<NM_SubMaterialesModel>();
      List<NM_SubMaterialesModel> data_list_submaterials_05 = new List<NM_SubMaterialesModel>();
      List<NM_SubMaterialesModel> data_list_submaterials_06 = new List<NM_SubMaterialesModel>();
      string error = string.Empty;

      try
      {
        data_list_materials = configuracion_controller.GetListMaterials();
        data_list_submaterials = configuracion_controller.GetLisSubtMaterials();

        if (data_list_materials.Count > 0 && data_list_submaterials.Count > 0)
        {
          for (int i = 0; i < data_list_materials.Count; i++)
          {
            if (0 == i)
            {
              lblMaterial01.Visible = true;
              lblMaterial01.Text = data_list_materials[i].Nombre_Material;
            }

            if (1 == i)
            {
              lblMaterial02.Visible = true;
              lblMaterial02.Text = data_list_materials[i].Nombre_Material;
            }

            if (2 == i)
            {
              lblMaterial03.Visible = true;
              lblMaterial03.Text = data_list_materials[i].Nombre_Material;
            }

            if (3 == i)
            {
              lblMaterial04.Visible = true;
              lblMaterial04.Text = data_list_materials[i].Nombre_Material;
            }

            if (4 == i)
            {
              lblMaterial05.Visible = true;
              lblMaterial05.Text = data_list_materials[i].Nombre_Material;
            }

            if (5 == i)
            {
              lblMaterial06.Visible = true;
              lblMaterial06.Text = data_list_materials[i].Nombre_Material;
            }
          }

          for (int i = 0; i < data_list_materials.Count; i++)
          {
            for (int j = 0; j < data_list_submaterials.Count; j++)
            {
              if (data_list_materials[i].Id == data_list_submaterials[j].Id_Material_Base)
              {
                NM_SubMaterialesModel data_model = new NM_SubMaterialesModel();

                if (0 == i)
                {
                  if (data_list_submaterials_01.Count == 0)
                  {
                    data_model = new NM_SubMaterialesModel { Id = 0, Nombre_Material = "Seleccione una opción..." };
                    data_list_submaterials_01.Add(data_model);
                  }

                  data_model = new NM_SubMaterialesModel { Id = data_list_submaterials[j].Id, Nombre_Material = data_list_submaterials[j].Nombre_Material };
                  data_list_submaterials_01.Add(data_model);
                }

                if (1 == i)
                {
                  if (data_list_submaterials_02.Count == 0)
                  {
                    data_model = new NM_SubMaterialesModel { Id = 0, Nombre_Material = "Seleccione una opción..." };
                    data_list_submaterials_02.Add(data_model);
                  }

                  data_model = new NM_SubMaterialesModel { Id = data_list_submaterials[j].Id, Nombre_Material = data_list_submaterials[j].Nombre_Material };
                  data_list_submaterials_02.Add(data_model);
                }

                if (2 == i)
                {
                  if (data_list_submaterials_03.Count == 0)
                  {
                    data_model = new NM_SubMaterialesModel { Id = 0, Nombre_Material = "Seleccione una opción..." };
                    data_list_submaterials_03.Add(data_model);
                  }

                  data_model = new NM_SubMaterialesModel { Id = data_list_submaterials[j].Id, Nombre_Material = data_list_submaterials[j].Nombre_Material };
                  data_list_submaterials_03.Add(data_model);
                }

                if (3 == i)
                {
                  if (data_list_submaterials_04.Count == 0)
                  {
                    data_model = new NM_SubMaterialesModel { Id = 0, Nombre_Material = "Seleccione una opción..." };
                    data_list_submaterials_04.Add(data_model);
                  }

                  data_model = new NM_SubMaterialesModel { Id = data_list_submaterials[j].Id, Nombre_Material = data_list_submaterials[j].Nombre_Material };
                  data_list_submaterials_04.Add(data_model);
                }

                if (4 == i)
                {
                  if (data_list_submaterials_05.Count == 0)
                  {
                    data_model = new NM_SubMaterialesModel { Id = 0, Nombre_Material = "Seleccione una opción..." };
                    data_list_submaterials_05.Add(data_model);
                  }

                  data_model = new NM_SubMaterialesModel { Id = data_list_submaterials[j].Id, Nombre_Material = data_list_submaterials[j].Nombre_Material };
                  data_list_submaterials_05.Add(data_model);
                }

                if (5 == i)
                {
                  if (data_list_submaterials_06.Count == 0)
                  {
                    data_model = new NM_SubMaterialesModel { Id = 0, Nombre_Material = "Seleccione una opción..." };
                    data_list_submaterials_06.Add(data_model);
                  }

                  data_model = new NM_SubMaterialesModel { Id = data_list_submaterials[j].Id, Nombre_Material = data_list_submaterials[j].Nombre_Material };
                  data_list_submaterials_06.Add(data_model);
                }
              }
            }
          }

          if (data_list_submaterials_01.Count > 0)
          {
            LoadCombo01(data_list_submaterials_01);
          }

          if (data_list_submaterials_02.Count > 0)
          {
            LoadCombo02(data_list_submaterials_02);
          }

          if (data_list_submaterials_03.Count > 0)
          {
            LoadCombo03(data_list_submaterials_03);
          }

          if (data_list_submaterials_04.Count > 0)
          {
            LoadCombo04(data_list_submaterials_04);
          }

          if (data_list_submaterials_05.Count > 0)
          {
            LoadCombo05(data_list_submaterials_05);
          }

          if (data_list_submaterials_06.Count > 0)
          {
            LoadCombo06(data_list_submaterials_06);
          }
        }
        else
        {
          error = "NO hay materiales registrados.";
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
      }
    }

    private void LoadCombo01(List<NM_SubMaterialesModel> dataList)
    {
      string error = string.Empty;
      try
      {
        if (dataList.Any())
        {
          var dataFilter = dataList
              .OrderBy(SMM => SMM.Nombre_Material)
              .Where(SMM => SMM.Nombre_Material != "Seleccione una opción...")
              .ToList();

          dataFilter.Insert(0, new NM_SubMaterialesModel
          {
            Id = -1,
            Nombre_Material = "Seleccione una opción..."
          });

          cmbMaterial01.DataSource = dataFilter;
          cmbMaterial01.DisplayMember = "Nombre_Material";
          cmbMaterial01.ValueMember = "Id";
          cmbMaterial01.DropDownStyle = ComboBoxStyle.DropDownList;
          cmbMaterial01.Visible = true;
        }

      }
      catch (Exception e)
      {
        error = e.Message;
      }
    }

    private void LoadCombo02(List<NM_SubMaterialesModel> dataList)
    {
      string error = string.Empty;
      try
      {
        if (dataList.Any())
        {
          var dataFilter = dataList
              .OrderBy(SMM => SMM.Nombre_Material)
              .Where(SMM => SMM.Nombre_Material != "Seleccione una opción...")
              .ToList();
          dataFilter.Insert(0, new NM_SubMaterialesModel
          {
            Nombre_Material = "Seleccione una opción...",
            Id = -1
          });

          cmbMaterial02.DataSource = dataFilter;
          cmbMaterial02.DisplayMember = "Nombre_Material";
          cmbMaterial02.ValueMember = "Id";
          cmbMaterial02.DropDownStyle = ComboBoxStyle.DropDownList;
          cmbMaterial02.Visible = true;
        }
      }
      catch (Exception e)
      {
        error = e.Message;
      }
    }

    private void LoadCombo03(List<NM_SubMaterialesModel> dataList)
    {
      string error = string.Empty;

      try
      {
        if (dataList.Any())
        {
          var dataFilter = dataList
              .OrderBy(SMM => SMM.Nombre_Material)
              .Where(SMM => SMM.Nombre_Material != "Seleccione una opción...")
              .ToList();

          dataFilter.Insert(0, new NM_SubMaterialesModel
          {
            Id = -1,
            Nombre_Material = "Seleccione una opción..."
          });

          cmbMaterial03.DataSource = dataFilter;
          cmbMaterial03.DisplayMember = "Nombre_Material";
          cmbMaterial03.ValueMember = "Id";
          cmbMaterial03.DropDownStyle = ComboBoxStyle.DropDownList;
          cmbMaterial03.Visible = true;
        }

      }
      catch (Exception e)
      {
        error = e.Message;
      }
    }

    private void LoadCombo04(List<NM_SubMaterialesModel> dataList)
    {
      string errorMessage = string.Empty;
      try
      {
        if (dataList.Any())
        {
          var dataFilter = dataList
              .OrderBy(SMM => SMM.Nombre_Material)
              .Where(SMM => SMM.Nombre_Material != "Seleccione una opción...")
              .ToList();
          dataFilter.Insert(0, new NM_SubMaterialesModel
          {
            Id = -1,
            Nombre_Material = "Seleccione una opción..."
          });

          cmbMaterial04.DataSource = dataFilter;
          cmbMaterial04.DisplayMember = "Nombre_Material";
          cmbMaterial04.ValueMember = "Id";
          cmbMaterial04.DropDownStyle = ComboBoxStyle.DropDownList;
          cmbMaterial04.Visible = true;
        }
      }
      catch (Exception ex)
      {

      }
    }

    private void LoadCombo05(List<NM_SubMaterialesModel> dataList)
    {
      string errorMessage = string.Empty;
      try
      {
        if (dataList.Any())
        {
          var dataFilter = dataList
              .OrderBy(SMM => SMM.Nombre_Material)
              .Where(SMM => SMM.Nombre_Material != "Seleccione una opción...")
              .ToList();
          dataFilter.Insert(0, new NM_SubMaterialesModel
          {
            Id = -1,
            Nombre_Material = "Seleccione una opción..."
          });

          cmbMaterial05.DataSource = dataFilter;
          cmbMaterial05.DisplayMember = "Nombre_Material";
          cmbMaterial05.ValueMember = "Id";
          cmbMaterial05.DropDownStyle = ComboBoxStyle.DropDownList;
          cmbMaterial05.Visible = true;
        }
      }
      catch (Exception ex)
      {
        errorMessage = ex.Message;
      }
    }

    private void LoadCombo06(List<NM_SubMaterialesModel> dataList)
    {
      string errorMessage = string.Empty;
      try
      {
        if (dataList.Any())
        {
          var dataFilter = dataList
              .OrderBy(NM => NM.Nombre_Material)
              .Where(NM => NM.Nombre_Material != "Seleccione una opción...")
              .ToList();

          dataFilter.Insert(0, new NM_SubMaterialesModel
          {
            Id = -1,
            Nombre_Material = "Seleccione una opción..."
          });

          cmbMaterial06.DataSource = dataFilter;
          cmbMaterial06.DisplayMember = "Nombre_Material";
          cmbMaterial06.ValueMember = "Id";
          cmbMaterial06.DropDownStyle = ComboBoxStyle.DropDownList;
          cmbMaterial06.Visible = true;
        }
      }
      catch (Exception ex)
      {
        errorMessage = ex.Message;
      }
    }

    private void CmbMaterial01_SelectedIndexChanged(object sender, EventArgs e)
    {
      string error = string.Empty;
      string code = string.Empty;
      string combination = string.Empty;
      string temporal_name = string.Empty;
      int id = 0;
      bool success = false;

      try
      {
        success = Int32.TryParse(cmbMaterial01.SelectedValue.ToString(), out id);

        if (success)
        {
          if (id > 0)
          {
            code = cmbMaterial01.Text;

            if (Convert.ToInt32(code) >= 15)
            {
              code = code.Substring(1, 1);
            }

            temporal_name = txtPreviewCombination.Text;
            temporal_name += code;
            txtPreviewCombination.Text = temporal_name;
          }
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void CmbMaterial02_SelectedIndexChanged(object sender, EventArgs e)
    {
      string error = string.Empty;
      string code = string.Empty;
      string temporal_name = string.Empty;
      int id = 0;
      bool success = false;

      try
      {
        success = Int32.TryParse(cmbMaterial02.SelectedValue.ToString(), out id);

        if (success)
        {
          if (id > 0)
          {
            code = cmbMaterial02.Text;
            temporal_name = txtPreviewCombination.Text;
            temporal_name += "-" + code;
            txtPreviewCombination.Text = temporal_name;
          }
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void CmbMaterial03_SelectedIndexChanged(object sender, EventArgs e)
    {
      string error = string.Empty;
      string code = string.Empty;
      string temporal_name = string.Empty;
      int id = 0;
      bool success = false;

      try
      {
        success = Int32.TryParse(cmbMaterial03.SelectedValue.ToString(), out id);

        if (success)
        {
          if (id > 0)
          {
            code = cmbMaterial03.Text;
            temporal_name = txtPreviewCombination.Text;
            temporal_name += "-" + code;
            txtPreviewCombination.Text = temporal_name;
          }
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void CmbMaterial04_SelectedIndexChanged(object sender, EventArgs e)
    {
      string error = string.Empty;
      string code = string.Empty;
      string temporal_name = string.Empty;
      int id = 0;
      bool success = false;

      try
      {
        success = Int32.TryParse(cmbMaterial04.SelectedValue.ToString(), out id);

        if (success)
        {
          if (id > 0)
          {
            code = cmbMaterial04.Text;
            temporal_name = txtPreviewCombination.Text;
            temporal_name += "-" + code;
            txtPreviewCombination.Text = temporal_name;
          }
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void CmbMaterial05_SelectedIndexChanged(object sender, EventArgs e)
    {
      string error = string.Empty;
      string code = string.Empty;
      string temporal_name = string.Empty;
      int id = 0;
      bool success = false;

      try
      {
        success = Int32.TryParse(cmbMaterial05.SelectedValue.ToString(), out id);

        if (success)
        {
          if (id > 0)
          {
            code = cmbMaterial05.Text;
            temporal_name = txtPreviewCombination.Text;
            temporal_name += "-" + code;
            txtPreviewCombination.Text = temporal_name;
          }
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void CmbMaterial06_SelectedIndexChanged(object sender, EventArgs e)
    {
      string error = string.Empty;
      string code = string.Empty;
      string temporal_name = string.Empty;
      int id = 0;
      bool success = false;

      try
      {
        success = Int32.TryParse(cmbMaterial06.SelectedValue.ToString(), out id);

        if (success)
        {
          if (id > 0)
          {
            code = cmbMaterial06.Text;
            temporal_name = txtPreviewCombination.Text;
            temporal_name += "-" + code;
            txtPreviewCombination.Text = temporal_name;
          }
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnEditarCombinacion_Click(object sender, EventArgs e)
    {
      if (Application.OpenForms["frmEditComponentsBom"] != null)
      {
        Application.OpenForms["frmEditComponentsBom"].Activate();
      }
      else
      {
        frmEditComponentsBom form = new frmEditComponentsBom();
        form.Show();
      }
    }

    #endregion

    #region TAB CATALOGO DE FORMULAS

    private void Btn_Eliminar_Click(object sender, EventArgs e)
    {
      //List<Elemento> elementos = new List<Elemento>();
      //Elemento ele1 = new Elemento() { Elemento_ = "cantidad", Value = "1" };
      //Elemento ele2 = new Elemento() { Elemento_ = "largo", Value = "23" };
      //Elemento ele3 = new Elemento() { Elemento_ = "ancho", Value = "23" };
      //elementos.Add(ele1);
      //elementos.Add(ele2);
      //elementos.Add(ele3);

      //string expresion = "RESULT(M1175 + M1178)*2";

      //expresion = con.MasterEvaluator(expresion, elementos);


      DataGridViewSelectedRowCollection rows = dgv_Formulas.SelectedRows;
      string error = string.Empty;

      if (dgv_Formulas.SelectedRows.Count > 0)
      {
        try
        {
          string id = dgv_Formulas.Rows[dgv_Formulas.CurrentRow.Index].Cells["IdFormula"].Value.ToString();

          sql.DeleteFormula(id);
          dgv_Formulas.Rows.Clear();
          LoadDGVFormulas();
        }
        catch (Exception ex)
        {
          error = ex.Message;
        }
      }
    }

    private void LoadDGVFormulas()
    {
      List<NM_Formula> formulas = sql.GetGeneralFormulas("SELECT * FROM NM_Formulas");
      formulas = formulas.OrderBy(x => x.NombreFormula).ToList();

      foreach (NM_Formula formula in formulas)
      {
        dgv_Formulas.Rows.Add(formula.Id, formula.NombreFormula, formula.Tipo, formula.Formula, formula.FechaCreacion);
        dgv_Formulas_Condicional.Rows.Add(formula.Id, formula.NombreFormula, formula.Tipo, formula.Formula, formula.FechaCreacion);
      }
    }

    private void LoadTipoFormula()
    {
      List<string> formulas = new List<string> { "md", "qty", "total", "peso" };

      formulas.Sort();
      formulas.Insert(0, "Seleccione una opción...");

      cb_TipoFormula.DataSource = formulas;
    }

    private void Btn_ValidarFormula_Click(object sender, EventArgs e)
    {
      string formula = txt_Formula.Text;
      bool result = eval.FormulaValidator(formula);
      List<string> variables = eval.GetVariables(formula);
      List<Elemento> elementos = GetRandomElementos();
      string expresion = string.Empty;
      bool parentesis = eval.ValidateParentesis(formula);

      if (parentesis)
      {
        //if (result)
        //{
        if (cb_TipoFormula.Text != "" && txt_NombreFormula.Text != "")
        {
          if (cb_TipoFormula.Text != "Seleccione una opcion...")
          {
            NM_Formula formulaObj = new NM_Formula() { NombreFormula = txt_NombreFormula.Text.ToUpper(), Tipo = cb_TipoFormula.Text.ToLower(), Formula = txt_Formula.Text };

            sql.InsertFormula(formulaObj);
            dgv_Formulas.Rows.Clear();
            LoadDGVFormulas();
            ClearFields();
          }
          else
          {
            MessageBox.Show("Elija una opción valida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
        else
        {
          MessageBox.Show("Valida que todos los campos esten completos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //}
        //else
        //{
        //    MessageBox.Show("Error en la formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
      }
      else
      {
        MessageBox.Show("Valida la cantidad de parentesis");
      }
    }

    private void Btn_Editar_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection rows = dgv_Formulas.SelectedRows;

      if (dgv_Formulas.SelectedRows.Count > 0)
      {
        string test = dgv_Formulas.Rows[dgv_Formulas.CurrentRow.Index].Cells["IdFormula"].Value.ToString();
        cb_TipoFormula.Text = dgv_Formulas.Rows[dgv_Formulas.CurrentRow.Index].Cells["TipoFormula"].Value.ToString();
        txt_NombreFormula.Text = dgv_Formulas.Rows[dgv_Formulas.CurrentRow.Index].Cells["NombreFormula"].Value.ToString();
        txt_Formula.Text = dgv_Formulas.Rows[dgv_Formulas.CurrentRow.Index].Cells["Formula"].Value.ToString();
      }
      else
      {
        MessageBox.Show("No hay filas seleccionadas");
      }
    }

    private void Btn_Guardar_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection rows = dgv_Formulas.SelectedRows;

      if (dgv_Formulas.SelectedRows.Count > 0)
      {
        try
        {
          NM_Formula formula = new NM_Formula();
          NM_Formula oldFormula = new NM_Formula();

          formula.NombreFormula = txt_NombreFormula.Text;
          formula.Tipo = cb_TipoFormula.Text;
          formula.Formula = txt_Formula.Text;

          oldFormula.Tipo = dgv_Formulas.Rows[dgv_Formulas.CurrentRow.Index].Cells["TipoFormula"].Value.ToString().ToLower();
          oldFormula.NombreFormula = dgv_Formulas.Rows[dgv_Formulas.CurrentRow.Index].Cells["NombreFormula"].Value.ToString().ToUpper();
          oldFormula.Formula = dgv_Formulas.Rows[dgv_Formulas.CurrentRow.Index].Cells["Formula"].Value.ToString();

          //if (eval.FormulaValidator(formula.Formula))
          //{
          sql.UpdateFormula(formula, oldFormula);
          dgv_Formulas.Rows.Clear();
          LoadDGVFormulas();
          ClearFields();
          //}
          //else
          //{
          //    MessageBox.Show("Valida que la formula este correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          //}
        }
        catch (Exception ex)
        {
          string error = ex.Message;
        }
      }
    }

    private List<Elemento> GetRandomElementos()
    {
      List<Elemento> elementos = new List<Elemento>();
      List<string> parametros = new List<string>() {"largo","ancho","cantidad","horizontal","vertical",
                                                          "ranuras","diametro","pies"};
      Elemento elemento;
      Random ran = new Random();

      foreach (string parametro in parametros)
      {
        elemento = new Elemento();
        elemento.Elemento_ = parametro;
        elemento.Value = ran.Next(0, 100).ToString();
        elementos.Add(elemento);
      }

      return elementos;
    }

    #endregion

    #region TAB CONDICIONAL

    private void LoadCbTipoCondicional()
    {
      List<string> conditionalType = new List<string> { "Medida", "Cantidad", "Total" };

      conditionalType.Sort();
      conditionalType.Insert(0, "Seleccione una opción...");

      cb_TipoCondicional.DataSource = conditionalType;
    }

    private bool ValidForm()
    {
      string tipo = string.Empty;
      tipo = cb_TipoCondicional.Text;
      bool state = false;

      if (!string.IsNullOrWhiteSpace(tb_NombreCondicional.Text))
      {
        if (!string.IsNullOrWhiteSpace(tb_Condicional.Text))
        {
          if (!string.IsNullOrWhiteSpace(tb_Verdadero.Text))
          {
            if (!string.IsNullOrWhiteSpace(tb_Falso.Text))
            {
              state = true;
            }
            else
            {
              MessageBox.Show("El campo de valor Falso no debe estar vacio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
          else
          {
            MessageBox.Show("El campo de valor verdadero no debe estar vacio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
        else
        {
          MessageBox.Show("El campo de condicional no debe estar vacio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      else
      {
        MessageBox.Show("El campo de nombre de condicional no debe estar vacio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      if (tipo == "Seleccione una opcion...")
      {
        state = false;
        MessageBox.Show("El campo de tipo de condicional debe ser una opcion valida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      return state;
    }

    public void LoadDGVCondicionales()
    {
      List<NM_Condicional> validaciones = sql.GetCondicionales();
      validaciones = validaciones.OrderBy(x => x.Id).ToList();

      dgv_Condicionales.Rows.Clear();
      foreach (NM_Condicional validacion in validaciones)
      {
        dgv_Condicionales.Rows.Add(Convert.ToInt32(validacion.Id), validacion.NombreCondicional, validacion.Condicional,
                                                   validacion.Verdadero, validacion.Falso, validacion.Tipo);
      }
    }

    public void CleanFormCondicional()
    {
      tb_NombreCondicional.Text = string.Empty;
      tb_Condicional.Text = string.Empty;
      tb_Verdadero.Text = string.Empty;
      tb_Falso.Text = string.Empty;
    }

    public void AddConditional(bool area)
    {
      DataGridViewSelectedRowCollection rows = dgv_Condicionales.SelectedRows;
      string tipo = string.Empty;
      string id = string.Empty;
      string valor = string.Empty;

      if (rows.Count > 0)
      {
        //IF TABS
        if (tabCondicionales.SelectedTab.Name == "tbp_Condicionales")
        {
          id = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Id_Condicional"].Value.ToString();
          tipo = "Condicional";
          valor = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Condicional_Condicionales"].Value.ToString();
        }
        else
        {
          id = dgv_Formulas_Condicional.Rows[dgv_Formulas_Condicional.CurrentRow.Index].Cells["Id"].Value.ToString();
          tipo = "Formula";
          valor = dgv_Formulas_Condicional.Rows[dgv_Formulas_Condicional.CurrentRow.Index].Cells["Condicionales_Formula"].Value.ToString();
        }

      }
      else
      {
        MessageBox.Show("No se ha seleccionado ninguna condicional o formula", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

    }

    private void Pb_Agregar_Click(object sender, EventArgs e)
    {
      TreeNode node = tv_Condicional.SelectedNode;
      DataGridViewSelectedRowCollection rows = dgv_Formulas_Condicional.SelectedRows;
      DataGridViewSelectedRowCollection condicionalRows = dgv_Condicionales.SelectedRows;
      NM_Condicional condicional = new NM_Condicional();
      NM_Formula formula = new NM_Formula();
      string id = string.Empty;
      string tipo = string.Empty;
      string valor = string.Empty;

      if (node != null)
      {
        if (node.Text == "Verdadero" || node.Text == "Falso")
        {
          if (rows.Count > 0 || condicionalRows.Count > 0)
          {
            //IF TABS
            if (tabCondicionales.SelectedTab.Name == "tbp_Condicionales")
            {
              id = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Id_Condicional"].Value.ToString();
              if (id != idMaster)
              {
                condicional.Id = Convert.ToInt32(id);
                condicional.Condicional = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Condicional_Condicionales"].Value.ToString();
                condicional.Verdadero = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Verdadero_Condicionales"].Value.ToString();
                condicional.Falso = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Falso_Condicionales"].Value.ToString();
                if (!ExistNodo(id))
                {
                  AddNodoCondicional(node, condicional);
                }
              }
              else
              {
                MessageBox.Show("La condicional no puede ser la misma que la condicional raiz", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
            }
            else if (tabCondicionales.SelectedTab.Name == "tbpFormulas")
            {
              formula.Id = Convert.ToInt32(dgv_Formulas_Condicional.Rows[dgv_Formulas_Condicional.CurrentRow.Index].Cells["Condicional_Id_Formula"].Value.ToString());
              formula.Tipo = "Formula";
              formula.Formula = dgv_Formulas_Condicional.Rows[dgv_Formulas_Condicional.CurrentRow.Index].Cells["Condicional_Formula"].Value.ToString();
              if (!ExistNodo(formula.Id.ToString()))
              {
                AddNodoFormula(node, formula);
              }
            }
            else
            {
              MessageBox.Show("No se puede agregar una condicional master a un nodo");
            }

            node.ExpandAll();
          }
        }
        else
        {
          MessageBox.Show("No se puede agregar un nodo en esta posicion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      else
      {
        if (condicionalRows.Count > 0)
        {
          condicional.Id = Convert.ToInt32(dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Id_Condicional"].Value);
          condicional.Condicional = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Condicional_Condicionales"].Value.ToString();
          condicional.Verdadero = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Verdadero_Condicionales"].Value.ToString();
          condicional.Falso = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Falso_Condicionales"].Value.ToString();
          AddRoot(condicional);
        }
        else
        {
          MessageBox.Show("No hay ninguna condicional seleccionada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
    }

    private void Pb_AgregarCondicional_Click(object sender, EventArgs e)
    {
      ExprParser ep = new ExprParser();
      LambdaExpression lambda;
      bool result;
      string condicionalTxt = string.Empty;

      if (ValidForm())
      {
        try
        {
          condicionalTxt = tb_Condicional.Text;
          lambda = ep.Parse(condicionalTxt);
          result = (bool)ep.Run(lambda);

          if (tv_Condicional.Nodes.Count == 0)
          {
            NM_Condicional condicional = new NM_Condicional();
            condicional.Condicional = tb_Condicional.Text;
            condicional.Verdadero = tb_Verdadero.Text;
            condicional.Falso = tb_Falso.Text;
            AddRoot(condicional);
          }
          else
          {
            TreeNode node = tv_Condicional.SelectedNode;

            if (node != null)
            {
              node.Nodes.Remove(node.Nodes[0]);

              node.Nodes.Add("Condicional");
              TreeNode condicional = node.Nodes[0];
              condicional.ForeColor = Color.Blue;
              condicional.Nodes.Add("Verdadero");
              condicional.Nodes.Add("Falso");

              TreeNode verdadero = condicional.Nodes[0];
              verdadero.ForeColor = Color.Green;
              TreeNode falso = condicional.Nodes[1];
              falso.ForeColor = Color.Red;

              verdadero.Nodes.Add(tb_Verdadero.Text);
              falso.Nodes.Add(tb_Falso.Text);

              node.ExpandAll();
              CleanFormCondicional();
            }
          }
        }
        catch (ExprException ex)
        {
          MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
    }

    public string FindNodoPadre(string fullPath)
    {
      string[] split = fullPath.Split('\\');
      return split[split.Count() - 3];
    }

    public void AddRoot(NM_Condicional condicional)
    {
      tv_Condicional.Nodes.Add("Raiz", "Raiz - " + condicional.Condicional);
      TreeNode raiz = tv_Condicional.Nodes[0];
      NM_CondicionalMaster master = new NM_CondicionalMaster();
      raiz.Tag = condicional.Id;
      raiz.ForeColor = Color.Blue;
      raiz.Name = "Raiz";
      raiz.Nodes.Add("Verdadero", "Verdadero");
      raiz.Nodes.Add("Falso", "Falso");
      idMaster = condicional.Id.ToString();

      TreeNode verdadero = raiz.Nodes[0];
      verdadero.ForeColor = Color.Green;
      TreeNode falso = raiz.Nodes[1];
      falso.ForeColor = Color.Red;

      verdadero.Nodes.Add(condicional.Verdadero);
      falso.Nodes.Add(condicional.Falso);

      TreeNode valorVerdadero = verdadero.Nodes[0];
      TreeNode valorFalso = falso.Nodes[0];

      this.idCondicionalMaster = condicional.Id.ToString();
      master.IdElemento = Convert.ToInt32(condicional.Id);
      if (!string.IsNullOrEmpty(idMaster))
        master.IdCondicionalMaster = Convert.ToInt32(idMaster);
      else
        master.IdCondicionalMaster = Convert.ToInt32(this.idCondicionalMaster);
      master.Nivel = raiz.Level;
      master.Tipo = "Raiz";
      master.Posicion = "NA";
      master.NodoPadre = "RAIZ";
      nodos.Add(master);

      raiz.ExpandAll();
      CleanFormCondicional();
    }

    public void LoadDGVCondicionalesMaster()
    {
      List<NM_CondicionalMaster> masters = sql.GetMasterCondicional();
      masters = masters.OrderBy(x => x.IdCondicionalMaster).ToList();
      dgv_CondicionalesMaster.Rows.Clear();

      foreach (NM_CondicionalMaster master in masters)
      {
        dgv_CondicionalesMaster.Rows.Add(master.IdCondicionalMaster, master.Nombre, master.IdCompuesto);
      }
    }

    public void AddNodoCondicional(TreeNode node, NM_Condicional condicional)
    {
      NM_CondicionalMaster master = new NM_CondicionalMaster();
      if (node.Nodes.Count > 0)
      {
        node.Nodes.Remove(node.Nodes[0]);
      }
      node.Nodes.Add("Condicional - " + condicional.Condicional);
      TreeNode nodoCondicional = node.Nodes[0];
      nodoCondicional.Tag = condicional.Id + "|Condicional";
      nodoCondicional.Name = condicional.Id + "|Condicional";
      TreeNode verdadero = new TreeNode();
      TreeNode falso = new TreeNode();
      nodoCondicional.ForeColor = Color.Blue;
      nodoCondicional.Nodes.Add("Verdadero");
      nodoCondicional.Nodes.Add("Falso");

      verdadero = nodoCondicional.Nodes[0];
      falso = nodoCondicional.Nodes[1];

      verdadero.ForeColor = Color.Green;
      falso.ForeColor = Color.Red;

      verdadero.Nodes.Add(condicional.Verdadero);
      falso.Nodes.Add(condicional.Falso);

      if (!string.IsNullOrEmpty(idMaster))
        master.IdCondicionalMaster = Convert.ToInt32(idMaster);
      else
        master.IdCondicionalMaster = Convert.ToInt32(this.idCondicionalMaster);
      master.IdElemento = Convert.ToInt32(condicional.Id);
      master.Nivel = nodoCondicional.Level;
      master.Tipo = "Condicional";
      master.Posicion = nodoCondicional.Parent.Text;
      master.Path = nodoCondicional.FullPath;
      master.NodoPadre = FindNodoPadre(nodoCondicional.FullPath);
      nodos.Add(master);
    }

    public void AddNodoFormula(TreeNode node, NM_Formula formula)
    {
      NM_CondicionalMaster master = new NM_CondicionalMaster();
      if (node.Nodes.Count > 0)
      {
        node.Nodes.Remove(node.Nodes[0]);
      }
      node.Nodes.Add("Formula");
      TreeNode Nodotipo = node.Nodes[0];

      Nodotipo.Tag = formula.Id + "|Formula";
      Nodotipo.Name = formula.Id + "|Formula";
      Nodotipo.ForeColor = Color.Blue;
      Nodotipo.Nodes.Add(formula.Formula);
      TreeNode valorFormula = Nodotipo.Nodes[0];
      if (!string.IsNullOrEmpty(idMaster))
        master.IdCondicionalMaster = Convert.ToInt32(idMaster);
      else
        master.IdCondicionalMaster = Convert.ToInt32(this.idCondicionalMaster);
      master.IdElemento = Convert.ToInt32(formula.Id);
      master.Nivel = Nodotipo.Level;
      master.Posicion = Nodotipo.Parent.Text;
      master.Tipo = "Formula";
      master.Path = Nodotipo.FullPath;
      master.NodoPadre = FindNodoPadre(Nodotipo.FullPath);
      nodos.Add(master);
    }

    private void Pb_AgregarCondicionalForm_Click(object sender, EventArgs e)
    {
      string condicional = string.Empty;


      if (ValidForm())
      {
        condicional = tb_Condicional.Text;
        condicional = eval.ReplaceDecimalToFraction(condicional);
        //if (con.ValidateConditional(condicional))
        //{
        if (!sql.ExistConditionalName(tb_NombreCondicional.Text))
        {
          if (!sql.ExistConditional(tb_Condicional.Text))
          {
            NM_Condicional validacion = new NM_Condicional();
            validacion.NombreCondicional = tb_NombreCondicional.Text;
            validacion.Condicional = tb_Condicional.Text;
            validacion.Tipo = cb_TipoCondicional.Text;
            validacion.Verdadero = tb_Verdadero.Text;
            validacion.Falso = tb_Falso.Text;
            sql.InsertCondicional(validacion);
            dgv_Condicionales.Rows.Clear();
            LoadDGVCondicionales();
            CleanFormCondicional();
          }
          else
          {
            MessageBox.Show("La condicional ya fue dada de alta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
        else
        {
          MessageBox.Show("El nombre de la condicional ya fue dada de alta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      //}
    }

    private void Pb_Guardar_Click(object sender, EventArgs e)
    {
      int nodesCount = tv_Condicional.GetNodeCount(true);

      if (nodesCount > 5)
      {
        TreeNode raiz = tv_Condicional.Nodes[0];
        if (raiz != null)
        {
          if (!string.IsNullOrEmpty(tb_MasterCondicional.Text))
          {
            if (!sql.ExistMasterConditionalName(tb_MasterCondicional.Text))
            {
              string idCom = con.makeIdComposed(nodos);
              string nombreMaster = tb_MasterCondicional.Text;

              if (!sql.ExistIdCompuesto(idCom))
              {
                foreach (NM_CondicionalMaster nodo in nodos)
                {
                  //nodo.IdCondicionalMaster = idMaster;
                  sql.InsertCondicionalMaster(nodo, idCom, nombreMaster, nodo.Tipo);
                }
                tv_Condicional.Nodes[0].Remove();
                nodos.Clear();
                tb_MasterCondicional.Text = string.Empty;
                MessageBox.Show("Guardado correctamente!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
              else
              {
                MessageBox.Show("La estructura de esta condicional ya se ha dado de alta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              }
            }
            else
            {
              MessageBox.Show("El nombre de la condicional ya existe", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          }
          else
          {
            MessageBox.Show("El nombre de la condicional master no debe estar vacio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }
        }
        else
        {
          MessageBox.Show("No hay ningun arbol de condicionales", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      else
      {
        MessageBox.Show("Esta opcion no esta habilitada para condicionales simples");
      }
    }

    private void Pb_Eliminar_Click(object sender, EventArgs e)
    {
      TreeNode node = tv_Condicional.SelectedNode;

      if (node != null)
      {
        if (node.Tag != null)
        {
          node.Remove();
        }
        else
        {
          MessageBox.Show("Solo se pueden eliminar nodos de formula o condicional, no valores implicitos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
      else
      {
        MessageBox.Show("No se ha seleccionado ningun nodo para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    public bool ExistNodo(string idNodo)
    {
      foreach (NM_CondicionalMaster nodo in nodos)
      {
        if (string.Equals(nodo.IdElemento, idNodo))
        {
          return true;
        }
      }

      return false;
    }

    public void ClearFormCondicional()
    {
      tb_NombreCondicional.Text = string.Empty;
      tb_Condicional.Text = string.Empty;
      tb_Verdadero.Text = string.Empty;
      tb_Falso.Text = string.Empty;
      cb_TipoCondicional.SelectedIndex = 0;
    }

    public void RecorrerArbol(TreeView tree)
    {
      TreeNodeCollection nodes = tree.Nodes;
      nodos.Clear();

      foreach (TreeNode node in nodes)
      {
        CallRecursive(node);
      }
    }

    public void CallRecursive(TreeNode node)
    {
      string condicional = string.Empty;
      string formula = string.Empty;
      NM_CondicionalMaster master = new NM_CondicionalMaster();

      if (node.Text.Contains("Raiz"))
      {
        master.Tipo = "Raiz";
        master.Posicion = "NA";
        master.NodoPadre = "RAIZ";
        master.IdCondicionalMaster = Convert.ToInt32(this.idCondicionalMaster);
        master.Nivel = node.Level;
        master.IdCompuesto = this.idCompuestoCondicionalMaster;
        condicional = node.Text.Replace("Raiz - ", "");
        master.IdElemento = Convert.ToInt32(sql.GetIdCondicional(condicional));
        nodos.Add(master);
      }
      if (node.Text.Contains("Condicional") || node.Text.Contains("Formula"))
      {
        if (node.Text.Contains("Condicional"))
        {
          condicional = node.Text.Replace("Condicional - ", "");
          master.IdElemento = Convert.ToInt32(sql.GetIdCondicional(condicional));
          master.Tipo = "Condicional";
        }
        if (node.Text.Contains("Formula"))
        {
          formula = node.Nodes[0].Text;
          master.IdElemento = Convert.ToInt32(sql.GetIdFormula(formula));
          master.Tipo = "Formula";
        }

        master.Posicion = node.Parent.Text;
        master.NodoPadre = FindNodoPadre(node.FullPath);
        master.IdCondicionalMaster = Convert.ToInt32(this.idCondicionalMaster);
        master.Nivel = node.Level;
        master.IdCompuesto = this.idCompuestoCondicionalMaster;

        nodos.Add(master);
      }

      foreach (TreeNode _node in node.Nodes)
      {
        CallRecursive(_node);
      }
    }

    #endregion

    #region TAB CLONADO

    public void FillCBFamilia()
    {
      string error = string.Empty;
      List<NM_ModelosLModel> data = configuracion_controller.GetListModelL0WithSubNivel(out error);
      try
      {
        if (data.Any())
        {
          var dataFilter = data
              .OrderBy(NM => NM.Name_Model)
              .Where(NM => NM.Name_Model != "Seleccione una opción...")
              .ToList();

          dataFilter.Insert(0, new NM_ModelosLModel
          {
            Id_L0 = -1,
            Name_Model = "Seleccione una opción..."
          });

          cb_Familias.DataSource = dataFilter;
          cb_Familias.DisplayMember = "Name_Model";
          cb_Familias.ValueMember = "Id_L0";
          cb_Familias.DropDownStyle = ComboBoxStyle.DropDownList;
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
      }

    }

    public void FillCBFamiliaDestino()
    {
      string error = string.Empty;
      List<NM_ModelosLModel> data = configuracion_controller.GetListModelL0WithSubNivel(out error);

      cbFamilias.DataSource = data;
      cbFamilias.DisplayMember = "Name_Model";
      cbFamilias.ValueMember = "Id_L0";
      cbFamilias.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    private void FillCBModelos(int id)
    {
      List<NM_CombinacionesModel> data_list = new List<NM_CombinacionesModel>();
      string error = string.Empty;

      try
      {
        data_list = generatorController.GetListModelAssembly(id, "AL", out error);//configuracion_controller.GetListModelL1WithSubNivel(id, out error);

        if (data_list.Count > 0)
        {
          var dataFilter = data_list
              .OrderBy(NMC => NMC.Combinacion)
              .Where(NMC => NMC.Combinacion != "Seleccione una opción...")
              .ToList();

          dataFilter.Insert(0, new NM_CombinacionesModel
          {
            Id = -1,
            Combinacion = "Seleccione una opción..."
          });

          cb_Modelos.DataSource = dataFilter;
          cb_Modelos.DisplayMember = "Combinacion";
          cb_Modelos.ValueMember = "Id";
          cb_Modelos.DropDownStyle = ComboBoxStyle.DropDownList;
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
      }
    }

    private void cb_Familias_SelectedIndexChanged(object sender, EventArgs e)
    {
      int id = 0;
      bool result = Int32.TryParse(cb_Familias.SelectedValue.ToString(), out id);

      if (result && id > 0)
      {
        FillCBModelos(id);
      }
    }

    private void cb_Modelos_SelectedIndexChanged(object sender, EventArgs e)
    {
      string error = string.Empty;

      List<string> secciones = new List<string>();
      string modelo = cb_Modelos.Text;
      try
      {
        if (cb_Modelos.SelectedIndex > 0)
        {
          secciones = sql.GetSectionFromModel(modelo);
          secciones.Sort();
          var seccionesFilter = secciones
              .Where(s => !(
              s.Equals(null) ||
              s.Equals(string.Empty) ||
              s.Equals("NULL")
              )).ToList();
          seccionesFilter.Insert(0, "");
          cb_Secciones.DataSource = seccionesFilter;
          cb_Secciones.DropDownStyle = ComboBoxStyle.DropDownList;
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
      }
    }

    private void btnBuscarComponentes_Click(object sender, EventArgs e)
    {
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> componentes = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      string modelo = string.Empty;
      string seccion = string.Empty;

      if (cb_Modelos.SelectedIndex > 0)
      {
        dgvOrigenClon.Rows.Clear();
        modelo = cb_Modelos.Text;

        if (cb_Secciones.SelectedIndex > 0)
        {
          seccion = cb_Secciones.Text;
          componentes = sql.GetComponentsFromClon(modelo, seccion);
        }
        else
        {
          componentes = sql.GetComponentsFromClon(modelo);
        }

        FillDGVClonOrigen(componentes);
      }
    }

    public void FillDGVClonOrigen(List<NM_Detalle_Combinacion_Componentes_FormulasModel> componentes)
    {
      if (componentes.Count > 0)
      {
        foreach (var componente in componentes)
        {
          dgvOrigenClon.Rows.Add(false, componente.IdCombinacion, componente.IdDetalleComponente, componente.Itemno, componente.IdComponente,
                                 componente.IdFormulaQty, componente.IdFormulaMd, componente.IdFormulaTotal, componente.IdFormulaPeso,
                                 componente.IdCondicionalQty, componente.IdCondicionalMd, componente.TypeConditionalMd,
                                 componente.TypeConditionalQty, componente.IdCompuestoQty, componente.IdCompuestoMd,
                                 componente.Descripcion, componente.Seccion, componente.Linea);
        }
      }
    }

    private void btn_SeleccionarTodo_Click(object sender, EventArgs e)
    {
      if (dgvOrigenClon.Rows.Count > 0)
      {
        for (int i = 0; i < dgvOrigenClon.Rows.Count; i++)
        {
          dgvOrigenClon.Rows[i].Cells["Seleccion"].Value = true;
        }
      }
    }

    private void btnTransferirRegistro_Click(object sender, EventArgs e)
    {
      if (dgvOrigenClon.Rows.Count > 0)
      {
        for (int i = 0; i < dgvOrigenClon.Rows.Count; i++)
        {
          if (Convert.ToBoolean(dgvOrigenClon.Rows[i].Cells["Seleccion"].Value) == true)
          {
            dgvClonDestino.Rows.Add("Editar",
                dgvOrigenClon.Rows[i].Cells["IdCombinacion_Origen"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["IdDetalleComp_clon"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Itemno"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_IdComponente"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_FormulaQty"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_FormulaMd"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_FormulaTotal"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_FormulaPeso"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_CondicionalQty"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_CondicionalMd"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_TypeCondicionalMd"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_TypeCondicionalQty"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_CompuestoQty"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_CompuestoMd"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_Descripcion"].Value.ToString(),
                dgvOrigenClon.Rows[i].Cells["Origen_Seccion"].Value.ToString(),
                Convert.ToInt16(dgvOrigenClon.Rows[i].Cells["Origen_Linea"].Value.ToString()));
          }
        }

        for (int i = 0; i < dgvOrigenClon.Rows.Count; i++)
        {
          if (Convert.ToBoolean(dgvOrigenClon.Rows[i].Cells["Seleccion"].Value) == true)
          {
            dgvOrigenClon.Rows[i].Cells["Seleccion"].Value = false;
          }
        }
      }
      else
      {
        MessageBox.Show("No hay ningun componente seleccionado");
      }
    }
    private void btnGuardarComponente_Click(object sender, EventArgs e)
    {
      dgvClonDestino.Rows[indexRowClonDest].Cells["Destino_Descripcion"].Value = tb_Descripcion.Text;
      dgvClonDestino.Rows[indexRowClonDest].Cells["Destino_Linea"].Value = tb_DestinoLinea.Text;
      tb_Descripcion.Text = string.Empty;
      tb_DestinoLinea.Text = string.Empty;
    }

    private void dgvClonDestino_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (dgvClonDestino.Columns[e.ColumnIndex].Name.Equals("Destino_Editar"))
      {
        tb_Descripcion.Text = dgvClonDestino.Rows[e.RowIndex].Cells["Destino_Descripcion"].Value.ToString();
        tb_DestinoLinea.Text = dgvClonDestino.Rows[e.RowIndex].Cells["Destino_Linea"].Value.ToString();
        indexRowClonDest = e.RowIndex;
      }
    }

    private void btnEliminarComponente_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection rows = dgvClonDestino.SelectedRows;
      DataGridViewRow _row;

      if (rows.Count > 0)
      {
        foreach (var row in rows)
        {
          _row = row as DataGridViewRow;
          dgvClonDestino.Rows.Remove(_row);
        }
      }
      else
      {
        MessageBox.Show("No hay ninguna fila seleccionada");
      }
    }

    private void btn_NuevoModelo_Click(object sender, EventArgs e)
    {
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> componentesFormulas = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> componentesFormulasAL = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> componentesFormulasAN = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      List<NM_Detalle_Combinaciones_ComponentesModel> componentes = new List<NM_Detalle_Combinaciones_ComponentesModel>();
      List<NM_Detalle_Combinaciones_ComponentesModel> componentesAL = new List<NM_Detalle_Combinaciones_ComponentesModel>();
      List<NM_Detalle_Combinaciones_ComponentesModel> componentesAN = new List<NM_Detalle_Combinaciones_ComponentesModel>();
      string idModeloBomAL = string.Empty;
      string idModeloBomAN = string.Empty;
      string error = string.Empty;
      int idFamilia = 0;
      bool existModelOnCombinaciones = false;
      bool modelFormulasCompleteAL = false;
      bool modelFormulasCompleteAN = false;


      if (!cbFamilias.Text.Equals("Seleccione una opción..."))
      {
        idFamilia = Convert.ToInt32(cbFamilias.SelectedValue.ToString());

        if (dgvClonDestino.Rows.Count > 0)
        {
          componentesFormulas = GetComponentsFromDestino();

          if (!string.IsNullOrEmpty(txtNuevoModelo.Text))
          {
            existModelOnCombinaciones = sql.ExistModelOnCombinaciones(txtNuevoModelo.Text.ToUpper());

            if (!existModelOnCombinaciones)
            {
              componentes = FormulasToComponentes(ref componentesFormulas, cbCentroTrabajo.SelectedValue.ToString());
              componentesAL = TransformComponents(componentes, "AL");

              configuracion_controller.CreateModelComponents(idFamilia, txtNuevoModelo.Text.ToUpper(), "AL", componentesAL, out error);
              idModeloBomAL = sql.GetIdCombinacion(txtNuevoModelo.Text.ToUpper(), "AL");

              componentesAL = sql.GetDetalleComponente(idModeloBomAL);

              componentesFormulasAL = TransformarComponentesFormulas(componentesFormulas, idModeloBomAL, "AL", componentesAL);

              modelFormulasCompleteAL = configuracion_controller.CreateModelComplete(componentesFormulasAL, out error);


              if (checkBox_AN.Checked)
              {
                componentesAN = TransformComponents(componentes, "AN");

                configuracion_controller.CreateModelComponents(idFamilia, txtNuevoModelo.Text.ToUpper(), "AN", componentesAN, out error);
                idModeloBomAN = sql.GetIdCombinacion(txtNuevoModelo.Text.ToUpper(), "AN");

                componentesAN = sql.GetDetalleComponente(idModeloBomAN);

                componentesFormulasAN = TransformarComponentesFormulas(componentesFormulas, idModeloBomAN, "AN", componentesAN);

                modelFormulasCompleteAN = configuracion_controller.CreateModelComplete(componentesFormulasAN, out error);
              }

              if (modelFormulasCompleteAL)
              {
                MessageBox.Show("Clonado completado!");
                dgvClonDestino.Rows.Clear();
                dgvOrigenClon.Rows.Clear();

                cb_Secciones.DataSource = null;
                cb_Secciones.Items.Clear();

                cb_Modelos.DataSource = null;
                cb_Modelos.Items.Clear();

                cb_Familias.SelectedIndex = 0;
                cbFamilias.SelectedIndex = 0;
                cbCentroTrabajo.SelectedIndex = 0;

                txtNuevoModelo.Text = string.Empty;

                checkBox_AN.Checked = false;

              }
              else
              {
                MessageBox.Show(string.Format("Hubo un error al intentar clonar el BOM: \n {0}", error));
              }
            }
            else
            {
              MessageBox.Show("El nombre del nuevo modelo de BOM ya ha sido dado de alta");
            }
          }
          else
          {
            MessageBox.Show("El nombre del modelo no puede estar vacio");
          }
        }
        else
        {
          MessageBox.Show("No se han agregado componentes al BOM destino");
        }
      }
      else
      {
        MessageBox.Show("Seleccione una familia valida para el BOM a crear");
      }
    }

    public List<NM_Detalle_Combinacion_Componentes_FormulasModel> TransformarComponentesFormulas(List<NM_Detalle_Combinacion_Componentes_FormulasModel> componentesFormulas
                                                                , string idCombinacion, string acabado, List<NM_Detalle_Combinaciones_ComponentesModel> componentes)
    {
      NM_Detalle_Combinaciones_ComponentesModel componenteMod = new NM_Detalle_Combinaciones_ComponentesModel();
      List<NM_Detalle_Combinaciones_ComponentesModel> componenteAux = new List<NM_Detalle_Combinaciones_ComponentesModel>();
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> newComponenteForm = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      NM_Detalle_Combinacion_Componentes_FormulasModel componenteFormula;
      string itemno = string.Empty;


      foreach (var componente in componentesFormulas)
      {
        componenteFormula = new NM_Detalle_Combinacion_Componentes_FormulasModel();

        if (componente.Itemno.Contains("PEXAL") || componente.Itemno.Contains("PEXAN"))
        {
          if (componente.Itemno.Contains("PEXAL") && acabado.Equals("AN"))
          {
            itemno = componente.Itemno;
            itemno = itemno.Replace("PEXAL", "PEXAN");
          }
          else if (componente.Itemno.Contains("PEXAN") && acabado.Equals("AL"))
          {
            itemno = componente.Itemno;
            itemno = itemno.Replace("PEXAN", "PEXAL");
          }
          else
          {
            itemno = componente.Itemno;
          }

          //componenteMod = sql.GetCombinacionComponente(itemno);
          componenteFormula = (NM_Detalle_Combinacion_Componentes_FormulasModel)componente.Clone();
          //componenteFormula.IdComponente = Convert.ToInt32(componenteMod.IdComponentes);
          componenteFormula.IdCombinacion = Convert.ToInt32(idCombinacion);
          componenteFormula.Itemno = itemno;
          componenteAux = (from detalle in componentes where detalle.Itemno == itemno && detalle.isUsed == false select detalle).ToList();
          if (componenteAux.Count > 0)
          {
            componenteFormula.IdDetalleComponente = componenteAux[0].Id;
            UpdateIsUsedComponent(ref componentes, componenteAux[0].Id);
          }
          newComponenteForm.Add(componenteFormula);
        }
        else
        {
          itemno = componente.Itemno;
          componenteFormula = (NM_Detalle_Combinacion_Componentes_FormulasModel)componente.Clone();
          componenteFormula.IdCombinacion = Convert.ToInt32(idCombinacion);
          componenteFormula.Itemno = itemno;
          componenteAux = (from detalle in componentes where detalle.Itemno == componente.Itemno && detalle.isUsed == false select detalle).ToList();
          if (componenteAux.Count > 0)
          {
            componenteFormula.IdDetalleComponente = componenteAux[0].Id;
            UpdateIsUsedComponent(ref componentes, componenteAux[0].Id);
          }
          newComponenteForm.Add(componenteFormula);
        }
      }

      return newComponenteForm;
    }

    public void UpdateIsUsedComponent(ref List<NM_Detalle_Combinaciones_ComponentesModel> componentes, int idDetalleComponente)
    {
      foreach (var componente in componentes)
      {
        if (componente.Id == Convert.ToInt32(idDetalleComponente))
        {
          componente.isUsed = true;
          return;
        }
      }
    }

    public List<NM_Detalle_Combinaciones_ComponentesModel> TransformComponents(List<NM_Detalle_Combinaciones_ComponentesModel> componentes, string acabado)
    {
      List<NM_Detalle_Combinaciones_ComponentesModel> finishComponents = new List<NM_Detalle_Combinaciones_ComponentesModel>();
      NM_Detalle_Combinaciones_ComponentesModel componenteAux;
      //NM_ComponentesModel componenteMod;
      Arinvt art;
      string itemno = string.Empty;

      foreach (var componente in componentes)
      {
        if (componente.Itemno.Contains("PEXAL") || componente.Itemno.Contains("PEXAN"))
        {
          itemno = componente.Itemno;

          if (componente.Itemno.Contains("PEXAL") && acabado.Equals("AN"))
            itemno = itemno.Replace("PEXAL", "PEXAN");
          else if (componente.Itemno.Contains("PEXAN") && acabado.Equals("AL"))
            itemno = itemno.Replace("PEXAN", "PEXAL");

          //componenteMod = new NM_ComponentesModel();
          art = new Arinvt();
          art = conexion.GetArinvt(itemno);
          componenteAux = new NM_Detalle_Combinaciones_ComponentesModel();
          //componenteMod = sql.GetComponente(itemno);
          //componenteAux.Id_Arinvt = componenteMod.Id_Arinvt;
          componenteAux.Id_Arinvt = componente.Id_Arinvt;
          componenteAux.Itemno = itemno;
          componenteAux.Nombre_Componente = art.descripcion;
          componenteAux.Class = art.clase;
          if (!string.IsNullOrEmpty(componente.Id_Arinvt))
            componenteAux.IdComponentes = Convert.ToInt64(componente.Id_Arinvt);
          else
            componenteAux.IdComponentes = 0;
          componenteAux.Acabado = acabado;
          finishComponents.Add(componenteAux);
        }
        else
        {
          //componenteMod = new NM_ComponentesModel();
          //componenteMod = sql.GetComponente(componente.Itemno);
          art = new Arinvt();
          art = conexion.GetArinvt(componente.Itemno);
          componente.Acabado = acabado;
          componente.Class = art.clase;
          componente.Nombre_Componente = art.descripcion;
          if (!string.IsNullOrEmpty(componente.Id_Arinvt))
            componente.IdComponentes = Convert.ToInt64(componente.Id_Arinvt);
          else
            componente.IdComponentes = 0;
          componente.Id_Arinvt = componente.Id_Arinvt;
          finishComponents.Add(componente);
        }
      }

      return finishComponents;
    }

    public List<NM_Detalle_Combinacion_Componentes_FormulasModel> GetComponentsFromDestino()
    {
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> componentes = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      NM_Detalle_Combinacion_Componentes_FormulasModel componente;

      for (int i = 0; i < dgvClonDestino.Rows.Count; i++)
      {
        componente = new NM_Detalle_Combinacion_Componentes_FormulasModel();
        componente.Itemno = Convert.ToString(dgvClonDestino.Rows[i].Cells["Destino_Itemno"].Value);
        componente.IdComponente = Convert.ToInt32(dgvClonDestino.Rows[i].Cells["Destino_IdComponente"].Value);
        componente.IdDetalleComponente = Convert.ToInt32(dgvClonDestino.Rows[i].Cells["Destino_IdDetalleComp"].Value);
        componente.IdFormulaQty = Convert.ToInt32(dgvClonDestino.Rows[i].Cells["Destino_FormulaQty"].Value);
        componente.IdFormulaMd = Convert.ToInt32(dgvClonDestino.Rows[i].Cells["Destino_FormulaMd"].Value);
        componente.IdFormulaTotal = Convert.ToInt32(dgvClonDestino.Rows[i].Cells["Destino_FormulaTotal"].Value);
        componente.IdFormulaPeso = Convert.ToInt32(dgvClonDestino.Rows[i].Cells["Destino_FormulaPeso"].Value);
        componente.IdCondicionalQty = Convert.ToInt32(dgvClonDestino.Rows[i].Cells["Destino_CondicionalQty"].Value);
        componente.IdCondicionalMd = Convert.ToInt32(dgvClonDestino.Rows[i].Cells["Destino_CondicionalMd"].Value);
        componente.TypeConditionalMd = Convert.ToString(dgvClonDestino.Rows[i].Cells["Destino_TypeCondicionalMd"].Value);
        componente.TypeConditionalQty = Convert.ToString(dgvClonDestino.Rows[i].Cells["Destino_TypeCondicionalQty"].Value);
        componente.IdCompuestoQty = Convert.ToString(dgvClonDestino.Rows[i].Cells["Destino_IdCompuestoQty"].Value);
        componente.IdCompuestoMd = Convert.ToString(dgvClonDestino.Rows[i].Cells["Destino_IdCompuestoMd"].Value);
        componente.Descripcion = Convert.ToString(dgvClonDestino.Rows[i].Cells["Destino_Descripcion"].Value);
        componente.Seccion = Convert.ToString(dgvClonDestino.Rows[i].Cells["Destino_Seccion"].Value);
        componente.Linea = Convert.ToInt32(dgvClonDestino.Rows[i].Cells["Destino_Linea"].Value);
        componentes.Add(componente);
      }

      return componentes;
    }

    public List<NM_Detalle_Combinaciones_ComponentesModel> FormulasToComponentes(ref List<NM_Detalle_Combinacion_Componentes_FormulasModel> componentesFormulas,
                                                                                 string clase)
    {
      List<NM_Detalle_Combinaciones_ComponentesModel> componentes = new List<NM_Detalle_Combinaciones_ComponentesModel>();
      NM_Detalle_Combinaciones_ComponentesModel componente;

      foreach (var compForm in componentesFormulas)
      {
        //NM_ComponentesModel comp = sql.GetComponente(compForm.Itemno);
        componente = new NM_Detalle_Combinaciones_ComponentesModel();
        componente.Id_Arinvt = compForm.IdComponente.ToString();
        componente.Itemno = compForm.Itemno;
        componente.Nombre_Componente = compForm.NombreComponente;
        componente.Class = clase;
        componentes.Add(componente);
      }

      return componentes;
    }

    #endregion

    #region CODIGO PARA ASOCIAR BOM PRE ENSAMBLADO Y FORMULAS POR COMPONENTES

    private void BtnBuscarCombinacionesComponentes_Click(object sender, EventArgs e)
    {
      string error = string.Empty;
      string finish_material = string.Empty;
      bool success = false;
      int id = 0;

      try
      {
        success = Int32.TryParse(cmbListadoModelos.SelectedValue.ToString(), out id);

        if (rbnAlAsociar.Checked)
        {
          finish_material = "AL";
          btn_Clonar.Visible = false;
        }

        if (rbnAnAsociar.Checked)
        {
          finish_material = "AN";
          btnAsociar.Enabled = true;
        }

        if (finish_material != "")
        {
          LoadCombinacions(finish_material, id);
        }
        else
        {
          MessageBox.Show("El campo de acabdo es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return;
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void CmbCombinacionesBoms_SelectedIndexChanged(object sender, EventArgs e)
    {
      SearchModel();
    }

    public void SearchModel()
    {
      List<NM_Detalle_Combinaciones_ComponentesModel> data_list = new List<NM_Detalle_Combinaciones_ComponentesModel>();
      string error = string.Empty;
      string code = string.Empty;
      int id = 0;
      bool success = false;
      string finish_material = string.Empty;

      try
      {
        success = Int32.TryParse(cmbCombinacionesBoms.SelectedValue.ToString(), out id);

        if (success && id > 0)
        {
          code = cmbCombinacionesBoms.Text;

          if (code != "")
          {
            if (rbnAlAsociar.Checked)
            {
              finish_material = "AL";
            }

            if (rbnAnAsociar.Checked)
            {
              finish_material = "AN";
              btn_Clonar.Visible = true;
            }

            if (finish_material != "")
            {
              data_list = configuracion_controller.GetListCombinacionComponente(code, finish_material);
              //data_list = data_list.OrderBy(x => x.Itemno).ToList();
              //data_list.OrderBy(x => x.);
              data_list = data_list.OrderBy(x => x.Linea).ToList();

              if (data_list.Count != 0)
              {
                FillGridBomCombinations(data_list, out error);
              }
            }
            else
            {
              error += "El campo de acabado es obligatorio.";
            }

            if (error != "")
            {
              MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          }
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    //private void BtnAsociar_Click(object sender, EventArgs e)
    //{
    //    DataGridViewRowCollection rowCollection = dgvCombinacionesFormulas.Rows;
    //    List<NM_Detalle_Combinacion_Componentes_FormulasModel> data_list = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
    //    NM_Detalle_Combinacion_Componentes_FormulasModel data_model = new NM_Detalle_Combinacion_Componentes_FormulasModel();
    //    string error = string.Empty;
    //    string model = string.Empty;
    //    int id_combination = 0;
    //    int id_components = 0;
    //    int id_formula_qty = 0;
    //    int id_formula_md = 0;
    //    int id_formula_total = 0;
    //    int id_conditional_qty = 0;
    //    int id_conditional_md = 0;
    //    int id_formula_peso = 0;
    //    int id_detalleComp = 0;
    //    string type_conditional_qty = string.Empty;
    //    string type_conditional_md = string.Empty;
    //    string id_compuesto_qty = string.Empty;
    //    string id_compuesto_md = string.Empty;
    //    string name_master_qty = string.Empty;
    //    string name_master_md = string.Empty;
    //    string itemno = string.Empty;

    //    try
    //    {
    //        id_combination = Convert.ToInt32(cmbCombinacionesBoms.SelectedValue.ToString());
    //        model = cmbCombinacionesBoms.Text;

    //        foreach (DataGridViewRow item in rowCollection)
    //        {
    //            id_compuesto_qty = "";
    //            id_compuesto_md = "";
    //            id_detalleComp = Convert.ToInt32(item.Cells["IdDetalleComp"].Value);
    //            id_components = Convert.ToInt32(item.Cells[2].Value); 
    //            id_conditional_qty = Convert.ToInt32(item.Cells["ConditionalQty"].Value);
    //            id_conditional_md = Convert.ToInt32(item.Cells["ConditionalMd"].Value);
    //            id_formula_qty = Convert.ToInt32(item.Cells["FormulaQty"].Value);
    //            id_formula_md = Convert.ToInt32(item.Cells["FormulaMd"].Value);
    //            id_formula_total = Convert.ToInt32(item.Cells["FormulaTotal"].Value);
    //            id_formula_peso = Convert.ToInt32(item.Cells["FormulaPeso"].Value);
    //            itemno = Convert.ToString(item.Cells["ItemnoComponent"].Value);

    //            if (id_conditional_qty == 0 && id_conditional_md == 0 && id_formula_qty == 0 && id_formula_md == 0 && id_formula_total == 0)
    //            {
    //                error += "Seleccione una opción valida por lo menos para formulas de cantidad, medidas y/o totales." + Environment.NewLine;
    //                //break;
    //            }
    //            else if (id_conditional_qty == 0 && id_formula_qty == 0)
    //            {
    //                error += "No se puede aplicar al mismo tiempo una condicional y formula para el mismo componente." + Environment.NewLine;
    //                //break;
    //            }
    //            else if (id_conditional_md == 0 && id_formula_md == 0)
    //            {
    //                error += "No se puede aplicar al mismo tiempo una condicional y formula para el mismo componente." + Environment.NewLine;
    //                //break;
    //            }
    //            else if (id_formula_total == 0)
    //            {
    //                id_formula_total = id_formula_peso;

    //                if (id_formula_total == 0)
    //                {
    //                    error += "Debe seleccionar una formula para total (obligatorio)." + Environment.NewLine;
    //                    //break;
    //                }
    //            }

    //            if (id_conditional_qty > 0)
    //            {
    //                name_master_qty = Convert.ToString(item.Cells["ConditionalQty"].FormattedValue);
    //                id_compuesto_qty = configuracion_controller.GetIdCompuesto(id_conditional_qty.ToString());

    //                if (id_compuesto_qty != "")
    //                {
    //                    type_conditional_qty = "M";
    //                }
    //                else
    //                {
    //                    type_conditional_qty = "C";
    //                }
    //            }
    //            else
    //            {
    //                type_conditional_qty = "";
    //            }

    //            if (id_conditional_md > 0)
    //            {
    //                name_master_md = Convert.ToString(item.Cells["ConditionalMd"].FormattedValue);
    //                id_compuesto_md = configuracion_controller.GetIdCompuesto(id_conditional_md.ToString());

    //                if (id_compuesto_md != "")
    //                {
    //                    type_conditional_md = "M";
    //                }
    //                else
    //                {
    //                    type_conditional_md = "C";
    //                }
    //            }
    //            else
    //            {
    //                type_conditional_md = "";
    //            }

    //            data_model = new NM_Detalle_Combinacion_Componentes_FormulasModel
    //            {
    //                IdCombinacion = id_combination,
    //                IdComponente = id_components,
    //                IdFormulaQty = id_formula_qty,
    //                IdFormulaMd = id_formula_md,
    //                IdFormulaTotal = id_formula_total,
    //                IdCondicionalMd = id_conditional_md,
    //                IdCondicionalQty = id_conditional_qty,
    //                TypeConditionalQty = type_conditional_qty,
    //                TypeConditionalMd = type_conditional_md,
    //                IdCompuestoMd = id_compuesto_md,
    //                IdCompuestoQty = id_compuesto_qty,
    //                NombreMasterMd = name_master_md,
    //                NombreMasterQty = name_master_qty,
    //                IdDetalleComponente = id_detalleComp,
    //                Itemno = itemno
    //            };

    //            data_list.Add(data_model);
    //        }

    //        if (data_list.Count > 0)
    //        {
    //            configuracion_controller.CreateModelComplete(data_list, out error);
    //        }
    //        else
    //        {
    //            error += "No se puideron asociar los componentes con las formulas." + Environment.NewLine;
    //        }

    //        if (error == "")
    //        {
    //            MessageBox.Show("Se acaba de generar el modelo completo de BOM " + model + ", con sus respetectivos componentes y formulas para cantidades y medidas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //            ResetTabAsociar();
    //            ClearDataGrid();
    //        }
    //        else
    //        {
    //            MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        error = ex.Message;
    //        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //}

    //private void DgvCombinacionesFormulas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    //{
    //    int id = 0;
    //    string formula = string.Empty;
    //    string error = string.Empty;

    //    try
    //    {
    //        if (dgvCombinacionesFormulas.Columns[e.ColumnIndex].Name == "ConditionalQty")
    //        {
    //            id = Convert.ToInt32(this.dgvCombinacionesFormulas[e.ColumnIndex, e.RowIndex].Value.ToString());

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
    //                trvShowConditional.Nodes[0].Remove();
    //                trvShowConditional.ResetText();
    //                trvShowConditional.Nodes.Clear();
    //            }
    //        }

    //        if (dgvCombinacionesFormulas.Columns[e.ColumnIndex].Name == "ConditionalMd")
    //        {
    //            id = Convert.ToInt32(this.dgvCombinacionesFormulas[e.ColumnIndex, e.RowIndex].Value.ToString());

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
    //                trvShowConditional.Nodes[0].Remove();
    //                trvShowConditional.ResetText();
    //                trvShowConditional.Nodes.Clear();
    //            }
    //        }

    //        if (dgvCombinacionesFormulas.Columns[e.ColumnIndex].Name == "ConditionalTotal")
    //        {
    //            id = Convert.ToInt32(this.dgvCombinacionesFormulas[e.ColumnIndex, e.RowIndex].Value.ToString());

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
    //                trvShowConditional.Nodes[0].Remove();
    //                trvShowConditional.ResetText();
    //                trvShowConditional.Nodes.Clear();
    //            }
    //        }

    //        if (dgvCombinacionesFormulas.Columns[e.ColumnIndex].Name == "FormulaQty")
    //        {
    //            id = Convert.ToInt32(this.dgvCombinacionesFormulas[e.ColumnIndex, e.RowIndex].Value.ToString());

    //            if (id > 0)
    //            {
    //                formula = configuracion_controller.GetFormula(id, out error);

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

    //        if (dgvCombinacionesFormulas.Columns[e.ColumnIndex].Name == "FormulaMd")
    //        {
    //            id = Convert.ToInt32(this.dgvCombinacionesFormulas[e.ColumnIndex, e.RowIndex].Value.ToString());

    //            if (id > 0)
    //            {
    //                formula = configuracion_controller.GetFormula(id, out error);

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

    //        if (dgvCombinacionesFormulas.Columns[e.ColumnIndex].Name == "FormulaTotal")
    //        {
    //            id = Convert.ToInt32(this.dgvCombinacionesFormulas[e.ColumnIndex, e.RowIndex].Value.ToString());

    //            if (id > 0)
    //            {
    //                formula = configuracion_controller.GetFormula(id, out error);

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

    //        if (dgvCombinacionesFormulas.Columns[e.ColumnIndex].Name == "FormulaPeso")
    //        {
    //            id = Convert.ToInt32(this.dgvCombinacionesFormulas[e.ColumnIndex, e.RowIndex].Value.ToString());

    //            if (id > 0)
    //            {
    //                formula = configuracion_controller.GetFormula(id, out error);

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

    private void BtnEditarFormulas_Click(object sender, EventArgs e)
    {
      if (Application.OpenForms["frmEditFormulaBom"] != null)
      {
        Application.OpenForms["frmEditFormulaBom"].Activate();
      }
      else
      {
        frmEditFormulaBom form = new frmEditFormulaBom();
        form.Show();
      }
    }

    public void LoadCombinacions(string finish, int idL0)
    {
      List<NM_CombinacionesModel> data_list = new List<NM_CombinacionesModel>();
      data_list = configuracion_controller.GetListCombinacions(finish, idL0);
      cmbCombinacionesBoms.DataSource = data_list;
      cmbCombinacionesBoms.DisplayMember = "Combinacion";
      cmbCombinacionesBoms.ValueMember = "Id";
      cmbCombinacionesBoms.DropDownStyle = ComboBoxStyle.DropDownList;
    }

    public void FillGridBomCombinations(List<NM_Detalle_Combinaciones_ComponentesModel> dataListModel, out string errorMethod)
    {
      string error = string.Empty;
      string finish_material = string.Empty;

      ClearDataGrid();

      foreach (var item in dataListModel)
      {
        dgvCombinacionesFormulas.Rows.Add(item.Linea, item.Id, item.IdCombinacion, item.IdComponentes, "Editar", item.Itemno, item.Nombre_Componente);
      }
      if (rbnAlAsociar.Checked)
      {
        finish_material = "AL";
      }

      if (rbnAnAsociar.Checked)
      {
        finish_material = "AN";
        btn_Clonar.Visible = true;
      }
      FillGridResult(cmbCombinacionesBoms.Text, finish_material, out error);
      //FillFormulasGrid(out error);
      errorMethod = error;
    }

    private void FillGridResult(string combination, string typeMaterial, out string errorMethod)
    {
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> dataList = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      string error = string.Empty;

      try
      {
        dataList = configuracion_controller.GetListComponentsFormulas(combination, typeMaterial, out error);
        dataList = dataList.OrderBy(x => x.Linea).ToList();

        if (dataList != null)
        {

          if (dataList.Count > 0)
          {
            ClearDataGrid();

            foreach (var item in dataList)
            {
              dgvCombinacionesFormulas.Rows.Add(item.Linea, item.IdDetalleForComp, item.IdCombinacion, item.IdComponente, "Editar", item.Itemno,
                                                item.NombreComponente, item.NombreCondicionalQty, item.NombreCondicionalMd,
                                                item.NombreFormulaQty, item.NombreFormulaMd, item.NombreFormulaTotal, item.NombreFormulaPeso,
                                                item.Seccion, item.Descripcion);
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
    private void LoadModels()
    {
      string error = string.Empty;
      try
      {
        List<NM_ModelosLModel> data_list = new List<NM_ModelosLModel>();
        data_list = generatorController.GetListModel(out error);

        if (data_list.Count != 0)
        {
          var data_listFilter = data_list
              .OrderBy(NMM => NMM.Name_Model)
              .Where(NMM => NMM.Name_Model != "Seleccione una opción...")
              .ToList();

          data_listFilter.Insert(0, new NM_ModelosLModel
          {
            Id_L1 = -1,
            Name_Model = "Seleccione una opción..."
          });

          cmbListadoModelos.DataSource = data_listFilter;
          cmbListadoModelos.DisplayMember = "Name_Model";
          cmbListadoModelos.ValueMember = "Id_L1";
          cmbListadoModelos.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        else
        {
          error = "No hay datos que mostrar, para el listado de modelos.";
        }

      }
      catch
      {

      }
    }

    public void FillFormulasGrid(out string errorMethod)
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
        data_list = formulador_controller.GetListFormulas(out error);
        data_list_conditionals = configuracion_controller.GetListConditionals(out error);

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

          if (data_list_qty.Count != 0)
          {
            foreach (DataGridViewRow row in dgvCombinacionesFormulas.Rows)
            {
              DataGridViewComboBoxCell viewRowQty = row.Cells["FormulaQty"] as DataGridViewComboBoxCell;
              viewRowQty.DataSource = data_list_qty;
              viewRowQty.ValueMember = "Id";
              viewRowQty.DisplayMember = "NombreFormula";
            }
          }

          if (data_list_md.Count != 0)
          {
            foreach (DataGridViewRow row in dgvCombinacionesFormulas.Rows)
            {
              DataGridViewComboBoxCell viewRowMd = row.Cells["FormulaMd"] as DataGridViewComboBoxCell;
              viewRowMd.DataSource = data_list_md;
              viewRowMd.ValueMember = "Id";
              viewRowMd.DisplayMember = "NombreFormula";
            }
          }

          if (data_list_total.Count != 0)
          {
            foreach (DataGridViewRow row in dgvCombinacionesFormulas.Rows)
            {
              DataGridViewComboBoxCell viewRowTotal = row.Cells["FormulaTotal"] as DataGridViewComboBoxCell;
              viewRowTotal.DataSource = data_list_total;
              viewRowTotal.ValueMember = "Id";
              viewRowTotal.DisplayMember = "NombreFormula";
            }
          }

          if (data_list_total_peso.Count != 0)
          {
            foreach (DataGridViewRow row in dgvCombinacionesFormulas.Rows)
            {
              DataGridViewComboBoxCell viewRowTotalPeso = row.Cells["FormulaPeso"] as DataGridViewComboBoxCell;
              viewRowTotalPeso.DataSource = data_list_total_peso;
              viewRowTotalPeso.ValueMember = "Id";
              viewRowTotalPeso.DisplayMember = "NombreFormula";
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

          foreach (DataGridViewRow row in dgvCombinacionesFormulas.Rows)
          {
            DataGridViewComboBoxCell viewRowConditionalQty = row.Cells["ConditionalQty"] as DataGridViewComboBoxCell;
            viewRowConditionalQty.DataSource = data_list_conditionals_temps_qty;
            viewRowConditionalQty.ValueMember = "IdCondicionalMaster";
            viewRowConditionalQty.DisplayMember = "Nombre";
          }

          foreach (DataGridViewRow row in dgvCombinacionesFormulas.Rows)
          {
            DataGridViewComboBoxCell viewRowConditionalMd = row.Cells["ConditionalMd"] as DataGridViewComboBoxCell;
            viewRowConditionalMd.DataSource = data_list_conditionals_temps_md;
            viewRowConditionalMd.ValueMember = "IdCondicionalMaster";
            viewRowConditionalMd.DisplayMember = "Nombre";
          }
        }
      }
      catch (Exception ex)
      {
        error = ex.Message;
      }

      errorMethod = error;
    }

    public void ResetTabAsociar()
    {
      rbnAlAsociar.Checked = false;
      rbnAnAsociar.Checked = false;

      txtShowFormulas.Text = "";
      dgvCombinacionesFormulas.Rows.Clear();
      dgvCombinacionesFormulas.Refresh();
      dgvCombinacionesFormulas.DataSource = null;
    }

    public void CreateTreeConditionals(int id)
    {
      List<ConditionalsModel> data_list = new List<ConditionalsModel>();
      TreeNode treeNode = new TreeNode();
      string error = string.Empty;

      try
      {
        data_list = configuracion_controller.GetListConditionals(id, out error);

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
          conditionalsModel = configuracion_controller.GetConditionals(dataList[i].Id, out error);

          if (error == "" && conditionalsModel != null)
          {
            TreeNode treeNodeParent = new TreeNode(conditionalsModel.Nombre + " ---> " + conditionalsModel.Condicional);
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
            conditionalsModel = configuracion_controller.GetConditionals(item.IdElemento, out error);

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

    #endregion

    private void btn_Clonar_Click(object sender, EventArgs e)
    {
      string modelo = cmbCombinacionesBoms.Text;
      string idsModeloOriginal = sql.GetIdCombinacion(modelo, "AL");
      string idsModeloClon = sql.GetIdCombinacion(modelo, "AN");

      List<NM_Detalle_Combinacion_Componentes_FormulasModel> original = sql.GetComponentesFormulas(idsModeloOriginal);
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> clon = sql.GetComponentesFormulas(idsModeloClon);
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> final = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();

      if (string.IsNullOrEmpty(this.idCombinacion))
      {
        this.idCombinacion = sql.GetIdCombinacion(modelo, "AN");
      }


      bool exist = sql.ExistPreAssy(idCombinacion);

      if (exist)
      {
        final = MakeUpdateListFormulas(original, clon);

        if (final.Count == original.Count)
        {
          sql.UpdateComponentesFormulas(final);
          sql.UpdateCombinacionCompletada(idsModeloClon);
          dgvCombinacionesFormulas.Rows.Clear();
          MessageBox.Show("Clonado exitoso!");
        }
      }
      else
      {
        CreateModelFormulas();
        clon = sql.GetComponentesFormulas(idsModeloClon);
        final = MakeUpdateListFormulas(original, clon);
        sql.UpdateComponentesFormulas(final);
        sql.UpdateCombinacionCompletada(idsModeloClon);
        dgvCombinacionesFormulas.Rows.Clear();
        MessageBox.Show("Clonado exitoso!");
      }
    }

    public List<NM_Detalle_Combinacion_Componentes_FormulasModel> MakeUpdateListFormulas(List<NM_Detalle_Combinacion_Componentes_FormulasModel> original, List<NM_Detalle_Combinacion_Componentes_FormulasModel> clon)
    {
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> auxClon = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> formulasNueva = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      NM_Detalle_Combinacion_Componentes_FormulasModel backup;

      foreach (var org in original)
      {
        backup = new NM_Detalle_Combinacion_Componentes_FormulasModel();

        if (org.Itemno.Contains("PEXAL"))
        {
          org.Itemno = org.Itemno.Replace("PEXAL", "PEXAN");
        }

        auxClon = (from formula in clon where formula.Itemno == org.Itemno && formula.IsUsed != true select formula).ToList();

        if (auxClon.Count > 0)
        {
          backup = org;
          backup.IdDetalleComponente = auxClon[0].IdDetalleComponente;
          backup.IdCombinacion = auxClon[0].IdCombinacion;

          foreach (var cln in clon)
          {
            if (string.Equals(cln.IdDetalleComponente, backup.IdDetalleComponente))
            {
              cln.IsUsed = true;
              formulasNueva.Add(backup);
              break;
            }
          }
        }
      }

      return formulasNueva;
    }

    public void FillFormulasComboboxByIndex(DataGridViewRow row)
    {
      List<NM_CondicionalMaster> master = sql.GetMasterCondicional();
      List<NM_Condicional> condicionales = sql.GetCondicionales();
      List<NM_Formula> formulas = sql.GetGeneralFormulas("SELECT * from NM_Formulas");
      List<string> duo = JoinListConditional(master, condicionales);
      formulas.Insert(0, new NM_Formula { Id = 0, NombreFormula = "", Tipo = "", Formula = "", FechaCreacion = "" });

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
    private void dgvCombinacionesFormulas_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.dgvCombinacionesFormulas.Columns[e.ColumnIndex].Name.Equals("Editar"))
      {
        List<NM_CondicionalMaster> master = sql.GetMasterCondicional();
        List<NM_Condicional> condicionales = sql.GetCondicionales();
        List<NM_Formula> formulas = sql.GetGeneralFormulas("SELECT * from NM_Formulas");

        master = master.OrderBy(x => x.Nombre).ToList();
        condicionales = condicionales.OrderBy(x => x.NombreCondicional).ToList();
        formulas = formulas.OrderBy(x => x.NombreFormula).ToList();

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
        cb_CondicionalesCantidad.Text = Convert.ToString(this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["ConditionalQty"].Value);
        if (!string.IsNullOrEmpty(cb_CondicionalesCantidad.Text))
          cb_CondicionalesCantidad.AutoCompleteMode = AutoCompleteMode.Suggest;

        cb_CondicionalesMedida.Text = Convert.ToString(this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["ConditionalMd"].Value);
        if (!string.IsNullOrEmpty(cb_CondicionalesMedida.Text))
          cb_CondicionalesMedida.AutoCompleteMode = AutoCompleteMode.Suggest;

        cb_FormulaCantidad.Text = Convert.ToString(this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["FormulaQty"].Value);
        if (!string.IsNullOrEmpty(cb_FormulaCantidad.Text))
          cb_FormulaCantidad.AutoCompleteMode = AutoCompleteMode.Suggest;

        cb_FormulaMedida.Text = Convert.ToString(this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["FormulaMd"].Value);
        if (!string.IsNullOrEmpty(cb_FormulaMedida.Text))
          cb_FormulaMedida.AutoCompleteMode = AutoCompleteMode.Suggest;

        cb_FormulaTotal.Text = Convert.ToString(this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["FormulaTotal"].Value);
        if (!string.IsNullOrEmpty(cb_FormulaTotal.Text))
          cb_FormulaTotal.AutoCompleteMode = AutoCompleteMode.Suggest;

        cb_FormulaPeso.Text = Convert.ToString(this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["FormulaPeso"].Value);
        if (!string.IsNullOrEmpty(cb_FormulaPeso.Text))
          cb_FormulaPeso.AutoCompleteMode = AutoCompleteMode.Suggest;

        txt_Seccion.Text = Convert.ToString(this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["Seccion"].Value);
        txt_Linea.Text = Convert.ToString(this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["Linea"].Value);
        txt_Descripcion.Text = Convert.ToString(this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["Descripcion"].Value);

        currentEdit.NombreCondicionalQty = cb_CondicionalesCantidad.Text;
        currentEdit.NombreCondicionalMd = cb_CondicionalesMedida.Text;
        currentEdit.NombreFormulaQty = cb_FormulaCantidad.Text;
        currentEdit.NombreFormulaMd = cb_FormulaMedida.Text;
        currentEdit.NombreFormulaTotal = cb_FormulaTotal.Text;
        currentEdit.NombreFormulaPeso = cb_FormulaPeso.Text;
        currentEdit.Seccion = txt_Seccion.Text;
        if (string.IsNullOrEmpty(txt_Linea.Text))
        {
          currentEdit.Linea = 0;
        }
        else
        {
          currentEdit.Linea = Convert.ToInt32(txt_Linea.Text);
        }
        currentEdit.Descripcion = txt_Descripcion.Text;

        idCombinacion = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["IdCombinacion_"].Value.ToString();
        idDetalleComp = this.dgvCombinacionesFormulas.Rows[e.RowIndex].Cells["IdDetalleComp_"].Value.ToString();
      }
    }

    public void Clear()
    {
      cb_CondicionalesCantidad.DataSource = null;
      cb_CondicionalesMedida.DataSource = null;
      cb_FormulaCantidad.DataSource = null;
      cb_FormulaMedida.DataSource = null;
      cb_FormulaTotal.DataSource = null;
      cb_FormulaPeso.DataSource = null;
      tb_NumeroParte.Text = string.Empty;
      trvShowConditional.Nodes.Clear();
      txtShowFormulas.Text = string.Empty;
      txt_Seccion.Text = string.Empty;
      txt_Linea.Text = string.Empty;
      txt_Descripcion.Text = string.Empty;
    }

    private void btn_GuardarFormula_Click(object sender, EventArgs e)
    {
      bool exist = sql.ExistPreAssy(idCombinacion);

      if (exist)
      {
        formulasUtilities.UpdateFormulasFromCombo(cb_CondicionalesCantidad.Text, cb_CondicionalesMedida.Text, cb_FormulaCantidad.Text,
                                    cb_FormulaMedida.Text, cb_FormulaTotal.Text, cb_FormulaPeso.Text, currentEdit, idCombinacion, idDetalleComp, txt_Seccion.Text,
                                    txt_Linea.Text, txt_Descripcion.Text);
      }
      else
      {
        CreateModelFormulas();
        formulasUtilities.UpdateFormulasFromCombo(cb_CondicionalesCantidad.Text, cb_CondicionalesMedida.Text, cb_FormulaCantidad.Text,
                                    cb_FormulaMedida.Text, cb_FormulaTotal.Text, cb_FormulaPeso.Text, currentEdit, idCombinacion, idDetalleComp, txt_Seccion.Text,
                                    txt_Linea.Text, txt_Descripcion.Text);
      }
      SearchModel();
      Clear();
    }

    private void CreateModelFormulas()
    {
      DataGridViewRowCollection rows = dgvCombinacionesFormulas.Rows as DataGridViewRowCollection;
      NM_Detalle_Combinacion_Componentes_FormulasModel registro;
      List<NM_Detalle_Combinacion_Componentes_FormulasModel> registros = new List<NM_Detalle_Combinacion_Componentes_FormulasModel>();
      string[] split = new string[] { };
      string error = string.Empty;

      foreach (DataGridViewRow row in rows)
      {
        registro = new NM_Detalle_Combinacion_Componentes_FormulasModel();
        registro.IdCombinacion = Convert.ToInt32(idCombinacion);
        registro.IdDetalleComponente = Convert.ToInt32(row.Cells["IdDetalleComp_"].Value);
        registro.IdComponente = Convert.ToInt32(row.Cells["IdComponente"].Value);
        registro.NombreCondicionalQty = Convert.ToString(row.Cells["ConditionalQty"].Value);
        registro.NombreCondicionalMd = Convert.ToString(row.Cells["ConditionalMd"].Value);
        registro.NombreFormulaQty = Convert.ToString(row.Cells["FormulaQty"].Value);
        registro.NombreFormulaMd = Convert.ToString(row.Cells["FormulaMd"].Value);
        registro.NombreFormulaTotal = Convert.ToString(row.Cells["FormulaTotal"].Value);
        registro.NombreFormulaPeso = Convert.ToString(row.Cells["FormulaPeso"].Value);
        registro.Itemno = row.Cells["ItemnoComponent"].Value.ToString();

        if (!string.IsNullOrEmpty(registro.NombreCondicionalQty))
        {
          split = formulasUtilities.FindIdByName(registro.NombreCondicionalQty, "Condicional").Split('|');
          if (split.Length > 2)
          {
            registro.IdCompuestoQty = split[1];
          }
          registro.IdCondicionalQty = Convert.ToInt32(formulasUtilities.FindIdByName(registro.NombreCondicionalQty, "Condicional")[0]);
        }
        else
        {
          registro.IdCondicionalQty = 0;
        }
        if (!string.IsNullOrEmpty(registro.NombreCondicionalMd))
        {
          split = formulasUtilities.FindIdByName(registro.NombreCondicionalMd, "Condicional").Split('|');
          if (split.Length > 2)
          {
            registro.IdCompuestoMd = split[1];
          }
          registro.IdCondicionalMd = Convert.ToInt32(formulasUtilities.FindIdByName(registro.NombreCondicionalMd, "Condicional")[0]);
        }
        else
        {
          registro.IdCondicionalMd = 0;
        }
        if (!string.IsNullOrEmpty(registro.NombreFormulaQty))
        {
          registro.IdFormulaQty = Convert.ToInt32(formulasUtilities.FindIdByName(registro.NombreFormulaQty, "Formula")[0]);
        }
        else
        {
          registro.IdFormulaQty = 0;
        }
        if (!string.IsNullOrEmpty(registro.NombreFormulaMd))
        {
          registro.IdFormulaMd = Convert.ToInt32(formulasUtilities.FindIdByName(registro.NombreFormulaMd, "Formula")[0]);
        }
        if (!string.IsNullOrEmpty(registro.NombreFormulaTotal))
        {
          registro.IdFormulaTotal = Convert.ToInt32(formulasUtilities.FindIdByName(registro.NombreFormulaTotal, "Formula")[0]);
        }
        else
        {
          registro.IdFormulaTotal = 0;
        }

        registros.Add(registro);
      }

      if (registros.Count() > 0)
      {
        configuracion_controller.CreateModelComplete(registros, out error);
      }
    }

    private void btnAsociar_Click(object sender, EventArgs e)
    {
      string finish_material = string.Empty;
      string idComb = string.Empty;

      if (rbnAlAsociar.Checked)
      {
        finish_material = "AL";
      }

      if (rbnAnAsociar.Checked)
      {
        finish_material = "AN";

      }

      idComb = sql.GetIdCombinacion(cmbCombinacionesBoms.Text, finish_material);
      this.idCombinacion = idComb;
      bool exist = sql.ExistPreAssy(idComb);

      if (!exist)
      {
        CreateModelFormulas();
      }

      sql.UpdateCombinacionCompletada(idComb);
      ResetTabAsociar();
      ClearDataGrid();
      MessageBox.Show("Asociado con exito!");
    }

    private void cb_CondicionalesCantidad_SelectedValueChanged(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(cb_CondicionalesCantidad.Text) && !string.Equals(cb_CondicionalesCantidad.Text, "** CONDICIONALES MASTER **")
          && !string.Equals(cb_CondicionalesCantidad.Text, "** CONDICIONALES SIMPLES **"))
      {
        formulasUtilities.ShowCondicional(cb_CondicionalesCantidad.Text, trvShowConditional);
      }
    }

    private void cb_CondicionalesMedida_SelectedValueChanged(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(cb_CondicionalesMedida.Text) && !string.Equals(cb_CondicionalesMedida.Text, "** CONDICIONALES MASTER **")
          && !string.Equals(cb_CondicionalesMedida.Text, "** CONDICIONALES SIMPLES **"))
      {
        formulasUtilities.ShowCondicional(cb_CondicionalesMedida.Text, trvShowConditional);
      }
    }

    private void cb_FormulaTotal_SelectedValueChanged(object sender, EventArgs e)
    {
      formulasUtilities.ShowFormula(cb_FormulaTotal.Text, txtShowFormulas);
    }

    private void cb_FormulaCantidad_SelectedValueChanged(object sender, EventArgs e)
    {
      formulasUtilities.ShowFormula(cb_FormulaCantidad.Text, txtShowFormulas);
    }

    private void cb_FormulaMedida_SelectedValueChanged(object sender, EventArgs e)
    {
      formulasUtilities.ShowFormula(cb_FormulaMedida.Text, txtShowFormulas);
    }

    private void cb_FormulaPeso_SelectedValueChanged(object sender, EventArgs e)
    {
      formulasUtilities.ShowFormula(cb_FormulaPeso.Text, txtShowFormulas);
    }

    private void pb_VisualizarCondicional_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection masterRows = dgv_CondicionalesMaster.SelectedRows;
      DataGridViewSelectedRowCollection condicionalRows = dgv_Condicionales.SelectedRows;
      string nombre = string.Empty;


      if (masterRows.Count > 0 || condicionalRows.Count > 0)
      {
        //IF TABS
        if (tabCondicionales.SelectedTab.Name == "tbp_Condicionales")
        {
          nombre = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Nombre_Condicionales"].Value.ToString();
          this.nombreCondicional = nombre;
          this.idCondicional = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Id_Condicional"].Value.ToString();
          this.masterFlag = false;
        }
        else
        {
          nombre = dgv_CondicionalesMaster.Rows[dgv_CondicionalesMaster.CurrentRow.Index].Cells["Nombre_CondicionalMaster"].Value.ToString();
          tb_MasterCondicional.Text = nombre;
          this.idNombreCondicionalMaster = nombre;
          this.idCondicionalMaster = dgv_CondicionalesMaster.Rows[dgv_CondicionalesMaster.CurrentRow.Index].Cells["Id_CondicionalMaster"].Value.ToString();
          this.idCompuestoCondicionalMaster = dgv_CondicionalesMaster.Rows[dgv_CondicionalesMaster.CurrentRow.Index].Cells["IdCompuesto_CondicionalMaster"].Value.ToString();
          this.masterFlag = true;
          tb_MasterCondicional.Enabled = true;
        }
        formulasUtilities.ShowCondicional(nombre, tv_Condicional);
        if (tv_Condicional.Nodes.Count > 0)
          tv_Condicional.Nodes[0].ExpandAll();
      }
    }

    private void pb_EliminarCondicional_Click(object sender, EventArgs e)
    {
      DataGridViewSelectedRowCollection masterRows = dgv_CondicionalesMaster.SelectedRows;
      DataGridViewSelectedRowCollection condicionalRows = dgv_Condicionales.SelectedRows;
      string id = string.Empty;
      string nombre = string.Empty;
      string idCompuesto = string.Empty;
      bool existDependency = false;

      var result = MessageBox.Show("Estas seguro que deseas eliminar la condicional?", "AVISO!", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

      if (result == DialogResult.Yes)
      {
        if (masterRows.Count > 0 || condicionalRows.Count > 0)
        {
          //IF TABS
          if (tabCondicionales.SelectedTab.Name == "tbp_Condicionales")
          {
            id = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Id_Condicional"].Value.ToString();
            nombre = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Nombre_Condicionales"].Value.ToString();
            existDependency = sql.ExistConditionalReferentInMaster(id, "Condicional");

            if (!existDependency)
            {
              sql.DeleteCondicional(id, nombre);
              dgv_Condicionales.Rows.Clear();
              LoadDGVCondicionales();
              MessageBox.Show("Condicional eliminada con exito!");
            }
            else
            {
              MessageBox.Show("Existe una condicional master que depende de esta condicional, no puede ser eliminada");
            }
          }
          else
          {
            id = dgv_CondicionalesMaster.Rows[dgv_CondicionalesMaster.CurrentRow.Index].Cells["Id_CondicionalMaster"].Value.ToString();
            nombre = dgv_CondicionalesMaster.Rows[dgv_CondicionalesMaster.CurrentRow.Index].Cells["Nombre_CondicionalMaster"].Value.ToString();
            idCompuesto = dgv_CondicionalesMaster.Rows[dgv_CondicionalesMaster.CurrentRow.Index].Cells["IdCompuesto_CondicionalMaster"].Value.ToString();
            existDependency = sql.ExistConditionalReferentInMaster(id, "Formula");
            if (!existDependency)
            {
              sql.DeleteCondicionalMaster(id, nombre, idCompuesto);
              dgv_CondicionalesMaster.Rows.Clear();
              LoadDGVCondicionalesMaster();
            }
            else
            {
              MessageBox.Show("Existe una condicional master que depende de esta formula, no puede ser eliminada");
            }
            MessageBox.Show("Condicional eliminada con exito!");
          }

          tv_Condicional.Nodes.Clear();
        }
      }
    }

    private void tabCondicionales_Selecting(object sender, TabControlCancelEventArgs e)
    {
      if (tabCondicionales.SelectedTab.Name == "tbp_Condicionales")
      {
        pb_EditarCondicional.Visible = true;
        lbl_EditarCondicional.Visible = true;
        lbl_EditarCondicional_2.Visible = true;
      }
      else
      {
        pb_EditarCondicional.Visible = false;
        lbl_EditarCondicional.Visible = false;
        lbl_EditarCondicional_2.Visible = false;

      }
    }

    private void pb_EditarCondicional_Click(object sender, EventArgs e)
    {
      if (tabCondicionales.SelectedTab.Name == "tbp_Condicionales")
      {
        ClearFormCondicional();
        pb_GuardarCondicional.Visible = true;
        lbl_GuardarCondicional.Visible = true;
        lbl_GuardarCondicional_2.Visible = true;

        tb_NombreCondicional.Text = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Nombre_Condicionales"].Value.ToString();
        tb_NombreCondicional.Enabled = true;
        tb_Condicional.Text = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Condicional_Condicionales"].Value.ToString();
        tb_Verdadero.Text = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Verdadero_Condicionales"].Value.ToString();
        tb_Falso.Text = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Falso_Condicionales"].Value.ToString();
        cb_TipoCondicional.Text = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Tipo_Condicional"].Value.ToString();
      }
    }

    private void pb_GuardarCondicional_Click(object sender, EventArgs e)
    {
      string nombre = string.Empty;
      string condicional = string.Empty;
      string verdadero = string.Empty;
      string falso = string.Empty;
      string tipo = string.Empty;
      string id = dgv_Condicionales.Rows[dgv_Condicionales.CurrentRow.Index].Cells["Id_Condicional"].Value.ToString();
      bool success = false;

      if (ValidForm())
      {
        nombre = tb_NombreCondicional.Text;
        condicional = tb_Condicional.Text;
        verdadero = tb_Verdadero.Text;
        falso = tb_Falso.Text;
        tipo = cb_TipoCondicional.Text;

        success = sql.UpdateCondicional(condicional, verdadero, falso, tipo, nombre, id);

        if (success)
        {
          pb_GuardarCondicional.Visible = false;
          lbl_GuardarCondicional.Visible = false;
          lbl_GuardarCondicional_2.Visible = false;

          ClearFormCondicional();
          LoadDGVCondicionales();
        }
      }
    }

    private void pb_ActualizarCondicional_Click(object sender, EventArgs e)
    {
      if (this.masterFlag)
      {
        int nodosCount = tv_Condicional.GetNodeCount(true);

        var result = MessageBox.Show("Esta condicional master se encuentra asignada a algunos modelos, la edicion de la condicional podria cambiar el comportamiento " +
                            "de estos, desea proseguir con la actualizacion?", "AVISO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
          RecorrerArbol(tv_Condicional);
          sql.DeleteCondicionalMaster(this.idCondicionalMaster, this.idNombreCondicionalMaster, this.idCompuestoCondicionalMaster);
          this.idNombreCondicionalMaster = tb_MasterCondicional.Text;
          if (nodosCount > 5)
          {
            foreach (NM_CondicionalMaster nodo in nodos)
            {
              sql.InsertCondicionalMaster(nodo, this.idCompuestoCondicionalMaster, this.idNombreCondicionalMaster, nodo.Tipo);
            }
            tv_Condicional.Nodes[0].Remove();
            nodos.Clear();
            tb_MasterCondicional.Text = string.Empty;
            LoadDGVCondicionalesMaster();
            MessageBox.Show("Guardado correctamente!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
        }
      }
    }

    private void pb_BuscarFormula_Click(object sender, EventArgs e)
    {
      frmBuscarFormulas buscarFormulas = new frmBuscarFormulas();
      buscarFormulas.Show();
    }

    private void btnRemplazarComponente_Click(object sender, EventArgs e)
    {
      if (Application.OpenForms["frmRemplazoComponentes"] != null)
      {
        Application.OpenForms["frmRemplazoComponentes"].Activate();
      }
      else
      {
        frmRemplazoComponentes form = new frmRemplazoComponentes();
        form.Show();
      }
    }

    private void btnEliminarBom_Click(object sender, EventArgs e)
    {
      string combinacion = cmbCombinacionesBoms.Text;
      string finish_material = string.Empty;
      string idCombinacion = string.Empty;
      bool deleteCombinacion = false;
      bool deleteDetalleFormulas = false;
      bool deleteDetalleComponentes = false;

      if (rbnAlAsociar.Checked)
      {
        finish_material = "AL";
      }

      if (rbnAnAsociar.Checked)
      {
        finish_material = "AN";
      }

      idCombinacion = sql.GetIdCombinacion(combinacion, finish_material);

      if (string.IsNullOrEmpty(idCombinacion))
      {
        var result = MessageBox.Show("¿Esta seguro que desea eliminar este modelo?", "AVISO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
          deleteCombinacion = sql.DeleteNM_Combinacion(idCombinacion);
          deleteDetalleComponentes = sql.DeleteNM_Detalle_Combinaciones_Componentes(idCombinacion);
          deleteDetalleFormulas = sql.DeleteNM_Detalle_Combinacion_Componentes_Formulas(idCombinacion);

          if (deleteCombinacion && deleteDetalleComponentes && deleteDetalleFormulas)
          {

          }
        }
      }
    }

    private void gvbModelL1_Enter(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private void tabPage1_Click(object sender, EventArgs e)
    {
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void dgvModeloL0_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void gpbModel0_Enter(object sender, EventArgs e)
    {

    }

    private void ProcessMantence_Paint(object sender, PaintEventArgs e)
    {

    }

    private void lblSecuenceName_Click(object sender, EventArgs e)
    {

    }

    private void lbProcessSelection(object sender, EventArgs e)
    {

    }

    private async void LoadNMSecuencias()
    {
      try
      {
        var data = await sql.GetNMSecuences();
        if (data != null && data.Count > 0)
        {
          dgvSecuenceList.DataSource = data;
          dgvSecuencesRelaList.DataSource = data;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error al cargar secuencias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private async void LoadFamilys()
    {
      try
      {
        var data = await sql.GetFamilys();
        if (data != null && data.Count > 0)
        {
          dgvFamilyRelaList.DataSource= data;

        }
      }
      catch (Exception ex) {
        MessageBox.Show($"Error tratando de obtener las familias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private async void LoadDetallesSecuencesDetail()
    {
      try
      {
        var data = await sql.GetSecuenceDetailSecuences();
        if (data != null && data.Count > 0)
        {
          dgvListRelaExistentes.DataSource = data;

        }
      }catch (Exception ex)
      {
        MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private async void LoadSecuenceDetails()
    {
      try
      {
        var data = await sql.GetSecuenceDetails();
        if (data != null && data.Count > 0)
        {
          dgvProcessList.DataSource = data;
          dgvProccessRelaList.DataSource = data;
        }

      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error al cargar los detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void dgvSecuenceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private async void dgvSecuenceList_Load(object sender, EventArgs e)
    {
      var data = await sql.GetNMSecuences();
      dgvSecuenceList.DataSource = data;
    }

    //! 

    private async void dgvSecuencesRelaList_load(object sender, EventArgs e)
    {
      var data = await sql.GetNMSecuences();
      dgvSecuencesRelaList.DataSource = data;
    }

    private void txtSequence_TextChanged(object sender, EventArgs e)
    {

    }

    #region Sequence Management Event Handlers

    private async void txtSequence_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter)
      {
        e.Handled = true; // Prevent beep sound
        await SaveOrUpdateSequence();
      }
    }

    private async void btnSaveSecuence_Click(object sender, EventArgs e)
    {
      await SaveOrUpdateSequence();
    }

    private async Task SaveOrUpdateSequence()
    {
      string descripcion = txtSequence.Text.Trim();

      if (string.IsNullOrWhiteSpace(descripcion))
      {
        MessageBox.Show("Por favor ingrese una descripción para la secuencia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      try
      {
        if (isEditMode && selectedSequenceId.HasValue)
        {
          // Update existing sequence
          bool success = sql.UpdateSequenceDescription(selectedSequenceId.Value, descripcion);

          if (success)
          {
            MessageBox.Show("Secuencia actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtSequence.Text = string.Empty;
            txtSequence.ReadOnly = false;
            isEditMode = false;
            selectedSequenceId = null;
            btnEditSecuence.Enabled = false;
            await RefreshSequenceGrid();
          }
          else
          {
            MessageBox.Show("Error al actualizar la secuencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        else
        {

          if (sql.ValidateSequenceExists(descripcion))
          {
            MessageBox.Show("Ya existe una secuencia con esta descripción. Por favor ingrese una descripción diferente.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
          }

          bool success = sql.InsertSequence(descripcion);

          if (success)
          {
            MessageBox.Show("Secuencia guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtSequence.Text = string.Empty;
            await RefreshSequenceGrid();
          }
          else
          {
            MessageBox.Show("Error al guardar la secuencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    
    private void btnEditSecuence_Click(object sender, EventArgs e)
    {
      if (!selectedSequenceId.HasValue)
      {
        MessageBox.Show("Por favor seleccione una secuencia del listado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      // Get the selected row
      if (dgvSecuenceList.SelectedRows.Count > 0)
      {
        var selectedRow = dgvSecuenceList.SelectedRows[0];
        string descripcion = selectedRow.Cells["Descripcion"].Value?.ToString() ?? string.Empty;

        txtSequence.Text = descripcion;
        txtSequence.ReadOnly = false;
        txtSequence.Focus();
        isEditMode = true;
      }
    }

    private async void btnHideSecuence_Click(object sender, EventArgs e)
    {
      if (!selectedSequenceId.HasValue)
      {
        MessageBox.Show("Por favor seleccione una secuencia del listado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      var result = MessageBox.Show("¿Está seguro que desea desactivar esta secuencia?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (result == DialogResult.Yes)
      {
        try
        {
          bool success = sql.MarkSequenceAsHidden(selectedSequenceId.Value);

          if (success)
          {
            MessageBox.Show("Secuencia desactivada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            selectedSequenceId = null;
            isEditMode = false;
            txtSequence.Text = string.Empty;
            btnEditSecuence.Enabled = false;
            btnHideSecuence.Enabled = false;
            btnDeleteSecuence.Enabled = false;
            await RefreshSequenceGrid();
          }
          else
          {
            MessageBox.Show("Error al desactivar la secuencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private async void btnDeleteSecuence_Click(object sender, EventArgs e)
    {
      if (!selectedSequenceId.HasValue)
      {
        MessageBox.Show("Por favor seleccione una secuencia del listado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      try
      {
        // Check if sequence is being used
        bool isInUse = sql.ValidateSequenceInUse(selectedSequenceId.Value);

        if (isInUse)
        {
          var result = MessageBox.Show("Esta secuencia está siendo utilizada en otras tablas y no puede ser eliminada físicamente. " +
                                       "¿Desea marcarla como desactivada?", "Secuencia en Uso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

          if (result == DialogResult.Yes)
          {
            bool success = sql.MarkSequenceAsHidden(selectedSequenceId.Value);

            if (success)
            {
              MessageBox.Show("Secuencia marcada como desactivada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
              selectedSequenceId = null;
              isEditMode = false;
              txtSequence.Text = string.Empty;
              btnEditSecuence.Enabled = false;
              btnHideSecuence.Enabled = false;
              btnDeleteSecuence.Enabled = false;
              await RefreshSequenceGrid();
            }
          }
        }
        else
        {
          var result = MessageBox.Show("¿Está seguro que desea eliminar esta secuencia permanentemente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

          if (result == DialogResult.Yes)
          {
            bool success = sql.DeleteSequence(selectedSequenceId.Value);

            if (success)
            {
              MessageBox.Show("Secuencia eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
              selectedSequenceId = null;
              isEditMode = false;
              txtSequence.Text = string.Empty;
              btnEditSecuence.Enabled = false;
              btnHideSecuence.Enabled = false;
              btnDeleteSecuence.Enabled = false;
              await RefreshSequenceGrid();
            }
            else
            {
              MessageBox.Show("Error al eliminar la secuencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void dgvSecuenceList_SelectionChanged(object sender, EventArgs e)
    {
      if (dgvSecuenceList.SelectedRows.Count > 0)
      {
        var selectedRow = dgvSecuenceList.SelectedRows[0];

        if (selectedRow.Cells["ID"].Value != null)
        {
          selectedSequenceId = Convert.ToDecimal(selectedRow.Cells["ID"].Value);
          btnEditSecuence.Enabled = true;
          btnHideSecuence.Enabled = true;
          btnDeleteSecuence.Enabled = true;
        }
        else
        {
          selectedSequenceId = null;
          btnEditSecuence.Enabled = false;
          btnHideSecuence.Enabled = false;
          btnDeleteSecuence.Enabled = false;
        }
      }
      else
      {
        selectedSequenceId = null;
        btnEditSecuence.Enabled = false;
        btnHideSecuence.Enabled = false;
        btnDeleteSecuence.Enabled = false;
      }

      // Exit edit mode if selection changes
      if (isEditMode)
      {
        isEditMode = false;
        txtSequence.Text = string.Empty;
        txtSequence.ReadOnly = false;
      }
    }

    private async Task RefreshSequenceGrid()
    {
      try
      {
        var data = await sql.GetNMSecuences();
        if (data == null || data.Count <= 0)
        {
          dgvSecuenceList.DataSource = null;
          return;
        }

        dgvSecuenceList.DataSource = null;
        dgvSecuenceList.DataSource = data;

      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error al refrescar el listado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    private async Task RefreshProccessGrid()
    {
      try
      {
        var data = await sql.GetSecuenceDetails();
        if (data == null || data.Count <= 0)
        {
          dgvProcessList.DataSource = null;
          return;
        }

        dgvProcessList.DataSource = null;
        dgvProcessList.DataSource = data;
        return;

      }
      catch (Exception ex)
      {
        MessageBox.Show("Error tratando de refrescar el listado de procesos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    #endregion

    #region Proccess Management event handler
    private async Task SaveOrUpdateProccess()
    {
      string description = txtProcess.Text.Trim();

      if (string.IsNullOrEmpty(description))
      {
        MessageBox.Show(
            "Por favor ingrese una descripcion de los detalles",
            "Validación",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
        );
        return;
      }

      try
      {
        bool success = false;

        if (isEditMode && selectedProccessId.HasValue)
        {
          // Check for duplicate on update if name changed? 
          // Assuming we just update description for the given ID.
          // Note: Could check if another record has same description, but omitting for now unless requested.
          success = sql.UpdateSequenceDetail(selectedProccessId.Value, description);

          if (success)
          {
            MessageBox.Show("Proceso actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
            MessageBox.Show("Error al actualizar el proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        else
        {
          // Check for validation before insert
          if (sql.ValidateProccessExists(description))
          {
             MessageBox.Show("La secuencia que se esta agregando ya existe repetida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             return;
          }

          success = sql.InsertSequenceDetail(description);
          
          if (success)
          {
             MessageBox.Show("Proceso guardado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
          else
          {
             MessageBox.Show("Error al guardar el proceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }

        if (success)
        {
          txtProcess.Text = string.Empty;
          isEditMode = false;
          selectedProccessId = null;
          btnEditProccess.Enabled = false;
          btnHideProcess.Enabled = false;
          btnDeleteProceso.Enabled = false;

          await RefreshProccessGrid();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            $"Error: {ex.Message}",
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );
      }
    }

    private async void txtProcess_KeyPress(object sencer, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter)
      {
        e.Handled = true;
        await SaveOrUpdateProccess();
      }
    }

    private void btnEditProccess_Click(object sender, EventArgs e)
    {
      if (!selectedProccessId.HasValue)
      {
        MessageBox.Show("Por favor selecciona un proceso del listado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if(dgvProcessList.SelectedRows.Count > 0)
      {
        var selectedRow = dgvProcessList.SelectedRows[0];
        string description = selectedRow.Cells["Detalle"].Value?.ToString() ?? string.Empty;

        txtProcess.Text = description;
        // Ensure we enable editing
        txtProcess.Focus(); 
        isEditMode = true;
      }
    }

    private async void btnSaveProccess_Click(object sender, EventArgs e)
    {
      await SaveOrUpdateProccess();
    }

    private async void btnHideProcess_Click_1(object sender, EventArgs e)
    {
      if (!selectedProccessId.HasValue)
      {
        MessageBox.Show("Por favor selecciona un proceso del listado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      var result = MessageBox.Show("¿Está seguro que desea desactivar este proceso?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (result == DialogResult.Yes)
      {
         try
         {
           bool success = sql.MarkSequenceDetailAsHidden(selectedProccessId.Value);

           if (success)
           {
             MessageBox.Show("Proceso desactivado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
             selectedProccessId = null;
             isEditMode = false;
             txtProcess.Text = string.Empty;
             btnEditProccess.Enabled = false;
             btnHideProcess.Enabled = false;
             btnDeleteProceso.Enabled = false;
             await RefreshProccessGrid();
           }
           else
           {
             MessageBox.Show("Error al desactivar el proceso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
         }
         catch (Exception ex)
         {
           MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
    }

    private async void btnDeleteProceso_Click_1(object sender, EventArgs e)
    {
       if (!selectedProccessId.HasValue)
       {
         MessageBox.Show("Por favor selecciona un proceso del listado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         return;
       }

       try
       {
          // Validar uso en NM_Secuencia_Detalle_secuencia
          bool isInUse = sql.ValidateProcessInUse(selectedProccessId.Value);

          if (isInUse)
          {
             var result = MessageBox.Show("No es posible borrar por las relaciones existentes con otras tablas. ¿Desea marcar como desactivada?", "Proceso en Uso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
             
             if (result == DialogResult.Yes)
             {
                bool success = sql.MarkSequenceDetailAsHidden(selectedProccessId.Value);
                if (success) 
                {
                   MessageBox.Show("Proceso marcado como desactivado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   selectedProccessId = null;
                   isEditMode = false;
                   txtProcess.Text = string.Empty;
                   btnEditProccess.Enabled = false;
                   btnHideProcess.Enabled = false;
                   btnDeleteProceso.Enabled = false;
                   await RefreshProccessGrid();
                }
             }
          }
          else
          {
             // Si no se encuentra en uso, proceder a borrar
             var result = MessageBox.Show("¿Está seguro que desea eliminar este proceso permanentemente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (result == DialogResult.Yes)
             {
               bool success = sql.DeleteSequenceDetail(selectedProccessId.Value);
               
               if (success)
               {
                 MessageBox.Show("Proceso eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 selectedProccessId = null;
                 isEditMode = false;
                 txtProcess.Text = string.Empty;
                 btnEditProccess.Enabled = false;
                 btnHideProcess.Enabled = false;
                 btnDeleteProceso.Enabled = false;
                 await RefreshProccessGrid();
               }
               else 
               {
                 MessageBox.Show("Error al eliminar el proceso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
             }
          }
       }
       catch (Exception ex)
       {
          MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
    }

    private void dgvProcessList_SelectionChanged(object sender, EventArgs e)
    {
      if (dgvProcessList.SelectedRows.Count > 0)
      {
        var selectedRow = dgvProcessList.SelectedRows[0];
        
        // Assuming column ID is named "ID" based on DTO mapping logic (usually DTO property name)
        // DTO has ID, Detalle, PK.
        if (selectedRow.Cells["ID"].Value != null)
        {
          selectedProccessId = Convert.ToDecimal(selectedRow.Cells["ID"].Value);
          btnEditProccess.Enabled = true;
          btnHideProcess.Enabled = true;
          btnDeleteProceso.Enabled = true;
        }
        else
        {
           selectedProccessId = null;
           btnEditProccess.Enabled = false;
           btnHideProcess.Enabled = false;
           btnDeleteProceso.Enabled = false;
        }
      }
      else
      {
         selectedProccessId = null;
         btnEditProccess.Enabled = false;
         // btnHideProccess (Note: Check exact name if it was hidden/typo) -> user said btnHideProcess
         btnHideProcess.Enabled = false;
         btnDeleteProceso.Enabled = false;
      }
      
      // Exit edit mode if selection changes logic? Same as sequence
      if (isEditMode)
      {
        isEditMode = false;
        txtProcess.Text = string.Empty;
      }
    }


    #endregion

    private void lblSeleccionSecuencia_Click(object sender, EventArgs e)
    {

    }

    private int? selectedFamilyId = null;
    private int? selectedRelId = null;
    private bool isEditModeRel = false;

    private async void btnSecuenceProccessRel_Click(object sender, EventArgs e)
    {
      try
      {
        if (dgvSecuencesRelaList.SelectedRows.Count == 0 ||
            dgvProccessRelaList.SelectedRows.Count == 0 ||
            dgvFamilyRelaList.SelectedRows.Count == 0 ||
            string.IsNullOrWhiteSpace(txtSecuenceBOM.Text))
        {
           MessageBox.Show("Debe seleccionar una Secuencia, un Proceso, una Familia e ingresar un texto en Secuencia BOM.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           return;
        }

        decimal sequenceId = Convert.ToDecimal(dgvSecuencesRelaList.SelectedRows[0].Cells["ID"].Value);
        decimal processId = Convert.ToDecimal(dgvProccessRelaList.SelectedRows[0].Cells["ID"].Value); 
        int familyId = Convert.ToInt32(dgvFamilyRelaList.SelectedRows[0].Cells["ID"].Value);
        string sequenceBom = txtSecuenceBOM.Text.Trim();

        // Validation - Check if exists
        bool exists = await sql.ValidateSequenceProcessRelation(sequenceId, processId, familyId, sequenceBom);

        if (exists && !isEditModeRel)
        {
           MessageBox.Show("La combinación ya existe. Utilice la opción de Editar seleccionando el registro en la lista de relaciones existentes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
           return;
        }

        bool success = false;
        if (isEditModeRel)
        {
             if (selectedRelId.HasValue)
             {
                 success = await sql.UpdateSequenceProcessRelation(selectedRelId.Value, sequenceId, processId, familyId, sequenceBom);
                 if (success) MessageBox.Show("Relación actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
        }
        else
        {
             success = await sql.InsertSequenceProcessRelation(sequenceId, processId, familyId, sequenceBom);
             if (success) MessageBox.Show("Relación guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        if (success)
        {
           ResetRelForm();
           LoadDetallesSecuencesDetail(); // Refresh list
        }
        else
        {
           MessageBox.Show("Error al guardar la relación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

      }
      catch (Exception ex)
      {
         MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnCncelSecuenceProccessRel_Click(object sender, EventArgs e)
    {
       ResetRelForm();
    }

    private void ResetRelForm()
    {
       txtSecuenceBOM.Text = string.Empty;
       dgvSecuencesRelaList.ClearSelection();
       dgvProccessRelaList.ClearSelection();
       dgvFamilyRelaList.ClearSelection();
       
       isEditModeRel = false;
       selectedRelId = null;
       btnEditSecuenceProccessRel.Enabled = false;
    }

    private void btnEditSecuenceProccessRel_Click(object sender, EventArgs e)
    {
        if (!selectedRelId.HasValue) 
        {
            MessageBox.Show("Seleccione un registro para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        // Enable edit mode
        isEditModeRel = true;
        txtSecuenceBOM.Focus();
        // MessageBox.Show("Modo edición activado.", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private async void dgvListRelaExistentes_SelectionChanged(object sender, EventArgs e)
    {
       if (dgvListRelaExistentes.SelectedRows.Count > 0)
       {
          var row = dgvListRelaExistentes.SelectedRows[0];
          
          if (row.Cells["ID"].Value != null)
          {
             selectedRelId = Convert.ToInt32(row.Cells["ID"].Value);
             btnEditSecuenceProccessRel.Enabled = true;

             try 
             {
                 var details = await sql.GetSequenceProcessRelationById(selectedRelId.Value);
                 
                 if (details != null)
                 {
                     SelectRowInGrid(dgvSecuencesRelaList, "ID", details.Item1);
                     SelectRowInGrid(dgvProccessRelaList, "ID", details.Item2); 
                     SelectRowInGrid(dgvFamilyRelaList, "ID", details.Item3);
                     txtSecuenceBOM.Text = details.Item4;
                 }
             }
             catch(Exception ex)
             {
                 Console.WriteLine("Error autofilling selection: " + ex.Message);
             }
          }
       }
       else
       {
          selectedRelId = null;
          btnEditSecuenceProccessRel.Enabled = false;
       }
    }

    private void SelectRowInGrid(DataGridView dgv, string columnName, object value)
    {
       dgv.ClearSelection();
       foreach (DataGridViewRow row in dgv.Rows)
       {
           if (row.Cells[columnName].Value != null)
           {
               // Compare as strings to avoid type issues (decimal vs int)
               if (row.Cells[columnName].Value.ToString() == value.ToString())
               {
                   row.Selected = true;
                   if (row.Visible) dgv.FirstDisplayedScrollingRowIndex = row.Index;
                   break;
               }
           }
       }
    }

    private void btnDiableSecuenceProccessRel_Click(object sender, EventArgs e)
    {
      // Optional: Logic to disable/hide relationship? Not explicitly requested but button exists.
    }

    private void dgvListRelaExistentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dgvListRelaExistentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
             ActivateEditModeRel();
        }
    }

    private void ActivateEditModeRel()
    {
         if (selectedRelId.HasValue)
         {
             isEditModeRel = true;
             btnEditSecuenceProccessRel.Enabled = true;
             txtSecuenceBOM.Focus();
             // MessageBox.Show("Modo edición activado via teclado/mouse.", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information); 
             // Commented out message box to make it smoother for shortcuts
         }
    }

    private void dgvListRelaExistentes_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.Handled = true; // Use Handled or SuppressKeyPress depending on needs, but Handled usually for KeyPress.
            e.SuppressKeyPress = true; // Prevents "Ding" sound and default behavior
            ActivateEditModeRel();
        }
    }

    private void txtSecuenceBOM_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
             e.Handled = true;
             btnSecuenceProccessRel_Click(sender, e);
        }
    }

    private void dgvModeloL1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
  }
}
