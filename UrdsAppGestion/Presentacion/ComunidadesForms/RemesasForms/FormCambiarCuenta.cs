using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.RemesasForms
{
    public partial class FormCambiarCuenta : Form
    {
        String id_entidad, idDetRemesa;
        FormDetalleRemesa form_anterior;
        public FormCambiarCuenta(FormDetalleRemesa form_anterior, String id_entidad, String nombreEntidad, String idDetRemesa)
        {
            InitializeComponent();
            this.id_entidad = id_entidad;
            this.form_anterior = form_anterior;
            this.Text = nombreEntidad;
            this.idDetRemesa = idDetRemesa;
        }
        private void cargarDatagrid() {
            String sqlCuentas = "SELECT ctos_detbancos.IdCuenta, ctos_detbancos.Descripcion, ctos_detbancos.CC FROM ctos_detbancos WHERE ctos_detbancos.IdEntidad = " + id_entidad;
            dataGridView_cuentas.DataSource = Persistencia.SentenciasSQL.select(sqlCuentas);
            dataGridView_cuentas.Columns[0].Visible = false;
            dataGridView_cuentas.Columns[0].Width = 50;
            dataGridView_cuentas.Columns[1].Width = 100;
            dataGridView_cuentas.Columns[2].Width = 200;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sqlUpdate = "UPDATE com_detremesa SET IdCuenta=" + dataGridView_cuentas.SelectedRows[0].Cells[0].Value + ", Cuenta='" + dataGridView_cuentas.SelectedRows[0].Cells[2].Value + "' WHERE IdDetRemesa = " + idDetRemesa;

            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            this.Close();
            form_anterior.cargarDatagrid();
        }

        private void FormCambiarCuenta_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
    }
}
