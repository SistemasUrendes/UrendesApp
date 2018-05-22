namespace UrdsAppGestión.Presentacion.ComunidadesForms.RemesasForms
{
    partial class FormCambiarCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCambiarCuenta));
            this.dataGridView_cuentas = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_cuentas
            // 
            this.dataGridView_cuentas.AllowUserToAddRows = false;
            this.dataGridView_cuentas.AllowUserToDeleteRows = false;
            this.dataGridView_cuentas.AllowUserToResizeRows = false;
            this.dataGridView_cuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_cuentas.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_cuentas.Name = "dataGridView_cuentas";
            this.dataGridView_cuentas.ReadOnly = true;
            this.dataGridView_cuentas.RowHeadersVisible = false;
            this.dataGridView_cuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_cuentas.Size = new System.Drawing.Size(312, 189);
            this.dataGridView_cuentas.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cambiar Cuenta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormCambiarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 240);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_cuentas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCambiarCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Cuenta de ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCambiarCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cuentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_cuentas;
        private System.Windows.Forms.Button button1;
    }
}