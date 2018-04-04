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
            this.maskedTextBox_fin = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox_inicio = new System.Windows.Forms.MaskedTextBox();
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
            this.reportViewer1.Location = new System.Drawing.Point(19, 54);
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
            this.checkBoxAcuerdoJunta.Location = new System.Drawing.Point(658, 16);
            this.checkBoxAcuerdoJunta.Name = "checkBoxAcuerdoJunta";
            this.checkBoxAcuerdoJunta.Size = new System.Drawing.Size(98, 17);
            this.checkBoxAcuerdoJunta.TabIndex = 1;
            this.checkBoxAcuerdoJunta.Text = "Acuerdo Junta:";
            this.checkBoxAcuerdoJunta.UseVisualStyleBackColor = true;
            // 
            // checkBoxProximaJunta
            // 
            this.checkBoxProximaJunta.AutoSize = true;
            this.checkBoxProximaJunta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxProximaJunta.Location = new System.Drawing.Point(878, 16);
            this.checkBoxProximaJunta.Name = "checkBoxProximaJunta";
            this.checkBoxProximaJunta.Size = new System.Drawing.Size(82, 17);
            this.checkBoxProximaJunta.TabIndex = 2;
            this.checkBoxProximaJunta.Text = "Prox. Junta:";
            this.checkBoxProximaJunta.UseVisualStyleBackColor = true;
            // 
            // checkBoxImportante
            // 
            this.checkBoxImportante.AutoSize = true;
            this.checkBoxImportante.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxImportante.Location = new System.Drawing.Point(773, 16);
            this.checkBoxImportante.Name = "checkBoxImportante";
            this.checkBoxImportante.Size = new System.Drawing.Size(79, 17);
            this.checkBoxImportante.TabIndex = 3;
            this.checkBoxImportante.Text = "Importante:";
            this.checkBoxImportante.UseVisualStyleBackColor = true;
            // 
            // checkBoxSeguro
            // 
            this.checkBoxSeguro.AutoSize = true;
            this.checkBoxSeguro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxSeguro.Location = new System.Drawing.Point(982, 16);
            this.checkBoxSeguro.Name = "checkBoxSeguro";
            this.checkBoxSeguro.Size = new System.Drawing.Size(63, 17);
            this.checkBoxSeguro.TabIndex = 4;
            this.checkBoxSeguro.Text = "Seguro:";
            this.checkBoxSeguro.UseVisualStyleBackColor = true;
            // 
            // buttonFiltrar
            // 
            this.buttonFiltrar.Location = new System.Drawing.Point(1066, 11);
            this.buttonFiltrar.Name = "buttonFiltrar";
            this.buttonFiltrar.Size = new System.Drawing.Size(75, 23);
            this.buttonFiltrar.TabIndex = 5;
            this.buttonFiltrar.Text = "Filtrar";
            this.buttonFiltrar.UseVisualStyleBackColor = true;
            this.buttonFiltrar.Click += new System.EventHandler(this.buttonFiltrar_Click);
            // 
            // maskedTextBox_fin
            // 
            this.maskedTextBox_fin.Location = new System.Drawing.Point(581, 14);
            this.maskedTextBox_fin.Mask = "00/00/0000";
            this.maskedTextBox_fin.Name = "maskedTextBox_fin";
            this.maskedTextBox_fin.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_fin.TabIndex = 19;
            this.maskedTextBox_fin.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(539, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "hasta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Fecha desde:";
            // 
            // maskedTextBox_inicio
            // 
            this.maskedTextBox_inicio.Location = new System.Drawing.Point(462, 14);
            this.maskedTextBox_inicio.Mask = "00/00/0000";
            this.maskedTextBox_inicio.Name = "maskedTextBox_inicio";
            this.maskedTextBox_inicio.Size = new System.Drawing.Size(71, 20);
            this.maskedTextBox_inicio.TabIndex = 18;
            this.maskedTextBox_inicio.ValidatingType = typeof(System.DateTime);
            // 
            // VistaInformeSeguimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 757);
            this.Controls.Add(this.maskedTextBox_fin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBox_inicio);
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
        private System.Windows.Forms.MaskedTextBox maskedTextBox_fin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_inicio;
    }
}