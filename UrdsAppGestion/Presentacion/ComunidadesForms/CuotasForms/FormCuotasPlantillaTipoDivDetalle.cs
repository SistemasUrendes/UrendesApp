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
    public partial class FormCuotasPlantillaTipoDivDetalle : Form
    {
        String id_comunidad_cargado;
        String id_plantilla_cargado = "0";
        FormCuotasPlantillas form_anterior;

        public FormCuotasPlantillaTipoDivDetalle(FormCuotasPlantillas form_anterior, String id_comunidad_cargado, String id_plantilla_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_plantilla_cargado = id_plantilla_cargado;
            this.form_anterior = form_anterior;
        }

        private void button_Añadir_Click(object sender, EventArgs e)
        {
            FormCuotasPlantillaTipoDivAlta nueva = new FormCuotasPlantillaTipoDivAlta(id_plantilla_cargado, this, textBox_descripcion.Text);
            nueva.Show();
        }

        private void FormCuotasPlantillaTipoDivDetalle_Load(object sender, EventArgs e)
        {
            if (id_plantilla_cargado != "0") {

                String sqlSelectCabecera = "SELECT com_plantillacuotas.IdPlantillaCuota, com_plantillacuotas.Descripcion, com_plantillacuotas.Activa FROM com_plantillacuotas WHERE(((com_plantillacuotas.IdPlantillaCuota) = " + id_plantilla_cargado + "));";

                DataTable cabecera = Persistencia.SentenciasSQL.select(sqlSelectCabecera);

                textBox_descripcion.Text = cabecera.Rows[0][1].ToString();

                if (cabecera.Rows[0][2].ToString() == "True") checkBox_activa.Checked = true;

                cargarDatagrid();
            }
        }
        public void cargarDatagrid() {
            String sqlSelect = "SELECT com_detplantillacuotas.IdDetPlantCuota, com_tipodivs.TipoDivision, com_detplantillacuotas.Importe FROM com_tipodivs INNER JOIN com_detplantillacuotas ON com_tipodivs.IdTipoDiv = com_detplantillacuotas.IdTipoDivision WHERE(((com_detplantillacuotas.IdPlantillaCuota) = " + id_plantilla_cargado + "));";
            dataGridView_PlantillaTipoDiv.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            FormCuotasPlantillaTipoDivAlta nueva = new FormCuotasPlantillaTipoDivAlta(id_plantilla_cargado,dataGridView_PlantillaTipoDiv.SelectedCells[0].Value.ToString(), this, textBox_descripcion.Text);
            nueva.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String activo = "0";
            if (checkBox_activa.Checked) activo = "-1";

            String sqlUpdate = "UPDATE com_plantillacuotas SET Descripcion='" + textBox_descripcion.Text + "',Activa=" + activo + " WHERE IdPlantillaCuota = " + id_plantilla_cargado;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            form_anterior.cargarDatagrid();
            form_anterior.cargarPrefiltro();
            this.Close();
        }
    }
}
