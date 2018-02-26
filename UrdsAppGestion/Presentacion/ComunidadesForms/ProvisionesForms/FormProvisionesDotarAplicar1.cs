using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProvisionesForms
{
    public partial class FormProvisionesDotarAplicar1 : Form
    {
        String id_comunidad_cargado = "0";
        String dedondevengo;

        public FormProvisionesDotarAplicar1(String id_comunidad_cargado, String dedondevengo)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.dedondevengo = dedondevengo;
        }

        private void FormProvisionesDotarAplicar_Load(object sender, EventArgs e)
        {

            String sqlSelectProvisiones = "SELECT IdProvision, Nombre FROM com_provisiones WHERE IdComunidad = " + id_comunidad_cargado;
            DataTable provisiones = Persistencia.SentenciasSQL.select(sqlSelectProvisiones);
            listBox_provisiones.DataSource = provisiones;

            listBox_provisiones.DisplayMember = "Nombre";
            listBox_provisiones.ValueMember = "IdProvision";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormProvisionesDotarAplicar2 nueva = new FormProvisionesDotarAplicar2(id_comunidad_cargado,listBox_provisiones.SelectedValue.ToString(),dedondevengo);
            nueva.Show();
            this.Close();
        }
    }
}
