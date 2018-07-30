namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    partial class Comuneros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comuneros));
            this.dataGridView_comuneros = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_operaciones = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_Activo = new System.Windows.Forms.CheckBox();
            this.checkBox_papel = new System.Windows.Forms.CheckBox();
            this.checkBox_IVA = new System.Windows.Forms.CheckBox();
            this.checkBox_EMail = new System.Windows.Forms.CheckBox();
            this.textBox_Comunero = new System.Windows.Forms.TextBox();
            this.textBox_Direccion = new System.Windows.Forms.TextBox();
            this.textBox_FPago = new System.Windows.Forms.TextBox();
            this.textBox_EMail = new System.Windows.Forms.TextBox();
            this.textBox_Divppal = new System.Windows.Forms.TextBox();
            this.textBox_NumCuenta = new System.Windows.Forms.TextBox();
            this.textBox_Notas = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verEntidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reglasRecibosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acuerdosCobroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.textBox_copiaEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_comuneros)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_comuneros
            // 
            this.dataGridView_comuneros.AllowUserToAddRows = false;
            this.dataGridView_comuneros.AllowUserToDeleteRows = false;
            this.dataGridView_comuneros.AllowUserToResizeRows = false;
            this.dataGridView_comuneros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_comuneros.Location = new System.Drawing.Point(32, 96);
            this.dataGridView_comuneros.MultiSelect = false;
            this.dataGridView_comuneros.Name = "dataGridView_comuneros";
            this.dataGridView_comuneros.ReadOnly = true;
            this.dataGridView_comuneros.RowHeadersVisible = false;
            this.dataGridView_comuneros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_comuneros.Size = new System.Drawing.Size(794, 259);
            this.dataGridView_comuneros.TabIndex = 0;
            this.dataGridView_comuneros.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_comuneros_RowEnter);
            this.dataGridView_comuneros.Click += new System.EventHandler(this.dataGridView_comuneros_Click);
            this.dataGridView_comuneros.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_comuneros_KeyDown);
            this.dataGridView_comuneros.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_comuneros_MouseClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(194, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Borrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Editar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Añadir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboBox_operaciones
            // 
            this.comboBox_operaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_operaciones.FormattingEnabled = true;
            this.comboBox_operaciones.Items.AddRange(new object[] {
            "Anticipos",
            "Movimientos",
            "Vencimientos",
            "Recibos"});
            this.comboBox_operaciones.Location = new System.Drawing.Point(432, 22);
            this.comboBox_operaciones.Name = "comboBox_operaciones";
            this.comboBox_operaciones.Size = new System.Drawing.Size(156, 21);
            this.comboBox_operaciones.TabIndex = 5;
            this.comboBox_operaciones.SelectionChangeCommitted += new System.EventHandler(this.comboBox_operaciones_SelectionChangeCommitted);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Informe de deudas",
            "Confirmación de datos",
            "Informe Recibos",
            "Divisiones con Asociaciones"});
            this.comboBox2.Location = new System.Drawing.Point(670, 23);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(156, 21);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(370, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Operativa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(614, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Informes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Comunero: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Dirección: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 448);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Forma de Pago: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 503);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Notas: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(505, 418);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Div. Principal: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 478);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "E-Mail: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(505, 448);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Nº. de Cuenta: ";
            // 
            // checkBox_Activo
            // 
            this.checkBox_Activo.AutoSize = true;
            this.checkBox_Activo.Enabled = false;
            this.checkBox_Activo.Location = new System.Drawing.Point(767, 389);
            this.checkBox_Activo.Name = "checkBox_Activo";
            this.checkBox_Activo.Size = new System.Drawing.Size(56, 17);
            this.checkBox_Activo.TabIndex = 20;
            this.checkBox_Activo.Text = "Activo";
            this.checkBox_Activo.UseVisualStyleBackColor = true;
            // 
            // checkBox_papel
            // 
            this.checkBox_papel.AutoSize = true;
            this.checkBox_papel.Enabled = false;
            this.checkBox_papel.Location = new System.Drawing.Point(508, 389);
            this.checkBox_papel.Name = "checkBox_papel";
            this.checkBox_papel.Size = new System.Drawing.Size(53, 17);
            this.checkBox_papel.TabIndex = 21;
            this.checkBox_papel.Text = "Papel";
            this.checkBox_papel.UseVisualStyleBackColor = true;
            // 
            // checkBox_IVA
            // 
            this.checkBox_IVA.AutoSize = true;
            this.checkBox_IVA.Enabled = false;
            this.checkBox_IVA.Location = new System.Drawing.Point(718, 389);
            this.checkBox_IVA.Name = "checkBox_IVA";
            this.checkBox_IVA.Size = new System.Drawing.Size(43, 17);
            this.checkBox_IVA.TabIndex = 22;
            this.checkBox_IVA.Text = "IVA";
            this.checkBox_IVA.UseVisualStyleBackColor = true;
            // 
            // checkBox_EMail
            // 
            this.checkBox_EMail.AutoSize = true;
            this.checkBox_EMail.Enabled = false;
            this.checkBox_EMail.Location = new System.Drawing.Point(567, 389);
            this.checkBox_EMail.Name = "checkBox_EMail";
            this.checkBox_EMail.Size = new System.Drawing.Size(55, 17);
            this.checkBox_EMail.TabIndex = 23;
            this.checkBox_EMail.Text = "E-Mail";
            this.checkBox_EMail.UseVisualStyleBackColor = true;
            // 
            // textBox_Comunero
            // 
            this.textBox_Comunero.Location = new System.Drawing.Point(149, 387);
            this.textBox_Comunero.Name = "textBox_Comunero";
            this.textBox_Comunero.ReadOnly = true;
            this.textBox_Comunero.Size = new System.Drawing.Size(296, 20);
            this.textBox_Comunero.TabIndex = 24;
            // 
            // textBox_Direccion
            // 
            this.textBox_Direccion.Location = new System.Drawing.Point(149, 416);
            this.textBox_Direccion.Name = "textBox_Direccion";
            this.textBox_Direccion.ReadOnly = true;
            this.textBox_Direccion.Size = new System.Drawing.Size(296, 20);
            this.textBox_Direccion.TabIndex = 25;
            // 
            // textBox_FPago
            // 
            this.textBox_FPago.Location = new System.Drawing.Point(149, 445);
            this.textBox_FPago.Name = "textBox_FPago";
            this.textBox_FPago.ReadOnly = true;
            this.textBox_FPago.Size = new System.Drawing.Size(296, 20);
            this.textBox_FPago.TabIndex = 26;
            // 
            // textBox_EMail
            // 
            this.textBox_EMail.Location = new System.Drawing.Point(149, 474);
            this.textBox_EMail.Name = "textBox_EMail";
            this.textBox_EMail.ReadOnly = true;
            this.textBox_EMail.Size = new System.Drawing.Size(296, 20);
            this.textBox_EMail.TabIndex = 27;
            // 
            // textBox_Divppal
            // 
            this.textBox_Divppal.Location = new System.Drawing.Point(586, 416);
            this.textBox_Divppal.Name = "textBox_Divppal";
            this.textBox_Divppal.ReadOnly = true;
            this.textBox_Divppal.Size = new System.Drawing.Size(240, 20);
            this.textBox_Divppal.TabIndex = 28;
            // 
            // textBox_NumCuenta
            // 
            this.textBox_NumCuenta.Location = new System.Drawing.Point(586, 445);
            this.textBox_NumCuenta.Name = "textBox_NumCuenta";
            this.textBox_NumCuenta.ReadOnly = true;
            this.textBox_NumCuenta.Size = new System.Drawing.Size(240, 20);
            this.textBox_NumCuenta.TabIndex = 29;
            // 
            // textBox_Notas
            // 
            this.textBox_Notas.Location = new System.Drawing.Point(149, 503);
            this.textBox_Notas.Multiline = true;
            this.textBox_Notas.Name = "textBox_Notas";
            this.textBox_Notas.ReadOnly = true;
            this.textBox_Notas.Size = new System.Drawing.Size(677, 69);
            this.textBox_Notas.TabIndex = 30;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verEntidadToolStripMenuItem,
            this.toolStripMenuItem1,
            this.reglasRecibosToolStripMenuItem,
            this.acuerdosCobroToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 92);
            // 
            // verEntidadToolStripMenuItem
            // 
            this.verEntidadToolStripMenuItem.Name = "verEntidadToolStripMenuItem";
            this.verEntidadToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.verEntidadToolStripMenuItem.Text = "Ver Entidad";
            this.verEntidadToolStripMenuItem.Click += new System.EventHandler(this.verEntidadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem1.Text = "Asociaciones";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // reglasRecibosToolStripMenuItem
            // 
            this.reglasRecibosToolStripMenuItem.Name = "reglasRecibosToolStripMenuItem";
            this.reglasRecibosToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.reglasRecibosToolStripMenuItem.Text = "Reglas Recibos";
            this.reglasRecibosToolStripMenuItem.Click += new System.EventHandler(this.reglasRecibosToolStripMenuItem_Click);
            // 
            // acuerdosCobroToolStripMenuItem
            // 
            this.acuerdosCobroToolStripMenuItem.Enabled = false;
            this.acuerdosCobroToolStripMenuItem.Name = "acuerdosCobroToolStripMenuItem";
            this.acuerdosCobroToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.acuerdosCobroToolStripMenuItem.Text = "Acuerdos Cobro";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(670, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 23);
            this.button4.TabIndex = 31;
            this.button4.Text = "Enviar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Buscar : ";
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(87, 72);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(182, 20);
            this.textBox_buscar.TabIndex = 33;
            this.textBox_buscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_comuneros_KeyDown);
            // 
            // textBox_copiaEmail
            // 
            this.textBox_copiaEmail.Location = new System.Drawing.Point(586, 475);
            this.textBox_copiaEmail.Name = "textBox_copiaEmail";
            this.textBox_copiaEmail.ReadOnly = true;
            this.textBox_copiaEmail.Size = new System.Drawing.Size(240, 20);
            this.textBox_copiaEmail.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(505, 478);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Copia E-Mail: ";
            // 
            // Comuneros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 587);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_copiaEmail);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox_Notas);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_NumCuenta);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_Divppal);
            this.Controls.Add(this.textBox_EMail);
            this.Controls.Add(this.textBox_FPago);
            this.Controls.Add(this.textBox_Direccion);
            this.Controls.Add(this.textBox_Comunero);
            this.Controls.Add(this.checkBox_EMail);
            this.Controls.Add(this.checkBox_IVA);
            this.Controls.Add(this.checkBox_papel);
            this.Controls.Add(this.checkBox_Activo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox_operaciones);
            this.Controls.Add(this.dataGridView_comuneros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Comuneros";
            this.Text = "Comuneros";
            this.Load += new System.EventHandler(this.Comuneros_Load);
            this.Shown += new System.EventHandler(this.Comuneros_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_comuneros_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_comuneros)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_operaciones;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_Activo;
        private System.Windows.Forms.CheckBox checkBox_papel;
        private System.Windows.Forms.CheckBox checkBox_IVA;
        private System.Windows.Forms.CheckBox checkBox_EMail;
        private System.Windows.Forms.TextBox textBox_Comunero;
        private System.Windows.Forms.TextBox textBox_Direccion;
        private System.Windows.Forms.TextBox textBox_FPago;
        private System.Windows.Forms.TextBox textBox_EMail;
        private System.Windows.Forms.TextBox textBox_Divppal;
        private System.Windows.Forms.TextBox textBox_NumCuenta;
        private System.Windows.Forms.TextBox textBox_Notas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reglasRecibosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acuerdosCobroToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.ToolStripMenuItem verEntidadToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridView_comuneros;
        private System.Windows.Forms.TextBox textBox_copiaEmail;
        private System.Windows.Forms.Label label11;
    }
}