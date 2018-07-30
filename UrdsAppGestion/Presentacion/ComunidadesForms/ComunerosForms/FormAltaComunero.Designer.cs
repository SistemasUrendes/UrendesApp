namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    partial class FormAltaComunero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAltaComunero));
            this.textBox_Entidad = new System.Windows.Forms.TextBox();
            this.comboBox_Direccion = new System.Windows.Forms.ComboBox();
            this.comboBox_Email = new System.Windows.Forms.ComboBox();
            this.checkBox_EMail = new System.Windows.Forms.CheckBox();
            this.checkBox_Postal = new System.Windows.Forms.CheckBox();
            this.comboBox_cc = new System.Windows.Forms.ComboBox();
            this.comboBox_FormadePago = new System.Windows.Forms.ComboBox();
            this.checkBox_Iva = new System.Windows.Forms.CheckBox();
            this.label_Entidad = new System.Windows.Forms.Label();
            this.label_Direccion = new System.Windows.Forms.Label();
            this.label_Email = new System.Windows.Forms.Label();
            this.label_FPago = new System.Windows.Forms.Label();
            this.label_IVA = new System.Windows.Forms.Label();
            this.label_Notas = new System.Windows.Forms.Label();
            this.textBox_Notas = new System.Windows.Forms.TextBox();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_copiaEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_Entidad
            // 
            this.textBox_Entidad.Location = new System.Drawing.Point(126, 40);
            this.textBox_Entidad.Name = "textBox_Entidad";
            this.textBox_Entidad.ReadOnly = true;
            this.textBox_Entidad.Size = new System.Drawing.Size(281, 20);
            this.textBox_Entidad.TabIndex = 0;
            this.textBox_Entidad.Text = "Pulsa espacio para buscar Entidad";
            this.textBox_Entidad.DoubleClick += new System.EventHandler(this.textBox_Entidad_DoubleClick);
            this.textBox_Entidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Entidad_KeyPress);
            // 
            // comboBox_Direccion
            // 
            this.comboBox_Direccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Direccion.FormattingEnabled = true;
            this.comboBox_Direccion.Location = new System.Drawing.Point(126, 66);
            this.comboBox_Direccion.Name = "comboBox_Direccion";
            this.comboBox_Direccion.Size = new System.Drawing.Size(157, 21);
            this.comboBox_Direccion.TabIndex = 1;
            // 
            // comboBox_Email
            // 
            this.comboBox_Email.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Email.FormattingEnabled = true;
            this.comboBox_Email.Location = new System.Drawing.Point(126, 93);
            this.comboBox_Email.Name = "comboBox_Email";
            this.comboBox_Email.Size = new System.Drawing.Size(157, 21);
            this.comboBox_Email.TabIndex = 2;
            // 
            // checkBox_EMail
            // 
            this.checkBox_EMail.AutoSize = true;
            this.checkBox_EMail.Location = new System.Drawing.Point(126, 148);
            this.checkBox_EMail.Name = "checkBox_EMail";
            this.checkBox_EMail.Size = new System.Drawing.Size(89, 17);
            this.checkBox_EMail.TabIndex = 3;
            this.checkBox_EMail.Text = "Envíos EMail";
            this.checkBox_EMail.UseVisualStyleBackColor = true;
            // 
            // checkBox_Postal
            // 
            this.checkBox_Postal.AutoSize = true;
            this.checkBox_Postal.Location = new System.Drawing.Point(126, 171);
            this.checkBox_Postal.Name = "checkBox_Postal";
            this.checkBox_Postal.Size = new System.Drawing.Size(103, 17);
            this.checkBox_Postal.TabIndex = 4;
            this.checkBox_Postal.Text = "Envíos Postales";
            this.checkBox_Postal.UseVisualStyleBackColor = true;
            // 
            // comboBox_cc
            // 
            this.comboBox_cc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cc.FormattingEnabled = true;
            this.comboBox_cc.Location = new System.Drawing.Point(126, 229);
            this.comboBox_cc.Name = "comboBox_cc";
            this.comboBox_cc.Size = new System.Drawing.Size(157, 21);
            this.comboBox_cc.TabIndex = 6;
            // 
            // comboBox_FormadePago
            // 
            this.comboBox_FormadePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FormadePago.FormattingEnabled = true;
            this.comboBox_FormadePago.Location = new System.Drawing.Point(126, 202);
            this.comboBox_FormadePago.Name = "comboBox_FormadePago";
            this.comboBox_FormadePago.Size = new System.Drawing.Size(157, 21);
            this.comboBox_FormadePago.TabIndex = 7;
            // 
            // checkBox_Iva
            // 
            this.checkBox_Iva.AutoSize = true;
            this.checkBox_Iva.Location = new System.Drawing.Point(126, 257);
            this.checkBox_Iva.Name = "checkBox_Iva";
            this.checkBox_Iva.Size = new System.Drawing.Size(107, 17);
            this.checkBox_Iva.TabIndex = 8;
            this.checkBox_Iva.Text = "Informes con IVA";
            this.checkBox_Iva.UseVisualStyleBackColor = true;
            // 
            // label_Entidad
            // 
            this.label_Entidad.AutoSize = true;
            this.label_Entidad.Location = new System.Drawing.Point(40, 43);
            this.label_Entidad.Name = "label_Entidad";
            this.label_Entidad.Size = new System.Drawing.Size(46, 13);
            this.label_Entidad.TabIndex = 9;
            this.label_Entidad.Text = "Entidad:";
            // 
            // label_Direccion
            // 
            this.label_Direccion.AutoSize = true;
            this.label_Direccion.Location = new System.Drawing.Point(40, 69);
            this.label_Direccion.Name = "label_Direccion";
            this.label_Direccion.Size = new System.Drawing.Size(55, 13);
            this.label_Direccion.TabIndex = 10;
            this.label_Direccion.Text = "Dirección:";
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.Location = new System.Drawing.Point(40, 96);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(39, 13);
            this.label_Email.TabIndex = 11;
            this.label_Email.Text = "E-Mail:";
            // 
            // label_FPago
            // 
            this.label_FPago.AutoSize = true;
            this.label_FPago.Location = new System.Drawing.Point(40, 205);
            this.label_FPago.Name = "label_FPago";
            this.label_FPago.Size = new System.Drawing.Size(82, 13);
            this.label_FPago.TabIndex = 13;
            this.label_FPago.Text = "Forma de Pago:";
            // 
            // label_IVA
            // 
            this.label_IVA.AutoSize = true;
            this.label_IVA.Location = new System.Drawing.Point(40, 232);
            this.label_IVA.Name = "label_IVA";
            this.label_IVA.Size = new System.Drawing.Size(47, 13);
            this.label_IVA.TabIndex = 14;
            this.label_IVA.Text = "Cuenta :";
            // 
            // label_Notas
            // 
            this.label_Notas.AutoSize = true;
            this.label_Notas.Location = new System.Drawing.Point(40, 283);
            this.label_Notas.Name = "label_Notas";
            this.label_Notas.Size = new System.Drawing.Size(35, 13);
            this.label_Notas.TabIndex = 15;
            this.label_Notas.Text = "Notas";
            // 
            // textBox_Notas
            // 
            this.textBox_Notas.Location = new System.Drawing.Point(126, 280);
            this.textBox_Notas.Multiline = true;
            this.textBox_Notas.Name = "textBox_Notas";
            this.textBox_Notas.Size = new System.Drawing.Size(281, 58);
            this.textBox_Notas.TabIndex = 16;
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(251, 357);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 23);
            this.button_Guardar.TabIndex = 17;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(332, 357);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 18;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Copia E-Mail:";
            // 
            // textBox_copiaEmail
            // 
            this.textBox_copiaEmail.Location = new System.Drawing.Point(126, 120);
            this.textBox_copiaEmail.Name = "textBox_copiaEmail";
            this.textBox_copiaEmail.Size = new System.Drawing.Size(251, 20);
            this.textBox_copiaEmail.TabIndex = 20;
            // 
            // FormAltaComunero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 395);
            this.Controls.Add(this.textBox_copiaEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.textBox_Notas);
            this.Controls.Add(this.label_Notas);
            this.Controls.Add(this.label_IVA);
            this.Controls.Add(this.label_FPago);
            this.Controls.Add(this.label_Email);
            this.Controls.Add(this.label_Direccion);
            this.Controls.Add(this.label_Entidad);
            this.Controls.Add(this.checkBox_Iva);
            this.Controls.Add(this.comboBox_FormadePago);
            this.Controls.Add(this.comboBox_cc);
            this.Controls.Add(this.checkBox_Postal);
            this.Controls.Add(this.checkBox_EMail);
            this.Controls.Add(this.comboBox_Email);
            this.Controls.Add(this.comboBox_Direccion);
            this.Controls.Add(this.textBox_Entidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAltaComunero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comunero";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAltaComunero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Entidad;
        private System.Windows.Forms.ComboBox comboBox_Direccion;
        private System.Windows.Forms.ComboBox comboBox_Email;
        private System.Windows.Forms.CheckBox checkBox_EMail;
        private System.Windows.Forms.CheckBox checkBox_Postal;
        private System.Windows.Forms.ComboBox comboBox_cc;
        private System.Windows.Forms.ComboBox comboBox_FormadePago;
        private System.Windows.Forms.CheckBox checkBox_Iva;
        private System.Windows.Forms.Label label_Entidad;
        private System.Windows.Forms.Label label_Direccion;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.Label label_FPago;
        private System.Windows.Forms.Label label_IVA;
        private System.Windows.Forms.Label label_Notas;
        private System.Windows.Forms.TextBox textBox_Notas;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_copiaEmail;
    }
}