using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    public partial class FormDevolucionIngreso : Form
    {
        String id_mov_anterior;
        String id_comunidad;
        Tesoreria form_anterior;
        String id_cuenta;
        String importe;
        String id_entidad;

        public FormDevolucionIngreso(Tesoreria form_anterior, String id_comunidad, String id_mov_anterior)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.id_mov_anterior = id_mov_anterior;
            this.form_anterior = form_anterior;
        }

        private void FormDevolucionIngreso_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        private void cargarDatagrid() {
            String sqlDatosMovimiento = "SELECT ctos_entidades.NombreCorto, com_cuentas.Descripcion, ctos_entidades_1.Entidad, com_movimientos.Fecha, com_opdetalles.IdOp, com_movimientos.ImpMovNeto, ctos_entidades_1.IDEntidad, com_cuentas.IdCuenta FROM com_opdetalles INNER JOIN ((ctos_entidades AS ctos_entidades_1 INNER JOIN(((com_movimientos INNER JOIN com_cuentas ON com_movimientos.IdCuenta = com_cuentas.IdCuenta) INNER JOIN com_comunidades ON com_cuentas.IdComunidad = com_comunidades.IdComunidad) INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad) ON ctos_entidades_1.IDEntidad = com_movimientos.IdEntidad) INNER JOIN com_detmovs ON com_movimientos.IdMov = com_detmovs.IdMov) ON com_opdetalles.IdOpDet = com_detmovs.IdOpDet WHERE(((com_movimientos.IdMov) = " + id_mov_anterior + "));";

            DataTable datos =  Persistencia.SentenciasSQL.select(sqlDatosMovimiento);

            if (datos.Rows.Count > 0) {
                textBox_comunidad.Text = datos.Rows[0][0].ToString();
                textBox_cuenta.Text = datos.Rows[0][1].ToString();
                textBox_movimiento.Text = id_mov_anterior;
                textBox_entidad.Text = datos.Rows[0][2].ToString();
                textBox_fecha.Text = datos.Rows[0][3].ToString();
                textBox_operacion.Text = datos.Rows[0][4].ToString();
                textBox_importe.Text = datos.Rows[0][5].ToString();

                importe = datos.Rows[0][5].ToString(); 
                id_cuenta = datos.Rows[0][7].ToString();
                id_entidad = datos.Rows[0][6].ToString();
            }

            comboBox_iva.DataSource = Persistencia.SentenciasSQL.select("SELECT IdIVA,`%IVA` FROM aux_iva");
            comboBox_iva.ValueMember = "IdIVA";
            comboBox_iva.DisplayMember = "%IVA";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            String fecha = (Convert.ToDateTime(maskedTextBox_fecha_nueva.Text)).ToString("yyyy-MM-dd");

            String sqlMovsCA = "SELECT com_opdetalles.IdOpDet, com_opdetalles.IdOp, com_opdetalles.IdEstado, com_operaciones.IdSubCuenta, com_operaciones.IdMovCrea FROM com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE (((com_opdetalles.Importe)<0) AND ((com_opdetalles.nummov) <>0) AND ((com_operaciones.IdSubCuenta)=43801) AND ((com_operaciones.IdMovCrea)=" + id_mov_anterior + "));";

            DataTable MovsCA = Persistencia.SentenciasSQL.select(sqlMovsCA);
            if (MovsCA.Rows.Count > 0) {
                MessageBox.Show("Se ha utilizado saldo de la Operación de Salida AC");
                return;
            }

            //LIQUIDACION ACTIVA
            String ejercicioActivo = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad, fecha);

            String descrip = "Devolución M" + id_mov_anterior + "-" + fecha;
            int id_mov = Logica.FuncionesTesoreria.CreaMovimiento(ejercicioActivo, id_cuenta, "12", id_entidad, fecha, descrip);
            Logica.FuncionesTesoreria.ActualizaMovDevol(id_mov_anterior, id_mov.ToString());

            String sqlDetallesMovs = "SELECT com_detmovs.IdDetMov, com_detmovs.IdMov, com_detmovs.IdOpDet, com_operaciones.IdSubCuenta, com_detmovs.Importe, com_operaciones.IdMovCrea FROM(com_detmovs INNER JOIN com_opdetalles ON com_detmovs.IdOpDet = com_opdetalles.IdOpDet) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE(((com_detmovs.IdMov) = " + id_mov_anterior + "));";

            DataTable detalles = Persistencia.SentenciasSQL.select(sqlDetallesMovs);

            for (int a = 0; a < detalles.Rows.Count;a++) {
                if (detalles.Rows[a][3].ToString() == "43801") {
                    String sqlIdOp = "SELECT com_opdetalles.IdOpDet, com_opdetalles.Importe FROM com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE(((com_operaciones.IdSubCuenta) = 43801) AND((com_operaciones.IdMovCrea) = " + id_mov_anterior + ") AND((com_opdetalles.Importe) < 0));";
                    String opdetca = (Persistencia.SentenciasSQL.select(sqlIdOp)).Rows[0][0].ToString();
                    Logica.FuncionesTesoreria.CreaDetalleMovimiento(id_mov.ToString(), opdetca, Logica.FuncionesGenerales.ArreglarImportes(detalles.Rows[a][4].ToString()));
                }else {
                    Logica.FuncionesTesoreria.CreaDetalleMovimiento(id_mov.ToString(), detalles.Rows[a][2].ToString(),Logica.FuncionesGenerales.ArreglarImportes(detalles.Rows[a][4].ToString()));
                }
                
            }

            //Crear Operación de gasto (añadir el detalle idmovcrea)
            if (textBox_baseIVA.Text != "" && Convert.ToDouble(textBox_baseIVA.Text) > 0.01) {

                String idEntidadBanco = (Persistencia.SentenciasSQL.select("SELECT IdEntidad FROM com_cuentas WHERE IdCuenta = " + id_cuenta)).Rows[0][0].ToString();

                String doc = "G_Dev. M" + id_mov_anterior;
                String descripcion = "Gastos Devolución M" + id_mov_anterior + " " + textBox_fecha.Text;
                double importe = double.Parse(textBox_baseIVA.Text.Replace('.', ',')) + double.Parse(textBox_iva.Text.Replace('.',',')) + double.Parse(textBox_gastoCorreo.Text.Replace('.', ','));
                //if (importe < 0) {
                //    MessageBox.Show("El importe tiene que ser positivo");
                //    return;
                //}

                if (radioButton1.Checked) {
                    int opGasto = Logica.FuncionesTesoreria.CreaOpGastoDevolucionParticular(id_comunidad, idEntidadBanco, id_entidad, fecha, Logica.FuncionesGenerales.ArreglarImportes(textBox_baseIVA.Text), Logica.FuncionesGenerales.ArreglarImportes(textBox_iva.Text), comboBox_iva.SelectedValue.ToString(), id_mov.ToString(), fecha);

                    int varMovGastos = Logica.FuncionesTesoreria.CreaMovimientoDevol(ejercicioActivo, id_cuenta, "8", id_entidad, fecha, descripcion,id_mov.ToString());
                    String varDetOp = (Persistencia.SentenciasSQL.select("SELECT IdOpDet FROM com_opdetalles WHERE IdOp = " + opGasto.ToString())).Rows[0][0].ToString();

                    Logica.FuncionesTesoreria.CreaDetalleMovimiento(varMovGastos.ToString(), varDetOp, Logica.FuncionesGenerales.ArreglarImportes(importe.ToString()));

                    int opGastoEntidad = Logica.FuncionesTesoreria.CreaOpPagoGastoDevolucionPart(id_comunidad, id_entidad, fecha, Logica.FuncionesGenerales.ArreglarImportes(textBox_baseIVA.Text), Logica.FuncionesGenerales.ArreglarImportes(textBox_iva.Text), comboBox_iva.SelectedValue.ToString(),id_mov.ToString(), opGasto.ToString(), fecha);

                }else if(radioButton2.Checked) {
                    int OpGasto = Logica.FuncionesTesoreria.CreaOpGastoDevolucion(id_comunidad, idEntidadBanco,fecha, Logica.FuncionesGenerales.ArreglarImportes(textBox_baseIVA.Text), Logica.FuncionesGenerales.ArreglarImportes(textBox_iva.Text), comboBox_iva.SelectedValue.ToString(),id_mov.ToString(),fecha);

                    int varMovGastos = Logica.FuncionesTesoreria.CreaMovimiento(ejercicioActivo,id_cuenta,"8",idEntidadBanco,fecha,descripcion);

                    String varDetOp = (Persistencia.SentenciasSQL.select("SELECT IdOpDet FROM com_opdetalles WHERE IdOp = " + OpGasto.ToString())).Rows[0][0].ToString();
                    Logica.FuncionesTesoreria.CreaDetalleMovimiento(varMovGastos.ToString(), varDetOp, Logica.FuncionesGenerales.ArreglarImportes(importe.ToString()));
                }
            }
            form_anterior.cargarDatagrid();
            this.Close();
        }

        private void maskedTextBox_fecha_nueva_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBox_fecha_nueva.Text, sPattern))
            {
                maskedTextBox_fecha_nueva.Text = maskedTextBox_fecha_nueva.Text + DateTime.Now.Year;
                textBox_baseIVA.Select();
            }
            else if (Regex.IsMatch(maskedTextBox_fecha_nueva.Text, sPattern1))
            {
                textBox_baseIVA.Select();
            }
            else
            {
                maskedTextBox_fecha_nueva.Focus();
                maskedTextBox_fecha_nueva.Select();
            }
        }

        private void comboBox_iva_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRowView valor = (DataRowView)comboBox_iva.SelectedItem;
            double comboIVA = double.Parse(valor[1].ToString()) / 100;
            double total = double.Parse(textBox_baseIVA.Text.Replace('.', ',')) * comboIVA;
            textBox_iva.Text = total.ToString("N2").Replace(',', '.');
        }
    }
}
