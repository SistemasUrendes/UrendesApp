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
    public partial class FormSeleccionarBloque : Form
    {
        DataTable tablaBloques;
        String idComunidad;
        FormVerTarea form_anterior;
        public FormSeleccionarBloque(FormVerTarea form_anterior, String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.form_anterior = form_anterior;
        }

        private void FormSeleccionarBloque_Load(object sender, EventArgs e)
        {
            cargarBloques();
        }

        private void cargarBloques()
        {

            String sqlSelect = "SELECT com_bloques.IdBloque,com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdTipoBloque) = 1) AND((com_bloques.IdComunidad) = " + idComunidad + "))";
            tablaBloques = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewBloques.DataSource = tablaBloques;

            if (dataGridViewBloques.Rows.Count > 0)
            {
                dataGridViewBloques.Columns["IdBloque"].Visible = false;
                dataGridViewBloques.Columns["Descripcion"].Width = 350;
            }
        }

        private void textBoxFiltroBloque_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = tablaBloques;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroBloque.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewBloques.DataSource = busqueda;
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            form_anterior.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
            this.Close();
        }

        private void dataGridViewBloques_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            form_anterior.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
            this.Close();
        }
    }

}
