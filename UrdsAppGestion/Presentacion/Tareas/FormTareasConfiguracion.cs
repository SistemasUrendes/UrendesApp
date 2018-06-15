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
        DataTable tipoTarea;
        DataTable allGestion;

        public FormTareasConfiguracion()
        {
            InitializeComponent();
        }

        private void FormTareasConfiguracion_Load(object sender, EventArgs e)
        {
            cargarTiposTarea();
            cargarTodosTipoGestion();
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

        private void dataGridViewTipoTarea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //labelName.Text = "";
        }

        private void cargarTodosTipoGestion()
        {
            String sqlSelect = "SELECT exp_tipogestion.IdTipoGestion, exp_tipogestion.Descripcion, ctos_gruposurd.Grupo AS Perfil, exp_tipogestion.Plazo AS Días, '0' AS `Orden` FROM exp_tipogestion LEFT JOIN ctos_gruposurd ON exp_tipogestion.IdGrupo = ctos_gruposurd.IdGrupoURD";
            allGestion = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewAllGestion.DataSource = allGestion;

            if (dataGridViewAllGestion.Rows.Count > 0)
            {
                dataGridViewAllGestion.Columns["IdTipoGestion"].Visible = false;
                dataGridViewAllGestion.Columns["Descripcion"].Width = 170;
                dataGridViewAllGestion.Columns["Perfil"].Width = 90;
                dataGridViewAllGestion.Columns["Días"].Width = 40;
                dataGridViewAllGestion.Columns["Orden"].Visible = false;
            }
        }
    }
}
