namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms
{
    partial class FormEntradasFondos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEntradasFondos));
            this.dataGridView_entradas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.textBox_pendiente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_entradas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_entradas
            // 
            this.dataGridView_entradas.AllowUserToAddRows = false;
            this.dataGridView_entradas.AllowUserToDeleteRows = false;
            this.dataGridView_entradas.AllowUserToResizeRows = false;
            this.dataGridView_entradas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_entradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_entradas.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_entradas.Name = "dataGridView_entradas";
            this.dataGridView_entradas.ReadOnly = true;
            this.dataGridView_entradas.RowHeadersVisible = false;
            this.dataGridView_entradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_entradas.Size = new System.Drawing.Size(645, 516);
            this.dataGridView_entradas.TabIndex = 0;
            this.dataGridView_entradas.DoubleClick += new System.EventHandler(this.dataGridView_entradas_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 537);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Importe:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(482, 537);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Pendiente:";
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(388, 534);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.ReadOnly = true;
            this.textBox_importe.Size = new System.Drawing.Size(84, 20);
            this.textBox_importe.TabIndex = 3;
            this.textBox_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_pendiente
            // 
            this.textBox_pendiente.Location = new System.Drawing.Point(573, 534);
            this.textBox_pendiente.Name = "textBox_pendiente";
            this.textBox_pendiente.ReadOnly = true;
            this.textBox_pendiente.Size = new System.Drawing.Size(84, 20);
            this.textBox_pendiente.TabIndex = 4;
            this.textBox_pendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormEntradasFondos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 571);
            this.Controls.Add(this.textBox_pendiente);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_entradas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEntradasFondos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entradas Fondos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormEntradasFondos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_entradas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_entradas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.TextBox textBox_pendiente;
    }
}