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
            this.button_liquidar = new System.Windows.Forms.Button();
            this.button_cerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencimietos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_vencimietos
            // 
            this.dataGridView_vencimietos.AllowUserToAddRows = false;
            this.dataGridView_vencimietos.AllowUserToDeleteRows = false;
            this.dataGridView_vencimietos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_vencimietos.Location = new System.Drawing.Point(14, 42);
            this.dataGridView_vencimietos.MultiSelect = false;
            this.dataGridView_vencimietos.Name = "dataGridView_vencimietos";
            this.dataGridView_vencimietos.ReadOnly = true;
            this.dataGridView_vencimietos.RowHeadersVisible = false;
            this.dataGridView_vencimietos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_vencimietos.Size = new System.Drawing.Size(747, 197);
            this.dataGridView_vencimietos.TabIndex = 0;
            // 
            // button_liquidar
            // 
            this.button_liquidar.Enabled = false;
            this.button_liquidar.Location = new System.Drawing.Point(679, 12);
            this.button_liquidar.Name = "button_liquidar";
            this.button_liquidar.Size = new System.Drawing.Size(82, 23);
            this.button_liquidar.TabIndex = 2;
            this.button_liquidar.Text = "Liquidar Pte.";
            this.button_liquidar.UseVisualStyleBackColor = true;
            this.button_liquidar.Click += new System.EventHandler(this.button_cerrar_Click);
            // 
            // button_cerrar
            // 
            this.button_cerrar.Enabled = false;
            this.button_cerrar.Location = new System.Drawing.Point(598, 12);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(75, 23);
            this.button_cerrar.TabIndex = 3;
            this.button_cerrar.Text = "Cerrar Pte.";
            this.button_cerrar.UseVisualStyleBackColor = true;
            this.button_cerrar.Click += new System.EventHandler(this.button_cerrar_Click_1);
            // 
            // FormDetallesOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 252);
            this.Controls.Add(this.button_cerrar);
            this.Controls.Add(this.button_liquidar);
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
        private System.Windows.Forms.Button button_liquidar;
        private System.Windows.Forms.Button button_cerrar;
    }
}