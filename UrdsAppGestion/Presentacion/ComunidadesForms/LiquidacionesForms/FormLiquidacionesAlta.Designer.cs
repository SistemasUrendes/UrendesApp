namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms
{
    partial class FormLiquidacionesAlta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLiquidacionesAlta));
            this.textBox_liquidacion = new System.Windows.Forms.TextBox();
            this.comboBox_Ejercicio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_TipoLiquiacion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Fondo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_Ppal = new System.Windows.Forms.CheckBox();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_liq_corto = new System.Windows.Forms.TextBox();
            this.textBox_FIni = new System.Windows.Forms.MaskedTextBox();
            this.textBox_FFin = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // textBox_liquidacion
            // 
            this.textBox_liquidacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_liquidacion.Location = new System.Drawing.Point(148, 62);
            this.textBox_liquidacion.Name = "textBox_liquidacion";
            this.textBox_liquidacion.Size = new System.Drawing.Size(203, 20);
            this.textBox_liquidacion.TabIndex = 2;
            // 
            // comboBox_Ejercicio
            // 
            this.comboBox_Ejercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Ejercicio.FormattingEnabled = true;
            this.comboBox_Ejercicio.Location = new System.Drawing.Point(148, 35);
            this.comboBox_Ejercicio.Name = "comboBox_Ejercicio";
            this.comboBox_Ejercicio.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Ejercicio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ejercicio Abierto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Liquidación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fecha Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha Fin:";
            // 
            // comboBox_TipoLiquiacion
            // 
            this.comboBox_TipoLiquiacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TipoLiquiacion.FormattingEnabled = true;
            this.comboBox_TipoLiquiacion.Location = new System.Drawing.Point(148, 169);
            this.comboBox_TipoLiquiacion.Name = "comboBox_TipoLiquiacion";
            this.comboBox_TipoLiquiacion.Size = new System.Drawing.Size(121, 21);
            this.comboBox_TipoLiquiacion.TabIndex = 6;
            this.comboBox_TipoLiquiacion.SelectionChangeCommitted += new System.EventHandler(this.comboBox_TipoLiquiacion_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tipo:";
            // 
            // comboBox_Fondo
            // 
            this.comboBox_Fondo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Fondo.FormattingEnabled = true;
            this.comboBox_Fondo.Location = new System.Drawing.Point(148, 197);
            this.comboBox_Fondo.Name = "comboBox_Fondo";
            this.comboBox_Fondo.Size = new System.Drawing.Size(203, 21);
            this.comboBox_Fondo.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Fondo:";
            // 
            // checkBox_Ppal
            // 
            this.checkBox_Ppal.AutoSize = true;
            this.checkBox_Ppal.Location = new System.Drawing.Point(148, 225);
            this.checkBox_Ppal.Name = "checkBox_Ppal";
            this.checkBox_Ppal.Size = new System.Drawing.Size(123, 17);
            this.checkBox_Ppal.TabIndex = 8;
            this.checkBox_Ppal.Text = "Liquidación Principal";
            this.checkBox_Ppal.UseVisualStyleBackColor = true;
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(231, 250);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 23);
            this.button_Guardar.TabIndex = 9;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(312, 250);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 10;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Liq. Corto:";
            // 
            // textBox_liq_corto
            // 
            this.textBox_liq_corto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_liq_corto.Location = new System.Drawing.Point(148, 89);
            this.textBox_liq_corto.Name = "textBox_liq_corto";
            this.textBox_liq_corto.Size = new System.Drawing.Size(203, 20);
            this.textBox_liq_corto.TabIndex = 3;
            // 
            // textBox_FIni
            // 
            this.textBox_FIni.Location = new System.Drawing.Point(148, 115);
            this.textBox_FIni.Mask = "00/00/0000";
            this.textBox_FIni.Name = "textBox_FIni";
            this.textBox_FIni.Size = new System.Drawing.Size(72, 20);
            this.textBox_FIni.TabIndex = 4;
            this.textBox_FIni.ValidatingType = typeof(System.DateTime);
            this.textBox_FIni.Leave += new System.EventHandler(this.textBox_FIni_Leave);
            // 
            // textBox_FFin
            // 
            this.textBox_FFin.Location = new System.Drawing.Point(148, 142);
            this.textBox_FFin.Mask = "00/00/0000";
            this.textBox_FFin.Name = "textBox_FFin";
            this.textBox_FFin.Size = new System.Drawing.Size(72, 20);
            this.textBox_FFin.TabIndex = 5;
            this.textBox_FFin.ValidatingType = typeof(System.DateTime);
            this.textBox_FFin.Leave += new System.EventHandler(this.textBox_FFin_Leave);
            // 
            // FormLiquidacionesAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 296);
            this.Controls.Add(this.textBox_FFin);
            this.Controls.Add(this.textBox_FIni);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_liq_corto);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.checkBox_Ppal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_Fondo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_TipoLiquiacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Ejercicio);
            this.Controls.Add(this.textBox_liquidacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLiquidacionesAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edición de Liquidaciones";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormLiquidacionesAlta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_liquidacion;
        private System.Windows.Forms.ComboBox comboBox_Ejercicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_TipoLiquiacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Fondo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_Ppal;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_liq_corto;
        private System.Windows.Forms.MaskedTextBox textBox_FIni;
        private System.Windows.Forms.MaskedTextBox textBox_FFin;
    }
}