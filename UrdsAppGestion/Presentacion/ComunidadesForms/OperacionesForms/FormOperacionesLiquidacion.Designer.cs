namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormOperacionesLiquidacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperacionesLiquidacion));
            this.dataGridView_liquidacion = new System.Windows.Forms.DataGridView();
            this.button_guardar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_importe_actual = new System.Windows.Forms.TextBox();
            this.textBox_importe_op = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_liquidacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_liquidacion
            // 
            this.dataGridView_liquidacion.AllowUserToOrderColumns = true;
            this.dataGridView_liquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_liquidacion.Location = new System.Drawing.Point(12, 22);
            this.dataGridView_liquidacion.Name = "dataGridView_liquidacion";
            this.dataGridView_liquidacion.Size = new System.Drawing.Size(330, 150);
            this.dataGridView_liquidacion.TabIndex = 0;
            this.dataGridView_liquidacion.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_liquidacion_CellValidated);
            this.dataGridView_liquidacion.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_liquidacion_UserDeletingRow);
            this.dataGridView_liquidacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView_liquidacion_KeyPress);
            this.dataGridView_liquidacion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_liquidacion_MouseDoubleClick);
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(187, 190);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 2;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_importe_actual
            // 
            this.textBox_importe_actual.Location = new System.Drawing.Point(104, 203);
            this.textBox_importe_actual.Name = "textBox_importe_actual";
            this.textBox_importe_actual.ReadOnly = true;
            this.textBox_importe_actual.Size = new System.Drawing.Size(64, 20);
            this.textBox_importe_actual.TabIndex = 14;
            this.textBox_importe_actual.TabStop = false;
            // 
            // textBox_importe_op
            // 
            this.textBox_importe_op.Location = new System.Drawing.Point(104, 182);
            this.textBox_importe_op.Name = "textBox_importe_op";
            this.textBox_importe_op.ReadOnly = true;
            this.textBox_importe_op.Size = new System.Drawing.Size(64, 20);
            this.textBox_importe_op.TabIndex = 13;
            this.textBox_importe_op.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Importe Actual:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Importe Op:";
            // 
            // FormOperacionesLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 234);
            this.Controls.Add(this.textBox_importe_actual);
            this.Controls.Add(this.textBox_importe_op);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.dataGridView_liquidacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOperacionesLiquidacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidacion";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOperacionesLiquidacion_FormClosing);
            this.Load += new System.EventHandler(this.FormOperacionesLiquidacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_liquidacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_liquidacion;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_importe_actual;
        private System.Windows.Forms.TextBox textBox_importe_op;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}