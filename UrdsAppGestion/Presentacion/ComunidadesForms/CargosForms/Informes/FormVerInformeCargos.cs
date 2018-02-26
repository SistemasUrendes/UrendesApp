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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms.Informes
{
    public partial class FormVerInformeCargos : Form
    {
        public FormVerInformeCargos(String idComunidad)
        {
            InitializeComponent();

            String nombreComunidad = "SELECT ctos_entidades.Entidad FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + idComunidad + "));";

            nombreComunidad = (Persistencia.SentenciasSQL.select(nombreComunidad)).Rows[0][0].ToString();

            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("ReportParameterNombreComunidad", nombreComunidad);

            String cargos = "SELECT com_cargos.Cargo, com_organos.Nombre, ctos_entidades.Entidad, com_divisiones.Division, DATE_FORMAT(Coalesce(com_cargoscom.FInicio,'ok'),'%d/%m/%Y') AS FInicio FROM(com_divisiones RIGHT JOIN(((com_cargos INNER JOIN com_cargoscom ON com_cargos.IdCargo = com_cargoscom.IdCargo) INNER JOIN com_comuneros ON com_cargoscom.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) ON com_divisiones.IdDivision = com_comuneros.IdDivPpal) LEFT JOIN com_organos ON com_cargos.IdOrgano = com_organos.IdOrgano GROUP BY com_cargoscom.IdCargoCom, com_cargos.Cargo, com_organos.Nombre, ctos_entidades.Entidad, com_comuneros.IdEntidad, com_divisiones.Division, com_cargoscom.FInicio, com_cargoscom.FFin, com_cargoscom.IdComunidad HAVING(((com_cargoscom.FFin)Is Null) AND((com_cargoscom.IdComunidad) = " + idComunidad + "));";

            CargosBindingSource.DataSource = Persistencia.SentenciasSQL.select(cargos);

            reportViewer1.LocalReport.SetParameters(parameters);

        }

        private void FormVerInformeCargos_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
