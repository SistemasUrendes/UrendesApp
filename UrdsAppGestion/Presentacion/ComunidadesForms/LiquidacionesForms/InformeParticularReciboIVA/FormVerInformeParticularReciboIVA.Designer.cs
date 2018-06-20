namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularRecibo
{
    partial class FormVerInformeParticularReciboIVA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerInformeParticularRecibo));
            this.ReciboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetInformeParticularRecibo = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularRecibo.DataSetInformeParticularRecibo();
            this.dataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new UrdsAppGestión.Presentacion.Informes.DataSet2();
            this.dataSetInfoEntidadxsdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetInfoEntidadxsd = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularRecibo.DataSetInfoEntidadxsd();
            this.dataSetLiqResumenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReparto = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularRecibo.DataSetReparto();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReciboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetInformeParticularRecibo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqResumenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReparto)).BeginInit();
            this.SuspendLayout();
            // 
            // ReciboBindingSource
            // 
            this.ReciboBindingSource.DataMember = "Recibo";
            this.ReciboBindingSource.DataSource = this.DataSetInformeParticularRecibo;
            // 
            // DataSetInformeParticularRecibo
            // 
            this.DataSetInformeParticularRecibo.DataSetName = "DataSetInformeParticularRecibo";
            this.DataSetInformeParticularRecibo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // dataSetInfoEntidadxsdBindingSource
            // 
            this.dataSetInfoEntidadxsdBindingSource.DataSource = this.dataSetInfoEntidadxsd;
            this.dataSetInfoEntidadxsdBindingSource.Position = 0;
            // 
            // dataSetInfoEntidadxsd
            // 
            this.dataSetInfoEntidadxsd.DataSetName = "DataSetInfoEntidadxsd";
            this.dataSetInfoEntidadxsd.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataSetReparto
            // 
            this.DataSetReparto.DataSetName = "DataSetReparto";
            this.DataSetReparto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReciboBindingSource;
            reportDataSource2.Name = "DataSet3";
            reportDataSource2.Value = this.dataSet2BindingSource;
            reportDataSource3.Name = "DataSet4";
            reportDataSource3.Value = this.dataSetInfoEntidadxsdBindingSource;
            reportDataSource4.Name = "DataSet2";
            reportDataSource4.Value = this.dataSetLiqResumenBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticular" +
    "Recibo.ReportInformeParticularRecibo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(665, 579);
            this.reportViewer1.TabIndex = 0;
            // 
            // FormVerInformeParticularRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 579);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerInformeParticularRecibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe Particular Recibo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormVerInformeParticularRecibo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReciboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetInformeParticularRecibo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLiqResumenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReparto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource ReciboBindingSource;
        private DataSetInformeParticularRecibo DataSetInformeParticularRecibo;
        private DataSetReparto DataSetReparto;
        private System.Windows.Forms.BindingSource dataSet2BindingSource;
        private Presentacion.Informes.DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource dataSetInfoEntidadxsdBindingSource;
        private DataSetInfoEntidadxsd dataSetInfoEntidadxsd;
        private System.Windows.Forms.BindingSource dataSetLiqResumenBindingSource;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}