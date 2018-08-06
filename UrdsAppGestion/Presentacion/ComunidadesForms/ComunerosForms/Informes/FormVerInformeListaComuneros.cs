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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms.Informes
{
    public partial class FormVerInformeListaComuneros : Form
    {
        DataTable telefonos = null;
        DataTable correos = null;
        DataTable cuentas = null;
        DataTable direecciones = null;

        public FormVerInformeListaComuneros(String idComunidad)
        {
            InitializeComponent();

            String sqlSelect = "SELECT com_comuneros.IdComunero, com_comuneros.IdEntidad, ctos_entidades.Entidad, com_comuneros.Asociaciones, aux_formapago.FormaPago, com_comuneros.EnvioEmail, com_comuneros.EnvioPostal, com_comuneros.IdEmail, com_comuneros.IdCC, com_comuneros.IdDireccion FROM(com_comuneros INNER JOIN aux_formapago ON com_comuneros.IdFormaPago = aux_formapago.IdFormaPago) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE (((com_comuneros.IdComunidad) = " + idComunidad + "));";

            ComunerosBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);

            String sqlSelectTelefonos = "SELECT ctos_dettelf.IdEntidad, ctos_dettelf.Telefono, ctos_dettelf.Orden FROM ctos_dettelf INNER JOIN com_comuneros ON ctos_dettelf.IdEntidad = com_comuneros.IdEntidad WHERE(((com_comuneros.IdComunidad) = " + idComunidad + "));";
            telefonos = Persistencia.SentenciasSQL.select(sqlSelectTelefonos);

            String sqlSelectEmails = "SELECT ctos_detemail.IdEmail, ctos_detemail.IdEntidad, ctos_detemail.Email FROM com_comuneros INNER JOIN ctos_detemail ON com_comuneros.IdEntidad = ctos_detemail.IdEntidad WHERE(((com_comuneros.IdComunidad) = " + idComunidad + "));";
            correos = Persistencia.SentenciasSQL.select(sqlSelectEmails);

            String sqlSelectCuentas = "SELECT ctos_detbancos.IdCuenta, ctos_detbancos.IdEntidad, ctos_detbancos.CC FROM ctos_detbancos INNER JOIN com_comuneros ON ctos_detbancos.IdEntidad = com_comuneros.IdEntidad WHERE(((com_comuneros.IdComunidad) = " + idComunidad + "));";
            cuentas = Persistencia.SentenciasSQL.select(sqlSelectCuentas);

            String sqlSelectDirecciones = "SELECT ctos_detdirecent.IdDireccion, ctos_detdirecent.IdEntidad, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia FROM ctos_detdirecent INNER JOIN com_comuneros ON ctos_detdirecent.IdEntidad = com_comuneros.IdEntidad WHERE(((com_comuneros.IdComunidad) = " + idComunidad + "));";
            direecciones = Persistencia.SentenciasSQL.select(sqlSelectDirecciones);

            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);

        }

        private void FormVerInformeListaComuneros_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSet1", (object)telefonos));
            e.DataSources.Add(new ReportDataSource("DataSet2", (object)correos));
            e.DataSources.Add(new ReportDataSource("DataSet3", (object)cuentas));
            e.DataSources.Add(new ReportDataSource("DataSet4", (object)direecciones));
        }
    }
}
