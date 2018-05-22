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
    public partial class FormServiciosBloque : Form
    {
        String idComunidad;
        DataTable tablaBloques;

        public FormServiciosBloque(String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
        }

        private void FormServiciosBloque_Load(object sender, EventArgs e)
        {
            cargarBloques();
        }

        private void dataGridViewBloque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewBloque.SelectedRows[0].Index > -1)
            {
                FormArbolAreasBloque nueva = new FormArbolAreasBloque(dataGridViewBloque.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloque.SelectedRows[0].Cells[1].Value.ToString(), nombreComunidad());
                nueva.Show();
            }
        }

        private void cargarBloques()
        {

            String sqlSelect = "SELECT com_bloques.IdBloque,com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdTipoBloque) = 1) AND ((com_bloques.Baja) = 0) AND((com_bloques.IdComunidad) = " + idComunidad + "))";
            tablaBloques = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewBloque.DataSource = tablaBloques;

            if (dataGridViewBloque.Rows.Count > 0)
            {
                dataGridViewBloque.Columns["IdBloque"].Visible = false;
                dataGridViewBloque.Columns["Descripcion"].Width = 350;
            }
        }

        private void textBoxFiltroBloque_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = tablaBloques;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroBloque.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewBloque.DataSource = busqueda;
        }

        private String nombreComunidad()
        {
            String sqlSelect = "SELECT ctos_entidades.NombreCorto FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + idComunidad + "))";
            return Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
        }
    }
}
