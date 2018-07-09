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
    public partial class FormAreasBloque : Form
    {
        FormServiciosConfiguracion form_anterior;
        String idBloque;
        String nombreBloque;
        DataTable areasTabla;
        DataTable bloqueTabla;

        public FormAreasBloque(FormServiciosConfiguracion form_anterior, String idBloque, String nombreBloque)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idBloque = idBloque;
            this.nombreBloque = nombreBloque;
        }

        private void FormAreasBloque_Load(object sender, EventArgs e)
        {
            cargarBloque();
            cargarAreas();
        }

        private void cargarAreas()
        {
            String sqlSelect = "SELECT IdCatElemento,Nombre, Descripcion FROM exp_catElemento";
            areasTabla = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewAllAreas.DataSource = areasTabla;
            if (dataGridViewAllAreas.Rows.Count > 0)
            {
                dataGridViewAllAreas.Columns["IdCatElemento"].Visible = false;
                dataGridViewAllAreas.Columns["Nombre"].Width = 100;
                dataGridViewAllAreas.Columns["Descripcion"].Width = 190;
            }
        }

        private void cargarBloque()
        {
            String sqlSelect = "SELECT IdArea, Nombre, Descripcion FROM exp_area WHERE IdBloque = '" + idBloque + "' AND IdAreaPrevio > 0";
            bloqueTabla = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewAddArea.DataSource = bloqueTabla;
            if (dataGridViewAddArea.Rows.Count > 0)
            {
                dataGridViewAddArea.Columns["IdArea"].Visible = false;
                dataGridViewAddArea.Columns["Nombre"].Width = 100;
                dataGridViewAddArea.Columns["Descripcion"].Width = 190;
            }
        }

        private void buttonAddArea_Click(object sender, EventArgs e)
        {
            if (dataGridViewAllAreas.SelectedRows.Count > 0)
            {
                addAreaABloque();
            }
        }

        private void buttonRemoveArea_Click(object sender, EventArgs e)
        {
            if (dataGridViewAddArea.SelectedRows.Count > 0)
            {
                quitarArea();
            }
        }

        private void textBoxFiltroAreas_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = areasTabla;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroAreas.Text.ToString() + "%' OR Nombre like '%" + textBoxFiltroAreas.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewAllAreas.DataSource = busqueda;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT exp_area.IdArea FROM exp_area WHERE(((exp_area.IdBloque) = '" + idBloque + "'))";
            DataTable oldBloque = Persistencia.SentenciasSQL.select(sqlSelect);
            
            foreach (DataRow row in oldBloque.Rows)
            {
                String sqlBorrar = "DELETE FROM exp_area WHERE IdArea = " + row[0];
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
            }
            String sqlInsertBloque = "INSERT INTO exp_area (IdAreaPrevio,IdBloque,Nombre,Descripcion) VALUES (0,'" + idBloque + "','" + nombreBloque + "','Bloque físico')";
            int idArea = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertBloque);
            foreach (DataGridViewRow row in dataGridViewAddArea.Rows)
            {
                String sqlInsert = "INSERT INTO exp_area (IdAreaPrevio,IdBloque,Nombre,Descripcion) VALUES ('" + idArea + "','" + idBloque + "','" + row.Cells[1].Value + "','" + row.Cells[2].Value + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
            MessageBox.Show("Areas del bloque actualizadas correctamente");
            this.Close();
        }

        private void addAreaABloque()
        {
            dataGridViewAddArea.AllowUserToAddRows = true;
            //SI EL DATAGRID ESTÁ VACÍO CREA LAS COLUMNAS ANTES DE AÑADIR
            if (dataGridViewAddArea.Columns.Count == 0)
            {
                foreach (DataGridViewColumn col in dataGridViewAllAreas.Columns)
                {
                    dataGridViewAddArea.Columns.Add(col.Clone() as DataGridViewColumn);
                }
            }
            if (!yaAñadida())
            {
                if (bloqueTabla == null)
                {
                    //CLONA LA LÍNEA SELECCIONADA PARA AÑADIR EN EL GRUPO
                    DataGridViewRow row = new DataGridViewRow();
                    row = (DataGridViewRow)dataGridViewAllAreas.SelectedRows[0].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dataGridViewAllAreas.SelectedRows[0].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dataGridViewAddArea.Rows.Add(row);
                    dataGridViewAddArea.Refresh();
                }
                else
                {
                    DataTable table = dataGridViewAllAreas.DataSource as DataTable;
                    DataRow row = table.NewRow();
                    row = ((DataRowView)dataGridViewAllAreas.SelectedRows[0].DataBoundItem).Row;
                    DataRow newRow = bloqueTabla.NewRow();
                    newRow.ItemArray = row.ItemArray.Clone() as object[];
                    bloqueTabla.Rows.Add(newRow);
                    dataGridViewAddArea.Refresh();
                }
            }
            dataGridViewAddArea.AllowUserToAddRows = false;

        }

        private Boolean yaAñadida()
        {
            for (int i = 0; i < dataGridViewAddArea.Rows.Count; i++)
            {
                if (dataGridViewAddArea.Rows[i].Cells[0].Value != null)
                {
                    if (dataGridViewAddArea.Rows[i].Cells[0].Value.ToString() == dataGridViewAllAreas.SelectedRows[0].Cells[0].Value.ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void dataGridViewAllAreas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAllAreas.SelectedRows.Count > 0)
            {
                addAreaABloque();
            }
        }

        private void quitarArea()
        {
            dataGridViewAddArea.Rows.RemoveAt(dataGridViewAddArea.SelectedRows[0].Index);
        }

        private void dataGridViewAddArea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAddArea.SelectedRows.Count > 0)
            {
                quitarArea();
            }
        }


    }
}
