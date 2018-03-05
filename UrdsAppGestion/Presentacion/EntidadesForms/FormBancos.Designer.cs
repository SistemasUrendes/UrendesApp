namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    partial class FormBancos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBancos));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_principal = new System.Windows.Forms.CheckBox();
            this.textBox_CC = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CC : ";
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(88, 27);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(127, 20);
            this.textBox_descripcion.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_principal
            // 
            this.checkBox_principal.AutoSize = true;
            this.checkBox_principal.Location = new System.Drawing.Point(232, 29);
            this.checkBox_principal.Name = "checkBox_principal";
            this.checkBox_principal.Size = new System.Drawing.Size(66, 17);
            this.checkBox_principal.TabIndex = 5;
            this.checkBox_principal.Text = "Principal";
            this.checkBox_principal.UseVisualStyleBackColor = true;
            // 
            // textBox_CC
            // 
            this.textBox_CC.Location = new System.Drawing.Point(88, 58);
            this.textBox_CC.Mask = "CCCC CCCC CCCC CCCC CCCC CCCC";
            this.textBox_CC.Name = "textBox_CC";
            this.textBox_CC.Size = new System.Drawing.Size(210, 20);
            this.textBox_CC.TabIndex = 2;
            this.textBox_CC.Leave += new System.EventHandler(this.textBox_CC_Leave);
            // 
            // FormBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 145);
            this.Controls.Add(this.textBox_CC);
            this.Controls.Add(this.checkBox_principal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_descripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBancos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bancos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormBancos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_principal;
        private System.Windows.Forms.MaskedTextBox textBox_CC;
    }
}