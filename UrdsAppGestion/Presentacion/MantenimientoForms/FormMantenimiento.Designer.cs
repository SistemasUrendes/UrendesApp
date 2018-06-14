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
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonActualizarCategoriasEntidad = new System.Windows.Forms.Button();
            this.buttonActualizarBloqueTareas = new System.Windows.Forms.Button();
            this.buttonActualizarCategoriasProv = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
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
            this.button_borradoMultiple.Enabled = false;
            this.button_borradoMultiple.Location = new System.Drawing.Point(40, 224);
            this.button_borradoMultiple.Name = "button_borradoMultiple";
            this.button_borradoMultiple.Size = new System.Drawing.Size(78, 60);
            this.button_borradoMultiple.TabIndex = 2;
            this.button_borradoMultiple.Text = "Borrado Múltiple";
            this.button_borradoMultiple.UseVisualStyleBackColor = true;
            this.button_borradoMultiple.Click += new System.EventHandler(this.button_borradoMultiple_Click);
            // 
            // button_insertarPendientes
            // 
            this.button_insertarPendientes.Enabled = false;
            this.button_insertarPendientes.Location = new System.Drawing.Point(163, 224);
            this.button_insertarPendientes.Name = "button_insertarPendientes";
            this.button_insertarPendientes.Size = new System.Drawing.Size(78, 60);
            this.button_insertarPendientes.TabIndex = 3;
            this.button_insertarPendientes.Text = "Insertar Pendientes";
            this.button_insertarPendientes.UseVisualStyleBackColor = true;
            this.button_insertarPendientes.Click += new System.EventHandler(this.button_insertarPendientes_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(281, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 60);
            this.button1.TabIndex = 4;
            this.button1.Text = "ActualizarSinAcentos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(40, 302);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 60);
            this.button2.TabIndex = 5;
            this.button2.Text = "Actualizar Total Liquidaciones";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 525);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(298, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(163, 302);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 60);
            this.button3.TabIndex = 7;
            this.button3.Text = "Crear Bloques en Elementos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(281, 302);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 60);
            this.button4.TabIndex = 8;
            this.button4.Text = "Actualizar IDTareas";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonActualizarCategoriasEntidad
            // 
            this.buttonActualizarCategoriasEntidad.Enabled = false;
            this.buttonActualizarCategoriasEntidad.Location = new System.Drawing.Point(40, 377);
            this.buttonActualizarCategoriasEntidad.Name = "buttonActualizarCategoriasEntidad";
            this.buttonActualizarCategoriasEntidad.Size = new System.Drawing.Size(78, 61);
            this.buttonActualizarCategoriasEntidad.TabIndex = 9;
            this.buttonActualizarCategoriasEntidad.Text = "Actualizar Categorías Entidad";
            this.buttonActualizarCategoriasEntidad.UseVisualStyleBackColor = true;
            this.buttonActualizarCategoriasEntidad.Click += new System.EventHandler(this.buttonActualizarCategoriasEntidad_Click);
            // 
            // buttonActualizarBloqueTareas
            // 
            this.buttonActualizarBloqueTareas.Enabled = false;
            this.buttonActualizarBloqueTareas.Location = new System.Drawing.Point(163, 377);
            this.buttonActualizarBloqueTareas.Name = "buttonActualizarBloqueTareas";
            this.buttonActualizarBloqueTareas.Size = new System.Drawing.Size(75, 61);
            this.buttonActualizarBloqueTareas.TabIndex = 10;
            this.buttonActualizarBloqueTareas.Text = "Actualizar Bloque Tareas";
            this.buttonActualizarBloqueTareas.UseVisualStyleBackColor = true;
            this.buttonActualizarBloqueTareas.Click += new System.EventHandler(this.buttonActualizarBloqueTareas_Click);
            // 
            // buttonActualizarCategoriasProv
            // 
            this.buttonActualizarCategoriasProv.Location = new System.Drawing.Point(40, 146);
            this.buttonActualizarCategoriasProv.Name = "buttonActualizarCategoriasProv";
            this.buttonActualizarCategoriasProv.Size = new System.Drawing.Size(78, 61);
            this.buttonActualizarCategoriasProv.TabIndex = 11;
            this.buttonActualizarCategoriasProv.Text = "Actualizar Categorías Proveedores";
            this.buttonActualizarCategoriasProv.UseVisualStyleBackColor = true;
            this.buttonActualizarCategoriasProv.Click += new System.EventHandler(this.buttonActualizarCategoriasProv_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(163, 146);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 61);
            this.button5.TabIndex = 12;
            this.button5.Text = "Crear Movimientos a opdetalles  con Pte 0";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(281, 377);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 61);
            this.button6.TabIndex = 13;
            this.button6.Text = "Actualizar Tareas Sin Acentos";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // FormMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 560);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonActualizarCategoriasProv);
            this.Controls.Add(this.buttonActualizarBloqueTareas);
            this.Controls.Add(this.buttonActualizarCategoriasEntidad);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonActualizarCategoriasEntidad;
        private System.Windows.Forms.Button buttonActualizarBloqueTareas;
        private System.Windows.Forms.Button buttonActualizarCategoriasProv;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}