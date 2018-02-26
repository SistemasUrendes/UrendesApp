namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    partial class FormComuneroReglas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComuneroReglas));
            this.textBox_Entidad = new System.Windows.Forms.TextBox();
            this.label_Entidad = new System.Windows.Forms.Label();
            this.dataGridView_ListaReglas = new System.Windows.Forms.DataGridView();
            this.dataGridView_DivisionRegla = new System.Windows.Forms.DataGridView();
            this.label_ListaReglas = new System.Windows.Forms.Label();
            this.label_AsociacionesComunero = new System.Windows.Forms.Label();
            this.button_Añadir = new System.Windows.Forms.Button();
            this.button_Editar = new System.Windows.Forms.Button();
            this.button_Borrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListaReglas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DivisionRegla)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Entidad
            // 
            this.textBox_Entidad.Enabled = false;
            this.textBox_Entidad.Location = new System.Drawing.Point(114, 23);
            this.textBox_Entidad.Name = "textBox_Entidad";
            this.textBox_Entidad.Size = new System.Drawing.Size(239, 20);
            this.textBox_Entidad.TabIndex = 0;
            // 
            // label_Entidad
            // 
            this.label_Entidad.AutoSize = true;
            this.label_Entidad.Location = new System.Drawing.Point(47, 26);
            this.label_Entidad.Name = "label_Entidad";
            this.label_Entidad.Size = new System.Drawing.Size(61, 13);
            this.label_Entidad.TabIndex = 1;
            this.label_Entidad.Text = "Comunero :";
            // 
            // dataGridView_ListaReglas
            // 
            this.dataGridView_ListaReglas.AllowUserToAddRows = false;
            this.dataGridView_ListaReglas.AllowUserToDeleteRows = false;
            this.dataGridView_ListaReglas.AllowUserToOrderColumns = true;
            this.dataGridView_ListaReglas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ListaReglas.Location = new System.Drawing.Point(45, 85);
            this.dataGridView_ListaReglas.MultiSelect = false;
            this.dataGridView_ListaReglas.Name = "dataGridView_ListaReglas";
            this.dataGridView_ListaReglas.ReadOnly = true;
            this.dataGridView_ListaReglas.RowHeadersVisible = false;
            this.dataGridView_ListaReglas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ListaReglas.Size = new System.Drawing.Size(534, 108);
            this.dataGridView_ListaReglas.TabIndex = 2;
            // 
            // dataGridView_DivisionRegla
            // 
            this.dataGridView_DivisionRegla.AllowUserToAddRows = false;
            this.dataGridView_DivisionRegla.AllowUserToDeleteRows = false;
            this.dataGridView_DivisionRegla.AllowUserToOrderColumns = true;
            this.dataGridView_DivisionRegla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DivisionRegla.Location = new System.Drawing.Point(131, 237);
            this.dataGridView_DivisionRegla.MultiSelect = false;
            this.dataGridView_DivisionRegla.Name = "dataGridView_DivisionRegla";
            this.dataGridView_DivisionRegla.ReadOnly = true;
            this.dataGridView_DivisionRegla.RowHeadersVisible = false;
            this.dataGridView_DivisionRegla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_DivisionRegla.Size = new System.Drawing.Size(343, 167);
            this.dataGridView_DivisionRegla.TabIndex = 3;
            this.dataGridView_DivisionRegla.DoubleClick += new System.EventHandler(this.dataGridView_DivisionRegla_DoubleClick);
            // 
            // label_ListaReglas
            // 
            this.label_ListaReglas.AutoSize = true;
            this.label_ListaReglas.Location = new System.Drawing.Point(42, 69);
            this.label_ListaReglas.Name = "label_ListaReglas";
            this.label_ListaReglas.Size = new System.Drawing.Size(111, 13);
            this.label_ListaReglas.TabIndex = 4;
            this.label_ListaReglas.Text = "Reglas del Comunero:";
            // 
            // label_AsociacionesComunero
            // 
            this.label_AsociacionesComunero.AutoSize = true;
            this.label_AsociacionesComunero.Location = new System.Drawing.Point(216, 221);
            this.label_AsociacionesComunero.Name = "label_AsociacionesComunero";
            this.label_AsociacionesComunero.Size = new System.Drawing.Size(172, 13);
            this.label_AsociacionesComunero.TabIndex = 5;
            this.label_AsociacionesComunero.Text = "Divisiones Asociadas al Comunero:";
            // 
            // button_Añadir
            // 
            this.button_Añadir.Location = new System.Drawing.Point(393, 56);
            this.button_Añadir.Name = "button_Añadir";
            this.button_Añadir.Size = new System.Drawing.Size(58, 23);
            this.button_Añadir.TabIndex = 6;
            this.button_Añadir.Text = "Añadir";
            this.button_Añadir.UseVisualStyleBackColor = true;
            this.button_Añadir.Click += new System.EventHandler(this.button_Añadir_Click);
            // 
            // button_Editar
            // 
            this.button_Editar.Location = new System.Drawing.Point(457, 56);
            this.button_Editar.Name = "button_Editar";
            this.button_Editar.Size = new System.Drawing.Size(58, 23);
            this.button_Editar.TabIndex = 7;
            this.button_Editar.Text = "Editar";
            this.button_Editar.UseVisualStyleBackColor = true;
            this.button_Editar.Click += new System.EventHandler(this.button_Editar_Click);
            // 
            // button_Borrar
            // 
            this.button_Borrar.Location = new System.Drawing.Point(521, 56);
            this.button_Borrar.Name = "button_Borrar";
            this.button_Borrar.Size = new System.Drawing.Size(58, 23);
            this.button_Borrar.TabIndex = 8;
            this.button_Borrar.Text = "Borrar";
            this.button_Borrar.UseVisualStyleBackColor = true;
            this.button_Borrar.Click += new System.EventHandler(this.button_Borrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(392, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "    ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 407);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Con Regla";
            // 
            // FormComuneroReglas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 468);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Borrar);
            this.Controls.Add(this.button_Editar);
            this.Controls.Add(this.button_Añadir);
            this.Controls.Add(this.label_AsociacionesComunero);
            this.Controls.Add(this.label_ListaReglas);
            this.Controls.Add(this.dataGridView_DivisionRegla);
            this.Controls.Add(this.dataGridView_ListaReglas);
            this.Controls.Add(this.label_Entidad);
            this.Controls.Add(this.textBox_Entidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormComuneroReglas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comunero Reglas Recibos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormComuneroReglas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListaReglas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DivisionRegla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Entidad;
        private System.Windows.Forms.Label label_Entidad;
        private System.Windows.Forms.DataGridView dataGridView_ListaReglas;
        private System.Windows.Forms.DataGridView dataGridView_DivisionRegla;
        private System.Windows.Forms.Label label_ListaReglas;
        private System.Windows.Forms.Label label_AsociacionesComunero;
        private System.Windows.Forms.Button button_Añadir;
        private System.Windows.Forms.Button button_Editar;
        private System.Windows.Forms.Button button_Borrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}