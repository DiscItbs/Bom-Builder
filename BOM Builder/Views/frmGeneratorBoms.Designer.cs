namespace BOM_Builder.Views
{
   partial class frmGeneratorBoms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGeneratorBoms));
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblTipoBom = new System.Windows.Forms.Label();
            this.cmbModelosEnsamblados = new System.Windows.Forms.ComboBox();
            this.cmbListadoModelos = new System.Windows.Forms.ComboBox();
            this.txtCycle = new System.Windows.Forms.TextBox();
            this.lblCycle = new System.Windows.Forms.Label();
            this.btnGenerateBom = new System.Windows.Forms.Button();
            this.btnPreviewBom = new System.Windows.Forms.Button();
            this.dgvListComponents = new System.Windows.Forms.DataGridView();
            this.Numero_Parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_perfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso_KG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.lblLarge = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtLarge = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.cmbClasses = new System.Windows.Forms.ComboBox();
            this.lblClasses = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Horizontal = new System.Windows.Forms.TextBox();
            this.tb_Vertical = new System.Windows.Forms.TextBox();
            this.tb_Ranuras = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Diametro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Pies = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblTotalCantidad = new System.Windows.Forms.Label();
            this.lblTotalMedida = new System.Windows.Forms.Label();
            this.lblMedida = new System.Windows.Forms.Label();
            this.lblTotalPerfil = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(819, 19);
            this.lblModelo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(168, 20);
            this.lblModelo.TabIndex = 9;
            this.lblModelo.Text = "Modelos ensamblados";
            // 
            // lblTipoBom
            // 
            this.lblTipoBom.AutoSize = true;
            this.lblTipoBom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoBom.Location = new System.Drawing.Point(16, 19);
            this.lblTipoBom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoBom.Name = "lblTipoBom";
            this.lblTipoBom.Size = new System.Drawing.Size(125, 20);
            this.lblTipoBom.TabIndex = 8;
            this.lblTipoBom.Text = "Listado modelos";
            // 
            // cmbModelosEnsamblados
            // 
            this.cmbModelosEnsamblados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelosEnsamblados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModelosEnsamblados.FormattingEnabled = true;
            this.cmbModelosEnsamblados.Location = new System.Drawing.Point(823, 44);
            this.cmbModelosEnsamblados.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbModelosEnsamblados.Name = "cmbModelosEnsamblados";
            this.cmbModelosEnsamblados.Size = new System.Drawing.Size(235, 28);
            this.cmbModelosEnsamblados.TabIndex = 4;
            // 
            // cmbListadoModelos
            // 
            this.cmbListadoModelos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListadoModelos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbListadoModelos.FormattingEnabled = true;
            this.cmbListadoModelos.Location = new System.Drawing.Point(20, 44);
            this.cmbListadoModelos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbListadoModelos.Name = "cmbListadoModelos";
            this.cmbListadoModelos.Size = new System.Drawing.Size(236, 28);
            this.cmbListadoModelos.TabIndex = 1;
            this.cmbListadoModelos.SelectedIndexChanged += new System.EventHandler(this.CmbListadoModelos_SelectedIndexChanged);
            // 
            // txtCycle
            // 
            this.txtCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCycle.Location = new System.Drawing.Point(408, 169);
            this.txtCycle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCycle.Name = "txtCycle";
            this.txtCycle.Size = new System.Drawing.Size(159, 26);
            this.txtCycle.TabIndex = 8;
            this.txtCycle.Text = "120";
            this.txtCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCycle
            // 
            this.lblCycle.AutoSize = true;
            this.lblCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCycle.Location = new System.Drawing.Point(404, 144);
            this.lblCycle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCycle.Name = "lblCycle";
            this.lblCycle.Size = new System.Drawing.Size(51, 20);
            this.lblCycle.TabIndex = 48;
            this.lblCycle.Text = "Ciclos";
            // 
            // btnGenerateBom
            // 
            this.btnGenerateBom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateBom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGenerateBom.Location = new System.Drawing.Point(813, 158);
            this.btnGenerateBom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerateBom.Name = "btnGenerateBom";
            this.btnGenerateBom.Size = new System.Drawing.Size(182, 48);
            this.btnGenerateBom.TabIndex = 10;
            this.btnGenerateBom.Text = "Crear";
            this.btnGenerateBom.UseVisualStyleBackColor = true;
            this.btnGenerateBom.Click += new System.EventHandler(this.BtnGenerateBom_Click);
            // 
            // btnPreviewBom
            // 
            this.btnPreviewBom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviewBom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPreviewBom.Location = new System.Drawing.Point(598, 158);
            this.btnPreviewBom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPreviewBom.Name = "btnPreviewBom";
            this.btnPreviewBom.Size = new System.Drawing.Size(182, 48);
            this.btnPreviewBom.TabIndex = 9;
            this.btnPreviewBom.Text = "Preview";
            this.btnPreviewBom.UseVisualStyleBackColor = true;
            this.btnPreviewBom.Click += new System.EventHandler(this.BtnPreviewBom_Click);
            // 
            // dgvListComponents
            // 
            this.dgvListComponents.AllowUserToAddRows = false;
            this.dgvListComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListComponents.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvListComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero_Parte,
            this.Descripcion,
            this.Cantidad,
            this.Medida,
            this.Total_perfil,
            this.Peso_KG,
            this.Seccion,
            this.Linea,
            this.Descripcion_});
            this.dgvListComponents.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListComponents.Location = new System.Drawing.Point(16, 261);
            this.dgvListComponents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvListComponents.Name = "dgvListComponents";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvListComponents.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListComponents.Size = new System.Drawing.Size(1069, 409);
            this.dgvListComponents.TabIndex = 12;
            // 
            // Numero_Parte
            // 
            this.Numero_Parte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Numero_Parte.HeaderText = "Número de parte";
            this.Numero_Parte.Name = "Numero_Parte";
            this.Numero_Parte.ReadOnly = true;
            this.Numero_Parte.Width = 106;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Descripcion.HeaderText = "Nombre";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 90;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cantidad.Width = 98;
            // 
            // Medida
            // 
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            // 
            // Total_perfil
            // 
            this.Total_perfil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Total_perfil.HeaderText = "Total Perfil";
            this.Total_perfil.Name = "Total_perfil";
            this.Total_perfil.Width = 99;
            // 
            // Peso_KG
            // 
            this.Peso_KG.HeaderText = "Peso_Kg";
            this.Peso_KG.Name = "Peso_KG";
            this.Peso_KG.ReadOnly = true;
            this.Peso_KG.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Seccion
            // 
            this.Seccion.HeaderText = "Seccion";
            this.Seccion.Name = "Seccion";
            // 
            // Linea
            // 
            this.Linea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Linea.HeaderText = "Linea";
            this.Linea.Name = "Linea";
            this.Linea.Width = 73;
            // 
            // Descripcion_
            // 
            this.Descripcion_.HeaderText = "Descripcion";
            this.Descripcion_.Name = "Descripcion_";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.Location = new System.Drawing.Point(598, 43);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(182, 28);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Buscar modelos";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(0, 0);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 24);
            this.radioButton1.TabIndex = 0;
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(0, 0);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 24);
            this.radioButton2.TabIndex = 0;
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(0, 0);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 24);
            this.radioButton3.TabIndex = 0;
            // 
            // lblLarge
            // 
            this.lblLarge.AutoSize = true;
            this.lblLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLarge.Location = new System.Drawing.Point(16, 77);
            this.lblLarge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLarge.Name = "lblLarge";
            this.lblLarge.Size = new System.Drawing.Size(50, 20);
            this.lblLarge.TabIndex = 53;
            this.lblLarge.Text = "Largo";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.Location = new System.Drawing.Point(194, 77);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(55, 20);
            this.lblWidth.TabIndex = 54;
            this.lblWidth.Text = "Ancho";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(198, 144);
            this.lblQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(73, 20);
            this.lblQty.TabIndex = 55;
            this.lblQty.Text = "Cantidad";
            // 
            // txtLarge
            // 
            this.txtLarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLarge.Location = new System.Drawing.Point(16, 105);
            this.txtLarge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLarge.Name = "txtLarge";
            this.txtLarge.Size = new System.Drawing.Size(151, 26);
            this.txtLarge.TabIndex = 5;
            this.txtLarge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWidth.Location = new System.Drawing.Point(198, 105);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(148, 26);
            this.txtWidth.TabIndex = 6;
            this.txtWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(198, 169);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(168, 26);
            this.txtQty.TabIndex = 7;
            this.txtQty.Text = "1";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbClasses
            // 
            this.cmbClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClasses.FormattingEnabled = true;
            this.cmbClasses.Location = new System.Drawing.Point(310, 44);
            this.cmbClasses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClasses.Name = "cmbClasses";
            this.cmbClasses.Size = new System.Drawing.Size(241, 28);
            this.cmbClasses.TabIndex = 2;
            // 
            // lblClasses
            // 
            this.lblClasses.AutoSize = true;
            this.lblClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasses.Location = new System.Drawing.Point(306, 19);
            this.lblClasses.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClasses.Name = "lblClasses";
            this.lblClasses.Size = new System.Drawing.Size(163, 20);
            this.lblClasses.TabIndex = 60;
            this.lblClasses.Text = "Aplicar bom con clase";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(364, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 61;
            this.label1.Text = "Horizontal";
            // 
            // tb_Horizontal
            // 
            this.tb_Horizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Horizontal.Location = new System.Drawing.Point(368, 105);
            this.tb_Horizontal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Horizontal.Name = "tb_Horizontal";
            this.tb_Horizontal.Size = new System.Drawing.Size(161, 26);
            this.tb_Horizontal.TabIndex = 62;
            this.tb_Horizontal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Vertical
            // 
            this.tb_Vertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Vertical.Location = new System.Drawing.Point(556, 105);
            this.tb_Vertical.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Vertical.Name = "tb_Vertical";
            this.tb_Vertical.Size = new System.Drawing.Size(159, 26);
            this.tb_Vertical.TabIndex = 63;
            this.tb_Vertical.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Ranuras
            // 
            this.tb_Ranuras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Ranuras.Location = new System.Drawing.Point(742, 105);
            this.tb_Ranuras.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Ranuras.Name = "tb_Ranuras";
            this.tb_Ranuras.Size = new System.Drawing.Size(160, 26);
            this.tb_Ranuras.TabIndex = 64;
            this.tb_Ranuras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(552, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 65;
            this.label2.Text = "Vertical";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(738, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 66;
            this.label3.Text = "Ranuras";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(921, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 67;
            this.label4.Text = "Diametro";
            // 
            // tb_Diametro
            // 
            this.tb_Diametro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Diametro.Location = new System.Drawing.Point(925, 104);
            this.tb_Diametro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Diametro.Name = "tb_Diametro";
            this.tb_Diametro.Size = new System.Drawing.Size(145, 26);
            this.tb_Diametro.TabIndex = 68;
            this.tb_Diametro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 144);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 69;
            this.label5.Text = "Pies";
            // 
            // tb_Pies
            // 
            this.tb_Pies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Pies.Location = new System.Drawing.Point(20, 169);
            this.tb_Pies.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_Pies.Name = "tb_Pies";
            this.tb_Pies.Size = new System.Drawing.Size(147, 26);
            this.tb_Pies.TabIndex = 70;
            this.tb_Pies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(16, 221);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(77, 20);
            this.lblCantidad.TabIndex = 71;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblTotalCantidad
            // 
            this.lblTotalCantidad.AutoSize = true;
            this.lblTotalCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCantidad.Location = new System.Drawing.Point(91, 221);
            this.lblTotalCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCantidad.Name = "lblTotalCantidad";
            this.lblTotalCantidad.Size = new System.Drawing.Size(40, 20);
            this.lblTotalCantidad.TabIndex = 72;
            this.lblTotalCantidad.Text = "total";
            // 
            // lblTotalMedida
            // 
            this.lblTotalMedida.AutoSize = true;
            this.lblTotalMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMedida.Location = new System.Drawing.Point(289, 221);
            this.lblTotalMedida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalMedida.Name = "lblTotalMedida";
            this.lblTotalMedida.Size = new System.Drawing.Size(40, 20);
            this.lblTotalMedida.TabIndex = 74;
            this.lblTotalMedida.Text = "total";
            // 
            // lblMedida
            // 
            this.lblMedida.AutoSize = true;
            this.lblMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedida.Location = new System.Drawing.Point(224, 221);
            this.lblMedida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMedida.Name = "lblMedida";
            this.lblMedida.Size = new System.Drawing.Size(65, 20);
            this.lblMedida.TabIndex = 73;
            this.lblMedida.Text = "Medida:";
            // 
            // lblTotalPerfil
            // 
            this.lblTotalPerfil.AutoSize = true;
            this.lblTotalPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPerfil.Location = new System.Drawing.Point(539, 221);
            this.lblTotalPerfil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPerfil.Name = "lblTotalPerfil";
            this.lblTotalPerfil.Size = new System.Drawing.Size(40, 20);
            this.lblTotalPerfil.TabIndex = 76;
            this.lblTotalPerfil.Text = "total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(454, 221);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 20);
            this.label9.TabIndex = 75;
            this.label9.Text = "Total perfil:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(785, 221);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(40, 20);
            this.lblTotal.TabIndex = 78;
            this.lblTotal.Text = "total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(714, 221);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 20);
            this.label11.TabIndex = 77;
            this.label11.Text = "TOTAL:";
            // 
            // frmGeneratorBoms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(1098, 684);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblTotalPerfil);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTotalMedida);
            this.Controls.Add(this.lblMedida);
            this.Controls.Add(this.lblTotalCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.tb_Pies);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_Diametro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Ranuras);
            this.Controls.Add(this.tb_Vertical);
            this.Controls.Add(this.tb_Horizontal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClasses);
            this.Controls.Add(this.cmbClasses);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtLarge);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblLarge);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvListComponents);
            this.Controls.Add(this.btnGenerateBom);
            this.Controls.Add(this.btnPreviewBom);
            this.Controls.Add(this.txtCycle);
            this.Controls.Add(this.lblCycle);
            this.Controls.Add(this.cmbModelosEnsamblados);
            this.Controls.Add(this.cmbListadoModelos);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.lblTipoBom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmGeneratorBoms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de boms";
            this.Load += new System.EventHandler(this.FrmGeneratorBoms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Label lblModelo;
      private System.Windows.Forms.Label lblTipoBom;
      private System.Windows.Forms.ComboBox cmbModelosEnsamblados;
      private System.Windows.Forms.ComboBox cmbListadoModelos;
      private System.Windows.Forms.TextBox txtCycle;
      private System.Windows.Forms.Label lblCycle;
      private System.Windows.Forms.Button btnGenerateBom;
      private System.Windows.Forms.Button btnPreviewBom;
      private System.Windows.Forms.DataGridView dgvListComponents;
      private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label lblLarge;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtLarge;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.ComboBox cmbClasses;
        private System.Windows.Forms.Label lblClasses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Horizontal;
        private System.Windows.Forms.TextBox tb_Vertical;
        private System.Windows.Forms.TextBox tb_Ranuras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Diametro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Pies;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero_Parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_perfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso_KG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion_;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblTotalCantidad;
        private System.Windows.Forms.Label lblTotalMedida;
        private System.Windows.Forms.Label lblMedida;
        private System.Windows.Forms.Label lblTotalPerfil;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label11;
    }
}