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
            this.textBoxIdTarea = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.textBoxNotas = new System.Windows.Forms.TextBox();
            this.textBoxRuta = new System.Windows.Forms.TextBox();
            this.maskedTextBoxFFin = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxFIni = new System.Windows.Forms.MaskedTextBox();
            this.textBoxSiniestro = new System.Windows.Forms.TextBox();
            this.checkBoxAcuerdoJunta = new System.Windows.Forms.CheckBox();
            this.checkBoxProxJunta = new System.Windows.Forms.CheckBox();
            this.maskedTextBoxFechaActa = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewGestiones = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelRutaLink = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonAddGestion = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEditarGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAddSeguimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarCorreoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemInfoEntidad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEliminarGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEditarSeguimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEliminarSeguimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRuta = new System.Windows.Forms.Button();
            this.textBoxEntidad = new System.Windows.Forms.TextBox();
            this.maskedTextBoxReferencia = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEditarContacto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopiarPortapapelesContacto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEliminarContacto = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCerrarGestion = new System.Windows.Forms.Button();
            this.buttonEliminarTarea = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCoste = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBoxImportante = new System.Windows.Forms.CheckBox();
            this.textBoxTareaNueva = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataSetCargos1 = new UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms.Informes.DataSetCargos();
            this.comboBoxEstadoGestion = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.borrarExpedienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonBloque = new System.Windows.Forms.Button();
            this.textBoxBloque = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonDuplicarTarea = new System.Windows.Forms.Button();
            this.textBoxIdTareaNuevo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxDivision = new System.Windows.Forms.TextBox();
            this.buttonSelServicio = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonSelDivision = new System.Windows.Forms.Button();
            this.textBoxServicio = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxSugerencia = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.buttonSugerenciaDesc = new System.Windows.Forms.Button();
            this.tabPageExpedientes = new System.Windows.Forms.TabPage();
            this.dataGridViewExpedientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddExpediente = new System.Windows.Forms.Button();
            this.tabPageContactos = new System.Windows.Forms.TabPage();
            this.dataGridViewContactos = new System.Windows.Forms.DataGridView();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonEnviarMail = new System.Windows.Forms.Button();
            this.buttonAddContacto = new System.Windows.Forms.Button();
            this.tabPagSeguimientos = new System.Windows.Forms.TabPage();
            this.buttonAddSeguimiento = new System.Windows.Forms.Button();
            this.dataGridViewSeguimientos = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonTodosSeguimientos = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGestiones)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCargos1)).BeginInit();
            this.contextMenuStrip5.SuspendLayout();
            this.tabPageExpedientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpedientes)).BeginInit();
            this.tabPageContactos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContactos)).BeginInit();
            this.tabPagSeguimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeguimientos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxIdTarea
            // 
            this.textBoxIdTarea.Location = new System.Drawing.Point(76, 46);
            this.textBoxIdTarea.Name = "textBoxIdTarea";
            this.textBoxIdTarea.ReadOnly = true;
            this.textBoxIdTarea.Size = new System.Drawing.Size(64, 20);
            this.textBoxIdTarea.TabIndex = 1;
            this.textBoxIdTarea.TabStop = false;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(76, 187);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(370, 20);
            this.textBoxDescripcion.TabIndex = 12;
            // 
            // textBoxNotas
            // 
            this.textBoxNotas.Location = new System.Drawing.Point(74, 246);
            this.textBoxNotas.Multiline = true;
            this.textBoxNotas.Name = "textBoxNotas";
            this.textBoxNotas.Size = new System.Drawing.Size(499, 76);
            this.textBoxNotas.TabIndex = 17;
            // 
            // textBoxRuta
            // 
            this.textBoxRuta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxRuta.ForeColor = System.Drawing.Color.Blue;
            this.textBoxRuta.Location = new System.Drawing.Point(98, 329);
            this.textBoxRuta.Name = "textBoxRuta";
            this.textBoxRuta.Size = new System.Drawing.Size(475, 20);
            this.textBoxRuta.TabIndex = 17;
            this.textBoxRuta.TabStop = false;
            this.textBoxRuta.Click += new System.EventHandler(this.textBoxRuta_Click);
            // 
            // maskedTextBoxFFin
            // 
            this.maskedTextBoxFFin.Location = new System.Drawing.Point(205, 136);
            this.maskedTextBoxFFin.Mask = "00/00/0000";
            this.maskedTextBoxFFin.Name = "maskedTextBoxFFin";
            this.maskedTextBoxFFin.Size = new System.Drawing.Size(66, 20);
            this.maskedTextBoxFFin.TabIndex = 9;
            this.maskedTextBoxFFin.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFFin.Leave += new System.EventHandler(this.maskedTextBoxFFin_Leave);
            // 
            // maskedTextBoxFIni
            // 
            this.maskedTextBoxFIni.Location = new System.Drawing.Point(76, 136);
            this.maskedTextBoxFIni.Mask = "00/00/0000";
            this.maskedTextBoxFIni.Name = "maskedTextBoxFIni";
            this.maskedTextBoxFIni.Size = new System.Drawing.Size(65, 20);
            this.maskedTextBoxFIni.TabIndex = 8;
            this.maskedTextBoxFIni.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFIni.Leave += new System.EventHandler(this.maskedTextBoxFIni_Leave);
            // 
            // textBoxSiniestro
            // 
            this.textBoxSiniestro.Location = new System.Drawing.Point(322, 214);
            this.textBoxSiniestro.Name = "textBoxSiniestro";
            this.textBoxSiniestro.Size = new System.Drawing.Size(124, 20);
            this.textBoxSiniestro.TabIndex = 15;
            // 
            // checkBoxAcuerdoJunta
            // 
            this.checkBoxAcuerdoJunta.AutoSize = true;
            this.checkBoxAcuerdoJunta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAcuerdoJunta.Location = new System.Drawing.Point(558, 164);
            this.checkBoxAcuerdoJunta.Name = "checkBoxAcuerdoJunta";
            this.checkBoxAcuerdoJunta.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAcuerdoJunta.TabIndex = 12;
            this.checkBoxAcuerdoJunta.TabStop = false;
            this.checkBoxAcuerdoJunta.UseVisualStyleBackColor = true;
            this.checkBoxAcuerdoJunta.CheckedChanged += new System.EventHandler(this.checkBoxAcuerdoJunta_CheckedChanged);
            // 
            // checkBoxProxJunta
            // 
            this.checkBoxProxJunta.AutoSize = true;
            this.checkBoxProxJunta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxProxJunta.Location = new System.Drawing.Point(491, 189);
            this.checkBoxProxJunta.Name = "checkBoxProxJunta";
            this.checkBoxProxJunta.Size = new System.Drawing.Size(82, 17);
            this.checkBoxProxJunta.TabIndex = 13;
            this.checkBoxProxJunta.Text = "Prox. Junta:";
            this.checkBoxProxJunta.UseVisualStyleBackColor = true;
            // 
            // maskedTextBoxFechaActa
            // 
            this.maskedTextBoxFechaActa.Location = new System.Drawing.Point(486, 161);
            this.maskedTextBoxFechaActa.Mask = "00/00/0000";
            this.maskedTextBoxFechaActa.Name = "maskedTextBoxFechaActa";
            this.maskedTextBoxFechaActa.Size = new System.Drawing.Size(66, 20);
            this.maskedTextBoxFechaActa.TabIndex = 11;
            this.maskedTextBoxFechaActa.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFechaActa.Leave += new System.EventHandler(this.maskedTextBoxFechaActa_Leave);
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Location = new System.Drawing.Point(76, 104);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(220, 21);
            this.comboBoxTipo.TabIndex = 5;
            this.comboBoxTipo.SelectionChangeCommitted += new System.EventHandler(this.comboBoxTipo_SelectionChangeCommitted);
            this.comboBoxTipo.Leave += new System.EventHandler(this.comboBoxTipo_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tarea:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 50);
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
            this.dataGridViewGestiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGestiones.Location = new System.Drawing.Point(28, 391);
            this.dataGridViewGestiones.Name = "dataGridViewGestiones";
            this.dataGridViewGestiones.ReadOnly = true;
            this.dataGridViewGestiones.RowHeadersVisible = false;
            this.dataGridViewGestiones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewGestiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGestiones.Size = new System.Drawing.Size(1215, 198);
            this.dataGridViewGestiones.TabIndex = 19;
            this.dataGridViewGestiones.TabStop = false;
            this.dataGridViewGestiones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGestiones_CellDoubleClick);
            this.dataGridViewGestiones.SelectionChanged += new System.EventHandler(this.dataGridViewGestiones_SelectionChanged);
            this.dataGridViewGestiones.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewGestiones_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Gestiones";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Notas:";
            // 
            // labelRutaLink
            // 
            this.labelRutaLink.AutoSize = true;
            this.labelRutaLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRutaLink.Location = new System.Drawing.Point(30, 332);
            this.labelRutaLink.Name = "labelRutaLink";
            this.labelRutaLink.Size = new System.Drawing.Size(33, 13);
            this.labelRutaLink.TabIndex = 27;
            this.labelRutaLink.Text = "Ruta:";
            this.labelRutaLink.DoubleClick += new System.EventHandler(this.labelRutaLink_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Tipo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "F. Inicio:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(160, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "F. Fin:";
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(338, 13);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(75, 23);
            this.buttonEditar.TabIndex = 22;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(500, 13);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 21;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonAddGestion
            // 
            this.buttonAddGestion.Location = new System.Drawing.Point(1067, 361);
            this.buttonAddGestion.Name = "buttonAddGestion";
            this.buttonAddGestion.Size = new System.Drawing.Size(95, 23);
            this.buttonAddGestion.TabIndex = 19;
            this.buttonAddGestion.Text = "Añadir Gestión";
            this.buttonAddGestion.UseVisualStyleBackColor = true;
            this.buttonAddGestion.Click += new System.EventHandler(this.buttonAddGestion_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditarGestion,
            this.toolStripMenuItemAddSeguimiento,
            this.enviarCorreoToolStripMenuItem,
            this.toolStripMenuItemInfoEntidad,
            this.toolStripMenuItemEliminarGestion});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 114);
            // 
            // toolStripMenuItemEditarGestion
            // 
            this.toolStripMenuItemEditarGestion.Name = "toolStripMenuItemEditarGestion";
            this.toolStripMenuItemEditarGestion.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemEditarGestion.Text = "Editar";
            this.toolStripMenuItemEditarGestion.Click += new System.EventHandler(this.toolStripMenuItemEditarGestion_Click);
            // 
            // toolStripMenuItemAddSeguimiento
            // 
            this.toolStripMenuItemAddSeguimiento.Name = "toolStripMenuItemAddSeguimiento";
            this.toolStripMenuItemAddSeguimiento.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemAddSeguimiento.Text = "Añadir Seguimiento";
            this.toolStripMenuItemAddSeguimiento.Click += new System.EventHandler(this.toolStripMenuItemAddSeguimiento_Click);
            // 
            // enviarCorreoToolStripMenuItem
            // 
            this.enviarCorreoToolStripMenuItem.Name = "enviarCorreoToolStripMenuItem";
            this.enviarCorreoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.enviarCorreoToolStripMenuItem.Text = "Enviar Correo";
            this.enviarCorreoToolStripMenuItem.Click += new System.EventHandler(this.enviarCorreoToolStripMenuItem_Click);
            // 
            // toolStripMenuItemInfoEntidad
            // 
            this.toolStripMenuItemInfoEntidad.Name = "toolStripMenuItemInfoEntidad";
            this.toolStripMenuItemInfoEntidad.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemInfoEntidad.Text = "Ver Entidad";
            this.toolStripMenuItemInfoEntidad.Click += new System.EventHandler(this.toolStripMenuItemInfoEntidad_Click);
            // 
            // toolStripMenuItemEliminarGestion
            // 
            this.toolStripMenuItemEliminarGestion.Name = "toolStripMenuItemEliminarGestion";
            this.toolStripMenuItemEliminarGestion.Size = new System.Drawing.Size(179, 22);
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
            this.buttonRuta.Location = new System.Drawing.Point(73, 329);
            this.buttonRuta.Name = "buttonRuta";
            this.buttonRuta.Size = new System.Drawing.Size(19, 19);
            this.buttonRuta.TabIndex = 18;
            this.buttonRuta.Text = "...";
            this.buttonRuta.UseVisualStyleBackColor = true;
            this.buttonRuta.Click += new System.EventHandler(this.buttonRuta_Click);
            // 
            // textBoxEntidad
            // 
            this.textBoxEntidad.Location = new System.Drawing.Point(294, 46);
            this.textBoxEntidad.Name = "textBoxEntidad";
            this.textBoxEntidad.ReadOnly = true;
            this.textBoxEntidad.Size = new System.Drawing.Size(281, 20);
            this.textBoxEntidad.TabIndex = 3;
            this.textBoxEntidad.Text = "Pulsa espacio para Seleccionar Entidad";
            this.textBoxEntidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEntidad_KeyPress);
            // 
            // maskedTextBoxReferencia
            // 
            this.maskedTextBoxReferencia.Location = new System.Drawing.Point(257, 46);
            this.maskedTextBoxReferencia.Mask = "999";
            this.maskedTextBoxReferencia.Name = "maskedTextBoxReferencia";
            this.maskedTextBoxReferencia.Size = new System.Drawing.Size(31, 20);
            this.maskedTextBoxReferencia.TabIndex = 2;
            this.maskedTextBoxReferencia.ValidatingType = typeof(int);
            this.maskedTextBoxReferencia.Leave += new System.EventHandler(this.maskedTextBoxReferencia_Leave);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditarContacto,
            this.toolStripMenuItemCopiarPortapapelesContacto,
            this.toolStripMenuItemEliminarContacto});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(193, 70);
            // 
            // toolStripMenuItemEditarContacto
            // 
            this.toolStripMenuItemEditarContacto.Name = "toolStripMenuItemEditarContacto";
            this.toolStripMenuItemEditarContacto.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItemEditarContacto.Text = "Editar";
            this.toolStripMenuItemEditarContacto.Click += new System.EventHandler(this.toolStripMenuItemEditarContacto_Click);
            // 
            // toolStripMenuItemCopiarPortapapelesContacto
            // 
            this.toolStripMenuItemCopiarPortapapelesContacto.Name = "toolStripMenuItemCopiarPortapapelesContacto";
            this.toolStripMenuItemCopiarPortapapelesContacto.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItemCopiarPortapapelesContacto.Text = "Copiar al Portapapeles";
            this.toolStripMenuItemCopiarPortapapelesContacto.Click += new System.EventHandler(this.toolStripMenuItemCopiarPortapapelesContacto_Click);
            // 
            // toolStripMenuItemEliminarContacto
            // 
            this.toolStripMenuItemEliminarContacto.Name = "toolStripMenuItemEliminarContacto";
            this.toolStripMenuItemEliminarContacto.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItemEliminarContacto.Text = "Eliminar";
            this.toolStripMenuItemEliminarContacto.Click += new System.EventHandler(this.toolStripMenuItemEliminarContacto_Click);
            // 
            // buttonCerrarGestion
            // 
            this.buttonCerrarGestion.Location = new System.Drawing.Point(1168, 361);
            this.buttonCerrarGestion.Name = "buttonCerrarGestion";
            this.buttonCerrarGestion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonCerrarGestion.Size = new System.Drawing.Size(75, 23);
            this.buttonCerrarGestion.TabIndex = 20;
            this.buttonCerrarGestion.Text = "Cerrar";
            this.buttonCerrarGestion.UseVisualStyleBackColor = true;
            this.buttonCerrarGestion.Click += new System.EventHandler(this.buttonCerrarGestion_Click);
            // 
            // buttonEliminarTarea
            // 
            this.buttonEliminarTarea.Location = new System.Drawing.Point(419, 13);
            this.buttonEliminarTarea.Name = "buttonEliminarTarea";
            this.buttonEliminarTarea.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminarTarea.TabIndex = 23;
            this.buttonEliminarTarea.Text = "Borrar";
            this.buttonEliminarTarea.UseVisualStyleBackColor = true;
            this.buttonEliminarTarea.Click += new System.EventHandler(this.buttonEliminarTarea_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(289, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Ref.";
            // 
            // textBoxCoste
            // 
            this.textBoxCoste.Location = new System.Drawing.Point(76, 214);
            this.textBoxCoste.Name = "textBoxCoste";
            this.textBoxCoste.Size = new System.Drawing.Size(100, 20);
            this.textBoxCoste.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 218);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Coste:";
            // 
            // checkBoxImportante
            // 
            this.checkBoxImportante.AutoSize = true;
            this.checkBoxImportante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxImportante.Location = new System.Drawing.Point(494, 216);
            this.checkBoxImportante.Name = "checkBoxImportante";
            this.checkBoxImportante.Size = new System.Drawing.Size(79, 17);
            this.checkBoxImportante.TabIndex = 16;
            this.checkBoxImportante.Text = "Importante:";
            this.checkBoxImportante.UseVisualStyleBackColor = true;
            // 
            // textBoxTareaNueva
            // 
            this.textBoxTareaNueva.Location = new System.Drawing.Point(76, 16);
            this.textBoxTareaNueva.Name = "textBoxTareaNueva";
            this.textBoxTareaNueva.Size = new System.Drawing.Size(100, 20);
            this.textBoxTareaNueva.TabIndex = 39;
            this.textBoxTareaNueva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTareaNueva_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Ir a Tarea:";
            // 
            // dataSetCargos1
            // 
            this.dataSetCargos1.DataSetName = "DataSetCargos";
            this.dataSetCargos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBoxEstadoGestion
            // 
            this.comboBoxEstadoGestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstadoGestion.FormattingEnabled = true;
            this.comboBoxEstadoGestion.Items.AddRange(new object[] {
            "Abiertas",
            "Cerradas",
            "Todas"});
            this.comboBoxEstadoGestion.Location = new System.Drawing.Point(963, 362);
            this.comboBoxEstadoGestion.Name = "comboBoxEstadoGestion";
            this.comboBoxEstadoGestion.Size = new System.Drawing.Size(98, 21);
            this.comboBoxEstadoGestion.TabIndex = 42;
            this.comboBoxEstadoGestion.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstadoGestion_SelectedIndexChanged);
            // 
            // contextMenuStrip5
            // 
            this.contextMenuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrarExpedienteToolStripMenuItem});
            this.contextMenuStrip5.Name = "contextMenuStrip5";
            this.contextMenuStrip5.Size = new System.Drawing.Size(178, 26);
            // 
            // borrarExpedienteToolStripMenuItem
            // 
            this.borrarExpedienteToolStripMenuItem.Name = "borrarExpedienteToolStripMenuItem";
            this.borrarExpedienteToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.borrarExpedienteToolStripMenuItem.Text = "Eliminar Expediente";
            this.borrarExpedienteToolStripMenuItem.Click += new System.EventHandler(this.borrarExpedienteToolStripMenuItem_Click);
            // 
            // buttonBloque
            // 
            this.buttonBloque.Location = new System.Drawing.Point(263, 74);
            this.buttonBloque.Name = "buttonBloque";
            this.buttonBloque.Size = new System.Drawing.Size(33, 20);
            this.buttonBloque.TabIndex = 4;
            this.buttonBloque.Text = "Seleccionar";
            this.buttonBloque.UseVisualStyleBackColor = true;
            this.buttonBloque.Click += new System.EventHandler(this.buttonBloque_Click);
            // 
            // textBoxBloque
            // 
            this.textBoxBloque.Location = new System.Drawing.Point(76, 74);
            this.textBoxBloque.Name = "textBoxBloque";
            this.textBoxBloque.ReadOnly = true;
            this.textBoxBloque.Size = new System.Drawing.Size(185, 20);
            this.textBoxBloque.TabIndex = 44;
            this.textBoxBloque.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxBloque_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Bloque:";
            // 
            // buttonDuplicarTarea
            // 
            this.buttonDuplicarTarea.Location = new System.Drawing.Point(242, 12);
            this.buttonDuplicarTarea.Name = "buttonDuplicarTarea";
            this.buttonDuplicarTarea.Size = new System.Drawing.Size(90, 23);
            this.buttonDuplicarTarea.TabIndex = 46;
            this.buttonDuplicarTarea.Text = "Duplicar Tarea";
            this.buttonDuplicarTarea.UseVisualStyleBackColor = true;
            this.buttonDuplicarTarea.Click += new System.EventHandler(this.buttonDuplicarTarea_Click);
            // 
            // textBoxIdTareaNuevo
            // 
            this.textBoxIdTareaNuevo.Location = new System.Drawing.Point(146, 46);
            this.textBoxIdTareaNuevo.Name = "textBoxIdTareaNuevo";
            this.textBoxIdTareaNuevo.ReadOnly = true;
            this.textBoxIdTareaNuevo.Size = new System.Drawing.Size(53, 20);
            this.textBoxIdTareaNuevo.TabIndex = 47;
            this.textBoxIdTareaNuevo.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(302, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "División:";
            // 
            // textBoxDivision
            // 
            this.textBoxDivision.Location = new System.Drawing.Point(355, 74);
            this.textBoxDivision.Name = "textBoxDivision";
            this.textBoxDivision.ReadOnly = true;
            this.textBoxDivision.Size = new System.Drawing.Size(182, 20);
            this.textBoxDivision.TabIndex = 49;
            // 
            // buttonSelServicio
            // 
            this.buttonSelServicio.Location = new System.Drawing.Point(543, 104);
            this.buttonSelServicio.Name = "buttonSelServicio";
            this.buttonSelServicio.Size = new System.Drawing.Size(30, 20);
            this.buttonSelServicio.TabIndex = 7;
            this.buttonSelServicio.Text = "Sel";
            this.buttonSelServicio.UseVisualStyleBackColor = true;
            this.buttonSelServicio.Click += new System.EventHandler(this.buttonSelDivSer_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(2, 190);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 13);
            this.label18.TabIndex = 51;
            this.label18.Text = "Descripción:";
            // 
            // buttonSelDivision
            // 
            this.buttonSelDivision.Location = new System.Drawing.Point(543, 74);
            this.buttonSelDivision.Name = "buttonSelDivision";
            this.buttonSelDivision.Size = new System.Drawing.Size(30, 20);
            this.buttonSelDivision.TabIndex = 6;
            this.buttonSelDivision.Text = "Sel";
            this.buttonSelDivision.UseVisualStyleBackColor = true;
            this.buttonSelDivision.Click += new System.EventHandler(this.buttonSelDivision_Click);
            // 
            // textBoxServicio
            // 
            this.textBoxServicio.Location = new System.Drawing.Point(355, 104);
            this.textBoxServicio.Name = "textBoxServicio";
            this.textBoxServicio.ReadOnly = true;
            this.textBoxServicio.Size = new System.Drawing.Size(182, 20);
            this.textBoxServicio.TabIndex = 53;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(302, 108);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 54;
            this.label19.Text = "Servicio:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(483, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 55;
            this.label11.Text = "Acuerdo Junta:";
            // 
            // textBoxSugerencia
            // 
            this.textBoxSugerencia.Location = new System.Drawing.Point(76, 161);
            this.textBoxSugerencia.Name = "textBoxSugerencia";
            this.textBoxSugerencia.ReadOnly = true;
            this.textBoxSugerencia.Size = new System.Drawing.Size(337, 20);
            this.textBoxSugerencia.TabIndex = 56;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 164);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 13);
            this.label20.TabIndex = 58;
            this.label20.Text = "Sugerencia:";
            // 
            // buttonSugerenciaDesc
            // 
            this.buttonSugerenciaDesc.Location = new System.Drawing.Point(419, 159);
            this.buttonSugerenciaDesc.Name = "buttonSugerenciaDesc";
            this.buttonSugerenciaDesc.Size = new System.Drawing.Size(28, 23);
            this.buttonSugerenciaDesc.TabIndex = 10;
            this.buttonSugerenciaDesc.Text = "↓";
            this.buttonSugerenciaDesc.UseVisualStyleBackColor = true;
            this.buttonSugerenciaDesc.Click += new System.EventHandler(this.buttonSugerenciaDesc_Click);
            // 
            // tabPageExpedientes
            // 
            this.tabPageExpedientes.Controls.Add(this.buttonAddExpediente);
            this.tabPageExpedientes.Controls.Add(this.label1);
            this.tabPageExpedientes.Controls.Add(this.dataGridViewExpedientes);
            this.tabPageExpedientes.Location = new System.Drawing.Point(4, 22);
            this.tabPageExpedientes.Name = "tabPageExpedientes";
            this.tabPageExpedientes.Size = new System.Drawing.Size(658, 308);
            this.tabPageExpedientes.TabIndex = 3;
            this.tabPageExpedientes.Text = "Expedientes";
            this.tabPageExpedientes.UseVisualStyleBackColor = true;
            // 
            // dataGridViewExpedientes
            // 
            this.dataGridViewExpedientes.AllowUserToAddRows = false;
            this.dataGridViewExpedientes.AllowUserToDeleteRows = false;
            this.dataGridViewExpedientes.AllowUserToResizeRows = false;
            this.dataGridViewExpedientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpedientes.Location = new System.Drawing.Point(9, 37);
            this.dataGridViewExpedientes.Name = "dataGridViewExpedientes";
            this.dataGridViewExpedientes.ReadOnly = true;
            this.dataGridViewExpedientes.RowHeadersVisible = false;
            this.dataGridViewExpedientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExpedientes.Size = new System.Drawing.Size(643, 253);
            this.dataGridViewExpedientes.TabIndex = 27;
            this.dataGridViewExpedientes.TabStop = false;
            this.dataGridViewExpedientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExpedientes_CellDoubleClick);
            this.dataGridViewExpedientes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewExpedientes_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "Expedientes";
            // 
            // buttonAddExpediente
            // 
            this.buttonAddExpediente.Location = new System.Drawing.Point(539, 8);
            this.buttonAddExpediente.Name = "buttonAddExpediente";
            this.buttonAddExpediente.Size = new System.Drawing.Size(113, 23);
            this.buttonAddExpediente.TabIndex = 28;
            this.buttonAddExpediente.Text = "Añadir Expediente";
            this.buttonAddExpediente.UseVisualStyleBackColor = true;
            this.buttonAddExpediente.Click += new System.EventHandler(this.buttonAddExpediente_Click);
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
            this.tabPageContactos.Size = new System.Drawing.Size(658, 308);
            this.tabPageContactos.TabIndex = 1;
            this.tabPageContactos.Text = "Contactos";
            this.tabPageContactos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewContactos
            // 
            this.dataGridViewContactos.AllowUserToAddRows = false;
            this.dataGridViewContactos.AllowUserToDeleteRows = false;
            this.dataGridViewContactos.AllowUserToResizeRows = false;
            this.dataGridViewContactos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContactos.Location = new System.Drawing.Point(9, 39);
            this.dataGridViewContactos.Name = "dataGridViewContactos";
            this.dataGridViewContactos.ReadOnly = true;
            this.dataGridViewContactos.RowHeadersVisible = false;
            this.dataGridViewContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContactos.Size = new System.Drawing.Size(643, 253);
            this.dataGridViewContactos.TabIndex = 0;
            this.dataGridViewContactos.TabStop = false;
            this.dataGridViewContactos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContactos_CellDoubleClick);
            this.dataGridViewContactos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewContactos_MouseClick);
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
            // buttonEnviarMail
            // 
            this.buttonEnviarMail.Location = new System.Drawing.Point(555, 10);
            this.buttonEnviarMail.Name = "buttonEnviarMail";
            this.buttonEnviarMail.Size = new System.Drawing.Size(97, 23);
            this.buttonEnviarMail.TabIndex = 25;
            this.buttonEnviarMail.Text = "Enviar Correo";
            this.buttonEnviarMail.UseVisualStyleBackColor = true;
            this.buttonEnviarMail.Click += new System.EventHandler(this.buttonEnviarMail_Click);
            // 
            // buttonAddContacto
            // 
            this.buttonAddContacto.Location = new System.Drawing.Point(452, 10);
            this.buttonAddContacto.Name = "buttonAddContacto";
            this.buttonAddContacto.Size = new System.Drawing.Size(97, 23);
            this.buttonAddContacto.TabIndex = 24;
            this.buttonAddContacto.Text = "Añadir Contacto";
            this.buttonAddContacto.UseVisualStyleBackColor = true;
            this.buttonAddContacto.Click += new System.EventHandler(this.buttonAddContacto_Click);
            // 
            // tabPagSeguimientos
            // 
            this.tabPagSeguimientos.Controls.Add(this.buttonTodosSeguimientos);
            this.tabPagSeguimientos.Controls.Add(this.label5);
            this.tabPagSeguimientos.Controls.Add(this.dataGridViewSeguimientos);
            this.tabPagSeguimientos.Controls.Add(this.buttonAddSeguimiento);
            this.tabPagSeguimientos.Location = new System.Drawing.Point(4, 22);
            this.tabPagSeguimientos.Name = "tabPagSeguimientos";
            this.tabPagSeguimientos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagSeguimientos.Size = new System.Drawing.Size(658, 308);
            this.tabPagSeguimientos.TabIndex = 0;
            this.tabPagSeguimientos.Text = "Seguimientos";
            this.tabPagSeguimientos.UseVisualStyleBackColor = true;
            // 
            // buttonAddSeguimiento
            // 
            this.buttonAddSeguimiento.Location = new System.Drawing.Point(537, 11);
            this.buttonAddSeguimiento.Name = "buttonAddSeguimiento";
            this.buttonAddSeguimiento.Size = new System.Drawing.Size(115, 23);
            this.buttonAddSeguimiento.TabIndex = 21;
            this.buttonAddSeguimiento.Text = "Añadir Seguimiento";
            this.buttonAddSeguimiento.UseVisualStyleBackColor = true;
            this.buttonAddSeguimiento.Click += new System.EventHandler(this.buttonAddSeguimiento_Click);
            // 
            // dataGridViewSeguimientos
            // 
            this.dataGridViewSeguimientos.AllowUserToAddRows = false;
            this.dataGridViewSeguimientos.AllowUserToDeleteRows = false;
            this.dataGridViewSeguimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeguimientos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewSeguimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeguimientos.Location = new System.Drawing.Point(9, 39);
            this.dataGridViewSeguimientos.Name = "dataGridViewSeguimientos";
            this.dataGridViewSeguimientos.ReadOnly = true;
            this.dataGridViewSeguimientos.RowHeadersVisible = false;
            this.dataGridViewSeguimientos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewSeguimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSeguimientos.Size = new System.Drawing.Size(643, 252);
            this.dataGridViewSeguimientos.TabIndex = 20;
            this.dataGridViewSeguimientos.TabStop = false;
            this.dataGridViewSeguimientos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeguimientos_CellDoubleClick);
            this.dataGridViewSeguimientos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewSeguimientos_MouseClick);
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
            // buttonTodosSeguimientos
            // 
            this.buttonTodosSeguimientos.Location = new System.Drawing.Point(403, 11);
            this.buttonTodosSeguimientos.Name = "buttonTodosSeguimientos";
            this.buttonTodosSeguimientos.Size = new System.Drawing.Size(128, 23);
            this.buttonTodosSeguimientos.TabIndex = 20;
            this.buttonTodosSeguimientos.Text = "Todos los Seguimientos";
            this.buttonTodosSeguimientos.UseVisualStyleBackColor = true;
            this.buttonTodosSeguimientos.Click += new System.EventHandler(this.buttonTodosSeguimientos_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagSeguimientos);
            this.tabControl1.Controls.Add(this.tabPageContactos);
            this.tabControl1.Controls.Add(this.tabPageExpedientes);
            this.tabControl1.Location = new System.Drawing.Point(581, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(666, 334);
            this.tabControl1.TabIndex = 19;
            // 
            // FormVerTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 604);
            this.Controls.Add(this.buttonSugerenciaDesc);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBoxSugerencia);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBoxServicio);
            this.Controls.Add(this.buttonSelDivision);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxDivision);
            this.Controls.Add(this.buttonSelServicio);
            this.Controls.Add(this.textBoxIdTareaNuevo);
            this.Controls.Add(this.buttonDuplicarTarea);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxBloque);
            this.Controls.Add(this.buttonBloque);
            this.Controls.Add(this.comboBoxEstadoGestion);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxTareaNueva);
            this.Controls.Add(this.checkBoxImportante);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonEliminarTarea);
            this.Controls.Add(this.buttonCerrarGestion);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.maskedTextBoxReferencia);
            this.Controls.Add(this.textBoxEntidad);
            this.Controls.Add(this.buttonRuta);
            this.Controls.Add(this.buttonAddGestion);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelRutaLink);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewGestiones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTipo);
            this.Controls.Add(this.maskedTextBoxFechaActa);
            this.Controls.Add(this.checkBoxProxJunta);
            this.Controls.Add(this.checkBoxAcuerdoJunta);
            this.Controls.Add(this.textBoxSiniestro);
            this.Controls.Add(this.textBoxCoste);
            this.Controls.Add(this.maskedTextBoxFIni);
            this.Controls.Add(this.maskedTextBoxFFin);
            this.Controls.Add(this.textBoxRuta);
            this.Controls.Add(this.textBoxNotas);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.textBoxIdTarea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerTarea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Tarea";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVerTarea_FormClosing);
            this.Load += new System.EventHandler(this.FormVerTarea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGestiones)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCargos1)).EndInit();
            this.contextMenuStrip5.ResumeLayout(false);
            this.tabPageExpedientes.ResumeLayout(false);
            this.tabPageExpedientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpedientes)).EndInit();
            this.tabPageContactos.ResumeLayout(false);
            this.tabPageContactos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContactos)).EndInit();
            this.tabPagSeguimientos.ResumeLayout(false);
            this.tabPagSeguimientos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeguimientos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxIdTarea;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.TextBox textBoxNotas;
        private System.Windows.Forms.TextBox textBoxRuta;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxFFin;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxFIni;
        private System.Windows.Forms.TextBox textBoxSiniestro;
        private System.Windows.Forms.CheckBox checkBoxAcuerdoJunta;
        private System.Windows.Forms.CheckBox checkBoxProxJunta;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxFechaActa;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewGestiones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelRutaLink;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonAddGestion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEliminarGestion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEliminarSeguimiento;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditarGestion;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditarSeguimiento;
        private System.Windows.Forms.Button buttonRuta;
        private System.Windows.Forms.TextBox textBoxEntidad;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxReferencia;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditarContacto;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEliminarContacto;
        private System.Windows.Forms.Button buttonCerrarGestion;
        private System.Windows.Forms.Button buttonEliminarTarea;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxCoste;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBoxImportante;
        private System.Windows.Forms.TextBox textBoxTareaNueva;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemInfoEntidad;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddSeguimiento;
        private ComunidadesForms.CargosForms.Informes.DataSetCargos dataSetCargos1;
        private System.Windows.Forms.ComboBox comboBoxEstadoGestion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip5;
        private System.Windows.Forms.ToolStripMenuItem borrarExpedienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopiarPortapapelesContacto;
        private System.Windows.Forms.Button buttonBloque;
        private System.Windows.Forms.TextBox textBoxBloque;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonDuplicarTarea;
        private System.Windows.Forms.TextBox textBoxIdTareaNuevo;
        private System.Windows.Forms.ToolStripMenuItem enviarCorreoToolStripMenuItem;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxDivision;
        private System.Windows.Forms.Button buttonSelServicio;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button buttonSelDivision;
        private System.Windows.Forms.TextBox textBoxServicio;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxSugerencia;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button buttonSugerenciaDesc;
        private System.Windows.Forms.TabPage tabPageExpedientes;
        private System.Windows.Forms.Button buttonAddExpediente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewExpedientes;
        private System.Windows.Forms.TabPage tabPageContactos;
        private System.Windows.Forms.Button buttonAddContacto;
        private System.Windows.Forms.Button buttonEnviarMail;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dataGridViewContactos;
        private System.Windows.Forms.TabPage tabPagSeguimientos;
        private System.Windows.Forms.Button buttonTodosSeguimientos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewSeguimientos;
        private System.Windows.Forms.Button buttonAddSeguimiento;
        private System.Windows.Forms.TabControl tabControl1;
    }
}