namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    partial class FormCrearCuentaComunidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrearCuentaComunidad));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_ajuste = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_compesacion = new System.Windows.Forms.CheckBox();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.textBox_num_cuenta = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_entidad_bancaria = new System.Windows.Forms.TextBox();
            this.checkBox_ppal = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción Cuenta :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número Cuenta :";
            // 
            // checkBox_ajuste
            // 
            this.checkBox_ajuste.AutoSize = true;
            this.checkBox_ajuste.Location = new System.Drawing.Point(215, 65);
            this.checkBox_ajuste.Name = "checkBox_ajuste";
            this.checkBox_ajuste.Size = new System.Drawing.Size(55, 17);
            this.checkBox_ajuste.TabIndex = 2;
            this.checkBox_ajuste.Text = "Ajuste";
            this.checkBox_ajuste.UseVisualStyleBackColor = true;
            this.checkBox_ajuste.CheckedChanged += new System.EventHandler(this.checkBox_ajuste_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo Cuenta :";
            // 
            // checkBox_compesacion
            // 
            this.checkBox_compesacion.AutoSize = true;
            this.checkBox_compesacion.Location = new System.Drawing.Point(295, 65);
            this.checkBox_compesacion.Name = "checkBox_compesacion";
            this.checkBox_compesacion.Size = new System.Drawing.Size(101, 17);
            this.checkBox_compesacion.TabIndex = 3;
            this.checkBox_compesacion.Text = "Compesaciones";
            this.checkBox_compesacion.UseVisualStyleBackColor = true;
            this.checkBox_compesacion.CheckedChanged += new System.EventHandler(this.checkBox_compesacion_CheckedChanged);
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(124, 34);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(304, 20);
            this.textBox_descripcion.TabIndex = 1;
            // 
            // textBox_num_cuenta
            // 
            this.textBox_num_cuenta.Location = new System.Drawing.Point(124, 122);
            this.textBox_num_cuenta.Name = "textBox_num_cuenta";
            this.textBox_num_cuenta.Size = new System.Drawing.Size(304, 20);
            this.textBox_num_cuenta.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(353, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Entidad Bancaria :";
            // 
            // textBox_entidad_bancaria
            // 
            this.textBox_entidad_bancaria.Location = new System.Drawing.Point(124, 92);
            this.textBox_entidad_bancaria.Name = "textBox_entidad_bancaria";
            this.textBox_entidad_bancaria.Size = new System.Drawing.Size(304, 20);
            this.textBox_entidad_bancaria.TabIndex = 4;
            this.textBox_entidad_bancaria.Text = "Pulse espacio para seleccionar Entidad";
            this.textBox_entidad_bancaria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_entidad_bancaria_KeyPress);
            // 
            // checkBox_ppal
            // 
            this.checkBox_ppal.AutoSize = true;
            this.checkBox_ppal.Location = new System.Drawing.Point(134, 65);
            this.checkBox_ppal.Name = "checkBox_ppal";
            this.checkBox_ppal.Size = new System.Drawing.Size(66, 17);
            this.checkBox_ppal.TabIndex = 10;
            this.checkBox_ppal.Text = "Principal";
            this.checkBox_ppal.UseVisualStyleBackColor = true;
            this.checkBox_ppal.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FormCrearCuentaComunidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 217);
            this.Controls.Add(this.checkBox_ppal);
            this.Controls.Add(this.textBox_entidad_bancaria);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_num_cuenta);
            this.Controls.Add(this.textBox_descripcion);
            this.Controls.Add(this.checkBox_compesacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox_ajuste);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCrearCuentaComunidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Cuenta Comunidad";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCrearCuentaComunidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_ajuste;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_compesacion;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.TextBox textBox_num_cuenta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_entidad_bancaria;
        private System.Windows.Forms.CheckBox checkBox_ppal;
    }
}