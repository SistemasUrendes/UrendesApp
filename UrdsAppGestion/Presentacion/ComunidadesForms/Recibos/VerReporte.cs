using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;

namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    public partial class VerReporte : Form
    {
        public VerReporte(String idRecibo, String idEntidad,String idComunidad)
        {
            InitializeComponent();

            String comm = "SELECT com_recibos.IdRecibo, com_recibos.IdComunidad, ctos_entidades.Entidad,DATE_FORMAT(Coalesce(com_opdetalles.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_recibos.ImpRbo, com_recibos.Referencia, com_operaciones.Descripcion, com_opdetalles.Importe, com_operaciones.ImpOp, com_opdetalles.IdOpDet, com_opdetalles.IdOp, ctos_entidades.CIF FROM((com_recibos INNER JOIN ctos_entidades ON com_recibos.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_opdetalles ON com_recibos.IdRecibo = com_opdetalles.IdRecibo) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE(((com_recibos.IdRecibo) = " + idRecibo + "));";


            String comm2 = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_cuentas.NumCuenta, com_cuentas.Descripcion FROM((ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad) INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad) INNER JOIN com_cuentas ON com_comunidades.IdComunidad = com_cuentas.IdComunidad WHERE(((com_cuentas.Ppal) = -1) AND((com_comunidades.IdComunidad) = " + idComunidad + "));";


            String comm3 = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, ctos_entidades.IDEntidad FROM ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + idEntidad + "));";


            dataSetnuevoBindingSource.DataSource = null;
            bindingSource1.DataSource = null;

            dataSetnuevoBindingSource.DataSource = Persistencia.SentenciasSQL.select(comm);
            bindingSource1.DataSource = Persistencia.SentenciasSQL.select(comm2); ;       
            bindingSource2.DataSource = Persistencia.SentenciasSQL.select(comm3); ;       


            this.reportViewer1.RefreshReport();
        }

        private void VerReporte_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void dataSetnuevoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
