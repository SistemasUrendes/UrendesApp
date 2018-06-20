namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormInsertarGestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInsertarGestion));
            this.maskedTextBoxFInicio = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxFSeguir = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxFFin = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxFMax = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxImportante = new System.Windows.Forms.CheckBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.textBoxEspera = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxTipoGestion = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.comboBoxEspera = new System.Windows.Forms.ComboBox();
            this.buttonEspera = new System.Windows.Forms.Button();
            this.buttonFIni = new System.Windows.Forms.Button();
            this.buttonFAgenda = new System.Windows.Forms.Button();
            this.buttonFLimite = new System.Windows.Forms.Button();
            this.buttonFFin = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // maskedTextBoxFInicio
            // 
            this.maskedTextBoxFInicio.Location = new System.Drawing.Point(88, 205);
            this.maskedTextBoxFInicio.Mask = "00/00/0000";
            this.maskedTextBoxFInicio.Name = "maskedTextBoxFInicio";
            this.maskedTextBoxFInicio.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBoxFInicio.TabIndex = 7;
            this.maskedTextBoxFInicio.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFInicio.Leave += new System.EventHandler(this.maskedTextBoxFInicio_Leave);
            // 
            // maskedTextBoxFSeguir
            // 
            this.maskedTextBoxFSeguir.Location = new System.Drawing.Point(88, 240);
            this.maskedTextBoxFSeguir.Mask = "00/00/0000";
            this.maskedTextBoxFSeguir.Name = "maskedTextBoxFSeguir";
            this.maskedTextBoxFSeguir.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBoxFSeguir.TabIndex = 8;
            this.maskedTextBoxFSeguir.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFSeguir.Leave += new System.EventHandler(this.maskedTextBoxFSeguir_Leave);
            // 
            // maskedTextBoxFFin
            // 
            this.maskedTextBoxFFin.Location = new System.Drawing.Point(88, 310);
            this.maskedTextBoxFFin.Mask = "00/00/0000";
            this.maskedTextBoxFFin.Name = "maskedTextBoxFFin";
            this.maskedTextBoxFFin.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBoxFFin.TabIndex = 10;
            this.maskedTextBoxFFin.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFFin.Leave += new System.EventHandler(this.maskedTextBoxFFin_Leave);
            // 
            // maskedTextBoxFMax
            // 
            this.maskedTextBoxFMax.Location = new System.Drawing.Point(88, 275);
            this.maskedTextBoxFMax.Mask = "00/00/0000";
            this.maskedTextBoxFMax.Name = "maskedTextBoxFMax";
            this.maskedTextBoxFMax.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBoxFMax.TabIndex = 9;
            this.maskedTextBoxFMax.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFMax.Leave += new System.EventHandler(this.maskedTextBoxFMax_Leave);
            // 
            // comboBoxUsuario
            // 
            this.comboBoxUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuario.FormattingEnabled = true;
            this.comboBoxUsuario.Location = new System.Drawing.Point(87, 18);
            this.comboBoxUsuario.Name = "comboBoxUsuario";
            this.comboBoxUsuario.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUsuario.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha Inicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha Límite:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha Agenda:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha Fin:";
            // 
            // checkBoxImportante
            // 
            this.checkBoxImportante.AutoSize = true;
            this.checkBoxImportante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxImportante.Location = new System.Drawing.Point(267, 169);
            this.checkBoxImportante.Name = "checkBoxImportante";
            this.checkBoxImportante.Size = new System.Drawing.Size(79, 17);
            this.checkBoxImportante.TabIndex = 5;
            this.checkBoxImportante.Text = "Importante:";
            this.checkBoxImportante.UseVisualStyleBackColor = true;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(225, 362);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 11;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(315, 362);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 12;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Descripción:";
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(87, 47);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(191, 60);
            this.textBoxDescripcion.TabIndex = 2;
            // 
            // textBoxEspera
            // 
            this.textBoxEspera.Location = new System.Drawing.Point(87, 142);
            this.textBoxEspera.Name = "textBoxEspera";
            this.textBoxEspera.ReadOnly = true;
            this.textBoxEspera.Size = new System.Drawing.Size(191, 20);
            this.textBoxEspera.TabIndex = 3;
            this.textBoxEspera.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "En espera de:";
            // 
            // comboBoxTipoGestion
            // 
            this.comboBoxTipoGestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoGestion.FormattingEnabled = true;
            this.comboBoxTipoGestion.Location = new System.Drawing.Point(88, 167);
            this.comboBoxTipoGestion.Name = "comboBoxTipoGestion";
            this.comboBoxTipoGestion.Size = new System.Drawing.Size(157, 21);
            this.comboBoxTipoGestion.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tipo Gestión:";
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(141, 362);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(75, 23);
            this.buttonEditar.TabIndex = 22;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // comboBoxEspera
            // 
            this.comboBoxEspera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEspera.FormattingEnabled = true;
            this.comboBoxEspera.Items.AddRange(new object[] {
            "Entidades",
            "Comuneros",
            "Proveedores",
            "Cargos",
            "Contactos",
            "Grupo"});
            this.comboBoxEspera.Location = new System.Drawing.Point(87, 114);
            this.comboBoxEspera.Name = "comboBoxEspera";
            this.comboBoxEspera.Size = new System.Drawing.Size(158, 21);
            this.comboBoxEspera.TabIndex = 35;
            // 
            // buttonEspera
            // 
            this.buttonEspera.Location = new System.Drawing.Point(251, 113);
            this.buttonEspera.Name = "buttonEspera";
            this.buttonEspera.Size = new System.Drawing.Size(27, 22);
            this.buttonEspera.TabIndex = 36;
            this.buttonEspera.Text = ">";
            this.buttonEspera.UseVisualStyleBackColor = true;
            this.buttonEspera.Click += new System.EventHandler(this.buttonEspera_Click);
            // 
            // buttonFIni
            // 
            this.buttonFIni.Location = new System.Drawing.Point(163, 205);
            this.buttonFIni.Name = "buttonFIni";
            this.buttonFIni.Size = new System.Drawing.Size(27, 20);
            this.buttonFIni.TabIndex = 37;
            this.buttonFIni.Text = "<";
            this.buttonFIni.UseVisualStyleBackColor = true;
            this.buttonFIni.Click += new System.EventHandler(this.buttonFIni_Click);
            // 
            // buttonFAgenda
            // 
            this.buttonFAgenda.Location = new System.Drawing.Point(163, 240);
            this.buttonFAgenda.Name = "buttonFAgenda";
            this.buttonFAgenda.Size = new System.Drawing.Size(27, 20);
            this.buttonFAgenda.TabIndex = 38;
            this.buttonFAgenda.Text = "<";
            this.buttonFAgenda.UseVisualStyleBackColor = true;
            this.buttonFAgenda.Click += new System.EventHandler(this.buttonFAgenda_Click);
            // 
            // buttonFLimite
            // 
            this.buttonFLimite.Location = new System.Drawing.Point(163, 275);
            this.buttonFLimite.Name = "buttonFLimite";
            this.buttonFLimite.Size = new System.Drawing.Size(27, 20);
            this.buttonFLimite.TabIndex = 39;
            this.buttonFLimite.Text = "<";
            this.buttonFLimite.UseVisualStyleBackColor = true;
            this.buttonFLimite.Click += new System.EventHandler(this.buttonFLimite_Click);
            // 
            // buttonFFin
            // 
            this.buttonFFin.Location = new System.Drawing.Point(163, 310);
            this.buttonFFin.Name = "buttonFFin";
            this.buttonFFin.Size = new System.Drawing.Size(27, 20);
            this.buttonFFin.TabIndex = 40;
            this.buttonFFin.Text = "<";
            this.buttonFFin.UseVisualStyleBackColor = true;
            this.buttonFFin.Click += new System.EventHandler(this.buttonFFin_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(202, 194);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 41;
            // 
            // FormInsertarGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 397);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.buttonFFin);
            this.Controls.Add(this.buttonFLimite);
            this.Controls.Add(this.buttonFAgenda);
            this.Controls.Add(this.buttonFIni);
            this.Controls.Add(this.buttonEspera);
            this.Controls.Add(this.comboBoxEspera);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxTipoGestion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxEspera);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.checkBoxImportante);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxUsuario);
            this.Controls.Add(this.maskedTextBoxFMax);
            this.Controls.Add(this.maskedTextBoxFFin);
            this.Controls.Add(this.maskedTextBoxFSeguir);
            this.Controls.Add(this.maskedTextBoxFInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInsertarGestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion";
            this.Load += new System.EventHandler(this.FormInsertarGestion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBoxFInicio;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxFSeguir;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxFFin;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxFMax;
        private System.Windows.Forms.ComboBox comboBoxUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxImportante;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.TextBox textBoxEspera;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxTipoGestion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.ComboBox comboBoxEspera;
        private System.Windows.Forms.Button buttonEspera;
        private System.Windows.Forms.Button buttonFIni;
        private System.Windows.Forms.Button buttonFAgenda;
        private System.Windows.Forms.Button buttonFLimite;
        private System.Windows.Forms.Button buttonFFin;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}