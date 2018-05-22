using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    public partial class FormRecibosEmitidos : Form
    {
        String idEntidad;
        public FormRecibosEmitidos(String idEntidad)
        {
            InitializeComponent();
            this.idEntidad = idEntidad;
        }

        private void FormRecibosEmitidos_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        private void cargarDatagrid() {
            String sqlRecibos = "SELECT com_recibos.IdRecibo, ctos_detbancos.Descripcion, ctos_detbancos.CC, com_recibos.ImpRboPte, com_remesas.Remesa, com_remesas.IdRemesa FROM((ctos_detbancos INNER JOIN com_recibos ON ctos_detbancos.IdCuenta = com_recibos.IdCC) INNER JOIN com_detremesa ON com_recibos.IdRecibo = com_detremesa.IdRecibo) INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa WHERE(((com_recibos.IdEntidad) = " + idEntidad + "));";

            dataGridView_recibosPte.DataSource = Persistencia.SentenciasSQL.select(sqlRecibos);

            dataGridView_recibosPte.Columns["IdRemesa"].Visible = false;
            dataGridView_recibosPte.Columns["CC"].Width = 200;
        }

        private void verEnRemesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComunidadesForms.RemesasForms.FormDetalleRemesa nueva = new ComunidadesForms.RemesasForms.FormDetalleRemesa(dataGridView_recibosPte.SelectedRows[0].Cells[5].Value.ToString());
            nueva.Show();
        }

        private void dataGridView_recibosPte_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_recibosPte.HitTest(e.X, e.Y);
                dataGridView_recibosPte.ClearSelection();
                dataGridView_recibosPte.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
