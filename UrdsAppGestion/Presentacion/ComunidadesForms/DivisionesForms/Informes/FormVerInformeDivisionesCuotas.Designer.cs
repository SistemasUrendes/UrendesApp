namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes
{
    partial class FormVerInformeDivisionesCuotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerInformeDivisionesCuotas));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetCuotasDivision = new UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes.DataSetCuotasDivision();
            this.dataSetCuotasDivisionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetInfoEntidadxsd = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularRecibo.DataSetInfoEntidadxsd();
            this.dataSetInfoEntidadxsdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new UrdsAppGestión.Presentacion.Informes.DataSet2();
            this.dataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCuotasDivision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCuotasDivisionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataSetCuotasDivisionBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.dataSetInfoEntidadxsdBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.dataSet2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes.ReportDivis" +
    "ionesCuotas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(688, 658);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetCuotasDivision
            // 
            this.dataSetCuotasDivision.DataSetName = "DataSetCuotasDivision";
            this.dataSetCuotasDivision.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetCuotasDivisionBindingSource
            // 
            this.dataSetCuotasDivisionBindingSource.DataSource = this.dataSetCuotasDivision;
            this.dataSetCuotasDivisionBindingSource.Position = 0;
            // 
            // dataSetInfoEntidadxsd
            // 
            this.dataSetInfoEntidadxsd.DataSetName = "DataSetInfoEntidadxsd";
            this.dataSetInfoEntidadxsd.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetInfoEntidadxsdBindingSource
            // 
            this.dataSetInfoEntidadxsdBindingSource.DataSource = this.dataSetInfoEntidadxsd;
            this.dataSetInfoEntidadxsdBindingSource.Position = 0;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet2BindingSource
            // 
            this.dataSet2BindingSource.DataSource = this.dataSet2;
            this.dataSet2BindingSource.Position = 0;
            // 
            // FormVerInformeDivisionesCuotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 658);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerInformeDivisionesCuotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuotas Emitidas";
            this.Load += new System.EventHandler(this.FormVerInformeDivisionesCuotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCuotasDivision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetCuotasDivisionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataSetCuotasDivisionBindingSource;
        private DataSetCuotasDivision dataSetCuotasDivision;
        private System.Windows.Forms.BindingSource dataSetInfoEntidadxsdBindingSource;
        private LiquidacionesForms.InformeParticularRecibo.DataSetInfoEntidadxsd dataSetInfoEntidadxsd;
        private System.Windows.Forms.BindingSource dataSet2BindingSource;
        private Presentacion.Informes.DataSet2 dataSet2;
    }
}