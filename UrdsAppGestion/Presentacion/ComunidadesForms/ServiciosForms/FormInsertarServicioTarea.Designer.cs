namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormInsertarServicioTarea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInsertarServicioTarea));
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxFiltroBloque = new System.Windows.Forms.TextBox();
            this.textBoxFiltroCategoria = new System.Windows.Forms.TextBox();
            this.textBoxFiltroServicios = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridViewServicios = new System.Windows.Forms.DataGridView();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.buttonAddServicio = new System.Windows.Forms.Button();
            this.dataGridViewCategorias = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(545, 47);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Bloque.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(781, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 13);
            this.label16.TabIndex = 40;
            this.label16.Text = "Cat.";
            // 
            // textBoxFiltroBloque
            // 
            this.textBoxFiltroBloque.Location = new System.Drawing.Point(594, 44);
            this.textBoxFiltroBloque.Name = "textBoxFiltroBloque";
            this.textBoxFiltroBloque.Size = new System.Drawing.Size(170, 20);
            this.textBoxFiltroBloque.TabIndex = 2;
            this.textBoxFiltroBloque.TextChanged += new System.EventHandler(this.filtrarServicios);
            this.textBoxFiltroBloque.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFiltroBloque_KeyDown);
            // 
            // textBoxFiltroCategoria
            // 
            this.textBoxFiltroCategoria.Location = new System.Drawing.Point(813, 44);
            this.textBoxFiltroCategoria.Name = "textBoxFiltroCategoria";
            this.textBoxFiltroCategoria.Size = new System.Drawing.Size(170, 20);
            this.textBoxFiltroCategoria.TabIndex = 3;
            this.textBoxFiltroCategoria.TextChanged += new System.EventHandler(this.filtrarServicios);
            this.textBoxFiltroCategoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFiltroCategoria_KeyDown);
            // 
            // textBoxFiltroServicios
            // 
            this.textBoxFiltroServicios.Location = new System.Drawing.Point(340, 44);
            this.textBoxFiltroServicios.Name = "textBoxFiltroServicios";
            this.textBoxFiltroServicios.Size = new System.Drawing.Size(199, 20);
            this.textBoxFiltroServicios.TabIndex = 1;
            this.textBoxFiltroServicios.TextChanged += new System.EventHandler(this.filtrarServicios);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(142, 17);
            this.label15.TabIndex = 36;
            this.label15.Text = "Servicios de la Tarea";
            // 
            // dataGridViewServicios
            // 
            this.dataGridViewServicios.AllowUserToAddRows = false;
            this.dataGridViewServicios.AllowUserToDeleteRows = false;
            this.dataGridViewServicios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServicios.Location = new System.Drawing.Point(340, 70);
            this.dataGridViewServicios.Name = "dataGridViewServicios";
            this.dataGridViewServicios.ReadOnly = true;
            this.dataGridViewServicios.RowHeadersVisible = false;
            this.dataGridViewServicios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewServicios.Size = new System.Drawing.Size(643, 340);
            this.dataGridViewServicios.TabIndex = 4;
            this.dataGridViewServicios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewServicios_CellClick);
            this.dataGridViewServicios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewServicios_KeyDown);
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Location = new System.Drawing.Point(609, 12);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(88, 23);
            this.buttonEnviar.TabIndex = 5;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // buttonAddServicio
            // 
            this.buttonAddServicio.Location = new System.Drawing.Point(855, 12);
            this.buttonAddServicio.Name = "buttonAddServicio";
            this.buttonAddServicio.Size = new System.Drawing.Size(128, 23);
            this.buttonAddServicio.TabIndex = 42;
            this.buttonAddServicio.Text = "Añadir Servicio nuevo";
            this.buttonAddServicio.UseVisualStyleBackColor = true;
            this.buttonAddServicio.Click += new System.EventHandler(this.buttonAddServicio_Click);
            // 
            // dataGridViewCategorias
            // 
            this.dataGridViewCategorias.AllowUserToAddRows = false;
            this.dataGridViewCategorias.AllowUserToDeleteRows = false;
            this.dataGridViewCategorias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategorias.Location = new System.Drawing.Point(12, 70);
            this.dataGridViewCategorias.Name = "dataGridViewCategorias";
            this.dataGridViewCategorias.ReadOnly = true;
            this.dataGridViewCategorias.RowHeadersVisible = false;
            this.dataGridViewCategorias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCategorias.Size = new System.Drawing.Size(322, 340);
            this.dataGridViewCategorias.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 44;
            this.label1.Text = "Categorías:";
            // 
            // FormInsertarServicioTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 422);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewCategorias);
            this.Controls.Add(this.buttonAddServicio);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxFiltroBloque);
            this.Controls.Add(this.textBoxFiltroCategoria);
            this.Controls.Add(this.textBoxFiltroServicios);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dataGridViewServicios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInsertarServicioTarea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInsertarServicioTarea";
            this.Load += new System.EventHandler(this.FormInsertarServicioTarea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxFiltroBloque;
        private System.Windows.Forms.TextBox textBoxFiltroCategoria;
        private System.Windows.Forms.TextBox textBoxFiltroServicios;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dataGridViewServicios;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.Button buttonAddServicio;
        private System.Windows.Forms.DataGridView dataGridViewCategorias;
        private System.Windows.Forms.Label label1;
    }
}