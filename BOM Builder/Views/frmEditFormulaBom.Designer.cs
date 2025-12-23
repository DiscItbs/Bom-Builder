namespace BOM_Builder.Views
{
    partial class frmEditFormulaBom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditFormulaBom));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gpbTipos = new System.Windows.Forms.GroupBox();
            this.rbtnAN = new System.Windows.Forms.RadioButton();
            this.rbtnAL = new System.Windows.Forms.RadioButton();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCombinacion = new System.Windows.Forms.TextBox();
            this.lblCombinacion = new System.Windows.Forms.Label();
            this.dgvCombinacionesFormulas = new System.Windows.Forms.DataGridView();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdDetalleForCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblListadoFormulas = new System.Windows.Forms.Label();
            this.btnAsocias = new System.Windows.Forms.Button();
            this.gpbShowFormulas = new System.Windows.Forms.GroupBox();
            this.txtShowFormulas = new System.Windows.Forms.TextBox();
            this.trvShowConditional = new System.Windows.Forms.TreeView();
            this.gpbShowConditional = new System.Windows.Forms.GroupBox();
            this.tb_NumeroParte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_CondicionalesCantidad = new System.Windows.Forms.ComboBox();
            this.cb_CondicionalesMedida = new System.Windows.Forms.ComboBox();
            this.cb_FormulaTotal = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_FormulaPeso = new System.Windows.Forms.ComboBox();
            this.cb_FormulaMedida = new System.Windows.Forms.ComboBox();
            this.cb_FormulaCantidad = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Seccion = new System.Windows.Forms.TextBox();
            this.txt_Linea = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Descripcion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnEliminarBom = new System.Windows.Forms.Button();
            this.gpbTipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombinacionesFormulas)).BeginInit();
            this.gpbShowFormulas.SuspendLayout();
            this.gpbShowConditional.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(566, 17);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(108, 36);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // gpbTipos
            // 
            this.gpbTipos.Controls.Add(this.rbtnAN);
            this.gpbTipos.Controls.Add(this.rbtnAL);
            this.gpbTipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbTipos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpbTipos.Location = new System.Drawing.Point(354, 8);
            this.gpbTipos.Margin = new System.Windows.Forms.Padding(4);
            this.gpbTipos.Name = "gpbTipos";
            this.gpbTipos.Padding = new System.Windows.Forms.Padding(4);
            this.gpbTipos.Size = new System.Drawing.Size(194, 45);
            this.gpbTipos.TabIndex = 72;
            this.gpbTipos.TabStop = false;
            this.gpbTipos.Text = "Tipos de componentes";
            // 
            // rbtnAN
            // 
            this.rbtnAN.AutoSize = true;
            this.rbtnAN.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rbtnAN.Location = new System.Drawing.Point(70, 16);
            this.rbtnAN.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnAN.Name = "rbtnAN";
            this.rbtnAN.Size = new System.Drawing.Size(49, 24);
            this.rbtnAN.TabIndex = 3;
            this.rbtnAN.TabStop = true;
            this.rbtnAN.Text = "AN";
            this.rbtnAN.UseVisualStyleBackColor = true;
            // 
            // rbtnAL
            // 
            this.rbtnAL.AutoSize = true;
            this.rbtnAL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rbtnAL.Location = new System.Drawing.Point(7, 16);
            this.rbtnAL.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnAL.Name = "rbtnAL";
            this.rbtnAL.Size = new System.Drawing.Size(47, 24);
            this.rbtnAL.TabIndex = 2;
            this.rbtnAL.TabStop = true;
            this.rbtnAL.Text = "AL";
            this.rbtnAL.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(682, 17);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(114, 36);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // txtCombinacion
            // 
            this.txtCombinacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCombinacion.Location = new System.Drawing.Point(8, 27);
            this.txtCombinacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtCombinacion.Name = "txtCombinacion";
            this.txtCombinacion.Size = new System.Drawing.Size(317, 26);
            this.txtCombinacion.TabIndex = 1;
            this.txtCombinacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCombinacion
            // 
            this.lblCombinacion.AutoSize = true;
            this.lblCombinacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombinacion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCombinacion.Location = new System.Drawing.Point(4, 8);
            this.lblCombinacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCombinacion.Name = "lblCombinacion";
            this.lblCombinacion.Size = new System.Drawing.Size(221, 20);
            this.lblCombinacion.TabIndex = 68;
            this.lblCombinacion.Text = "Ingrese combinación del BOM";
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
            this.Id,
            this.IdDetalleForCom,
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
            this.dgvCombinacionesFormulas.Location = new System.Drawing.Point(8, 61);
            this.dgvCombinacionesFormulas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCombinacionesFormulas.Name = "dgvCombinacionesFormulas";
            this.dgvCombinacionesFormulas.Size = new System.Drawing.Size(909, 202);
            this.dgvCombinacionesFormulas.TabIndex = 6;
            this.dgvCombinacionesFormulas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCombinacionesFormulas_CellClick);
            this.dgvCombinacionesFormulas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCombinacionesFormulas_CellContentClick);
            // 
            // Linea
            // 
            this.Linea.HeaderText = "Linea";
            this.Linea.Name = "Linea";
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Id.Visible = false;
            // 
            // IdDetalleForCom
            // 
            this.IdDetalleForCom.HeaderText = "IdDetalleForCom";
            this.IdDetalleForCom.Name = "IdDetalleForCom";
            this.IdDetalleForCom.Visible = false;
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
            this.Editar.HeaderText = "Seleccione para editar";
            this.Editar.Name = "Editar";
            // 
            // ItemnoComponent
            // 
            this.ItemnoComponent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ItemnoComponent.FillWeight = 80F;
            this.ItemnoComponent.HeaderText = "Número de parte";
            this.ItemnoComponent.Name = "ItemnoComponent";
            this.ItemnoComponent.ReadOnly = true;
            this.ItemnoComponent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemnoComponent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ItemnoComponent.Width = 76;
            // 
            // NameComponent
            // 
            this.NameComponent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NameComponent.HeaderText = "Nombre componente";
            this.NameComponent.Name = "NameComponent";
            this.NameComponent.ReadOnly = true;
            this.NameComponent.Width = 146;
            // 
            // ConditionalQty
            // 
            this.ConditionalQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ConditionalQty.FillWeight = 200F;
            this.ConditionalQty.HeaderText = "Condicionales para cantidad";
            this.ConditionalQty.Name = "ConditionalQty";
            this.ConditionalQty.ReadOnly = true;
            this.ConditionalQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ConditionalQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ConditionalQty.Width = 121;
            // 
            // ConditionalMd
            // 
            this.ConditionalMd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ConditionalMd.FillWeight = 200F;
            this.ConditionalMd.HeaderText = "Condicionales para medidas";
            this.ConditionalMd.Name = "ConditionalMd";
            this.ConditionalMd.ReadOnly = true;
            this.ConditionalMd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ConditionalMd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ConditionalMd.Width = 121;
            // 
            // FormulaQty
            // 
            this.FormulaQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FormulaQty.FillWeight = 150F;
            this.FormulaQty.HeaderText = "Formula cantidad";
            this.FormulaQty.Name = "FormulaQty";
            this.FormulaQty.ReadOnly = true;
            this.FormulaQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FormulaQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FormulaQty.Width = 106;
            // 
            // FormulaMd
            // 
            this.FormulaMd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FormulaMd.FillWeight = 150F;
            this.FormulaMd.HeaderText = "Formula medida";
            this.FormulaMd.Name = "FormulaMd";
            this.FormulaMd.ReadOnly = true;
            this.FormulaMd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FormulaMd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FormulaMd.Width = 101;
            // 
            // FormulaTotal
            // 
            this.FormulaTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FormulaTotal.FillWeight = 150F;
            this.FormulaTotal.HeaderText = "Formula total";
            this.FormulaTotal.Name = "FormulaTotal";
            this.FormulaTotal.ReadOnly = true;
            this.FormulaTotal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FormulaTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FormulaTotal.Width = 82;
            // 
            // FormulaPeso
            // 
            this.FormulaPeso.HeaderText = "Formula Peso";
            this.FormulaPeso.Name = "FormulaPeso";
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
            this.Descripcion.Width = 105;
            // 
            // lblListadoFormulas
            // 
            this.lblListadoFormulas.AutoSize = true;
            this.lblListadoFormulas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListadoFormulas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblListadoFormulas.Location = new System.Drawing.Point(4, 275);
            this.lblListadoFormulas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListadoFormulas.Name = "lblListadoFormulas";
            this.lblListadoFormulas.Size = new System.Drawing.Size(126, 20);
            this.lblListadoFormulas.TabIndex = 76;
            this.lblListadoFormulas.Text = "Listado formulas";
            // 
            // btnAsocias
            // 
            this.btnAsocias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsocias.Location = new System.Drawing.Point(158, 270);
            this.btnAsocias.Margin = new System.Windows.Forms.Padding(4);
            this.btnAsocias.Name = "btnAsocias";
            this.btnAsocias.Size = new System.Drawing.Size(121, 29);
            this.btnAsocias.TabIndex = 7;
            this.btnAsocias.Text = "Asociar";
            this.btnAsocias.UseVisualStyleBackColor = true;
            this.btnAsocias.Visible = false;
            this.btnAsocias.Click += new System.EventHandler(this.BtnAsocias_Click);
            // 
            // gpbShowFormulas
            // 
            this.gpbShowFormulas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbShowFormulas.Controls.Add(this.txtShowFormulas);
            this.gpbShowFormulas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbShowFormulas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpbShowFormulas.Location = new System.Drawing.Point(498, 446);
            this.gpbShowFormulas.Margin = new System.Windows.Forms.Padding(4);
            this.gpbShowFormulas.Name = "gpbShowFormulas";
            this.gpbShowFormulas.Padding = new System.Windows.Forms.Padding(4);
            this.gpbShowFormulas.Size = new System.Drawing.Size(419, 204);
            this.gpbShowFormulas.TabIndex = 78;
            this.gpbShowFormulas.TabStop = false;
            this.gpbShowFormulas.Text = "Visualizador de formulas";
            // 
            // txtShowFormulas
            // 
            this.txtShowFormulas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtShowFormulas.Enabled = false;
            this.txtShowFormulas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShowFormulas.Location = new System.Drawing.Point(7, 23);
            this.txtShowFormulas.Margin = new System.Windows.Forms.Padding(4);
            this.txtShowFormulas.Multiline = true;
            this.txtShowFormulas.Name = "txtShowFormulas";
            this.txtShowFormulas.Size = new System.Drawing.Size(408, 174);
            this.txtShowFormulas.TabIndex = 10;
            // 
            // trvShowConditional
            // 
            this.trvShowConditional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trvShowConditional.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvShowConditional.Location = new System.Drawing.Point(9, 23);
            this.trvShowConditional.Margin = new System.Windows.Forms.Padding(4);
            this.trvShowConditional.Name = "trvShowConditional";
            this.trvShowConditional.Size = new System.Drawing.Size(462, 174);
            this.trvShowConditional.TabIndex = 9;
            // 
            // gpbShowConditional
            // 
            this.gpbShowConditional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gpbShowConditional.Controls.Add(this.trvShowConditional);
            this.gpbShowConditional.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbShowConditional.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpbShowConditional.Location = new System.Drawing.Point(8, 446);
            this.gpbShowConditional.Margin = new System.Windows.Forms.Padding(4);
            this.gpbShowConditional.Name = "gpbShowConditional";
            this.gpbShowConditional.Padding = new System.Windows.Forms.Padding(4);
            this.gpbShowConditional.Size = new System.Drawing.Size(482, 204);
            this.gpbShowConditional.TabIndex = 79;
            this.gpbShowConditional.TabStop = false;
            this.gpbShowConditional.Text = "Visualización de condicionales";
            // 
            // tb_NumeroParte
            // 
            this.tb_NumeroParte.Location = new System.Drawing.Point(530, 275);
            this.tb_NumeroParte.Multiline = true;
            this.tb_NumeroParte.Name = "tb_NumeroParte";
            this.tb_NumeroParte.ReadOnly = true;
            this.tb_NumeroParte.Size = new System.Drawing.Size(374, 25);
            this.tb_NumeroParte.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(377, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 82;
            this.label1.Text = "Numero de parte";
            // 
            // cb_CondicionalesCantidad
            // 
            this.cb_CondicionalesCantidad.FormattingEnabled = true;
            this.cb_CondicionalesCantidad.Location = new System.Drawing.Point(12, 324);
            this.cb_CondicionalesCantidad.Name = "cb_CondicionalesCantidad";
            this.cb_CondicionalesCantidad.Size = new System.Drawing.Size(266, 24);
            this.cb_CondicionalesCantidad.TabIndex = 83;
            this.cb_CondicionalesCantidad.SelectedValueChanged += new System.EventHandler(this.cb_CondicionalesCantidad_SelectedValueChanged);
            // 
            // cb_CondicionalesMedida
            // 
            this.cb_CondicionalesMedida.FormattingEnabled = true;
            this.cb_CondicionalesMedida.Location = new System.Drawing.Point(315, 324);
            this.cb_CondicionalesMedida.Name = "cb_CondicionalesMedida";
            this.cb_CondicionalesMedida.Size = new System.Drawing.Size(277, 24);
            this.cb_CondicionalesMedida.TabIndex = 84;
            this.cb_CondicionalesMedida.SelectedValueChanged += new System.EventHandler(this.cb_CondicionalesMedida_SelectedValueChanged);
            // 
            // cb_FormulaTotal
            // 
            this.cb_FormulaTotal.FormattingEnabled = true;
            this.cb_FormulaTotal.Location = new System.Drawing.Point(640, 324);
            this.cb_FormulaTotal.Name = "cb_FormulaTotal";
            this.cb_FormulaTotal.Size = new System.Drawing.Size(264, 24);
            this.cb_FormulaTotal.TabIndex = 85;
            this.cb_FormulaTotal.SelectedValueChanged += new System.EventHandler(this.cb_FormulaTotal_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 20);
            this.label2.TabIndex = 86;
            this.label2.Text = "Condicionales cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(311, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 20);
            this.label3.TabIndex = 87;
            this.label3.Text = "Condicionales medida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(636, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 88;
            this.label4.Text = "Formula total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(637, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 94;
            this.label5.Text = "Formula peso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(312, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 20);
            this.label6.TabIndex = 93;
            this.label6.Text = "Formula medida";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(13, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 20);
            this.label7.TabIndex = 92;
            this.label7.Text = "Formula cantidad";
            // 
            // cb_FormulaPeso
            // 
            this.cb_FormulaPeso.FormattingEnabled = true;
            this.cb_FormulaPeso.Location = new System.Drawing.Point(641, 369);
            this.cb_FormulaPeso.Name = "cb_FormulaPeso";
            this.cb_FormulaPeso.Size = new System.Drawing.Size(264, 24);
            this.cb_FormulaPeso.TabIndex = 91;
            this.cb_FormulaPeso.SelectedValueChanged += new System.EventHandler(this.cb_FormulaPeso_SelectedValueChanged);
            // 
            // cb_FormulaMedida
            // 
            this.cb_FormulaMedida.FormattingEnabled = true;
            this.cb_FormulaMedida.Location = new System.Drawing.Point(316, 369);
            this.cb_FormulaMedida.Name = "cb_FormulaMedida";
            this.cb_FormulaMedida.Size = new System.Drawing.Size(277, 24);
            this.cb_FormulaMedida.TabIndex = 90;
            this.cb_FormulaMedida.SelectedValueChanged += new System.EventHandler(this.cb_FormulaMedida_SelectedValueChanged);
            // 
            // cb_FormulaCantidad
            // 
            this.cb_FormulaCantidad.FormattingEnabled = true;
            this.cb_FormulaCantidad.Location = new System.Drawing.Point(13, 369);
            this.cb_FormulaCantidad.Name = "cb_FormulaCantidad";
            this.cb_FormulaCantidad.Size = new System.Drawing.Size(266, 24);
            this.cb_FormulaCantidad.TabIndex = 89;
            this.cb_FormulaCantidad.SelectedValueChanged += new System.EventHandler(this.cb_FormulaCantidad_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(13, 396);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 95;
            this.label8.Text = "Seccion";
            // 
            // txt_Seccion
            // 
            this.txt_Seccion.Location = new System.Drawing.Point(13, 417);
            this.txt_Seccion.Name = "txt_Seccion";
            this.txt_Seccion.Size = new System.Drawing.Size(265, 22);
            this.txt_Seccion.TabIndex = 96;
            // 
            // txt_Linea
            // 
            this.txt_Linea.Location = new System.Drawing.Point(316, 417);
            this.txt_Linea.Name = "txt_Linea";
            this.txt_Linea.Size = new System.Drawing.Size(277, 22);
            this.txt_Linea.TabIndex = 98;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(311, 396);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 97;
            this.label9.Text = "Linea";
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.Location = new System.Drawing.Point(640, 417);
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(265, 22);
            this.txt_Descripcion.TabIndex = 100;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(637, 396);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 20);
            this.label10.TabIndex = 99;
            this.label10.Text = "Descripcion";
            // 
            // btnEliminarBom
            // 
            this.btnEliminarBom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarBom.Location = new System.Drawing.Point(804, 17);
            this.btnEliminarBom.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarBom.Name = "btnEliminarBom";
            this.btnEliminarBom.Size = new System.Drawing.Size(108, 36);
            this.btnEliminarBom.TabIndex = 101;
            this.btnEliminarBom.Text = "Eliminar";
            this.btnEliminarBom.UseVisualStyleBackColor = true;
            this.btnEliminarBom.Click += new System.EventHandler(this.btnEliminarBom_Click);
            // 
            // frmEditFormulaBom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(926, 670);
            this.Controls.Add(this.btnEliminarBom);
            this.Controls.Add(this.txt_Descripcion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Linea);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_Seccion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_FormulaPeso);
            this.Controls.Add(this.cb_FormulaMedida);
            this.Controls.Add(this.cb_FormulaCantidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_FormulaTotal);
            this.Controls.Add(this.cb_CondicionalesMedida);
            this.Controls.Add(this.cb_CondicionalesCantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_NumeroParte);
            this.Controls.Add(this.gpbShowConditional);
            this.Controls.Add(this.gpbShowFormulas);
            this.Controls.Add(this.btnAsocias);
            this.Controls.Add(this.lblListadoFormulas);
            this.Controls.Add(this.dgvCombinacionesFormulas);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.gpbTipos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtCombinacion);
            this.Controls.Add(this.lblCombinacion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEditFormulaBom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edición de formulas por componente";
            this.Load += new System.EventHandler(this.FrmEditFormulaBom_Load);
            this.gpbTipos.ResumeLayout(false);
            this.gpbTipos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCombinacionesFormulas)).EndInit();
            this.gpbShowFormulas.ResumeLayout(false);
            this.gpbShowFormulas.PerformLayout();
            this.gpbShowConditional.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gpbTipos;
        private System.Windows.Forms.RadioButton rbtnAN;
        private System.Windows.Forms.RadioButton rbtnAL;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCombinacion;
        private System.Windows.Forms.Label lblCombinacion;
        private System.Windows.Forms.DataGridView dgvCombinacionesFormulas;
        private System.Windows.Forms.Label lblListadoFormulas;
        private System.Windows.Forms.Button btnAsocias;
        private System.Windows.Forms.GroupBox gpbShowFormulas;
        private System.Windows.Forms.TextBox txtShowFormulas;
        private System.Windows.Forms.TreeView trvShowConditional;
        private System.Windows.Forms.GroupBox gpbShowConditional;
        private System.Windows.Forms.TextBox tb_NumeroParte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_CondicionalesCantidad;
        private System.Windows.Forms.ComboBox cb_CondicionalesMedida;
        private System.Windows.Forms.ComboBox cb_FormulaTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_FormulaPeso;
        private System.Windows.Forms.ComboBox cb_FormulaMedida;
        private System.Windows.Forms.ComboBox cb_FormulaCantidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Seccion;
        private System.Windows.Forms.TextBox txt_Linea;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Descripcion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDetalleForCom;
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
        private System.Windows.Forms.Button btnEliminarBom;
    }
}