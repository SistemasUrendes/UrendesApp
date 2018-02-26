using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms
{
    public partial class FormFondosDetalles : Form
    {
        String idComunidad;
        String idFondo;
        public FormFondosDetalles(String idComunidad, String idFondo)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idFondo = idFondo;
        }

        private void FormFondosDetalles_Load(object sender, EventArgs e)
        {

                cargarDatagrid();
        }
        private void ajustarDatagrid() {
            dataGridView_detallesFondos.Columns["NombreFondo"].Width = 210;
            dataGridView_detallesFondos.Columns["IdDetalleFondo"].Width = 60;

            dataGridView_detallesFondos.Columns["Entradas"].Width = 100;
            dataGridView_detallesFondos.Columns["Entradas"].DefaultCellStyle.Format = "c";

            dataGridView_detallesFondos.Columns["Salidas"].Width = 100;
            dataGridView_detallesFondos.Columns["Salidas"].DefaultCellStyle.Format = "c";

            //dataGridView_detallesFondos.Columns["PteProveedores"].Width = 100;
            //dataGridView_detallesFondos.Columns["PteProveedores"].DefaultCellStyle.Format = "c";

            //dataGridView_detallesFondos.Columns["PteComuneros"].Width = 100;
            //dataGridView_detallesFondos.Columns["PteComuneros"].DefaultCellStyle.Format = "c";

            dataGridView_detallesFondos.Columns["SaldoInicial"].Width = 100;
            dataGridView_detallesFondos.Columns["SaldoInicial"].DefaultCellStyle.Format = "c";

            dataGridView_detallesFondos.Columns["Resultado"].Width = 100;
            dataGridView_detallesFondos.Columns["Resultado"].DefaultCellStyle.Format = "c";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FormIniciarFondo nueva = new FormIniciarFondo(this, idComunidad, idFondo);
            //nueva.Show();
        }
        public void cargarDatagrid() {
            String sqlSelect = "SELECT com_detallesfondo.IdDetalleFondo, com_fondos.NombreFondo, com_ejercicios.Ejercicio, com_detallesfondo.Entradas, com_detallesfondo.Salidas, com_detallesfondo.SaldoInicial, com_detallesfondo.Resultado FROM(com_detallesfondo INNER JOIN com_fondos ON com_detallesfondo.IdFondo = com_fondos.IdFondo) INNER JOIN com_ejercicios ON com_detallesfondo.IdEjercicio = com_ejercicios.IdEjercicio WHERE com_detallesfondo.IdFondo = " + idFondo;

            dataGridView_detallesFondos.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            ajustarDatagrid();
        }
    }
}
