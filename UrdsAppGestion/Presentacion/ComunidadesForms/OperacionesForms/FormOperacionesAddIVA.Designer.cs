namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    partial class FormOperacionesAddIVA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperacionesAddIVA));
            this.button_guardar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.dataGridView_add_iva = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_importe_op = new System.Windows.Forms.TextBox();
            this.textBox_importe_actual = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_add_iva)).BeginInit();
            this.SuspendLayout();
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(205, 230);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(66, 23);
            this.button_guardar.TabIndex = 2;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(273, 230);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(66, 23);
            this.button_cancelar.TabIndex = 3;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // dataGridView_add_iva
            // 
            this.dataGridView_add_iva.AllowUserToOrderColumns = true;
            this.dataGridView_add_iva.AllowUserToResizeRows = false;
            this.dataGridView_add_iva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_add_iva.Location = new System.Drawing.Point(12, 13);
            this.dataGridView_add_iva.MultiSelect = false;
            this.dataGridView_add_iva.Name = "dataGridView_add_iva";
            this.dataGridView_add_iva.RowHeadersVisible = false;
            this.dataGridView_add_iva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_add_iva.Size = new System.Drawing.Size(329, 187);
            this.dataGridView_add_iva.TabIndex = 1;
            this.dataGridView_add_iva.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_add_iva_CellContentClick);
            this.dataGridView_add_iva.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_add_iva_CellValueChanged);
            this.dataGridView_add_iva.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_add_iva_EditingControlShowing);
            this.dataGridView_add_iva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView_add_iva_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Importe Op:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Importe Actual:";
            // 
            // textBox_importe_op
            // 
            this.textBox_importe_op.Location = new System.Drawing.Point(101, 216);
            this.textBox_importe_op.Name = "textBox_importe_op";
            this.textBox_importe_op.ReadOnly = true;
            this.textBox_importe_op.Size = new System.Drawing.Size(64, 20);
            this.textBox_importe_op.TabIndex = 5;
            this.textBox_importe_op.TabStop = false;
            // 
            // textBox_importe_actual
            // 
            this.textBox_importe_actual.Location = new System.Drawing.Point(101, 237);
            this.textBox_importe_actual.Name = "textBox_importe_actual";
            this.textBox_importe_actual.ReadOnly = true;
            this.textBox_importe_actual.Size = new System.Drawing.Size(64, 20);
            this.textBox_importe_actual.TabIndex = 6;
            this.textBox_importe_actual.TabStop = false;
            // 
            // FormOperacionesAddIVA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 275);
            this.Controls.Add(this.textBox_importe_actual);
            this.Controls.Add(this.textBox_importe_op);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_add_iva);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_guardar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOperacionesAddIVA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IVA";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOperacionesAddIVA_FormClosing);
            this.Load += new System.EventHandler(this.FormOperacionesAddIVA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_add_iva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.DataGridView dataGridView_add_iva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_importe_op;
        private System.Windows.Forms.TextBox textBox_importe_actual;
    }
}