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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.Informes
{
    public partial class FormVerInformeResumen : Form
    {
        public FormVerInformeResumen(String idComunidad, String idLiquidacion)
        {
            InitializeComponent();

            ReportParameter[] parametros = new ReportParameter[1];
            String nombreComunidad = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Entidad FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + idComunidad + "));")).Rows[0][0].ToString();
            parametros[0] = new ReportParameter("nombreComunidad", nombreComunidad);

            this.reportViewer1.LocalReport.SetParameters(parametros);


            String comm1 = "SELECT com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA` as TITSUBCTA , Sum((`com_opdetliquidacion`.`Importe`*`com_opdetbloques`.`Porcentaje`)*IF(`com_subcuentas`.`ES`=1,-1,1)) AS TotalSub, com_liquidaciones.Notas FROM((((com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion GROUP BY com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA`, com_liquidaciones.Notas, com_bloques.IdTipoBloque, com_operaciones.IdTipoReparto HAVING(((com_operaciones.IdComunidad) = " + idComunidad + ") AND((com_opdetliquidacion.IdLiquidacion) = " + idLiquidacion + ") AND((com_operaciones.IdSubCuenta)Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900) AND((Sum((`com_opdetliquidacion`.`Importe` * `com_opdetbloques`.`Porcentaje`) * IF(`com_subcuentas`.`ES` = 1, -1, 1))) <> 0) AND((com_bloques.IdTipoBloque) = 1) AND((com_operaciones.IdTipoReparto) = 1)) ORDER BY com_opdetbloques.IdBloque, com_bloques.Descripcion, com_subcuentas.`TIT SUBCTA`;";

                LiquidacionBindingSource.DataSource = Persistencia.SentenciasSQL.select(comm1);

            String com2 = "SELECT com_liquidaciones.Liquidacion, com_liquidaciones.LiqLargo, com_comunidades.Referencia, ctos_entidades.NombreCorto FROM((com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio) INNER JOIN com_comunidades ON com_ejercicios.IdComunidad = com_comunidades.IdComunidad) INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_liquidaciones.IdLiquidacion) = " + idLiquidacion + "));";

            dataSetLiqInformacionBindingSource.DataSource = Persistencia.SentenciasSQL.select(com2);

        }

        private void FormVerInformeDetallado_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
