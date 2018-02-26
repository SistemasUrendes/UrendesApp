using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    public partial class CuentasBanco : Form
    {
        String id_comunidad;

        public CuentasBanco(String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
        }

        private void CuentasBanco_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        private void cargarDatagrid() {
            String sqlSelect = "SELECT ctos_entidades.Entidad, com_cuentas.Descripcion, com_cuentas.NumCuenta, com_cuentas.FCierre, com_cuentas.Ppal, com_cuentas.C, com_cuentas.A FROM com_cuentas INNER JOIN ctos_entidades ON com_cuentas.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_cuentas.IdComunidad) = " + id_comunidad + "));";
            DataTable cuentasComunidad = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_cuentasBanco.DataSource = cuentasComunidad;

            ajutarDatagrid();


        }
        private void ajutarDatagrid() {
            dataGridView_cuentasBanco.Columns["Entidad"].Width = 200;
            dataGridView_cuentasBanco.Columns["Descripcion"].Width = 200;
            dataGridView_cuentasBanco.Columns["NumCuenta"].Width = 200;
            dataGridView_cuentasBanco.Columns["FCierre"].Width = 80;
            dataGridView_cuentasBanco.Columns["Ppal"].Width = 50;
            dataGridView_cuentasBanco.Columns["C"].Width = 50;
            dataGridView_cuentasBanco.Columns["A"].Width = 50;
        }

        private void copiarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dataGridView_cuentasBanco.SelectedRows[0].Cells[2].Value.ToString());
        }

        private void dataGridView_cuentasBanco_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_cuentasBanco.HitTest(e.X, e.Y);
                dataGridView_cuentasBanco.ClearSelection();
                dataGridView_cuentasBanco.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
