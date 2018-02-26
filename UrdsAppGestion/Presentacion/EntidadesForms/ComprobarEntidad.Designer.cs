namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    partial class ComprobarEntidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprobarEntidad));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_añadir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_nombrecorto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_abrir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Entidad";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_nombre.Location = new System.Drawing.Point(142, 26);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(323, 20);
            this.textBox_nombre.TabIndex = 1;
            this.textBox_nombre.TextChanged += new System.EventHandler(this.textBox_nombre_TextChanged);
            this.textBox_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_nombre_KeyPress);
            this.textBox_nombre.Leave += new System.EventHandler(this.textBox_nombre_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(461, 296);
            this.dataGridView1.TabIndex = 6;
            // 
            // button_añadir
            // 
            this.button_añadir.Location = new System.Drawing.Point(386, 414);
            this.button_añadir.Name = "button_añadir";
            this.button_añadir.Size = new System.Drawing.Size(100, 23);
            this.button_añadir.TabIndex = 3;
            this.button_añadir.Text = "Añadir Entidad";
            this.button_añadir.UseVisualStyleBackColor = true;
            this.button_añadir.Click += new System.EventHandler(this.button_añadir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tal vez quisiste decir ...";
            // 
            // textBox_nombrecorto
            // 
            this.textBox_nombrecorto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_nombrecorto.Location = new System.Drawing.Point(142, 52);
            this.textBox_nombrecorto.Name = "textBox_nombrecorto";
            this.textBox_nombrecorto.Size = new System.Drawing.Size(215, 20);
            this.textBox_nombrecorto.TabIndex = 2;
            this.textBox_nombrecorto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_nombrecorto_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nombre Corto";
            // 
            // button_abrir
            // 
            this.button_abrir.Location = new System.Drawing.Point(279, 414);
            this.button_abrir.Name = "button_abrir";
            this.button_abrir.Size = new System.Drawing.Size(100, 23);
            this.button_abrir.TabIndex = 8;
            this.button_abrir.Text = "Abrir Entidad";
            this.button_abrir.UseVisualStyleBackColor = true;
            this.button_abrir.Click += new System.EventHandler(this.button_abrir_Click);
            // 
            // ComprobarEntidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 447);
            this.Controls.Add(this.button_abrir);
            this.Controls.Add(this.textBox_nombrecorto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_añadir);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox_nombre);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComprobarEntidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Entidad";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ComprobarEntidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_añadir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_nombrecorto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_abrir;
    }
}