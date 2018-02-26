namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms
{
    partial class FormCuotasDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCuotasDetalle));
            this.textBox_cuota = new System.Windows.Forms.TextBox();
            this.textBox_estado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_DetalleCuota = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_total = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verOperaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DetalleCuota)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_cuota
            // 
            this.textBox_cuota.Enabled = false;
            this.textBox_cuota.Location = new System.Drawing.Point(69, 26);
            this.textBox_cuota.Name = "textBox_cuota";
            this.textBox_cuota.Size = new System.Drawing.Size(236, 20);
            this.textBox_cuota.TabIndex = 0;
            // 
            // textBox_estado
            // 
            this.textBox_estado.Enabled = false;
            this.textBox_estado.Location = new System.Drawing.Point(727, 29);
            this.textBox_estado.Name = "textBox_estado";
            this.textBox_estado.Size = new System.Drawing.Size(84, 20);
            this.textBox_estado.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cuota:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(678, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estado:";
            // 
            // dataGridView_DetalleCuota
            // 
            this.dataGridView_DetalleCuota.AllowUserToAddRows = false;
            this.dataGridView_DetalleCuota.AllowUserToDeleteRows = false;
            this.dataGridView_DetalleCuota.AllowUserToOrderColumns = true;
            this.dataGridView_DetalleCuota.AllowUserToResizeRows = false;
            this.dataGridView_DetalleCuota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DetalleCuota.Location = new System.Drawing.Point(26, 57);
            this.dataGridView_DetalleCuota.Name = "dataGridView_DetalleCuota";
            this.dataGridView_DetalleCuota.ReadOnly = true;
            this.dataGridView_DetalleCuota.RowHeadersVisible = false;
            this.dataGridView_DetalleCuota.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_DetalleCuota.Size = new System.Drawing.Size(794, 464);
            this.dataGridView_DetalleCuota.TabIndex = 4;
            this.dataGridView_DetalleCuota.DoubleClick += new System.EventHandler(this.dataGridView_DetalleCuota_DoubleClick);
            this.dataGridView_DetalleCuota.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_DetalleCuota_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(657, 527);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total : ";
            // 
            // textBox_total
            // 
            this.textBox_total.Location = new System.Drawing.Point(703, 524);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.Size = new System.Drawing.Size(117, 20);
            this.textBox_total.TabIndex = 6;
            this.textBox_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verOperaciónToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // verOperaciónToolStripMenuItem
            // 
            this.verOperaciónToolStripMenuItem.Name = "verOperaciónToolStripMenuItem";
            this.verOperaciónToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.verOperaciónToolStripMenuItem.Text = "Ver Operación";
            this.verOperaciónToolStripMenuItem.Click += new System.EventHandler(this.verOperaciónToolStripMenuItem_Click);
            // 
            // FormCuotasDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 579);
            this.Controls.Add(this.textBox_total);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView_DetalleCuota);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_estado);
            this.Controls.Add(this.textBox_cuota);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCuotasDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles de Cuota";
            this.Load += new System.EventHandler(this.FormCuotasDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DetalleCuota)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_cuota;
        private System.Windows.Forms.TextBox textBox_estado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_DetalleCuota;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_total;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verOperaciónToolStripMenuItem;
    }
}