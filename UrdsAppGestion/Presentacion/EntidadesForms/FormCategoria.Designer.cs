namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    partial class FormCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCategoria));
            this.button1 = new System.Windows.Forms.Button();
            this.listBox_categorias = new System.Windows.Forms.ListBox();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 500);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Guardar y Volver";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBox_categorias
            // 
            this.listBox_categorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_categorias.FormattingEnabled = true;
            this.listBox_categorias.ItemHeight = 16;
            this.listBox_categorias.Location = new System.Drawing.Point(19, 87);
            this.listBox_categorias.Name = "listBox_categorias";
            this.listBox_categorias.Size = new System.Drawing.Size(265, 404);
            this.listBox_categorias.TabIndex = 1;
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(19, 42);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(265, 20);
            this.textBox_buscar.TabIndex = 0;
            this.textBox_buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_buscar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar :";
            // 
            // FormCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 533);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.listBox_categorias);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categoria";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCategoria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox_categorias;
        private System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.Label label1;
    }
}