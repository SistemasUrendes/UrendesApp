namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormAbonarVencimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbonarVencimiento));
            this.dataGridView_vencimientos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_nuevoComunero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verMovimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencimientos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_vencimientos
            // 
            this.dataGridView_vencimientos.AllowUserToAddRows = false;
            this.dataGridView_vencimientos.AllowUserToDeleteRows = false;
            this.dataGridView_vencimientos.AllowUserToResizeRows = false;
            this.dataGridView_vencimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_vencimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_vencimientos.Location = new System.Drawing.Point(12, 37);
            this.dataGridView_vencimientos.MultiSelect = false;
            this.dataGridView_vencimientos.Name = "dataGridView_vencimientos";
            this.dataGridView_vencimientos.ReadOnly = true;
            this.dataGridView_vencimientos.RowHeadersVisible = false;
            this.dataGridView_vencimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_vencimientos.Size = new System.Drawing.Size(634, 150);
            this.dataGridView_vencimientos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vencimientos de la operación: ";
            // 
            // textBox_nuevoComunero
            // 
            this.textBox_nuevoComunero.Location = new System.Drawing.Point(194, 199);
            this.textBox_nuevoComunero.Name = "textBox_nuevoComunero";
            this.textBox_nuevoComunero.ReadOnly = true;
            this.textBox_nuevoComunero.Size = new System.Drawing.Size(205, 20);
            this.textBox_nuevoComunero.TabIndex = 3;
            this.textBox_nuevoComunero.Text = "Pulsa espacio para buscar Comunero";
            this.textBox_nuevoComunero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_nuevoComunero_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nuevo Comunero: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Abonar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(488, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verMovimientosToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 48);
            // 
            // verMovimientosToolStripMenuItem
            // 
            this.verMovimientosToolStripMenuItem.Name = "verMovimientosToolStripMenuItem";
            this.verMovimientosToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.verMovimientosToolStripMenuItem.Text = "Ver movimientos";
            this.verMovimientosToolStripMenuItem.Click += new System.EventHandler(this.verMovimientosToolStripMenuItem_Click);
            // 
            // FormAbonarVencimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 235);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_nuevoComunero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_vencimientos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAbonarVencimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abonar Vencimiento";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAbonarVencimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencimientos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_vencimientos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nuevoComunero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verMovimientosToolStripMenuItem;
    }
}