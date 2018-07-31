namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProveedoresForms
{
    partial class FormAnyadirProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnyadirProveedor));
            this.textBox_entidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_bloque = new System.Windows.Forms.ComboBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.comboBox_categoria = new System.Windows.Forms.ComboBox();
            this.textBox_ref = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_entidad
            // 
            this.textBox_entidad.Location = new System.Drawing.Point(99, 23);
            this.textBox_entidad.Name = "textBox_entidad";
            this.textBox_entidad.ReadOnly = true;
            this.textBox_entidad.Size = new System.Drawing.Size(261, 20);
            this.textBox_entidad.TabIndex = 0;
            this.textBox_entidad.Text = "Pulsa espacio para buscar Entidad";
            this.textBox_entidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_entidad_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entidad: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Categoria : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Descripción : ";
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(99, 86);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(184, 20);
            this.textBox_descripcion.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bloque : ";
            // 
            // comboBox_bloque
            // 
            this.comboBox_bloque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bloque.FormattingEnabled = true;
            this.comboBox_bloque.Location = new System.Drawing.Point(99, 146);
            this.comboBox_bloque.Name = "comboBox_bloque";
            this.comboBox_bloque.Size = new System.Drawing.Size(121, 21);
            this.comboBox_bloque.TabIndex = 6;
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(204, 210);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 8;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(285, 210);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 9;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // comboBox_categoria
            // 
            this.comboBox_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_categoria.FormattingEnabled = true;
            this.comboBox_categoria.Location = new System.Drawing.Point(99, 53);
            this.comboBox_categoria.Name = "comboBox_categoria";
            this.comboBox_categoria.Size = new System.Drawing.Size(184, 21);
            this.comboBox_categoria.TabIndex = 10;
            // 
            // textBox_ref
            // 
            this.textBox_ref.Location = new System.Drawing.Point(99, 116);
            this.textBox_ref.Name = "textBox_ref";
            this.textBox_ref.Size = new System.Drawing.Size(118, 20);
            this.textBox_ref.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ref. Contrato : ";
            // 
            // FormAnyadirProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 245);
            this.Controls.Add(this.textBox_ref);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_categoria);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.comboBox_bloque);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_descripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_entidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAnyadirProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Añadir Proveedor";
            this.Load += new System.EventHandler(this.FormAnyadirProveedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_entidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_bloque;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.ComboBox comboBox_categoria;
        private System.Windows.Forms.TextBox textBox_ref;
        private System.Windows.Forms.Label label5;
    }
}