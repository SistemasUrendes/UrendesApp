namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    partial class FormReglasPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReglasPago));
            this.dataGridView_repartos = new System.Windows.Forms.DataGridView();
            this.button_anyadirReparto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_detalles_regla = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activarReglaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarReglaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarReglaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirDetalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarDetalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_repartos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detalles_regla)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_repartos
            // 
            this.dataGridView_repartos.AllowUserToAddRows = false;
            this.dataGridView_repartos.AllowUserToDeleteRows = false;
            this.dataGridView_repartos.AllowUserToResizeRows = false;
            this.dataGridView_repartos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_repartos.Location = new System.Drawing.Point(12, 44);
            this.dataGridView_repartos.MultiSelect = false;
            this.dataGridView_repartos.Name = "dataGridView_repartos";
            this.dataGridView_repartos.ReadOnly = true;
            this.dataGridView_repartos.RowHeadersVisible = false;
            this.dataGridView_repartos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_repartos.Size = new System.Drawing.Size(457, 150);
            this.dataGridView_repartos.TabIndex = 2;
            this.dataGridView_repartos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_repartos_MouseClick);
            // 
            // button_anyadirReparto
            // 
            this.button_anyadirReparto.Location = new System.Drawing.Point(393, 18);
            this.button_anyadirReparto.Name = "button_anyadirReparto";
            this.button_anyadirReparto.Size = new System.Drawing.Size(76, 23);
            this.button_anyadirReparto.TabIndex = 3;
            this.button_anyadirReparto.Text = "Añadir Regla";
            this.button_anyadirReparto.UseVisualStyleBackColor = true;
            this.button_anyadirReparto.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Reglas de Reparto :";
            // 
            // dataGridView_detalles_regla
            // 
            this.dataGridView_detalles_regla.AllowUserToAddRows = false;
            this.dataGridView_detalles_regla.AllowUserToDeleteRows = false;
            this.dataGridView_detalles_regla.AllowUserToResizeRows = false;
            this.dataGridView_detalles_regla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_detalles_regla.Location = new System.Drawing.Point(11, 229);
            this.dataGridView_detalles_regla.MultiSelect = false;
            this.dataGridView_detalles_regla.Name = "dataGridView_detalles_regla";
            this.dataGridView_detalles_regla.ReadOnly = true;
            this.dataGridView_detalles_regla.RowHeadersVisible = false;
            this.dataGridView_detalles_regla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_detalles_regla.Size = new System.Drawing.Size(458, 150);
            this.dataGridView_detalles_regla.TabIndex = 5;
            this.dataGridView_detalles_regla.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_detalles_regla_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Detalles de la Regla :";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activarReglaToolStripMenuItem,
            this.desactivarReglaToolStripMenuItem,
            this.eliminarReglaToolStripMenuItem,
            this.añadirDetalleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 92);
            // 
            // activarReglaToolStripMenuItem
            // 
            this.activarReglaToolStripMenuItem.Name = "activarReglaToolStripMenuItem";
            this.activarReglaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.activarReglaToolStripMenuItem.Text = "Activar Regla";
            this.activarReglaToolStripMenuItem.Visible = false;
            this.activarReglaToolStripMenuItem.Click += new System.EventHandler(this.activarReglaToolStripMenuItem_Click);
            // 
            // desactivarReglaToolStripMenuItem
            // 
            this.desactivarReglaToolStripMenuItem.Name = "desactivarReglaToolStripMenuItem";
            this.desactivarReglaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.desactivarReglaToolStripMenuItem.Text = "Desactivar Regla";
            this.desactivarReglaToolStripMenuItem.Visible = false;
            this.desactivarReglaToolStripMenuItem.Click += new System.EventHandler(this.desactivarReglaToolStripMenuItem_Click);
            // 
            // eliminarReglaToolStripMenuItem
            // 
            this.eliminarReglaToolStripMenuItem.Name = "eliminarReglaToolStripMenuItem";
            this.eliminarReglaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.eliminarReglaToolStripMenuItem.Text = "Eliminar Regla";
            this.eliminarReglaToolStripMenuItem.Click += new System.EventHandler(this.eliminarReglaToolStripMenuItem_Click);
            // 
            // añadirDetalleToolStripMenuItem
            // 
            this.añadirDetalleToolStripMenuItem.Name = "añadirDetalleToolStripMenuItem";
            this.añadirDetalleToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.añadirDetalleToolStripMenuItem.Text = "Añadir Detalle";
            this.añadirDetalleToolStripMenuItem.Click += new System.EventHandler(this.añadirDetalleToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.eliminarDetalleToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(157, 70);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarDetalleToolStripMenuItem
            // 
            this.eliminarDetalleToolStripMenuItem.Name = "eliminarDetalleToolStripMenuItem";
            this.eliminarDetalleToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.eliminarDetalleToolStripMenuItem.Text = "Eliminar Detalle";
            this.eliminarDetalleToolStripMenuItem.Click += new System.EventHandler(this.eliminarDetalleToolStripMenuItem_Click);
            // 
            // FormReglasPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 394);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView_detalles_regla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_anyadirReparto);
            this.Controls.Add(this.dataGridView_repartos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReglasPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reglas de pago";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormReglasPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_repartos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detalles_regla)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_repartos;
        private System.Windows.Forms.Button button_anyadirReparto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_detalles_regla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eliminarReglaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activarReglaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactivarReglaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirDetalleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarDetalleToolStripMenuItem;
    }
}