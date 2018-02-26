namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    partial class FormTraspasoES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTraspasoES));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_cuenta = new System.Windows.Forms.TextBox();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.maskedTextBox_fecha = new System.Windows.Forms.MaskedTextBox();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receptora : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Apunte : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Importe : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(221, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(302, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_cuenta
            // 
            this.textBox_cuenta.Enabled = false;
            this.textBox_cuenta.Location = new System.Drawing.Point(102, 43);
            this.textBox_cuenta.Name = "textBox_cuenta";
            this.textBox_cuenta.Size = new System.Drawing.Size(275, 20);
            this.textBox_cuenta.TabIndex = 6;
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(102, 75);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(275, 20);
            this.textBox_descripcion.TabIndex = 7;
            // 
            // maskedTextBox_fecha
            // 
            this.maskedTextBox_fecha.Location = new System.Drawing.Point(102, 110);
            this.maskedTextBox_fecha.Mask = "00/00/0000";
            this.maskedTextBox_fecha.Name = "maskedTextBox_fecha";
            this.maskedTextBox_fecha.Size = new System.Drawing.Size(82, 20);
            this.maskedTextBox_fecha.TabIndex = 8;
            this.maskedTextBox_fecha.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_fecha.Leave += new System.EventHandler(this.maskedTextBox_fecha_Leave);
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(259, 110);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(118, 20);
            this.textBox_importe.TabIndex = 9;
            // 
            // FormTraspasoES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 191);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.maskedTextBox_fecha);
            this.Controls.Add(this.textBox_descripcion);
            this.Controls.Add(this.textBox_cuenta);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTraspasoES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traspaso ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTraspasoES_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_cuenta;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_fecha;
        private System.Windows.Forms.TextBox textBox_importe;
    }
}