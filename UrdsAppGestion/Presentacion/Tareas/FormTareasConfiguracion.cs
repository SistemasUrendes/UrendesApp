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
    public partial class FormTareasConfiguracion : Form
    {
        DataTable tipoGestion;
        DataTable tipoTarea;
        public FormTareasConfiguracion()
        {
            InitializeComponent();
        }

        private void FormTareasConfiguracion_Load(object sender, EventArgs e)
        {
            cargarTiposGestion();
            cargarTiposTarea();
        }

        private void buttonAddGestion_Click(object sender, EventArgs e)
        {
            Tareas.FormInsertarTipoGestion nueva = new FormInsertarTipoGestion(this);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        public void cargarTiposGestion()
        {
            String sqlSelect = "SELECT exp_tipogestion.IdTipoGestion, exp_tipogestion.Descripcion, ctos_gruposurd.Grupo, exp_tipogestion.Plazo AS Días, exp_tipogestion.HorasDeTrabajo AS 'HT' FROM exp_tipogestion LEFT JOIN ctos_gruposurd ON exp_tipogestion.IdGrupo = ctos_gruposurd.IdGrupoURD";
            tipoGestion = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewTipoGestion.DataSource = tipoGestion;

            if (dataGridViewTipoGestion.Rows.Count > 0)
            {
                dataGridViewTipoGestion.Columns["IdTipoGestion"].Visible = false;
                dataGridViewTipoGestion.Columns["Descripcion"].Width = 140;
                dataGridViewTipoGestion.Columns["Grupo"].Width = 80;
                dataGridViewTipoGestion.Columns["Días"].Width = 40;
                dataGridViewTipoGestion.Columns["HT"].Width = 30;
            }
        }

        private void dataGridViewTipoGestion_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewTipoGestion.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    dataGridViewTipoGestion.ClearSelection();
                    dataGridViewTipoGestion.Rows[hti.RowIndex].Selected = true;
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tareas.FormInsertarTipoGestion nueva = new FormInsertarTipoGestion(this, dataGridViewTipoGestion.SelectedRows[0].Cells[0].Value.ToString());
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewTipoGestion.SelectedCells.Count > 0)
            {
                string idTipoGestion = dataGridViewTipoGestion.SelectedRows[0].Cells[0].Value.ToString();

                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar este Tipo Gestión?", "Borrar Tipo Gestión", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    String sqlBorrar = "DELETE FROM exp_tipogestion WHERE IdTipoGestion = " + idTipoGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    cargarTiposGestion();
                }
            }
        }

        private void textBoxFiltroTipoGestion_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = tipoGestion;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroTipoGestion.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewTipoGestion.DataSource = busqueda;
        }

        private void buttonAddTipoTarea_Click(object sender, EventArgs e)
        {
            Tareas.FormInsertarTipoTarea nueva = new FormInsertarTipoTarea(this);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        public void cargarTiposTarea()
        {
            String sqlSelect = "SELECT exp_tipostareas.IdTipoTarea, exp_tipostareas.TipoTarea AS Descripcion FROM exp_tipostareas";
            tipoTarea = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewTipoTarea.DataSource = tipoTarea;

            if (dataGridViewTipoTarea.Rows.Count > 0)
            {
                dataGridViewTipoTarea.Columns["IdTipoTarea"].Visible = false;
                dataGridViewTipoTarea.Columns["Descripcion"].Width = 280;
            }

        }

        private void textBoxFiltroTarea_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = tipoTarea;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroTarea.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewTipoTarea.DataSource = busqueda;
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tareas.FormInsertarTipoTarea nueva = new FormInsertarTipoTarea(this, dataGridViewTipoTarea.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewTipoTarea.SelectedRows[0].Cells[1].Value.ToString());
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void borrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridViewTipoTarea.SelectedCells.Count > 0)
            {
                string idTipoTarea = dataGridViewTipoTarea.SelectedRows[0].Cells[0].Value.ToString();

                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar este Tipo de Tarea?", "Borrar Tipo Tarea", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    String sqlBorrar = "DELETE FROM exp_tipostareas WHERE IdTipoTarea = " + idTipoTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    cargarTiposTarea();
                }
            }
        }

        private void dataGridViewTipoTarea_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewTipoTarea.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    dataGridViewTipoTarea.ClearSelection();
                    dataGridViewTipoTarea.Rows[hti.RowIndex].Selected = true;
                    contextMenuStrip2.Show(Cursor.Position);
                }
            }
        }

        private void dataGridViewTipoTarea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tareas.FormInsertarTipoTarea nueva = new FormInsertarTipoTarea(this, dataGridViewTipoTarea.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewTipoTarea.SelectedRows[0].Cells[1].Value.ToString());
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void dataGridViewTipoGestion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tareas.FormInsertarTipoGestion nueva = new FormInsertarTipoGestion(this, dataGridViewTipoGestion.SelectedRows[0].Cells[0].Value.ToString());
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
    }
}
