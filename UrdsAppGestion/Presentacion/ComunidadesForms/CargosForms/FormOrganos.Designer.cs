namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    partial class FormOrganos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrganos));
            this.dataGridView_organos = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_organos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_organos
            // 
            this.dataGridView_organos.AllowUserToAddRows = false;
            this.dataGridView_organos.AllowUserToDeleteRows = false;
            this.dataGridView_organos.AllowUserToResizeRows = false;
            this.dataGridView_organos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_organos.Location = new System.Drawing.Point(12, 41);
            this.dataGridView_organos.MultiSelect = false;
            this.dataGridView_organos.Name = "dataGridView_organos";
            this.dataGridView_organos.ReadOnly = true;
            this.dataGridView_organos.RowHeadersVisible = false;
            this.dataGridView_organos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_organos.Size = new System.Drawing.Size(347, 326);
            this.dataGridView_organos.TabIndex = 0;
            this.dataGridView_organos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_organos_MouseClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Nuevo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activarToolStripMenuItem,
            this.desactivarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 48);
            // 
            // activarToolStripMenuItem
            // 
            this.activarToolStripMenuItem.Name = "activarToolStripMenuItem";
            this.activarToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.activarToolStripMenuItem.Text = "Activar";
            this.activarToolStripMenuItem.Click += new System.EventHandler(this.activarToolStripMenuItem_Click);
            // 
            // desactivarToolStripMenuItem
            // 
            this.desactivarToolStripMenuItem.Name = "desactivarToolStripMenuItem";
            this.desactivarToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.desactivarToolStripMenuItem.Text = "Desactivar";
            this.desactivarToolStripMenuItem.Click += new System.EventHandler(this.desactivarToolStripMenuItem_Click);
            // 
            // FormAñadirOrgano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 379);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView_organos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAñadirOrgano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Añadir Organo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAñadirOrgano_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_organos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_organos;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem activarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactivarToolStripMenuItem;
    }
}