namespace UrdsAppGestión.Presentacion.ComunidadesForms.BloquesForms
{
    partial class FormCambiarPartes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCambiarPartes));
            this.comboBox_tiposDivision = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_valor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_partes = new System.Windows.Forms.ListBox();
            this.button_anyadir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_calcular = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_tiposDivision
            // 
            this.comboBox_tiposDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tiposDivision.FormattingEnabled = true;
            this.comboBox_tiposDivision.Location = new System.Drawing.Point(137, 18);
            this.comboBox_tiposDivision.Name = "comboBox_tiposDivision";
            this.comboBox_tiposDivision.Size = new System.Drawing.Size(121, 21);
            this.comboBox_tiposDivision.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipos División: ";
            // 
            // textBox_valor
            // 
            this.textBox_valor.Location = new System.Drawing.Point(137, 51);
            this.textBox_valor.Name = "textBox_valor";
            this.textBox_valor.Size = new System.Drawing.Size(36, 20);
            this.textBox_valor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor: ";
            // 
            // listBox_partes
            // 
            this.listBox_partes.FormattingEnabled = true;
            this.listBox_partes.Location = new System.Drawing.Point(65, 142);
            this.listBox_partes.MultiColumn = true;
            this.listBox_partes.Name = "listBox_partes";
            this.listBox_partes.Size = new System.Drawing.Size(189, 95);
            this.listBox_partes.TabIndex = 4;
            // 
            // button_anyadir
            // 
            this.button_anyadir.Location = new System.Drawing.Point(115, 88);
            this.button_anyadir.Name = "button_anyadir";
            this.button_anyadir.Size = new System.Drawing.Size(92, 23);
            this.button_anyadir.TabIndex = 5;
            this.button_anyadir.Text = "Añadir";
            this.button_anyadir.UseVisualStyleBackColor = true;
            this.button_anyadir.Click += new System.EventHandler(this.button_anyadir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "____________________________________________________";
            // 
            // button_calcular
            // 
            this.button_calcular.Location = new System.Drawing.Point(143, 253);
            this.button_calcular.Name = "button_calcular";
            this.button_calcular.Size = new System.Drawing.Size(75, 23);
            this.button_calcular.TabIndex = 7;
            this.button_calcular.Text = "Calcular";
            this.button_calcular.UseVisualStyleBackColor = true;
            this.button_calcular.Click += new System.EventHandler(this.button_calcular_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(225, 253);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_cancelar.TabIndex = 8;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // FormCambiarPartes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 288);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_calcular);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_anyadir);
            this.Controls.Add(this.listBox_partes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_valor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_tiposDivision);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCambiarPartes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Partes";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCambiarPartes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_tiposDivision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_valor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_partes;
        private System.Windows.Forms.Button button_anyadir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_calcular;
        private System.Windows.Forms.Button button_cancelar;
    }
}