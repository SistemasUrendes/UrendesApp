namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProvisionesForms
{
    partial class FormCuentasExistentes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCuentasExistentes));
            this.dataGridView_cuentas = new System.Windows.Forms.DataGridView();
            this.button_enviar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_cuentas
            // 
            this.dataGridView_cuentas.AllowUserToAddRows = false;
            this.dataGridView_cuentas.AllowUserToDeleteRows = false;
            this.dataGridView_cuentas.AllowUserToResizeRows = false;
            this.dataGridView_cuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_cuentas.Location = new System.Drawing.Point(2, 38);
            this.dataGridView_cuentas.MultiSelect = false;
            this.dataGridView_cuentas.Name = "dataGridView_cuentas";
            this.dataGridView_cuentas.ReadOnly = true;
            this.dataGridView_cuentas.RowHeadersVisible = false;
            this.dataGridView_cuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_cuentas.Size = new System.Drawing.Size(282, 261);
            this.dataGridView_cuentas.TabIndex = 0;
            this.dataGridView_cuentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_cuentas_KeyDown);
            // 
            // button_enviar
            // 
            this.button_enviar.Location = new System.Drawing.Point(2, 9);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(75, 23);
            this.button_enviar.TabIndex = 2;
            this.button_enviar.Text = "Enviar";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // FormCuentasExistentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 300);
            this.Controls.Add(this.button_enviar);
            this.Controls.Add(this.dataGridView_cuentas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCuentasExistentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas Fondos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCuentasExistentes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cuentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_cuentas;
        private System.Windows.Forms.Button button_enviar;
    }
}