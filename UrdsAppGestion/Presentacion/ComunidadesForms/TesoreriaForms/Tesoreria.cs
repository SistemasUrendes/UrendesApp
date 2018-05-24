using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    public partial class Tesoreria : Form
    {
        String nombre_comunidad = "";
        int id_comunidad;
        int id_cuenta;
        DataTable nueva;
        String fechaCierre;

        public Tesoreria(String nombre_comunidad,int id_comunidad,int id_cuenta)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.nombre_comunidad = nombre_comunidad;
            this.id_cuenta = id_cuenta;
        }

        private void Tesoreria_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String sql2 = "SELECT IdEjercicio,Ejercicio FROM com_ejercicios WHERE IdComunidad = " + id_comunidad + " ORDER BY FFin DESC";

            comboBox_ejercicio.DataSource = Persistencia.SentenciasSQL.select(sql2);
            comboBox_ejercicio.DisplayMember = "Ejercicio";
            comboBox_ejercicio.ValueMember = "IdEjercicio";

            String sqlEjercicioActivo = "SELECT IdEjercicio FROM com_ejercicios WHERE IdComunidad = " + id_comunidad + " AND Ppal = -1";
            DataTable EjercicioAtivo = Persistencia.SentenciasSQL.select(sqlEjercicioActivo);
            if (EjercicioAtivo.Rows.Count > 0)
                comboBox_ejercicio.SelectedValue = EjercicioAtivo.Rows[0][0].ToString();
            else
                MessageBox.Show("No hay ejercicio principal");

            String sql = "SELECT com_movimientos.IdMov, com_movimientos.Fecha, com_movimientos.Detalle, com_movimientos.IdEjercicio, com_movimientos.IdCuenta, com_movimientos.IdDetTipoMov, com_movimientos.IdEntidad, ctos_entidades.Entidad, com_movimientos.MovDevol, com_movimientos.MovCA, com_movimientos.ImpMovEnt, com_movimientos.ImpMovSal, com_movimientos.ImpMovNeto,com_movimientos.MovSaldo,  com_movimientos.IdRemesa,com_movimientos.NumSecuencia FROM com_movimientos INNER JOIN ctos_entidades ON com_movimientos.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_movimientos.IdEjercicio) = " + comboBox_ejercicio.SelectedValue + " ) AND ((com_movimientos.IdCuenta) = " + id_cuenta + ") ) ORDER BY com_movimientos.NumSecuencia DESC;";

            nueva = Persistencia.SentenciasSQL.select(sql);

            dataGridView_tesoreria.DataSource = nueva;

            //CONSIGO LA FECHA DE CIERRE DE LA CUENTA
            fechaCierreRecargar();

            //VALOR POR DEFECTO COMBOS
            //comboBox_s_proveedor.SelectedIndex = 0;
            ajustarDatagrid();
        }
        private void fechaCierreRecargar() {
            String sqlFechaCierre = "SELECT FCierre FROM com_cuentas WHERE IdCuenta = " + id_cuenta;
            fechaCierre = (Persistencia.SentenciasSQL.select(sqlFechaCierre)).Rows[0][0].ToString();
            textBox_fechacierre.Text = fechaCierre;
        }
        private void comboBox_ejercicio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String sql = "SELECT IdMov,Fecha, Detalle, IdEjercicio, IdCuenta, IdDetTipoMov, com_movimientos.IdEntidad, ctos_entidades.Entidad, MovDevol, MovCA, ImpMovEnt, ImpMovSal, ImpMovNeto,MovSaldo, IdRemesa,NumSecuencia FROM com_movimientos INNER JOIN ctos_entidades ON com_movimientos.IdEntidad = ctos_entidades.IDEntidad WHERE (((com_movimientos.IdEjercicio) = " + comboBox_ejercicio.SelectedValue + " ) AND ((com_movimientos.IdCuenta) = " + id_cuenta + ") ) ORDER BY com_movimientos.NumSecuencia DESC";

            nueva = Persistencia.SentenciasSQL.select(sql);
            dataGridView_tesoreria.DataSource = nueva;
            ajustarDatagrid();

        }
        public void ajustarDatagrid() {
            dataGridView_tesoreria.Columns["IdEjercicio"].Visible = false;
            dataGridView_tesoreria.Columns["IdCuenta"].Visible = false;
            dataGridView_tesoreria.Columns["IdDetTipoMov"].Visible = false;
            dataGridView_tesoreria.Columns["IdEntidad"].Visible = false;
            dataGridView_tesoreria.Columns["MovDevol"].Visible = false;
            dataGridView_tesoreria.Columns["MovCA"].Visible = false;
            dataGridView_tesoreria.Columns["ImpMovEnt"].Visible = false;
            dataGridView_tesoreria.Columns["ImpMovSal"].Visible = false;
            dataGridView_tesoreria.Columns["IdRemesa"].Visible = false;
            dataGridView_tesoreria.Columns["NumSecuencia"].Visible = true;

            dataGridView_tesoreria.Columns["Entidad"].Width = 350;
            dataGridView_tesoreria.Columns["MovSaldo"].Width = 117;
            dataGridView_tesoreria.Columns["Detalle"].Width = 250;
            dataGridView_tesoreria.Columns["Fecha"].Width = 80;
            dataGridView_tesoreria.Columns["IdMov"].Width = 70;

            dataGridView_tesoreria.Columns["MovSaldo"].HeaderText = "Saldo";
            dataGridView_tesoreria.Columns["ImpMovNeto"].HeaderText = "Neto";
            dataGridView_tesoreria.Columns["NumSecuencia"].Width = 85;
            dataGridView_tesoreria.Columns["NumSecuencia"].Visible = false;
            dataGridView_tesoreria.Columns["NumSecuencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView_tesoreria.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_tesoreria.Columns[12].DefaultCellStyle.Format = "c";
            dataGridView_tesoreria.Columns[13].DefaultCellStyle.Format = "c";
            dataGridView_tesoreria.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_tesoreria.Columns["Fecha"].DefaultCellStyle.Format = "d";
        }
        private void textBox_entidad_TextChanged(object sender, EventArgs e)
        {
            if (textBox_buscar.TextLength == 0)
            {
                DataTable busqueda = nueva;
                busqueda.DefaultView.RowFilter = "Entidad like '%%' ";
                this.dataGridView_tesoreria.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = nueva;
                busqueda.DefaultView.RowFilter = "Entidad like '%" + textBox_buscar.Text + "%' OR Detalle like '%" + textBox_buscar.Text + "%'";
                this.dataGridView_tesoreria.DataSource = busqueda;
            }
        }

        private void textBox_detalles_TextChanged(object sender, EventArgs e)
        {
            if (textBox_idmov.TextLength == 0)
            {
                DataTable busqueda = nueva;
                busqueda.DefaultView.RowFilter = "IdMov > 0 ";
                this.dataGridView_tesoreria.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = nueva;
                busqueda.DefaultView.RowFilter = "IdMov = " + textBox_idmov.Text + "";
                this.dataGridView_tesoreria.DataSource = busqueda;
            }
        }

        private void comboBox_s_proveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
           // ComboBox combo = (ComboBox)sender;
            if (comboBox_s_proveedor.SelectedIndex == 0 )
            {
                TesoreriaForms.FormOperacionesTesoreria nueva = new TesoreriaForms.FormOperacionesTesoreria(this,id_comunidad.ToString(), id_cuenta.ToString(),"Pago");
                nueva.Show();
            }
            else if (comboBox_s_proveedor.SelectedIndex == 1 )
            {
                TesoreriaForms.FormAccesoOperacionesTesoreria nueva = new TesoreriaForms.FormAccesoOperacionesTesoreria(id_comunidad.ToString(),id_cuenta.ToString(),"Pago a Proveedor");
                nueva.Show();
            }
        }

        private void button_mostrarSecuencia_Click(object sender, EventArgs e)
        {
            if (dataGridView_tesoreria.Columns["NumSecuencia"].Visible == false)
            {
                dataGridView_tesoreria.Columns["NumSecuencia"].Visible = true;
            }else {
                dataGridView_tesoreria.Columns["NumSecuencia"].Visible = false;
            }
        }

        private void button_banco_Click(object sender, EventArgs e)
        {
            OperacionesForms.FormTesoreriaCasamiento nueva = new OperacionesForms.FormTesoreriaCasamiento(id_comunidad.ToString());
            nueva.Show();
        }

        private void verVencimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TesoreriaForms.FormVerVencimientos nueva = new TesoreriaForms.FormVerVencimientos(dataGridView_tesoreria.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void dataGridView_tesoreria_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                borrarMovimientoToolStripMenuItem.Visible = false;
                borrar0MovimientosToolStripMenuItem.Visible = false;

                if (dataGridView_tesoreria.SelectedRows.Count > 1) {
                    var hti = dataGridView_tesoreria.HitTest(e.X, e.Y);
                    dataGridView_tesoreria.Rows[hti.RowIndex].Selected = true;

                    borrar0MovimientosToolStripMenuItem.Visible = true;
                    borrar0MovimientosToolStripMenuItem.Text = "Borrar " + dataGridView_tesoreria.SelectedRows.Count + " Movimientos";
                    borrarMovimientoToolStripMenuItem.Visible = false;

                }
                else
                {
                    buscarFechaToolStripMenuItem.Visible = true;
                    borrarMovimientoToolStripMenuItem.Visible = true;
                    var hti = dataGridView_tesoreria.HitTest(e.X, e.Y);
                    dataGridView_tesoreria.ClearSelection();
                    dataGridView_tesoreria.Rows[hti.RowIndex].Selected = true;
                    buscarFechaToolStripMenuItem.Text = "Filtrar Fecha = " + dataGridView_tesoreria.SelectedRows[0].Cells[1].Value.ToString();

                }
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void comboBox_e_comuneros_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ComboBox combo = (ComboBox)sender;
            if (comboBox_e_comuneros.SelectedIndex == 0)
            {
                TesoreriaForms.FormAccesoOperacionesTesoreria nueva = new TesoreriaForms.FormAccesoOperacionesTesoreria(id_comunidad.ToString(), id_cuenta.ToString(), "Ingreso a Comuneros");
                nueva.Show();

            }else if (comboBox_e_comuneros.SelectedIndex == 1) {

                TesoreriaForms.Remesas nueva = new TesoreriaForms.Remesas(this,id_comunidad.ToString(),id_cuenta.ToString(), "Remesa de Ingreso");
                nueva.Show();

            }
        }

        private void comboBox_s_comuneros_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ComboBox combo = (ComboBox)sender;
            if (comboBox_s_comuneros.SelectedIndex == 0)  {
                TesoreriaForms.FormAccesoOperacionesTesoreria nueva = new TesoreriaForms.FormAccesoOperacionesTesoreria(id_comunidad.ToString(), id_cuenta.ToString(), "Salida a Comuneros");
                nueva.Show();
            }
            else if (comboBox_s_comuneros.SelectedIndex == 1)  {
                TesoreriaForms.Remesas nueva = new TesoreriaForms.Remesas(this,id_comunidad.ToString(), id_cuenta.ToString(), "Remesa de Abono");
                nueva.Show();
            }else if (comboBox_s_comuneros.SelectedIndex == 2) {
                if (dataGridView_tesoreria.Rows.Count > 0)
                {
                    String tipoMov = (Persistencia.SentenciasSQL.select("SELECT IdTipoMov FROM com_dettiposmov WHERE IdDetTipoMov = " + dataGridView_tesoreria.SelectedRows[0].Cells[5].Value.ToString())).Rows[0][0].ToString();

                    if (tipoMov == "1")
                    {
                        TesoreriaForms.FormDevolucionIngreso nueva = new TesoreriaForms.FormDevolucionIngreso(this, id_comunidad.ToString(), dataGridView_tesoreria.SelectedRows[0].Cells[0].Value.ToString());
                        nueva.Show();
                    }
                    else
                    {
                        MessageBox.Show("Debes seleccionar un movimiento de Entrada");
                    }
                }
            }
        }

        private void comboBox_e_otras_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox combo = (ComboBox)sender;
            if (comboBox_e_otras.SelectedIndex == 0)
            {
                TesoreriaForms.FormTraspasoES nueva = new TesoreriaForms.FormTraspasoES(this, id_comunidad.ToString(), "1", id_cuenta.ToString());
                nueva.Show();
            }
            else if (comboBox_e_otras.SelectedIndex == 1)
            {
                TesoreriaForms.FormAsientoApertura nueva = new TesoreriaForms.FormAsientoApertura(this, id_comunidad.ToString(), id_cuenta.ToString(), comboBox_ejercicio.SelectedValue.ToString());
                nueva.Show();
            }
            else if (comboBox_e_otras.SelectedIndex == 2)   {
                TesoreriaForms.FormOperacionesTesoreria nueva = new TesoreriaForms.FormOperacionesTesoreria(this, id_comunidad.ToString(), id_cuenta.ToString(), "Otras Entradas");
                nueva.Show();
            }
        }

        private void comboBox_s_otras_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (comboBox_s_otras.SelectedIndex == 0)
            {
                TesoreriaForms.FormTraspasoES nueva = new TesoreriaForms.FormTraspasoES(this, id_comunidad.ToString(), "2", id_cuenta.ToString());
                nueva.Show();
            }
            else if (comboBox_s_otras.SelectedIndex == 1) {
                TesoreriaForms.FormOperacionesTesoreria nueva = new TesoreriaForms.FormOperacionesTesoreria(this, id_comunidad.ToString(), id_cuenta.ToString(), "Otras Salidas");
                nueva.Show();
            }
            else if (comboBox_s_otras.SelectedIndex == 2)
            {
                TesoreriaForms.FormDevolucionAbonoCuota nueva = new TesoreriaForms.FormDevolucionAbonoCuota(this,dataGridView_tesoreria.SelectedRows[0].Cells[0].Value.ToString(), comboBox_ejercicio.SelectedValue.ToString(), id_cuenta.ToString(), dataGridView_tesoreria.SelectedRows[0].Cells[6].Value.ToString(), dataGridView_tesoreria.SelectedRows[0].Cells[11].Value.ToString());

                nueva.Show();
            }
        }

        private void comboBox_e_proveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ComboBox combo = (ComboBox)sender;
            if (comboBox_e_proveedor.SelectedIndex == 0)
            {
                TesoreriaForms.FormAccesoOperacionesTesoreria nueva = new TesoreriaForms.FormAccesoOperacionesTesoreria(id_comunidad.ToString(), id_cuenta.ToString(), "Entrada a Proveedor");
                nueva.Show();
            }
        }

        private void borrarMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrarMovimiento();
        }
        private void BorrarMovimiento() {
            //BORRAR MOVIMIENTO
            List<String> movimientosParaBorrar = new List<String>();
            List<String> movimientosNoSePueden = new List<String>();

            for (int a = 0; a < dataGridView_tesoreria.SelectedRows.Count; a++)
            {
                String idMovimiento = dataGridView_tesoreria.SelectedRows[a].Cells[0].Value.ToString();
                String tipoMovimiento = Logica.FuncionesTesoreria.TipoMovimiento(idMovimiento);

                if (!Logica.FuncionesTesoreria.FechaCierreAceptado(idMovimiento))
                {
                    MessageBox.Show("Banco Cerrado a fecha de ese movimiento. No se puede Borrar ese movimiento:\n " + idMovimiento);
                    movimientosNoSePueden.Add(idMovimiento);
                    continue;
                }

                switch (tipoMovimiento)
                {
                    case "1":
                    case "2":
                    case "3":
                        if (!Logica.FuncionesTesoreria.MovimientoDevuelto(idMovimiento))
                        {
                            String SelectOp = "SELECT IdOp FROM com_operaciones WHERE IdMovCrea = " + idMovimiento + " AND ImpOp < 0";
                            DataTable temporal = Persistencia.SentenciasSQL.select(SelectOp);

                            if (temporal.Rows.Count > 0)
                            {
                                if (temporal.Rows[0][0].ToString() != "" || temporal.Rows[0][0].ToString() != null)
                                {
                                    String NumeroMovimientos = "SELECT com_opdetalles.IdOp, com_detmovs.IdDetMov FROM com_opdetalles INNER JOIN com_detmovs ON com_opdetalles.IdOpDet = com_detmovs.IdOpDet WHERE (((com_opdetalles.IdOp)=" + temporal.Rows[0][0].ToString() + "));";
                                    DataTable movimientosTemp = Persistencia.SentenciasSQL.select(NumeroMovimientos);
                                    if (movimientosTemp.Rows.Count > 0)
                                    {
                                        MessageBox.Show("No se puede borrar. El movimiento generó un anticipo del Comunero y se ha utilizado");
                                        movimientosNoSePueden.Add(idMovimiento);
                                    }
                                }
                            }
                            else
                            {
                                movimientosParaBorrar.Add(idMovimiento);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El movimiento ha sido devuelto y no se puede borrar");
                            movimientosNoSePueden.Add(idMovimiento);
                        }

                        break;
                    case "6":
                        //OTROS
                        if (!Logica.FuncionesTesoreria.MovimientoDevuelto(idMovimiento))
                        {
                            movimientosParaBorrar.Add(idMovimiento);
                        }
                        else
                        {
                            movimientosNoSePueden.Add(idMovimiento);
                            MessageBox.Show("El movimiento ha sido devuelto y no se puede borrar");
                            return;
                        }

                        break;
                    //ES UN PAGO
                    case "8":
                    case "9":
                        //COMPRUEBO SI HA SIDO DEVUELTO Y LA FECHA DE CIERRE
                        if (!Logica.FuncionesTesoreria.MovimientoDevuelto(idMovimiento))
                            movimientosParaBorrar.Add(idMovimiento);
                        else
                            movimientosNoSePueden.Add(idMovimiento);

                        break;
                    case "7":
                    case "22":
                        String fechaMov;
                        String idRemesa = dataGridView_tesoreria.SelectedRows[a].Cells[14].Value.ToString();

                        try {fechaMov = (Convert.ToDateTime(dataGridView_tesoreria.SelectedRows[a].Cells[1].Value)).ToString("yyyy-MM-dd"); }
                        catch { MessageBox.Show("Fallo en fecha"); return; }

                        if (idRemesa != "" || idRemesa != null) {
                            String IngreRemeconDevol = "SELECT com_movimientos.IdMov, com_movimientos.IdCuenta, com_movimientos.Fecha, com_movimientos.IdRemesa, com_movimientos.MovDevol From com_movimientos WHERE (((com_movimientos.IdCuenta)=" + id_cuenta + ") AND ((com_movimientos.Fecha)='" + fechaMov + "') AND ((com_movimientos.IdRemesa)=" + idRemesa + ") AND (Not (com_movimientos.MovDevol) Is Null));";

                            DataTable RemesaConDevol = Persistencia.SentenciasSQL.select(IngreRemeconDevol);
                            if (RemesaConDevol.Rows.Count > 0) {
                                MessageBox.Show("No se puede borrar la remesa porque hay movimientos que han sido devueltos");
                                return;
                            }else {
                                DialogResult resultado_message;
                                resultado_message = MessageBox.Show("Esta opción elimina la remesa completa. ¿Seguimos?", "Borrar Remesa", MessageBoxButtons.OKCancel);
                                if (resultado_message == System.Windows.Forms.DialogResult.OK) {
                                    String sqlMovs = "SELECT com_movimientos.IdMov, com_movimientos.IdRemesa FROM com_movimientos WHERE (((com_movimientos.IdRemesa)=" + idRemesa + "));";
                                    DataTable movBorrar = Persistencia.SentenciasSQL.select(sqlMovs);
                                    if (movBorrar.Rows.Count > 0) {
                                       for (int b = 0; b < movBorrar.Rows.Count;b++) {
                                            movimientosParaBorrar.Add(movBorrar.Rows[b][0].ToString());
                                        }

                                        //Actualizamos el estado de la remesa a 2 (18/08/2016 Provisional)
                                        String sqlActRemesa = "UPDATE com_remesas SET com_remesas.IdEstado = 2 WHERE (((com_remesas.IdRemesa)=" + idRemesa + "));";
                                        Persistencia.SentenciasSQL.InsertarGenerico(sqlActRemesa);
                                    }
                                }
                            }
                        }

                        break;
                    case "18":
                    case "20":
                    case "21":
                        String IdMovCrea = "SELECT IdOp FROM com_operaciones WHERE IdMovCrea = " + idMovimiento;
                        DataTable TableIdMovCrea = Persistencia.SentenciasSQL.select(IdMovCrea);
                        if (TableIdMovCrea.Rows.Count > 0)
                        {
                            IdMovCrea = TableIdMovCrea.Rows[0][0].ToString();
                            Logica.FuncionesOperaciones.CombrobacionesBorrarOp(IdMovCrea);
                            movimientosParaBorrar.Add(idMovimiento);
                        }
                        else
                        {
                            MessageBox.Show("No existe un IdMovCrea en la tabla operaciones.");
                            movimientosNoSePueden.Add(idMovimiento);
                        }
                        break;
                    case "12":
                        String varOpEnt, varIdOpdet, varRbo, varMovGastos, varOpGasto;

                        String sqlSelect = "SELECT com_operaciones.IdOp FROM com_operaciones WHERE(((com_operaciones.IdSubCuenta) = 70001) AND((com_operaciones.IdMovCrea) = " + idMovimiento + "));";

                        DataTable movcreas = Persistencia.SentenciasSQL.select(sqlSelect);
                        if (movcreas.Rows.Count > 0 && movcreas.Rows[0][0].ToString() != "")  {
                            varOpEnt = movcreas.Rows[0][0].ToString();

                            varIdOpdet = (Persistencia.SentenciasSQL.select("SELECT com_opdetalles.IdOpDet FROM com_opdetalles WHERE com_opdetalles.IdOp = " + varOpEnt)).Rows[0][0].ToString();

                            //COMPRUEBO QUE EL GASTO NO TIENE MOVIMIENTOS

                            DataTable movimientos = Persistencia.SentenciasSQL.select("SELECT Count(com_detmovs.IdDetMov) AS CuentaDeIdDetMov FROM com_detmovs GROUP BY com_detmovs.IdOpDet HAVING (((com_detmovs.IdOpDet) = " + varIdOpdet + "));");

                            if (movimientos.Rows.Count > 0 && movimientos.Rows[0][0].ToString() != "0") {
                                MessageBox.Show("No se puede borrar. Existe un gasto particular y tiene movimientos");
                                movimientosNoSePueden.Add(idMovimiento);
                                break;
                            }

                            //COMPRUEBO QUE EL RECIBO NO HAS SIDO ENVIADO
                            String sqlSelectRecibo = "SELECT com_opdetalles.IdRecibo FROM com_opdetalles WHERE com_opdetalles.IdOpDet = " + varIdOpdet + ";";

                            DataTable recibos = Persistencia.SentenciasSQL.select(sqlSelectRecibo);
                            varRbo = "";
                            if (recibos.Rows.Count > 0) {
                                varRbo = recibos.Rows[0][0].ToString();
                                String sqlFechaEnvio = "SELECT FEnvio FROM com_recibos WHERE com_recibos.IdRecibo = " + varRbo + " AND com_recibos.FEnvio Is Not Null;";
                                DataTable envios = Persistencia.SentenciasSQL.select(sqlFechaEnvio);
                                if (envios.Rows.Count > 0)  {
                                    MessageBox.Show("El recibo ha sido enviado el día: " + envios.Rows[0][0].ToString() );
                                    break;
                                }
                            }

                            //BORRO MOVIMIENTO
                            varMovGastos = (Persistencia.SentenciasSQL.select("SELECT com_movimientos.IdMov FROM com_movimientos WHERE com_movimientos.IdDetTipoMov = 8 AND com_movimientos.MovDevol = " + idMovimiento + ";")).Rows[0][0].ToString();

                            Logica.FuncionesTesoreria.BorrarMoviento(varMovGastos);

                            varOpGasto = (Persistencia.SentenciasSQL.select("SELECT com_operaciones.IdOp FROM com_operaciones WHERE com_operaciones.IdSubCuenta = 62600 AND com_operaciones.IdMovCrea = " + idMovimiento)).Rows[0][0].ToString();
                            Logica.FuncionesTesoreria.BorrarRecibo(varRbo);
                            Logica.FuncionesTesoreria.BorrarOperacion(varOpEnt);
                            Logica.FuncionesTesoreria.BorrarOperacion(varOpGasto);
                            Logica.FuncionesTesoreria.BorrarMovDevol(idMovimiento);
                            MessageBox.Show("Borrado");

                        }
                        break;
                    default:
                        movimientosNoSePueden.Add(idMovimiento);
                        break;
                }
            }


            if (movimientosParaBorrar.Count > 0)
            {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar estos movimientos ? ", "Borrar Movimientos", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)  {
                    label_borrado.Visible = true;
                    progressBar_op.Visible = true;
                    progressBar_op.Maximum = movimientosParaBorrar.Count;
                    int b = 0;
                    foreach (String id in movimientosParaBorrar)   {
                        Logica.FuncionesTesoreria.BorrarMoviento(id);
                        progressBar_op.Value = b;
                        b++;
                    }
                    MessageBox.Show("Borrado");
                    label_borrado.Visible = false;
                    progressBar_op.Visible = false;
                }
            }

            if (movimientosNoSePueden.Count > 0)
            {
                String cadena = "";
                foreach (String id in movimientosNoSePueden)
                    cadena = cadena + id + "\n";

                MessageBox.Show("Los siguientes Movimientos no se han podido Borrar \n" + cadena);
            }
            else
            {
                cargarDatagrid();
            }
        }
        private void buscarFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String fecha = (Convert.ToDateTime(dataGridView_tesoreria.SelectedRows[0].Cells[1].Value)).ToString("yyyy-MM-dd");

            String sql = "SELECT com_movimientos.IdMov, com_movimientos.Fecha, com_movimientos.Detalle, com_movimientos.IdEjercicio, com_movimientos.IdCuenta, com_movimientos.IdDetTipoMov, com_movimientos.IdEntidad, ctos_entidades.Entidad, com_movimientos.MovDevol, com_movimientos.MovCA, com_movimientos.ImpMovEnt, com_movimientos.ImpMovSal, com_movimientos.ImpMovNeto,com_movimientos.MovSaldo,  com_movimientos.IdRemesa,com_movimientos.NumSecuencia FROM com_movimientos INNER JOIN ctos_entidades ON com_movimientos.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_movimientos.IdEjercicio) = " + comboBox_ejercicio.SelectedValue + " ) AND ((com_movimientos.IdCuenta) = " + id_cuenta + ") AND (Fecha = '" + fecha + "') ) ORDER BY com_movimientos.NumSecuencia DESC;";

            DataTable fecha_data = Persistencia.SentenciasSQL.select(sql);

            dataGridView_tesoreria.DataSource = fecha_data;
            ajustarDatagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable busqueda = nueva;
            busqueda.DefaultView.RowFilter = "Entidad like '%%' ";
            this.dataGridView_tesoreria.DataSource = busqueda;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TesoreriaForms.FormActualizarFechaCierre nueva = new TesoreriaForms.FormActualizarFechaCierre(this,id_cuenta.ToString());
            nueva.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormAccesoTesoreria nueva = new FormAccesoTesoreria(nombre_comunidad, id_comunidad);
            nueva.Show();
        }

        private void borrar0MovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrarMovimiento();
            cargarDatagrid();
        }
    }
}
