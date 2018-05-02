namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormDuplicarTarea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDuplicarTarea));
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxContactos = new System.Windows.Forms.CheckBox();
            this.checkBoxExpedientes = new System.Windows.Forms.CheckBox();
            this.buttonDuplicar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Duplicar:";
            // 
            // checkBoxContactos
            // 
            this.checkBoxContactos.AutoSize = true;
            this.checkBoxContactos.Location = new System.Drawing.Point(38, 36);
            this.checkBoxContactos.Name = "checkBoxContactos";
            this.checkBoxContactos.Size = new System.Drawing.Size(74, 17);
            this.checkBoxContactos.TabIndex = 1;
            this.checkBoxContactos.Text = "Contactos";
            this.checkBoxContactos.UseVisualStyleBackColor = true;
            // 
            // checkBoxExpedientes
            // 
            this.checkBoxExpedientes.AutoSize = true;
            this.checkBoxExpedientes.Location = new System.Drawing.Point(38, 60);
            this.checkBoxExpedientes.Name = "checkBoxExpedientes";
            this.checkBoxExpedientes.Size = new System.Drawing.Size(84, 17);
            this.checkBoxExpedientes.TabIndex = 2;
            this.checkBoxExpedientes.Text = "Expedientes";
            this.checkBoxExpedientes.UseVisualStyleBackColor = true;
            // 
            // buttonDuplicar
            // 
            this.buttonDuplicar.Location = new System.Drawing.Point(57, 94);
            this.buttonDuplicar.Name = "buttonDuplicar";
            this.buttonDuplicar.Size = new System.Drawing.Size(75, 23);
            this.buttonDuplicar.TabIndex = 3;
            this.buttonDuplicar.Text = "Duplicar";
            this.buttonDuplicar.UseVisualStyleBackColor = true;
            this.buttonDuplicar.Click += new System.EventHandler(this.buttonDuplicar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(138, 94);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 4;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // FormDuplicarTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 129);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonDuplicar);
            this.Controls.Add(this.checkBoxExpedientes);
            this.Controls.Add(this.checkBoxContactos);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDuplicarTarea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duplicar Tarea";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxContactos;
        private System.Windows.Forms.CheckBox checkBoxExpedientes;
        private System.Windows.Forms.Button buttonDuplicar;
        private System.Windows.Forms.Button buttonCancelar;
    }
}