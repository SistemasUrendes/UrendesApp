namespace UrdsAppGestión.Presentacion.ComunidadesForms.RemesasForms
{
    partial class FormDetalleRemesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetalleRemesa));
            this.dataGridView_detalles_remesa = new System.Windows.Forms.DataGridView();
            this.button_anyadir_recibos = new System.Windows.Forms.Button();
            this.buttonQuitarRecibos = new System.Windows.Forms.Button();
            this.buttonLanzar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_total = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detalles_remesa)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_detalles_remesa
            // 
            this.dataGridView_detalles_remesa.AllowUserToAddRows = false;
            this.dataGridView_detalles_remesa.AllowUserToDeleteRows = false;
            this.dataGridView_detalles_remesa.AllowUserToOrderColumns = true;
            this.dataGridView_detalles_remesa.AllowUserToResizeRows = false;
            this.dataGridView_detalles_remesa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_detalles_remesa.Location = new System.Drawing.Point(12, 60);
            this.dataGridView_detalles_remesa.Name = "dataGridView_detalles_remesa";
            this.dataGridView_detalles_remesa.ReadOnly = true;
            this.dataGridView_detalles_remesa.RowHeadersVisible = false;
            this.dataGridView_detalles_remesa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_detalles_remesa.Size = new System.Drawing.Size(1135, 520);
            this.dataGridView_detalles_remesa.TabIndex = 0;
            // 
            // button_anyadir_recibos
            // 
            this.button_anyadir_recibos.Location = new System.Drawing.Point(871, 31);
            this.button_anyadir_recibos.Name = "button_anyadir_recibos";
            this.button_anyadir_recibos.Size = new System.Drawing.Size(100, 23);
            this.button_anyadir_recibos.TabIndex = 1;
            this.button_anyadir_recibos.Text = "Añadir Recibos";
            this.button_anyadir_recibos.UseVisualStyleBackColor = true;
            this.button_anyadir_recibos.Click += new System.EventHandler(this.button_anyadir_recibos_Click);
            // 
            // buttonQuitarRecibos
            // 
            this.buttonQuitarRecibos.Location = new System.Drawing.Point(977, 31);
            this.buttonQuitarRecibos.Name = "buttonQuitarRecibos";
            this.buttonQuitarRecibos.Size = new System.Drawing.Size(89, 23);
            this.buttonQuitarRecibos.TabIndex = 2;
            this.buttonQuitarRecibos.Text = "Quitar Recibos";
            this.buttonQuitarRecibos.UseVisualStyleBackColor = true;
            this.buttonQuitarRecibos.Click += new System.EventHandler(this.buttonQuitarRecibos_Click);
            // 
            // buttonLanzar
            // 
            this.buttonLanzar.Location = new System.Drawing.Point(1072, 31);
            this.buttonLanzar.Name = "buttonLanzar";
            this.buttonLanzar.Size = new System.Drawing.Size(75, 23);
            this.buttonLanzar.TabIndex = 3;
            this.buttonLanzar.Text = "Lanzar";
            this.buttonLanzar.UseVisualStyleBackColor = true;
            this.buttonLanzar.Click += new System.EventHandler(this.buttonLanzar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(953, 590);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Remesa : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_total
            // 
            this.textBox_total.Location = new System.Drawing.Point(1035, 586);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.Size = new System.Drawing.Size(112, 20);
            this.textBox_total.TabIndex = 5;
            this.textBox_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_total.TextChanged += new System.EventHandler(this.textBox_total_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(842, 586);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Enviar a Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormDetalleRemesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 620);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLanzar);
            this.Controls.Add(this.buttonQuitarRecibos);
            this.Controls.Add(this.button_anyadir_recibos);
            this.Controls.Add(this.dataGridView_detalles_remesa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDetalleRemesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles Remesas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormDetalleRemesa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detalles_remesa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_detalles_remesa;
        private System.Windows.Forms.Button button_anyadir_recibos;
        private System.Windows.Forms.Button buttonQuitarRecibos;
        private System.Windows.Forms.Button buttonLanzar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_total;
        private System.Windows.Forms.Button button1;
    }
}