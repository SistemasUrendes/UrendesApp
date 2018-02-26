namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    partial class FormComuneroReglasDivision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComuneroReglasDivision));
            this.dataGridView_ListaReglasActivas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button_AsignarRegla = new System.Windows.Forms.Button();
            this.button_SinRegla = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.textBox_Division = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Regla = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListaReglasActivas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_ListaReglasActivas
            // 
            this.dataGridView_ListaReglasActivas.AllowUserToAddRows = false;
            this.dataGridView_ListaReglasActivas.AllowUserToDeleteRows = false;
            this.dataGridView_ListaReglasActivas.AllowUserToOrderColumns = true;
            this.dataGridView_ListaReglasActivas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ListaReglasActivas.Location = new System.Drawing.Point(25, 83);
            this.dataGridView_ListaReglasActivas.MultiSelect = false;
            this.dataGridView_ListaReglasActivas.Name = "dataGridView_ListaReglasActivas";
            this.dataGridView_ListaReglasActivas.ReadOnly = true;
            this.dataGridView_ListaReglasActivas.RowHeadersVisible = false;
            this.dataGridView_ListaReglasActivas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ListaReglasActivas.Size = new System.Drawing.Size(406, 150);
            this.dataGridView_ListaReglasActivas.TabIndex = 0;
            this.dataGridView_ListaReglasActivas.Click += new System.EventHandler(this.dataGridView_ListaReglasActivas_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Reglas Activas:";
            // 
            // button_AsignarRegla
            // 
            this.button_AsignarRegla.Location = new System.Drawing.Point(185, 254);
            this.button_AsignarRegla.Name = "button_AsignarRegla";
            this.button_AsignarRegla.Size = new System.Drawing.Size(94, 23);
            this.button_AsignarRegla.TabIndex = 2;
            this.button_AsignarRegla.Text = "Asignar Regla";
            this.button_AsignarRegla.UseVisualStyleBackColor = true;
            this.button_AsignarRegla.Click += new System.EventHandler(this.button_AsignarRegla_Click);
            // 
            // button_SinRegla
            // 
            this.button_SinRegla.Location = new System.Drawing.Point(285, 254);
            this.button_SinRegla.Name = "button_SinRegla";
            this.button_SinRegla.Size = new System.Drawing.Size(75, 23);
            this.button_SinRegla.TabIndex = 3;
            this.button_SinRegla.Text = "Sin Reglas";
            this.button_SinRegla.UseVisualStyleBackColor = true;
            this.button_SinRegla.Click += new System.EventHandler(this.button_SinRegla_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(366, 254);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 4;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // textBox_Division
            // 
            this.textBox_Division.Enabled = false;
            this.textBox_Division.Location = new System.Drawing.Point(78, 26);
            this.textBox_Division.Name = "textBox_Division";
            this.textBox_Division.Size = new System.Drawing.Size(148, 20);
            this.textBox_Division.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "División:";
            // 
            // textBox_Regla
            // 
            this.textBox_Regla.Enabled = false;
            this.textBox_Regla.Location = new System.Drawing.Point(336, 26);
            this.textBox_Regla.Name = "textBox_Regla";
            this.textBox_Regla.Size = new System.Drawing.Size(95, 20);
            this.textBox_Regla.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Regla Actual:";
            // 
            // FormComuneroReglasDivision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 298);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Regla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Division);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_SinRegla);
            this.Controls.Add(this.button_AsignarRegla);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_ListaReglasActivas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormComuneroReglasDivision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Reglas de Recibos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormComuneroReglasDivision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListaReglasActivas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ListaReglasActivas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_AsignarRegla;
        private System.Windows.Forms.Button button_SinRegla;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.TextBox textBox_Division;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Regla;
        private System.Windows.Forms.Label label3;
    }
}