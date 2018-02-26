using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms
{
    public partial class Cuotas : Form
    {
        String id_comunidad_cargado;

        public Cuotas(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void Cuotas_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
            comboBox_TipoPlantilla.SelectedItem = "Tipo División";
        }
        public void cargarDatagrid() {
            String SelectCuotas = "SELECT com_cuotas.IdCuota, com_cuotas.FEmision, com_cuotas.Descripcion, com_liquidaciones.Liquidacion, com_ejercicios.Ejercicio, com_metodoscuotas.Método, com_tipocuotas.TipoCuota, com_cuotas.FVto, com_cuotas.IdEstado FROM(((com_cuotas INNER JOIN com_liquidaciones ON com_cuotas.IdLiquidacion = com_liquidaciones.IdLiquidacion) INNER JOIN com_tipocuotas ON com_cuotas.IdTipoCuota = com_tipocuotas.IdTipoCuota) INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio) INNER JOIN com_metodoscuotas ON com_ejercicios.IdMetodoCuota = com_metodoscuotas.IdMetodoCuota WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + ")) ORDER BY com_cuotas.FEmision DESC, com_cuotas.IdCuota DESC;";

            DataTable cuotas = Persistencia.SentenciasSQL.select(SelectCuotas);
            dataGridView_Cuotas.DataSource = cuotas;

        }

        private void button_Añadir_Click(object sender, EventArgs e)
        {
            FormCuotasAlta nueva = new FormCuotasAlta(this, id_comunidad_cargado,1);
            nueva.Show();
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta Cuota ?", "Borrar Cuota", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                BorrarCuota(dataGridView_Cuotas.SelectedCells[0].Value.ToString());
            }
        }
        private void BorrarCuota(String id_cuota) {

            String numeroMovimientos = "SELECT Count(com_detmovs.IdDetMov) AS CuentaDeIdDetMov FROM(com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_detmovs ON com_opdetalles.IdOpDet = com_detmovs.IdOpDet GROUP BY com_operaciones.IdCuota HAVING(((com_operaciones.IdCuota) = " + id_cuota + "));";

            DataTable movimientos = Persistencia.SentenciasSQL.select(numeroMovimientos);
            if (movimientos.Rows.Count > 0)
            {
                if (Convert.ToInt32(movimientos.Rows[0][0].ToString()) > 0)
                {
                    MessageBox.Show("No se puede borrar porque existen movimientos");
                }
                else if (Convert.ToInt32(movimientos.Rows[0][0].ToString()) == 0 )
                {
                    //BORRO LOS RECIBOS PERTENECIENTES A ESA CUOTA
                    String sqlBorrarRecibos = "DELETE From com_recibos WHERE (((com_recibos.IdCuota) = " + id_cuota + "));";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarRecibos);

                    //BORRO LAS OPERACIONES PERTENECIENTES A ESA CUOTA
                    String sqlBorrarOperaciones = "DELETE From com_operaciones WHERE (((com_operaciones.IdCuota) = " + id_cuota + "));";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarOperaciones);

                    //BORRO LA CUOTA
                    String sqlBorrar = "DELETE FROM com_cuotas WHERE IdCuota = " + id_cuota;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);

                    MessageBox.Show("Cuota Borrada");
                    cargarDatagrid();
                }
            }else {
                //BORRO LOS RECIBOS PERTENECIENTES A ESA CUOTA
                String sqlBorrarRecibos = "DELETE From com_recibos WHERE (((com_recibos.IdCuota) = " + id_cuota + "));";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarRecibos);

                //BORRO LAS OPERACIONES PERTENECIENTES A ESA CUOTA
                String sqlBorrarOperaciones = "DELETE From com_operaciones WHERE (((com_operaciones.IdCuota) = " + id_cuota + "));";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarOperaciones);

                //BORRO LA CUOTA
                String sqlBorrar = "DELETE FROM com_cuotas WHERE IdCuota = " + id_cuota;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);

                MessageBox.Show("Cuota Borrada");
                cargarDatagrid();
            }
        }

        private void dataGridView_Cuotas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_Cuotas.HitTest(e.X, e.Y);
                dataGridView_Cuotas.ClearSelection();
                dataGridView_Cuotas.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void verDetallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCuotasDetalle nueva = new FormCuotasDetalle(dataGridView_Cuotas.SelectedCells[0].Value.ToString(), dataGridView_Cuotas.SelectedCells[2].Value.ToString(), dataGridView_Cuotas.SelectedCells[8].Value.ToString());
            nueva.Show();
        }

        private void button_IrAPlantillas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aun esta en fase de prueba");
            //Manuales
            //Presupuesto
            //Tipo División

            ComboBox combo = comboBox_TipoPlantilla;
            FormCuotasPlantillas nueva = new FormCuotasPlantillas(id_comunidad_cargado, combo.SelectedItem.ToString());
            nueva.Show();

            //if (combo.SelectedItem.ToString() == "Tipo División") { 
            //    FormCuotasPlantillaTipoDivDetalle nueva = new FormCuotasPlantillaTipoDivDetalle(id_comunidad_cargado, combo.SelectedItem.ToString());
            //    nueva.Show();
            //}
            //if (combo.SelectedItem.ToString() == "Manuales")
            //{
            //    FormCuotasPlantillaManualDetalle nueva = new FormCuotasPlantillaManualDetalle(id_comunidad_cargado);
            //    nueva.Show();
            //}
            //else if (combo.SelectedItem.ToString() == "Presupuesto")
            //{
            //    FormCuotasPlantillaPptoDetalle nueva = new FormCuotasPlantillaPptoDetalle(id_comunidad_cargado);
            //    nueva.Show();
            //}
            //else if (combo.SelectedItem.ToString() == "Todas")
            //{
            //    FormCuotasPlantillas nueva = new FormCuotasPlantillas(id_comunidad_cargado);
            //    nueva.Show();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCuotasAlta nueva = new FormCuotasAlta(this, id_comunidad_cargado,2);
            nueva.Show();
        }

        private void informeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuotasForms.Informes.VisorInformeCuotas nueva = new Informes.VisorInformeCuotas(dataGridView_Cuotas.SelectedRows[0].Cells[0].Value.ToString());
            nueva.Show();
        }

        private void button_abonar_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            button_abonar.Enabled = false;
            AbonarCuotaSeleccionada();
            progressBar1.Visible = false;
            button_abonar.Enabled = true;
        }
        private void AbonarCuotaSeleccionada() {

            DialogResult resultado_message;
            MessageBox.Show("Asegurate que no existen ingresos en esa Cuota");
            resultado_message = MessageBox.Show("¿Desea Abonar la cuota de " + dataGridView_Cuotas.SelectedRows[0].Cells[2].Value.ToString()  + " ?", "Abonar Cuota", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.Cancel)
                return;

            String fechaHoy = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");

            //TEMPORAL
            fechaHoy = (Convert.ToDateTime("2017-10-30")).ToString("yyyy-MM-dd");
            String sqlCuotaVieja = "SELECT Descripcion, IdLiquidacion, IdTipoCuota,IdMetodo,FEmision, FVto FROM com_cuotas WHERE IdCuota = " + dataGridView_Cuotas.SelectedRows[0].Cells[0].Value.ToString();

            String IdCuotaVieja = dataGridView_Cuotas.SelectedRows[0].Cells[0].Value.ToString();

            DataTable cuotaVieja = Persistencia.SentenciasSQL.select(sqlCuotaVieja);

            String CuentaCompesacion = Logica.FuncionesTesoreria.CuentaCompesaciones(id_comunidad_cargado);
            if (CuentaCompesacion == "No")
            {
                MessageBox.Show("Esa comunidad no tiene cuenta de compesaciones");
                return;
            }

            if (cuotaVieja.Rows.Count > 0)  {

                String fechaEmision = (Convert.ToDateTime(cuotaVieja.Rows[0][4].ToString())).ToString("yyyy-MM-dd");
                String fechaVto = (Convert.ToDateTime(cuotaVieja.Rows[0][5].ToString())).ToString("yyyy-MM-dd");

                String sqlInsertCuota = "INSERT INTO com_cuotas (Descripcion, IdLiquidacion, IdTipoCuota, IdMetodo, FEmision, FVto, IdEstado) VALUES ('ABONO " + cuotaVieja.Rows[0][0].ToString() + "'," + cuotaVieja.Rows[0][1].ToString() + "," + cuotaVieja.Rows[0][2].ToString() + "," + cuotaVieja.Rows[0][3].ToString() + ",'" + fechaEmision + "','" + fechaVto + "','1')";
                int idNuevaCuota = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertCuota);

                String sqlOperacionesAabonar = "SELECT IdOp, IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Documento, Descripcion, IdRetencion, BaseRet, Retencion, Notas, IdDivision, IdExpte, ImpOp, ImpOpPte FROM com_operaciones WHERE IdCuota = " + IdCuotaVieja;
                DataTable OperacionesAabonar = Persistencia.SentenciasSQL.select(sqlOperacionesAabonar);
                progressBar1.Maximum = OperacionesAabonar.Rows.Count;

                for (int a = 0; a < OperacionesAabonar.Rows.Count;a++) {
                    progressBar1.Value = a;
                    String idOpActual = OperacionesAabonar.Rows[a][0].ToString();
                    String sqlInsertCabecera = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdRetencion, BaseRet, Retencion, Notas, IdEstado, IdCuota, IdDivision, IdExpte, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + OperacionesAabonar.Rows[a][1].ToString() + "," + OperacionesAabonar.Rows[a][2].ToString() + "," + OperacionesAabonar.Rows[a][3].ToString() + "," + OperacionesAabonar.Rows[a][4] + ",'" + fechaHoy + "',CONCAT('AB ','" + OperacionesAabonar.Rows[a][5].ToString() + "'),CONCAT('ABONO ','" + OperacionesAabonar.Rows[a][6].ToString() + "')," + OperacionesAabonar.Rows[a][7].ToString() + "," + Logica.FuncionesGenerales.ArreglarImportes(OperacionesAabonar.Rows[a][8].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(OperacionesAabonar.Rows[a][9].ToString()) + ",'" + OperacionesAabonar.Rows[a][10].ToString() + "',1," + idNuevaCuota + "," + OperacionesAabonar.Rows[a][11].ToString() + ",'" + OperacionesAabonar.Rows[a][12].ToString() + "',-" + Logica.FuncionesGenerales.ArreglarImportes(OperacionesAabonar.Rows[a][13].ToString()) + ",-" + Logica.FuncionesGenerales.ArreglarImportes(OperacionesAabonar.Rows[a][14].ToString()) + ",0,'Si'," + Login.getId() + ",'" + fechaHoy + "')";
                    int idOpNueva = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertCabecera);

                    //IVA
                    String sqlIVA = "SELECT Base, IdIVA, IVA FROM com_opdetiva WHERE IdOp = " + idOpActual;
                    DataTable ivasAnteriores = Persistencia.SentenciasSQL.select(sqlIVA);
                    for (int b = 0; b < ivasAnteriores.Rows.Count;b++) {
                        String sqlInsertIVA = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + idOpNueva + ",-" + Logica.FuncionesGenerales.ArreglarImportes(ivasAnteriores.Rows[b][0].ToString()) + "," + ivasAnteriores.Rows[b][1].ToString() + ",-" + Logica.FuncionesGenerales.ArreglarImportes(ivasAnteriores.Rows[b][2].ToString()) + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertIVA);

                    }

                    //REPARTO
                    String sqlReparto = "SELECT IdBloque, Porcentaje, Importe FROM com_opdetbloques WHERE IdOp = " + idOpActual;
                    DataTable repartosAnteriores = Persistencia.SentenciasSQL.select(sqlReparto);
                    for (int b = 0; b < repartosAnteriores.Rows.Count; b++)
                    {
                        String sqlInsertReparto = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES (" + idOpNueva + "," + repartosAnteriores.Rows[b][0].ToString() + "," + Logica.FuncionesGenerales.ArreglarImportes(repartosAnteriores.Rows[b][1].ToString()) + ",-" + Logica.FuncionesGenerales.ArreglarImportes(repartosAnteriores.Rows[b][2].ToString()) + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertReparto);

                    }

                    //LIQUIDACION
                    String sqlLiquidacion = "SELECT IdLiquidacion, Porcentaje, Importe FROM com_opdetliquidacion WHERE IdOp = " + idOpActual;
                    DataTable liquidacionesAnteriores = Persistencia.SentenciasSQL.select(sqlLiquidacion);
                    for (int b = 0; b < liquidacionesAnteriores.Rows.Count; b++)
                    {
                        String sqlInsertLiquidacion = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + idOpNueva + "," + liquidacionesAnteriores.Rows[b][0].ToString() + "," + Logica.FuncionesGenerales.ArreglarImportes(liquidacionesAnteriores.Rows[b][1].ToString()) + ",-" + Logica.FuncionesGenerales.ArreglarImportes(liquidacionesAnteriores.Rows[b][2].ToString()) + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertLiquidacion);
                    }

                    //VENCIMIENTOS
                    String sqlVencimientos = "SELECT IdOpDet, IdEntidad, Importe, ImpOpDetMov, ImpOpDetPte, NumMov, FXN FROM com_opdetalles WHERE IdOp = " + idOpActual;
                    DataTable vencimientosAntiguos = Persistencia.SentenciasSQL.select(sqlVencimientos);

                    String FXN = vencimientosAntiguos.Rows[0][6].ToString().Replace(IdCuotaVieja, idNuevaCuota.ToString());
                    int idopNegativa=0;

                    if (vencimientosAntiguos.Rows.Count > 1) {
                        MessageBox.Show("Aspai");

                    }else if (vencimientosAntiguos.Rows.Count == 1) {
                        //if (Convert.ToInt32(vencimientosAntiguos.Rows[0][5].ToString()) > 0 && vencimientosAntiguos.Rows[0][2].ToString() != vencimientosAntiguos.Rows[0][4].ToString()) {

                        //    //BUSCO EL EJERCICIO ACTIVO
                        //    String idEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaHoy);

                        //    String idMovDeOpDet = (Persistencia.SentenciasSQL.select("SELECT com_detmovs.IdMov FROM com_detmovs WHERE(((com_detmovs.IdOpDet) = " + vencimientosAntiguos.Rows[0][0].ToString() + "));").Rows[0][0].ToString());

                        //    //CREO CABECERA DEL MOVIMIENTO
                        //    //int numMovAbono = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, Logica.FuncionesTesoreria.CuentaCompesaciones(id_comunidad_cargado), "11", vencimientosAntiguos.Rows[0][1].ToString(), fechaHoy, "Ingreso A Cuenta");

                        //    //Logica.FuncionesTesoreria.AbonoComunero(id_comunidad_cargado, vencimientosAntiguos.Rows[0][1].ToString(), fechaHoy, -1* Convert.ToDouble(vencimientosAntiguos.Rows[0][3].ToString()), numMovAbono);

                        //    int numMov = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, Logica.FuncionesTesoreria.CuentaCompesaciones(id_comunidad_cargado), "11", vencimientosAntiguos.Rows[0][1].ToString(), fechaHoy, "Abono a Comuneros");

                        //    //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE ENTERO
                        //    Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), vencimientosAntiguos.Rows[0][0].ToString(), Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][3].ToString()));

                        //    String sqlInserDetalle = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetMov, ImpOpDetPte, NumMov, IdEstado, FXN) VALUES (" + idOpNueva + "," + vencimientosAntiguos.Rows[0][1].ToString() + ",'" + fechaHoy + "','" + fechaHoy + "',-" + Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][2].ToString()) + ",-" + Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][3].ToString()) + ",-" + Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][4].ToString()) + ",0,1,'" + FXN + "')";
                        //    idopNegativa = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInserDetalle);
                        //}
                        //else  {
                            String sqlInserDetalle = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetMov, ImpOpDetPte, NumMov, IdEstado, FXN) VALUES (" + idOpNueva + "," + vencimientosAntiguos.Rows[0][1].ToString() + ",'" + fechaHoy + "','" + fechaHoy + "',-" + Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][2].ToString()) + ",-" + Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][3].ToString()) + ",-" + Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][3].ToString()) + ",0,1,'" + FXN + "')";
                            idopNegativa = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInserDetalle);
                        //}

                        //String strDesc = "Comp. Abono Cuota";

                        //// ENTRADA DEL NUEVO VENCIMIENTO
                        ////CREO LA CABECERA MOVIMIENTO
                        //int varMovSal = Logica.FuncionesTesoreria.CreaMovimiento(Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaHoy), CuentaCompesacion, "15", vencimientosAntiguos.Rows[0][1].ToString(), fechaHoy, strDesc);

                        //////CREO EL DETALLE DEL MOVIMIENTO
                        //Logica.FuncionesTesoreria.CreaDetalleMovimiento(varMovSal.ToString(), idopNegativa.ToString(), "-" + Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][2].ToString()));


                        //// SALIDA DEL ANTIGUO VENCIMIENTO
                        ////CREO LA CABECERA MOVIMIENTO  
                        //int varMovEnt = Logica.FuncionesTesoreria.CreaMovimientoCA(Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaHoy), CuentaCompesacion, "16", vencimientosAntiguos.Rows[0][1].ToString(), fechaHoy, strDesc, varMovSal.ToString());
                        ////CREO EL DETALLE DEL MOVIMIENTO
                        //Logica.FuncionesTesoreria.CreaDetalleMovimiento(varMovEnt.ToString(), vencimientosAntiguos.Rows[0][0].ToString(), Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][2].ToString()));
                        ////ACTUALIZO CA EN MOVSAL
                        //Logica.FuncionesTesoreria.ActualizaMovCA(varMovEnt.ToString(), varMovSal.ToString());

                    }
                }
                Logica.FuncionesTesoreria.CreoRecibosAgrupados(id_comunidad_cargado, idNuevaCuota.ToString());
            }

            cargarDatagrid();
            MessageBox.Show("Cuota Abono Creada");
        }
    }
}


