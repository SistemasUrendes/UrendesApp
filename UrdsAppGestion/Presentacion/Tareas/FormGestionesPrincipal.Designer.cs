namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormGestionesPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestionesPrincipal));
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.maskedTextBox_FIni2 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox_FIni1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_FMax2 = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.maskedTextBox_FMax1 = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxImportante = new System.Windows.Forms.CheckBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.maskedTextBoxRefComunidad = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonEditarGestion = new System.Windows.Forms.Button();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Estado = new System.Windows.Forms.ComboBox();
            this.textBox_Entidad = new System.Windows.Forms.TextBox();
            this.comboBox_Tipo = new System.Windows.Forms.ComboBox();
            this.dataGridViewGestiones = new System.Windows.Forms.DataGridView();
            this.textBoxEnEsperaDe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSeguimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVerTarea = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxFiltro = new System.Windows.Forms.ToolStripTextBox();
            this.comboBoxResponsable = new System.Windows.Forms.ComboBox();
            this.buttonRuta = new System.Windows.Forms.Button();
            this.maskedTextBoxAplazarDias = new System.Windows.Forms.MaskedTextBox();
            this.buttonAplazar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGestiones)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Location = new System.Drawing.Point(1059, 72);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(84, 23);
            this.buttonImprimir.TabIndex = 72;
            this.buttonImprimir.Text = "Imprimir";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            this.buttonImprimir.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(853, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 70;
            this.label11.Text = "Responsable:";
            // 
            // maskedTextBox_FIni2
            // 
            this.maskedTextBox_FIni2.Location = new System.Drawing.Point(564, 73);
            this.maskedTextBox_FIni2.Mask = "00/00/0000";
            this.maskedTextBox_FIni2.Name = "maskedTextBox_FIni2";
            this.maskedTextBox_FIni2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FIni2.TabIndex = 64;
            this.maskedTextBox_FIni2.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(434, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "F. Inicio:";
            // 
            // maskedTextBox_FIni1
            // 
            this.maskedTextBox_FIni1.Location = new System.Drawing.Point(487, 73);
            this.maskedTextBox_FIni1.Mask = "00/00/0000";
            this.maskedTextBox_FIni1.Name = "maskedTextBox_FIni1";
            this.maskedTextBox_FIni1.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FIni1.TabIndex = 63;
            this.maskedTextBox_FIni1.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox_FMax2
            // 
            this.maskedTextBox_FMax2.Location = new System.Drawing.Point(768, 73);
            this.maskedTextBox_FMax2.Mask = "00/00/0000";
            this.maskedTextBox_FMax2.Name = "maskedTextBox_FMax2";
            this.maskedTextBox_FMax2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FMax2.TabIndex = 66;
            this.maskedTextBox_FMax2.ValidatingType = typeof(System.DateTime);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(641, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "F. Limite:";
            // 
            // maskedTextBox_FMax1
            // 
            this.maskedTextBox_FMax1.Location = new System.Drawing.Point(690, 73);
            this.maskedTextBox_FMax1.Mask = "00/00/0000";
            this.maskedTextBox_FMax1.Name = "maskedTextBox_FMax1";
            this.maskedTextBox_FMax1.Size = new System.Drawing.Size(72, 20);
            this.maskedTextBox_FMax1.TabIndex = 65;
            this.maskedTextBox_FMax1.ValidatingType = typeof(System.DateTime);
            // 
            // checkBoxImportante
            // 
            this.checkBoxImportante.AutoSize = true;
            this.checkBoxImportante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxImportante.Location = new System.Drawing.Point(437, 47);
            this.checkBoxImportante.Name = "checkBoxImportante";
            this.checkBoxImportante.Size = new System.Drawing.Size(79, 17);
            this.checkBoxImportante.TabIndex = 62;
            this.checkBoxImportante.Text = "&Importante:";
            this.checkBoxImportante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxImportante.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(1059, 43);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(84, 23);
            this.buttonReset.TabIndex = 61;
            this.buttonReset.Text = "Limpiar";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // maskedTextBoxRefComunidad
            // 
            this.maskedTextBoxRefComunidad.Location = new System.Drawing.Point(503, 16);
            this.maskedTextBoxRefComunidad.Mask = "999";
            this.maskedTextBoxRefComunidad.Name = "maskedTextBoxRefComunidad";
            this.maskedTextBoxRefComunidad.Size = new System.Drawing.Size(31, 20);
            this.maskedTextBoxRefComunidad.TabIndex = 48;
            this.maskedTextBoxRefComunidad.ValidatingType = typeof(int);
            this.maskedTextBoxRefComunidad.Leave += new System.EventHandler(this.maskedTextBoxRefComunidad_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Comunidad:";
            // 
            // buttonEditarGestion
            // 
            this.buttonEditarGestion.Location = new System.Drawing.Point(9, 72);
            this.buttonEditarGestion.Name = "buttonEditarGestion";
            this.buttonEditarGestion.Size = new System.Drawing.Size(75, 23);
            this.buttonEditarGestion.TabIndex = 58;
            this.buttonEditarGestion.Text = "Editar";
            this.buttonEditarGestion.UseVisualStyleBackColor = true;
            this.buttonEditarGestion.Click += new System.EventHandler(this.buttonEditarGestion_Click);
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Location = new System.Drawing.Point(1059, 14);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(84, 25);
            this.button_Filtrar.TabIndex = 57;
            this.button_Filtrar.Text = "Filtrar";
            this.button_Filtrar.UseVisualStyleBackColor = true;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(894, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "&Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(883, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Estado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(540, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Entidad:";
            // 
            // comboBox_Estado
            // 
            this.comboBox_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Estado.FormattingEnabled = true;
            this.comboBox_Estado.Location = new System.Drawing.Point(931, 44);
            this.comboBox_Estado.Name = "comboBox_Estado";
            this.comboBox_Estado.Size = new System.Drawing.Size(101, 21);
            this.comboBox_Estado.TabIndex = 56;
            // 
            // textBox_Entidad
            // 
            this.textBox_Entidad.Location = new System.Drawing.Point(586, 16);
            this.textBox_Entidad.Name = "textBox_Entidad";
            this.textBox_Entidad.Size = new System.Drawing.Size(253, 20);
            this.textBox_Entidad.TabIndex = 49;
            // 
            // comboBox_Tipo
            // 
            this.comboBox_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo.FormattingEnabled = true;
            this.comboBox_Tipo.Location = new System.Drawing.Point(931, 16);
            this.comboBox_Tipo.Name = "comboBox_Tipo";
            this.comboBox_Tipo.Size = new System.Drawing.Size(101, 21);
            this.comboBox_Tipo.TabIndex = 52;
            // 
            // dataGridViewGestiones
            // 
            this.dataGridViewGestiones.AllowUserToAddRows = false;
            this.dataGridViewGestiones.AllowUserToDeleteRows = false;
            this.dataGridViewGestiones.AllowUserToOrderColumns = true;
            this.dataGridViewGestiones.AllowUserToResizeRows = false;
            this.dataGridViewGestiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGestiones.Location = new System.Drawing.Point(9, 107);
            this.dataGridViewGestiones.Name = "dataGridViewGestiones";
            this.dataGridViewGestiones.ReadOnly = true;
            this.dataGridViewGestiones.RowHeadersVisible = false;
            this.dataGridViewGestiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGestiones.Size = new System.Drawing.Size(1134, 546);
            this.dataGridViewGestiones.TabIndex = 46;
            this.dataGridViewGestiones.TabStop = false;
            this.dataGridViewGestiones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGestiones_CellDoubleClick);
            this.dataGridViewGestiones.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewGestiones_MouseClick);
            // 
            // textBoxEnEsperaDe
            // 
            this.textBoxEnEsperaDe.Location = new System.Drawing.Point(586, 44);
            this.textBoxEnEsperaDe.Name = "textBoxEnEsperaDe";
            this.textBoxEnEsperaDe.ReadOnly = true;
            this.textBoxEnEsperaDe.Size = new System.Drawing.Size(253, 20);
            this.textBoxEnEsperaDe.TabIndex = 74;
            this.textBoxEnEsperaDe.Text = "Pulsa espacio para Seleccionar Entidad";
            this.textBoxEnEsperaDe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEnEsperaDe_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(528, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 75;
            this.label4.Text = "Espera de:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSeguimiento,
            this.toolStripMenuItemCerrar,
            this.toolStripMenuItemVerTarea,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripTextBoxFiltro});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 123);
            // 
            // toolStripMenuItemSeguimiento
            // 
            this.toolStripMenuItemSeguimiento.Name = "toolStripMenuItemSeguimiento";
            this.toolStripMenuItemSeguimiento.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemSeguimiento.Text = "Añadir Seguimiento";
            this.toolStripMenuItemSeguimiento.Click += new System.EventHandler(this.toolStripMenuItemSeguimiento_Click);
            // 
            // toolStripMenuItemCerrar
            // 
            this.toolStripMenuItemCerrar.Name = "toolStripMenuItemCerrar";
            this.toolStripMenuItemCerrar.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemCerrar.Text = "Cerrar";
            this.toolStripMenuItemCerrar.Click += new System.EventHandler(this.toolStripMenuItemCerrar_Click);
            // 
            // toolStripMenuItemVerTarea
            // 
            this.toolStripMenuItemVerTarea.Name = "toolStripMenuItemVerTarea";
            this.toolStripMenuItemVerTarea.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemVerTarea.Text = "VerTarea";
            this.toolStripMenuItemVerTarea.Click += new System.EventHandler(this.verTareaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem1.Text = "Buscar:";
            // 
            // toolStripTextBoxFiltro
            // 
            this.toolStripTextBoxFiltro.AccessibleDescription = "";
            this.toolStripTextBoxFiltro.AccessibleName = "";
            this.toolStripTextBoxFiltro.Name = "toolStripTextBoxFiltro";
            this.toolStripTextBoxFiltro.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxFiltro.Tag = "";
            this.toolStripTextBoxFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxFiltro_KeyPress);
            this.toolStripTextBoxFiltro.TextChanged += new System.EventHandler(this.toolStripTextBoxFiltro_TextChanged);
            // 
            // comboBoxResponsable
            // 
            this.comboBoxResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResponsable.FormattingEnabled = true;
            this.comboBoxResponsable.Location = new System.Drawing.Point(931, 73);
            this.comboBoxResponsable.Name = "comboBoxResponsable";
            this.comboBoxResponsable.Size = new System.Drawing.Size(101, 21);
            this.comboBoxResponsable.TabIndex = 76;
            // 
            // buttonRuta
            // 
            this.buttonRuta.Location = new System.Drawing.Point(91, 72);
            this.buttonRuta.Name = "buttonRuta";
            this.buttonRuta.Size = new System.Drawing.Size(75, 23);
            this.buttonRuta.TabIndex = 77;
            this.buttonRuta.Text = "Ruta";
            this.buttonRuta.UseVisualStyleBackColor = true;
            this.buttonRuta.Click += new System.EventHandler(this.buttonRuta_Click);
            // 
            // maskedTextBoxAplazarDias
            // 
            this.maskedTextBoxAplazarDias.Location = new System.Drawing.Point(222, 74);
            this.maskedTextBoxAplazarDias.Mask = "999";
            this.maskedTextBoxAplazarDias.Name = "maskedTextBoxAplazarDias";
            this.maskedTextBoxAplazarDias.Size = new System.Drawing.Size(23, 20);
            this.maskedTextBoxAplazarDias.TabIndex = 78;
            this.maskedTextBoxAplazarDias.Text = "3";
            // 
            // buttonAplazar
            // 
            this.buttonAplazar.Location = new System.Drawing.Point(251, 73);
            this.buttonAplazar.Name = "buttonAplazar";
            this.buttonAplazar.Size = new System.Drawing.Size(75, 23);
            this.buttonAplazar.TabIndex = 79;
            this.buttonAplazar.Text = "Aplazar";
            this.buttonAplazar.UseVisualStyleBackColor = true;
            this.buttonAplazar.Click += new System.EventHandler(this.buttonAplazar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(171, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 80;
            this.label7.Text = "Nº Días:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(6, 656);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 13);
            this.labelCount.TabIndex = 81;
            // 
            // FormGestionesPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 677);
            this.ControlBox = false;
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonAplazar);
            this.Controls.Add(this.maskedTextBoxAplazarDias);
            this.Controls.Add(this.buttonRuta);
            this.Controls.Add(this.comboBoxResponsable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxEnEsperaDe);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.maskedTextBox_FIni2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBox_FIni1);
            this.Controls.Add(this.maskedTextBox_FMax2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.maskedTextBox_FMax1);
            this.Controls.Add(this.checkBoxImportante);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.maskedTextBoxRefComunidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonEditarGestion);
            this.Controls.Add(this.button_Filtrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Estado);
            this.Controls.Add(this.textBox_Entidad);
            this.Controls.Add(this.comboBox_Tipo);
            this.Controls.Add(this.dataGridViewGestiones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGestionesPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestiones";
            this.Load += new System.EventHandler(this.FormGestionesPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGestiones)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FIni2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FIni1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FMax2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FMax1;
        private System.Windows.Forms.CheckBox checkBoxImportante;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxRefComunidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonEditarGestion;
        private System.Windows.Forms.Button button_Filtrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Estado;
        private System.Windows.Forms.TextBox textBox_Entidad;
        private System.Windows.Forms.ComboBox comboBox_Tipo;
        private System.Windows.Forms.DataGridView dataGridViewGestiones;
        private System.Windows.Forms.TextBox textBoxEnEsperaDe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVerTarea;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFiltro;
        private System.Windows.Forms.ComboBox comboBoxResponsable;
        private System.Windows.Forms.Button buttonRuta;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAplazarDias;
        private System.Windows.Forms.Button buttonAplazar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSeguimiento;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCerrar;
        private System.Windows.Forms.Label labelCount;
    }
}