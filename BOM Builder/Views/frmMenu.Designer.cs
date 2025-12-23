namespace BOM_Builder
{
   partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGenerador = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLegacyForm = new System.Windows.Forms.Button();
            this.btnTestCon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BOM_Builder.Properties.Resources.namm;
            this.pictureBox1.Location = new System.Drawing.Point(13, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(309, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnGenerador
            // 
            this.btnGenerador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerador.Location = new System.Drawing.Point(44, 303);
            this.btnGenerador.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerador.Name = "btnGenerador";
            this.btnGenerador.Size = new System.Drawing.Size(252, 63);
            this.btnGenerador.TabIndex = 2;
            this.btnGenerador.Text = "Generador de boms";
            this.btnGenerador.UseVisualStyleBackColor = true;
            this.btnGenerador.Click += new System.EventHandler(this.btnDifusoresPerimentrales_Click);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.Location = new System.Drawing.Point(44, 230);
            this.btnConfiguracion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(252, 63);
            this.btnConfiguracion.TabIndex = 1;
            this.btnConfiguracion.Text = "Configuracion global";
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(198, 547);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Version 4.7.0";
            // 
            // btnLegacyForm
            // 
            this.btnLegacyForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLegacyForm.Location = new System.Drawing.Point(44, 376);
            this.btnLegacyForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLegacyForm.Name = "btnLegacyForm";
            this.btnLegacyForm.Size = new System.Drawing.Size(252, 63);
            this.btnLegacyForm.TabIndex = 4;
            this.btnLegacyForm.Text = "Legacy approved";
            this.btnLegacyForm.UseVisualStyleBackColor = true;
            this.btnLegacyForm.Click += new System.EventHandler(this.btnLegacyForm_Click);
            // 
            // btnTestCon
            // 
            this.btnTestCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestCon.Location = new System.Drawing.Point(44, 449);
            this.btnTestCon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTestCon.Name = "btnTestCon";
            this.btnTestCon.Size = new System.Drawing.Size(252, 63);
            this.btnTestCon.TabIndex = 5;
            this.btnTestCon.Text = "Test Connection";
            this.btnTestCon.UseVisualStyleBackColor = true;
            this.btnTestCon.Visible = false;
            this.btnTestCon.Click += new System.EventHandler(this.btnTestCon_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(343, 588);
            this.Controls.Add(this.btnTestCon);
            this.Controls.Add(this.btnLegacyForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfiguracion);
            this.Controls.Add(this.btnGenerador);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "       ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Button btnGenerador;
      private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLegacyForm;
        private System.Windows.Forms.Button btnTestCon;
    }
}