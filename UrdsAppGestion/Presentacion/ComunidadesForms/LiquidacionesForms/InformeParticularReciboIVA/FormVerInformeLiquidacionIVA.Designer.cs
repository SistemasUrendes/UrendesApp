namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularReciboIVA
{
    partial class FormVerInformeLiquidacionIVA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerInformeLiquidacionIVA));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetInformeParticularIVA = new UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularReciboIVA.DataSetInformeParticularIVA();
            this.DivisionLiquidacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetInformeParticularIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DivisionLiquidacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DivisionLiquidacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticular" +
    "ReciboIVA.ReportLiquidacionParticularIVA.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(733, 804);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetInformeParticularIVA
            // 
            this.DataSetInformeParticularIVA.DataSetName = "DataSetInformeParticularIVA";
            this.DataSetInformeParticularIVA.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DivisionLiquidacionBindingSource
            // 
            this.DivisionLiquidacionBindingSource.DataMember = "DivisionLiquidacion";
            this.DivisionLiquidacionBindingSource.DataSource = this.DataSetInformeParticularIVA;
            // 
            // FormVerInformeLiquidacionIVA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 804);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVerInformeLiquidacionIVA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidacion con IVA";
            this.Load += new System.EventHandler(this.FormVerInformeLiquidacionIVA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetInformeParticularIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DivisionLiquidacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DivisionLiquidacionBindingSource;
        private DataSetInformeParticularIVA DataSetInformeParticularIVA;
    }
}