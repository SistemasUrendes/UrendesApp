using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms.FormPlantilla
{
    public partial class FormDetalleCuotaCambiar : Form
    {
        String idComunidad;
        FormCuotasPlantillaManualDetalle form_anterior;

        public FormDetalleCuotaCambiar(FormCuotasPlantillaManualDetalle form_anterior, String idComunidad)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idComunidad = idComunidad;
        }

        private void FormDetalleCuotaCambiar_Load(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_bloques.IdBloque, com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdComunidad) = " + idComunidad + ") AND((com_bloques.IdTipoBloque) = 1));";

            comboBox_bloque.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            comboBox_bloque.DisplayMember = "Descripcion";
            comboBox_bloque.ValueMember = "IdBloque";
            
        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            try
            {
                double importe = Convert.ToDouble(textBox_importe.Text);
            }catch {
                MessageBox.Show("El Importe no es un número");
                return;
            }
            form_anterior.recibirDatos(comboBox_bloque.SelectedValue.ToString(), comboBox_bloque.Text, textBox_importe.Text.Replace('.',','));
            this.Close();
        }
    }
}
