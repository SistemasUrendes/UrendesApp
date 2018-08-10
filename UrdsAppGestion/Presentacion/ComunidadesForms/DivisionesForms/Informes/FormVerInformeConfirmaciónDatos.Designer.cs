namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes
{
    partial class FormVerInformeConfirmaciónDatos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerInformeConfirmaciónDatos));
            this.dataSetInformacionComunerosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetInformacionComuneros = new UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes.DataSetInformacionComuneros();
            this.dataSetAsociacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetAsociacion = new UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes.DataSetAsociacion();
            this.dataSetTelefonosComunerosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetTelefonosComuneros = new UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms.Informes.DataSetTelefonosComuneros();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetDirecciones = new UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms.Informes.DataSetDirecciones();
            this.dataSetDireccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetEmails = new UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms.Informes.DataSetEmails();
            this.dataSetEmailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetInfoEntidadxsd = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularRecibo.DataSetInfoEntidadxsd();
            this.dataSetInfoEntidadxsdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInformacionComunerosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInformacionComuneros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAsociacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAsociacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTelefonosComunerosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTelefonosComuneros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDirecciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDireccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEmails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEmailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsdBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSetInformacionComunerosBindingSource
            // 
            this.dataSetInformacionComunerosBindingSource.DataSource = this.dataSetInformacionComuneros;
            this.dataSetInformacionComunerosBindingSource.Position = 0;
            // 
            // dataSetInformacionComuneros
            // 
            this.dataSetInformacionComuneros.DataSetName = "DataSetInformacionComuneros";
            this.dataSetInformacionComuneros.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetAsociacionBindingSource
            // 
            this.dataSetAsociacionBindingSource.DataSource = this.dataSetAsociacion;
            this.dataSetAsociacionBindingSource.Position = 0;
            // 
            // dataSetAsociacion
            // 
            this.dataSetAsociacion.DataSetName = "DataSetAsociacion";
            this.dataSetAsociacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetTelefonosComunerosBindingSource
            // 
            this.dataSetTelefonosComunerosBindingSource.DataSource = this.dataSetTelefonosComuneros;
            this.dataSetTelefonosComunerosBindingSource.Position = 0;
            // 
            // dataSetTelefonosComuneros
            // 
            this.dataSetTelefonosComuneros.DataSetName = "DataSetTelefonosComuneros";
            this.dataSetTelefonosComuneros.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataSetInformacionComunerosBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.dataSetAsociacionBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.dataSetTelefonosComunerosBindingSource;
            reportDataSource4.Name = "DataSet4";
            reportDataSource4.Value = this.dataSetDireccionesBindingSource;
            reportDataSource5.Name = "DataSet5";
            reportDataSource5.Value = this.dataSetEmailsBindingSource;
            reportDataSource6.Name = "DataSet6";
            reportDataSource6.Value = this.dataSetInfoEntidadxsdBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes.ReportConfi" +
    "rmacionDatos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(651, 749);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetDirecciones
            // 
            this.dataSetDirecciones.DataSetName = "DataSetDirecciones";
            this.dataSetDirecciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetDireccionesBindingSource
            // 
            this.dataSetDireccionesBindingSource.DataSource = this.dataSetDirecciones;
            this.dataSetDireccionesBindingSource.Position = 0;
            // 
            // dataSetEmails
            // 
            this.dataSetEmails.DataSetName = "DataSetEmails";
            this.dataSetEmails.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetEmailsBindingSource
            // 
            this.dataSetEmailsBindingSource.DataSource = this.dataSetEmails;
            this.dataSetEmailsBindingSource.Position = 0;
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
            // FormVerInformeConfirmaciónDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 749);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerInformeConfirmaciónDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmación Datos";
            this.Load += new System.EventHandler(this.FormVerInformeConfirmaciónDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInformacionComunerosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInformacionComuneros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAsociacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAsociacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTelefonosComunerosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTelefonosComuneros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDirecciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDireccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEmails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetEmailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInfoEntidadxsdBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataSetInformacionComunerosBindingSource;
        private DataSetInformacionComuneros dataSetInformacionComuneros;
        private System.Windows.Forms.BindingSource dataSetAsociacionBindingSource;
        private DataSetAsociacion dataSetAsociacion;
        private System.Windows.Forms.BindingSource dataSetTelefonosComunerosBindingSource;
        private ComunerosForms.Informes.DataSetTelefonosComuneros dataSetTelefonosComuneros;
        private System.Windows.Forms.BindingSource dataSetDireccionesBindingSource;
        private ComunerosForms.Informes.DataSetDirecciones dataSetDirecciones;
        private System.Windows.Forms.BindingSource dataSetEmailsBindingSource;
        private ComunerosForms.Informes.DataSetEmails dataSetEmails;
        private System.Windows.Forms.BindingSource dataSetInfoEntidadxsdBindingSource;
        private LiquidacionesForms.InformeParticularRecibo.DataSetInfoEntidadxsd dataSetInfoEntidadxsd;
    }
}