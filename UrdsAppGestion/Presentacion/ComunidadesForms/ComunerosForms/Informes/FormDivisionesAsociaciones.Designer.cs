namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms.Informes
{
    partial class FormDivisionesAsociaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDivisionesAsociaciones));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetDivisionesAsociaciones = new UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms.Informes.DataSetDivisionesAsociaciones();
            this.dataSetDivisionesAsociacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDivisionesAsociaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDivisionesAsociacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataSetDivisionesAsociacionesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms.Informes.InformeDivis" +
    "ionesAsociaciones.rdlc";
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
            this.reportViewer1.Size = new System.Drawing.Size(941, 863);
            this.reportViewer1.TabIndex = 2;
            // 
            // dataSetDivisionesAsociaciones
            // 
            this.dataSetDivisionesAsociaciones.DataSetName = "DataSetDivisionesAsociaciones";
            this.dataSetDivisionesAsociaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetDivisionesAsociacionesBindingSource
            // 
            this.dataSetDivisionesAsociacionesBindingSource.DataSource = this.dataSetDivisionesAsociaciones;
            this.dataSetDivisionesAsociacionesBindingSource.Position = 0;
            // 
            // FormDivisionesAsociaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 863);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDivisionesAsociaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDivisionesAsociaciones";
            this.Load += new System.EventHandler(this.FormDivisionesAsociaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDivisionesAsociaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDivisionesAsociacionesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataSetDivisionesAsociacionesBindingSource;
        private DataSetDivisionesAsociaciones dataSetDivisionesAsociaciones;
    }
}