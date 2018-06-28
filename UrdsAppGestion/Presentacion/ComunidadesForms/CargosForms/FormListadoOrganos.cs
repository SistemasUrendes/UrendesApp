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
        String idBloque;
        Tareas.FormInsertarGestion formAnt;
        public FormListadoOrganos(String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
        }


        public FormListadoOrganos(Tareas.FormInsertarGestion formAnt, String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.formAnt = formAnt;
        }

        private void FormListadoOrganos_Load(object sender, EventArgs e)
        {
            cargarGrupos();
            if (formAnt != null)
            {
                buttonEnviar.Visible = true;
            }
        }
        
        public void cargarGrupos()
        {
            //String sqlComboGrupo = "SELECT exp_categoriaContactos.IdGrupo,exp_categoriaContactos.Nombre  FROM exp_categoriaContactos WHERE (exp_categoriaContactos.IdComunidad) = '" + idComunidad + "' AND FBaja Is Null";
            String sqlSelect = "SELECT exp_categoriaContactos.IdGrupo, exp_categoriaContactos.Nombre, com_bloques.Descripcion AS Bloque, DATE_FORMAT(Coalesce(exp_categoriaContactos.FBaja, 'ok'), '%d/%m/%Y') AS FBaja FROM exp_categoriaContactos LEFT JOIN com_bloques ON exp_categoriaContactos.IdBloque = com_bloques.IdBloque WHERE(((exp_categoriaContactos.IdComunidad) = '" + idComunidad + "'))";
            grupos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewOrganos.DataSource = grupos;

            if (dataGridViewOrganos.Rows.Count > 0 )
            {
                dataGridViewOrganos.Columns["IdGrupo"].Visible = false;
                dataGridViewOrganos.Columns["FBaja"].Width = 90;
                dataGridViewOrganos.Columns["FBaja"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridViewOrganos.Columns["FBaja"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void cargarGruposBloque()
        {
            String sqlSelect = "SELECT exp_categoriaContactos.IdGrupo, exp_categoriaContactos.Nombre, com_bloques.Descripcion AS Bloque, DATE_FORMAT(Coalesce(exp_categoriaContactos.FBaja, 'ok'), '%d/%m/%Y') AS FBaja FROM exp_categoriaContactos LEFT JOIN com_bloques ON exp_categoriaContactos.IdBloque = com_bloques.IdBloque WHERE (((exp_categoriaContactos.IdComunidad) = '" + idComunidad + "') AND (exp_categoriaContactos.IdBloque = '" + idBloque + "'))";
            grupos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewOrganos.DataSource = grupos;

            if (dataGridViewOrganos.Rows.Count > 0)
            {
                dataGridViewOrganos.Columns["IdGrupo"].Visible = false;
                dataGridViewOrganos.Columns["FBaja"].Width = 90;
                dataGridViewOrganos.Columns["FBaja"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridViewOrganos.Columns["FBaja"].SortMode = DataGridViewColumnSortMode.NotSortable;
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
            nueva.ControlBox = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
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
            nueva.ControlBox = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
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

        private void buttonSelBloque_Click(object sender, EventArgs e)
        {
            Tareas.FormSeleccionarBloque nueva = new Tareas.FormSeleccionarBloque(this, idComunidad);
            nueva.Show();
        }

        public void recibirBloque(String idBloque, String bloque)
        {
            textBoxBloque.Text = bloque;
            this.idBloque = idBloque;

            cargarGruposBloque();
        }

        private void textBoxOrgano_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBoxBloque.Text = "";
            this.idBloque = null;
            cargarGrupos();
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            formAnt.recibirGrupo(dataGridViewOrganos.Rows[0].Cells[0].Value.ToString(), dataGridViewOrganos.Rows[0].Cells[1].Value.ToString());
            this.Close();
        }
    }
}
