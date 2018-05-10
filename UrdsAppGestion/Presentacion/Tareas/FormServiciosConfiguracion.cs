using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.Tareas
{
    public partial class FormServiciosConfiguracion : Form
    {
        public FormServiciosConfiguracion()
        {
            InitializeComponent();
        }

        private void FormServiciosConfiguracion_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
        }

        private void rellenarComboBox()
        {
            DataTable comunidades;
            String sqlComboTipo = "SELECT com_comunidades.Referencia, ctos_entidades.NombreCorto FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.FBaja)Is Null))";
            comunidades = Persistencia.SentenciasSQL.select(sqlComboTipo);

            comboBoxComunidades.DataSource = comunidades;
            comboBoxComunidades.DisplayMember = "NombreCorto";
            comboBoxComunidades.ValueMember = "Referencia";

        }

        private void buttonAddBloque_Click(object sender, EventArgs e)
        {

        }
        
    }
}
