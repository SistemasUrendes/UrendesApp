namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms
{
    partial class FormGastosReparto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGastosReparto));
            this.dataGridView_gastos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_total = new System.Windows.Forms.TextBox();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_gastos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_gastos
            // 
            this.dataGridView_gastos.AllowUserToAddRows = false;
            this.dataGridView_gastos.AllowUserToDeleteRows = false;
            this.dataGridView_gastos.AllowUserToResizeRows = false;
            this.dataGridView_gastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_gastos.Location = new System.Drawing.Point(12, 38);
            this.dataGridView_gastos.Name = "dataGridView_gastos";
            this.dataGridView_gastos.ReadOnly = true;
            this.dataGridView_gastos.RowHeadersVisible = false;
            this.dataGridView_gastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_gastos.Size = new System.Drawing.Size(1004, 475);
            this.dataGridView_gastos.TabIndex = 2;
            this.dataGridView_gastos.DoubleClick += new System.EventHandler(this.dataGridView_gastos_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(889, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total :";
            // 
            // textBox_total
            // 
            this.textBox_total.Enabled = false;
            this.textBox_total.Location = new System.Drawing.Point(932, 524);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.ReadOnly = true;
            this.textBox_total.Size = new System.Drawing.Size(116, 20);
            this.textBox_total.TabIndex = 2;
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(67, 12);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(213, 20);
            this.textBox_buscar.TabIndex = 1;
            this.textBox_buscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buscar : ";
            // 
            // FormGastosReparto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 555);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.textBox_total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_gastos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGastosReparto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gastos Reparto";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormGastosReparto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_gastos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_gastos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_total;
        private System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.Label label2;
    }
}