namespace UrdsAppGestión.Presentacion.MantenimientoForms
{
    partial class FormBorradoMultiple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBorradoMultiple));
            this.dataGridView_idBorrar = new System.Windows.Forms.DataGridView();
            this.textBox_nombre_tabla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_campo = new System.Windows.Forms.TextBox();
            this.button_borrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_idBorrar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_idBorrar
            // 
            this.dataGridView_idBorrar.AllowUserToAddRows = false;
            this.dataGridView_idBorrar.AllowUserToDeleteRows = false;
            this.dataGridView_idBorrar.AllowUserToResizeRows = false;
            this.dataGridView_idBorrar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_idBorrar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_idBorrar.Location = new System.Drawing.Point(250, 12);
            this.dataGridView_idBorrar.Name = "dataGridView_idBorrar";
            this.dataGridView_idBorrar.ReadOnly = true;
            this.dataGridView_idBorrar.RowHeadersVisible = false;
            this.dataGridView_idBorrar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_idBorrar.Size = new System.Drawing.Size(240, 179);
            this.dataGridView_idBorrar.TabIndex = 0;
            this.dataGridView_idBorrar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_idBorrar_KeyDown);
            // 
            // textBox_nombre_tabla
            // 
            this.textBox_nombre_tabla.Location = new System.Drawing.Point(124, 57);
            this.textBox_nombre_tabla.Name = "textBox_nombre_tabla";
            this.textBox_nombre_tabla.Size = new System.Drawing.Size(110, 20);
            this.textBox_nombre_tabla.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre Tabla: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre Campo:  ";
            // 
            // textBox_campo
            // 
            this.textBox_campo.Location = new System.Drawing.Point(124, 87);
            this.textBox_campo.Name = "textBox_campo";
            this.textBox_campo.Size = new System.Drawing.Size(110, 20);
            this.textBox_campo.TabIndex = 3;
            // 
            // button_borrar
            // 
            this.button_borrar.Location = new System.Drawing.Point(85, 133);
            this.button_borrar.Name = "button_borrar";
            this.button_borrar.Size = new System.Drawing.Size(75, 23);
            this.button_borrar.TabIndex = 5;
            this.button_borrar.Text = "Borrar";
            this.button_borrar.UseVisualStyleBackColor = true;
            this.button_borrar.Click += new System.EventHandler(this.button_borrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(250, 197);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(135, 23);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // FormBorradoMultiple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 226);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_borrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_campo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_nombre_tabla);
            this.Controls.Add(this.dataGridView_idBorrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBorradoMultiple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrado Multiple";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_idBorrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_idBorrar;
        private System.Windows.Forms.TextBox textBox_nombre_tabla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_campo;
        private System.Windows.Forms.Button button_borrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}