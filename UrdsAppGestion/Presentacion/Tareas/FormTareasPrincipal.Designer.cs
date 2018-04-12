namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormTareasPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTareasPrincipal));
            this.dataGridView_tareas = new System.Windows.Forms.DataGridView();
            this.comboBox_Tipo = new System.Windows.Forms.ComboBox();
            this.textBox_Entidad = new System.Windows.Forms.TextBox();
            this.comboBox_Estado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemBorrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxFiltro = new System.Windows.Forms.ToolStripTextBox();
            this.buttonNuevaTarea = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBoxRefComunidad = new System.Windows.Forms.MaskedTextBox();
            this.buttonGrupo = new System.Windows.Forms.Button();
            this.checkBoxProxJunta = new System.Windows.Forms.CheckBox();
            this.checkBoxSeguro = new System.Windows.Forms.CheckBox();
            this.textBoxTarea = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxInformes = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.checkBoxImportante = new System.Windows.Forms.CheckBox();
            this.maskedTextBox_FIni2 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox_FIni1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_FFin2 = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.maskedTextBox_FFin1 = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxAdmComunidad = new System.Windows.Forms.ComboBox();
            this.checkBoxAcuerdoJunta = new System.Windows.Forms.CheckBox();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.button_enviar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tareas)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_tareas
            // 
            this.dataGridView_tareas.AllowUserToAddRows = false;
            this.dataGridView_tareas.AllowUserToDeleteRows = false;
            this.dataGridView_tareas.AllowUserToOrderColumns = true;
            this.dataGridView_tareas.AllowUserToResizeRows = false;
            this.dataGridView_tareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tareas.Location = new System.Drawing.Point(6, 101);
            this.dataGridView_tareas.Name = "dataGridView_tareas";
            this.dataGridView_tareas.ReadOnly = true;
            this.dataGridView_tareas.RowHeadersVisible = false;
            this.dataGridView_tareas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_tareas.Size = new System.Drawing.Size(1134, 546);
            this.dataGridView_tareas.TabIndex = 0;
            this.dataGridView_tareas.TabStop = false;
            this.dataGridView_tareas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_tareas_CellDoubleClick);
            this.dataGridView_tareas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_tareas_MouseClick);
            // 
            // comboBox_Tipo
            // 
            this.comboBox_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo.FormattingEnabled = true;
            this.comboBox_Tipo.Location = new System.Drawing.Point(928, 9);
            this.comboBox_Tipo.Name = "comboBox_Tipo";
            this.comboBox_Tipo.Size = new System.Drawing.Size(101, 21);
            this.comboBox_Tipo.TabIndex = 6;
            // 
            // textBox_Entidad
            // 
            this.textBox_Entidad.Location = new System.Drawing.Point(583, 11);
            this.textBox_Entidad.Name = "textBox_Entidad";
            this.textBox_Entidad.Size = new System.Drawing.Size(253, 20);
            this.textBox_Entidad.TabIndex = 3;
            this.textBox_Entidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Entidad_KeyPress);
            // 
            // comboBox_Estado
            // 
            this.comboBox_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Estado.FormattingEnabled = true;
            this.comboBox_Estado.Location = new System.Drawing.Point(928, 38);
            this.comboBox_Estado.Name = "comboBox_Estado";
            this.comboBox_Estado.Size = new System.Drawing.Size(101, 21);
            this.comboBox_Estado.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(537, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Entidad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(880, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(891, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "&Tipo:";
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Location = new System.Drawing.Point(1056, 6);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(84, 25);
            this.button_Filtrar.TabIndex = 9;
            this.button_Filtrar.Text = "Filtrar";
            this.button_Filtrar.UseVisualStyleBackColor = true;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBorrar,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripTextBoxFiltro});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 79);
            // 
            // toolStripMenuItemBorrar
            // 
            this.toolStripMenuItemBorrar.Name = "toolStripMenuItemBorrar";
            this.toolStripMenuItemBorrar.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemBorrar.Text = "Borrar";
            this.toolStripMenuItemBorrar.Click += new System.EventHandler(this.toolStripMenuItemBorrar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
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
            // buttonNuevaTarea
            // 
            this.buttonNuevaTarea.Location = new System.Drawing.Point(6, 65);
            this.buttonNuevaTarea.Name = "buttonNuevaTarea";
            this.buttonNuevaTarea.Size = new System.Drawing.Size(75, 23);
            this.buttonNuevaTarea.TabIndex = 10;
            this.buttonNuevaTarea.Text = "Nueva";
            this.buttonNuevaTarea.UseVisualStyleBackColor = true;
            this.buttonNuevaTarea.Click += new System.EventHandler(this.buttonNuevaTarea_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(431, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Comunidad:";
            // 
            // maskedTextBoxRefComunidad
            // 
            this.maskedTextBoxRefComunidad.Location = new System.Drawing.Point(500, 10);
            this.maskedTextBoxRefComunidad.Mask = "999";
            this.maskedTextBoxRefComunidad.Name = "maskedTextBoxRefComunidad";
            this.maskedTextBoxRefComunidad.Size = new System.Drawing.Size(31, 20);
            this.maskedTextBoxRefComunidad.TabIndex = 2;
            this.maskedTextBoxRefComunidad.ValidatingType = typeof(int);
            this.maskedTextBoxRefComunidad.DoubleClick += new System.EventHandler(this.maskedTextBoxRefComunidad_DoubleClick);
            this.maskedTextBoxRefComunidad.Leave += new System.EventHandler(this.maskedTextBoxRefComunidad_Leave);
            // 
            // buttonGrupo
            // 
            this.buttonGrupo.Location = new System.Drawing.Point(6, 39);
            this.buttonGrupo.Name = "buttonGrupo";
            this.buttonGrupo.Size = new System.Drawing.Size(100, 23);
            this.buttonGrupo.TabIndex = 11;
            this.buttonGrupo.Text = "Añadir Grupo";
            this.buttonGrupo.UseVisualStyleBackColor = true;
            this.buttonGrupo.Visible = false;
            this.buttonGrupo.Click += new System.EventHandler(this.buttonGrupo_Click);
            // 
            // checkBoxProxJunta
            // 
            this.checkBoxProxJunta.AutoSize = true;
            this.checkBoxProxJunta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxProxJunta.Location = new System.Drawing.Point(754, 71);
            this.checkBoxProxJunta.Name = "checkBoxProxJunta";
            this.checkBoxProxJunta.Size = new System.Drawing.Size(82, 17);
            this.checkBoxProxJunta.TabIndex = 7;
            this.checkBoxProxJunta.Text = "&Prox. Junta:";
            this.checkBoxProxJunta.UseVisualStyleBackColor = true;
            // 
            // checkBoxSeguro
            // 
            this.checkBoxSeguro.AutoSize = true;
            this.checkBoxSeguro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxSeguro.Location = new System.Drawing.Point(773, 43);
            this.checkBoxSeguro.Name = "checkBoxSeguro";
            this.checkBoxSeguro.Size = new System.Drawing.Size(63, 17);
            this.checkBoxSeguro.TabIndex = 8;
            this.checkBoxSeguro.Text = "Seguro:";
            this.checkBoxSeguro.UseVisualStyleBackColor = true;
            // 
            // textBoxTarea
            // 
            this.textBoxTarea.Location = new System.Drawing.Point(146, 67);
            this.textBoxTarea.Name = "textBoxTarea";
            this.textBoxTarea.Size = new System.Drawing.Size(43, 20);
            this.textBoxTarea.TabIndex = 1;
            this.textBoxTarea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTarea_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "IdTarea:";
            // 
            // comboBoxInformes
            // 
            this.comboBoxInformes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInformes.FormattingEnabled = true;
            this.comboBoxInformes.Items.AddRange(new object[] {
            "En Seguimiento"});
            this.comboBoxInformes.Location = new System.Drawing.Point(68, 10);
            this.comboBoxInformes.Name = "comboBoxInformes";
            this.comboBoxInformes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInformes.TabIndex = 23;
            this.comboBoxInformes.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Informes:";
            this.label9.Visible = false;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(1056, 36);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(84, 23);
            this.buttonReset.TabIndex = 27;
            this.buttonReset.Text = "Limpiar";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // checkBoxImportante
            // 
            this.checkBoxImportante.AutoSize = true;
            this.checkBoxImportante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxImportante.Location = new System.Drawing.Point(669, 71);
            this.checkBoxImportante.Name = "checkBoxImportante";
            this.checkBoxImportante.Size = new System.Drawing.Size(79, 17);
            this.checkBoxImportante.TabIndex = 32;
            this.checkBoxImportante.Text = "&Importante:";
            this.checkBoxImportante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxImportante.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox_FIni2
            // 
            this.maskedTextBox_FIni2.Location = new System.Drawing.Point(577, 41);
            this.maskedTextBox_FIni2.Mask = "00/00/0000";
            this.maskedTextBox_FIni2.Name = "maskedTextBox_FIni2";
            this.maskedTextBox_FIni2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FIni2.TabIndex = 34;
            this.maskedTextBox_FIni2.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(447, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "F. Inicio:";
            // 
            // maskedTextBox_FIni1
            // 
            this.maskedTextBox_FIni1.Location = new System.Drawing.Point(500, 41);
            this.maskedTextBox_FIni1.Mask = "00/00/0000";
            this.maskedTextBox_FIni1.Name = "maskedTextBox_FIni1";
            this.maskedTextBox_FIni1.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FIni1.TabIndex = 33;
            this.maskedTextBox_FIni1.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox_FFin2
            // 
            this.maskedTextBox_FFin2.Location = new System.Drawing.Point(577, 69);
            this.maskedTextBox_FFin2.Mask = "00/00/0000";
            this.maskedTextBox_FFin2.Name = "maskedTextBox_FFin2";
            this.maskedTextBox_FFin2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FFin2.TabIndex = 36;
            this.maskedTextBox_FFin2.ValidatingType = typeof(System.DateTime);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(458, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "F. Fin:";
            // 
            // maskedTextBox_FFin1
            // 
            this.maskedTextBox_FFin1.Location = new System.Drawing.Point(499, 69);
            this.maskedTextBox_FFin1.Mask = "00/00/0000";
            this.maskedTextBox_FFin1.Name = "maskedTextBox_FFin1";
            this.maskedTextBox_FFin1.Size = new System.Drawing.Size(72, 20);
            this.maskedTextBox_FFin1.TabIndex = 35;
            this.maskedTextBox_FFin1.ValidatingType = typeof(System.DateTime);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(882, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "Gestor:";
            // 
            // comboBoxAdmComunidad
            // 
            this.comboBoxAdmComunidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdmComunidad.FormattingEnabled = true;
            this.comboBoxAdmComunidad.Location = new System.Drawing.Point(928, 68);
            this.comboBoxAdmComunidad.Name = "comboBoxAdmComunidad";
            this.comboBoxAdmComunidad.Size = new System.Drawing.Size(101, 21);
            this.comboBoxAdmComunidad.TabIndex = 41;
            // 
            // checkBoxAcuerdoJunta
            // 
            this.checkBoxAcuerdoJunta.AutoSize = true;
            this.checkBoxAcuerdoJunta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAcuerdoJunta.Location = new System.Drawing.Point(679, 43);
            this.checkBoxAcuerdoJunta.Name = "checkBoxAcuerdoJunta";
            this.checkBoxAcuerdoJunta.Size = new System.Drawing.Size(69, 17);
            this.checkBoxAcuerdoJunta.TabIndex = 43;
            this.checkBoxAcuerdoJunta.Text = "&Acuerdo:";
            this.checkBoxAcuerdoJunta.UseVisualStyleBackColor = true;
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Location = new System.Drawing.Point(1056, 66);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(84, 23);
            this.buttonImprimir.TabIndex = 44;
            this.buttonImprimir.Text = "Imprimir";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // button_enviar
            // 
            this.button_enviar.Location = new System.Drawing.Point(271, 65);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(75, 23);
            this.button_enviar.TabIndex = 45;
            this.button_enviar.Text = "Enviar";
            this.button_enviar.UseMnemonic = false;
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Visible = false;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // FormTareasPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 665);
            this.ControlBox = false;
            this.Controls.Add(this.button_enviar);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.checkBoxAcuerdoJunta);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxAdmComunidad);
            this.Controls.Add(this.maskedTextBox_FIni2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBox_FIni1);
            this.Controls.Add(this.maskedTextBox_FFin2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.maskedTextBox_FFin1);
            this.Controls.Add(this.checkBoxImportante);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxInformes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxTarea);
            this.Controls.Add(this.checkBoxSeguro);
            this.Controls.Add(this.checkBoxProxJunta);
            this.Controls.Add(this.buttonGrupo);
            this.Controls.Add(this.maskedTextBoxRefComunidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonNuevaTarea);
            this.Controls.Add(this.button_Filtrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Estado);
            this.Controls.Add(this.textBox_Entidad);
            this.Controls.Add(this.comboBox_Tipo);
            this.Controls.Add(this.dataGridView_tareas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTareasPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tareas";
            this.Load += new System.EventHandler(this.FormTareasPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tareas)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_tareas;
        private System.Windows.Forms.ComboBox comboBox_Tipo;
        private System.Windows.Forms.TextBox textBox_Entidad;
        private System.Windows.Forms.ComboBox comboBox_Estado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Filtrar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFiltro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button buttonNuevaTarea;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBorrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxRefComunidad;
        private System.Windows.Forms.Button buttonGrupo;
        private System.Windows.Forms.CheckBox checkBoxProxJunta;
        private System.Windows.Forms.CheckBox checkBoxSeguro;
        private System.Windows.Forms.TextBox textBoxTarea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxInformes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.CheckBox checkBoxImportante;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FIni2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FIni1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FFin2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FFin1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxAdmComunidad;
        private System.Windows.Forms.CheckBox checkBoxAcuerdoJunta;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Button button_enviar;
    }
}