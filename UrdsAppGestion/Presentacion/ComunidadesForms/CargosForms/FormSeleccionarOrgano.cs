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
    public partial class FormSeleccionarOrgano : Form
    {
        String idComunidad;
        Form formAnt;
        public FormSeleccionarOrgano(Form formAnt , String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.formAnt = formAnt;
        }

        private void FormSeleccionarOrgano_Load(object sender, EventArgs e)
        {
            cargarOrganos();
        }

        private void cargarOrganos()
        {
            String sqlSelect = "SELECT com_organos.IdOrgano, com_organos.Nombre FROM com_organos WHERE(((com_organos.IdComunidad) = " + idComunidad + ") AND((com_organos.Activo) = -1))";
            dataGridViewBloques.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
        }
    }
}
