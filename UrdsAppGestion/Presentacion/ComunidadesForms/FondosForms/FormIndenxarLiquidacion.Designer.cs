namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms
{
    partial class FormIndenxarLiquidacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIndenxarLiquidacion));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_liquidacion = new System.Windows.Forms.ComboBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Liquidación: ";
            // 
            // comboBox_liquidacion
            // 
            this.comboBox_liquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_liquidacion.FormattingEnabled = true;
            this.comboBox_liquidacion.Location = new System.Drawing.Point(102, 25);
            this.comboBox_liquidacion.Name = "comboBox_liquidacion";
            this.comboBox_liquidacion.Size = new System.Drawing.Size(145, 21);
            this.comboBox_liquidacion.TabIndex = 2;
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(102, 60);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 3;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // FormIndenxarLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 102);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.comboBox_liquidacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormIndenxarLiquidacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indenxar Liquidación";
            this.Load += new System.EventHandler(this.FormIndenxarLiquidacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_liquidacion;
        private System.Windows.Forms.Button button_guardar;
    }
}