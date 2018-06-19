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
        String idCargo;
        DataTable organos;
        Tareas.FormInsertarGestion formAnt;
        FormCargos formAnt2;

        public FormSeleccionarOrgano(Tareas.FormInsertarGestion formAnt, String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.formAnt = formAnt;
        }

        public FormSeleccionarOrgano(FormCargos formAnt2, String idComunidad, String idCargo)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.formAnt2 = formAnt2;
            this.idCargo = idCargo;
        }

        private void FormSeleccionarOrgano_Load(object sender, EventArgs e)
        {
            cargarOrganos();
        }

        private void cargarOrganos()
        {
            String sqlSelect = "SELECT com_organos.IdOrgano, com_organos.Nombre FROM com_organos WHERE(((com_organos.IdComunidad) = " + idComunidad + ") AND((com_organos.Activo) = -1))";
            organos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewOrganos.DataSource = organos;
            if (dataGridViewOrganos.Rows.Count > 0 )
            {
                dataGridViewOrganos.Columns[0].Visible = false;
            }
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            //if (formAnt != null) formAnt.recibirOrgano(dataGridViewOrganos.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewOrganos.SelectedRows[0].Cells[1].Value.ToString());
            if (formAnt2 != null) formAnt2.addCargoOrgano(dataGridViewOrganos.SelectedRows[0].Cells[0].Value.ToString(), idCargo);
            this.Close();
        }

        private void textBoxFiltroBloque_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = organos;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroOrganos.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewOrganos.DataSource = busqueda;
        }
    }
}
