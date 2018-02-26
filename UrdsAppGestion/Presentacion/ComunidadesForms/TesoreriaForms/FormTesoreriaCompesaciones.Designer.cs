namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    partial class FormTesoreriaCompesaciones
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
            this.dataGridView_compesaciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_compesaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_compesaciones
            // 
            this.dataGridView_compesaciones.AllowUserToAddRows = false;
            this.dataGridView_compesaciones.AllowUserToDeleteRows = false;
            this.dataGridView_compesaciones.AllowUserToResizeRows = false;
            this.dataGridView_compesaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_compesaciones.Location = new System.Drawing.Point(12, 63);
            this.dataGridView_compesaciones.MultiSelect = false;
            this.dataGridView_compesaciones.Name = "dataGridView_compesaciones";
            this.dataGridView_compesaciones.ReadOnly = true;
            this.dataGridView_compesaciones.RowHeadersVisible = false;
            this.dataGridView_compesaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_compesaciones.Size = new System.Drawing.Size(1077, 498);
            this.dataGridView_compesaciones.TabIndex = 0;
            // 
            // FormTesoreriaCompesaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 580);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView_compesaciones);
            this.Name = "FormTesoreriaCompesaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compesaciones";
            this.Load += new System.EventHandler(this.FormTesoreriaCompesaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_compesaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_compesaciones;
    }
}