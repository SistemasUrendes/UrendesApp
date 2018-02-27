
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
    public partial class VistaInformeMovimientos : Form
    {
        public VistaInformeMovimientos(String comunero, String id_comunidad, String id_entidad, String fecha_ini, String fecha_fin)
        {
            InitializeComponent();
            /* 
             String comm1 = "SELECT com_detmovs.IdDetMov, com_detmovs.IdMov, com_dettiposmov.IdTipoMov, com_detmovs.IdOpDet, com_opdetalles.IdOp, com_operaciones.IdSubCuenta, com_subcuentas.`ES`, com_operaciones.Descripcion,DATE_FORMAT(Coalesce(com_opdetalles.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_opdetalles.IdRecibo, com_opdetalles.Importe, If(`IdTipoMov` = 3,If(`ES` = 1,`com_detmovs`.`Importe`,Null),If(`IdTipoMov`= 1, `com_detmovs`.`importe`, Null)) AS ImpEnt, If(`IdTipoMov` = 3, If(`ES` = 1, Null,`com_detmovs`.`Importe`), If(`IdTipoMov` = 1, Null,`com_detmovs`.`importe`)) AS ImpSal FROM(((com_operaciones INNER JOIN (com_detmovs INNER JOIN com_opdetalles ON com_detmovs.IdOpDet = com_opdetalles.IdOpDet) ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_movimientos ON com_detmovs.IdMov = com_movimientos.IdMov) INNER JOIN com_dettiposmov ON com_movimientos.IdDetTipoMov = com_dettiposmov.IdDetTipoMov) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE(((com_operaciones.IdEntidad)=" + id_entidad + "))";
             */

            //Ajuste fecha
            String fini = (Convert.ToDateTime(fecha_ini)).ToString("yyyy-MM-dd");
            String ffin = (Convert.ToDateTime(fecha_fin)).ToString("yyyy-MM-dd");

            String comm1 = "SELECT com_detmovs.IdDetMov, com_detmovs.IdMov, com_detmovs.IdOpDet, com_opdetalles.IdOp, com_operaciones.IdSubCuenta, com_subcuentas.`ES`, com_operaciones.Descripcion, DATE_FORMAT(Coalesce(com_movimientos.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_opdetalles.IdRecibo, com_opdetalles.Importe, If(`IdTipoMov` = 3,If(`ES` = 1,`com_detmovs`.`Importe`,Null),If(`IdTipoMov`= 1, `com_detmovs`.`importe`, Null)) AS ImpEnt, If(`IdTipoMov` = 3, If(`ES` = 1, Null,`com_detmovs`.`Importe`), If(`IdTipoMov` = 1, Null,`com_detmovs`.`importe`)) AS ImpSal, com_dettiposmov.Descripcion AS DescripcionMovimiento, com_cuentas.Descripcion AS DescripcionCuenta FROM com_cuentas INNER JOIN((((com_operaciones INNER JOIN (com_detmovs INNER JOIN com_opdetalles ON com_detmovs.IdOpDet = com_opdetalles.IdOpDet) ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_movimientos ON com_detmovs.IdMov = com_movimientos.IdMov) INNER JOIN com_dettiposmov ON com_movimientos.IdDetTipoMov = com_dettiposmov.IdDetTipoMov) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) ON com_cuentas.IdCuenta = com_movimientos.IdCuenta WHERE ((com_movimientos.Fecha >= '" + fini + "' AND com_movimientos.Fecha <= '" + ffin + "') AND ((com_movimientos.IdEntidad)= " + id_entidad + ")) ORDER BY com_movimientos.Fecha DESC;";
            

            String comm2 = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_cuentas.NumCuenta, com_cuentas.Descripcion FROM((ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad) INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad) INNER JOIN com_cuentas ON com_comunidades.IdComunidad = com_cuentas.IdComunidad WHERE(((com_cuentas.Ppal) = -1) AND((com_comunidades.IdComunidad) = " + id_comunidad + "));";


            bindingSource1.DataSource = null;
            bindingSource2.DataSource = null;


            bindingSource1.DataSource = Persistencia.SentenciasSQL.select(comm1); 
            bindingSource2.DataSource = Persistencia.SentenciasSQL.select(comm2);

            this.reportViewer1.RefreshReport();

            

            ReportParameter parametro = new ReportParameter("fecha_ini", fecha_ini);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

            ReportParameter parametro2 = new ReportParameter("fecha_fin", fecha_fin);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro2 });

            ReportParameter parametro3 = new ReportParameter("comunero", comunero);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro3 });
        }

        private void VistaInformeMovimientos_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
        
    }
}
