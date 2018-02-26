namespace UrdsAppGestión.Presentacion.ComunidadesForms.EnviosForms
{
    partial class Envios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Envios));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verRegistroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verCuerpoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_documentos = new System.Windows.Forms.DataGridView();
            this.abrirDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_filtro = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_documentos)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enviar Correo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Añadir Documento";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(140, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Eliminar Documento";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verRegistroToolStripMenuItem,
            this.verCuerpoToolStripMenuItem,
            this.rToolStripMenuItem,
            this.abrirDocumentoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 92);
            // 
            // verRegistroToolStripMenuItem
            // 
            this.verRegistroToolStripMenuItem.Name = "verRegistroToolStripMenuItem";
            this.verRegistroToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.verRegistroToolStripMenuItem.Text = "Ver Registro";
            this.verRegistroToolStripMenuItem.Click += new System.EventHandler(this.verRegistroToolStripMenuItem_Click);
            // 
            // verCuerpoToolStripMenuItem
            // 
            this.verCuerpoToolStripMenuItem.Name = "verCuerpoToolStripMenuItem";
            this.verCuerpoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.verCuerpoToolStripMenuItem.Text = "Ver Cuerpo";
            this.verCuerpoToolStripMenuItem.Click += new System.EventHandler(this.verCuerpoToolStripMenuItem_Click);
            // 
            // rToolStripMenuItem
            // 
            this.rToolStripMenuItem.Name = "rToolStripMenuItem";
            this.rToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.rToolStripMenuItem.Text = "Reintentar Envio";
            this.rToolStripMenuItem.Click += new System.EventHandler(this.rToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(890, 583);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = " : Envio Incompleto";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(859, 584);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "         ";
            this.label3.Visible = false;
            // 
            // dataGridView_documentos
            // 
            this.dataGridView_documentos.AllowUserToAddRows = false;
            this.dataGridView_documentos.AllowUserToDeleteRows = false;
            this.dataGridView_documentos.AllowUserToResizeRows = false;
            this.dataGridView_documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_documentos.Location = new System.Drawing.Point(12, 54);
            this.dataGridView_documentos.MultiSelect = false;
            this.dataGridView_documentos.Name = "dataGridView_documentos";
            this.dataGridView_documentos.ReadOnly = true;
            this.dataGridView_documentos.RowHeadersVisible = false;
            this.dataGridView_documentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_documentos.Size = new System.Drawing.Size(998, 514);
            this.dataGridView_documentos.TabIndex = 7;
            this.dataGridView_documentos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_documentos_MouseClick);
            // 
            // abrirDocumentoToolStripMenuItem
            // 
            this.abrirDocumentoToolStripMenuItem.Name = "abrirDocumentoToolStripMenuItem";
            this.abrirDocumentoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.abrirDocumentoToolStripMenuItem.Text = "Abrir Documento";
            this.abrirDocumentoToolStripMenuItem.Click += new System.EventHandler(this.abrirDocumentoToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(881, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Últimos :";
            // 
            // comboBox_filtro
            // 
            this.comboBox_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filtro.FormattingEnabled = true;
            this.comboBox_filtro.Items.AddRange(new object[] {
            "5   Envíos",
            "10 Envíos",
            "20 Envíos",
            "Todos"});
            this.comboBox_filtro.Location = new System.Drawing.Point(934, 18);
            this.comboBox_filtro.Name = "comboBox_filtro";
            this.comboBox_filtro.Size = new System.Drawing.Size(75, 21);
            this.comboBox_filtro.TabIndex = 9;
            this.comboBox_filtro.SelectionChangeCommitted += new System.EventHandler(this.comboBox_filtro_SelectionChangeCommitted);
            // 
            // Envios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 616);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox_filtro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_documentos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Envios";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envios";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Envios_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_documentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verRegistroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verCuerpoToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem rToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_documentos;
        private System.Windows.Forms.ToolStripMenuItem abrirDocumentoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_filtro;
    }
}