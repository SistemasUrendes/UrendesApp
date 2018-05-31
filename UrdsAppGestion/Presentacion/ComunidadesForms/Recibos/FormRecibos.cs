using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    public partial class FormRecibos : Form
    {
        String id_comunidad_cargado;
        String id_comunero_cargado = "0";
        String id_op_pasado;
        DataTable recibos;

        public FormRecibos(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        public FormRecibos(String id_comunidad_cargado, String id_comunero_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_comunero_cargado = id_comunero_cargado;
        }
        public void cargarDatagrid()
        {
            if (id_comunero_cargado != "0")
            {
                String fechaInicio = (Convert.ToDateTime(maskedTextBox_inicio.Text)).ToString("yyyy-MM-dd");
                String fechaFin = (Convert.ToDateTime(maskedTextBox_fin.Text)).ToString("yyyy-MM-dd");

                String sqlSelect = "SELECT com_recibos.IdRecibo, com_recibos.Fecha, com_recibos.IdEntidad, ctos_entidades.Entidad, com_recibos.IdCuota, com_recibos.Referencia, com_recibos.ImpRbo, com_recibos.ImpRboPte, com_recibos.FEnvio FROM com_recibos INNER JOIN ctos_entidades ON com_recibos.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_recibos.Fecha) >='" + fechaInicio + "' And (com_recibos.Fecha)<='" + fechaFin + "') AND ((com_recibos.IdComunidad)=" + id_comunidad_cargado + ") AND (com_recibos.IdEntidad = " + id_comunero_cargado + ")) ORDER BY com_recibos.Fecha DESC;";

                recibos = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_recibos.DataSource = recibos;
                ajustarDatagrid();
            }
            else
            {
                String fechaInicio = (Convert.ToDateTime(maskedTextBox_inicio.Text)).ToString("yyyy-MM-dd");
                String fechaFin = (Convert.ToDateTime(maskedTextBox_fin.Text)).ToString("yyyy-MM-dd");

                String sqlSelect = "SELECT com_recibos.IdRecibo, com_recibos.Fecha, com_recibos.IdEntidad, ctos_entidades.Entidad, com_recibos.IdCuota, com_recibos.Referencia, com_recibos.ImpRbo, com_recibos.ImpRboPte, com_recibos.FEnvio FROM com_recibos INNER JOIN ctos_entidades ON com_recibos.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_recibos.Fecha) >='" + fechaInicio + "' And (com_recibos.Fecha)<='" + fechaFin + "') AND ((com_recibos.IdComunidad)=" + id_comunidad_cargado + ")) ORDER BY com_recibos.Fecha DESC;";

                recibos = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_recibos.DataSource = recibos;
                ajustarDatagrid();
            }
        }

        private void FormRecibos_Load(object sender, EventArgs e)
        {
            maskedTextBox_inicio.Text = "01/01/2018";
            maskedTextBox_fin.Text = DateTime.Now.ToShortDateString();
            comboBox_estado.SelectedIndex = 2;
            if (id_comunero_cargado != "0")
                textBox_buscarComunero.Text = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IDEntidad = " + id_comunero_cargado)).Rows[0][0].ToString();


            cargarDatagrid();
        }
        private void ajustarDatagrid()
        {
            dataGridView_recibos.Columns["IdRecibo"].Width = 60;
            dataGridView_recibos.Columns["Fecha"].Width = 80;
            dataGridView_recibos.Columns["IdEntidad"].Width = 60;
            dataGridView_recibos.Columns["Entidad"].Width = 350;
            dataGridView_recibos.Columns["IdCuota"].Width = 60;
            dataGridView_recibos.Columns["Referencia"].Width = 170;
            dataGridView_recibos.Columns["ImpRbo"].DefaultCellStyle.Format = "c";
            dataGridView_recibos.Columns["ImpRboPte"].DefaultCellStyle.Format = "c";
            dataGridView_recibos.Columns["ImpRboPte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_recibos.Columns["ImpRbo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_recibos.Columns["FEnvio"].Width = 80;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargarDatagrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Recibos.FormNuevoRecibo nueva = new Recibos.FormNuevoRecibo(id_comunidad_cargado, id_comunero_cargado);
            nueva.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sqlSelect;

            String fechaInicio = (Convert.ToDateTime(maskedTextBox_inicio.Text)).ToString("yyyy-MM-dd");
            String fechaFin = (Convert.ToDateTime(maskedTextBox_fin.Text)).ToString("yyyy-MM-dd");

            sqlSelect = "SELECT com_recibos.IdRecibo, com_recibos.Fecha, com_recibos.IdEntidad, ctos_entidades.Entidad, com_recibos.IdCuota, com_recibos.Referencia, com_recibos.ImpRbo, com_recibos.ImpRboPte, com_recibos.FEnvio FROM com_recibos INNER JOIN ctos_entidades ON com_recibos.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_recibos.Fecha) >='" + fechaInicio + "' And (com_recibos.Fecha)<='" + fechaFin + "') AND ((com_recibos.IdComunidad)=" + id_comunidad_cargado + ")) ORDER BY com_recibos.Fecha DESC;";

            if (comboBox_estado.SelectedItem.ToString() == "Todos")
            {
                recibos = Persistencia.SentenciasSQL.select(sqlSelect);

                if (textBox_buscarComunero.Text != "")
                    recibos.DefaultView.RowFilter = "Entidad like '%" + textBox_buscarComunero.Text + "%'";

                dataGridView_recibos.DataSource = recibos;
                ajustarDatagrid();
            }
            else if (comboBox_estado.SelectedItem.ToString() == "Cerrados")
            {
                recibos = Persistencia.SentenciasSQL.select(sqlSelect);

                if (textBox_buscarComunero.Text != "")
                    recibos.DefaultView.RowFilter = "ImpRboPte = 0 AND Entidad like '%" + textBox_buscarComunero.Text + "%'";
                else
                    recibos.DefaultView.RowFilter = "ImpRboPte = 0";

                dataGridView_recibos.DataSource = recibos;
                ajustarDatagrid();
            }
            else if (comboBox_estado.SelectedItem.ToString() == "Pendientes")
            {
                recibos = Persistencia.SentenciasSQL.select(sqlSelect);

                if (textBox_buscarComunero.Text != "")
                    recibos.DefaultView.RowFilter = "ImpRboPte > 0 AND Entidad like '%" + textBox_buscarComunero.Text + "%'";
                else
                    recibos.DefaultView.RowFilter = "ImpRboPte > 0";

                dataGridView_recibos.DataSource = recibos;
                ajustarDatagrid();
            }
        }

        private void textBox_recibos_KeyPress(object sender, KeyPressEventArgs e)
        {
            int idRecibo;

            if (e.KeyChar == (Char)Keys.Enter && textBox_recibos.Text != "" && int.TryParse(textBox_recibos.Text, out idRecibo))
            {
                cargarDatagrid();
                recibos.DefaultView.RowFilter = "IdRecibo = " + idRecibo;
                dataGridView_recibos.DataSource = recibos;
                label_num.Text = "1 Registro en Pantalla";
                ajustarDatagrid();
            }
        }

        private void dataGridView_recibos_DataSourceChanged(object sender, EventArgs e)
        {
            label_num.Text = dataGridView_recibos.Rows.Count + " Registros en Pantalla";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonVerRecibo.Text = "Abriendo...";
            buttonVerRecibo.Enabled = false;
            EntidadesForms.VerReporte nueva = new EntidadesForms.VerReporte(dataGridView_recibos.SelectedRows[0].Cells[0].Value.ToString(), dataGridView_recibos.SelectedRows[0].Cells[2].Value.ToString(), id_comunidad_cargado);
            nueva.Show();
            buttonVerRecibo.Text = "Abrir Recibo";
            buttonVerRecibo.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttonImprimirRecibo.Text = "Imprimiendo...";
            buttonImprimirRecibo.Enabled = false;

            DataTable RecibosSeleccionados = new DataTable();

            FolderBrowserDialog fichero = new FolderBrowserDialog();

            String RutaComunidad = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Ruta FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_cargado + "));")).Rows[0][0].ToString().Trim('#');

            fichero.SelectedPath = RutaComunidad;

            if (fichero.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewColumn column in dataGridView_recibos.Columns)
                    RecibosSeleccionados.Columns.Add(column.Name);

                for (int i = 0; i < dataGridView_recibos.SelectedRows.Count; i++)
                {
                    RecibosSeleccionados.Rows.Add();
                    for (int j = 0; j < dataGridView_recibos.Columns.Count; j++)
                    {
                        RecibosSeleccionados.Rows[i][j] = dataGridView_recibos.SelectedRows[i].Cells[j].Value;
                    }
                }

                PanelControl existe = Application.OpenForms.OfType<PanelControl>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<PanelControl>();

                if (existe != null)
                {
                    existe.WindowState = FormWindowState.Normal;
                    existe.BringToFront();
                    existe.imprimirRecibos(RecibosSeleccionados, id_comunidad_cargado, fichero.SelectedPath);
                    
                }
            }
            buttonImprimirRecibo.Text = "Imprimir";
            buttonImprimirRecibo.Enabled = true;

        }

        private void abonarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double total_importe_vencimientos = 0.00;

            String sqlSelectVencimiento = "SELECT com_opdetalles.IdOpDet, com_opdetalles.IdOp FROM com_opdetalles WHERE com_opdetalles.IdRecibo = " + dataGridView_recibos.SelectedRows[0].Cells[0].Value.ToString();

            DataTable vencimientos = Persistencia.SentenciasSQL.select(sqlSelectVencimiento);

            id_op_pasado = vencimientos.Rows[0][1].ToString();

            //RECORRO LOS VECIMIENTOS DE ESA OPERACION PARA ABONARLOS
            String sqlSelectVencimientos = "SELECT IdOpDet, IdEntidad, Importe FROM com_opdetalles WHERE IdOp = " + id_op_pasado;

            DataTable vencimientosAntiguos = Persistencia.SentenciasSQL.select(sqlSelectVencimientos);

            for (int a = 0; a < vencimientosAntiguos.Rows.Count; a++)
            {
                    if (CreoAbonoVencimiento(id_op_pasado,vencimientosAntiguos.Rows[a][0].ToString(), vencimientosAntiguos.Rows[a][1].ToString(), vencimientosAntiguos.Rows[a][2].ToString()))
                        total_importe_vencimientos = total_importe_vencimientos + Convert.ToDouble(vencimientosAntiguos.Rows[a][2].ToString());
                    else
                        return;
            }
        }

        private Boolean CreoAbonoVencimiento(String idOp, String id_opdet, String id_entidad, String importe)
        {

            String fechaHoy = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
            String cuentaCompesaciones = Logica.FuncionesTesoreria.CuentaCompesaciones(id_comunidad_cargado);

            if (cuentaCompesaciones == "No")
            {
                MessageBox.Show("No existe la cuenta de compensaciones para esa comunidad");
                return false;
            }

            //BUSCO EL EJERCICIO ACTIVO
            String idEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaHoy);

            ////////######################### MOVIMIENTOS SOBRE LA OPERACION ############################//////////////////////

            //CREO CABECERA DEL MOVIMIENTO
            int numMov = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, cuentaCompesaciones, "15", id_entidad, fechaHoy, "Abono Salida");

            //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE
            Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), id_opdet, Logica.FuncionesGenerales.ArreglarImportes(importe));

            ////////############## CREO VENCIMIENTO Y MOVIMIENTOS SOBRE LA OPERACION DE ABONO ##############//////////////////

            int op_det = Logica.FuncionesTesoreria.CreoVencimientoID(idOp, id_entidad, fechaHoy, Logica.FuncionesGenerales.ArreglarImportes(importe), Logica.FuncionesGenerales.ArreglarImportes(importe));

            //CREO EL RECIBO
            int id_recibo = Logica.FuncionesTesoreria.CreoReciboID(id_comunidad_cargado, id_entidad, fechaHoy, "-" + importe, "-" + importe, "Recibo de Abono");

            //ACTUALIZO RECIBO EN EL VENCIMIENTO
            Logica.FuncionesTesoreria.ActualizoIdReciboVencimiento(id_recibo.ToString(), op_det.ToString());

            //CREO CABECERA DEL MOVIMIENTO
            int numMov1 = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, cuentaCompesaciones, "16", id_entidad, fechaHoy, "Abono Entrada");

            //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE
            Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov1.ToString(), op_det.ToString(), Logica.FuncionesGenerales.ArreglarImportes(importe));

            ////////##########################################################################################//////////////////////
            return true;

        }
        private void AbonoRecibo(String idOpActual)
        {
            int idopNegativa = 0;

            String CuentaCompesacion = Logica.FuncionesTesoreria.CuentaCompesaciones(id_comunidad_cargado);
            if (CuentaCompesacion == "No")
            {
                MessageBox.Show("Esa comunidad no tiene cuenta de compesaciones");
                return;
            }
            String fechaHoy = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd");

            String sqlOpPasada = "SELECT IdOp, IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Documento, Descripcion, IdRetencion, BaseRet, Retencion, Notas, IdDivision, IdExpte, ImpOp, ImpOpPte FROM com_operaciones WHERE IdOp = " + idOpActual;

            DataTable OperacionAabonar = Persistencia.SentenciasSQL.select(sqlOpPasada);

            String sqlInsertCabecera = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdRetencion, BaseRet, Retencion, Notas, IdEstado, IdDivision, IdExpte, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + OperacionAabonar.Rows[0][1].ToString() + "," + OperacionAabonar.Rows[0][2].ToString() + ",70001," + OperacionAabonar.Rows[0][4] + ",'" + fechaHoy + "',CONCAT('AB ','" + OperacionAabonar.Rows[0][5].ToString() + "'),CONCAT('ABONO ','" + OperacionAabonar.Rows[0][6].ToString() + "')," + OperacionAabonar.Rows[0][7].ToString() + "," + Logica.FuncionesGenerales.ArreglarImportes(OperacionAabonar.Rows[0][8].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(OperacionAabonar.Rows[0][9].ToString()) + ",'" + OperacionAabonar.Rows[0][10].ToString() + "',1," + OperacionAabonar.Rows[0][11].ToString() + ",'" + OperacionAabonar.Rows[0][12].ToString() + "',-" + Logica.FuncionesGenerales.ArreglarImportes(OperacionAabonar.Rows[0][13].ToString()) + ",-" + Logica.FuncionesGenerales.ArreglarImportes(OperacionAabonar.Rows[0][14].ToString()) + ",0,'Si'," + Login.getId() + ",'" + fechaHoy + "')";

            int idOpNueva = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertCabecera);

            //IVA
            String sqlIVA = "SELECT Base, IdIVA, IVA FROM com_opdetiva WHERE IdOp = " + idOpActual;
            DataTable ivasAnteriores = Persistencia.SentenciasSQL.select(sqlIVA);
            for (int b = 0; b < ivasAnteriores.Rows.Count; b++)
            {
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

            if (Convert.ToInt32(vencimientosAntiguos.Rows[0][5].ToString()) > 0 && vencimientosAntiguos.Rows[0][2].ToString() != vencimientosAntiguos.Rows[0][3].ToString())
            {

                //BUSCO EL EJERCICIO ACTIVO
                String idEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaHoy);

                String idMovDeOpDet = (Persistencia.SentenciasSQL.select("SELECT com_detmovs.IdMov FROM com_detmovs WHERE(((com_detmovs.IdOpDet) = " + vencimientosAntiguos.Rows[0][0].ToString() + "));").Rows[0][0].ToString());

                //CREO CABECERA DEL MOVIMIENTO
                int numMovAbono = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, Logica.FuncionesTesoreria.CuentaCompesaciones(id_comunidad_cargado), "11", vencimientosAntiguos.Rows[0][1].ToString(), fechaHoy, "Ingreso A Cuenta");

                Logica.FuncionesTesoreria.AbonoComunero(id_comunidad_cargado, vencimientosAntiguos.Rows[0][1].ToString(), fechaHoy, -1 * Convert.ToDouble(vencimientosAntiguos.Rows[0][3].ToString()), numMovAbono);


                int numMov = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, Logica.FuncionesTesoreria.CuentaCompesaciones(id_comunidad_cargado), "11", vencimientosAntiguos.Rows[0][1].ToString(), fechaHoy, "Abono a Comuneros");
                //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE ENTERO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), vencimientosAntiguos.Rows[0][0].ToString(), Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][3].ToString()));

                String sqlInserDetalle = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetMov, ImpOpDetPte, NumMov, IdEstado) VALUES (" + idOpNueva + "," + vencimientosAntiguos.Rows[0][1].ToString() + ",'" + fechaHoy + "','" + fechaHoy + "',-" + Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][2].ToString()) + ",-" + Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][3].ToString()) + ",-" + Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][4].ToString()) + ",0,1)";
                idopNegativa = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInserDetalle);
            }

            String strDesc = "Comp. Abono Cuota";
            //CREO LA CABECERA MOVIMIENTO
            int varMovSal = Logica.FuncionesTesoreria.CreaMovimiento(Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaHoy), CuentaCompesacion, "15", vencimientosAntiguos.Rows[0][1].ToString(), fechaHoy, strDesc);

            ////CREO EL DETALLE DEL MOVIMIENTO
            Logica.FuncionesTesoreria.CreaDetalleMovimiento(varMovSal.ToString(), idopNegativa.ToString(), Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][2].ToString()));

            //CREO LA CABECERA MOVIMIENTO
            int varMovEnt = Logica.FuncionesTesoreria.CreaMovimientoCA(Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaHoy), CuentaCompesacion, "16", vencimientosAntiguos.Rows[0][1].ToString(), fechaHoy, strDesc, varMovSal.ToString());

            //CREO EL DETALLE DEL MOVIMIENTO
            Logica.FuncionesTesoreria.CreaDetalleMovimiento(varMovEnt.ToString(), vencimientosAntiguos.Rows[0][0].ToString(), Logica.FuncionesGenerales.ArreglarImportes(vencimientosAntiguos.Rows[0][2].ToString()));

            //ACTUALIZO CA EN MOVSAL
            Logica.FuncionesTesoreria.ActualizaMovCA(varMovEnt.ToString(), varMovSal.ToString());
        }
        
        private void dataGridView_recibos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_recibos.HitTest(e.X, e.Y);
                dataGridView_recibos.ClearSelection();
                dataGridView_recibos.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fichero = new FolderBrowserDialog();
            DataTable RecibosSeleccionados = new DataTable();

            DataTable DatosComunidad = Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Ruta, ctos_entidades.NombreCorto FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_cargado + "));");

            String RutaComunidad = DatosComunidad.Rows[0][0].ToString().Trim('#');
            String strComunidad = DatosComunidad.Rows[0][1].ToString();

            fichero.SelectedPath = RutaComunidad;

            if (fichero.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewColumn column in dataGridView_recibos.Columns)
                    RecibosSeleccionados.Columns.Add(column.Name);

                for (int i = 0; i < dataGridView_recibos.SelectedRows.Count; i++)
                {
                    RecibosSeleccionados.Rows.Add();
                    for (int j = 0; j < dataGridView_recibos.Columns.Count; j++)
                    {
                        RecibosSeleccionados.Rows[i][j] = dataGridView_recibos.SelectedRows[i].Cells[j].Value;
                    }
                }

                PanelControl existe = Application.OpenForms.OfType<PanelControl>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<PanelControl>();

                if (existe != null)
                {
                    existe.WindowState = FormWindowState.Normal;
                    existe.BringToFront();
                    existe.enviarRecibos(RecibosSeleccionados, strComunidad, fichero.SelectedPath);
                }
            }
        }

        private void dataGridView_recibos_DoubleClick(object sender, EventArgs e)
        {
            String sqlSelectIdOp = "SELECT com_operaciones.IdOp FROM com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp WHERE com_opdetalles.IdRecibo = " + dataGridView_recibos.SelectedRows[0].Cells[0].Value.ToString();

            DataTable idOp = Persistencia.SentenciasSQL.select(sqlSelectIdOp);

            if (idOp.Rows.Count > 0) {
                OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(idOp.Rows[0][0].ToString(),2);
                nueva.Show();
            }
        }
    }
}
