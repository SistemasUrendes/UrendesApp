namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms
{
    partial class FormCuotasPlantillaAlta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCuotasPlantillaAlta));
            this.textBox_Plantilla = new System.Windows.Forms.TextBox();
            this.comboBox_TipoPlantilla = new System.Windows.Forms.ComboBox();
            this.checkBox_Activa = new System.Windows.Forms.CheckBox();
            this.label_Plantilla = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Plantilla
            // 
            this.textBox_Plantilla.AcceptsReturn = true;
            this.textBox_Plantilla.Location = new System.Drawing.Point(126, 50);
            this.textBox_Plantilla.Name = "textBox_Plantilla";
            this.textBox_Plantilla.Size = new System.Drawing.Size(243, 20);
            this.textBox_Plantilla.TabIndex = 0;
            // 
            // comboBox_TipoPlantilla
            // 
            this.comboBox_TipoPlantilla.FormattingEnabled = true;
            this.comboBox_TipoPlantilla.Location = new System.Drawing.Point(126, 74);
            this.comboBox_TipoPlantilla.Name = "comboBox_TipoPlantilla";
            this.comboBox_TipoPlantilla.Size = new System.Drawing.Size(192, 21);
            this.comboBox_TipoPlantilla.TabIndex = 1;
            // 
            // checkBox_Activa
            // 
            this.checkBox_Activa.AutoSize = true;
            this.checkBox_Activa.Location = new System.Drawing.Point(332, 16);
            this.checkBox_Activa.Name = "checkBox_Activa";
            this.checkBox_Activa.Size = new System.Drawing.Size(56, 17);
            this.checkBox_Activa.TabIndex = 2;
            this.checkBox_Activa.Text = "Activa";
            this.checkBox_Activa.UseVisualStyleBackColor = true;
            // 
            // label_Plantilla
            // 
            this.label_Plantilla.AutoSize = true;
            this.label_Plantilla.Location = new System.Drawing.Point(27, 53);
            this.label_Plantilla.Name = "label_Plantilla";
            this.label_Plantilla.Size = new System.Drawing.Size(46, 13);
            this.label_Plantilla.TabIndex = 4;
            this.label_Plantilla.Text = "Plantilla:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipo de Plantilla:";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(232, 115);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 23);
            this.button_Guardar.TabIndex = 6;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(313, 115);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 7;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            // 
            // FormCuotasPlantillaAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 159);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Plantilla);
            this.Controls.Add(this.checkBox_Activa);
            this.Controls.Add(this.comboBox_TipoPlantilla);
            this.Controls.Add(this.textBox_Plantilla);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCuotasPlantillaAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edición Plantillas de Cuotas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCuotasPlantillaAlta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Plantilla;
        private System.Windows.Forms.ComboBox comboBox_TipoPlantilla;
        private System.Windows.Forms.CheckBox checkBox_Activa;
        private System.Windows.Forms.Label label_Plantilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cancelar;
    }
}