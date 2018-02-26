using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    public partial class FormVerVencimientos : Form
    {
        String id_mov_cargado;

        public FormVerVencimientos(String id_mov_cargado)
        {
            InitializeComponent();
            this.id_mov_cargado = id_mov_cargado;
        }

        private void FormVerVencimientos_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String sql = "SELECT com_detmovs.IdDetMov, com_operaciones.IdOp, com_operaciones.Descripcion, com_opdetalles.Fecha, com_detmovs.Importe, com_opdetalles.IdRecibo FROM(((com_operaciones INNER JOIN(com_detmovs INNER JOIN com_opdetalles ON com_detmovs.IdOpDet = com_opdetalles.IdOpDet) ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_movimientos ON com_detmovs.IdMov = com_movimientos.IdMov) INNER JOIN com_dettiposmov ON com_movimientos.IdDetTipoMov = com_dettiposmov.IdDetTipoMov) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE(((com_detmovs.IdMov) = " + id_mov_cargado + "));";

            dataGridView_vencmientos.DataSource = Persistencia.SentenciasSQL.select(sql);
            dataGridView_vencmientos.Columns["Descripcion"].Width = 300;
            dataGridView_vencmientos.Columns["Importe"].DefaultCellStyle.Format = "c";

        }

        private void dataGridView_vencmientos_DoubleClick(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView_vencmientos.SelectedRows[0].Cells[1].Value.ToString(), 2);
            nueva.Show();
        }

        private void dataGridView_vencmientos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_vencmientos.HitTest(e.X, e.Y);
                dataGridView_vencmientos.ClearSelection();
                dataGridView_vencmientos.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void verOperaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView_vencmientos.SelectedRows[0].Cells[1].Value.ToString(), 2);
            nueva.Show();
        }
    }
}
