using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    public partial class FormDetallesOperacion : Form
    {
        String id_det_operacion;
        double importeDetOperacion;
        double totalMov = 0.00;
        double totalPte = 0.00;

        public FormDetallesOperacion(String id_det_operacion)
        {
            InitializeComponent();
            this.id_det_operacion = id_det_operacion;
        }

        private void FormDetallesOperacion_Load(object sender, EventArgs e)
        {
            if (Login.getRol() == "Admin") {
                button_liquidar.Enabled = true;
                button_cerrar.Enabled = true;
            }

            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String sqlVencimiento = "SELECT com_movimientos.IdMov, com_detmovs.IdDetMov, com_detmovs.IdOpDet, com_movimientos.Fecha, com_cuentas.Descripcion, com_movimientos.Detalle, com_detmovs.ImpDetMovEntra AS Entrada, com_detmovs.ImpDetMovSale AS Salida FROM(com_detmovs INNER JOIN com_movimientos ON com_detmovs.IdMov = com_movimientos.IdMov) INNER JOIN com_cuentas ON com_movimientos.IdCuenta = com_cuentas.IdCuenta WHERE(((com_detmovs.IdOpDet) = " + id_det_operacion + "));";

            dataGridView_vencimietos.DataSource = Persistencia.SentenciasSQL.select(sqlVencimiento);
            ajustarDatagrid();
        }
        private void ajustarDatagrid() {
            dataGridView_vencimietos.Columns["IdMov"].Width = 60;
            dataGridView_vencimietos.Columns["IdDetMov"].Width = 60;
            dataGridView_vencimietos.Columns["IdOpDet"].Width = 60;
            dataGridView_vencimietos.Columns["Fecha"].Width = 80;
            dataGridView_vencimietos.Columns["Detalle"].Width = 250;
            dataGridView_vencimietos.Columns["Entrada"].DefaultCellStyle.Format = "c";
            dataGridView_vencimietos.Columns["Salida"].DefaultCellStyle.Format = "c";
            dataGridView_vencimietos.Columns["Entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_vencimietos.Columns["Salida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_vencimietos.Columns["Detalle"].Width = 250;
            dataGridView_vencimietos.Columns["Descripcion"].Width = 150;
            dataGridView_vencimietos.Columns["Descripcion"].HeaderText = "Banco";

        }
        private void  calcularPteVto() {

            for (int a = 0; a < dataGridView_vencimietos.Rows.Count; a++)  {
                totalMov += Convert.ToDouble(dataGridView_vencimietos.Rows[a].Cells[5].Value);
                totalMov -= Convert.ToDouble(dataGridView_vencimietos.Rows[a].Cells[6].Value);
            }

            String sqlSelect = "SELECT Importe FROM com_opdetalles WHERE IdOpDet = " + id_det_operacion;
            importeDetOperacion = Convert.ToDouble((Persistencia.SentenciasSQL.select(sqlSelect)).Rows[0][0].ToString());
            totalPte = importeDetOperacion - totalMov;

        }
        private void button_cerrar_Click(object sender, EventArgs e)
        {
            String bloqueGG ="";

            //SACO INFORMACIÓN NECESARIA
            String sqlSelect = "SELECT com_operaciones.IdComunidad, com_opdetalles.IdEntidad FROM com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE com_opdetalles.IdOpDet = " + id_det_operacion;
            DataTable datos = Persistencia.SentenciasSQL.select(sqlSelect);

            String sqlBloqueGG = "SELECT IdBloque FROM com_bloques WHERE IdComunidad = " + datos.Rows[0][0].ToString() + " and GG = '-1'";
            DataTable bloque = Persistencia.SentenciasSQL.select(sqlBloqueGG);

            if (bloque.Rows.Count > 0) {
                bloqueGG = bloque.Rows[0][0].ToString();
                calcularPteVto();

                if (datos.Rows.Count > 0)
                {
                    FormLiqCerrarOp nueva = new FormLiqCerrarOp(this, datos.Rows[0][0].ToString(), datos.Rows[0][1].ToString(), id_det_operacion, bloqueGG, totalPte.ToString(), "");
                    nueva.Show();
                }

            }
        }

        private void button_cerrar_Click_1(object sender, EventArgs e)
        {
            calcularPteVto();

            String sqlSelect = "SELECT com_operaciones.IdComunidad, com_opdetalles.IdEntidad FROM com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE com_opdetalles.IdOpDet = " + id_det_operacion;
            DataTable datos = Persistencia.SentenciasSQL.select(sqlSelect);

            String fechaHoy = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd");
            String idCuentaCom = Logica.FuncionesTesoreria.CuentaCompesaciones(datos.Rows[0][0].ToString());

            if (idCuentaCom == "")
            {
                MessageBox.Show("Debes crear una cuenta de compesaciones para la comunidad");
                return;
            }

            //BUSCO EJERCICIO
            String IdEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(datos.Rows[0][0].ToString(), fechaHoy);
            //CREO EL MOVIMIENTO
            int idMov = Logica.FuncionesTesoreria.CreaMovimiento(IdEjercicio, idCuentaCom, "2", datos.Rows[0][1].ToString(), fechaHoy, "AJUSTE VENCIMIENTO ANTIGUO");
            //CREO EL DETALLE
            Logica.FuncionesTesoreria.CreaDetalleMovimiento(idMov.ToString(), id_det_operacion, totalPte.ToString().Replace(",", "."));
            MessageBox.Show("Ajuste realizado");
            cargarDatagrid();
        }
    }
}
