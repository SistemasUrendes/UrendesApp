namespace UrdsAppGestión.Presentacion.EnviosForms
{
    partial class RegistroEnvios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroEnvios));
            this.dataGridView_registro = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_registro)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_registro
            // 
            this.dataGridView_registro.AllowUserToAddRows = false;
            this.dataGridView_registro.AllowUserToDeleteRows = false;
            this.dataGridView_registro.AllowUserToResizeRows = false;
            this.dataGridView_registro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_registro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_registro.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_registro.Name = "dataGridView_registro";
            this.dataGridView_registro.ReadOnly = true;
            this.dataGridView_registro.RowHeadersVisible = false;
            this.dataGridView_registro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_registro.Size = new System.Drawing.Size(995, 470);
            this.dataGridView_registro.TabIndex = 0;
            // 
            // RegistroEnvios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 470);
            this.Controls.Add(this.dataGridView_registro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroEnvios";
            this.Text = "Registro Envios";
            this.Load += new System.EventHandler(this.RegistroEnvios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_registro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_registro;
    }
}