using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.BloquesForms
{
    public partial class FormCambiarPartes : Form
    {
        FormBloquesDetalles form_anterior;

        public FormCambiarPartes(FormBloquesDetalles form_anterior)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
        }

        private void button_anyadir_Click(object sender, EventArgs e)
        {
            listBox_partes.Items.Add(comboBox_tiposDivision.SelectedValue + ";" + (comboBox_tiposDivision.GetItemText(comboBox_tiposDivision.SelectedItem)) + ";" + textBox_valor.Text.ToString().Replace(".",","));
        }

        private void FormCambiarPartes_Load(object sender, EventArgs e)
        {
            String sqlTiposDiv = "SELECT com_tipodivs.IdTipoDiv, com_tipodivs.TipoDivision FROM com_tipodivs;";
            comboBox_tiposDivision.DataSource = Persistencia.SentenciasSQL.select(sqlTiposDiv);
            comboBox_tiposDivision.DisplayMember = "TipoDivision";
            comboBox_tiposDivision.ValueMember = "IdTipoDiv";
            
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_calcular_Click(object sender, EventArgs e)
        {
            String[] valoresPartes=new String[listBox_partes.Items.Count];
            for (int a = 0; a < listBox_partes.Items.Count; a++) {
                valoresPartes[a] = listBox_partes.Items[a].ToString().Split(';')[0] + ";" + listBox_partes.Items[a].ToString().Split(';')[2];
            }
            form_anterior.cambiarPartes(valoresPartes);
            this.Close();
        }
    }
}
