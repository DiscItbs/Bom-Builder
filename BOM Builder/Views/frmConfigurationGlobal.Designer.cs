namespace BOM_Builder.Views
{
      partial class frmConfigurationGlobal
      {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                  if (disposing && (components != null))
                  {
                        components.Dispose();
                  }
                  base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurationGlobal));
      this.Id_Formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Condicional_Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.groupBox5 = new System.Windows.Forms.GroupBox();
      this.dgvListRelaExistentes = new System.Windows.Forms.DataGridView();
      this.btnCncelSecuenceProccessRel = new System.Windows.Forms.Button();
      this.btnSecuenceProccessRel = new System.Windows.Forms.Button();
      this.dgvFamilyRelaList = new System.Windows.Forms.DataGridView();
      this.dgvProccessRelaList = new System.Windows.Forms.DataGridView();
      this.dgvSecuencesRelaList = new System.Windows.Forms.DataGridView();
      this.txtSecuenceBOM = new System.Windows.Forms.TextBox();
      this.btnDiableSecuenceProccessRel = new System.Windows.Forms.Button();
      this.btnEditSecuenceProccessRel = new System.Windows.Forms.Button();
      this.label39 = new System.Windows.Forms.Label();
      this.label41 = new System.Windows.Forms.Label();
      this.label40 = new System.Windows.Forms.Label();
      this.lblSeleccionSecuencia = new System.Windows.Forms.Label();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.btnEditProccess = new System.Windows.Forms.Button();
      this.btnHideProcess = new System.Windows.Forms.Button();
      this.btnDeleteProceso = new System.Windows.Forms.Button();
      this.btnSaveProccess = new System.Windows.Forms.Button();
      this.txtProcess = new System.Windows.Forms.TextBox();
      this.dgvProcessList = new System.Windows.Forms.DataGridView();
      this.lblProcessList = new System.Windows.Forms.Label();
      this.lblProcessName = new System.Windows.Forms.Label();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.btnDeleteSecuence = new System.Windows.Forms.Button();
      this.btnHideSecuence = new System.Windows.Forms.Button();
      this.btnEditSecuence = new System.Windows.Forms.Button();
      this.btnSaveSecuence = new System.Windows.Forms.Button();
      this.dgvSecuenceList = new System.Windows.Forms.DataGridView();
      this.lblSequenceList = new System.Windows.Forms.Label();
      this.txtSequence = new System.Windows.Forms.TextBox();
      this.lblSecuenceName = new System.Windows.Forms.Label();
      this.tbpAsociarComponenteFormula = new System.Windows.Forms.TabPage();
      this.label36 = new System.Windows.Forms.Label();
      this.label35 = new System.Windows.Forms.Label();
      this.txt_Descripcion = new System.Windows.Forms.TextBox();
      this.txt_Linea = new System.Windows.Forms.TextBox();
      this.txt_Seccion = new System.Windows.Forms.TextBox();
      this.tb_NumeroParte = new System.Windows.Forms.TextBox();
      this.label34 = new System.Windows.Forms.Label();
      this.btn_GuardarFormula = new System.Windows.Forms.Button();
      this.dgvCombinacionesFormulas = new System.Windows.Forms.DataGridView();
      this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.IdDetalleComp_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.IdCombinacion_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.IdComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
      this.ItemnoComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.NameComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ConditionalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ConditionalMd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FormulaQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FormulaMd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FormulaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FormulaPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Seccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.label20 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.cb_FormulaPeso = new System.Windows.Forms.ComboBox();
      this.cb_FormulaMedida = new System.Windows.Forms.ComboBox();
      this.cb_FormulaCantidad = new System.Windows.Forms.ComboBox();
      this.label14 = new System.Windows.Forms.Label();
      this.label17 = new System.Windows.Forms.Label();
      this.label19 = new System.Windows.Forms.Label();
      this.cb_FormulaTotal = new System.Windows.Forms.ComboBox();
      this.cb_CondicionalesMedida = new System.Windows.Forms.ComboBox();
      this.cb_CondicionalesCantidad = new System.Windows.Forms.ComboBox();
      this.btn_Clonar = new System.Windows.Forms.Button();
      this.btnEditarFormulas = new System.Windows.Forms.Button();
      this.cmbListadoModelos = new System.Windows.Forms.ComboBox();
      this.lblTipoBom = new System.Windows.Forms.Label();
      this.gpbShowFormulas = new System.Windows.Forms.GroupBox();
      this.txtShowFormulas = new System.Windows.Forms.TextBox();
      this.gpbShowConditional = new System.Windows.Forms.GroupBox();
      this.trvShowConditional = new System.Windows.Forms.TreeView();
      this.gpbAcabadosAsociar = new System.Windows.Forms.GroupBox();
      this.rbnAnAsociar = new System.Windows.Forms.RadioButton();
      this.rbnAlAsociar = new System.Windows.Forms.RadioButton();
      this.btnAsociar = new System.Windows.Forms.Button();
      this.btnBuscarCombinacionesComponentes = new System.Windows.Forms.Button();
      this.cmbCombinacionesBoms = new System.Windows.Forms.ComboBox();
      this.lblCombinaciones = new System.Windows.Forms.Label();
      this.tbpClonado = new System.Windows.Forms.TabPage();
      this.checkBox_AN = new System.Windows.Forms.CheckBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.tb_Descripcion = new System.Windows.Forms.TextBox();
      this.label30 = new System.Windows.Forms.Label();
      this.label31 = new System.Windows.Forms.Label();
      this.tb_DestinoLinea = new System.Windows.Forms.TextBox();
      this.btnGuardarComponente = new System.Windows.Forms.Button();
      this.btnEliminarComponente = new System.Windows.Forms.Button();
      this.cbCentroTrabajo = new System.Windows.Forms.ComboBox();
      this.label33 = new System.Windows.Forms.Label();
      this.cbFamilias = new System.Windows.Forms.ComboBox();
      this.label32 = new System.Windows.Forms.Label();
      this.btnTransferirRegistro = new System.Windows.Forms.Button();
      this.btnBuscarComponentes = new System.Windows.Forms.Button();
      this.btn_SeleccionarTodo = new System.Windows.Forms.Button();
      this.cb_Modelos = new System.Windows.Forms.ComboBox();
      this.label29 = new System.Windows.Forms.Label();
      this.cb_Secciones = new System.Windows.Forms.ComboBox();
      this.btn_NuevoModelo = new System.Windows.Forms.Button();
      this.txtNuevoModelo = new System.Windows.Forms.TextBox();
      this.label28 = new System.Windows.Forms.Label();
      this.label27 = new System.Windows.Forms.Label();
      this.label26 = new System.Windows.Forms.Label();
      this.gb_Destino = new System.Windows.Forms.GroupBox();
      this.dgvClonDestino = new System.Windows.Forms.DataGridView();
      this.Destino_Editar = new System.Windows.Forms.DataGridViewButtonColumn();
      this.Destino_IdCombinacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_IdDetalleComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_Itemno = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_IdComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_FormulaQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_FormulaMd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_FormulaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_FormulaPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_CondicionalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_CondicionalMd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_TypeCondicionalMd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_TypeCondicionalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_IdCompuestoQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_IdCompuestoMd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_Seccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Destino_Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gb_ClonOrigen = new System.Windows.Forms.GroupBox();
      this.dgvOrigenClon = new System.Windows.Forms.DataGridView();
      this.Seleccion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.IdCombinacion_Origen = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.IdDetalleComp_clon = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Itemno = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_IdComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_FormulaQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_FormulaMd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_FormulaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_FormulaPeso = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_CondicionalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_CondicionalMd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_TypeCondicionalMd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_TypeCondicionalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_CompuestoQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_CompuestoMd = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_Seccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Origen_Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cb_Familias = new System.Windows.Forms.ComboBox();
      this.tbpCondicionales = new System.Windows.Forms.TabPage();
      this.label38 = new System.Windows.Forms.Label();
      this.label37 = new System.Windows.Forms.Label();
      this.pb_BuscarFormula = new System.Windows.Forms.PictureBox();
      this.label24 = new System.Windows.Forms.Label();
      this.pb_ActualizarCondicional = new System.Windows.Forms.PictureBox();
      this.label25 = new System.Windows.Forms.Label();
      this.pb_VisualizarCondicional = new System.Windows.Forms.PictureBox();
      this.label23 = new System.Windows.Forms.Label();
      this.label22 = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.pb_EliminarCondicional = new System.Windows.Forms.PictureBox();
      this.tb_MasterCondicional = new System.Windows.Forms.TextBox();
      this.label15 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.pb_Guardar = new System.Windows.Forms.PictureBox();
      this.lbl_EliminarNodo = new System.Windows.Forms.Label();
      this.lbl_AgregarNodo = new System.Windows.Forms.Label();
      this.pb_Agregar = new System.Windows.Forms.PictureBox();
      this.pb_Eliminar = new System.Windows.Forms.PictureBox();
      this.tv_Condicional = new System.Windows.Forms.TreeView();
      this.tabCondicionales = new System.Windows.Forms.TabControl();
      this.tbp_Condicionales = new System.Windows.Forms.TabPage();
      this.dgv_Condicionales = new System.Windows.Forms.DataGridView();
      this.Id_Condicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Nombre_Condicionales = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Condicional_Condicionales = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Verdadero_Condicionales = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Falso_Condicionales = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Tipo_Condicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tbp_CondicionalMaster = new System.Windows.Forms.TabPage();
      this.dgv_CondicionalesMaster = new System.Windows.Forms.DataGridView();
      this.Id_CondicionalMaster = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Nombre_CondicionalMaster = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.IdCompuesto_CondicionalMaster = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tbpFormulas = new System.Windows.Forms.TabPage();
      this.dgv_Formulas_Condicional = new System.Windows.Forms.DataGridView();
      this.Condicional_Id_Formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Condicional_Tipo_Formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Condicional_NombreFormula = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Condicional_Formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Condicional_Formula_FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lbl_EditarCondicional_2 = new System.Windows.Forms.Label();
      this.lbl_GuardarCondicional_2 = new System.Windows.Forms.Label();
      this.lbl_EditarCondicional = new System.Windows.Forms.Label();
      this.cb_TipoCondicional = new System.Windows.Forms.ComboBox();
      this.pb_EditarCondicional = new System.Windows.Forms.PictureBox();
      this.lbl_GuardarCondicional = new System.Windows.Forms.Label();
      this.label16 = new System.Windows.Forms.Label();
      this.pb_GuardarCondicional = new System.Windows.Forms.PictureBox();
      this.lbl_Condicional = new System.Windows.Forms.Label();
      this.label18 = new System.Windows.Forms.Label();
      this.pb_AgregarCondicionalForm = new System.Windows.Forms.PictureBox();
      this.tb_NombreCondicional = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.tb_Falso = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.tb_Verdadero = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.tb_Condicional = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.tbPCatalogoFormulas = new System.Windows.Forms.TabPage();
      this.gpbCantidades = new System.Windows.Forms.GroupBox();
      this.btn_Eliminar = new System.Windows.Forms.Button();
      this.btn_Guardar = new System.Windows.Forms.Button();
      this.btn_Editar = new System.Windows.Forms.Button();
      this.dgv_Formulas = new System.Windows.Forms.DataGridView();
      this.IdFormula = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.NombreFormula = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.TipoFormula = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cb_TipoFormula = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btn_ValidarFormula = new System.Windows.Forms.Button();
      this.txt_Formula = new System.Windows.Forms.TextBox();
      this.lblNombreFormula = new System.Windows.Forms.Label();
      this.lblFormula = new System.Windows.Forms.Label();
      this.txt_NombreFormula = new System.Windows.Forms.TextBox();
      this.tbpConstruccionBomComponente = new System.Windows.Forms.TabPage();
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.btnRemplazarComponente = new System.Windows.Forms.Button();
      this.btnEditarCombinacion = new System.Windows.Forms.Button();
      this.txtFilter = new System.Windows.Forms.TextBox();
      this.txtPreviewCombination = new System.Windows.Forms.TextBox();
      this.lblFilter = new System.Windows.Forms.Label();
      this.lblPreviewCombination = new System.Windows.Forms.Label();
      this.btnCreatePreAssembly = new System.Windows.Forms.Button();
      this.btnSearch = new System.Windows.Forms.Button();
      this.dgvListComponents = new System.Windows.Forms.DataGridView();
      this.IdComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Itemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Apply = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.gpbAgregados = new System.Windows.Forms.GroupBox();
      this.cmbMaterial06 = new System.Windows.Forms.ComboBox();
      this.lblMaterial04 = new System.Windows.Forms.Label();
      this.lblMaterial06 = new System.Windows.Forms.Label();
      this.cmbMaterial04 = new System.Windows.Forms.ComboBox();
      this.cmbMaterial05 = new System.Windows.Forms.ComboBox();
      this.lblMaterial05 = new System.Windows.Forms.Label();
      this.cmbMaterial03 = new System.Windows.Forms.ComboBox();
      this.lblMaterial01 = new System.Windows.Forms.Label();
      this.lblMaterial03 = new System.Windows.Forms.Label();
      this.cmbMaterial01 = new System.Windows.Forms.ComboBox();
      this.cmbMaterial02 = new System.Windows.Forms.ComboBox();
      this.lblMaterial02 = new System.Windows.Forms.Label();
      this.gpbAcabados = new System.Windows.Forms.GroupBox();
      this.rbnAn = new System.Windows.Forms.RadioButton();
      this.rbnAl = new System.Windows.Forms.RadioButton();
      this.cmbListModelL0 = new System.Windows.Forms.ComboBox();
      this.lblSubNivelBomsL1 = new System.Windows.Forms.Label();
      this.cmbListModelL1 = new System.Windows.Forms.ComboBox();
      this.lblListadoBomL0 = new System.Windows.Forms.Label();
      this.tbpCreacionModelos = new System.Windows.Forms.TabPage();
      this.gpbModel0 = new System.Windows.Forms.GroupBox();
      this.txtEnglishDescription = new System.Windows.Forms.TextBox();
      this.txtLargeDescription = new System.Windows.Forms.TextBox();
      this.lblDescripcionIngles = new System.Windows.Forms.Label();
      this.lblDescripcionLarga = new System.Windows.Forms.Label();
      this.btnEliminar0 = new System.Windows.Forms.Button();
      this.btnEditar0 = new System.Windows.Forms.Button();
      this.btnCrear0 = new System.Windows.Forms.Button();
      this.dgvModeloL0 = new System.Windows.Forms.DataGridView();
      this.IdModeloL0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.NombreModeloL0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DescripcionModeloL0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.LargeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EnglishDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.txtDescripcionL0 = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.txtNombreL0 = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.gvbModelL1 = new System.Windows.Forms.GroupBox();
      this.cmbMfgCell = new System.Windows.Forms.ComboBox();
      this.lblMfg_Cell = new System.Windows.Forms.Label();
      this.dgvModeloL1 = new System.Windows.Forms.DataGridView();
      this.IdModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.NombreModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DescripcionModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DescripcionExt = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cmbModeloL0 = new System.Windows.Forms.ComboBox();
      this.label13 = new System.Windows.Forms.Label();
      this.btnEliminarL1 = new System.Windows.Forms.Button();
      this.btnEditarL1 = new System.Windows.Forms.Button();
      this.btnCrearL1 = new System.Windows.Forms.Button();
      this.txtDescripcionL1 = new System.Windows.Forms.TextBox();
      this.lblDescripcionModelo = new System.Windows.Forms.Label();
      this.txtNombreL1 = new System.Windows.Forms.TextBox();
      this.lblNombreModelo = new System.Windows.Forms.Label();
      this.tbpConfiguracionInicial = new System.Windows.Forms.TabPage();
      this.gpbSubMaterials = new System.Windows.Forms.GroupBox();
      this.lblSubMaterialDescription = new System.Windows.Forms.Label();
      this.dgvListSubMaterials = new System.Windows.Forms.DataGridView();
      this.IdSubMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.IdMaterialBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MaterialBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.NameSubMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DescriptionSubMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btnDeleteSubMaterial = new System.Windows.Forms.Button();
      this.txtDescriptionSubMaterial = new System.Windows.Forms.TextBox();
      this.btnEditSubtMaterial = new System.Windows.Forms.Button();
      this.cmbChoiceMaterial = new System.Windows.Forms.ComboBox();
      this.btnSaveSubMaterial = new System.Windows.Forms.Button();
      this.txtNameSubMaterial = new System.Windows.Forms.TextBox();
      this.lblChoice = new System.Windows.Forms.Label();
      this.lblSubMaterial = new System.Windows.Forms.Label();
      this.gpbTypeMaterial = new System.Windows.Forms.GroupBox();
      this.btnDeleteMaterial = new System.Windows.Forms.Button();
      this.btnEditMaterial = new System.Windows.Forms.Button();
      this.btnSaveMaterial = new System.Windows.Forms.Button();
      this.dgvListMaterials = new System.Windows.Forms.DataGridView();
      this.IdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.NameMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DescriptionMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.txtDescriptionMaterial = new System.Windows.Forms.TextBox();
      this.txtNameMaterial = new System.Windows.Forms.TextBox();
      this.lblDescripcionAccesorio = new System.Windows.Forms.Label();
      this.lblNombreMaterial = new System.Windows.Forms.Label();
      this.tbcControlPanel = new System.Windows.Forms.TabControl();
      this.tabPage1.SuspendLayout();
      this.groupBox5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvListRelaExistentes)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvFamilyRelaList)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvProccessRelaList)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvSecuencesRelaList)).BeginInit();
      this.groupBox4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvProcessList)).BeginInit();
      this.groupBox3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvSecuenceList)).BeginInit();
      this.tbpAsociarComponenteFormula.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvCombinacionesFormulas)).BeginInit();
      this.gpbShowFormulas.SuspendLayout();
      this.gpbShowConditional.SuspendLayout();
      this.gpbAcabadosAsociar.SuspendLayout();
      this.tbpClonado.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.gb_Destino.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvClonDestino)).BeginInit();
      this.gb_ClonOrigen.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvOrigenClon)).BeginInit();
      this.tbpCondicionales.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pb_BuscarFormula)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_ActualizarCondicional)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_VisualizarCondicional)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_EliminarCondicional)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_Guardar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_Agregar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_Eliminar)).BeginInit();
      this.tabCondicionales.SuspendLayout();
      this.tbp_Condicionales.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_Condicionales)).BeginInit();
      this.tbp_CondicionalMaster.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_CondicionalesMaster)).BeginInit();
      this.tbpFormulas.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_Formulas_Condicional)).BeginInit();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pb_EditarCondicional)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_GuardarCondicional)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_AgregarCondicionalForm)).BeginInit();
      this.tbPCatalogoFormulas.SuspendLayout();
      this.gpbCantidades.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_Formulas)).BeginInit();
      this.tbpConstruccionBomComponente.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvListComponents)).BeginInit();
      this.gpbAgregados.SuspendLayout();
      this.gpbAcabados.SuspendLayout();
      this.tbpCreacionModelos.SuspendLayout();
      this.gpbModel0.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvModeloL0)).BeginInit();
      this.gvbModelL1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvModeloL1)).BeginInit();
      this.tbpConfiguracionInicial.SuspendLayout();
      this.gpbSubMaterials.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvListSubMaterials)).BeginInit();
      this.gpbTypeMaterial.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvListMaterials)).BeginInit();
      this.tbcControlPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // Id_Formula
      // 
      this.Id_Formula.Name = "Id_Formula";
      // 
      // Condicional_Tipo
      // 
      this.Condicional_Tipo.Name = "Condicional_Tipo";
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.groupBox5);
      this.tabPage1.Controls.Add(this.groupBox4);
      this.tabPage1.Controls.Add(this.groupBox3);
      this.tabPage1.Location = new System.Drawing.Point(4, 29);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(1152, 719);
      this.tabPage1.TabIndex = 9;
      this.tabPage1.Text = "Configuración de secuencias";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // groupBox5
      // 
      this.groupBox5.Controls.Add(this.dgvListRelaExistentes);
      this.groupBox5.Controls.Add(this.btnCncelSecuenceProccessRel);
      this.groupBox5.Controls.Add(this.btnSecuenceProccessRel);
      this.groupBox5.Controls.Add(this.dgvFamilyRelaList);
      this.groupBox5.Controls.Add(this.dgvProccessRelaList);
      this.groupBox5.Controls.Add(this.dgvSecuencesRelaList);
      this.groupBox5.Controls.Add(this.txtSecuenceBOM);
      this.groupBox5.Controls.Add(this.btnDiableSecuenceProccessRel);
      this.groupBox5.Controls.Add(this.btnEditSecuenceProccessRel);
      this.groupBox5.Controls.Add(this.label39);
      this.groupBox5.Controls.Add(this.label41);
      this.groupBox5.Controls.Add(this.label40);
      this.groupBox5.Controls.Add(this.lblSeleccionSecuencia);
      this.groupBox5.Location = new System.Drawing.Point(760, 6);
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.Size = new System.Drawing.Size(371, 710);
      this.groupBox5.TabIndex = 2;
      this.groupBox5.TabStop = false;
      this.groupBox5.Text = "Mantenimiento Relación de secuencias vs Procesos";
      // 
      // dgvListRelaExistentes
      // 
      this.dgvListRelaExistentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvListRelaExistentes.Location = new System.Drawing.Point(6, 446);
      this.dgvListRelaExistentes.Name = "dgvListRelaExistentes";
      this.dgvListRelaExistentes.Size = new System.Drawing.Size(237, 258);
      this.dgvListRelaExistentes.TabIndex = 13;
      this.dgvListRelaExistentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListRelaExistentes_CellContentClick);
      // 
      // btnCncelSecuenceProccessRel
      // 
      this.btnCncelSecuenceProccessRel.Location = new System.Drawing.Point(249, 348);
      this.btnCncelSecuenceProccessRel.Name = "btnCncelSecuenceProccessRel";
      this.btnCncelSecuenceProccessRel.Size = new System.Drawing.Size(116, 43);
      this.btnCncelSecuenceProccessRel.TabIndex = 12;
      this.btnCncelSecuenceProccessRel.Text = "Cancelar";
      this.btnCncelSecuenceProccessRel.UseVisualStyleBackColor = true;
      this.btnCncelSecuenceProccessRel.Click += new System.EventHandler(this.btnCncelSecuenceProccessRel_Click);
      // 
      // btnSecuenceProccessRel
      // 
      this.btnSecuenceProccessRel.Location = new System.Drawing.Point(249, 303);
      this.btnSecuenceProccessRel.Name = "btnSecuenceProccessRel";
      this.btnSecuenceProccessRel.Size = new System.Drawing.Size(116, 43);
      this.btnSecuenceProccessRel.TabIndex = 11;
      this.btnSecuenceProccessRel.Text = "Relacionar";
      this.btnSecuenceProccessRel.UseVisualStyleBackColor = true;
      this.btnSecuenceProccessRel.Click += new System.EventHandler(this.btnSecuenceProccessRel_Click);
      // 
      // dgvFamilyRelaList
      // 
      this.dgvFamilyRelaList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvFamilyRelaList.Location = new System.Drawing.Point(232, 136);
      this.dgvFamilyRelaList.Name = "dgvFamilyRelaList";
      this.dgvFamilyRelaList.Size = new System.Drawing.Size(99, 150);
      this.dgvFamilyRelaList.TabIndex = 9;
      // 
      // dgvProccessRelaList
      // 
      this.dgvProccessRelaList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvProccessRelaList.Location = new System.Drawing.Point(119, 136);
      this.dgvProccessRelaList.Name = "dgvProccessRelaList";
      this.dgvProccessRelaList.Size = new System.Drawing.Size(99, 150);
      this.dgvProccessRelaList.TabIndex = 8;
      // 
      // dgvSecuencesRelaList
      // 
      this.dgvSecuencesRelaList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSecuencesRelaList.Location = new System.Drawing.Point(10, 136);
      this.dgvSecuencesRelaList.Name = "dgvSecuencesRelaList";
      this.dgvSecuencesRelaList.Size = new System.Drawing.Size(99, 150);
      this.dgvSecuencesRelaList.TabIndex = 7;
      // 
      // txtSecuenceBOM
      // 
      this.txtSecuenceBOM.Location = new System.Drawing.Point(178, 313);
      this.txtSecuenceBOM.Name = "txtSecuenceBOM";
      this.txtSecuenceBOM.Size = new System.Drawing.Size(44, 26);
      this.txtSecuenceBOM.TabIndex = 6;
      // 
      // btnDiableSecuenceProccessRel
      // 
      this.btnDiableSecuenceProccessRel.Location = new System.Drawing.Point(249, 558);
      this.btnDiableSecuenceProccessRel.Name = "btnDiableSecuenceProccessRel";
      this.btnDiableSecuenceProccessRel.Size = new System.Drawing.Size(116, 38);
      this.btnDiableSecuenceProccessRel.TabIndex = 5;
      this.btnDiableSecuenceProccessRel.Text = "Desactivar";
      this.btnDiableSecuenceProccessRel.UseVisualStyleBackColor = true;
      this.btnDiableSecuenceProccessRel.Click += new System.EventHandler(this.btnDiableSecuenceProccessRel_Click);
      // 
      // btnEditSecuenceProccessRel
      // 
      this.btnEditSecuenceProccessRel.Location = new System.Drawing.Point(249, 509);
      this.btnEditSecuenceProccessRel.Name = "btnEditSecuenceProccessRel";
      this.btnEditSecuenceProccessRel.Size = new System.Drawing.Size(116, 43);
      this.btnEditSecuenceProccessRel.TabIndex = 4;
      this.btnEditSecuenceProccessRel.Text = "Editar";
      this.btnEditSecuenceProccessRel.UseVisualStyleBackColor = true;
      this.btnEditSecuenceProccessRel.Click += new System.EventHandler(this.btnEditSecuenceProccessRel_Click);
      // 
      // label39
      // 
      this.label39.BackColor = System.Drawing.Color.Black;
      this.label39.Location = new System.Drawing.Point(-4, 408);
      this.label39.Name = "label39";
      this.label39.Size = new System.Drawing.Size(371, 2);
      this.label39.TabIndex = 3;
      this.label39.Text = "label39";
      // 
      // label41
      // 
      this.label41.Location = new System.Drawing.Point(228, 50);
      this.label41.Name = "label41";
      this.label41.Size = new System.Drawing.Size(92, 83);
      this.label41.TabIndex = 2;
      this.label41.Text = "3) Selecciona una familia";
      // 
      // label40
      // 
      this.label40.Location = new System.Drawing.Point(115, 50);
      this.label40.Name = "label40";
      this.label40.Size = new System.Drawing.Size(107, 83);
      this.label40.TabIndex = 1;
      this.label40.Text = "2) Selecciona un proceso";
      this.label40.Click += new System.EventHandler(this.lbProcessSelection);
      // 
      // lblSeleccionSecuencia
      // 
      this.lblSeleccionSecuencia.Location = new System.Drawing.Point(6, 50);
      this.lblSeleccionSecuencia.Name = "lblSeleccionSecuencia";
      this.lblSeleccionSecuencia.Size = new System.Drawing.Size(103, 83);
      this.lblSeleccionSecuencia.TabIndex = 0;
      this.lblSeleccionSecuencia.Text = "1) Selecciona una secuencia";
      this.lblSeleccionSecuencia.Click += new System.EventHandler(this.lblSeleccionSecuencia_Click);
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.btnEditProccess);
      this.groupBox4.Controls.Add(this.btnHideProcess);
      this.groupBox4.Controls.Add(this.btnDeleteProceso);
      this.groupBox4.Controls.Add(this.btnSaveProccess);
      this.groupBox4.Controls.Add(this.txtProcess);
      this.groupBox4.Controls.Add(this.dgvProcessList);
      this.groupBox4.Controls.Add(this.lblProcessList);
      this.groupBox4.Controls.Add(this.lblProcessName);
      this.groupBox4.Location = new System.Drawing.Point(380, 6);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(374, 710);
      this.groupBox4.TabIndex = 1;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Mantenimiento de procesos";
      // 
      // btnEditProccess
      // 
      this.btnEditProccess.AutoSize = true;
      this.btnEditProccess.Location = new System.Drawing.Point(100, 609);
      this.btnEditProccess.Name = "btnEditProccess";
      this.btnEditProccess.Size = new System.Drawing.Size(75, 42);
      this.btnEditProccess.TabIndex = 8;
      this.btnEditProccess.Text = "Editar";
      this.btnEditProccess.UseVisualStyleBackColor = true;
      this.btnEditProccess.Click += new System.EventHandler(this.btnEditProccess_Click);
      // 
      // btnHideProcess
      // 
      this.btnHideProcess.AutoSize = true;
      this.btnHideProcess.Location = new System.Drawing.Point(184, 609);
      this.btnHideProcess.Name = "btnHideProcess";
      this.btnHideProcess.Size = new System.Drawing.Size(94, 42);
      this.btnHideProcess.TabIndex = 9;
      this.btnHideProcess.Text = "Desactivar";
      this.btnHideProcess.UseVisualStyleBackColor = true;
      this.btnHideProcess.Click += new System.EventHandler(this.btnHideProcess_Click_1);
      // 
      // btnDeleteProceso
      // 
      this.btnDeleteProceso.AutoSize = true;
      this.btnDeleteProceso.Location = new System.Drawing.Point(284, 609);
      this.btnDeleteProceso.Name = "btnDeleteProceso";
      this.btnDeleteProceso.Size = new System.Drawing.Size(75, 42);
      this.btnDeleteProceso.TabIndex = 10;
      this.btnDeleteProceso.Text = "Eliminar";
      this.btnDeleteProceso.UseVisualStyleBackColor = true;
      this.btnDeleteProceso.Click += new System.EventHandler(this.btnDeleteProceso_Click_1);
      // 
      // btnSaveProccess
      // 
      this.btnSaveProccess.AutoSize = true;
      this.btnSaveProccess.Location = new System.Drawing.Point(16, 609);
      this.btnSaveProccess.Name = "btnSaveProccess";
      this.btnSaveProccess.Size = new System.Drawing.Size(78, 42);
      this.btnSaveProccess.TabIndex = 5;
      this.btnSaveProccess.Text = "Guardar";
      this.btnSaveProccess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnSaveProccess.UseVisualStyleBackColor = true;
      this.btnSaveProccess.Click += new System.EventHandler(this.btnSaveProccess_Click);
      // 
      // txtProcess
      // 
      this.txtProcess.Location = new System.Drawing.Point(29, 73);
      this.txtProcess.Name = "txtProcess";
      this.txtProcess.Size = new System.Drawing.Size(318, 26);
      this.txtProcess.TabIndex = 3;
      // 
      // dgvProcessList
      // 
      this.dgvProcessList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
      this.dgvProcessList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvProcessList.Location = new System.Drawing.Point(29, 141);
      this.dgvProcessList.Name = "dgvProcessList";
      this.dgvProcessList.Size = new System.Drawing.Size(318, 440);
      this.dgvProcessList.TabIndex = 2;
      // 
      // lblProcessList
      // 
      this.lblProcessList.AutoSize = true;
      this.lblProcessList.Location = new System.Drawing.Point(112, 113);
      this.lblProcessList.Name = "lblProcessList";
      this.lblProcessList.Size = new System.Drawing.Size(153, 20);
      this.lblProcessList.TabIndex = 1;
      this.lblProcessList.Text = "Procesos Existentes";
      // 
      // lblProcessName
      // 
      this.lblProcessName.AutoSize = true;
      this.lblProcessName.Location = new System.Drawing.Point(112, 50);
      this.lblProcessName.Name = "lblProcessName";
      this.lblProcessName.Size = new System.Drawing.Size(156, 20);
      this.lblProcessName.TabIndex = 0;
      this.lblProcessName.Text = "Nombre de procesos";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.btnDeleteSecuence);
      this.groupBox3.Controls.Add(this.btnHideSecuence);
      this.groupBox3.Controls.Add(this.btnEditSecuence);
      this.groupBox3.Controls.Add(this.btnSaveSecuence);
      this.groupBox3.Controls.Add(this.dgvSecuenceList);
      this.groupBox3.Controls.Add(this.lblSequenceList);
      this.groupBox3.Controls.Add(this.txtSequence);
      this.groupBox3.Controls.Add(this.lblSecuenceName);
      this.groupBox3.Location = new System.Drawing.Point(3, 6);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(371, 710);
      this.groupBox3.TabIndex = 0;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Mantenimiento de secuencias";
      // 
      // btnDeleteSecuence
      // 
      this.btnDeleteSecuence.AutoSize = true;
      this.btnDeleteSecuence.Location = new System.Drawing.Point(282, 615);
      this.btnDeleteSecuence.Name = "btnDeleteSecuence";
      this.btnDeleteSecuence.Size = new System.Drawing.Size(75, 42);
      this.btnDeleteSecuence.TabIndex = 7;
      this.btnDeleteSecuence.Text = "Eliminar";
      this.btnDeleteSecuence.UseVisualStyleBackColor = true;
      this.btnDeleteSecuence.Click += new System.EventHandler(this.btnDeleteSecuence_Click);
      // 
      // btnHideSecuence
      // 
      this.btnHideSecuence.AutoSize = true;
      this.btnHideSecuence.Location = new System.Drawing.Point(182, 615);
      this.btnHideSecuence.Name = "btnHideSecuence";
      this.btnHideSecuence.Size = new System.Drawing.Size(94, 42);
      this.btnHideSecuence.TabIndex = 6;
      this.btnHideSecuence.Text = "Desactivar";
      this.btnHideSecuence.UseVisualStyleBackColor = true;
      this.btnHideSecuence.Click += new System.EventHandler(this.btnHideSecuence_Click);
      // 
      // btnEditSecuence
      // 
      this.btnEditSecuence.AutoSize = true;
      this.btnEditSecuence.Location = new System.Drawing.Point(101, 615);
      this.btnEditSecuence.Name = "btnEditSecuence";
      this.btnEditSecuence.Size = new System.Drawing.Size(75, 42);
      this.btnEditSecuence.TabIndex = 5;
      this.btnEditSecuence.Text = "Editar";
      this.btnEditSecuence.UseVisualStyleBackColor = true;
      this.btnEditSecuence.Click += new System.EventHandler(this.btnEditSecuence_Click);
      // 
      // btnSaveSecuence
      // 
      this.btnSaveSecuence.AutoSize = true;
      this.btnSaveSecuence.Location = new System.Drawing.Point(17, 615);
      this.btnSaveSecuence.Name = "btnSaveSecuence";
      this.btnSaveSecuence.Size = new System.Drawing.Size(78, 42);
      this.btnSaveSecuence.TabIndex = 4;
      this.btnSaveSecuence.Text = "Guardar";
      this.btnSaveSecuence.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnSaveSecuence.UseVisualStyleBackColor = true;
      this.btnSaveSecuence.Click += new System.EventHandler(this.btnSaveSecuence_Click);
      // 
      // dgvSecuenceList
      // 
      this.dgvSecuenceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSecuenceList.Location = new System.Drawing.Point(32, 142);
      this.dgvSecuenceList.Name = "dgvSecuenceList";
      this.dgvSecuenceList.Size = new System.Drawing.Size(306, 440);
      this.dgvSecuenceList.TabIndex = 3;
      this.dgvSecuenceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSecuenceList_CellContentClick);
      this.dgvSecuenceList.SelectionChanged += new System.EventHandler(this.dgvSecuenceList_SelectionChanged);
      // 
      // lblSequenceList
      // 
      this.lblSequenceList.AutoSize = true;
      this.lblSequenceList.Location = new System.Drawing.Point(108, 119);
      this.lblSequenceList.Name = "lblSequenceList";
      this.lblSequenceList.Size = new System.Drawing.Size(168, 20);
      this.lblSequenceList.TabIndex = 2;
      this.lblSequenceList.Text = "Secuencias existentes";
      this.lblSequenceList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // txtSequence
      // 
      this.txtSequence.Location = new System.Drawing.Point(32, 79);
      this.txtSequence.Name = "txtSequence";
      this.txtSequence.Size = new System.Drawing.Size(306, 26);
      this.txtSequence.TabIndex = 1;
      this.txtSequence.TextChanged += new System.EventHandler(this.txtSequence_TextChanged);
      this.txtSequence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSequence_KeyPress);
      // 
      // lblSecuenceName
      // 
      this.lblSecuenceName.AutoSize = true;
      this.lblSecuenceName.Location = new System.Drawing.Point(108, 56);
      this.lblSecuenceName.Name = "lblSecuenceName";
      this.lblSecuenceName.Size = new System.Drawing.Size(163, 20);
      this.lblSecuenceName.TabIndex = 0;
      this.lblSecuenceName.Text = "Nombre de secuencia";
      this.lblSecuenceName.Click += new System.EventHandler(this.lblSecuenceName_Click);
      // 
      // tbpAsociarComponenteFormula
      // 
      this.tbpAsociarComponenteFormula.BackColor = System.Drawing.SystemColors.Window;
      this.tbpAsociarComponenteFormula.Controls.Add(this.label36);
      this.tbpAsociarComponenteFormula.Controls.Add(this.label35);
      this.tbpAsociarComponenteFormula.Controls.Add(this.txt_Descripcion);
      this.tbpAsociarComponenteFormula.Controls.Add(this.txt_Linea);
      this.tbpAsociarComponenteFormula.Controls.Add(this.txt_Seccion);
      this.tbpAsociarComponenteFormula.Controls.Add(this.tb_NumeroParte);
      this.tbpAsociarComponenteFormula.Controls.Add(this.label34);
      this.tbpAsociarComponenteFormula.Controls.Add(this.btn_GuardarFormula);
      this.tbpAsociarComponenteFormula.Controls.Add(this.dgvCombinacionesFormulas);
      this.tbpAsociarComponenteFormula.Controls.Add(this.label20);
      this.tbpAsociarComponenteFormula.Controls.Add(this.label5);
      this.tbpAsociarComponenteFormula.Controls.Add(this.label6);
      this.tbpAsociarComponenteFormula.Controls.Add(this.label4);
      this.tbpAsociarComponenteFormula.Controls.Add(this.cb_FormulaPeso);
      this.tbpAsociarComponenteFormula.Controls.Add(this.cb_FormulaMedida);
      this.tbpAsociarComponenteFormula.Controls.Add(this.cb_FormulaCantidad);
      this.tbpAsociarComponenteFormula.Controls.Add(this.label14);
      this.tbpAsociarComponenteFormula.Controls.Add(this.label17);
      this.tbpAsociarComponenteFormula.Controls.Add(this.label19);
      this.tbpAsociarComponenteFormula.Controls.Add(this.cb_FormulaTotal);
      this.tbpAsociarComponenteFormula.Controls.Add(this.cb_CondicionalesMedida);
      this.tbpAsociarComponenteFormula.Controls.Add(this.cb_CondicionalesCantidad);
      this.tbpAsociarComponenteFormula.Controls.Add(this.btn_Clonar);
      this.tbpAsociarComponenteFormula.Controls.Add(this.btnEditarFormulas);
      this.tbpAsociarComponenteFormula.Controls.Add(this.cmbListadoModelos);
      this.tbpAsociarComponenteFormula.Controls.Add(this.lblTipoBom);
      this.tbpAsociarComponenteFormula.Controls.Add(this.gpbShowFormulas);
      this.tbpAsociarComponenteFormula.Controls.Add(this.gpbShowConditional);
      this.tbpAsociarComponenteFormula.Controls.Add(this.gpbAcabadosAsociar);
      this.tbpAsociarComponenteFormula.Controls.Add(this.btnAsociar);
      this.tbpAsociarComponenteFormula.Controls.Add(this.btnBuscarCombinacionesComponentes);
      this.tbpAsociarComponenteFormula.Controls.Add(this.cmbCombinacionesBoms);
      this.tbpAsociarComponenteFormula.Controls.Add(this.lblCombinaciones);
      this.tbpAsociarComponenteFormula.Location = new System.Drawing.Point(4, 29);
      this.tbpAsociarComponenteFormula.Margin = new System.Windows.Forms.Padding(4);
      this.tbpAsociarComponenteFormula.Name = "tbpAsociarComponenteFormula";
      this.tbpAsociarComponenteFormula.Padding = new System.Windows.Forms.Padding(4);
      this.tbpAsociarComponenteFormula.Size = new System.Drawing.Size(1152, 719);
      this.tbpAsociarComponenteFormula.TabIndex = 3;
      this.tbpAsociarComponenteFormula.Text = "Asociar componentes formulas";
      // 
      // label36
      // 
      this.label36.AutoSize = true;
      this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label36.Location = new System.Drawing.Point(756, 501);
      this.label36.Name = "label36";
      this.label36.Size = new System.Drawing.Size(92, 20);
      this.label36.TabIndex = 116;
      this.label36.Text = "Descripcion";
      // 
      // label35
      // 
      this.label35.AutoSize = true;
      this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label35.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label35.Location = new System.Drawing.Point(387, 501);
      this.label35.Name = "label35";
      this.label35.Size = new System.Drawing.Size(48, 20);
      this.label35.TabIndex = 115;
      this.label35.Text = "Linea";
      // 
      // txt_Descripcion
      // 
      this.txt_Descripcion.Location = new System.Drawing.Point(760, 524);
      this.txt_Descripcion.Name = "txt_Descripcion";
      this.txt_Descripcion.Size = new System.Drawing.Size(358, 26);
      this.txt_Descripcion.TabIndex = 114;
      // 
      // txt_Linea
      // 
      this.txt_Linea.Location = new System.Drawing.Point(385, 524);
      this.txt_Linea.Name = "txt_Linea";
      this.txt_Linea.Size = new System.Drawing.Size(334, 26);
      this.txt_Linea.TabIndex = 113;
      // 
      // txt_Seccion
      // 
      this.txt_Seccion.Location = new System.Drawing.Point(31, 524);
      this.txt_Seccion.Name = "txt_Seccion";
      this.txt_Seccion.Size = new System.Drawing.Size(306, 26);
      this.txt_Seccion.TabIndex = 112;
      // 
      // tb_NumeroParte
      // 
      this.tb_NumeroParte.Location = new System.Drawing.Point(178, 357);
      this.tb_NumeroParte.Multiline = true;
      this.tb_NumeroParte.Name = "tb_NumeroParte";
      this.tb_NumeroParte.ReadOnly = true;
      this.tb_NumeroParte.Size = new System.Drawing.Size(541, 25);
      this.tb_NumeroParte.TabIndex = 95;
      // 
      // label34
      // 
      this.label34.AutoSize = true;
      this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label34.Location = new System.Drawing.Point(32, 501);
      this.label34.Name = "label34";
      this.label34.Size = new System.Drawing.Size(66, 20);
      this.label34.TabIndex = 111;
      this.label34.Text = "Seccion";
      // 
      // btn_GuardarFormula
      // 
      this.btn_GuardarFormula.Location = new System.Drawing.Point(761, 357);
      this.btn_GuardarFormula.Name = "btn_GuardarFormula";
      this.btn_GuardarFormula.Size = new System.Drawing.Size(125, 31);
      this.btn_GuardarFormula.TabIndex = 110;
      this.btn_GuardarFormula.Text = "Guardar";
      this.btn_GuardarFormula.UseVisualStyleBackColor = true;
      this.btn_GuardarFormula.Click += new System.EventHandler(this.btn_GuardarFormula_Click);
      // 
      // dgvCombinacionesFormulas
      // 
      this.dgvCombinacionesFormulas.AllowUserToAddRows = false;
      this.dgvCombinacionesFormulas.AllowUserToDeleteRows = false;
      this.dgvCombinacionesFormulas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvCombinacionesFormulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvCombinacionesFormulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Linea,
            this.IdDetalleComp_,
            this.IdCombinacion_,
            this.IdComponente,
            this.Editar,
            this.ItemnoComponent,
            this.NameComponent,
            this.ConditionalQty,
            this.ConditionalMd,
            this.FormulaQty,
            this.FormulaMd,
            this.FormulaTotal,
            this.FormulaPeso,
            this.Seccion,
            this.Descripcion});
      this.dgvCombinacionesFormulas.Location = new System.Drawing.Point(13, 69);
      this.dgvCombinacionesFormulas.Margin = new System.Windows.Forms.Padding(4);
      this.dgvCombinacionesFormulas.Name = "dgvCombinacionesFormulas";
      this.dgvCombinacionesFormulas.Size = new System.Drawing.Size(1128, 281);
      this.dgvCombinacionesFormulas.TabIndex = 109;
      this.dgvCombinacionesFormulas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCombinacionesFormulas_CellContentClick);
      // 
      // Linea
      // 
      this.Linea.HeaderText = "Linea";
      this.Linea.Name = "Linea";
      // 
      // IdDetalleComp_
      // 
      this.IdDetalleComp_.HeaderText = "Id";
      this.IdDetalleComp_.Name = "IdDetalleComp_";
      this.IdDetalleComp_.Visible = false;
      // 
      // IdCombinacion_
      // 
      this.IdCombinacion_.HeaderText = "IdCombinacion";
      this.IdCombinacion_.Name = "IdCombinacion_";
      this.IdCombinacion_.Visible = false;
      // 
      // IdComponente
      // 
      this.IdComponente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.IdComponente.HeaderText = "IdComponente";
      this.IdComponente.Name = "IdComponente";
      this.IdComponente.Visible = false;
      // 
      // Editar
      // 
      this.Editar.HeaderText = "Seleccion para editar";
      this.Editar.Name = "Editar";
      this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      // 
      // ItemnoComponent
      // 
      this.ItemnoComponent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.ItemnoComponent.FillWeight = 80F;
      this.ItemnoComponent.HeaderText = "Número de parte";
      this.ItemnoComponent.Name = "ItemnoComponent";
      this.ItemnoComponent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.ItemnoComponent.Width = 106;
      // 
      // NameComponent
      // 
      this.NameComponent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.NameComponent.HeaderText = "Nombre componente";
      this.NameComponent.Name = "NameComponent";
      this.NameComponent.Width = 167;
      // 
      // ConditionalQty
      // 
      this.ConditionalQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.ConditionalQty.FillWeight = 200F;
      this.ConditionalQty.HeaderText = "Condicionales para cantidad";
      this.ConditionalQty.Name = "ConditionalQty";
      this.ConditionalQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.ConditionalQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.ConditionalQty.Width = 139;
      // 
      // ConditionalMd
      // 
      this.ConditionalMd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.ConditionalMd.FillWeight = 200F;
      this.ConditionalMd.HeaderText = "Condicionales para medidas";
      this.ConditionalMd.Name = "ConditionalMd";
      this.ConditionalMd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.ConditionalMd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.ConditionalMd.Width = 139;
      // 
      // FormulaQty
      // 
      this.FormulaQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.FormulaQty.FillWeight = 150F;
      this.FormulaQty.HeaderText = "Formula cantidad";
      this.FormulaQty.Name = "FormulaQty";
      this.FormulaQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.FormulaQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.FormulaQty.Width = 124;
      // 
      // FormulaMd
      // 
      this.FormulaMd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.FormulaMd.FillWeight = 150F;
      this.FormulaMd.HeaderText = "Formula medida";
      this.FormulaMd.Name = "FormulaMd";
      this.FormulaMd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.FormulaMd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.FormulaMd.Width = 116;
      // 
      // FormulaTotal
      // 
      this.FormulaTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.FormulaTotal.FillWeight = 150F;
      this.FormulaTotal.HeaderText = "Formula total";
      this.FormulaTotal.Name = "FormulaTotal";
      this.FormulaTotal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.FormulaTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.FormulaTotal.Width = 97;
      // 
      // FormulaPeso
      // 
      this.FormulaPeso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.FormulaPeso.HeaderText = "Formula peso (Kg)";
      this.FormulaPeso.Name = "FormulaPeso";
      this.FormulaPeso.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.FormulaPeso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.FormulaPeso.Width = 105;
      // 
      // Seccion
      // 
      this.Seccion.HeaderText = "Seccion";
      this.Seccion.Name = "Seccion";
      // 
      // Descripcion
      // 
      this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
      this.Descripcion.HeaderText = "Descripcion";
      this.Descripcion.Name = "Descripcion";
      this.Descripcion.Width = 117;
      // 
      // label20
      // 
      this.label20.AutoSize = true;
      this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label20.Location = new System.Drawing.Point(32, 360);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(128, 20);
      this.label20.TabIndex = 108;
      this.label20.Text = "Numero de parte";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label5.Location = new System.Drawing.Point(757, 444);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(106, 20);
      this.label5.TabIndex = 107;
      this.label5.Text = "Formula peso";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label6.Location = new System.Drawing.Point(383, 444);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(123, 20);
      this.label6.TabIndex = 106;
      this.label6.Text = "Formula medida";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label4.Location = new System.Drawing.Point(32, 444);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(132, 20);
      this.label4.TabIndex = 105;
      this.label4.Text = "Formula cantidad";
      // 
      // cb_FormulaPeso
      // 
      this.cb_FormulaPeso.FormattingEnabled = true;
      this.cb_FormulaPeso.Location = new System.Drawing.Point(761, 465);
      this.cb_FormulaPeso.Name = "cb_FormulaPeso";
      this.cb_FormulaPeso.Size = new System.Drawing.Size(359, 28);
      this.cb_FormulaPeso.TabIndex = 104;
      this.cb_FormulaPeso.SelectedValueChanged += new System.EventHandler(this.cb_FormulaPeso_SelectedValueChanged);
      // 
      // cb_FormulaMedida
      // 
      this.cb_FormulaMedida.FormattingEnabled = true;
      this.cb_FormulaMedida.Location = new System.Drawing.Point(387, 465);
      this.cb_FormulaMedida.Name = "cb_FormulaMedida";
      this.cb_FormulaMedida.Size = new System.Drawing.Size(333, 28);
      this.cb_FormulaMedida.TabIndex = 103;
      this.cb_FormulaMedida.SelectedValueChanged += new System.EventHandler(this.cb_FormulaMedida_SelectedValueChanged);
      // 
      // cb_FormulaCantidad
      // 
      this.cb_FormulaCantidad.FormattingEnabled = true;
      this.cb_FormulaCantidad.Location = new System.Drawing.Point(31, 465);
      this.cb_FormulaCantidad.Name = "cb_FormulaCantidad";
      this.cb_FormulaCantidad.Size = new System.Drawing.Size(307, 28);
      this.cb_FormulaCantidad.TabIndex = 102;
      this.cb_FormulaCantidad.SelectedValueChanged += new System.EventHandler(this.cb_FormulaCantidad_SelectedValueChanged);
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label14.Location = new System.Drawing.Point(756, 391);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(102, 20);
      this.label14.TabIndex = 101;
      this.label14.Text = "Formula total";
      // 
      // label17
      // 
      this.label17.AutoSize = true;
      this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label17.Location = new System.Drawing.Point(382, 391);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(164, 20);
      this.label17.TabIndex = 100;
      this.label17.Text = "Condicionales medida";
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label19.Location = new System.Drawing.Point(31, 391);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(173, 20);
      this.label19.TabIndex = 99;
      this.label19.Text = "Condicionales cantidad";
      // 
      // cb_FormulaTotal
      // 
      this.cb_FormulaTotal.FormattingEnabled = true;
      this.cb_FormulaTotal.Location = new System.Drawing.Point(760, 412);
      this.cb_FormulaTotal.Name = "cb_FormulaTotal";
      this.cb_FormulaTotal.Size = new System.Drawing.Size(359, 28);
      this.cb_FormulaTotal.TabIndex = 98;
      this.cb_FormulaTotal.SelectedValueChanged += new System.EventHandler(this.cb_FormulaTotal_SelectedValueChanged);
      // 
      // cb_CondicionalesMedida
      // 
      this.cb_CondicionalesMedida.FormattingEnabled = true;
      this.cb_CondicionalesMedida.Location = new System.Drawing.Point(386, 412);
      this.cb_CondicionalesMedida.Name = "cb_CondicionalesMedida";
      this.cb_CondicionalesMedida.Size = new System.Drawing.Size(333, 28);
      this.cb_CondicionalesMedida.TabIndex = 97;
      this.cb_CondicionalesMedida.SelectedValueChanged += new System.EventHandler(this.cb_CondicionalesMedida_SelectedValueChanged);
      // 
      // cb_CondicionalesCantidad
      // 
      this.cb_CondicionalesCantidad.FormattingEnabled = true;
      this.cb_CondicionalesCantidad.Location = new System.Drawing.Point(31, 412);
      this.cb_CondicionalesCantidad.Name = "cb_CondicionalesCantidad";
      this.cb_CondicionalesCantidad.Size = new System.Drawing.Size(306, 28);
      this.cb_CondicionalesCantidad.TabIndex = 96;
      this.cb_CondicionalesCantidad.SelectedValueChanged += new System.EventHandler(this.cb_CondicionalesCantidad_SelectedValueChanged);
      // 
      // btn_Clonar
      // 
      this.btn_Clonar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn_Clonar.Location = new System.Drawing.Point(993, 19);
      this.btn_Clonar.Margin = new System.Windows.Forms.Padding(4);
      this.btn_Clonar.Name = "btn_Clonar";
      this.btn_Clonar.Size = new System.Drawing.Size(76, 48);
      this.btn_Clonar.TabIndex = 63;
      this.btn_Clonar.Text = "Clonar";
      this.btn_Clonar.UseVisualStyleBackColor = true;
      this.btn_Clonar.Visible = false;
      this.btn_Clonar.Click += new System.EventHandler(this.btn_Clonar_Click);
      // 
      // btnEditarFormulas
      // 
      this.btnEditarFormulas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnEditarFormulas.Location = new System.Drawing.Point(907, 19);
      this.btnEditarFormulas.Margin = new System.Windows.Forms.Padding(4);
      this.btnEditarFormulas.Name = "btnEditarFormulas";
      this.btnEditarFormulas.Size = new System.Drawing.Size(76, 48);
      this.btnEditarFormulas.TabIndex = 9;
      this.btnEditarFormulas.Text = "Editar";
      this.btnEditarFormulas.UseVisualStyleBackColor = true;
      this.btnEditarFormulas.Click += new System.EventHandler(this.BtnEditarFormulas_Click);
      // 
      // cmbListadoModelos
      // 
      this.cmbListadoModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbListadoModelos.FormattingEnabled = true;
      this.cmbListadoModelos.Location = new System.Drawing.Point(16, 33);
      this.cmbListadoModelos.Margin = new System.Windows.Forms.Padding(4);
      this.cmbListadoModelos.Name = "cmbListadoModelos";
      this.cmbListadoModelos.Size = new System.Drawing.Size(287, 28);
      this.cmbListadoModelos.TabIndex = 1;
      // 
      // lblTipoBom
      // 
      this.lblTipoBom.AutoSize = true;
      this.lblTipoBom.Location = new System.Drawing.Point(11, 5);
      this.lblTipoBom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTipoBom.Name = "lblTipoBom";
      this.lblTipoBom.Size = new System.Drawing.Size(125, 20);
      this.lblTipoBom.TabIndex = 62;
      this.lblTipoBom.Text = "Listado modelos";
      // 
      // gpbShowFormulas
      // 
      this.gpbShowFormulas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.gpbShowFormulas.Controls.Add(this.txtShowFormulas);
      this.gpbShowFormulas.Location = new System.Drawing.Point(568, 560);
      this.gpbShowFormulas.Margin = new System.Windows.Forms.Padding(4);
      this.gpbShowFormulas.Name = "gpbShowFormulas";
      this.gpbShowFormulas.Padding = new System.Windows.Forms.Padding(4);
      this.gpbShowFormulas.Size = new System.Drawing.Size(581, 151);
      this.gpbShowFormulas.TabIndex = 60;
      this.gpbShowFormulas.TabStop = false;
      this.gpbShowFormulas.Text = "Visualizador de formulas";
      // 
      // txtShowFormulas
      // 
      this.txtShowFormulas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.txtShowFormulas.Enabled = false;
      this.txtShowFormulas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtShowFormulas.Location = new System.Drawing.Point(9, 25);
      this.txtShowFormulas.Margin = new System.Windows.Forms.Padding(4);
      this.txtShowFormulas.Multiline = true;
      this.txtShowFormulas.Name = "txtShowFormulas";
      this.txtShowFormulas.Size = new System.Drawing.Size(564, 118);
      this.txtShowFormulas.TabIndex = 0;
      // 
      // gpbShowConditional
      // 
      this.gpbShowConditional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.gpbShowConditional.Controls.Add(this.trvShowConditional);
      this.gpbShowConditional.Location = new System.Drawing.Point(13, 560);
      this.gpbShowConditional.Margin = new System.Windows.Forms.Padding(4);
      this.gpbShowConditional.Name = "gpbShowConditional";
      this.gpbShowConditional.Padding = new System.Windows.Forms.Padding(4);
      this.gpbShowConditional.Size = new System.Drawing.Size(547, 151);
      this.gpbShowConditional.TabIndex = 59;
      this.gpbShowConditional.TabStop = false;
      this.gpbShowConditional.Text = "Visualización de condicionales";
      // 
      // trvShowConditional
      // 
      this.trvShowConditional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.trvShowConditional.Location = new System.Drawing.Point(8, 25);
      this.trvShowConditional.Margin = new System.Windows.Forms.Padding(4);
      this.trvShowConditional.Name = "trvShowConditional";
      this.trvShowConditional.Size = new System.Drawing.Size(531, 118);
      this.trvShowConditional.TabIndex = 0;
      // 
      // gpbAcabadosAsociar
      // 
      this.gpbAcabadosAsociar.Controls.Add(this.rbnAnAsociar);
      this.gpbAcabadosAsociar.Controls.Add(this.rbnAlAsociar);
      this.gpbAcabadosAsociar.Location = new System.Drawing.Point(313, 5);
      this.gpbAcabadosAsociar.Margin = new System.Windows.Forms.Padding(4);
      this.gpbAcabadosAsociar.Name = "gpbAcabadosAsociar";
      this.gpbAcabadosAsociar.Padding = new System.Windows.Forms.Padding(4);
      this.gpbAcabadosAsociar.Size = new System.Drawing.Size(178, 56);
      this.gpbAcabadosAsociar.TabIndex = 58;
      this.gpbAcabadosAsociar.TabStop = false;
      this.gpbAcabadosAsociar.Text = "Tipo de componentes";
      // 
      // rbnAnAsociar
      // 
      this.rbnAnAsociar.AutoSize = true;
      this.rbnAnAsociar.Location = new System.Drawing.Point(80, 26);
      this.rbnAnAsociar.Margin = new System.Windows.Forms.Padding(4);
      this.rbnAnAsociar.Name = "rbnAnAsociar";
      this.rbnAnAsociar.Size = new System.Drawing.Size(49, 24);
      this.rbnAnAsociar.TabIndex = 3;
      this.rbnAnAsociar.TabStop = true;
      this.rbnAnAsociar.Text = "AN";
      this.rbnAnAsociar.UseVisualStyleBackColor = true;
      // 
      // rbnAlAsociar
      // 
      this.rbnAlAsociar.AutoSize = true;
      this.rbnAlAsociar.Location = new System.Drawing.Point(9, 26);
      this.rbnAlAsociar.Margin = new System.Windows.Forms.Padding(4);
      this.rbnAlAsociar.Name = "rbnAlAsociar";
      this.rbnAlAsociar.Size = new System.Drawing.Size(47, 24);
      this.rbnAlAsociar.TabIndex = 2;
      this.rbnAlAsociar.TabStop = true;
      this.rbnAlAsociar.Text = "AL";
      this.rbnAlAsociar.UseVisualStyleBackColor = true;
      // 
      // btnAsociar
      // 
      this.btnAsociar.Location = new System.Drawing.Point(816, 19);
      this.btnAsociar.Margin = new System.Windows.Forms.Padding(4);
      this.btnAsociar.Name = "btnAsociar";
      this.btnAsociar.Size = new System.Drawing.Size(83, 47);
      this.btnAsociar.TabIndex = 7;
      this.btnAsociar.Text = "Asociar";
      this.btnAsociar.UseVisualStyleBackColor = true;
      this.btnAsociar.Click += new System.EventHandler(this.btnAsociar_Click);
      // 
      // btnBuscarCombinacionesComponentes
      // 
      this.btnBuscarCombinacionesComponentes.Location = new System.Drawing.Point(503, 13);
      this.btnBuscarCombinacionesComponentes.Margin = new System.Windows.Forms.Padding(4);
      this.btnBuscarCombinacionesComponentes.Name = "btnBuscarCombinacionesComponentes";
      this.btnBuscarCombinacionesComponentes.Size = new System.Drawing.Size(103, 48);
      this.btnBuscarCombinacionesComponentes.TabIndex = 4;
      this.btnBuscarCombinacionesComponentes.Text = "Buscar";
      this.btnBuscarCombinacionesComponentes.UseVisualStyleBackColor = true;
      this.btnBuscarCombinacionesComponentes.Click += new System.EventHandler(this.BtnBuscarCombinacionesComponentes_Click);
      // 
      // cmbCombinacionesBoms
      // 
      this.cmbCombinacionesBoms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbCombinacionesBoms.FormattingEnabled = true;
      this.cmbCombinacionesBoms.Location = new System.Drawing.Point(614, 33);
      this.cmbCombinacionesBoms.Margin = new System.Windows.Forms.Padding(4);
      this.cmbCombinacionesBoms.Name = "cmbCombinacionesBoms";
      this.cmbCombinacionesBoms.Size = new System.Drawing.Size(194, 28);
      this.cmbCombinacionesBoms.TabIndex = 5;
      this.cmbCombinacionesBoms.SelectedIndexChanged += new System.EventHandler(this.CmbCombinacionesBoms_SelectedIndexChanged);
      // 
      // lblCombinaciones
      // 
      this.lblCombinaciones.AutoSize = true;
      this.lblCombinaciones.Location = new System.Drawing.Point(614, 4);
      this.lblCombinaciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblCombinaciones.Name = "lblCombinaciones";
      this.lblCombinaciones.Size = new System.Drawing.Size(118, 20);
      this.lblCombinaciones.TabIndex = 0;
      this.lblCombinaciones.Text = "Combinaciones";
      // 
      // tbpClonado
      // 
      this.tbpClonado.Controls.Add(this.checkBox_AN);
      this.tbpClonado.Controls.Add(this.groupBox2);
      this.tbpClonado.Controls.Add(this.cbCentroTrabajo);
      this.tbpClonado.Controls.Add(this.label33);
      this.tbpClonado.Controls.Add(this.cbFamilias);
      this.tbpClonado.Controls.Add(this.label32);
      this.tbpClonado.Controls.Add(this.btnTransferirRegistro);
      this.tbpClonado.Controls.Add(this.btnBuscarComponentes);
      this.tbpClonado.Controls.Add(this.btn_SeleccionarTodo);
      this.tbpClonado.Controls.Add(this.cb_Modelos);
      this.tbpClonado.Controls.Add(this.label29);
      this.tbpClonado.Controls.Add(this.cb_Secciones);
      this.tbpClonado.Controls.Add(this.btn_NuevoModelo);
      this.tbpClonado.Controls.Add(this.txtNuevoModelo);
      this.tbpClonado.Controls.Add(this.label28);
      this.tbpClonado.Controls.Add(this.label27);
      this.tbpClonado.Controls.Add(this.label26);
      this.tbpClonado.Controls.Add(this.gb_Destino);
      this.tbpClonado.Controls.Add(this.gb_ClonOrigen);
      this.tbpClonado.Controls.Add(this.cb_Familias);
      this.tbpClonado.Location = new System.Drawing.Point(4, 29);
      this.tbpClonado.Name = "tbpClonado";
      this.tbpClonado.Size = new System.Drawing.Size(1152, 719);
      this.tbpClonado.TabIndex = 8;
      this.tbpClonado.Text = "Clonado";
      this.tbpClonado.UseVisualStyleBackColor = true;
      // 
      // checkBox_AN
      // 
      this.checkBox_AN.AutoSize = true;
      this.checkBox_AN.Location = new System.Drawing.Point(998, 91);
      this.checkBox_AN.Name = "checkBox_AN";
      this.checkBox_AN.Size = new System.Drawing.Size(50, 24);
      this.checkBox_AN.TabIndex = 45;
      this.checkBox_AN.Text = "AN";
      this.checkBox_AN.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.tb_Descripcion);
      this.groupBox2.Controls.Add(this.label30);
      this.groupBox2.Controls.Add(this.label31);
      this.groupBox2.Controls.Add(this.tb_DestinoLinea);
      this.groupBox2.Controls.Add(this.btnGuardarComponente);
      this.groupBox2.Controls.Add(this.btnEliminarComponente);
      this.groupBox2.Location = new System.Drawing.Point(611, 205);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(533, 82);
      this.groupBox2.TabIndex = 44;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Editar componente";
      // 
      // tb_Descripcion
      // 
      this.tb_Descripcion.Location = new System.Drawing.Point(6, 43);
      this.tb_Descripcion.Name = "tb_Descripcion";
      this.tb_Descripcion.Size = new System.Drawing.Size(241, 26);
      this.tb_Descripcion.TabIndex = 29;
      // 
      // label30
      // 
      this.label30.AutoSize = true;
      this.label30.Location = new System.Drawing.Point(2, 23);
      this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label30.Name = "label30";
      this.label30.Size = new System.Drawing.Size(92, 20);
      this.label30.TabIndex = 28;
      this.label30.Text = "Descripcion";
      // 
      // label31
      // 
      this.label31.AutoSize = true;
      this.label31.Location = new System.Drawing.Point(261, 23);
      this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label31.Name = "label31";
      this.label31.Size = new System.Drawing.Size(48, 20);
      this.label31.TabIndex = 30;
      this.label31.Text = "Linea";
      // 
      // tb_DestinoLinea
      // 
      this.tb_DestinoLinea.Location = new System.Drawing.Point(265, 43);
      this.tb_DestinoLinea.Name = "tb_DestinoLinea";
      this.tb_DestinoLinea.Size = new System.Drawing.Size(155, 26);
      this.tb_DestinoLinea.TabIndex = 31;
      // 
      // btnGuardarComponente
      // 
      this.btnGuardarComponente.BackColor = System.Drawing.Color.White;
      this.btnGuardarComponente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuardarComponente.BackgroundImage")));
      this.btnGuardarComponente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnGuardarComponente.Location = new System.Drawing.Point(427, 31);
      this.btnGuardarComponente.Name = "btnGuardarComponente";
      this.btnGuardarComponente.Size = new System.Drawing.Size(45, 38);
      this.btnGuardarComponente.TabIndex = 35;
      this.btnGuardarComponente.UseVisualStyleBackColor = false;
      this.btnGuardarComponente.Click += new System.EventHandler(this.btnGuardarComponente_Click);
      // 
      // btnEliminarComponente
      // 
      this.btnEliminarComponente.BackColor = System.Drawing.Color.White;
      this.btnEliminarComponente.BackgroundImage = global::BOM_Builder.Properties.Resources.error;
      this.btnEliminarComponente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnEliminarComponente.Location = new System.Drawing.Point(482, 31);
      this.btnEliminarComponente.Name = "btnEliminarComponente";
      this.btnEliminarComponente.Size = new System.Drawing.Size(45, 38);
      this.btnEliminarComponente.TabIndex = 36;
      this.btnEliminarComponente.UseVisualStyleBackColor = false;
      this.btnEliminarComponente.Click += new System.EventHandler(this.btnEliminarComponente_Click);
      // 
      // cbCentroTrabajo
      // 
      this.cbCentroTrabajo.FormattingEnabled = true;
      this.cbCentroTrabajo.Location = new System.Drawing.Point(611, 155);
      this.cbCentroTrabajo.Name = "cbCentroTrabajo";
      this.cbCentroTrabajo.Size = new System.Drawing.Size(468, 28);
      this.cbCentroTrabajo.TabIndex = 43;
      // 
      // label33
      // 
      this.label33.AutoSize = true;
      this.label33.Location = new System.Drawing.Point(607, 135);
      this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label33.Name = "label33";
      this.label33.Size = new System.Drawing.Size(132, 20);
      this.label33.TabIndex = 42;
      this.label33.Text = "Centro de trabajo";
      // 
      // cbFamilias
      // 
      this.cbFamilias.FormattingEnabled = true;
      this.cbFamilias.Location = new System.Drawing.Point(611, 87);
      this.cbFamilias.Name = "cbFamilias";
      this.cbFamilias.Size = new System.Drawing.Size(357, 28);
      this.cbFamilias.TabIndex = 39;
      // 
      // label32
      // 
      this.label32.AutoSize = true;
      this.label32.Location = new System.Drawing.Point(607, 67);
      this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label32.Name = "label32";
      this.label32.Size = new System.Drawing.Size(59, 20);
      this.label32.TabIndex = 38;
      this.label32.Text = "Familia";
      // 
      // btnTransferirRegistro
      // 
      this.btnTransferirRegistro.BackColor = System.Drawing.Color.White;
      this.btnTransferirRegistro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTransferirRegistro.BackgroundImage")));
      this.btnTransferirRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnTransferirRegistro.Location = new System.Drawing.Point(563, 260);
      this.btnTransferirRegistro.Name = "btnTransferirRegistro";
      this.btnTransferirRegistro.Size = new System.Drawing.Size(31, 26);
      this.btnTransferirRegistro.TabIndex = 37;
      this.btnTransferirRegistro.UseVisualStyleBackColor = false;
      this.btnTransferirRegistro.Click += new System.EventHandler(this.btnTransferirRegistro_Click);
      // 
      // btnBuscarComponentes
      // 
      this.btnBuscarComponentes.Location = new System.Drawing.Point(317, 122);
      this.btnBuscarComponentes.Name = "btnBuscarComponentes";
      this.btnBuscarComponentes.Size = new System.Drawing.Size(103, 50);
      this.btnBuscarComponentes.TabIndex = 34;
      this.btnBuscarComponentes.Text = "Buscar";
      this.btnBuscarComponentes.UseVisualStyleBackColor = true;
      this.btnBuscarComponentes.Click += new System.EventHandler(this.btnBuscarComponentes_Click);
      // 
      // btn_SeleccionarTodo
      // 
      this.btn_SeleccionarTodo.BackColor = System.Drawing.Color.Transparent;
      this.btn_SeleccionarTodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btn_SeleccionarTodo.Location = new System.Drawing.Point(426, 122);
      this.btn_SeleccionarTodo.Name = "btn_SeleccionarTodo";
      this.btn_SeleccionarTodo.Size = new System.Drawing.Size(121, 50);
      this.btn_SeleccionarTodo.TabIndex = 27;
      this.btn_SeleccionarTodo.Text = "Seleccionar todo";
      this.btn_SeleccionarTodo.UseVisualStyleBackColor = false;
      this.btn_SeleccionarTodo.Click += new System.EventHandler(this.btn_SeleccionarTodo_Click);
      // 
      // cb_Modelos
      // 
      this.cb_Modelos.FormattingEnabled = true;
      this.cb_Modelos.Location = new System.Drawing.Point(317, 48);
      this.cb_Modelos.Name = "cb_Modelos";
      this.cb_Modelos.Size = new System.Drawing.Size(230, 28);
      this.cb_Modelos.TabIndex = 26;
      this.cb_Modelos.SelectedIndexChanged += new System.EventHandler(this.cb_Modelos_SelectedIndexChanged);
      // 
      // label29
      // 
      this.label29.AutoSize = true;
      this.label29.Location = new System.Drawing.Point(17, 113);
      this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label29.Name = "label29";
      this.label29.Size = new System.Drawing.Size(66, 20);
      this.label29.TabIndex = 25;
      this.label29.Text = "Seccion";
      // 
      // cb_Secciones
      // 
      this.cb_Secciones.FormattingEnabled = true;
      this.cb_Secciones.Location = new System.Drawing.Point(21, 136);
      this.cb_Secciones.Name = "cb_Secciones";
      this.cb_Secciones.Size = new System.Drawing.Size(268, 28);
      this.cb_Secciones.TabIndex = 24;
      // 
      // btn_NuevoModelo
      // 
      this.btn_NuevoModelo.Location = new System.Drawing.Point(980, 29);
      this.btn_NuevoModelo.Name = "btn_NuevoModelo";
      this.btn_NuevoModelo.Size = new System.Drawing.Size(99, 29);
      this.btn_NuevoModelo.TabIndex = 23;
      this.btn_NuevoModelo.Text = "Clonar";
      this.btn_NuevoModelo.UseVisualStyleBackColor = true;
      this.btn_NuevoModelo.Click += new System.EventHandler(this.btn_NuevoModelo_Click);
      // 
      // txtNuevoModelo
      // 
      this.txtNuevoModelo.Location = new System.Drawing.Point(611, 29);
      this.txtNuevoModelo.Name = "txtNuevoModelo";
      this.txtNuevoModelo.Size = new System.Drawing.Size(357, 26);
      this.txtNuevoModelo.TabIndex = 22;
      // 
      // label28
      // 
      this.label28.AutoSize = true;
      this.label28.Location = new System.Drawing.Point(607, 6);
      this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label28.Name = "label28";
      this.label28.Size = new System.Drawing.Size(168, 20);
      this.label28.TabIndex = 21;
      this.label28.Text = "Nombre nuevo modelo";
      // 
      // label27
      // 
      this.label27.AutoSize = true;
      this.label27.Location = new System.Drawing.Point(313, 6);
      this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label27.Name = "label27";
      this.label27.Size = new System.Drawing.Size(61, 20);
      this.label27.TabIndex = 18;
      this.label27.Text = "Modelo";
      // 
      // label26
      // 
      this.label26.AutoSize = true;
      this.label26.Location = new System.Drawing.Point(17, 14);
      this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(59, 20);
      this.label26.TabIndex = 17;
      this.label26.Text = "Familia";
      // 
      // gb_Destino
      // 
      this.gb_Destino.Controls.Add(this.dgvClonDestino);
      this.gb_Destino.Location = new System.Drawing.Point(586, 292);
      this.gb_Destino.Name = "gb_Destino";
      this.gb_Destino.Size = new System.Drawing.Size(558, 424);
      this.gb_Destino.TabIndex = 5;
      this.gb_Destino.TabStop = false;
      this.gb_Destino.Text = "Destino";
      // 
      // dgvClonDestino
      // 
      this.dgvClonDestino.AllowUserToAddRows = false;
      this.dgvClonDestino.AllowUserToDeleteRows = false;
      this.dgvClonDestino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvClonDestino.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Destino_Editar,
            this.Destino_IdCombinacion,
            this.Destino_IdDetalleComp,
            this.Destino_Itemno,
            this.Destino_IdComponente,
            this.Destino_FormulaQty,
            this.Destino_FormulaMd,
            this.Destino_FormulaTotal,
            this.Destino_FormulaPeso,
            this.Destino_CondicionalQty,
            this.Destino_CondicionalMd,
            this.Destino_TypeCondicionalMd,
            this.Destino_TypeCondicionalQty,
            this.Destino_IdCompuestoQty,
            this.Destino_IdCompuestoMd,
            this.Destino_Descripcion,
            this.Destino_Seccion,
            this.Destino_Linea});
      this.dgvClonDestino.Location = new System.Drawing.Point(6, 25);
      this.dgvClonDestino.Name = "dgvClonDestino";
      this.dgvClonDestino.Size = new System.Drawing.Size(546, 393);
      this.dgvClonDestino.TabIndex = 0;
      this.dgvClonDestino.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClonDestino_CellContentClick);
      // 
      // Destino_Editar
      // 
      this.Destino_Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.Destino_Editar.HeaderText = "Editar";
      this.Destino_Editar.Name = "Destino_Editar";
      this.Destino_Editar.Width = 57;
      // 
      // Destino_IdCombinacion
      // 
      this.Destino_IdCombinacion.HeaderText = "IdCombinacion";
      this.Destino_IdCombinacion.Name = "Destino_IdCombinacion";
      this.Destino_IdCombinacion.Visible = false;
      // 
      // Destino_IdDetalleComp
      // 
      this.Destino_IdDetalleComp.HeaderText = "IdDetalleComp";
      this.Destino_IdDetalleComp.Name = "Destino_IdDetalleComp";
      this.Destino_IdDetalleComp.Visible = false;
      // 
      // Destino_Itemno
      // 
      this.Destino_Itemno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Destino_Itemno.HeaderText = "Itemno";
      this.Destino_Itemno.Name = "Destino_Itemno";
      // 
      // Destino_IdComponente
      // 
      this.Destino_IdComponente.HeaderText = "IdComponente";
      this.Destino_IdComponente.Name = "Destino_IdComponente";
      this.Destino_IdComponente.Visible = false;
      // 
      // Destino_FormulaQty
      // 
      this.Destino_FormulaQty.HeaderText = "FormulaQty";
      this.Destino_FormulaQty.Name = "Destino_FormulaQty";
      this.Destino_FormulaQty.Visible = false;
      // 
      // Destino_FormulaMd
      // 
      this.Destino_FormulaMd.HeaderText = "FormulaMd";
      this.Destino_FormulaMd.Name = "Destino_FormulaMd";
      this.Destino_FormulaMd.Visible = false;
      // 
      // Destino_FormulaTotal
      // 
      this.Destino_FormulaTotal.HeaderText = "FormulaTotal";
      this.Destino_FormulaTotal.Name = "Destino_FormulaTotal";
      this.Destino_FormulaTotal.Visible = false;
      // 
      // Destino_FormulaPeso
      // 
      this.Destino_FormulaPeso.HeaderText = "FormulaPeso";
      this.Destino_FormulaPeso.Name = "Destino_FormulaPeso";
      this.Destino_FormulaPeso.Visible = false;
      // 
      // Destino_CondicionalQty
      // 
      this.Destino_CondicionalQty.HeaderText = "CondicionalQty";
      this.Destino_CondicionalQty.Name = "Destino_CondicionalQty";
      this.Destino_CondicionalQty.Visible = false;
      // 
      // Destino_CondicionalMd
      // 
      this.Destino_CondicionalMd.HeaderText = "CondicionalMd";
      this.Destino_CondicionalMd.Name = "Destino_CondicionalMd";
      this.Destino_CondicionalMd.Visible = false;
      // 
      // Destino_TypeCondicionalMd
      // 
      this.Destino_TypeCondicionalMd.HeaderText = "TypeCondicionalMd";
      this.Destino_TypeCondicionalMd.Name = "Destino_TypeCondicionalMd";
      this.Destino_TypeCondicionalMd.Visible = false;
      // 
      // Destino_TypeCondicionalQty
      // 
      this.Destino_TypeCondicionalQty.HeaderText = "TypeCondicionalQty";
      this.Destino_TypeCondicionalQty.Name = "Destino_TypeCondicionalQty";
      this.Destino_TypeCondicionalQty.Visible = false;
      // 
      // Destino_IdCompuestoQty
      // 
      this.Destino_IdCompuestoQty.HeaderText = "IdCompuestoQty";
      this.Destino_IdCompuestoQty.Name = "Destino_IdCompuestoQty";
      this.Destino_IdCompuestoQty.Visible = false;
      // 
      // Destino_IdCompuestoMd
      // 
      this.Destino_IdCompuestoMd.HeaderText = "IdCompuestoMd";
      this.Destino_IdCompuestoMd.Name = "Destino_IdCompuestoMd";
      this.Destino_IdCompuestoMd.Visible = false;
      // 
      // Destino_Descripcion
      // 
      this.Destino_Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Destino_Descripcion.HeaderText = "Descripcion";
      this.Destino_Descripcion.Name = "Destino_Descripcion";
      // 
      // Destino_Seccion
      // 
      this.Destino_Seccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.Destino_Seccion.HeaderText = "Seccion";
      this.Destino_Seccion.Name = "Destino_Seccion";
      this.Destino_Seccion.Width = 91;
      // 
      // Destino_Linea
      // 
      this.Destino_Linea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.Destino_Linea.HeaderText = "Linea";
      this.Destino_Linea.Name = "Destino_Linea";
      this.Destino_Linea.Width = 73;
      // 
      // gb_ClonOrigen
      // 
      this.gb_ClonOrigen.Controls.Add(this.dgvOrigenClon);
      this.gb_ClonOrigen.Location = new System.Drawing.Point(9, 292);
      this.gb_ClonOrigen.Name = "gb_ClonOrigen";
      this.gb_ClonOrigen.Size = new System.Drawing.Size(559, 424);
      this.gb_ClonOrigen.TabIndex = 4;
      this.gb_ClonOrigen.TabStop = false;
      this.gb_ClonOrigen.Text = "Origen";
      // 
      // dgvOrigenClon
      // 
      this.dgvOrigenClon.AllowUserToAddRows = false;
      this.dgvOrigenClon.AllowUserToDeleteRows = false;
      this.dgvOrigenClon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvOrigenClon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccion,
            this.IdCombinacion_Origen,
            this.IdDetalleComp_clon,
            this.Itemno,
            this.Origen_IdComponente,
            this.Origen_FormulaQty,
            this.Origen_FormulaMd,
            this.Origen_FormulaTotal,
            this.Origen_FormulaPeso,
            this.Origen_CondicionalQty,
            this.Origen_CondicionalMd,
            this.Origen_TypeCondicionalMd,
            this.Origen_TypeCondicionalQty,
            this.Origen_CompuestoQty,
            this.Origen_CompuestoMd,
            this.Origen_Descripcion,
            this.Origen_Seccion,
            this.Origen_Linea});
      this.dgvOrigenClon.Location = new System.Drawing.Point(6, 25);
      this.dgvOrigenClon.Name = "dgvOrigenClon";
      this.dgvOrigenClon.Size = new System.Drawing.Size(547, 393);
      this.dgvOrigenClon.TabIndex = 0;
      // 
      // Seleccion
      // 
      this.Seleccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.Seleccion.HeaderText = "Seleccion";
      this.Seleccion.Name = "Seleccion";
      this.Seleccion.Width = 84;
      // 
      // IdCombinacion_Origen
      // 
      this.IdCombinacion_Origen.HeaderText = "IdCombinacion";
      this.IdCombinacion_Origen.Name = "IdCombinacion_Origen";
      this.IdCombinacion_Origen.Visible = false;
      // 
      // IdDetalleComp_clon
      // 
      this.IdDetalleComp_clon.HeaderText = "IdDetalle";
      this.IdDetalleComp_clon.Name = "IdDetalleComp_clon";
      this.IdDetalleComp_clon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.IdDetalleComp_clon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.IdDetalleComp_clon.Visible = false;
      // 
      // Itemno
      // 
      this.Itemno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Itemno.HeaderText = "Itemno";
      this.Itemno.Name = "Itemno";
      this.Itemno.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Itemno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Origen_IdComponente
      // 
      this.Origen_IdComponente.HeaderText = "IdComponente";
      this.Origen_IdComponente.Name = "Origen_IdComponente";
      this.Origen_IdComponente.Visible = false;
      // 
      // Origen_FormulaQty
      // 
      this.Origen_FormulaQty.HeaderText = "FormulaQty";
      this.Origen_FormulaQty.Name = "Origen_FormulaQty";
      this.Origen_FormulaQty.Visible = false;
      // 
      // Origen_FormulaMd
      // 
      this.Origen_FormulaMd.HeaderText = "FormulaMd";
      this.Origen_FormulaMd.Name = "Origen_FormulaMd";
      this.Origen_FormulaMd.Visible = false;
      // 
      // Origen_FormulaTotal
      // 
      this.Origen_FormulaTotal.HeaderText = "FormulaTotal";
      this.Origen_FormulaTotal.Name = "Origen_FormulaTotal";
      this.Origen_FormulaTotal.Visible = false;
      // 
      // Origen_FormulaPeso
      // 
      this.Origen_FormulaPeso.HeaderText = "FormulaPeso";
      this.Origen_FormulaPeso.Name = "Origen_FormulaPeso";
      this.Origen_FormulaPeso.Visible = false;
      // 
      // Origen_CondicionalQty
      // 
      this.Origen_CondicionalQty.HeaderText = "CondicionalQty";
      this.Origen_CondicionalQty.Name = "Origen_CondicionalQty";
      this.Origen_CondicionalQty.Visible = false;
      // 
      // Origen_CondicionalMd
      // 
      this.Origen_CondicionalMd.HeaderText = "CondicionalMd";
      this.Origen_CondicionalMd.Name = "Origen_CondicionalMd";
      this.Origen_CondicionalMd.Visible = false;
      // 
      // Origen_TypeCondicionalMd
      // 
      this.Origen_TypeCondicionalMd.HeaderText = "TypeCondicionalMd";
      this.Origen_TypeCondicionalMd.Name = "Origen_TypeCondicionalMd";
      this.Origen_TypeCondicionalMd.Visible = false;
      // 
      // Origen_TypeCondicionalQty
      // 
      this.Origen_TypeCondicionalQty.HeaderText = "TypeCondicionalQty";
      this.Origen_TypeCondicionalQty.Name = "Origen_TypeCondicionalQty";
      this.Origen_TypeCondicionalQty.Visible = false;
      // 
      // Origen_CompuestoQty
      // 
      this.Origen_CompuestoQty.HeaderText = "CompuestoQty";
      this.Origen_CompuestoQty.Name = "Origen_CompuestoQty";
      this.Origen_CompuestoQty.Visible = false;
      // 
      // Origen_CompuestoMd
      // 
      this.Origen_CompuestoMd.HeaderText = "CompuestoMd";
      this.Origen_CompuestoMd.Name = "Origen_CompuestoMd";
      this.Origen_CompuestoMd.Visible = false;
      // 
      // Origen_Descripcion
      // 
      this.Origen_Descripcion.HeaderText = "Descripcion";
      this.Origen_Descripcion.Name = "Origen_Descripcion";
      // 
      // Origen_Seccion
      // 
      this.Origen_Seccion.HeaderText = "Seccion";
      this.Origen_Seccion.Name = "Origen_Seccion";
      // 
      // Origen_Linea
      // 
      this.Origen_Linea.HeaderText = "Linea";
      this.Origen_Linea.Name = "Origen_Linea";
      // 
      // cb_Familias
      // 
      this.cb_Familias.FormattingEnabled = true;
      this.cb_Familias.Location = new System.Drawing.Point(21, 48);
      this.cb_Familias.Name = "cb_Familias";
      this.cb_Familias.Size = new System.Drawing.Size(268, 28);
      this.cb_Familias.TabIndex = 2;
      this.cb_Familias.SelectedIndexChanged += new System.EventHandler(this.cb_Familias_SelectedIndexChanged);
      // 
      // tbpCondicionales
      // 
      this.tbpCondicionales.Controls.Add(this.label38);
      this.tbpCondicionales.Controls.Add(this.label37);
      this.tbpCondicionales.Controls.Add(this.pb_BuscarFormula);
      this.tbpCondicionales.Controls.Add(this.label24);
      this.tbpCondicionales.Controls.Add(this.pb_ActualizarCondicional);
      this.tbpCondicionales.Controls.Add(this.label25);
      this.tbpCondicionales.Controls.Add(this.pb_VisualizarCondicional);
      this.tbpCondicionales.Controls.Add(this.label23);
      this.tbpCondicionales.Controls.Add(this.label22);
      this.tbpCondicionales.Controls.Add(this.label21);
      this.tbpCondicionales.Controls.Add(this.pb_EliminarCondicional);
      this.tbpCondicionales.Controls.Add(this.tb_MasterCondicional);
      this.tbpCondicionales.Controls.Add(this.label15);
      this.tbpCondicionales.Controls.Add(this.label2);
      this.tbpCondicionales.Controls.Add(this.pb_Guardar);
      this.tbpCondicionales.Controls.Add(this.lbl_EliminarNodo);
      this.tbpCondicionales.Controls.Add(this.lbl_AgregarNodo);
      this.tbpCondicionales.Controls.Add(this.pb_Agregar);
      this.tbpCondicionales.Controls.Add(this.pb_Eliminar);
      this.tbpCondicionales.Controls.Add(this.tv_Condicional);
      this.tbpCondicionales.Controls.Add(this.tabCondicionales);
      this.tbpCondicionales.Controls.Add(this.groupBox1);
      this.tbpCondicionales.Location = new System.Drawing.Point(4, 29);
      this.tbpCondicionales.Margin = new System.Windows.Forms.Padding(4);
      this.tbpCondicionales.Name = "tbpCondicionales";
      this.tbpCondicionales.Padding = new System.Windows.Forms.Padding(4);
      this.tbpCondicionales.Size = new System.Drawing.Size(1152, 719);
      this.tbpCondicionales.TabIndex = 5;
      this.tbpCondicionales.Text = "Condicionales";
      this.tbpCondicionales.UseVisualStyleBackColor = true;
      // 
      // label38
      // 
      this.label38.AutoSize = true;
      this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label38.Location = new System.Drawing.Point(1009, 436);
      this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label38.Name = "label38";
      this.label38.Size = new System.Drawing.Size(58, 16);
      this.label38.TabIndex = 27;
      this.label38.Text = "formula";
      // 
      // label37
      // 
      this.label37.AutoSize = true;
      this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label37.Location = new System.Drawing.Point(1012, 418);
      this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label37.Name = "label37";
      this.label37.Size = new System.Drawing.Size(55, 16);
      this.label37.TabIndex = 26;
      this.label37.Text = "Buscar";
      // 
      // pb_BuscarFormula
      // 
      this.pb_BuscarFormula.Image = ((System.Drawing.Image)(resources.GetObject("pb_BuscarFormula.Image")));
      this.pb_BuscarFormula.Location = new System.Drawing.Point(995, 365);
      this.pb_BuscarFormula.Margin = new System.Windows.Forms.Padding(4);
      this.pb_BuscarFormula.Name = "pb_BuscarFormula";
      this.pb_BuscarFormula.Size = new System.Drawing.Size(89, 49);
      this.pb_BuscarFormula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_BuscarFormula.TabIndex = 25;
      this.pb_BuscarFormula.TabStop = false;
      this.pb_BuscarFormula.Click += new System.EventHandler(this.pb_BuscarFormula_Click);
      // 
      // label24
      // 
      this.label24.AutoSize = true;
      this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label24.Location = new System.Drawing.Point(1060, 209);
      this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label24.Name = "label24";
      this.label24.Size = new System.Drawing.Size(75, 16);
      this.label24.TabIndex = 24;
      this.label24.Text = "Actualizar";
      // 
      // pb_ActualizarCondicional
      // 
      this.pb_ActualizarCondicional.Image = global::BOM_Builder.Properties.Resources.actualizar;
      this.pb_ActualizarCondicional.Location = new System.Drawing.Point(1053, 156);
      this.pb_ActualizarCondicional.Margin = new System.Windows.Forms.Padding(4);
      this.pb_ActualizarCondicional.Name = "pb_ActualizarCondicional";
      this.pb_ActualizarCondicional.Size = new System.Drawing.Size(89, 49);
      this.pb_ActualizarCondicional.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_ActualizarCondicional.TabIndex = 23;
      this.pb_ActualizarCondicional.TabStop = false;
      this.pb_ActualizarCondicional.Click += new System.EventHandler(this.pb_ActualizarCondicional_Click);
      // 
      // label25
      // 
      this.label25.AutoSize = true;
      this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label25.Location = new System.Drawing.Point(1060, 101);
      this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label25.Name = "label25";
      this.label25.Size = new System.Drawing.Size(75, 16);
      this.label25.TabIndex = 22;
      this.label25.Text = "Visualizar";
      // 
      // pb_VisualizarCondicional
      // 
      this.pb_VisualizarCondicional.Image = global::BOM_Builder.Properties.Resources.ver;
      this.pb_VisualizarCondicional.Location = new System.Drawing.Point(1053, 49);
      this.pb_VisualizarCondicional.Margin = new System.Windows.Forms.Padding(4);
      this.pb_VisualizarCondicional.Name = "pb_VisualizarCondicional";
      this.pb_VisualizarCondicional.Size = new System.Drawing.Size(89, 49);
      this.pb_VisualizarCondicional.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_VisualizarCondicional.TabIndex = 21;
      this.pb_VisualizarCondicional.TabStop = false;
      this.pb_VisualizarCondicional.Click += new System.EventHandler(this.pb_VisualizarCondicional_Click);
      // 
      // label23
      // 
      this.label23.AutoSize = true;
      this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label23.Location = new System.Drawing.Point(963, 336);
      this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label23.Name = "label23";
      this.label23.Size = new System.Drawing.Size(42, 16);
      this.label23.TabIndex = 20;
      this.label23.Text = "nodo";
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label22.Location = new System.Drawing.Point(1064, 334);
      this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(71, 16);
      this.label22.TabIndex = 19;
      this.label22.Text = "elemento";
      // 
      // label21
      // 
      this.label21.AutoSize = true;
      this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label21.Location = new System.Drawing.Point(1067, 318);
      this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(63, 16);
      this.label21.TabIndex = 18;
      this.label21.Text = "Eliminar";
      // 
      // pb_EliminarCondicional
      // 
      this.pb_EliminarCondicional.Image = global::BOM_Builder.Properties.Resources.eliminar;
      this.pb_EliminarCondicional.Location = new System.Drawing.Point(1053, 264);
      this.pb_EliminarCondicional.Margin = new System.Windows.Forms.Padding(4);
      this.pb_EliminarCondicional.Name = "pb_EliminarCondicional";
      this.pb_EliminarCondicional.Size = new System.Drawing.Size(89, 49);
      this.pb_EliminarCondicional.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_EliminarCondicional.TabIndex = 17;
      this.pb_EliminarCondicional.TabStop = false;
      this.pb_EliminarCondicional.Click += new System.EventHandler(this.pb_EliminarCondicional_Click);
      // 
      // tb_MasterCondicional
      // 
      this.tb_MasterCondicional.Location = new System.Drawing.Point(403, 34);
      this.tb_MasterCondicional.Margin = new System.Windows.Forms.Padding(4);
      this.tb_MasterCondicional.Name = "tb_MasterCondicional";
      this.tb_MasterCondicional.Size = new System.Drawing.Size(510, 26);
      this.tb_MasterCondicional.TabIndex = 8;
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(399, 5);
      this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(201, 20);
      this.label15.TabIndex = 16;
      this.label15.Text = "Nombre condicional master";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(960, 209);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(45, 16);
      this.label2.TabIndex = 12;
      this.label2.Text = "Crear";
      // 
      // pb_Guardar
      // 
      this.pb_Guardar.Image = global::BOM_Builder.Properties.Resources.save;
      this.pb_Guardar.Location = new System.Drawing.Point(938, 156);
      this.pb_Guardar.Margin = new System.Windows.Forms.Padding(4);
      this.pb_Guardar.Name = "pb_Guardar";
      this.pb_Guardar.Size = new System.Drawing.Size(89, 49);
      this.pb_Guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_Guardar.TabIndex = 11;
      this.pb_Guardar.TabStop = false;
      this.pb_Guardar.Click += new System.EventHandler(this.Pb_Guardar_Click);
      // 
      // lbl_EliminarNodo
      // 
      this.lbl_EliminarNodo.AutoSize = true;
      this.lbl_EliminarNodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_EliminarNodo.Location = new System.Drawing.Point(952, 320);
      this.lbl_EliminarNodo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_EliminarNodo.Name = "lbl_EliminarNodo";
      this.lbl_EliminarNodo.Size = new System.Drawing.Size(63, 16);
      this.lbl_EliminarNodo.TabIndex = 10;
      this.lbl_EliminarNodo.Text = "Eliminar";
      // 
      // lbl_AgregarNodo
      // 
      this.lbl_AgregarNodo.AutoSize = true;
      this.lbl_AgregarNodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_AgregarNodo.Location = new System.Drawing.Point(952, 102);
      this.lbl_AgregarNodo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_AgregarNodo.Name = "lbl_AgregarNodo";
      this.lbl_AgregarNodo.Size = new System.Drawing.Size(63, 16);
      this.lbl_AgregarNodo.TabIndex = 9;
      this.lbl_AgregarNodo.Text = "Agregar";
      // 
      // pb_Agregar
      // 
      this.pb_Agregar.Image = global::BOM_Builder.Properties.Resources.plus;
      this.pb_Agregar.Location = new System.Drawing.Point(938, 49);
      this.pb_Agregar.Margin = new System.Windows.Forms.Padding(4);
      this.pb_Agregar.Name = "pb_Agregar";
      this.pb_Agregar.Size = new System.Drawing.Size(89, 49);
      this.pb_Agregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_Agregar.TabIndex = 7;
      this.pb_Agregar.TabStop = false;
      this.pb_Agregar.Click += new System.EventHandler(this.Pb_Agregar_Click);
      // 
      // pb_Eliminar
      // 
      this.pb_Eliminar.Image = global::BOM_Builder.Properties.Resources.error;
      this.pb_Eliminar.Location = new System.Drawing.Point(938, 266);
      this.pb_Eliminar.Margin = new System.Windows.Forms.Padding(4);
      this.pb_Eliminar.Name = "pb_Eliminar";
      this.pb_Eliminar.Size = new System.Drawing.Size(89, 49);
      this.pb_Eliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_Eliminar.TabIndex = 6;
      this.pb_Eliminar.TabStop = false;
      this.pb_Eliminar.Click += new System.EventHandler(this.Pb_Eliminar_Click);
      // 
      // tv_Condicional
      // 
      this.tv_Condicional.Location = new System.Drawing.Point(403, 69);
      this.tv_Condicional.Margin = new System.Windows.Forms.Padding(4);
      this.tv_Condicional.Name = "tv_Condicional";
      this.tv_Condicional.Size = new System.Drawing.Size(510, 385);
      this.tv_Condicional.TabIndex = 9;
      // 
      // tabCondicionales
      // 
      this.tabCondicionales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabCondicionales.Controls.Add(this.tbp_Condicionales);
      this.tabCondicionales.Controls.Add(this.tbp_CondicionalMaster);
      this.tabCondicionales.Controls.Add(this.tbpFormulas);
      this.tabCondicionales.Location = new System.Drawing.Point(16, 461);
      this.tabCondicionales.Margin = new System.Windows.Forms.Padding(4);
      this.tabCondicionales.Name = "tabCondicionales";
      this.tabCondicionales.SelectedIndex = 0;
      this.tabCondicionales.Size = new System.Drawing.Size(1132, 254);
      this.tabCondicionales.TabIndex = 4;
      this.tabCondicionales.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabCondicionales_Selecting);
      // 
      // tbp_Condicionales
      // 
      this.tbp_Condicionales.Controls.Add(this.dgv_Condicionales);
      this.tbp_Condicionales.Location = new System.Drawing.Point(4, 29);
      this.tbp_Condicionales.Margin = new System.Windows.Forms.Padding(4);
      this.tbp_Condicionales.Name = "tbp_Condicionales";
      this.tbp_Condicionales.Padding = new System.Windows.Forms.Padding(4);
      this.tbp_Condicionales.Size = new System.Drawing.Size(1124, 221);
      this.tbp_Condicionales.TabIndex = 1;
      this.tbp_Condicionales.Text = "Condicionales";
      this.tbp_Condicionales.UseVisualStyleBackColor = true;
      // 
      // dgv_Condicionales
      // 
      this.dgv_Condicionales.AllowUserToAddRows = false;
      this.dgv_Condicionales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgv_Condicionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_Condicionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Condicional,
            this.Nombre_Condicionales,
            this.Condicional_Condicionales,
            this.Verdadero_Condicionales,
            this.Falso_Condicionales,
            this.Tipo_Condicional});
      this.dgv_Condicionales.Location = new System.Drawing.Point(4, 4);
      this.dgv_Condicionales.Margin = new System.Windows.Forms.Padding(4);
      this.dgv_Condicionales.MultiSelect = false;
      this.dgv_Condicionales.Name = "dgv_Condicionales";
      this.dgv_Condicionales.Size = new System.Drawing.Size(1116, 62);
      this.dgv_Condicionales.TabIndex = 7;
      // 
      // Id_Condicional
      // 
      this.Id_Condicional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.Id_Condicional.HeaderText = "ID";
      this.Id_Condicional.Name = "Id_Condicional";
      this.Id_Condicional.Width = 51;
      // 
      // Nombre_Condicionales
      // 
      this.Nombre_Condicionales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Nombre_Condicionales.HeaderText = "Nombre";
      this.Nombre_Condicionales.Name = "Nombre_Condicionales";
      // 
      // Condicional_Condicionales
      // 
      this.Condicional_Condicionales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Condicional_Condicionales.HeaderText = "Condicional";
      this.Condicional_Condicionales.Name = "Condicional_Condicionales";
      // 
      // Verdadero_Condicionales
      // 
      this.Verdadero_Condicionales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Verdadero_Condicionales.HeaderText = "Verdadero";
      this.Verdadero_Condicionales.Name = "Verdadero_Condicionales";
      // 
      // Falso_Condicionales
      // 
      this.Falso_Condicionales.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Falso_Condicionales.HeaderText = "Falso";
      this.Falso_Condicionales.Name = "Falso_Condicionales";
      // 
      // Tipo_Condicional
      // 
      this.Tipo_Condicional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Tipo_Condicional.HeaderText = "Tipo";
      this.Tipo_Condicional.Name = "Tipo_Condicional";
      // 
      // tbp_CondicionalMaster
      // 
      this.tbp_CondicionalMaster.Controls.Add(this.dgv_CondicionalesMaster);
      this.tbp_CondicionalMaster.Location = new System.Drawing.Point(4, 29);
      this.tbp_CondicionalMaster.Name = "tbp_CondicionalMaster";
      this.tbp_CondicionalMaster.Padding = new System.Windows.Forms.Padding(3);
      this.tbp_CondicionalMaster.Size = new System.Drawing.Size(1124, 221);
      this.tbp_CondicionalMaster.TabIndex = 2;
      this.tbp_CondicionalMaster.Text = "Master";
      this.tbp_CondicionalMaster.UseVisualStyleBackColor = true;
      // 
      // dgv_CondicionalesMaster
      // 
      this.dgv_CondicionalesMaster.AllowUserToAddRows = false;
      this.dgv_CondicionalesMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgv_CondicionalesMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_CondicionalesMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_CondicionalMaster,
            this.Nombre_CondicionalMaster,
            this.IdCompuesto_CondicionalMaster});
      this.dgv_CondicionalesMaster.Location = new System.Drawing.Point(3, 3);
      this.dgv_CondicionalesMaster.Name = "dgv_CondicionalesMaster";
      this.dgv_CondicionalesMaster.Size = new System.Drawing.Size(1118, 261);
      this.dgv_CondicionalesMaster.TabIndex = 0;
      // 
      // Id_CondicionalMaster
      // 
      this.Id_CondicionalMaster.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.Id_CondicionalMaster.HeaderText = "Id";
      this.Id_CondicionalMaster.Name = "Id_CondicionalMaster";
      this.Id_CondicionalMaster.Width = 48;
      // 
      // Nombre_CondicionalMaster
      // 
      this.Nombre_CondicionalMaster.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Nombre_CondicionalMaster.HeaderText = "Nombre";
      this.Nombre_CondicionalMaster.Name = "Nombre_CondicionalMaster";
      // 
      // IdCompuesto_CondicionalMaster
      // 
      this.IdCompuesto_CondicionalMaster.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.IdCompuesto_CondicionalMaster.HeaderText = "Id Compuesto";
      this.IdCompuesto_CondicionalMaster.Name = "IdCompuesto_CondicionalMaster";
      // 
      // tbpFormulas
      // 
      this.tbpFormulas.Controls.Add(this.dgv_Formulas_Condicional);
      this.tbpFormulas.Location = new System.Drawing.Point(4, 29);
      this.tbpFormulas.Margin = new System.Windows.Forms.Padding(4);
      this.tbpFormulas.Name = "tbpFormulas";
      this.tbpFormulas.Padding = new System.Windows.Forms.Padding(4);
      this.tbpFormulas.Size = new System.Drawing.Size(1124, 221);
      this.tbpFormulas.TabIndex = 0;
      this.tbpFormulas.Text = "Formulas";
      this.tbpFormulas.UseVisualStyleBackColor = true;
      // 
      // dgv_Formulas_Condicional
      // 
      this.dgv_Formulas_Condicional.AllowUserToAddRows = false;
      this.dgv_Formulas_Condicional.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgv_Formulas_Condicional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_Formulas_Condicional.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Condicional_Id_Formula,
            this.Condicional_Tipo_Formula,
            this.Condicional_NombreFormula,
            this.Condicional_Formula,
            this.Condicional_Formula_FechaCreacion});
      this.dgv_Formulas_Condicional.Location = new System.Drawing.Point(4, 4);
      this.dgv_Formulas_Condicional.Margin = new System.Windows.Forms.Padding(4);
      this.dgv_Formulas_Condicional.Name = "dgv_Formulas_Condicional";
      this.dgv_Formulas_Condicional.Size = new System.Drawing.Size(1116, 262);
      this.dgv_Formulas_Condicional.TabIndex = 0;
      // 
      // Condicional_Id_Formula
      // 
      this.Condicional_Id_Formula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.Condicional_Id_Formula.HeaderText = "Id";
      this.Condicional_Id_Formula.Name = "Condicional_Id_Formula";
      this.Condicional_Id_Formula.Width = 48;
      // 
      // Condicional_Tipo_Formula
      // 
      this.Condicional_Tipo_Formula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Condicional_Tipo_Formula.HeaderText = "Tipo";
      this.Condicional_Tipo_Formula.Name = "Condicional_Tipo_Formula";
      // 
      // Condicional_NombreFormula
      // 
      this.Condicional_NombreFormula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Condicional_NombreFormula.HeaderText = "Nombre";
      this.Condicional_NombreFormula.Name = "Condicional_NombreFormula";
      // 
      // Condicional_Formula
      // 
      this.Condicional_Formula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Condicional_Formula.HeaderText = "Formula";
      this.Condicional_Formula.Name = "Condicional_Formula";
      // 
      // Condicional_Formula_FechaCreacion
      // 
      this.Condicional_Formula_FechaCreacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Condicional_Formula_FechaCreacion.HeaderText = "Fecha creacion";
      this.Condicional_Formula_FechaCreacion.Name = "Condicional_Formula_FechaCreacion";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.lbl_EditarCondicional_2);
      this.groupBox1.Controls.Add(this.lbl_GuardarCondicional_2);
      this.groupBox1.Controls.Add(this.lbl_EditarCondicional);
      this.groupBox1.Controls.Add(this.cb_TipoCondicional);
      this.groupBox1.Controls.Add(this.pb_EditarCondicional);
      this.groupBox1.Controls.Add(this.lbl_GuardarCondicional);
      this.groupBox1.Controls.Add(this.label16);
      this.groupBox1.Controls.Add(this.pb_GuardarCondicional);
      this.groupBox1.Controls.Add(this.lbl_Condicional);
      this.groupBox1.Controls.Add(this.label18);
      this.groupBox1.Controls.Add(this.pb_AgregarCondicionalForm);
      this.groupBox1.Controls.Add(this.tb_NombreCondicional);
      this.groupBox1.Controls.Add(this.label10);
      this.groupBox1.Controls.Add(this.tb_Falso);
      this.groupBox1.Controls.Add(this.label9);
      this.groupBox1.Controls.Add(this.tb_Verdadero);
      this.groupBox1.Controls.Add(this.label8);
      this.groupBox1.Controls.Add(this.tb_Condicional);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Location = new System.Drawing.Point(16, 4);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
      this.groupBox1.Size = new System.Drawing.Size(379, 450);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Creacion";
      // 
      // lbl_EditarCondicional_2
      // 
      this.lbl_EditarCondicional_2.AutoSize = true;
      this.lbl_EditarCondicional_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_EditarCondicional_2.Location = new System.Drawing.Point(169, 418);
      this.lbl_EditarCondicional_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_EditarCondicional_2.Name = "lbl_EditarCondicional_2";
      this.lbl_EditarCondicional_2.Size = new System.Drawing.Size(87, 16);
      this.lbl_EditarCondicional_2.TabIndex = 27;
      this.lbl_EditarCondicional_2.Text = "condicional";
      // 
      // lbl_GuardarCondicional_2
      // 
      this.lbl_GuardarCondicional_2.AutoSize = true;
      this.lbl_GuardarCondicional_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_GuardarCondicional_2.Location = new System.Drawing.Point(58, 418);
      this.lbl_GuardarCondicional_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_GuardarCondicional_2.Name = "lbl_GuardarCondicional_2";
      this.lbl_GuardarCondicional_2.Size = new System.Drawing.Size(87, 16);
      this.lbl_GuardarCondicional_2.TabIndex = 30;
      this.lbl_GuardarCondicional_2.Text = "condicional";
      this.lbl_GuardarCondicional_2.Visible = false;
      // 
      // lbl_EditarCondicional
      // 
      this.lbl_EditarCondicional.AutoSize = true;
      this.lbl_EditarCondicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_EditarCondicional.Location = new System.Drawing.Point(192, 402);
      this.lbl_EditarCondicional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_EditarCondicional.Name = "lbl_EditarCondicional";
      this.lbl_EditarCondicional.Size = new System.Drawing.Size(48, 16);
      this.lbl_EditarCondicional.TabIndex = 26;
      this.lbl_EditarCondicional.Text = "Editar";
      // 
      // cb_TipoCondicional
      // 
      this.cb_TipoCondicional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cb_TipoCondicional.FormattingEnabled = true;
      this.cb_TipoCondicional.Location = new System.Drawing.Point(13, 177);
      this.cb_TipoCondicional.Margin = new System.Windows.Forms.Padding(4);
      this.cb_TipoCondicional.Name = "cb_TipoCondicional";
      this.cb_TipoCondicional.Size = new System.Drawing.Size(348, 28);
      this.cb_TipoCondicional.TabIndex = 3;
      // 
      // pb_EditarCondicional
      // 
      this.pb_EditarCondicional.Image = ((System.Drawing.Image)(resources.GetObject("pb_EditarCondicional.Image")));
      this.pb_EditarCondicional.Location = new System.Drawing.Point(168, 349);
      this.pb_EditarCondicional.Margin = new System.Windows.Forms.Padding(4);
      this.pb_EditarCondicional.Name = "pb_EditarCondicional";
      this.pb_EditarCondicional.Size = new System.Drawing.Size(89, 49);
      this.pb_EditarCondicional.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_EditarCondicional.TabIndex = 25;
      this.pb_EditarCondicional.TabStop = false;
      this.pb_EditarCondicional.Click += new System.EventHandler(this.pb_EditarCondicional_Click);
      // 
      // lbl_GuardarCondicional
      // 
      this.lbl_GuardarCondicional.AutoSize = true;
      this.lbl_GuardarCondicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_GuardarCondicional.Location = new System.Drawing.Point(70, 402);
      this.lbl_GuardarCondicional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_GuardarCondicional.Name = "lbl_GuardarCondicional";
      this.lbl_GuardarCondicional.Size = new System.Drawing.Size(63, 16);
      this.lbl_GuardarCondicional.TabIndex = 29;
      this.lbl_GuardarCondicional.Text = "Guardar";
      this.lbl_GuardarCondicional.Visible = false;
      // 
      // label16
      // 
      this.label16.AutoSize = true;
      this.label16.Location = new System.Drawing.Point(8, 149);
      this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(39, 20);
      this.label16.TabIndex = 16;
      this.label16.Text = "Tipo";
      // 
      // pb_GuardarCondicional
      // 
      this.pb_GuardarCondicional.Image = ((System.Drawing.Image)(resources.GetObject("pb_GuardarCondicional.Image")));
      this.pb_GuardarCondicional.Location = new System.Drawing.Point(57, 349);
      this.pb_GuardarCondicional.Margin = new System.Windows.Forms.Padding(4);
      this.pb_GuardarCondicional.Name = "pb_GuardarCondicional";
      this.pb_GuardarCondicional.Size = new System.Drawing.Size(89, 49);
      this.pb_GuardarCondicional.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_GuardarCondicional.TabIndex = 28;
      this.pb_GuardarCondicional.TabStop = false;
      this.pb_GuardarCondicional.Visible = false;
      this.pb_GuardarCondicional.Click += new System.EventHandler(this.pb_GuardarCondicional_Click);
      // 
      // lbl_Condicional
      // 
      this.lbl_Condicional.AutoSize = true;
      this.lbl_Condicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbl_Condicional.Location = new System.Drawing.Point(273, 419);
      this.lbl_Condicional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl_Condicional.Name = "lbl_Condicional";
      this.lbl_Condicional.Size = new System.Drawing.Size(87, 16);
      this.lbl_Condicional.TabIndex = 15;
      this.lbl_Condicional.Text = "condicional";
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label18.Location = new System.Drawing.Point(285, 402);
      this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(63, 16);
      this.label18.TabIndex = 14;
      this.label18.Text = "Agregar";
      // 
      // pb_AgregarCondicionalForm
      // 
      this.pb_AgregarCondicionalForm.Image = global::BOM_Builder.Properties.Resources.street;
      this.pb_AgregarCondicionalForm.Location = new System.Drawing.Point(281, 349);
      this.pb_AgregarCondicionalForm.Margin = new System.Windows.Forms.Padding(4);
      this.pb_AgregarCondicionalForm.Name = "pb_AgregarCondicionalForm";
      this.pb_AgregarCondicionalForm.Size = new System.Drawing.Size(75, 49);
      this.pb_AgregarCondicionalForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_AgregarCondicionalForm.TabIndex = 13;
      this.pb_AgregarCondicionalForm.TabStop = false;
      this.pb_AgregarCondicionalForm.Click += new System.EventHandler(this.Pb_AgregarCondicionalForm_Click);
      // 
      // tb_NombreCondicional
      // 
      this.tb_NombreCondicional.Location = new System.Drawing.Point(13, 46);
      this.tb_NombreCondicional.Margin = new System.Windows.Forms.Padding(4);
      this.tb_NombreCondicional.Name = "tb_NombreCondicional";
      this.tb_NombreCondicional.Size = new System.Drawing.Size(348, 26);
      this.tb_NombreCondicional.TabIndex = 1;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(8, 17);
      this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(65, 20);
      this.label10.TabIndex = 6;
      this.label10.Text = "Nombre";
      // 
      // tb_Falso
      // 
      this.tb_Falso.Location = new System.Drawing.Point(13, 315);
      this.tb_Falso.Margin = new System.Windows.Forms.Padding(4);
      this.tb_Falso.Name = "tb_Falso";
      this.tb_Falso.Size = new System.Drawing.Size(348, 26);
      this.tb_Falso.TabIndex = 5;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(8, 287);
      this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(48, 20);
      this.label9.TabIndex = 4;
      this.label9.Text = "Falso";
      // 
      // tb_Verdadero
      // 
      this.tb_Verdadero.Location = new System.Drawing.Point(13, 247);
      this.tb_Verdadero.Margin = new System.Windows.Forms.Padding(4);
      this.tb_Verdadero.Name = "tb_Verdadero";
      this.tb_Verdadero.Size = new System.Drawing.Size(348, 26);
      this.tb_Verdadero.TabIndex = 4;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(8, 219);
      this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(84, 20);
      this.label8.TabIndex = 2;
      this.label8.Text = "Verdadero";
      // 
      // tb_Condicional
      // 
      this.tb_Condicional.Location = new System.Drawing.Point(13, 113);
      this.tb_Condicional.Margin = new System.Windows.Forms.Padding(4);
      this.tb_Condicional.Name = "tb_Condicional";
      this.tb_Condicional.Size = new System.Drawing.Size(348, 26);
      this.tb_Condicional.TabIndex = 2;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(8, 81);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(91, 20);
      this.label7.TabIndex = 0;
      this.label7.Text = "Condicional";
      // 
      // tbPCatalogoFormulas
      // 
      this.tbPCatalogoFormulas.Controls.Add(this.gpbCantidades);
      this.tbPCatalogoFormulas.Location = new System.Drawing.Point(4, 29);
      this.tbPCatalogoFormulas.Margin = new System.Windows.Forms.Padding(4);
      this.tbPCatalogoFormulas.Name = "tbPCatalogoFormulas";
      this.tbPCatalogoFormulas.Padding = new System.Windows.Forms.Padding(4);
      this.tbPCatalogoFormulas.Size = new System.Drawing.Size(1152, 719);
      this.tbPCatalogoFormulas.TabIndex = 0;
      this.tbPCatalogoFormulas.Text = "Catalogo de formulas";
      this.tbPCatalogoFormulas.UseVisualStyleBackColor = true;
      // 
      // gpbCantidades
      // 
      this.gpbCantidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gpbCantidades.Controls.Add(this.btn_Eliminar);
      this.gpbCantidades.Controls.Add(this.btn_Guardar);
      this.gpbCantidades.Controls.Add(this.btn_Editar);
      this.gpbCantidades.Controls.Add(this.dgv_Formulas);
      this.gpbCantidades.Controls.Add(this.cb_TipoFormula);
      this.gpbCantidades.Controls.Add(this.label3);
      this.gpbCantidades.Controls.Add(this.btn_ValidarFormula);
      this.gpbCantidades.Controls.Add(this.txt_Formula);
      this.gpbCantidades.Controls.Add(this.lblNombreFormula);
      this.gpbCantidades.Controls.Add(this.lblFormula);
      this.gpbCantidades.Controls.Add(this.txt_NombreFormula);
      this.gpbCantidades.Location = new System.Drawing.Point(8, 7);
      this.gpbCantidades.Margin = new System.Windows.Forms.Padding(4);
      this.gpbCantidades.Name = "gpbCantidades";
      this.gpbCantidades.Padding = new System.Windows.Forms.Padding(4);
      this.gpbCantidades.Size = new System.Drawing.Size(1144, 708);
      this.gpbCantidades.TabIndex = 1;
      this.gpbCantidades.TabStop = false;
      this.gpbCantidades.Text = "Formulador de cantidades";
      // 
      // btn_Eliminar
      // 
      this.btn_Eliminar.Location = new System.Drawing.Point(423, 102);
      this.btn_Eliminar.Margin = new System.Windows.Forms.Padding(4);
      this.btn_Eliminar.Name = "btn_Eliminar";
      this.btn_Eliminar.Size = new System.Drawing.Size(127, 46);
      this.btn_Eliminar.TabIndex = 7;
      this.btn_Eliminar.Text = "Eliminar";
      this.btn_Eliminar.UseVisualStyleBackColor = true;
      this.btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
      // 
      // btn_Guardar
      // 
      this.btn_Guardar.Location = new System.Drawing.Point(153, 102);
      this.btn_Guardar.Margin = new System.Windows.Forms.Padding(4);
      this.btn_Guardar.Name = "btn_Guardar";
      this.btn_Guardar.Size = new System.Drawing.Size(127, 46);
      this.btn_Guardar.TabIndex = 6;
      this.btn_Guardar.Text = "Guardar";
      this.btn_Guardar.UseVisualStyleBackColor = true;
      this.btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
      // 
      // btn_Editar
      // 
      this.btn_Editar.Location = new System.Drawing.Point(288, 102);
      this.btn_Editar.Margin = new System.Windows.Forms.Padding(4);
      this.btn_Editar.Name = "btn_Editar";
      this.btn_Editar.Size = new System.Drawing.Size(127, 46);
      this.btn_Editar.TabIndex = 5;
      this.btn_Editar.Text = "Editar";
      this.btn_Editar.UseVisualStyleBackColor = true;
      this.btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
      // 
      // dgv_Formulas
      // 
      this.dgv_Formulas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgv_Formulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_Formulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdFormula,
            this.NombreFormula,
            this.TipoFormula,
            this.Formula});
      this.dgv_Formulas.Location = new System.Drawing.Point(19, 156);
      this.dgv_Formulas.Margin = new System.Windows.Forms.Padding(4);
      this.dgv_Formulas.Name = "dgv_Formulas";
      this.dgv_Formulas.Size = new System.Drawing.Size(1106, 544);
      this.dgv_Formulas.TabIndex = 8;
      // 
      // IdFormula
      // 
      this.IdFormula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.IdFormula.HeaderText = "Id";
      this.IdFormula.Name = "IdFormula";
      this.IdFormula.Width = 48;
      // 
      // NombreFormula
      // 
      this.NombreFormula.HeaderText = "Nombre Formula";
      this.NombreFormula.Name = "NombreFormula";
      // 
      // TipoFormula
      // 
      this.TipoFormula.HeaderText = "Tipo Formula";
      this.TipoFormula.Name = "TipoFormula";
      // 
      // Formula
      // 
      this.Formula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Formula.HeaderText = "Formula";
      this.Formula.Name = "Formula";
      // 
      // cb_TipoFormula
      // 
      this.cb_TipoFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cb_TipoFormula.FormattingEnabled = true;
      this.cb_TipoFormula.Location = new System.Drawing.Point(19, 44);
      this.cb_TipoFormula.Margin = new System.Windows.Forms.Padding(4);
      this.cb_TipoFormula.Name = "cb_TipoFormula";
      this.cb_TipoFormula.Size = new System.Drawing.Size(287, 28);
      this.cb_TipoFormula.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(13, 16);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(96, 20);
      this.label3.TabIndex = 18;
      this.label3.Text = "Tipo formula";
      // 
      // btn_ValidarFormula
      // 
      this.btn_ValidarFormula.Location = new System.Drawing.Point(19, 102);
      this.btn_ValidarFormula.Margin = new System.Windows.Forms.Padding(4);
      this.btn_ValidarFormula.Name = "btn_ValidarFormula";
      this.btn_ValidarFormula.Size = new System.Drawing.Size(127, 46);
      this.btn_ValidarFormula.TabIndex = 4;
      this.btn_ValidarFormula.Text = "Crear";
      this.btn_ValidarFormula.UseVisualStyleBackColor = true;
      this.btn_ValidarFormula.Click += new System.EventHandler(this.Btn_ValidarFormula_Click);
      // 
      // txt_Formula
      // 
      this.txt_Formula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txt_Formula.Location = new System.Drawing.Point(649, 44);
      this.txt_Formula.Margin = new System.Windows.Forms.Padding(4);
      this.txt_Formula.Multiline = true;
      this.txt_Formula.Name = "txt_Formula";
      this.txt_Formula.Size = new System.Drawing.Size(476, 102);
      this.txt_Formula.TabIndex = 3;
      // 
      // lblNombreFormula
      // 
      this.lblNombreFormula.AutoSize = true;
      this.lblNombreFormula.Location = new System.Drawing.Point(325, 16);
      this.lblNombreFormula.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblNombreFormula.Name = "lblNombreFormula";
      this.lblNombreFormula.Size = new System.Drawing.Size(160, 20);
      this.lblNombreFormula.TabIndex = 12;
      this.lblNombreFormula.Text = "Nombre de la formula";
      // 
      // lblFormula
      // 
      this.lblFormula.AutoSize = true;
      this.lblFormula.Location = new System.Drawing.Point(644, 16);
      this.lblFormula.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblFormula.Name = "lblFormula";
      this.lblFormula.Size = new System.Drawing.Size(67, 20);
      this.lblFormula.TabIndex = 14;
      this.lblFormula.Text = "Formula";
      // 
      // txt_NombreFormula
      // 
      this.txt_NombreFormula.Location = new System.Drawing.Point(331, 44);
      this.txt_NombreFormula.Margin = new System.Windows.Forms.Padding(4);
      this.txt_NombreFormula.Multiline = true;
      this.txt_NombreFormula.Name = "txt_NombreFormula";
      this.txt_NombreFormula.Size = new System.Drawing.Size(287, 34);
      this.txt_NombreFormula.TabIndex = 2;
      // 
      // tbpConstruccionBomComponente
      // 
      this.tbpConstruccionBomComponente.Controls.Add(this.treeView1);
      this.tbpConstruccionBomComponente.Controls.Add(this.btnRemplazarComponente);
      this.tbpConstruccionBomComponente.Controls.Add(this.btnEditarCombinacion);
      this.tbpConstruccionBomComponente.Controls.Add(this.txtFilter);
      this.tbpConstruccionBomComponente.Controls.Add(this.txtPreviewCombination);
      this.tbpConstruccionBomComponente.Controls.Add(this.lblFilter);
      this.tbpConstruccionBomComponente.Controls.Add(this.lblPreviewCombination);
      this.tbpConstruccionBomComponente.Controls.Add(this.btnCreatePreAssembly);
      this.tbpConstruccionBomComponente.Controls.Add(this.btnSearch);
      this.tbpConstruccionBomComponente.Controls.Add(this.dgvListComponents);
      this.tbpConstruccionBomComponente.Controls.Add(this.gpbAgregados);
      this.tbpConstruccionBomComponente.Controls.Add(this.gpbAcabados);
      this.tbpConstruccionBomComponente.Controls.Add(this.cmbListModelL0);
      this.tbpConstruccionBomComponente.Controls.Add(this.lblSubNivelBomsL1);
      this.tbpConstruccionBomComponente.Controls.Add(this.cmbListModelL1);
      this.tbpConstruccionBomComponente.Controls.Add(this.lblListadoBomL0);
      this.tbpConstruccionBomComponente.Location = new System.Drawing.Point(4, 29);
      this.tbpConstruccionBomComponente.Margin = new System.Windows.Forms.Padding(4);
      this.tbpConstruccionBomComponente.Name = "tbpConstruccionBomComponente";
      this.tbpConstruccionBomComponente.Padding = new System.Windows.Forms.Padding(4);
      this.tbpConstruccionBomComponente.Size = new System.Drawing.Size(1152, 719);
      this.tbpConstruccionBomComponente.TabIndex = 6;
      this.tbpConstruccionBomComponente.Text = "Construccion bom por componentes";
      this.tbpConstruccionBomComponente.UseVisualStyleBackColor = true;
      // 
      // treeView1
      // 
      this.treeView1.Location = new System.Drawing.Point(21, 117);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new System.Drawing.Size(457, 273);
      this.treeView1.TabIndex = 66;
      // 
      // btnRemplazarComponente
      // 
      this.btnRemplazarComponente.Location = new System.Drawing.Point(1009, 17);
      this.btnRemplazarComponente.Name = "btnRemplazarComponente";
      this.btnRemplazarComponente.Size = new System.Drawing.Size(107, 54);
      this.btnRemplazarComponente.TabIndex = 65;
      this.btnRemplazarComponente.Text = "Remplazar componente";
      this.btnRemplazarComponente.UseVisualStyleBackColor = true;
      this.btnRemplazarComponente.Click += new System.EventHandler(this.btnRemplazarComponente_Click);
      // 
      // btnEditarCombinacion
      // 
      this.btnEditarCombinacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnEditarCombinacion.Location = new System.Drawing.Point(851, 17);
      this.btnEditarCombinacion.Margin = new System.Windows.Forms.Padding(4);
      this.btnEditarCombinacion.Name = "btnEditarCombinacion";
      this.btnEditarCombinacion.Size = new System.Drawing.Size(135, 54);
      this.btnEditarCombinacion.TabIndex = 16;
      this.btnEditarCombinacion.Text = "Editar compontes de BOM";
      this.btnEditarCombinacion.UseVisualStyleBackColor = true;
      this.btnEditarCombinacion.Click += new System.EventHandler(this.BtnEditarCombinacion_Click);
      // 
      // txtFilter
      // 
      this.txtFilter.Location = new System.Drawing.Point(904, 191);
      this.txtFilter.Margin = new System.Windows.Forms.Padding(4);
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Size = new System.Drawing.Size(236, 26);
      this.txtFilter.TabIndex = 13;
      this.txtFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtFilter.TextChanged += new System.EventHandler(this.TxtFilter_TextChanged);
      // 
      // txtPreviewCombination
      // 
      this.txtPreviewCombination.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPreviewCombination.Location = new System.Drawing.Point(552, 130);
      this.txtPreviewCombination.Margin = new System.Windows.Forms.Padding(4);
      this.txtPreviewCombination.Name = "txtPreviewCombination";
      this.txtPreviewCombination.Size = new System.Drawing.Size(227, 29);
      this.txtPreviewCombination.TabIndex = 12;
      this.txtPreviewCombination.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtPreviewCombination.Visible = false;
      // 
      // lblFilter
      // 
      this.lblFilter.AutoSize = true;
      this.lblFilter.Location = new System.Drawing.Point(774, 194);
      this.lblFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblFilter.Name = "lblFilter";
      this.lblFilter.Size = new System.Drawing.Size(127, 20);
      this.lblFilter.TabIndex = 64;
      this.lblFilter.Text = "Filtrar resultados";
      // 
      // lblPreviewCombination
      // 
      this.lblPreviewCombination.AutoSize = true;
      this.lblPreviewCombination.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPreviewCombination.Location = new System.Drawing.Point(548, 101);
      this.lblPreviewCombination.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblPreviewCombination.Name = "lblPreviewCombination";
      this.lblPreviewCombination.Size = new System.Drawing.Size(267, 20);
      this.lblPreviewCombination.TabIndex = 62;
      this.lblPreviewCombination.Text = "Previsualización de combinación";
      this.lblPreviewCombination.Visible = false;
      // 
      // btnCreatePreAssembly
      // 
      this.btnCreatePreAssembly.Location = new System.Drawing.Point(835, 93);
      this.btnCreatePreAssembly.Margin = new System.Windows.Forms.Padding(4);
      this.btnCreatePreAssembly.Name = "btnCreatePreAssembly";
      this.btnCreatePreAssembly.Size = new System.Drawing.Size(161, 68);
      this.btnCreatePreAssembly.TabIndex = 15;
      this.btnCreatePreAssembly.Text = "Crear pre ensamblado";
      this.btnCreatePreAssembly.UseVisualStyleBackColor = true;
      this.btnCreatePreAssembly.Visible = false;
      this.btnCreatePreAssembly.Click += new System.EventHandler(this.BtnCrearPreEnsamble_Click);
      // 
      // btnSearch
      // 
      this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSearch.Location = new System.Drawing.Point(731, 17);
      this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(99, 54);
      this.btnSearch.TabIndex = 5;
      this.btnSearch.Text = "Buscar componentes";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Visible = false;
      this.btnSearch.Click += new System.EventHandler(this.BtnBuscarComponetes_Click);
      // 
      // dgvListComponents
      // 
      this.dgvListComponents.AllowUserToAddRows = false;
      this.dgvListComponents.AllowUserToDeleteRows = false;
      this.dgvListComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvListComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvListComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdComponent,
            this.Itemo,
            this.Class,
            this.Description,
            this.Qty,
            this.Apply});
      this.dgvListComponents.Location = new System.Drawing.Point(19, 410);
      this.dgvListComponents.Margin = new System.Windows.Forms.Padding(4);
      this.dgvListComponents.Name = "dgvListComponents";
      this.dgvListComponents.Size = new System.Drawing.Size(1110, 301);
      this.dgvListComponents.TabIndex = 14;
      // 
      // IdComponent
      // 
      this.IdComponent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.IdComponent.HeaderText = "Id";
      this.IdComponent.Name = "IdComponent";
      this.IdComponent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.IdComponent.Visible = false;
      // 
      // Itemo
      // 
      this.Itemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Itemo.HeaderText = "Número de parte";
      this.Itemo.Name = "Itemo";
      this.Itemo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.Itemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // Class
      // 
      this.Class.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.Class.HeaderText = "Class";
      this.Class.Name = "Class";
      this.Class.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.Class.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.Class.Width = 54;
      // 
      // Description
      // 
      this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.Description.HeaderText = "Descripcion";
      this.Description.Name = "Description";
      // 
      // Qty
      // 
      this.Qty.HeaderText = "Cantidad de material requerido (pza)";
      this.Qty.Name = "Qty";
      // 
      // Apply
      // 
      this.Apply.HeaderText = "Seleccionar componente";
      this.Apply.Name = "Apply";
      // 
      // gpbAgregados
      // 
      this.gpbAgregados.Controls.Add(this.cmbMaterial06);
      this.gpbAgregados.Controls.Add(this.lblMaterial04);
      this.gpbAgregados.Controls.Add(this.lblMaterial06);
      this.gpbAgregados.Controls.Add(this.cmbMaterial04);
      this.gpbAgregados.Controls.Add(this.cmbMaterial05);
      this.gpbAgregados.Controls.Add(this.lblMaterial05);
      this.gpbAgregados.Controls.Add(this.cmbMaterial03);
      this.gpbAgregados.Controls.Add(this.lblMaterial01);
      this.gpbAgregados.Controls.Add(this.lblMaterial03);
      this.gpbAgregados.Controls.Add(this.cmbMaterial01);
      this.gpbAgregados.Controls.Add(this.cmbMaterial02);
      this.gpbAgregados.Controls.Add(this.lblMaterial02);
      this.gpbAgregados.Location = new System.Drawing.Point(601, 258);
      this.gpbAgregados.Margin = new System.Windows.Forms.Padding(4);
      this.gpbAgregados.Name = "gpbAgregados";
      this.gpbAgregados.Padding = new System.Windows.Forms.Padding(4);
      this.gpbAgregados.Size = new System.Drawing.Size(515, 144);
      this.gpbAgregados.TabIndex = 58;
      this.gpbAgregados.TabStop = false;
      this.gpbAgregados.Text = "Construcción";
      this.gpbAgregados.Visible = false;
      // 
      // cmbMaterial06
      // 
      this.cmbMaterial06.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbMaterial06.FormattingEnabled = true;
      this.cmbMaterial06.Location = new System.Drawing.Point(348, 104);
      this.cmbMaterial06.Margin = new System.Windows.Forms.Padding(4);
      this.cmbMaterial06.Name = "cmbMaterial06";
      this.cmbMaterial06.Size = new System.Drawing.Size(160, 28);
      this.cmbMaterial06.TabIndex = 11;
      this.cmbMaterial06.Visible = false;
      this.cmbMaterial06.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial06_SelectedIndexChanged);
      // 
      // lblMaterial04
      // 
      this.lblMaterial04.AutoSize = true;
      this.lblMaterial04.Location = new System.Drawing.Point(7, 80);
      this.lblMaterial04.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblMaterial04.Name = "lblMaterial04";
      this.lblMaterial04.Size = new System.Drawing.Size(87, 20);
      this.lblMaterial04.TabIndex = 68;
      this.lblMaterial04.Text = "Material 04";
      this.lblMaterial04.Visible = false;
      // 
      // lblMaterial06
      // 
      this.lblMaterial06.AutoSize = true;
      this.lblMaterial06.Location = new System.Drawing.Point(344, 80);
      this.lblMaterial06.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblMaterial06.Name = "lblMaterial06";
      this.lblMaterial06.Size = new System.Drawing.Size(87, 20);
      this.lblMaterial06.TabIndex = 70;
      this.lblMaterial06.Text = "Material 06";
      this.lblMaterial06.Visible = false;
      // 
      // cmbMaterial04
      // 
      this.cmbMaterial04.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbMaterial04.FormattingEnabled = true;
      this.cmbMaterial04.Location = new System.Drawing.Point(12, 104);
      this.cmbMaterial04.Margin = new System.Windows.Forms.Padding(4);
      this.cmbMaterial04.Name = "cmbMaterial04";
      this.cmbMaterial04.Size = new System.Drawing.Size(160, 28);
      this.cmbMaterial04.TabIndex = 9;
      this.cmbMaterial04.Visible = false;
      this.cmbMaterial04.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial04_SelectedIndexChanged);
      // 
      // cmbMaterial05
      // 
      this.cmbMaterial05.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbMaterial05.FormattingEnabled = true;
      this.cmbMaterial05.Location = new System.Drawing.Point(180, 104);
      this.cmbMaterial05.Margin = new System.Windows.Forms.Padding(4);
      this.cmbMaterial05.Name = "cmbMaterial05";
      this.cmbMaterial05.Size = new System.Drawing.Size(160, 28);
      this.cmbMaterial05.TabIndex = 10;
      this.cmbMaterial05.Visible = false;
      this.cmbMaterial05.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial05_SelectedIndexChanged);
      // 
      // lblMaterial05
      // 
      this.lblMaterial05.AutoSize = true;
      this.lblMaterial05.Location = new System.Drawing.Point(176, 80);
      this.lblMaterial05.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblMaterial05.Name = "lblMaterial05";
      this.lblMaterial05.Size = new System.Drawing.Size(87, 20);
      this.lblMaterial05.TabIndex = 69;
      this.lblMaterial05.Text = "Material 05";
      this.lblMaterial05.Visible = false;
      // 
      // cmbMaterial03
      // 
      this.cmbMaterial03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbMaterial03.FormattingEnabled = true;
      this.cmbMaterial03.Location = new System.Drawing.Point(348, 48);
      this.cmbMaterial03.Margin = new System.Windows.Forms.Padding(4);
      this.cmbMaterial03.Name = "cmbMaterial03";
      this.cmbMaterial03.Size = new System.Drawing.Size(160, 28);
      this.cmbMaterial03.TabIndex = 8;
      this.cmbMaterial03.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial03_SelectedIndexChanged);
      // 
      // lblMaterial01
      // 
      this.lblMaterial01.AutoSize = true;
      this.lblMaterial01.Location = new System.Drawing.Point(7, 16);
      this.lblMaterial01.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblMaterial01.Name = "lblMaterial01";
      this.lblMaterial01.Size = new System.Drawing.Size(87, 20);
      this.lblMaterial01.TabIndex = 62;
      this.lblMaterial01.Text = "Material 01";
      // 
      // lblMaterial03
      // 
      this.lblMaterial03.AutoSize = true;
      this.lblMaterial03.Location = new System.Drawing.Point(344, 16);
      this.lblMaterial03.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblMaterial03.Name = "lblMaterial03";
      this.lblMaterial03.Size = new System.Drawing.Size(87, 20);
      this.lblMaterial03.TabIndex = 64;
      this.lblMaterial03.Text = "Material 03";
      // 
      // cmbMaterial01
      // 
      this.cmbMaterial01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbMaterial01.FormattingEnabled = true;
      this.cmbMaterial01.Location = new System.Drawing.Point(12, 48);
      this.cmbMaterial01.Margin = new System.Windows.Forms.Padding(4);
      this.cmbMaterial01.Name = "cmbMaterial01";
      this.cmbMaterial01.Size = new System.Drawing.Size(160, 28);
      this.cmbMaterial01.TabIndex = 6;
      this.cmbMaterial01.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial01_SelectedIndexChanged);
      // 
      // cmbMaterial02
      // 
      this.cmbMaterial02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbMaterial02.FormattingEnabled = true;
      this.cmbMaterial02.Location = new System.Drawing.Point(180, 48);
      this.cmbMaterial02.Margin = new System.Windows.Forms.Padding(4);
      this.cmbMaterial02.Name = "cmbMaterial02";
      this.cmbMaterial02.Size = new System.Drawing.Size(160, 28);
      this.cmbMaterial02.TabIndex = 7;
      this.cmbMaterial02.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial02_SelectedIndexChanged);
      // 
      // lblMaterial02
      // 
      this.lblMaterial02.AutoSize = true;
      this.lblMaterial02.Location = new System.Drawing.Point(176, 16);
      this.lblMaterial02.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblMaterial02.Name = "lblMaterial02";
      this.lblMaterial02.Size = new System.Drawing.Size(87, 20);
      this.lblMaterial02.TabIndex = 63;
      this.lblMaterial02.Text = "Material 02";
      // 
      // gpbAcabados
      // 
      this.gpbAcabados.Controls.Add(this.rbnAn);
      this.gpbAcabados.Controls.Add(this.rbnAl);
      this.gpbAcabados.Location = new System.Drawing.Point(544, 15);
      this.gpbAcabados.Margin = new System.Windows.Forms.Padding(4);
      this.gpbAcabados.Name = "gpbAcabados";
      this.gpbAcabados.Padding = new System.Windows.Forms.Padding(4);
      this.gpbAcabados.Size = new System.Drawing.Size(179, 56);
      this.gpbAcabados.TabIndex = 57;
      this.gpbAcabados.TabStop = false;
      this.gpbAcabados.Text = "Tipo de componentes";
      this.gpbAcabados.Visible = false;
      // 
      // rbnAn
      // 
      this.rbnAn.AutoSize = true;
      this.rbnAn.Location = new System.Drawing.Point(79, 26);
      this.rbnAn.Margin = new System.Windows.Forms.Padding(4);
      this.rbnAn.Name = "rbnAn";
      this.rbnAn.Size = new System.Drawing.Size(49, 24);
      this.rbnAn.TabIndex = 4;
      this.rbnAn.TabStop = true;
      this.rbnAn.Text = "AN";
      this.rbnAn.UseVisualStyleBackColor = true;
      // 
      // rbnAl
      // 
      this.rbnAl.AutoSize = true;
      this.rbnAl.Location = new System.Drawing.Point(8, 26);
      this.rbnAl.Margin = new System.Windows.Forms.Padding(4);
      this.rbnAl.Name = "rbnAl";
      this.rbnAl.Size = new System.Drawing.Size(47, 24);
      this.rbnAl.TabIndex = 3;
      this.rbnAl.TabStop = true;
      this.rbnAl.Text = "AL";
      this.rbnAl.UseVisualStyleBackColor = true;
      // 
      // cmbListModelL0
      // 
      this.cmbListModelL0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbListModelL0.FormattingEnabled = true;
      this.cmbListModelL0.Location = new System.Drawing.Point(21, 43);
      this.cmbListModelL0.Margin = new System.Windows.Forms.Padding(4);
      this.cmbListModelL0.Name = "cmbListModelL0";
      this.cmbListModelL0.Size = new System.Drawing.Size(226, 28);
      this.cmbListModelL0.TabIndex = 1;
      this.cmbListModelL0.SelectedIndexChanged += new System.EventHandler(this.CmbListModelL0_SelectedIndexChanged);
      // 
      // lblSubNivelBomsL1
      // 
      this.lblSubNivelBomsL1.AutoSize = true;
      this.lblSubNivelBomsL1.Location = new System.Drawing.Point(251, 15);
      this.lblSubNivelBomsL1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSubNivelBomsL1.Name = "lblSubNivelBomsL1";
      this.lblSubNivelBomsL1.Size = new System.Drawing.Size(163, 20);
      this.lblSubNivelBomsL1.TabIndex = 20;
      this.lblSubNivelBomsL1.Text = "Modelos relacionados";
      this.lblSubNivelBomsL1.Visible = false;
      // 
      // cmbListModelL1
      // 
      this.cmbListModelL1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbListModelL1.FormattingEnabled = true;
      this.cmbListModelL1.Location = new System.Drawing.Point(255, 43);
      this.cmbListModelL1.Margin = new System.Windows.Forms.Padding(4);
      this.cmbListModelL1.Name = "cmbListModelL1";
      this.cmbListModelL1.Size = new System.Drawing.Size(281, 28);
      this.cmbListModelL1.TabIndex = 2;
      this.cmbListModelL1.Visible = false;
      this.cmbListModelL1.SelectedIndexChanged += new System.EventHandler(this.CmbListModelL1_SelectedIndexChanged);
      // 
      // lblListadoBomL0
      // 
      this.lblListadoBomL0.AutoSize = true;
      this.lblListadoBomL0.Location = new System.Drawing.Point(16, 15);
      this.lblListadoBomL0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblListadoBomL0.Name = "lblListadoBomL0";
      this.lblListadoBomL0.Size = new System.Drawing.Size(126, 20);
      this.lblListadoBomL0.TabIndex = 17;
      this.lblListadoBomL0.Text = "Modelo de boms";
      // 
      // tbpCreacionModelos
      // 
      this.tbpCreacionModelos.Controls.Add(this.gpbModel0);
      this.tbpCreacionModelos.Controls.Add(this.gvbModelL1);
      this.tbpCreacionModelos.Location = new System.Drawing.Point(4, 29);
      this.tbpCreacionModelos.Margin = new System.Windows.Forms.Padding(4);
      this.tbpCreacionModelos.Name = "tbpCreacionModelos";
      this.tbpCreacionModelos.Padding = new System.Windows.Forms.Padding(4);
      this.tbpCreacionModelos.Size = new System.Drawing.Size(1152, 719);
      this.tbpCreacionModelos.TabIndex = 4;
      this.tbpCreacionModelos.Text = "Configurador de modelos";
      this.tbpCreacionModelos.UseVisualStyleBackColor = true;
      // 
      // gpbModel0
      // 
      this.gpbModel0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gpbModel0.Controls.Add(this.txtEnglishDescription);
      this.gpbModel0.Controls.Add(this.txtLargeDescription);
      this.gpbModel0.Controls.Add(this.lblDescripcionIngles);
      this.gpbModel0.Controls.Add(this.lblDescripcionLarga);
      this.gpbModel0.Controls.Add(this.btnEliminar0);
      this.gpbModel0.Controls.Add(this.btnEditar0);
      this.gpbModel0.Controls.Add(this.btnCrear0);
      this.gpbModel0.Controls.Add(this.dgvModeloL0);
      this.gpbModel0.Controls.Add(this.txtDescripcionL0);
      this.gpbModel0.Controls.Add(this.label11);
      this.gpbModel0.Controls.Add(this.txtNombreL0);
      this.gpbModel0.Controls.Add(this.label12);
      this.gpbModel0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.gpbModel0.Location = new System.Drawing.Point(8, 7);
      this.gpbModel0.Margin = new System.Windows.Forms.Padding(4);
      this.gpbModel0.Name = "gpbModel0";
      this.gpbModel0.Padding = new System.Windows.Forms.Padding(4);
      this.gpbModel0.Size = new System.Drawing.Size(1135, 350);
      this.gpbModel0.TabIndex = 11;
      this.gpbModel0.TabStop = false;
      this.gpbModel0.Text = "Familias boms";
      this.gpbModel0.Enter += new System.EventHandler(this.gpbModel0_Enter);
      // 
      // txtEnglishDescription
      // 
      this.txtEnglishDescription.Location = new System.Drawing.Point(843, 51);
      this.txtEnglishDescription.Margin = new System.Windows.Forms.Padding(4);
      this.txtEnglishDescription.Name = "txtEnglishDescription";
      this.txtEnglishDescription.Size = new System.Drawing.Size(269, 26);
      this.txtEnglishDescription.TabIndex = 4;
      this.txtEnglishDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtLargeDescription
      // 
      this.txtLargeDescription.Location = new System.Drawing.Point(566, 51);
      this.txtLargeDescription.Margin = new System.Windows.Forms.Padding(4);
      this.txtLargeDescription.Name = "txtLargeDescription";
      this.txtLargeDescription.Size = new System.Drawing.Size(269, 26);
      this.txtLargeDescription.TabIndex = 3;
      this.txtLargeDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lblDescripcionIngles
      // 
      this.lblDescripcionIngles.AutoSize = true;
      this.lblDescripcionIngles.Location = new System.Drawing.Point(843, 27);
      this.lblDescripcionIngles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblDescripcionIngles.Name = "lblDescripcionIngles";
      this.lblDescripcionIngles.Size = new System.Drawing.Size(137, 20);
      this.lblDescripcionIngles.TabIndex = 11;
      this.lblDescripcionIngles.Text = "Descripción inglés";
      // 
      // lblDescripcionLarga
      // 
      this.lblDescripcionLarga.AutoSize = true;
      this.lblDescripcionLarga.Location = new System.Drawing.Point(562, 27);
      this.lblDescripcionLarga.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblDescripcionLarga.Name = "lblDescripcionLarga";
      this.lblDescripcionLarga.Size = new System.Drawing.Size(131, 20);
      this.lblDescripcionLarga.TabIndex = 10;
      this.lblDescripcionLarga.Text = "Descripción larga";
      // 
      // btnEliminar0
      // 
      this.btnEliminar0.Location = new System.Drawing.Point(398, 85);
      this.btnEliminar0.Margin = new System.Windows.Forms.Padding(4);
      this.btnEliminar0.Name = "btnEliminar0";
      this.btnEliminar0.Size = new System.Drawing.Size(177, 46);
      this.btnEliminar0.TabIndex = 7;
      this.btnEliminar0.Text = "Eliminar modelo";
      this.btnEliminar0.UseVisualStyleBackColor = true;
      this.btnEliminar0.Click += new System.EventHandler(this.BtnEliminarModelo0_Click);
      // 
      // btnEditar0
      // 
      this.btnEditar0.Location = new System.Drawing.Point(204, 85);
      this.btnEditar0.Margin = new System.Windows.Forms.Padding(4);
      this.btnEditar0.Name = "btnEditar0";
      this.btnEditar0.Size = new System.Drawing.Size(177, 46);
      this.btnEditar0.TabIndex = 6;
      this.btnEditar0.Text = "Editar modelo";
      this.btnEditar0.UseVisualStyleBackColor = true;
      this.btnEditar0.Click += new System.EventHandler(this.BtnEditarModelo0_Click);
      // 
      // btnCrear0
      // 
      this.btnCrear0.Location = new System.Drawing.Point(12, 85);
      this.btnCrear0.Margin = new System.Windows.Forms.Padding(4);
      this.btnCrear0.Name = "btnCrear0";
      this.btnCrear0.Size = new System.Drawing.Size(177, 46);
      this.btnCrear0.TabIndex = 5;
      this.btnCrear0.Text = "Guardar";
      this.btnCrear0.UseVisualStyleBackColor = true;
      this.btnCrear0.Click += new System.EventHandler(this.BtnCrearModelo0_Click);
      // 
      // dgvModeloL0
      // 
      this.dgvModeloL0.AllowUserToAddRows = false;
      this.dgvModeloL0.AllowUserToDeleteRows = false;
      this.dgvModeloL0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvModeloL0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvModeloL0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdModeloL0,
            this.NombreModeloL0,
            this.DescripcionModeloL0,
            this.LargeDescription,
            this.EnglishDescription});
      this.dgvModeloL0.Location = new System.Drawing.Point(17, 139);
      this.dgvModeloL0.Margin = new System.Windows.Forms.Padding(4);
      this.dgvModeloL0.Name = "dgvModeloL0";
      this.dgvModeloL0.ReadOnly = true;
      this.dgvModeloL0.Size = new System.Drawing.Size(1108, 203);
      this.dgvModeloL0.TabIndex = 8;
      this.dgvModeloL0.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModeloL0_CellContentClick);
      // 
      // IdModeloL0
      // 
      this.IdModeloL0.HeaderText = "#";
      this.IdModeloL0.Name = "IdModeloL0";
      this.IdModeloL0.ReadOnly = true;
      this.IdModeloL0.Width = 43;
      // 
      // NombreModeloL0
      // 
      this.NombreModeloL0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.NombreModeloL0.HeaderText = "Nombre del modelo";
      this.NombreModeloL0.Name = "NombreModeloL0";
      this.NombreModeloL0.ReadOnly = true;
      // 
      // DescripcionModeloL0
      // 
      this.DescripcionModeloL0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.DescripcionModeloL0.HeaderText = "Descripcion modelo";
      this.DescripcionModeloL0.Name = "DescripcionModeloL0";
      this.DescripcionModeloL0.ReadOnly = true;
      // 
      // LargeDescription
      // 
      this.LargeDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.LargeDescription.HeaderText = "Descripción larga";
      this.LargeDescription.Name = "LargeDescription";
      this.LargeDescription.ReadOnly = true;
      // 
      // EnglishDescription
      // 
      this.EnglishDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.EnglishDescription.HeaderText = "Descripción en ingles";
      this.EnglishDescription.Name = "EnglishDescription";
      this.EnglishDescription.ReadOnly = true;
      // 
      // txtDescripcionL0
      // 
      this.txtDescripcionL0.Location = new System.Drawing.Point(289, 51);
      this.txtDescripcionL0.Margin = new System.Windows.Forms.Padding(4);
      this.txtDescripcionL0.Name = "txtDescripcionL0";
      this.txtDescripcionL0.Size = new System.Drawing.Size(269, 26);
      this.txtDescripcionL0.TabIndex = 2;
      this.txtDescripcionL0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(289, 27);
      this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(148, 20);
      this.label11.TabIndex = 2;
      this.label11.Text = "Descripcion modelo";
      // 
      // txtNombreL0
      // 
      this.txtNombreL0.Location = new System.Drawing.Point(12, 51);
      this.txtNombreL0.Margin = new System.Windows.Forms.Padding(4);
      this.txtNombreL0.Name = "txtNombreL0";
      this.txtNombreL0.Size = new System.Drawing.Size(269, 26);
      this.txtNombreL0.TabIndex = 1;
      this.txtNombreL0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(9, 27);
      this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(156, 20);
      this.label12.TabIndex = 0;
      this.label12.Text = "Nombre modelo bom";
      // 
      // gvbModelL1
      // 
      this.gvbModelL1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gvbModelL1.Controls.Add(this.cmbMfgCell);
      this.gvbModelL1.Controls.Add(this.lblMfg_Cell);
      this.gvbModelL1.Controls.Add(this.dgvModeloL1);
      this.gvbModelL1.Controls.Add(this.cmbModeloL0);
      this.gvbModelL1.Controls.Add(this.label13);
      this.gvbModelL1.Controls.Add(this.btnEliminarL1);
      this.gvbModelL1.Controls.Add(this.btnEditarL1);
      this.gvbModelL1.Controls.Add(this.btnCrearL1);
      this.gvbModelL1.Controls.Add(this.txtDescripcionL1);
      this.gvbModelL1.Controls.Add(this.lblDescripcionModelo);
      this.gvbModelL1.Controls.Add(this.txtNombreL1);
      this.gvbModelL1.Controls.Add(this.lblNombreModelo);
      this.gvbModelL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.gvbModelL1.Location = new System.Drawing.Point(8, 365);
      this.gvbModelL1.Margin = new System.Windows.Forms.Padding(4);
      this.gvbModelL1.Name = "gvbModelL1";
      this.gvbModelL1.Padding = new System.Windows.Forms.Padding(4);
      this.gvbModelL1.Size = new System.Drawing.Size(1138, 350);
      this.gvbModelL1.TabIndex = 0;
      this.gvbModelL1.TabStop = false;
      this.gvbModelL1.Text = "Modelos boms";
      this.gvbModelL1.Enter += new System.EventHandler(this.gvbModelL1_Enter);
      // 
      // cmbMfgCell
      // 
      this.cmbMfgCell.DropDownHeight = 150;
      this.cmbMfgCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbMfgCell.DropDownWidth = 50;
      this.cmbMfgCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmbMfgCell.FormattingEnabled = true;
      this.cmbMfgCell.IntegralHeight = false;
      this.cmbMfgCell.Location = new System.Drawing.Point(843, 48);
      this.cmbMfgCell.Margin = new System.Windows.Forms.Padding(4);
      this.cmbMfgCell.Name = "cmbMfgCell";
      this.cmbMfgCell.Size = new System.Drawing.Size(269, 26);
      this.cmbMfgCell.TabIndex = 12;
      // 
      // lblMfg_Cell
      // 
      this.lblMfg_Cell.AutoSize = true;
      this.lblMfg_Cell.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMfg_Cell.Location = new System.Drawing.Point(843, 20);
      this.lblMfg_Cell.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblMfg_Cell.Name = "lblMfg_Cell";
      this.lblMfg_Cell.Size = new System.Drawing.Size(196, 18);
      this.lblMfg_Cell.TabIndex = 19;
      this.lblMfg_Cell.Text = "Seleccione centro de trabajo";
      // 
      // dgvModeloL1
      // 
      this.dgvModeloL1.AllowUserToAddRows = false;
      this.dgvModeloL1.AllowUserToDeleteRows = false;
      this.dgvModeloL1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvModeloL1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvModeloL1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdModelo,
            this.NombreModelo,
            this.DescripcionModelo,
            this.DescripcionExt});
      this.dgvModeloL1.Location = new System.Drawing.Point(15, 140);
      this.dgvModeloL1.Margin = new System.Windows.Forms.Padding(4);
      this.dgvModeloL1.Name = "dgvModeloL1";
      this.dgvModeloL1.ReadOnly = true;
      this.dgvModeloL1.Size = new System.Drawing.Size(1115, 202);
      this.dgvModeloL1.TabIndex = 16;
      this.dgvModeloL1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModeloL1_CellContentClick);
      // 
      // IdModelo
      // 
      this.IdModelo.HeaderText = "#";
      this.IdModelo.Name = "IdModelo";
      this.IdModelo.ReadOnly = true;
      this.IdModelo.Width = 43;
      // 
      // NombreModelo
      // 
      this.NombreModelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.NombreModelo.HeaderText = "Nombre del modelo";
      this.NombreModelo.Name = "NombreModelo";
      this.NombreModelo.ReadOnly = true;
      // 
      // DescripcionModelo
      // 
      this.DescripcionModelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.DescripcionModelo.HeaderText = "Descripcion modelo";
      this.DescripcionModelo.Name = "DescripcionModelo";
      this.DescripcionModelo.ReadOnly = true;
      // 
      // DescripcionExt
      // 
      this.DescripcionExt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.DescripcionExt.HeaderText = "Secuencia";
      this.DescripcionExt.Name = "DescripcionExt";
      this.DescripcionExt.ReadOnly = true;
      // 
      // cmbModeloL0
      // 
      this.cmbModeloL0.DropDownHeight = 150;
      this.cmbModeloL0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbModeloL0.DropDownWidth = 100;
      this.cmbModeloL0.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cmbModeloL0.FormattingEnabled = true;
      this.cmbModeloL0.IntegralHeight = false;
      this.cmbModeloL0.Location = new System.Drawing.Point(15, 48);
      this.cmbModeloL0.Margin = new System.Windows.Forms.Padding(4);
      this.cmbModeloL0.Name = "cmbModeloL0";
      this.cmbModeloL0.Size = new System.Drawing.Size(266, 26);
      this.cmbModeloL0.TabIndex = 9;
      this.cmbModeloL0.SelectedIndexChanged += new System.EventHandler(this.CmbModeloL0_SelectedIndexChanged);
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label13.Location = new System.Drawing.Point(8, 20);
      this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(193, 18);
      this.label13.TabIndex = 15;
      this.label13.Text = "Seleccione modelo superior";
      // 
      // btnEliminarL1
      // 
      this.btnEliminarL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnEliminarL1.Location = new System.Drawing.Point(345, 90);
      this.btnEliminarL1.Margin = new System.Windows.Forms.Padding(4);
      this.btnEliminarL1.Name = "btnEliminarL1";
      this.btnEliminarL1.Size = new System.Drawing.Size(157, 42);
      this.btnEliminarL1.TabIndex = 15;
      this.btnEliminarL1.Text = "Eliminar modelo";
      this.btnEliminarL1.UseVisualStyleBackColor = true;
      this.btnEliminarL1.Click += new System.EventHandler(this.BtnEliminarL1_Click);
      // 
      // btnEditarL1
      // 
      this.btnEditarL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnEditarL1.Location = new System.Drawing.Point(180, 90);
      this.btnEditarL1.Margin = new System.Windows.Forms.Padding(4);
      this.btnEditarL1.Name = "btnEditarL1";
      this.btnEditarL1.Size = new System.Drawing.Size(157, 42);
      this.btnEditarL1.TabIndex = 14;
      this.btnEditarL1.Text = "Editar modelo";
      this.btnEditarL1.UseVisualStyleBackColor = true;
      this.btnEditarL1.Click += new System.EventHandler(this.BtnEditarL1_Click);
      // 
      // btnCrearL1
      // 
      this.btnCrearL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCrearL1.Location = new System.Drawing.Point(15, 90);
      this.btnCrearL1.Margin = new System.Windows.Forms.Padding(4);
      this.btnCrearL1.Name = "btnCrearL1";
      this.btnCrearL1.Size = new System.Drawing.Size(157, 42);
      this.btnCrearL1.TabIndex = 13;
      this.btnCrearL1.Text = "Guardar";
      this.btnCrearL1.UseVisualStyleBackColor = true;
      this.btnCrearL1.Click += new System.EventHandler(this.BtnCrearL1_Click);
      // 
      // txtDescripcionL1
      // 
      this.txtDescripcionL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtDescripcionL1.Location = new System.Drawing.Point(566, 48);
      this.txtDescripcionL1.Margin = new System.Windows.Forms.Padding(4);
      this.txtDescripcionL1.Name = "txtDescripcionL1";
      this.txtDescripcionL1.Size = new System.Drawing.Size(269, 24);
      this.txtDescripcionL1.TabIndex = 11;
      this.txtDescripcionL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lblDescripcionModelo
      // 
      this.lblDescripcionModelo.AutoSize = true;
      this.lblDescripcionModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDescripcionModelo.Location = new System.Drawing.Point(562, 24);
      this.lblDescripcionModelo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblDescripcionModelo.Name = "lblDescripcionModelo";
      this.lblDescripcionModelo.Size = new System.Drawing.Size(141, 18);
      this.lblDescripcionModelo.TabIndex = 2;
      this.lblDescripcionModelo.Text = "Descripcion modelo";
      // 
      // txtNombreL1
      // 
      this.txtNombreL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtNombreL1.Location = new System.Drawing.Point(289, 50);
      this.txtNombreL1.Margin = new System.Windows.Forms.Padding(4);
      this.txtNombreL1.Name = "txtNombreL1";
      this.txtNombreL1.Size = new System.Drawing.Size(269, 24);
      this.txtNombreL1.TabIndex = 10;
      this.txtNombreL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lblNombreModelo
      // 
      this.lblNombreModelo.AutoSize = true;
      this.lblNombreModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblNombreModelo.Location = new System.Drawing.Point(289, 20);
      this.lblNombreModelo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblNombreModelo.Name = "lblNombreModelo";
      this.lblNombreModelo.Size = new System.Drawing.Size(150, 18);
      this.lblNombreModelo.TabIndex = 0;
      this.lblNombreModelo.Text = "Nombre modelo bom";
      // 
      // tbpConfiguracionInicial
      // 
      this.tbpConfiguracionInicial.Controls.Add(this.gpbSubMaterials);
      this.tbpConfiguracionInicial.Controls.Add(this.gpbTypeMaterial);
      this.tbpConfiguracionInicial.Location = new System.Drawing.Point(4, 29);
      this.tbpConfiguracionInicial.Margin = new System.Windows.Forms.Padding(4);
      this.tbpConfiguracionInicial.Name = "tbpConfiguracionInicial";
      this.tbpConfiguracionInicial.Padding = new System.Windows.Forms.Padding(4);
      this.tbpConfiguracionInicial.Size = new System.Drawing.Size(1152, 719);
      this.tbpConfiguracionInicial.TabIndex = 7;
      this.tbpConfiguracionInicial.Text = "Configuracion inicial";
      this.tbpConfiguracionInicial.UseVisualStyleBackColor = true;
      // 
      // gpbSubMaterials
      // 
      this.gpbSubMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gpbSubMaterials.Controls.Add(this.lblSubMaterialDescription);
      this.gpbSubMaterials.Controls.Add(this.dgvListSubMaterials);
      this.gpbSubMaterials.Controls.Add(this.btnDeleteSubMaterial);
      this.gpbSubMaterials.Controls.Add(this.txtDescriptionSubMaterial);
      this.gpbSubMaterials.Controls.Add(this.btnEditSubtMaterial);
      this.gpbSubMaterials.Controls.Add(this.cmbChoiceMaterial);
      this.gpbSubMaterials.Controls.Add(this.btnSaveSubMaterial);
      this.gpbSubMaterials.Controls.Add(this.txtNameSubMaterial);
      this.gpbSubMaterials.Controls.Add(this.lblChoice);
      this.gpbSubMaterials.Controls.Add(this.lblSubMaterial);
      this.gpbSubMaterials.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.gpbSubMaterials.Location = new System.Drawing.Point(13, 318);
      this.gpbSubMaterials.Margin = new System.Windows.Forms.Padding(4);
      this.gpbSubMaterials.Name = "gpbSubMaterials";
      this.gpbSubMaterials.Padding = new System.Windows.Forms.Padding(4);
      this.gpbSubMaterials.Size = new System.Drawing.Size(1123, 356);
      this.gpbSubMaterials.TabIndex = 7;
      this.gpbSubMaterials.TabStop = false;
      this.gpbSubMaterials.Text = "Definición de sub materiales";
      // 
      // lblSubMaterialDescription
      // 
      this.lblSubMaterialDescription.AutoSize = true;
      this.lblSubMaterialDescription.Location = new System.Drawing.Point(628, 25);
      this.lblSubMaterialDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSubMaterialDescription.Name = "lblSubMaterialDescription";
      this.lblSubMaterialDescription.Size = new System.Drawing.Size(207, 20);
      this.lblSubMaterialDescription.TabIndex = 10;
      this.lblSubMaterialDescription.Text = "Descripción del sub material";
      // 
      // dgvListSubMaterials
      // 
      this.dgvListSubMaterials.AllowUserToAddRows = false;
      this.dgvListSubMaterials.AllowUserToDeleteRows = false;
      this.dgvListSubMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvListSubMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvListSubMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdSubMaterial,
            this.IdMaterialBase,
            this.MaterialBase,
            this.NameSubMaterial,
            this.DescriptionSubMaterial});
      this.dgvListSubMaterials.Location = new System.Drawing.Point(15, 152);
      this.dgvListSubMaterials.Margin = new System.Windows.Forms.Padding(4);
      this.dgvListSubMaterials.Name = "dgvListSubMaterials";
      this.dgvListSubMaterials.ReadOnly = true;
      this.dgvListSubMaterials.Size = new System.Drawing.Size(1097, 199);
      this.dgvListSubMaterials.TabIndex = 13;
      // 
      // IdSubMaterial
      // 
      this.IdSubMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.IdSubMaterial.HeaderText = "#";
      this.IdSubMaterial.Name = "IdSubMaterial";
      this.IdSubMaterial.ReadOnly = true;
      // 
      // IdMaterialBase
      // 
      this.IdMaterialBase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.IdMaterialBase.HeaderText = "IdMaterialBase";
      this.IdMaterialBase.Name = "IdMaterialBase";
      this.IdMaterialBase.ReadOnly = true;
      this.IdMaterialBase.Visible = false;
      // 
      // MaterialBase
      // 
      this.MaterialBase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.MaterialBase.HeaderText = "Material base";
      this.MaterialBase.Name = "MaterialBase";
      this.MaterialBase.ReadOnly = true;
      // 
      // NameSubMaterial
      // 
      this.NameSubMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.NameSubMaterial.HeaderText = "Nombre del sub material";
      this.NameSubMaterial.Name = "NameSubMaterial";
      this.NameSubMaterial.ReadOnly = true;
      // 
      // DescriptionSubMaterial
      // 
      this.DescriptionSubMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.DescriptionSubMaterial.HeaderText = "Descripción de sub material";
      this.DescriptionSubMaterial.Name = "DescriptionSubMaterial";
      this.DescriptionSubMaterial.ReadOnly = true;
      // 
      // btnDeleteSubMaterial
      // 
      this.btnDeleteSubMaterial.Location = new System.Drawing.Point(286, 95);
      this.btnDeleteSubMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.btnDeleteSubMaterial.Name = "btnDeleteSubMaterial";
      this.btnDeleteSubMaterial.Size = new System.Drawing.Size(123, 50);
      this.btnDeleteSubMaterial.TabIndex = 12;
      this.btnDeleteSubMaterial.Text = "Eliminar";
      this.btnDeleteSubMaterial.UseVisualStyleBackColor = true;
      this.btnDeleteSubMaterial.Click += new System.EventHandler(this.BtnDeleteSubMaterial_Click);
      // 
      // txtDescriptionSubMaterial
      // 
      this.txtDescriptionSubMaterial.Location = new System.Drawing.Point(633, 59);
      this.txtDescriptionSubMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.txtDescriptionSubMaterial.Name = "txtDescriptionSubMaterial";
      this.txtDescriptionSubMaterial.Size = new System.Drawing.Size(345, 26);
      this.txtDescriptionSubMaterial.TabIndex = 9;
      this.txtDescriptionSubMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // btnEditSubtMaterial
      // 
      this.btnEditSubtMaterial.Location = new System.Drawing.Point(144, 95);
      this.btnEditSubtMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.btnEditSubtMaterial.Name = "btnEditSubtMaterial";
      this.btnEditSubtMaterial.Size = new System.Drawing.Size(123, 49);
      this.btnEditSubtMaterial.TabIndex = 11;
      this.btnEditSubtMaterial.Text = "Editar";
      this.btnEditSubtMaterial.UseVisualStyleBackColor = true;
      this.btnEditSubtMaterial.Click += new System.EventHandler(this.BtnEditSubtMaterial_Click);
      // 
      // cmbChoiceMaterial
      // 
      this.cmbChoiceMaterial.DropDownHeight = 200;
      this.cmbChoiceMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbChoiceMaterial.FormattingEnabled = true;
      this.cmbChoiceMaterial.IntegralHeight = false;
      this.cmbChoiceMaterial.Location = new System.Drawing.Point(15, 59);
      this.cmbChoiceMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.cmbChoiceMaterial.MaxDropDownItems = 10;
      this.cmbChoiceMaterial.Name = "cmbChoiceMaterial";
      this.cmbChoiceMaterial.Size = new System.Drawing.Size(295, 28);
      this.cmbChoiceMaterial.TabIndex = 7;
      this.cmbChoiceMaterial.SelectedIndexChanged += new System.EventHandler(this.CmbChoiceMaterial_SelectedIndexChanged);
      // 
      // btnSaveSubMaterial
      // 
      this.btnSaveSubMaterial.Location = new System.Drawing.Point(13, 95);
      this.btnSaveSubMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.btnSaveSubMaterial.Name = "btnSaveSubMaterial";
      this.btnSaveSubMaterial.Size = new System.Drawing.Size(123, 50);
      this.btnSaveSubMaterial.TabIndex = 10;
      this.btnSaveSubMaterial.Text = "Guardar";
      this.btnSaveSubMaterial.UseVisualStyleBackColor = true;
      this.btnSaveSubMaterial.Click += new System.EventHandler(this.BtnSaveSubMaterial_Click);
      // 
      // txtNameSubMaterial
      // 
      this.txtNameSubMaterial.Location = new System.Drawing.Point(345, 59);
      this.txtNameSubMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.txtNameSubMaterial.Name = "txtNameSubMaterial";
      this.txtNameSubMaterial.Size = new System.Drawing.Size(257, 26);
      this.txtNameSubMaterial.TabIndex = 8;
      this.txtNameSubMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lblChoice
      // 
      this.lblChoice.AutoSize = true;
      this.lblChoice.Location = new System.Drawing.Point(8, 25);
      this.lblChoice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblChoice.Name = "lblChoice";
      this.lblChoice.Size = new System.Drawing.Size(139, 20);
      this.lblChoice.TabIndex = 2;
      this.lblChoice.Text = "Elegir tipo material";
      // 
      // lblSubMaterial
      // 
      this.lblSubMaterial.AutoSize = true;
      this.lblSubMaterial.Location = new System.Drawing.Point(340, 25);
      this.lblSubMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSubMaterial.Name = "lblSubMaterial";
      this.lblSubMaterial.Size = new System.Drawing.Size(183, 20);
      this.lblSubMaterial.TabIndex = 4;
      this.lblSubMaterial.Text = "Nombre del Sub material";
      // 
      // gpbTypeMaterial
      // 
      this.gpbTypeMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gpbTypeMaterial.Controls.Add(this.btnDeleteMaterial);
      this.gpbTypeMaterial.Controls.Add(this.btnEditMaterial);
      this.gpbTypeMaterial.Controls.Add(this.btnSaveMaterial);
      this.gpbTypeMaterial.Controls.Add(this.dgvListMaterials);
      this.gpbTypeMaterial.Controls.Add(this.txtDescriptionMaterial);
      this.gpbTypeMaterial.Controls.Add(this.txtNameMaterial);
      this.gpbTypeMaterial.Controls.Add(this.lblDescripcionAccesorio);
      this.gpbTypeMaterial.Controls.Add(this.lblNombreMaterial);
      this.gpbTypeMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.gpbTypeMaterial.Location = new System.Drawing.Point(13, 9);
      this.gpbTypeMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.gpbTypeMaterial.Name = "gpbTypeMaterial";
      this.gpbTypeMaterial.Padding = new System.Windows.Forms.Padding(4);
      this.gpbTypeMaterial.Size = new System.Drawing.Size(1131, 301);
      this.gpbTypeMaterial.TabIndex = 0;
      this.gpbTypeMaterial.TabStop = false;
      this.gpbTypeMaterial.Text = "Definición de materiales";
      // 
      // btnDeleteMaterial
      // 
      this.btnDeleteMaterial.Location = new System.Drawing.Point(996, 31);
      this.btnDeleteMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.btnDeleteMaterial.Name = "btnDeleteMaterial";
      this.btnDeleteMaterial.Size = new System.Drawing.Size(127, 57);
      this.btnDeleteMaterial.TabIndex = 5;
      this.btnDeleteMaterial.Text = "Eliminar";
      this.btnDeleteMaterial.UseVisualStyleBackColor = true;
      this.btnDeleteMaterial.Click += new System.EventHandler(this.BtnDeleteMaterial_Click);
      // 
      // btnEditMaterial
      // 
      this.btnEditMaterial.Location = new System.Drawing.Point(861, 31);
      this.btnEditMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.btnEditMaterial.Name = "btnEditMaterial";
      this.btnEditMaterial.Size = new System.Drawing.Size(127, 57);
      this.btnEditMaterial.TabIndex = 4;
      this.btnEditMaterial.Text = "Editar";
      this.btnEditMaterial.UseVisualStyleBackColor = true;
      this.btnEditMaterial.Click += new System.EventHandler(this.BtnEditMaterial_Click);
      // 
      // btnSaveMaterial
      // 
      this.btnSaveMaterial.Location = new System.Drawing.Point(700, 31);
      this.btnSaveMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.btnSaveMaterial.Name = "btnSaveMaterial";
      this.btnSaveMaterial.Size = new System.Drawing.Size(127, 57);
      this.btnSaveMaterial.TabIndex = 3;
      this.btnSaveMaterial.Text = "Guardar";
      this.btnSaveMaterial.UseVisualStyleBackColor = true;
      this.btnSaveMaterial.Click += new System.EventHandler(this.BtnSaveMaterial_Click);
      // 
      // dgvListMaterials
      // 
      this.dgvListMaterials.AllowUserToAddRows = false;
      this.dgvListMaterials.AllowUserToDeleteRows = false;
      this.dgvListMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvListMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvListMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMaterial,
            this.NameMaterial,
            this.DescriptionMaterial});
      this.dgvListMaterials.Location = new System.Drawing.Point(15, 89);
      this.dgvListMaterials.Margin = new System.Windows.Forms.Padding(4);
      this.dgvListMaterials.Name = "dgvListMaterials";
      this.dgvListMaterials.ReadOnly = true;
      this.dgvListMaterials.Size = new System.Drawing.Size(1105, 204);
      this.dgvListMaterials.TabIndex = 6;
      // 
      // IdMaterial
      // 
      this.IdMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.IdMaterial.HeaderText = "#";
      this.IdMaterial.Name = "IdMaterial";
      this.IdMaterial.ReadOnly = true;
      this.IdMaterial.Width = 43;
      // 
      // NameMaterial
      // 
      this.NameMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.NameMaterial.HeaderText = "Nombre del material";
      this.NameMaterial.Name = "NameMaterial";
      this.NameMaterial.ReadOnly = true;
      // 
      // DescriptionMaterial
      // 
      this.DescriptionMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.DescriptionMaterial.HeaderText = "Descripción del material";
      this.DescriptionMaterial.Name = "DescriptionMaterial";
      this.DescriptionMaterial.ReadOnly = true;
      // 
      // txtDescriptionMaterial
      // 
      this.txtDescriptionMaterial.Location = new System.Drawing.Point(391, 55);
      this.txtDescriptionMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.txtDescriptionMaterial.Name = "txtDescriptionMaterial";
      this.txtDescriptionMaterial.Size = new System.Drawing.Size(301, 26);
      this.txtDescriptionMaterial.TabIndex = 2;
      this.txtDescriptionMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtNameMaterial
      // 
      this.txtNameMaterial.Location = new System.Drawing.Point(15, 55);
      this.txtNameMaterial.Margin = new System.Windows.Forms.Padding(4);
      this.txtNameMaterial.Name = "txtNameMaterial";
      this.txtNameMaterial.Size = new System.Drawing.Size(329, 26);
      this.txtNameMaterial.TabIndex = 1;
      this.txtNameMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // lblDescripcionAccesorio
      // 
      this.lblDescripcionAccesorio.AutoSize = true;
      this.lblDescripcionAccesorio.Location = new System.Drawing.Point(385, 25);
      this.lblDescripcionAccesorio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblDescripcionAccesorio.Name = "lblDescripcionAccesorio";
      this.lblDescripcionAccesorio.Size = new System.Drawing.Size(177, 20);
      this.lblDescripcionAccesorio.TabIndex = 1;
      this.lblDescripcionAccesorio.Text = "Descripción del material";
      // 
      // lblNombreMaterial
      // 
      this.lblNombreMaterial.AutoSize = true;
      this.lblNombreMaterial.Location = new System.Drawing.Point(9, 25);
      this.lblNombreMaterial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblNombreMaterial.Name = "lblNombreMaterial";
      this.lblNombreMaterial.Size = new System.Drawing.Size(150, 20);
      this.lblNombreMaterial.TabIndex = 0;
      this.lblNombreMaterial.Text = "Nombre del material";
      // 
      // tbcControlPanel
      // 
      this.tbcControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbcControlPanel.Controls.Add(this.tbpConfiguracionInicial);
      this.tbcControlPanel.Controls.Add(this.tbpCreacionModelos);
      this.tbcControlPanel.Controls.Add(this.tbpConstruccionBomComponente);
      this.tbcControlPanel.Controls.Add(this.tbPCatalogoFormulas);
      this.tbcControlPanel.Controls.Add(this.tbpCondicionales);
      this.tbcControlPanel.Controls.Add(this.tbpClonado);
      this.tbcControlPanel.Controls.Add(this.tbpAsociarComponenteFormula);
      this.tbcControlPanel.Controls.Add(this.tabPage1);
      this.tbcControlPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbcControlPanel.Location = new System.Drawing.Point(-1, -2);
      this.tbcControlPanel.Margin = new System.Windows.Forms.Padding(4);
      this.tbcControlPanel.Name = "tbcControlPanel";
      this.tbcControlPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.tbcControlPanel.SelectedIndex = 0;
      this.tbcControlPanel.Size = new System.Drawing.Size(1160, 752);
      this.tbcControlPanel.TabIndex = 0;
      // 
      // frmConfigurationGlobal
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
      this.ClientSize = new System.Drawing.Size(1159, 749);
      this.Controls.Add(this.tbcControlPanel);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "frmConfigurationGlobal";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Configuracion global del generador de boms";
      this.Load += new System.EventHandler(this.FrmConfigurationGlobal_Load);
      this.tabPage1.ResumeLayout(false);
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvListRelaExistentes)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvFamilyRelaList)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvProccessRelaList)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgvSecuencesRelaList)).EndInit();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvProcessList)).EndInit();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvSecuenceList)).EndInit();
      this.tbpAsociarComponenteFormula.ResumeLayout(false);
      this.tbpAsociarComponenteFormula.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvCombinacionesFormulas)).EndInit();
      this.gpbShowFormulas.ResumeLayout(false);
      this.gpbShowFormulas.PerformLayout();
      this.gpbShowConditional.ResumeLayout(false);
      this.gpbAcabadosAsociar.ResumeLayout(false);
      this.gpbAcabadosAsociar.PerformLayout();
      this.tbpClonado.ResumeLayout(false);
      this.tbpClonado.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.gb_Destino.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvClonDestino)).EndInit();
      this.gb_ClonOrigen.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvOrigenClon)).EndInit();
      this.tbpCondicionales.ResumeLayout(false);
      this.tbpCondicionales.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pb_BuscarFormula)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_ActualizarCondicional)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_VisualizarCondicional)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_EliminarCondicional)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_Guardar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_Agregar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_Eliminar)).EndInit();
      this.tabCondicionales.ResumeLayout(false);
      this.tbp_Condicionales.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgv_Condicionales)).EndInit();
      this.tbp_CondicionalMaster.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgv_CondicionalesMaster)).EndInit();
      this.tbpFormulas.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgv_Formulas_Condicional)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pb_EditarCondicional)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_GuardarCondicional)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_AgregarCondicionalForm)).EndInit();
      this.tbPCatalogoFormulas.ResumeLayout(false);
      this.gpbCantidades.ResumeLayout(false);
      this.gpbCantidades.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgv_Formulas)).EndInit();
      this.tbpConstruccionBomComponente.ResumeLayout(false);
      this.tbpConstruccionBomComponente.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvListComponents)).EndInit();
      this.gpbAgregados.ResumeLayout(false);
      this.gpbAgregados.PerformLayout();
      this.gpbAcabados.ResumeLayout(false);
      this.gpbAcabados.PerformLayout();
      this.tbpCreacionModelos.ResumeLayout(false);
      this.gpbModel0.ResumeLayout(false);
      this.gpbModel0.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvModeloL0)).EndInit();
      this.gvbModelL1.ResumeLayout(false);
      this.gvbModelL1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvModeloL1)).EndInit();
      this.tbpConfiguracionInicial.ResumeLayout(false);
      this.gpbSubMaterials.ResumeLayout(false);
      this.gpbSubMaterials.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvListSubMaterials)).EndInit();
      this.gpbTypeMaterial.ResumeLayout(false);
      this.gpbTypeMaterial.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvListMaterials)).EndInit();
      this.tbcControlPanel.ResumeLayout(false);
      this.ResumeLayout(false);

            }

            #endregion
            private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
            private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
            private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
            private System.Windows.Forms.DataGridViewTextBoxColumn Condicionales_Formula;
            private System.Windows.Forms.TabPage tbpTestCondicional;
            private System.Windows.Forms.TreeView treeView2;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
            private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
            private System.Windows.Forms.DataGridViewTextBoxColumn Subnivel;
            private System.Windows.Forms.DataGridViewTextBoxColumn Id_Formula;
            private System.Windows.Forms.DataGridViewTextBoxColumn Condicional_Tipo;
            private System.Windows.Forms.TabPage tabPage1;
            private System.Windows.Forms.TabPage tbpAsociarComponenteFormula;
            private System.Windows.Forms.Label label36;
            private System.Windows.Forms.Label label35;
            private System.Windows.Forms.TextBox txt_Descripcion;
            private System.Windows.Forms.TextBox txt_Linea;
            private System.Windows.Forms.TextBox txt_Seccion;
            private System.Windows.Forms.TextBox tb_NumeroParte;
            private System.Windows.Forms.Label label34;
            private System.Windows.Forms.Button btn_GuardarFormula;
            private System.Windows.Forms.DataGridView dgvCombinacionesFormulas;
            private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdDetalleComp_;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdCombinacion_;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdComponente;
            private System.Windows.Forms.DataGridViewButtonColumn Editar;
            private System.Windows.Forms.DataGridViewTextBoxColumn ItemnoComponent;
            private System.Windows.Forms.DataGridViewTextBoxColumn NameComponent;
            private System.Windows.Forms.DataGridViewTextBoxColumn ConditionalQty;
            private System.Windows.Forms.DataGridViewTextBoxColumn ConditionalMd;
            private System.Windows.Forms.DataGridViewTextBoxColumn FormulaQty;
            private System.Windows.Forms.DataGridViewTextBoxColumn FormulaMd;
            private System.Windows.Forms.DataGridViewTextBoxColumn FormulaTotal;
            private System.Windows.Forms.DataGridViewTextBoxColumn FormulaPeso;
            private System.Windows.Forms.DataGridViewTextBoxColumn Seccion;
            private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
            private System.Windows.Forms.Label label20;
            private System.Windows.Forms.Label label5;
            private System.Windows.Forms.Label label6;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.ComboBox cb_FormulaPeso;
            private System.Windows.Forms.ComboBox cb_FormulaMedida;
            private System.Windows.Forms.ComboBox cb_FormulaCantidad;
            private System.Windows.Forms.Label label14;
            private System.Windows.Forms.Label label17;
            private System.Windows.Forms.Label label19;
            private System.Windows.Forms.ComboBox cb_FormulaTotal;
            private System.Windows.Forms.ComboBox cb_CondicionalesMedida;
            private System.Windows.Forms.ComboBox cb_CondicionalesCantidad;
            private System.Windows.Forms.Button btn_Clonar;
            private System.Windows.Forms.Button btnEditarFormulas;
            private System.Windows.Forms.ComboBox cmbListadoModelos;
            private System.Windows.Forms.Label lblTipoBom;
            private System.Windows.Forms.GroupBox gpbShowFormulas;
            private System.Windows.Forms.TextBox txtShowFormulas;
            private System.Windows.Forms.GroupBox gpbShowConditional;
            private System.Windows.Forms.TreeView trvShowConditional;
            private System.Windows.Forms.GroupBox gpbAcabadosAsociar;
            private System.Windows.Forms.RadioButton rbnAnAsociar;
            private System.Windows.Forms.RadioButton rbnAlAsociar;
            private System.Windows.Forms.Button btnAsociar;
            private System.Windows.Forms.Button btnBuscarCombinacionesComponentes;
            private System.Windows.Forms.ComboBox cmbCombinacionesBoms;
            private System.Windows.Forms.Label lblCombinaciones;
            private System.Windows.Forms.TabPage tbpClonado;
            private System.Windows.Forms.CheckBox checkBox_AN;
            private System.Windows.Forms.GroupBox groupBox2;
            private System.Windows.Forms.TextBox tb_Descripcion;
            private System.Windows.Forms.Label label30;
            private System.Windows.Forms.Label label31;
            private System.Windows.Forms.TextBox tb_DestinoLinea;
            private System.Windows.Forms.Button btnGuardarComponente;
            private System.Windows.Forms.Button btnEliminarComponente;
            private System.Windows.Forms.ComboBox cbCentroTrabajo;
            private System.Windows.Forms.Label label33;
            private System.Windows.Forms.ComboBox cbFamilias;
            private System.Windows.Forms.Label label32;
            private System.Windows.Forms.Button btnTransferirRegistro;
            private System.Windows.Forms.Button btnBuscarComponentes;
            private System.Windows.Forms.Button btn_SeleccionarTodo;
            private System.Windows.Forms.ComboBox cb_Modelos;
            private System.Windows.Forms.Label label29;
            private System.Windows.Forms.ComboBox cb_Secciones;
            private System.Windows.Forms.Button btn_NuevoModelo;
            private System.Windows.Forms.TextBox txtNuevoModelo;
            private System.Windows.Forms.Label label28;
            private System.Windows.Forms.Label label27;
            private System.Windows.Forms.Label label26;
            private System.Windows.Forms.GroupBox gb_Destino;
            private System.Windows.Forms.DataGridView dgvClonDestino;
            private System.Windows.Forms.DataGridViewButtonColumn Destino_Editar;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_IdCombinacion;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_IdDetalleComp;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_Itemno;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_IdComponente;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_FormulaQty;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_FormulaMd;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_FormulaTotal;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_FormulaPeso;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_CondicionalQty;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_CondicionalMd;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_TypeCondicionalMd;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_TypeCondicionalQty;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_IdCompuestoQty;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_IdCompuestoMd;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_Descripcion;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_Seccion;
            private System.Windows.Forms.DataGridViewTextBoxColumn Destino_Linea;
            private System.Windows.Forms.GroupBox gb_ClonOrigen;
            private System.Windows.Forms.DataGridView dgvOrigenClon;
            private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccion;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdCombinacion_Origen;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdDetalleComp_clon;
            private System.Windows.Forms.DataGridViewTextBoxColumn Itemno;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_IdComponente;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_FormulaQty;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_FormulaMd;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_FormulaTotal;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_FormulaPeso;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_CondicionalQty;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_CondicionalMd;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_TypeCondicionalMd;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_TypeCondicionalQty;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_CompuestoQty;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_CompuestoMd;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_Descripcion;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_Seccion;
            private System.Windows.Forms.DataGridViewTextBoxColumn Origen_Linea;
            private System.Windows.Forms.ComboBox cb_Familias;
            private System.Windows.Forms.TabPage tbpCondicionales;
            private System.Windows.Forms.Label label38;
            private System.Windows.Forms.Label label37;
            private System.Windows.Forms.PictureBox pb_BuscarFormula;
            private System.Windows.Forms.Label label24;
            private System.Windows.Forms.PictureBox pb_ActualizarCondicional;
            private System.Windows.Forms.Label label25;
            private System.Windows.Forms.PictureBox pb_VisualizarCondicional;
            private System.Windows.Forms.Label label23;
            private System.Windows.Forms.Label label22;
            private System.Windows.Forms.Label label21;
            private System.Windows.Forms.PictureBox pb_EliminarCondicional;
            private System.Windows.Forms.TextBox tb_MasterCondicional;
            private System.Windows.Forms.Label label15;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.PictureBox pb_Guardar;
            private System.Windows.Forms.Label lbl_EliminarNodo;
            private System.Windows.Forms.Label lbl_AgregarNodo;
            private System.Windows.Forms.PictureBox pb_Agregar;
            private System.Windows.Forms.PictureBox pb_Eliminar;
            private System.Windows.Forms.TreeView tv_Condicional;
            private System.Windows.Forms.TabControl tabCondicionales;
            private System.Windows.Forms.TabPage tbp_Condicionales;
            private System.Windows.Forms.DataGridView dgv_Condicionales;
            private System.Windows.Forms.DataGridViewTextBoxColumn Id_Condicional;
            private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Condicionales;
            private System.Windows.Forms.DataGridViewTextBoxColumn Condicional_Condicionales;
            private System.Windows.Forms.DataGridViewTextBoxColumn Verdadero_Condicionales;
            private System.Windows.Forms.DataGridViewTextBoxColumn Falso_Condicionales;
            private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Condicional;
            private System.Windows.Forms.TabPage tbp_CondicionalMaster;
            private System.Windows.Forms.DataGridView dgv_CondicionalesMaster;
            private System.Windows.Forms.DataGridViewTextBoxColumn Id_CondicionalMaster;
            private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_CondicionalMaster;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdCompuesto_CondicionalMaster;
            private System.Windows.Forms.TabPage tbpFormulas;
            private System.Windows.Forms.DataGridView dgv_Formulas_Condicional;
            private System.Windows.Forms.DataGridViewTextBoxColumn Condicional_Id_Formula;
            private System.Windows.Forms.DataGridViewTextBoxColumn Condicional_Tipo_Formula;
            private System.Windows.Forms.DataGridViewTextBoxColumn Condicional_NombreFormula;
            private System.Windows.Forms.DataGridViewTextBoxColumn Condicional_Formula;
            private System.Windows.Forms.DataGridViewTextBoxColumn Condicional_Formula_FechaCreacion;
            private System.Windows.Forms.GroupBox groupBox1;
            private System.Windows.Forms.Label lbl_EditarCondicional_2;
            private System.Windows.Forms.Label lbl_GuardarCondicional_2;
            private System.Windows.Forms.Label lbl_EditarCondicional;
            private System.Windows.Forms.ComboBox cb_TipoCondicional;
            private System.Windows.Forms.PictureBox pb_EditarCondicional;
            private System.Windows.Forms.Label lbl_GuardarCondicional;
            private System.Windows.Forms.Label label16;
            private System.Windows.Forms.PictureBox pb_GuardarCondicional;
            private System.Windows.Forms.Label lbl_Condicional;
            private System.Windows.Forms.Label label18;
            private System.Windows.Forms.PictureBox pb_AgregarCondicionalForm;
            private System.Windows.Forms.TextBox tb_NombreCondicional;
            private System.Windows.Forms.Label label10;
            private System.Windows.Forms.TextBox tb_Falso;
            private System.Windows.Forms.Label label9;
            private System.Windows.Forms.TextBox tb_Verdadero;
            private System.Windows.Forms.Label label8;
            private System.Windows.Forms.TextBox tb_Condicional;
            private System.Windows.Forms.Label label7;
            private System.Windows.Forms.TabPage tbPCatalogoFormulas;
            private System.Windows.Forms.GroupBox gpbCantidades;
            private System.Windows.Forms.Button btn_Eliminar;
            private System.Windows.Forms.Button btn_Guardar;
            private System.Windows.Forms.Button btn_Editar;
            private System.Windows.Forms.DataGridView dgv_Formulas;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdFormula;
            private System.Windows.Forms.DataGridViewTextBoxColumn NombreFormula;
            private System.Windows.Forms.DataGridViewTextBoxColumn TipoFormula;
            private System.Windows.Forms.DataGridViewTextBoxColumn Formula;
            private System.Windows.Forms.ComboBox cb_TipoFormula;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.Button btn_ValidarFormula;
            private System.Windows.Forms.TextBox txt_Formula;
            private System.Windows.Forms.Label lblNombreFormula;
            private System.Windows.Forms.Label lblFormula;
            private System.Windows.Forms.TextBox txt_NombreFormula;
            private System.Windows.Forms.TabPage tbpConstruccionBomComponente;
            private System.Windows.Forms.Button btnRemplazarComponente;
            private System.Windows.Forms.Button btnEditarCombinacion;
            private System.Windows.Forms.TextBox txtFilter;
            private System.Windows.Forms.TextBox txtPreviewCombination;
            private System.Windows.Forms.Label lblFilter;
            private System.Windows.Forms.Label lblPreviewCombination;
            private System.Windows.Forms.Button btnCreatePreAssembly;
            private System.Windows.Forms.Button btnSearch;
            private System.Windows.Forms.DataGridView dgvListComponents;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdComponent;
            private System.Windows.Forms.DataGridViewTextBoxColumn Itemo;
            private System.Windows.Forms.DataGridViewTextBoxColumn Class;
            private System.Windows.Forms.DataGridViewTextBoxColumn Description;
            private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
            private System.Windows.Forms.DataGridViewCheckBoxColumn Apply;
            private System.Windows.Forms.GroupBox gpbAgregados;
            private System.Windows.Forms.ComboBox cmbMaterial06;
            private System.Windows.Forms.Label lblMaterial04;
            private System.Windows.Forms.Label lblMaterial06;
            private System.Windows.Forms.ComboBox cmbMaterial04;
            private System.Windows.Forms.ComboBox cmbMaterial05;
            private System.Windows.Forms.Label lblMaterial05;
            private System.Windows.Forms.ComboBox cmbMaterial03;
            private System.Windows.Forms.Label lblMaterial01;
            private System.Windows.Forms.Label lblMaterial03;
            private System.Windows.Forms.ComboBox cmbMaterial01;
            private System.Windows.Forms.ComboBox cmbMaterial02;
            private System.Windows.Forms.Label lblMaterial02;
            private System.Windows.Forms.GroupBox gpbAcabados;
            private System.Windows.Forms.RadioButton rbnAn;
            private System.Windows.Forms.RadioButton rbnAl;
            private System.Windows.Forms.ComboBox cmbListModelL0;
            private System.Windows.Forms.Label lblSubNivelBomsL1;
            private System.Windows.Forms.ComboBox cmbListModelL1;
            private System.Windows.Forms.Label lblListadoBomL0;
            private System.Windows.Forms.TabPage tbpCreacionModelos;
            private System.Windows.Forms.GroupBox gpbModel0;
            private System.Windows.Forms.TextBox txtEnglishDescription;
            private System.Windows.Forms.TextBox txtLargeDescription;
            private System.Windows.Forms.Label lblDescripcionIngles;
            private System.Windows.Forms.Label lblDescripcionLarga;
            private System.Windows.Forms.Button btnEliminar0;
            private System.Windows.Forms.Button btnEditar0;
            private System.Windows.Forms.Button btnCrear0;
            private System.Windows.Forms.DataGridView dgvModeloL0;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdModeloL0;
            private System.Windows.Forms.DataGridViewTextBoxColumn NombreModeloL0;
            private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionModeloL0;
            private System.Windows.Forms.DataGridViewTextBoxColumn LargeDescription;
            private System.Windows.Forms.DataGridViewTextBoxColumn EnglishDescription;
            private System.Windows.Forms.TextBox txtDescripcionL0;
            private System.Windows.Forms.Label label11;
            private System.Windows.Forms.TextBox txtNombreL0;
            private System.Windows.Forms.Label label12;
            private System.Windows.Forms.GroupBox gvbModelL1;
            private System.Windows.Forms.ComboBox cmbMfgCell;
            private System.Windows.Forms.Label lblMfg_Cell;
            private System.Windows.Forms.DataGridView dgvModeloL1;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdModelo;
            private System.Windows.Forms.DataGridViewTextBoxColumn NombreModelo;
            private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionModelo;
            private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionExt;
            private System.Windows.Forms.ComboBox cmbModeloL0;
            private System.Windows.Forms.Label label13;
            private System.Windows.Forms.Button btnEliminarL1;
            private System.Windows.Forms.Button btnEditarL1;
            private System.Windows.Forms.Button btnCrearL1;
            private System.Windows.Forms.TextBox txtDescripcionL1;
            private System.Windows.Forms.Label lblDescripcionModelo;
            private System.Windows.Forms.TextBox txtNombreL1;
            private System.Windows.Forms.Label lblNombreModelo;
            private System.Windows.Forms.TabPage tbpConfiguracionInicial;
            private System.Windows.Forms.GroupBox gpbSubMaterials;
            private System.Windows.Forms.Label lblSubMaterialDescription;
            private System.Windows.Forms.DataGridView dgvListSubMaterials;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdSubMaterial;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdMaterialBase;
            private System.Windows.Forms.DataGridViewTextBoxColumn MaterialBase;
            private System.Windows.Forms.DataGridViewTextBoxColumn NameSubMaterial;
            private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionSubMaterial;
            private System.Windows.Forms.Button btnDeleteSubMaterial;
            private System.Windows.Forms.TextBox txtDescriptionSubMaterial;
            private System.Windows.Forms.Button btnEditSubtMaterial;
            private System.Windows.Forms.ComboBox cmbChoiceMaterial;
            private System.Windows.Forms.Button btnSaveSubMaterial;
            private System.Windows.Forms.TextBox txtNameSubMaterial;
            private System.Windows.Forms.Label lblChoice;
            private System.Windows.Forms.Label lblSubMaterial;
            private System.Windows.Forms.GroupBox gpbTypeMaterial;
            private System.Windows.Forms.Button btnDeleteMaterial;
            private System.Windows.Forms.Button btnEditMaterial;
            private System.Windows.Forms.Button btnSaveMaterial;
            private System.Windows.Forms.DataGridView dgvListMaterials;
            private System.Windows.Forms.DataGridViewTextBoxColumn IdMaterial;
            private System.Windows.Forms.DataGridViewTextBoxColumn NameMaterial;
            private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionMaterial;
            private System.Windows.Forms.TextBox txtDescriptionMaterial;
            private System.Windows.Forms.TextBox txtNameMaterial;
            private System.Windows.Forms.Label lblDescripcionAccesorio;
            private System.Windows.Forms.Label lblNombreMaterial;
            private System.Windows.Forms.TabControl tbcControlPanel;
            private System.Windows.Forms.GroupBox groupBox5;
            private System.Windows.Forms.GroupBox groupBox4;
            private System.Windows.Forms.GroupBox groupBox3;
            private System.Windows.Forms.Label lblSecuenceName;
            private System.Windows.Forms.TextBox txtSequence;
            private System.Windows.Forms.DataGridView dgvSecuenceList;
            private System.Windows.Forms.Label lblSequenceList;
            private System.Windows.Forms.Button btnDeleteSecuence;
            private System.Windows.Forms.Button btnHideSecuence;
            private System.Windows.Forms.Button btnEditSecuence;
            private System.Windows.Forms.Button btnSaveSecuence;
            private System.Windows.Forms.TextBox txtProcess;
            private System.Windows.Forms.DataGridView dgvProcessList;
            private System.Windows.Forms.Label lblProcessList;
            private System.Windows.Forms.Label lblProcessName;
            private System.Windows.Forms.Button btnEditProccess;
            private System.Windows.Forms.Button btnHideProcess;
            private System.Windows.Forms.Button btnDeleteProceso;
            private System.Windows.Forms.Button btnSaveProccess;
            private System.Windows.Forms.Label label41;
            private System.Windows.Forms.Label label40;
            private System.Windows.Forms.Label lblSeleccionSecuencia;
    private System.Windows.Forms.Label label39;
    private System.Windows.Forms.Button btnEditSecuenceProccessRel;
    private System.Windows.Forms.Button btnDiableSecuenceProccessRel;
    private System.Windows.Forms.TextBox txtSecuenceBOM;
    private System.Windows.Forms.DataGridView dgvFamilyRelaList;
    private System.Windows.Forms.DataGridView dgvProccessRelaList;
    private System.Windows.Forms.DataGridView dgvSecuencesRelaList;
    private System.Windows.Forms.Button btnCncelSecuenceProccessRel;
    private System.Windows.Forms.Button btnSecuenceProccessRel;
    private System.Windows.Forms.DataGridView dgvListRelaExistentes;
    private System.Windows.Forms.TreeView treeView1;
  }
} 