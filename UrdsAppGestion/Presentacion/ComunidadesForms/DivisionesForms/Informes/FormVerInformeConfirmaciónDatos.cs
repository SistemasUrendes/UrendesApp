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
    public partial class FormVerInformeConfirmaciónDatos : Form
    {
        public FormVerInformeConfirmaciónDatos(String IdComunidad, String IdComunero, String IdDivision, String NombreDivision, String tipoDivision, String IdEntidad)
        {
            InitializeComponent();

            String sqlSelectComuneros = "SELECT aux_formapago.FormaPago, com_comuneros.EnvioPostal, com_comuneros.EnvioEmail, com_comuneros.IVA, com_comuneros.IdEntidad FROM com_comuneros INNER JOIN aux_formapago ON com_comuneros.IdFormaPago = aux_formapago.IdFormaPago WHERE(((com_comuneros.IdComunero) = " + IdComunero + ") AND((com_comuneros.IdComunidad) = " + IdComunidad + "));";

            dataSetInformacionComunerosBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectComuneros);

            String sqlSelectAsociacion = "SELECT ctos_entidades.Entidad, com_asociacion.Participacion, com_asociacion.Ppal FROM(com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_asociacion.IdDivision) = " + IdDivision + "));";

            dataSetAsociacionBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectAsociacion);

            String sqlSelectTelefonos = "SELECT ctos_dettelf.IdEntidad, ctos_dettelf.Telefono, ctos_dettelf.Orden FROM ctos_dettelf INNER JOIN com_comuneros ON ctos_dettelf.IdEntidad = com_comuneros.IdEntidad WHERE(((com_comuneros.IdComunidad) = " + IdComunidad + "));";

            dataSetTelefonosComunerosBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectTelefonos);

            String sqlSelectDirecciones = "SELECT ctos_detdirecent.IdDireccion, ctos_detdirecent.IdEntidad, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia FROM ctos_detdirecent INNER JOIN com_comuneros ON ctos_detdirecent.IdEntidad = com_comuneros.IdEntidad WHERE(((com_comuneros.IdComunidad) = " + IdComunidad + "));";
            dataSetDireccionesBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectDirecciones);

            String sqlSelectEmails = "SELECT ctos_detemail.IdEmail, ctos_detemail.IdEntidad, ctos_detemail.Email FROM com_comuneros INNER JOIN ctos_detemail ON com_comuneros.IdEntidad = ctos_detemail.IdEntidad WHERE(((com_comuneros.IdComunidad) = " + IdComunidad + "));";
            dataSetEmailsBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectEmails);

            String Entidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, ctos_entidades.IDEntidad FROM ctos_detdirecent INNER JOIN (ctos_entidades INNER JOIN com_comuneros ON ctos_entidades.IDEntidad = com_comuneros.IdEntidad) ON ctos_detdirecent.IdDireccion = com_comuneros.IdDireccion WHERE(((ctos_entidades.IDEntidad) = " + IdEntidad + "));";

            dataSetInfoEntidadxsdBindingSource.DataSource = Persistencia.SentenciasSQL.select(Entidad);

            ReportParameter parametro = new ReportParameter("Division", NombreDivision);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

            ReportParameter parametro2 = new ReportParameter("TipoDivision", tipoDivision);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro2 });

            ReportParameter parametro3 = new ReportParameter("IdEntidad", IdEntidad);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro3 });
        }

        private void FormVerInformeConfirmaciónDatos_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
