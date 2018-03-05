namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms
{
    partial class FormSalidasFondos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSalidasFondos));
            this.dataGridView_salidas = new System.Windows.Forms.DataGridView();
            this.textBox_pendiente = new System.Windows.Forms.TextBox();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_salidas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_salidas
            // 
            this.dataGridView_salidas.AllowUserToAddRows = false;
            this.dataGridView_salidas.AllowUserToDeleteRows = false;
            this.dataGridView_salidas.AllowUserToResizeRows = false;
            this.dataGridView_salidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_salidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_salidas.Location = new System.Drawing.Point(12, 35);
            this.dataGridView_salidas.Name = "dataGridView_salidas";
            this.dataGridView_salidas.ReadOnly = true;
            this.dataGridView_salidas.RowHeadersVisible = false;
            this.dataGridView_salidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_salidas.Size = new System.Drawing.Size(861, 501);
            this.dataGridView_salidas.TabIndex = 0;
            this.dataGridView_salidas.DoubleClick += new System.EventHandler(this.dataGridView_salidas_DoubleClick);
            // 
            // textBox_pendiente
            // 
            this.textBox_pendiente.Location = new System.Drawing.Point(789, 542);
            this.textBox_pendiente.Name = "textBox_pendiente";
            this.textBox_pendiente.ReadOnly = true;
            this.textBox_pendiente.Size = new System.Drawing.Size(84, 20);
            this.textBox_pendiente.TabIndex = 8;
            this.textBox_pendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(604, 542);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.ReadOnly = true;
            this.textBox_importe.Size = new System.Drawing.Size(84, 20);
            this.textBox_importe.TabIndex = 7;
            this.textBox_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(698, 545);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Pendiente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(526, 545);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total Importe:";
            // 
            // FormSalidasFondos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 580);
            this.Controls.Add(this.textBox_pendiente);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_salidas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSalidasFondos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salidas Fondos";
            this.Load += new System.EventHandler(this.FormSalidasFondos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_salidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_salidas;
        private System.Windows.Forms.TextBox textBox_pendiente;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}