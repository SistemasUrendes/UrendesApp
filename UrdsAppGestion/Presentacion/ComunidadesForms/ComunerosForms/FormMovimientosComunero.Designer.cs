namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    partial class FormMovimientosComunero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMovimientosComunero));
            this.dataGridView_movimientos = new System.Windows.Forms.DataGridView();
            this.dataGridView_detallesmov = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button_imprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_movimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detallesmov)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_movimientos
            // 
            this.dataGridView_movimientos.AllowUserToAddRows = false;
            this.dataGridView_movimientos.AllowUserToDeleteRows = false;
            this.dataGridView_movimientos.AllowUserToResizeRows = false;
            this.dataGridView_movimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_movimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_movimientos.Location = new System.Drawing.Point(12, 43);
            this.dataGridView_movimientos.Name = "dataGridView_movimientos";
            this.dataGridView_movimientos.ReadOnly = true;
            this.dataGridView_movimientos.RowHeadersVisible = false;
            this.dataGridView_movimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_movimientos.Size = new System.Drawing.Size(720, 200);
            this.dataGridView_movimientos.TabIndex = 0;
            this.dataGridView_movimientos.SelectionChanged += new System.EventHandler(this.dataGridView_movimientos_SelectionChanged);
            // 
            // dataGridView_detallesmov
            // 
            this.dataGridView_detallesmov.AllowUserToAddRows = false;
            this.dataGridView_detallesmov.AllowUserToDeleteRows = false;
            this.dataGridView_detallesmov.AllowUserToResizeRows = false;
            this.dataGridView_detallesmov.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_detallesmov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_detallesmov.Location = new System.Drawing.Point(12, 276);
            this.dataGridView_detallesmov.Name = "dataGridView_detallesmov";
            this.dataGridView_detallesmov.ReadOnly = true;
            this.dataGridView_detallesmov.RowHeadersVisible = false;
            this.dataGridView_detallesmov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_detallesmov.Size = new System.Drawing.Size(720, 116);
            this.dataGridView_detallesmov.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Detalles del Movimiento: ";
            // 
            // button_imprimir
            // 
            this.button_imprimir.Location = new System.Drawing.Point(624, 14);
            this.button_imprimir.Name = "button_imprimir";
            this.button_imprimir.Size = new System.Drawing.Size(108, 23);
            this.button_imprimir.TabIndex = 3;
            this.button_imprimir.Text = "Imprimir Informe";
            this.button_imprimir.UseVisualStyleBackColor = true;
            this.button_imprimir.Click += new System.EventHandler(this.button_imprimir_Click);
            // 
            // FormMovimientosComunero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 414);
            this.Controls.Add(this.button_imprimir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_detallesmov);
            this.Controls.Add(this.dataGridView_movimientos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMovimientosComunero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos Comunero";
            this.Load += new System.EventHandler(this.FormMovimientosComunero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_movimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_detallesmov)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_movimientos;
        private System.Windows.Forms.DataGridView dataGridView_detallesmov;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_imprimir;
    }
}