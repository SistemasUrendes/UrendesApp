namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormInsertarTipoTarea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInsertarTipoTarea));
            this.dataGridViewAllGestion = new System.Windows.Forms.DataGridView();
            this.dataGridViewAddGestion = new System.Windows.Forms.DataGridView();
            this.textBoxFiltroGestiones = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSubir = new System.Windows.Forms.Button();
            this.buttonBajar = new System.Windows.Forms.Button();
            this.buttonAddGestion = new System.Windows.Forms.Button();
            this.buttonRemoveGestion = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllGestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddGestion)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAllGestion
            // 
            this.dataGridViewAllGestion.AllowUserToAddRows = false;
            this.dataGridViewAllGestion.AllowUserToDeleteRows = false;
            this.dataGridViewAllGestion.AllowUserToResizeRows = false;
            this.dataGridViewAllGestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllGestion.Location = new System.Drawing.Point(351, 74);
            this.dataGridViewAllGestion.MultiSelect = false;
            this.dataGridViewAllGestion.Name = "dataGridViewAllGestion";
            this.dataGridViewAllGestion.ReadOnly = true;
            this.dataGridViewAllGestion.RowHeadersVisible = false;
            this.dataGridViewAllGestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAllGestion.Size = new System.Drawing.Size(309, 343);
            this.dataGridViewAllGestion.TabIndex = 1;
            this.dataGridViewAllGestion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAllGestion_CellDoubleClick);
            // 
            // dataGridViewAddGestion
            // 
            this.dataGridViewAddGestion.AllowUserToAddRows = false;
            this.dataGridViewAddGestion.AllowUserToDeleteRows = false;
            this.dataGridViewAddGestion.AllowUserToResizeRows = false;
            this.dataGridViewAddGestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddGestion.Location = new System.Drawing.Point(12, 74);
            this.dataGridViewAddGestion.MultiSelect = false;
            this.dataGridViewAddGestion.Name = "dataGridViewAddGestion";
            this.dataGridViewAddGestion.ReadOnly = true;
            this.dataGridViewAddGestion.RowHeadersVisible = false;
            this.dataGridViewAddGestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAddGestion.Size = new System.Drawing.Size(299, 343);
            this.dataGridViewAddGestion.TabIndex = 2;
            this.dataGridViewAddGestion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAddGestion_CellDoubleClick);
            // 
            // textBoxFiltroGestiones
            // 
            this.textBoxFiltroGestiones.Location = new System.Drawing.Point(351, 48);
            this.textBoxFiltroGestiones.Name = "textBoxFiltroGestiones";
            this.textBoxFiltroGestiones.Size = new System.Drawing.Size(309, 20);
            this.textBoxFiltroGestiones.TabIndex = 3;
            this.textBoxFiltroGestiones.TextChanged += new System.EventHandler(this.textBoxFiltroGestiones_TextChanged);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(66, 12);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(245, 20);
            this.textBoxNombre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre:";
            // 
            // buttonSubir
            // 
            this.buttonSubir.Location = new System.Drawing.Point(317, 124);
            this.buttonSubir.Name = "buttonSubir";
            this.buttonSubir.Size = new System.Drawing.Size(28, 23);
            this.buttonSubir.TabIndex = 7;
            this.buttonSubir.Text = "↑";
            this.buttonSubir.UseVisualStyleBackColor = true;
            this.buttonSubir.Click += new System.EventHandler(this.buttonSubir_Click);
            // 
            // buttonBajar
            // 
            this.buttonBajar.Location = new System.Drawing.Point(317, 153);
            this.buttonBajar.Name = "buttonBajar";
            this.buttonBajar.Size = new System.Drawing.Size(28, 23);
            this.buttonBajar.TabIndex = 8;
            this.buttonBajar.Text = "↓";
            this.buttonBajar.UseVisualStyleBackColor = true;
            this.buttonBajar.Click += new System.EventHandler(this.buttonBajar_Click);
            // 
            // buttonAddGestion
            // 
            this.buttonAddGestion.Location = new System.Drawing.Point(317, 235);
            this.buttonAddGestion.Name = "buttonAddGestion";
            this.buttonAddGestion.Size = new System.Drawing.Size(28, 23);
            this.buttonAddGestion.TabIndex = 9;
            this.buttonAddGestion.Text = "<<";
            this.buttonAddGestion.UseVisualStyleBackColor = true;
            this.buttonAddGestion.Click += new System.EventHandler(this.buttonAddGestion_Click);
            // 
            // buttonRemoveGestion
            // 
            this.buttonRemoveGestion.Location = new System.Drawing.Point(317, 264);
            this.buttonRemoveGestion.Name = "buttonRemoveGestion";
            this.buttonRemoveGestion.Size = new System.Drawing.Size(28, 23);
            this.buttonRemoveGestion.TabIndex = 10;
            this.buttonRemoveGestion.Text = ">>";
            this.buttonRemoveGestion.UseVisualStyleBackColor = true;
            this.buttonRemoveGestion.Click += new System.EventHandler(this.buttonRemoveGestion_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(585, 423);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 11;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(504, 423);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 12;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // comboBoxCategorias
            // 
            this.comboBoxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategorias.FormattingEnabled = true;
            this.comboBoxCategorias.Location = new System.Drawing.Point(66, 39);
            this.comboBoxCategorias.Name = "comboBoxCategorias";
            this.comboBoxCategorias.Size = new System.Drawing.Size(245, 21);
            this.comboBoxCategorias.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Categoría:";
            // 
            // FormInsertarTipoTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 457);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCategorias);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonRemoveGestion);
            this.Controls.Add(this.buttonAddGestion);
            this.Controls.Add(this.buttonBajar);
            this.Controls.Add(this.buttonSubir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.textBoxFiltroGestiones);
            this.Controls.Add(this.dataGridViewAddGestion);
            this.Controls.Add(this.dataGridViewAllGestion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInsertarTipoTarea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insertar Tipo Tarea";
            this.Load += new System.EventHandler(this.FormInsertarTipoTarea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllGestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddGestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAllGestion;
        private System.Windows.Forms.DataGridView dataGridViewAddGestion;
        private System.Windows.Forms.TextBox textBoxFiltroGestiones;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSubir;
        private System.Windows.Forms.Button buttonBajar;
        private System.Windows.Forms.Button buttonAddGestion;
        private System.Windows.Forms.Button buttonRemoveGestion;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.Label label1;
    }
}