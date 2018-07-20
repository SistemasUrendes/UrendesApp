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
        String nombreForm;
        Form form_anterior;

        public FormSeleccionarBloque(Form form_anterior,String nombreForm, String idComunidad, String idTarea)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idTarea = idTarea;
            this.form_anterior = form_anterior;
            this.nombreForm = nombreForm;
        }

        public FormSeleccionarBloque(String idTarea, Form form_anterior, String nombreForm)
        {
            InitializeComponent();
            this.idTarea = idTarea;
            this.form_anterior = form_anterior;
            this.nombreForm = nombreForm;
        }
                
        public FormSeleccionarBloque(Form form_anterior, String nombreForm, String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.form_anterior = form_anterior;
            this.nombreForm = nombreForm;
        }
        
        private void FormSeleccionarBloque_Load(object sender, EventArgs e)
        {
            cargarBloques();
            if (idComunidad == null && !nombreForm.Contains("FormInsertarServicioTarea"))
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
            else if (nombreForm.Contains("FormListadoOrganos") || nombreForm.Contains("FormNuevoGrupo"))
            {
                sqlSelect = "SELECT com_bloques.IdBloque, com_bloques.Descripcion,'true' AS Selected FROM com_bloques WHERE(((com_bloques.IdComunidad) = '" + idComunidad + "') AND((com_bloques.IdTipoBloque) = 1))";
            }
            else if(idTarea == null)
            {
                sqlSelect = "SELECT exp_area.IdBloque, exp_area.Nombre,'true' AS Selected FROM com_comunidades INNER JOIN (exp_area INNER JOIN com_bloques ON exp_area.IdBloque = com_bloques.IdBloque) ON com_comunidades.IdComunidad = com_bloques.IdComunidad WHERE(((com_comunidades.IdComunidad) = '" + idComunidad + "') AND((exp_area.IdAreaPrevio) = 0) AND((com_bloques.Baja) = 0) AND ((com_bloques.IdTipoBloque) = 1))";
            }
            else
            {
                sqlSelect = "SELECT com_bloques.IdBloque, com_bloques.Descripcion, If((SELECT Count(*)FROM exp_area INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((exp_area.IdAreaPrevio) = 0) AND((exp_areaTarea.IdTarea) = " + idTarea + ") AND((exp_area.IdBloque) = com_bloques.IdBloque))) > 0,'true','false') AS Selected FROM com_bloques WHERE(((com_bloques.IdTipoBloque) = 1) AND((com_bloques.IdComunidad) = " + idComunidad + ") AND ((com_bloques.IdTipoBloque) = 1))";
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
            enviarFormAnt();
        }
        
        private void enviarFormAnt()
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombreForm)).SingleOrDefault<Form>();
            if (existe != null)
            {
                if (nombreForm.Contains("FormVerTarea"))
                {
                    if (idComunidad != null) guardarBloques();
                }
                else if (nombreForm.Contains("FormInsertarServicioTarea"))
                {
                    FormInsertarServicioTarea nueva = (FormInsertarServicioTarea)existe;
                    nueva.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
                }
                else if (nombreForm.Contains("FormTareasPrincipal"))
                {
                    FormTareasPrincipal nueva = (FormTareasPrincipal)existe;
                    nueva.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
                }
                else if (nombreForm.Contains("FormListadoOrganos"))
                {
                    ComunidadesForms.CargosForms.FormListadoOrganos nueva = (ComunidadesForms.CargosForms.FormListadoOrganos)existe;
                    nueva.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
                }
                else if (nombreForm.Contains("FormNuevoGrupo"))
                {
                    ComunidadesForms.CargosForms.FormNuevoGrupo nueva = (ComunidadesForms.CargosForms.FormNuevoGrupo)existe;
                    nueva.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
                }
                else if (nombreForm.Contains("FormGestionesPrincipal"))
                {
                    FormGestionesPrincipal nueva = (FormGestionesPrincipal)existe;
                    nueva.recibirBloque(dataGridViewBloques.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloques.SelectedRows[0].Cells[1].Value.ToString());
                }
            }
            this.Close();
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
                    String sqlInsert = "INSERT INTO exp_areaTarea (IdArea,IdTarea,TipoArea) VALUES ('" + idAreaBloque(row[0].ToString()) + "','" + idTarea + "','B')";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
            }
            FormVerTarea nueva = (FormVerTarea)form_anterior;
            nueva.cargarBloque();
            nueva.recibirBloque();
            this.Close();
        }

        private String idAreaBloque(String idBloque)
        {
            String sqlSelect = "SELECT IdArea FROM exp_area WHERE idBloque = " + idBloque + " AND IdAreaPrevio = 0";
            return Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
        }
        

        private void dataGridViewBloques_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enviarFormAnt();
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
            else
            {
                enviarFormAnt();
            }
        }
    }

}
