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
            this.dataGridViewTipoGestion = new System.Windows.Forms.DataGridView();
            this.buttonAddGestion = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxFiltroTipoGestion = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxFiltroTarea = new System.Windows.Forms.TextBox();
            this.buttonAddTipoTarea = new System.Windows.Forms.Button();
            this.dataGridViewTipoTarea = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoGestion)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoTarea)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTipoGestion
            // 
            this.dataGridViewTipoGestion.AllowUserToAddRows = false;
            this.dataGridViewTipoGestion.AllowUserToDeleteRows = false;
            this.dataGridViewTipoGestion.AllowUserToResizeRows = false;
            this.dataGridViewTipoGestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTipoGestion.Location = new System.Drawing.Point(6, 43);
            this.dataGridViewTipoGestion.Name = "dataGridViewTipoGestion";
            this.dataGridViewTipoGestion.ReadOnly = true;
            this.dataGridViewTipoGestion.RowHeadersVisible = false;
            this.dataGridViewTipoGestion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewTipoGestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTipoGestion.ShowEditingIcon = false;
            this.dataGridViewTipoGestion.Size = new System.Drawing.Size(293, 350);
            this.dataGridViewTipoGestion.TabIndex = 0;
            this.dataGridViewTipoGestion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTipoGestion_CellDoubleClick);
            this.dataGridViewTipoGestion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewTipoGestion_MouseClick);
            // 
            // buttonAddGestion
            // 
            this.buttonAddGestion.Location = new System.Drawing.Point(224, 17);
            this.buttonAddGestion.Name = "buttonAddGestion";
            this.buttonAddGestion.Size = new System.Drawing.Size(75, 23);
            this.buttonAddGestion.TabIndex = 2;
            this.buttonAddGestion.Text = "Añadir";
            this.buttonAddGestion.UseVisualStyleBackColor = true;
            this.buttonAddGestion.Click += new System.EventHandler(this.buttonAddGestion_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.borrarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(107, 48);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.borrarToolStripMenuItem.Text = "Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFiltroTipoGestion);
            this.groupBox1.Controls.Add(this.buttonAddGestion);
            this.groupBox1.Controls.Add(this.dataGridViewTipoGestion);
            this.groupBox1.Location = new System.Drawing.Point(393, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 418);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Gestión";
            // 
            // textBoxFiltroTipoGestion
            // 
            this.textBoxFiltroTipoGestion.Location = new System.Drawing.Point(6, 19);
            this.textBoxFiltroTipoGestion.Name = "textBoxFiltroTipoGestion";
            this.textBoxFiltroTipoGestion.Size = new System.Drawing.Size(212, 20);
            this.textBoxFiltroTipoGestion.TabIndex = 3;
            this.textBoxFiltroTipoGestion.TextChanged += new System.EventHandler(this.textBoxFiltroTipoGestion_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxFiltroTarea);
            this.groupBox2.Controls.Add(this.buttonAddTipoTarea);
            this.groupBox2.Controls.Add(this.dataGridViewTipoTarea);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
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
            this.dataGridViewTipoTarea.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTipoTarea_CellDoubleClick);
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
            // FormTareasConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 628);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTareasConfiguracion";
            this.Text = "Configuración Tarea";
            this.Load += new System.EventHandler(this.FormTareasConfiguracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoGestion)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoTarea)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTipoGestion;
        private System.Windows.Forms.Button buttonAddGestion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFiltroTipoGestion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxFiltroTarea;
        private System.Windows.Forms.Button buttonAddTipoTarea;
        private System.Windows.Forms.DataGridView dataGridViewTipoTarea;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem1;
    }
}