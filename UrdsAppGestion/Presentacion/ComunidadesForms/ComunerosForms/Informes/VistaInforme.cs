using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    public partial class VistaInforme : Form
    {
        public VistaInforme(String id_comunero,String id_comunidad,String id_entidad)
        {
            InitializeComponent();

            String comm1 = "SELECT com_opdetalles.IdEntidad, com_opdetalles.IdOpDet, com_opdetalles.IdOp, com_opdetalles.IdRecibo, IF(com_operaciones.IdSubCuenta = 43801, com_subcuentas.`TIT SUBCTA`, com_operaciones.Descripcion) AS Descripcion, DATE_FORMAT(Coalesce(com_opdetalles.Fecha,'ok'),'%d/%m/%Y') AS Fecha, DATE_FORMAT(Coalesce(com_opdetalles.FechaPrev,'ok'),'%d/%m/%Y') AS FechaPrev, com_opdetalles.Importe, com_opdetalles.IdEstado, com_comuneros.Asociaciones, com_opdetalles.ImpOpDetPte FROM(((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN com_comuneros ON (com_operaciones.IdComunidad = com_comuneros.IdComunidad) AND(com_opdetalles.IdEntidad = com_comuneros.IdEntidad)) INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_opdetalles.IdEntidad) = " + id_entidad + ") AND((com_opdetalles.ImpOpDetPte) <> 0) AND((com_operaciones.IdSubCuenta)Between 70000 And 70001 OR (com_operaciones.IdSubCuenta)Between 71000 AND 72000 Or(com_operaciones.IdSubCuenta) = 10000 Or((com_operaciones.IdSubCuenta)Between 43800 And 46000))) ORDER BY com_opdetalles.Fecha;";

            String comm2 = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_cuentas.NumCuenta, com_cuentas.Descripcion FROM((ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad) INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad) INNER JOIN com_cuentas ON com_comunidades.IdComunidad = com_cuentas.IdComunidad WHERE(((com_cuentas.Ppal) = -1) AND((com_comunidades.IdComunidad) = " + id_comunidad + "));";


            String comm3 = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, ctos_entidades.IDEntidad FROM ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + id_entidad + "));";


            bindingSource1.DataSource = null;
            bindingSource2.DataSource = null;
            bindingSource3.DataSource = null;


            bindingSource3.DataSource = Persistencia.SentenciasSQL.select(comm1); ;
            bindingSource1.DataSource = Persistencia.SentenciasSQL.select(comm2); ;
            bindingSource2.DataSource = Persistencia.SentenciasSQL.select(comm3); ;


            this.reportViewer1.RefreshReport();
        }

        private void VistaInforme_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
