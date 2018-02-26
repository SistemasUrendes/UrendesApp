namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms.Informes
{
    partial class VisorInformeCuotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisorInformeCuotas));
            this.VencimientosCuotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetCuota = new UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms.Informes.DataSetCuota();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.VencimientosCuotaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCuota)).BeginInit();
            this.SuspendLayout();
            // 
            // VencimientosCuotaBindingSource
            // 
            this.VencimientosCuotaBindingSource.DataMember = "VencimientosCuota";
            this.VencimientosCuotaBindingSource.DataSource = this.DataSetCuota;
            // 
            // DataSetCuota
            // 
            this.DataSetCuota.DataSetName = "DataSetCuota";
            this.DataSetCuota.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.VencimientosCuotaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms.Informes.InformeCuotas.r" +
    "dlc";
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
            this.reportViewer1.Size = new System.Drawing.Size(758, 714);
            this.reportViewer1.TabIndex = 0;
            // 
            // VisorInformeCuotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 714);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VisorInformeCuotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor Informe Cuotas";
            this.Load += new System.EventHandler(this.VisorInformeCuotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VencimientosCuotaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCuota)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VencimientosCuotaBindingSource;
        private DataSetCuota DataSetCuota;
    }
}