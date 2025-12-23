namespace BOM_Builder.Views
{
    partial class frmLegacyNewBoms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLegacyNewBoms));
            this.dgvLegacy = new System.Windows.Forms.DataGridView();
            this.btnUpdateLegacy = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnUnselectLegacy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilterLegacy = new System.Windows.Forms.TextBox();
            this.btnSelectAllPhantom = new System.Windows.Forms.Button();
            this.btnUnselectPhantom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegacy)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLegacy
            // 
            this.dgvLegacy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLegacy.Location = new System.Drawing.Point(12, 115);
            this.dgvLegacy.Name = "dgvLegacy";
            this.dgvLegacy.Size = new System.Drawing.Size(776, 323);
            this.dgvLegacy.TabIndex = 0;
            // 
            // btnUpdateLegacy
            // 
            this.btnUpdateLegacy.Location = new System.Drawing.Point(418, 59);
            this.btnUpdateLegacy.Name = "btnUpdateLegacy";
            this.btnUpdateLegacy.Size = new System.Drawing.Size(115, 38);
            this.btnUpdateLegacy.TabIndex = 1;
            this.btnUpdateLegacy.Text = "Update";
            this.btnUpdateLegacy.UseVisualStyleBackColor = true;
            this.btnUpdateLegacy.Click += new System.EventHandler(this.btnUpdateLegacy_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(564, 12);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(103, 38);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Select All approved";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnselectLegacy
            // 
            this.btnUnselectLegacy.Location = new System.Drawing.Point(685, 12);
            this.btnUnselectLegacy.Name = "btnUnselectLegacy";
            this.btnUnselectLegacy.Size = new System.Drawing.Size(103, 38);
            this.btnUnselectLegacy.TabIndex = 3;
            this.btnUnselectLegacy.Text = "Unselect All approved";
            this.btnUnselectLegacy.UseVisualStyleBackColor = true;
            this.btnUnselectLegacy.Click += new System.EventHandler(this.btnUnselectLegacy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter:";
            // 
            // txtFilterLegacy
            // 
            this.txtFilterLegacy.Location = new System.Drawing.Point(92, 68);
            this.txtFilterLegacy.Multiline = true;
            this.txtFilterLegacy.Name = "txtFilterLegacy";
            this.txtFilterLegacy.Size = new System.Drawing.Size(255, 29);
            this.txtFilterLegacy.TabIndex = 5;
            this.txtFilterLegacy.TextChanged += new System.EventHandler(this.txtFilterLegacy_TextChanged);
            // 
            // btnSelectAllPhantom
            // 
            this.btnSelectAllPhantom.Location = new System.Drawing.Point(564, 64);
            this.btnSelectAllPhantom.Name = "btnSelectAllPhantom";
            this.btnSelectAllPhantom.Size = new System.Drawing.Size(103, 38);
            this.btnSelectAllPhantom.TabIndex = 6;
            this.btnSelectAllPhantom.Text = "Select All phantom";
            this.btnSelectAllPhantom.UseVisualStyleBackColor = true;
            this.btnSelectAllPhantom.Click += new System.EventHandler(this.btnSelectAllPhantom_Click);
            // 
            // btnUnselectPhantom
            // 
            this.btnUnselectPhantom.Location = new System.Drawing.Point(685, 64);
            this.btnUnselectPhantom.Name = "btnUnselectPhantom";
            this.btnUnselectPhantom.Size = new System.Drawing.Size(103, 38);
            this.btnUnselectPhantom.TabIndex = 7;
            this.btnUnselectPhantom.Text = "Unselect All phantom";
            this.btnUnselectPhantom.UseVisualStyleBackColor = true;
            this.btnUnselectPhantom.Click += new System.EventHandler(this.btnUnselectPhantom_Click);
            // 
            // frmLegacyNewBoms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(41)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUnselectPhantom);
            this.Controls.Add(this.btnSelectAllPhantom);
            this.Controls.Add(this.txtFilterLegacy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUnselectLegacy);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnUpdateLegacy);
            this.Controls.Add(this.dgvLegacy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLegacyNewBoms";
            this.Text = "Legacy";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegacy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLegacy;
        private System.Windows.Forms.Button btnUpdateLegacy;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnUnselectLegacy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilterLegacy;
        private System.Windows.Forms.Button btnSelectAllPhantom;
        private System.Windows.Forms.Button btnUnselectPhantom;
    }
}