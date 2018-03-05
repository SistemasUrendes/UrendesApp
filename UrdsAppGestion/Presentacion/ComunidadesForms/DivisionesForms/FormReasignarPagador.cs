using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    public partial class FormReasignarPagador : Form
    {
        String id_comunidad_cargado;
        String id_op_pasado;
        String id_entidad_pasado;
        String nombre_entidad_pasado;
        String importe_pasado;
        String id_nueva_entidad;
        int indice_seleccioando = -1;

        FormDivisionesCuotas form_anterior;
        Operaciones_comuneros form_anterior1;

        public FormReasignarPagador(FormDivisionesCuotas form_anterior, String id_comunidad_cargado, String id_op_pasado, String nombre_entidad_pasado, String id_entidad_pasado, String importe_pasado,int indice_seleccioando)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_op_pasado = id_op_pasado;
            this.id_entidad_pasado = id_entidad_pasado;
            this.nombre_entidad_pasado = nombre_entidad_pasado;
            this.importe_pasado = importe_pasado;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.indice_seleccioando = indice_seleccioando;
        }
        public FormReasignarPagador(FormDivisionesCuotas form_anterior, String id_comunidad_cargado, String id_op_pasado, String nombre_entidad_pasado, String id_entidad_pasado, String importe_pasado)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_op_pasado = id_op_pasado;
            this.id_entidad_pasado = id_entidad_pasado;
            this.nombre_entidad_pasado = nombre_entidad_pasado;
            this.importe_pasado = importe_pasado;
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        public FormReasignarPagador(Operaciones_comuneros form_anterior1, String id_comunidad_cargado, String id_op_pasado, String nombre_entidad_pasado, String id_entidad_pasado, String importe_pasado,String quien)
        {
            InitializeComponent();
            this.form_anterior1 = form_anterior1;
            this.id_op_pasado = id_op_pasado;
            this.id_entidad_pasado = id_entidad_pasado;
            this.nombre_entidad_pasado = nombre_entidad_pasado;
            this.importe_pasado = importe_pasado;
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormReasignarOperacion_Load(object sender, EventArgs e)
        {
            textBox_id_op.Text = id_op_pasado;
            textBox_vieja_entidad.Text = nombre_entidad_pasado;
            textBox_importe.Text = importe_pasado;
            textBox_nueva_entidad.Text = "Pulse espacio para buscar Comunero";
            textBox_nueva_entidad.SelectAll();
        }

        private void textBox_nueva_entidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Space)
            {
                Comuneros nueva = new Comuneros(this, this.Name, id_comunidad_cargado);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar.Select();
                nueva.Show();
            }
            else if (e.KeyChar == (Char)Keys.E)
            {

                Entidades nueva = new Entidades(this, this.Name);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar_nombre.Select();
                nueva.dataGridView1.TabIndex = 2;
                nueva.textBox_buscar_nombre.TabIndex = 1;
                nueva.Show();
            }


        }
        public void recibirEntidad(String id_entidad , String nombre_entidad) {
            textBox_nueva_entidad.Text = nombre_entidad;
            id_nueva_entidad = id_entidad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fechaHoy = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
            Double total_importe_vencimientos = Convert.ToDouble(0.00);

            //RECORRO LOS VECIMIENTOS DE ESA OPERACION PARA ABONARLOS
            String sqlSelectVencimientos = "SELECT IdOpDet, IdEntidad, ImpOpDetPte FROM com_opdetalles WHERE IdOp = " + id_op_pasado;
            DataTable vencimientosAntiguos = Persistencia.SentenciasSQL.select(sqlSelectVencimientos);
            for (int a = 0; a < vencimientosAntiguos.Rows.Count; a++) {
                if (Convert.ToDouble(vencimientosAntiguos.Rows[a][2].ToString()) > 0.00) {
                    if (CreoAbonoVencimiento(vencimientosAntiguos.Rows[a][0].ToString(), vencimientosAntiguos.Rows[a][1].ToString(), vencimientosAntiguos.Rows[a][2].ToString()))
                        total_importe_vencimientos = total_importe_vencimientos + Convert.ToDouble(vencimientosAntiguos.Rows[a][2].ToString());
                    else
                        return;
                }
            }

            ////////############################# CREO VENCIMIENTO NUEVO Y EL RECIBO ######################################//////////////////

            int op_det = Logica.FuncionesTesoreria.CreoVencimientoID(id_op_pasado, id_nueva_entidad, fechaHoy, Logica.FuncionesGenerales.ArreglarImportes(total_importe_vencimientos.ToString()), Logica.FuncionesGenerales.ArreglarImportes(total_importe_vencimientos.ToString()));

            //CREO EL RECIBO
            int id_recibo = Logica.FuncionesTesoreria.CreoReciboID(id_comunidad_cargado, id_nueva_entidad, fechaHoy, Logica.FuncionesGenerales.ArreglarImportes(total_importe_vencimientos.ToString()), Logica.FuncionesGenerales.ArreglarImportes(total_importe_vencimientos.ToString()), "Recibo reasignado");

            //ACTUALIZO RECIBO EN EL VENCIMIENTO
            Logica.FuncionesTesoreria.ActualizoIdReciboVencimiento(id_recibo.ToString(), op_det.ToString());

            //////########################## CAMBIO ENTIDAD DE LA OPERACION ###################################///////////////

            String sqlUpdateOperacion = "UPDATE com_operaciones SET IdEntidad = " + id_nueva_entidad + " WHERE IdOp = " + id_op_pasado;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateOperacion);

            if (form_anterior1 == null)
            {
                form_anterior.aplicarFiltro();
                if (indice_seleccioando > -1)
                {
                    form_anterior.dataGridView_operacionesComuneros.ClearSelection();
                    form_anterior.dataGridView_operacionesComuneros.Rows[indice_seleccioando].Selected = true;
                }
            }else {
                form_anterior1.cargardatagrid();
                form_anterior1.aplicarFiltro();
            }
            MessageBox.Show("Operación reasignada");
            this.Close();
        }
        private Boolean CreoAbonoVencimiento(String id_opdet, String id_entidad , String importe) {

            String fechaHoy = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
            String cuentaCompesaciones = Logica.FuncionesTesoreria.CuentaCompesaciones(id_comunidad_cargado);

            if (cuentaCompesaciones == "No") {
                MessageBox.Show("No existe la cuenta de compensaciones para esa comunidad");
                return false;
            }

            //BUSCO EL EJERCICIO ACTIVO
            String idEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaHoy);

            ////////######################### MOVIMIENTOS SOBRE LA OPERACION ############################//////////////////////

            //CREO CABECERA DEL MOVIMIENTO
            int numMov = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, cuentaCompesaciones, "16", id_entidad, fechaHoy, "Abono Entrada");

            //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE
            Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), id_opdet, Logica.FuncionesGenerales.ArreglarImportes(importe));

            ////////############## CREO VENCIMIENTO Y MOVIMIENTOS SOBRE LA OPERACION DE ABONO ##############//////////////////

            int op_det = Logica.FuncionesTesoreria.CreoVencimientoID(id_op_pasado, id_entidad, fechaHoy,"-" + Logica.FuncionesGenerales.ArreglarImportes(importe), "-" + Logica.FuncionesGenerales.ArreglarImportes(importe));

            //CREO EL RECIBO
            int id_recibo = Logica.FuncionesTesoreria.CreoReciboID(id_comunidad_cargado, id_entidad, fechaHoy,"-" + importe, "-" + importe,"Recibo de Abono");

            //ACTUALIZO RECIBO EN EL VENCIMIENTO
            Logica.FuncionesTesoreria.ActualizoIdReciboVencimiento(id_recibo.ToString(), op_det.ToString());
            
            //CREO CABECERA DEL MOVIMIENTO
            int numMov1 = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, cuentaCompesaciones, "15", id_entidad, fechaHoy, "Abono Salida");

            //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE
            Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov1.ToString(), op_det.ToString(), Logica.FuncionesGenerales.ArreglarImportes(importe));

            ////////##########################################################################################//////////////////////
            return true;

        }
    }
}
