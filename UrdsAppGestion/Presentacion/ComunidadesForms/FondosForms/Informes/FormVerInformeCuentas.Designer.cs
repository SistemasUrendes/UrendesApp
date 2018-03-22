namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms.Informes
{
    partial class FormVerInformeCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerInformeCuentas));
            this.FondosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetFondosInforme = new UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms.Informes.DataSetFondosInforme();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FondosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetFondosInforme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // FondosBindingSource
            // 
            this.FondosBindingSource.DataMember = "Fondos";
            this.FondosBindingSource.DataSource = this.DataSetFondosInforme;
            // 
            // DataSetFondosInforme
            // 
            this.DataSetFondosInforme.DataSetName = "DataSetFondosInforme";
            this.DataSetFondosInforme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FondosBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.bindingSource1;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.bindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms.Informes.ReportCuentas.r" +
    "dlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(806, 681);
            this.reportViewer1.TabIndex = 0;
            // 
            // FormVerInformeCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 681);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerInformeCuentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe Cuentas";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormVerInformeCuentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FondosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetFondosInforme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FondosBindingSource;
        private DataSetFondosInforme DataSetFondosInforme;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
    }
}