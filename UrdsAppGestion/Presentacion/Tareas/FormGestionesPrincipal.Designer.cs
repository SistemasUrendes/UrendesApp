namespace UrdsAppGestión.Presentacion.Tareas
{
    partial class FormGestionesPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestionesPrincipal));
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxAdmComunidad = new System.Windows.Forms.ComboBox();
            this.maskedTextBox_FIni2 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox_FIni1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_FMax2 = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.maskedTextBox_FMax1 = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxImportante = new System.Windows.Forms.CheckBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxGestion = new System.Windows.Forms.TextBox();
            this.maskedTextBoxRefComunidad = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonNuevaGestion = new System.Windows.Forms.Button();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Estado = new System.Windows.Forms.ComboBox();
            this.textBox_Entidad = new System.Windows.Forms.TextBox();
            this.comboBox_Tipo = new System.Windows.Forms.ComboBox();
            this.dataGridViewGestiones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGestiones)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Location = new System.Drawing.Point(1059, 72);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(84, 23);
            this.buttonImprimir.TabIndex = 72;
            this.buttonImprimir.Text = "Imprimir";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            this.buttonImprimir.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(885, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 70;
            this.label11.Text = "Gestor:";
            this.label11.Visible = false;
            // 
            // comboBoxAdmComunidad
            // 
            this.comboBoxAdmComunidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdmComunidad.FormattingEnabled = true;
            this.comboBoxAdmComunidad.Location = new System.Drawing.Point(931, 74);
            this.comboBoxAdmComunidad.Name = "comboBoxAdmComunidad";
            this.comboBoxAdmComunidad.Size = new System.Drawing.Size(101, 21);
            this.comboBoxAdmComunidad.TabIndex = 69;
            this.comboBoxAdmComunidad.Visible = false;
            // 
            // maskedTextBox_FIni2
            // 
            this.maskedTextBox_FIni2.Location = new System.Drawing.Point(580, 47);
            this.maskedTextBox_FIni2.Mask = "00/00/0000";
            this.maskedTextBox_FIni2.Name = "maskedTextBox_FIni2";
            this.maskedTextBox_FIni2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FIni2.TabIndex = 64;
            this.maskedTextBox_FIni2.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_FIni2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "F. Inicio:";
            this.label5.Visible = false;
            // 
            // maskedTextBox_FIni1
            // 
            this.maskedTextBox_FIni1.Location = new System.Drawing.Point(503, 47);
            this.maskedTextBox_FIni1.Mask = "00/00/0000";
            this.maskedTextBox_FIni1.Name = "maskedTextBox_FIni1";
            this.maskedTextBox_FIni1.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FIni1.TabIndex = 63;
            this.maskedTextBox_FIni1.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_FIni1.Visible = false;
            // 
            // maskedTextBox_FMax2
            // 
            this.maskedTextBox_FMax2.Location = new System.Drawing.Point(580, 75);
            this.maskedTextBox_FMax2.Mask = "00/00/0000";
            this.maskedTextBox_FMax2.Name = "maskedTextBox_FMax2";
            this.maskedTextBox_FMax2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FMax2.TabIndex = 66;
            this.maskedTextBox_FMax2.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_FMax2.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(447, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "F. Limite:";
            this.label10.Visible = false;
            // 
            // maskedTextBox_FMax1
            // 
            this.maskedTextBox_FMax1.Location = new System.Drawing.Point(502, 75);
            this.maskedTextBox_FMax1.Mask = "00/00/0000";
            this.maskedTextBox_FMax1.Name = "maskedTextBox_FMax1";
            this.maskedTextBox_FMax1.Size = new System.Drawing.Size(72, 20);
            this.maskedTextBox_FMax1.TabIndex = 65;
            this.maskedTextBox_FMax1.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_FMax1.Visible = false;
            // 
            // checkBoxImportante
            // 
            this.checkBoxImportante.AutoSize = true;
            this.checkBoxImportante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxImportante.Location = new System.Drawing.Point(672, 77);
            this.checkBoxImportante.Name = "checkBoxImportante";
            this.checkBoxImportante.Size = new System.Drawing.Size(79, 17);
            this.checkBoxImportante.TabIndex = 62;
            this.checkBoxImportante.Text = "&Importante:";
            this.checkBoxImportante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxImportante.UseVisualStyleBackColor = true;
            this.checkBoxImportante.Visible = false;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(1059, 42);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(84, 23);
            this.buttonReset.TabIndex = 61;
            this.buttonReset.Text = "Limpiar";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(96, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "IdGestion:";
            this.label7.Visible = false;
            // 
            // textBoxGestion
            // 
            this.textBoxGestion.Location = new System.Drawing.Point(157, 74);
            this.textBoxGestion.Name = "textBoxGestion";
            this.textBoxGestion.Size = new System.Drawing.Size(43, 20);
            this.textBoxGestion.TabIndex = 47;
            this.textBoxGestion.Visible = false;
            // 
            // maskedTextBoxRefComunidad
            // 
            this.maskedTextBoxRefComunidad.Location = new System.Drawing.Point(503, 16);
            this.maskedTextBoxRefComunidad.Mask = "999";
            this.maskedTextBoxRefComunidad.Name = "maskedTextBoxRefComunidad";
            this.maskedTextBoxRefComunidad.Size = new System.Drawing.Size(31, 20);
            this.maskedTextBoxRefComunidad.TabIndex = 48;
            this.maskedTextBoxRefComunidad.ValidatingType = typeof(int);
            this.maskedTextBoxRefComunidad.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Comunidad:";
            this.label6.Visible = false;
            // 
            // buttonNuevaGestion
            // 
            this.buttonNuevaGestion.Location = new System.Drawing.Point(9, 71);
            this.buttonNuevaGestion.Name = "buttonNuevaGestion";
            this.buttonNuevaGestion.Size = new System.Drawing.Size(75, 23);
            this.buttonNuevaGestion.TabIndex = 58;
            this.buttonNuevaGestion.Text = "Nueva";
            this.buttonNuevaGestion.UseVisualStyleBackColor = true;
            this.buttonNuevaGestion.Visible = false;
            this.buttonNuevaGestion.Click += new System.EventHandler(this.buttonNuevaGestion_Click);
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.Location = new System.Drawing.Point(1059, 12);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(84, 25);
            this.button_Filtrar.TabIndex = 57;
            this.button_Filtrar.Text = "Filtrar";
            this.button_Filtrar.UseVisualStyleBackColor = true;
            this.button_Filtrar.Visible = false;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(894, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "&Tipo:";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(883, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Estado:";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(540, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Entidad:";
            this.label1.Visible = false;
            // 
            // comboBox_Estado
            // 
            this.comboBox_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Estado.FormattingEnabled = true;
            this.comboBox_Estado.Location = new System.Drawing.Point(931, 44);
            this.comboBox_Estado.Name = "comboBox_Estado";
            this.comboBox_Estado.Size = new System.Drawing.Size(101, 21);
            this.comboBox_Estado.TabIndex = 56;
            this.comboBox_Estado.Visible = false;
            // 
            // textBox_Entidad
            // 
            this.textBox_Entidad.Location = new System.Drawing.Point(586, 17);
            this.textBox_Entidad.Name = "textBox_Entidad";
            this.textBox_Entidad.Size = new System.Drawing.Size(253, 20);
            this.textBox_Entidad.TabIndex = 49;
            this.textBox_Entidad.Visible = false;
            // 
            // comboBox_Tipo
            // 
            this.comboBox_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo.FormattingEnabled = true;
            this.comboBox_Tipo.Location = new System.Drawing.Point(931, 15);
            this.comboBox_Tipo.Name = "comboBox_Tipo";
            this.comboBox_Tipo.Size = new System.Drawing.Size(101, 21);
            this.comboBox_Tipo.TabIndex = 52;
            this.comboBox_Tipo.Visible = false;
            // 
            // dataGridViewGestiones
            // 
            this.dataGridViewGestiones.AllowUserToAddRows = false;
            this.dataGridViewGestiones.AllowUserToDeleteRows = false;
            this.dataGridViewGestiones.AllowUserToOrderColumns = true;
            this.dataGridViewGestiones.AllowUserToResizeRows = false;
            this.dataGridViewGestiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGestiones.Location = new System.Drawing.Point(9, 107);
            this.dataGridViewGestiones.Name = "dataGridViewGestiones";
            this.dataGridViewGestiones.ReadOnly = true;
            this.dataGridViewGestiones.RowHeadersVisible = false;
            this.dataGridViewGestiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGestiones.Size = new System.Drawing.Size(1134, 546);
            this.dataGridViewGestiones.TabIndex = 46;
            this.dataGridViewGestiones.TabStop = false;
            // 
            // FormGestionesPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 665);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxAdmComunidad);
            this.Controls.Add(this.maskedTextBox_FIni2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBox_FIni1);
            this.Controls.Add(this.maskedTextBox_FMax2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.maskedTextBox_FMax1);
            this.Controls.Add(this.checkBoxImportante);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxGestion);
            this.Controls.Add(this.maskedTextBoxRefComunidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonNuevaGestion);
            this.Controls.Add(this.button_Filtrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Estado);
            this.Controls.Add(this.textBox_Entidad);
            this.Controls.Add(this.comboBox_Tipo);
            this.Controls.Add(this.dataGridViewGestiones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGestionesPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestiones";
            this.Load += new System.EventHandler(this.FormGestionesPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGestiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxAdmComunidad;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FIni2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FIni1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FMax2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FMax1;
        private System.Windows.Forms.CheckBox checkBoxImportante;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxGestion;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxRefComunidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonNuevaGestion;
        private System.Windows.Forms.Button button_Filtrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Estado;
        private System.Windows.Forms.TextBox textBox_Entidad;
        private System.Windows.Forms.ComboBox comboBox_Tipo;
        private System.Windows.Forms.DataGridView dataGridViewGestiones;
    }
}