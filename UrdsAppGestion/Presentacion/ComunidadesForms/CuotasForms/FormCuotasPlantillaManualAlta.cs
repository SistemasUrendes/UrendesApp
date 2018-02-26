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
    public partial class FormCuotasPlantillaManualAlta : Form
    {
        String id_comunidad;
        FormCuotasPlantillaManualDetalle form_anterior;

        public FormCuotasPlantillaManualAlta(FormCuotasPlantillaManualDetalle form_anterior, String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.form_anterior = form_anterior;
        }

        private void FormCuotasPlantillaManualAlta_Load(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_bloques.IdBloque, com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdComunidad) = " + id_comunidad + ") AND((com_bloques.IdTipoBloque) = 1));";
            comboBox_Bloque.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            comboBox_Bloque.DisplayMember = "Descripcion";
            comboBox_Bloque.ValueMember = "IdBloque";

            String sqlSelect2 = "SELECT com_divisiones.IdDivision, com_divisiones.Division FROM com_bloques INNER JOIN (com_divisiones INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision) ON com_bloques.IdBloque = com_subcuotas.IdBloque WHERE(((com_bloques.IdBloque) = " + comboBox_Bloque.SelectedValue.ToString() + "));";

            listBox_divisiones.DataSource = Persistencia.SentenciasSQL.select(sqlSelect2);

            listBox_divisiones.DisplayMember = "Division";
            listBox_divisiones.ValueMember = "IdDivision";
        }

        private void comboBox_Bloque_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_divisiones.IdDivision, com_divisiones.Division FROM com_bloques INNER JOIN (com_divisiones INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision) ON com_bloques.IdBloque = com_subcuotas.IdBloque WHERE(((com_bloques.IdBloque) = " + comboBox_Bloque.SelectedValue.ToString() + "));";

            listBox_divisiones.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);

            listBox_divisiones.DisplayMember = "Division";
            listBox_divisiones.ValueMember = "IdDivision";
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            List<String> selectedValues = listBox_divisiones.SelectedItems.Cast<DataRowView>()
                             .Select(dr => (String)(dr[listBox_divisiones.DisplayMember]))
                             .ToList();

            form_anterior.anyadir_division(selectedValues);
            this.Close();
        }
    }
}
