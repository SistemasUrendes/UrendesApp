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
    public partial class FormListadoOrganos : Form
    {
        String idComunidad;
        DataTable grupos;
        public FormListadoOrganos(String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
        }

        private void FormListadoOrganos_Load(object sender, EventArgs e)
        {
            cargarGrupos();
        }
        
        public void cargarGrupos()
        {
            String sqlComboGrupo = "SELECT exp_categoriaContactos.IdGrupo,exp_categoriaContactos.Nombre  FROM exp_categoriaContactos WHERE (exp_categoriaContactos.IdComunidad) = '" + idComunidad + "' AND FBaja Is Null";
            grupos = Persistencia.SentenciasSQL.select(sqlComboGrupo);
            dataGridViewOrganos.DataSource = grupos;

            if (dataGridViewOrganos.Rows.Count > 0 )
            {
                dataGridViewOrganos.Columns["IdGrupo"].Visible = false;
            }
        }

        private void dataGridViewOrganos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EntidadesForms.FormInsertarGrupo nueva = new EntidadesForms.FormInsertarGrupo(dataGridViewOrganos.SelectedRows[0].Cells[0].Value.ToString(), idComunidad);
            nueva.Show();
        }

        private void cambiarNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNuevoGrupo nueva = new FormNuevoGrupo(this, dataGridViewOrganos.SelectedRows[0].Cells[0].Value.ToString(),idComunidad);
            nueva.Show();
        }

        private void darDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String idGrupo = dataGridViewOrganos.SelectedRows[0].Cells[0].Value.ToString();
            String fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
            String sqlUpdate = "UPDATE exp_categoriaContactos SET FBaja = '" + fechaHoy + "' WHERE IdGrupo = '" + idGrupo + "'";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);

            cargarGrupos();
        }
        

        private void textBoxfiltro_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = grupos;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Nombre like '%" + textBoxfiltro.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewOrganos.DataSource = busqueda;
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            FormNuevoGrupo nueva = new FormNuevoGrupo(this,idComunidad);
            nueva.Show();
        }

        private void dataGridViewOrganos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewOrganos.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    dataGridViewOrganos.ClearSelection();
                    dataGridViewOrganos.Rows[hti.RowIndex].Selected = true;
                    dataGridViewOrganos.Columns[hti.ColumnIndex].Selected = true;
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }
    }
}
