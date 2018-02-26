using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms
{
    public partial class FormCuotasDetalle : Form
    {
        String id_cuota_cargado;

        public FormCuotasDetalle(String id_cuota_cargado, String descripcion_cuota_cargado, String estado_cuota_cargado)
        {
            InitializeComponent();
            this.id_cuota_cargado = id_cuota_cargado;
            textBox_cuota.Text = descripcion_cuota_cargado;
            textBox_estado.Text = estado_cuota_cargado;
        }

        private void FormCuotasDetalle_Load(object sender, EventArgs e)
        {
            cargarDetalles();
        }
        private void cargarDetalles() {
            double total = 0.00;
            String sqlDetalles = "SELECT com_operaciones.IdOp, com_divisiones.Division, ctos_entidades.Entidad, com_operaciones.ImpOp, com_operaciones.ImpOpPte FROM(com_operaciones INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_divisiones ON com_operaciones.IdDivision = com_divisiones.IdDivision WHERE (((com_operaciones.IdCuota) = " + id_cuota_cargado +" ));";

            DataTable detalles = Persistencia.SentenciasSQL.select(sqlDetalles);

            dataGridView_DetalleCuota.DataSource = detalles;

            dataGridView_DetalleCuota.Columns["Entidad"].Width = 370;
            for (int a = 0; a < detalles.Rows.Count; a++) {
                total = total + Convert.ToDouble(detalles.Rows[a][3].ToString());
            }
            textBox_total.Text = string.Format("{0:C2}", total);

        }

        private void dataGridView_DetalleCuota_DoubleClick(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView_DetalleCuota.SelectedRows[0].Cells[0].Value.ToString(), 2);
            nueva.Show();
        }

        private void verOperaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView_DetalleCuota.SelectedRows[0].Cells[0].Value.ToString(), 2);
            nueva.Show();
        }

        private void dataGridView_DetalleCuota_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_DetalleCuota.HitTest(e.X, e.Y);
                dataGridView_DetalleCuota.ClearSelection();
                dataGridView_DetalleCuota.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
