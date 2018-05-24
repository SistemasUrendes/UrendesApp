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
    public partial class FormInsertarTipoTarea : Form
    {
        FormTareasConfiguracion form;
        String idTipoTarea;
        DataTable allGestion;
        DataTable addGestion;
        int order;
        String nombre;
        public FormInsertarTipoTarea(FormTareasConfiguracion form, String idTipoTarea, String nombre)
        {
            InitializeComponent();
            this.form = form;
            this.idTipoTarea = idTipoTarea;
            this.nombre = nombre;
        }

        public FormInsertarTipoTarea(FormTareasConfiguracion form)
        {
            InitializeComponent();
            this.form = form;
            order = 1;
        }

        private void FormInsertarTipoTarea_Load(object sender, EventArgs e)
        {
            if (idTipoTarea != null)
            {
                cargarTipoTarea();
                textBoxNombre.Visible = false;
                label2.Visible = false;
                labelName.Text = nombre;
            }
            cargarTodosTipoGestion();
        }

        private void cargarTodosTipoGestion()
        {
            String sqlSelect = "SELECT exp_tipogestion.IdTipoGestion, exp_tipogestion.Descripcion, ctos_gruposurd.Grupo AS Perfil, exp_tipogestion.Plazo AS Días, '0' AS `Orden` FROM exp_tipogestion LEFT JOIN ctos_gruposurd ON exp_tipogestion.IdGrupo = ctos_gruposurd.IdGrupoURD";
            //String sqlSelect = "SELECT exp_tipogestion.IdTipoGestion, exp_tipogestion.Descripcion, exp_tipogestion.Plazo AS Días, '0' AS `Orden` FROM exp_tipogestion";
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

        private void cargarTipoTarea()
        {
            //String sqlSelect = "SELECT exp_tipogestion.IdTipoGestion, exp_tipogestion.Descripcion, exp_tipogestion.Plazo AS Días, exp_gestionEstado.Orden FROM exp_tipogestion INNER JOIN (exp_tipostareas INNER JOIN exp_gestionEstado ON exp_tipostareas.IdTipoTarea = exp_gestionEstado.IdTipoTarea) ON exp_tipogestion.IdTipoGestion = exp_gestionEstado.IdTipoGestion WHERE(((exp_tipostareas.IdTipoTarea) = " + idTipoTarea + ")) ORDER BY exp_gestionEstado.Orden";
            String sqlSelect = "SELECT exp_tipogestion.IdTipoGestion, exp_tipogestion.Descripcion, ctos_gruposurd.Grupo AS Perfil, exp_tipogestion.Plazo AS Días, exp_gestionEstado.Orden FROM(exp_tipogestion INNER JOIN(exp_tipostareas INNER JOIN exp_gestionEstado ON exp_tipostareas.IdTipoTarea = exp_gestionEstado.IdTipoTarea) ON exp_tipogestion.IdTipoGestion = exp_gestionEstado.IdTipoGestion) INNER JOIN ctos_gruposurd ON exp_tipogestion.IdGrupo = ctos_gruposurd.IdGrupoURD WHERE(((exp_tipostareas.IdTipoTarea) = " + idTipoTarea + ")) ORDER BY exp_gestionEstado.Orden";
            addGestion = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewAddGestion.DataSource = addGestion;
            dataGridViewAddGestion.Sort(dataGridViewAddGestion.Columns["Orden"], ListSortDirection.Ascending);
            ajustardataGridViewAddGestion();
            order = addGestion.Rows.Count + 1;
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
            dataGridViewAddGestion.Rows.RemoveAt(dataGridViewAddGestion.SelectedRows[0].Index);
            order--;
            reordenarAddGestion();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (idTipoTarea == null)
            {
                if (textBoxNombre.Text == "")
                {
                    MessageBox.Show("Introduce el nombre del Tipo de Tarea");
                    textBoxNombre.Focus();
                    textBoxNombre.SelectAll();
                    return;
                }
                String sqlInsert = "INSERT INTO exp_tipostareas (TipoTarea) VALUES ('" + textBoxNombre.Text.ToString() + "')";
                idTipoTarea = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
            }
            else
            {
                String sqlBorrar = "DELETE FROM exp_gestionEstado WHERE IdTipoTarea = " + idTipoTarea;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
            }
            foreach (DataGridViewRow row in dataGridViewAddGestion.Rows)
            {
                String idTipoTarea = this.idTipoTarea;
                String idTipoGestion = row.Cells[0].Value.ToString();
                String orden = row.Cells[4].Value.ToString();
                String sqlInsert = "INSERT INTO exp_gestionEstado (IdTipoTarea,IdTipoGestion,Orden) VALUES ('" + idTipoTarea + "','" + idTipoGestion + "','" + orden + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert).ToString();

            }

            if (nombre != null) MessageBox.Show("Tipo de Tarea actualizado correctamente");
            else
            {
                MessageBox.Show("Tipo de Tarea añadido correctamente");
                form.cargarTiposTarea();
            }
            cargarTipoTarea();

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
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxFiltroGestiones_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = allGestion;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroGestiones.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewAllGestion.DataSource = busqueda;
        }

        private void addTipoGestionATipo()
        {
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

        /*
        private Boolean comprobarOrden()
        {
            //POR IMPLEMENTAR
            int [] ordenes = new int[20];
            int ultimo = 0;
            foreach (DataGridViewRow row in dataGridViewAddGestion.Rows)
            {
                int value = Int32.Parse(row.Cells["Orden"].Value.ToString());
                ordenes[value] = 1;
                if (value > ultimo) ultimo = value;
            }
            for ( int i = 1; i <= ultimo; i ++)
            {
                if (ordenes[i] != 1)
                {
                    return false;
                }
            }
            return true;
        }
        */
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
    }
}
