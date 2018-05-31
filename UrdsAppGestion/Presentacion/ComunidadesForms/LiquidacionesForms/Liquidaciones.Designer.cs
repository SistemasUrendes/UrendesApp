namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms
{
    partial class Liquidaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Liquidaciones));
            this.dataGridView_Liquidaciones = new System.Windows.Forms.DataGridView();
            this.button_Añadir = new System.Windows.Forms.Button();
            this.button_Editar = new System.Windows.Forms.Button();
            this.button_Borrar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verGastosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verRepartoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.establecerPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarLiquidaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitarPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirLiquidaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirNotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_enviar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_filtro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_informes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Liquidaciones)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Liquidaciones
            // 
            this.dataGridView_Liquidaciones.AllowUserToAddRows = false;
            this.dataGridView_Liquidaciones.AllowUserToDeleteRows = false;
            this.dataGridView_Liquidaciones.AllowUserToOrderColumns = true;
            this.dataGridView_Liquidaciones.AllowUserToResizeRows = false;
            this.dataGridView_Liquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Liquidaciones.Location = new System.Drawing.Point(26, 78);
            this.dataGridView_Liquidaciones.MultiSelect = false;
            this.dataGridView_Liquidaciones.Name = "dataGridView_Liquidaciones";
            this.dataGridView_Liquidaciones.ReadOnly = true;
            this.dataGridView_Liquidaciones.RowHeadersVisible = false;
            this.dataGridView_Liquidaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Liquidaciones.Size = new System.Drawing.Size(937, 401);
            this.dataGridView_Liquidaciones.TabIndex = 0;
            this.dataGridView_Liquidaciones.DoubleClick += new System.EventHandler(this.dataGridView_Liquidaciones_DoubleClick);
            this.dataGridView_Liquidaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView_Liquidaciones_KeyPress);
            this.dataGridView_Liquidaciones.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Liquidaciones_MouseClick);
            // 
            // button_Añadir
            // 
            this.button_Añadir.Location = new System.Drawing.Point(26, 49);
            this.button_Añadir.Name = "button_Añadir";
            this.button_Añadir.Size = new System.Drawing.Size(75, 23);
            this.button_Añadir.TabIndex = 1;
            this.button_Añadir.Text = "Añadir";
            this.button_Añadir.UseVisualStyleBackColor = true;
            this.button_Añadir.Click += new System.EventHandler(this.button_Añadir_Click);
            // 
            // button_Editar
            // 
            this.button_Editar.Location = new System.Drawing.Point(107, 49);
            this.button_Editar.Name = "button_Editar";
            this.button_Editar.Size = new System.Drawing.Size(75, 23);
            this.button_Editar.TabIndex = 2;
            this.button_Editar.Text = "Editar";
            this.button_Editar.UseVisualStyleBackColor = true;
            this.button_Editar.Click += new System.EventHandler(this.button_Editar_Click);
            // 
            // button_Borrar
            // 
            this.button_Borrar.Location = new System.Drawing.Point(188, 49);
            this.button_Borrar.Name = "button_Borrar";
            this.button_Borrar.Size = new System.Drawing.Size(75, 23);
            this.button_Borrar.TabIndex = 3;
            this.button_Borrar.Text = "Borrar";
            this.button_Borrar.UseVisualStyleBackColor = true;
            this.button_Borrar.Click += new System.EventHandler(this.button_Borrar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verGastosToolStripMenuItem,
            this.verRepartoToolStripMenuItem,
            this.establecerPrincipalToolStripMenuItem,
            this.cerrarLiquidaciónToolStripMenuItem,
            this.quitarPrincipalToolStripMenuItem,
            this.abrirLiquidaciónToolStripMenuItem,
            this.añadirNotaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 158);
            // 
            // verGastosToolStripMenuItem
            // 
            this.verGastosToolStripMenuItem.Name = "verGastosToolStripMenuItem";
            this.verGastosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.verGastosToolStripMenuItem.Text = "Ver Gastos";
            this.verGastosToolStripMenuItem.Click += new System.EventHandler(this.verGastosToolStripMenuItem_Click);
            // 
            // verRepartoToolStripMenuItem
            // 
            this.verRepartoToolStripMenuItem.Name = "verRepartoToolStripMenuItem";
            this.verRepartoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.verRepartoToolStripMenuItem.Text = "Ver Reparto";
            this.verRepartoToolStripMenuItem.Click += new System.EventHandler(this.verRepartoToolStripMenuItem_Click);
            // 
            // establecerPrincipalToolStripMenuItem
            // 
            this.establecerPrincipalToolStripMenuItem.Name = "establecerPrincipalToolStripMenuItem";
            this.establecerPrincipalToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.establecerPrincipalToolStripMenuItem.Text = "Establecer Principal";
            this.establecerPrincipalToolStripMenuItem.Visible = false;
            this.establecerPrincipalToolStripMenuItem.Click += new System.EventHandler(this.establecerPrincipalToolStripMenuItem_Click);
            // 
            // cerrarLiquidaciónToolStripMenuItem
            // 
            this.cerrarLiquidaciónToolStripMenuItem.Name = "cerrarLiquidaciónToolStripMenuItem";
            this.cerrarLiquidaciónToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.cerrarLiquidaciónToolStripMenuItem.Text = "Cerrar Liquidación";
            this.cerrarLiquidaciónToolStripMenuItem.Visible = false;
            this.cerrarLiquidaciónToolStripMenuItem.Click += new System.EventHandler(this.cerrarLiquidaciónToolStripMenuItem_Click);
            // 
            // quitarPrincipalToolStripMenuItem
            // 
            this.quitarPrincipalToolStripMenuItem.Name = "quitarPrincipalToolStripMenuItem";
            this.quitarPrincipalToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.quitarPrincipalToolStripMenuItem.Text = "Quitar Principal";
            this.quitarPrincipalToolStripMenuItem.Visible = false;
            // 
            // abrirLiquidaciónToolStripMenuItem
            // 
            this.abrirLiquidaciónToolStripMenuItem.Name = "abrirLiquidaciónToolStripMenuItem";
            this.abrirLiquidaciónToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.abrirLiquidaciónToolStripMenuItem.Text = "Abrir Liquidación";
            this.abrirLiquidaciónToolStripMenuItem.Visible = false;
            this.abrirLiquidaciónToolStripMenuItem.Click += new System.EventHandler(this.abrirLiquidaciónToolStripMenuItem_Click);
            // 
            // añadirNotaToolStripMenuItem
            // 
            this.añadirNotaToolStripMenuItem.Name = "añadirNotaToolStripMenuItem";
            this.añadirNotaToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.añadirNotaToolStripMenuItem.Text = "Añadir Nota";
            this.añadirNotaToolStripMenuItem.Click += new System.EventHandler(this.añadirNotaToolStripMenuItem_Click);
            // 
            // button_enviar
            // 
            this.button_enviar.Location = new System.Drawing.Point(26, 49);
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.Size = new System.Drawing.Size(237, 23);
            this.button_enviar.TabIndex = 1;
            this.button_enviar.Text = "Enviar";
            this.button_enviar.UseVisualStyleBackColor = true;
            this.button_enviar.Visible = false;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(799, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filtro : ";
            // 
            // comboBox_filtro
            // 
            this.comboBox_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filtro.FormattingEnabled = true;
            this.comboBox_filtro.Items.AddRange(new object[] {
            "Cerradas",
            "Abiertas",
            "Todas"});
            this.comboBox_filtro.Location = new System.Drawing.Point(861, 51);
            this.comboBox_filtro.Name = "comboBox_filtro";
            this.comboBox_filtro.Size = new System.Drawing.Size(102, 21);
            this.comboBox_filtro.TabIndex = 3;
            this.comboBox_filtro.SelectionChangeCommitted += new System.EventHandler(this.comboBox_filtro_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(799, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Informes  :";
            // 
            // comboBox_informes
            // 
            this.comboBox_informes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_informes.FormattingEnabled = true;
            this.comboBox_informes.Items.AddRange(new object[] {
            "Resumen",
            "Detallado"});
            this.comboBox_informes.Location = new System.Drawing.Point(860, 19);
            this.comboBox_informes.Name = "comboBox_informes";
            this.comboBox_informes.Size = new System.Drawing.Size(103, 21);
            this.comboBox_informes.TabIndex = 8;
            this.comboBox_informes.SelectionChangeCommitted += new System.EventHandler(this.comboBox_informes_SelectionChangeCommitted);
            // 
            // Liquidaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 502);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox_informes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_filtro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_enviar);
            this.Controls.Add(this.button_Borrar);
            this.Controls.Add(this.button_Editar);
            this.Controls.Add(this.button_Añadir);
            this.Controls.Add(this.dataGridView_Liquidaciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Liquidaciones";
            this.Text = "Liquidaciones";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Liquidaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Liquidaciones)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Liquidaciones;
        private System.Windows.Forms.Button button_Añadir;
        private System.Windows.Forms.Button button_Editar;
        private System.Windows.Forms.Button button_Borrar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verGastosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verRepartoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem establecerPrincipalToolStripMenuItem;
        private System.Windows.Forms.Button button_enviar;
        private System.Windows.Forms.ToolStripMenuItem cerrarLiquidaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitarPrincipalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirLiquidaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirNotaToolStripMenuItem;
        public System.Windows.Forms.ComboBox comboBox_filtro;
        public System.Windows.Forms.ComboBox comboBox_informes;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
    }
}