namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms
{
    partial class FormCuotasPlantillaManualDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCuotasPlantillaManualDetalle));
            this.textBox_Plantilla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_PlantillaManual = new System.Windows.Forms.DataGridView();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Añadir = new System.Windows.Forms.Button();
            this.button_Borrar = new System.Windows.Forms.Button();
            this.textBox_filtro_division = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PlantillaManual)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Plantilla
            // 
            this.textBox_Plantilla.Location = new System.Drawing.Point(134, 15);
            this.textBox_Plantilla.Name = "textBox_Plantilla";
            this.textBox_Plantilla.Size = new System.Drawing.Size(267, 20);
            this.textBox_Plantilla.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plantilla Tipo Manual:";
            // 
            // dataGridView_PlantillaManual
            // 
            this.dataGridView_PlantillaManual.AllowUserToAddRows = false;
            this.dataGridView_PlantillaManual.AllowUserToDeleteRows = false;
            this.dataGridView_PlantillaManual.AllowUserToOrderColumns = true;
            this.dataGridView_PlantillaManual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PlantillaManual.Enabled = false;
            this.dataGridView_PlantillaManual.Location = new System.Drawing.Point(21, 58);
            this.dataGridView_PlantillaManual.Name = "dataGridView_PlantillaManual";
            this.dataGridView_PlantillaManual.RowHeadersVisible = false;
            this.dataGridView_PlantillaManual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_PlantillaManual.Size = new System.Drawing.Size(716, 346);
            this.dataGridView_PlantillaManual.TabIndex = 2;
            this.dataGridView_PlantillaManual.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(581, 410);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 23);
            this.button_Guardar.TabIndex = 3;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(662, 410);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 4;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Añadir
            // 
            this.button_Añadir.Location = new System.Drawing.Point(581, 13);
            this.button_Añadir.Name = "button_Añadir";
            this.button_Añadir.Size = new System.Drawing.Size(75, 23);
            this.button_Añadir.TabIndex = 5;
            this.button_Añadir.Text = "Añadir";
            this.button_Añadir.UseVisualStyleBackColor = true;
            this.button_Añadir.Click += new System.EventHandler(this.button_Añadir_Click);
            // 
            // button_Borrar
            // 
            this.button_Borrar.Location = new System.Drawing.Point(662, 13);
            this.button_Borrar.Name = "button_Borrar";
            this.button_Borrar.Size = new System.Drawing.Size(75, 23);
            this.button_Borrar.TabIndex = 7;
            this.button_Borrar.Text = "Borrar";
            this.button_Borrar.UseVisualStyleBackColor = true;
            this.button_Borrar.Click += new System.EventHandler(this.button_Borrar_Click);
            // 
            // textBox_filtro_division
            // 
            this.textBox_filtro_division.ForeColor = System.Drawing.Color.Gray;
            this.textBox_filtro_division.Location = new System.Drawing.Point(451, 15);
            this.textBox_filtro_division.Name = "textBox_filtro_division";
            this.textBox_filtro_division.Size = new System.Drawing.Size(124, 20);
            this.textBox_filtro_division.TabIndex = 8;
            this.textBox_filtro_division.Text = "Filtrar División";
            this.textBox_filtro_division.Click += new System.EventHandler(this.textBox_filtro_division_Click);
            this.textBox_filtro_division.TextChanged += new System.EventHandler(this.textBox_filtro_division_TextChanged);
            this.textBox_filtro_division.Leave += new System.EventHandler(this.textBox_filtro_division_Leave);
            // 
            // FormCuotasPlantillaManualDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 450);
            this.Controls.Add(this.textBox_filtro_division);
            this.Controls.Add(this.button_Borrar);
            this.Controls.Add(this.button_Añadir);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.dataGridView_PlantillaManual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Plantilla);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCuotasPlantillaManualDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Plantilla Manual";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCuotasPlantillaManualDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PlantillaManual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Plantilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_PlantillaManual;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Añadir;
        private System.Windows.Forms.Button button_Borrar;
        private System.Windows.Forms.TextBox textBox_filtro_division;
    }
}