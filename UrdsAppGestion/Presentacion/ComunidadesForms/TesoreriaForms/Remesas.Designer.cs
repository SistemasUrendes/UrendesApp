namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    partial class Remesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remesas));
            this.dataGridView_remesas = new System.Windows.Forms.DataGridView();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_comunidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_cuenta = new System.Windows.Forms.TextBox();
            this.textBox_tipo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox_fecha_apunte = new System.Windows.Forms.MaskedTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_progress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_remesas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_remesas
            // 
            this.dataGridView_remesas.AllowUserToAddRows = false;
            this.dataGridView_remesas.AllowUserToDeleteRows = false;
            this.dataGridView_remesas.AllowUserToResizeRows = false;
            this.dataGridView_remesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_remesas.Location = new System.Drawing.Point(12, 135);
            this.dataGridView_remesas.MultiSelect = false;
            this.dataGridView_remesas.Name = "dataGridView_remesas";
            this.dataGridView_remesas.ReadOnly = true;
            this.dataGridView_remesas.RowHeadersVisible = false;
            this.dataGridView_remesas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_remesas.Size = new System.Drawing.Size(533, 177);
            this.dataGridView_remesas.TabIndex = 2;
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(388, 318);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(76, 40);
            this.button_aceptar.TabIndex = 1;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(470, 318);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 40);
            this.button_cancelar.TabIndex = 2;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Remesas Pendientes :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Comunidad : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cuenta : ";
            // 
            // textBox_comunidad
            // 
            this.textBox_comunidad.Location = new System.Drawing.Point(87, 18);
            this.textBox_comunidad.Name = "textBox_comunidad";
            this.textBox_comunidad.ReadOnly = true;
            this.textBox_comunidad.Size = new System.Drawing.Size(363, 20);
            this.textBox_comunidad.TabIndex = 6;
            this.textBox_comunidad.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo : ";
            // 
            // textBox_cuenta
            // 
            this.textBox_cuenta.Location = new System.Drawing.Point(87, 47);
            this.textBox_cuenta.Name = "textBox_cuenta";
            this.textBox_cuenta.ReadOnly = true;
            this.textBox_cuenta.Size = new System.Drawing.Size(363, 20);
            this.textBox_cuenta.TabIndex = 8;
            this.textBox_cuenta.TabStop = false;
            // 
            // textBox_tipo
            // 
            this.textBox_tipo.Location = new System.Drawing.Point(87, 76);
            this.textBox_tipo.Name = "textBox_tipo";
            this.textBox_tipo.ReadOnly = true;
            this.textBox_tipo.Size = new System.Drawing.Size(116, 20);
            this.textBox_tipo.TabIndex = 9;
            this.textBox_tipo.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha Apunte : ";
            // 
            // maskedTextBox_fecha_apunte
            // 
            this.maskedTextBox_fecha_apunte.Location = new System.Drawing.Point(296, 329);
            this.maskedTextBox_fecha_apunte.Mask = "00/00/0000";
            this.maskedTextBox_fecha_apunte.Name = "maskedTextBox_fecha_apunte";
            this.maskedTextBox_fecha_apunte.Size = new System.Drawing.Size(69, 20);
            this.maskedTextBox_fecha_apunte.TabIndex = 1;
            this.maskedTextBox_fecha_apunte.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_fecha_apunte.Leave += new System.EventHandler(this.maskedTextBox_fecha_apunte_Leave);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(185, 326);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(180, 23);
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Location = new System.Drawing.Point(218, 331);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(102, 13);
            this.label_progress.TabIndex = 12;
            this.label_progress.Text = "Ingresando Remesa";
            this.label_progress.Visible = false;
            // 
            // Remesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 374);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.maskedTextBox_fecha_apunte);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_tipo);
            this.Controls.Add(this.textBox_cuenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_comunidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.dataGridView_remesas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Remesas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remesas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Remesas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_remesas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_remesas;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_comunidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_cuenta;
        private System.Windows.Forms.TextBox textBox_tipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_fecha_apunte;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_progress;
    }
}