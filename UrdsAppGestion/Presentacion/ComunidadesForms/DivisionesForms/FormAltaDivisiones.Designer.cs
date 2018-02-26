namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    partial class FormAltaDivisiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAltaDivisiones));
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.textBox_Cuota = new System.Windows.Forms.TextBox();
            this.comboBox_Tipo = new System.Windows.Forms.ComboBox();
            this.textBox_Orden = new System.Windows.Forms.TextBox();
            this.checkBox_Excluido = new System.Windows.Forms.CheckBox();
            this.textBox_Notas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_notas = new System.Windows.Forms.Label();
            this.label_tipo = new System.Windows.Forms.Label();
            this.label_cuota = new System.Windows.Forms.Label();
            this.label_orden = new System.Windows.Forms.Label();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_guardar = new System.Windows.Forms.Button();
            this.label_nombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(116, 22);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(166, 20);
            this.textBox_Nombre.TabIndex = 0;
            // 
            // textBox_Cuota
            // 
            this.textBox_Cuota.Location = new System.Drawing.Point(116, 75);
            this.textBox_Cuota.Name = "textBox_Cuota";
            this.textBox_Cuota.Size = new System.Drawing.Size(166, 20);
            this.textBox_Cuota.TabIndex = 2;
            // 
            // comboBox_Tipo
            // 
            this.comboBox_Tipo.FormattingEnabled = true;
            this.comboBox_Tipo.Location = new System.Drawing.Point(116, 48);
            this.comboBox_Tipo.Name = "comboBox_Tipo";
            this.comboBox_Tipo.Size = new System.Drawing.Size(165, 21);
            this.comboBox_Tipo.TabIndex = 1;
            // 
            // textBox_Orden
            // 
            this.textBox_Orden.Location = new System.Drawing.Point(116, 101);
            this.textBox_Orden.Name = "textBox_Orden";
            this.textBox_Orden.Size = new System.Drawing.Size(166, 20);
            this.textBox_Orden.TabIndex = 3;
            // 
            // checkBox_Excluido
            // 
            this.checkBox_Excluido.AutoSize = true;
            this.checkBox_Excluido.Location = new System.Drawing.Point(116, 127);
            this.checkBox_Excluido.Name = "checkBox_Excluido";
            this.checkBox_Excluido.Size = new System.Drawing.Size(66, 17);
            this.checkBox_Excluido.TabIndex = 4;
            this.checkBox_Excluido.Text = "Excluida";
            this.checkBox_Excluido.UseVisualStyleBackColor = true;
            // 
            // textBox_Notas
            // 
            this.textBox_Notas.Location = new System.Drawing.Point(116, 151);
            this.textBox_Notas.Multiline = true;
            this.textBox_Notas.Name = "textBox_Notas";
            this.textBox_Notas.Size = new System.Drawing.Size(378, 86);
            this.textBox_Notas.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 13;
            // 
            // label_notas
            // 
            this.label_notas.AutoSize = true;
            this.label_notas.Location = new System.Drawing.Point(35, 154);
            this.label_notas.Name = "label_notas";
            this.label_notas.Size = new System.Drawing.Size(38, 13);
            this.label_notas.TabIndex = 7;
            this.label_notas.Text = "Notas:";
            // 
            // label_tipo
            // 
            this.label_tipo.AutoSize = true;
            this.label_tipo.Location = new System.Drawing.Point(35, 51);
            this.label_tipo.Name = "label_tipo";
            this.label_tipo.Size = new System.Drawing.Size(31, 13);
            this.label_tipo.TabIndex = 8;
            this.label_tipo.Text = "Tipo:";
            // 
            // label_cuota
            // 
            this.label_cuota.AutoSize = true;
            this.label_cuota.Location = new System.Drawing.Point(35, 78);
            this.label_cuota.Name = "label_cuota";
            this.label_cuota.Size = new System.Drawing.Size(38, 13);
            this.label_cuota.TabIndex = 9;
            this.label_cuota.Text = "Cuota:";
            // 
            // label_orden
            // 
            this.label_orden.AutoSize = true;
            this.label_orden.Location = new System.Drawing.Point(35, 104);
            this.label_orden.Name = "label_orden";
            this.label_orden.Size = new System.Drawing.Size(69, 13);
            this.label_orden.TabIndex = 10;
            this.label_orden.Text = "Nº de Orden:";
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(445, 256);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 7;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(364, 256);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 6;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // label_nombre
            // 
            this.label_nombre.AutoSize = true;
            this.label_nombre.Location = new System.Drawing.Point(35, 25);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Size = new System.Drawing.Size(47, 13);
            this.label_nombre.TabIndex = 14;
            this.label_nombre.Text = "Nombre:";
            // 
            // FormAltaDivisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 298);
            this.Controls.Add(this.label_nombre);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.label_orden);
            this.Controls.Add(this.label_cuota);
            this.Controls.Add(this.label_tipo);
            this.Controls.Add(this.label_notas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Notas);
            this.Controls.Add(this.checkBox_Excluido);
            this.Controls.Add(this.textBox_Orden);
            this.Controls.Add(this.comboBox_Tipo);
            this.Controls.Add(this.textBox_Cuota);
            this.Controls.Add(this.textBox_Nombre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAltaDivisiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Divisiones Edición";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAltaDivisiones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.TextBox textBox_Cuota;
        private System.Windows.Forms.ComboBox comboBox_Tipo;
        private System.Windows.Forms.TextBox textBox_Orden;
        private System.Windows.Forms.CheckBox checkBox_Excluido;
        private System.Windows.Forms.TextBox textBox_Notas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_notas;
        private System.Windows.Forms.Label label_tipo;
        private System.Windows.Forms.Label label_cuota;
        private System.Windows.Forms.Label label_orden;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Label label_nombre;
    }
}