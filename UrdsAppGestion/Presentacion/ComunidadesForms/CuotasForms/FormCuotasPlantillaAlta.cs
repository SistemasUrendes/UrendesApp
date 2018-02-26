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
    public partial class FormCuotasPlantillaAlta : Form
    {
        String id_comunidad_cargado;
        FormCuotasPlantillas form_anterior;
        String id_plantilla_cargado = "0";

        public FormCuotasPlantillaAlta(FormCuotasPlantillas form_anterior,String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
        }

        public FormCuotasPlantillaAlta(FormCuotasPlantillas form_anterior,String id_comunidad_cargado, String id_plantilla_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
            this.id_plantilla_cargado = id_plantilla_cargado;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCuotasPlantillaAlta_Load(object sender, EventArgs e)
        {
            String sqlMetodo = "SELECT IdTipoPlantillaCuota, TipoPlantillaCuota FROM com_TipoPlantillaCuota";
            comboBox_TipoPlantilla.DataSource = Persistencia.SentenciasSQL.select(sqlMetodo);
            comboBox_TipoPlantilla.DisplayMember = "TipoPlantillaCuota";
            comboBox_TipoPlantilla.ValueMember = "IdTipoPlantillaCuota";

            if (id_plantilla_cargado != "0") cargarDatos();
        }
        private void cargarDatos() {
            String SelectPlantilla = "SELECT IdPlantillaCuota, IdTipoPlantillaCuota, Descripcion, Activa FROM com_plantillacuotas WHERE IdPlantillaCuota = " + id_plantilla_cargado;
            DataTable fila = Persistencia.SentenciasSQL.select(SelectPlantilla);

            if (fila.Rows[0][1].ToString() != "") comboBox_TipoPlantilla.SelectedValue = fila.Rows[0][1].ToString();

            if (fila.Rows[0][3].ToString() == "True") checkBox_Activa.Checked = true;
            else checkBox_Activa.Checked = false;

            textBox_Plantilla.Text = fila.Rows[0][2].ToString();
        }
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String activa = "0";
            if (checkBox_Activa.Checked) activa = "-1";

            if (id_plantilla_cargado != "0")
            {
                String sqlUpdate = "UPDATE com_plantillacuotas SET IdTipoPlantillaCuota=" + comboBox_TipoPlantilla.SelectedValue.ToString() + ", Descripcion='" + textBox_Plantilla.Text + "',Activa=" + activa + " WHERE IdPlantillaCuota = " + id_plantilla_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            else { 
                String sqlInsert = "INSERT INTO com_plantillacuotas (IdComunidad, IdTipoPlantillaCuota, Descripcion, Activa) VALUES (" + id_comunidad_cargado + "," + comboBox_TipoPlantilla.SelectedValue.ToString() + ",'" + textBox_Plantilla.Text + "'," + activa + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
            form_anterior.cargarDatagrid();
            this.Close();
        }
    }
}
