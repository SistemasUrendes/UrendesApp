namespace UrdsAppGestión.Presentacion.ComunidadesForms.Informes.InformeDeudasComunero
{
    partial class FormInformeDeudasComunero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInformeDeudasComunero));
            this.deudasComunerosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetDeudasComunero = new UrdsAppGestión.Presentacion.ComunidadesForms.Informes.InformeDeudasComunero.DataSetDeudasComunero();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.deudasComunerosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDeudasComunero)).BeginInit();
            this.SuspendLayout();
            // 
            // deudasComunerosBindingSource
            // 
            this.deudasComunerosBindingSource.DataMember = "DeudasComuneros";
            this.deudasComunerosBindingSource.DataSource = this.dataSetDeudasComunero;
            // 
            // dataSetDeudasComunero
            // 
            this.dataSetDeudasComunero.DataSetName = "DataSetDeudasComunero";
            this.dataSetDeudasComunero.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.deudasComunerosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.Informes.InformeDeudasComunero.Repor" +
    "tDeudasComunero.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(389, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(735, 706);
            this.reportViewer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Informe Deudas Comunero";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormInformeDeudasComunero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 773);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInformeDeudasComunero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informes";
            this.Load += new System.EventHandler(this.FormInformeDeudasComunero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deudasComunerosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetDeudasComunero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource deudasComunerosBindingSource;
        private DataSetDeudasComunero dataSetDeudasComunero;
        private System.Windows.Forms.Button button1;
    }
}