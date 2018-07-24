namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormOperacionesListadoProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperacionesListadoProveedores));
            this.dataGridView_proveedores = new System.Windows.Forms.DataGridView();
            this.button_enviar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verEntidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirBloqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darDeBajaProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darDeAltaProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_informes = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_proveedores)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_proveedores
            // 
            this.dataGridView_proveedores.AllowUserToAddRows = false;
            this.dataGridView_proveedores.AllowUserToDeleteRows = false;
            this.dataGridView_proveedores.AllowUserToOrderColumns = true;
            this.dataGridView_proveedores.AllowUserToResizeRows = false;
            this.dataGridView_proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_proveedores.Location = new System.Drawing.Point(13, 61);
            this.dataGridView_proveedores.Name = "dataGridView_proveedores";
            this.dataGridView_proveedores.ReadOnly = true;
            this.dataGridView_proveedores.RowHeadersVisible = false;
            this.dataGridView_proveedores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_proveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_proveedores.Size = new System.Drawing.Size(1199, 498);
            this.dataGridView_proveedores.TabIndex = 2;
            this.dataGridView_proveedores.DoubleClick += new System.EventHandler(this.dataGridView_proveedores_DoubleClick);
            this.dataGridView_proveedores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView_proveedores_KeyPress);
            this.dataGridView_proveedores.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_proveedores_MouseClick);
            // 
            // button_enviar
            // 
            this.button_enviar.Location = new System.Drawing.Point(816, 36);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(102, 23);
            this.button_enviar.TabIndex = 3;
            this.button_enviar.Text = "Enviar";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Visible = false;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar : ";
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(65, 38);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(174, 20);
            this.textBox_buscar.TabIndex = 1;
            this.textBox_buscar.TextChanged += new System.EventHandler(this.textBox_buscar_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verEntidadToolStripMenuItem,
            this.añadirBloqueToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.eliminarProveedorToolStripMenuItem,
            this.darDeBajaProveedorToolStripMenuItem,
            this.darDeAltaProveedorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 136);
            // 
            // verEntidadToolStripMenuItem
            // 
            this.verEntidadToolStripMenuItem.Name = "verEntidadToolStripMenuItem";
            this.verEntidadToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.verEntidadToolStripMenuItem.Text = "Ver Entidad";
            this.verEntidadToolStripMenuItem.Click += new System.EventHandler(this.verEntidadToolStripMenuItem_Click);
            // 
            // añadirBloqueToolStripMenuItem
            // 
            this.añadirBloqueToolStripMenuItem.Name = "añadirBloqueToolStripMenuItem";
            this.añadirBloqueToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.añadirBloqueToolStripMenuItem.Text = "Añadir Bloque";
            this.añadirBloqueToolStripMenuItem.Click += new System.EventHandler(this.añadirBloqueToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.editarToolStripMenuItem.Text = "Editar Proveedor";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarProveedorToolStripMenuItem
            // 
            this.eliminarProveedorToolStripMenuItem.Name = "eliminarProveedorToolStripMenuItem";
            this.eliminarProveedorToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.eliminarProveedorToolStripMenuItem.Text = "Eliminar Proveedor";
            this.eliminarProveedorToolStripMenuItem.Click += new System.EventHandler(this.eliminarProveedorToolStripMenuItem_Click);
            // 
            // darDeBajaProveedorToolStripMenuItem
            // 
            this.darDeBajaProveedorToolStripMenuItem.Name = "darDeBajaProveedorToolStripMenuItem";
            this.darDeBajaProveedorToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.darDeBajaProveedorToolStripMenuItem.Text = "Dar de Baja Proveedor";
            this.darDeBajaProveedorToolStripMenuItem.Click += new System.EventHandler(this.darDeBajaProveedorToolStripMenuItem_Click);
            // 
            // darDeAltaProveedorToolStripMenuItem
            // 
            this.darDeAltaProveedorToolStripMenuItem.Name = "darDeAltaProveedorToolStripMenuItem";
            this.darDeAltaProveedorToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.darDeAltaProveedorToolStripMenuItem.Text = "Dar de Alta Proveedor";
            this.darDeAltaProveedorToolStripMenuItem.Click += new System.EventHandler(this.darDeAltaProveedorToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(959, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Informes :";
            // 
            // comboBox_informes
            // 
            this.comboBox_informes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_informes.FormattingEnabled = true;
            this.comboBox_informes.Items.AddRange(new object[] {
            "Listado Proveedores"});
            this.comboBox_informes.Location = new System.Drawing.Point(1018, 12);
            this.comboBox_informes.Name = "comboBox_informes";
            this.comboBox_informes.Size = new System.Drawing.Size(121, 21);
            this.comboBox_informes.TabIndex = 5;
            this.comboBox_informes.SelectionChangeCommitted += new System.EventHandler(this.comboBox_informes_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Añadir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Alta",
            "Baja",
            "Todos"});
            this.comboBox1.Location = new System.Drawing.Point(1018, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(966, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Estado :";
            // 
            // FormOperacionesListadoProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 571);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_informes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_enviar);
            this.Controls.Add(this.dataGridView_proveedores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOperacionesListadoProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Proveedores";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormOperacionesListadoProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_proveedores)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_proveedores;
        private System.Windows.Forms.Button button_enviar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem añadirBloqueToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_informes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem eliminarProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verEntidadToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem darDeBajaProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darDeAltaProveedorToolStripMenuItem;
        private System.Windows.Forms.Label label3;
    }
}