namespace UrdsAppGestión.Presentacion.ComunidadesForms.Recibos
{
    partial class FormNuevoRecibo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevoRecibo));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_pagador = new System.Windows.Forms.TextBox();
            this.textBox_fecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_cuenta = new System.Windows.Forms.ComboBox();
            this.textBox_cc = new System.Windows.Forms.TextBox();
            this.textBox_referencias = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView_vencimientos = new System.Windows.Forms.DataGridView();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pagador : ";
            // 
            // textBox_pagador
            // 
            this.textBox_pagador.Location = new System.Drawing.Point(91, 28);
            this.textBox_pagador.Name = "textBox_pagador";
            this.textBox_pagador.ReadOnly = true;
            this.textBox_pagador.Size = new System.Drawing.Size(284, 20);
            this.textBox_pagador.TabIndex = 1;
            this.textBox_pagador.Text = "Pulsa espacio para Buscar";
            this.textBox_pagador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_pagador_KeyPress);
            // 
            // textBox_fecha
            // 
            this.textBox_fecha.Location = new System.Drawing.Point(91, 62);
            this.textBox_fecha.Name = "textBox_fecha";
            this.textBox_fecha.ReadOnly = true;
            this.textBox_fecha.Size = new System.Drawing.Size(100, 20);
            this.textBox_fecha.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Domiciliación : ";
            // 
            // comboBox_cuenta
            // 
            this.comboBox_cuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cuenta.FormattingEnabled = true;
            this.comboBox_cuenta.Location = new System.Drawing.Point(91, 93);
            this.comboBox_cuenta.Name = "comboBox_cuenta";
            this.comboBox_cuenta.Size = new System.Drawing.Size(100, 21);
            this.comboBox_cuenta.TabIndex = 6;
            this.comboBox_cuenta.SelectionChangeCommitted += new System.EventHandler(this.comboBox_cuenta_SelectionChangeCommitted);
            // 
            // textBox_cc
            // 
            this.textBox_cc.Location = new System.Drawing.Point(197, 93);
            this.textBox_cc.Name = "textBox_cc";
            this.textBox_cc.ReadOnly = true;
            this.textBox_cc.Size = new System.Drawing.Size(178, 20);
            this.textBox_cc.TabIndex = 7;
            // 
            // textBox_referencias
            // 
            this.textBox_referencias.Location = new System.Drawing.Point(91, 130);
            this.textBox_referencias.Name = "textBox_referencias";
            this.textBox_referencias.Size = new System.Drawing.Size(284, 20);
            this.textBox_referencias.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Referencia : ";
            // 
            // dataGridView_vencimientos
            // 
            this.dataGridView_vencimientos.AllowUserToAddRows = false;
            this.dataGridView_vencimientos.AllowUserToDeleteRows = false;
            this.dataGridView_vencimientos.AllowUserToOrderColumns = true;
            this.dataGridView_vencimientos.AllowUserToResizeRows = false;
            this.dataGridView_vencimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_vencimientos.Location = new System.Drawing.Point(15, 181);
            this.dataGridView_vencimientos.Name = "dataGridView_vencimientos";
            this.dataGridView_vencimientos.ReadOnly = true;
            this.dataGridView_vencimientos.RowHeadersVisible = false;
            this.dataGridView_vencimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_vencimientos.Size = new System.Drawing.Size(360, 150);
            this.dataGridView_vencimientos.TabIndex = 10;
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(219, 349);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(75, 23);
            this.button_aceptar.TabIndex = 11;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(300, 349);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 12;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // FormNuevoRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 387);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.dataGridView_vencimientos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_referencias);
            this.Controls.Add(this.textBox_cc);
            this.Controls.Add(this.comboBox_cuenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_fecha);
            this.Controls.Add(this.textBox_pagador);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNuevoRecibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Recibo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormNuevoRecibo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vencimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_pagador;
        private System.Windows.Forms.TextBox textBox_fecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_cuenta;
        private System.Windows.Forms.TextBox textBox_cc;
        private System.Windows.Forms.TextBox textBox_referencias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView_vencimientos;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_cancelar;
    }
}