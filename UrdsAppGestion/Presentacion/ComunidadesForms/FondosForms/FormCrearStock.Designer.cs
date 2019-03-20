namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms
{
    partial class FormCrearStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrearStock));
            this.dataGridView_stocks = new System.Windows.Forms.DataGridView();
            this.button_crear = new System.Windows.Forms.Button();
            this.button_cerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.textBox_valor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stocks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_stocks
            // 
            this.dataGridView_stocks.AllowUserToAddRows = false;
            this.dataGridView_stocks.AllowUserToDeleteRows = false;
            this.dataGridView_stocks.AllowUserToResizeColumns = false;
            this.dataGridView_stocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_stocks.Location = new System.Drawing.Point(20, 102);
            this.dataGridView_stocks.MultiSelect = false;
            this.dataGridView_stocks.Name = "dataGridView_stocks";
            this.dataGridView_stocks.RowHeadersVisible = false;
            this.dataGridView_stocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_stocks.Size = new System.Drawing.Size(335, 150);
            this.dataGridView_stocks.TabIndex = 0;
            // 
            // button_crear
            // 
            this.button_crear.Location = new System.Drawing.Point(286, 17);
            this.button_crear.Name = "button_crear";
            this.button_crear.Size = new System.Drawing.Size(69, 57);
            this.button_crear.TabIndex = 1;
            this.button_crear.Text = "Crear";
            this.button_crear.UseVisualStyleBackColor = true;
            this.button_crear.Click += new System.EventHandler(this.button_crear_Click);
            // 
            // button_cerrar
            // 
            this.button_cerrar.Location = new System.Drawing.Point(279, 271);
            this.button_cerrar.Name = "button_cerrar";
            this.button_cerrar.Size = new System.Drawing.Size(75, 23);
            this.button_cerrar.TabIndex = 3;
            this.button_cerrar.Text = "Cerrar";
            this.button_cerrar.UseVisualStyleBackColor = true;
            this.button_cerrar.Click += new System.EventHandler(this.button_cerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Valor : ";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(76, 17);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(131, 20);
            this.textBox_nombre.TabIndex = 6;
            // 
            // textBox_valor
            // 
            this.textBox_valor.Location = new System.Drawing.Point(76, 48);
            this.textBox_valor.Name = "textBox_valor";
            this.textBox_valor.Size = new System.Drawing.Size(100, 20);
            this.textBox_valor.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(337, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "_______________________________________________________";
            // 
            // FormCrearStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 308);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_valor);
            this.Controls.Add(this.textBox_nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cerrar);
            this.Controls.Add(this.button_crear);
            this.Controls.Add(this.dataGridView_stocks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCrearStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Stock";
            this.Load += new System.EventHandler(this.FormCrearStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_stocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_stocks;
        private System.Windows.Forms.Button button_crear;
        private System.Windows.Forms.Button button_cerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.TextBox textBox_valor;
        private System.Windows.Forms.Label label3;
    }
}