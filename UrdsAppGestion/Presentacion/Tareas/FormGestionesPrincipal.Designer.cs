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
            this.buttonBloque = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxBloque = new System.Windows.Forms.TextBox();
            this.maskedTextBox_FAgenda2 = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.maskedTextBox_FAgenda1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_FFin2 = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.maskedTextBox_FFin1 = new System.Windows.Forms.MaskedTextBox();
            this.textBox_Entidad = new System.Windows.Forms.TextBox();
            this.buttonDivisión = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxDivisión = new System.Windows.Forms.TextBox();
            this.buttonServicio = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxServicio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGestiones)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Location = new System.Drawing.Point(1056, 119);
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
            this.label11.Location = new System.Drawing.Point(847, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 70;
            this.label11.Text = "Responsable:";
            // 
            // maskedTextBox_FIni2
            // 
            this.maskedTextBox_FIni2.Location = new System.Drawing.Point(569, 91);
            this.maskedTextBox_FIni2.Mask = "00/00/0000";
            this.maskedTextBox_FIni2.Name = "maskedTextBox_FIni2";
            this.maskedTextBox_FIni2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FIni2.TabIndex = 64;
            this.maskedTextBox_FIni2.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(439, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "F. Inicio:";
            // 
            // maskedTextBox_FIni1
            // 
            this.maskedTextBox_FIni1.Location = new System.Drawing.Point(492, 91);
            this.maskedTextBox_FIni1.Mask = "00/00/0000";
            this.maskedTextBox_FIni1.Name = "maskedTextBox_FIni1";
            this.maskedTextBox_FIni1.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FIni1.TabIndex = 63;
            this.maskedTextBox_FIni1.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox_FMax2
            // 
            this.maskedTextBox_FMax2.Location = new System.Drawing.Point(773, 91);
            this.maskedTextBox_FMax2.Mask = "00/00/0000";
            this.maskedTextBox_FMax2.Name = "maskedTextBox_FMax2";
            this.maskedTextBox_FMax2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FMax2.TabIndex = 66;
            this.maskedTextBox_FMax2.ValidatingType = typeof(System.DateTime);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(646, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "F. Limite:";
            // 
            // maskedTextBox_FMax1
            // 
            this.maskedTextBox_FMax1.Location = new System.Drawing.Point(695, 91);
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
            this.checkBoxImportante.Location = new System.Drawing.Point(430, 13);
            this.checkBoxImportante.Name = "checkBoxImportante";
            this.checkBoxImportante.Size = new System.Drawing.Size(79, 17);
            this.checkBoxImportante.TabIndex = 62;
            this.checkBoxImportante.Text = "&Importante:";
            this.checkBoxImportante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxImportante.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(1056, 90);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(84, 23);
            this.buttonReset.TabIndex = 61;
            this.buttonReset.Text = "Limpiar";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // maskedTextBoxRefComunidad
            // 
            this.maskedTextBoxRefComunidad.Location = new System.Drawing.Point(73, 11);
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
            this.label6.Location = new System.Drawing.Point(4, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Comunidad:";
            // 
            // buttonEditarGestion
            // 
            this.buttonEditarGestion.Location = new System.Drawing.Point(7, 124);
            this.buttonEditarGestion.Name = "buttonEditarGestion";
            this.buttonEditarGestion.Size = new System.Drawing.Size(75, 23);
            this.buttonEditarGestion.TabIndex = 58;
            this.buttonEditarGestion.Text = "Editar";
            this.buttonEditarGestion.UseVisualStyleBackColor = true;
            this.buttonEditarGestion.Click += new System.EventHandler(this.buttonEditarGestion_Click);
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Location = new System.Drawing.Point(1056, 12);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(84, 72);
            this.button_Filtrar.TabIndex = 57;
            this.button_Filtrar.Text = "Filtrar";
            this.button_Filtrar.UseVisualStyleBackColor = true;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(891, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "&Tipo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(877, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Estado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Entidad:";
            // 
            // comboBox_Estado
            // 
            this.comboBox_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Estado.FormattingEnabled = true;
            this.comboBox_Estado.Location = new System.Drawing.Point(925, 91);
            this.comboBox_Estado.Name = "comboBox_Estado";
            this.comboBox_Estado.Size = new System.Drawing.Size(101, 21);
            this.comboBox_Estado.TabIndex = 56;
            // 
            // comboBox_Tipo
            // 
            this.comboBox_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo.FormattingEnabled = true;
            this.comboBox_Tipo.Location = new System.Drawing.Point(928, 12);
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
            this.dataGridViewGestiones.Location = new System.Drawing.Point(6, 153);
            this.dataGridViewGestiones.Name = "dataGridViewGestiones";
            this.dataGridViewGestiones.ReadOnly = true;
            this.dataGridViewGestiones.RowHeadersVisible = false;
            this.dataGridViewGestiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGestiones.Size = new System.Drawing.Size(1134, 550);
            this.dataGridViewGestiones.TabIndex = 46;
            this.dataGridViewGestiones.TabStop = false;
            this.dataGridViewGestiones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGestiones_CellDoubleClick);
            this.dataGridViewGestiones.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewGestiones_MouseClick);
            // 
            // textBoxEnEsperaDe
            // 
            this.textBoxEnEsperaDe.Location = new System.Drawing.Point(594, 11);
            this.textBoxEnEsperaDe.Name = "textBoxEnEsperaDe";
            this.textBoxEnEsperaDe.ReadOnly = true;
            this.textBoxEnEsperaDe.Size = new System.Drawing.Size(253, 20);
            this.textBoxEnEsperaDe.TabIndex = 74;
            this.textBoxEnEsperaDe.Text = "Pulsa espacio para Seleccionar Entidad";
            this.textBoxEnEsperaDe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEnEsperaDe_KeyPress);
            this.textBoxEnEsperaDe.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxEnEsperaDe_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 14);
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
            this.comboBoxResponsable.Location = new System.Drawing.Point(925, 120);
            this.comboBoxResponsable.Name = "comboBoxResponsable";
            this.comboBoxResponsable.Size = new System.Drawing.Size(101, 21);
            this.comboBoxResponsable.TabIndex = 76;
            // 
            // buttonRuta
            // 
            this.buttonRuta.Location = new System.Drawing.Point(89, 124);
            this.buttonRuta.Name = "buttonRuta";
            this.buttonRuta.Size = new System.Drawing.Size(75, 23);
            this.buttonRuta.TabIndex = 77;
            this.buttonRuta.Text = "Ruta";
            this.buttonRuta.UseVisualStyleBackColor = true;
            this.buttonRuta.Click += new System.EventHandler(this.buttonRuta_Click);
            // 
            // maskedTextBoxAplazarDias
            // 
            this.maskedTextBoxAplazarDias.Location = new System.Drawing.Point(220, 125);
            this.maskedTextBoxAplazarDias.Mask = "999";
            this.maskedTextBoxAplazarDias.Name = "maskedTextBoxAplazarDias";
            this.maskedTextBoxAplazarDias.Size = new System.Drawing.Size(23, 20);
            this.maskedTextBoxAplazarDias.TabIndex = 78;
            this.maskedTextBoxAplazarDias.Text = "3";
            // 
            // buttonAplazar
            // 
            this.buttonAplazar.Location = new System.Drawing.Point(249, 124);
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
            this.label7.Location = new System.Drawing.Point(169, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 80;
            this.label7.Text = "Nº Días:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(7, 710);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 13);
            this.labelCount.TabIndex = 81;
            // 
            // buttonBloque
            // 
            this.buttonBloque.Location = new System.Drawing.Point(346, 41);
            this.buttonBloque.Name = "buttonBloque";
            this.buttonBloque.Size = new System.Drawing.Size(63, 23);
            this.buttonBloque.TabIndex = 84;
            this.buttonBloque.Text = "Bloque";
            this.buttonBloque.UseVisualStyleBackColor = true;
            this.buttonBloque.Visible = false;
            this.buttonBloque.Click += new System.EventHandler(this.buttonBloque_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 83;
            this.label8.Text = "Bloque:";
            this.label8.Visible = false;
            // 
            // textBoxBloque
            // 
            this.textBoxBloque.Location = new System.Drawing.Point(73, 42);
            this.textBoxBloque.Name = "textBoxBloque";
            this.textBoxBloque.ReadOnly = true;
            this.textBoxBloque.Size = new System.Drawing.Size(261, 20);
            this.textBoxBloque.TabIndex = 82;
            this.textBoxBloque.Visible = false;
            this.textBoxBloque.DoubleClick += new System.EventHandler(this.textBoxBloque_DoubleClick);
            // 
            // maskedTextBox_FAgenda2
            // 
            this.maskedTextBox_FAgenda2.Location = new System.Drawing.Point(569, 120);
            this.maskedTextBox_FAgenda2.Mask = "00/00/0000";
            this.maskedTextBox_FAgenda2.Name = "maskedTextBox_FAgenda2";
            this.maskedTextBox_FAgenda2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FAgenda2.TabIndex = 86;
            this.maskedTextBox_FAgenda2.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(427, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 90;
            this.label9.Text = "F. Agenda:";
            // 
            // maskedTextBox_FAgenda1
            // 
            this.maskedTextBox_FAgenda1.Location = new System.Drawing.Point(492, 120);
            this.maskedTextBox_FAgenda1.Mask = "00/00/0000";
            this.maskedTextBox_FAgenda1.Name = "maskedTextBox_FAgenda1";
            this.maskedTextBox_FAgenda1.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FAgenda1.TabIndex = 85;
            this.maskedTextBox_FAgenda1.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox_FFin2
            // 
            this.maskedTextBox_FFin2.Location = new System.Drawing.Point(773, 120);
            this.maskedTextBox_FFin2.Mask = "00/00/0000";
            this.maskedTextBox_FFin2.Name = "maskedTextBox_FFin2";
            this.maskedTextBox_FFin2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FFin2.TabIndex = 88;
            this.maskedTextBox_FFin2.ValidatingType = typeof(System.DateTime);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(646, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 89;
            this.label12.Text = "F. Fin:";
            // 
            // maskedTextBox_FFin1
            // 
            this.maskedTextBox_FFin1.Location = new System.Drawing.Point(695, 120);
            this.maskedTextBox_FFin1.Mask = "00/00/0000";
            this.maskedTextBox_FFin1.Name = "maskedTextBox_FFin1";
            this.maskedTextBox_FFin1.Size = new System.Drawing.Size(72, 20);
            this.maskedTextBox_FFin1.TabIndex = 87;
            this.maskedTextBox_FFin1.ValidatingType = typeof(System.DateTime);
            // 
            // textBox_Entidad
            // 
            this.textBox_Entidad.Location = new System.Drawing.Point(162, 12);
            this.textBox_Entidad.Name = "textBox_Entidad";
            this.textBox_Entidad.ReadOnly = true;
            this.textBox_Entidad.Size = new System.Drawing.Size(247, 20);
            this.textBox_Entidad.TabIndex = 91;
            this.textBox_Entidad.Text = "Pulsa espacio para Seleccionar Entidad";
            this.textBox_Entidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Entidad_KeyPress);
            this.textBox_Entidad.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_Entidad_MouseDoubleClick);
            // 
            // buttonDivisión
            // 
            this.buttonDivisión.Location = new System.Drawing.Point(347, 68);
            this.buttonDivisión.Name = "buttonDivisión";
            this.buttonDivisión.Size = new System.Drawing.Size(63, 23);
            this.buttonDivisión.TabIndex = 97;
            this.buttonDivisión.Text = "División";
            this.buttonDivisión.UseVisualStyleBackColor = true;
            this.buttonDivisión.Visible = false;
            this.buttonDivisión.Click += new System.EventHandler(this.buttonDivisión_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(225, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 96;
            this.label13.Text = "División:";
            this.label13.Visible = false;
            // 
            // textBoxDivisión
            // 
            this.textBoxDivisión.Location = new System.Drawing.Point(278, 69);
            this.textBoxDivisión.Name = "textBoxDivisión";
            this.textBoxDivisión.ReadOnly = true;
            this.textBoxDivisión.Size = new System.Drawing.Size(57, 20);
            this.textBoxDivisión.TabIndex = 95;
            this.textBoxDivisión.Visible = false;
            this.textBoxDivisión.DoubleClick += new System.EventHandler(this.textBoxDivisión_DoubleClick);
            // 
            // buttonServicio
            // 
            this.buttonServicio.Location = new System.Drawing.Point(156, 68);
            this.buttonServicio.Name = "buttonServicio";
            this.buttonServicio.Size = new System.Drawing.Size(63, 23);
            this.buttonServicio.TabIndex = 94;
            this.buttonServicio.Text = "Servicio";
            this.buttonServicio.UseVisualStyleBackColor = true;
            this.buttonServicio.Visible = false;
            this.buttonServicio.Click += new System.EventHandler(this.buttonServicio_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 93;
            this.label14.Text = "Servicio:";
            this.label14.Visible = false;
            // 
            // textBoxServicio
            // 
            this.textBoxServicio.Location = new System.Drawing.Point(73, 69);
            this.textBoxServicio.Name = "textBoxServicio";
            this.textBoxServicio.ReadOnly = true;
            this.textBoxServicio.Size = new System.Drawing.Size(77, 20);
            this.textBoxServicio.TabIndex = 92;
            this.textBoxServicio.Visible = false;
            this.textBoxServicio.DoubleClick += new System.EventHandler(this.textBoxServicio_DoubleClick);
            // 
            // FormGestionesPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 732);
            this.ControlBox = false;
            this.Controls.Add(this.buttonDivisión);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxDivisión);
            this.Controls.Add(this.buttonServicio);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxServicio);
            this.Controls.Add(this.textBox_Entidad);
            this.Controls.Add(this.maskedTextBox_FAgenda2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.maskedTextBox_FAgenda1);
            this.Controls.Add(this.maskedTextBox_FFin2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.maskedTextBox_FFin1);
            this.Controls.Add(this.buttonBloque);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxBloque);
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
        private System.Windows.Forms.Button buttonBloque;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxBloque;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FAgenda2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FAgenda1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FFin2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FFin1;
        private System.Windows.Forms.TextBox textBox_Entidad;
        private System.Windows.Forms.Button buttonDivisión;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxDivisión;
        private System.Windows.Forms.Button buttonServicio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxServicio;
    }
}