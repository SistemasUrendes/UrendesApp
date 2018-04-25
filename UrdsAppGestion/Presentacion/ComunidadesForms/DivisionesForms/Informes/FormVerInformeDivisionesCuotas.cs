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
    public partial class FormVerInformeDivisionesCuotas : Form
    {
        public FormVerInformeDivisionesCuotas(String idDivision, String idComunidad, String fechaInicio, String fechaFin, String nombreDivision)
        {
            InitializeComponent();
            String fechaInicio2 = (Convert.ToDateTime(fechaInicio)).ToString("yyyy-MM-dd");
            String fechaFin2 = (Convert.ToDateTime(fechaFin)).ToString("yyyy-MM-dd");

            String sqlSelectCuotas = "SELECT com_operaciones.IdOp, DATE_FORMAT(Coalesce(com_operaciones.Fecha, 'ok'), '%d/%m/%Y') AS Fecha, ctos_entidades.Entidad, com_operaciones.Descripcion, com_operaciones.ImpOp FROM com_operaciones INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad WHERE (((com_operaciones.IdDivision) = " + idDivision + ") AND com_operaciones.Fecha >= '" + fechaInicio2 + "' AND com_operaciones.Fecha <= '" + fechaFin2 + "' );";

            DataTable cuotas = Persistencia.SentenciasSQL.select(sqlSelectCuotas);

            dataSetCuotasDivisionBindingSource.DataSource = cuotas;

            String sqlSelectEntidad = "SELECT com_comuneros.IdEntidad FROM(com_divisiones INNER JOIN com_asociacion ON com_divisiones.IdDivision = com_asociacion.IdDivision) INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero WHERE(((com_divisiones.IdDivision) = " + idDivision + ") AND((com_asociacion.Ppal) = -1));";

            DataTable entidad = Persistencia.SentenciasSQL.select(sqlSelectEntidad);

            String sqlSelectInfoComunidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_cuentas.Descripcion, com_cuentas.NumCuenta, com_comunidades.IdComunidad FROM com_cuentas INNER JOIN (com_comunidades INNER JOIN(ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad) ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad) ON com_cuentas.IdComunidad = com_comunidades.IdComunidad WHERE(((com_comunidades.IdComunidad) = " + idComunidad + ") AND((com_cuentas.Ppal) = -1));";

            dataSet2BindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectInfoComunidad);

            String cabecera = "DIVISIÓN : " + nombreDivision + "                                                                            PERÍODO: " + fechaInicio + " A " + fechaFin;

            ReportParameter parametro = new ReportParameter("ReportParameter1", cabecera);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

            if (entidad.Rows.Count == 1) {
                String sqlSelectInfoEntidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia FROM ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + entidad.Rows[0][0].ToString() + ") AND (ctos_detdirecent.Ppal = -1));";
                dataSetInfoEntidadxsdBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectInfoEntidad);
            }else {
                MessageBox.Show("La división tiene más de un representante.");
                this.Close();
            }  

        }

        private void FormVerInformeDivisionesCuotas_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
