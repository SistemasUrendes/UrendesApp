namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    partial class FormComuneroAsociaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComuneroAsociaciones));
            this.textBox_Entidad = new System.Windows.Forms.TextBox();
            this.label_Entidad = new System.Windows.Forms.Label();
            this.dataGridView_ListaAsociaciones = new System.Windows.Forms.DataGridView();
            this.label_ListaAsoc = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListaAsociaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Entidad
            // 
            this.textBox_Entidad.Location = new System.Drawing.Point(98, 34);
            this.textBox_Entidad.Name = "textBox_Entidad";
            this.textBox_Entidad.Size = new System.Drawing.Size(277, 20);
            this.textBox_Entidad.TabIndex = 0;
            // 
            // label_Entidad
            // 
            this.label_Entidad.AutoSize = true;
            this.label_Entidad.Location = new System.Drawing.Point(31, 37);
            this.label_Entidad.Name = "label_Entidad";
            this.label_Entidad.Size = new System.Drawing.Size(61, 13);
            this.label_Entidad.TabIndex = 1;
            this.label_Entidad.Text = "Comunero :";
            // 
            // dataGridView_ListaAsociaciones
            // 
            this.dataGridView_ListaAsociaciones.AllowUserToAddRows = false;
            this.dataGridView_ListaAsociaciones.AllowUserToDeleteRows = false;
            this.dataGridView_ListaAsociaciones.AllowUserToOrderColumns = true;
            this.dataGridView_ListaAsociaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ListaAsociaciones.Location = new System.Drawing.Point(49, 94);
            this.dataGridView_ListaAsociaciones.MultiSelect = false;
            this.dataGridView_ListaAsociaciones.Name = "dataGridView_ListaAsociaciones";
            this.dataGridView_ListaAsociaciones.ReadOnly = true;
            this.dataGridView_ListaAsociaciones.RowHeadersVisible = false;
            this.dataGridView_ListaAsociaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ListaAsociaciones.Size = new System.Drawing.Size(326, 173);
            this.dataGridView_ListaAsociaciones.TabIndex = 2;
            // 
            // label_ListaAsoc
            // 
            this.label_ListaAsoc.AutoSize = true;
            this.label_ListaAsoc.Location = new System.Drawing.Point(49, 75);
            this.label_ListaAsoc.Name = "label_ListaAsoc";
            this.label_ListaAsoc.Size = new System.Drawing.Size(113, 13);
            this.label_ListaAsoc.TabIndex = 3;
            this.label_ListaAsoc.Text = "Lista de Asociaciones:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormComuneroAsociaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 335);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_ListaAsoc);
            this.Controls.Add(this.dataGridView_ListaAsociaciones);
            this.Controls.Add(this.label_Entidad);
            this.Controls.Add(this.textBox_Entidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormComuneroAsociaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comunero Asociaciones";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormComuneroAsociaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListaAsociaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Entidad;
        private System.Windows.Forms.Label label_Entidad;
        private System.Windows.Forms.DataGridView dataGridView_ListaAsociaciones;
        private System.Windows.Forms.Label label_ListaAsoc;
        private System.Windows.Forms.Button button1;
    }
}