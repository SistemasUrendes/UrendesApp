namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms
{
    partial class FormAnyadirNotaLiq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnyadirNotaLiq));
            this.textBox_notas = new System.Windows.Forms.TextBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_notas
            // 
            this.textBox_notas.Location = new System.Drawing.Point(12, 12);
            this.textBox_notas.Multiline = true;
            this.textBox_notas.Name = "textBox_notas";
            this.textBox_notas.Size = new System.Drawing.Size(418, 184);
            this.textBox_notas.TabIndex = 0;
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(355, 202);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 1;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // FormAnyadirNotaLiq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 233);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.textBox_notas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAnyadirNotaLiq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Añadir Nota";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAnyadirNotaLiq_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_notas;
        private System.Windows.Forms.Button button_guardar;
    }
}