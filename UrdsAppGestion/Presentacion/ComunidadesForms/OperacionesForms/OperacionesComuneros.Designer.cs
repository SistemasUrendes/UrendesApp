namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    partial class Operaciones_comuneros
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.marcarComoFavoritaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verMovimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verOperacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compensarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reasignarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarOperaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_fondo = new System.Windows.Forms.Button();
            this.abonarVencimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dataGridView_operaciones.Size = new System.Drawing.Size(1131, 455);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcarComoFavoritaToolStripMenuItem,
            this.verMovimientosToolStripMenuItem,
            this.verOperacionesToolStripMenuItem,
            this.compensarToolStripMenuItem,
            this.abonarVencimientoToolStripMenuItem,
            this.reasignarToolStripMenuItem,
            this.eliminarOperaciónToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 158);
            // 
            // marcarComoFavoritaToolStripMenuItem
            // 
            this.marcarComoFavoritaToolStripMenuItem.Enabled = false;
            this.marcarComoFavoritaToolStripMenuItem.Name = "marcarComoFavoritaToolStripMenuItem";
            this.marcarComoFavoritaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.marcarComoFavoritaToolStripMenuItem.Text = "Marcar como favorita";
            this.marcarComoFavoritaToolStripMenuItem.Click += new System.EventHandler(this.marcarComoFavoritaToolStripMenuItem_Click);
            // 
            // verMovimientosToolStripMenuItem
            // 
            this.verMovimientosToolStripMenuItem.Name = "verMovimientosToolStripMenuItem";
            this.verMovimientosToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.verMovimientosToolStripMenuItem.Text = "Ver Movimientos";
            this.verMovimientosToolStripMenuItem.Click += new System.EventHandler(this.verMovimientosToolStripMenuItem_Click);
            // 
            // verOperacionesToolStripMenuItem
            // 
            this.verOperacionesToolStripMenuItem.Name = "verOperacionesToolStripMenuItem";
            this.verOperacionesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.verOperacionesToolStripMenuItem.Text = "Ver Operaciones ";
            this.verOperacionesToolStripMenuItem.Click += new System.EventHandler(this.verOperacionesToolStripMenuItem_Click);
            // 
            // compensarToolStripMenuItem
            // 
            this.compensarToolStripMenuItem.Name = "compensarToolStripMenuItem";
            this.compensarToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.compensarToolStripMenuItem.Text = "Compensar";
            this.compensarToolStripMenuItem.Click += new System.EventHandler(this.compensarToolStripMenuItem_Click);
            // 
            // reasignarToolStripMenuItem
            // 
            this.reasignarToolStripMenuItem.Name = "reasignarToolStripMenuItem";
            this.reasignarToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reasignarToolStripMenuItem.Text = "Reasignar";
            this.reasignarToolStripMenuItem.Click += new System.EventHandler(this.reasignarToolStripMenuItem_Click);
            // 
            // eliminarOperaciónToolStripMenuItem
            // 
            this.eliminarOperaciónToolStripMenuItem.Name = "eliminarOperaciónToolStripMenuItem";
            this.eliminarOperaciónToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.eliminarOperaciónToolStripMenuItem.Text = "Eliminar Operación";
            this.eliminarOperaciónToolStripMenuItem.Click += new System.EventHandler(this.eliminarOperaciónToolStripMenuItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(956, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Provisiones : ";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Dotar",
            "Aplicar"});
            this.comboBox1.Location = new System.Drawing.Point(1023, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Pendiente",
            "Cerrado",
            "Todo"});
            this.comboBox2.Location = new System.Drawing.Point(482, 50);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(82, 21);
            this.comboBox2.TabIndex = 23;
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(414, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Estado : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(949, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 27);
            this.button1.TabIndex = 25;
            this.button1.Text = "Nuevo Recibo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button_fondo
            // 
            this.button_fondo.Location = new System.Drawing.Point(1041, 74);
            this.button_fondo.Name = "button_fondo";
            this.button_fondo.Size = new System.Drawing.Size(103, 44);
            this.button_fondo.TabIndex = 26;
            this.button_fondo.Text = "Ingreso/Abono Fondo";
            this.button_fondo.UseVisualStyleBackColor = true;
            this.button_fondo.Click += new System.EventHandler(this.button_fondo_Click);
            // 
            // abonarVencimientoToolStripMenuItem
            // 
            this.abonarVencimientoToolStripMenuItem.Name = "abonarVencimientoToolStripMenuItem";
            this.abonarVencimientoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.abonarVencimientoToolStripMenuItem.Text = "Abonar Vencimiento";
            this.abonarVencimientoToolStripMenuItem.Click += new System.EventHandler(this.abonarVencimientoToolStripMenuItem_Click);
            // 
            // Operaciones_comuneros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 591);
            this.ControlBox = false;
            this.Controls.Add(this.button_fondo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
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
            this.Name = "Operaciones_comuneros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operaciones Comuneros";
            this.Load += new System.EventHandler(this.Operaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_operaciones)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem marcarComoFavoritaToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem verOperacionesToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem compensarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verMovimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reasignarToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem eliminarOperaciónToolStripMenuItem;
        private System.Windows.Forms.Button button_fondo;
        private System.Windows.Forms.ToolStripMenuItem abonarVencimientoToolStripMenuItem;
    }
}