namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormVerTarea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerTarea));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIdTarea = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.textBoxNotas = new System.Windows.Forms.TextBox();
            this.textBoxRuta = new System.Windows.Forms.TextBox();
            this.textBoxFrecuencia = new System.Windows.Forms.TextBox();
            this.maskedTextBoxFFin = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxFIni = new System.Windows.Forms.MaskedTextBox();
            this.textBoxCoste = new System.Windows.Forms.TextBox();
            this.textBoxPtto = new System.Windows.Forms.TextBox();
            this.textBoxSiniestro = new System.Windows.Forms.TextBox();
            this.checkBoxSeguro = new System.Windows.Forms.CheckBox();
            this.checkBoxAcuerdoJunta = new System.Windows.Forms.CheckBox();
            this.checkBoxProxJunta = new System.Windows.Forms.CheckBox();
            this.maskedTextBoxFechaActa = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxUsuario = new System.Windows.Forms.ComboBox();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewGestiones = new System.Windows.Forms.DataGridView();
            this.dataGridViewSeguimientos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonAddGestion = new System.Windows.Forms.Button();
            this.buttonAddSeguimiento = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEditarGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEliminarGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEditarSeguimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEliminarSeguimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRuta = new System.Windows.Forms.Button();
            this.textBoxEntidad = new System.Windows.Forms.TextBox();
            this.maskedTextBoxReferencia = new System.Windows.Forms.MaskedTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagSeguimientos = new System.Windows.Forms.TabPage();
            this.tabPageContactos = new System.Windows.Forms.TabPage();
            this.buttonAddContacto = new System.Windows.Forms.Button();
            this.buttonEnviarMail = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.dataGridViewContactos = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEditarContacto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEliminarContacto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCorreoResponsable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCorreoSeguir = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGestiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeguimientos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPagSeguimientos.SuspendLayout();
            this.tabPageContactos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContactos)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "DETALLES DE TAREAS";
            // 
            // textBoxIdTarea
            // 
            this.textBoxIdTarea.Location = new System.Drawing.Point(65, 49);
            this.textBoxIdTarea.Name = "textBoxIdTarea";
            this.textBoxIdTarea.ReadOnly = true;
            this.textBoxIdTarea.Size = new System.Drawing.Size(35, 20);
            this.textBoxIdTarea.TabIndex = 1;
            this.textBoxIdTarea.TabStop = false;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(106, 49);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(491, 20);
            this.textBoxDescripcion.TabIndex = 2;
            // 
            // textBoxNotas
            // 
            this.textBoxNotas.Location = new System.Drawing.Point(65, 101);
            this.textBoxNotas.Multiline = true;
            this.textBoxNotas.Name = "textBoxNotas";
            this.textBoxNotas.Size = new System.Drawing.Size(532, 92);
            this.textBoxNotas.TabIndex = 5;
            // 
            // textBoxRuta
            // 
            this.textBoxRuta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxRuta.ForeColor = System.Drawing.Color.Blue;
            this.textBoxRuta.Location = new System.Drawing.Point(120, 322);
            this.textBoxRuta.Name = "textBoxRuta";
            this.textBoxRuta.ReadOnly = true;
            this.textBoxRuta.Size = new System.Drawing.Size(478, 20);
            this.textBoxRuta.TabIndex = 19;
            this.textBoxRuta.Click += new System.EventHandler(this.textBoxRuta_Click);
            // 
            // textBoxFrecuencia
            // 
            this.textBoxFrecuencia.Location = new System.Drawing.Point(311, 197);
            this.textBoxFrecuencia.Name = "textBoxFrecuencia";
            this.textBoxFrecuencia.Size = new System.Drawing.Size(100, 20);
            this.textBoxFrecuencia.TabIndex = 7;
            // 
            // maskedTextBoxFFin
            // 
            this.maskedTextBoxFFin.Location = new System.Drawing.Point(311, 250);
            this.maskedTextBoxFFin.Mask = "00/00/0000";
            this.maskedTextBoxFFin.Name = "maskedTextBoxFFin";
            this.maskedTextBoxFFin.Size = new System.Drawing.Size(66, 20);
            this.maskedTextBoxFFin.TabIndex = 11;
            this.maskedTextBoxFFin.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFFin.Leave += new System.EventHandler(this.maskedTextBoxFFin_Leave);
            // 
            // maskedTextBoxFIni
            // 
            this.maskedTextBoxFIni.Location = new System.Drawing.Point(64, 249);
            this.maskedTextBoxFIni.Mask = "00/00/0000";
            this.maskedTextBoxFIni.Name = "maskedTextBoxFIni";
            this.maskedTextBoxFIni.Size = new System.Drawing.Size(65, 20);
            this.maskedTextBoxFIni.TabIndex = 10;
            this.maskedTextBoxFIni.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFIni.Leave += new System.EventHandler(this.maskedTextBoxFIni_Leave);
            // 
            // textBoxCoste
            // 
            this.textBoxCoste.Location = new System.Drawing.Point(311, 224);
            this.textBoxCoste.Name = "textBoxCoste";
            this.textBoxCoste.Size = new System.Drawing.Size(100, 20);
            this.textBoxCoste.TabIndex = 9;
            // 
            // textBoxPtto
            // 
            this.textBoxPtto.Location = new System.Drawing.Point(64, 274);
            this.textBoxPtto.Name = "textBoxPtto";
            this.textBoxPtto.Size = new System.Drawing.Size(100, 20);
            this.textBoxPtto.TabIndex = 12;
            // 
            // textBoxSiniestro
            // 
            this.textBoxSiniestro.Location = new System.Drawing.Point(311, 274);
            this.textBoxSiniestro.Name = "textBoxSiniestro";
            this.textBoxSiniestro.Size = new System.Drawing.Size(100, 20);
            this.textBoxSiniestro.TabIndex = 13;
            // 
            // checkBoxSeguro
            // 
            this.checkBoxSeguro.AutoSize = true;
            this.checkBoxSeguro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxSeguro.Location = new System.Drawing.Point(14, 301);
            this.checkBoxSeguro.Name = "checkBoxSeguro";
            this.checkBoxSeguro.Size = new System.Drawing.Size(63, 17);
            this.checkBoxSeguro.TabIndex = 14;
            this.checkBoxSeguro.Text = "Seguro:";
            this.checkBoxSeguro.UseVisualStyleBackColor = true;
            // 
            // checkBoxAcuerdoJunta
            // 
            this.checkBoxAcuerdoJunta.AutoSize = true;
            this.checkBoxAcuerdoJunta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAcuerdoJunta.Location = new System.Drawing.Point(87, 301);
            this.checkBoxAcuerdoJunta.Name = "checkBoxAcuerdoJunta";
            this.checkBoxAcuerdoJunta.Size = new System.Drawing.Size(98, 17);
            this.checkBoxAcuerdoJunta.TabIndex = 15;
            this.checkBoxAcuerdoJunta.Text = "Acuerdo Junta:";
            this.checkBoxAcuerdoJunta.UseVisualStyleBackColor = true;
            // 
            // checkBoxProxJunta
            // 
            this.checkBoxProxJunta.AutoSize = true;
            this.checkBoxProxJunta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxProxJunta.Location = new System.Drawing.Point(381, 302);
            this.checkBoxProxJunta.Name = "checkBoxProxJunta";
            this.checkBoxProxJunta.Size = new System.Drawing.Size(82, 17);
            this.checkBoxProxJunta.TabIndex = 17;
            this.checkBoxProxJunta.Text = "Prox. Junta:";
            this.checkBoxProxJunta.UseVisualStyleBackColor = true;
            // 
            // maskedTextBoxFechaActa
            // 
            this.maskedTextBoxFechaActa.Location = new System.Drawing.Point(311, 298);
            this.maskedTextBoxFechaActa.Mask = "00/00/0000";
            this.maskedTextBoxFechaActa.Name = "maskedTextBoxFechaActa";
            this.maskedTextBoxFechaActa.Size = new System.Drawing.Size(66, 20);
            this.maskedTextBoxFechaActa.TabIndex = 16;
            this.maskedTextBoxFechaActa.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFechaActa.Leave += new System.EventHandler(this.maskedTextBoxFechaActa_Leave);
            // 
            // comboBoxUsuario
            // 
            this.comboBoxUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuario.FormattingEnabled = true;
            this.comboBoxUsuario.Location = new System.Drawing.Point(64, 196);
            this.comboBoxUsuario.Name = "comboBoxUsuario";
            this.comboBoxUsuario.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUsuario.TabIndex = 6;
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(64, 223);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tarea:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Entidad:";
            // 
            // dataGridViewGestiones
            // 
            this.dataGridViewGestiones.AllowUserToAddRows = false;
            this.dataGridViewGestiones.AllowUserToDeleteRows = false;
            this.dataGridViewGestiones.AllowUserToResizeRows = false;
            this.dataGridViewGestiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGestiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGestiones.Location = new System.Drawing.Point(17, 379);
            this.dataGridViewGestiones.Name = "dataGridViewGestiones";
            this.dataGridViewGestiones.ReadOnly = true;
            this.dataGridViewGestiones.RowHeadersVisible = false;
            this.dataGridViewGestiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGestiones.Size = new System.Drawing.Size(581, 198);
            this.dataGridViewGestiones.TabIndex = 19;
            this.dataGridViewGestiones.TabStop = false;
            this.dataGridViewGestiones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGestiones_CellDoubleClick);
            this.dataGridViewGestiones.SelectionChanged += new System.EventHandler(this.dataGridViewGestiones_SelectionChanged);
            this.dataGridViewGestiones.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewGestiones_MouseClick);
            // 
            // dataGridViewSeguimientos
            // 
            this.dataGridViewSeguimientos.AllowUserToAddRows = false;
            this.dataGridViewSeguimientos.AllowUserToDeleteRows = false;
            this.dataGridViewSeguimientos.AllowUserToResizeRows = false;
            this.dataGridViewSeguimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeguimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeguimientos.Location = new System.Drawing.Point(9, 39);
            this.dataGridViewSeguimientos.Name = "dataGridViewSeguimientos";
            this.dataGridViewSeguimientos.ReadOnly = true;
            this.dataGridViewSeguimientos.RowHeadersVisible = false;
            this.dataGridViewSeguimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSeguimientos.Size = new System.Drawing.Size(513, 503);
            this.dataGridViewSeguimientos.TabIndex = 20;
            this.dataGridViewSeguimientos.TabStop = false;
            this.dataGridViewSeguimientos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeguimientos_CellDoubleClick);
            this.dataGridViewSeguimientos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewSeguimientos_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Gestiones";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Seguimientos de la Gestión";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Notas:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Ruta:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Usuario:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Tipo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "F. Inicio:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Ptto:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(242, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Frecuencia:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(268, 252);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "F. Fin:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(268, 227);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Coste:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(232, 277);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Ref. Siniestro:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(191, 302);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "Fecha Acta Acordado:";
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(425, 13);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(75, 23);
            this.buttonEditar.TabIndex = 27;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(522, 13);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 26;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonAddGestion
            // 
            this.buttonAddGestion.Location = new System.Drawing.Point(473, 352);
            this.buttonAddGestion.Name = "buttonAddGestion";
            this.buttonAddGestion.Size = new System.Drawing.Size(124, 23);
            this.buttonAddGestion.TabIndex = 20;
            this.buttonAddGestion.Text = "Añadir Gestión";
            this.buttonAddGestion.UseVisualStyleBackColor = true;
            this.buttonAddGestion.Click += new System.EventHandler(this.buttonAddGestion_Click);
            // 
            // buttonAddSeguimiento
            // 
            this.buttonAddSeguimiento.Location = new System.Drawing.Point(407, 10);
            this.buttonAddSeguimiento.Name = "buttonAddSeguimiento";
            this.buttonAddSeguimiento.Size = new System.Drawing.Size(115, 23);
            this.buttonAddSeguimiento.TabIndex = 22;
            this.buttonAddSeguimiento.Text = "Añadir Seguimiento";
            this.buttonAddSeguimiento.UseVisualStyleBackColor = true;
            this.buttonAddSeguimiento.Click += new System.EventHandler(this.buttonAddSeguimiento_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditarGestion,
            this.toolStripMenuItemEliminarGestion,
            this.toolStripMenuItemCorreoResponsable,
            this.toolStripMenuItemCorreoSeguir});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 114);
            // 
            // toolStripMenuItemEditarGestion
            // 
            this.toolStripMenuItemEditarGestion.Name = "toolStripMenuItemEditarGestion";
            this.toolStripMenuItemEditarGestion.Size = new System.Drawing.Size(188, 22);
            this.toolStripMenuItemEditarGestion.Text = "Editar";
            this.toolStripMenuItemEditarGestion.Click += new System.EventHandler(this.toolStripMenuItemEditarGestion_Click);
            // 
            // toolStripMenuItemEliminarGestion
            // 
            this.toolStripMenuItemEliminarGestion.Name = "toolStripMenuItemEliminarGestion";
            this.toolStripMenuItemEliminarGestion.Size = new System.Drawing.Size(188, 22);
            this.toolStripMenuItemEliminarGestion.Text = "Eliminar";
            this.toolStripMenuItemEliminarGestion.Click += new System.EventHandler(this.toolStripMenuItemEliminarGestion_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditarSeguimiento,
            this.ToolStripMenuItemEliminarSeguimiento});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(118, 48);
            // 
            // toolStripMenuItemEditarSeguimiento
            // 
            this.toolStripMenuItemEditarSeguimiento.Name = "toolStripMenuItemEditarSeguimiento";
            this.toolStripMenuItemEditarSeguimiento.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItemEditarSeguimiento.Text = "Editar";
            this.toolStripMenuItemEditarSeguimiento.Click += new System.EventHandler(this.toolStripMenuItemEditarSeguimiento_Click);
            // 
            // ToolStripMenuItemEliminarSeguimiento
            // 
            this.ToolStripMenuItemEliminarSeguimiento.Name = "ToolStripMenuItemEliminarSeguimiento";
            this.ToolStripMenuItemEliminarSeguimiento.Size = new System.Drawing.Size(117, 22);
            this.ToolStripMenuItemEliminarSeguimiento.Text = "Eliminar";
            this.ToolStripMenuItemEliminarSeguimiento.Click += new System.EventHandler(this.ToolStripMenuItemEliminarSeguimiento_Click);
            // 
            // buttonRuta
            // 
            this.buttonRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRuta.Location = new System.Drawing.Point(64, 323);
            this.buttonRuta.Name = "buttonRuta";
            this.buttonRuta.Size = new System.Drawing.Size(48, 19);
            this.buttonRuta.TabIndex = 18;
            this.buttonRuta.Text = "...";
            this.buttonRuta.UseVisualStyleBackColor = true;
            this.buttonRuta.Click += new System.EventHandler(this.buttonRuta_Click);
            // 
            // textBoxEntidad
            // 
            this.textBoxEntidad.Location = new System.Drawing.Point(106, 74);
            this.textBoxEntidad.Name = "textBoxEntidad";
            this.textBoxEntidad.ReadOnly = true;
            this.textBoxEntidad.Size = new System.Drawing.Size(491, 20);
            this.textBoxEntidad.TabIndex = 4;
            this.textBoxEntidad.Text = "Pulsa espacio para Seleccionar Entidad";
            this.textBoxEntidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEntidad_KeyPress);
            // 
            // maskedTextBoxReferencia
            // 
            this.maskedTextBoxReferencia.Location = new System.Drawing.Point(65, 74);
            this.maskedTextBoxReferencia.Mask = "999";
            this.maskedTextBoxReferencia.Name = "maskedTextBoxReferencia";
            this.maskedTextBoxReferencia.Size = new System.Drawing.Size(35, 20);
            this.maskedTextBoxReferencia.TabIndex = 3;
            this.maskedTextBoxReferencia.ValidatingType = typeof(int);
            this.maskedTextBoxReferencia.Leave += new System.EventHandler(this.maskedTextBoxReferencia_Leave);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagSeguimientos);
            this.tabControl1.Controls.Add(this.tabPageContactos);
            this.tabControl1.Location = new System.Drawing.Point(639, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(540, 573);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPagSeguimientos
            // 
            this.tabPagSeguimientos.Controls.Add(this.label5);
            this.tabPagSeguimientos.Controls.Add(this.dataGridViewSeguimientos);
            this.tabPagSeguimientos.Controls.Add(this.buttonAddSeguimiento);
            this.tabPagSeguimientos.Location = new System.Drawing.Point(4, 22);
            this.tabPagSeguimientos.Name = "tabPagSeguimientos";
            this.tabPagSeguimientos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagSeguimientos.Size = new System.Drawing.Size(532, 547);
            this.tabPagSeguimientos.TabIndex = 0;
            this.tabPagSeguimientos.Text = "Seguimientos";
            this.tabPagSeguimientos.UseVisualStyleBackColor = true;
            // 
            // tabPageContactos
            // 
            this.tabPageContactos.Controls.Add(this.buttonAddContacto);
            this.tabPageContactos.Controls.Add(this.buttonEnviarMail);
            this.tabPageContactos.Controls.Add(this.label17);
            this.tabPageContactos.Controls.Add(this.dataGridViewContactos);
            this.tabPageContactos.Location = new System.Drawing.Point(4, 22);
            this.tabPageContactos.Name = "tabPageContactos";
            this.tabPageContactos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageContactos.Size = new System.Drawing.Size(532, 547);
            this.tabPageContactos.TabIndex = 1;
            this.tabPageContactos.Text = "Contactos";
            this.tabPageContactos.UseVisualStyleBackColor = true;
            // 
            // buttonAddContacto
            // 
            this.buttonAddContacto.Location = new System.Drawing.Point(322, 10);
            this.buttonAddContacto.Name = "buttonAddContacto";
            this.buttonAddContacto.Size = new System.Drawing.Size(97, 23);
            this.buttonAddContacto.TabIndex = 24;
            this.buttonAddContacto.Text = "Añadir Contacto";
            this.buttonAddContacto.UseVisualStyleBackColor = true;
            this.buttonAddContacto.Click += new System.EventHandler(this.buttonAddContacto_Click);
            // 
            // buttonEnviarMail
            // 
            this.buttonEnviarMail.Location = new System.Drawing.Point(425, 10);
            this.buttonEnviarMail.Name = "buttonEnviarMail";
            this.buttonEnviarMail.Size = new System.Drawing.Size(97, 23);
            this.buttonEnviarMail.TabIndex = 25;
            this.buttonEnviarMail.Text = "Enviar Correo";
            this.buttonEnviarMail.UseVisualStyleBackColor = true;
            this.buttonEnviarMail.Click += new System.EventHandler(this.buttonEnviarMail_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 15);
            this.label17.TabIndex = 26;
            this.label17.Text = "Contactos";
            // 
            // dataGridViewContactos
            // 
            this.dataGridViewContactos.AllowUserToAddRows = false;
            this.dataGridViewContactos.AllowUserToDeleteRows = false;
            this.dataGridViewContactos.AllowUserToResizeRows = false;
            this.dataGridViewContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContactos.Location = new System.Drawing.Point(9, 39);
            this.dataGridViewContactos.Name = "dataGridViewContactos";
            this.dataGridViewContactos.ReadOnly = true;
            this.dataGridViewContactos.RowHeadersVisible = false;
            this.dataGridViewContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContactos.Size = new System.Drawing.Size(513, 503);
            this.dataGridViewContactos.TabIndex = 0;
            this.dataGridViewContactos.TabStop = false;
            this.dataGridViewContactos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContactos_CellDoubleClick);
            this.dataGridViewContactos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewContactos_MouseClick);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditarContacto,
            this.toolStripMenuItemEliminarContacto});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(118, 48);
            // 
            // toolStripMenuItemEditarContacto
            // 
            this.toolStripMenuItemEditarContacto.Name = "toolStripMenuItemEditarContacto";
            this.toolStripMenuItemEditarContacto.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItemEditarContacto.Text = "Editar";
            this.toolStripMenuItemEditarContacto.Click += new System.EventHandler(this.toolStripMenuItemEditarContacto_Click);
            // 
            // toolStripMenuItemEliminarContacto
            // 
            this.toolStripMenuItemEliminarContacto.Name = "toolStripMenuItemEliminarContacto";
            this.toolStripMenuItemEliminarContacto.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItemEliminarContacto.Text = "Eliminar";
            this.toolStripMenuItemEliminarContacto.Click += new System.EventHandler(this.toolStripMenuItemEliminarContacto_Click);
            // 
            // toolStripMenuItemCorreoResponsable
            // 
            this.toolStripMenuItemCorreoResponsable.Name = "toolStripMenuItemCorreoResponsable";
            this.toolStripMenuItemCorreoResponsable.Size = new System.Drawing.Size(188, 22);
            this.toolStripMenuItemCorreoResponsable.Text = "Correo a Responsable";
            this.toolStripMenuItemCorreoResponsable.Click += new System.EventHandler(this.toolStripMenuItemCorreoResponsable_Click);
            // 
            // toolStripMenuItemCorreoSeguir
            // 
            this.toolStripMenuItemCorreoSeguir.Name = "toolStripMenuItemCorreoSeguir";
            this.toolStripMenuItemCorreoSeguir.Size = new System.Drawing.Size(188, 22);
            this.toolStripMenuItemCorreoSeguir.Text = "Correo a Seguir";
            this.toolStripMenuItemCorreoSeguir.Click += new System.EventHandler(this.toolStripMenuItemCorreoSeguir_Click);
            // 
            // FormVerTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 612);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.maskedTextBoxReferencia);
            this.Controls.Add(this.textBoxEntidad);
            this.Controls.Add(this.buttonRuta);
            this.Controls.Add(this.buttonAddGestion);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewGestiones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.comboBoxUsuario);
            this.Controls.Add(this.maskedTextBoxFechaActa);
            this.Controls.Add(this.checkBoxProxJunta);
            this.Controls.Add(this.checkBoxAcuerdoJunta);
            this.Controls.Add(this.checkBoxSeguro);
            this.Controls.Add(this.textBoxSiniestro);
            this.Controls.Add(this.textBoxPtto);
            this.Controls.Add(this.textBoxCoste);
            this.Controls.Add(this.maskedTextBoxFIni);
            this.Controls.Add(this.maskedTextBoxFFin);
            this.Controls.Add(this.textBoxFrecuencia);
            this.Controls.Add(this.textBoxRuta);
            this.Controls.Add(this.textBoxNotas);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.textBoxIdTarea);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerTarea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Tarea";
            this.Load += new System.EventHandler(this.FormVerTarea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGestiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeguimientos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPagSeguimientos.ResumeLayout(false);
            this.tabPagSeguimientos.PerformLayout();
            this.tabPageContactos.ResumeLayout(false);
            this.tabPageContactos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContactos)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIdTarea;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.TextBox textBoxNotas;
        private System.Windows.Forms.TextBox textBoxRuta;
        private System.Windows.Forms.TextBox textBoxFrecuencia;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxFFin;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxFIni;
        private System.Windows.Forms.TextBox textBoxCoste;
        private System.Windows.Forms.TextBox textBoxPtto;
        private System.Windows.Forms.TextBox textBoxSiniestro;
        private System.Windows.Forms.CheckBox checkBoxSeguro;
        private System.Windows.Forms.CheckBox checkBoxAcuerdoJunta;
        private System.Windows.Forms.CheckBox checkBoxProxJunta;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxFechaActa;
        private System.Windows.Forms.ComboBox comboBoxUsuario;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewGestiones;
        private System.Windows.Forms.DataGridView dataGridViewSeguimientos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonAddGestion;
        private System.Windows.Forms.Button buttonAddSeguimiento;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEliminarGestion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEliminarSeguimiento;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditarGestion;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditarSeguimiento;
        private System.Windows.Forms.Button buttonRuta;
        private System.Windows.Forms.TextBox textBoxEntidad;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxReferencia;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagSeguimientos;
        private System.Windows.Forms.TabPage tabPageContactos;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dataGridViewContactos;
        private System.Windows.Forms.Button buttonEnviarMail;
        private System.Windows.Forms.Button buttonAddContacto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditarContacto;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEliminarContacto;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCorreoResponsable;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCorreoSeguir;
    }
}