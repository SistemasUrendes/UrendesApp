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
    public partial class FormAbonarVencimiento : Form
    {
        String IdOp_pasada;
        Operaciones_comuneros form_anterior;
        String idComunidad;
        String id_entidad_nuevo = "0";

        public FormAbonarVencimiento(Operaciones_comuneros form_anterior, String IdOp_pasada, String idComunidad)
        {
            InitializeComponent();
            this.IdOp_pasada = IdOp_pasada;
            this.form_anterior = form_anterior;
            this.idComunidad = idComunidad;
        }

        private void FormAbonarVencimiento_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        private void cargarDatagrid() {

            String sqlSelect = "SELECT com_opdetalles.IdOpDet, ctos_entidades.Entidad, com_opdetalles.Fecha, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte, com_opdetalles.IdRecibo, com_opdetalles.IdEntidad, com_operaciones.Descripcion FROM(com_opdetalles INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE(((com_opdetalles.IdOp) = " + IdOp_pasada + "));";

            dataGridView_vencimientos.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_vencimientos.Columns["IdEntidad"].Visible = false;
            dataGridView_vencimientos.Columns["Descripcion"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView_vencimientos.SelectedRows[0].Cells[4].Value.ToString() == "0,00" && id_entidad_nuevo != "0") {
                String fechaHoy = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd");
                
                String idCuentaCom = Logica.FuncionesTesoreria.CuentaCompesaciones(idComunidad);

                if (idCuentaCom == "")
                {
                    MessageBox.Show("Debes crear una cuenta de compesaciones para la comunidad");
                    return;
                }

                //BUSCO EJERCICIO
                String IdEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(idComunidad, fechaHoy);

                //CREO EL MOVIMIENTO
                int idMov = Logica.FuncionesTesoreria.CreaMovimiento(IdEjercicio, idCuentaCom, "8", dataGridView_vencimientos.SelectedRows[0].Cells[6].Value.ToString(), fechaHoy, "ABONO");

                //CREO EL DETALLE DEL MOVIMIENTO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(idMov.ToString(), dataGridView_vencimientos.SelectedRows[0].Cells[0].Value.ToString(), dataGridView_vencimientos.SelectedRows[0].Cells[3].Value.ToString().Replace(",","."));

                //CREO EL DETALLE DE ABONO
                int idDetOpAbono = Logica.FuncionesTesoreria.CreoVencimientoID(IdOp_pasada, dataGridView_vencimientos.SelectedRows[0].Cells[6].Value.ToString(), fechaHoy, "-" + dataGridView_vencimientos.SelectedRows[0].Cells[3].Value.ToString().Replace(",", "."), "-" + dataGridView_vencimientos.SelectedRows[0].Cells[3].Value.ToString().Replace(",", "."));
                
                //CREO RECIBO ABONO
                int num_recibo = Logica.FuncionesTesoreria.CreoReciboID(idComunidad, dataGridView_vencimientos.SelectedRows[0].Cells[6].Value.ToString(), fechaHoy, "-" + dataGridView_vencimientos.SelectedRows[0].Cells[3].Value.ToString().Replace(",", "."),"-" + dataGridView_vencimientos.SelectedRows[0].Cells[3].Value.ToString().Replace(",", "."), "Abono " + dataGridView_vencimientos.SelectedRows[0].Cells[7].Value.ToString());

                //ACTUALIZO EL IDRECIBO AL VENCIMIENTO
                String strActVtosRbo = "UPDATE com_opdetalles SET com_opdetalles.IdRecibo = " + num_recibo + " WHERE (((com_opdetalles.IdOpDet)=" + idDetOpAbono + "));";
                Persistencia.SentenciasSQL.InsertarGenerico(strActVtosRbo);

                //CREO EL DETALLE DEL NUEVO COMUNERO
                int idDetOpRecibo = Logica.FuncionesTesoreria.CreoVencimientoID(IdOp_pasada, id_entidad_nuevo, fechaHoy, dataGridView_vencimientos.SelectedRows[0].Cells[3].Value.ToString().Replace(",", "."),dataGridView_vencimientos.SelectedRows[0].Cells[3].Value.ToString().Replace(",", "."));

                //CREO RECIBO ABONO
                int num_reciboComunero = Logica.FuncionesTesoreria.CreoReciboID(idComunidad, id_entidad_nuevo, fechaHoy, dataGridView_vencimientos.SelectedRows[0].Cells[3].Value.ToString().Replace(",", "."), dataGridView_vencimientos.SelectedRows[0].Cells[3].Value.ToString().Replace(",", "."), dataGridView_vencimientos.SelectedRows[0].Cells[7].Value.ToString());

                //ACTUALIZO EL IDRECIBO AL VENCIMIENTO
                String strActVtosRbo2 = "UPDATE com_opdetalles SET com_opdetalles.IdRecibo = " + num_reciboComunero + " WHERE (((com_opdetalles.IdOpDet)=" + idDetOpRecibo + "));";
                Persistencia.SentenciasSQL.InsertarGenerico(strActVtosRbo2);

                MessageBox.Show("Vencimiento Reasignado");
                cargarDatagrid();

                FromOperacionesVer nueva = new FromOperacionesVer(IdOp_pasada, 2);
                nueva.Show();
                this.Close();
            }
            else {
                MessageBox.Show("El vencimiento debe estar completamente pagado. Por ahora");
            }
        }

        private void textBox_nuevoComunero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter || e.KeyChar == (Char)Keys.Space)
            {
                Comuneros nueva = new Comuneros(this, this.Name, idComunidad);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
        }

        public void recibirComunero(String id_entidad, String nombre)
        {
            id_entidad_nuevo = id_entidad;
            textBox_nuevoComunero.Text = nombre;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDetallesOperacion nueva = new FormDetallesOperacion(dataGridView_vencimientos.SelectedCells[0].Value.ToString());
            nueva.Show();
        }
    }
}
