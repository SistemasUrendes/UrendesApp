namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    partial class FormAltaAsociacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAltaAsociacion));
            this.textBox_Comunero = new System.Windows.Forms.TextBox();
            this.textBox_porcentaje = new System.Windows.Forms.TextBox();
            this.checkBox_representante = new System.Windows.Forms.CheckBox();
            this.label_comunero = new System.Windows.Forms.Label();
            this.label_fechadebaja = new System.Windows.Forms.Label();
            this.label_fecahdealta = new System.Windows.Forms.Label();
            this.label_porcentaje = new System.Windows.Forms.Label();
            this.label_asociacion = new System.Windows.Forms.Label();
            this.comboBox_tipoasociacion = new System.Windows.Forms.ComboBox();
            this.button_guardar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.textBox_fechaalta = new System.Windows.Forms.MaskedTextBox();
            this.textBox_fechabaja = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Comunero
            // 
            this.textBox_Comunero.Location = new System.Drawing.Point(121, 30);
            this.textBox_Comunero.Name = "textBox_Comunero";
            this.textBox_Comunero.ReadOnly = true;
            this.textBox_Comunero.Size = new System.Drawing.Size(287, 20);
            this.textBox_Comunero.TabIndex = 0;
            this.textBox_Comunero.Text = "Pulse espacio para buscar un Comunero";
            this.textBox_Comunero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Comunero_KeyPress);
            // 
            // textBox_porcentaje
            // 
            this.textBox_porcentaje.Location = new System.Drawing.Point(121, 82);
            this.textBox_porcentaje.Name = "textBox_porcentaje";
            this.textBox_porcentaje.Size = new System.Drawing.Size(100, 20);
            this.textBox_porcentaje.TabIndex = 2;
            // 
            // checkBox_representante
            // 
            this.checkBox_representante.AutoSize = true;
            this.checkBox_representante.Location = new System.Drawing.Point(121, 171);
            this.checkBox_representante.Name = "checkBox_representante";
            this.checkBox_representante.Size = new System.Drawing.Size(96, 17);
            this.checkBox_representante.TabIndex = 6;
            this.checkBox_representante.Text = "Representante";
            this.checkBox_representante.UseVisualStyleBackColor = true;
            this.checkBox_representante.CheckedChanged += new System.EventHandler(this.checkBox_representante_CheckedChanged);
            // 
            // label_comunero
            // 
            this.label_comunero.AutoSize = true;
            this.label_comunero.Location = new System.Drawing.Point(50, 33);
            this.label_comunero.Name = "label_comunero";
            this.label_comunero.Size = new System.Drawing.Size(58, 13);
            this.label_comunero.TabIndex = 7;
            this.label_comunero.Text = "Comunero:";
            // 
            // label_fechadebaja
            // 
            this.label_fechadebaja.AutoSize = true;
            this.label_fechadebaja.Location = new System.Drawing.Point(50, 137);
            this.label_fechadebaja.Name = "label_fechadebaja";
            this.label_fechadebaja.Size = new System.Drawing.Size(43, 13);
            this.label_fechadebaja.TabIndex = 9;
            this.label_fechadebaja.Text = "F. Baja:";
            // 
            // label_fecahdealta
            // 
            this.label_fecahdealta.AutoSize = true;
            this.label_fecahdealta.Location = new System.Drawing.Point(50, 111);
            this.label_fecahdealta.Name = "label_fecahdealta";
            this.label_fecahdealta.Size = new System.Drawing.Size(40, 13);
            this.label_fecahdealta.TabIndex = 10;
            this.label_fecahdealta.Text = "F. Alta:";
            // 
            // label_porcentaje
            // 
            this.label_porcentaje.AutoSize = true;
            this.label_porcentaje.Location = new System.Drawing.Point(50, 85);
            this.label_porcentaje.Name = "label_porcentaje";
            this.label_porcentaje.Size = new System.Drawing.Size(61, 13);
            this.label_porcentaje.TabIndex = 11;
            this.label_porcentaje.Text = "Porcentaje:";
            // 
            // label_asociacion
            // 
            this.label_asociacion.AutoSize = true;
            this.label_asociacion.Location = new System.Drawing.Point(50, 59);
            this.label_asociacion.Name = "label_asociacion";
            this.label_asociacion.Size = new System.Drawing.Size(62, 13);
            this.label_asociacion.TabIndex = 13;
            this.label_asociacion.Text = "Asociación:";
            // 
            // comboBox_tipoasociacion
            // 
            this.comboBox_tipoasociacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tipoasociacion.FormattingEnabled = true;
            this.comboBox_tipoasociacion.Location = new System.Drawing.Point(121, 55);
            this.comboBox_tipoasociacion.Name = "comboBox_tipoasociacion";
            this.comboBox_tipoasociacion.Size = new System.Drawing.Size(121, 21);
            this.comboBox_tipoasociacion.TabIndex = 1;
            this.comboBox_tipoasociacion.SelectionChangeCommitted += new System.EventHandler(this.comboBox_tipoasociacion_SelectionChangeCommitted);
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(251, 187);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 7;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(333, 187);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 8;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // textBox_fechaalta
            // 
            this.textBox_fechaalta.Location = new System.Drawing.Point(121, 108);
            this.textBox_fechaalta.Mask = "00/00/0000";
            this.textBox_fechaalta.Name = "textBox_fechaalta";
            this.textBox_fechaalta.Size = new System.Drawing.Size(72, 20);
            this.textBox_fechaalta.TabIndex = 3;
            this.textBox_fechaalta.ValidatingType = typeof(System.DateTime);
            // 
            // textBox_fechabaja
            // 
            this.textBox_fechabaja.Location = new System.Drawing.Point(121, 134);
            this.textBox_fechabaja.Mask = "00/00/0000";
            this.textBox_fechabaja.Name = "textBox_fechabaja";
            this.textBox_fechabaja.Size = new System.Drawing.Size(72, 20);
            this.textBox_fechabaja.TabIndex = 4;
            this.textBox_fechabaja.ValidatingType = typeof(System.DateTime);
            this.textBox_fechabaja.Leave += new System.EventHandler(this.textBox_fechabaja_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(227, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Poner 0.5 para 50% o 1 para 100%";
            // 
            // FormAltaAsociacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 230);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_fechabaja);
            this.Controls.Add(this.textBox_fechaalta);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.comboBox_tipoasociacion);
            this.Controls.Add(this.label_asociacion);
            this.Controls.Add(this.label_porcentaje);
            this.Controls.Add(this.label_fecahdealta);
            this.Controls.Add(this.label_fechadebaja);
            this.Controls.Add(this.label_comunero);
            this.Controls.Add(this.checkBox_representante);
            this.Controls.Add(this.textBox_porcentaje);
            this.Controls.Add(this.textBox_Comunero);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAltaAsociacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asociaciones Edición";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAltaAsociacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Comunero;
        private System.Windows.Forms.TextBox textBox_porcentaje;
        private System.Windows.Forms.CheckBox checkBox_representante;
        private System.Windows.Forms.Label label_comunero;
        private System.Windows.Forms.Label label_fechadebaja;
        private System.Windows.Forms.Label label_fecahdealta;
        private System.Windows.Forms.Label label_porcentaje;
        private System.Windows.Forms.Label label_asociacion;
        private System.Windows.Forms.ComboBox comboBox_tipoasociacion;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.MaskedTextBox textBox_fechaalta;
        private System.Windows.Forms.MaskedTextBox textBox_fechabaja;
        private System.Windows.Forms.Label label1;
    }
}