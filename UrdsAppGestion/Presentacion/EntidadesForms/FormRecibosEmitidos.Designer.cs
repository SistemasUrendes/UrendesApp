namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    partial class FormRecibosEmitidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecibosEmitidos));
            this.dataGridView_recibosPte = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verEnRemesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_recibosPte)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_recibosPte
            // 
            this.dataGridView_recibosPte.AllowUserToAddRows = false;
            this.dataGridView_recibosPte.AllowUserToDeleteRows = false;
            this.dataGridView_recibosPte.AllowUserToResizeRows = false;
            this.dataGridView_recibosPte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_recibosPte.Location = new System.Drawing.Point(12, 34);
            this.dataGridView_recibosPte.MultiSelect = false;
            this.dataGridView_recibosPte.Name = "dataGridView_recibosPte";
            this.dataGridView_recibosPte.ReadOnly = true;
            this.dataGridView_recibosPte.RowHeadersVisible = false;
            this.dataGridView_recibosPte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_recibosPte.Size = new System.Drawing.Size(614, 296);
            this.dataGridView_recibosPte.TabIndex = 0;
            this.dataGridView_recibosPte.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_recibosPte_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "RECIBOS EMITIDOS";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verEnRemesaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 26);
            // 
            // verEnRemesaToolStripMenuItem
            // 
            this.verEnRemesaToolStripMenuItem.Name = "verEnRemesaToolStripMenuItem";
            this.verEnRemesaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.verEnRemesaToolStripMenuItem.Text = "Ver en Remesa";
            this.verEnRemesaToolStripMenuItem.Click += new System.EventHandler(this.verEnRemesaToolStripMenuItem_Click);
            // 
            // FormRecibosEmitidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 343);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_recibosPte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRecibosEmitidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibos Emitidos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormRecibosEmitidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_recibosPte)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_recibosPte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verEnRemesaToolStripMenuItem;
    }
}