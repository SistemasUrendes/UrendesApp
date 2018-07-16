namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    partial class Divisiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Divisiones));
            this.dataGridView_divisiones = new System.Windows.Forms.DataGridView();
            this.dataGridView_detalles_divisiones = new System.Windows.Forms.DataGridView();
            this.button_Borrar = new System.Windows.Forms.Button();
            this.button_Editar = new System.Windows.Forms.Button();
            this.button_Añadir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Filtro = new System.Windows.Forms.ComboBox();
            this.textBox_Division = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.certificadoDeDeudasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.filtroAvanzadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_addasociacion = new System.Windows.Forms.Button();
            this.button_borrarasociacion = new System.Windows.Forms.Button();
            this.button_editaasociacion = new System.Windows.Forms.Button();
            this.button_num_representantes = new System.Windows.Forms.Button();
            this.button_enviar = new System.Windows.Forms.Button();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verEntidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_informes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_divisiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detalles_divisiones)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_divisiones
            // 
            this.dataGridView_divisiones.AllowUserToAddRows = false;
            this.dataGridView_divisiones.AllowUserToDeleteRows = false;
            this.dataGridView_divisiones.AllowUserToOrderColumns = true;
            this.dataGridView_divisiones.AllowUserToResizeRows = false;
            this.dataGridView_divisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_divisiones.Location = new System.Drawing.Point(40, 85);
            this.dataGridView_divisiones.MultiSelect = false;
            this.dataGridView_divisiones.Name = "dataGridView_divisiones";
            this.dataGridView_divisiones.ReadOnly = true;
            this.dataGridView_divisiones.RowHeadersVisible = false;
            this.dataGridView_divisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_divisiones.Size = new System.Drawing.Size(755, 352);
            this.dataGridView_divisiones.TabIndex = 0;
            this.dataGridView_divisiones.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_divisiones_RowEnter);
            this.dataGridView_divisiones.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView_divisiones_RowPostPaint);
            this.dataGridView_divisiones.Click += new System.EventHandler(this.dataGridView_divisiones_Click);
            this.dataGridView_divisiones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView_divisiones_KeyPress);
            this.dataGridView_divisiones.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_divisiones_MouseClick);
            // 
            // dataGridView_detalles_divisiones
            // 
            this.dataGridView_detalles_divisiones.AllowUserToAddRows = false;
            this.dataGridView_detalles_divisiones.AllowUserToDeleteRows = false;
            this.dataGridView_detalles_divisiones.AllowUserToOrderColumns = true;
            this.dataGridView_detalles_divisiones.AllowUserToResizeRows = false;
            this.dataGridView_detalles_divisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_detalles_divisiones.Location = new System.Drawing.Point(39, 499);
            this.dataGridView_detalles_divisiones.Name = "dataGridView_detalles_divisiones";
            this.dataGridView_detalles_divisiones.ReadOnly = true;
            this.dataGridView_detalles_divisiones.RowHeadersVisible = false;
            this.dataGridView_detalles_divisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_detalles_divisiones.Size = new System.Drawing.Size(755, 105);
            this.dataGridView_detalles_divisiones.TabIndex = 1;
            this.dataGridView_detalles_divisiones.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_detalles_divisiones_MouseClick);
            // 
            // button_Borrar
            // 
            this.button_Borrar.Location = new System.Drawing.Point(202, 30);
            this.button_Borrar.Name = "button_Borrar";
            this.button_Borrar.Size = new System.Drawing.Size(75, 23);
            this.button_Borrar.TabIndex = 8;
            this.button_Borrar.Text = "Borrar";
            this.button_Borrar.UseVisualStyleBackColor = true;
            this.button_Borrar.Click += new System.EventHandler(this.button_Borrar_Click);
            // 
            // button_Editar
            // 
            this.button_Editar.Location = new System.Drawing.Point(121, 30);
            this.button_Editar.Name = "button_Editar";
            this.button_Editar.Size = new System.Drawing.Size(75, 23);
            this.button_Editar.TabIndex = 7;
            this.button_Editar.Text = "Editar";
            this.button_Editar.UseVisualStyleBackColor = true;
            this.button_Editar.Click += new System.EventHandler(this.button_Editar_Click);
            // 
            // button_Añadir
            // 
            this.button_Añadir.Location = new System.Drawing.Point(40, 30);
            this.button_Añadir.Name = "button_Añadir";
            this.button_Añadir.Size = new System.Drawing.Size(75, 23);
            this.button_Añadir.TabIndex = 6;
            this.button_Añadir.Text = "Añadir";
            this.button_Añadir.UseVisualStyleBackColor = true;
            this.button_Añadir.Click += new System.EventHandler(this.button_Añadir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(560, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filtro:";
            // 
            // comboBox_Filtro
            // 
            this.comboBox_Filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Filtro.FormattingEnabled = true;
            this.comboBox_Filtro.Items.AddRange(new object[] {
            "Ver Todas",
            "Con Reglas"});
            this.comboBox_Filtro.Location = new System.Drawing.Point(598, 55);
            this.comboBox_Filtro.Name = "comboBox_Filtro";
            this.comboBox_Filtro.Size = new System.Drawing.Size(89, 21);
            this.comboBox_Filtro.TabIndex = 13;
            this.comboBox_Filtro.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Filtro_SelectionChangeCommitted);
            // 
            // textBox_Division
            // 
            this.textBox_Division.Location = new System.Drawing.Point(248, 473);
            this.textBox_Division.Name = "textBox_Division";
            this.textBox_Division.Size = new System.Drawing.Size(285, 20);
            this.textBox_Division.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Asociaciones para División Seleccionada:";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reToolStripMenuItem,
            this.cuotasToolStripMenuItem,
            this.certificadoDeDeudasToolStripMenuItem1,
            this.toolStripSeparator1,
            this.toolStripTextBox2,
            this.filtroAvanzadoToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(191, 123);
            // 
            // reToolStripMenuItem
            // 
            this.reToolStripMenuItem.Name = "reToolStripMenuItem";
            this.reToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.reToolStripMenuItem.Text = "Reglas de Pago";
            this.reToolStripMenuItem.Click += new System.EventHandler(this.reToolStripMenuItem_Click);
            // 
            // cuotasToolStripMenuItem
            // 
            this.cuotasToolStripMenuItem.Name = "cuotasToolStripMenuItem";
            this.cuotasToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.cuotasToolStripMenuItem.Text = "Cuotas Pendientes";
            this.cuotasToolStripMenuItem.Click += new System.EventHandler(this.cuotasToolStripMenuItem_Click);
            // 
            // certificadoDeDeudasToolStripMenuItem1
            // 
            this.certificadoDeDeudasToolStripMenuItem1.Name = "certificadoDeDeudasToolStripMenuItem1";
            this.certificadoDeDeudasToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.certificadoDeDeudasToolStripMenuItem1.Text = "Certificado de Deudas";
            this.certificadoDeDeudasToolStripMenuItem1.Click += new System.EventHandler(this.certificadoDeDeudasToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(110, 23);
            this.toolStripTextBox2.TextChanged += new System.EventHandler(this.toolStripTextBox2_TextChanged);
            // 
            // filtroAvanzadoToolStripMenuItem
            // 
            this.filtroAvanzadoToolStripMenuItem.Name = "filtroAvanzadoToolStripMenuItem";
            this.filtroAvanzadoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.filtroAvanzadoToolStripMenuItem.Text = "Filtro Avanzado";
            this.filtroAvanzadoToolStripMenuItem.Visible = false;
            this.filtroAvanzadoToolStripMenuItem.Click += new System.EventHandler(this.filtroAvanzadoToolStripMenuItem_Click);
            // 
            // button_addasociacion
            // 
            this.button_addasociacion.Location = new System.Drawing.Point(557, 470);
            this.button_addasociacion.Name = "button_addasociacion";
            this.button_addasociacion.Size = new System.Drawing.Size(75, 23);
            this.button_addasociacion.TabIndex = 17;
            this.button_addasociacion.Text = "Añadir";
            this.button_addasociacion.UseVisualStyleBackColor = true;
            this.button_addasociacion.Click += new System.EventHandler(this.button_addasociacion_Click);
            // 
            // button_borrarasociacion
            // 
            this.button_borrarasociacion.Location = new System.Drawing.Point(719, 470);
            this.button_borrarasociacion.Name = "button_borrarasociacion";
            this.button_borrarasociacion.Size = new System.Drawing.Size(75, 23);
            this.button_borrarasociacion.TabIndex = 18;
            this.button_borrarasociacion.Text = "Borrar";
            this.button_borrarasociacion.UseVisualStyleBackColor = true;
            this.button_borrarasociacion.Click += new System.EventHandler(this.button_borrarasociacion_Click);
            // 
            // button_editaasociacion
            // 
            this.button_editaasociacion.Location = new System.Drawing.Point(638, 470);
            this.button_editaasociacion.Name = "button_editaasociacion";
            this.button_editaasociacion.Size = new System.Drawing.Size(75, 23);
            this.button_editaasociacion.TabIndex = 19;
            this.button_editaasociacion.Text = "Editar";
            this.button_editaasociacion.UseVisualStyleBackColor = true;
            this.button_editaasociacion.Click += new System.EventHandler(this.button_editaasociacion_Click);
            // 
            // button_num_representantes
            // 
            this.button_num_representantes.Location = new System.Drawing.Point(693, 53);
            this.button_num_representantes.Name = "button_num_representantes";
            this.button_num_representantes.Size = new System.Drawing.Size(102, 25);
            this.button_num_representantes.TabIndex = 22;
            this.button_num_representantes.Text = "Comprobar Rep. ";
            this.button_num_representantes.UseVisualStyleBackColor = true;
            this.button_num_representantes.Click += new System.EventHandler(this.button_num_representantes_Click);
            // 
            // button_enviar
            // 
            this.button_enviar.Location = new System.Drawing.Point(368, 54);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(114, 23);
            this.button_enviar.TabIndex = 23;
            this.button_enviar.Text = "Enviar";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Visible = false;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(97, 59);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(170, 20);
            this.textBox_buscar.TabIndex = 24;
            this.textBox_buscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Buscar : ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verEntidadToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 26);
            // 
            // verEntidadToolStripMenuItem
            // 
            this.verEntidadToolStripMenuItem.Name = "verEntidadToolStripMenuItem";
            this.verEntidadToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.verEntidadToolStripMenuItem.Text = "Ver Entidad";
            this.verEntidadToolStripMenuItem.Click += new System.EventHandler(this.verEntidadToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Total : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(544, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Informes :";
            // 
            // comboBox_informes
            // 
            this.comboBox_informes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_informes.FormattingEnabled = true;
            this.comboBox_informes.Items.AddRange(new object[] {
            "Cuotas Emitidas",
            "Bloques Junta"});
            this.comboBox_informes.Location = new System.Drawing.Point(598, 26);
            this.comboBox_informes.Name = "comboBox_informes";
            this.comboBox_informes.Size = new System.Drawing.Size(196, 21);
            this.comboBox_informes.TabIndex = 28;
            this.comboBox_informes.SelectionChangeCommitted += new System.EventHandler(this.comboBox_informes_SelectionChangeCommitted);
            // 
            // Divisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 619);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox_informes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.button_enviar);
            this.Controls.Add(this.button_num_representantes);
            this.Controls.Add(this.button_editaasociacion);
            this.Controls.Add(this.button_borrarasociacion);
            this.Controls.Add(this.button_addasociacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Division);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Filtro);
            this.Controls.Add(this.button_Borrar);
            this.Controls.Add(this.button_Editar);
            this.Controls.Add(this.button_Añadir);
            this.Controls.Add(this.dataGridView_detalles_divisiones);
            this.Controls.Add(this.dataGridView_divisiones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Divisiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Divisiones";
            this.Load += new System.EventHandler(this.FormDivisiones_Load);
            this.Shown += new System.EventHandler(this.Divisiones_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_divisiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detalles_divisiones)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_detalles_divisiones;
        private System.Windows.Forms.Button button_Borrar;
        private System.Windows.Forms.Button button_Editar;
        private System.Windows.Forms.Button button_Añadir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Filtro;
        private System.Windows.Forms.TextBox textBox_Division;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem reToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem certificadoDeDeudasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripMenuItem filtroAvanzadoToolStripMenuItem;
        private System.Windows.Forms.Button button_addasociacion;
        private System.Windows.Forms.Button button_borrarasociacion;
        private System.Windows.Forms.Button button_editaasociacion;
        private System.Windows.Forms.Button button_num_representantes;
        private System.Windows.Forms.Button button_enviar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verEntidadToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridView_divisiones;
        public System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_informes;
    }
}