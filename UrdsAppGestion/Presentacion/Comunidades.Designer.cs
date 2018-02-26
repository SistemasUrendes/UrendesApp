namespace UrdsAppGestión.Presentacion
{
    partial class Comunidades
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
            this.dataGridView_comunidades = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_contabilidad = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_estado = new System.Windows.Forms.ComboBox();
            this.textBox_referencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_gestor = new System.Windows.Forms.ComboBox();
            this.comboBox_administrador = new System.Windows.Forms.ComboBox();
            this.textBox_poblacion = new System.Windows.Forms.TextBox();
            this.textBox_nombre_corto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarNIFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_comunidades)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_comunidades
            // 
            this.dataGridView_comunidades.AllowUserToAddRows = false;
            this.dataGridView_comunidades.AllowUserToDeleteRows = false;
            this.dataGridView_comunidades.AllowUserToResizeRows = false;
            this.dataGridView_comunidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_comunidades.Location = new System.Drawing.Point(12, 118);
            this.dataGridView_comunidades.MultiSelect = false;
            this.dataGridView_comunidades.Name = "dataGridView_comunidades";
            this.dataGridView_comunidades.ReadOnly = true;
            this.dataGridView_comunidades.RowHeadersVisible = false;
            this.dataGridView_comunidades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_comunidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_comunidades.Size = new System.Drawing.Size(1244, 516);
            this.dataGridView_comunidades.TabIndex = 0;
            this.dataGridView_comunidades.DoubleClick += new System.EventHandler(this.dataGridView_comunidades_DoubleClick);
            this.dataGridView_comunidades.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_comunidades_MouseClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Borrar Comunidad";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Editar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Añadir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_contabilidad);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox_estado);
            this.groupBox2.Controls.Add(this.textBox_referencia);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBox_gestor);
            this.groupBox2.Controls.Add(this.comboBox_administrador);
            this.groupBox2.Controls.Add(this.textBox_poblacion);
            this.groupBox2.Controls.Add(this.textBox_nombre_corto);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(680, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // comboBox_contabilidad
            // 
            this.comboBox_contabilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_contabilidad.FormattingEnabled = true;
            this.comboBox_contabilidad.Location = new System.Drawing.Point(363, 69);
            this.comboBox_contabilidad.Name = "comboBox_contabilidad";
            this.comboBox_contabilidad.Size = new System.Drawing.Size(151, 21);
            this.comboBox_contabilidad.TabIndex = 18;
            this.comboBox_contabilidad.SelectionChangeCommitted += new System.EventHandler(this.comboBox_contabilidad_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Contabilidad : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Estado:";
            // 
            // comboBox_estado
            // 
            this.comboBox_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_estado.FormattingEnabled = true;
            this.comboBox_estado.Items.AddRange(new object[] {
            "Alta",
            "Baja",
            "Todas"});
            this.comboBox_estado.Location = new System.Drawing.Point(90, 66);
            this.comboBox_estado.Name = "comboBox_estado";
            this.comboBox_estado.Size = new System.Drawing.Size(83, 21);
            this.comboBox_estado.TabIndex = 15;
            this.comboBox_estado.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // textBox_referencia
            // 
            this.textBox_referencia.Location = new System.Drawing.Point(206, 66);
            this.textBox_referencia.Name = "textBox_referencia";
            this.textBox_referencia.Size = new System.Drawing.Size(49, 20);
            this.textBox_referencia.TabIndex = 13;
            this.textBox_referencia.TextChanged += new System.EventHandler(this.textBox_referencia_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ref: ";
            // 
            // comboBox_gestor
            // 
            this.comboBox_gestor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_gestor.FormattingEnabled = true;
            this.comboBox_gestor.Location = new System.Drawing.Point(363, 44);
            this.comboBox_gestor.Name = "comboBox_gestor";
            this.comboBox_gestor.Size = new System.Drawing.Size(151, 21);
            this.comboBox_gestor.TabIndex = 11;
            this.comboBox_gestor.SelectionChangeCommitted += new System.EventHandler(this.comboBox_gestor_SelectionChangeCommitted);
            // 
            // comboBox_administrador
            // 
            this.comboBox_administrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_administrador.FormattingEnabled = true;
            this.comboBox_administrador.Location = new System.Drawing.Point(363, 19);
            this.comboBox_administrador.Name = "comboBox_administrador";
            this.comboBox_administrador.Size = new System.Drawing.Size(151, 21);
            this.comboBox_administrador.TabIndex = 10;
            this.comboBox_administrador.SelectionChangeCommitted += new System.EventHandler(this.comboBox_administrador_SelectedValueChanged);
            // 
            // textBox_poblacion
            // 
            this.textBox_poblacion.Location = new System.Drawing.Point(90, 41);
            this.textBox_poblacion.Name = "textBox_poblacion";
            this.textBox_poblacion.Size = new System.Drawing.Size(165, 20);
            this.textBox_poblacion.TabIndex = 9;
            this.textBox_poblacion.TextChanged += new System.EventHandler(this.textBox_poblacion_TextChanged);
            // 
            // textBox_nombre_corto
            // 
            this.textBox_nombre_corto.Location = new System.Drawing.Point(90, 16);
            this.textBox_nombre_corto.Name = "textBox_nombre_corto";
            this.textBox_nombre_corto.Size = new System.Drawing.Size(165, 20);
            this.textBox_nombre_corto.TabIndex = 7;
            this.textBox_nombre_corto.TextChanged += new System.EventHandler(this.textBox_nombre_corto_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Gestor : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Administrador : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Población: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Corto: ";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1209, 89);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "Reset";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.entidadToolStripMenuItem,
            this.rutaToolStripMenuItem,
            this.fichaToolStripMenuItem,
            this.copiarNIFToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 136);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // entidadToolStripMenuItem
            // 
            this.entidadToolStripMenuItem.Name = "entidadToolStripMenuItem";
            this.entidadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.entidadToolStripMenuItem.Text = "Entidad";
            this.entidadToolStripMenuItem.Click += new System.EventHandler(this.entidadToolStripMenuItem_Click);
            // 
            // rutaToolStripMenuItem
            // 
            this.rutaToolStripMenuItem.Name = "rutaToolStripMenuItem";
            this.rutaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rutaToolStripMenuItem.Text = "Ruta";
            this.rutaToolStripMenuItem.Click += new System.EventHandler(this.rutaToolStripMenuItem_Click);
            // 
            // fichaToolStripMenuItem
            // 
            this.fichaToolStripMenuItem.Name = "fichaToolStripMenuItem";
            this.fichaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fichaToolStripMenuItem.Text = "Ficha";
            this.fichaToolStripMenuItem.Click += new System.EventHandler(this.fichaToolStripMenuItem_Click);
            // 
            // copiarNIFToolStripMenuItem
            // 
            this.copiarNIFToolStripMenuItem.Name = "copiarNIFToolStripMenuItem";
            this.copiarNIFToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copiarNIFToolStripMenuItem.Text = "Copiar NIF";
            this.copiarNIFToolStripMenuItem.Click += new System.EventHandler(this.copiarNIFToolStripMenuItem_Click);
            // 
            // Comunidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 646);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_comunidades);
            this.Name = "Comunidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comunidades";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Comunidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_comunidades)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_comunidades;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_gestor;
        private System.Windows.Forms.ComboBox comboBox_administrador;
        private System.Windows.Forms.TextBox textBox_poblacion;
        private System.Windows.Forms.TextBox textBox_nombre_corto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox_referencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rutaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichaToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_estado;
        private System.Windows.Forms.ComboBox comboBox_contabilidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem copiarNIFToolStripMenuItem;
    }
}