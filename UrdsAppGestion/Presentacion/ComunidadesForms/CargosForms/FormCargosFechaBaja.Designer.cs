namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    partial class FormCargosFechaBaja
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
            this.maskedTextBox_fecha = new System.Windows.Forms.MaskedTextBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // maskedTextBox_fecha
            // 
            this.maskedTextBox_fecha.Location = new System.Drawing.Point(130, 26);
            this.maskedTextBox_fecha.Mask = "00/00/0000";
            this.maskedTextBox_fecha.Name = "maskedTextBox_fecha";
            this.maskedTextBox_fecha.Size = new System.Drawing.Size(76, 20);
            this.maskedTextBox_fecha.TabIndex = 0;
            this.maskedTextBox_fecha.ValidatingType = typeof(System.DateTime);
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(98, 52);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 1;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha de Baja : ";
            // 
            // FormCargosFechaBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 98);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.maskedTextBox_fecha);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCargosFechaBaja";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fecha Baja";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CargosFormFechaBaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox_fecha;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Label label1;
    }
}