namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms.Informes
{
    partial class FormVerInformeCargos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerInformeCargos));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetCargos = new UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms.Informes.DataSetCargos();
            this.CargosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCargos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CargosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CargosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms.Informes.ReportCargo.rdl" +
    "c";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(643, 586);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetCargos
            // 
            this.DataSetCargos.DataSetName = "DataSetCargos";
            this.DataSetCargos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CargosBindingSource
            // 
            this.CargosBindingSource.DataMember = "Cargos";
            this.CargosBindingSource.DataSource = this.DataSetCargos;
            // 
            // FormVerInformeCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 586);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerInformeCargos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargos";
            this.Load += new System.EventHandler(this.FormVerInformeCargos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCargos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CargosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CargosBindingSource;
        private DataSetCargos DataSetCargos;
    }
}