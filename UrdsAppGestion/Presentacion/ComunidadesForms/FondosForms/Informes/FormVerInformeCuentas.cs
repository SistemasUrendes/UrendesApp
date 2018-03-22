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

            String sqlFondos = "SELECT com_detallesfondo.IdFondo, com_detallesfondo.IdDetalleFondo, com_detallesfondo.IdEjercicio, com_ejercicios.Ejercicio, com_detallesfondo.Entradas, com_detallesfondo.Salidas, com_detallesfondo.SaldoInicial, com_detallesfondo.SaldoActual, com_detallesfondo.SaldoCierre, com_detallesfondo.Cierre, com_detallesfondo.Resultado AS Resultado, com_fondos.TipoFondo FROM(com_fondos INNER JOIN com_detallesfondo ON com_fondos.IdFondo = com_detallesfondo.IdFondo) INNER JOIN com_ejercicios ON com_detallesfondo.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_fondos.IdComunidad) = " + idComunidad + ") AND((com_fondos.TipoFondo) = 1)) ORDER BY com_ejercicios.Ejercicio; ";

            DataTable fondosOrd = Persistencia.SentenciasSQL.select(sqlFondos);

            FondosBindingSource.DataSource = fondosOrd;

            String sqlFondos2 = "SELECT com_detallesfondo.IdFondo, com_detallesfondo.IdDetalleFondo, com_detallesfondo.IdEjercicio, com_ejercicios.Ejercicio, com_detallesfondo.Entradas, com_detallesfondo.Salidas, com_detallesfondo.SaldoInicial, com_detallesfondo.SaldoActual, com_detallesfondo.SaldoCierre, com_detallesfondo.Cierre, com_detallesfondo.Resultado AS Resultado, com_fondos.TipoFondo, com_fondos.NombreFondo AS Nombre FROM(com_fondos INNER JOIN com_detallesfondo ON com_fondos.IdFondo = com_detallesfondo.IdFondo) INNER JOIN com_ejercicios ON com_detallesfondo.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_fondos.IdComunidad) = " + idComunidad + ") AND((com_fondos.TipoFondo) = 2)) ORDER BY com_ejercicios.Ejercicio; ";

            DataTable fondosExtra = Persistencia.SentenciasSQL.select(sqlFondos2);
            bindingSource1.DataSource = fondosExtra;

            String sqlTotales = "SELECT Sum(Resultado + com_detallesfondo.SaldoInicial) AS Resultado, com_ejercicios.Ejercicio FROM(com_fondos INNER JOIN com_detallesfondo ON com_fondos.IdFondo = com_detallesfondo.IdFondo) INNER JOIN com_ejercicios ON com_detallesfondo.IdEjercicio = com_ejercicios.IdEjercicio GROUP BY com_detallesfondo.Cierre, com_fondos.IdComunidad, com_detallesfondo.IdEjercicio, com_ejercicios.Ejercicio HAVING(((com_detallesfondo.Cierre) = -1) AND((com_fondos.IdComunidad) = " + idComunidad + "));";

            bindingSource2.DataSource = Persistencia.SentenciasSQL.select(sqlTotales);

        }

        private void FormVerInformeCuentas_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
