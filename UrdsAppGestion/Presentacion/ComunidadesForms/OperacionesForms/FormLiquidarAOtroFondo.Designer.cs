namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormLiquidarAOtroFondo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLiquidarAOtroFondo));
            this.dataGridView_fondos = new System.Windows.Forms.DataGridView();
            this.button_aceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fondos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_fondos
            // 
            this.dataGridView_fondos.AllowUserToAddRows = false;
            this.dataGridView_fondos.AllowUserToDeleteRows = false;
            this.dataGridView_fondos.AllowUserToResizeRows = false;
            this.dataGridView_fondos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_fondos.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_fondos.Name = "dataGridView_fondos";
            this.dataGridView_fondos.ReadOnly = true;
            this.dataGridView_fondos.RowHeadersVisible = false;
            this.dataGridView_fondos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_fondos.Size = new System.Drawing.Size(387, 119);
            this.dataGridView_fondos.TabIndex = 0;
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(161, 139);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(75, 23);
            this.button_aceptar.TabIndex = 1;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // FormLiquidarAOtroFondo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 174);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.dataGridView_fondos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLiquidarAOtroFondo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidar a Otro Fondo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormLiquidarAOtroFondo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fondos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_fondos;
        private System.Windows.Forms.Button button_aceptar;
    }
}