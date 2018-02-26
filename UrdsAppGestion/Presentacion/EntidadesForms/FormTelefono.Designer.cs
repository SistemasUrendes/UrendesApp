namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    partial class FormTelefono
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
            this.maskedTextBox_telefono = new System.Windows.Forms.MaskedTextBox();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_principal = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskedTextBox_telefono
            // 
            this.maskedTextBox_telefono.Location = new System.Drawing.Point(92, 58);
            this.maskedTextBox_telefono.Mask = "999999999";
            this.maskedTextBox_telefono.Name = "maskedTextBox_telefono";
            this.maskedTextBox_telefono.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox_telefono.TabIndex = 2;
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(92, 27);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(157, 20);
            this.textBox_descripcion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Descripción :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Teléfono :";
            // 
            // checkBox_principal
            // 
            this.checkBox_principal.AutoSize = true;
            this.checkBox_principal.Location = new System.Drawing.Point(92, 95);
            this.checkBox_principal.Name = "checkBox_principal";
            this.checkBox_principal.Size = new System.Drawing.Size(66, 17);
            this.checkBox_principal.TabIndex = 3;
            this.checkBox_principal.Text = "Principal";
            this.checkBox_principal.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTelefono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 161);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_principal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_descripcion);
            this.Controls.Add(this.maskedTextBox_telefono);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTelefono";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telefono";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTelefono_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox_telefono;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_principal;
        private System.Windows.Forms.Button button1;
    }
}