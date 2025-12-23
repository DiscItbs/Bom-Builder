namespace BOM_Builder.Views
{
    partial class frmEditComponentsBom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditComponentsBom));
            this.lblCombinacion = new System.Windows.Forms.Label();
            this.txtCombinacion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gpbTipos = new System.Windows.Forms.GroupBox();
            this.rbtnAN = new System.Windows.Forms.RadioButton();
            this.rbtnAL = new System.Windows.Forms.RadioButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvListComponents = new System.Windows.Forms.DataGridView();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblListadoActual = new System.Windows.Forms.Label();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.dgvListComponentsNews = new System.Windows.Forms.DataGridView();
            this.IdC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdComponents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Itemno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descriptions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Applys = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Itemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apply = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gpbTipos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListComponents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListComponentsNews)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCombinacion
            // 
            this.lblCombinacion.AutoSize = true;
            this.lblCombinacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombinacion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblCombinacion.Location = new System.Drawing.Point(12, 14);
            this.lblCombinacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCombinacion.Name = "lblCombinacion";
            this.lblCombinacion.Size = new System.Drawing.Size(221, 20);
            this.lblCombinacion.TabIndex = 0;
            this.lblCombinacion.Text = "Ingrese combinación del BOM";
            // 
            // txtCombinacion
            // 
            this.txtCombinacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCombinacion.Location = new System.Drawing.Point(15, 39);
            this.txtCombinacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtCombinacion.Name = "txtCombinacion";
            this.txtCombinacion.Size = new System.Drawing.Size(317, 26);
            this.txtCombinacion.TabIndex = 1;
            this.txtCombinacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(660, 14);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(121, 46);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // gpbTipos
            // 
            this.gpbTipos.Controls.Add(this.rbtnAN);
            this.gpbTipos.Controls.Add(this.rbtnAL);
            this.gpbTipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbTipos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gpbTipos.Location = new System.Drawing.Point(350, 14);
            this.gpbTipos.Margin = new System.Windows.Forms.Padding(4);
            this.gpbTipos.Name = "gpbTipos";
            this.gpbTipos.Padding = new System.Windows.Forms.Padding(4);
            this.gpbTipos.Size = new System.Drawing.Size(187, 46);
            this.gpbTipos.TabIndex = 8;
            this.gpbTipos.TabStop = false;
            this.gpbTipos.Text = "Tipos de componentes";
            // 
            // rbtnAN
            // 
            this.rbtnAN.AutoSize = true;
            this.rbtnAN.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rbtnAN.Location = new System.Drawing.Point(65, 18);
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
            this.rbtnAL.Location = new System.Drawing.Point(7, 18);
            this.rbtnAL.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnAL.Name = "rbtnAL";
            this.rbtnAL.Size = new System.Drawing.Size(47, 24);
            this.rbtnAL.TabIndex = 2;
            this.rbtnAL.TabStop = true;
            this.rbtnAL.Text = "AL";
            this.rbtnAL.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(545, 14);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(108, 46);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // dgvListComponents
            // 
            this.dgvListComponents.AllowUserToAddRows = false;
            this.dgvListComponents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListComponents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListComponents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdComponent,
            this.Linea,
            this.Itemo,
            this.Class,
            this.Description,
            this.Qty,
            this.Apply});
            this.dgvListComponents.Location = new System.Drawing.Point(15, 101);
            this.dgvListComponents.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListComponents.Name = "dgvListComponents";
            this.dgvListComponents.Size = new System.Drawing.Size(1021, 277);
            this.dgvListComponents.TabIndex = 6;
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(811, 389);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(226, 26);
            this.txtFilter.TabIndex = 7;
            this.txtFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFilter.TextChanged += new System.EventHandler(this.TxtFilter_TextChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblFilter.Location = new System.Drawing.Point(681, 394);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(127, 20);
            this.lblFilter.TabIndex = 66;
            this.lblFilter.Text = "Filtrar resultados";
            // 
            // lblListadoActual
            // 
            this.lblListadoActual.AutoSize = true;
            this.lblListadoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListadoActual.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblListadoActual.Location = new System.Drawing.Point(12, 73);
            this.lblListadoActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListadoActual.Name = "lblListadoActual";
            this.lblListadoActual.Size = new System.Drawing.Size(173, 20);
            this.lblListadoActual.TabIndex = 67;
            this.lblListadoActual.Text = "Componentes actuales";
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblBusqueda.Location = new System.Drawing.Point(12, 391);
            this.lblBusqueda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(260, 20);
            this.lblBusqueda.TabIndex = 69;
            this.lblBusqueda.Text = "Busqueda de nuevos componentes";
            // 
            // dgvListComponentsNews
            // 
            this.dgvListComponentsNews.AllowUserToAddRows = false;
            this.dgvListComponentsNews.AllowUserToDeleteRows = false;
            this.dgvListComponentsNews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListComponentsNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListComponentsNews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdC,
            this.IdComponents,
            this.Itemno,
            this.Classes,
            this.Descriptions,
            this.Qtys,
            this.Applys});
            this.dgvListComponentsNews.Location = new System.Drawing.Point(15, 418);
            this.dgvListComponentsNews.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListComponentsNews.Name = "dgvListComponentsNews";
            this.dgvListComponentsNews.Size = new System.Drawing.Size(1021, 260);
            this.dgvListComponentsNews.TabIndex = 8;
            // 
            // IdC
            // 
            this.IdC.HeaderText = "Id";
            this.IdC.Name = "IdC";
            this.IdC.Visible = false;
            // 
            // IdComponents
            // 
            this.IdComponents.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdComponents.HeaderText = "IdComponent";
            this.IdComponents.Name = "IdComponents";
            this.IdComponents.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdComponents.Visible = false;
            // 
            // Itemno
            // 
            this.Itemno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Itemno.HeaderText = "Número de parte";
            this.Itemno.Name = "Itemno";
            this.Itemno.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Itemno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Classes
            // 
            this.Classes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Classes.HeaderText = "Class";
            this.Classes.Name = "Classes";
            this.Classes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Classes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Classes.Width = 48;
            // 
            // Descriptions
            // 
            this.Descriptions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descriptions.HeaderText = "Descipcion";
            this.Descriptions.Name = "Descriptions";
            // 
            // Qtys
            // 
            this.Qtys.HeaderText = "Cantidad de material requerido (pza)";
            this.Qtys.Name = "Qtys";
            // 
            // Applys
            // 
            this.Applys.HeaderText = "Seleccionar componente";
            this.Applys.Name = "Applys";
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // IdComponent
            // 
            this.IdComponent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdComponent.HeaderText = "IdComponent";
            this.IdComponent.Name = "IdComponent";
            this.IdComponent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdComponent.Visible = false;
            // 
            // Linea
            // 
            this.Linea.HeaderText = "Linea";
            this.Linea.Name = "Linea";
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
            this.Class.Width = 48;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Descipcion";
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
            // frmEditComponentsBom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(1050, 691);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.dgvListComponentsNews);
            this.Controls.Add(this.lblListadoActual);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.dgvListComponents);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.gpbTipos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtCombinacion);
            this.Controls.Add(this.lblCombinacion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEditComponentsBom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edición de componentes por BOM";
            this.Load += new System.EventHandler(this.FrmEditComponentsBom_Load);
            this.gpbTipos.ResumeLayout(false);
            this.gpbTipos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListComponents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListComponentsNews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCombinacion;
        private System.Windows.Forms.TextBox txtCombinacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox gpbTipos;
        private System.Windows.Forms.RadioButton rbtnAN;
        private System.Windows.Forms.RadioButton rbtnAL;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvListComponents;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblListadoActual;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.DataGridView dgvListComponentsNews;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdC;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComponents;
        private System.Windows.Forms.DataGridViewTextBoxColumn Itemno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descriptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtys;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Applys;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Itemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Apply;
    }
}