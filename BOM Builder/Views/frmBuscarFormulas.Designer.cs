namespace BOM_Builder.Views
{
    partial class frmBuscarFormulas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarFormulas));
            this.rb_busquedaId = new System.Windows.Forms.RadioButton();
            this.rb_busqueda_formula = new System.Windows.Forms.RadioButton();
            this.rb_tipo_Condicional = new System.Windows.Forms.RadioButton();
            this.rb_tipo_simple = new System.Windows.Forms.RadioButton();
            this.rb_Columna_Verdadero = new System.Windows.Forms.RadioButton();
            this.rb_Columna_Todos = new System.Windows.Forms.RadioButton();
            this.rb_Columna_Falso = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_formula = new System.Windows.Forms.TextBox();
            this.btn_BuscarFormula = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb_Columna_Condicional = new System.Windows.Forms.RadioButton();
            this.rb_Columna_Formula = new System.Windows.Forms.RadioButton();
            this.rb_Columna_Nombre = new System.Windows.Forms.RadioButton();
            this.Formula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoFormula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreFormula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdFormula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Formulas = new System.Windows.Forms.DataGridView();
            this.tabControl_Formulas_Condicionales = new System.Windows.Forms.TabControl();
            this.tab_Formulas = new System.Windows.Forms.TabPage();
            this.tab_Condicionales = new System.Windows.Forms.TabPage();
            this.dgv_Condicionales = new System.Windows.Forms.DataGridView();
            this.Id_Condicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Condicionales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicional_Condicionales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verdadero_Condicionales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Falso_Condicionales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHome = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Formulas)).BeginInit();
            this.tabControl_Formulas_Condicionales.SuspendLayout();
            this.tab_Formulas.SuspendLayout();
            this.tab_Condicionales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Condicionales)).BeginInit();
            this.SuspendLayout();
            // 
            // rb_busquedaId
            // 
            this.rb_busquedaId.AutoSize = true;
            this.rb_busquedaId.Checked = true;
            this.rb_busquedaId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_busquedaId.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rb_busquedaId.Location = new System.Drawing.Point(17, 38);
            this.rb_busquedaId.Name = "rb_busquedaId";
            this.rb_busquedaId.Size = new System.Drawing.Size(130, 22);
            this.rb_busquedaId.TabIndex = 0;
            this.rb_busquedaId.TabStop = true;
            this.rb_busquedaId.Text = "Buscar por ID";
            this.rb_busquedaId.UseVisualStyleBackColor = true;
            this.rb_busquedaId.CheckedChanged += new System.EventHandler(this.rb_busquedaId_CheckedChanged);
            // 
            // rb_busqueda_formula
            // 
            this.rb_busqueda_formula.AutoSize = true;
            this.rb_busqueda_formula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_busqueda_formula.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rb_busqueda_formula.Location = new System.Drawing.Point(17, 84);
            this.rb_busqueda_formula.Name = "rb_busqueda_formula";
            this.rb_busqueda_formula.Size = new System.Drawing.Size(171, 22);
            this.rb_busqueda_formula.TabIndex = 1;
            this.rb_busqueda_formula.Text = "Buscar por fórmula";
            this.rb_busqueda_formula.UseVisualStyleBackColor = true;
            this.rb_busqueda_formula.CheckedChanged += new System.EventHandler(this.rb_busqueda_formula_CheckedChanged);
            // 
            // rb_tipo_Condicional
            // 
            this.rb_tipo_Condicional.AutoSize = true;
            this.rb_tipo_Condicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_tipo_Condicional.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rb_tipo_Condicional.Location = new System.Drawing.Point(24, 85);
            this.rb_tipo_Condicional.Name = "rb_tipo_Condicional";
            this.rb_tipo_Condicional.Size = new System.Drawing.Size(115, 22);
            this.rb_tipo_Condicional.TabIndex = 4;
            this.rb_tipo_Condicional.Text = "Condicional";
            this.rb_tipo_Condicional.UseVisualStyleBackColor = true;
            this.rb_tipo_Condicional.CheckedChanged += new System.EventHandler(this.rb_tipo_Condicional_CheckedChanged);
            // 
            // rb_tipo_simple
            // 
            this.rb_tipo_simple.AutoSize = true;
            this.rb_tipo_simple.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_tipo_simple.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rb_tipo_simple.Location = new System.Drawing.Point(24, 39);
            this.rb_tipo_simple.Name = "rb_tipo_simple";
            this.rb_tipo_simple.Size = new System.Drawing.Size(77, 22);
            this.rb_tipo_simple.TabIndex = 3;
            this.rb_tipo_simple.Text = "Simple";
            this.rb_tipo_simple.UseVisualStyleBackColor = true;
            this.rb_tipo_simple.CheckedChanged += new System.EventHandler(this.rb_tipo_simple_CheckedChanged);
            // 
            // rb_Columna_Verdadero
            // 
            this.rb_Columna_Verdadero.AutoSize = true;
            this.rb_Columna_Verdadero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Columna_Verdadero.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rb_Columna_Verdadero.Location = new System.Drawing.Point(183, 29);
            this.rb_Columna_Verdadero.Name = "rb_Columna_Verdadero";
            this.rb_Columna_Verdadero.Size = new System.Drawing.Size(103, 22);
            this.rb_Columna_Verdadero.TabIndex = 7;
            this.rb_Columna_Verdadero.Text = "Verdadero";
            this.rb_Columna_Verdadero.UseVisualStyleBackColor = true;
            // 
            // rb_Columna_Todos
            // 
            this.rb_Columna_Todos.AutoSize = true;
            this.rb_Columna_Todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Columna_Todos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rb_Columna_Todos.Location = new System.Drawing.Point(183, 100);
            this.rb_Columna_Todos.Name = "rb_Columna_Todos";
            this.rb_Columna_Todos.Size = new System.Drawing.Size(74, 22);
            this.rb_Columna_Todos.TabIndex = 8;
            this.rb_Columna_Todos.Text = "Todos";
            this.rb_Columna_Todos.UseVisualStyleBackColor = true;
            // 
            // rb_Columna_Falso
            // 
            this.rb_Columna_Falso.AutoSize = true;
            this.rb_Columna_Falso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Columna_Falso.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rb_Columna_Falso.Location = new System.Drawing.Point(183, 63);
            this.rb_Columna_Falso.Name = "rb_Columna_Falso";
            this.rb_Columna_Falso.Size = new System.Drawing.Size(68, 22);
            this.rb_Columna_Falso.TabIndex = 9;
            this.rb_Columna_Falso.Text = "Falso";
            this.rb_Columna_Falso.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(21, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "ID/Fórmula a buscar:";
            // 
            // tb_formula
            // 
            this.tb_formula.Location = new System.Drawing.Point(24, 212);
            this.tb_formula.Multiline = true;
            this.tb_formula.Name = "tb_formula";
            this.tb_formula.Size = new System.Drawing.Size(788, 53);
            this.tb_formula.TabIndex = 11;
            // 
            // btn_BuscarFormula
            // 
            this.btn_BuscarFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarFormula.Location = new System.Drawing.Point(830, 214);
            this.btn_BuscarFormula.Name = "btn_BuscarFormula";
            this.btn_BuscarFormula.Size = new System.Drawing.Size(138, 44);
            this.btn_BuscarFormula.TabIndex = 12;
            this.btn_BuscarFormula.Text = "BUSCAR";
            this.btn_BuscarFormula.UseVisualStyleBackColor = true;
            this.btn_BuscarFormula.Click += new System.EventHandler(this.btn_BuscarFormula_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_busquedaId);
            this.groupBox1.Controls.Add(this.rb_busqueda_formula);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(29, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 141);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo busqueda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_tipo_Condicional);
            this.groupBox2.Controls.Add(this.rb_tipo_simple);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(317, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 142);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo formula";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_Columna_Condicional);
            this.groupBox3.Controls.Add(this.rb_Columna_Formula);
            this.groupBox3.Controls.Add(this.rb_Columna_Nombre);
            this.groupBox3.Controls.Add(this.rb_Columna_Verdadero);
            this.groupBox3.Controls.Add(this.rb_Columna_Todos);
            this.groupBox3.Controls.Add(this.rb_Columna_Falso);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(613, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(351, 141);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Columna busqueda";
            // 
            // rb_Columna_Condicional
            // 
            this.rb_Columna_Condicional.AutoSize = true;
            this.rb_Columna_Condicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Columna_Condicional.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rb_Columna_Condicional.Location = new System.Drawing.Point(25, 100);
            this.rb_Columna_Condicional.Name = "rb_Columna_Condicional";
            this.rb_Columna_Condicional.Size = new System.Drawing.Size(115, 22);
            this.rb_Columna_Condicional.TabIndex = 12;
            this.rb_Columna_Condicional.Text = "Condicional";
            this.rb_Columna_Condicional.UseVisualStyleBackColor = true;
            // 
            // rb_Columna_Formula
            // 
            this.rb_Columna_Formula.AutoSize = true;
            this.rb_Columna_Formula.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Columna_Formula.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rb_Columna_Formula.Location = new System.Drawing.Point(25, 63);
            this.rb_Columna_Formula.Name = "rb_Columna_Formula";
            this.rb_Columna_Formula.Size = new System.Drawing.Size(88, 22);
            this.rb_Columna_Formula.TabIndex = 11;
            this.rb_Columna_Formula.Text = "Formula";
            this.rb_Columna_Formula.UseVisualStyleBackColor = true;
            // 
            // rb_Columna_Nombre
            // 
            this.rb_Columna_Nombre.AutoSize = true;
            this.rb_Columna_Nombre.Checked = true;
            this.rb_Columna_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Columna_Nombre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rb_Columna_Nombre.Location = new System.Drawing.Point(25, 29);
            this.rb_Columna_Nombre.Name = "rb_Columna_Nombre";
            this.rb_Columna_Nombre.Size = new System.Drawing.Size(86, 22);
            this.rb_Columna_Nombre.TabIndex = 10;
            this.rb_Columna_Nombre.TabStop = true;
            this.rb_Columna_Nombre.Text = "Nombre";
            this.rb_Columna_Nombre.UseVisualStyleBackColor = true;
            // 
            // Formula
            // 
            this.Formula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Formula.HeaderText = "Formula";
            this.Formula.Name = "Formula";
            // 
            // TipoFormula
            // 
            this.TipoFormula.HeaderText = "Tipo Formula";
            this.TipoFormula.Name = "TipoFormula";
            // 
            // NombreFormula
            // 
            this.NombreFormula.HeaderText = "Nombre Formula";
            this.NombreFormula.Name = "NombreFormula";
            // 
            // IdFormula
            // 
            this.IdFormula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IdFormula.HeaderText = "Id";
            this.IdFormula.Name = "IdFormula";
            this.IdFormula.Width = 41;
            // 
            // dgv_Formulas
            // 
            this.dgv_Formulas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Formulas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Formulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Formulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdFormula,
            this.NombreFormula,
            this.TipoFormula,
            this.Formula});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Formulas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Formulas.Location = new System.Drawing.Point(1, 0);
            this.dgv_Formulas.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Formulas.Name = "dgv_Formulas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Formulas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Formulas.Size = new System.Drawing.Size(931, 321);
            this.dgv_Formulas.TabIndex = 13;
            // 
            // tabControl_Formulas_Condicionales
            // 
            this.tabControl_Formulas_Condicionales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Formulas_Condicionales.Controls.Add(this.tab_Formulas);
            this.tabControl_Formulas_Condicionales.Controls.Add(this.tab_Condicionales);
            this.tabControl_Formulas_Condicionales.Location = new System.Drawing.Point(24, 283);
            this.tabControl_Formulas_Condicionales.Name = "tabControl_Formulas_Condicionales";
            this.tabControl_Formulas_Condicionales.SelectedIndex = 0;
            this.tabControl_Formulas_Condicionales.Size = new System.Drawing.Size(944, 351);
            this.tabControl_Formulas_Condicionales.TabIndex = 17;
            // 
            // tab_Formulas
            // 
            this.tab_Formulas.Controls.Add(this.dgv_Formulas);
            this.tab_Formulas.Location = new System.Drawing.Point(4, 22);
            this.tab_Formulas.Name = "tab_Formulas";
            this.tab_Formulas.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Formulas.Size = new System.Drawing.Size(936, 325);
            this.tab_Formulas.TabIndex = 0;
            this.tab_Formulas.Text = "Formulas";
            this.tab_Formulas.UseVisualStyleBackColor = true;
            // 
            // tab_Condicionales
            // 
            this.tab_Condicionales.Controls.Add(this.dgv_Condicionales);
            this.tab_Condicionales.Location = new System.Drawing.Point(4, 22);
            this.tab_Condicionales.Name = "tab_Condicionales";
            this.tab_Condicionales.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Condicionales.Size = new System.Drawing.Size(936, 325);
            this.tab_Condicionales.TabIndex = 1;
            this.tab_Condicionales.Text = "Condicionales";
            this.tab_Condicionales.UseVisualStyleBackColor = true;
            // 
            // dgv_Condicionales
            // 
            this.dgv_Condicionales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Condicionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Condicionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Condicional,
            this.Nombre_Condicionales,
            this.Condicional_Condicionales,
            this.Verdadero_Condicionales,
            this.Falso_Condicionales});
            this.dgv_Condicionales.Location = new System.Drawing.Point(1, 0);
            this.dgv_Condicionales.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Condicionales.MultiSelect = false;
            this.dgv_Condicionales.Name = "dgv_Condicionales";
            this.dgv_Condicionales.Size = new System.Drawing.Size(935, 321);
            this.dgv_Condicionales.TabIndex = 8;
            // 
            // Id_Condicional
            // 
            this.Id_Condicional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Id_Condicional.HeaderText = "ID";
            this.Id_Condicional.Name = "Id_Condicional";
            this.Id_Condicional.Width = 43;
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
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.Location = new System.Drawing.Point(878, 162);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(45, 38);
            this.btnHome.TabIndex = 36;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // frmBuscarFormulas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(998, 659);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.tabControl_Formulas_Condicionales);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_BuscarFormula);
            this.Controls.Add(this.tb_formula);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBuscarFormulas";
            this.Text = "Buscar formula";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Formulas)).EndInit();
            this.tabControl_Formulas_Condicionales.ResumeLayout(false);
            this.tab_Formulas.ResumeLayout(false);
            this.tab_Condicionales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Condicionales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_busquedaId;
        private System.Windows.Forms.RadioButton rb_busqueda_formula;
        private System.Windows.Forms.RadioButton rb_tipo_Condicional;
        private System.Windows.Forms.RadioButton rb_tipo_simple;
        private System.Windows.Forms.RadioButton rb_Columna_Verdadero;
        private System.Windows.Forms.RadioButton rb_Columna_Todos;
        private System.Windows.Forms.RadioButton rb_Columna_Falso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_formula;
        private System.Windows.Forms.Button btn_BuscarFormula;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Formula;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoFormula;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreFormula;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFormula;
        private System.Windows.Forms.DataGridView dgv_Formulas;
        private System.Windows.Forms.TabControl tabControl_Formulas_Condicionales;
        private System.Windows.Forms.TabPage tab_Formulas;
        private System.Windows.Forms.TabPage tab_Condicionales;
        private System.Windows.Forms.RadioButton rb_Columna_Formula;
        private System.Windows.Forms.RadioButton rb_Columna_Nombre;
        private System.Windows.Forms.DataGridView dgv_Condicionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Condicional;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Condicionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicional_Condicionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Verdadero_Condicionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Falso_Condicionales;
        private System.Windows.Forms.RadioButton rb_Columna_Condicional;
        private System.Windows.Forms.Button btnHome;
    }
}