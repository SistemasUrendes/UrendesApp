namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    partial class FormListadoOrganos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListadoOrganos));
            this.dataGridViewOrganos = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cambiarNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darDeBajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxfiltro = new System.Windows.Forms.TextBox();
            this.buttonNuevo = new System.Windows.Forms.Button();
            this.textBoxBloque = new System.Windows.Forms.TextBox();
            this.buttonSelBloque = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEnviar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrganos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewOrganos
            // 
            this.dataGridViewOrganos.AllowUserToAddRows = false;
            this.dataGridViewOrganos.AllowUserToDeleteRows = false;
            this.dataGridViewOrganos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrganos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOrganos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrganos.Location = new System.Drawing.Point(13, 70);
            this.dataGridViewOrganos.Name = "dataGridViewOrganos";
            this.dataGridViewOrganos.ReadOnly = true;
            this.dataGridViewOrganos.RowHeadersVisible = false;
            this.dataGridViewOrganos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewOrganos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrganos.Size = new System.Drawing.Size(336, 454);
            this.dataGridViewOrganos.TabIndex = 21;
            this.dataGridViewOrganos.TabStop = false;
            this.dataGridViewOrganos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrganos_CellDoubleClick);
            this.dataGridViewOrganos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewOrganos_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarNombreToolStripMenuItem,
            this.darDeBajaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 48);
            // 
            // cambiarNombreToolStripMenuItem
            // 
            this.cambiarNombreToolStripMenuItem.Name = "cambiarNombreToolStripMenuItem";
            this.cambiarNombreToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.cambiarNombreToolStripMenuItem.Text = "Editar";
            this.cambiarNombreToolStripMenuItem.Click += new System.EventHandler(this.cambiarNombreToolStripMenuItem_Click);
            // 
            // darDeBajaToolStripMenuItem
            // 
            this.darDeBajaToolStripMenuItem.Name = "darDeBajaToolStripMenuItem";
            this.darDeBajaToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.darDeBajaToolStripMenuItem.Text = "Dar de Baja";
            this.darDeBajaToolStripMenuItem.Click += new System.EventHandler(this.darDeBajaToolStripMenuItem_Click);
            // 
            // textBoxfiltro
            // 
            this.textBoxfiltro.Location = new System.Drawing.Point(63, 44);
            this.textBoxfiltro.Name = "textBoxfiltro";
            this.textBoxfiltro.Size = new System.Drawing.Size(193, 20);
            this.textBoxfiltro.TabIndex = 23;
            this.textBoxfiltro.TextChanged += new System.EventHandler(this.textBoxfiltro_TextChanged);
            // 
            // buttonNuevo
            // 
            this.buttonNuevo.Location = new System.Drawing.Point(262, 41);
            this.buttonNuevo.Name = "buttonNuevo";
            this.buttonNuevo.Size = new System.Drawing.Size(87, 23);
            this.buttonNuevo.TabIndex = 24;
            this.buttonNuevo.Text = "Nuevo";
            this.buttonNuevo.UseVisualStyleBackColor = true;
            this.buttonNuevo.Click += new System.EventHandler(this.buttonNuevo_Click);
            // 
            // textBoxBloque
            // 
            this.textBoxBloque.Location = new System.Drawing.Point(63, 14);
            this.textBoxBloque.Name = "textBoxBloque";
            this.textBoxBloque.ReadOnly = true;
            this.textBoxBloque.Size = new System.Drawing.Size(193, 20);
            this.textBoxBloque.TabIndex = 25;
            this.textBoxBloque.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxOrgano_MouseDoubleClick);
            // 
            // buttonSelBloque
            // 
            this.buttonSelBloque.Location = new System.Drawing.Point(262, 12);
            this.buttonSelBloque.Name = "buttonSelBloque";
            this.buttonSelBloque.Size = new System.Drawing.Size(87, 23);
            this.buttonSelBloque.TabIndex = 26;
            this.buttonSelBloque.Text = "Bloque";
            this.buttonSelBloque.UseVisualStyleBackColor = true;
            this.buttonSelBloque.Click += new System.EventHandler(this.buttonSelBloque_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Bloque:";
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Location = new System.Drawing.Point(12, 41);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(45, 23);
            this.buttonEnviar.TabIndex = 28;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Visible = false;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // FormListadoOrganos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 540);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSelBloque);
            this.Controls.Add(this.textBoxBloque);
            this.Controls.Add(this.buttonNuevo);
            this.Controls.Add(this.textBoxfiltro);
            this.Controls.Add(this.dataGridViewOrganos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormListadoOrganos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Organos de Gobierno";
            this.Load += new System.EventHandler(this.FormListadoOrganos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrganos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrganos;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cambiarNombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darDeBajaToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxfiltro;
        private System.Windows.Forms.Button buttonNuevo;
        private System.Windows.Forms.TextBox textBoxBloque;
        private System.Windows.Forms.Button buttonSelBloque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEnviar;
    }
}