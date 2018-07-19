using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularReciboIVA
{
    public partial class FormVerInformeLiquidacionIVA : Form
    {
        DataTable data2;

        public FormVerInformeLiquidacionIVA(DataTable data1, DataTable data2, DataTable InformacionComunidad, DataTable datosRepartoResumenIVA, DataTable InfoEntidad,DataTable liqResumen, String NombreLiquidacion)
        {
            InitializeComponent();
            DivisionLiquidacionBindingSource.DataSource = data1;
            dataSet2BindingSource.DataSource = InformacionComunidad;
            dataSetIVATotalesBindingSource.DataSource = datosRepartoResumenIVA;
            dataSetInfoEntidadxsdBindingSource.DataSource = InfoEntidad;
            dataSetLiqResumenBindingSource.DataSource = liqResumen;
            this.data2 = data2;

            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);

            ReportParameter parametro = new ReportParameter("NombreLiquidacion", NombreLiquidacion);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

        }

        private void FormVerInformeLiquidacionIVA_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e) {
            e.DataSources.Add(new ReportDataSource("DataSet1", (object)data2));
        }
    }
}
