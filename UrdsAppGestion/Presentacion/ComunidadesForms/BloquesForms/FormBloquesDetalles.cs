using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.BloquesForms
{
    public partial class FormBloquesDetalles : Form
    {
        DataTable subcuotas;
        String id_bloque;
        String descripcion;
        String tipo_calculo;
        double total_subcuotas = 0.0;
        double total_cuotas = 0.0;
        double total_partes = 0.0;
        Bloques form_anterior;
        DataTable filas_pegadas = new DataTable();

        String id_comunidad;
        List<String> id_divisiones;

        public FormBloquesDetalles(Bloques form_anterior, String id_bloque, String descripcion, String id_comunidad, String tipo_calculo)
        {
            InitializeComponent();
            this.id_bloque = id_bloque;
            this.descripcion = descripcion;
            this.id_comunidad = id_comunidad;
            this.tipo_calculo = tipo_calculo;
            this.form_anterior = form_anterior;
        }

        private void FormBloquesDetalles_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
            sumarTotales();
           
            this.Text = "Bloques Detalle " + descripcion;
            if (tipo_calculo == "1") {
                button_partes.Visible = false;
                button_cambiarPartes.Visible = false;
                button_manual.Visible = false;
                dataGridView_DetallesBloque.Columns[5].Visible = false;
            }
            if (tipo_calculo == "2")  {
                button_Coeficiente.Visible = false;
                button_cambiarPartes.Visible = true;
                button_manual.Visible = false;
            }
            if (tipo_calculo == "3") {
                dataGridView_DetallesBloque.Columns[5].Visible = false;
                button_Coeficiente.Visible = false;
                button_cambiarPartes.Visible = false;
            }

        }
        private void sumarTotales()
        {
            total_subcuotas = 0.0;
            total_cuotas = 0.0;
            total_partes = 0.0;
            double parte = 0.00;
            for (int a = 0; a < subcuotas.Rows.Count; a++) {
                total_subcuotas += Convert.ToDouble((subcuotas.Rows[a]["Subcuota"]));
                total_cuotas += Convert.ToDouble((subcuotas.Rows[a]["Cuota"]));
                parte = 0.00;
                if (double.TryParse(subcuotas.Rows[a]["Parte"].ToString(),out parte) )
                    total_partes += Convert.ToDouble((subcuotas.Rows[a]["Parte"]));
            }

            label_total.Text = "Sum Subcuota: " + SignificantTruncate(total_subcuotas * 100, 4) + " %";
            label_cuotas.Text = "Sum Cuota: " + SignificantTruncate(total_cuotas * 100, 4) + " %";
            label_partes.Text = "Partes: " + total_partes.ToString();
        }
        public void cargarDatagrid()
        {
            String sql = "SELECT com_subcuotas.IdSubcuota, com_divisiones.IdDivision, com_divisiones.Division, com_tipodivs.TipoDivision, com_divisiones.Cuota,com_subcuotas.Parte, com_subcuotas.Subcuota, com_tipodivs.IdTipoDiv FROM(com_divisiones INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision) INNER JOIN com_tipodivs ON com_divisiones.IdTipoDiv = com_tipodivs.IdTipoDiv WHERE(((com_subcuotas.IdBloque) = " + id_bloque + "));";

            subcuotas = Persistencia.SentenciasSQL.select(sql);
            dataGridView_DetallesBloque.DataSource = subcuotas;

            dataGridView_DetallesBloque.Columns["IdDivision"].Visible = false;
            dataGridView_DetallesBloque.Columns["IdSubcuota"].Visible = false;
            dataGridView_DetallesBloque.Columns["IdTipoDiv"].Visible = false;

            //dataGridView_DetallesBloque.Columns["Cuota"].DefaultCellStyle.Format = "N3";
            dataGridView_DetallesBloque.Columns["Cuota"].DefaultCellStyle.Format = "p4";
            dataGridView_DetallesBloque.Columns["Subcuota"].DefaultCellStyle.Format = "p4";
            dataGridView_DetallesBloque.Columns["Division"].Width = 140;
        }
        public static double SignificantTruncate(double num, int significantDigits)
        {
            double y = Math.Pow(10, significantDigits);
            return Math.Truncate(num * y) / y;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label2.Visible)
            {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("Hay cambios sin guardar\n¿Desea salir sin guardar?", "Salir", MessageBoxButtons.YesNo);
                if (resultado_message == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void button_Importar_Click(object sender, EventArgs e)
        {
            String donde = this.Name;
            Divisiones nueva = new Divisiones(Convert.ToInt32(id_comunidad), donde, this);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void recibirDivision(List<String> id_divisiones)
        {
            this.id_divisiones = id_divisiones;

            for (int a = 0; a < id_divisiones.Count; a++)
            {
                String division = (Persistencia.SentenciasSQL.select("SELECT division FROM com_divisiones WHERE IdDivision = " + id_divisiones[a])).Rows[0][0].ToString();

                String sql = "SELECT Cuota FROM com_divisiones WHERE IdDivision = " + id_divisiones[a];

                String cuota_pasada = (Persistencia.SentenciasSQL.select(sql)).Rows[0][0].ToString();

                if (revisarRepetidos(id_divisiones[a]))
                {
                    DataRow row = subcuotas.NewRow();
                    row[0] = 0;
                    row[1] = id_divisiones[a];
                    row[2] = division;

                    row[3] = (Persistencia.SentenciasSQL.select("SELECT com_tipodivs.TipoDivision FROM com_tipodivs INNER JOIN com_divisiones ON com_tipodivs.IdTipoDiv = com_divisiones.IdTipoDiv WHERE(((com_divisiones.IdDivision) = " + id_divisiones[a] + "));")).Rows[0][0].ToString();

                    row[4] = Convert.ToDouble(cuota_pasada);
                    row[6] = 0.0;

                    row[7] = (Persistencia.SentenciasSQL.select("SELECT com_tipodivs.IdTipoDiv FROM com_tipodivs INNER JOIN com_divisiones ON com_tipodivs.IdTipoDiv = com_divisiones.IdTipoDiv WHERE(((com_divisiones.IdDivision) = " + id_divisiones[a] + "));")).Rows[0][0].ToString();

                    subcuotas.Rows.Add(row);
                    sumarTotales();
                }
                else
                {
                    continue;
                }
            }
            dataGridView_DetallesBloque.DataSource = subcuotas;
            sumarTotales();
            pintarRojo();
        }
        private void pintarRojo()
        {
            for (int b = 0; b < dataGridView_DetallesBloque.Rows.Count; b++)
            {
                if (dataGridView_DetallesBloque.Rows[b].Cells[0].Value.ToString() == "0")
                {
                    dataGridView_DetallesBloque.Rows[b].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView_DetallesBloque.Rows[b].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        private Boolean revisarRepetidos(String nombre_division)
        {
            Boolean resultado = true;
            for (int b = 0; b < dataGridView_DetallesBloque.Rows.Count; b++)
            {
                if (dataGridView_DetallesBloque.Rows[b].Cells["IdDivision"].Value.ToString() == nombre_division)
                {
                    MessageBox.Show("Esa división no se puede añadir porque ya existe.");
                    resultado = false;
                }
            }
            return resultado;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;

            if (label2.Visible)
            {
                for (int c = 0; c < dataGridView_DetallesBloque.Rows.Count; c++)
                {
                    if (dataGridView_DetallesBloque.Rows[c].Cells[0].Value.ToString() != "0")
                    {
                        String sql = "UPDATE com_subcuotas SET Subcuota = " + (dataGridView_DetallesBloque.Rows[c].Cells["Subcuota"].Value.ToString()).Replace(",", ".") + ", Parte = '" + (dataGridView_DetallesBloque.Rows[c].Cells["Parte"].Value.ToString()).Replace(",", ".") + "' WHERE IdSubcuota = " + dataGridView_DetallesBloque.Rows[c].Cells[0].Value.ToString();

                        Persistencia.SentenciasSQL.InsertarGenerico(sql);
                        campoCalculo();
                    }
                }
                if (id_divisiones != null)
                {
                    for (int a = 0; a < id_divisiones.Count; a++)
                    {
                        String subcuota_division = "";
                        for (int b = 0; b < dataGridView_DetallesBloque.Rows.Count; b++)
                        {
                            if (dataGridView_DetallesBloque.Rows[b].Cells["IdDivision"].Value.ToString() == id_divisiones[a])
                            {
                                subcuota_division = (dataGridView_DetallesBloque.Rows[b].Cells["Subcuota"].Value.ToString()).Replace(",", ".");
                            }
                        }
                        String sql = "INSERT INTO com_subcuotas (IdDivision, IdBloque, Subcuota) VALUES (" + id_divisiones[a] + "," + id_bloque + "," + subcuota_division + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sql);
                        campoCalculo();
                    }
                }
                form_anterior.cargarBloques();
                button5.Enabled = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay nada que guardar");
                button5.Enabled = true;
            }
        }

        private void button_Coeficiente_Click(object sender, EventArgs e)
        {
            for (int b = 0; b < dataGridView_DetallesBloque.Rows.Count; b++)
            {
                dataGridView_DetallesBloque.Rows[b].Cells["Subcuota"].Value = (Convert.ToDouble(dataGridView_DetallesBloque.Rows[b].Cells["Cuota"].Value) / total_cuotas).ToString();
            }
            label2.Visible = true;
            sumarTotales();
        }
        //CAMBIADO POR NO CALCULAR BIEN POR PARTES
        //ALEX 12/2017
        private void button_Iguales_Click(object sender, EventArgs e)
        {
            for (int b = 0; b < dataGridView_DetallesBloque.Rows.Count; b++)
                if (dataGridView_DetallesBloque.Rows[b].Cells["Parte"].Value.ToString() == "") dataGridView_DetallesBloque.Rows[b].Cells["Parte"].Value = "1,00";

            label2.Visible = true;
            sumarTotales();

            for (int b = 0; b < dataGridView_DetallesBloque.Rows.Count; b++)
                dataGridView_DetallesBloque.Rows[b].Cells["Subcuota"].Value = Convert.ToDouble(dataGridView_DetallesBloque.Rows[b].Cells["Parte"].Value.ToString()) / total_partes;
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            if (dataGridView_DetallesBloque.SelectedCells[0].Value.ToString() == "0")
            {
                id_divisiones.Remove(dataGridView_DetallesBloque.SelectedCells[1].Value.ToString());
                dataGridView_DetallesBloque.Rows.RemoveAt(dataGridView_DetallesBloque.SelectedCells[0].RowIndex);
            }
            else
            {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar esta División de este Bloque ?", "Borrar Asociacion", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    String sqlBorrar = "DELETE FROM com_subcuotas WHERE IdSubcuota =  " + dataGridView_DetallesBloque.SelectedCells[0].Value.ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    cargarDatagrid();
                    sumarTotales();
                    pintarRojo();
                }
            }
        }

        private void dataGridView_DetallesBloque_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_DetallesBloque.HitTest(e.X, e.Y);
                dataGridView_DetallesBloque.ClearSelection();
                dataGridView_DetallesBloque.Rows[hti.RowIndex].Selected = true;
                dataGridView_DetallesBloque.Columns[hti.ColumnIndex].Selected = true;
                dataGridView_DetallesBloque.CurrentCell = this.dataGridView_DetallesBloque[hti.ColumnIndex, hti.RowIndex];

                if (dataGridView_DetallesBloque.CurrentCell.OwningColumn.Name == "Subcuota")
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void cambiarSubcuotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarSubcuota nueva = new CambiarSubcuota(this, dataGridView_DetallesBloque.SelectedCells[6].Value.ToString());
            nueva.Show();
        }
        public void recogerValorSubcuota(String subcuota_nueva)
        {
            dataGridView_DetallesBloque.SelectedCells[6].Value = Convert.ToDouble(subcuota_nueva);
            label2.Visible = true;
        }

        private void dataGridView_DetallesBloque_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            label3.Text = "Cuenta: " + dataGridView_DetallesBloque.RowCount;
        }

        private void button_cambiarPartes_Click(object sender, EventArgs e)
        {
            FormCambiarPartes nueva = new FormCambiarPartes(this);
            nueva.Show();
        }
        public void cambiarPartes(String[] PartesValores)
        {
            for (int a = 0; a < dataGridView_DetallesBloque.Rows.Count; a++)
            {
                for (int b = 0; b < PartesValores.Length; b++)
                {
                    if (dataGridView_DetallesBloque.Rows[a].Cells["IdTipoDiv"].Value.ToString() == PartesValores[b].ToString().Split(';')[0])
                    {
                        dataGridView_DetallesBloque.Rows[a].Cells["Parte"].Value = PartesValores[b].ToString().Split(';')[1];
                        label2.Visible = true;
                    }
                }
            }
            sumarTotales();
            for (int a = 0; a < dataGridView_DetallesBloque.Rows.Count; a++)
            {
                dataGridView_DetallesBloque.Rows[a].Cells["Subcuota"].Value = (Convert.ToDouble(dataGridView_DetallesBloque.Rows[a].Cells["Parte"].Value) / total_partes);
            }
            sumarTotales();
        }

        private void button_manual_Click(object sender, EventArgs e)
        {
            dataGridView_DetallesBloque.Columns[1].Visible = true;
            dataGridView_DetallesBloque.Columns[2].Visible = true;
            dataGridView_DetallesBloque.Columns[3].Visible = false;
            dataGridView_DetallesBloque.Columns[4].Visible = true;
            dataGridView_DetallesBloque.Columns[5].Visible = false;
            dataGridView_DetallesBloque.Columns[6].Visible = true;
            //dataGridView_DetallesBloque.Columns[6].Visible = false;

            filas_pegadas.Columns.Clear();
            filas_pegadas.Columns.Add("IdDivision");
            filas_pegadas.Columns.Add("Division");
            filas_pegadas.Columns.Add("Cuota");
            filas_pegadas.Columns.Add("Detalle");
            filas_pegadas.Columns.Add("Subcuota");
        }

        private void dataGridView_DetallesBloque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject d = dataGridView_DetallesBloque.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
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
                actualizarDatagrid();
            }
        }
        private void actualizarDatagrid() {
            for (int a = 0; a < dataGridView_DetallesBloque.Rows.Count;a++) {
                for (int b = 0; b < filas_pegadas.Rows.Count; b++)
                if (dataGridView_DetallesBloque.Rows[a].Cells[1].Value.ToString() == filas_pegadas.Rows[b][0].ToString()) {
                        dataGridView_DetallesBloque.Rows[a].Cells["Subcuota"].Value = (Convert.ToDouble(filas_pegadas.Rows[b][3].ToString().Replace("%","")))/100;
                        dataGridView_DetallesBloque.Rows[a].Cells["Parte"].Value = filas_pegadas.Rows[b][4].ToString().Replace("%","");
                }
            }
            sumarTotales();
            label2.Visible = true;
        }
        
        private void campoCalculo() {
            for (int a = 0; a < dataGridView_DetallesBloque.Rows.Count; a++)
            {
                dataGridView_DetallesBloque.Rows[a].Cells["Parte"].Value = "( " + String.Format("{0:0.000}", Math.Round((Convert.ToDouble(dataGridView_DetallesBloque.Rows[a].Cells["Cuota"].Value)) * 100, 4)) + "% / " + String.Format("{0:#.00}", total_cuotas * 100) + "% )";

            }
            label2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            campoCalculo();
        }
    }
}

