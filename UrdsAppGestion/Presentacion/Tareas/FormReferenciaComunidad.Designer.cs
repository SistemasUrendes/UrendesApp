namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormReferenciaComunidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReferenciaComunidad));
            this.comboBoxComunidades = new System.Windows.Forms.ComboBox();
            this.textBoxReferencia = new System.Windows.Forms.TextBox();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxComunidades
            // 
            this.comboBoxComunidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComunidades.FormattingEnabled = true;
            this.comboBoxComunidades.Location = new System.Drawing.Point(72, 15);
            this.comboBoxComunidades.Name = "comboBoxComunidades";
            this.comboBoxComunidades.Size = new System.Drawing.Size(176, 21);
            this.comboBoxComunidades.TabIndex = 0;
            this.comboBoxComunidades.SelectionChangeCommitted += new System.EventHandler(this.comboBoxComunidades_SelectionChangeCommitted);
            // 
            // textBoxReferencia
            // 
            this.textBoxReferencia.Location = new System.Drawing.Point(31, 15);
            this.textBoxReferencia.Name = "textBoxReferencia";
            this.textBoxReferencia.ReadOnly = true;
            this.textBoxReferencia.Size = new System.Drawing.Size(35, 20);
            this.textBoxReferencia.TabIndex = 1;
            this.textBoxReferencia.Text = "000";
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Location = new System.Drawing.Point(92, 56);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(75, 23);
            this.buttonEnviar.TabIndex = 2;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(173, 56);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 3;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // FormReferenciaComunidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 101);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.textBoxReferencia);
            this.Controls.Add(this.comboBoxComunidades);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReferenciaComunidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormReferenciaComunidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxComunidades;
        private System.Windows.Forms.TextBox textBoxReferencia;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.Button buttonCancelar;
    }
}