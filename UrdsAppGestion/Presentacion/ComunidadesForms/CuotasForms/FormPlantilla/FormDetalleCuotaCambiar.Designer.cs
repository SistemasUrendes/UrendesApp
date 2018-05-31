namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms.FormPlantilla
{
    partial class FormDetalleCuotaCambiar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetalleCuotaCambiar));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_bloque = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.button_enviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bloque: ";
            // 
            // comboBox_bloque
            // 
            this.comboBox_bloque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bloque.FormattingEnabled = true;
            this.comboBox_bloque.Location = new System.Drawing.Point(84, 34);
            this.comboBox_bloque.Name = "comboBox_bloque";
            this.comboBox_bloque.Size = new System.Drawing.Size(152, 21);
            this.comboBox_bloque.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Importe: ";
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(84, 77);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(100, 20);
            this.textBox_importe.TabIndex = 3;
            // 
            // button_enviar
            // 
            this.button_enviar.Location = new System.Drawing.Point(84, 117);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(75, 23);
            this.button_enviar.TabIndex = 4;
            this.button_enviar.Text = "Cambiar";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // FormDetalleCuotaCambiar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 164);
            this.Controls.Add(this.button_enviar);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_bloque);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDetalleCuotaCambiar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Detalle";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormDetalleCuotaCambiar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_bloque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.Button button_enviar;
    }
}