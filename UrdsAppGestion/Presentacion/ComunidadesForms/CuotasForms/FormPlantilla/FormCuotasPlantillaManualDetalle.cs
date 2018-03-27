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
            String sqlSelect = "SELECT com_cuotamanualdet.IdDetCuotaManual, com_divisiones.IdDivision, com_divisiones.Division, com_bloques.IdBloque, com_bloques.Descripcion, com_cuotamanualdet.Importe FROM(com_cuotamanualdet INNER JOIN com_divisiones ON com_cuotamanualdet.IdDivision = com_divisiones.IdDivision) INNER JOIN com_bloques ON com_cuotamanualdet.IdBloque = com_bloques.IdBloque WHERE com_cuotamanualdet.IdCuotaManual = " + id_plantilla_pasado;

            dataGridView_PlantillaManual.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_PlantillaManual.Enabled = true;

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
                if (textBox_filtro_division.TextLength > 0)
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
            if (dataGridView_PlantillaManual.Rows.Count > 0) {
                for (int a = 0; a < dataGridView_PlantillaManual.Rows.Count; a++) {

                }

            }
        }

        private void button_Añadir_Click(object sender, EventArgs e)
        {
            FormCuotasPlantillaManualAlta nueva = new FormCuotasPlantillaManualAlta(this,id_comunidad_cargado);
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
                dataGridView_PlantillaManual.Rows.RemoveAt(dataGridView_PlantillaManual.CurrentRow.Index);
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
