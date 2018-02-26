namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    partial class FormReasignarPagador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReasignarPagador));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_id_op = new System.Windows.Forms.TextBox();
            this.textBox_vieja_entidad = new System.Windows.Forms.TextBox();
            this.textBox_nueva_entidad = new System.Windows.Forms.TextBox();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IdOp : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Entidad Actual : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nueva Entidad :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Importe Pte :";
            // 
            // textBox_id_op
            // 
            this.textBox_id_op.Enabled = false;
            this.textBox_id_op.Location = new System.Drawing.Point(112, 26);
            this.textBox_id_op.Name = "textBox_id_op";
            this.textBox_id_op.Size = new System.Drawing.Size(62, 20);
            this.textBox_id_op.TabIndex = 4;
            // 
            // textBox_vieja_entidad
            // 
            this.textBox_vieja_entidad.Enabled = false;
            this.textBox_vieja_entidad.Location = new System.Drawing.Point(112, 58);
            this.textBox_vieja_entidad.Name = "textBox_vieja_entidad";
            this.textBox_vieja_entidad.Size = new System.Drawing.Size(215, 20);
            this.textBox_vieja_entidad.TabIndex = 5;
            // 
            // textBox_nueva_entidad
            // 
            this.textBox_nueva_entidad.Location = new System.Drawing.Point(112, 90);
            this.textBox_nueva_entidad.Name = "textBox_nueva_entidad";
            this.textBox_nueva_entidad.Size = new System.Drawing.Size(215, 20);
            this.textBox_nueva_entidad.TabIndex = 6;
            this.textBox_nueva_entidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_nueva_entidad_KeyPress);
            // 
            // textBox_importe
            // 
            this.textBox_importe.Enabled = false;
            this.textBox_importe.Location = new System.Drawing.Point(112, 122);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(94, 20);
            this.textBox_importe.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Reasignar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(278, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormReasignarOperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 202);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.textBox_nueva_entidad);
            this.Controls.Add(this.textBox_vieja_entidad);
            this.Controls.Add(this.textBox_id_op);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReasignarOperacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reasignar Operacion";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormReasignarOperacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_id_op;
        private System.Windows.Forms.TextBox textBox_vieja_entidad;
        private System.Windows.Forms.TextBox textBox_nueva_entidad;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}