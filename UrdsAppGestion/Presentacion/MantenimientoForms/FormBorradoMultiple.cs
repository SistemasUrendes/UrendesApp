using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.MantenimientoForms
{
    public partial class FormBorradoMultiple : Form
    {
        DataTable filas_pegadas = new DataTable();
        public FormBorradoMultiple()
        {
            InitializeComponent();
            label3.Visible = false;
        }

        private void dataGridView_idBorrar_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.V)
            {
                filas_pegadas.Columns.Clear();
                filas_pegadas.Columns.Add(textBox_campo.Text);

                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');

                foreach (string line in lines)
                {
                    DataRow row2 = filas_pegadas.NewRow();
                    if (line.Length > 0)
                    {
                        string[] cells = line.Split('\t');
                        for (int i = 0; i < cells.GetLength(0); ++i)
                        {
                            row2[i] = cells[i];
                        }
                    }
                    else
                    {
                        break;
                    }
                    filas_pegadas.Rows.Add(row2);
                }
            }
            dataGridView_idBorrar.DataSource = filas_pegadas;
            label3.Visible = true;
            label3.Text = dataGridView_idBorrar.Rows.Count.ToString();

        }
        private void button_borrar_Click(object sender, EventArgs e)
        {
            //progressBar1.Visible = true;
            //progressBar1.Maximum = dataGridView_idBorrar.Rows.Count;

            //if (textBox_campo.Text != "" && textBox_nombre_tabla.Text != "") {
            //    for (int a = 0; a < dataGridView_idBorrar.Rows.Count; a++) {

            //        String sqlDelete = "DELETE FROM " + textBox_nombre_tabla.Text + " WHERE " + textBox_campo.Text + " = " + dataGridView_idBorrar.Rows[a].Cells[0].Value.ToString().Replace("\r","");

            //        //MessageBox.Show(sqlDelete);
            //        Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
            //        progressBar1.Value = a;
            //    }
            //}else {
            //    MessageBox.Show("Rellena los dos campos");
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = dataGridView_idBorrar.Rows.Count;

            for (int a = 0; a < dataGridView_idBorrar.Rows.Count; a++)
            {
                progressBar1.Value = a;
                String sqlUpdate = "UPDATE com_opdetalles SET ImpOpDetMov = Importe, ImpOpDetPte= 0.00 WHERE IdOpDet = " + dataGridView_idBorrar.Rows[a].Cells[0].Value.ToString().Replace("\r", ""); ;

                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String IdSubcuenta;
            String IdEntidad;
            String Importe;
            String Fecha;
            String idComunidad;

            //PONGO A 0 EL IMPORTE DEL VENCIMIENTO CREANDO MOVIMIENTOS.
            for (int a = 0; a < dataGridView_idBorrar.Rows.Count; a++)
            {
                Double totalMov = 0.00;
                String sqlVencimientos = "SELECT com_opdetalles.IdOpDet FROM com_opdetalles WHERE com_opdetalles.IdOp = " + dataGridView_idBorrar.Rows[a].Cells[0].Value.ToString();

                DataTable vencimientos = Persistencia.SentenciasSQL.select(sqlVencimientos);

                for (int b = 0; b < vencimientos.Rows.Count; b++ ) {
                    String IdOpDet = vencimientos.Rows[b][0].ToString();

                    String sqlMovs = "SELECT com_detmovs.IdOpDet, Sum(com_detmovs.Importe*If(idtipomov=1,1,0)) AS ImpEnt, Sum(com_detmovs.Importe*IF(idtipomov=2,1,0)) AS ImpSal FROM(com_detmovs INNER JOIN com_movimientos ON com_detmovs.IdMov = com_movimientos.IdMov) INNER JOIN com_dettiposmov ON com_movimientos.IdDetTipoMov = com_dettiposmov.IdDetTipoMov GROUP BY com_detmovs.IdOpDet HAVING com_detmovs.IdOpDet = " + IdOpDet;

                    DataTable movimientos = Persistencia.SentenciasSQL.select(sqlMovs);

                    String sqlIdSubcuenta = "SELECT com_operaciones.IdSubCuenta, com_operaciones.IdEntidad, com_opdetalles.Importe, com_opdetalles.Fecha, com_operaciones.IdComunidad FROM com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp WHERE(((com_opdetalles.IdOpDet) = " + IdOpDet + "));";
                    DataTable datos = Persistencia.SentenciasSQL.select(sqlIdSubcuenta);

                    if (datos.Rows.Count > 0)
                    {
                        IdSubcuenta = datos.Rows[0][0].ToString();
                        IdEntidad = datos.Rows[0][1].ToString();
                        Importe = datos.Rows[0][2].ToString();
                        Fecha = datos.Rows[0][3].ToString();
                        idComunidad = datos.Rows[0][4].ToString();
                    }
                    else
                    {
                        return;
                    }

                    double entrada = 0.00;
                    double salida = 0.00;

                    for (int c = 0; c < movimientos.Rows.Count; c++)
                    {
                        entrada += Convert.ToDouble(movimientos.Rows[b][1]);
                        salida += Convert.ToDouble(movimientos.Rows[b][2]);
                    }

                    String tipoOperacion = "";
                    String sqltipo = "SELECT ES FROM com_subcuentas WHERE IdSubCuenta = " + IdSubcuenta;
                    DataTable tipoC = Persistencia.SentenciasSQL.select(sqltipo);

                    if (tipoC.Rows.Count > 0)
                    {
                        tipoOperacion = tipoC.Rows[0][0].ToString();
                    }

                    if (tipoOperacion == "1")
                    {
                        Double importeOpDet = Convert.ToDouble(Importe);
                        Double sumaMov = entrada - salida;
                        totalMov = totalMov + sumaMov;

                        //Double ImporteAingresar = importeOpDet + salida;

                        // insertarMovimiento(ImporteAingresar.ToString(), Fecha, IdEntidad, IdOpDet, "1", idComunidad);

                    }
                    else if (tipoOperacion == "2")
                    {
                        Double importeOpDet = Convert.ToDouble(Importe);
                        Double sumaMov = salida - entrada;
                        totalMov = totalMov + sumaMov;
                        //Double ImporteAingresar = importeOpDet + entrada;

                        //insertarMovimiento(ImporteAingresar.ToString(), Fecha, IdEntidad, IdOpDet, "2", idComunidad);
                    }

                }
                MessageBox.Show(totalMov.ToString());

            }
        }
        public static void insertarMovimiento(String importe, String fecha, String idEntidad, String idOpdet, String tipoMov, String idComunidad)
        {

            String sqlSelectCuenta = "SELECT com_cuentas.IdCuenta FROM com_cuentas WHERE(((com_cuentas.IdComunidad) = " + idComunidad + ") AND((com_cuentas.A) = -1));";

            String idCuentaCom = (Persistencia.SentenciasSQL.select(sqlSelectCuenta)).Rows[0][0].ToString();
            if (idCuentaCom == "")
            {
                MessageBox.Show("Debes crear una cuenta de Ajustes para la comunidad");
                return;
            }

            int año = Convert.ToDateTime(fecha).Year;

            int dia = DateTime.DaysInMonth(Convert.ToDateTime(fecha).Year, 12);
            String fechaHoy = año + "-12-" + dia;

            //BUSCO EJERCICIO
            String IdEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(idComunidad, fechaHoy);
            //CREO EL MOVIMIENTO
            int idMov = Logica.FuncionesTesoreria.CreaMovimiento(IdEjercicio, idCuentaCom, tipoMov, idEntidad, fechaHoy, "AJUSTE VENCIMIENTO ANTIGUO_4");
            //CREO EL DETALLE
            Logica.FuncionesTesoreria.CreaDetalleMovimiento(idMov.ToString(), idOpdet, importe.Replace(",", "."));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        public static void AjustarVencimiento (String IdOp) {
            String IdSubcuenta = "";
            String IdEntidad = "";
            String Importe = "";
            String Fecha = "";
            String idComunidad = "";
            String tipoOperacion = "";
            String IdOpDet = "";

            //PONGO A 0 EL IMPORTE DEL VENCIMIENTO CREANDO MOVIMIENTOS.
            Double totalMov = 0.00;
            String sqlVencimientos = "SELECT com_opdetalles.IdOpDet, com_operaciones.ImpOp, com_operaciones.IdOp FROM com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE com_opdetalles.IdOp = " + IdOp;

            DataTable vencimientos = Persistencia.SentenciasSQL.select(sqlVencimientos);

            for (int b = 0; b < vencimientos.Rows.Count; b++)
            {
                IdOpDet = vencimientos.Rows[b][0].ToString();

                String sqlMovs = "SELECT com_detmovs.IdOpDet, Sum(com_detmovs.Importe*If(idtipomov=1,1,0)) AS ImpEnt, Sum(com_detmovs.Importe*IF(idtipomov=2,1,0)) AS ImpSal FROM(com_detmovs INNER JOIN com_movimientos ON com_detmovs.IdMov = com_movimientos.IdMov) INNER JOIN com_dettiposmov ON com_movimientos.IdDetTipoMov = com_dettiposmov.IdDetTipoMov GROUP BY com_detmovs.IdOpDet HAVING com_detmovs.IdOpDet = " + IdOpDet;

                DataTable movimientos = Persistencia.SentenciasSQL.select(sqlMovs);

                String sqlIdSubcuenta = "SELECT com_operaciones.IdSubCuenta, com_operaciones.IdEntidad, com_opdetalles.Importe, com_opdetalles.Fecha, com_operaciones.IdComunidad FROM com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp WHERE(((com_opdetalles.IdOpDet) = " + IdOpDet + "));";
                DataTable datos = Persistencia.SentenciasSQL.select(sqlIdSubcuenta);

                if (datos.Rows.Count > 0)
                {
                    IdSubcuenta = datos.Rows[0][0].ToString();
                    IdEntidad = datos.Rows[0][1].ToString();
                    Importe = datos.Rows[0][2].ToString();
                    Fecha = datos.Rows[0][3].ToString();
                    idComunidad = datos.Rows[0][4].ToString();
                }
                else
                {
                    return;
                }

                double entrada = 0.00;
                double salida = 0.00;

                for (int c = 0; c < movimientos.Rows.Count; c++)
                {
                    entrada += Convert.ToDouble(movimientos.Rows[c][1]);
                    salida += Convert.ToDouble(movimientos.Rows[c][2]);
                }

                String sqltipo = "SELECT ES FROM com_subcuentas WHERE IdSubCuenta = " + IdSubcuenta;
                DataTable tipoC = Persistencia.SentenciasSQL.select(sqltipo);

                if (tipoC.Rows.Count > 0)
                {
                    tipoOperacion = tipoC.Rows[0][0].ToString();
                }

                if (tipoOperacion == "1")
                {
                    Double importeOpDet = Convert.ToDouble(Importe);
                    Double sumaMov = entrada - salida;
                    //totalMov = totalMov + sumaMov;

                    double totalAdevolver = Math.Round(Convert.ToDouble(Importe) - sumaMov, 2);

                    if (totalAdevolver < 0)
                    {
                        if (totalAdevolver != 0)
                            insertarMovimiento((Convert.ToDouble(totalAdevolver.ToString()) * -1).ToString().Replace(",", "."), Fecha, IdEntidad, IdOpDet, "8", idComunidad);
                    }
                    else
                    {
                        if (totalAdevolver != 0)
                            insertarMovimiento(totalAdevolver.ToString().Replace(",", "."), Fecha, IdEntidad, IdOpDet, "1", idComunidad);
                    }

                }
                else if (tipoOperacion == "2")
                {
                    Double importeOpDet = Convert.ToDouble(Importe);
                    Double sumaMov = salida - entrada;
                    //totalMov = totalMov + sumaMov;

                    double totalAdevolver = Math.Round(sumaMov - Convert.ToDouble(Importe), 2);

                    if (totalAdevolver > 0)
                    {
                        if (totalAdevolver != 0)
                            insertarMovimiento(totalAdevolver.ToString().Replace(",", "."), Fecha, IdEntidad, IdOpDet, "1", idComunidad);
                    }
                    else
                    {
                        if (totalAdevolver != 0)
                            insertarMovimiento((totalAdevolver * -1).ToString().Replace(",", "."), Fecha, IdEntidad, IdOpDet, "8", idComunidad);
                    }
                }

            }
            if (vencimientos.Rows.Count > 0)
            {

                //RETIFICO LO QUE HA HECHO EL TRIGGER EN OPDETALLES
                String sqlUpdateDtealle = "UPDATE com_opdetalles SET ImpOpDetPte=0.00,ImpOpDetMov=com_opdetalles.Importe WHERE IdOpDet = " + IdOpDet;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateDtealle);

                //RETIFICO LO QUE HA HECHO TRIGGER EN OPERACIONES
                String sqlUpdateOperaciones = "UPDATE com_operaciones SET ImpOpPte=0.00 WHERE IdOp = " + vencimientos.Rows[0][2].ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateOperaciones);

                //BUSCO EL RECIBO Y LO PONGO A CERO TAMBIEN
                String sqlIdRecibo = "SELECT com_opdetalles.IdRecibo FROM com_opdetalles WHERE com_opdetalles.IdOpDet = " + IdOpDet;
                DataTable recibos = Persistencia.SentenciasSQL.select(sqlIdRecibo);

                if (recibos.Rows.Count > 0 && recibos.Rows[0][0].ToString() != "")
                {
                    String sqlUpdate = "UPDATE com_recibos SET ImpRboPte=0.00  WHERE IdRecibo = " + recibos.Rows[0][0].ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);

                }
            }
        }
    }
}
