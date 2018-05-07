using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticular
{
    public partial class FormVerInformeParticular : Form
    {
        String idEntidadPasado;
        String idLiquidacionPasado;
        String idComunidad;

        public FormVerInformeParticular(String idComunidad, String idLiquidacionPasado,String idEntidadPasado)
        {
            InitializeComponent();
            this.idEntidadPasado = idEntidadPasado;
            this.idLiquidacionPasado = idLiquidacionPasado;
            this.idComunidad = idComunidad;

            String com2 = "SELECT com_liqreparto.IdLiqReparto, com_liqreparto.DivPar, com_liqreparto.IdDivPar, com_liqreparto.Nombre, com_liqreparto.IdTitular, com_liqreparto.Titular, com_liqreparto.Descripcion, com_liqreparto.IdBloque, com_liqreparto.ImpBloque, com_liqreparto.CGB, com_liqreparto.CGP, com_liqreparto.Importe FROM com_liqreparto WHERE(((com_liqreparto.IdLiquidacion) = " + idLiquidacionPasado +") AND((com_liqreparto.DivPar) = 1) AND((com_liqreparto.IdTitular) = " + idEntidadPasado + ")) ORDER BY com_liqreparto.Nombre;";

            DataTable reparto = Persistencia.SentenciasSQL.select(com2);
            repartoBindingSource1.DataSource = reparto;

            String ResumenLiq = "SELECT com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA` as TITSUBCTA , Sum((`com_opdetliquidacion`.`Importe`*`com_opdetbloques`.`Porcentaje`)*IF(`com_subcuentas`.`ES`=1,-1,1)) AS TotalSub, com_liquidaciones.Notas FROM((((com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion GROUP BY com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA`, com_liquidaciones.Notas, com_bloques.IdTipoBloque, com_operaciones.IdTipoReparto HAVING(((com_operaciones.IdComunidad) = " + idComunidad + ") AND((com_opdetliquidacion.IdLiquidacion) = " + idLiquidacionPasado + ") AND((com_operaciones.IdSubCuenta)Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900) AND((Sum((`com_opdetliquidacion`.`Importe` * `com_opdetbloques`.`Porcentaje`) * IF(`com_subcuentas`.`ES` = 1, -1, 1))) <> 0) AND((com_bloques.IdTipoBloque) = 1) AND((com_operaciones.IdTipoReparto) = 1)) ORDER BY com_opdetbloques.IdBloque, com_bloques.Descripcion, com_subcuentas.`TIT SUBCTA`;";
            dataSetLiqResumenBindingSource.DataSource = Persistencia.SentenciasSQL.select(ResumenLiq);

            String Comunidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_cuentas.NumCuenta, com_cuentas.Descripcion FROM((ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad) INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad) INNER JOIN com_cuentas ON com_comunidades.IdComunidad = com_cuentas.IdComunidad WHERE(((com_cuentas.Ppal) = -1) AND((com_comunidades.IdComunidad) = " + idComunidad + "));";
            dataSet2BindingSource.DataSource = Persistencia.SentenciasSQL.select(Comunidad);

            String Entidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, ctos_entidades.IDEntidad FROM ctos_detdirecent INNER JOIN (ctos_entidades INNER JOIN com_comuneros ON ctos_entidades.IDEntidad = com_comuneros.IdEntidad) ON ctos_detdirecent.IdDireccion = com_comuneros.IdDireccion WHERE(((ctos_entidades.IDEntidad) = " + idEntidadPasado + "));";

            dataSet2BindingSource1.DataSource = Persistencia.SentenciasSQL.select(Entidad);

            String Liquidacion_info = "SELECT com_liquidaciones.Liquidacion, com_liquidaciones.LiqLargo, com_comunidades.Referencia, ctos_entidades.NombreCorto FROM((com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio) INNER JOIN com_comunidades ON com_ejercicios.IdComunidad = com_comunidades.IdComunidad) INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_liquidaciones.IdLiquidacion) = " + idLiquidacionPasado + "));";

            dataSetLiqInformacionBindingSource.DataSource = Persistencia.SentenciasSQL.select(Liquidacion_info);
        }

        private void FormVerInformeParticular_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

    }
}