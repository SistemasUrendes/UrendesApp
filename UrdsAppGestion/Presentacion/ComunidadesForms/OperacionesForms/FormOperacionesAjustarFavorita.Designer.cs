namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormOperacionesAjustarFavorita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperacionesAjustarFavorita));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_nuevo_nombre = new System.Windows.Forms.TextBox();
            this.maskedTextBox_nueva_fecha = new System.Windows.Forms.MaskedTextBox();
            this.textBox_documento = new System.Windows.Forms.TextBox();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.button_crear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo Importe :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nueva Fecha :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nuevo Documento :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nuevo Nombre :";
            // 
            // textBox_nuevo_nombre
            // 
            this.textBox_nuevo_nombre.Location = new System.Drawing.Point(130, 33);
            this.textBox_nuevo_nombre.Name = "textBox_nuevo_nombre";
            this.textBox_nuevo_nombre.Size = new System.Drawing.Size(226, 20);
            this.textBox_nuevo_nombre.TabIndex = 1;
            // 
            // maskedTextBox_nueva_fecha
            // 
            this.maskedTextBox_nueva_fecha.Location = new System.Drawing.Point(130, 68);
            this.maskedTextBox_nueva_fecha.Mask = "00/00/0000";
            this.maskedTextBox_nueva_fecha.Name = "maskedTextBox_nueva_fecha";
            this.maskedTextBox_nueva_fecha.Size = new System.Drawing.Size(70, 20);
            this.maskedTextBox_nueva_fecha.TabIndex = 2;
            this.maskedTextBox_nueva_fecha.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_nueva_fecha.Enter += new System.EventHandler(this.maskedTextBox_nueva_fecha_Enter);
            this.maskedTextBox_nueva_fecha.Leave += new System.EventHandler(this.maskedTextBox_nueva_fecha_Leave);
            // 
            // textBox_documento
            // 
            this.textBox_documento.Location = new System.Drawing.Point(130, 103);
            this.textBox_documento.Name = "textBox_documento";
            this.textBox_documento.Size = new System.Drawing.Size(100, 20);
            this.textBox_documento.TabIndex = 3;
            this.textBox_documento.Enter += new System.EventHandler(this.textBox_documento_Enter);
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(130, 138);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(70, 20);
            this.textBox_importe.TabIndex = 4;
            this.textBox_importe.TextChanged += new System.EventHandler(this.textBox_importe_TextChanged);
            this.textBox_importe.Enter += new System.EventHandler(this.textBox_importe_Enter);
            // 
            // button_crear
            // 
            this.button_crear.Location = new System.Drawing.Point(281, 183);
            this.button_crear.Name = "button_crear";
            this.button_crear.Size = new System.Drawing.Size(75, 23);
            this.button_crear.TabIndex = 5;
            this.button_crear.Text = "Crear Nueva";
            this.button_crear.UseVisualStyleBackColor = true;
            this.button_crear.Click += new System.EventHandler(this.button_crear_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(207, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Hoy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Actualizar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormOperacionesAjustarFavorita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 221);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_crear);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.textBox_documento);
            this.Controls.Add(this.maskedTextBox_nueva_fecha);
            this.Controls.Add(this.textBox_nuevo_nombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOperacionesAjustarFavorita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajustar Favorita";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormOperacionesAjustarFavorita_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_nuevo_nombre;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_nueva_fecha;
        private System.Windows.Forms.TextBox textBox_documento;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.Button button_crear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}