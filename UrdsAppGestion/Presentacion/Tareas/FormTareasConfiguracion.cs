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
        DataTable addGestion;
        String idTipoTarea;

        int order;
        public FormTareasConfiguracion()
        {
            InitializeComponent();
        }

        private void FormTareasConfiguracion_Load(object sender, EventArgs e)
        {   
            cargarTiposTarea();
            cargarTodosTipoGestion();
            order = 1;
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
            cambioTarea();
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

        private void buttonSubir_Click(object sender, EventArgs e)
        {
            if (dataGridViewAddGestion.SelectedRows.Count > 0)
            {
                if (addGestion == null)
                {

                    int mover = dataGridViewAddGestion.Rows.IndexOf(dataGridViewAddGestion.SelectedRows[0]);
                    if (mover == 0) return;
                    int movida = mover - 1;
                    DataGridViewRow RowMover = dataGridViewAddGestion.SelectedRows[0];
                    DataGridViewRow RowMovida = dataGridViewAddGestion.Rows[movida];
                    int ordenMover = Int32.Parse(RowMover.Cells[4].Value.ToString());
                    int ordenMovida = Int32.Parse(RowMovida.Cells[4].Value.ToString());
                    dataGridViewAddGestion.Rows.RemoveAt(movida);
                    dataGridViewAddGestion.Rows.RemoveAt(movida);
                    dataGridViewAddGestion.Rows.Insert(movida, RowMover);
                    dataGridViewAddGestion.Rows.Insert(mover, RowMovida);
                    dataGridViewAddGestion.Rows[movida].Cells[4].Value = ordenMovida;
                    dataGridViewAddGestion.Rows[mover].Cells[4].Value = ordenMover;
                    dataGridViewAddGestion.ClearSelection();
                    dataGridViewAddGestion.Rows[movida].Selected = true;
                }
                else
                {

                    int mover = dataGridViewAddGestion.Rows.IndexOf(dataGridViewAddGestion.SelectedRows[0]);
                    if (mover == 0) return;
                    int movida = mover - 1;
                    DataGridViewRow RowMover = dataGridViewAddGestion.SelectedRows[0];
                    DataGridViewRow RowMovida = dataGridViewAddGestion.Rows[movida];
                    int ordenMover = Int32.Parse(RowMover.Cells[4].Value.ToString());
                    int ordenMovida = Int32.Parse(RowMovida.Cells[4].Value.ToString());
                    DataRow r1 = addGestion.Rows[mover];
                    DataRow r2 = addGestion.Rows[movida];
                    DataRow rowMover = addGestion.NewRow();
                    DataRow rowMovida = addGestion.NewRow();
                    rowMover.ItemArray = r1.ItemArray;
                    rowMovida.ItemArray = r2.ItemArray;
                    rowMover["Orden"] = ordenMovida;
                    rowMovida["Orden"] = ordenMover;
                    addGestion.Rows.RemoveAt(movida);
                    addGestion.Rows.RemoveAt(movida);
                    addGestion.Rows.InsertAt(rowMovida, mover);
                    addGestion.Rows.InsertAt(rowMover, movida);
                    dataGridViewAddGestion.Refresh();
                    ajustardataGridViewAddGestion();
                    actualizarMovimiento(movida);
                }
            }
        }

        private void buttonBajar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAddGestion.SelectedRows.Count > 0)
            {
                if (addGestion == null)
                {
                    int mover = dataGridViewAddGestion.Rows.IndexOf(dataGridViewAddGestion.SelectedRows[0]);
                    if (mover == dataGridViewAddGestion.Rows.Count - 1) return;
                    int movida = mover + 1;
                    DataGridViewRow RowMover = dataGridViewAddGestion.SelectedRows[0];
                    DataGridViewRow RowMovida = dataGridViewAddGestion.Rows[movida];
                    int ordenMover = Int32.Parse(RowMover.Cells[4].Value.ToString());
                    int ordenMovida = Int32.Parse(RowMovida.Cells[4].Value.ToString());
                    dataGridViewAddGestion.Rows.RemoveAt(mover);
                    dataGridViewAddGestion.Rows.RemoveAt(mover);
                    dataGridViewAddGestion.Rows.Insert(mover, RowMovida);
                    dataGridViewAddGestion.Rows.Insert(movida, RowMover);
                    dataGridViewAddGestion.Rows[movida].Cells[4].Value = ordenMovida;
                    dataGridViewAddGestion.Rows[mover].Cells[4].Value = ordenMover;
                    dataGridViewAddGestion.ClearSelection();
                    dataGridViewAddGestion.Rows[movida].Selected = true;
                }
                else
                {
                    int mover = dataGridViewAddGestion.Rows.IndexOf(dataGridViewAddGestion.SelectedRows[0]);
                    if (mover == dataGridViewAddGestion.Rows.Count - 1) return;
                    int movida = mover + 1;
                    DataGridViewRow RowMover = dataGridViewAddGestion.SelectedRows[0];
                    DataGridViewRow RowMovida = dataGridViewAddGestion.Rows[movida];
                    int ordenMover = Int32.Parse(RowMover.Cells[4].Value.ToString());
                    int ordenMovida = Int32.Parse(RowMovida.Cells[4].Value.ToString());
                    DataRow r1 = addGestion.Rows[mover];
                    DataRow r2 = addGestion.Rows[movida];
                    DataRow rowMover = addGestion.NewRow();
                    DataRow rowMovida = addGestion.NewRow();
                    rowMover.ItemArray = r1.ItemArray;
                    rowMovida.ItemArray = r2.ItemArray;
                    rowMover["Orden"] = ordenMovida;
                    rowMovida["Orden"] = ordenMover;
                    addGestion.Rows.RemoveAt(mover);
                    addGestion.Rows.RemoveAt(mover);
                    addGestion.Rows.InsertAt(rowMover, movida);
                    addGestion.Rows.InsertAt(rowMovida, mover);
                    dataGridViewAddGestion.Refresh();
                    ajustardataGridViewAddGestion();
                    actualizarMovimiento(movida);
                }
            }
        }

        private void buttonAddGestion_Click(object sender, EventArgs e)
        {
            if (dataGridViewAllGestion.SelectedCells.Count > 0)
            {
                addTipoGestionATipo();
            }
        }

        private void buttonRemoveGestion_Click(object sender, EventArgs e)
        {
            if (dataGridViewAddGestion.SelectedCells.Count > 0)
            {
                quitarTipoGestion();
            }
        }

        private void quitarTipoGestion()
        {
            String sqlDelete = "DELETE FROM exp_gestionEstado WHERE IdTipoGestion = " + dataGridViewAddGestion.SelectedRows[0].Cells[0].Value.ToString();
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
            dataGridViewAddGestion.Rows.RemoveAt(dataGridViewAddGestion.SelectedRows[0].Index);
            order--;
            reordenarAddGestion();
        }

        private void reordenarAddGestion()
        {
            int[] ordenes = new int[20];
            int ultimo = 0;
            foreach (DataGridViewRow row in dataGridViewAddGestion.Rows)
            {
                int value = Int32.Parse(row.Cells["Orden"].Value.ToString());
                ordenes[value] = 1;
                if (value > ultimo) ultimo = value;
            }
            for (int i = 1; i <= ultimo; i++)
            {
                if (ordenes[i] != 1)
                {
                    for (int j = i; j < ultimo; j++)
                    {
                        dataGridViewAddGestion.Rows[j - 1].Cells["Orden"].Value = j;
                    }
                    if (i == ultimo - 1)
                    {
                        dataGridViewAddGestion.Rows[i - 1].Cells["Orden"].Value = i;
                    }
                    break;
                }
            }
        }

        private void addTipoGestionATipo()
        {

            String sqlInsert = "INSERT INTO exp_gestionEstado (IdTipoTarea,IdTipoGestion,Orden) VALUES ('" + idTipoTarea + "','" + dataGridViewAllGestion.SelectedRows[0].Cells[0].Value.ToString() + "','" + order + "')";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            
            dataGridViewAddGestion.AllowUserToAddRows = true;
            //SI EL DATAGRID ESTÁ VACÍO CREA LAS COLUMNAS ANTES DE AÑADIR
            if (dataGridViewAddGestion.Columns.Count == 0)
            {
                foreach (DataGridViewColumn col in dataGridViewAllGestion.Columns)
                {
                    dataGridViewAddGestion.Columns.Add(col.Clone() as DataGridViewColumn);
                }
                ajustardataGridViewAddGestion();
            }
            if (!yaAñadida())
            {
                if (addGestion == null)
                {
                    //CLONA LA LÍNEA SELECCIONADA PARA AÑADIR EN EL GRUPO
                    DataGridViewRow row = new DataGridViewRow();
                    row = (DataGridViewRow)dataGridViewAllGestion.SelectedRows[0].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dataGridViewAllGestion.SelectedRows[0].Cells)
                    {
                        if (intColIndex == 4)
                        {
                            row.Cells[intColIndex].Value = order;
                        }
                        else
                        {
                            row.Cells[intColIndex].Value = cell.Value;
                        }
                        intColIndex++;
                    }
                    dataGridViewAddGestion.Rows.Add(row);
                    dataGridViewAddGestion.Refresh();
                    ajustardataGridViewAddGestion();
                    order++;
                }
                else
                {
                    DataTable table = dataGridViewAllGestion.DataSource as DataTable;
                    DataRow row = table.NewRow();
                    row = ((DataRowView)dataGridViewAllGestion.SelectedRows[0].DataBoundItem).Row;
                    row[4] = order;
                    DataRow newRow = addGestion.NewRow();
                    newRow.ItemArray = row.ItemArray.Clone() as object[];
                    addGestion.Rows.Add(newRow);
                    dataGridViewAddGestion.Refresh();
                    ajustardataGridViewAddGestion();
                    order++;
                }
            }
            dataGridViewAddGestion.AllowUserToAddRows = false;

        }

        private Boolean yaAñadida()
        {
            for (int i = 0; i < dataGridViewAddGestion.Rows.Count; i++)
            {
                if (dataGridViewAddGestion.Rows[i].Cells[0].Value != null)
                {
                    if (dataGridViewAddGestion.Rows[i].Cells[0].Value.ToString() == dataGridViewAllGestion.SelectedRows[0].Cells[0].Value.ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void ajustardataGridViewAddGestion()
        {
            if (dataGridViewAddGestion.Rows.Count > 0)
            {
                dataGridViewAddGestion.Columns["IdTipoGestion"].Visible = false;
                dataGridViewAddGestion.Columns["Descripcion"].Width = 130;
                dataGridViewAddGestion.Columns["Perfil"].Width = 90;
                dataGridViewAddGestion.Columns["Días"].Width = 40;
                dataGridViewAddGestion.Columns["Orden"].Visible = true;
                dataGridViewAddGestion.Columns["Orden"].Width = 40;
            }
        }


        private void actualizarMovimiento(int movimiento)
        {
            String sqlBorrar = "DELETE FROM exp_gestionEstado WHERE IdTipoTarea = " + idTipoTarea;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
            foreach (DataGridViewRow row in dataGridViewAddGestion.Rows)
            {
                String idTipoTarea = this.idTipoTarea;
                String idTipoGestion = row.Cells[0].Value.ToString();
                String orden = row.Cells[4].Value.ToString();
                String sqlInsert = "INSERT INTO exp_gestionEstado (IdTipoTarea,IdTipoGestion,Orden) VALUES ('" + idTipoTarea + "','" + idTipoGestion + "','" + orden + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert).ToString();
            }
            cargarTipoTarea();
            dataGridViewAddGestion.ClearSelection();
            dataGridViewAddGestion.Rows[movimiento].Selected = true;
        }

        private void cargarTipoTarea()
        {
            String sqlSelect = "SELECT exp_tipogestion.IdTipoGestion, exp_tipogestion.Descripcion, ctos_gruposurd.Grupo AS Perfil, exp_tipogestion.Plazo AS Días, exp_gestionEstado.Orden FROM(exp_tipogestion INNER JOIN(exp_tipostareas INNER JOIN exp_gestionEstado ON exp_tipostareas.IdTipoTarea = exp_gestionEstado.IdTipoTarea) ON exp_tipogestion.IdTipoGestion = exp_gestionEstado.IdTipoGestion) INNER JOIN ctos_gruposurd ON exp_tipogestion.IdGrupo = ctos_gruposurd.IdGrupoURD WHERE(((exp_tipostareas.IdTipoTarea) = " + idTipoTarea + ")) ORDER BY exp_gestionEstado.Orden";
            addGestion = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewAddGestion.DataSource = addGestion;
            dataGridViewAddGestion.Sort(dataGridViewAddGestion.Columns["Orden"], ListSortDirection.Ascending);
            ajustardataGridViewAddGestion();
            order = addGestion.Rows.Count + 1;
        }

        private void cambioTarea()
        {
            this.idTipoTarea = dataGridViewTipoTarea.SelectedRows[0].Cells[0].Value.ToString();
            labelName.Text = dataGridViewTipoTarea.SelectedRows[0].Cells[1].Value.ToString();
            order = 0;
            cargarTipoTarea();
        }

        private void dataGridViewAddGestion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAddGestion.SelectedCells.Count > 0)
            {
                quitarTipoGestion();
            }
        }

        private void dataGridViewAllGestion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAllGestion.SelectedCells.Count > 0)
            {
                addTipoGestionATipo();
            }
        }

        private void textBoxFiltroGestiones_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = allGestion;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroGestiones.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewAllGestion.DataSource = busqueda;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
