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
            if (id_plantilla_cargado != "0") cargarDatos();
        }
        private void cargarDatos() {

            String SelectPlantilla = "SELECT com_cuotamanual.NombreCuotaManual, com_cuotamanual.Activa, com_cuotamanual.Abono FROM com_cuotamanual WHERE com_cuotamanual.IdCuotaManual = " + id_plantilla_cargado;

            DataTable fila = Persistencia.SentenciasSQL.select(SelectPlantilla);

            if (fila.Rows[0][1].ToString() == "True") checkBox_Activa.Checked = true;
            else checkBox_Activa.Checked = false;

            if (fila.Rows[0][2].ToString() == "True") checkBox_abono.Checked = true;
            else checkBox_abono.Checked = false;

            textBox_Plantilla.Text = fila.Rows[0][0].ToString();
        }
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String activa = "0";
            if (checkBox_Activa.Checked) activa = "-1";

            String abono = "0";
            if (checkBox_abono.Checked) abono = "-1";

            if (id_plantilla_cargado != "0")
            {
                String sqlUpdate = "UPDATE com_cuotamanual SET NombreCuotaManual='" + textBox_Plantilla.Text + "', Activa=" + activa + ", Abono=" + abono + " WHERE IdCuotaManual = " + id_plantilla_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            else { 
                String sqlInsert = "INSERT INTO com_cuotamanual (NombreCuotaManual, Activa, Abono, IdComunidad) VALUES ('" + textBox_Plantilla.Text + "'," + activa + ", " + abono + " ," + id_comunidad_cargado + ")";

                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
            form_anterior.cargarDatagrid();
            this.Close();
        }

        private void button_Cancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
