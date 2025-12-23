namespace BOM_Builder.Views
{
    partial class frmRemplazoComponentes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRemplazoComponentes));
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.lblComponenteOriginal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Buscar_Componente = new System.Windows.Forms.Button();
            this.btn_RemplazarComponente = new System.Windows.Forms.Button();
            this.dgvBoms = new System.Windows.Forms.DataGridView();
            this.NombreBom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeleccionarBom = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnQuitarSeleccion = new System.Windows.Forms.Button();
            this.cbComponenteOrig = new System.Windows.Forms.ComboBox();
            this.chbAL = new System.Windows.Forms.CheckBox();
            this.chbTipo = new System.Windows.Forms.GroupBox();
            this.chbAN = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoms)).BeginInit();
            this.chbTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDestino
            // 
            this.txtDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestino.Location = new System.Drawing.Point(297, 59);
            this.txtDestino.Multiline = true;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(223, 21);
            this.txtDestino.TabIndex = 1;
            this.txtDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblComponenteOriginal
            // 
            this.lblComponenteOriginal.AutoSize = true;
            this.lblComponenteOriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComponenteOriginal.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblComponenteOriginal.Location = new System.Drawing.Point(32, 27);
            this.lblComponenteOriginal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComponenteOriginal.Name = "lblComponenteOriginal";
            this.lblComponenteOriginal.Size = new System.Drawing.Size(225, 20);
            this.lblComponenteOriginal.TabIndex = 2;
            this.lblComponenteOriginal.Text = "Ingrese componente asignado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(278, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese componente a reemplazar";
            // 
            // btn_Buscar_Componente
            // 
            this.btn_Buscar_Componente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Buscar_Componente.Location = new System.Drawing.Point(538, 44);
            this.btn_Buscar_Componente.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Buscar_Componente.Name = "btn_Buscar_Componente";
            this.btn_Buscar_Componente.Size = new System.Drawing.Size(108, 46);
            this.btn_Buscar_Componente.TabIndex = 5;
            this.btn_Buscar_Componente.Text = "Buscar";
            this.btn_Buscar_Componente.UseVisualStyleBackColor = true;
            this.btn_Buscar_Componente.Click += new System.EventHandler(this.btn_Buscar_Componente_Click);
            // 
            // btn_RemplazarComponente
            // 
            this.btn_RemplazarComponente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RemplazarComponente.Location = new System.Drawing.Point(654, 44);
            this.btn_RemplazarComponente.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RemplazarComponente.Name = "btn_RemplazarComponente";
            this.btn_RemplazarComponente.Size = new System.Drawing.Size(108, 46);
            this.btn_RemplazarComponente.TabIndex = 6;
            this.btn_RemplazarComponente.Text = "Remplazar";
            this.btn_RemplazarComponente.UseVisualStyleBackColor = true;
            this.btn_RemplazarComponente.Click += new System.EventHandler(this.btn_RemplazarComponente_Click);
            // 
            // dgvBoms
            // 
            this.dgvBoms.AllowUserToAddRows = false;
            this.dgvBoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreBom,
            this.SeleccionarBom});
            this.dgvBoms.Location = new System.Drawing.Point(30, 145);
            this.dgvBoms.Name = "dgvBoms";
            this.dgvBoms.Size = new System.Drawing.Size(718, 248);
            this.dgvBoms.TabIndex = 7;
            // 
            // NombreBom
            // 
            this.NombreBom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreBom.HeaderText = "Nombre bom";
            this.NombreBom.Name = "NombreBom";
            // 
            // SeleccionarBom
            // 
            this.SeleccionarBom.HeaderText = "Seleccionar";
            this.SeleccionarBom.Name = "SeleccionarBom";
            this.SeleccionarBom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SeleccionarBom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnQuitarSeleccion
            // 
            this.btnQuitarSeleccion.Location = new System.Drawing.Point(654, 103);
            this.btnQuitarSeleccion.Name = "btnQuitarSeleccion";
            this.btnQuitarSeleccion.Size = new System.Drawing.Size(90, 36);
            this.btnQuitarSeleccion.TabIndex = 8;
            this.btnQuitarSeleccion.Text = "Seleccionar todo";
            this.btnQuitarSeleccion.UseVisualStyleBackColor = true;
            this.btnQuitarSeleccion.Click += new System.EventHandler(this.btnQuitarSeleccion_Click);
            // 
            // cbComponenteOrig
            // 
            this.cbComponenteOrig.FormattingEnabled = true;
            this.cbComponenteOrig.Location = new System.Drawing.Point(36, 59);
            this.cbComponenteOrig.Name = "cbComponenteOrig";
            this.cbComponenteOrig.Size = new System.Drawing.Size(221, 21);
            this.cbComponenteOrig.TabIndex = 9;
            // 
            // chbAL
            // 
            this.chbAL.AutoSize = true;
            this.chbAL.Location = new System.Drawing.Point(31, 22);
            this.chbAL.Name = "chbAL";
            this.chbAL.Size = new System.Drawing.Size(48, 24);
            this.chbAL.TabIndex = 11;
            this.chbAL.Text = "AL";
            this.chbAL.UseVisualStyleBackColor = true;
            // 
            // chbTipo
            // 
            this.chbTipo.Controls.Add(this.chbAN);
            this.chbTipo.Controls.Add(this.chbAL);
            this.chbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbTipo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.chbTipo.Location = new System.Drawing.Point(333, 87);
            this.chbTipo.Margin = new System.Windows.Forms.Padding(4);
            this.chbTipo.Name = "chbTipo";
            this.chbTipo.Padding = new System.Windows.Forms.Padding(4);
            this.chbTipo.Size = new System.Drawing.Size(187, 52);
            this.chbTipo.TabIndex = 10;
            this.chbTipo.TabStop = false;
            this.chbTipo.Text = "Tipos de componentes";
            // 
            // chbAN
            // 
            this.chbAN.AutoSize = true;
            this.chbAN.Location = new System.Drawing.Point(85, 22);
            this.chbAN.Name = "chbAN";
            this.chbAN.Size = new System.Drawing.Size(50, 24);
            this.chbAN.TabIndex = 12;
            this.chbAN.Text = "AN";
            this.chbAN.UseVisualStyleBackColor = true;
            // 
            // frmRemplazoComponentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(775, 415);
            this.Controls.Add(this.chbTipo);
            this.Controls.Add(this.cbComponenteOrig);
            this.Controls.Add(this.btnQuitarSeleccion);
            this.Controls.Add(this.dgvBoms);
            this.Controls.Add(this.btn_RemplazarComponente);
            this.Controls.Add(this.btn_Buscar_Componente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblComponenteOriginal);
            this.Controls.Add(this.txtDestino);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRemplazoComponentes";
            this.Text = "Remplazo de componentes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoms)).EndInit();
            this.chbTipo.ResumeLayout(false);
            this.chbTipo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label lblComponenteOriginal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Buscar_Componente;
        private System.Windows.Forms.Button btn_RemplazarComponente;
        private System.Windows.Forms.DataGridView dgvBoms;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreBom;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SeleccionarBom;
        private System.Windows.Forms.Button btnQuitarSeleccion;
        private System.Windows.Forms.ComboBox cbComponenteOrig;
        private System.Windows.Forms.CheckBox chbAL;
        private System.Windows.Forms.GroupBox chbTipo;
        private System.Windows.Forms.CheckBox chbAN;
    }
}