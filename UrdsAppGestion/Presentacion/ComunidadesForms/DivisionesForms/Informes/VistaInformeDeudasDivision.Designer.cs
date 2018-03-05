namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes
{
    partial class VistaInformeDeudasDivision
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaInformeDeudasDivision));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetDeudasDivisionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetDeudasDivision = new UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes.DataSetDeudasDivision();
            this.DeudasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDeudasDivisionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDeudasDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeudasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bindingSource1;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.bindingSource2;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.bindingSource3;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes.InformeDeud" +
    "asDivision.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
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
            this.reportViewer1.Size = new System.Drawing.Size(749, 580);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetDeudasDivisionBindingSource
            // 
            this.dataSetDeudasDivisionBindingSource.DataSource = this.dataSetDeudasDivision;
            this.dataSetDeudasDivisionBindingSource.Position = 0;
            // 
            // dataSetDeudasDivision
            // 
            this.dataSetDeudasDivision.DataSetName = "DataSetDeudasDivision";
            this.dataSetDeudasDivision.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DeudasBindingSource
            // 
            this.DeudasBindingSource.DataMember = "Deudas";
            this.DeudasBindingSource.DataSource = this.dataSetDeudasDivision;
            // 
            // VistaInformeDeudasDivision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 580);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VistaInformeDeudasDivision";
            this.Text = "VistaInformeDeudasDivision";
            this.Load += new System.EventHandler(this.VistaInformeDeudasDivision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDeudasDivisionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDeudasDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeudasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataSetDeudasDivisionBindingSource;
        private DataSetDeudasDivision dataSetDeudasDivision;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.BindingSource DeudasBindingSource;
    }
}