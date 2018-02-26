namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.ReglasPago
{
    partial class FormAnyadirRegla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnyadirRegla));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.comboBox_tipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_activa = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_division = new System.Windows.Forms.TextBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción :";
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(118, 27);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(202, 20);
            this.textBox_descripcion.TabIndex = 1;
            // 
            // comboBox_tipo
            // 
            this.comboBox_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tipo.FormattingEnabled = true;
            this.comboBox_tipo.Location = new System.Drawing.Point(118, 88);
            this.comboBox_tipo.Name = "comboBox_tipo";
            this.comboBox_tipo.Size = new System.Drawing.Size(121, 21);
            this.comboBox_tipo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo de Cuota :";
            // 
            // checkBox_activa
            // 
            this.checkBox_activa.AutoSize = true;
            this.checkBox_activa.Checked = true;
            this.checkBox_activa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_activa.Location = new System.Drawing.Point(118, 124);
            this.checkBox_activa.Name = "checkBox_activa";
            this.checkBox_activa.Size = new System.Drawing.Size(90, 17);
            this.checkBox_activa.TabIndex = 4;
            this.checkBox_activa.Text = "Activar Regla";
            this.checkBox_activa.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "División :";
            // 
            // textBox_division
            // 
            this.textBox_division.Enabled = false;
            this.textBox_division.Location = new System.Drawing.Point(118, 57);
            this.textBox_division.Name = "textBox_division";
            this.textBox_division.ReadOnly = true;
            this.textBox_division.Size = new System.Drawing.Size(121, 20);
            this.textBox_division.TabIndex = 6;
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(174, 157);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 7;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(255, 157);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 8;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // FormAnyadirRegla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 193);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.textBox_division);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox_activa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_tipo);
            this.Controls.Add(this.textBox_descripcion);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAnyadirRegla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Añadir Regla";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAnyadirRegla_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.ComboBox comboBox_tipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_activa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_division;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Button button_cancelar;
    }
}