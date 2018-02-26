namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    partial class FormAccesoOperacionesTesoreria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccesoOperacionesTesoreria));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_cuenta = new System.Windows.Forms.TextBox();
            this.textBox_nombre_cuenta = new System.Windows.Forms.TextBox();
            this.textBox_tipo_operacion = new System.Windows.Forms.TextBox();
            this.textBox_entidad = new System.Windows.Forms.TextBox();
            this.maskedTextBox_fecha = new System.Windows.Forms.MaskedTextBox();
            this.button_continuar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuenta : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Operacion : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Entidad : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Importe : ";
            // 
            // textBox_cuenta
            // 
            this.textBox_cuenta.Location = new System.Drawing.Point(92, 33);
            this.textBox_cuenta.Name = "textBox_cuenta";
            this.textBox_cuenta.ReadOnly = true;
            this.textBox_cuenta.Size = new System.Drawing.Size(31, 20);
            this.textBox_cuenta.TabIndex = 5;
            this.textBox_cuenta.TabStop = false;
            // 
            // textBox_nombre_cuenta
            // 
            this.textBox_nombre_cuenta.Location = new System.Drawing.Point(128, 33);
            this.textBox_nombre_cuenta.Name = "textBox_nombre_cuenta";
            this.textBox_nombre_cuenta.ReadOnly = true;
            this.textBox_nombre_cuenta.Size = new System.Drawing.Size(195, 20);
            this.textBox_nombre_cuenta.TabIndex = 6;
            this.textBox_nombre_cuenta.TabStop = false;
            // 
            // textBox_tipo_operacion
            // 
            this.textBox_tipo_operacion.Location = new System.Drawing.Point(92, 68);
            this.textBox_tipo_operacion.Name = "textBox_tipo_operacion";
            this.textBox_tipo_operacion.ReadOnly = true;
            this.textBox_tipo_operacion.Size = new System.Drawing.Size(231, 20);
            this.textBox_tipo_operacion.TabIndex = 7;
            this.textBox_tipo_operacion.TabStop = false;
            // 
            // textBox_entidad
            // 
            this.textBox_entidad.Location = new System.Drawing.Point(92, 103);
            this.textBox_entidad.Name = "textBox_entidad";
            this.textBox_entidad.ReadOnly = true;
            this.textBox_entidad.Size = new System.Drawing.Size(231, 20);
            this.textBox_entidad.TabIndex = 1;
            this.textBox_entidad.DoubleClick += new System.EventHandler(this.textBox_entidad_DoubleClick);
            this.textBox_entidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_entidad_KeyPress);
            // 
            // maskedTextBox_fecha
            // 
            this.maskedTextBox_fecha.Location = new System.Drawing.Point(92, 138);
            this.maskedTextBox_fecha.Mask = "00/00/0000";
            this.maskedTextBox_fecha.Name = "maskedTextBox_fecha";
            this.maskedTextBox_fecha.Size = new System.Drawing.Size(70, 20);
            this.maskedTextBox_fecha.TabIndex = 2;
            this.maskedTextBox_fecha.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_fecha.Leave += new System.EventHandler(this.maskedTextBox_fecha_Leave);
            this.maskedTextBox_fecha.Validated += new System.EventHandler(this.maskedTextBox_fecha_Validated);
            // 
            // button_continuar
            // 
            this.button_continuar.Location = new System.Drawing.Point(167, 210);
            this.button_continuar.Name = "button_continuar";
            this.button_continuar.Size = new System.Drawing.Size(75, 23);
            this.button_continuar.TabIndex = 4;
            this.button_continuar.Text = "Continuar";
            this.button_continuar.UseVisualStyleBackColor = true;
            this.button_continuar.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(248, 210);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 5;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(92, 173);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(70, 20);
            this.textBox_importe.TabIndex = 3;
            this.textBox_importe.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(164, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "El importe tiene que estar en positivo";
            this.label6.Visible = false;
            // 
            // FormAccesoOperacionesTesoreria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 255);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_continuar);
            this.Controls.Add(this.maskedTextBox_fecha);
            this.Controls.Add(this.textBox_entidad);
            this.Controls.Add(this.textBox_tipo_operacion);
            this.Controls.Add(this.textBox_nombre_cuenta);
            this.Controls.Add(this.textBox_cuenta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAccesoOperacionesTesoreria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso Operaciones";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAccesoOperacionesTesoreria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_cuenta;
        private System.Windows.Forms.TextBox textBox_nombre_cuenta;
        private System.Windows.Forms.TextBox textBox_tipo_operacion;
        private System.Windows.Forms.TextBox textBox_entidad;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_fecha;
        private System.Windows.Forms.Button button_continuar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.Label label6;
    }
}