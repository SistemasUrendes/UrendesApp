namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProveedoresForms
{
    partial class FormInformeProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInformeProveedores));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetProveedores = new UrdsAppGestión.Presentacion.ComunidadesForms.ProveedoresForms.DataSetProveedores();
            this.ProveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProveedoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ProveedoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UrdsAppGestión.Presentacion.ComunidadesForms.ProveedoresForms.ReportProveedoresLi" +
    "stado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1153, 520);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetProveedores
            // 
            this.DataSetProveedores.DataSetName = "DataSetProveedores";
            this.DataSetProveedores.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ProveedoresBindingSource
            // 
            this.ProveedoresBindingSource.DataMember = "Proveedores";
            this.ProveedoresBindingSource.DataSource = this.DataSetProveedores;
            // 
            // FormInformeProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 520);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInformeProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe Proveedores";
            this.Load += new System.EventHandler(this.FormInformeProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProveedoresBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProveedoresBindingSource;
        private DataSetProveedores DataSetProveedores;
    }
}