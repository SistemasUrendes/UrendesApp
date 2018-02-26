namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormIngresoFondo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIngresoFondo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_fondos = new System.Windows.Forms.ComboBox();
            this.comboBox_liquidación = new System.Windows.Forms.ComboBox();
            this.textBox_comunero = new System.Windows.Forms.TextBox();
            this.maskedTextBox_fecha = new System.Windows.Forms.MaskedTextBox();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_subcuenta = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fondo : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Liquidación : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Comunero : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Importe : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha : ";
            // 
            // comboBox_fondos
            // 
            this.comboBox_fondos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_fondos.FormattingEnabled = true;
            this.comboBox_fondos.Location = new System.Drawing.Point(104, 38);
            this.comboBox_fondos.Name = "comboBox_fondos";
            this.comboBox_fondos.Size = new System.Drawing.Size(220, 21);
            this.comboBox_fondos.TabIndex = 1;
            this.comboBox_fondos.SelectionChangeCommitted += new System.EventHandler(this.comboBox_fondos_SelectionChangeCommitted);
            // 
            // comboBox_liquidación
            // 
            this.comboBox_liquidación.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_liquidación.FormattingEnabled = true;
            this.comboBox_liquidación.Items.AddRange(new object[] {
            "Selecciona un Fondo..."});
            this.comboBox_liquidación.Location = new System.Drawing.Point(104, 69);
            this.comboBox_liquidación.Name = "comboBox_liquidación";
            this.comboBox_liquidación.Size = new System.Drawing.Size(220, 21);
            this.comboBox_liquidación.TabIndex = 2;
            // 
            // textBox_comunero
            // 
            this.textBox_comunero.Location = new System.Drawing.Point(104, 100);
            this.textBox_comunero.Name = "textBox_comunero";
            this.textBox_comunero.ReadOnly = true;
            this.textBox_comunero.Size = new System.Drawing.Size(220, 20);
            this.textBox_comunero.TabIndex = 3;
            this.textBox_comunero.Text = "Pulsa espacio para Seleccionar Comunero";
            this.textBox_comunero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_comunero_KeyPress);
            // 
            // maskedTextBox_fecha
            // 
            this.maskedTextBox_fecha.Location = new System.Drawing.Point(104, 227);
            this.maskedTextBox_fecha.Mask = "00/00/0000";
            this.maskedTextBox_fecha.Name = "maskedTextBox_fecha";
            this.maskedTextBox_fecha.Size = new System.Drawing.Size(67, 20);
            this.maskedTextBox_fecha.TabIndex = 7;
            this.maskedTextBox_fecha.ValidatingType = typeof(System.DateTime);
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(104, 195);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(67, 20);
            this.textBox_importe.TabIndex = 6;
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(173, 270);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 8;
            this.button_guardar.Text = "Crear";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(104, 165);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(220, 20);
            this.textBox_descripcion.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Descripción : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "SubCuenta : ";
            // 
            // comboBox_subcuenta
            // 
            this.comboBox_subcuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_subcuenta.FormattingEnabled = true;
            this.comboBox_subcuenta.Items.AddRange(new object[] {
            "70001",
            "70000"});
            this.comboBox_subcuenta.Location = new System.Drawing.Point(104, 131);
            this.comboBox_subcuenta.Name = "comboBox_subcuenta";
            this.comboBox_subcuenta.Size = new System.Drawing.Size(93, 21);
            this.comboBox_subcuenta.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormIngresoFondo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 313);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_subcuenta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_descripcion);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.maskedTextBox_fecha);
            this.Controls.Add(this.textBox_comunero);
            this.Controls.Add(this.comboBox_liquidación);
            this.Controls.Add(this.comboBox_fondos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormIngresoFondo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso Fondo o  Abono";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormIngresoFondo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_fondos;
        private System.Windows.Forms.ComboBox comboBox_liquidación;
        private System.Windows.Forms.TextBox textBox_comunero;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_fecha;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_subcuenta;
        private System.Windows.Forms.Button button1;
    }
}