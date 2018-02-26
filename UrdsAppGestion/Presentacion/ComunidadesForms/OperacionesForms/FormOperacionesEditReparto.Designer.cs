namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormOperacionesEditReparto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperacionesEditReparto));
            this.dataGridView_reparto = new System.Windows.Forms.DataGridView();
            this.button_guardar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.textBox_importe_actual = new System.Windows.Forms.TextBox();
            this.textBox_importe_op = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reparto)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_reparto
            // 
            this.dataGridView_reparto.AllowUserToOrderColumns = true;
            this.dataGridView_reparto.AllowUserToResizeRows = false;
            this.dataGridView_reparto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_reparto.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_reparto.Name = "dataGridView_reparto";
            this.dataGridView_reparto.Size = new System.Drawing.Size(390, 159);
            this.dataGridView_reparto.TabIndex = 1;
            this.dataGridView_reparto.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_reparto_CellValidated);
            this.dataGridView_reparto.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_reparto_UserDeletingRow);
            this.dataGridView_reparto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView_reparto_KeyPress);
            this.dataGridView_reparto.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_reparto_MouseDoubleClick);
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(246, 208);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 2;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(327, 208);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 3;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // textBox_importe_actual
            // 
            this.textBox_importe_actual.Location = new System.Drawing.Point(92, 201);
            this.textBox_importe_actual.Name = "textBox_importe_actual";
            this.textBox_importe_actual.ReadOnly = true;
            this.textBox_importe_actual.Size = new System.Drawing.Size(64, 20);
            this.textBox_importe_actual.TabIndex = 10;
            this.textBox_importe_actual.TabStop = false;
            // 
            // textBox_importe_op
            // 
            this.textBox_importe_op.Location = new System.Drawing.Point(92, 180);
            this.textBox_importe_op.Name = "textBox_importe_op";
            this.textBox_importe_op.ReadOnly = true;
            this.textBox_importe_op.Size = new System.Drawing.Size(64, 20);
            this.textBox_importe_op.TabIndex = 9;
            this.textBox_importe_op.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Importe Actual:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Importe Op:";
            // 
            // FormOperacionesEditReparto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 243);
            this.Controls.Add(this.textBox_importe_actual);
            this.Controls.Add(this.textBox_importe_op);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.dataGridView_reparto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOperacionesEditReparto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reparto";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOperacionesEditReparto_FormClosing);
            this.Load += new System.EventHandler(this.FormOperacionesEditReparto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reparto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_reparto;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.TextBox textBox_importe_actual;
        private System.Windows.Forms.TextBox textBox_importe_op;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}