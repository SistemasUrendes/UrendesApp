namespace UrdsAppGestión.Presentacion.ComunidadesForms.BloquesForms
{
    partial class FormBloquesAlta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBloquesAlta));
            this.textBox_Bloque = new System.Windows.Forms.TextBox();
            this.checkBox_GG = new System.Windows.Forms.CheckBox();
            this.checkBox_Desactivado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comboBox_tipoCalculo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Bloque
            // 
            this.textBox_Bloque.Location = new System.Drawing.Point(84, 30);
            this.textBox_Bloque.Name = "textBox_Bloque";
            this.textBox_Bloque.Size = new System.Drawing.Size(192, 20);
            this.textBox_Bloque.TabIndex = 0;
            // 
            // checkBox_GG
            // 
            this.checkBox_GG.AutoSize = true;
            this.checkBox_GG.Location = new System.Drawing.Point(84, 101);
            this.checkBox_GG.Name = "checkBox_GG";
            this.checkBox_GG.Size = new System.Drawing.Size(110, 17);
            this.checkBox_GG.TabIndex = 1;
            this.checkBox_GG.Text = "Gastos Generales";
            this.checkBox_GG.UseVisualStyleBackColor = true;
            this.checkBox_GG.CheckedChanged += new System.EventHandler(this.checkBox_GG_CheckedChanged);
            // 
            // checkBox_Desactivado
            // 
            this.checkBox_Desactivado.AutoSize = true;
            this.checkBox_Desactivado.Location = new System.Drawing.Point(200, 101);
            this.checkBox_Desactivado.Name = "checkBox_Desactivado";
            this.checkBox_Desactivado.Size = new System.Drawing.Size(86, 17);
            this.checkBox_Desactivado.TabIndex = 2;
            this.checkBox_Desactivado.Text = "Desactivado";
            this.checkBox_Desactivado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bloque:";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(101, 124);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 23);
            this.button_Guardar.TabIndex = 4;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(182, 124);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 5;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // comboBox_tipoCalculo
            // 
            this.comboBox_tipoCalculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tipoCalculo.FormattingEnabled = true;
            this.comboBox_tipoCalculo.Location = new System.Drawing.Point(84, 63);
            this.comboBox_tipoCalculo.Name = "comboBox_tipoCalculo";
            this.comboBox_tipoCalculo.Size = new System.Drawing.Size(126, 21);
            this.comboBox_tipoCalculo.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cálculo: ";
            // 
            // FormBloquesAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 159);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_tipoCalculo);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Desactivado);
            this.Controls.Add(this.checkBox_GG);
            this.Controls.Add(this.textBox_Bloque);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBloquesAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edición de Bloques";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormBloquesAlta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Bloque;
        private System.Windows.Forms.CheckBox checkBox_GG;
        private System.Windows.Forms.CheckBox checkBox_Desactivado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox comboBox_tipoCalculo;
        private System.Windows.Forms.Label label2;
    }
}