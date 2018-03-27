namespace UrdsAppGestión.Presentacion.ComunidadesForms.BloquesForms
{
    partial class FormBloquesDetalles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBloquesDetalles));
            this.dataGridView_DetallesBloque = new System.Windows.Forms.DataGridView();
            this.button_Importar = new System.Windows.Forms.Button();
            this.button_Borrar = new System.Windows.Forms.Button();
            this.button_Coeficiente = new System.Windows.Forms.Button();
            this.button_partes = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label_total = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cambiarSubcuotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_cuotas = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_partes = new System.Windows.Forms.Label();
            this.button_cambiarPartes = new System.Windows.Forms.Button();
            this.button_manual = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DetallesBloque)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_DetallesBloque
            // 
            this.dataGridView_DetallesBloque.AllowUserToAddRows = false;
            this.dataGridView_DetallesBloque.AllowUserToDeleteRows = false;
            this.dataGridView_DetallesBloque.AllowUserToOrderColumns = true;
            this.dataGridView_DetallesBloque.AllowUserToResizeRows = false;
            this.dataGridView_DetallesBloque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DetallesBloque.Location = new System.Drawing.Point(24, 41);
            this.dataGridView_DetallesBloque.Name = "dataGridView_DetallesBloque";
            this.dataGridView_DetallesBloque.ReadOnly = true;
            this.dataGridView_DetallesBloque.RowHeadersVisible = false;
            this.dataGridView_DetallesBloque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_DetallesBloque.Size = new System.Drawing.Size(562, 306);
            this.dataGridView_DetallesBloque.TabIndex = 1;
            this.dataGridView_DetallesBloque.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_DetallesBloque_RowsAdded);
            this.dataGridView_DetallesBloque.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_DetallesBloque_KeyDown);
            this.dataGridView_DetallesBloque.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_DetallesBloque_MouseClick);
            // 
            // button_Importar
            // 
            this.button_Importar.Location = new System.Drawing.Point(24, 12);
            this.button_Importar.Name = "button_Importar";
            this.button_Importar.Size = new System.Drawing.Size(75, 23);
            this.button_Importar.TabIndex = 2;
            this.button_Importar.Text = "Añadir";
            this.button_Importar.UseVisualStyleBackColor = true;
            this.button_Importar.Click += new System.EventHandler(this.button_Importar_Click);
            // 
            // button_Borrar
            // 
            this.button_Borrar.Location = new System.Drawing.Point(105, 12);
            this.button_Borrar.Name = "button_Borrar";
            this.button_Borrar.Size = new System.Drawing.Size(75, 23);
            this.button_Borrar.TabIndex = 4;
            this.button_Borrar.Text = "Borrar";
            this.button_Borrar.UseVisualStyleBackColor = true;
            this.button_Borrar.Click += new System.EventHandler(this.button_Borrar_Click);
            // 
            // button_Coeficiente
            // 
            this.button_Coeficiente.Location = new System.Drawing.Point(511, 12);
            this.button_Coeficiente.Name = "button_Coeficiente";
            this.button_Coeficiente.Size = new System.Drawing.Size(75, 23);
            this.button_Coeficiente.TabIndex = 5;
            this.button_Coeficiente.Text = "Calcular";
            this.button_Coeficiente.UseVisualStyleBackColor = true;
            this.button_Coeficiente.Click += new System.EventHandler(this.button_Coeficiente_Click);
            // 
            // button_partes
            // 
            this.button_partes.Location = new System.Drawing.Point(198, 12);
            this.button_partes.Name = "button_partes";
            this.button_partes.Size = new System.Drawing.Size(98, 23);
            this.button_partes.TabIndex = 6;
            this.button_partes.Text = "Calcular Iguales";
            this.button_partes.UseVisualStyleBackColor = true;
            this.button_partes.Visible = false;
            this.button_partes.Click += new System.EventHandler(this.button_Iguales_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(430, 383);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Guardar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(511, 383);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Cancelar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_total.Location = new System.Drawing.Point(471, 354);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(58, 13);
            this.label_total.TabIndex = 10;
            this.label_total.Text = "Subcuotas";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarSubcuotaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 26);
            // 
            // cambiarSubcuotaToolStripMenuItem
            // 
            this.cambiarSubcuotaToolStripMenuItem.Name = "cambiarSubcuotaToolStripMenuItem";
            this.cambiarSubcuotaToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cambiarSubcuotaToolStripMenuItem.Text = "Cambiar Subcuota";
            this.cambiarSubcuotaToolStripMenuItem.Click += new System.EventHandler(this.cambiarSubcuotaToolStripMenuItem_Click);
            // 
            // label_cuotas
            // 
            this.label_cuotas.AutoSize = true;
            this.label_cuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cuotas.Location = new System.Drawing.Point(256, 354);
            this.label_cuotas.Name = "label_cuotas";
            this.label_cuotas.Size = new System.Drawing.Size(40, 13);
            this.label_cuotas.TabIndex = 12;
            this.label_cuotas.Text = "Cuotas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(160, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Se han realizado modificaciones";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Total :";
            // 
            // label_partes
            // 
            this.label_partes.AutoSize = true;
            this.label_partes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_partes.Location = new System.Drawing.Point(374, 354);
            this.label_partes.Name = "label_partes";
            this.label_partes.Size = new System.Drawing.Size(37, 13);
            this.label_partes.TabIndex = 15;
            this.label_partes.Text = "Partes";
            // 
            // button_cambiarPartes
            // 
            this.button_cambiarPartes.Location = new System.Drawing.Point(302, 12);
            this.button_cambiarPartes.Name = "button_cambiarPartes";
            this.button_cambiarPartes.Size = new System.Drawing.Size(100, 23);
            this.button_cambiarPartes.TabIndex = 16;
            this.button_cambiarPartes.Text = "Cambiar Partes";
            this.button_cambiarPartes.UseVisualStyleBackColor = true;
            this.button_cambiarPartes.Visible = false;
            this.button_cambiarPartes.Click += new System.EventHandler(this.button_cambiarPartes_Click);
            // 
            // button_manual
            // 
            this.button_manual.Location = new System.Drawing.Point(511, 12);
            this.button_manual.Name = "button_manual";
            this.button_manual.Size = new System.Drawing.Size(75, 23);
            this.button_manual.TabIndex = 17;
            this.button_manual.Text = "Manual";
            this.button_manual.UseVisualStyleBackColor = true;
            this.button_manual.Click += new System.EventHandler(this.button_manual_Click);
            // 
            // FormBloquesDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 421);
            this.Controls.Add(this.button_manual);
            this.Controls.Add(this.button_cambiarPartes);
            this.Controls.Add(this.label_partes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_cuotas);
            this.Controls.Add(this.label_total);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button_partes);
            this.Controls.Add(this.button_Coeficiente);
            this.Controls.Add(this.button_Borrar);
            this.Controls.Add(this.button_Importar);
            this.Controls.Add(this.dataGridView_DetallesBloque);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBloquesDetalles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bloques Detalles";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormBloquesDetalles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DetallesBloque)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_DetallesBloque;
        private System.Windows.Forms.Button button_Importar;
        private System.Windows.Forms.Button button_Borrar;
        private System.Windows.Forms.Button button_Coeficiente;
        private System.Windows.Forms.Button button_partes;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label_cuotas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem cambiarSubcuotaToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_partes;
        private System.Windows.Forms.Button button_cambiarPartes;
        private System.Windows.Forms.Button button_manual;
    }
}