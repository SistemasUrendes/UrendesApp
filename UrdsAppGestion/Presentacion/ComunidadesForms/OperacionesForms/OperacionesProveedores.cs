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
    public partial class Operaciones_proveedores : Form
    {
        String id_comunidad_cargado = "0";
        DataTable operaciones;
        String nombre_columna;

        public Operaciones_proveedores(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void Operaciones_Load(object sender, EventArgs e)
        {
            cargardatagrid();
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

            comboBox_cuenta_fin.SelectedValue = "69999";
            comboBox_cuenta_inicio.SelectedValue = "60000";

            String fechaInicio = (Convert.ToDateTime("1-1-" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
            String fechaFin = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");

            String sqlSelectOp = "SELECT com_operaciones.IdOp, ctos_entidades.IDEntidad, ctos_entidades.Entidad, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA`, com_operaciones.Fecha, com_operaciones.Documento, com_operaciones.Descripcion, com_operaciones.ImpOp, com_operaciones.ImpOpPte FROM(com_operaciones INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE (((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ") AND (com_operaciones.Fecha >='" + fechaInicio + "' AND com_operaciones.Fecha <= '" + fechaFin + "') AND (com_operaciones.IdSubCuenta > 59999) AND(com_operaciones.IdSubCuenta < 70000) OR (com_operaciones.IdSubCuenta = 43812) AND ((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ")) ORDER BY com_operaciones.IdOp DESC;";


            operaciones = Persistencia.SentenciasSQL.select(sqlSelectOp);
            ajustarDatagrid();


        }

        private void ajustarDatagrid()
        {
            dataGridView_operaciones.DataSource = operaciones;
            dataGridView_operaciones.Columns["IDEntidad"].Visible = false;
            dataGridView_operaciones.Columns["IdOp"].Width = 50;
            dataGridView_operaciones.Columns["Entidad"].Width = 250;
            dataGridView_operaciones.Columns["IdSubCuenta"].Width = 50;
            dataGridView_operaciones.Columns["Fecha"].Width = 70;
            dataGridView_operaciones.Columns["Documento"].Width = 70;
            dataGridView_operaciones.Columns["TIT SUBCTA"].Width = 170;
            dataGridView_operaciones.Columns["Descripcion"].Width = 250;
            dataGridView_operaciones.Columns["ImpOp"].Width = 70;
            dataGridView_operaciones.Columns["ImpOp"].DefaultCellStyle.Format = "c";
            dataGridView_operaciones.Columns["ImpOpPte"].Width = 70;
            dataGridView_operaciones.Columns["ImpOpPte"].DefaultCellStyle.Format = "c";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargarFiltro();
        }
        public void cargarFiltro() {
            textBox_buscar.Text = "";
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

            String sqlSelect = "SELECT com_operaciones.IdOp, ctos_entidades.IDEntidad, ctos_entidades.Entidad, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA`, com_operaciones.Fecha, com_operaciones.Documento, com_operaciones.Descripcion, com_operaciones.ImpOp, com_operaciones.ImpOpPte FROM(com_operaciones INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE (((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ") AND (com_operaciones.Fecha >='" + fechaInicio + "' AND com_operaciones.Fecha <= '" + fechaFin + "') AND (com_operaciones.IdSubCuenta > " + cuenta_inicio + ") AND(com_operaciones.IdSubCuenta < " + cuenta_fin + ")) ORDER BY com_operaciones.IdOp DESC;";

            operaciones = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_operaciones.DataSource = operaciones;
            dataGridView_operaciones.Columns["IDEntidad"].Visible = false;
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
                String[] palabras = textBox_buscar.Text.Split(' ');
                String filtro = "";
                for (int a = 0; a < palabras.Length; a++)
                {
                    if (palabras[a] != "")
                        filtro += "Entidad like '%" + palabras[a] + "%' OR Descripcion like '%" + palabras[a] + "%' AND ";
                    if (a == palabras.Length - 1)
                        filtro += "Entidad like '%" + palabras[a] + "%' OR Descripcion like '%" + palabras[a] + "%'";

                }
                busqueda.DefaultView.RowFilter = filtro;
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
            for (int a = 0; a< dataGridView_operaciones.Rows.Count;a++) {
                try
                {
                    if (comprobarValidaFavorita(dataGridView_operaciones.SelectedRows[a].Cells[0].Value.ToString()))
                    {
                        String fecha = (Convert.ToDateTime(dataGridView_operaciones.SelectedRows[a].Cells[5].Value.ToString())).ToString("yyyy-MM-dd");
                        String sqlFavorita = "INSERT INTO com_opfavoritas (IdOp, NomFavo, FechaFavo, DocFavo, ImpFavo, IdComunidad) VALUES (" + dataGridView_operaciones.SelectedRows[a].Cells[0].Value.ToString() + ",'" + dataGridView_operaciones.SelectedRows[a].Cells[7].Value.ToString() + "','" + fecha + "','" + dataGridView_operaciones.SelectedRows[a].Cells[6].Value.ToString() + "'," + dataGridView_operaciones.SelectedRows[a].Cells[8].Value.ToString().Replace(',', '.') + "," + id_comunidad_cargado + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlFavorita);
                    }
                }
                catch {
                    return;
                }
            }
            MessageBox.Show("Guardada como favorita");
        }

        private void dataGridView_operaciones_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                toolStripTextBoxFiltro.Text = "";
                var hti = dataGridView_operaciones.HitTest(e.X, e.Y);
                dataGridView_operaciones.ClearSelection();
                dataGridView_operaciones.Rows[hti.RowIndex].Selected = true;
                dataGridView_operaciones.CurrentCell = this.dataGridView_operaciones[hti.ColumnIndex, hti.RowIndex];
                nombre_columna = dataGridView_operaciones.CurrentCell.OwningColumn.Name;
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

        private void eliminarOperaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String idOpBorrar = dataGridView_operaciones.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿ Desea borrar la Operación ?", "Borrar Operación", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)   {
                String resultado = Logica.FuncionesOperaciones.CombrobacionesBorrarOp(idOpBorrar);
                if (resultado == "true") {
                    MessageBox.Show("Operación Borrada");
                    cargardatagrid();
                    cargarFiltro();
                }
                else {
                    MessageBox.Show(resultado);
                }
            }
        }

        private void abonarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String IdOp = dataGridView_operaciones.SelectedRows[0].Cells[0].Value.ToString();
            AbonarOpGasto(IdOp);
        }
        private void AbonarOpGasto(String Op) {
            
            ////COMPROBAR SI TIENE VENCIMIENTOS PAGADOS
            //String vencimientos =  "SELECT com_opdetalles.IdOp, com_opdetalles.IdOpDet, com_opdetalles.Importe, com_opdetalles.ImpOpDetMov, com_opdetalles.ImpOpDetPte, com_opdetalles.IdEntidad, com_opdetalles.Fecha FROM com_opdetalles WHERE(((com_opdetalles.IdOp) = 121212));";

        }

        private void toolStripTextBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            String filtro;
            if (toolStripTextBoxFiltro.TextLength == 1)
            {
                DataTable busqueda = operaciones;
                busqueda.DefaultView.RowFilter = string.Empty;
                this.dataGridView_operaciones.DataSource = busqueda;


                if (nombre_columna == "Descripcion" || nombre_columna == "Entidad")
                {
                    filtro = nombre_columna + " like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%'";
                    busqueda.DefaultView.RowFilter = filtro;
                }
                else
                {

                }
                this.dataGridView_operaciones.DataSource = busqueda;
                ajustarDatagrid();
            }
            else if (toolStripTextBoxFiltro.TextLength > 1)
            {
                DataTable busqueda = operaciones;

                if (nombre_columna == "Descripcion" || nombre_columna == "Entidad")
                {
                    filtro = nombre_columna + " like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%'";
                    busqueda.DefaultView.RowFilter = filtro;
                }
                else
                {
                }

                this.dataGridView_operaciones.DataSource = busqueda;
                ajustarDatagrid();
            }
        }

        private void toolStripTextBoxFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Tab || e.KeyChar == (Char)Keys.Enter)
            {
                contextMenuStrip1.Close();
            }
        }
    }
}
