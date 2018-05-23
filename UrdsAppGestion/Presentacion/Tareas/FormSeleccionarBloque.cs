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
        String idTarea;
        FormVerTarea form_anterior1;
        FormInsertarServicioTarea form_anterior2;
        FormTareasPrincipal form_anterior3;

        public FormSeleccionarBloque(FormVerTarea form_anterior1, String idComunidad, String idTarea)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idTarea = idTarea;
            this.form_anterior1 = form_anterior1;
        }

        public FormSeleccionarBloque(FormVerTarea form_anterior1,String idTarea)
        {
            InitializeComponent();
            this.idTarea = idTarea;
            this.form_anterior1 = form_anterior1;
        }

        public FormSeleccionarBloque(FormInsertarServicioTarea form_anterior2, String idTarea)
        {
            InitializeComponent();
            this.idTarea = idTarea;
            this.form_anterior2 = form_anterior2;
        }
        
        public FormSeleccionarBloque(FormTareasPrincipal form_anterior3, String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.form_anterior3 = form_anterior3;
        }

        private void FormSeleccionarBloque_Load(object sender, EventArgs e)
        {
            cargarBloques();
            if (idComunidad == null && form_anterior2 == null)
            {
                buttonEnviar.Visible = false;
            }
        }

        private void cargarBloques()
        {
            String sqlSelect = "";
            if (idComunidad == null)
            {
                sqlSelect = "SELECT exp_area.IdBloque, exp_area.Nombre AS Descripcion,'true' AS Selected FROM exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea WHERE(((exp_area.IdAreaPrevio) = 0) AND((exp_areaTarea.IdTarea) = " + idTarea + "))";
            }
            else if(idTarea == null)
            {
                sqlSelect = "SELECT exp_area.IdArea AS IdBloque, exp_area.Nombre,'true' AS Selected FROM com_comunidades INNER JOIN (exp_area INNER JOIN com_bloques ON exp_area.IdBloque = com_bloques.IdBloque) ON com_comunidades.IdComunidad = com_bloques.IdComunidad WHERE(((com_comunidades.IdComunidad) = " + idComunidad + ") AND((exp_area.IdAreaPrevio) = 0) AND((com_bloques.Baja) = 0))";
            }
            else
            {
                sqlSelect = "SELECT com_bloques.IdBloque, com_bloques.Descripcion, If((SELECT Count(*)FROM exp_area INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((exp_area.IdAreaPrevio) = 0) AND((exp_areaTarea.IdTarea) = " + idTarea + ") AND((exp_area.IdBloque) = com_bloques.IdBloque))) > 0,'true','false') AS Selected FROM com_bloques WHERE(((com_bloques.IdTipoBloque) = 1) AND((com_bloques.IdComunidad) = " + idComunidad + "))";
            }
            tablaBloques = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewBloques.DataSource = tablaBloques;
            
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Sel";
            checkColumn.HeaderText = "Sel";
            checkColumn.Width = 50;
            if (idComunidad != null) checkColumn.ReadOnly = false;
            else checkColumn.ReadOnly = true;
            checkColumn.FillWeight = 10;
            dataGridViewBloques.Columns.Add(checkColumn);

            ajustarDataGrid();
        }

        private void textBoxFiltroBloque_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = tablaBloques;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroBloque.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewBloques.DataSource = busqueda;
            ajustarDataGrid();
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            if (form_anterior1 != null && idComunidad != null) guardarBloques();
            else enviarbloque();
        }

        private void dataGridViewBloques_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int indiceTabla(String idBloque)
        {
            int i = 0;
            foreach( DataRow row in tablaBloques.Rows)
            {
                if (row[0].ToString() == idBloque) return i;
                i++;
            }
            return -1;
        }

        private void ajustarDataGrid()
        {
            if (dataGridViewBloques.Rows.Count > 0)
            {
                dataGridViewBloques.Columns[0].Visible = false;
                dataGridViewBloques.Columns[1].Width = 330;
                dataGridViewBloques.Columns["Selected"].Visible = false;
                dataGridViewBloques.Columns["Sel"].Width = 50;

                dataGridViewBloques.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewBloques.Columns["Sel"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewRow row in dataGridViewBloques.Rows)
            {
                row.Cells["Sel"].Value = row.Cells["Selected"].Value;
            }
        }

        private void guardarBloques()
        {
            String sqlBorrar = "DELETE FROM exp_areaTarea WHERE IdTarea = " + idTarea;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
            

            foreach (DataRow row in tablaBloques.Rows)
            {
                if (row["Selected"].ToString() == "true")
                {
                    String sqlInsert = "INSERT INTO exp_areaTarea (IdArea,IdTarea) VALUES ('" + idAreaBloque(row[0].ToString()) + "','" + idTarea + "')";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
            }
            form_anterior1.cargarBloque();
            this.Close();
        }

        private String idAreaBloque(String idBloque)
        {
            String sqlSelect = "SELECT IdArea FROM exp_area WHERE idBloque = " + idBloque + " AND IdAreaPrevio = 0";
            return Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
        }

        private void enviarbloque()
        {
            if (form_anterior2 != null) form_anterior2.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
            if (form_anterior3 != null) form_anterior3.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
            this.Close();
        }
        

        private void dataGridViewBloques_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (form_anterior1 != null) guardarBloques();
                else if (form_anterior2 != null) form_anterior2.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
                else if (form_anterior3 != null) form_anterior3.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
                this.Close();
            }
            if (e.KeyCode == Keys.Space)
            {
                if (idComunidad != null && idTarea != null)
                {
                    if (dataGridViewBloques.SelectedRows[0].Index > -1)
                    {
                        if (dataGridViewBloques.SelectedRows[0].Cells["Sel"].Value.ToString() == "false")
                        {
                            dataGridViewBloques.SelectedRows[0].Cells["Sel"].Value = "true";
                            tablaBloques.Rows[indiceTabla(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString())]["Selected"] = "true";
                        }
                        else if (dataGridViewBloques.SelectedRows[0].Cells["Sel"].Value.ToString() == "true")
                        {
                            dataGridViewBloques.SelectedRows[0].Cells["Sel"].Value = "false";
                            tablaBloques.Rows[indiceTabla(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString())]["Selected"] = "false";
                        }
                    }
                }
            }
        }

        private void dataGridViewBloques_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (idComunidad != null && idTarea != null)
            {
                if (dataGridViewBloques.SelectedRows[0].Index > -1)
                {
                    if (dataGridViewBloques.SelectedRows[0].Cells["Sel"].Value.ToString() == "false")
                    {
                        dataGridViewBloques.SelectedRows[0].Cells["Sel"].Value = "true";
                        tablaBloques.Rows[indiceTabla(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString())]["Selected"] = "true";
                    }
                    else if (dataGridViewBloques.SelectedRows[0].Cells["Sel"].Value.ToString() == "true")
                    {
                        dataGridViewBloques.SelectedRows[0].Cells["Sel"].Value = "false";
                        tablaBloques.Rows[indiceTabla(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString())]["Selected"] = "false";
                    }
                }
            }
            if (form_anterior2 != null)
            {
                form_anterior2.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
                this.Close();
            }
            if (form_anterior3 != null)
            {
                form_anterior3.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
                this.Close();
            }

        }
    }

}
