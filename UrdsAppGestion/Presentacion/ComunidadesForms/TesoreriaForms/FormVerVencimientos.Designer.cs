namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    partial class FormVerVencimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerVencimientos));
            this.dataGridView_vencmientos = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verOperaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencmientos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_vencmientos
            // 
            this.dataGridView_vencmientos.AllowUserToAddRows = false;
            this.dataGridView_vencmientos.AllowUserToDeleteRows = false;
            this.dataGridView_vencmientos.AllowUserToResizeRows = false;
            this.dataGridView_vencmientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_vencmientos.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_vencmientos.MultiSelect = false;
            this.dataGridView_vencmientos.Name = "dataGridView_vencmientos";
            this.dataGridView_vencmientos.ReadOnly = true;
            this.dataGridView_vencmientos.RowHeadersVisible = false;
            this.dataGridView_vencmientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_vencmientos.Size = new System.Drawing.Size(804, 226);
            this.dataGridView_vencmientos.TabIndex = 0;
            this.dataGridView_vencmientos.DoubleClick += new System.EventHandler(this.dataGridView_vencmientos_DoubleClick);
            this.dataGridView_vencmientos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_vencmientos_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verOperaciónToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // verOperaciónToolStripMenuItem
            // 
            this.verOperaciónToolStripMenuItem.Name = "verOperaciónToolStripMenuItem";
            this.verOperaciónToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verOperaciónToolStripMenuItem.Text = "Ver Operación";
            this.verOperaciónToolStripMenuItem.Click += new System.EventHandler(this.verOperaciónToolStripMenuItem_Click);
            // 
            // FormVerVencimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 247);
            this.Controls.Add(this.dataGridView_vencmientos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerVencimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vencimientos";
            this.Load += new System.EventHandler(this.FormVerVencimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencmientos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_vencmientos;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verOperaciónToolStripMenuItem;
    }
}