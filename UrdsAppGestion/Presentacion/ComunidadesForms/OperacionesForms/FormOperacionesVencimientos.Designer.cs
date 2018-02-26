namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormOperacionesVencimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperacionesVencimientos));
            this.dataGridView_vencimientos = new System.Windows.Forms.DataGridView();
            this.button_guardar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.entidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comuneroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_importe_actual = new System.Windows.Forms.TextBox();
            this.textBox_importe_op = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencimientos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_vencimientos
            // 
            this.dataGridView_vencimientos.AllowUserToOrderColumns = true;
            this.dataGridView_vencimientos.AllowUserToResizeRows = false;
            this.dataGridView_vencimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_vencimientos.Location = new System.Drawing.Point(12, 27);
            this.dataGridView_vencimientos.Name = "dataGridView_vencimientos";
            this.dataGridView_vencimientos.Size = new System.Drawing.Size(693, 150);
            this.dataGridView_vencimientos.TabIndex = 1;
            this.dataGridView_vencimientos.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_vencimientos_CellValidated);
            this.dataGridView_vencimientos.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_vencimientos_UserDeletedRow);
            this.dataGridView_vencimientos.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_vencimientos_UserDeletingRow);
            this.dataGridView_vencimientos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView_vencimientos_KeyPress);
            this.dataGridView_vencimientos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_vencimientos_MouseClick);
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(549, 221);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 2;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(630, 221);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 3;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entidadToolStripMenuItem,
            this.comuneroToolStripMenuItem,
            this.proveedorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 70);
            // 
            // entidadToolStripMenuItem
            // 
            this.entidadToolStripMenuItem.Name = "entidadToolStripMenuItem";
            this.entidadToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.entidadToolStripMenuItem.Text = "Entidad";
            this.entidadToolStripMenuItem.Click += new System.EventHandler(this.entidadToolStripMenuItem_Click);
            // 
            // comuneroToolStripMenuItem
            // 
            this.comuneroToolStripMenuItem.Name = "comuneroToolStripMenuItem";
            this.comuneroToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.comuneroToolStripMenuItem.Text = "Comunero";
            this.comuneroToolStripMenuItem.Click += new System.EventHandler(this.comuneroToolStripMenuItem_Click);
            // 
            // proveedorToolStripMenuItem
            // 
            this.proveedorToolStripMenuItem.Name = "proveedorToolStripMenuItem";
            this.proveedorToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.proveedorToolStripMenuItem.Text = "Proveedor";
            this.proveedorToolStripMenuItem.Click += new System.EventHandler(this.proveedorToolStripMenuItem_Click);
            // 
            // textBox_importe_actual
            // 
            this.textBox_importe_actual.Location = new System.Drawing.Point(108, 218);
            this.textBox_importe_actual.Name = "textBox_importe_actual";
            this.textBox_importe_actual.ReadOnly = true;
            this.textBox_importe_actual.Size = new System.Drawing.Size(64, 20);
            this.textBox_importe_actual.TabIndex = 18;
            this.textBox_importe_actual.TabStop = false;
            // 
            // textBox_importe_op
            // 
            this.textBox_importe_op.Location = new System.Drawing.Point(108, 197);
            this.textBox_importe_op.Name = "textBox_importe_op";
            this.textBox_importe_op.ReadOnly = true;
            this.textBox_importe_op.Size = new System.Drawing.Size(64, 20);
            this.textBox_importe_op.TabIndex = 17;
            this.textBox_importe_op.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Importe Actual:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Importe Op:";
            // 
            // FormOperacionesVencimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 258);
            this.Controls.Add(this.textBox_importe_actual);
            this.Controls.Add(this.textBox_importe_op);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.dataGridView_vencimientos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOperacionesVencimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vencimientos";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOperacionesVencimientos_FormClosing);
            this.Load += new System.EventHandler(this.FormOperacionesVencimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencimientos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_vencimientos;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem entidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comuneroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_importe_actual;
        private System.Windows.Forms.TextBox textBox_importe_op;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}