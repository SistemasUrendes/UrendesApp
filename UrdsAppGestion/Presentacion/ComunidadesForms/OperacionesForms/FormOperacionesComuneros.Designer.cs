namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormOperacionesComuneros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperacionesComuneros));
            this.dataGridView_operacionesComuneros = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_estado = new System.Windows.Forms.ComboBox();
            this.maskedTextBox_fin = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBox_inicio = new System.Windows.Forms.MaskedTextBox();
            this.button_filtrar = new System.Windows.Forms.Button();
            this.button_compensar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reasignarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_operacionesComuneros)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_operacionesComuneros
            // 
            this.dataGridView_operacionesComuneros.AllowUserToAddRows = false;
            this.dataGridView_operacionesComuneros.AllowUserToDeleteRows = false;
            this.dataGridView_operacionesComuneros.AllowUserToResizeRows = false;
            this.dataGridView_operacionesComuneros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_operacionesComuneros.Location = new System.Drawing.Point(12, 92);
            this.dataGridView_operacionesComuneros.MultiSelect = false;
            this.dataGridView_operacionesComuneros.Name = "dataGridView_operacionesComuneros";
            this.dataGridView_operacionesComuneros.ReadOnly = true;
            this.dataGridView_operacionesComuneros.RowHeadersVisible = false;
            this.dataGridView_operacionesComuneros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_operacionesComuneros.Size = new System.Drawing.Size(920, 436);
            this.dataGridView_operacionesComuneros.TabIndex = 0;
            this.dataGridView_operacionesComuneros.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_operacionesComuneros_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estado : ";
            // 
            // comboBox_estado
            // 
            this.comboBox_estado.FormattingEnabled = true;
            this.comboBox_estado.Items.AddRange(new object[] {
            "Pendiente",
            "Cerrado",
            "Todo"});
            this.comboBox_estado.Location = new System.Drawing.Point(89, 49);
            this.comboBox_estado.Name = "comboBox_estado";
            this.comboBox_estado.Size = new System.Drawing.Size(92, 21);
            this.comboBox_estado.TabIndex = 2;
            this.comboBox_estado.SelectionChangeCommitted += new System.EventHandler(this.comboBox_estado_SelectionChangeCommitted);
            // 
            // maskedTextBox_fin
            // 
            this.maskedTextBox_fin.Location = new System.Drawing.Point(208, 17);
            this.maskedTextBox_fin.Mask = "00/00/0000";
            this.maskedTextBox_fin.Name = "maskedTextBox_fin";
            this.maskedTextBox_fin.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_fin.TabIndex = 18;
            this.maskedTextBox_fin.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Fecha desde:";
            // 
            // maskedTextBox_inicio
            // 
            this.maskedTextBox_inicio.Location = new System.Drawing.Point(89, 17);
            this.maskedTextBox_inicio.Mask = "00/00/0000";
            this.maskedTextBox_inicio.Name = "maskedTextBox_inicio";
            this.maskedTextBox_inicio.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_inicio.TabIndex = 15;
            this.maskedTextBox_inicio.ValidatingType = typeof(System.DateTime);
            // 
            // button_filtrar
            // 
            this.button_filtrar.Location = new System.Drawing.Point(204, 49);
            this.button_filtrar.Name = "button_filtrar";
            this.button_filtrar.Size = new System.Drawing.Size(75, 23);
            this.button_filtrar.TabIndex = 19;
            this.button_filtrar.Text = "Filtrar";
            this.button_filtrar.UseVisualStyleBackColor = true;
            this.button_filtrar.Click += new System.EventHandler(this.button_filtrar_Click);
            // 
            // button_compensar
            // 
            this.button_compensar.Location = new System.Drawing.Point(824, 63);
            this.button_compensar.Name = "button_compensar";
            this.button_compensar.Size = new System.Drawing.Size(108, 23);
            this.button_compensar.TabIndex = 20;
            this.button_compensar.Text = "Compensar";
            this.button_compensar.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reasignarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 26);
            // 
            // reasignarToolStripMenuItem
            // 
            this.reasignarToolStripMenuItem.Name = "reasignarToolStripMenuItem";
            this.reasignarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.reasignarToolStripMenuItem.Text = "Reasignar";
            // 
            // FormOperacionesComuneros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 540);
            this.Controls.Add(this.button_compensar);
            this.Controls.Add(this.button_filtrar);
            this.Controls.Add(this.maskedTextBox_fin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskedTextBox_inicio);
            this.Controls.Add(this.comboBox_estado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_operacionesComuneros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOperacionesComuneros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operaciones Comuneros";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormOperacionesComuneros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_operacionesComuneros)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_operacionesComuneros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_estado;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_fin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_inicio;
        private System.Windows.Forms.Button button_filtrar;
        private System.Windows.Forms.Button button_compensar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reasignarToolStripMenuItem;
    }
}