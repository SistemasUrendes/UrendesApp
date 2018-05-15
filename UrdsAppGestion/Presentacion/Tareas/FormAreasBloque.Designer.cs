namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormAreasBloque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAreasBloque));
            this.buttonRemoveArea = new System.Windows.Forms.Button();
            this.buttonAddArea = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxFiltroAreas = new System.Windows.Forms.TextBox();
            this.dataGridViewAddArea = new System.Windows.Forms.DataGridView();
            this.dataGridViewAllAreas = new System.Windows.Forms.DataGridView();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllAreas)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRemoveArea
            // 
            this.buttonRemoveArea.Location = new System.Drawing.Point(314, 228);
            this.buttonRemoveArea.Name = "buttonRemoveArea";
            this.buttonRemoveArea.Size = new System.Drawing.Size(28, 23);
            this.buttonRemoveArea.TabIndex = 20;
            this.buttonRemoveArea.Text = ">>";
            this.buttonRemoveArea.UseVisualStyleBackColor = true;
            this.buttonRemoveArea.Click += new System.EventHandler(this.buttonRemoveArea_Click);
            // 
            // buttonAddArea
            // 
            this.buttonAddArea.Location = new System.Drawing.Point(314, 199);
            this.buttonAddArea.Name = "buttonAddArea";
            this.buttonAddArea.Size = new System.Drawing.Size(28, 23);
            this.buttonAddArea.TabIndex = 19;
            this.buttonAddArea.Text = "<<";
            this.buttonAddArea.UseVisualStyleBackColor = true;
            this.buttonAddArea.Click += new System.EventHandler(this.buttonAddArea_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(10, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 17);
            this.labelName.TabIndex = 15;
            // 
            // textBoxFiltroAreas
            // 
            this.textBoxFiltroAreas.Location = new System.Drawing.Point(348, 12);
            this.textBoxFiltroAreas.Name = "textBoxFiltroAreas";
            this.textBoxFiltroAreas.Size = new System.Drawing.Size(300, 20);
            this.textBoxFiltroAreas.TabIndex = 13;
            this.textBoxFiltroAreas.TextChanged += new System.EventHandler(this.textBoxFiltroAreas_TextChanged);
            // 
            // dataGridViewAddArea
            // 
            this.dataGridViewAddArea.AllowUserToAddRows = false;
            this.dataGridViewAddArea.AllowUserToDeleteRows = false;
            this.dataGridViewAddArea.AllowUserToResizeRows = false;
            this.dataGridViewAddArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddArea.Location = new System.Drawing.Point(9, 38);
            this.dataGridViewAddArea.MultiSelect = false;
            this.dataGridViewAddArea.Name = "dataGridViewAddArea";
            this.dataGridViewAddArea.ReadOnly = true;
            this.dataGridViewAddArea.RowHeadersVisible = false;
            this.dataGridViewAddArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAddArea.Size = new System.Drawing.Size(300, 343);
            this.dataGridViewAddArea.TabIndex = 12;
            this.dataGridViewAddArea.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAddArea_CellDoubleClick);
            // 
            // dataGridViewAllAreas
            // 
            this.dataGridViewAllAreas.AllowUserToAddRows = false;
            this.dataGridViewAllAreas.AllowUserToDeleteRows = false;
            this.dataGridViewAllAreas.AllowUserToResizeRows = false;
            this.dataGridViewAllAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllAreas.Location = new System.Drawing.Point(348, 38);
            this.dataGridViewAllAreas.MultiSelect = false;
            this.dataGridViewAllAreas.Name = "dataGridViewAllAreas";
            this.dataGridViewAllAreas.ReadOnly = true;
            this.dataGridViewAllAreas.RowHeadersVisible = false;
            this.dataGridViewAllAreas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAllAreas.Size = new System.Drawing.Size(300, 343);
            this.dataGridViewAllAreas.TabIndex = 11;
            this.dataGridViewAllAreas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAllAreas_CellDoubleClick);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(572, 399);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 21;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(491, 399);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 22;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // FormAreasBloque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 442);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonRemoveArea);
            this.Controls.Add(this.buttonAddArea);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxFiltroAreas);
            this.Controls.Add(this.dataGridViewAddArea);
            this.Controls.Add(this.dataGridViewAllAreas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAreasBloque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Areas del Bloque";
            this.Load += new System.EventHandler(this.FormAreasBloque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllAreas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRemoveArea;
        private System.Windows.Forms.Button buttonAddArea;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxFiltroAreas;
        private System.Windows.Forms.DataGridView dataGridViewAddArea;
        private System.Windows.Forms.DataGridView dataGridViewAllAreas;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGuardar;
    }
}