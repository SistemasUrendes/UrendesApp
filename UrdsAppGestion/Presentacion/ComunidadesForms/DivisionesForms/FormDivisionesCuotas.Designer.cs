namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    partial class FormDivisionesCuotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDivisionesCuotas));
            this.dataGridView_operacionesComuneros = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_estado = new System.Windows.Forms.ComboBox();
            this.maskedTextBox_fin = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBox_inicio = new System.Windows.Forms.MaskedTextBox();
            this.button_filtrar = new System.Windows.Forms.Button();
            this.button_certificar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirOperacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reasignarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reasignarOperaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarFechaCertificaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidarFondoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.label_registros = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_certificado = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxestado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_filtrofecha = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_operacionesComuneros)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_operacionesComuneros
            // 
            this.dataGridView_operacionesComuneros.AllowUserToAddRows = false;
            this.dataGridView_operacionesComuneros.AllowUserToDeleteRows = false;
            this.dataGridView_operacionesComuneros.AllowUserToResizeRows = false;
            this.dataGridView_operacionesComuneros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_operacionesComuneros.Location = new System.Drawing.Point(12, 107);
            this.dataGridView_operacionesComuneros.Name = "dataGridView_operacionesComuneros";
            this.dataGridView_operacionesComuneros.ReadOnly = true;
            this.dataGridView_operacionesComuneros.RowHeadersVisible = false;
            this.dataGridView_operacionesComuneros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_operacionesComuneros.Size = new System.Drawing.Size(1194, 421);
            this.dataGridView_operacionesComuneros.TabIndex = 0;
            this.dataGridView_operacionesComuneros.DoubleClick += new System.EventHandler(this.dataGridView_operacionesComuneros_DoubleClick);
            this.dataGridView_operacionesComuneros.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_operacionesComuneros_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estado Imp : ";
            // 
            // comboBox_estado
            // 
            this.comboBox_estado.FormattingEnabled = true;
            this.comboBox_estado.Items.AddRange(new object[] {
            "Pendiente",
            "Cerrado",
            "Todo"});
            this.comboBox_estado.Location = new System.Drawing.Point(89, 44);
            this.comboBox_estado.Name = "comboBox_estado";
            this.comboBox_estado.Size = new System.Drawing.Size(71, 21);
            this.comboBox_estado.TabIndex = 2;
            // 
            // maskedTextBox_fin
            // 
            this.maskedTextBox_fin.Location = new System.Drawing.Point(208, 16);
            this.maskedTextBox_fin.Mask = "00/00/0000";
            this.maskedTextBox_fin.Name = "maskedTextBox_fin";
            this.maskedTextBox_fin.Size = new System.Drawing.Size(77, 20);
            this.maskedTextBox_fin.TabIndex = 18;
            this.maskedTextBox_fin.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Fecha desde:";
            // 
            // maskedTextBox_inicio
            // 
            this.maskedTextBox_inicio.Location = new System.Drawing.Point(89, 17);
            this.maskedTextBox_inicio.Mask = "00/00/0000";
            this.maskedTextBox_inicio.Name = "maskedTextBox_inicio";
            this.maskedTextBox_inicio.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_inicio.TabIndex = 15;
            this.maskedTextBox_inicio.ValidatingType = typeof(System.DateTime);
            // 
            // button_filtrar
            // 
            this.button_filtrar.Location = new System.Drawing.Point(433, 12);
            this.button_filtrar.Name = "button_filtrar";
            this.button_filtrar.Size = new System.Drawing.Size(74, 79);
            this.button_filtrar.TabIndex = 19;
            this.button_filtrar.Text = "Filtrar";
            this.button_filtrar.UseVisualStyleBackColor = true;
            this.button_filtrar.Click += new System.EventHandler(this.button_filtrar_Click);
            // 
            // button_certificar
            // 
            this.button_certificar.Location = new System.Drawing.Point(1005, 78);
            this.button_certificar.Name = "button_certificar";
            this.button_certificar.Size = new System.Drawing.Size(100, 23);
            this.button_certificar.TabIndex = 20;
            this.button_certificar.Text = "Cambiar Estado";
            this.button_certificar.UseVisualStyleBackColor = true;
            this.button_certificar.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirOperacionToolStripMenuItem,
            this.reasignarToolStripMenuItem,
            this.reasignarOperaciónToolStripMenuItem,
            this.borrarFechaCertificaciónToolStripMenuItem,
            this.liquidarFondoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 136);
            // 
            // abrirOperacionToolStripMenuItem
            // 
            this.abrirOperacionToolStripMenuItem.Name = "abrirOperacionToolStripMenuItem";
            this.abrirOperacionToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.abrirOperacionToolStripMenuItem.Text = "Abrir Operacion";
            this.abrirOperacionToolStripMenuItem.Click += new System.EventHandler(this.abrirOperacionToolStripMenuItem_Click);
            // 
            // reasignarToolStripMenuItem
            // 
            this.reasignarToolStripMenuItem.Name = "reasignarToolStripMenuItem";
            this.reasignarToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.reasignarToolStripMenuItem.Text = "Asignar a División";
            this.reasignarToolStripMenuItem.Click += new System.EventHandler(this.reasignarToolStripMenuItem_Click);
            // 
            // reasignarOperaciónToolStripMenuItem
            // 
            this.reasignarOperaciónToolStripMenuItem.Name = "reasignarOperaciónToolStripMenuItem";
            this.reasignarOperaciónToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.reasignarOperaciónToolStripMenuItem.Text = "Reasignar Titular";
            this.reasignarOperaciónToolStripMenuItem.Click += new System.EventHandler(this.reasignarOperaciónToolStripMenuItem_Click);
            // 
            // borrarFechaCertificaciónToolStripMenuItem
            // 
            this.borrarFechaCertificaciónToolStripMenuItem.Name = "borrarFechaCertificaciónToolStripMenuItem";
            this.borrarFechaCertificaciónToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.borrarFechaCertificaciónToolStripMenuItem.Text = "Borrar Fecha Certificación";
            this.borrarFechaCertificaciónToolStripMenuItem.Click += new System.EventHandler(this.borrarFechaCertificaciónToolStripMenuItem_Click);
            // 
            // liquidarFondoToolStripMenuItem
            // 
            this.liquidarFondoToolStripMenuItem.Name = "liquidarFondoToolStripMenuItem";
            this.liquidarFondoToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.liquidarFondoToolStripMenuItem.Text = "Liquidar Fondo";
            this.liquidarFondoToolStripMenuItem.Click += new System.EventHandler(this.liquidarFondoToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Buscar :";
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(89, 71);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(121, 20);
            this.textBox_buscar.TabIndex = 22;
            // 
            // label_registros
            // 
            this.label_registros.AutoSize = true;
            this.label_registros.Location = new System.Drawing.Point(826, 83);
            this.label_registros.Name = "label_registros";
            this.label_registros.Size = new System.Drawing.Size(35, 13);
            this.label_registros.TabIndex = 24;
            this.label_registros.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Certificación :";
            // 
            // comboBox_certificado
            // 
            this.comboBox_certificado.FormattingEnabled = true;
            this.comboBox_certificado.Items.AddRange(new object[] {
            "Certificadas",
            "No Certificadas",
            "Todas"});
            this.comboBox_certificado.Location = new System.Drawing.Point(243, 43);
            this.comboBox_certificado.Name = "comboBox_certificado";
            this.comboBox_certificado.Size = new System.Drawing.Size(153, 21);
            this.comboBox_certificado.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1111, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Certificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboBoxestado
            // 
            this.comboBoxestado.FormattingEnabled = true;
            this.comboBoxestado.Items.AddRange(new object[] {
            "Certificadas",
            "No Certificadas"});
            this.comboBoxestado.Location = new System.Drawing.Point(282, 71);
            this.comboBoxestado.Name = "comboBoxestado";
            this.comboBoxestado.Size = new System.Drawing.Size(114, 21);
            this.comboBoxestado.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Estado :";
            // 
            // comboBox_filtrofecha
            // 
            this.comboBox_filtrofecha.FormattingEnabled = true;
            this.comboBox_filtrofecha.Items.AddRange(new object[] {
            "Operaciones",
            "Certificados"});
            this.comboBox_filtrofecha.Location = new System.Drawing.Point(291, 15);
            this.comboBox_filtrofecha.Name = "comboBox_filtrofecha";
            this.comboBox_filtrofecha.Size = new System.Drawing.Size(105, 21);
            this.comboBox_filtrofecha.TabIndex = 30;
            // 
            // FormDivisionesCuotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 540);
            this.Controls.Add(this.comboBox_filtrofecha);
            this.Controls.Add(this.comboBoxestado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_certificado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_registros);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_certificar);
            this.Controls.Add(this.button_filtrar);
            this.Controls.Add(this.maskedTextBox_fin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskedTextBox_inicio);
            this.Controls.Add(this.comboBox_estado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_operacionesComuneros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDivisionesCuotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuotas Divisiones";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormOperacionesComuneros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_operacionesComuneros)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_estado;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_fin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_inicio;
        private System.Windows.Forms.Button button_filtrar;
        private System.Windows.Forms.Button button_certificar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reasignarToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.Label label_registros;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_certificado;
        public System.Windows.Forms.DataGridView dataGridView_operacionesComuneros;
        private System.Windows.Forms.ToolStripMenuItem abrirOperacionToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxestado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem reasignarOperaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarFechaCertificaciónToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox_filtrofecha;
        private System.Windows.Forms.ToolStripMenuItem liquidarFondoToolStripMenuItem;
    }
}