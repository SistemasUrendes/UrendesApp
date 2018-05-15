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
    public partial class FormOperacionesAddIVA : Form
    {
        String id_comunidad_cargado;
        String id_operacion_cargado;
        FromOperacionesVer form_anterior;
        String importeOperacion_cargado;
        String guardada = "no";
        Boolean vengoDePantallaVer = false;

        decimal importeActual = Convert.ToDecimal(0.00);

        public FormOperacionesAddIVA(FromOperacionesVer form_anterior,String id_comunidad_cargado, String id_operacion_cargado, String importeOperacion_cargado, Boolean vengoDePantallaVer)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_operacion_cargado = id_operacion_cargado;
            this.form_anterior = form_anterior;
            this.importeOperacion_cargado = importeOperacion_cargado;
            this.vengoDePantallaVer = vengoDePantallaVer;
        }

        public FormOperacionesAddIVA(String id_comunidad_cargado, String id_operacion_cargado, String importeOperacion_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_operacion_cargado = id_operacion_cargado;
            this.importeOperacion_cargado = importeOperacion_cargado;
        }

        private void FormOperacionesAddIVA_Load(object sender, EventArgs e)
        {

            DataGridViewComboBoxColumn colbox = new DataGridViewComboBoxColumn();
            colbox.DataSource = Persistencia.SentenciasSQL.select("SELECT IdIVA,`%IVA` FROM aux_iva WHERE Activo = -1");
            colbox.ValueMember = "IdIVA";
            colbox.DisplayMember = "%IVA";
            colbox.HeaderText = "IVA";
            colbox.Name = "IVA";
            colbox.AutoComplete = true;

            DataGridViewTextBoxColumn baseIva = new DataGridViewTextBoxColumn();
            baseIva.HeaderText = "Base";
            DataGridViewTextBoxColumn total = new DataGridViewTextBoxColumn();
            total.HeaderText = "Total";
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            total.HeaderText = "Total";

            dataGridView_add_iva.Columns.Add(baseIva);
            dataGridView_add_iva.Columns.Add(colbox);
            dataGridView_add_iva.Columns.Add(total);
            dataGridView_add_iva.Columns.Add(id);
            dataGridView_add_iva.Columns[0].DefaultCellStyle.Format = "N2";
            dataGridView_add_iva.Columns[0].Name = "Base";
            dataGridView_add_iva.Columns[1].Name = "IVA";
            dataGridView_add_iva.Columns[2].Name = "Total";
            dataGridView_add_iva.Columns[3].Name = "ID";

            dataGridView_add_iva.Columns[3].Visible = false;

            cargarIva();
            dataGridView_add_iva.EditMode = DataGridViewEditMode.EditOnEnter;
        }
        public void cargarIva() {
            if (id_operacion_cargado != "0") {
                String sqlSelectIVA = "SELECT IdDetOpIVA, Base, IdIVA, IVA FROM com_opdetiva WHERE IdOp = " + id_operacion_cargado;
                DataTable ivas = Persistencia.SentenciasSQL.select(sqlSelectIVA);

                for (int a = 0; a< ivas.Rows.Count;a++) {
                    DataGridViewRow row = (DataGridViewRow)dataGridView_add_iva.Rows[0].Clone();
                    row.Cells[0].Value = ivas.Rows[a][1].ToString();
                    row.Cells[1].Value = ivas.Rows[a][2];
                    row.Cells[2].Value = ivas.Rows[a][3].ToString();
                    row.Cells[3].Value = ivas.Rows[a][0].ToString();
                    dataGridView_add_iva.Rows.Add(row);

                    Convert.ToDecimal(string.Format("{0:F2}", ivas.Rows[a][1].ToString()));

                    importeActual = importeActual + Convert.ToDecimal(string.Format("{0:F2}", ivas.Rows[a][1].ToString())) + Convert.ToDecimal(string.Format("{0:F2}", ivas.Rows[a][3].ToString()));

                }
           
            }
            textBox_importe_actual.Text = importeActual.ToString();
            textBox_importe_op.Text = Convert.ToDouble(importeOperacion_cargado).ToString("N2");

        }

        public decimal calcularIVA (String baseIVA, String tipoIVA) {
            decimal baseIva = Convert.ToDecimal(string.Format("{0:F2}",baseIVA));
            decimal IVA = Convert.ToDecimal(string.Format("{0:F2}",tipoIVA));
            return ((baseIva * IVA) / 100);
        }
        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (comprobarImporte())  {
                for (int a = 0; a < dataGridView_add_iva.Rows.Count; a++)
                {
                    if (dataGridView_add_iva.Rows[a].Cells[3].Value != null && dataGridView_add_iva.Rows[a].Cells[0].Value != null && dataGridView_add_iva.Rows[a].Cells[0].Value.ToString() != "0")
                    {
                        actualizar_filasIVA(dataGridView_add_iva.Rows[a].Cells[3].Value.ToString(), dataGridView_add_iva.Rows[a].Cells[0].Value.ToString(), dataGridView_add_iva.Rows[a].Cells[1].Value.ToString(), dataGridView_add_iva.Rows[a].Cells[2].Value.ToString());
                    }
                    else if (dataGridView_add_iva.Rows[a].Cells[0].Value != null && dataGridView_add_iva.Rows[a].Cells[0].Value.ToString() != "0")
                    {
                        insertar_filasIVA(dataGridView_add_iva.Rows[a].Cells[0].Value.ToString(), dataGridView_add_iva.Rows[a].Cells[1].Value.ToString(), dataGridView_add_iva.Rows[a].Cells[2].Value.ToString());
                    }else if (dataGridView_add_iva.Rows[a].Cells[3].Value != null && dataGridView_add_iva.Rows[a].Cells[0].Value.ToString() == "0") {
                        String sqlDelete = "DELETE FROM com_opdetiva WHERE IdDetOpIVA = " + dataGridView_add_iva.Rows[a].Cells[3].Value;
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
                    }
                }
                if (vengoDePantallaVer)
                {
                    form_anterior.cargarOperacion(id_operacion_cargado);
                }
                else
                {
                    FormOperacionesEditReparto nueva = new FormOperacionesEditReparto(id_comunidad_cargado, id_operacion_cargado, (Persistencia.SentenciasSQL.select("SELECT IdTipoReparto FROM com_operaciones WHERE IdOp = " + id_operacion_cargado)).Rows[0][0].ToString(), textBox_importe_actual.Text.Replace('.',','));
                    nueva.Show();
                }
                guardada = "si";

                this.Close();
            }else {
                MessageBox.Show("Revise el IVA, el total es : " + textBox_importe_actual.Text + " y debe ser " + importeOperacion_cargado);
            }
        }

        private void actualizar_filasIVA (String id_IVA, String baseIVA,String iva,String total ) {
            if (baseIVA != "0")
            {
                decimal baseIva = Convert.ToDecimal(string.Format("{0:F2}", baseIVA));
                decimal totalDec = Convert.ToDecimal(string.Format("{0:F2}", total));

                String sqlUpdate = "UPDATE com_opdetiva SET IdOp=" + id_operacion_cargado + ", Base=" + Logica.FuncionesGenerales.ArreglarImportes(baseIVA) + ", IdIVA=" + iva + ", IVA=" + Logica.FuncionesGenerales.ArreglarImportes(total) + " WHERE IdDetOpIVA = " + id_IVA;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
        }
        private bool comprobarImporte()
        {
            double ImporteOperacion = Convert.ToDouble(string.Format("{0:F2}", importeOperacion_cargado));
            double ImporteActual = Convert.ToDouble(string.Format("{0:F2}", textBox_importe_actual.Text));
            //totalFilas = Convert.ToDouble(0.00);

            //for (int a = 0; a < dataGridView_add_iva.Rows.Count; a++)  {
            //    if (dataGridView_add_iva.Rows[a].Cells[0].Value != null && dataGridView_add_iva.Rows[a].Cells[2].Value != null) {

            //        double baseIva = Convert.ToDouble(string.Format("{0:F2}", dataGridView_add_iva.Rows[a].Cells[0].Value.ToString().Replace('.',',')));
            //        double total = Convert.ToDouble(string.Format("{0:F2}", dataGridView_add_iva.Rows[a].Cells[2].Value.ToString()));
            //        totalFilas = totalFilas + baseIva + total;
            //    }
            //}
            //MessageBox.Show(totalFilas.ToString() + "-" + importeOperacion_cargado);

            if (ImporteOperacion.Equals(ImporteActual)) { return true; }
            else { return false; }
            
        }
        private void insertar_filasIVA (String baseIVA,String iva,String total ) {
            if (baseIVA != "0")
            {
                String sqlInsert = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + id_operacion_cargado + "," + Logica.FuncionesGenerales.ArreglarImportes(baseIVA) + "," + iva + "," + Logica.FuncionesGenerales.ArreglarImportes(total) + ");";

                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
        }
        public decimal comprobarIVA(String baseIVA, String IVA) {
            decimal baseIva = Convert.ToDecimal(string.Format("{0:F2}", baseIVA));
            decimal IVA_combo = Convert.ToDecimal(string.Format("{0:F2}", IVA));
            decimal totalIVa = ((baseIva * IVA_combo) / 100);
            return totalIVa;
        }

        private void dataGridView_add_iva_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewComboBoxEditingControl dgvCombo = e.Control as DataGridViewComboBoxEditingControl;
            
            if (dgvCombo != null)  {
                dgvCombo.SelectedIndexChanged -= new EventHandler(dvgCombo_SelectedIndexChanged);
                dgvCombo.SelectedIndexChanged += new EventHandler(dvgCombo_SelectedIndexChanged);
            }
        }

        private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            DataRowView valor = (DataRowView)combo.SelectedItem;

            double num, num2;
            if (dataGridView_add_iva.CurrentCell.ColumnIndex == 1)
            {
                if (double.TryParse(valor.Row[1].ToString().Replace('.',','), out num) && double.TryParse(dataGridView_add_iva.Rows[dataGridView_add_iva.CurrentCell.RowIndex].Cells[0].Value.ToString().Replace('.', ','), out num2))  {

                    double numtotal = Convert.ToDouble(string.Format("{0:F2}", comprobarIVA(dataGridView_add_iva.Rows[dataGridView_add_iva.CurrentCell.RowIndex].Cells[0].Value.ToString().Replace('.', ','), valor.Row[1].ToString().Replace('.', ','))));

                    dataGridView_add_iva.Rows[dataGridView_add_iva.CurrentCell.RowIndex].Cells[2].Value = numtotal.ToString().Replace(',','.');              
                }
            }
        }
        private void borrarOperacionEnCurso() {

            if (!vengoDePantallaVer) {
                //TENGO QUE BORRAR LO ANTERIOR
                String sqlDelete = "DELETE FROM com_operaciones WHERE IdOp = " + id_operacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
                MessageBox.Show("Operación Borrada");
            }
        }
        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_add_iva_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double numTotalFila = Convert.ToDouble(0.00);
            double num, num2;

            for (int a = 0; a < dataGridView_add_iva.Rows.Count; a++)  {
                if (dataGridView_add_iva.Rows[a].Cells[0].Value != null && dataGridView_add_iva.Rows[a].Cells[2].Value != null)
                {
                    String num_base = Logica.FuncionesGenerales.ArreglarImportes(dataGridView_add_iva.Rows[a].Cells[0].Value.ToString());

                    if (double.TryParse(num_base.ToString().Replace('.', ','), out num) && double.TryParse(dataGridView_add_iva.Rows[a].Cells[2].Value.ToString().Replace('.',','), out num2))
                    {
                        numTotalFila = num + num2 + numTotalFila;
                    }
                }
            }
            textBox_importe_actual.Text = numTotalFila.ToString();
        }

        private void dataGridView_add_iva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Tab) {
                if (dataGridView_add_iva.CurrentRow.IsNewRow == true && comprobarImporte()) {
                    button_guardar.Select();
                }
            }
        }

        private void FormOperacionesAddIVA_FormClosing(object sender, FormClosingEventArgs e)
        {   if (guardada == "no")
                borrarOperacionEnCurso();
        }
    }
}
