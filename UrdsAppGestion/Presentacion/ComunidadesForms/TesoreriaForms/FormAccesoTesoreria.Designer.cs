namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    partial class FormAccesoTesoreria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccesoTesoreria));
            this.listBox_cuentas = new System.Windows.Forms.ListBox();
            this.button_abrir_tesoreria = new System.Windows.Forms.Button();
            this.label_comunidad = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_cuentas
            // 
            this.listBox_cuentas.FormattingEnabled = true;
            this.listBox_cuentas.Location = new System.Drawing.Point(12, 71);
            this.listBox_cuentas.Name = "listBox_cuentas";
            this.listBox_cuentas.Size = new System.Drawing.Size(193, 186);
            this.listBox_cuentas.TabIndex = 0;
            this.listBox_cuentas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_cuentas_MouseDoubleClick);
            // 
            // button_abrir_tesoreria
            // 
            this.button_abrir_tesoreria.Location = new System.Drawing.Point(12, 263);
            this.button_abrir_tesoreria.Name = "button_abrir_tesoreria";
            this.button_abrir_tesoreria.Size = new System.Drawing.Size(190, 23);
            this.button_abrir_tesoreria.TabIndex = 1;
            this.button_abrir_tesoreria.Text = "Abrir";
            this.button_abrir_tesoreria.UseVisualStyleBackColor = true;
            this.button_abrir_tesoreria.Click += new System.EventHandler(this.button_abrir_tesoreria_Click);
            // 
            // label_comunidad
            // 
            this.label_comunidad.AutoSize = true;
            this.label_comunidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_comunidad.Location = new System.Drawing.Point(30, 24);
            this.label_comunidad.Name = "label_comunidad";
            this.label_comunidad.Size = new System.Drawing.Size(76, 16);
            this.label_comunidad.TabIndex = 2;
            this.label_comunidad.Text = "Tesoreria";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Crear Cuenta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAccesoTesoreria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_comunidad);
            this.Controls.Add(this.button_abrir_tesoreria);
            this.Controls.Add(this.listBox_cuentas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAccesoTesoreria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso Tesoreria";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAccesoTesoreria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_cuentas;
        private System.Windows.Forms.Button button_abrir_tesoreria;
        private System.Windows.Forms.Label label_comunidad;
        private System.Windows.Forms.Button button1;
    }
}