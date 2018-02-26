namespace UrdsAppGestión.Presentacion.ComunidadesForms.RemesasForms
{
    partial class FormAnyadirRemesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnyadirRemesa));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_referencia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBox_efectiva = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_cargo = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_envio = new System.Windows.Forms.MaskedTextBox();
            this.textBox_sufijo = new System.Windows.Forms.TextBox();
            this.comboBox_tipoRemesa = new System.Windows.Forms.ComboBox();
            this.comboBox_cuenta = new System.Windows.Forms.ComboBox();
            this.button_anyadir = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Referencia : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo Remesa : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha de Envío : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fecha de Cargo : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Fecha de Efectiva : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Sufijo : ";
            // 
            // textBox_referencia
            // 
            this.textBox_referencia.Location = new System.Drawing.Point(143, 36);
            this.textBox_referencia.Name = "textBox_referencia";
            this.textBox_referencia.Size = new System.Drawing.Size(179, 20);
            this.textBox_referencia.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Cuenta : ";
            // 
            // maskedTextBox_efectiva
            // 
            this.maskedTextBox_efectiva.Location = new System.Drawing.Point(143, 201);
            this.maskedTextBox_efectiva.Mask = "00/00/0000";
            this.maskedTextBox_efectiva.Name = "maskedTextBox_efectiva";
            this.maskedTextBox_efectiva.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBox_efectiva.TabIndex = 6;
            this.maskedTextBox_efectiva.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_efectiva.Leave += new System.EventHandler(this.maskedTextBox_efectiva_Leave);
            // 
            // maskedTextBox_cargo
            // 
            this.maskedTextBox_cargo.Location = new System.Drawing.Point(143, 168);
            this.maskedTextBox_cargo.Mask = "00/00/0000";
            this.maskedTextBox_cargo.Name = "maskedTextBox_cargo";
            this.maskedTextBox_cargo.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBox_cargo.TabIndex = 5;
            this.maskedTextBox_cargo.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_cargo.Leave += new System.EventHandler(this.maskedTextBox_cargo_Leave);
            // 
            // maskedTextBox_envio
            // 
            this.maskedTextBox_envio.Location = new System.Drawing.Point(143, 135);
            this.maskedTextBox_envio.Mask = "00/00/0000";
            this.maskedTextBox_envio.Name = "maskedTextBox_envio";
            this.maskedTextBox_envio.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBox_envio.TabIndex = 4;
            this.maskedTextBox_envio.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_envio.Leave += new System.EventHandler(this.maskedTextBox_envio_Leave);
            // 
            // textBox_sufijo
            // 
            this.textBox_sufijo.Location = new System.Drawing.Point(143, 234);
            this.textBox_sufijo.Name = "textBox_sufijo";
            this.textBox_sufijo.Size = new System.Drawing.Size(45, 20);
            this.textBox_sufijo.TabIndex = 7;
            this.textBox_sufijo.Text = "0";
            // 
            // comboBox_tipoRemesa
            // 
            this.comboBox_tipoRemesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tipoRemesa.FormattingEnabled = true;
            this.comboBox_tipoRemesa.Location = new System.Drawing.Point(143, 69);
            this.comboBox_tipoRemesa.Name = "comboBox_tipoRemesa";
            this.comboBox_tipoRemesa.Size = new System.Drawing.Size(155, 21);
            this.comboBox_tipoRemesa.TabIndex = 2;
            // 
            // comboBox_cuenta
            // 
            this.comboBox_cuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cuenta.FormattingEnabled = true;
            this.comboBox_cuenta.Location = new System.Drawing.Point(143, 102);
            this.comboBox_cuenta.Name = "comboBox_cuenta";
            this.comboBox_cuenta.Size = new System.Drawing.Size(155, 21);
            this.comboBox_cuenta.TabIndex = 3;
            // 
            // button_anyadir
            // 
            this.button_anyadir.Location = new System.Drawing.Point(166, 276);
            this.button_anyadir.Name = "button_anyadir";
            this.button_anyadir.Size = new System.Drawing.Size(75, 23);
            this.button_anyadir.TabIndex = 8;
            this.button_anyadir.Text = "Añadir";
            this.button_anyadir.UseVisualStyleBackColor = true;
            this.button_anyadir.Click += new System.EventHandler(this.button_anyadir_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(247, 276);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 9;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // FormAnyadirRemesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 320);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_anyadir);
            this.Controls.Add(this.comboBox_cuenta);
            this.Controls.Add(this.comboBox_tipoRemesa);
            this.Controls.Add(this.textBox_sufijo);
            this.Controls.Add(this.maskedTextBox_envio);
            this.Controls.Add(this.maskedTextBox_cargo);
            this.Controls.Add(this.maskedTextBox_efectiva);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_referencia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAnyadirRemesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Remesa";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAnyadirRemesa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_referencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_efectiva;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_cargo;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_envio;
        private System.Windows.Forms.TextBox textBox_sufijo;
        private System.Windows.Forms.ComboBox comboBox_tipoRemesa;
        private System.Windows.Forms.ComboBox comboBox_cuenta;
        private System.Windows.Forms.Button button_anyadir;
        private System.Windows.Forms.Button button_cancelar;
    }
}