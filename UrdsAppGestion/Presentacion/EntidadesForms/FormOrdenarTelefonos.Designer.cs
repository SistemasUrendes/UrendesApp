namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    partial class FormOrdenarTelefonos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrdenarTelefonos));
            this.dataGridView_telefonos = new System.Windows.Forms.DataGridView();
            this.labelEntidad = new System.Windows.Forms.Label();
            this.buttonBajar = new System.Windows.Forms.Button();
            this.buttonSubir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_telefonos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_telefonos
            // 
            this.dataGridView_telefonos.AllowUserToAddRows = false;
            this.dataGridView_telefonos.AllowUserToDeleteRows = false;
            this.dataGridView_telefonos.AllowUserToResizeRows = false;
            this.dataGridView_telefonos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView_telefonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_telefonos.Location = new System.Drawing.Point(12, 40);
            this.dataGridView_telefonos.MultiSelect = false;
            this.dataGridView_telefonos.Name = "dataGridView_telefonos";
            this.dataGridView_telefonos.ReadOnly = true;
            this.dataGridView_telefonos.RowHeadersVisible = false;
            this.dataGridView_telefonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_telefonos.Size = new System.Drawing.Size(455, 301);
            this.dataGridView_telefonos.TabIndex = 1;
            // 
            // labelEntidad
            // 
            this.labelEntidad.AutoSize = true;
            this.labelEntidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntidad.Location = new System.Drawing.Point(13, 13);
            this.labelEntidad.Name = "labelEntidad";
            this.labelEntidad.Size = new System.Drawing.Size(0, 17);
            this.labelEntidad.TabIndex = 2;
            // 
            // buttonBajar
            // 
            this.buttonBajar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBajar.Location = new System.Drawing.Point(472, 184);
            this.buttonBajar.Name = "buttonBajar";
            this.buttonBajar.Size = new System.Drawing.Size(28, 57);
            this.buttonBajar.TabIndex = 34;
            this.buttonBajar.Text = "↓";
            this.buttonBajar.UseVisualStyleBackColor = true;
            this.buttonBajar.Click += new System.EventHandler(this.buttonBajar_Click);
            // 
            // buttonSubir
            // 
            this.buttonSubir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubir.Location = new System.Drawing.Point(473, 121);
            this.buttonSubir.Name = "buttonSubir";
            this.buttonSubir.Size = new System.Drawing.Size(28, 57);
            this.buttonSubir.TabIndex = 33;
            this.buttonSubir.Text = "↑";
            this.buttonSubir.UseVisualStyleBackColor = true;
            this.buttonSubir.Click += new System.EventHandler(this.buttonSubir_Click);
            // 
            // FormOrdenarTelefonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 370);
            this.Controls.Add(this.buttonBajar);
            this.Controls.Add(this.buttonSubir);
            this.Controls.Add(this.labelEntidad);
            this.Controls.Add(this.dataGridView_telefonos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOrdenarTelefonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordenar Teléfonos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormOrdenarTelefonos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_telefonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView_telefonos;
        private System.Windows.Forms.Label labelEntidad;
        private System.Windows.Forms.Button buttonBajar;
        private System.Windows.Forms.Button buttonSubir;
    }
}