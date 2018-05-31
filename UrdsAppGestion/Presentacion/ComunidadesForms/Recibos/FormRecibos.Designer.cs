namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    partial class FormRecibos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecibos));
            this.dataGridView_recibos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox_fin = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBox_inicio = new System.Windows.Forms.MaskedTextBox();
            this.textBox_buscarComunero = new System.Windows.Forms.TextBox();
            this.textBox_recibos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_estado = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label_num = new System.Windows.Forms.Label();
            this.buttonVerRecibo = new System.Windows.Forms.Button();
            this.buttonImprimirRecibo = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_impriendo = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button_enviar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_recibos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_recibos
            // 
            this.dataGridView_recibos.AllowUserToAddRows = false;
            this.dataGridView_recibos.AllowUserToDeleteRows = false;
            this.dataGridView_recibos.AllowUserToOrderColumns = true;
            this.dataGridView_recibos.AllowUserToResizeRows = false;
            this.dataGridView_recibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_recibos.Location = new System.Drawing.Point(12, 110);
            this.dataGridView_recibos.Name = "dataGridView_recibos";
            this.dataGridView_recibos.ReadOnly = true;
            this.dataGridView_recibos.RowHeadersVisible = false;
            this.dataGridView_recibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_recibos.Size = new System.Drawing.Size(1081, 484);
            this.dataGridView_recibos.TabIndex = 0;
            this.dataGridView_recibos.DataSourceChanged += new System.EventHandler(this.dataGridView_recibos_DataSourceChanged);
            this.dataGridView_recibos.DoubleClick += new System.EventHandler(this.dataGridView_recibos_DoubleClick);
            this.dataGridView_recibos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_recibos_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comunero : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(409, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Recibo : ";
            // 
            // maskedTextBox_fin
            // 
            this.maskedTextBox_fin.Location = new System.Drawing.Point(217, 18);
            this.maskedTextBox_fin.Mask = "00/00/0000";
            this.maskedTextBox_fin.Name = "maskedTextBox_fin";
            this.maskedTextBox_fin.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_fin.TabIndex = 8;
            this.maskedTextBox_fin.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "hasta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha desde:";
            // 
            // maskedTextBox_inicio
            // 
            this.maskedTextBox_inicio.Location = new System.Drawing.Point(90, 18);
            this.maskedTextBox_inicio.Mask = "00/00/0000";
            this.maskedTextBox_inicio.Name = "maskedTextBox_inicio";
            this.maskedTextBox_inicio.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_inicio.TabIndex = 5;
            this.maskedTextBox_inicio.ValidatingType = typeof(System.DateTime);
            // 
            // textBox_buscarComunero
            // 
            this.textBox_buscarComunero.Location = new System.Drawing.Point(90, 48);
            this.textBox_buscarComunero.Name = "textBox_buscarComunero";
            this.textBox_buscarComunero.Size = new System.Drawing.Size(198, 20);
            this.textBox_buscarComunero.TabIndex = 9;
            // 
            // textBox_recibos
            // 
            this.textBox_recibos.Location = new System.Drawing.Point(465, 17);
            this.textBox_recibos.Name = "textBox_recibos";
            this.textBox_recibos.Size = new System.Drawing.Size(71, 20);
            this.textBox_recibos.TabIndex = 10;
            this.textBox_recibos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_recibos_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Estado :";
            // 
            // comboBox_estado
            // 
            this.comboBox_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_estado.FormattingEnabled = true;
            this.comboBox_estado.Items.AddRange(new object[] {
            "Pendientes",
            "Cerrados",
            "Todos"});
            this.comboBox_estado.Location = new System.Drawing.Point(90, 78);
            this.comboBox_estado.Name = "comboBox_estado";
            this.comboBox_estado.Size = new System.Drawing.Size(84, 21);
            this.comboBox_estado.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 38);
            this.button1.TabIndex = 13;
            this.button1.Text = "Filtrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 35);
            this.button2.TabIndex = 14;
            this.button2.Text = "Quitar Filtro";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(995, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Crear Recibo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label_num
            // 
            this.label_num.AutoSize = true;
            this.label_num.Location = new System.Drawing.Point(12, 597);
            this.label_num.Name = "label_num";
            this.label_num.Size = new System.Drawing.Size(106, 13);
            this.label_num.TabIndex = 16;
            this.label_num.Text = "Número de Registros";
            // 
            // buttonVerRecibo
            // 
            this.buttonVerRecibo.Location = new System.Drawing.Point(441, 81);
            this.buttonVerRecibo.Name = "buttonVerRecibo";
            this.buttonVerRecibo.Size = new System.Drawing.Size(127, 23);
            this.buttonVerRecibo.TabIndex = 17;
            this.buttonVerRecibo.Text = "Ver Recibo PDF";
            this.buttonVerRecibo.UseVisualStyleBackColor = true;
            this.buttonVerRecibo.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonImprimirRecibo
            // 
            this.buttonImprimirRecibo.Location = new System.Drawing.Point(574, 81);
            this.buttonImprimirRecibo.Name = "buttonImprimirRecibo";
            this.buttonImprimirRecibo.Size = new System.Drawing.Size(127, 23);
            this.buttonImprimirRecibo.TabIndex = 18;
            this.buttonImprimirRecibo.Text = "Imprimir Varios";
            this.buttonImprimirRecibo.UseVisualStyleBackColor = true;
            this.buttonImprimirRecibo.Click += new System.EventHandler(this.button5_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(925, 597);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(168, 23);
            this.progressBar1.TabIndex = 19;
            this.progressBar1.Visible = false;
            // 
            // label_impriendo
            // 
            this.label_impriendo.AutoSize = true;
            this.label_impriendo.Location = new System.Drawing.Point(980, 602);
            this.label_impriendo.Name = "label_impriendo";
            this.label_impriendo.Size = new System.Drawing.Size(63, 13);
            this.label_impriendo.TabIndex = 20;
            this.label_impriendo.Text = "Imprimiendo";
            this.label_impriendo.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button_enviar
            // 
            this.button_enviar.Location = new System.Drawing.Point(707, 81);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(127, 23);
            this.button_enviar.TabIndex = 21;
            this.button_enviar.Text = "Enviar Varios";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // FormRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 625);
            this.ControlBox = false;
            this.Controls.Add(this.button_enviar);
            this.Controls.Add(this.label_impriendo);
            this.Controls.Add(this.buttonImprimirRecibo);
            this.Controls.Add(this.buttonVerRecibo);
            this.Controls.Add(this.label_num);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_estado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_recibos);
            this.Controls.Add(this.textBox_buscarComunero);
            this.Controls.Add(this.maskedTextBox_fin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maskedTextBox_inicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_recibos);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRecibos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibos";
            this.Load += new System.EventHandler(this.FormRecibos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_recibos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_recibos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_fin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_inicio;
        private System.Windows.Forms.TextBox textBox_buscarComunero;
        private System.Windows.Forms.TextBox textBox_recibos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_estado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label_num;
        private System.Windows.Forms.Button buttonVerRecibo;
        private System.Windows.Forms.Button buttonImprimirRecibo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_impriendo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button_enviar;
    }
}