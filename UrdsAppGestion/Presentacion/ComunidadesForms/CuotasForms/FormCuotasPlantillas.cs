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
    public partial class FormCuotasPlantillas : Form
    {
        String id_comunidad_cargado = "0";
        DataTable plantillas;
        String filtro_pasado;

        public FormCuotasPlantillas(String id_comunidad_cargado, String filtro_pasado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.filtro_pasado = filtro_pasado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCuotasPlantillaAlta nueva = new FormCuotasPlantillaAlta(this,id_comunidad_cargado);
            nueva.Show();
        }

        private void FormCuotasPlantillas_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
            comboBox_TipodeCuota.SelectedItem = filtro_pasado;
            cargarPrefiltro();
        }
        public void cargarDatagrid() {
            String sqlSelect = "SELECT IdCuotaManual, NombreCuotaManual, Abono, Activa FROM com_cuotamanual WHERE IdComunidad = " + id_comunidad_cargado;
            plantillas = Persistencia.SentenciasSQL.select(sqlSelect);


            dataGridView_plantillas.DataSource = plantillas;
            dataGridView_plantillas.Columns["Activa"].Width = 50;
            dataGridView_plantillas.Columns["NombreCuotaManual"].Width = 235;
            dataGridView_plantillas.Columns["Abono"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView_plantillas.SelectedCells[1].Value.ToString());

            //if (dataGridView_plantillas.SelectedCells[1].Value.ToString() == "Presupuesto") {
            //    FormCuotasPlantillaPptoDetalle nueva = new FormCuotasPlantillaPptoDetalle(this,id_comunidad_cargado, dataGridView_plantillas.SelectedCells[0].Value.ToString());
            //    nueva.Show();
            //}else if(dataGridView_plantillas.SelectedCells[1].Value.ToString() == "Tipo División") {
            //    FormCuotasPlantillaTipoDivDetalle nueva = new FormCuotasPlantillaTipoDivDetalle(this,id_comunidad_cargado,dataGridView_plantillas.SelectedCells[0].Value.ToString());
            //    nueva.Show();

            //}else if (dataGridView_plantillas.SelectedCells[1].Value.ToString() == "Cuota Fija") {
                FormCuotasPlantillaManualDetalle nueva = new FormCuotasPlantillaManualDetalle(id_comunidad_cargado, dataGridView_plantillas.SelectedCells[0].Value.ToString());
                nueva.Show();
            //}

            //FormCuotasPlantillaAlta nueva = new FormCuotasPlantillaAlta(this, id_comunidad_cargado,dataGridView_plantillas.SelectedCells[0].Value.ToString());
            //nueva.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta Plantilla ?", "Borrar Plantilla", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_plantillacuotas WHERE IdPlantillaCuota =  " + dataGridView_plantillas.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarDatagrid();
            }
        }

        private void dataGridView_plantillas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_plantillas.HitTest(e.X, e.Y);
                dataGridView_plantillas.ClearSelection();
                dataGridView_plantillas.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void editarPlantillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCuotasPlantillaAlta nueva = new FormCuotasPlantillaAlta(this, id_comunidad_cargado, dataGridView_plantillas.SelectedCells[0].Value.ToString());
            nueva.Show();
        }
         public void cargarPrefiltro() {

            DataTable busqueda = plantillas;

            //if (filtro_pasado == "Manuales")
            //    busqueda.DefaultView.RowFilter = "IdTipoPlantillaCuota = '1'";
            //else if (filtro_pasado == "Presupuesto")
            //    busqueda.DefaultView.RowFilter = "IdTipoPlantillaCuota = '2'";
            //else if (filtro_pasado == "Tipo División")
            //    busqueda.DefaultView.RowFilter = "IdTipoPlantillaCuota = '3'";
            //else if (filtro_pasado == "Todos")
            //    busqueda.DefaultView.RowFilter = "IdTipoPlantillaCuota = '3' OR IdTipoPlantillaCuota = '2' OR IdTipoPlantillaCuota = '1'";

            this.dataGridView_plantillas.DataSource = busqueda;
        }

        private void comboBox_TipodeCuota_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Importe Fijo
            //Presupuesto
            //Tipo División

            ComboBox estado = (ComboBox)sender;
            DataTable busqueda = plantillas;

            if (estado.SelectedItem.ToString() == "Manuales")
            {
                busqueda.DefaultView.RowFilter = "IdTipoPlantillaCuota = '1'";
            }
            else if (estado.SelectedItem.ToString() == "Presupuesto")
            {
                busqueda.DefaultView.RowFilter = "IdTipoPlantillaCuota = '2'";
            }
            else if (estado.SelectedItem.ToString() == "Tipo División")
            {
                busqueda.DefaultView.RowFilter = "IdTipoPlantillaCuota = '3'";
            }
            else if (estado.SelectedItem.ToString() == "Todos")
            {
                busqueda.DefaultView.RowFilter = "IdTipoPlantillaCuota = '3' OR IdTipoPlantillaCuota = '2' OR IdTipoPlantillaCuota = '1'";
            }
            
            this.dataGridView_plantillas.DataSource = busqueda;
        }
    }
}
