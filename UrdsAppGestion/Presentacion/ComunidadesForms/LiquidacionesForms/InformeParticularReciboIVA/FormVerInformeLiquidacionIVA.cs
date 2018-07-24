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

        public FormVerInformeLiquidacionIVA(String entidad,String idLiquidacion, DataTable datosReparto, DataTable data2, DataTable InformacionComunidad, DataTable liqResumen, String NombreLiquidacion)
        {
            InitializeComponent();

            //BUSCO EL TOTAL DE LOS IVAS
            String sqlSelectResumenIVA = "SELECT com_liqrepartoiva.`%IVA` AS PorIVA, Sum(com_liqrepartoiva.BaseDivBloq) AS SumaDeBase, Sum(com_liqrepartoiva.IVADivBloq) AS SumaDelIVA FROM com_liqrepartoiva GROUP BY com_liqrepartoiva.`%IVA`, com_liqrepartoiva.IdTitular, com_liqrepartoiva.IdLiquidacion HAVING(((com_liqrepartoiva.IdTitular) = " + entidad + ") AND((com_liqrepartoiva.IdLiquidacion) = " + idLiquidacion + "));";

            dataSetIVATotalesBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectResumenIVA);

            //BUSCO INFORMACION DE LA ENTIDAD
            String sqlSelectInfoEntidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia FROM ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + entidad + ") AND (ctos_detdirecent.Ppal = -1));";

            dataSetInfoEntidadxsdBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectInfoEntidad);

            dataSetLiqResumenBindingSource.DataSource = liqResumen;
            DivisionLiquidacionBindingSource.DataSource = datosReparto;
            dataSet2BindingSource.DataSource = InformacionComunidad;
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
