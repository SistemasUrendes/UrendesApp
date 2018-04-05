namespace UrdsAppGestión.Presentacion.Tareas.Informes
{
    partial class VistaInformeSeguimiento
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaInformeSeguimiento));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetSeguimiento1 = new UrdsAppGestión.Presentacion.Tareas.Informes.DataSetSeguimiento();
            this.checkBoxAcuerdoJunta = new System.Windows.Forms.CheckBox();
            this.checkBoxProximaJunta = new System.Windows.Forms.CheckBox();
            this.checkBoxImportante = new System.Windows.Forms.CheckBox();
            this.checkBoxSeguro = new System.Windows.Forms.CheckBox();
            this.buttonFiltrar = new System.Windows.Forms.Button();
            this.maskedTextBox_FFin2 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox_FFin1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_FIni2 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox_FIni1 = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSeguimiento1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.Tareas.Informes.InformeSeguimiento.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(19, 74);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowContextMenu = false;
            this.reportViewer1.ShowCredentialPrompts = false;
            this.reportViewer1.ShowDocumentMapButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowParameterPrompts = false;
            this.reportViewer1.ShowPromptAreaButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(1122, 697);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetSeguimiento1
            // 
            this.dataSetSeguimiento1.DataSetName = "DataSetSeguimiento";
            this.dataSetSeguimiento1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkBoxAcuerdoJunta
            // 
            this.checkBoxAcuerdoJunta.AutoSize = true;
            this.checkBoxAcuerdoJunta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAcuerdoJunta.Location = new System.Drawing.Point(684, 24);
            this.checkBoxAcuerdoJunta.Name = "checkBoxAcuerdoJunta";
            this.checkBoxAcuerdoJunta.Size = new System.Drawing.Size(98, 17);
            this.checkBoxAcuerdoJunta.TabIndex = 5;
            this.checkBoxAcuerdoJunta.Text = "Acuerdo Junta:";
            this.checkBoxAcuerdoJunta.UseVisualStyleBackColor = true;
            // 
            // checkBoxProximaJunta
            // 
            this.checkBoxProximaJunta.AutoSize = true;
            this.checkBoxProximaJunta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxProximaJunta.Location = new System.Drawing.Point(885, 24);
            this.checkBoxProximaJunta.Name = "checkBoxProximaJunta";
            this.checkBoxProximaJunta.Size = new System.Drawing.Size(82, 17);
            this.checkBoxProximaJunta.TabIndex = 7;
            this.checkBoxProximaJunta.Text = "Prox. Junta:";
            this.checkBoxProximaJunta.UseVisualStyleBackColor = true;
            // 
            // checkBoxImportante
            // 
            this.checkBoxImportante.AutoSize = true;
            this.checkBoxImportante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxImportante.Location = new System.Drawing.Point(794, 24);
            this.checkBoxImportante.Name = "checkBoxImportante";
            this.checkBoxImportante.Size = new System.Drawing.Size(79, 17);
            this.checkBoxImportante.TabIndex = 6;
            this.checkBoxImportante.Text = "Importante:";
            this.checkBoxImportante.UseVisualStyleBackColor = true;
            // 
            // checkBoxSeguro
            // 
            this.checkBoxSeguro.AutoSize = true;
            this.checkBoxSeguro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxSeguro.Location = new System.Drawing.Point(979, 24);
            this.checkBoxSeguro.Name = "checkBoxSeguro";
            this.checkBoxSeguro.Size = new System.Drawing.Size(63, 17);
            this.checkBoxSeguro.TabIndex = 8;
            this.checkBoxSeguro.Text = "Seguro:";
            this.checkBoxSeguro.UseVisualStyleBackColor = true;
            // 
            // buttonFiltrar
            // 
            this.buttonFiltrar.Location = new System.Drawing.Point(1066, 9);
            this.buttonFiltrar.Name = "buttonFiltrar";
            this.buttonFiltrar.Size = new System.Drawing.Size(75, 46);
            this.buttonFiltrar.TabIndex = 9;
            this.buttonFiltrar.Text = "Filtrar";
            this.buttonFiltrar.UseVisualStyleBackColor = true;
            this.buttonFiltrar.Click += new System.EventHandler(this.buttonFiltrar_Click);
            // 
            // maskedTextBox_FFin2
            // 
            this.maskedTextBox_FFin2.Location = new System.Drawing.Point(597, 35);
            this.maskedTextBox_FFin2.Mask = "00/00/0000";
            this.maskedTextBox_FFin2.Name = "maskedTextBox_FFin2";
            this.maskedTextBox_FFin2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FFin2.TabIndex = 4;
            this.maskedTextBox_FFin2.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(549, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Fecha fin desde:";
            // 
            // maskedTextBox_FFin1
            // 
            this.maskedTextBox_FFin1.Location = new System.Drawing.Point(466, 35);
            this.maskedTextBox_FFin1.Mask = "00/00/0000";
            this.maskedTextBox_FFin1.Name = "maskedTextBox_FFin1";
            this.maskedTextBox_FFin1.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FFin1.TabIndex = 3;
            this.maskedTextBox_FFin1.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox_FIni2
            // 
            this.maskedTextBox_FIni2.Location = new System.Drawing.Point(597, 9);
            this.maskedTextBox_FIni2.Mask = "00/00/0000";
            this.maskedTextBox_FIni2.Name = "maskedTextBox_FIni2";
            this.maskedTextBox_FIni2.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FIni2.TabIndex = 2;
            this.maskedTextBox_FIni2.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(549, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Fecha inicio desde:";
            // 
            // maskedTextBox_FIni1
            // 
            this.maskedTextBox_FIni1.Location = new System.Drawing.Point(466, 9);
            this.maskedTextBox_FIni1.Mask = "00/00/0000";
            this.maskedTextBox_FIni1.Name = "maskedTextBox_FIni1";
            this.maskedTextBox_FIni1.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_FIni1.TabIndex = 1;
            this.maskedTextBox_FIni1.ValidatingType = typeof(System.DateTime);
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "Todas",
            "Abiertas",
            "Cerradas"});
            this.comboBoxEstado.Location = new System.Drawing.Point(212, 20);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEstado.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Estado:";
            // 
            // VistaInformeSeguimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 777);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.maskedTextBox_FIni2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBox_FIni1);
            this.Controls.Add(this.maskedTextBox_FFin2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBox_FFin1);
            this.Controls.Add(this.buttonFiltrar);
            this.Controls.Add(this.checkBoxSeguro);
            this.Controls.Add(this.checkBoxImportante);
            this.Controls.Add(this.checkBoxProximaJunta);
            this.Controls.Add(this.checkBoxAcuerdoJunta);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VistaInformeSeguimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VistaInformeSeguimiento";
            this.Load += new System.EventHandler(this.VistaInformeSeguimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSeguimiento1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DataSetSeguimiento dataSetSeguimiento1;
        private System.Windows.Forms.CheckBox checkBoxAcuerdoJunta;
        private System.Windows.Forms.CheckBox checkBoxProximaJunta;
        private System.Windows.Forms.CheckBox checkBoxImportante;
        private System.Windows.Forms.CheckBox checkBoxSeguro;
        private System.Windows.Forms.Button buttonFiltrar;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FFin2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FFin1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FIni2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FIni1;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Label label6;
    }
}