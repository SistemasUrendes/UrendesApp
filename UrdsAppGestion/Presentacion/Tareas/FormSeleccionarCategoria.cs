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
    public partial class FormSeleccionarCategoria : Form
    {
        DataTable tablaCategorias;
        FormInsertarServicioTarea formAnt;
        String idTarea;

        public FormSeleccionarCategoria(FormInsertarServicioTarea formAnt, String idTarea)
        {
            InitializeComponent();
            this.formAnt = formAnt;
            this.idTarea = idTarea;
        }

        private void FormSeleccionarCategoria_Load(object sender, EventArgs e)
        {
            cargarCategorias();
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            formAnt.recibirCategoria(dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void textBoxFiltroCategoria_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = tablaCategorias;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Nombre like '%" + textBoxFiltroCategoria.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewCategorias.DataSource = busqueda;
        }

        private void cargarCategorias()
        {
            DataTable bloques;
            String sqlSelect = "SELECT exp_area.IdArea FROM exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea WHERE(((exp_area.IdAreaPrevio) = 0) AND((exp_areaTarea.IdTarea) = " + idTarea + "))";
            bloques = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach(DataRow row in bloques.Rows)
            {
                String sqlSelect2 = "SELECT Nombre FROM exp_area WHERE IdAreaPrevio = '" + row[0] + "'";

                if (tablaCategorias == null) tablaCategorias = Persistencia.SentenciasSQL.select(sqlSelect2);
                else tablaCategorias.Merge(Persistencia.SentenciasSQL.select(sqlSelect2));
            }

            dataGridViewCategorias.DataSource = tablaCategorias;
        }
        
        private void dataGridViewCategorias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                formAnt.recibirCategoria(dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString());
                this.Close();
            }
        }
    }
}
