using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    public partial class FormAnyadirOrgano : Form
    {
        String id_comunidad_cargado;
        FormOrganos form_anterior;

        public FormAnyadirOrgano(FormOrganos form_anterior, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") {
                String sqlInsert = "INSERT INTO com_organos (Nombre, IdComunidad, Activo) VALUES ('" + textBox1.Text + "'," + id_comunidad_cargado + ",-1)";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                form_anterior.cargarOrganos();
                this.Close();
            }
        
        }
    }
}
