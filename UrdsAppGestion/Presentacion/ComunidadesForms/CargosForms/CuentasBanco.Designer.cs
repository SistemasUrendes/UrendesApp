namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    partial class CuentasBanco
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuentasBanco));
            this.dataGridView_cuentasBanco = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiarCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cuentasBanco)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_cuentasBanco
            // 
            this.dataGridView_cuentasBanco.AllowUserToAddRows = false;
            this.dataGridView_cuentasBanco.AllowUserToDeleteRows = false;
            this.dataGridView_cuentasBanco.AllowUserToResizeRows = false;
            this.dataGridView_cuentasBanco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_cuentasBanco.Location = new System.Drawing.Point(12, 47);
            this.dataGridView_cuentasBanco.MultiSelect = false;
            this.dataGridView_cuentasBanco.Name = "dataGridView_cuentasBanco";
            this.dataGridView_cuentasBanco.ReadOnly = true;
            this.dataGridView_cuentasBanco.RowHeadersVisible = false;
            this.dataGridView_cuentasBanco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_cuentasBanco.Size = new System.Drawing.Size(1013, 385);
            this.dataGridView_cuentasBanco.TabIndex = 0;
            this.dataGridView_cuentasBanco.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_cuentasBanco_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiarCuentaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 26);
            // 
            // copiarCuentaToolStripMenuItem
            // 
            this.copiarCuentaToolStripMenuItem.Name = "copiarCuentaToolStripMenuItem";
            this.copiarCuentaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.copiarCuentaToolStripMenuItem.Text = "Copiar Cuenta";
            this.copiarCuentaToolStripMenuItem.Click += new System.EventHandler(this.copiarCuentaToolStripMenuItem_Click);
            // 
            // CuentasBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 444);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView_cuentasBanco);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CuentasBanco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas Banco";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CuentasBanco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_cuentasBanco)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_cuentasBanco;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copiarCuentaToolStripMenuItem;
    }
}