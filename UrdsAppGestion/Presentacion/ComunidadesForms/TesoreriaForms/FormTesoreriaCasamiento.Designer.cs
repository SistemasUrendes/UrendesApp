namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormTesoreriaCasamiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTesoreriaCasamiento));
            this.dataGridView_datos_bancos = new System.Windows.Forms.DataGridView();
            this.dataGridView_vencimientos = new System.Windows.Forms.DataGridView();
            this.button_importarBanco = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_datos_bancos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_datos_bancos
            // 
            this.dataGridView_datos_bancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_datos_bancos.Location = new System.Drawing.Point(176, 42);
            this.dataGridView_datos_bancos.MultiSelect = false;
            this.dataGridView_datos_bancos.Name = "dataGridView_datos_bancos";
            this.dataGridView_datos_bancos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_datos_bancos.Size = new System.Drawing.Size(650, 311);
            this.dataGridView_datos_bancos.TabIndex = 0;
            this.dataGridView_datos_bancos.Click += new System.EventHandler(this.dataGridView_datos_bancos_Click);
            // 
            // dataGridView_vencimientos
            // 
            this.dataGridView_vencimientos.AllowUserToAddRows = false;
            this.dataGridView_vencimientos.AllowUserToDeleteRows = false;
            this.dataGridView_vencimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_vencimientos.Location = new System.Drawing.Point(21, 373);
            this.dataGridView_vencimientos.Name = "dataGridView_vencimientos";
            this.dataGridView_vencimientos.ReadOnly = true;
            this.dataGridView_vencimientos.Size = new System.Drawing.Size(936, 311);
            this.dataGridView_vencimientos.TabIndex = 1;
            // 
            // button_importarBanco
            // 
            this.button_importarBanco.Location = new System.Drawing.Point(37, 42);
            this.button_importarBanco.Name = "button_importarBanco";
            this.button_importarBanco.Size = new System.Drawing.Size(124, 89);
            this.button_importarBanco.TabIndex = 2;
            this.button_importarBanco.Text = "Examinar...";
            this.button_importarBanco.UseVisualStyleBackColor = true;
            this.button_importarBanco.Click += new System.EventHandler(this.button_importarBanco_Click);
            // 
            // FormTesoreriaCasamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 693);
            this.Controls.Add(this.button_importarBanco);
            this.Controls.Add(this.dataGridView_vencimientos);
            this.Controls.Add(this.dataGridView_datos_bancos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTesoreriaCasamiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTesoreriaCasamiento";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTesoreriaCasamiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_datos_bancos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencimientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_datos_bancos;
        private System.Windows.Forms.DataGridView dataGridView_vencimientos;
        private System.Windows.Forms.Button button_importarBanco;
    }
}