namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormServiciosBloque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServiciosBloque));
            this.textBoxFiltroBloque = new System.Windows.Forms.TextBox();
            this.dataGridViewBloque = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBloque)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFiltroBloque
            // 
            this.textBoxFiltroBloque.Location = new System.Drawing.Point(12, 12);
            this.textBoxFiltroBloque.Name = "textBoxFiltroBloque";
            this.textBoxFiltroBloque.Size = new System.Drawing.Size(293, 20);
            this.textBoxFiltroBloque.TabIndex = 5;
            this.textBoxFiltroBloque.TextChanged += new System.EventHandler(this.textBoxFiltroBloque_TextChanged);
            // 
            // dataGridViewBloque
            // 
            this.dataGridViewBloque.AllowUserToAddRows = false;
            this.dataGridViewBloque.AllowUserToDeleteRows = false;
            this.dataGridViewBloque.AllowUserToResizeRows = false;
            this.dataGridViewBloque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBloque.Location = new System.Drawing.Point(12, 36);
            this.dataGridViewBloque.Name = "dataGridViewBloque";
            this.dataGridViewBloque.ReadOnly = true;
            this.dataGridViewBloque.RowHeadersVisible = false;
            this.dataGridViewBloque.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewBloque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBloque.ShowEditingIcon = false;
            this.dataGridViewBloque.Size = new System.Drawing.Size(293, 350);
            this.dataGridViewBloque.TabIndex = 4;
            this.dataGridViewBloque.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBloque_CellDoubleClick);
            // 
            // FormServiciosBloque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 399);
            this.Controls.Add(this.textBoxFiltroBloque);
            this.Controls.Add(this.dataGridViewBloque);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormServiciosBloque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servicios Bloque";
            this.Load += new System.EventHandler(this.FormServiciosBloque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBloque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFiltroBloque;
        private System.Windows.Forms.DataGridView dataGridViewBloque;
    }
}