namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms
{
    partial class FormCuotasPlantillaPptoDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCuotasPlantillaPptoDetalle));
            this.button_Borrar = new System.Windows.Forms.Button();
            this.button_Añadir = new System.Windows.Forms.Button();
            this.dataGridView_DetallePlantilla = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Plantilla = new System.Windows.Forms.TextBox();
            this.button_Editar = new System.Windows.Forms.Button();
            this.checkBox_activa = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DetallePlantilla)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Borrar
            // 
            this.button_Borrar.Location = new System.Drawing.Point(366, 85);
            this.button_Borrar.Name = "button_Borrar";
            this.button_Borrar.Size = new System.Drawing.Size(48, 23);
            this.button_Borrar.TabIndex = 14;
            this.button_Borrar.Text = "Borrar";
            this.button_Borrar.UseVisualStyleBackColor = true;
            this.button_Borrar.Click += new System.EventHandler(this.button_Borrar_Click);
            // 
            // button_Añadir
            // 
            this.button_Añadir.Location = new System.Drawing.Point(259, 85);
            this.button_Añadir.Name = "button_Añadir";
            this.button_Añadir.Size = new System.Drawing.Size(46, 23);
            this.button_Añadir.TabIndex = 13;
            this.button_Añadir.Text = "Añadir";
            this.button_Añadir.UseVisualStyleBackColor = true;
            this.button_Añadir.Click += new System.EventHandler(this.button_Añadir_Click);
            // 
            // dataGridView_DetallePlantilla
            // 
            this.dataGridView_DetallePlantilla.AllowUserToAddRows = false;
            this.dataGridView_DetallePlantilla.AllowUserToDeleteRows = false;
            this.dataGridView_DetallePlantilla.AllowUserToOrderColumns = true;
            this.dataGridView_DetallePlantilla.AllowUserToResizeRows = false;
            this.dataGridView_DetallePlantilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DetallePlantilla.Location = new System.Drawing.Point(35, 114);
            this.dataGridView_DetallePlantilla.MultiSelect = false;
            this.dataGridView_DetallePlantilla.Name = "dataGridView_DetallePlantilla";
            this.dataGridView_DetallePlantilla.ReadOnly = true;
            this.dataGridView_DetallePlantilla.RowHeadersVisible = false;
            this.dataGridView_DetallePlantilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_DetallePlantilla.Size = new System.Drawing.Size(379, 203);
            this.dataGridView_DetallePlantilla.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Plantilla por Presupuesto:";
            // 
            // textBox_Plantilla
            // 
            this.textBox_Plantilla.Location = new System.Drawing.Point(164, 19);
            this.textBox_Plantilla.Name = "textBox_Plantilla";
            this.textBox_Plantilla.Size = new System.Drawing.Size(250, 20);
            this.textBox_Plantilla.TabIndex = 8;
            // 
            // button_Editar
            // 
            this.button_Editar.Location = new System.Drawing.Point(311, 85);
            this.button_Editar.Name = "button_Editar";
            this.button_Editar.Size = new System.Drawing.Size(49, 23);
            this.button_Editar.TabIndex = 15;
            this.button_Editar.Text = "Editar";
            this.button_Editar.UseVisualStyleBackColor = true;
            this.button_Editar.Click += new System.EventHandler(this.button_Editar_Click);
            // 
            // checkBox_activa
            // 
            this.checkBox_activa.AutoSize = true;
            this.checkBox_activa.Location = new System.Drawing.Point(164, 45);
            this.checkBox_activa.Name = "checkBox_activa";
            this.checkBox_activa.Size = new System.Drawing.Size(56, 17);
            this.checkBox_activa.TabIndex = 16;
            this.checkBox_activa.Text = "Activa";
            this.checkBox_activa.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 323);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormCuotasPlantillaPptoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 366);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_activa);
            this.Controls.Add(this.button_Editar);
            this.Controls.Add(this.button_Borrar);
            this.Controls.Add(this.button_Añadir);
            this.Controls.Add(this.dataGridView_DetallePlantilla);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Plantilla);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCuotasPlantillaPptoDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Cuotas por Presupuesto";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCuotasPlantillaPptoDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DetallePlantilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Borrar;
        private System.Windows.Forms.Button button_Añadir;
        private System.Windows.Forms.DataGridView dataGridView_DetallePlantilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Plantilla;
        private System.Windows.Forms.Button button_Editar;
        private System.Windows.Forms.CheckBox checkBox_activa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}