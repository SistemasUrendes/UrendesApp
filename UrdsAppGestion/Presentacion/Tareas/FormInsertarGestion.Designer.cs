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
            this.buttonEntidad = new System.Windows.Forms.Button();
            this.comboBoxTipoGestion = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonAgenda5 = new System.Windows.Forms.Button();
            this.buttonLimite5 = new System.Windows.Forms.Button();
            this.buttonAgenda15 = new System.Windows.Forms.Button();
            this.buttonLimite15 = new System.Windows.Forms.Button();
            this.buttonAgenda30 = new System.Windows.Forms.Button();
            this.buttonLimite30 = new System.Windows.Forms.Button();
            this.buttonInicio5 = new System.Windows.Forms.Button();
            this.buttonInicio15 = new System.Windows.Forms.Button();
            this.buttonInicio30 = new System.Windows.Forms.Button();
            this.buttonFinNow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskedTextBoxFInicio
            // 
            this.maskedTextBoxFInicio.Location = new System.Drawing.Point(88, 190);
            this.maskedTextBoxFInicio.Mask = "00/00/0000";
            this.maskedTextBoxFInicio.Name = "maskedTextBoxFInicio";
            this.maskedTextBoxFInicio.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBoxFInicio.TabIndex = 7;
            this.maskedTextBoxFInicio.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFInicio.Leave += new System.EventHandler(this.maskedTextBoxFInicio_Leave);
            // 
            // maskedTextBoxFSeguir
            // 
            this.maskedTextBoxFSeguir.Location = new System.Drawing.Point(88, 215);
            this.maskedTextBoxFSeguir.Mask = "00/00/0000";
            this.maskedTextBoxFSeguir.Name = "maskedTextBoxFSeguir";
            this.maskedTextBoxFSeguir.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBoxFSeguir.TabIndex = 8;
            this.maskedTextBoxFSeguir.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFSeguir.Leave += new System.EventHandler(this.maskedTextBoxFSeguir_Leave);
            // 
            // maskedTextBoxFFin
            // 
            this.maskedTextBoxFFin.Location = new System.Drawing.Point(88, 266);
            this.maskedTextBoxFFin.Mask = "00/00/0000";
            this.maskedTextBoxFFin.Name = "maskedTextBoxFFin";
            this.maskedTextBoxFFin.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBoxFFin.TabIndex = 10;
            this.maskedTextBoxFFin.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFFin.Leave += new System.EventHandler(this.maskedTextBoxFFin_Leave);
            // 
            // maskedTextBoxFMax
            // 
            this.maskedTextBoxFMax.Location = new System.Drawing.Point(88, 241);
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
            this.label2.Location = new System.Drawing.Point(13, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha Inicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha Límite:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha Agenda:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha Fin:";
            // 
            // checkBoxImportante
            // 
            this.checkBoxImportante.AutoSize = true;
            this.checkBoxImportante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxImportante.Location = new System.Drawing.Point(20, 139);
            this.checkBoxImportante.Name = "checkBoxImportante";
            this.checkBoxImportante.Size = new System.Drawing.Size(79, 17);
            this.checkBoxImportante.TabIndex = 5;
            this.checkBoxImportante.Text = "Importante:";
            this.checkBoxImportante.UseVisualStyleBackColor = true;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(108, 303);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 11;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(198, 303);
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
            this.textBoxEspera.Location = new System.Drawing.Point(87, 113);
            this.textBoxEspera.Name = "textBoxEspera";
            this.textBoxEspera.ReadOnly = true;
            this.textBoxEspera.Size = new System.Drawing.Size(158, 20);
            this.textBoxEspera.TabIndex = 3;
            this.textBoxEspera.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "En espera de:";
            // 
            // buttonEntidad
            // 
            this.buttonEntidad.Location = new System.Drawing.Point(247, 113);
            this.buttonEntidad.Name = "buttonEntidad";
            this.buttonEntidad.Size = new System.Drawing.Size(25, 20);
            this.buttonEntidad.TabIndex = 4;
            this.buttonEntidad.Text = "E";
            this.buttonEntidad.UseVisualStyleBackColor = true;
            this.buttonEntidad.Click += new System.EventHandler(this.buttonEntidad_Click);
            // 
            // comboBoxTipoGestion
            // 
            this.comboBoxTipoGestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoGestion.FormattingEnabled = true;
            this.comboBoxTipoGestion.Location = new System.Drawing.Point(88, 163);
            this.comboBoxTipoGestion.Name = "comboBoxTipoGestion";
            this.comboBoxTipoGestion.Size = new System.Drawing.Size(157, 21);
            this.comboBoxTipoGestion.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tipo Gestión:";
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(24, 303);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(75, 23);
            this.buttonEditar.TabIndex = 22;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonAgenda5
            // 
            this.buttonAgenda5.Location = new System.Drawing.Point(164, 215);
            this.buttonAgenda5.Name = "buttonAgenda5";
            this.buttonAgenda5.Size = new System.Drawing.Size(29, 20);
            this.buttonAgenda5.TabIndex = 23;
            this.buttonAgenda5.Text = "5";
            this.buttonAgenda5.UseVisualStyleBackColor = true;
            this.buttonAgenda5.Click += new System.EventHandler(this.buttonAgenda5_Click);
            // 
            // buttonLimite5
            // 
            this.buttonLimite5.Location = new System.Drawing.Point(164, 241);
            this.buttonLimite5.Name = "buttonLimite5";
            this.buttonLimite5.Size = new System.Drawing.Size(29, 20);
            this.buttonLimite5.TabIndex = 25;
            this.buttonLimite5.Text = "5";
            this.buttonLimite5.UseVisualStyleBackColor = true;
            this.buttonLimite5.Click += new System.EventHandler(this.buttonLimite5_Click);
            // 
            // buttonAgenda15
            // 
            this.buttonAgenda15.Location = new System.Drawing.Point(198, 215);
            this.buttonAgenda15.Name = "buttonAgenda15";
            this.buttonAgenda15.Size = new System.Drawing.Size(36, 20);
            this.buttonAgenda15.TabIndex = 28;
            this.buttonAgenda15.Text = "15";
            this.buttonAgenda15.UseVisualStyleBackColor = true;
            this.buttonAgenda15.Click += new System.EventHandler(this.buttonAgenda15_Click);
            // 
            // buttonLimite15
            // 
            this.buttonLimite15.Location = new System.Drawing.Point(198, 241);
            this.buttonLimite15.Name = "buttonLimite15";
            this.buttonLimite15.Size = new System.Drawing.Size(36, 20);
            this.buttonLimite15.TabIndex = 29;
            this.buttonLimite15.Text = "15";
            this.buttonLimite15.UseVisualStyleBackColor = true;
            this.buttonLimite15.Click += new System.EventHandler(this.buttonLimite15_Click);
            // 
            // buttonAgenda30
            // 
            this.buttonAgenda30.Location = new System.Drawing.Point(236, 215);
            this.buttonAgenda30.Name = "buttonAgenda30";
            this.buttonAgenda30.Size = new System.Drawing.Size(36, 20);
            this.buttonAgenda30.TabIndex = 32;
            this.buttonAgenda30.Text = "30";
            this.buttonAgenda30.UseVisualStyleBackColor = true;
            this.buttonAgenda30.Click += new System.EventHandler(this.buttonAgenda30_Click);
            // 
            // buttonLimite30
            // 
            this.buttonLimite30.Location = new System.Drawing.Point(236, 241);
            this.buttonLimite30.Name = "buttonLimite30";
            this.buttonLimite30.Size = new System.Drawing.Size(36, 20);
            this.buttonLimite30.TabIndex = 33;
            this.buttonLimite30.Text = "30";
            this.buttonLimite30.UseVisualStyleBackColor = true;
            this.buttonLimite30.Click += new System.EventHandler(this.buttonLimite30_Click);
            // 
            // buttonInicio5
            // 
            this.buttonInicio5.Location = new System.Drawing.Point(164, 190);
            this.buttonInicio5.Name = "buttonInicio5";
            this.buttonInicio5.Size = new System.Drawing.Size(29, 20);
            this.buttonInicio5.TabIndex = 24;
            this.buttonInicio5.Text = "5";
            this.buttonInicio5.UseVisualStyleBackColor = true;
            this.buttonInicio5.Click += new System.EventHandler(this.buttonInicio5_Click);
            // 
            // buttonInicio15
            // 
            this.buttonInicio15.Location = new System.Drawing.Point(198, 190);
            this.buttonInicio15.Name = "buttonInicio15";
            this.buttonInicio15.Size = new System.Drawing.Size(36, 20);
            this.buttonInicio15.TabIndex = 27;
            this.buttonInicio15.Text = "15";
            this.buttonInicio15.UseVisualStyleBackColor = true;
            this.buttonInicio15.Click += new System.EventHandler(this.buttonInicio15_Click);
            // 
            // buttonInicio30
            // 
            this.buttonInicio30.Location = new System.Drawing.Point(236, 190);
            this.buttonInicio30.Name = "buttonInicio30";
            this.buttonInicio30.Size = new System.Drawing.Size(36, 20);
            this.buttonInicio30.TabIndex = 31;
            this.buttonInicio30.Text = "30";
            this.buttonInicio30.UseVisualStyleBackColor = true;
            this.buttonInicio30.Click += new System.EventHandler(this.buttonInicio30_Click);
            // 
            // buttonFinNow
            // 
            this.buttonFinNow.Location = new System.Drawing.Point(164, 266);
            this.buttonFinNow.Name = "buttonFinNow";
            this.buttonFinNow.Size = new System.Drawing.Size(108, 20);
            this.buttonFinNow.TabIndex = 34;
            this.buttonFinNow.Text = "Hoy";
            this.buttonFinNow.UseVisualStyleBackColor = true;
            this.buttonFinNow.Click += new System.EventHandler(this.buttonFinNow_Click);
            // 
            // FormInsertarGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 342);
            this.Controls.Add(this.buttonFinNow);
            this.Controls.Add(this.buttonLimite30);
            this.Controls.Add(this.buttonAgenda30);
            this.Controls.Add(this.buttonInicio30);
            this.Controls.Add(this.buttonLimite15);
            this.Controls.Add(this.buttonAgenda15);
            this.Controls.Add(this.buttonInicio15);
            this.Controls.Add(this.buttonLimite5);
            this.Controls.Add(this.buttonInicio5);
            this.Controls.Add(this.buttonAgenda5);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxTipoGestion);
            this.Controls.Add(this.buttonEntidad);
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
            this.Text = "FormInsertarGestion";
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
        private System.Windows.Forms.Button buttonEntidad;
        private System.Windows.Forms.ComboBox comboBoxTipoGestion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonAgenda5;
        private System.Windows.Forms.Button buttonLimite5;
        private System.Windows.Forms.Button buttonAgenda15;
        private System.Windows.Forms.Button buttonLimite15;
        private System.Windows.Forms.Button buttonAgenda30;
        private System.Windows.Forms.Button buttonLimite30;
        private System.Windows.Forms.Button buttonInicio5;
        private System.Windows.Forms.Button buttonInicio15;
        private System.Windows.Forms.Button buttonInicio30;
        private System.Windows.Forms.Button buttonFinNow;
    }
}