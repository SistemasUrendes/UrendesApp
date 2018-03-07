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
    public partial class FormIniciarFondo : Form
    {
        String idComunidad;
        String idFondo;
        String ImporteResultado;
        String idDetalleFondoAnterior = "";
        FormFondos form_anterior;


        public FormIniciarFondo(FormFondos form_anterior, String idComunidad, String idFondo)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idFondo = idFondo;
            this.form_anterior = form_anterior;
        }

        public FormIniciarFondo(FormFondos form_anterior, String idComunidad, String idFondo, String ImporteResultado, String idDetalleFondoAnterior)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idFondo = idFondo;
            this.form_anterior = form_anterior;
            this.ImporteResultado = ImporteResultado;
            this.idDetalleFondoAnterior = idDetalleFondoAnterior;
        }

        private void FormIniciarFondo_Load(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_ejercicios.IdEjercicio, com_ejercicios.Ejercicio FROM com_ejercicios WHERE(((com_ejercicios.IdComunidad) = " + idComunidad + "));";

            comboBox_ejercicio.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            comboBox_ejercicio.ValueMember = "IdEjercicio";
            comboBox_ejercicio.DisplayMember = "Ejercicio";

            cargarCombo();

        }
        private void cargarCombo() {
            String sqlSelectLiq = "SELECT com_liquidaciones.IdLiquidacion, com_liquidaciones.Liquidacion FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE (((com_ejercicios.IdEjercicio) = " + comboBox_ejercicio.SelectedValue.ToString() + ") AND((com_ejercicios.IdComunidad) = " + idComunidad + "));";

            listBox_liquidaciones.DataSource = Persistencia.SentenciasSQL.select(sqlSelectLiq);

            listBox_liquidaciones.ValueMember = "IdLiquidacion";
            listBox_liquidaciones.DisplayMember = "Liquidacion";

            textBox_importe.Text = ImporteResultado;
        }

        private void button_fondoVacio_Click(object sender, EventArgs e)
        {
            String sqlInsert = "INSERT INTO com_detallesfondo (IdFondo, IdEjercicio, Entradas, Salidas, SaldoInicial, SaldoActual, SaldoCierre) VALUES (" + idFondo + "," + comboBox_ejercicio.SelectedValue + ",0.00,0.00,0.00,0.00,0.00)";

            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            form_anterior.cargarDatagrid();
            form_anterior.cargarDatagridDetalles(); ;
            this.Close();
        }

        private void button1_traspaso_Click(object sender, EventArgs e)
        {
            ImporteResultado = textBox_importe.Text;
            String idEntidadComunidad = (Persistencia.SentenciasSQL.select("SELECT IdEntidad FROM com_comunidades WHERE IdComunidad = " + idComunidad)).Rows[0][0].ToString();

            //BUSCO EL BLOQUE PRINCIPAL
            String sqlIdBloqueGeneral = "SELECT IdBloque FROM com_bloques WHERE IdComunidad = " + idComunidad + " AND GG = -1";
            String IdBloque = (Persistencia.SentenciasSQL.select(sqlIdBloqueGeneral)).Rows[0][0].ToString();

            String fechaHoy = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd");

            //BUSCO ÚLTIMA LIQUIDACIÓN DEL FONDO ANTERIOR PARA LA OPERACIÓN DE SALIDA
            
            if (idDetalleFondoAnterior != "" || idDetalleFondoAnterior == null)
            {
                String sqlUltimaLiquidacion = "SELECT IdLiquidacion FROM com_liquidaciones WHERE IdDetalleFondo = " + idDetalleFondoAnterior + " ORDER BY FFin DESC LIMIT 1";
                DataTable ultimaLiquidacion = Persistencia.SentenciasSQL.select(sqlUltimaLiquidacion);
                if (ultimaLiquidacion.Rows.Count > 0)
                {
                    String sqlSelect = "SELECT SaldoActual FROM com_detallesfondo WHERE IdDetalleFondo = " + idDetalleFondoAnterior;
                    DataTable saldo = Persistencia.SentenciasSQL.select(sqlSelect);
                    String saldoResultado = "0.00";

                    if (saldo.Rows.Count > 0)
                    {
                        saldoResultado = saldo.Rows[0][0].ToString();
                    }

                    String sqlUpdateAnterior = "UPDATE com_detallesfondo SET Resultado=0.00, SaldoActual=" + saldoResultado.ToString().Replace(",", ".") + ", SaldoCierre=" + saldoResultado.ToString().Replace(",", ".") + ",Cierre=-1 WHERE IdDetalleFondo = " + idDetalleFondoAnterior;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateAnterior);

                    String descripcionSalida = "SALIDA TRASPASO FONDO";
                    String idLiquidacionSalida = ultimaLiquidacion.Rows[0][0].ToString();

                    //OPERACIÓN SALIDA
                    String sqlInsertCabeSalida = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Descripcion, IdEstado, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + idComunidad + "," + idEntidadComunidad + ", 55502, 1,'" + fechaHoy + "','" + descripcionSalida + "',1," + ImporteResultado.Replace(',', '.') + ",0.00,0,'Si'," + Login.getId() + ",'" + fechaHoy + "')";
                    int idOpSalida = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertCabeSalida);
                    //IVA
                    String sqlInsertIva = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + idOpSalida + "," + ImporteResultado.Replace(',', '.') + ",1,0.00)";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertIva);
                    //REPARTO
                    String sqlInsertReparto = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES (" + idOpSalida + "," + IdBloque + ",1," + ImporteResultado.Replace(',', '.') + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertReparto);
                    //VENCIMIENTOS
                    String sqlInsertVencimiento = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, Importe, ImpOpDetPte) VALUES (" + idOpSalida + "," + idEntidadComunidad + ",'" + fechaHoy + "'," + ImporteResultado.Replace(',', '.') + ",0.00)";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertVencimiento);
                    //LIQUIDACIONES
                    String sqlInsertarLiquidacionDet = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + idOpSalida + "," + idLiquidacionSalida + ",1," + ImporteResultado.Replace(',', '.') + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertarLiquidacionDet);

                }
            }

            String descripcionEntrada = "ENTRADA TRASPASO INICIAL FONDO";

            //BUSCO ÚLTIMA LIQ AÑADIDA
            String idLiquidacionEntrada = "0";
            String FechaAnterior = DateTime.Now.ToShortDateString();

            foreach (object element in listBox_liquidaciones.SelectedItems)
            {
                DataRowView row = (DataRowView)element;
                
                String sqlidLiquidacion = "SELECT FFin FROM com_liquidaciones WHERE IdLiquidacion = " + row[0].ToString();
                DataTable fechaLiq = Persistencia.SentenciasSQL.select(sqlidLiquidacion);

                if (DateTime.Compare(Convert.ToDateTime(fechaLiq.Rows[0][0].ToString()),Convert.ToDateTime(FechaAnterior)) < 0) {
                    FechaAnterior = fechaLiq.Rows[0][0].ToString();
                    idLiquidacionEntrada = row[0].ToString();
                }
            }

            //OPERACIÓN ENTRADA
            String sqlInsertCabeEntrada = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Descripcion, IdEstado, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + idComunidad + "," + idEntidadComunidad + ", 55501, 1,'" + FechaAnterior + "','" + descripcionEntrada + "',1," + ImporteResultado.Replace(',', '.') + ",0.00,0,'Si'," + Login.getId() + ",'" + fechaHoy + "')";
            int idOpEntrada = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertCabeEntrada);
            //IVA
            String sqlInsertIvaEntrada = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + idOpEntrada + "," + ImporteResultado.Replace(',', '.') + ",1,0.00)";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertIvaEntrada);
            //REPARTO
            //BUSCO EL BLOQUE PRINCIPAL
            String sqlInsertRepartoEntrada = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES (" + idOpEntrada + "," + IdBloque + ",1," + ImporteResultado.Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertRepartoEntrada);
            //VENCIMIENTOS
            String sqlInsertVencimientoEntrada = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, Importe, ImpOpDetPte) VALUES (" + idOpEntrada + "," + idEntidadComunidad + ",'" + fechaHoy + "'," + ImporteResultado.Replace(',', '.') + ",0.00)";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertVencimientoEntrada);
            //LIQUIDACIONES
            String sqlInsertarLiquidacionDetEntrada = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + idOpEntrada + "," + idLiquidacionEntrada + ",1," + ImporteResultado.Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertarLiquidacionDetEntrada);

            String sqlInsert = "INSERT INTO com_detallesfondo (IdFondo, IdEjercicio, Entradas, Salidas, SaldoInicial, Resultado, SaldoActual, SaldoCierre) VALUES (" + idFondo + "," + comboBox_ejercicio.SelectedValue + ",0.00,0.00," + ImporteResultado.Replace(',', '.') + ",0.00," + ImporteResultado.Replace(',', '.') + ",0.00)";

            int idDetalleNueva = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert);


            foreach (object element in listBox_liquidaciones.SelectedItems)
            {
                DataRowView row = (DataRowView)element;
                String sqlUpdate = "UPDATE com_liquidaciones SET IdDetalleFondo = " + idDetalleNueva + " WHERE IdLiquidacion = " + row[0].ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }

            form_anterior.CalcularFondo(idDetalleNueva.ToString());
            form_anterior.cargarDatagrid();
            form_anterior.cargarDatagridDetalles(); ;
            this.Close();
        }

        private void comboBox_ejercicio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarCombo();
        }
    }
}
