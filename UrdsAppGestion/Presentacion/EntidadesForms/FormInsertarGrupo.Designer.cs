namespace UrdsAppGestión.Presentacion.EntidadesForms
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
            this.dataGridViewGrupo = new System.Windows.Forms.DataGridView();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxComunidad = new System.Windows.Forms.ComboBox();
            this.labelGrupo = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.dataGridViewContactos = new System.Windows.Forms.DataGridView();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.textBoxfiltroTodas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxGrupos = new System.Windows.Forms.ComboBox();
            this.buttonNuevoGrupo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContactos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGrupo
            // 
            this.dataGridViewGrupo.AllowUserToAddRows = false;
            this.dataGridViewGrupo.AllowUserToDeleteRows = false;
            this.dataGridViewGrupo.AllowUserToResizeRows = false;
            this.dataGridViewGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGrupo.Location = new System.Drawing.Point(363, 126);
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
            this.dataGridViewGrupo.TabIndex = 21;
            this.dataGridViewGrupo.TabStop = false;
            this.dataGridViewGrupo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGrupo_CellDoubleClick);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(323, 233);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(34, 21);
            this.buttonRemove.TabIndex = 20;
            this.buttonRemove.Text = "<<";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(323, 206);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(34, 21);
            this.buttonAdd.TabIndex = 19;
            this.buttonAdd.Text = ">>";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(590, 369);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 18;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Comunidad:";
            // 
            // comboBoxComunidad
            // 
            this.comboBoxComunidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComunidad.FormattingEnabled = true;
            this.comboBoxComunidad.Location = new System.Drawing.Point(81, 20);
            this.comboBoxComunidad.Name = "comboBoxComunidad";
            this.comboBoxComunidad.Size = new System.Drawing.Size(236, 21);
            this.comboBoxComunidad.TabIndex = 16;
            this.comboBoxComunidad.SelectionChangeCommitted += new System.EventHandler(this.comboBoxComunidad_SelectionChangeCommitted);
            // 
            // labelGrupo
            // 
            this.labelGrupo.AutoSize = true;
            this.labelGrupo.Location = new System.Drawing.Point(360, 62);
            this.labelGrupo.Name = "labelGrupo";
            this.labelGrupo.Size = new System.Drawing.Size(74, 13);
            this.labelGrupo.TabIndex = 15;
            this.labelGrupo.Text = "Nuevo Grupo:";
            this.labelGrupo.Visible = false;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(440, 59);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(225, 20);
            this.textBoxNombre.TabIndex = 14;
            this.textBoxNombre.Visible = false;
            // 
            // dataGridViewContactos
            // 
            this.dataGridViewContactos.AllowUserToAddRows = false;
            this.dataGridViewContactos.AllowUserToDeleteRows = false;
            this.dataGridViewContactos.AllowUserToResizeRows = false;
            this.dataGridViewContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContactos.Location = new System.Drawing.Point(15, 126);
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
            this.dataGridViewContactos.TabIndex = 13;
            this.dataGridViewContactos.TabStop = false;
            this.dataGridViewContactos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContactos_CellDoubleClick);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(509, 369);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 12;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // textBoxfiltroTodas
            // 
            this.textBoxfiltroTodas.Location = new System.Drawing.Point(15, 100);
            this.textBoxfiltroTodas.Name = "textBoxfiltroTodas";
            this.textBoxfiltroTodas.Size = new System.Drawing.Size(302, 20);
            this.textBoxfiltroTodas.TabIndex = 22;
            this.textBoxfiltroTodas.TextChanged += new System.EventHandler(this.textBoxfiltroTodas_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Grupos:";
            // 
            // comboBoxGrupos
            // 
            this.comboBoxGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGrupos.FormattingEnabled = true;
            this.comboBoxGrupos.Location = new System.Drawing.Point(81, 59);
            this.comboBoxGrupos.Name = "comboBoxGrupos";
            this.comboBoxGrupos.Size = new System.Drawing.Size(236, 21);
            this.comboBoxGrupos.TabIndex = 24;
            this.comboBoxGrupos.SelectionChangeCommitted += new System.EventHandler(this.comboBoxGrupos_SelectionChangeCommitted);
            // 
            // buttonNuevoGrupo
            // 
            this.buttonNuevoGrupo.Location = new System.Drawing.Point(363, 19);
            this.buttonNuevoGrupo.Name = "buttonNuevoGrupo";
            this.buttonNuevoGrupo.Size = new System.Drawing.Size(110, 23);
            this.buttonNuevoGrupo.TabIndex = 26;
            this.buttonNuevoGrupo.Text = "Nuevo Grupo";
            this.buttonNuevoGrupo.UseVisualStyleBackColor = true;
            this.buttonNuevoGrupo.Click += new System.EventHandler(this.buttonNuevoGrupo_Click);
            // 
            // FormInsertarGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 410);
            this.Controls.Add(this.buttonNuevoGrupo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxGrupos);
            this.Controls.Add(this.textBoxfiltroTodas);
            this.Controls.Add(this.dataGridViewGrupo);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxComunidad);
            this.Controls.Add(this.labelGrupo);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.dataGridViewContactos);
            this.Controls.Add(this.buttonGuardar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInsertarGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormInsertarGrupo";
            this.Load += new System.EventHandler(this.FormInsertarGrupo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContactos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGrupo;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxComunidad;
        private System.Windows.Forms.Label labelGrupo;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.DataGridView dataGridViewContactos;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.TextBox textBoxfiltroTodas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxGrupos;
        private System.Windows.Forms.Button buttonNuevoGrupo;
    }
}