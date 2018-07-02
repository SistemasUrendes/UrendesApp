namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes
{
    partial class FormListadoJuntasBloque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListadoJuntasBloque));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetListadoJuntasBloqueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetListadoJuntasBloque = new UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes.DataSetListadoJuntasBloque();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetListadoJuntasBloqueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetListadoJuntasBloque)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataSetListadoJuntasBloqueBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes.ReportLista" +
    "doJuntasBloque.rdlc";
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
            this.reportViewer1.Size = new System.Drawing.Size(833, 992);
            this.reportViewer1.TabIndex = 1;
            // 
            // dataSetListadoJuntasBloqueBindingSource
            // 
            this.dataSetListadoJuntasBloqueBindingSource.DataSource = this.dataSetListadoJuntasBloque;
            this.dataSetListadoJuntasBloqueBindingSource.Position = 0;
            // 
            // dataSetListadoJuntasBloque
            // 
            this.dataSetListadoJuntasBloque.DataSetName = "DataSetListadoJuntasBloque";
            this.dataSetListadoJuntasBloque.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FormListadoJuntasBloque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 992);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormListadoJuntasBloque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Juntas Bloque";
            this.Load += new System.EventHandler(this.FormListadoJuntasBloque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetListadoJuntasBloqueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetListadoJuntasBloque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataSetListadoJuntasBloqueBindingSource;
        private DataSetListadoJuntasBloque dataSetListadoJuntasBloque;
    }
}