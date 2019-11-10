namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.Informes
{
    partial class FormVerInformeResumen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerInformeResumen));
            this.LiquidacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetLiq = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.Informes.DataSetLiq();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetLiqInformacion = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.Informes.DataSetLiqInformacion();
            this.dataSetLiqInformacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LiquidacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetLiq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqInformacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqInformacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LiquidacionBindingSource
            // 
            this.LiquidacionBindingSource.DataMember = "Liquidacion";
            this.LiquidacionBindingSource.DataSource = this.DataSetLiq;
            // 
            // DataSetLiq
            // 
            this.DataSetLiq.DataSetName = "DataSetLiq";
            this.DataSetLiq.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.LiquidacionBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.dataSetLiqInformacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.Informes.ReportLi" +
    "qResumen.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowContextMenu = false;
            this.reportViewer1.ShowCredentialPrompts = false;
            this.reportViewer1.ShowDocumentMapButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowPageNavigationControls = false;
            this.reportViewer1.ShowParameterPrompts = false;
            this.reportViewer1.ShowPromptAreaButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(730, 746);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetLiqInformacion
            // 
            this.dataSetLiqInformacion.DataSetName = "DataSetLiqInformacion";
            this.dataSetLiqInformacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetLiqInformacionBindingSource
            // 
            this.dataSetLiqInformacionBindingSource.DataSource = this.dataSetLiqInformacion;
            this.dataSetLiqInformacionBindingSource.Position = 0;
            // 
            // FormVerInformeResumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 746);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerInformeResumen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe Detallado";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormVerInformeDetallado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LiquidacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetLiq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqInformacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqInformacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource LiquidacionBindingSource;
        private DataSetLiq DataSetLiq;
        private System.Windows.Forms.BindingSource dataSetLiqInformacionBindingSource;
        private DataSetLiqInformacion dataSetLiqInformacion;
    }
}