namespace UrdsAppGestión.Presentacion.MantenimientoForms
{
    partial class FormInsertarPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInsertarPendientes));
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelElementos = new System.Windows.Forms.Label();
            this.progressBar_insert = new System.Windows.Forms.ProgressBar();
            this.comboBox_cuota = new System.Windows.Forms.ComboBox();
            this.comboBox_liquid = new System.Windows.Forms.ComboBox();
            this.comboBox_IdBloque = new System.Windows.Forms.ComboBox();
            this.comboBox_IdComunidad = new System.Windows.Forms.ComboBox();
            this.buttonInsertar = new System.Windows.Forms.Button();
            this.dataGridView_Insertar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Insertar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(887, 481);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(0, 13);
            this.labelTotal.TabIndex = 19;
            // 
            // labelElementos
            // 
            this.labelElementos.AutoSize = true;
            this.labelElementos.Location = new System.Drawing.Point(887, 452);
            this.labelElementos.Name = "labelElementos";
            this.labelElementos.Size = new System.Drawing.Size(0, 13);
            this.labelElementos.TabIndex = 18;
            // 
            // progressBar_insert
            // 
            this.progressBar_insert.Location = new System.Drawing.Point(203, 520);
            this.progressBar_insert.Name = "progressBar_insert";
            this.progressBar_insert.Size = new System.Drawing.Size(442, 23);
            this.progressBar_insert.TabIndex = 17;
            this.progressBar_insert.Visible = false;
            // 
            // comboBox_cuota
            // 
            this.comboBox_cuota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cuota.FormattingEnabled = true;
            this.comboBox_cuota.Location = new System.Drawing.Point(874, 121);
            this.comboBox_cuota.Name = "comboBox_cuota";
            this.comboBox_cuota.Size = new System.Drawing.Size(121, 21);
            this.comboBox_cuota.TabIndex = 16;
            // 
            // comboBox_liquid
            // 
            this.comboBox_liquid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_liquid.FormattingEnabled = true;
            this.comboBox_liquid.Location = new System.Drawing.Point(874, 94);
            this.comboBox_liquid.Name = "comboBox_liquid";
            this.comboBox_liquid.Size = new System.Drawing.Size(121, 21);
            this.comboBox_liquid.TabIndex = 15;
            this.comboBox_liquid.SelectionChangeCommitted += new System.EventHandler(this.comboBox_liquid_SelectionChangeCommitted);
            // 
            // comboBox_IdBloque
            // 
            this.comboBox_IdBloque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_IdBloque.FormattingEnabled = true;
            this.comboBox_IdBloque.Location = new System.Drawing.Point(874, 65);
            this.comboBox_IdBloque.Name = "comboBox_IdBloque";
            this.comboBox_IdBloque.Size = new System.Drawing.Size(121, 21);
            this.comboBox_IdBloque.TabIndex = 14;
            // 
            // comboBox_IdComunidad
            // 
            this.comboBox_IdComunidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_IdComunidad.FormattingEnabled = true;
            this.comboBox_IdComunidad.Location = new System.Drawing.Point(874, 35);
            this.comboBox_IdComunidad.Name = "comboBox_IdComunidad";
            this.comboBox_IdComunidad.Size = new System.Drawing.Size(121, 21);
            this.comboBox_IdComunidad.TabIndex = 13;
            this.comboBox_IdComunidad.SelectionChangeCommitted += new System.EventHandler(this.comboBox_IdComunidad_SelectionChangeCommitted);
            // 
            // buttonInsertar
            // 
            this.buttonInsertar.Location = new System.Drawing.Point(890, 175);
            this.buttonInsertar.Name = "buttonInsertar";
            this.buttonInsertar.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertar.TabIndex = 12;
            this.buttonInsertar.Text = "Insertar";
            this.buttonInsertar.UseVisualStyleBackColor = true;
            this.buttonInsertar.Click += new System.EventHandler(this.button_insertar_Click);
            // 
            // dataGridView_Insertar
            // 
            this.dataGridView_Insertar.AllowUserToAddRows = false;
            this.dataGridView_Insertar.AllowUserToDeleteRows = false;
            this.dataGridView_Insertar.AllowUserToResizeRows = false;
            this.dataGridView_Insertar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_Insertar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Insertar.Location = new System.Drawing.Point(42, 35);
            this.dataGridView_Insertar.MultiSelect = false;
            this.dataGridView_Insertar.Name = "dataGridView_Insertar";
            this.dataGridView_Insertar.ReadOnly = true;
            this.dataGridView_Insertar.RowHeadersVisible = false;
            this.dataGridView_Insertar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Insertar.Size = new System.Drawing.Size(826, 459);
            this.dataGridView_Insertar.TabIndex = 11;
            this.dataGridView_Insertar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Insertar_CellContentClick);
            this.dataGridView_Insertar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_Insertar_KeyDown);
            // 
            // FormInsertarPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 578);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelElementos);
            this.Controls.Add(this.progressBar_insert);
            this.Controls.Add(this.comboBox_cuota);
            this.Controls.Add(this.comboBox_liquid);
            this.Controls.Add(this.comboBox_IdBloque);
            this.Controls.Add(this.comboBox_IdComunidad);
            this.Controls.Add(this.buttonInsertar);
            this.Controls.Add(this.dataGridView_Insertar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInsertarPendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insertar Pendientes";
            this.Load += new System.EventHandler(this.FormInsertarPendientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Insertar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelElementos;
        private System.Windows.Forms.ProgressBar progressBar_insert;
        private System.Windows.Forms.ComboBox comboBox_cuota;
        private System.Windows.Forms.ComboBox comboBox_liquid;
        private System.Windows.Forms.ComboBox comboBox_IdBloque;
        private System.Windows.Forms.ComboBox comboBox_IdComunidad;
        private System.Windows.Forms.Button buttonInsertar;
        private System.Windows.Forms.DataGridView dataGridView_Insertar;
    }
}