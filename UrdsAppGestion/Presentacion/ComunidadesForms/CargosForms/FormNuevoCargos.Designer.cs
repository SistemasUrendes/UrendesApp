namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    partial class FormNuevoCargos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevoCargos));
            this.textBox_nuevo = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.comboBox_sugerencia = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_organo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox_nuevo
            // 
            this.textBox_nuevo.Enabled = false;
            this.textBox_nuevo.Location = new System.Drawing.Point(123, 72);
            this.textBox_nuevo.Name = "textBox_nuevo";
            this.textBox_nuevo.Size = new System.Drawing.Size(121, 20);
            this.textBox_nuevo.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(33, 73);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "Otro";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // comboBox_sugerencia
            // 
            this.comboBox_sugerencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sugerencia.FormattingEnabled = true;
            this.comboBox_sugerencia.Items.AddRange(new object[] {
            "Presidente",
            "Vicepresidente",
            "Secretario"});
            this.comboBox_sugerencia.Location = new System.Drawing.Point(123, 38);
            this.comboBox_sugerencia.Name = "comboBox_sugerencia";
            this.comboBox_sugerencia.Size = new System.Drawing.Size(121, 21);
            this.comboBox_sugerencia.TabIndex = 2;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(33, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(84, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Sugerencias";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Añadir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Organo : ";
            // 
            // comboBox_organo
            // 
            this.comboBox_organo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_organo.FormattingEnabled = true;
            this.comboBox_organo.Location = new System.Drawing.Point(123, 109);
            this.comboBox_organo.Name = "comboBox_organo";
            this.comboBox_organo.Size = new System.Drawing.Size(121, 21);
            this.comboBox_organo.TabIndex = 6;
            // 
            // FormNuevoCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 191);
            this.Controls.Add(this.comboBox_organo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.comboBox_sugerencia);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.textBox_nuevo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNuevoCargos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Cargo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormNuevoCargos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_nuevo;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox comboBox_sugerencia;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_organo;
    }
}