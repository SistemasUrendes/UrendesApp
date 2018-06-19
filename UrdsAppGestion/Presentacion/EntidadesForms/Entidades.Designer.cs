namespace UrdsAppGestión.Presentacion
{
    partial class Entidades
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Entidades));
            this.label_buscar = new System.Windows.Forms.Label();
            this.listBox_categoria = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.button_mostrar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_buscar_nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_correo_buscar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_telefono_buscar = new System.Windows.Forms.TextBox();
            this.MenuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copiarAlPortapapelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_añadir_entidad = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_enviar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_categoria = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.MenuContextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_buscar
            // 
            this.label_buscar.AutoSize = true;
            this.label_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_buscar.Location = new System.Drawing.Point(25, 22);
            this.label_buscar.Name = "label_buscar";
            this.label_buscar.Size = new System.Drawing.Size(64, 16);
            this.label_buscar.TabIndex = 1;
            this.label_buscar.Text = "Buscar :";
            // 
            // listBox_categoria
            // 
            this.listBox_categoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_categoria.FormattingEnabled = true;
            this.listBox_categoria.ItemHeight = 16;
            this.listBox_categoria.Location = new System.Drawing.Point(28, 107);
            this.listBox_categoria.Name = "listBox_categoria";
            this.listBox_categoria.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_categoria.Size = new System.Drawing.Size(213, 516);
            this.listBox_categoria.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Categoria :";
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(28, 42);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(213, 20);
            this.textBox_buscar.TabIndex = 4;
            this.textBox_buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button_mostrar
            // 
            this.button_mostrar.Location = new System.Drawing.Point(51, 629);
            this.button_mostrar.Name = "button_mostrar";
            this.button_mostrar.Size = new System.Drawing.Size(170, 23);
            this.button_mostrar.TabIndex = 5;
            this.button_mostrar.Text = "Mostrar";
            this.button_mostrar.UseVisualStyleBackColor = true;
            this.button_mostrar.Click += new System.EventHandler(this.button_mostrar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(297, 107);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(849, 516);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // textBox_buscar_nombre
            // 
            this.textBox_buscar_nombre.Location = new System.Drawing.Point(728, 25);
            this.textBox_buscar_nombre.Name = "textBox_buscar_nombre";
            this.textBox_buscar_nombre.Size = new System.Drawing.Size(176, 20);
            this.textBox_buscar_nombre.TabIndex = 7;
            this.textBox_buscar_nombre.Click += new System.EventHandler(this.textBox_buscar_nombre_Click);
            this.textBox_buscar_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_buscar_nombre_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(677, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(683, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Correo :";
            // 
            // textBox_correo_buscar
            // 
            this.textBox_correo_buscar.Location = new System.Drawing.Point(728, 57);
            this.textBox_correo_buscar.Name = "textBox_correo_buscar";
            this.textBox_correo_buscar.Size = new System.Drawing.Size(176, 20);
            this.textBox_correo_buscar.TabIndex = 10;
            this.textBox_correo_buscar.Click += new System.EventHandler(this.textBox_correo_buscar_Click);
            this.textBox_correo_buscar.TextChanged += new System.EventHandler(this.textBox_correo_buscar_TextChanged);
            this.textBox_correo_buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_correo_buscar_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(916, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Telefono :";
            // 
            // textBox_telefono_buscar
            // 
            this.textBox_telefono_buscar.Location = new System.Drawing.Point(972, 25);
            this.textBox_telefono_buscar.Name = "textBox_telefono_buscar";
            this.textBox_telefono_buscar.Size = new System.Drawing.Size(176, 20);
            this.textBox_telefono_buscar.TabIndex = 12;
            this.textBox_telefono_buscar.Click += new System.EventHandler(this.textBox_telefono_buscar_Click);
            this.textBox_telefono_buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_telefono_buscar_KeyPress);
            // 
            // MenuContextual
            // 
            this.MenuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiarAlPortapapelesToolStripMenuItem});
            this.MenuContextual.Name = "Menu";
            this.MenuContextual.Size = new System.Drawing.Size(193, 26);
            // 
            // copiarAlPortapapelesToolStripMenuItem
            // 
            this.copiarAlPortapapelesToolStripMenuItem.Name = "copiarAlPortapapelesToolStripMenuItem";
            this.copiarAlPortapapelesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.copiarAlPortapapelesToolStripMenuItem.Text = "Copiar al Portapapeles";
            this.copiarAlPortapapelesToolStripMenuItem.Click += new System.EventHandler(this.copiarAlPortapapelesToolStripMenuItem_Click);
            // 
            // button_añadir_entidad
            // 
            this.button_añadir_entidad.Location = new System.Drawing.Point(296, 78);
            this.button_añadir_entidad.Name = "button_añadir_entidad";
            this.button_añadir_entidad.Size = new System.Drawing.Size(75, 23);
            this.button_añadir_entidad.TabIndex = 13;
            this.button_añadir_entidad.Text = "Añadir";
            this.button_añadir_entidad.UseVisualStyleBackColor = true;
            this.button_añadir_entidad.Click += new System.EventHandler(this.button_añadir_entidad_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(377, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Editar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(458, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Borrar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_enviar
            // 
            this.button_enviar.Location = new System.Drawing.Point(539, 78);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(75, 23);
            this.button_enviar.TabIndex = 16;
            this.button_enviar.Text = "Enviar";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Visible = false;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(913, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Categoria :";
            // 
            // textBox_categoria
            // 
            this.textBox_categoria.Location = new System.Drawing.Point(972, 57);
            this.textBox_categoria.Name = "textBox_categoria";
            this.textBox_categoria.Size = new System.Drawing.Size(174, 20);
            this.textBox_categoria.TabIndex = 17;
            this.textBox_categoria.TextChanged += new System.EventHandler(this.textBox_categoria_TextChanged);
            // 
            // Entidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 712);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_categoria);
            this.Controls.Add(this.button_enviar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_añadir_entidad);
            this.Controls.Add(this.textBox_telefono_buscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_correo_buscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_buscar_nombre);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_mostrar);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_categoria);
            this.Controls.Add(this.label_buscar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Entidades";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entidades";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Entidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.MenuContextual.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_buscar;
        private System.Windows.Forms.ListBox listBox_categoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.Button button_mostrar;
        private System.Windows.Forms.ContextMenuStrip MenuContextual;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_añadir_entidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_enviar;
        public System.Windows.Forms.TextBox textBox_buscar_nombre;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBox_correo_buscar;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox_telefono_buscar;
        private System.Windows.Forms.ToolStripMenuItem copiarAlPortapapelesToolStripMenuItem;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBox_categoria;
    }
}