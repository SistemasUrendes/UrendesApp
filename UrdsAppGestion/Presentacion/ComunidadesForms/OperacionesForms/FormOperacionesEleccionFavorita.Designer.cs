namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormOperacionesEleccionFavorita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperacionesEleccionFavorita));
            this.listBox_bloques = new System.Windows.Forms.ListBox();
            this.dataGridView_favoritas = new System.Windows.Forms.DataGridView();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_favoritas)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_bloques
            // 
            this.listBox_bloques.FormattingEnabled = true;
            this.listBox_bloques.Location = new System.Drawing.Point(29, 48);
            this.listBox_bloques.Name = "listBox_bloques";
            this.listBox_bloques.Size = new System.Drawing.Size(261, 303);
            this.listBox_bloques.TabIndex = 2;
            this.listBox_bloques.SelectedIndexChanged += new System.EventHandler(this.listBox_bloques_SelectedIndexChanged);
            this.listBox_bloques.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_bloques_KeyDown);
            // 
            // dataGridView_favoritas
            // 
            this.dataGridView_favoritas.AllowUserToAddRows = false;
            this.dataGridView_favoritas.AllowUserToDeleteRows = false;
            this.dataGridView_favoritas.AllowUserToOrderColumns = true;
            this.dataGridView_favoritas.AllowUserToResizeRows = false;
            this.dataGridView_favoritas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_favoritas.Location = new System.Drawing.Point(303, 48);
            this.dataGridView_favoritas.MultiSelect = false;
            this.dataGridView_favoritas.Name = "dataGridView_favoritas";
            this.dataGridView_favoritas.ReadOnly = true;
            this.dataGridView_favoritas.RowHeadersVisible = false;
            this.dataGridView_favoritas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_favoritas.Size = new System.Drawing.Size(511, 300);
            this.dataGridView_favoritas.TabIndex = 3;
            this.dataGridView_favoritas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_favoritas_KeyDown);
            this.dataGridView_favoritas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_favoritas_MouseClick);
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(82, 22);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(208, 20);
            this.textBox_buscar.TabIndex = 0;
            this.textBox_buscar.TextChanged += new System.EventHandler(this.textBox_buscar_TextChanged);
            this.textBox_buscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_buscar_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(739, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(658, 354);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Siguiente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 26);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Buscar :";
            // 
            // FormOperacionesEleccionFavorita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 389);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.dataGridView_favoritas);
            this.Controls.Add(this.listBox_bloques);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOperacionesEleccionFavorita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Favoritas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormOperacionesEleccionFavorita_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormOperacionesEleccionFavorita_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_favoritas)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_bloques;
        private System.Windows.Forms.DataGridView dataGridView_favoritas;
        private System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}