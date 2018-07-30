namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormTareasConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTareasConfiguracion));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxFiltroTarea = new System.Windows.Forms.TextBox();
            this.buttonAddTipoTarea = new System.Windows.Forms.Button();
            this.dataGridViewTipoTarea = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonRemoveGestion = new System.Windows.Forms.Button();
            this.buttonAddGestion = new System.Windows.Forms.Button();
            this.buttonBajar = new System.Windows.Forms.Button();
            this.buttonSubir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFiltroGestiones = new System.Windows.Forms.TextBox();
            this.dataGridViewAddGestion = new System.Windows.Forms.DataGridView();
            this.dataGridViewAllGestion = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxFiltroCategorias = new System.Windows.Forms.TextBox();
            this.buttonAddCategoria = new System.Windows.Forms.Button();
            this.dataGridViewCategorias = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoTarea)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddGestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllGestion)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategorias)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxFiltroTarea);
            this.groupBox2.Controls.Add(this.buttonAddTipoTarea);
            this.groupBox2.Controls.Add(this.dataGridViewTipoTarea);
            this.groupBox2.Location = new System.Drawing.Point(346, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 418);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tareas con Procedimiento";
            // 
            // textBoxFiltroTarea
            // 
            this.textBoxFiltroTarea.Location = new System.Drawing.Point(6, 19);
            this.textBoxFiltroTarea.Name = "textBoxFiltroTarea";
            this.textBoxFiltroTarea.Size = new System.Drawing.Size(212, 20);
            this.textBoxFiltroTarea.TabIndex = 3;
            this.textBoxFiltroTarea.TextChanged += new System.EventHandler(this.textBoxFiltroTarea_TextChanged);
            // 
            // buttonAddTipoTarea
            // 
            this.buttonAddTipoTarea.Location = new System.Drawing.Point(224, 17);
            this.buttonAddTipoTarea.Name = "buttonAddTipoTarea";
            this.buttonAddTipoTarea.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTipoTarea.TabIndex = 2;
            this.buttonAddTipoTarea.Text = "Añadir";
            this.buttonAddTipoTarea.UseVisualStyleBackColor = true;
            this.buttonAddTipoTarea.Click += new System.EventHandler(this.buttonAddTipoTarea_Click);
            // 
            // dataGridViewTipoTarea
            // 
            this.dataGridViewTipoTarea.AllowUserToAddRows = false;
            this.dataGridViewTipoTarea.AllowUserToDeleteRows = false;
            this.dataGridViewTipoTarea.AllowUserToResizeRows = false;
            this.dataGridViewTipoTarea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTipoTarea.Location = new System.Drawing.Point(6, 43);
            this.dataGridViewTipoTarea.Name = "dataGridViewTipoTarea";
            this.dataGridViewTipoTarea.ReadOnly = true;
            this.dataGridViewTipoTarea.RowHeadersVisible = false;
            this.dataGridViewTipoTarea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewTipoTarea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTipoTarea.ShowEditingIcon = false;
            this.dataGridViewTipoTarea.Size = new System.Drawing.Size(293, 350);
            this.dataGridViewTipoTarea.TabIndex = 0;
            this.dataGridViewTipoTarea.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTipoTarea_CellClick);
            this.dataGridViewTipoTarea.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCategorias_CellClick);
            this.dataGridViewTipoTarea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewTipoTarea_MouseClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem1,
            this.borrarToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(107, 48);
            // 
            // editarToolStripMenuItem1
            // 
            this.editarToolStripMenuItem1.Name = "editarToolStripMenuItem1";
            this.editarToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.editarToolStripMenuItem1.Text = "Editar";
            this.editarToolStripMenuItem1.Click += new System.EventHandler(this.editarToolStripMenuItem1_Click);
            // 
            // borrarToolStripMenuItem1
            // 
            this.borrarToolStripMenuItem1.Name = "borrarToolStripMenuItem1";
            this.borrarToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.borrarToolStripMenuItem1.Text = "Borrar";
            this.borrarToolStripMenuItem1.Click += new System.EventHandler(this.borrarToolStripMenuItem1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Controls.Add(this.buttonRemoveGestion);
            this.groupBox1.Controls.Add(this.buttonAddGestion);
            this.groupBox1.Controls.Add(this.buttonBajar);
            this.groupBox1.Controls.Add(this.buttonSubir);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxFiltroGestiones);
            this.groupBox1.Controls.Add(this.dataGridViewAddGestion);
            this.groupBox1.Controls.Add(this.dataGridViewAllGestion);
            this.groupBox1.Location = new System.Drawing.Point(680, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 418);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestiones del procedimiento";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(108, 25);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 17);
            this.labelName.TabIndex = 35;
            // 
            // buttonRemoveGestion
            // 
            this.buttonRemoveGestion.Location = new System.Drawing.Point(333, 254);
            this.buttonRemoveGestion.Name = "buttonRemoveGestion";
            this.buttonRemoveGestion.Size = new System.Drawing.Size(28, 23);
            this.buttonRemoveGestion.TabIndex = 34;
            this.buttonRemoveGestion.Text = ">>";
            this.buttonRemoveGestion.UseVisualStyleBackColor = true;
            this.buttonRemoveGestion.Click += new System.EventHandler(this.buttonRemoveGestion_Click);
            // 
            // buttonAddGestion
            // 
            this.buttonAddGestion.Location = new System.Drawing.Point(333, 225);
            this.buttonAddGestion.Name = "buttonAddGestion";
            this.buttonAddGestion.Size = new System.Drawing.Size(28, 23);
            this.buttonAddGestion.TabIndex = 33;
            this.buttonAddGestion.Text = "<<";
            this.buttonAddGestion.UseVisualStyleBackColor = true;
            this.buttonAddGestion.Click += new System.EventHandler(this.buttonAddGestion_Click);
            // 
            // buttonBajar
            // 
            this.buttonBajar.Location = new System.Drawing.Point(333, 143);
            this.buttonBajar.Name = "buttonBajar";
            this.buttonBajar.Size = new System.Drawing.Size(28, 23);
            this.buttonBajar.TabIndex = 32;
            this.buttonBajar.Text = "↓";
            this.buttonBajar.UseVisualStyleBackColor = true;
            this.buttonBajar.Click += new System.EventHandler(this.buttonBajar_Click);
            // 
            // buttonSubir
            // 
            this.buttonSubir.Location = new System.Drawing.Point(333, 114);
            this.buttonSubir.Name = "buttonSubir";
            this.buttonSubir.Size = new System.Drawing.Size(28, 23);
            this.buttonSubir.TabIndex = 31;
            this.buttonSubir.Text = "↑";
            this.buttonSubir.UseVisualStyleBackColor = true;
            this.buttonSubir.Click += new System.EventHandler(this.buttonSubir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Procedimiento:";
            // 
            // textBoxFiltroGestiones
            // 
            this.textBoxFiltroGestiones.Location = new System.Drawing.Point(367, 19);
            this.textBoxFiltroGestiones.Name = "textBoxFiltroGestiones";
            this.textBoxFiltroGestiones.Size = new System.Drawing.Size(309, 20);
            this.textBoxFiltroGestiones.TabIndex = 27;
            this.textBoxFiltroGestiones.TextChanged += new System.EventHandler(this.textBoxFiltroGestiones_TextChanged);
            // 
            // dataGridViewAddGestion
            // 
            this.dataGridViewAddGestion.AllowUserToAddRows = false;
            this.dataGridViewAddGestion.AllowUserToDeleteRows = false;
            this.dataGridViewAddGestion.AllowUserToResizeRows = false;
            this.dataGridViewAddGestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddGestion.Location = new System.Drawing.Point(28, 55);
            this.dataGridViewAddGestion.MultiSelect = false;
            this.dataGridViewAddGestion.Name = "dataGridViewAddGestion";
            this.dataGridViewAddGestion.ReadOnly = true;
            this.dataGridViewAddGestion.RowHeadersVisible = false;
            this.dataGridViewAddGestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAddGestion.Size = new System.Drawing.Size(299, 338);
            this.dataGridViewAddGestion.TabIndex = 26;
            this.dataGridViewAddGestion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAddGestion_CellDoubleClick);
            // 
            // dataGridViewAllGestion
            // 
            this.dataGridViewAllGestion.AllowUserToAddRows = false;
            this.dataGridViewAllGestion.AllowUserToDeleteRows = false;
            this.dataGridViewAllGestion.AllowUserToResizeRows = false;
            this.dataGridViewAllGestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllGestion.Location = new System.Drawing.Point(367, 55);
            this.dataGridViewAllGestion.MultiSelect = false;
            this.dataGridViewAllGestion.Name = "dataGridViewAllGestion";
            this.dataGridViewAllGestion.ReadOnly = true;
            this.dataGridViewAllGestion.RowHeadersVisible = false;
            this.dataGridViewAllGestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAllGestion.Size = new System.Drawing.Size(309, 338);
            this.dataGridViewAllGestion.TabIndex = 25;
            this.dataGridViewAllGestion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAllGestion_CellDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxFiltroCategorias);
            this.groupBox3.Controls.Add(this.buttonAddCategoria);
            this.groupBox3.Controls.Add(this.dataGridViewCategorias);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 418);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Categorías de Procedimientos";
            // 
            // textBoxFiltroCategorias
            // 
            this.textBoxFiltroCategorias.Location = new System.Drawing.Point(6, 19);
            this.textBoxFiltroCategorias.Name = "textBoxFiltroCategorias";
            this.textBoxFiltroCategorias.Size = new System.Drawing.Size(212, 20);
            this.textBoxFiltroCategorias.TabIndex = 3;
            this.textBoxFiltroCategorias.TextChanged += new System.EventHandler(this.textBoxFiltroCategorias_TextChanged);
            // 
            // buttonAddCategoria
            // 
            this.buttonAddCategoria.Location = new System.Drawing.Point(224, 17);
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
            this.dataGridViewCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCategorias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategorias.Location = new System.Drawing.Point(6, 43);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 26);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // FormTareasConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 628);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTareasConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración Tarea";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTareasConfiguracion_FormClosing);
            this.Load += new System.EventHandler(this.FormTareasConfiguracion_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoTarea)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddGestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllGestion)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategorias)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxFiltroTarea;
        private System.Windows.Forms.Button buttonAddTipoTarea;
        private System.Windows.Forms.DataGridView dataGridViewTipoTarea;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRemoveGestion;
        private System.Windows.Forms.Button buttonAddGestion;
        private System.Windows.Forms.Button buttonBajar;
        private System.Windows.Forms.Button buttonSubir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFiltroGestiones;
        private System.Windows.Forms.DataGridView dataGridViewAddGestion;
        private System.Windows.Forms.DataGridView dataGridViewAllGestion;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxFiltroCategorias;
        private System.Windows.Forms.Button buttonAddCategoria;
        private System.Windows.Forms.DataGridView dataGridViewCategorias;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
    }
}