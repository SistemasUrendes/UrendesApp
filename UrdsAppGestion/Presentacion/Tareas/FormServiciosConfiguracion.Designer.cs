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
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxAreas = new System.Windows.Forms.TextBox();
            this.buttonAddArea = new System.Windows.Forms.Button();
            this.dataGridViewAreas = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBloque)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAreas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxComunidades);
            this.groupBox2.Controls.Add(this.textBoxFiltroBloque);
            this.groupBox2.Controls.Add(this.dataGridViewBloque);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 428);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bloques";
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
            this.dataGridViewBloque.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewBloque_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(107, 26);
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
            this.groupBox1.Controls.Add(this.textBoxAreas);
            this.groupBox1.Controls.Add(this.buttonAddArea);
            this.groupBox1.Controls.Add(this.dataGridViewAreas);
            this.groupBox1.Location = new System.Drawing.Point(346, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 428);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Areas";
            // 
            // textBoxAreas
            // 
            this.textBoxAreas.Location = new System.Drawing.Point(6, 46);
            this.textBoxAreas.Name = "textBoxAreas";
            this.textBoxAreas.Size = new System.Drawing.Size(212, 20);
            this.textBoxAreas.TabIndex = 3;
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
            this.dataGridViewAreas.Size = new System.Drawing.Size(293, 350);
            this.dataGridViewAreas.TabIndex = 0;
            // 
            // FormServiciosConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 476);
            this.ControlBox = false;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxComunidades;
        private System.Windows.Forms.TextBox textBoxFiltroBloque;
        private System.Windows.Forms.DataGridView dataGridViewBloque;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxAreas;
        private System.Windows.Forms.Button buttonAddArea;
        private System.Windows.Forms.DataGridView dataGridViewAreas;
    }
}