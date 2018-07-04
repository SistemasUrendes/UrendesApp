using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    public partial class Operaciones_comuneros : Form
    {
        String id_comunidad_cargado = "0";
        DataTable operaciones;

        public Operaciones_comuneros(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void Operaciones_Load(object sender, EventArgs e)
        {
            cargardatagrid();
            aplicarFiltro();
        }
        public void cargardatagrid() {
            maskedTextBox_inicio.Text = "01-01-" + DateTime.Now.Year;

            maskedTextBox_fin.Text = DateTime.Now.ToShortDateString();

            String sqlSelect = "SELECT com_subcuentas.IdSubcuenta, com_subcuentas.`TIT SUBCTA` FROM com_subcuentas ORDER BY com_subcuentas.IdSubcuenta;";
            comboBox_cuenta_inicio.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            comboBox_cuenta_inicio.ValueMember = "IdSubcuenta";
            comboBox_cuenta_inicio.DisplayMember = "IdSubcuenta";

            comboBox_cuenta_fin.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            comboBox_cuenta_fin.ValueMember = "IdSubcuenta";
            comboBox_cuenta_fin.DisplayMember = "IdSubcuenta";

            comboBox_cuenta_fin.SelectedValue = "70001";
            comboBox_cuenta_inicio.SelectedValue = "70000";

            String fechaInicio = (Convert.ToDateTime("1-1-" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
            String fechaFin = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");

            String sqlSelectOp = "SELECT com_opdetalles.IdOp, com_opdetalles.IdOpDet, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_subcuentas.IdSubcuenta, com_subcuentas.`TIT SUBCTA`, com_opdetalles.Fecha, com_operaciones.Documento, com_operaciones.Descripcion, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte FROM((com_opdetalles INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE(((com_opdetalles.Fecha) >= '" + fechaInicio + "' And (com_opdetalles.Fecha) <= '" + fechaFin + "') AND ((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ")) ORDER BY com_opdetalles.Fecha DESC; ";

            operaciones = Persistencia.SentenciasSQL.select(sqlSelectOp);
            dataGridView_operaciones.DataSource = operaciones;
            dataGridView_operaciones.Columns["IdEntidad"].Visible = false;
            dataGridView_operaciones.Columns["IdOp"].Width = 50;
            dataGridView_operaciones.Columns["IdOpDet"].Width = 50;
            dataGridView_operaciones.Columns["Entidad"].Width = 250;
            dataGridView_operaciones.Columns["IdSubCuenta"].Width = 50;
            dataGridView_operaciones.Columns["Fecha"].Width = 70;
            dataGridView_operaciones.Columns["Documento"].Width = 70;
            dataGridView_operaciones.Columns["TIT SUBCTA"].Width = 170;
            dataGridView_operaciones.Columns["Descripcion"].Width = 250;
            dataGridView_operaciones.Columns["Importe"].Width = 80;
            dataGridView_operaciones.Columns["Importe"].DefaultCellStyle.Format = "c";
            dataGridView_operaciones.Columns["ImpOpDetPte"].Width = 70;
            dataGridView_operaciones.Columns["ImpOpDetPte"].DefaultCellStyle.Format = "c";
            dataGridView_operaciones.Columns["Importe"].HeaderText = "A ingresar";
            dataGridView_operaciones.Columns["ImpOpDetPte"].HeaderText = "Pendiente";
            dataGridView_operaciones.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_operaciones.Columns["ImpOpDetPte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataTable busqueda = operaciones;
            busqueda.DefaultView.RowFilter = "ImpOpDetPte > 0";
            this.dataGridView_operaciones.DataSource = busqueda;

        }
        public void aplicarFiltro() {
            String fechaInicio;
            String fechaFin;
            try
            {
                fechaInicio = (Convert.ToDateTime(maskedTextBox_inicio.Text)).ToString("yyyy-MM-dd");
                fechaFin = (Convert.ToDateTime(maskedTextBox_fin.Text)).ToString("yyyy-MM-dd");
            }
            catch
            {
                MessageBox.Show("Comprueba la fecha");
                return;
            }

            int cuenta_inicio = (Convert.ToInt32(comboBox_cuenta_inicio.SelectedValue.ToString())) - 1;
            int cuenta_fin = (Convert.ToInt32(comboBox_cuenta_fin.SelectedValue.ToString())) + 1;

            String sqlSelect = "SELECT com_opdetalles.IdOp, com_opdetalles.IdOpDet, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_subcuentas.IdSubcuenta, com_subcuentas.`TIT SUBCTA`, com_opdetalles.Fecha, com_operaciones.Documento, com_operaciones.Descripcion, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte FROM((com_opdetalles INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE com_subcuentas.IdSubcuenta >= " + cuenta_inicio + " AND com_subcuentas.IdSubcuenta <= " + cuenta_fin + " AND com_opdetalles.Fecha >= '" + fechaInicio + "' AND com_opdetalles.Fecha <='" + fechaFin + "' AND com_operaciones.IdComunidad =" + id_comunidad_cargado + " ORDER BY com_opdetalles.Fecha DESC;";

            operaciones = Persistencia.SentenciasSQL.select(sqlSelect);

            DataTable busqueda = operaciones;
            busqueda.DefaultView.RowFilter = "Entidad like '%" + textBox_buscar.Text + "%' OR Descripcion like '%" + textBox_buscar.Text + "%'";
            this.dataGridView_operaciones.DataSource = busqueda;

            dataGridView_operaciones.Columns["IDEntidad"].Visible = false;
        }
        public void button2_Click(object sender, EventArgs e)
        {
            aplicarFiltro();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargardatagrid();
        }

        private void textBox_entidad_TextChanged(object sender, EventArgs e)
        {
            if (textBox_buscar.TextLength < 2)
            {
                DataTable busqueda = operaciones;
                busqueda.DefaultView.RowFilter = "Entidad like '%%'";
                this.dataGridView_operaciones.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = operaciones;
                busqueda.DefaultView.RowFilter = "Entidad like '%" + textBox_buscar.Text + "%' OR Descripcion like '%" + textBox_buscar.Text + "%'";
                this.dataGridView_operaciones.DataSource = busqueda;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Presentacion.ComunidadesForms.OperacionesForms.FormOperacionesCabeceraEdicion nueva = new OperacionesForms.FormOperacionesCabeceraEdicion(id_comunidad_cargado);
            nueva.Show();
        }

        private void dataGridView_operaciones_DoubleClick(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(id_comunidad_cargado,dataGridView_operaciones.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OperacionesForms.FormOperacionesEleccionFavorita nueva = new OperacionesForms.FormOperacionesEleccionFavorita(id_comunidad_cargado);
            nueva.Show();
        }

        private void marcarComoFavoritaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (comprobarValidaFavorita(dataGridView_operaciones.SelectedCells[0].Value.ToString()))
                {
                    String fecha = (Convert.ToDateTime(dataGridView_operaciones.SelectedCells[5].Value.ToString())).ToString("yyyy-MM-dd");
                    String sqlFavorita = "INSERT INTO com_opfavoritas (IdOp, NomFavo, FechaFavo, DocFavo, ImpFavo, IdComunidad) VALUES (" + dataGridView_operaciones.SelectedCells[0].Value.ToString() + ",'" + dataGridView_operaciones.SelectedCells[7].Value.ToString() + "','" + fecha + "','" + dataGridView_operaciones.SelectedCells[6].Value.ToString() + "'," + dataGridView_operaciones.SelectedCells[8].Value.ToString().Replace(',', '.') + "," + id_comunidad_cargado + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlFavorita);
                    MessageBox.Show("Guardada como favorita");
                }
            }
            catch {
                return;
            }
        }

        private void dataGridView_operaciones_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_operaciones.HitTest(e.X, e.Y);
                dataGridView_operaciones.ClearSelection();
                dataGridView_operaciones.Rows[hti.RowIndex].Selected = true;
               // if (!dataGridView_operaciones.SelectedRows[0].Cells[9].Value.ToString().Contains('-') || ) {
                   // compensarToolStripMenuItem.Enabled = false;
                //}else {
                    compensarToolStripMenuItem.Enabled = true;
               // }   

                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int numeroOperacion;
            if (Int32.TryParse(textBox_ver_operacion.Text,out numeroOperacion)) {
                OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(id_comunidad_cargado, numeroOperacion.ToString());
                try  {
                    nueva.Show();
                }catch {
                    return;
                }
            }else {
                MessageBox.Show("No existe esa operación");
            }
        }
        private Boolean comprobarValidaFavorita(String id_op_marcada_favorita) {
            String sqlLiquidacion = "SELECT IdDetOpLiq FROM com_opdetliquidacion WHERE IdOp = " + id_op_marcada_favorita;
            DataTable Liquifav = Persistencia.SentenciasSQL.select(sqlLiquidacion);
            if (Liquifav.Rows.Count == 1) {
                return true;
            }else {
                MessageBox.Show("Existe más de una fila en Liquidacion, no se puede guardar como favorita");
                return false;
            }           
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void verOperacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesForms.FormOperacionesComuneros nueva = new OperacionesForms.FormOperacionesComuneros(id_comunidad_cargado, dataGridView_operaciones.SelectedCells[1].Value.ToString());
            nueva.Show();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            if (combo.SelectedText == "Pendiente")
            {
                DataTable busqueda = operaciones;
                busqueda.DefaultView.RowFilter = "ImpOpDetPte > 0";
                this.dataGridView_operaciones.DataSource = busqueda;
            }
            else if (combo.SelectedText == "Cerrado")
            {
                DataTable busqueda = operaciones;
                busqueda.DefaultView.RowFilter = "ImpOpDetPte = 0";
                this.dataGridView_operaciones.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = operaciones;
                busqueda.DefaultView.RowFilter = "ImpOpDetPte = 0 OR ImpOpDetPte > 0 OR ImpOpDetPte < 0 ";
                this.dataGridView_operaciones.DataSource = busqueda;
            }
        }

        private void compensarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesForms.FormCompensarAnticipos nuevo = new OperacionesForms.FormCompensarAnticipos(this,dataGridView_operaciones.SelectedCells[0].Value.ToString(),dataGridView_operaciones.SelectedCells[1].Value.ToString(), dataGridView_operaciones.SelectedCells[3].Value.ToString(), dataGridView_operaciones.SelectedCells[8].Value.ToString(), dataGridView_operaciones.SelectedCells[4].Value.ToString(), dataGridView_operaciones.SelectedCells[5].Value.ToString(), dataGridView_operaciones.SelectedCells[9].Value.ToString(), dataGridView_operaciones.SelectedCells[10].Value.ToString(), dataGridView_operaciones.SelectedCells[6].Value.ToString(),id_comunidad_cargado, dataGridView_operaciones.SelectedCells[2].Value.ToString());
            nuevo.Show();
        }

        private void verMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesForms.FormDetallesOperacion nueva = new OperacionesForms.FormDetallesOperacion(dataGridView_operaciones.SelectedCells[1].Value.ToString());
            nueva.Show();
        }

        private void reasignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_operaciones.SelectedRows.Count == 1)
            {
                if (Convert.ToDouble(dataGridView_operaciones.SelectedCells[10].Value.ToString()) > 0)
                {
                    DivisionesForms.FormReasignarPagador nueva = new DivisionesForms.FormReasignarPagador(this, id_comunidad_cargado, dataGridView_operaciones.SelectedCells[0].Value.ToString(), dataGridView_operaciones.SelectedCells[3].Value.ToString(), dataGridView_operaciones.SelectedCells[2].Value.ToString(), dataGridView_operaciones.SelectedCells[10].Value.ToString(), "OperacionComuneros");
                    nueva.Show();
                }else {
                    MessageBox.Show("Esa operación ya esta pagada");
                }
            }
            else
            {
                MessageBox.Show("Selecciona solo una operación ");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Recibos.FormNuevoRecibo nueva = new Recibos.FormNuevoRecibo(id_comunidad_cargado);
            nueva.Show();
        }

        private void eliminarOperaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String idOpBorrar = dataGridView_operaciones.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿ Desea borrar la operación ?", "Borrar Operación", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String resultado = Logica.FuncionesOperaciones.CombrobacionesBorrarOp(idOpBorrar);
                if (resultado == "true")
                {
                    MessageBox.Show("Operación Borrada");
                    cargardatagrid();
                    aplicarFiltro();
                }
                else
                {
                    MessageBox.Show(resultado);
                }
            }
        }

        private void button_fondo_Click(object sender, EventArgs e)
        {
            OperacionesForms.FormIngresoFondo nueva = new OperacionesForms.FormIngresoFondo(this,id_comunidad_cargado);
            nueva.Show();
        }

        private void abonarVencimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesForms.FormAbonarVencimiento nueva = new OperacionesForms.FormAbonarVencimiento(this, dataGridView_operaciones.SelectedRows[0].Cells[0].Value.ToString(),id_comunidad_cargado);
            nueva.Show();
        }

        private void liquidarAOtroFondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(dataGridView_operaciones.SelectedRows[0].Cells[10].Value) > 0)
            {
                String sqlSelect = "SELECT IdTipoReparto FROM com_operaciones WHERE IdOp = " + dataGridView_operaciones.SelectedRows[0].Cells[0].Value.ToString();

                OperacionesForms.FormLiquidarAOtroFondo nueva = new OperacionesForms.FormLiquidarAOtroFondo(this, dataGridView_operaciones.SelectedRows[0].Cells[0].Value.ToString(), id_comunidad_cargado, dataGridView_operaciones.SelectedRows[0].Cells[2].Value.ToString(), dataGridView_operaciones.SelectedRows[0].Cells[4].Value.ToString(), dataGridView_operaciones.SelectedRows[0].Cells[8].Value.ToString(), Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString());
                nueva.Show();
            }else {
                MessageBox.Show("La operación ya esta pagada.");
            }
        }

        private void comboBox_ajustes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_ajustes.SelectedIndex == 0)
            {
                //PONGO A 0 EL IMPORTE DEL VENCIMIENTO CREANDO MOVIMIENTOS.
                for (int a = 0; a < dataGridView_operaciones.Rows.Count; a++)
                {

                        String sqlMovs = "SELECT com_detmovs.IdOpDet, Sum(com_detmovs.Importe*If(idtipomov=1,1,0)) AS ImpEnt, Sum(com_detmovs.Importe*IF(idtipomov=2,1,0)) AS ImpSal FROM(com_detmovs INNER JOIN com_movimientos ON com_detmovs.IdMov = com_movimientos.IdMov) INNER JOIN com_dettiposmov ON com_movimientos.IdDetTipoMov = com_dettiposmov.IdDetTipoMov GROUP BY com_detmovs.IdOpDet HAVING com_detmovs.IdOpDet = " + dataGridView_operaciones.Rows[a].Cells[1].Value.ToString();

                        DataTable movimientos = Persistencia.SentenciasSQL.select(sqlMovs);

                        double entrada = 0.00;
                        double salida = 0.00;

                        for (int b = 0; b < movimientos.Rows.Count; b++) {
                            entrada += Convert.ToDouble(movimientos.Rows[b][1]);
                            salida += Convert.ToDouble(movimientos.Rows[b][2]);
                        }

                        String tipoOperacion = "";
                        String sqltipo = "SELECT ES FROM com_subcuentas WHERE IdSubCuenta = " + dataGridView_operaciones.Rows[a].Cells[4].Value.ToString();
                        DataTable tipoC = Persistencia.SentenciasSQL.select(sqltipo);
                        if (tipoC.Rows.Count > 0)
                        {
                            tipoOperacion = tipoC.Rows[0][0].ToString();
                        }

                        if (tipoOperacion == "1") {
                            Double importeOpDet = Convert.ToDouble(dataGridView_operaciones.Rows[a].Cells[9].Value);
                            Double sumaMov = entrada - salida;
                            Double ImporteAingresar = importeOpDet + salida;

                            //insertarMovimiento(ImporteAingresar.ToString(), dataGridView_operaciones.Rows[a].Cells[6].Value.ToString(), dataGridView_operaciones.Rows[a].Cells[2].Value.ToString(), dataGridView_operaciones.Rows[a].Cells[1].Value.ToString(),"1");

                        }
                        else if (tipoOperacion == "2") {
                            Double importeOpDet = Convert.ToDouble(dataGridView_operaciones.Rows[a].Cells[9].Value);
                            Double sumaMov = salida - entrada;
                            Double ImporteAingresar = importeOpDet + entrada ;

                            //insertarMovimiento(ImporteAingresar.ToString(), dataGridView_operaciones.Rows[a].Cells[6].Value.ToString(), dataGridView_operaciones.Rows[a].Cells[2].Value.ToString(), dataGridView_operaciones.Rows[a].Cells[1].Value.ToString(), "2");
                    }
                            
                }
            } else if (comboBox_ajustes.SelectedIndex == 1) {
                //ACTUALIZO LOS IMPORTES PENDIENTES.
                for (int a = 0; a < dataGridView_operaciones.Rows.Count; a++)
                {

                }
            } else if (comboBox_ajustes.SelectedIndex == 2) {
                if (dataGridView_operaciones.Rows.Count == 1) {

                }else {
                    MessageBox.Show("Debes seleccionar una sola operación");
                }
            }
        }
       
    }
}
