namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms
{
    partial class FormFondosDetalles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFondosDetalles));
            this.dataGridView_detallesFondos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detallesFondos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_detallesFondos
            // 
            this.dataGridView_detallesFondos.AllowUserToAddRows = false;
            this.dataGridView_detallesFondos.AllowUserToDeleteRows = false;
            this.dataGridView_detallesFondos.AllowUserToResizeRows = false;
            this.dataGridView_detallesFondos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_detallesFondos.Location = new System.Drawing.Point(12, 32);
            this.dataGridView_detallesFondos.MultiSelect = false;
            this.dataGridView_detallesFondos.Name = "dataGridView_detallesFondos";
            this.dataGridView_detallesFondos.ReadOnly = true;
            this.dataGridView_detallesFondos.RowHeadersVisible = false;
            this.dataGridView_detallesFondos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_detallesFondos.Size = new System.Drawing.Size(1054, 56);
            this.dataGridView_detallesFondos.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(991, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Iniciar Fondo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormFondosDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 98);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_detallesFondos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFondosDetalles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fondos Detalles";
            this.Load += new System.EventHandler(this.FormFondosDetalles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detallesFondos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_detallesFondos;
        private System.Windows.Forms.Button button1;
    }
}