namespace UrdsAppGestión.Presentacion.ComunidadesForms.EjerciciosForms
{
    partial class Ejercicios
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ejercicios));
            this.dataGridView_Ejercicios = new System.Windows.Forms.DataGridView();
            this.button_Añadir = new System.Windows.Forms.Button();
            this.button_Borrar = new System.Windows.Forms.Button();
            this.button_Editar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.establecerPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Ejercicios)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Ejercicios
            // 
            this.dataGridView_Ejercicios.AllowUserToAddRows = false;
            this.dataGridView_Ejercicios.AllowUserToDeleteRows = false;
            this.dataGridView_Ejercicios.AllowUserToOrderColumns = true;
            this.dataGridView_Ejercicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Ejercicios.Location = new System.Drawing.Point(40, 54);
            this.dataGridView_Ejercicios.MultiSelect = false;
            this.dataGridView_Ejercicios.Name = "dataGridView_Ejercicios";
            this.dataGridView_Ejercicios.ReadOnly = true;
            this.dataGridView_Ejercicios.RowHeadersVisible = false;
            this.dataGridView_Ejercicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Ejercicios.Size = new System.Drawing.Size(920, 442);
            this.dataGridView_Ejercicios.TabIndex = 0;
            // 
            // button_Añadir
            // 
            this.button_Añadir.Location = new System.Drawing.Point(40, 25);
            this.button_Añadir.Name = "button_Añadir";
            this.button_Añadir.Size = new System.Drawing.Size(75, 23);
            this.button_Añadir.TabIndex = 1;
            this.button_Añadir.Text = "Añadir";
            this.button_Añadir.UseVisualStyleBackColor = true;
            this.button_Añadir.Click += new System.EventHandler(this.button_Añadir_Click);
            // 
            // button_Borrar
            // 
            this.button_Borrar.Enabled = false;
            this.button_Borrar.Location = new System.Drawing.Point(202, 25);
            this.button_Borrar.Name = "button_Borrar";
            this.button_Borrar.Size = new System.Drawing.Size(75, 23);
            this.button_Borrar.TabIndex = 2;
            this.button_Borrar.Text = "Borrar";
            this.button_Borrar.UseVisualStyleBackColor = true;
            this.button_Borrar.Visible = false;
            this.button_Borrar.Click += new System.EventHandler(this.button_Borrar_Click);
            // 
            // button_Editar
            // 
            this.button_Editar.Location = new System.Drawing.Point(121, 25);
            this.button_Editar.Name = "button_Editar";
            this.button_Editar.Size = new System.Drawing.Size(75, 23);
            this.button_Editar.TabIndex = 3;
            this.button_Editar.Text = "Editar";
            this.button_Editar.UseVisualStyleBackColor = true;
            this.button_Editar.Click += new System.EventHandler(this.button_Editar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.establecerPrincipalToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 26);
            // 
            // establecerPrincipalToolStripMenuItem
            // 
            this.establecerPrincipalToolStripMenuItem.Name = "establecerPrincipalToolStripMenuItem";
            this.establecerPrincipalToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.establecerPrincipalToolStripMenuItem.Text = "Establecer Principal";
            // 
            // Ejercicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 508);
            this.ControlBox = false;
            this.Controls.Add(this.button_Editar);
            this.Controls.Add(this.button_Borrar);
            this.Controls.Add(this.button_Añadir);
            this.Controls.Add(this.dataGridView_Ejercicios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ejercicios";
            this.Text = "Ejercicios";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Ejercicios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Ejercicios)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Ejercicios;
        private System.Windows.Forms.Button button_Añadir;
        private System.Windows.Forms.Button button_Borrar;
        private System.Windows.Forms.Button button_Editar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem establecerPrincipalToolStripMenuItem;
    }
}