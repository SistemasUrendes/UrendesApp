namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormInsertarContacto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInsertarContacto));
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCorreo = new System.Windows.Forms.TextBox();
            this.maskedTextBoxTelefono = new System.Windows.Forms.MaskedTextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonEntidad = new System.Windows.Forms.Button();
            this.buttonProveedores = new System.Windows.Forms.Button();
            this.buttonComuneros = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNotas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(65, 37);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(203, 20);
            this.textBoxNombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Teléfono:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Correo:";
            // 
            // textBoxCorreo
            // 
            this.textBoxCorreo.Location = new System.Drawing.Point(65, 99);
            this.textBoxCorreo.Name = "textBoxCorreo";
            this.textBoxCorreo.Size = new System.Drawing.Size(204, 20);
            this.textBoxCorreo.TabIndex = 2;
            this.textBoxCorreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCorreo_KeyPress);
            // 
            // maskedTextBoxTelefono
            // 
            this.maskedTextBoxTelefono.Location = new System.Drawing.Point(65, 68);
            this.maskedTextBoxTelefono.Name = "maskedTextBoxTelefono";
            this.maskedTextBoxTelefono.Size = new System.Drawing.Size(70, 20);
            this.maskedTextBoxTelefono.TabIndex = 1;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(193, 236);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 4;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(112, 236);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 3;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonEntidad
            // 
            this.buttonEntidad.Location = new System.Drawing.Point(65, 12);
            this.buttonEntidad.Name = "buttonEntidad";
            this.buttonEntidad.Size = new System.Drawing.Size(53, 20);
            this.buttonEntidad.TabIndex = 5;
            this.buttonEntidad.Text = "Entidad";
            this.buttonEntidad.UseVisualStyleBackColor = true;
            this.buttonEntidad.Click += new System.EventHandler(this.buttonEntidad_Click);
            // 
            // buttonProveedores
            // 
            this.buttonProveedores.Location = new System.Drawing.Point(126, 12);
            this.buttonProveedores.Name = "buttonProveedores";
            this.buttonProveedores.Size = new System.Drawing.Size(68, 20);
            this.buttonProveedores.TabIndex = 6;
            this.buttonProveedores.Text = "Proveedor";
            this.buttonProveedores.UseVisualStyleBackColor = true;
            this.buttonProveedores.Click += new System.EventHandler(this.buttonProveedores_Click);
            // 
            // buttonComuneros
            // 
            this.buttonComuneros.Location = new System.Drawing.Point(200, 12);
            this.buttonComuneros.Name = "buttonComuneros";
            this.buttonComuneros.Size = new System.Drawing.Size(68, 20);
            this.buttonComuneros.TabIndex = 7;
            this.buttonComuneros.Text = "Comunero";
            this.buttonComuneros.UseVisualStyleBackColor = true;
            this.buttonComuneros.Click += new System.EventHandler(this.buttonComuneros_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Notas:";
            // 
            // textBoxNotas
            // 
            this.textBoxNotas.Location = new System.Drawing.Point(65, 132);
            this.textBoxNotas.Multiline = true;
            this.textBoxNotas.Name = "textBoxNotas";
            this.textBoxNotas.Size = new System.Drawing.Size(203, 98);
            this.textBoxNotas.TabIndex = 10;
            // 
            // FormInsertarContacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 271);
            this.Controls.Add(this.textBoxNotas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonComuneros);
            this.Controls.Add(this.buttonProveedores);
            this.Controls.Add(this.buttonEntidad);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.maskedTextBoxTelefono);
            this.Controls.Add(this.textBoxCorreo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNombre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInsertarContacto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInsertarContacto";
            this.Load += new System.EventHandler(this.FormInsertarContacto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCorreo;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefono;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonEntidad;
        private System.Windows.Forms.Button buttonProveedores;
        private System.Windows.Forms.Button buttonComuneros;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNotas;
    }
}