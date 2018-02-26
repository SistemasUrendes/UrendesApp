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
    public partial class FormCuotasPlantillaPptoAlta : Form
    {
        String id_plantilla_cargado;
        String id_plantilla_detalles_cargado = "0";
        String id_comunidad_cargado;

        FormCuotasPlantillaPptoDetalle form_anterior;

        public FormCuotasPlantillaPptoAlta(FormCuotasPlantillaPptoDetalle form_anterior, String id_plantilla_cargado, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_plantilla_cargado = id_plantilla_cargado;
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        public FormCuotasPlantillaPptoAlta(FormCuotasPlantillaPptoDetalle form_anterior, String id_plantilla_cargado, String id_comunidad_cargado, String id_plantilla_detalles_cargado)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_plantilla_cargado = id_plantilla_cargado;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_plantilla_detalles_cargado = id_plantilla_detalles_cargado;
        }

        private void FormCuotasPlantillaPptoAlta_Load(object sender, EventArgs e)
        {
            String sqlCombo = "SELECT com_bloques.IdBloque, com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdComunidad) = " + id_comunidad_cargado + ") AND((com_bloques.IdTipoBloque) = 1));";

            comboBox1.DataSource = Persistencia.SentenciasSQL.select(sqlCombo);
            comboBox1.ValueMember = "IdBloque";
            comboBox1.DisplayMember = "Descripcion";

            if (id_plantilla_detalles_cargado != "0") {
                String sqlSelect = "SELECT IdDetPlantCuota, IdBloque, Importe FROM com_detplantillacuotas WHERE IdDetPlantCuota = " + id_plantilla_detalles_cargado;
                DataTable fila = Persistencia.SentenciasSQL.select(sqlSelect);
                textBox_importe.Text = fila.Rows[0][2].ToString();

                if (fila.Rows[0][1].ToString() != "") comboBox1.SelectedValue = fila.Rows[0][1].ToString();
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (id_plantilla_detalles_cargado != "0")
            {
                String sqlUpdate = "UPDATE com_detplantillacuotas SET IdBloque=" + comboBox1.SelectedValue.ToString() + ", Importe= '" + textBox_importe.Text + "' WHERE IdDetPlantCuota = " + id_plantilla_detalles_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                form_anterior.cargarDatagrid();
                this.Close();
            }
            else {
                String sqlINSERT = "INSERT INTO com_detplantillacuotas (IdPlantillaCuota, IdBloque, Importe) VALUES (" + id_plantilla_cargado + "," + comboBox1.SelectedValue.ToString() + ",'" + textBox_importe.Text + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlINSERT);
                form_anterior.cargarDatagrid();
                this.Close();
            }
        }
    }
}
