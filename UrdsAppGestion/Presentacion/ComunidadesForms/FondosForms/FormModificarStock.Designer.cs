namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms
{
    partial class FormModificarStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModificarStock));
            this.dataGridView_stock = new System.Windows.Forms.DataGridView();
            this.button_guardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stock)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_stock
            // 
            this.dataGridView_stock.AllowUserToAddRows = false;
            this.dataGridView_stock.AllowUserToDeleteRows = false;
            this.dataGridView_stock.AllowUserToResizeRows = false;
            this.dataGridView_stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_stock.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_stock.Name = "dataGridView_stock";
            this.dataGridView_stock.RowHeadersVisible = false;
            this.dataGridView_stock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_stock.Size = new System.Drawing.Size(267, 150);
            this.dataGridView_stock.TabIndex = 0;
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(204, 168);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 1;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // FormModificarStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 200);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.dataGridView_stock);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormModificarStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Stock";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormModificarStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_stock;
        private System.Windows.Forms.Button button_guardar;
    }
}