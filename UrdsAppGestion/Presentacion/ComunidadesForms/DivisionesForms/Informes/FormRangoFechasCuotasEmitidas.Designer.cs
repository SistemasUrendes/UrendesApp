namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes
{
    partial class FormRangoFechasCuotasEmitidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRangoFechasCuotasEmitidas));
            this.maskedTextBox_fini = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_ffin = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskedTextBox_fini
            // 
            this.maskedTextBox_fini.Location = new System.Drawing.Point(113, 20);
            this.maskedTextBox_fini.Mask = "00/00/0000";
            this.maskedTextBox_fini.Name = "maskedTextBox_fini";
            this.maskedTextBox_fini.Size = new System.Drawing.Size(68, 20);
            this.maskedTextBox_fini.TabIndex = 0;
            this.maskedTextBox_fini.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_fini.Leave += new System.EventHandler(this.maskedTextBox_fini_Leave);
            // 
            // maskedTextBox_ffin
            // 
            this.maskedTextBox_ffin.Location = new System.Drawing.Point(237, 20);
            this.maskedTextBox_ffin.Mask = "00/00/0000";
            this.maskedTextBox_ffin.Name = "maskedTextBox_ffin";
            this.maskedTextBox_ffin.Size = new System.Drawing.Size(70, 20);
            this.maskedTextBox_ffin.TabIndex = 1;
            this.maskedTextBox_ffin.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_ffin.Leave += new System.EventHandler(this.maskedTextBox_ffin_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta : ";
            // 
            // button_ver
            // 
            this.button_ver.Location = new System.Drawing.Point(141, 55);
            this.button_ver.Name = "button_ver";
            this.button_ver.Size = new System.Drawing.Size(75, 23);
            this.button_ver.TabIndex = 4;
            this.button_ver.Text = "Ver Informe";
            this.button_ver.UseVisualStyleBackColor = true;
            this.button_ver.Click += new System.EventHandler(this.button_ver_Click);
            // 
            // FormRangoFechasCuotasEmitidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 97);
            this.Controls.Add(this.button_ver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox_ffin);
            this.Controls.Add(this.maskedTextBox_fini);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRangoFechasCuotasEmitidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuotas Emitidas";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox_fini;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ffin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_ver;
    }
}