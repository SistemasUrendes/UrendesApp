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
    public partial class FormLiqCerrarOp : Form
    {
        String idComunidad;
        String idDetOperacion;
        String totalPte;
        String idEntidad;
        String idBloqueGG;
        String descripcion;
        FormDetallesOperacion form_anterior;

        public FormLiqCerrarOp(FormDetallesOperacion form_anterior, String idComunidad, String idEntidad, String idDetOperacion, String idBloqueGG, String totalPte, String descripcion)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idDetOperacion = idDetOperacion;
            this.totalPte = totalPte;
            this.form_anterior = form_anterior;
            this.idEntidad = idEntidad;
            this.idBloqueGG = idBloqueGG;
            this.descripcion = descripcion;
        }

        private void FormLiqCerrarOp_Load(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_liquidaciones.IdLiquidacion, com_liquidaciones.Liquidacion FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE (((com_ejercicios.IdComunidad) = " + idComunidad + "));";
            comboBox_liquidacion.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);

            comboBox_liquidacion.ValueMember = "IdLiquidacion";
            comboBox_liquidacion.DisplayMember = "Liquidacion";

        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            String fechaHoy = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd");
            String idCuentaCom = Logica.FuncionesTesoreria.CuentaCompesaciones(idComunidad);

            if (idCuentaCom == "No")
            {
                MessageBox.Show("Debes crear una cuenta de compesaciones para la comunidad");
                return;
            }

            //BUSCO EJERCICIO
            String IdEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(idComunidad, fechaHoy);
            //CREO EL MOVIMIENTO
            int idMov = Logica.FuncionesTesoreria.CreaMovimiento(IdEjercicio, idCuentaCom, "1", idEntidad, fechaHoy, "AJUSTE VENCIMIENTO ANTIGUO");
            //CREO EL DETALLE
            Logica.FuncionesTesoreria.CreaDetalleMovimiento(idMov.ToString(), idDetOperacion, totalPte.ToString().Replace(",", "."));


            //OPERACION DEV
            String sqlInsertOperacion = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdMovCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + idComunidad + "," + idEntidad + ",67800,1,'" + fechaHoy + "','VTO. ANTIGUO', 'VTO. ANTIGUO MOV" + idMov + "'," + idMov + "," + totalPte.ToString().Replace(",", ".") + "," + totalPte.ToString().Replace(",", ".") + ",'Si'," + Presentacion.Login.getId() + ",'" + fechaHoy + "')";

            int op = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacion);

            //INSERTO EL IVA EN LA OPERACION
            String sqlIVA = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + op + "," + totalPte.ToString().Replace(",", ".") + ",1,0.00)";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA);

            //INSERTO EL REPARTO EN LA OPERACION
            String sqlBloq2 = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES (" + op + "," + idBloqueGG + ",1," + totalPte.ToString().Replace(",", ".") + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq2);

            //INSERTO EL VENCIMIENTO EN LA OPERACION
            String sqlDetOp2 = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + op + "," + idEntidad + ",'" + fechaHoy + "','" + fechaHoy + "'," + totalPte.ToString().Replace(",", ".") + "," + totalPte.ToString().Replace(",", ".") + ")";
            int nuevaDet = Persistencia.SentenciasSQL.InsertarGenericoID(sqlDetOp2);

            //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
            String sqlLiq2 = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + op + "," + comboBox_liquidacion.SelectedValue.ToString() + ",1," + totalPte.ToString().Replace(",", ".") + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq2);

            //CREO EL MOVIMIENTO
            int idMovEntrada = Logica.FuncionesTesoreria.CreaMovimiento(IdEjercicio, idCuentaCom, "8", idEntidad, fechaHoy, "AJUSTE VENCIMIENTO ANTIGUO");
            //CREO EL DETALLE
            Logica.FuncionesTesoreria.CreaDetalleMovimiento(idMovEntrada.ToString(), nuevaDet.ToString(), totalPte.ToString().Replace(",", "."));

            MessageBox.Show("Movimiento de cuadre realizado");
            form_anterior.cargarDatagrid();
            this.Close();
        }

    }
}
