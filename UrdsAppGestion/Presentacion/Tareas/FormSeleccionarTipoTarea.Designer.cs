namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormSeleccionarTipoTarea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeleccionarTipoTarea));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxFiltroCategorias = new System.Windows.Forms.TextBox();
            this.dataGridViewCategorias = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxFiltroTarea = new System.Windows.Forms.TextBox();
            this.buttonMantenimiento = new System.Windows.Forms.Button();
            this.dataGridViewTipoTarea = new System.Windows.Forms.DataGridView();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategorias)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoTarea)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxFiltroCategorias);
            this.groupBox3.Controls.Add(this.dataGridViewCategorias);
            this.groupBox3.Location = new System.Drawing.Point(12, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 418);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Categorías de Procedimientos";
            // 
            // textBoxFiltroCategorias
            // 
            this.textBoxFiltroCategorias.Location = new System.Drawing.Point(6, 19);
            this.textBoxFiltroCategorias.Name = "textBoxFiltroCategorias";
            this.textBoxFiltroCategorias.Size = new System.Drawing.Size(293, 20);
            this.textBoxFiltroCategorias.TabIndex = 3;
            this.textBoxFiltroCategorias.TextChanged += new System.EventHandler(this.textBoxFiltroCategorias_TextChanged);
            // 
            // dataGridViewCategorias
            // 
            this.dataGridViewCategorias.AllowUserToAddRows = false;
            this.dataGridViewCategorias.AllowUserToDeleteRows = false;
            this.dataGridViewCategorias.AllowUserToResizeRows = false;
            this.dataGridViewCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCategorias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategorias.Location = new System.Drawing.Point(6, 46);
            this.dataGridViewCategorias.Name = "dataGridViewCategorias";
            this.dataGridViewCategorias.ReadOnly = true;
            this.dataGridViewCategorias.RowHeadersVisible = false;
            this.dataGridViewCategorias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCategorias.ShowEditingIcon = false;
            this.dataGridViewCategorias.Size = new System.Drawing.Size(293, 350);
            this.dataGridViewCategorias.TabIndex = 0;
            this.dataGridViewCategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCategorias_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxFiltroTarea);
            this.groupBox2.Controls.Add(this.dataGridViewTipoTarea);
            this.groupBox2.Location = new System.Drawing.Point(346, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 418);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tareas con Procedimiento";
            // 
            // textBoxFiltroTarea
            // 
            this.textBoxFiltroTarea.Location = new System.Drawing.Point(6, 19);
            this.textBoxFiltroTarea.Name = "textBoxFiltroTarea";
            this.textBoxFiltroTarea.Size = new System.Drawing.Size(293, 20);
            this.textBoxFiltroTarea.TabIndex = 3;
            this.textBoxFiltroTarea.TextChanged += new System.EventHandler(this.textBoxFiltroTarea_TextChanged);
            // 
            // buttonMantenimiento
            // 
            this.buttonMantenimiento.Location = new System.Drawing.Point(588, 12);
            this.buttonMantenimiento.Name = "buttonMantenimiento";
            this.buttonMantenimiento.Size = new System.Drawing.Size(86, 23);
            this.buttonMantenimiento.TabIndex = 2;
            this.buttonMantenimiento.Text = "Mantenimiento";
            this.buttonMantenimiento.UseVisualStyleBackColor = true;
            this.buttonMantenimiento.Click += new System.EventHandler(this.buttonMantenimiento_Click);
            // 
            // dataGridViewTipoTarea
            // 
            this.dataGridViewTipoTarea.AllowUserToAddRows = false;
            this.dataGridViewTipoTarea.AllowUserToDeleteRows = false;
            this.dataGridViewTipoTarea.AllowUserToResizeRows = false;
            this.dataGridViewTipoTarea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTipoTarea.Location = new System.Drawing.Point(6, 45);
            this.dataGridViewTipoTarea.Name = "dataGridViewTipoTarea";
            this.dataGridViewTipoTarea.ReadOnly = true;
            this.dataGridViewTipoTarea.RowHeadersVisible = false;
            this.dataGridViewTipoTarea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewTipoTarea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTipoTarea.ShowEditingIcon = false;
            this.dataGridViewTipoTarea.Size = new System.Drawing.Size(293, 350);
            this.dataGridViewTipoTarea.TabIndex = 0;
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Location = new System.Drawing.Point(464, 12);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(86, 23);
            this.buttonEnviar.TabIndex = 8;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // FormSeleccionarTipoTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 480);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonMantenimiento);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSeleccionarTipoTarea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Tipo Tareas";
            this.Load += new System.EventHandler(this.FormSeleccionarTipoTarea_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategorias)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTipoTarea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxFiltroCategorias;
        private System.Windows.Forms.DataGridView dataGridViewCategorias;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxFiltroTarea;
        private System.Windows.Forms.Button buttonMantenimiento;
        private System.Windows.Forms.DataGridView dataGridViewTipoTarea;
        private System.Windows.Forms.Button buttonEnviar;
    }
}