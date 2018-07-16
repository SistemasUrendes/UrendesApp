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

        public FormVerInformeParticularRecibo(String IdLiquidacion, String IdComunidad, String IdEntidad,String IdRecibo,String NombreLiquidacion, DataTable resumenGastos, DataTable infoComunidad)
        {

            InitializeComponent();
            ReciboBindingSource.Dispose();

            //String sqlSelectInforme = "SELECT com_opdetalles.IdOpDet, com_opdetalles.IdOp, DATE_FORMAT(Coalesce(com_opdetalles.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_operaciones.Descripcion AS DescripcionRecibo, com_operaciones.ImpOp, com_opdetalles.Importe AS ImporteDetalle, com_opdetalles.IdRecibo, com_recibos.Referencia, com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.CalculoSubcuota, com_liqreparto.Importe, com_operaciones.IdDivision AS IdDivisionOP, com_recibos.ImpRbo FROM(((com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_recibos ON com_opdetalles.IdRecibo = com_recibos.IdRecibo) INNER JOIN com_liqreparto ON (com_operaciones.IdEntidad = com_liqreparto.IdTitular) AND(com_opdetliquidacion.IdLiquidacion = com_liqreparto.IdLiquidacion) GROUP BY com_opdetalles.IdOpDet, com_opdetalles.IdOp, com_operaciones.Descripcion, com_operaciones.ImpOp, com_opdetalles.Importe, com_opdetalles.IdRecibo, com_recibos.Referencia, com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.CalculoSubcuota, com_liqreparto.Importe, com_operaciones.IdDivision, com_opdetalles.Fecha, com_opdetalles.IdEntidad, com_opdetliquidacion.IdLiquidacion, com_operaciones.IdCuota, com_recibos.ImpRbo HAVING(((com_opdetalles.IdRecibo) = " + IdRecibo + ") AND((com_opdetliquidacion.IdLiquidacion) = " + IdLiquidacion + ") AND((com_operaciones.IdCuota)Is Not Null));";

            // String sqlSelectInforme = "SELECT com_opdetalles.IdOpDet, com_opdetalles.IdOp, DATE_FORMAT(Coalesce(com_opdetalles.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_operaciones.Descripcion AS DescripcionRecibo, com_operaciones.ImpOp, com_opdetalles.Importe AS ImporteDetalle, com_opdetalles.IdRecibo, com_recibos.Referencia, com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.CalculoSubcuota, com_liqreparto.Importe, com_operaciones.IdDivision AS IdDivisionOP, com_recibos.ImpRbo, com_subcuotas.Parte FROM com_subcuotas INNER JOIN ((((com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_recibos ON com_opdetalles.IdRecibo = com_recibos.IdRecibo) INNER JOIN com_liqreparto ON (com_opdetliquidacion.IdLiquidacion = com_liqreparto.IdLiquidacion) AND(com_operaciones.IdEntidad = com_liqreparto.IdTitular)) ON(com_liqreparto.IdBloque = com_subcuotas.IdBloque) AND(com_subcuotas.IdDivision = com_liqreparto.IdDivision) GROUP BY com_opdetalles.IdOpDet, com_opdetalles.IdOp, com_opdetalles.Fecha, com_operaciones.Descripcion, com_operaciones.ImpOp, com_opdetalles.Importe, com_opdetalles.IdRecibo, com_recibos.Referencia, com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.CalculoSubcuota, com_liqreparto.Importe, com_operaciones.IdDivision, com_recibos.ImpRbo, com_opdetalles.IdEntidad, com_opdetliquidacion.IdLiquidacion, com_operaciones.IdCuota, com_subcuotas.Parte HAVING(((com_opdetalles.IdRecibo) = " + IdRecibo + ") AND((com_opdetliquidacion.IdLiquidacion) = " + IdLiquidacion + ") AND((com_operaciones.IdCuota)Is Not Null));";

            String sqlSelectInforme = "SELECT com_opdetalles.IdOpDet, com_opdetalles.IdOp, DATE_FORMAT(Coalesce(com_opdetalles.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_operaciones.Descripcion AS DescripcionRecibo, com_operaciones.ImpOp, com_opdetalles.Importe AS ImporteDetalle, com_opdetalles.IdRecibo, com_recibos.Referencia, com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.CalculoSubcuota, com_liqreparto.Importe, com_operaciones.IdDivision AS IdDivisionOP, com_recibos.ImpRbo, com_subcuotas.Parte FROM com_subcuotas INNER JOIN ((((com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_recibos ON com_opdetalles.IdRecibo = com_recibos.IdRecibo) INNER JOIN com_liqreparto ON (com_operaciones.IdEntidad = com_liqreparto.IdTitular) AND(com_opdetliquidacion.IdLiquidacion = com_liqreparto.IdLiquidacion)) ON(com_subcuotas.IdDivision = com_liqreparto.IdDivision) AND(com_subcuotas.IdBloque = com_liqreparto.IdBloque) WHERE(((com_opdetalles.IdRecibo) = " + IdRecibo + ") AND((com_opdetliquidacion.IdLiquidacion) = " + IdLiquidacion + ") AND((com_operaciones.IdCuota)Is Not Null));";

            ReciboBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectInforme);

            String sqlSelectInfoEntidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia FROM ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + IdEntidad + ") AND (ctos_detdirecent.Ppal = -1));";

            dataSetInfoEntidadxsdBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelectInfoEntidad);

            dataSet2BindingSource.DataSource = infoComunidad;

            dataSetLiqResumenBindingSource.DataSource = resumenGastos;

            ReportParameter parametro = new ReportParameter("NombreLiquidacion", NombreLiquidacion);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

        }

        private void FormVerInformeParticularRecibo_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
