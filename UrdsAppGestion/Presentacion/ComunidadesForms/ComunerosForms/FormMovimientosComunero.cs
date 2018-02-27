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
    public partial class FormMovimientosComunero : Form
    {
        String idComunidad;
        String idEntidad;
        String nombreComunero;
        int curRow = -1;

        public FormMovimientosComunero(String idComunidad, String idEntidad, String nombreComunero)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idEntidad = idEntidad;
            this.nombreComunero = nombreComunero;
        }

        private void FormMovimientosComunero_Load(object sender, EventArgs e)
        {
            this.Text = "Movimientos [" + nombreComunero + "]";
            cargarDatagrid();
        }
        public void cargarDatagrid() {

            String sqlSelect = "SELECT com_movimientos.IdMov, com_movimientos.Fecha, com_movimientos.Detalle, com_dettiposmov.Descripcion as TipoMov, com_cuentas.Descripcion as Cuenta, Sum(com_detmovs.importe*If(Idtipomov=3,If(ES=1,1,Null),If(idtipomov=1,1,Null))) AS ImpEnt, Sum(com_detmovs.importe*If(Idtipomov=3,If(ES=2,1,Null),If(idtipomov=2,1,Null))) AS ImpSal FROM(((((com_movimientos INNER JOIN com_cuentas ON com_movimientos.IdCuenta = com_cuentas.IdCuenta) INNER JOIN com_dettiposmov ON com_movimientos.IdDetTipoMov = com_dettiposmov.IdDetTipoMov) INNER JOIN com_detmovs ON com_movimientos.IdMov = com_detmovs.IdMov) INNER JOIN com_opdetalles ON com_detmovs.IdOpDet = com_opdetalles.IdOpDet) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta GROUP BY com_movimientos.IdMov, com_movimientos.Fecha, com_movimientos.Detalle, com_movimientos.IdDetTipoMov, com_dettiposmov.Descripcion, com_dettiposmov.IdTipoMov, com_movimientos.IdCuenta, com_cuentas.Descripcion, com_movimientos.MovCA, com_cuentas.IdComunidad, com_movimientos.IdEntidad HAVING(((com_movimientos.IdEntidad) = " + idEntidad + ")) ORDER BY com_movimientos.IdMov DESC, com_movimientos.Fecha DESC;";

            DataTable movimientos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_movimientos.DataSource = movimientos;

            dataGridView_movimientos.Columns["ImpEnt"].DefaultCellStyle.Format = "c";
            dataGridView_movimientos.Columns["ImpSal"].DefaultCellStyle.Format = "c";
        }
        public void cargarDatagridDetalles() {
            String sqlSelect = "SELECT com_detmovs.IdDetMov, com_detmovs.IdOpDet, com_opdetalles.IdOp, com_operaciones.IdSubCuenta,com_opdetalles.Fecha,  com_operaciones.Descripcion,  com_opdetalles.Importe,com_opdetalles.IdRecibo FROM(((com_operaciones INNER JOIN(com_detmovs INNER JOIN com_opdetalles ON com_detmovs.IdOpDet = com_opdetalles.IdOpDet) ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_movimientos ON com_detmovs.IdMov = com_movimientos.IdMov) INNER JOIN com_dettiposmov ON com_movimientos.IdDetTipoMov = com_dettiposmov.IdDetTipoMov) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE(((com_detmovs.IdMov) = " + dataGridView_movimientos.SelectedRows[0].Cells[0].Value.ToString() + "));";

            label1.Text = "Detalles del Movimiento: " + dataGridView_movimientos.SelectedRows[0].Cells[0].Value.ToString();

            DataTable detalles = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_detallesmov.DataSource = detalles;
        }

        private void dataGridView_movimientos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_movimientos.CurrentRow.Index != curRow)
            {
                curRow = dataGridView_movimientos.CurrentRow.Index;
                cargarDatagridDetalles();
            }
        }

        private void button_imprimir_Click(object sender, EventArgs e)
        {
            ComunerosForms.FormImprimirMovimientos nueva = new ComunerosForms.FormImprimirMovimientos(nombreComunero, idComunidad, idEntidad);
            nueva.Show();
        }
    }
}
