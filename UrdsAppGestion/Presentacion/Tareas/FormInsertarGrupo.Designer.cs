namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormInsertarGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInsertarGrupo));
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.dataGridViewContactos = new System.Windows.Forms.DataGridView();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxComunidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.dataGridViewGrupo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContactos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(506, 287);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 0;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // dataGridViewContactos
            // 
            this.dataGridViewContactos.AllowUserToAddRows = false;
            this.dataGridViewContactos.AllowUserToDeleteRows = false;
            this.dataGridViewContactos.AllowUserToResizeRows = false;
            this.dataGridViewContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContactos.Location = new System.Drawing.Point(12, 44);
            this.dataGridViewContactos.MultiSelect = false;
            this.dataGridViewContactos.Name = "dataGridViewContactos";
            this.dataGridViewContactos.ReadOnly = true;
            this.dataGridViewContactos.RowHeadersVisible = false;
            this.dataGridViewContactos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContactos.ShowCellErrors = false;
            this.dataGridViewContactos.ShowCellToolTips = false;
            this.dataGridViewContactos.ShowEditingIcon = false;
            this.dataGridViewContactos.ShowRowErrors = false;
            this.dataGridViewContactos.Size = new System.Drawing.Size(302, 237);
            this.dataGridViewContactos.TabIndex = 2;
            this.dataGridViewContactos.TabStop = false;
            this.dataGridViewContactos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContactos_CellDoubleClick);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(109, 18);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(205, 20);
            this.textBoxNombre.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre del grupo:";
            // 
            // comboBoxComunidad
            // 
            this.comboBoxComunidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComunidad.FormattingEnabled = true;
            this.comboBoxComunidad.Location = new System.Drawing.Point(426, 17);
            this.comboBoxComunidad.Name = "comboBoxComunidad";
            this.comboBoxComunidad.Size = new System.Drawing.Size(236, 21);
            this.comboBoxComunidad.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Comunidad:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(587, 287);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(320, 124);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(34, 21);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = ">>";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(320, 151);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(34, 21);
            this.buttonRemove.TabIndex = 10;
            this.buttonRemove.Text = "<<";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // dataGridViewGrupo
            // 
            this.dataGridViewGrupo.AllowUserToAddRows = false;
            this.dataGridViewGrupo.AllowUserToDeleteRows = false;
            this.dataGridViewGrupo.AllowUserToResizeRows = false;
            this.dataGridViewGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGrupo.Location = new System.Drawing.Point(360, 44);
            this.dataGridViewGrupo.MultiSelect = false;
            this.dataGridViewGrupo.Name = "dataGridViewGrupo";
            this.dataGridViewGrupo.ReadOnly = true;
            this.dataGridViewGrupo.RowHeadersVisible = false;
            this.dataGridViewGrupo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGrupo.ShowCellErrors = false;
            this.dataGridViewGrupo.ShowCellToolTips = false;
            this.dataGridViewGrupo.ShowEditingIcon = false;
            this.dataGridViewGrupo.ShowRowErrors = false;
            this.dataGridViewGrupo.Size = new System.Drawing.Size(302, 237);
            this.dataGridViewGrupo.TabIndex = 11;
            this.dataGridViewGrupo.TabStop = false;
            this.dataGridViewGrupo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGrupo_CellDoubleClick);
            // 
            // FormInsertarGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 322);
            this.Controls.Add(this.dataGridViewGrupo);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxComunidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.dataGridViewContactos);
            this.Controls.Add(this.buttonGuardar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInsertarGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInsertarGrupo";
            this.Load += new System.EventHandler(this.FormInsertarGrupo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContactos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.DataGridView dataGridViewContactos;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxComunidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.DataGridView dataGridViewGrupo;
    }
}