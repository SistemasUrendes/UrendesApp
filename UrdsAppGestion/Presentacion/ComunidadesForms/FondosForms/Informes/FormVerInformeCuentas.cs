using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms.Informes
{
    public partial class FormVerInformeCuentas : Form
    {
        public FormVerInformeCuentas(String idComunidad)
        {
            InitializeComponent();

            String sqlFondos = "SELECT com_detallesfondo.IdFondo, com_detallesfondo.IdDetalleFondo, com_detallesfondo.IdEjercicio, com_ejercicios.Ejercicio, com_detallesfondo.Entradas, com_detallesfondo.Salidas, com_detallesfondo.SaldoInicial, com_detallesfondo.SaldoActual, com_detallesfondo.SaldoCierre, com_detallesfondo.Cierre, com_detallesfondo.Resultado, com_fondos.TipoFondo FROM(com_fondos INNER JOIN com_detallesfondo ON com_fondos.IdFondo = com_detallesfondo.IdFondo) INNER JOIN com_ejercicios ON com_detallesfondo.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_fondos.IdComunidad) = " + idComunidad + ")) ORDER BY Ejercicio ASC;";

            FondosBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlFondos);
        }

        private void FormVerInformeCuentas_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
