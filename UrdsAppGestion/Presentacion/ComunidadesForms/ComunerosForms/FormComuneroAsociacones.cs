using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms {
    public partial class FormComuneroAsociaciones : Form  {
        String id_comunero_cargado;
        String nombre_entidad;

        public FormComuneroAsociaciones(String nombre_entidad, String id_comunero_cargado)  {
            InitializeComponent();
            this.id_comunero_cargado = id_comunero_cargado;
            this.nombre_entidad = nombre_entidad;
            textBox_Entidad.Text = nombre_entidad;
        }

        private void FormComuneroAsociaciones_Load(object sender, EventArgs e)  {
            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String sql = "SELECT com_asociacion.IdAsociacion, com_divisiones.Division, com_asociacion.Participacion, com_asociacion.FechaBaja FROM com_asociacion INNER JOIN com_divisiones ON com_asociacion.IdDivision = com_divisiones.IdDivision WHERE(((com_asociacion.IdComunero) = " + id_comunero_cargado + ") AND((com_asociacion.FechaBaja)Is Null));";
            dataGridView_ListaAsociaciones.DataSource = Persistencia.SentenciasSQL.select(sql);

        }
        private void button1_Click(object sender, EventArgs e)  {
            this.Close();
        }
    }
}
