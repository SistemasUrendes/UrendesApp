namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    partial class FormCorreos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCorreos));
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_principal = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.textBox_correo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_principal
            // 
            this.checkBox_principal.AutoSize = true;
            this.checkBox_principal.Location = new System.Drawing.Point(108, 98);
            this.checkBox_principal.Name = "checkBox_principal";
            this.checkBox_principal.Size = new System.Drawing.Size(66, 17);
            this.checkBox_principal.TabIndex = 2;
            this.checkBox_principal.Text = "Principal";
            this.checkBox_principal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Correo :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descripción :";
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_descripcion.Location = new System.Drawing.Point(108, 30);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(157, 20);
            this.textBox_descripcion.TabIndex = 0;
            // 
            // textBox_correo
            // 
            this.textBox_correo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox_correo.Location = new System.Drawing.Point(108, 64);
            this.textBox_correo.Name = "textBox_correo";
            this.textBox_correo.Size = new System.Drawing.Size(157, 20);
            this.textBox_correo.TabIndex = 1;
            this.textBox_correo.Leave += new System.EventHandler(this.textBox_correo_Leave);
            // 
            // FormCorreos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 171);
            this.Controls.Add(this.textBox_correo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_principal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_descripcion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCorreos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Correo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCorreos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_principal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.TextBox textBox_correo;
    }
}