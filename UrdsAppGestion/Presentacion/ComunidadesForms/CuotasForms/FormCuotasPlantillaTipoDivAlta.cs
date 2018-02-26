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
    public partial class FormCuotasPlantillaTipoDivAlta : Form
    {
        String id_plantilla;
        String id_plantilla_detalle = "0";
        FormCuotasPlantillaTipoDivDetalle form_anterior;
        String nombre_plantilla;

        public FormCuotasPlantillaTipoDivAlta(String id_plantilla, FormCuotasPlantillaTipoDivDetalle form_anterior, String nombre_plantilla)
        {
            InitializeComponent();
            this.id_plantilla = id_plantilla;
            this.form_anterior = form_anterior;
            this.nombre_plantilla = nombre_plantilla;
        }
        public FormCuotasPlantillaTipoDivAlta(String id_plantilla, String id_plantilla_detalle, FormCuotasPlantillaTipoDivDetalle form_anterior, String nombre_plantilla)
        {
            InitializeComponent();
            this.id_plantilla = id_plantilla;
            this.form_anterior = form_anterior;
            this.nombre_plantilla = nombre_plantilla;
            this.id_plantilla_detalle = id_plantilla_detalle;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)  {
            this.Close();
        }

        private void FormCuotasPlantillaTipoDivAlta_Load(object sender, EventArgs e)
        {
            String sqlTipoDivision = "SELECT IdTipoDiv, TipoDivision FROM com_tipodivs";
            comboBox_tipo_division.DataSource = Persistencia.SentenciasSQL.select(sqlTipoDivision);

            comboBox_tipo_division.DisplayMember = "TipoDivision";
            comboBox_tipo_division.ValueMember = "IdTipoDiv";

            textBox_plantilla.Text = nombre_plantilla;            

            if (id_plantilla_detalle != "0") {
                String sqlSelect = "SELECT IdTipoDivision, Importe FROM com_detplantillacuotas WHERE IdDetPlantCuota = " + id_plantilla_detalle;
                DataTable detalle = Persistencia.SentenciasSQL.select(sqlSelect);
                textBox1.Text = detalle.Rows[0][1].ToString();
                comboBox_tipo_division.SelectedValue = detalle.Rows[0][0].ToString();
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (id_plantilla_detalle != "0") {
                String sqlUpdate = "UPDATE com_detplantillacuotas SET IdTipoDivision=" + comboBox_tipo_division.SelectedValue.ToString() + ", Importe=" + textBox1.Text + " WHERE IdDetPlantCuota = " + id_plantilla_detalle;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                form_anterior.cargarDatagrid();
                this.Close();
            }
            else {
                String sqlInsert = "INSERT INTO com_detplantillacuotas (IdPlantillaCuota, IdTipoDivision, Importe) VALUES (" + id_plantilla + "," + comboBox_tipo_division.SelectedValue.ToString() + "," + textBox1.Text + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                form_anterior.cargarDatagrid();
                this.Close();
            }
        }
    }
}
