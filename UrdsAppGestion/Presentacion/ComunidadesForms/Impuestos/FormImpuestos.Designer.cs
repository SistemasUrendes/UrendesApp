namespace UrdsAppGestión.Presentacion.ComunidadesForms.Impuestos
{
    partial class FormImpuestos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImpuestos));
            this.dataGridView_impuestos = new System.Windows.Forms.DataGridView();
            this.comboBox_liquidaciones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.marcarComoLiquidableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTodasDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_informes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_impuestos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_impuestos
            // 
            this.dataGridView_impuestos.AllowUserToAddRows = false;
            this.dataGridView_impuestos.AllowUserToDeleteRows = false;
            this.dataGridView_impuestos.AllowUserToResizeRows = false;
            this.dataGridView_impuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_impuestos.Location = new System.Drawing.Point(12, 72);
            this.dataGridView_impuestos.Name = "dataGridView_impuestos";
            this.dataGridView_impuestos.ReadOnly = true;
            this.dataGridView_impuestos.RowHeadersVisible = false;
            this.dataGridView_impuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_impuestos.Size = new System.Drawing.Size(1111, 472);
            this.dataGridView_impuestos.TabIndex = 0;
            this.dataGridView_impuestos.DoubleClick += new System.EventHandler(this.dataGridView_impuestos_DoubleClick);
            this.dataGridView_impuestos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_impuestos_MouseClick);
            // 
            // comboBox_liquidaciones
            // 
            this.comboBox_liquidaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_liquidaciones.FormattingEnabled = true;
            this.comboBox_liquidaciones.Items.AddRange(new object[] {
            "1 Trimestre IVA",
            "2 Trimestre IVA",
            "3 Trimestre IVA",
            "4 Trimestre IVA"});
            this.comboBox_liquidaciones.Location = new System.Drawing.Point(1002, 45);
            this.comboBox_liquidaciones.Name = "comboBox_liquidaciones";
            this.comboBox_liquidaciones.Size = new System.Drawing.Size(121, 21);
            this.comboBox_liquidaciones.TabIndex = 1;
            this.comboBox_liquidaciones.SelectionChangeCommitted += new System.EventHandler(this.comboBox_liquidaciones_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(940, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Trimestre :";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marcarComoLiquidableToolStripMenuItem,
            this.verTodasDeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 48);
            // 
            // marcarComoLiquidableToolStripMenuItem
            // 
            this.marcarComoLiquidableToolStripMenuItem.Name = "marcarComoLiquidableToolStripMenuItem";
            this.marcarComoLiquidableToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.marcarComoLiquidableToolStripMenuItem.Text = "Marcar como Liquidada";
            this.marcarComoLiquidableToolStripMenuItem.Click += new System.EventHandler(this.marcarComoLiquidableToolStripMenuItem_Click);
            // 
            // verTodasDeToolStripMenuItem
            // 
            this.verTodasDeToolStripMenuItem.Name = "verTodasDeToolStripMenuItem";
            this.verTodasDeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.verTodasDeToolStripMenuItem.Text = "Ver todas de :";
            this.verTodasDeToolStripMenuItem.Click += new System.EventHandler(this.verTodasDeToolStripMenuItem_Click);
            // 
            // comboBox_informes
            // 
            this.comboBox_informes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_informes.FormattingEnabled = true;
            this.comboBox_informes.Items.AddRange(new object[] {
            "Por Entidades"});
            this.comboBox_informes.Location = new System.Drawing.Point(1002, 13);
            this.comboBox_informes.Name = "comboBox_informes";
            this.comboBox_informes.Size = new System.Drawing.Size(121, 21);
            this.comboBox_informes.TabIndex = 3;
            this.comboBox_informes.SelectionChangeCommitted += new System.EventHandler(this.comboBox_informes_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(940, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Informes:";
            // 
            // FormImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 556);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_informes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_liquidaciones);
            this.Controls.Add(this.dataGridView_impuestos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormImpuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impuestos";
            this.Load += new System.EventHandler(this.FormImpuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_impuestos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_impuestos;
        private System.Windows.Forms.ComboBox comboBox_liquidaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem marcarComoLiquidableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTodasDeToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox_informes;
        private System.Windows.Forms.Label label2;
    }
}