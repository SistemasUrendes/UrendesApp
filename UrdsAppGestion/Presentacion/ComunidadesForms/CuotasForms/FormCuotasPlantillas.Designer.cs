namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms
{
    partial class FormCuotasPlantillas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCuotasPlantillas));
            this.dataGridView_plantillas = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox_TipodeCuota = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarPlantillaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_plantillas)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_plantillas
            // 
            this.dataGridView_plantillas.AllowUserToAddRows = false;
            this.dataGridView_plantillas.AllowUserToDeleteRows = false;
            this.dataGridView_plantillas.AllowUserToOrderColumns = true;
            this.dataGridView_plantillas.AllowUserToResizeRows = false;
            this.dataGridView_plantillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_plantillas.Location = new System.Drawing.Point(23, 54);
            this.dataGridView_plantillas.Name = "dataGridView_plantillas";
            this.dataGridView_plantillas.ReadOnly = true;
            this.dataGridView_plantillas.RowHeadersVisible = false;
            this.dataGridView_plantillas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_plantillas.Size = new System.Drawing.Size(488, 351);
            this.dataGridView_plantillas.TabIndex = 0;
            this.dataGridView_plantillas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_plantillas_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Añadir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(104, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Editar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(185, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Borrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox_TipodeCuota
            // 
            this.comboBox_TipodeCuota.Enabled = false;
            this.comboBox_TipodeCuota.FormattingEnabled = true;
            this.comboBox_TipodeCuota.Items.AddRange(new object[] {
            "Manuales",
            "Presupuesto",
            "Tipo División",
            "Todos"});
            this.comboBox_TipodeCuota.Location = new System.Drawing.Point(390, 27);
            this.comboBox_TipodeCuota.Name = "comboBox_TipodeCuota";
            this.comboBox_TipodeCuota.Size = new System.Drawing.Size(121, 21);
            this.comboBox_TipodeCuota.TabIndex = 4;
            this.comboBox_TipodeCuota.SelectionChangeCommitted += new System.EventHandler(this.comboBox_TipodeCuota_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filtro:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarPlantillaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 26);
            // 
            // editarPlantillaToolStripMenuItem
            // 
            this.editarPlantillaToolStripMenuItem.Name = "editarPlantillaToolStripMenuItem";
            this.editarPlantillaToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.editarPlantillaToolStripMenuItem.Text = "Editar Plantilla";
            this.editarPlantillaToolStripMenuItem.Click += new System.EventHandler(this.editarPlantillaToolStripMenuItem_Click);
            // 
            // FormCuotasPlantillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 430);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_TipodeCuota);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_plantillas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCuotasPlantillas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plantillas Cuotas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCuotasPlantillas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_plantillas)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_plantillas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox_TipodeCuota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarPlantillaToolStripMenuItem;
    }
}