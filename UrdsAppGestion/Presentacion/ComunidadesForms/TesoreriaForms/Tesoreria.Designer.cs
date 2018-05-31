namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    partial class Tesoreria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tesoreria));
            this.dataGridView_tesoreria = new System.Windows.Forms.DataGridView();
            this.comboBox_ejercicio = new System.Windows.Forms.ComboBox();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_idmov = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_fechacierre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_e_comuneros = new System.Windows.Forms.ComboBox();
            this.comboBox_e_proveedor = new System.Windows.Forms.ComboBox();
            this.comboBox_e_otras = new System.Windows.Forms.ComboBox();
            this.comboBox_s_otras = new System.Windows.Forms.ComboBox();
            this.comboBox_s_proveedor = new System.Windows.Forms.ComboBox();
            this.comboBox_s_comuneros = new System.Windows.Forms.ComboBox();
            this.button_mostrarSecuencia = new System.Windows.Forms.Button();
            this.button_banco = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verVencimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrar0MovimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarMovimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_abrir_comuneros = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.progressBar_op = new System.Windows.Forms.ProgressBar();
            this.label_borrado = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tesoreria)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_tesoreria
            // 
            this.dataGridView_tesoreria.AllowUserToAddRows = false;
            this.dataGridView_tesoreria.AllowUserToDeleteRows = false;
            this.dataGridView_tesoreria.AllowUserToOrderColumns = true;
            this.dataGridView_tesoreria.AllowUserToResizeRows = false;
            this.dataGridView_tesoreria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tesoreria.Location = new System.Drawing.Point(31, 126);
            this.dataGridView_tesoreria.Name = "dataGridView_tesoreria";
            this.dataGridView_tesoreria.ReadOnly = true;
            this.dataGridView_tesoreria.RowHeadersVisible = false;
            this.dataGridView_tesoreria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_tesoreria.Size = new System.Drawing.Size(1087, 460);
            this.dataGridView_tesoreria.TabIndex = 0;
            this.dataGridView_tesoreria.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_tesoreria_MouseClick);
            // 
            // comboBox_ejercicio
            // 
            this.comboBox_ejercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ejercicio.FormattingEnabled = true;
            this.comboBox_ejercicio.Location = new System.Drawing.Point(94, 20);
            this.comboBox_ejercicio.Name = "comboBox_ejercicio";
            this.comboBox_ejercicio.Size = new System.Drawing.Size(94, 21);
            this.comboBox_ejercicio.TabIndex = 1;
            this.comboBox_ejercicio.SelectionChangeCommitted += new System.EventHandler(this.comboBox_ejercicio_SelectionChangeCommitted);
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(94, 56);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(175, 20);
            this.textBox_buscar.TabIndex = 2;
            this.textBox_buscar.TextChanged += new System.EventHandler(this.textBox_entidad_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ejercicio :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buscar :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "IdMov :";
            // 
            // textBox_idmov
            // 
            this.textBox_idmov.Location = new System.Drawing.Point(94, 92);
            this.textBox_idmov.Name = "textBox_idmov";
            this.textBox_idmov.Size = new System.Drawing.Size(67, 20);
            this.textBox_idmov.TabIndex = 5;
            this.textBox_idmov.TextChanged += new System.EventHandler(this.textBox_detalles_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cerrada :";
            // 
            // textBox_fechacierre
            // 
            this.textBox_fechacierre.Enabled = false;
            this.textBox_fechacierre.Location = new System.Drawing.Point(299, 20);
            this.textBox_fechacierre.Name = "textBox_fechacierre";
            this.textBox_fechacierre.ReadOnly = true;
            this.textBox_fechacierre.Size = new System.Drawing.Size(80, 20);
            this.textBox_fechacierre.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "NUEVA ENTRADA :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(802, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "NUEVA SALIDA :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(495, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Comuneros : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Proveedores : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(495, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Otras : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(802, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Otras : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(802, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Proveedores : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(802, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Comuneros : ";
            // 
            // comboBox_e_comuneros
            // 
            this.comboBox_e_comuneros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_e_comuneros.FormattingEnabled = true;
            this.comboBox_e_comuneros.Items.AddRange(new object[] {
            "Ingreso",
            "Ingreso Remesa"});
            this.comboBox_e_comuneros.Location = new System.Drawing.Point(571, 38);
            this.comboBox_e_comuneros.Name = "comboBox_e_comuneros";
            this.comboBox_e_comuneros.Size = new System.Drawing.Size(148, 21);
            this.comboBox_e_comuneros.TabIndex = 17;
            this.comboBox_e_comuneros.SelectionChangeCommitted += new System.EventHandler(this.comboBox_e_comuneros_SelectionChangeCommitted);
            // 
            // comboBox_e_proveedor
            // 
            this.comboBox_e_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_e_proveedor.FormattingEnabled = true;
            this.comboBox_e_proveedor.Items.AddRange(new object[] {
            "Entrada a Proveedor"});
            this.comboBox_e_proveedor.Location = new System.Drawing.Point(571, 63);
            this.comboBox_e_proveedor.Name = "comboBox_e_proveedor";
            this.comboBox_e_proveedor.Size = new System.Drawing.Size(148, 21);
            this.comboBox_e_proveedor.TabIndex = 18;
            this.comboBox_e_proveedor.SelectionChangeCommitted += new System.EventHandler(this.comboBox_e_proveedor_SelectionChangeCommitted);
            // 
            // comboBox_e_otras
            // 
            this.comboBox_e_otras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_e_otras.FormattingEnabled = true;
            this.comboBox_e_otras.Items.AddRange(new object[] {
            "Traspaso de Entrada",
            "Asiento de Apertura",
            "Otras Entradas"});
            this.comboBox_e_otras.Location = new System.Drawing.Point(571, 88);
            this.comboBox_e_otras.Name = "comboBox_e_otras";
            this.comboBox_e_otras.Size = new System.Drawing.Size(148, 21);
            this.comboBox_e_otras.TabIndex = 19;
            this.comboBox_e_otras.SelectedIndexChanged += new System.EventHandler(this.comboBox_e_otras_SelectedIndexChanged);
            // 
            // comboBox_s_otras
            // 
            this.comboBox_s_otras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_s_otras.FormattingEnabled = true;
            this.comboBox_s_otras.Items.AddRange(new object[] {
            "Traspaso Salida",
            "Otras Salidas",
            "Devolución Abono Remesa"});
            this.comboBox_s_otras.Location = new System.Drawing.Point(877, 88);
            this.comboBox_s_otras.Name = "comboBox_s_otras";
            this.comboBox_s_otras.Size = new System.Drawing.Size(157, 21);
            this.comboBox_s_otras.TabIndex = 22;
            this.comboBox_s_otras.SelectionChangeCommitted += new System.EventHandler(this.comboBox_s_otras_SelectionChangeCommitted);
            // 
            // comboBox_s_proveedor
            // 
            this.comboBox_s_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_s_proveedor.FormattingEnabled = true;
            this.comboBox_s_proveedor.Items.AddRange(new object[] {
            "Pago",
            "Salida a Proveedor",
            "Remesa de Pago"});
            this.comboBox_s_proveedor.Location = new System.Drawing.Point(877, 63);
            this.comboBox_s_proveedor.Name = "comboBox_s_proveedor";
            this.comboBox_s_proveedor.Size = new System.Drawing.Size(157, 21);
            this.comboBox_s_proveedor.TabIndex = 21;
            this.comboBox_s_proveedor.SelectionChangeCommitted += new System.EventHandler(this.comboBox_s_proveedor_SelectionChangeCommitted);
            // 
            // comboBox_s_comuneros
            // 
            this.comboBox_s_comuneros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_s_comuneros.FormattingEnabled = true;
            this.comboBox_s_comuneros.Items.AddRange(new object[] {
            "Salida a Comunero",
            "Remesa de Abono",
            "Devolución Ingreso"});
            this.comboBox_s_comuneros.Location = new System.Drawing.Point(877, 38);
            this.comboBox_s_comuneros.Name = "comboBox_s_comuneros";
            this.comboBox_s_comuneros.Size = new System.Drawing.Size(157, 21);
            this.comboBox_s_comuneros.TabIndex = 20;
            this.comboBox_s_comuneros.SelectionChangeCommitted += new System.EventHandler(this.comboBox_s_comuneros_SelectionChangeCommitted);
            // 
            // button_mostrarSecuencia
            // 
            this.button_mostrarSecuencia.Location = new System.Drawing.Point(1102, 105);
            this.button_mostrarSecuencia.Name = "button_mostrarSecuencia";
            this.button_mostrarSecuencia.Size = new System.Drawing.Size(16, 15);
            this.button_mostrarSecuencia.TabIndex = 23;
            this.button_mostrarSecuencia.UseVisualStyleBackColor = true;
            this.button_mostrarSecuencia.Click += new System.EventHandler(this.button_mostrarSecuencia_Click);
            // 
            // button_banco
            // 
            this.button_banco.Location = new System.Drawing.Point(1091, 76);
            this.button_banco.Name = "button_banco";
            this.button_banco.Size = new System.Drawing.Size(27, 23);
            this.button_banco.TabIndex = 24;
            this.button_banco.Text = "Anotar Banco";
            this.button_banco.UseVisualStyleBackColor = true;
            this.button_banco.Visible = false;
            this.button_banco.Click += new System.EventHandler(this.button_banco_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verVencimientosToolStripMenuItem,
            this.borrar0MovimientosToolStripMenuItem,
            this.borrarMovimientoToolStripMenuItem,
            this.buscarFechaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 92);
            // 
            // verVencimientosToolStripMenuItem
            // 
            this.verVencimientosToolStripMenuItem.Name = "verVencimientosToolStripMenuItem";
            this.verVencimientosToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.verVencimientosToolStripMenuItem.Text = "Ver Vencimientos";
            this.verVencimientosToolStripMenuItem.Click += new System.EventHandler(this.verVencimientosToolStripMenuItem_Click);
            // 
            // borrar0MovimientosToolStripMenuItem
            // 
            this.borrar0MovimientosToolStripMenuItem.Name = "borrar0MovimientosToolStripMenuItem";
            this.borrar0MovimientosToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.borrar0MovimientosToolStripMenuItem.Text = "Borrar 0 Movimientos";
            this.borrar0MovimientosToolStripMenuItem.Visible = false;
            this.borrar0MovimientosToolStripMenuItem.Click += new System.EventHandler(this.borrar0MovimientosToolStripMenuItem_Click);
            // 
            // borrarMovimientoToolStripMenuItem
            // 
            this.borrarMovimientoToolStripMenuItem.Name = "borrarMovimientoToolStripMenuItem";
            this.borrarMovimientoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.borrarMovimientoToolStripMenuItem.Text = "Borrar Movimiento";
            this.borrarMovimientoToolStripMenuItem.Visible = false;
            this.borrarMovimientoToolStripMenuItem.Click += new System.EventHandler(this.borrarMovimientoToolStripMenuItem_Click);
            // 
            // buscarFechaToolStripMenuItem
            // 
            this.buscarFechaToolStripMenuItem.Name = "buscarFechaToolStripMenuItem";
            this.buscarFechaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.buscarFechaToolStripMenuItem.Text = "Buscar fecha = ";
            this.buscarFechaToolStripMenuItem.Visible = false;
            this.buscarFechaToolStripMenuItem.Click += new System.EventHandler(this.buscarFechaToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 592);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Quitar Filtro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(385, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Abrir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_abrir_comuneros
            // 
            this.button_abrir_comuneros.Location = new System.Drawing.Point(723, 37);
            this.button_abrir_comuneros.Name = "button_abrir_comuneros";
            this.button_abrir_comuneros.Size = new System.Drawing.Size(23, 23);
            this.button_abrir_comuneros.TabIndex = 27;
            this.button_abrir_comuneros.UseVisualStyleBackColor = true;
            this.button_abrir_comuneros.Click += new System.EventHandler(this.comboBox_e_comuneros_SelectionChangeCommitted);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(723, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 28;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.comboBox_e_proveedor_SelectionChangeCommitted);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(723, 87);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(23, 23);
            this.button4.TabIndex = 29;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.comboBox_e_otras_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1040, 37);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(23, 23);
            this.button5.TabIndex = 30;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.comboBox_s_comuneros_SelectionChangeCommitted);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1040, 61);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(23, 23);
            this.button6.TabIndex = 31;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.comboBox_s_proveedor_SelectionChangeCommitted);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1040, 86);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(23, 23);
            this.button7.TabIndex = 32;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.comboBox_s_otras_SelectionChangeCommitted);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(112, 592);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(97, 23);
            this.button8.TabIndex = 33;
            this.button8.Text = "Cambiar Cuenta";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // progressBar_op
            // 
            this.progressBar_op.Location = new System.Drawing.Point(934, 591);
            this.progressBar_op.Name = "progressBar_op";
            this.progressBar_op.Size = new System.Drawing.Size(184, 23);
            this.progressBar_op.TabIndex = 34;
            this.progressBar_op.Visible = false;
            // 
            // label_borrado
            // 
            this.label_borrado.AutoSize = true;
            this.label_borrado.BackColor = System.Drawing.Color.Transparent;
            this.label_borrado.Location = new System.Drawing.Point(974, 596);
            this.label_borrado.Name = "label_borrado";
            this.label_borrado.Size = new System.Drawing.Size(107, 13);
            this.label_borrado.TabIndex = 35;
            this.label_borrado.Text = "Borrando Movimiento";
            this.label_borrado.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(215, 597);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "label13";
            // 
            // Tesoreria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 617);
            this.ControlBox = false;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label_borrado);
            this.Controls.Add(this.progressBar_op);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_abrir_comuneros);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_banco);
            this.Controls.Add(this.button_mostrarSecuencia);
            this.Controls.Add(this.comboBox_s_otras);
            this.Controls.Add(this.comboBox_s_proveedor);
            this.Controls.Add(this.comboBox_s_comuneros);
            this.Controls.Add(this.comboBox_e_otras);
            this.Controls.Add(this.comboBox_e_proveedor);
            this.Controls.Add(this.comboBox_e_comuneros);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_fechacierre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_idmov);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.comboBox_ejercicio);
            this.Controls.Add(this.dataGridView_tesoreria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tesoreria";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tesoreria";
            this.Load += new System.EventHandler(this.Tesoreria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tesoreria)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_tesoreria;
        private System.Windows.Forms.ComboBox comboBox_ejercicio;
        private System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_idmov;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_fechacierre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_e_comuneros;
        private System.Windows.Forms.ComboBox comboBox_e_proveedor;
        private System.Windows.Forms.ComboBox comboBox_e_otras;
        private System.Windows.Forms.ComboBox comboBox_s_otras;
        private System.Windows.Forms.ComboBox comboBox_s_proveedor;
        private System.Windows.Forms.ComboBox comboBox_s_comuneros;
        private System.Windows.Forms.Button button_mostrarSecuencia;
        private System.Windows.Forms.Button button_banco;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verVencimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarMovimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarFechaToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_abrir_comuneros;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ToolStripMenuItem borrar0MovimientosToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar_op;
        private System.Windows.Forms.Label label_borrado;
        private System.Windows.Forms.Label label13;
    }
}