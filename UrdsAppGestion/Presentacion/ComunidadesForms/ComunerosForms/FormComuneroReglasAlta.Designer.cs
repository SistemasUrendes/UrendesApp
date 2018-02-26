namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    partial class FormComuneroReglasAlta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComuneroReglasAlta));
            this.textBox_Entidad = new System.Windows.Forms.TextBox();
            this.textBox_Regla = new System.Windows.Forms.TextBox();
            this.comboBox_FPago = new System.Windows.Forms.ComboBox();
            this.comboBox_Cuenta = new System.Windows.Forms.ComboBox();
            this.checkBox_Activa = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_Entidad
            // 
            this.textBox_Entidad.Location = new System.Drawing.Point(114, 35);
            this.textBox_Entidad.Name = "textBox_Entidad";
            this.textBox_Entidad.Size = new System.Drawing.Size(224, 20);
            this.textBox_Entidad.TabIndex = 0;
            // 
            // textBox_Regla
            // 
            this.textBox_Regla.Location = new System.Drawing.Point(114, 61);
            this.textBox_Regla.Name = "textBox_Regla";
            this.textBox_Regla.Size = new System.Drawing.Size(121, 20);
            this.textBox_Regla.TabIndex = 1;
            // 
            // comboBox_FPago
            // 
            this.comboBox_FPago.FormattingEnabled = true;
            this.comboBox_FPago.Location = new System.Drawing.Point(114, 141);
            this.comboBox_FPago.Name = "comboBox_FPago";
            this.comboBox_FPago.Size = new System.Drawing.Size(121, 21);
            this.comboBox_FPago.TabIndex = 3;
            // 
            // comboBox_Cuenta
            // 
            this.comboBox_Cuenta.FormattingEnabled = true;
            this.comboBox_Cuenta.Location = new System.Drawing.Point(114, 168);
            this.comboBox_Cuenta.Name = "comboBox_Cuenta";
            this.comboBox_Cuenta.Size = new System.Drawing.Size(224, 21);
            this.comboBox_Cuenta.TabIndex = 4;
            // 
            // checkBox_Activa
            // 
            this.checkBox_Activa.AutoSize = true;
            this.checkBox_Activa.Location = new System.Drawing.Point(114, 196);
            this.checkBox_Activa.Name = "checkBox_Activa";
            this.checkBox_Activa.Size = new System.Drawing.Size(56, 17);
            this.checkBox_Activa.TabIndex = 5;
            this.checkBox_Activa.Text = "Activa";
            this.checkBox_Activa.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Entidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Regla";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Forma de Pago:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cuenta";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(232, 234);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 23);
            this.button_Guardar.TabIndex = 10;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(313, 234);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 11;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(286, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "al desativar una regla, se debe eliminar de las asociaciones";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Descripción : ";
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(114, 88);
            this.textBox_descripcion.Multiline = true;
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(224, 47);
            this.textBox_descripcion.TabIndex = 14;
            // 
            // FormComuneroReglasAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 283);
            this.Controls.Add(this.textBox_descripcion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Activa);
            this.Controls.Add(this.comboBox_Cuenta);
            this.Controls.Add(this.comboBox_FPago);
            this.Controls.Add(this.textBox_Regla);
            this.Controls.Add(this.textBox_Entidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormComuneroReglasAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edición Reglas Recibos ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormComuneroReglasAlta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Entidad;
        private System.Windows.Forms.TextBox textBox_Regla;
        private System.Windows.Forms.ComboBox comboBox_FPago;
        private System.Windows.Forms.ComboBox comboBox_Cuenta;
        private System.Windows.Forms.CheckBox checkBox_Activa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_descripcion;
    }
}