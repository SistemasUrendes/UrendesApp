namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProvisionesForms
{
    partial class FormProvisionesDotarAplicar2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProvisionesDotarAplicar2));
            this.dataGridView_liquidaciones = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_importe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_acumulado = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_liquidaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_liquidaciones
            // 
            this.dataGridView_liquidaciones.AllowUserToOrderColumns = true;
            this.dataGridView_liquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_liquidaciones.Location = new System.Drawing.Point(15, 55);
            this.dataGridView_liquidaciones.Name = "dataGridView_liquidaciones";
            this.dataGridView_liquidaciones.Size = new System.Drawing.Size(385, 317);
            this.dataGridView_liquidaciones.TabIndex = 2;
            this.dataGridView_liquidaciones.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            this.dataGridView_liquidaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_importe
            // 
            this.textBox_importe.Location = new System.Drawing.Point(69, 17);
            this.textBox_importe.Name = "textBox_importe";
            this.textBox_importe.Size = new System.Drawing.Size(100, 20);
            this.textBox_importe.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Importe : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Importe Acumulado : ";
            // 
            // textBox_acumulado
            // 
            this.textBox_acumulado.Enabled = false;
            this.textBox_acumulado.Location = new System.Drawing.Point(299, 17);
            this.textBox_acumulado.Name = "textBox_acumulado";
            this.textBox_acumulado.ReadOnly = true;
            this.textBox_acumulado.Size = new System.Drawing.Size(100, 20);
            this.textBox_acumulado.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(244, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormProvisionesDotarAplicar2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 411);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_acumulado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_importe);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_liquidaciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProvisionesDotarAplicar2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProvisionesDotarAplicar";
            this.Load += new System.EventHandler(this.FormProvisionesDotarAplicar2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_liquidaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_liquidaciones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_importe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_acumulado;
        private System.Windows.Forms.Button button2;
    }
}