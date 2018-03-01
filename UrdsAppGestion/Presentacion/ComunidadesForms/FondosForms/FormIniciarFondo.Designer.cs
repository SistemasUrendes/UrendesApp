namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms
{
    partial class FormIniciarFondo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIniciarFondo));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_ejercicio = new System.Windows.Forms.ComboBox();
            this.button_fondoVacio = new System.Windows.Forms.Button();
            this.button1_traspaso = new System.Windows.Forms.Button();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_liquidaciones = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ejercicio: ";
            // 
            // comboBox_ejercicio
            // 
            this.comboBox_ejercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ejercicio.FormattingEnabled = true;
            this.comboBox_ejercicio.Location = new System.Drawing.Point(122, 25);
            this.comboBox_ejercicio.Name = "comboBox_ejercicio";
            this.comboBox_ejercicio.Size = new System.Drawing.Size(121, 21);
            this.comboBox_ejercicio.TabIndex = 1;
            this.comboBox_ejercicio.SelectionChangeCommitted += new System.EventHandler(this.comboBox_ejercicio_SelectionChangeCommitted);
            // 
            // button_fondoVacio
            // 
            this.button_fondoVacio.Location = new System.Drawing.Point(289, 110);
            this.button_fondoVacio.Name = "button_fondoVacio";
            this.button_fondoVacio.Size = new System.Drawing.Size(60, 58);
            this.button_fondoVacio.TabIndex = 2;
            this.button_fondoVacio.Text = "Iniciar Fondo Vacio";
            this.button_fondoVacio.UseVisualStyleBackColor = true;
            this.button_fondoVacio.Click += new System.EventHandler(this.button_fondoVacio_Click);
            // 
            // button1_traspaso
            // 
            this.button1_traspaso.Location = new System.Drawing.Point(127, 220);
            this.button1_traspaso.Name = "button1_traspaso";
            this.button1_traspaso.Size = new System.Drawing.Size(92, 46);
            this.button1_traspaso.TabIndex = 3;
            this.button1_traspaso.Text = "Iniciar Fondo";
            this.button1_traspaso.UseVisualStyleBackColor = true;
            this.button1_traspaso.Click += new System.EventHandler(this.button1_traspaso_Click);
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(123, 72);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(120, 20);
            this.textBox_importe.TabIndex = 4;
            this.textBox_importe.Text = "0.00";
            this.textBox_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Importe Inicial : ";
            // 
            // listBox_liquidaciones
            // 
            this.listBox_liquidaciones.FormattingEnabled = true;
            this.listBox_liquidaciones.Location = new System.Drawing.Point(123, 110);
            this.listBox_liquidaciones.Name = "listBox_liquidaciones";
            this.listBox_liquidaciones.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_liquidaciones.Size = new System.Drawing.Size(120, 95);
            this.listBox_liquidaciones.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Liquidaciones\r\n    Incluidas:";
            // 
            // FormIniciarFondo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 294);
            this.Controls.Add(this.listBox_liquidaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1_traspaso);
            this.Controls.Add(this.button_fondoVacio);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.comboBox_ejercicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormIniciarFondo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Fondo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormIniciarFondo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_ejercicio;
        private System.Windows.Forms.Button button_fondoVacio;
        private System.Windows.Forms.Button button1_traspaso;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_liquidaciones;
        private System.Windows.Forms.Label label3;
    }
}