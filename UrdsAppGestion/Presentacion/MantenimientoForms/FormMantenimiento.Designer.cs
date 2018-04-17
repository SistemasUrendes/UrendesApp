namespace UrdsAppGestión.Presentacion
{
    partial class FormMantenimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMantenimiento));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_fusionar = new System.Windows.Forms.Button();
            this.textBox_fusionar_nuevo = new System.Windows.Forms.TextBox();
            this.textBox_fusionar_viejo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_borradoMultiple = new System.Windows.Forms.Button();
            this.button_insertarPendientes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IdEntidad Antiguo : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_fusionar);
            this.groupBox1.Controls.Add(this.textBox_fusionar_nuevo);
            this.groupBox1.Controls.Add(this.textBox_fusionar_viejo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(40, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fusionar Entidades";
            // 
            // button_fusionar
            // 
            this.button_fusionar.Location = new System.Drawing.Point(241, 27);
            this.button_fusionar.Name = "button_fusionar";
            this.button_fusionar.Size = new System.Drawing.Size(64, 52);
            this.button_fusionar.TabIndex = 4;
            this.button_fusionar.Text = "Fusionar";
            this.button_fusionar.UseVisualStyleBackColor = true;
            this.button_fusionar.Click += new System.EventHandler(this.button_fusionar_Click);
            // 
            // textBox_fusionar_nuevo
            // 
            this.textBox_fusionar_nuevo.Location = new System.Drawing.Point(123, 59);
            this.textBox_fusionar_nuevo.Name = "textBox_fusionar_nuevo";
            this.textBox_fusionar_nuevo.Size = new System.Drawing.Size(100, 20);
            this.textBox_fusionar_nuevo.TabIndex = 3;
            // 
            // textBox_fusionar_viejo
            // 
            this.textBox_fusionar_viejo.Location = new System.Drawing.Point(123, 27);
            this.textBox_fusionar_viejo.Name = "textBox_fusionar_viejo";
            this.textBox_fusionar_viejo.Size = new System.Drawing.Size(100, 20);
            this.textBox_fusionar_viejo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IdEntidad Nuevo : ";
            // 
            // button_borradoMultiple
            // 
            this.button_borradoMultiple.Location = new System.Drawing.Point(40, 156);
            this.button_borradoMultiple.Name = "button_borradoMultiple";
            this.button_borradoMultiple.Size = new System.Drawing.Size(78, 60);
            this.button_borradoMultiple.TabIndex = 2;
            this.button_borradoMultiple.Text = "Borrado Múltiple";
            this.button_borradoMultiple.UseVisualStyleBackColor = true;
            this.button_borradoMultiple.Click += new System.EventHandler(this.button_borradoMultiple_Click);
            // 
            // button_insertarPendientes
            // 
            this.button_insertarPendientes.Location = new System.Drawing.Point(163, 156);
            this.button_insertarPendientes.Name = "button_insertarPendientes";
            this.button_insertarPendientes.Size = new System.Drawing.Size(78, 60);
            this.button_insertarPendientes.TabIndex = 3;
            this.button_insertarPendientes.Text = "Insertar Pendientes";
            this.button_insertarPendientes.UseVisualStyleBackColor = true;
            this.button_insertarPendientes.Click += new System.EventHandler(this.button_insertarPendientes_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 60);
            this.button1.TabIndex = 4;
            this.button1.Text = "ActualizarSinAcentos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 560);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_insertarPendientes);
            this.Controls.Add(this.button_borradoMultiple);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento";
            this.Load += new System.EventHandler(this.FormMantenimiento_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_fusionar;
        private System.Windows.Forms.TextBox textBox_fusionar_nuevo;
        private System.Windows.Forms.TextBox textBox_fusionar_viejo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_borradoMultiple;
        private System.Windows.Forms.Button button_insertarPendientes;
        private System.Windows.Forms.Button button1;
    }
}