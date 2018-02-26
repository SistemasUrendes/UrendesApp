namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms.Informes
{
    partial class VistaInformeMovimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaInformeMovimientos));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetInformeParticularRecibo1 = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularRecibo.DataSetInformeParticularRecibo();
            this.DataSetMovimientos = new UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms.Informes.DataSetMovimientos();
            this.MovimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInformeParticularRecibo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovimientosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSetInformeParticularRecibo1
            // 
            this.dataSetInformeParticularRecibo1.DataSetName = "DataSetInformeParticularRecibo";
            this.dataSetInformeParticularRecibo1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataSetMovimientos
            // 
            this.DataSetMovimientos.DataSetName = "DataSetMovimientos";
            this.DataSetMovimientos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MovimientosBindingSource
            // 
            this.MovimientosBindingSource.DataMember = "Movimientos";
            this.MovimientosBindingSource.DataSource = this.DataSetMovimientos;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bindingSource1;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.bindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms.Informes.InformeMovim" +
    "ientos.rdlc";
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
            this.reportViewer1.Size = new System.Drawing.Size(734, 713);
            this.reportViewer1.TabIndex = 1;
            // 
            // VistaInformeMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 713);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VistaInformeMovimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VistaInformeMovimientos";
            this.Load += new System.EventHandler(this.VistaInformeMovimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInformeParticularRecibo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovimientosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiquidacionesForms.InformeParticularRecibo.DataSetInformeParticularRecibo dataSetInformeParticularRecibo1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private DataSetMovimientos DataSetMovimientos;
        private System.Windows.Forms.BindingSource MovimientosBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}