namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProvisionesForms
{
    partial class FormProvisionesDotarAplicar1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProvisionesDotarAplicar1));
            this.listBox_provisiones = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_provisiones
            // 
            this.listBox_provisiones.FormattingEnabled = true;
            this.listBox_provisiones.Location = new System.Drawing.Point(12, 12);
            this.listBox_provisiones.Name = "listBox_provisiones";
            this.listBox_provisiones.Size = new System.Drawing.Size(221, 199);
            this.listBox_provisiones.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Siguiente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormProvisionesDotarAplicar1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 253);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox_provisiones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProvisionesDotarAplicar1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Provisiones";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormProvisionesDotarAplicar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_provisiones;
        private System.Windows.Forms.Button button1;
    }
}