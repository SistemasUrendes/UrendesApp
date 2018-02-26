namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticular
{
    partial class FormVerInformeParticular
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerInformeParticular));
            this.repartoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.InformeParticular = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticular.InformeParticular();
            this.dataSetLiqResumenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetLiqResumen = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.Informes.DataSetLiqResumen();
            this.dataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new UrdsAppGestión.Presentacion.Informes.DataSet2();
            this.dataSet2BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetLiqInformacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetLiqInformacion = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.Informes.DataSetLiqInformacion();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.repartoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformeParticular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqResumenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqResumen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqInformacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqInformacion)).BeginInit();
            this.SuspendLayout();
            // 
            // repartoBindingSource1
            // 
            this.repartoBindingSource1.DataMember = "Reparto";
            this.repartoBindingSource1.DataSource = this.InformeParticular;
            // 
            // InformeParticular
            // 
            this.InformeParticular.DataSetName = "InformeParticular";
            this.InformeParticular.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetLiqResumenBindingSource
            // 
            this.dataSetLiqResumenBindingSource.DataSource = this.dataSetLiqResumen;
            this.dataSetLiqResumenBindingSource.Position = 0;
            // 
            // dataSetLiqResumen
            // 
            this.dataSetLiqResumen.DataSetName = "DataSetLiq";
            this.dataSetLiqResumen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet2BindingSource
            // 
            this.dataSet2BindingSource.DataSource = this.dataSet2;
            this.dataSet2BindingSource.Position = 0;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet2BindingSource1
            // 
            this.dataSet2BindingSource1.DataSource = this.dataSet2;
            this.dataSet2BindingSource1.Position = 0;
            // 
            // dataSetLiqInformacionBindingSource
            // 
            this.dataSetLiqInformacionBindingSource.DataSource = this.dataSetLiqInformacion;
            this.dataSetLiqInformacionBindingSource.Position = 0;
            // 
            // dataSetLiqInformacion
            // 
            this.dataSetLiqInformacion.DataSetName = "DataSetLiqInformacion";
            this.dataSetLiqInformacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.repartoBindingSource1;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.dataSetLiqResumenBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.dataSet2BindingSource;
            reportDataSource4.Name = "DataSet4";
            reportDataSource4.Value = this.dataSet2BindingSource1;
            reportDataSource5.Name = "DataSet5";
            reportDataSource5.Value = this.dataSetLiqInformacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticular" +
    ".ReportLiquidacionParticular.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(652, 569);
            this.reportViewer1.TabIndex = 0;
            // 
            // FormVerInformeParticular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 569);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerInformeParticular";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Informe Particular";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormVerInformeParticular_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repartoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformeParticular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqResumenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqResumen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqInformacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqInformacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private InformeParticular InformeParticular;
        private System.Windows.Forms.BindingSource repartoBindingSource1;
        private System.Windows.Forms.BindingSource dataSetLiqResumenBindingSource;
        private Informes.DataSetLiqResumen dataSetLiqResumen;
        private System.Windows.Forms.BindingSource dataSet2BindingSource;
        private Presentacion.Informes.DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource dataSet2BindingSource1;
        private System.Windows.Forms.BindingSource dataSetLiqInformacionBindingSource;
        private Informes.DataSetLiqInformacion dataSetLiqInformacion;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}