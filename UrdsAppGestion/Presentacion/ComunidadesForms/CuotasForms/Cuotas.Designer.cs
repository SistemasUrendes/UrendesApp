namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms
{
    partial class Cuotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cuotas));
            this.dataGridView_Cuotas = new System.Windows.Forms.DataGridView();
            this.button_Añadir = new System.Windows.Forms.Button();
            this.button_Borrar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verDetallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_IrAPlantillas = new System.Windows.Forms.Button();
            this.comboBox_TipoPlantilla = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_abonar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cuotas)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Cuotas
            // 
            this.dataGridView_Cuotas.AllowUserToAddRows = false;
            this.dataGridView_Cuotas.AllowUserToDeleteRows = false;
            this.dataGridView_Cuotas.AllowUserToOrderColumns = true;
            this.dataGridView_Cuotas.AllowUserToResizeRows = false;
            this.dataGridView_Cuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Cuotas.Location = new System.Drawing.Point(23, 67);
            this.dataGridView_Cuotas.MultiSelect = false;
            this.dataGridView_Cuotas.Name = "dataGridView_Cuotas";
            this.dataGridView_Cuotas.ReadOnly = true;
            this.dataGridView_Cuotas.RowHeadersVisible = false;
            this.dataGridView_Cuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Cuotas.Size = new System.Drawing.Size(934, 361);
            this.dataGridView_Cuotas.TabIndex = 0;
            this.dataGridView_Cuotas.DoubleClick += new System.EventHandler(this.verDetallesToolStripMenuItem_Click);
            this.dataGridView_Cuotas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_Cuotas_MouseClick);
            // 
            // button_Añadir
            // 
            this.button_Añadir.Location = new System.Drawing.Point(23, 12);
            this.button_Añadir.Name = "button_Añadir";
            this.button_Añadir.Size = new System.Drawing.Size(54, 23);
            this.button_Añadir.TabIndex = 1;
            this.button_Añadir.Text = "Nueva";
            this.button_Añadir.UseVisualStyleBackColor = true;
            this.button_Añadir.Click += new System.EventHandler(this.button_Añadir_Click);
            // 
            // button_Borrar
            // 
            this.button_Borrar.Location = new System.Drawing.Point(83, 12);
            this.button_Borrar.Name = "button_Borrar";
            this.button_Borrar.Size = new System.Drawing.Size(52, 23);
            this.button_Borrar.TabIndex = 3;
            this.button_Borrar.Text = "Borrar";
            this.button_Borrar.UseVisualStyleBackColor = true;
            this.button_Borrar.Click += new System.EventHandler(this.button_Borrar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetallesToolStripMenuItem,
            this.informeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 48);
            // 
            // verDetallesToolStripMenuItem
            // 
            this.verDetallesToolStripMenuItem.Name = "verDetallesToolStripMenuItem";
            this.verDetallesToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.verDetallesToolStripMenuItem.Text = "Ver Detalles";
            this.verDetallesToolStripMenuItem.Click += new System.EventHandler(this.verDetallesToolStripMenuItem_Click);
            // 
            // informeToolStripMenuItem
            // 
            this.informeToolStripMenuItem.Name = "informeToolStripMenuItem";
            this.informeToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.informeToolStripMenuItem.Text = "Informe";
            this.informeToolStripMenuItem.Click += new System.EventHandler(this.informeToolStripMenuItem_Click);
            // 
            // button_IrAPlantillas
            // 
            this.button_IrAPlantillas.Location = new System.Drawing.Point(862, 38);
            this.button_IrAPlantillas.Name = "button_IrAPlantillas";
            this.button_IrAPlantillas.Size = new System.Drawing.Size(78, 23);
            this.button_IrAPlantillas.TabIndex = 6;
            this.button_IrAPlantillas.Text = "Plantillas";
            this.button_IrAPlantillas.UseVisualStyleBackColor = true;
            this.button_IrAPlantillas.Click += new System.EventHandler(this.button_IrAPlantillas_Click);
            // 
            // comboBox_TipoPlantilla
            // 
            this.comboBox_TipoPlantilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TipoPlantilla.FormattingEnabled = true;
            this.comboBox_TipoPlantilla.Items.AddRange(new object[] {
            "Manuales"});
            this.comboBox_TipoPlantilla.Location = new System.Drawing.Point(740, 39);
            this.comboBox_TipoPlantilla.Name = "comboBox_TipoPlantilla";
            this.comboBox_TipoPlantilla.Size = new System.Drawing.Size(116, 21);
            this.comboBox_TipoPlantilla.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Importar Cuotas con Detalles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_abonar
            // 
            this.button_abonar.Location = new System.Drawing.Point(587, 37);
            this.button_abonar.Name = "button_abonar";
            this.button_abonar.Size = new System.Drawing.Size(109, 23);
            this.button_abonar.TabIndex = 10;
            this.button_abonar.Text = "Abonar Cuota";
            this.button_abonar.UseVisualStyleBackColor = true;
            this.button_abonar.Visible = false;
            this.button_abonar.Click += new System.EventHandler(this.button_abonar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(796, 435);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(161, 23);
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Buscar : ";
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(78, 41);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(217, 20);
            this.textBox_buscar.TabIndex = 13;
            this.textBox_buscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Cuotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 471);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_abonar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_TipoPlantilla);
            this.Controls.Add(this.button_IrAPlantillas);
            this.Controls.Add(this.button_Borrar);
            this.Controls.Add(this.button_Añadir);
            this.Controls.Add(this.dataGridView_Cuotas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cuotas";
            this.Text = "Cuotas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Cuotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cuotas)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Cuotas;
        private System.Windows.Forms.Button button_Añadir;
        private System.Windows.Forms.Button button_Borrar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verDetallesToolStripMenuItem;
        private System.Windows.Forms.Button button_IrAPlantillas;
        private System.Windows.Forms.ComboBox comboBox_TipoPlantilla;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem informeToolStripMenuItem;
        private System.Windows.Forms.Button button_abonar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_buscar;
    }
}