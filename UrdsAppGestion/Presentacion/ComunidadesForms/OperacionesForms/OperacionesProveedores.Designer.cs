namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    partial class Operaciones_proveedores
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
            this.dataGridView_operaciones = new System.Windows.Forms.DataGridView();
            this.maskedTextBox_inicio = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox_fin = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_cuenta_inicio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_cuenta_fin = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ver_operacion = new System.Windows.Forms.TextBox();
            this.button_ver_operacion = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.marcarComoFavoritaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarOperaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abonarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxFiltro = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_operaciones)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_operaciones
            // 
            this.dataGridView_operaciones.AllowUserToAddRows = false;
            this.dataGridView_operaciones.AllowUserToDeleteRows = false;
            this.dataGridView_operaciones.AllowUserToOrderColumns = true;
            this.dataGridView_operaciones.AllowUserToResizeRows = false;
            this.dataGridView_operaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_operaciones.Location = new System.Drawing.Point(13, 124);
            this.dataGridView_operaciones.Name = "dataGridView_operaciones";
            this.dataGridView_operaciones.ReadOnly = true;
            this.dataGridView_operaciones.RowHeadersVisible = false;
            this.dataGridView_operaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_operaciones.Size = new System.Drawing.Size(1087, 455);
            this.dataGridView_operaciones.TabIndex = 0;
            this.dataGridView_operaciones.DoubleClick += new System.EventHandler(this.dataGridView_operaciones_DoubleClick);
            this.dataGridView_operaciones.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_operaciones_MouseClick);
            // 
            // maskedTextBox_inicio
            // 
            this.maskedTextBox_inicio.Location = new System.Drawing.Point(103, 19);
            this.maskedTextBox_inicio.Mask = "00/00/0000";
            this.maskedTextBox_inicio.Name = "maskedTextBox_inicio";
            this.maskedTextBox_inicio.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_inicio.TabIndex = 1;
            this.maskedTextBox_inicio.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "hasta:";
            // 
            // maskedTextBox_fin
            // 
            this.maskedTextBox_fin.Location = new System.Drawing.Point(222, 19);
            this.maskedTextBox_fin.Mask = "00/00/0000";
            this.maskedTextBox_fin.Name = "maskedTextBox_fin";
            this.maskedTextBox_fin.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_fin.TabIndex = 4;
            this.maskedTextBox_fin.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cuenta:";
            // 
            // comboBox_cuenta_inicio
            // 
            this.comboBox_cuenta_inicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cuenta_inicio.FormattingEnabled = true;
            this.comboBox_cuenta_inicio.Location = new System.Drawing.Point(103, 45);
            this.comboBox_cuenta_inicio.Name = "comboBox_cuenta_inicio";
            this.comboBox_cuenta_inicio.Size = new System.Drawing.Size(71, 21);
            this.comboBox_cuenta_inicio.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "hasta:";
            // 
            // comboBox_cuenta_fin
            // 
            this.comboBox_cuenta_fin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cuenta_fin.FormattingEnabled = true;
            this.comboBox_cuenta_fin.Location = new System.Drawing.Point(222, 45);
            this.comboBox_cuenta_fin.Name = "comboBox_cuenta_fin";
            this.comboBox_cuenta_fin.Size = new System.Drawing.Size(71, 21);
            this.comboBox_cuenta_fin.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Buscar : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Operación: ";
            // 
            // textBox_ver_operacion
            // 
            this.textBox_ver_operacion.Location = new System.Drawing.Point(482, 19);
            this.textBox_ver_operacion.Name = "textBox_ver_operacion";
            this.textBox_ver_operacion.Size = new System.Drawing.Size(100, 20);
            this.textBox_ver_operacion.TabIndex = 12;
            // 
            // button_ver_operacion
            // 
            this.button_ver_operacion.Location = new System.Drawing.Point(583, 17);
            this.button_ver_operacion.Name = "button_ver_operacion";
            this.button_ver_operacion.Size = new System.Drawing.Size(36, 23);
            this.button_ver_operacion.TabIndex = 13;
            this.button_ver_operacion.Text = "Ver";
            this.button_ver_operacion.UseVisualStyleBackColor = true;
            this.button_ver_operacion.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(299, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Consultar filtro";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(299, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(106, 91);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(141, 20);
            this.textBox_buscar.TabIndex = 16;
            this.textBox_buscar.TextChanged += new System.EventHandler(this.textBox_entidad_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(361, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "___________________________________________________________";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(847, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 27);
            this.button4.TabIndex = 18;
            this.button4.Text = "Nueva";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(914, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 27);
            this.button5.TabIndex = 19;
            this.button5.Text = "Nueva Favorita";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(1026, 91);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(74, 27);
            this.button6.TabIndex = 20;
            this.button6.Text = "Favorita";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.marcarComoFavoritaToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcarComoFavoritaToolStripMenuItem,
            this.eliminarOperaciónToolStripMenuItem,
            this.abonarToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripTextBoxFiltro,
            this.toolStripSeparator2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 107);
            // 
            // marcarComoFavoritaToolStripMenuItem
            // 
            this.marcarComoFavoritaToolStripMenuItem.Name = "marcarComoFavoritaToolStripMenuItem";
            this.marcarComoFavoritaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.marcarComoFavoritaToolStripMenuItem.Text = "Marcar como favorita";
            this.marcarComoFavoritaToolStripMenuItem.Click += new System.EventHandler(this.marcarComoFavoritaToolStripMenuItem_Click);
            // 
            // eliminarOperaciónToolStripMenuItem
            // 
            this.eliminarOperaciónToolStripMenuItem.Name = "eliminarOperaciónToolStripMenuItem";
            this.eliminarOperaciónToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.eliminarOperaciónToolStripMenuItem.Text = "Eliminar Operación";
            this.eliminarOperaciónToolStripMenuItem.Click += new System.EventHandler(this.eliminarOperaciónToolStripMenuItem_Click);
            // 
            // abonarToolStripMenuItem
            // 
            this.abonarToolStripMenuItem.Name = "abonarToolStripMenuItem";
            this.abonarToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.abonarToolStripMenuItem.Text = "Abonar";
            this.abonarToolStripMenuItem.Visible = false;
            this.abonarToolStripMenuItem.Click += new System.EventHandler(this.abonarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // toolStripTextBoxFiltro
            // 
            this.toolStripTextBoxFiltro.Name = "toolStripTextBoxFiltro";
            this.toolStripTextBoxFiltro.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxFiltro_KeyPress);
            this.toolStripTextBoxFiltro.TextChanged += new System.EventHandler(this.toolStripTextBoxFiltro_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // Operaciones_proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 591);
            this.ControlBox = false;
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_ver_operacion);
            this.Controls.Add(this.textBox_ver_operacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_cuenta_fin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_cuenta_inicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskedTextBox_fin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox_inicio);
            this.Controls.Add(this.dataGridView_operaciones);
            this.Name = "Operaciones_proveedores";
            this.Text = "Operaciones Proveedores";
            this.Load += new System.EventHandler(this.Operaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_operaciones)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_operaciones;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_inicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_fin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_cuenta_inicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_cuenta_fin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ver_operacion;
        private System.Windows.Forms.Button button_ver_operacion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem marcarComoFavoritaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarOperaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abonarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFiltro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}