namespace UrdsAppGestión.Presentacion.ComunidadesForms.FormProvisiones
{
    partial class FormProvisiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProvisiones));
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.button_Editar = new System.Windows.Forms.Button();
            this.button_Borrar = new System.Windows.Forms.Button();
            this.dataGridView_Provisiones = new System.Windows.Forms.DataGridView();
            this.comboBox_Filtro = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Provisiones)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Location = new System.Drawing.Point(30, 21);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.button_Aceptar.TabIndex = 0;
            this.button_Aceptar.Text = "Añadir";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // button_Editar
            // 
            this.button_Editar.Location = new System.Drawing.Point(111, 21);
            this.button_Editar.Name = "button_Editar";
            this.button_Editar.Size = new System.Drawing.Size(75, 23);
            this.button_Editar.TabIndex = 1;
            this.button_Editar.Text = "Editar";
            this.button_Editar.UseVisualStyleBackColor = true;
            this.button_Editar.Click += new System.EventHandler(this.button_Editar_Click);
            // 
            // button_Borrar
            // 
            this.button_Borrar.Location = new System.Drawing.Point(192, 21);
            this.button_Borrar.Name = "button_Borrar";
            this.button_Borrar.Size = new System.Drawing.Size(75, 23);
            this.button_Borrar.TabIndex = 2;
            this.button_Borrar.Text = "Borrar";
            this.button_Borrar.UseVisualStyleBackColor = true;
            this.button_Borrar.Click += new System.EventHandler(this.button_Borrar_Click);
            // 
            // dataGridView_Provisiones
            // 
            this.dataGridView_Provisiones.AllowUserToAddRows = false;
            this.dataGridView_Provisiones.AllowUserToDeleteRows = false;
            this.dataGridView_Provisiones.AllowUserToOrderColumns = true;
            this.dataGridView_Provisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Provisiones.Location = new System.Drawing.Point(30, 51);
            this.dataGridView_Provisiones.MultiSelect = false;
            this.dataGridView_Provisiones.Name = "dataGridView_Provisiones";
            this.dataGridView_Provisiones.ReadOnly = true;
            this.dataGridView_Provisiones.RowHeadersVisible = false;
            this.dataGridView_Provisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Provisiones.Size = new System.Drawing.Size(863, 380);
            this.dataGridView_Provisiones.TabIndex = 5;
            // 
            // comboBox_Filtro
            // 
            this.comboBox_Filtro.FormattingEnabled = true;
            this.comboBox_Filtro.Items.AddRange(new object[] {
            "Con Saldo",
            "Sin Saldo",
            "Todas"});
            this.comboBox_Filtro.Location = new System.Drawing.Point(772, 24);
            this.comboBox_Filtro.Name = "comboBox_Filtro";
            this.comboBox_Filtro.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Filtro.TabIndex = 6;
            this.comboBox_Filtro.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Filtro_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(734, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filtro:";
            // 
            // FormProvisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 467);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Filtro);
            this.Controls.Add(this.dataGridView_Provisiones);
            this.Controls.Add(this.button_Borrar);
            this.Controls.Add(this.button_Editar);
            this.Controls.Add(this.button_Aceptar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProvisiones";
            this.Text = "Provisiones";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormProvisiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Provisiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.Button button_Editar;
        private System.Windows.Forms.Button button_Borrar;
        private System.Windows.Forms.DataGridView dataGridView_Provisiones;
        private System.Windows.Forms.ComboBox comboBox_Filtro;
        private System.Windows.Forms.Label label1;
    }
}