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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.RemesasForms
{
    public partial class FormDetalleRemesa : Form
    {
        String id_remesa_cargado;
        String idEstadoCargado;
        String idComunidadCargado;
        FormRemesas form_anterior;

        DataTable detallesRemesas;

        public FormDetalleRemesa(FormRemesas form_anterior, String id_remesa_cargado, String idEstadoCargado, String idComunidadCargado)
        {
            InitializeComponent();
            this.id_remesa_cargado = id_remesa_cargado;
            this.idEstadoCargado = idEstadoCargado;
            this.idComunidadCargado = idComunidadCargado;
            this.form_anterior = form_anterior;
        }
        public FormDetalleRemesa(String id_remesa_cargado)
        {
            InitializeComponent();
            this.id_remesa_cargado = id_remesa_cargado;
        }

        private void FormDetalleRemesa_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String sqlDetalles = "SELECT com_detremesa.IdDetRemesa, CONCAT(com_recibos.Idcomunidad,'/',IdComunero) AS RefComuneroBanco, com_detremesa.IdRecibo, ctos_entidades.Entidad, com_recibos.Referencia, com_remesas.FEnvio, com_comuneros.IdComunero, com_recibos.IdEntidad, com_detremesa.IdCuenta, ctos_detbancos.CC, com_detremesa.Cuenta, com_detremesa.Importe, com_recibos.IdComunidad, com_detremesa.IdEstado FROM((((com_detremesa INNER JOIN com_recibos ON com_detremesa.IdRecibo = com_recibos.IdRecibo) INNER JOIN ctos_entidades ON com_recibos.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_detbancos ON com_detremesa.IdCuenta = ctos_detbancos.IdCuenta) LEFT JOIN com_comuneros ON (com_recibos.IdEntidad = com_comuneros.IdEntidad) AND(com_recibos.IdComunidad = com_comuneros.IdComunidad)) INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa WHERE(((com_detremesa.IdRemesa) = " + id_remesa_cargado + "));";

            detallesRemesas = Persistencia.SentenciasSQL.select(sqlDetalles);
            dataGridView_detalles_remesa.DataSource = detallesRemesas;

            ajustarDataGrid();
            calcularTotal();
        }
        private void ajustarDataGrid() {
            dataGridView_detalles_remesa.Columns[0].Width = 55;
            dataGridView_detalles_remesa.Columns[3].Width = 200;
            dataGridView_detalles_remesa.Columns[4].Width = 200;

            dataGridView_detalles_remesa.Columns["IdEntidad"].Visible = false;
            dataGridView_detalles_remesa.Columns["IdComunero"].Visible = false;
            dataGridView_detalles_remesa.Columns["IdCuenta"].Visible = false;
            dataGridView_detalles_remesa.Columns["IdComunidad"].Visible = false;
            dataGridView_detalles_remesa.Columns[7].Width = 200;
            dataGridView_detalles_remesa.Columns[9].Width = 200;

            dataGridView_detalles_remesa.Columns[10].Width = 200;
            dataGridView_detalles_remesa.Columns["Cuenta"].Visible = false;


            dataGridView_detalles_remesa.Columns[13].Width = 60;
            dataGridView_detalles_remesa.Columns[11].DefaultCellStyle.Format = "c";
            dataGridView_detalles_remesa.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView_detalles_remesa.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        private void calcularTotal()
        {
            double total = 0.00;

            for (int a = 0; a < dataGridView_detalles_remesa.Rows.Count; a++)
            {
                total = total + Convert.ToDouble(dataGridView_detalles_remesa.Rows[a].Cells[11].Value);
                if (dataGridView_detalles_remesa.Rows[a].Cells[10].Value.ToString() != "") {
                    dataGridView_detalles_remesa.Columns["Cuenta"].Visible = true;
                    dataGridView_detalles_remesa.Columns["CC"].Visible = false;
                }
            }

            textBox_total.Text = Math.Round(total, 2) + " €";
        }

        private void button_anyadir_recibos_Click(object sender, EventArgs e)
        {
            if (idEstadoCargado == "1") {
                FormAnyadirRecibos nueva = new FormAnyadirRecibos(this, idComunidadCargado, id_remesa_cargado);
                nueva.Show();
                this.WindowState = FormWindowState.Minimized;
            }else {
                MessageBox.Show("Esa Remesa esta cerrada");
            }
        }

        private void buttonQuitarRecibos_Click(object sender, EventArgs e)
        {
            if (idEstadoCargado == "1")
            {
                if (dataGridView_detalles_remesa.SelectedRows.Count > 0)
                {
                    DialogResult resultado_message;
                    resultado_message = MessageBox.Show("¿Desea borrar estos " + dataGridView_detalles_remesa.SelectedRows.Count + " Recibo de la Remesa ?", "Borrar Recibos Remesa", MessageBoxButtons.OKCancel);
                    if (resultado_message == System.Windows.Forms.DialogResult.OK)  {
                        for (int a = 0; a < dataGridView_detalles_remesa.SelectedRows.Count; a++)
                        {
                            String sqlBorrar = "DELETE From com_detremesa WHERE ((com_detremesa.IdDetRemesa)=" + dataGridView_detalles_remesa.SelectedRows[a].Cells[0].Value.ToString() + ");";
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                        }
                    }
                    cargarDatagrid();
                }
            }
            else
            {
                MessageBox.Show("Esa Remesa esta cerrada");
            }
        }

        private void buttonLanzar_Click(object sender, EventArgs e)
        {
            if (idEstadoCargado == "1")
            {
                String strActDet = "UPDATE com_detremesa SET com_detremesa.IdEstado = 2 WHERE (((com_detremesa.IdRemesa)=" + id_remesa_cargado + "));";
                Persistencia.SentenciasSQL.InsertarGenerico(strActDet);

                String strActRbos = "UPDATE com_detremesa INNER JOIN com_recibos ON com_detremesa.IdRecibo = com_recibos.IdRecibo SET com_recibos.IdEstado = 2 WHERE(((com_detremesa.IdRemesa)=" + id_remesa_cargado + "));";
                Persistencia.SentenciasSQL.InsertarGenerico(strActRbos);

                String strActRem = "UPDATE com_remesas SET com_remesas.IdEstado = 2 WHERE (((com_remesas.IdRemesa)=" + id_remesa_cargado + "));";
                Persistencia.SentenciasSQL.InsertarGenerico(strActRem);

                MessageBox.Show("Remesa Lista");
                form_anterior.cargarDatagrid("5");
                this.Close();
            }
            else   {
                MessageBox.Show("Esa Remesa esta cerrada");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewExcel(dataGridView_detalles_remesa);
        }
        private void ExportarDataGridViewExcel(DataGridView grd)
        {
            CultureInfo culture = new CultureInfo("es-ES");
            grd.Columns[5].DefaultCellStyle.Format = "d";
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            String NombreRemesa = (Persistencia.SentenciasSQL.select("SELECT Remesa FROM com_remesas WHERE IdRemesa = " + id_remesa_cargado)).Rows[0][0].ToString();
            String RutaComunidad = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Ruta FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.IdComunidad) = " + idComunidadCargado + "));")).Rows[0][0].ToString().Trim('#');

            fichero.FileName = "REMESA " + NombreRemesa.ToUpper() + ".xls";
            fichero.InitialDirectory = RutaComunidad;

            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0; i < grd.Rows.Count ; i++)
                {
                    for (int j = 0; j < grd.Columns.Count; j++)
                    {
                        if (j != 0)
                        {
                            if (j < 12)
                            {
                                if (j == 11)
                                    hoja_trabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString().Replace(',', '.');
                                else
                                    if (j == 5)
                                    hoja_trabajo.Cells[i + 2, j + 1] = Convert.ToDateTime(grd.Rows[i].Cells[j].Value).ToString("yyyy-MM-dd");
                                else
                                    hoja_trabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                }

                Microsoft.Office.Interop.Excel.Range rcd1 = ((Microsoft.Office.Interop.Excel.Range)(hoja_trabajo.Range["A1", "A30"]));
                rcd1.EntireColumn.Delete();

                Microsoft.Office.Interop.Excel.Range format = ((Microsoft.Office.Interop.Excel.Range)(hoja_trabajo.Range["A1", "A30"]));
                format.ClearFormats();

                Microsoft.Office.Interop.Excel.Range rcd3 = ((Microsoft.Office.Interop.Excel.Range)(hoja_trabajo.Range["F1", "F30"]));
                rcd3.EntireColumn.Delete();

                Microsoft.Office.Interop.Excel.Range rcd2 = ((Microsoft.Office.Interop.Excel.Range)(hoja_trabajo.Range["F1", "F30"]));
                rcd2.EntireColumn.Delete();

                Microsoft.Office.Interop.Excel.Range rcd4 = ((Microsoft.Office.Interop.Excel.Range)(hoja_trabajo.Range["F1", "F30"]));
                rcd4.EntireColumn.Delete();

                Microsoft.Office.Interop.Excel.Range rcd5 = ((Microsoft.Office.Interop.Excel.Range)(hoja_trabajo.Range["F1", "F30"]));
                rcd5.EntireColumn.Delete();

                Microsoft.Office.Interop.Excel.Range rcd8 = (hoja_trabajo.Range["A1", "A30"]);
                rcd8.EntireColumn.NumberFormat = "@";

                Microsoft.Office.Interop.Excel.Range rcd9 = (hoja_trabajo.Range["E1", "E30"]);
                rcd8.EntireColumn.NumberFormat = "@";


                try
                {
                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                }
                catch (Exception e) {
                    MessageBox.Show("Comprueba que el fichero esta cerrado " + e.Message);
                }
            }
            MessageBox.Show("Comprueba la fecha en el EXCEL");
        }

        private void textBox_buscar_TextChanged(object sender, EventArgs e)
        {
            if (textBox_buscar.TextLength < 2)
            {
                DataTable busqueda = detallesRemesas;
                busqueda.DefaultView.RowFilter = "Entidad like '%%'";
                this.dataGridView_detalles_remesa.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = detallesRemesas;
                busqueda.DefaultView.RowFilter = "Entidad like '%" + textBox_buscar.Text + "%' OR Referencia like '%" + textBox_buscar.Text + "%' ";
                this.dataGridView_detalles_remesa.DataSource = busqueda;
            }
        }

        private void dataGridView_detalles_remesa_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_detalles_remesa.HitTest(e.X, e.Y);
                dataGridView_detalles_remesa.ClearSelection();
                dataGridView_detalles_remesa.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void cambiarNºCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCambiarCuenta nueva = new FormCambiarCuenta(this,dataGridView_detalles_remesa.SelectedRows[0].Cells[7].Value.ToString(), dataGridView_detalles_remesa.SelectedRows[0].Cells[3].Value.ToString(), dataGridView_detalles_remesa.SelectedRows[0].Cells[0].Value.ToString());
            nueva.Show();
        }
    }
}
