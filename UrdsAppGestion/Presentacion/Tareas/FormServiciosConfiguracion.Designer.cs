namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormServiciosConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServiciosConfiguracion));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxComunidades = new System.Windows.Forms.ComboBox();
            this.textBoxFiltroBloque = new System.Windows.Forms.TextBox();
            this.buttonAddBloque = new System.Windows.Forms.Button();
            this.dataGridViewBloque = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBloque)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxComunidades);
            this.groupBox2.Controls.Add(this.textBoxFiltroBloque);
            this.groupBox2.Controls.Add(this.buttonAddBloque);
            this.groupBox2.Controls.Add(this.dataGridViewBloque);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 428);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bloques";
            // 
            // comboBoxComunidades
            // 
            this.comboBoxComunidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComunidades.FormattingEnabled = true;
            this.comboBoxComunidades.Location = new System.Drawing.Point(6, 19);
            this.comboBoxComunidades.Name = "comboBoxComunidades";
            this.comboBoxComunidades.Size = new System.Drawing.Size(212, 21);
            this.comboBoxComunidades.TabIndex = 4;
            // 
            // textBoxFiltroBloque
            // 
            this.textBoxFiltroBloque.Location = new System.Drawing.Point(6, 46);
            this.textBoxFiltroBloque.Name = "textBoxFiltroBloque";
            this.textBoxFiltroBloque.Size = new System.Drawing.Size(212, 20);
            this.textBoxFiltroBloque.TabIndex = 3;
            // 
            // buttonAddBloque
            // 
            this.buttonAddBloque.Location = new System.Drawing.Point(224, 44);
            this.buttonAddBloque.Name = "buttonAddBloque";
            this.buttonAddBloque.Size = new System.Drawing.Size(75, 23);
            this.buttonAddBloque.TabIndex = 2;
            this.buttonAddBloque.Text = "Añadir";
            this.buttonAddBloque.UseVisualStyleBackColor = true;
            this.buttonAddBloque.Click += new System.EventHandler(this.buttonAddBloque_Click);
            // 
            // dataGridViewBloque
            // 
            this.dataGridViewBloque.AllowUserToAddRows = false;
            this.dataGridViewBloque.AllowUserToDeleteRows = false;
            this.dataGridViewBloque.AllowUserToResizeRows = false;
            this.dataGridViewBloque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBloque.Location = new System.Drawing.Point(6, 70);
            this.dataGridViewBloque.Name = "dataGridViewBloque";
            this.dataGridViewBloque.ReadOnly = true;
            this.dataGridViewBloque.RowHeadersVisible = false;
            this.dataGridViewBloque.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewBloque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBloque.ShowEditingIcon = false;
            this.dataGridViewBloque.Size = new System.Drawing.Size(293, 350);
            this.dataGridViewBloque.TabIndex = 0;
            // 
            // FormServiciosConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 633);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormServiciosConfiguracion";
            this.Text = "Configuración Servicios";
            this.Load += new System.EventHandler(this.FormServiciosConfiguracion_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBloque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxComunidades;
        private System.Windows.Forms.TextBox textBoxFiltroBloque;
        private System.Windows.Forms.Button buttonAddBloque;
        private System.Windows.Forms.DataGridView dataGridViewBloque;
    }
}