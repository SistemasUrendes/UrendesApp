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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularRecibo
{
    public partial class FormVerInformeParticularRecibo : Form
    {
        DataTable newTable = new DataTable();

        public FormVerInformeParticularRecibo(String IdLiquidacion, String IdComunidad, String IdEntidad,String IdRecibo,String NombreLiquidacion)
        {

            InitializeComponent();
            ReciboBindingSource.Dispose();

            //String sqlSelectInforme = "SELECT com_opdetalles.IdOpDet, com_opdetalles.IdOp, DATE_FORMAT(Coalesce(com_opdetalles.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_operaciones.Descripcion AS DescripcionRecibo, com_operaciones.ImpOp, com_opdetalles.Importe AS ImporteDetalle, com_opdetalles.IdRecibo, com_recibos.Referencia, com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.CalculoSubcuota, com_liqreparto.Importe, com_operaciones.IdDivision AS IdDivisionOP, com_recibos.ImpRbo FROM(((com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_recibos ON com_opdetalles.IdRecibo = com_recibos.IdRecibo) INNER JOIN com_liqreparto ON (com_operaciones.IdEntidad = com_liqreparto.IdTitular) AND(com_opdetliquidacion.IdLiquidacion = com_liqreparto.IdLiquidacion) GROUP BY com_opdetalles.IdOpDet, com_opdetalles.IdOp, com_operaciones.Descripcion, com_operaciones.ImpOp, com_opdetalles.Importe, com_opdetalles.IdRecibo, com_recibos.Referencia, com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.CalculoSubcuota, com_liqreparto.Importe, com_operaciones.IdDivision, com_opdetalles.Fecha, com_opdetalles.IdEntidad, com_opdetliquidacion.IdLiquidacion, com_operaciones.IdCuota, com_recibos.ImpRbo HAVING(((com_opdetalles.IdRecibo) = " + IdRecibo + ") AND((com_opdetliquidacion.IdLiquidacion) = " + IdLiquidacion + ") AND((com_operaciones.IdCuota)Is Not Null));";

            String sqlSelectInforme = "SELECT com_opdetalles.IdOpDet, com_opdetalles.IdOp, DATE_FORMAT(Coalesce(com_opdetalles.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_operaciones.Descripcion AS DescripcionRecibo, com_operaciones.ImpOp, com_opdetalles.Importe AS ImporteDetalle, com_opdetalles.IdRecibo, com_recibos.Referencia, com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.CalculoSubcuota, com_liqreparto.Importe, com_operaciones.IdDivision AS IdDivisionOP, com_recibos.ImpRbo, com_subcuotas.Parte FROM com_subcuotas INNER JOIN ((((com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_recibos ON com_opdetalles.IdRecibo = com_recibos.IdRecibo) INNER JOIN com_liqreparto ON (com_opdetliquidacion.IdLiquidacion = com_liqreparto.IdLiquidacion) AND(com_operaciones.IdEntidad = com_liqreparto.IdTitular)) ON(com_liqreparto.IdBloque = com_subcuotas.IdBloque) AND(com_subcuotas.IdDivision = com_liqreparto.IdDivision) GROUP BY com_opdetalles.IdOpDet, com_opdetalles.IdOp, com_opdetalles.Fecha, com_operaciones.Descripcion, com_operaciones.ImpOp, com_opdetalles.Importe, com_opdetalles.IdRecibo, com_recibos.Referencia, com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.CalculoSubcuota, com_liqreparto.Importe, com_operaciones.IdDivision, com_recibos.ImpRbo, com_opdetalles.IdEntidad, com_opdetliquidacion.IdLiquidacion, com_operaciones.IdCuota, com_subcuotas.Parte HAVING(((com_opdetalles.IdRecibo) = " + IdRecibo + ") AND((com_opdetliquidacion.IdLiquidacion) = " + IdLiquidacion + ") AND((com_operaciones.IdCuota)Is Not Null));";

            ReciboBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectInforme);

            String sqlSelectInfoEntidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia FROM ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + IdEntidad + ") AND (ctos_detdirecent.Ppal = -1));";

            dataSetInfoEntidadxsdBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectInfoEntidad);

            String sqlSelectInfoComunidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_cuentas.Descripcion, com_cuentas.NumCuenta, com_comunidades.IdComunidad FROM com_cuentas INNER JOIN (com_comunidades INNER JOIN(ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad) ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad) ON com_cuentas.IdComunidad = com_comunidades.IdComunidad WHERE(((com_comunidades.IdComunidad) = " + IdComunidad + ") AND((com_cuentas.Ppal) = -1));";

            dataSet2BindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectInfoComunidad);

            //////////////////////////////RESUMEN DE GASTOS

            String sqlTipoInforme = "SELECT IdTipoInformeLiq FROM com_comunidades WHERE IdComunidad = " + IdComunidad;
            DataTable TipoInforme = Persistencia.SentenciasSQL.select(sqlTipoInforme);

            if (TipoInforme.Rows.Count > 0)
            {
                if (TipoInforme.Rows[0][0].ToString() == "1") //INFORME COMPLETO
                {

                    String ResumenLiq = "SELECT com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA` as TITSUBCTA , Sum((`com_opdetliquidacion`.`Importe`*`com_opdetbloques`.`Porcentaje`)*IF(`com_subcuentas`.`ES`=1,-1,1)) AS TotalSub, com_liquidaciones.Notas FROM((((com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion GROUP BY com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA`, com_liquidaciones.Notas, com_bloques.IdTipoBloque, com_operaciones.IdTipoReparto HAVING(((com_operaciones.IdComunidad) = " + IdComunidad + ") AND((com_opdetliquidacion.IdLiquidacion) = " + IdLiquidacion + ") AND((com_operaciones.IdSubCuenta)Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900) AND((Sum((`com_opdetliquidacion`.`Importe` * `com_opdetbloques`.`Porcentaje`) * IF(`com_subcuentas`.`ES` = 1, -1, 1))) <> 0) AND((com_bloques.IdTipoBloque) = 1) AND((com_operaciones.IdTipoReparto) = 1)) ORDER BY com_opdetbloques.IdBloque, com_bloques.Descripcion, com_subcuentas.`TIT SUBCTA`;";

                    dataSetLiqResumenBindingSource.DataSource = Persistencia.SentenciasSQL.select(ResumenLiq);
                }
                else if (TipoInforme.Rows[0][0].ToString() == "2") //INFORME ESPEFICIFO BLOQUE
                {
                    newTable = new DataTable();

                    String ResumenLiq = "SELECT com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA` as TITSUBCTA , Sum((`com_opdetliquidacion`.`Importe`*`com_opdetbloques`.`Porcentaje`)*IF(`com_subcuentas`.`ES`=1,-1,1)) AS TotalSub, com_liquidaciones.Notas FROM((((com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion GROUP BY com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA`, com_liquidaciones.Notas, com_bloques.IdTipoBloque, com_operaciones.IdTipoReparto HAVING(((com_operaciones.IdComunidad) = " + IdComunidad + ") AND((com_opdetliquidacion.IdLiquidacion) = " + IdLiquidacion + ") AND((com_operaciones.IdSubCuenta)Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900) AND((Sum((`com_opdetliquidacion`.`Importe` * `com_opdetbloques`.`Porcentaje`) * IF(`com_subcuentas`.`ES` = 1, -1, 1))) <> 0) AND((com_bloques.IdTipoBloque) = 1) AND((com_operaciones.IdTipoReparto) = 1)) ORDER BY com_opdetbloques.IdBloque, com_bloques.Descripcion, com_subcuentas.`TIT SUBCTA`;";

                    DataTable gastos = Persistencia.SentenciasSQL.select(ResumenLiq);

                    String sqlbloques = "SELECT com_liqreparto.IdLiquidacion, com_recibos.IdRecibo, com_liqreparto.IdBloque FROM((com_recibos INNER JOIN com_opdetalles ON com_recibos.IdRecibo = com_opdetalles.IdRecibo) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_liqreparto ON com_operaciones.IdDivision = com_liqreparto.IdDivision GROUP BY com_liqreparto.IdLiquidacion, com_recibos.IdRecibo, com_liqreparto.IdBloque HAVING(((com_liqreparto.IdLiquidacion) = " + IdLiquidacion + ") AND((com_recibos.IdRecibo) = " + IdRecibo + "));";

                    DataTable bloques = Persistencia.SentenciasSQL.select(sqlbloques);

                    var result = from x in bloques.AsEnumerable()
                                 join y in gastos.AsEnumerable() on x.Field<int>("IdBloque") equals y.Field<int>("IdBloque")
                                 into xy
                                 from y in xy.DefaultIfEmpty()
                                 select new
                                 {
                                     ID = y.Field<int>("IdBloque"),
                                     Field1 = y.Field<string>("Descripcion"),
                                     Field2 = y.Field<int>("IdSubCuenta"),
                                     Field3 = y.Field<string>("TITSUBCTA"),
                                     Field4 = y.Field<double>("TotalSub"),
                                     Field5 = y.Field<string>("Notas"),
                                 };

                    newTable.Columns.Add("IdBloque", typeof(int));
                    newTable.Columns.Add("Descripcion", typeof(string));
                    newTable.Columns.Add("IdSubCuenta", typeof(int));
                    newTable.Columns.Add("TITSUBCTA", typeof(string));
                    newTable.Columns.Add("TotalSub", typeof(double));
                    newTable.Columns.Add("Notas", typeof(string));



                    foreach (var rowInfo in result)
                        newTable.Rows.Add(rowInfo.ID, rowInfo.Field1, rowInfo.Field2, rowInfo.Field3, rowInfo.Field4, rowInfo.Field5);

                    dataSetLiqResumenBindingSource.DataSource = newTable;
                }
            }

            ReportParameter parametro = new ReportParameter("NombreLiquidacion", NombreLiquidacion);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

        }

        private void FormVerInformeParticularRecibo_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
