namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms
{
    partial class FormFondos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFondos));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox_Filtro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Fondos = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarFondoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView_detallesFondos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.entradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexarLiquidaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calcularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarConResultadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Fondos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detallesFondos)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Añadir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Editar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(174, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Borrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox_Filtro
            // 
            this.comboBox_Filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Filtro.FormattingEnabled = true;
            this.comboBox_Filtro.Items.AddRange(new object[] {
            "Inicial",
            "Reserva",
            "Resultado",
            "Voluntario",
            "Todos"});
            this.comboBox_Filtro.Location = new System.Drawing.Point(772, 17);
            this.comboBox_Filtro.Name = "comboBox_Filtro";
            this.comboBox_Filtro.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Filtro.TabIndex = 3;
            this.comboBox_Filtro.Visible = false;
            this.comboBox_Filtro.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Filtro_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(734, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtro:";
            this.label1.Visible = false;
            // 
            // dataGridView_Fondos
            // 
            this.dataGridView_Fondos.AllowUserToAddRows = false;
            this.dataGridView_Fondos.AllowUserToDeleteRows = false;
            this.dataGridView_Fondos.AllowUserToOrderColumns = true;
            this.dataGridView_Fondos.AllowUserToResizeRows = false;
            this.dataGridView_Fondos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Fondos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Fondos.Location = new System.Drawing.Point(12, 44);
            this.dataGridView_Fondos.MultiSelect = false;
            this.dataGridView_Fondos.Name = "dataGridView_Fondos";
            this.dataGridView_Fondos.ReadOnly = true;
            this.dataGridView_Fondos.RowHeadersVisible = false;
            this.dataGridView_Fondos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Fondos.Size = new System.Drawing.Size(881, 266);
            this.dataGridView_Fondos.TabIndex = 5;
            this.dataGridView_Fondos.SelectionChanged += new System.EventHandler(this.dataGridView_Fondos_SelectionChanged);
            this.dataGridView_Fondos.DoubleClick += new System.EventHandler(this.detallesToolStripMenuItem_Click);
            this.dataGridView_Fondos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Fondos_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detallesToolStripMenuItem,
            this.inciarToolStripMenuItem,
            this.cerrarFondoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 70);
            // 
            // detallesToolStripMenuItem
            // 
            this.detallesToolStripMenuItem.Name = "detallesToolStripMenuItem";
            this.detallesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.detallesToolStripMenuItem.Text = "Detalles";
            this.detallesToolStripMenuItem.Click += new System.EventHandler(this.detallesToolStripMenuItem_Click);
            // 
            // inciarToolStripMenuItem
            // 
            this.inciarToolStripMenuItem.Name = "inciarToolStripMenuItem";
            this.inciarToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.inciarToolStripMenuItem.Text = "Iniciar";
            this.inciarToolStripMenuItem.Click += new System.EventHandler(this.inciarToolStripMenuItem_Click);
            // 
            // cerrarFondoToolStripMenuItem
            // 
            this.cerrarFondoToolStripMenuItem.Name = "cerrarFondoToolStripMenuItem";
            this.cerrarFondoToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarFondoToolStripMenuItem.Text = "Cerrar Fondo";
            this.cerrarFondoToolStripMenuItem.Click += new System.EventHandler(this.cerrarFondoToolStripMenuItem_Click);
            // 
            // dataGridView_detallesFondos
            // 
            this.dataGridView_detallesFondos.AllowUserToAddRows = false;
            this.dataGridView_detallesFondos.AllowUserToDeleteRows = false;
            this.dataGridView_detallesFondos.AllowUserToResizeRows = false;
            this.dataGridView_detallesFondos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_detallesFondos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_detallesFondos.Location = new System.Drawing.Point(12, 345);
            this.dataGridView_detallesFondos.MultiSelect = false;
            this.dataGridView_detallesFondos.Name = "dataGridView_detallesFondos";
            this.dataGridView_detallesFondos.ReadOnly = true;
            this.dataGridView_detallesFondos.RowHeadersVisible = false;
            this.dataGridView_detallesFondos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_detallesFondos.Size = new System.Drawing.Size(881, 194);
            this.dataGridView_detallesFondos.TabIndex = 6;
            this.dataGridView_detallesFondos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_detallesFondos_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Detalles del Fondo";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entradasToolStripMenuItem,
            this.salidasToolStripMenuItem,
            this.indexarLiquidaciónToolStripMenuItem,
            this.calcularToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.iniciarConResultadoToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(185, 158);
            // 
            // entradasToolStripMenuItem
            // 
            this.entradasToolStripMenuItem.Name = "entradasToolStripMenuItem";
            this.entradasToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.entradasToolStripMenuItem.Text = "Entradas";
            this.entradasToolStripMenuItem.Click += new System.EventHandler(this.entradasToolStripMenuItem_Click);
            // 
            // salidasToolStripMenuItem
            // 
            this.salidasToolStripMenuItem.Name = "salidasToolStripMenuItem";
            this.salidasToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.salidasToolStripMenuItem.Text = "Salidas";
            this.salidasToolStripMenuItem.Click += new System.EventHandler(this.salidasToolStripMenuItem_Click);
            // 
            // indexarLiquidaciónToolStripMenuItem
            // 
            this.indexarLiquidaciónToolStripMenuItem.Name = "indexarLiquidaciónToolStripMenuItem";
            this.indexarLiquidaciónToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.indexarLiquidaciónToolStripMenuItem.Text = "Indexar Liquidación";
            this.indexarLiquidaciónToolStripMenuItem.Click += new System.EventHandler(this.indexarLiquidaciónToolStripMenuItem_Click);
            // 
            // calcularToolStripMenuItem
            // 
            this.calcularToolStripMenuItem.Name = "calcularToolStripMenuItem";
            this.calcularToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.calcularToolStripMenuItem.Text = "Calcular";
            this.calcularToolStripMenuItem.Click += new System.EventHandler(this.calcularToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // iniciarConResultadoToolStripMenuItem
            // 
            this.iniciarConResultadoToolStripMenuItem.Name = "iniciarConResultadoToolStripMenuItem";
            this.iniciarConResultadoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.iniciarConResultadoToolStripMenuItem.Text = "Iniciar con Resultado";
            this.iniciarConResultadoToolStripMenuItem.Click += new System.EventHandler(this.iniciarConResultadoToolStripMenuItem_Click);
            // 
            // FormFondos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 551);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView_detallesFondos);
            this.Controls.Add(this.dataGridView_Fondos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Filtro);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFondos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fondos Comunidad";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormFondos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Fondos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detallesFondos)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox_Filtro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Fondos;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem detallesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inciarToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView_detallesFondos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem cerrarFondoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem entradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexarLiquidaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calcularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarConResultadoToolStripMenuItem;
    }
}