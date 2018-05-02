namespace UrdsAppGestión.Presentacion.ComunidadesForms.BloquesForms
{
    partial class Bloques
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bloques));
            this.dataGridView_bloques = new System.Windows.Forms.DataGridView();
            this.button_Añadir = new System.Windows.Forms.Button();
            this.button_EditarBloque = new System.Windows.Forms.Button();
            this.button_Borrar = new System.Windows.Forms.Button();
            this.comboBox_FiltroBloques = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip_Bloques = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.subCuotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_enviar = new System.Windows.Forms.Button();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bloques)).BeginInit();
            this.contextMenuStrip_Bloques.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_bloques
            // 
            this.dataGridView_bloques.AllowUserToAddRows = false;
            this.dataGridView_bloques.AllowUserToDeleteRows = false;
            this.dataGridView_bloques.AllowUserToOrderColumns = true;
            this.dataGridView_bloques.AllowUserToResizeRows = false;
            this.dataGridView_bloques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_bloques.Location = new System.Drawing.Point(12, 69);
            this.dataGridView_bloques.Name = "dataGridView_bloques";
            this.dataGridView_bloques.ReadOnly = true;
            this.dataGridView_bloques.RowHeadersVisible = false;
            this.dataGridView_bloques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_bloques.Size = new System.Drawing.Size(792, 381);
            this.dataGridView_bloques.TabIndex = 0;
            this.dataGridView_bloques.DoubleClick += new System.EventHandler(this.dataGridView_bloques_DoubleClick);
            this.dataGridView_bloques.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_bloques_KeyDown);
            this.dataGridView_bloques.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView_bloques_KeyPress);
            this.dataGridView_bloques.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_bloques_MouseClick);
            // 
            // button_Añadir
            // 
            this.button_Añadir.Location = new System.Drawing.Point(12, 12);
            this.button_Añadir.Name = "button_Añadir";
            this.button_Añadir.Size = new System.Drawing.Size(55, 23);
            this.button_Añadir.TabIndex = 3;
            this.button_Añadir.Text = "Añadir";
            this.button_Añadir.UseVisualStyleBackColor = true;
            this.button_Añadir.Click += new System.EventHandler(this.button_Añadir_Click);
            // 
            // button_EditarBloque
            // 
            this.button_EditarBloque.Location = new System.Drawing.Point(73, 12);
            this.button_EditarBloque.Name = "button_EditarBloque";
            this.button_EditarBloque.Size = new System.Drawing.Size(55, 23);
            this.button_EditarBloque.TabIndex = 4;
            this.button_EditarBloque.Text = "Editar";
            this.button_EditarBloque.UseVisualStyleBackColor = true;
            this.button_EditarBloque.Click += new System.EventHandler(this.button_EditarBloque_Click);
            // 
            // button_Borrar
            // 
            this.button_Borrar.Location = new System.Drawing.Point(134, 12);
            this.button_Borrar.Name = "button_Borrar";
            this.button_Borrar.Size = new System.Drawing.Size(55, 23);
            this.button_Borrar.TabIndex = 5;
            this.button_Borrar.Text = "Borrar";
            this.button_Borrar.UseVisualStyleBackColor = true;
            this.button_Borrar.Click += new System.EventHandler(this.button_Borrar_Click);
            // 
            // comboBox_FiltroBloques
            // 
            this.comboBox_FiltroBloques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FiltroBloques.FormattingEnabled = true;
            this.comboBox_FiltroBloques.Items.AddRange(new object[] {
            "Activados",
            "Desactivados",
            "Bloque General",
            "Ver Todos"});
            this.comboBox_FiltroBloques.Location = new System.Drawing.Point(683, 43);
            this.comboBox_FiltroBloques.Name = "comboBox_FiltroBloques";
            this.comboBox_FiltroBloques.Size = new System.Drawing.Size(121, 21);
            this.comboBox_FiltroBloques.TabIndex = 2;
            this.comboBox_FiltroBloques.SelectionChangeCommitted += new System.EventHandler(this.comboBox_FiltroBloques_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(645, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filtro:";
            // 
            // contextMenuStrip_Bloques
            // 
            this.contextMenuStrip_Bloques.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subCuotasToolStripMenuItem});
            this.contextMenuStrip_Bloques.Name = "contextMenuStrip_Bloques";
            this.contextMenuStrip_Bloques.Size = new System.Drawing.Size(132, 26);
            // 
            // subCuotasToolStripMenuItem
            // 
            this.subCuotasToolStripMenuItem.Name = "subCuotasToolStripMenuItem";
            this.subCuotasToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.subCuotasToolStripMenuItem.Text = "SubCuotas";
            this.subCuotasToolStripMenuItem.Click += new System.EventHandler(this.subCuotasToolStripMenuItem_Click);
            // 
            // button_enviar
            // 
            this.button_enviar.Location = new System.Drawing.Point(12, 12);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(177, 23);
            this.button_enviar.TabIndex = 1;
            this.button_enviar.Text = "Enviar";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Visible = false;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(64, 43);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(125, 20);
            this.textBox_buscar.TabIndex = 15;
            this.textBox_buscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_buscar_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Buscar : ";
            // 
            // Bloques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 462);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.button_enviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_FiltroBloques);
            this.Controls.Add(this.button_Borrar);
            this.Controls.Add(this.button_EditarBloque);
            this.Controls.Add(this.button_Añadir);
            this.Controls.Add(this.dataGridView_bloques);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bloques";
            this.Text = "Bloques";
            this.Load += new System.EventHandler(this.Bloques_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bloques)).EndInit();
            this.contextMenuStrip_Bloques.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_bloques;
        private System.Windows.Forms.Button button_Añadir;
        private System.Windows.Forms.Button button_EditarBloque;
        private System.Windows.Forms.Button button_Borrar;
        private System.Windows.Forms.ComboBox comboBox_FiltroBloques;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Bloques;
        private System.Windows.Forms.ToolStripMenuItem subCuotasToolStripMenuItem;
        private System.Windows.Forms.Button button_enviar;
        private System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.Label label1;
    }
}