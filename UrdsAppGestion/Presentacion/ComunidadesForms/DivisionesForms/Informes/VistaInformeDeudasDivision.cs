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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes
{
    public partial class VistaInformeDeudasDivision : Form
    {
        public VistaInformeDeudasDivision(String id_division, String id_comunidad, String id_entidad, String id_comunero, String division, String tipo,String orden)
        {
            InitializeComponent();

            String comm1 = "SELECT com_opdetalles.IdOp, DATE_FORMAT(Coalesce(com_operaciones.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_operaciones.Descripcion AS Concepto, com_operaciones.IdEntidad AS Titular, ctos_entidades_1.Entidad AS NTitular, com_opdetalles.IdOpDet, com_opdetalles.IdRecibo, com_opdetalles.IdEntidad AS Pagador, ctos_entidades.Entidad AS NPagador, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte, com_estadosCuotas.Descripcion AS Estado FROM(((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_entidades AS ctos_entidades_1 ON com_operaciones.IdEntidad = ctos_entidades_1.IDEntidad) LEFT JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota WHERE(((com_operaciones.IdDivision) = " + id_division + ") AND((com_opdetalles.ImpOpDetPte) <> 0) AND((com_opdetalles.IdEstado) < 3));";

            String comm2 = "SELECT ctos_entidades.Entidad, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, ctos_entidades.IDEntidad, ctos_entidades.CIF, ctos_detdirecent.Ppal FROM ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + id_entidad + ") AND((ctos_detdirecent.Ppal) = -1));";

            String comm3 = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_cuentas.NumCuenta, com_cuentas.Descripcion FROM((ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad) INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad) INNER JOIN com_cuentas ON com_comunidades.IdComunidad = com_cuentas.IdComunidad WHERE(((com_cuentas.Ppal) = -1) AND((com_comunidades.IdComunidad) = " + id_comunidad + "));";


            bindingSource1.DataSource = null;
            bindingSource2.DataSource = null;
            bindingSource3.DataSource = null;

            if (Persistencia.SentenciasSQL.select(comm1).Rows.Count == 0) { }
            bindingSource1.DataSource = Persistencia.SentenciasSQL.select(comm1);
            bindingSource2.DataSource = Persistencia.SentenciasSQL.select(comm2);
            bindingSource3.DataSource = Persistencia.SentenciasSQL.select(comm3);

            ReportParameter parametro = new ReportParameter("ReportParameterComunero", id_comunero);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

            ReportParameter parametro1 = new ReportParameter("ReportParameterDivision", division);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro1 });

            ReportParameter parametro2 = new ReportParameter("ReportParameterTipo", tipo);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro2 });

            ReportParameter parametro3 = new ReportParameter("ReportParameterOrden", orden);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro3});

            this.reportViewer1.RefreshReport();
            
        }

        private void VistaInformeDeudasDivision_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
