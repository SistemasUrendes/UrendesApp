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
    public partial class FormInsertarServicioTarea : Form
    {
        private DataTable tablaFinalServicios;
        private DataTable tablaBloque;
        private FormVerTarea formAnt;
        private String idTarea;

        public FormInsertarServicioTarea(FormVerTarea formAnt , String idTarea)
        {
            InitializeComponent();
            this.formAnt = formAnt;
            this.idTarea = idTarea;
        }

        private void FormInsertarServicioTarea_Load(object sender, EventArgs e)
        {
            cargarBloques();
            cargarServicios();
            this.KeyPreview = true;
            if (Login.getRol() == "Admin")
            {
                buttonAddServicio.Visible = true;
            }
            else
            {
                buttonAddServicio.Visible = false;
            }
        }
        
        private void cargarServicios()
        {
            DataTable tablaServicios = null;
            tablaFinalServicios = null;
            foreach (DataRow row in tablaBloque.Rows)
            {

                String idAreaBloque = row[0].ToString();
                String nombreBloque = row[2].ToString();

                String sqlSelect = "SELECT exp_area.IdArea,'" + nombreBloque + "' AS Bloque,exp_area.Nombre AS Categoría, exp_area.Nombre AS Nombre ,exp_area_1.Nombre AS Previo,If((SELECT Count(*)FROM exp_areaTarea WHERE (((exp_areaTarea.IdArea)=exp_area.IdArea) AND ((exp_areaTarea.IdTarea)= " + idTarea + "))) > 0,'true','false') AS Selected FROM exp_area INNER JOIN exp_area AS exp_area_1 ON exp_area.IdAreaPrevio = exp_area_1.IdArea WHERE(((exp_area.IdAreaPrevio) = " + idAreaBloque + "))";
                tablaServicios = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tablaFinalServicios == null) tablaFinalServicios = tablaServicios.Copy();
                else tablaFinalServicios.Merge(tablaServicios);

                foreach (DataRow rowSub in tablaServicios.Rows)
                {
                    DataTable subServicios = null;
                    String sqlSelectSub = "SELECT exp_area.IdArea, '" + nombreBloque + "' AS Bloque,'" + rowSub[2] + "' AS Categoría, exp_area.Nombre AS Nombre ,exp_area_1.Nombre AS Previo,If((SELECT Count(*)FROM exp_areaTarea WHERE (((exp_areaTarea.IdArea)=exp_area.IdArea) AND ((exp_areaTarea.IdTarea)= " + idTarea + "))) > 0,'true','false') AS Selected FROM exp_area INNER JOIN exp_area AS exp_area_1 ON exp_area.IdAreaPrevio = exp_area_1.IdArea WHERE(((exp_area.IdAreaPrevio) = " + rowSub[0] + "))";
                    subServicios = Persistencia.SentenciasSQL.select(sqlSelectSub);
                    if (subServicios.Rows.Count > 0) tablaFinalServicios.Merge(subServicios);

                    foreach (DataRow rowSub2 in subServicios.Rows)
                    {
                        DataTable subServicios2 = null;
                        String sqlSelectSub2 = "SELECT exp_area.IdArea,'" + nombreBloque + "' AS Bloque,'" + rowSub[2] + "' AS Categoría, exp_area.Nombre AS Nombre ,exp_area_1.Nombre AS Previo,If((SELECT Count(*)FROM exp_areaTarea WHERE (((exp_areaTarea.IdArea)=exp_area.IdArea) AND ((exp_areaTarea.IdTarea)= " + idTarea + "))) > 0,'true','false') AS Selected FROM exp_area INNER JOIN exp_area AS exp_area_1 ON exp_area.IdAreaPrevio = exp_area_1.IdArea WHERE(((exp_area.IdAreaPrevio) = " + rowSub2[0] + "))";
                        subServicios2 = Persistencia.SentenciasSQL.select(sqlSelectSub2);
                        if (subServicios2.Rows.Count > 0 ) tablaFinalServicios.Merge(subServicios2);
                    }
                }
            }
            dataGridViewServicios.DataSource = tablaFinalServicios;

            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Sel";
            checkColumn.HeaderText = "Sel";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            checkColumn.FillWeight = 10;
            dataGridViewServicios.Columns.Add(checkColumn);

            ajustarDatagridServicios();
        }

        private void ajustarDatagridServicios()
        {
            if (dataGridViewServicios.Rows.Count > 0)
            {
                dataGridViewServicios.Columns["IdArea"].Visible = false;
                dataGridViewServicios.Columns["Nombre"].Width = 150;
                dataGridViewServicios.Columns["Previo"].Width = 150;
                dataGridViewServicios.Columns["Bloque"].Width = 100;
                dataGridViewServicios.Columns["Categoría"].Width = 150;
                dataGridViewServicios.Columns["Selected"].Visible = false;


                dataGridViewServicios.Columns["Nombre"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewServicios.Columns["Previo"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewServicios.Columns["Bloque"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewServicios.Columns["Categoría"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewServicios.Columns["Sel"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewRow row in dataGridViewServicios.Rows)
            {
                row.Cells["Sel"].Value = row.Cells["Selected"].Value;
            }
        }

        private void filtrarServicios(object sender, EventArgs e)
        {
            DataTable busqueda = tablaFinalServicios;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "";
            if (textBoxFiltroServicios.Text.ToString() != "") filtro += "Nombre like '%" + textBoxFiltroServicios.Text.ToString() + "%'";
            if (textBoxFiltroCategoria.Text.ToString() != "")
            {
                if (textBoxFiltroServicios.Text.ToString() != "") filtro += " AND ";
                filtro += "Categoría like '%" + textBoxFiltroCategoria.Text.ToString() + "%'";
            }
            if (textBoxFiltroBloque.Text.ToString() != "")
            {
                if (textBoxFiltroServicios.Text.ToString() != "" || textBoxFiltroCategoria.Text.ToString() != "") filtro += " AND ";
                filtro += "Bloque like '%" + textBoxFiltroBloque.Text.ToString() + "%'";
            }
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewServicios.DataSource = busqueda;
            ajustarDatagridServicios();
        }

        private void cargarBloques()
        {
            String sqlSelect = "SELECT exp_area.IdArea, exp_area.IdAreaPrevio, exp_area.Nombre, exp_area.Descripcion FROM exp_area INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((exp_areaTarea.IdTarea) = " + idTarea + ") AND((exp_area.IdAreaPrevio) = 0))";
            tablaBloque = Persistencia.SentenciasSQL.select(sqlSelect);
        }

        private void textBoxFiltroBloque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                FormSeleccionarBloque nueva = new FormSeleccionarBloque(this, idTarea);
                nueva.Show();
            }
        }

        private void textBoxFiltroCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                FormSeleccionarCategoria nueva = new FormSeleccionarCategoria(this, idTarea);
                nueva.Show();
            }
        }

        public void recibirBloque(String bloque)
        {
            textBoxFiltroBloque.Text = bloque;
        }

        public void recibirCategoria(String categoria)
        {
            textBoxFiltroCategoria.Text = categoria;
        }

        private void dataGridViewServicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guardarServicios();
            }
            else if (e.KeyCode == Keys.Space)
            {
                cambiarSeleccionFila();
            }
        }

        private void guardarServicios()
        {
            String sqlSelectAntiguos = "SELECT exp_areaTarea.IdAreaTarea FROM exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea WHERE(((exp_areaTarea.IdTarea) = '" + idTarea + "') AND((exp_area.IdAreaPrevio) <> 0))";
            DataTable antiguo = Persistencia.SentenciasSQL.select(sqlSelectAntiguos);

            foreach (DataRow rowAnt in antiguo.Rows)
            {
                String sqlBorrar = "DELETE FROM exp_areaTarea WHERE (exp_areaTarea.IdAreaTarea = '" + rowAnt[0].ToString() + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
            }

            foreach (DataRow row in tablaFinalServicios.Rows)
            {
                if (row["Selected"].ToString() == "true")
                {
                    String sqlInsert = "INSERT INTO exp_areaTarea (IdArea,IdTarea) VALUES ('" + row[0] + "','" + idTarea + "')";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
            }
            formAnt.cargarServicios();
            this.Close();
        }

        private void cambiarSeleccionFila()
        {
            if (dataGridViewServicios.SelectedRows[0].Index > -1)
            {
                if (dataGridViewServicios.SelectedRows[0].Cells["Sel"].Value.ToString() == "false")
                {
                    dataGridViewServicios.SelectedRows[0].Cells["Sel"].Value = "true";
                    tablaFinalServicios.Rows[indiceTabla(dataGridViewServicios.SelectedRows[0].Cells[0].Value.ToString())]["Selected"] = "true";
                }
                else if (dataGridViewServicios.SelectedRows[0].Cells["Sel"].Value.ToString() == "true")
                {
                    dataGridViewServicios.SelectedRows[0].Cells["Sel"].Value = "false";
                    tablaFinalServicios.Rows[indiceTabla(dataGridViewServicios.SelectedRows[0].Cells[0].Value.ToString())]["Selected"] = "false";
                }
            }
        }

        private int indiceTabla(String idServicio)
        {
            int i = 0;
            foreach (DataRow row in tablaFinalServicios.Rows)
            {
                if (row[0].ToString() == idServicio) return i;
                i++;
            }
            return -1;
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            guardarServicios();
        }

        private void dataGridViewServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cambiarSeleccionFila();
        }

        private void buttonAddServicio_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_comunidades.IdComunidad FROM com_comunidades INNER JOIN exp_tareas ON com_comunidades.IdEntidad = exp_tareas.IdEntidad WHERE(((exp_tareas.IdTarea) = " + idTarea + "))";
            String idComunidad = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            Tareas.FormServiciosBloque nueva = new Tareas.FormServiciosBloque(idComunidad);
            nueva.Show();
        }
    }
}
