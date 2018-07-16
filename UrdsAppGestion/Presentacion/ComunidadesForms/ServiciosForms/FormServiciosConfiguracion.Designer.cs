namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormServiciosConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServiciosConfiguracion));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxComunidades = new System.Windows.Forms.ComboBox();
            this.textBoxFiltroBloque = new System.Windows.Forms.TextBox();
            this.dataGridViewBloque = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonTodasAreas = new System.Windows.Forms.Button();
            this.textBoxAreas = new System.Windows.Forms.TextBox();
            this.buttonAddArea = new System.Windows.Forms.Button();
            this.dataGridViewAreas = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cambiarNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarCategoríaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonAddCategoria = new System.Windows.Forms.Button();
            this.dataGridViewCategorias = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBloque)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAreas)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxComunidades);
            this.groupBox2.Controls.Add(this.textBoxFiltroBloque);
            this.groupBox2.Controls.Add(this.dataGridViewBloque);
            this.groupBox2.Location = new System.Drawing.Point(983, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 428);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bloques";
            this.groupBox2.Visible = false;
            // 
            // comboBoxComunidades
            // 
            this.comboBoxComunidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComunidades.FormattingEnabled = true;
            this.comboBoxComunidades.Location = new System.Drawing.Point(6, 19);
            this.comboBoxComunidades.Name = "comboBoxComunidades";
            this.comboBoxComunidades.Size = new System.Drawing.Size(293, 21);
            this.comboBoxComunidades.TabIndex = 4;
            this.comboBoxComunidades.SelectionChangeCommitted += new System.EventHandler(this.comboBoxComunidades_SelectionChangeCommitted);
            // 
            // textBoxFiltroBloque
            // 
            this.textBoxFiltroBloque.Location = new System.Drawing.Point(6, 46);
            this.textBoxFiltroBloque.Name = "textBoxFiltroBloque";
            this.textBoxFiltroBloque.Size = new System.Drawing.Size(293, 20);
            this.textBoxFiltroBloque.TabIndex = 3;
            this.textBoxFiltroBloque.TextChanged += new System.EventHandler(this.textBoxFiltroBloque_TextChanged);
            // 
            // dataGridViewBloque
            // 
            this.dataGridViewBloque.AllowUserToAddRows = false;
            this.dataGridViewBloque.AllowUserToDeleteRows = false;
            this.dataGridViewBloque.AllowUserToResizeRows = false;
            this.dataGridViewBloque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBloque.Location = new System.Drawing.Point(6, 70);
            this.dataGridViewBloque.Name = "dataGridViewBloque";
            this.dataGridViewBloque.ReadOnly = true;
            this.dataGridViewBloque.RowHeadersVisible = false;
            this.dataGridViewBloque.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewBloque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBloque.ShowEditingIcon = false;
            this.dataGridViewBloque.Size = new System.Drawing.Size(293, 350);
            this.dataGridViewBloque.TabIndex = 0;
            this.dataGridViewBloque.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBloque_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 26);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.editarToolStripMenuItem.Text = "Editar Categoría";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonTodasAreas);
            this.groupBox1.Controls.Add(this.textBoxAreas);
            this.groupBox1.Controls.Add(this.buttonAddArea);
            this.groupBox1.Controls.Add(this.dataGridViewAreas);
            this.groupBox1.Location = new System.Drawing.Point(367, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 428);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Servicios";
            // 
            // buttonTodasAreas
            // 
            this.buttonTodasAreas.Location = new System.Drawing.Point(6, 19);
            this.buttonTodasAreas.Name = "buttonTodasAreas";
            this.buttonTodasAreas.Size = new System.Drawing.Size(121, 23);
            this.buttonTodasAreas.TabIndex = 4;
            this.buttonTodasAreas.Text = "Mostrar Todas Areas";
            this.buttonTodasAreas.UseVisualStyleBackColor = true;
            this.buttonTodasAreas.Click += new System.EventHandler(this.buttonTodasAreas_Click);
            // 
            // textBoxAreas
            // 
            this.textBoxAreas.Location = new System.Drawing.Point(6, 46);
            this.textBoxAreas.Name = "textBoxAreas";
            this.textBoxAreas.Size = new System.Drawing.Size(212, 20);
            this.textBoxAreas.TabIndex = 3;
            this.textBoxAreas.TextChanged += new System.EventHandler(this.textBoxAreas_TextChanged);
            // 
            // buttonAddArea
            // 
            this.buttonAddArea.Location = new System.Drawing.Point(224, 44);
            this.buttonAddArea.Name = "buttonAddArea";
            this.buttonAddArea.Size = new System.Drawing.Size(75, 23);
            this.buttonAddArea.TabIndex = 2;
            this.buttonAddArea.Text = "Añadir";
            this.buttonAddArea.UseVisualStyleBackColor = true;
            this.buttonAddArea.Click += new System.EventHandler(this.buttonAddArea_Click);
            // 
            // dataGridViewAreas
            // 
            this.dataGridViewAreas.AllowUserToAddRows = false;
            this.dataGridViewAreas.AllowUserToDeleteRows = false;
            this.dataGridViewAreas.AllowUserToResizeRows = false;
            this.dataGridViewAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAreas.Location = new System.Drawing.Point(6, 70);
            this.dataGridViewAreas.Name = "dataGridViewAreas";
            this.dataGridViewAreas.ReadOnly = true;
            this.dataGridViewAreas.RowHeadersVisible = false;
            this.dataGridViewAreas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewAreas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAreas.ShowEditingIcon = false;
            this.dataGridViewAreas.Size = new System.Drawing.Size(570, 350);
            this.dataGridViewAreas.TabIndex = 0;
            this.dataGridViewAreas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAreas_CellDoubleClick);
            this.dataGridViewAreas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewAreas_MouseClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarNombreToolStripMenuItem,
            this.borrarCategoríaToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(153, 70);
            // 
            // cambiarNombreToolStripMenuItem
            // 
            this.cambiarNombreToolStripMenuItem.Name = "cambiarNombreToolStripMenuItem";
            this.cambiarNombreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cambiarNombreToolStripMenuItem.Text = "Renombrar";
            this.cambiarNombreToolStripMenuItem.Click += new System.EventHandler(this.cambiarNombreToolStripMenuItem_Click);
            // 
            // borrarCategoríaToolStripMenuItem
            // 
            this.borrarCategoríaToolStripMenuItem.Name = "borrarCategoríaToolStripMenuItem";
            this.borrarCategoríaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.borrarCategoríaToolStripMenuItem.Text = "Borrar Servicio";
            this.borrarCategoríaToolStripMenuItem.Click += new System.EventHandler(this.borrarCategoríaToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.buttonAddCategoria);
            this.groupBox3.Controls.Add(this.dataGridViewCategorias);
            this.groupBox3.Location = new System.Drawing.Point(12, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 428);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Categorías Servicios";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonAddCategoria
            // 
            this.buttonAddCategoria.Location = new System.Drawing.Point(224, 44);
            this.buttonAddCategoria.Name = "buttonAddCategoria";
            this.buttonAddCategoria.Size = new System.Drawing.Size(75, 23);
            this.buttonAddCategoria.TabIndex = 2;
            this.buttonAddCategoria.Text = "Añadir";
            this.buttonAddCategoria.UseVisualStyleBackColor = true;
            this.buttonAddCategoria.Click += new System.EventHandler(this.buttonAddCategoria_Click);
            // 
            // dataGridViewCategorias
            // 
            this.dataGridViewCategorias.AllowUserToAddRows = false;
            this.dataGridViewCategorias.AllowUserToDeleteRows = false;
            this.dataGridViewCategorias.AllowUserToResizeRows = false;
            this.dataGridViewCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategorias.Location = new System.Drawing.Point(6, 70);
            this.dataGridViewCategorias.Name = "dataGridViewCategorias";
            this.dataGridViewCategorias.ReadOnly = true;
            this.dataGridViewCategorias.RowHeadersVisible = false;
            this.dataGridViewCategorias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCategorias.ShowEditingIcon = false;
            this.dataGridViewCategorias.Size = new System.Drawing.Size(293, 350);
            this.dataGridViewCategorias.TabIndex = 0;
            this.dataGridViewCategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCategorias_CellClick);
            this.dataGridViewCategorias.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewCategorias_MouseClick);
            // 
            // FormServiciosConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 476);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormServiciosConfiguracion";
            this.Text = "Configuración Servicios";
            this.Load += new System.EventHandler(this.FormServiciosConfiguracion_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBloque)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAreas)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategorias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxComunidades;
        private System.Windows.Forms.TextBox textBoxFiltroBloque;
        private System.Windows.Forms.DataGridView dataGridViewBloque;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAreas;
        private System.Windows.Forms.Button buttonAddArea;
        private System.Windows.Forms.DataGridView dataGridViewAreas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem cambiarNombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarCategoríaToolStripMenuItem;
        private System.Windows.Forms.Button buttonTodasAreas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonAddCategoria;
        private System.Windows.Forms.DataGridView dataGridViewCategorias;
    }
}