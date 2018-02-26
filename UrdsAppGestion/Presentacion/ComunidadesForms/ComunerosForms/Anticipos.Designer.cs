namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    partial class Anticipos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anticipos));
            this.dataGridView_anticipos = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.maskedTextBox_fin = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox_inicio = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_anticipos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_anticipos
            // 
            this.dataGridView_anticipos.AllowUserToAddRows = false;
            this.dataGridView_anticipos.AllowUserToDeleteRows = false;
            this.dataGridView_anticipos.AllowUserToResizeRows = false;
            this.dataGridView_anticipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_anticipos.Location = new System.Drawing.Point(12, 63);
            this.dataGridView_anticipos.Name = "dataGridView_anticipos";
            this.dataGridView_anticipos.ReadOnly = true;
            this.dataGridView_anticipos.RowHeadersVisible = false;
            this.dataGridView_anticipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_anticipos.Size = new System.Drawing.Size(1185, 509);
            this.dataGridView_anticipos.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(290, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Consultar filtro";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Anticipos_Load);
            // 
            // maskedTextBox_fin
            // 
            this.maskedTextBox_fin.Location = new System.Drawing.Point(213, 12);
            this.maskedTextBox_fin.Mask = "00/00/0000";
            this.maskedTextBox_fin.Name = "maskedTextBox_fin";
            this.maskedTextBox_fin.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_fin.TabIndex = 18;
            this.maskedTextBox_fin.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Fecha desde:";
            // 
            // maskedTextBox_inicio
            // 
            this.maskedTextBox_inicio.Location = new System.Drawing.Point(94, 12);
            this.maskedTextBox_inicio.Mask = "00/00/0000";
            this.maskedTextBox_inicio.Name = "maskedTextBox_inicio";
            this.maskedTextBox_inicio.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_inicio.TabIndex = 15;
            this.maskedTextBox_inicio.ValidatingType = typeof(System.DateTime);
            // 
            // Anticipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 584);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.maskedTextBox_fin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox_inicio);
            this.Controls.Add(this.dataGridView_anticipos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Anticipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anticipos";
            this.Load += new System.EventHandler(this.Anticipos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_anticipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_anticipos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_fin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_inicio;
    }
}