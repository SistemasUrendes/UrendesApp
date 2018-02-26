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
    public partial class FormTesoreriaCompesaciones : Form
    {
        String id_comunidad;
        DataTable compesaciones;

        public FormTesoreriaCompesaciones(String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
        }

        private void FormTesoreriaCompesaciones_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String CuentaCompensaciones = Logica.FuncionesTesoreria.CuentaCompesaciones(id_comunidad);
            String fechaInicio = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
            if (CuentaCompensaciones == "No") {
                MessageBox.Show("No existe cuenta de compesaciones.");
                return;
            }

            String sqlSelectCompesaciones = "SELECT com_movimientos.IdMov,com_movimientos.Fecha, com_movimientos.Detalle, com_movimientos.IdEjercicio, com_movimientos.IdCuenta, com_movimientos.IdDetTipoMov, com_movimientos.IdEntidad, ctos_entidades.Entidad, com_movimientos.MovDevol, com_movimientos.MovCA, com_movimientos.ImpMovEnt, com_movimientos.ImpMovSal, com_movimientos.ImpMovNeto,com_movimientos.MovSaldo,  com_movimientos.IdRemesa,com_movimientos.NumSecuencia FROM com_movimientos INNER JOIN ctos_entidades ON com_movimientos.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_movimientos.IdEjercicio) = " + Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad, fechaInicio) + ") AND ((com_movimientos.IdCuenta) = " + CuentaCompensaciones + ") ) ORDER BY com_movimientos.NumSecuencia DESC;";

            compesaciones = Persistencia.SentenciasSQL.select(sqlSelectCompesaciones);
            dataGridView_compesaciones.DataSource = compesaciones;
            dataGridView_compesaciones.Columns["IdEjercicio"].Visible = false;
            dataGridView_compesaciones.Columns["IdCuenta"].Visible = false;
            dataGridView_compesaciones.Columns["IdDetTipoMov"].Visible = false;
            dataGridView_compesaciones.Columns["IdEntidad"].Visible = false;
            dataGridView_compesaciones.Columns["MovDevol"].Visible = false;
            dataGridView_compesaciones.Columns["MovCA"].Visible = false;
            dataGridView_compesaciones.Columns["ImpMovEnt"].Visible = false;
            dataGridView_compesaciones.Columns["ImpMovSal"].Visible = false;
            dataGridView_compesaciones.Columns["IdRemesa"].Visible = false;
            dataGridView_compesaciones.Columns["NumSecuencia"].Visible = false;
            dataGridView_compesaciones.Columns["Entidad"].Width = 250;
            dataGridView_compesaciones.Columns["Detalle"].Width = 250;
            dataGridView_compesaciones.Columns["ImpMovNeto"].DefaultCellStyle.Format = "c";
            dataGridView_compesaciones.Columns["MovSaldo"].DefaultCellStyle.Format = "c";
        }
    }
}
