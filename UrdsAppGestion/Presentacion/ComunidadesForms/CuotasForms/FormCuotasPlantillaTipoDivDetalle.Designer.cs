namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms
{
    partial class FormCuotasPlantillaTipoDivDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCuotasPlantillaTipoDivDetalle));
            this.textBox_descripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_PlantillaTipoDiv = new System.Windows.Forms.DataGridView();
            this.button_Añadir = new System.Windows.Forms.Button();
            this.button_Editar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox_activa = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PlantillaTipoDiv)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_descripcion
            // 
            this.textBox_descripcion.Location = new System.Drawing.Point(155, 30);
            this.textBox_descripcion.Name = "textBox_descripcion";
            this.textBox_descripcion.Size = new System.Drawing.Size(254, 20);
            this.textBox_descripcion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plantilla Tipo División:";
            // 
            // dataGridView_PlantillaTipoDiv
            // 
            this.dataGridView_PlantillaTipoDiv.AllowUserToAddRows = false;
            this.dataGridView_PlantillaTipoDiv.AllowUserToDeleteRows = false;
            this.dataGridView_PlantillaTipoDiv.AllowUserToOrderColumns = true;
            this.dataGridView_PlantillaTipoDiv.AllowUserToResizeRows = false;
            this.dataGridView_PlantillaTipoDiv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PlantillaTipoDiv.Location = new System.Drawing.Point(42, 105);
            this.dataGridView_PlantillaTipoDiv.MultiSelect = false;
            this.dataGridView_PlantillaTipoDiv.Name = "dataGridView_PlantillaTipoDiv";
            this.dataGridView_PlantillaTipoDiv.ReadOnly = true;
            this.dataGridView_PlantillaTipoDiv.RowHeadersVisible = false;
            this.dataGridView_PlantillaTipoDiv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_PlantillaTipoDiv.Size = new System.Drawing.Size(367, 228);
            this.dataGridView_PlantillaTipoDiv.TabIndex = 2;
            // 
            // button_Añadir
            // 
            this.button_Añadir.Location = new System.Drawing.Point(297, 76);
            this.button_Añadir.Name = "button_Añadir";
            this.button_Añadir.Size = new System.Drawing.Size(55, 23);
            this.button_Añadir.TabIndex = 3;
            this.button_Añadir.Text = "Añadir";
            this.button_Añadir.UseVisualStyleBackColor = true;
            this.button_Añadir.Click += new System.EventHandler(this.button_Añadir_Click);
            // 
            // button_Editar
            // 
            this.button_Editar.Location = new System.Drawing.Point(358, 76);
            this.button_Editar.Name = "button_Editar";
            this.button_Editar.Size = new System.Drawing.Size(51, 23);
            this.button_Editar.TabIndex = 4;
            this.button_Editar.Text = "Editar";
            this.button_Editar.UseVisualStyleBackColor = true;
            this.button_Editar.Click += new System.EventHandler(this.button_Editar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(334, 367);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox_activa
            // 
            this.checkBox_activa.AutoSize = true;
            this.checkBox_activa.Location = new System.Drawing.Point(155, 66);
            this.checkBox_activa.Name = "checkBox_activa";
            this.checkBox_activa.Size = new System.Drawing.Size(56, 17);
            this.checkBox_activa.TabIndex = 8;
            this.checkBox_activa.Text = "Activa";
            this.checkBox_activa.UseVisualStyleBackColor = true;
            // 
            // FormCuotasPlantillaTipoDivDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 402);
            this.Controls.Add(this.checkBox_activa);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_Editar);
            this.Controls.Add(this.button_Añadir);
            this.Controls.Add(this.dataGridView_PlantillaTipoDiv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_descripcion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCuotasPlantillaTipoDivDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Plantilla Tipo División";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCuotasPlantillaTipoDivDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PlantillaTipoDiv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_descripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_PlantillaTipoDiv;
        private System.Windows.Forms.Button button_Añadir;
        private System.Windows.Forms.Button button_Editar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox_activa;
    }
}