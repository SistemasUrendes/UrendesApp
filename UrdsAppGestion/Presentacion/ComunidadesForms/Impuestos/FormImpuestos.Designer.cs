namespace UrdsAppGestión.Presentacion.ComunidadesForms.Impuestos
{
    partial class FormImpuestos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImpuestos));
            this.dataGridView_impuestos = new System.Windows.Forms.DataGridView();
            this.comboBox_liquidaciones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_informes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_impuestos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_impuestos
            // 
            this.dataGridView_impuestos.AllowUserToAddRows = false;
            this.dataGridView_impuestos.AllowUserToDeleteRows = false;
            this.dataGridView_impuestos.AllowUserToResizeRows = false;
            this.dataGridView_impuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_impuestos.Location = new System.Drawing.Point(12, 72);
            this.dataGridView_impuestos.Name = "dataGridView_impuestos";
            this.dataGridView_impuestos.RowHeadersVisible = false;
            this.dataGridView_impuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_impuestos.Size = new System.Drawing.Size(1087, 413);
            this.dataGridView_impuestos.TabIndex = 0;
            this.dataGridView_impuestos.DoubleClick += new System.EventHandler(this.dataGridView_impuestos_DoubleClick);
            // 
            // comboBox_liquidaciones
            // 
            this.comboBox_liquidaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_liquidaciones.FormattingEnabled = true;
            this.comboBox_liquidaciones.Items.AddRange(new object[] {
            "1 Trimestre IVA",
            "2 Trimestre IVA",
            "3 Trimestre IVA",
            "4 Trimestre IVA"});
            this.comboBox_liquidaciones.Location = new System.Drawing.Point(74, 45);
            this.comboBox_liquidaciones.Name = "comboBox_liquidaciones";
            this.comboBox_liquidaciones.Size = new System.Drawing.Size(121, 21);
            this.comboBox_liquidaciones.TabIndex = 1;
            this.comboBox_liquidaciones.SelectionChangeCommitted += new System.EventHandler(this.comboBox_liquidaciones_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Trimestre :";
            // 
            // comboBox_informes
            // 
            this.comboBox_informes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_informes.FormattingEnabled = true;
            this.comboBox_informes.Items.AddRange(new object[] {
            "Por Entidades"});
            this.comboBox_informes.Location = new System.Drawing.Point(325, 45);
            this.comboBox_informes.Name = "comboBox_informes";
            this.comboBox_informes.Size = new System.Drawing.Size(121, 21);
            this.comboBox_informes.TabIndex = 3;
            this.comboBox_informes.SelectionChangeCommitted += new System.EventHandler(this.comboBox_informes_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Informes:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1024, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Sel.Todos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(978, 491);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cerrar Operaciones";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormImpuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 533);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_informes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_liquidaciones);
            this.Controls.Add(this.dataGridView_impuestos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormImpuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impuestos";
            this.Load += new System.EventHandler(this.FormImpuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_impuestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_impuestos;
        private System.Windows.Forms.ComboBox comboBox_liquidaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_informes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}