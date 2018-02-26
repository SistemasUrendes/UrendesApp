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
    public partial class FormAsientoApertura : Form
    {
        String id_comunidad_cargado;
        String id_cuenta_cargado;
        Tesoreria form_anterior;
        String id_ejercicio;

        public FormAsientoApertura(Tesoreria form_anterior, String id_comunidad_cargado, String id_cuenta_cargado, String id_ejercicio)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_cuenta_cargado = id_cuenta_cargado;
            this.form_anterior = form_anterior;
            this.id_ejercicio = id_ejercicio;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAsientoApertura_Load(object sender, EventArgs e)
        {
            String nombreCuenta = (Persistencia.SentenciasSQL.select("SELECT Descripcion FROM com_cuentas WHERE IdCuenta = " + id_cuenta_cargado)).Rows[0][0].ToString();
            textBox_cuenta.Text = nombreCuenta;

            String ejercicio = (Persistencia.SentenciasSQL.select("SELECT Ejercicio FROM com_ejercicios WHERE IdEjercicio = " + id_ejercicio)).Rows[0][0].ToString();

            textBox_ejercicio.Text = ejercicio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fecha;
            String fecha_actualizacion;

            try {
                fecha = (Convert.ToDateTime(maskedTextBox_fecha.Text)).ToString("yyyy-MM-dd");
                fecha_actualizacion = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
            }
            catch {
                MessageBox.Show("Fecha Incorrecta");
                return;
            }            

            if ( textBox_importe != null && textBox_importe.Text != "") {

                //BUSCO LA ENTIDAD DE LA COMUNIDAD
                String idEntidadComunidad = (Persistencia.SentenciasSQL.select("SELECT IdEntidad FROM com_comunidades WHERE IdComunidad = " + id_comunidad_cargado)).Rows[0][0].ToString();


                //CREO CABECERA DEL MOVIMIENTO
                int numMov = Logica.FuncionesTesoreria.CreaMovimiento(id_ejercicio, id_cuenta_cargado, "20", idEntidadComunidad, fecha, "Asiento de Apertura");


                //CREO LA OPERACIÓN
                String sqlInsertOperacionAC = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdMovCrea ,ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + id_comunidad_cargado + "," + idEntidadComunidad + ", 55501 ,1,'" + fecha + "','Apertura','Asiento Apertura'," + numMov + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ",'Si'," + Presentacion.Login.getId() + ",'" + fecha_actualizacion + "')";

                int op = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacionAC);

                //INSERTO EL IVA EN LA OPERACION ANTERIOR
                String sqlIVA = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + op + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ",1,0)";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA);

                //BUSCO EL BLOQUE GENERAL
                String idBloqueGG = (Persistencia.SentenciasSQL.select("SELECT IdBloque FROM com_bloques WHERE GG = -1 AND IdComunidad = " + id_comunidad_cargado)).Rows[0][0].ToString();

                //INSERTO EL REPARTO EN LA OPERACION ANTERIOR
                String sqlBloq = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES (" + op + "," + idBloqueGG + ",1," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq);

                //INSERTO EL VENCIMIENTO EN LA OPERACION ANTERIOR
                String sqlDetOp = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + op + "," + idEntidadComunidad + ",'" + fecha + "','" + fecha + "'," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ")";

                Persistencia.SentenciasSQL.InsertarGenerico(sqlDetOp);

                //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
                String sqlLiq = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + op + "," + Logica.FuncionesTesoreria.LiquidacionActiva(id_comunidad_cargado) + ",1," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq);

                //CREO DETALLE DEL MOVIMIENTO SACP
                String varDetOp = (Persistencia.SentenciasSQL.select("SELECT IdOpDet FROM com_opdetalles WHERE IdOp = " + op)).Rows[0][0].ToString();

                Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), varDetOp, Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text));
                MessageBox.Show("Apertura Realizada");
                form_anterior.cargarDatagrid();
                this.Close();
            }
        }

        private void maskedTextBox_fecha_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBox_fecha.Text, sPattern))
            {
                maskedTextBox_fecha.Text = maskedTextBox_fecha.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBox_fecha.Text, sPattern1))
            {
                textBox_importe.Select();
            }
            else
            {
                maskedTextBox_fecha.Focus();
                maskedTextBox_fecha.Select();
            }
    }
    }
}
