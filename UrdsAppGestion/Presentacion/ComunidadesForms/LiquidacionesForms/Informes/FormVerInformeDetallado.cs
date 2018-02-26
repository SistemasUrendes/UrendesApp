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
    public partial class FormVerInformeDetallado : Form
    {
        public FormVerInformeDetallado(String idLiquidacion)
        {
            InitializeComponent();
            String com1 = "SELECT com_operaciones.IdOp, com_operaciones.Documento, ctos_entidades.Entidad, com_operaciones.Descripcion AS DescOp, DATE_FORMAT(Coalesce(com_operaciones.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_opdetbloques.IdBloque, com_bloques.Descripcion AS DescBloq, com_operaciones.ImpOp*IF(com_subcuentas.ES=1,-1,1) AS ImpOp, com_opdetliquidacion.Importe*IF(com_subcuentas.ES=1,-1,1) AS ImpLiq, com_opdetbloques.Porcentaje, com_operaciones.IdSubCuenta, com_liquidaciones.Notas,com_opdetliquidacion.Importe*IF(com_subcuentas.ES=1,-1,1) * com_opdetbloques.Porcentaje AS ImpBloque FROM(((((com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion) INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad GROUP BY com_operaciones.IdComunidad, com_liquidaciones.IdEjercicio, com_opdetliquidacion.IdLiquidacion, com_operaciones.IdOp, com_operaciones.Documento, ctos_entidades.Entidad, com_operaciones.Descripcion, com_operaciones.Fecha, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.ImpOp* IF(com_subcuentas.ES= 1,-1,1), com_opdetliquidacion.Importe* IF(com_subcuentas.ES= 1,-1,1), com_opdetbloques.Porcentaje, com_operaciones.IdSubCuenta, com_operaciones.IdTipoReparto, com_liquidaciones.Notas HAVING(((com_opdetliquidacion.IdLiquidacion)=" + idLiquidacion + ") AND((com_operaciones.IdSubCuenta) Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900) AND((com_operaciones.IdTipoReparto)=1)) ORDER BY com_operaciones.IdOp, com_opdetbloques.IdBloque, com_bloques.Descripcion;";

            bindingSource1.DataSource = Persistencia.SentenciasSQL.select(com1);


            String com2 = "SELECT com_liquidaciones.Liquidacion, com_liquidaciones.LiqLargo, com_comunidades.Referencia, ctos_entidades.NombreCorto FROM((com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio) INNER JOIN com_comunidades ON com_ejercicios.IdComunidad = com_comunidades.IdComunidad) INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_liquidaciones.IdLiquidacion) = " + idLiquidacion + "));";

            bindingSource2.DataSource = Persistencia.SentenciasSQL.select(com2);



        }

        private void FormVerInformeDetallado_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
