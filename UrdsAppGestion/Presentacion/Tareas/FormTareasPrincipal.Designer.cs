﻿namespace UrdsAppGestión.Presentacion.Tareas
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
            this.maskedTextBox_fin = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox_inicio = new System.Windows.Forms.MaskedTextBox();
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
            this.dataGridView_tareas.MultiSelect = false;
            this.dataGridView_tareas.Name = "dataGridView_tareas";
            this.dataGridView_tareas.ReadOnly = true;
            this.dataGridView_tareas.RowHeadersVisible = false;
            this.dataGridView_tareas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_tareas.Size = new System.Drawing.Size(1024, 546);
            this.dataGridView_tareas.TabIndex = 0;
            this.dataGridView_tareas.TabStop = false;
            this.dataGridView_tareas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_tareas_CellDoubleClick);
            this.dataGridView_tareas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_tareas_MouseClick);
            // 
            // comboBox_Tipo
            // 
            this.comboBox_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo.FormattingEnabled = true;
            this.comboBox_Tipo.Location = new System.Drawing.Point(801, 38);
            this.comboBox_Tipo.Name = "comboBox_Tipo";
            this.comboBox_Tipo.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Tipo.TabIndex = 6;
            // 
            // textBox_Entidad
            // 
            this.textBox_Entidad.Location = new System.Drawing.Point(679, 10);
            this.textBox_Entidad.Name = "textBox_Entidad";
            this.textBox_Entidad.Size = new System.Drawing.Size(243, 20);
            this.textBox_Entidad.TabIndex = 3;
            this.textBox_Entidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Entidad_KeyPress);
            // 
            // comboBox_Estado
            // 
            this.comboBox_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Estado.FormattingEnabled = true;
            this.comboBox_Estado.Location = new System.Drawing.Point(801, 67);
            this.comboBox_Estado.Name = "comboBox_Estado";
            this.comboBox_Estado.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Estado.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(633, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Entidad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(756, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(768, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo:";
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Location = new System.Drawing.Point(946, 17);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(84, 63);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 101);
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
            // maskedTextBox_fin
            // 
            this.maskedTextBox_fin.Location = new System.Drawing.Point(679, 39);
            this.maskedTextBox_fin.Mask = "00/00/0000";
            this.maskedTextBox_fin.Name = "maskedTextBox_fin";
            this.maskedTextBox_fin.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_fin.TabIndex = 5;
            this.maskedTextBox_fin.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(633, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(478, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Fecha desde:";
            // 
            // maskedTextBox_inicio
            // 
            this.maskedTextBox_inicio.Location = new System.Drawing.Point(556, 39);
            this.maskedTextBox_inicio.Mask = "00/00/0000";
            this.maskedTextBox_inicio.Name = "maskedTextBox_inicio";
            this.maskedTextBox_inicio.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_inicio.TabIndex = 4;
            this.maskedTextBox_inicio.ValidatingType = typeof(System.DateTime);
            // 
            // buttonNuevaTarea
            // 
            this.buttonNuevaTarea.Location = new System.Drawing.Point(6, 72);
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
            this.label6.Location = new System.Drawing.Point(487, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Comunidad:";
            // 
            // maskedTextBoxRefComunidad
            // 
            this.maskedTextBoxRefComunidad.Location = new System.Drawing.Point(556, 10);
            this.maskedTextBoxRefComunidad.Mask = "999";
            this.maskedTextBoxRefComunidad.Name = "maskedTextBoxRefComunidad";
            this.maskedTextBoxRefComunidad.Size = new System.Drawing.Size(45, 20);
            this.maskedTextBoxRefComunidad.TabIndex = 2;
            this.maskedTextBoxRefComunidad.ValidatingType = typeof(int);
            this.maskedTextBoxRefComunidad.Leave += new System.EventHandler(this.maskedTextBoxRefComunidad_Leave);
            // 
            // buttonGrupo
            // 
            this.buttonGrupo.Location = new System.Drawing.Point(87, 72);
            this.buttonGrupo.Name = "buttonGrupo";
            this.buttonGrupo.Size = new System.Drawing.Size(100, 23);
            this.buttonGrupo.TabIndex = 11;
            this.buttonGrupo.Text = "Añadir Grupo";
            this.buttonGrupo.UseVisualStyleBackColor = true;
            this.buttonGrupo.Click += new System.EventHandler(this.buttonGrupo_Click);
            // 
            // checkBoxProxJunta
            // 
            this.checkBoxProxJunta.AutoSize = true;
            this.checkBoxProxJunta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxProxJunta.Location = new System.Drawing.Point(490, 69);
            this.checkBoxProxJunta.Name = "checkBoxProxJunta";
            this.checkBoxProxJunta.Size = new System.Drawing.Size(82, 17);
            this.checkBoxProxJunta.TabIndex = 7;
            this.checkBoxProxJunta.Text = "Prox. Junta:";
            this.checkBoxProxJunta.UseVisualStyleBackColor = true;
            // 
            // checkBoxSeguro
            // 
            this.checkBoxSeguro.AutoSize = true;
            this.checkBoxSeguro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxSeguro.Location = new System.Drawing.Point(629, 69);
            this.checkBoxSeguro.Name = "checkBoxSeguro";
            this.checkBoxSeguro.Size = new System.Drawing.Size(63, 17);
            this.checkBoxSeguro.TabIndex = 8;
            this.checkBoxSeguro.Text = "Seguro:";
            this.checkBoxSeguro.UseVisualStyleBackColor = true;
            // 
            // textBoxTarea
            // 
            this.textBoxTarea.Location = new System.Drawing.Point(273, 75);
            this.textBoxTarea.Name = "textBoxTarea";
            this.textBoxTarea.Size = new System.Drawing.Size(100, 20);
            this.textBoxTarea.TabIndex = 1;
            this.textBoxTarea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTarea_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 78);
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
            this.comboBoxInformes.SelectionChangeCommitted += new System.EventHandler(this.comboBoxInformes_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Informes:";
            // 
            // FormTareasPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 665);
            this.ControlBox = false;
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
            this.Controls.Add(this.maskedTextBox_fin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBox_inicio);
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
        private System.Windows.Forms.MaskedTextBox maskedTextBox_fin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_inicio;
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
    }
}