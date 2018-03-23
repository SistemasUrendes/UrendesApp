﻿namespace UrdsAppGestión.Presentacion.Tareas
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
            this.comboBoxNivel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxEspera = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonEntidad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskedTextBoxFInicio
            // 
            this.maskedTextBoxFInicio.Location = new System.Drawing.Point(84, 188);
            this.maskedTextBoxFInicio.Mask = "00/00/0000";
            this.maskedTextBoxFInicio.Name = "maskedTextBoxFInicio";
            this.maskedTextBoxFInicio.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBoxFInicio.TabIndex = 7;
            this.maskedTextBoxFInicio.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFInicio.Leave += new System.EventHandler(this.maskedTextBoxFInicio_Leave);
            // 
            // maskedTextBoxFSeguir
            // 
            this.maskedTextBoxFSeguir.Location = new System.Drawing.Point(84, 240);
            this.maskedTextBoxFSeguir.Mask = "00/00/0000";
            this.maskedTextBoxFSeguir.Name = "maskedTextBoxFSeguir";
            this.maskedTextBoxFSeguir.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBoxFSeguir.TabIndex = 9;
            this.maskedTextBoxFSeguir.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFSeguir.Leave += new System.EventHandler(this.maskedTextBoxFSeguir_Leave);
            // 
            // maskedTextBoxFFin
            // 
            this.maskedTextBoxFFin.Location = new System.Drawing.Point(84, 266);
            this.maskedTextBoxFFin.Mask = "00/00/0000";
            this.maskedTextBoxFFin.Name = "maskedTextBoxFFin";
            this.maskedTextBoxFFin.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBoxFFin.TabIndex = 10;
            this.maskedTextBoxFFin.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFFin.Leave += new System.EventHandler(this.maskedTextBoxFFin_Leave);
            // 
            // maskedTextBoxFMax
            // 
            this.maskedTextBoxFMax.Location = new System.Drawing.Point(84, 214);
            this.maskedTextBoxFMax.Mask = "00/00/0000";
            this.maskedTextBoxFMax.Name = "maskedTextBoxFMax";
            this.maskedTextBoxFMax.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBoxFMax.TabIndex = 8;
            this.maskedTextBoxFMax.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxFMax.Leave += new System.EventHandler(this.maskedTextBoxFMax_Leave);
            // 
            // comboBoxUsuario
            // 
            this.comboBoxUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsuario.FormattingEnabled = true;
            this.comboBoxUsuario.Location = new System.Drawing.Point(83, 18);
            this.comboBoxUsuario.Name = "comboBoxUsuario";
            this.comboBoxUsuario.Size = new System.Drawing.Size(121, 21);
            this.comboBoxUsuario.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "FInicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "FMax:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "FSeguir:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "FFin:";
            // 
            // checkBoxImportante
            // 
            this.checkBoxImportante.AutoSize = true;
            this.checkBoxImportante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxImportante.Location = new System.Drawing.Point(18, 139);
            this.checkBoxImportante.Name = "checkBoxImportante";
            this.checkBoxImportante.Size = new System.Drawing.Size(79, 17);
            this.checkBoxImportante.TabIndex = 5;
            this.checkBoxImportante.Text = "Importante:";
            this.checkBoxImportante.UseVisualStyleBackColor = true;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(108, 301);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 11;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(198, 301);
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
            this.label6.Location = new System.Drawing.Point(11, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Descripción:";
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(83, 47);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(191, 60);
            this.textBoxDescripcion.TabIndex = 2;
            // 
            // comboBoxNivel
            // 
            this.comboBoxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNivel.FormattingEnabled = true;
            this.comboBoxNivel.Location = new System.Drawing.Point(84, 162);
            this.comboBoxNivel.Name = "comboBoxNivel";
            this.comboBoxNivel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNivel.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Nivel:";
            // 
            // textBoxEspera
            // 
            this.textBoxEspera.Location = new System.Drawing.Point(83, 113);
            this.textBoxEspera.Name = "textBoxEspera";
            this.textBoxEspera.ReadOnly = true;
            this.textBoxEspera.Size = new System.Drawing.Size(158, 20);
            this.textBoxEspera.TabIndex = 3;
            this.textBoxEspera.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 116);
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
            // FormInsertarGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 336);
            this.Controls.Add(this.buttonEntidad);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxEspera);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxNivel);
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
        private System.Windows.Forms.ComboBox comboBoxNivel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxEspera;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonEntidad;
    }
}