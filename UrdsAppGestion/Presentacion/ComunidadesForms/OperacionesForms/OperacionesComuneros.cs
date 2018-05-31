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
                    DivisionesForms.FormReasignarPagador nueva = new DivisionesForms.FormReasignarPagador(this, id_comunidad_cargado, dataGridView_operaciones.SelectedCells[0].Value.ToString(), dataGridView_operaciones.SelectedCells[3].Value.ToString(), dataGridView_operaciones.SelectedCells[2].Value.ToString(),dataGridView_operaciones.SelectedCells[10].Value.ToString(),"OperacionComuneros");
                    nueva.Show();
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
            resultado_message = MessageBox.Show("¿ Desea borrar la Operación ?", "Borrar Operación", MessageBoxButtons.OKCancel);
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
            OperacionesForms.FormLiquidarAOtroFondo nueva = new OperacionesForms.FormLiquidarAOtroFondo(dataGridView_operaciones.SelectedRows[0].Cells[0].Value.ToString(), id_comunidad_cargado, dataGridView_operaciones.SelectedRows[0].Cells[2].Value.ToString(), dataGridView_operaciones.SelectedRows[0].Cells[4].Value.ToString(), dataGridView_operaciones.SelectedRows[0].Cells[8].Value.ToString());
            nueva.Show();
        }
    }
}
