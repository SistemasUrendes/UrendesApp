namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    partial class FormCertificadoDeudasDivision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCertificadoDeudasDivision));
            this.textBox_representante = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_division = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_tipo = new System.Windows.Forms.TextBox();
            this.dataGridView_dedudasCertificado = new System.Windows.Forms.DataGridView();
            this.button_verCertificados = new System.Windows.Forms.Button();
            this.button_nuevoCertificados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dedudasCertificado)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_representante
            // 
            this.textBox_representante.Location = new System.Drawing.Point(123, 28);
            this.textBox_representante.Name = "textBox_representante";
            this.textBox_representante.ReadOnly = true;
            this.textBox_representante.Size = new System.Drawing.Size(264, 20);
            this.textBox_representante.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Representante: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "División: ";
            // 
            // textBox_division
            // 
            this.textBox_division.Location = new System.Drawing.Point(123, 57);
            this.textBox_division.Name = "textBox_division";
            this.textBox_division.ReadOnly = true;
            this.textBox_division.Size = new System.Drawing.Size(100, 20);
            this.textBox_division.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo : ";
            // 
            // textBox_tipo
            // 
            this.textBox_tipo.Location = new System.Drawing.Point(123, 86);
            this.textBox_tipo.Name = "textBox_tipo";
            this.textBox_tipo.ReadOnly = true;
            this.textBox_tipo.Size = new System.Drawing.Size(100, 20);
            this.textBox_tipo.TabIndex = 5;
            // 
            // dataGridView_dedudasCertificado
            // 
            this.dataGridView_dedudasCertificado.AllowUserToAddRows = false;
            this.dataGridView_dedudasCertificado.AllowUserToDeleteRows = false;
            this.dataGridView_dedudasCertificado.AllowUserToResizeRows = false;
            this.dataGridView_dedudasCertificado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dedudasCertificado.Location = new System.Drawing.Point(12, 128);
            this.dataGridView_dedudasCertificado.MultiSelect = false;
            this.dataGridView_dedudasCertificado.Name = "dataGridView_dedudasCertificado";
            this.dataGridView_dedudasCertificado.ReadOnly = true;
            this.dataGridView_dedudasCertificado.RowHeadersVisible = false;
            this.dataGridView_dedudasCertificado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_dedudasCertificado.Size = new System.Drawing.Size(1005, 353);
            this.dataGridView_dedudasCertificado.TabIndex = 6;
            // 
            // button_verCertificados
            // 
            this.button_verCertificados.Enabled = false;
            this.button_verCertificados.Location = new System.Drawing.Point(894, 50);
            this.button_verCertificados.Name = "button_verCertificados";
            this.button_verCertificados.Size = new System.Drawing.Size(102, 56);
            this.button_verCertificados.TabIndex = 7;
            this.button_verCertificados.Text = "Ver Certificados";
            this.button_verCertificados.UseVisualStyleBackColor = true;
            // 
            // button_nuevoCertificados
            // 
            this.button_nuevoCertificados.Location = new System.Drawing.Point(777, 50);
            this.button_nuevoCertificados.Name = "button_nuevoCertificados";
            this.button_nuevoCertificados.Size = new System.Drawing.Size(102, 56);
            this.button_nuevoCertificados.TabIndex = 8;
            this.button_nuevoCertificados.TabStop = false;
            this.button_nuevoCertificados.Text = "Nuevo Certificados";
            this.button_nuevoCertificados.UseVisualStyleBackColor = true;
            this.button_nuevoCertificados.Click += new System.EventHandler(this.button_nuevoCertificados_Click);
            // 
            // FormCertificadoDeudasDivision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 493);
            this.Controls.Add(this.button_nuevoCertificados);
            this.Controls.Add(this.button_verCertificados);
            this.Controls.Add(this.dataGridView_dedudasCertificado);
            this.Controls.Add(this.textBox_tipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_division);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_representante);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCertificadoDeudasDivision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deudas Division";
            this.Load += new System.EventHandler(this.FormCertificadoDeudasDivision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dedudasCertificado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_representante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_division;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_tipo;
        private System.Windows.Forms.DataGridView dataGridView_dedudasCertificado;
        private System.Windows.Forms.Button button_verCertificados;
        private System.Windows.Forms.Button button_nuevoCertificados;
    }
}