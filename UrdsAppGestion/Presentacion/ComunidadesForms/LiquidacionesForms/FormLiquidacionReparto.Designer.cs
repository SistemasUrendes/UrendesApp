namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms
{
    partial class FormLiquidacionReparto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLiquidacionReparto));
            this.dataGridView_reparto = new System.Windows.Forms.DataGridView();
            this.textBox_total = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_bloques = new System.Windows.Forms.TextBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView_bloques = new System.Windows.Forms.DataGridView();
            this.buttonaPdf = new System.Windows.Forms.Button();
            this.button_ver_pdf = new System.Windows.Forms.Button();
            this.button_enviarTodos = new System.Windows.Forms.Button();
            this.groupBox_liqrec = new System.Windows.Forms.GroupBox();
            this.button_imprimirNuevos = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_ver = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reparto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bloques)).BeginInit();
            this.groupBox_liqrec.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_reparto
            // 
            this.dataGridView_reparto.AllowUserToAddRows = false;
            this.dataGridView_reparto.AllowUserToDeleteRows = false;
            this.dataGridView_reparto.AllowUserToOrderColumns = true;
            this.dataGridView_reparto.AllowUserToResizeRows = false;
            this.dataGridView_reparto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_reparto.Location = new System.Drawing.Point(760, 214);
            this.dataGridView_reparto.MultiSelect = false;
            this.dataGridView_reparto.Name = "dataGridView_reparto";
            this.dataGridView_reparto.ReadOnly = true;
            this.dataGridView_reparto.RowHeadersVisible = false;
            this.dataGridView_reparto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_reparto.Size = new System.Drawing.Size(274, 129);
            this.dataGridView_reparto.TabIndex = 0;
            this.dataGridView_reparto.Visible = false;
            // 
            // textBox_total
            // 
            this.textBox_total.Enabled = false;
            this.textBox_total.Location = new System.Drawing.Point(330, 350);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.ReadOnly = true;
            this.textBox_total.Size = new System.Drawing.Size(100, 20);
            this.textBox_total.TabIndex = 2;
            this.textBox_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Particulares : ";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(18, 58);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(725, 285);
            this.dataGridView2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total Bloques : ";
            // 
            // textBox_bloques
            // 
            this.textBox_bloques.Enabled = false;
            this.textBox_bloques.Location = new System.Drawing.Point(105, 350);
            this.textBox_bloques.Name = "textBox_bloques";
            this.textBox_bloques.ReadOnly = true;
            this.textBox_bloques.Size = new System.Drawing.Size(100, 20);
            this.textBox_bloques.TabIndex = 6;
            this.textBox_bloques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(22, 21);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(109, 31);
            this.button_guardar.TabIndex = 8;
            this.button_guardar.Text = "Calcular y Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(569, 349);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(174, 23);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(647, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Registros :";
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(229, 27);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(133, 20);
            this.textBox_buscar.TabIndex = 12;
            this.textBox_buscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Buscar : ";
            // 
            // dataGridView_bloques
            // 
            this.dataGridView_bloques.AllowUserToAddRows = false;
            this.dataGridView_bloques.AllowUserToDeleteRows = false;
            this.dataGridView_bloques.AllowUserToOrderColumns = true;
            this.dataGridView_bloques.AllowUserToResizeRows = false;
            this.dataGridView_bloques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_bloques.Location = new System.Drawing.Point(760, 58);
            this.dataGridView_bloques.MultiSelect = false;
            this.dataGridView_bloques.Name = "dataGridView_bloques";
            this.dataGridView_bloques.ReadOnly = true;
            this.dataGridView_bloques.RowHeadersVisible = false;
            this.dataGridView_bloques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_bloques.Size = new System.Drawing.Size(274, 150);
            this.dataGridView_bloques.TabIndex = 14;
            // 
            // buttonaPdf
            // 
            this.buttonaPdf.Enabled = false;
            this.buttonaPdf.Location = new System.Drawing.Point(27, 29);
            this.buttonaPdf.Name = "buttonaPdf";
            this.buttonaPdf.Size = new System.Drawing.Size(92, 23);
            this.buttonaPdf.TabIndex = 16;
            this.buttonaPdf.Text = "Imprimir Todos ";
            this.buttonaPdf.UseVisualStyleBackColor = true;
            this.buttonaPdf.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button_ver_pdf
            // 
            this.button_ver_pdf.Enabled = false;
            this.button_ver_pdf.Location = new System.Drawing.Point(27, 58);
            this.button_ver_pdf.Name = "button_ver_pdf";
            this.button_ver_pdf.Size = new System.Drawing.Size(92, 23);
            this.button_ver_pdf.TabIndex = 17;
            this.button_ver_pdf.Text = "Ver Pdf";
            this.button_ver_pdf.UseVisualStyleBackColor = true;
            this.button_ver_pdf.Click += new System.EventHandler(this.button_ver_pdf_Click);
            // 
            // button_enviarTodos
            // 
            this.button_enviarTodos.Location = new System.Drawing.Point(21, 112);
            this.button_enviarTodos.Name = "button_enviarTodos";
            this.button_enviarTodos.Size = new System.Drawing.Size(110, 23);
            this.button_enviarTodos.TabIndex = 18;
            this.button_enviarTodos.Text = "Enviar";
            this.button_enviarTodos.UseVisualStyleBackColor = true;
            this.button_enviarTodos.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox_liqrec
            // 
            this.groupBox_liqrec.Controls.Add(this.button1);
            this.groupBox_liqrec.Controls.Add(this.button_imprimirNuevos);
            this.groupBox_liqrec.Controls.Add(this.button_enviarTodos);
            this.groupBox_liqrec.Location = new System.Drawing.Point(820, 231);
            this.groupBox_liqrec.Name = "groupBox_liqrec";
            this.groupBox_liqrec.Size = new System.Drawing.Size(153, 141);
            this.groupBox_liqrec.TabIndex = 20;
            this.groupBox_liqrec.TabStop = false;
            this.groupBox_liqrec.Text = "Informe Liquidación Recibo";
            this.groupBox_liqrec.Visible = false;
            // 
            // button_imprimirNuevos
            // 
            this.button_imprimirNuevos.Location = new System.Drawing.Point(19, 29);
            this.button_imprimirNuevos.Name = "button_imprimirNuevos";
            this.button_imprimirNuevos.Size = new System.Drawing.Size(110, 23);
            this.button_imprimirNuevos.TabIndex = 20;
            this.button_imprimirNuevos.Text = "Imprimir Todos";
            this.button_imprimirNuevos.UseVisualStyleBackColor = true;
            this.button_imprimirNuevos.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonaPdf);
            this.groupBox2.Controls.Add(this.button_ver_pdf);
            this.groupBox2.Location = new System.Drawing.Point(827, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 100);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informe Liquidación";
            this.groupBox2.Visible = false;
            // 
            // comboBox_ver
            // 
            this.comboBox_ver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ver.FormattingEnabled = true;
            this.comboBox_ver.Items.AddRange(new object[] {
            "Recibo Liq. ",
            "Informe Liq. IVA"});
            this.comboBox_ver.Location = new System.Drawing.Point(495, 30);
            this.comboBox_ver.Name = "comboBox_ver";
            this.comboBox_ver.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ver.TabIndex = 23;
            this.comboBox_ver.Visible = false;
            this.comboBox_ver.SelectionChangeCommitted += new System.EventHandler(this.comboBox_ver_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Ver:";
            this.label5.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Imprimir Todos IVA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_4);
            // 
            // FormLiquidacionReparto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 480);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_ver);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox_liqrec);
            this.Controls.Add(this.dataGridView_bloques);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_bloques);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_total);
            this.Controls.Add(this.dataGridView_reparto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLiquidacionReparto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidacion Reparto";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormLiquidacionReparto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reparto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bloques)).EndInit();
            this.groupBox_liqrec.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_reparto;
        private System.Windows.Forms.TextBox textBox_total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_bloques;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView_bloques;
        private System.Windows.Forms.Button buttonaPdf;
        private System.Windows.Forms.Button button_ver_pdf;
        private System.Windows.Forms.Button button_enviarTodos;
        private System.Windows.Forms.GroupBox groupBox_liqrec;
        private System.Windows.Forms.Button button_imprimirNuevos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_ver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}