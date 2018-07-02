namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    partial class FormVerInformeJunta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerInformeJunta));
            this.buttonImprimirInforme = new System.Windows.Forms.Button();
            this.labelBloque = new System.Windows.Forms.Label();
            this.dataGridViewInforme = new System.Windows.Forms.DataGridView();
            this.labelElementos = new System.Windows.Forms.Label();
            this.labelCuotaTotal = new System.Windows.Forms.Label();
            this.buttonCopiarPortapapeles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInforme)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImprimirInforme
            // 
            this.buttonImprimirInforme.Location = new System.Drawing.Point(828, 13);
            this.buttonImprimirInforme.Name = "buttonImprimirInforme";
            this.buttonImprimirInforme.Size = new System.Drawing.Size(98, 23);
            this.buttonImprimirInforme.TabIndex = 1;
            this.buttonImprimirInforme.Text = "Imprimir Informe";
            this.buttonImprimirInforme.UseVisualStyleBackColor = true;
            this.buttonImprimirInforme.Click += new System.EventHandler(this.buttonImprimirInforme_Click);
            // 
            // labelBloque
            // 
            this.labelBloque.AutoSize = true;
            this.labelBloque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBloque.Location = new System.Drawing.Point(12, 18);
            this.labelBloque.Name = "labelBloque";
            this.labelBloque.Size = new System.Drawing.Size(0, 13);
            this.labelBloque.TabIndex = 2;
            // 
            // dataGridViewInforme
            // 
            this.dataGridViewInforme.AllowUserToAddRows = false;
            this.dataGridViewInforme.AllowUserToDeleteRows = false;
            this.dataGridViewInforme.AllowUserToOrderColumns = true;
            this.dataGridViewInforme.AllowUserToResizeRows = false;
            this.dataGridViewInforme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInforme.Location = new System.Drawing.Point(15, 42);
            this.dataGridViewInforme.Name = "dataGridViewInforme";
            this.dataGridViewInforme.ReadOnly = true;
            this.dataGridViewInforme.RowHeadersVisible = false;
            this.dataGridViewInforme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInforme.Size = new System.Drawing.Size(911, 665);
            this.dataGridViewInforme.TabIndex = 3;
            this.dataGridViewInforme.TabStop = false;
            // 
            // labelElementos
            // 
            this.labelElementos.AutoSize = true;
            this.labelElementos.Location = new System.Drawing.Point(12, 724);
            this.labelElementos.Name = "labelElementos";
            this.labelElementos.Size = new System.Drawing.Size(0, 13);
            this.labelElementos.TabIndex = 4;
            // 
            // labelCuotaTotal
            // 
            this.labelCuotaTotal.AutoSize = true;
            this.labelCuotaTotal.Location = new System.Drawing.Point(840, 724);
            this.labelCuotaTotal.Name = "labelCuotaTotal";
            this.labelCuotaTotal.Size = new System.Drawing.Size(0, 13);
            this.labelCuotaTotal.TabIndex = 5;
            // 
            // buttonCopiarPortapapeles
            // 
            this.buttonCopiarPortapapeles.Location = new System.Drawing.Point(706, 13);
            this.buttonCopiarPortapapeles.Name = "buttonCopiarPortapapeles";
            this.buttonCopiarPortapapeles.Size = new System.Drawing.Size(116, 23);
            this.buttonCopiarPortapapeles.TabIndex = 6;
            this.buttonCopiarPortapapeles.Text = "Copiar Portapapeles";
            this.buttonCopiarPortapapeles.UseVisualStyleBackColor = true;
            this.buttonCopiarPortapapeles.Click += new System.EventHandler(this.buttonCopiarPortapapeles_Click);
            // 
            // FormVerInformeJunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 752);
            this.Controls.Add(this.buttonCopiarPortapapeles);
            this.Controls.Add(this.labelCuotaTotal);
            this.Controls.Add(this.labelElementos);
            this.Controls.Add(this.dataGridViewInforme);
            this.Controls.Add(this.labelBloque);
            this.Controls.Add(this.buttonImprimirInforme);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerInformeJunta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe Junta";
            this.Load += new System.EventHandler(this.FormVerInformeJunta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInforme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonImprimirInforme;
        private System.Windows.Forms.Label labelBloque;
        private System.Windows.Forms.DataGridView dataGridViewInforme;
        private System.Windows.Forms.Label labelElementos;
        private System.Windows.Forms.Label labelCuotaTotal;
        private System.Windows.Forms.Button buttonCopiarPortapapeles;
    }
}