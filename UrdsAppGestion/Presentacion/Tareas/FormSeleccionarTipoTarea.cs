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
    public partial class FormSeleccionarTipoTarea : Form
    {
        FormVerTarea formAnt;
        DataTable tipoTarea;
        DataTable categorias;

        public FormSeleccionarTipoTarea(FormVerTarea formAnt)
        {
            InitializeComponent();
            this.formAnt = formAnt;
        }

        private void FormSeleccionarTipoTarea_Load(object sender, EventArgs e)
        {
            cargarTiposTarea();
            cargarCategorias();
            if (Login.getRol() == "Admin")
            {
                buttonMantenimiento.Visible = true;
            }
            else
            {
                buttonMantenimiento.Visible = false;
            }
        }


        public void cargarTiposTarea()
        {
            String sqlSelect = "SELECT exp_tipostareas.IdTipoTarea, exp_tipostareas.TipoTarea AS Descripcion, Sum(exp_tipogestion.HorasDeTrabajo) AS CT FROM exp_tipogestion INNER JOIN (exp_tipostareas INNER JOIN exp_gestionEstado ON exp_tipostareas.IdTipoTarea = exp_gestionEstado.IdTipoTarea) ON exp_tipogestion.IdTipoGestion = exp_gestionEstado.IdTipoGestion GROUP BY exp_tipostareas.IdTipoTarea, exp_tipostareas.TipoTarea";
            

            tipoTarea = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewTipoTarea.DataSource = tipoTarea;

            if (dataGridViewTipoTarea.Rows.Count > 0)
            {
                dataGridViewTipoTarea.Columns["IdTipoTarea"].Visible = false;
                dataGridViewTipoTarea.Columns["Descripcion"].Width = 240;
                dataGridViewTipoTarea.Columns["CT"].Width = 40;
            }
        }

        public void cargarCategorias()
        {
            String sqlSelect = "SELECT exp_catTareas.IdCatTareas, exp_catTareas.Nombre FROM exp_catTareas";
            categorias = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewCategorias.DataSource = categorias;
            if (dataGridViewCategorias.Rows.Count > 0)
            {
                dataGridViewCategorias.Columns["IdCatTareas"].Visible = false;
            }
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            String tipoTarea = dataGridViewTipoTarea.SelectedRows[0].Cells[1].Value.ToString();
            String idTipoTarea = dataGridViewTipoTarea.SelectedRows[0].Cells[0].Value.ToString();
            formAnt.recibirTipoTarea(idTipoTarea, tipoTarea);
            this.Close();

        }

        private void dataGridViewCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCategorias.SelectedRows.Count > 0)
            {
                cargarTiposCat(dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void cargarTiposCat(String IdCat)
        {
            String sqlSelect = "SELECT exp_tipostareas.IdTipoTarea, exp_tipostareas.TipoTarea AS Descripcion, Sum(exp_tipogestion.HorasDeTrabajo) AS CT FROM exp_tipogestion INNER JOIN (exp_tipostareas INNER JOIN exp_gestionEstado ON exp_tipostareas.IdTipoTarea = exp_gestionEstado.IdTipoTarea) ON exp_tipogestion.IdTipoGestion = exp_gestionEstado.IdTipoGestion WHERE(((exp_tipostareas.IdCatTareas) = '" + IdCat + "')) GROUP BY exp_tipostareas.IdTipoTarea, exp_tipostareas.TipoTarea";


            tipoTarea = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewTipoTarea.DataSource = tipoTarea;

            if (dataGridViewTipoTarea.Rows.Count > 0)
            {
                dataGridViewTipoTarea.Columns["IdTipoTarea"].Visible = false;
                dataGridViewTipoTarea.Columns["Descripcion"].Width = 240;
                dataGridViewTipoTarea.Columns["CT"].Width = 40;
            }
        }

        private void buttonMantenimiento_Click(object sender, EventArgs e)
        {
            FormTareasConfiguracion nueva = new FormTareasConfiguracion(this);
            nueva.Show();
        }

        private void textBoxFiltroCategorias_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = categorias;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Nombre like '%" + textBoxFiltroCategorias.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewCategorias.DataSource = busqueda;
        }

        private void textBoxFiltroTarea_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = tipoTarea;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroTarea.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewTipoTarea.DataSource = busqueda;
        }
    }
}
