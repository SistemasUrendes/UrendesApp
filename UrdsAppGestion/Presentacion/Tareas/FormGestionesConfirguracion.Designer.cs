namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormGestionesConfirguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestionesConfirguracion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxFiltroTipoGestion = new System.Windows.Forms.TextBox();
            this.buttonAddGestion = new System.Windows.Forms.Button();
            this.dataGridViewTipoGestion = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoGestion)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFiltroTipoGestion);
            this.groupBox1.Controls.Add(this.buttonAddGestion);
            this.groupBox1.Controls.Add(this.dataGridViewTipoGestion);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 418);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Gestión";
            // 
            // textBoxFiltroTipoGestion
            // 
            this.textBoxFiltroTipoGestion.Location = new System.Drawing.Point(6, 19);
            this.textBoxFiltroTipoGestion.Name = "textBoxFiltroTipoGestion";
            this.textBoxFiltroTipoGestion.Size = new System.Drawing.Size(280, 20);
            this.textBoxFiltroTipoGestion.TabIndex = 3;
            this.textBoxFiltroTipoGestion.TextChanged += new System.EventHandler(this.textBoxFiltroTipoGestion_TextChanged);
            // 
            // buttonAddGestion
            // 
            this.buttonAddGestion.Location = new System.Drawing.Point(292, 17);
            this.buttonAddGestion.Name = "buttonAddGestion";
            this.buttonAddGestion.Size = new System.Drawing.Size(75, 23);
            this.buttonAddGestion.TabIndex = 2;
            this.buttonAddGestion.Text = "Añadir";
            this.buttonAddGestion.UseVisualStyleBackColor = true;
            this.buttonAddGestion.Click += new System.EventHandler(this.buttonAddGestion_Click);
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
            this.dataGridViewTipoGestion.Size = new System.Drawing.Size(361, 350);
            this.dataGridViewTipoGestion.TabIndex = 0;
            this.dataGridViewTipoGestion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTipoGestion_CellDoubleClick);
            this.dataGridViewTipoGestion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewTipoGestion_MouseClick);
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
            // FormGestionesConfirguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 514);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGestionesConfirguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento Gestiones";
            this.Load += new System.EventHandler(this.FormGestionesConfirguracion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoGestion)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFiltroTipoGestion;
        private System.Windows.Forms.Button buttonAddGestion;
        private System.Windows.Forms.DataGridView dataGridViewTipoGestion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
    }
}