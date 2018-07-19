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
        FormInsertarArea formAnt3;
        String idTarea;
        String idBloque;
        String codCat;

        public FormSeleccionarCategoria(FormInsertarServicioTarea formAnt1, String idTarea,String codCat)
        {
            InitializeComponent();
            this.formAnt1 = formAnt1;
            this.idTarea = idTarea;
            this.codCat = codCat;
        }

        public FormSeleccionarCategoria(FormTareasPrincipal formAnt2)
        {
            InitializeComponent();
            this.formAnt2 = formAnt2;
        }

        public FormSeleccionarCategoria(FormInsertarArea formAnt3)
        {
            InitializeComponent();
            this.formAnt3 = formAnt3;
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
            enviar();
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
            String sqlSelect2 = "SELECT exp_catElemento.Nombre, exp_catElemento.IdCatElemento AS codigoArea FROM exp_catElemento";

            if (tablaCategorias == null) tablaCategorias = Persistencia.SentenciasSQL.select(sqlSelect2);
            else tablaCategorias.Merge(Persistencia.SentenciasSQL.select(sqlSelect2));

            dataGridViewCategorias.DataSource = tablaCategorias;
            dataGridViewCategorias.Columns["codigoArea"].Visible = false;
        } 

        private void cargarCategoriasTarea()
        {
            DataTable bloques;
            //String sqlSelect = "SELECT exp_area.IdArea FROM exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea WHERE(((exp_area.IdAreaPrevio) = 0) AND((exp_areaTarea.IdTarea) = " + idTarea + "))";
            String sqlSelect = "SELECT exp_area.IdArea, exp_area.NombreCorto FROM exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea WHERE exp_area.IdAreaPrevio = 0 AND exp_areaTarea.IdTarea = " + idTarea;
            bloques = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach(DataRow row in bloques.Rows)
            {
                String sqlSelect2 = "SELECT Nombre,codigoArea FROM exp_area WHERE IdAreaPrevio = '" + row[0] + "' AND exp_area.NombreCorto Like '" + codCat + "'";

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
                enviar();
            }
        }

        private void enviar()
        {
            String idCat = dataGridViewCategorias.SelectedRows[0].Cells[1].Value.ToString();
            String codigo = "";
            if (idCat.Length == 1) codigo = "00" + idCat;
            else if (idCat.Length == 2) codigo = "0" + idCat;
            else codigo = idCat;
            
            if (formAnt1 != null) formAnt1.recibirCategoria(dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString());
            if (formAnt2 != null) formAnt2.recibirCategoria(dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString(), codigo);
            if (formAnt3 != null) formAnt3.recibirCategoria(dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewCategorias.SelectedRows[0].Cells[1].Value.ToString());
            this.Close();
            
        }
    }
}
