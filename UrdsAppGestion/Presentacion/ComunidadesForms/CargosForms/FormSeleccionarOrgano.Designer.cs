namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    partial class FormSeleccionarOrgano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeleccionarOrgano));
            this.textBoxFiltroOrganos = new System.Windows.Forms.TextBox();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.dataGridViewOrganos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrganos)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFiltroOrganos
            // 
            this.textBoxFiltroOrganos.Location = new System.Drawing.Point(93, 14);
            this.textBoxFiltroOrganos.Name = "textBoxFiltroOrganos";
            this.textBoxFiltroOrganos.Size = new System.Drawing.Size(319, 20);
            this.textBoxFiltroOrganos.TabIndex = 18;
            this.textBoxFiltroOrganos.TextChanged += new System.EventHandler(this.textBoxFiltroBloque_TextChanged);
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Location = new System.Drawing.Point(12, 12);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(75, 23);
            this.buttonEnviar.TabIndex = 17;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // dataGridViewOrganos
            // 
            this.dataGridViewOrganos.AllowUserToAddRows = false;
            this.dataGridViewOrganos.AllowUserToDeleteRows = false;
            this.dataGridViewOrganos.AllowUserToResizeRows = false;
            this.dataGridViewOrganos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrganos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrganos.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewOrganos.MultiSelect = false;
            this.dataGridViewOrganos.Name = "dataGridViewOrganos";
            this.dataGridViewOrganos.ReadOnly = true;
            this.dataGridViewOrganos.RowHeadersVisible = false;
            this.dataGridViewOrganos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrganos.Size = new System.Drawing.Size(400, 343);
            this.dataGridViewOrganos.TabIndex = 16;
            // 
            // FormSeleccionarOrgano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 392);
            this.Controls.Add(this.textBoxFiltroOrganos);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.dataGridViewOrganos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSeleccionarOrgano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSeleccionarOrgano";
            this.Load += new System.EventHandler(this.FormSeleccionarOrgano_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrganos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFiltroOrganos;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.DataGridView dataGridViewOrganos;
    }
}