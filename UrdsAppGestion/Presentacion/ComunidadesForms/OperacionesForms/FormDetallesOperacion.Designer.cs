namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormDetallesOperacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetallesOperacion));
            this.dataGridView_vencimietos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencimietos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_vencimietos
            // 
            this.dataGridView_vencimietos.AllowUserToAddRows = false;
            this.dataGridView_vencimietos.AllowUserToDeleteRows = false;
            this.dataGridView_vencimietos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_vencimietos.Location = new System.Drawing.Point(12, 61);
            this.dataGridView_vencimietos.MultiSelect = false;
            this.dataGridView_vencimietos.Name = "dataGridView_vencimietos";
            this.dataGridView_vencimietos.ReadOnly = true;
            this.dataGridView_vencimietos.RowHeadersVisible = false;
            this.dataGridView_vencimietos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_vencimietos.Size = new System.Drawing.Size(747, 197);
            this.dataGridView_vencimietos.TabIndex = 0;
            // 
            // FormDetallesOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 270);
            this.Controls.Add(this.dataGridView_vencimietos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDetallesOperacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles Operacion";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormDetallesOperacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencimietos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_vencimietos;
    }
}