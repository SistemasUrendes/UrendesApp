namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.ReglasPago
{
    partial class FormAnyadirReglaDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnyadirReglaDetalle));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_comunero = new System.Windows.Forms.TextBox();
            this.textBox_porcentaje = new System.Windows.Forms.TextBox();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_reparto = new System.Windows.Forms.TextBox();
            this.textBox_tipo_reparto = new System.Windows.Forms.TextBox();
            this.textBox_division = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comunero :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Porcentaje : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Importe :";
            // 
            // textBox_comunero
            // 
            this.textBox_comunero.Location = new System.Drawing.Point(118, 129);
            this.textBox_comunero.Name = "textBox_comunero";
            this.textBox_comunero.ReadOnly = true;
            this.textBox_comunero.Size = new System.Drawing.Size(244, 20);
            this.textBox_comunero.TabIndex = 3;
            this.textBox_comunero.Text = "Pulsa espacio para buscar Comunero";
            this.textBox_comunero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_comunero_KeyPress);
            // 
            // textBox_porcentaje
            // 
            this.textBox_porcentaje.Location = new System.Drawing.Point(118, 162);
            this.textBox_porcentaje.Name = "textBox_porcentaje";
            this.textBox_porcentaje.Size = new System.Drawing.Size(65, 20);
            this.textBox_porcentaje.TabIndex = 4;
            this.textBox_porcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_porcentaje.Enter += new System.EventHandler(this.textBox_porcentaje_Enter);
            this.textBox_porcentaje.Leave += new System.EventHandler(this.textBox_porcentaje_Leave);
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(118, 195);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(65, 20);
            this.textBox_importe.TabIndex = 5;
            this.textBox_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_importe.Enter += new System.EventHandler(this.textBox_importe_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(296, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 46);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_reparto);
            this.groupBox1.Controls.Add(this.textBox_tipo_reparto);
            this.groupBox1.Controls.Add(this.textBox_division);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(39, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // textBox_reparto
            // 
            this.textBox_reparto.Enabled = false;
            this.textBox_reparto.Location = new System.Drawing.Point(71, 61);
            this.textBox_reparto.Name = "textBox_reparto";
            this.textBox_reparto.ReadOnly = true;
            this.textBox_reparto.Size = new System.Drawing.Size(225, 20);
            this.textBox_reparto.TabIndex = 5;
            // 
            // textBox_tipo_reparto
            // 
            this.textBox_tipo_reparto.Enabled = false;
            this.textBox_tipo_reparto.Location = new System.Drawing.Point(202, 28);
            this.textBox_tipo_reparto.Name = "textBox_tipo_reparto";
            this.textBox_tipo_reparto.ReadOnly = true;
            this.textBox_tipo_reparto.Size = new System.Drawing.Size(94, 20);
            this.textBox_tipo_reparto.TabIndex = 4;
            // 
            // textBox_division
            // 
            this.textBox_division.Enabled = false;
            this.textBox_division.Location = new System.Drawing.Point(70, 28);
            this.textBox_division.Name = "textBox_division";
            this.textBox_division.ReadOnly = true;
            this.textBox_division.Size = new System.Drawing.Size(83, 20);
            this.textBox_division.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tipo :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "División :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Reparto :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "€";
            // 
            // FormAnyadirReglaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 238);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.textBox_porcentaje);
            this.Controls.Add(this.textBox_comunero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAnyadirReglaDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Regla";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAnyadirReglaDetalle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_comunero;
        private System.Windows.Forms.TextBox textBox_porcentaje;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_reparto;
        private System.Windows.Forms.TextBox textBox_tipo_reparto;
        private System.Windows.Forms.TextBox textBox_division;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}