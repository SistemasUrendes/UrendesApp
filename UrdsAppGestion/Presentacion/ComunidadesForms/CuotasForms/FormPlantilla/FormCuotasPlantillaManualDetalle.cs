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
    public partial class FormCuotasPlantillaManualDetalle : Form
    {
        DataTable filas_pegadas = new DataTable();
        String id_comunidad_cargado;
        String id_plantilla_pasado;
        List<String> id_divisiones = new List<String>();

        public FormCuotasPlantillaManualDetalle(String id_comunidad_cargado, String id_plantilla_pasado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_plantilla_pasado = id_plantilla_pasado;
        }

        private void textBox_filtro_division_Click(object sender, EventArgs e)
        {
            textBox_filtro_division.Text = "";
            textBox_filtro_division.ForeColor = Color.Black;
        }

        void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C) {
                DataObject d = dataGridView_PlantillaManual.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)  {  
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');

                foreach (string line in lines)  {
                    DataRow row2 = filas_pegadas.NewRow();
                    if (line.Length >0)  {
                        string[] cells = line.Split('\t');
                        for (int i = 0; i < cells.GetLength(0); ++i)  {
                                row2[i] = cells[i];
                        }
                    }
                    else  {
                        break;
                    }
                    filas_pegadas.Rows.Add(row2);
                }
            }
            actualizarDatagrid();
        }
        public void actualizarDatagrid() {
            dataGridView_PlantillaManual.DataSource = filas_pegadas;
           // dataGridView_PlantillaManual.Columns["Division"].Width = 260;
        }
        private void FormCuotasPlantillaManualDetalle_Load(object sender, EventArgs e)
        {
            cargarDatagrid();

        }
        private void cargarDatagrid() {
            String sqlSelect = "SELECT com_cuotamanualdet.IdDetCuotaManual, com_divisiones.IdDivision, com_divisiones.Division, com_bloques.IdBloque, com_bloques.Descripcion, com_cuotamanualdet.Importe FROM(com_cuotamanualdet INNER JOIN com_divisiones ON com_cuotamanualdet.IdDivision = com_divisiones.IdDivision) INNER JOIN com_bloques ON com_cuotamanualdet.IdBloque = com_bloques.IdBloque WHERE com_cuotamanualdet.IdCuotaManual = " + id_plantilla_pasado;

            filas_pegadas = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_PlantillaManual.DataSource = filas_pegadas;
            dataGridView_PlantillaManual.Enabled = true;
            dataGridView_PlantillaManual.Columns[3].Visible = false;
        }

        private void textBox_filtro_division_Leave(object sender, EventArgs e)
        {
            if (textBox_filtro_division.TextLength == 0)
            {
                textBox_filtro_division.Text = "Filtrar División";
                textBox_filtro_division.ForeColor = Color.Gray;
            }
        }
        private void textBox_filtro_division_TextChanged(object sender, EventArgs e)
        {
            if (textBox_filtro_division.Text != "Filtrar División") { 
                if (textBox_filtro_division.TextLength > 1)
                {
                    DataTable busqueda = filas_pegadas;
                    busqueda.DefaultView.RowFilter = "Division like '%" + textBox_filtro_division.Text + "%'";
                    dataGridView_PlantillaManual.DataSource = busqueda;
                }
                else if (textBox_filtro_division.TextLength == 0)
                {
                    DataTable busqueda = filas_pegadas;
                    busqueda.DefaultView.RowFilter = "Division like '%%'";
                    dataGridView_PlantillaManual.DataSource = busqueda;
                }
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            Boolean TodoBien = true;

            if (dataGridView_PlantillaManual.Rows.Count > 0) {

                for (int a = 0; a < dataGridView_PlantillaManual.Rows.Count;a++)
                {
                    string id = dataGridView_PlantillaManual.Rows[a].Cells[0].Value.ToString();
                    if (!todoCorrecto(Convert.ToInt32(id)))
                        TodoBien = false;
                }

                if (TodoBien) {
                    for (int a = 0; a < dataGridView_PlantillaManual.Rows.Count; a++)
                    {
                        string id = dataGridView_PlantillaManual.Rows[a].Cells[0].Value.ToString();
                        if (id == "0")
                        {
                            String sqlInsert = "INSERT INTO com_cuotamanualdet (IdCuotaManual, IdDivision, IdBloque, Importe) VALUES (" + id_plantilla_pasado + "," + dataGridView_PlantillaManual.Rows[a].Cells[1].Value.ToString() + "," + dataGridView_PlantillaManual.Rows[a].Cells[3].Value.ToString() + "," + dataGridView_PlantillaManual.Rows[a].Cells[5].Value.ToString() + ")";

                            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                        }else {
                            String sqlUpdate = "UPDATE com_cuotamanualdet SET IdCuotaManual=" + id_plantilla_pasado + ", IdDivision=" + dataGridView_PlantillaManual.Rows[a].Cells[1].Value.ToString() + ",IdBloque=" + dataGridView_PlantillaManual.Rows[a].Cells[3].Value.ToString() + ",Importe=" + dataGridView_PlantillaManual.Rows[a].Cells[5].Value.ToString() + " WHERE IdDetCuotaManual = " + id;

                            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                        }
                    }
                    cargarDatagrid();
                }
                else {
                    MessageBox.Show("Hay alguna linea incorrecta");
                }
                
            }
        }
        private Boolean todoCorrecto(int indice) {
            try
            {
                if (Convert.ToInt32(dataGridView_PlantillaManual.Rows[indice].Cells["IdBloque"].Value) != 0 && Convert.ToDouble(dataGridView_PlantillaManual.Rows[indice].Cells["Importe"].Value) != 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Los datos no son correctos");
                    return false;
                }
            }catch {
                MessageBox.Show("Los datos no son correctos");
                return false;
            }
        }

        private void button_Añadir_Click(object sender, EventArgs e)
        {
            
            String donde = this.Name;
            Divisiones nueva = new Divisiones(Convert.ToInt32(id_comunidad_cargado), donde, this);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void anyadir_division(List<String> division) {
           
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Quitar división de la lista ?", "Quitar División", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                if (dataGridView_PlantillaManual.SelectedRows[0].Cells[0].Value.ToString() == "0")
                    dataGridView_PlantillaManual.Rows.RemoveAt(dataGridView_PlantillaManual.CurrentRow.Index);
                else
                {
                    String sqlDelete = "DELETE FROM com_cuotamanualdet WHERE IdDetCuotaManual = " + dataGridView_PlantillaManual.SelectedRows[0].Cells[0].Value.ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
                }
                cargarDatagrid();
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    DataRow row = filas_pegadas.NewRow();
                    row[0] = 0;
                    row[1] = id_divisiones[a];
                    row[2] = division;
                    row[3] = Convert.ToDouble(cuota_pasada);

                    filas_pegadas.Rows.Add(row);
                }
                else
                {
                    continue;
                }
            }
            dataGridView_PlantillaManual.DataSource = filas_pegadas;

        }
        private Boolean revisarRepetidos(String nombre_division)
        {
            Boolean resultado = true;
            for (int b = 0; b < dataGridView_PlantillaManual.Rows.Count; b++)
            {
                if (dataGridView_PlantillaManual.Rows[b].Cells["IdDivision"].Value.ToString() == nombre_division)
                {
                    MessageBox.Show("Esa división no se puede añadir porque ya existe.");
                    resultado = false;
                }
            }
            return resultado;
        }

        private void button_cambiar_Click(object sender, EventArgs e)
        {
            FormPlantilla.FormDetalleCuotaCambiar nueva = new FormPlantilla.FormDetalleCuotaCambiar(this,id_comunidad_cargado);
            nueva.Show();
        }
        public void recibirDatos(String idBloque, String nombreBloque, String importe) {

            DataGridViewSelectedRowCollection Seleccionados = dataGridView_PlantillaManual.SelectedRows;
            foreach (DataGridViewRow item in Seleccionados)
            {
                item.Cells["Importe"].Value = importe;

                String sqlSelect = "SELECT com_subcuotas.IdBloque FROM com_divisiones INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision WHERE(((com_divisiones.IdDivision) = " + item.Cells["IdDivision"].Value.ToString() + "));";
                DataTable bloquesValidos = Persistencia.SentenciasSQL.select(sqlSelect);
                for (int b = 0;b < bloquesValidos.Rows.Count ;b++) {
                    if (bloquesValidos.Rows[b][0].ToString() == idBloque) {
                        item.Cells["Descripcion"].Value = nombreBloque;
                        item.Cells["IdBloque"].Value = idBloque;
                    }
                }
            }
        }
    }
}
