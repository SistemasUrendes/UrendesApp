namespace UrdsAppGestión.Presentacion.ComunidadesForms.RemesasForms
{
    partial class FormRemesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRemesas));
            this.dataGridView_remesas = new System.Windows.Forms.DataGridView();
            this.button_anyadir = new System.Windows.Forms.Button();
            this.button_eliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_filtro = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verDetallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_remesas)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_remesas
            // 
            this.dataGridView_remesas.AllowUserToAddRows = false;
            this.dataGridView_remesas.AllowUserToDeleteRows = false;
            this.dataGridView_remesas.AllowUserToResizeRows = false;
            this.dataGridView_remesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_remesas.Location = new System.Drawing.Point(12, 87);
            this.dataGridView_remesas.MultiSelect = false;
            this.dataGridView_remesas.Name = "dataGridView_remesas";
            this.dataGridView_remesas.ReadOnly = true;
            this.dataGridView_remesas.RowHeadersVisible = false;
            this.dataGridView_remesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_remesas.Size = new System.Drawing.Size(1134, 517);
            this.dataGridView_remesas.TabIndex = 0;
            this.dataGridView_remesas.DoubleClick += new System.EventHandler(this.button_detalles_Click);
            this.dataGridView_remesas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_remesas_MouseClick);
            // 
            // button_anyadir
            // 
            this.button_anyadir.Location = new System.Drawing.Point(12, 54);
            this.button_anyadir.Name = "button_anyadir";
            this.button_anyadir.Size = new System.Drawing.Size(75, 23);
            this.button_anyadir.TabIndex = 2;
            this.button_anyadir.Text = "Añadir";
            this.button_anyadir.UseVisualStyleBackColor = true;
            this.button_anyadir.Click += new System.EventHandler(this.button_anyadir_Click);
            // 
            // button_eliminar
            // 
            this.button_eliminar.Location = new System.Drawing.Point(94, 54);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(75, 23);
            this.button_eliminar.TabIndex = 3;
            this.button_eliminar.Text = "Eliminar";
            this.button_eliminar.UseVisualStyleBackColor = true;
            this.button_eliminar.Click += new System.EventHandler(this.button_eliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1021, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtro : ";
            // 
            // comboBox_filtro
            // 
            this.comboBox_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filtro.FormattingEnabled = true;
            this.comboBox_filtro.Items.AddRange(new object[] {
            "5 Últimos",
            "10 Últimos",
            "20 Últimos",
            "Todos"});
            this.comboBox_filtro.Location = new System.Drawing.Point(1061, 60);
            this.comboBox_filtro.Name = "comboBox_filtro";
            this.comboBox_filtro.Size = new System.Drawing.Size(85, 21);
            this.comboBox_filtro.TabIndex = 5;
            this.comboBox_filtro.SelectionChangeCommitted += new System.EventHandler(this.comboBox_filtro_SelectionChangeCommitted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verDetallesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 26);
            // 
            // verDetallesToolStripMenuItem
            // 
            this.verDetallesToolStripMenuItem.Name = "verDetallesToolStripMenuItem";
            this.verDetallesToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.verDetallesToolStripMenuItem.Text = "Ver Detalles";
            this.verDetallesToolStripMenuItem.Click += new System.EventHandler(this.button_detalles_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // FormRemesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 612);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox_filtro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_eliminar);
            this.Controls.Add(this.button_anyadir);
            this.Controls.Add(this.dataGridView_remesas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRemesas";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remesas";
            this.Load += new System.EventHandler(this.FormRemesas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_remesas)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_remesas;
        private System.Windows.Forms.Button button_anyadir;
        private System.Windows.Forms.Button button_eliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_filtro;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verDetallesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}