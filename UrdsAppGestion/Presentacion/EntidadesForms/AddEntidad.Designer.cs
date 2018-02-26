namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    partial class AddEntidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEntidad));
            this.textBox_nombre_largo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_nombre_corto = new System.Windows.Forms.TextBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.textBox_notas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textbox_cif = new System.Windows.Forms.MaskedTextBox();
            this.button_volver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_nombre_largo
            // 
            this.textBox_nombre_largo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_nombre_largo.Location = new System.Drawing.Point(126, 42);
            this.textBox_nombre_largo.Name = "textBox_nombre_largo";
            this.textBox_nombre_largo.Size = new System.Drawing.Size(338, 20);
            this.textBox_nombre_largo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Entidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre Corto";
            // 
            // textBox_nombre_corto
            // 
            this.textBox_nombre_corto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_nombre_corto.Location = new System.Drawing.Point(126, 72);
            this.textBox_nombre_corto.Name = "textBox_nombre_corto";
            this.textBox_nombre_corto.Size = new System.Drawing.Size(181, 20);
            this.textBox_nombre_corto.TabIndex = 1;
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(308, 225);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 4;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // textBox_notas
            // 
            this.textBox_notas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_notas.Location = new System.Drawing.Point(126, 132);
            this.textBox_notas.Multiline = true;
            this.textBox_notas.Name = "textBox_notas";
            this.textBox_notas.Size = new System.Drawing.Size(338, 77);
            this.textBox_notas.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Notas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "CIF";
            // 
            // textbox_cif
            // 
            this.textbox_cif.BeepOnError = true;
            this.textbox_cif.Location = new System.Drawing.Point(126, 102);
            this.textbox_cif.Mask = "CCCCCCCCC";
            this.textbox_cif.Name = "textbox_cif";
            this.textbox_cif.Size = new System.Drawing.Size(100, 20);
            this.textbox_cif.TabIndex = 2;
            // 
            // button_volver
            // 
            this.button_volver.Location = new System.Drawing.Point(389, 225);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(75, 23);
            this.button_volver.TabIndex = 10;
            this.button_volver.Text = "Cerrar";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // AddEntidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 263);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.textbox_cif);
            this.Controls.Add(this.textBox_notas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.textBox_nombre_corto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_nombre_largo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEntidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Añadir Entidad";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddEntidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_nombre_largo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_nombre_corto;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.TextBox textBox_notas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox textbox_cif;
        private System.Windows.Forms.Button button_volver;
    }
}