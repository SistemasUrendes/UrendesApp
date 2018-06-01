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
        FormInsertarServicioTarea formAnt1;
        FormTareasPrincipal formAnt2;
        String idTarea;
        String idBloque;

        public FormSeleccionarCategoria(FormInsertarServicioTarea formAnt1, String idTarea)
        {
            InitializeComponent();
            this.formAnt1 = formAnt1;
            this.idTarea = idTarea;
        }

        public FormSeleccionarCategoria(FormTareasPrincipal formAnt2)
        {
            InitializeComponent();
            this.formAnt2 = formAnt2;
        }
        
        public FormSeleccionarCategoria(FormTareasPrincipal formAnt2,String idBloque)
        {
            InitializeComponent();
            this.formAnt2 = formAnt2;
            this.idBloque = idBloque;
        }

        private void FormSeleccionarCategoria_Load(object sender, EventArgs e)
        {
            if ( idTarea != null) cargarCategoriasTarea();
            else
            {
                cargarCategorias();
            }
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            if (formAnt1 != null) formAnt1.recibirCategoria(dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString());
            if (formAnt2 != null) formAnt2.recibirCategoria(dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewCategorias.SelectedRows[0].Cells[1].Value.ToString());
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
            if (idBloque == null)
            {
                DataTable bloques;
                String sqlSelect = "SELECT exp_area.IdArea FROM exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea WHERE ((exp_area.IdAreaPrevio) = 0)";
                bloques = Persistencia.SentenciasSQL.select(sqlSelect);

                foreach (DataRow row in bloques.Rows)
                {
                    String sqlSelect2 = "SELECT Nombre,codigoArea FROM exp_area WHERE IdAreaPrevio = '" + row[0] + "'";

                    if (tablaCategorias == null) tablaCategorias = Persistencia.SentenciasSQL.select(sqlSelect2);
                    else tablaCategorias.Merge(Persistencia.SentenciasSQL.select(sqlSelect2));
                }
            }
            else
            {
                String sqlSelect2 = "SELECT Nombre,codigoArea FROM exp_area WHERE IdAreaPrevio = '" + idBloque + "'";

                if (tablaCategorias == null) tablaCategorias = Persistencia.SentenciasSQL.select(sqlSelect2);
                else tablaCategorias.Merge(Persistencia.SentenciasSQL.select(sqlSelect2));

                
            }
            dataGridViewCategorias.DataSource = tablaCategorias;
            dataGridViewCategorias.Columns["codigoArea"].Visible = false;
        } 

        private void cargarCategoriasTarea()
        {
            DataTable bloques;
            String sqlSelect = "SELECT exp_area.IdArea FROM exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea WHERE(((exp_area.IdAreaPrevio) = 0) AND((exp_areaTarea.IdTarea) = " + idTarea + "))";
            bloques = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach(DataRow row in bloques.Rows)
            {
                String sqlSelect2 = "SELECT Nombre,codigoArea FROM exp_area WHERE IdAreaPrevio = '" + row[0] + "'";

                if (tablaCategorias == null) tablaCategorias = Persistencia.SentenciasSQL.select(sqlSelect2);
                else tablaCategorias.Merge(Persistencia.SentenciasSQL.select(sqlSelect2));
            }
            dataGridViewCategorias.DataSource = tablaCategorias;
            dataGridViewCategorias.Columns["codigoArea"].Visible = false;
        }
        
        private void dataGridViewCategorias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (formAnt1 != null) formAnt1.recibirCategoria(dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString());
                if (formAnt2 != null) formAnt2.recibirCategoria(dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewCategorias.SelectedRows[0].Cells[1].Value.ToString());
                this.Close();
            }
        }
    }
}
