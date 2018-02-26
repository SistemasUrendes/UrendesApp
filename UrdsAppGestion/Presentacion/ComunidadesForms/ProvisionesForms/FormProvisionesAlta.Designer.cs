namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProvisionesForms
{
    partial class FormProvisionesAlta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProvisionesAlta));
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_NombreProvision = new System.Windows.Forms.TextBox();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_bloques = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SubCuenta :";
            // 
            // textBox_NombreProvision
            // 
            this.textBox_NombreProvision.Location = new System.Drawing.Point(136, 65);
            this.textBox_NombreProvision.Name = "textBox_NombreProvision";
            this.textBox_NombreProvision.ReadOnly = true;
            this.textBox_NombreProvision.Size = new System.Drawing.Size(215, 20);
            this.textBox_NombreProvision.TabIndex = 2;
            this.textBox_NombreProvision.TabStop = false;
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(216, 147);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 23);
            this.button_Guardar.TabIndex = 3;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(297, 147);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 5;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Bloque : ";
            // 
            // textBox_bloques
            // 
            this.textBox_bloques.Location = new System.Drawing.Point(136, 101);
            this.textBox_bloques.Name = "textBox_bloques";
            this.textBox_bloques.ReadOnly = true;
            this.textBox_bloques.Size = new System.Drawing.Size(236, 20);
            this.textBox_bloques.TabIndex = 2;
            this.textBox_bloques.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_bloques_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(205, 29);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.ReadOnly = true;
            this.maskedTextBox1.Size = new System.Drawing.Size(65, 20);
            this.maskedTextBox1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nombre Provisión :";
            // 
            // FormProvisionesAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 195);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_bloques);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.textBox_NombreProvision);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProvisionesAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edición de Provisiones";
            this.Load += new System.EventHandler(this.FormProvisionesAlta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_NombreProvision;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_bloques;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
    }
}