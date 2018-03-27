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
            this.checkBox_Activa = new System.Windows.Forms.CheckBox();
            this.label_Plantilla = new System.Windows.Forms.Label();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_abono = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox_Plantilla
            // 
            this.textBox_Plantilla.AcceptsReturn = true;
            this.textBox_Plantilla.Location = new System.Drawing.Point(79, 31);
            this.textBox_Plantilla.Name = "textBox_Plantilla";
            this.textBox_Plantilla.Size = new System.Drawing.Size(201, 20);
            this.textBox_Plantilla.TabIndex = 0;
            // 
            // checkBox_Activa
            // 
            this.checkBox_Activa.AutoSize = true;
            this.checkBox_Activa.Location = new System.Drawing.Point(79, 60);
            this.checkBox_Activa.Name = "checkBox_Activa";
            this.checkBox_Activa.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Activa.TabIndex = 2;
            this.checkBox_Activa.UseVisualStyleBackColor = true;
            // 
            // label_Plantilla
            // 
            this.label_Plantilla.AutoSize = true;
            this.label_Plantilla.Location = new System.Drawing.Point(27, 34);
            this.label_Plantilla.Name = "label_Plantilla";
            this.label_Plantilla.Size = new System.Drawing.Size(46, 13);
            this.label_Plantilla.TabIndex = 4;
            this.label_Plantilla.Text = "Plantilla:";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(124, 104);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 23);
            this.button_Guardar.TabIndex = 6;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(205, 104);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 7;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Activa: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Abono:";
            // 
            // checkBox_abono
            // 
            this.checkBox_abono.AutoSize = true;
            this.checkBox_abono.Location = new System.Drawing.Point(79, 84);
            this.checkBox_abono.Name = "checkBox_abono";
            this.checkBox_abono.Size = new System.Drawing.Size(15, 14);
            this.checkBox_abono.TabIndex = 10;
            this.checkBox_abono.UseVisualStyleBackColor = true;
            // 
            // FormCuotasPlantillaAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 150);
            this.Controls.Add(this.checkBox_abono);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.label_Plantilla);
            this.Controls.Add(this.checkBox_Activa);
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
        private System.Windows.Forms.CheckBox checkBox_Activa;
        private System.Windows.Forms.Label label_Plantilla;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_abono;
    }
}