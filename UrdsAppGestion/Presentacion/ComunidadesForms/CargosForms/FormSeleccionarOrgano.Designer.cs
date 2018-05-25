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
            this.textBoxFiltroBloque = new System.Windows.Forms.TextBox();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.dataGridViewBloques = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBloques)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFiltroBloque
            // 
            this.textBoxFiltroBloque.Location = new System.Drawing.Point(93, 14);
            this.textBoxFiltroBloque.Name = "textBoxFiltroBloque";
            this.textBoxFiltroBloque.Size = new System.Drawing.Size(319, 20);
            this.textBoxFiltroBloque.TabIndex = 18;
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Location = new System.Drawing.Point(12, 12);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(75, 23);
            this.buttonEnviar.TabIndex = 17;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBloques
            // 
            this.dataGridViewBloques.AllowUserToAddRows = false;
            this.dataGridViewBloques.AllowUserToDeleteRows = false;
            this.dataGridViewBloques.AllowUserToResizeRows = false;
            this.dataGridViewBloques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBloques.Location = new System.Drawing.Point(12, 41);
            this.dataGridViewBloques.MultiSelect = false;
            this.dataGridViewBloques.Name = "dataGridViewBloques";
            this.dataGridViewBloques.ReadOnly = true;
            this.dataGridViewBloques.RowHeadersVisible = false;
            this.dataGridViewBloques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBloques.Size = new System.Drawing.Size(400, 343);
            this.dataGridViewBloques.TabIndex = 16;
            // 
            // FormSeleccionarOrgano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 392);
            this.Controls.Add(this.textBoxFiltroBloque);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.dataGridViewBloques);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSeleccionarOrgano";
            this.Text = "FormSeleccionarOrgano";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBloques)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFiltroBloque;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.DataGridView dataGridViewBloques;
    }
}