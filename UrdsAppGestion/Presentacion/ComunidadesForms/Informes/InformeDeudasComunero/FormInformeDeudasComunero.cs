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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.Informes.InformeDeudasComunero
{
    public partial class FormInformeDeudasComunero : Form
    {
        public FormInformeDeudasComunero(String idComunidad)
        {
            InitializeComponent();

            ReportParameter[] parametros = new ReportParameter[1];

            String nombreComunidad = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Entidad FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + idComunidad + "));")).Rows[0][0].ToString();

            parametros[0] = new ReportParameter("NombreComunidad", nombreComunidad);

            String sqlDeudas = "SELECT com_operaciones.IdComunidad, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_opdetalles.IdOpDet, com_opdetalles.IdOp, com_opdetalles.IdRecibo, com_operaciones.Descripcion, DATE_FORMAT(Coalesce(com_opdetalles.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_opdetalles.Importe, com_comuneros.Asociaciones, com_opdetalles.ImpOpDetPte FROM(((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN com_comuneros ON (com_opdetalles.IdEntidad = com_comuneros.IdEntidad) AND(com_operaciones.IdComunidad = com_comuneros.IdComunidad)) INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_operaciones.IdComunidad) = " + idComunidad + ") AND((com_opdetalles.ImpOpDetPte) <> 0) AND((com_operaciones.IdSubCuenta)Between 70000 And 70001 OR (com_operaciones.IdSubCuenta)Between 71000 AND 72000 Or(com_operaciones.IdSubCuenta) = 10000)) ORDER BY com_opdetalles.Fecha;";

            this.reportViewer1.LocalReport.SetParameters(parametros);
            deudasComunerosBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlDeudas);

        }

        private void FormInformeDeudasComunero_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
