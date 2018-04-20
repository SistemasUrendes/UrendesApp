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
    public partial class FormGestionesPrincipal : Form
    {
        DataTable tablaGestiones;
        String idEntidad;
        String idEntidadEspera;
        String nombre_columna;
        public FormGestionesPrincipal()
        {
            InitializeComponent();
        }

        private void FormGestionesPrincipal_Load(object sender, EventArgs e)
        {
            RellenarComboBox();
            CargarGestiones();
        }


        public void CargarGestiones()
        {
            String sqlSelect;
            if (idEntidad != null)
            {
                sqlSelect = "SELECT exp_gestiones.IdGestión AS Id, exp_gestiones.IdTarea, com_comunidades.Referencia AS Ref, ctos_urendes.Usuario,exp_tareas.Descripción AS Tareas, exp_gestiones.Descripción, ctos_entidades.Entidad AS `Espera de`, exp_tipogestion.Descripcion AS `Tipo Gestión`, exp_gestiones.Importante AS I, exp_gestiones.FIni, exp_gestiones.FSeguir AS FAgenda, exp_gestiones.FMax AS `FLímite`, exp_gestiones.FFin FROM(com_comunidades RIGHT JOIN(ctos_urendes INNER JOIN((exp_gestiones INNER JOIN exp_tareas ON exp_gestiones.IdTarea = exp_tareas.IdTarea) LEFT JOIN ctos_entidades ON exp_gestiones.IdEntidad = ctos_entidades.IDEntidad) ON ctos_urendes.IdURD = exp_gestiones.IdUser) ON com_comunidades.IdEntidad = exp_tareas.IdEntidad) LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE ((com_comunidades.FBaja) Is Null) AND (exp_gestiones.IdUser = " + Login.getId() + ") AND (exp_gestiones.FSeguir > '" + DateTime.Now.ToString("yyyy-MM-dd") + "') AND (exp_tareas.IdEntidad = " + idEntidad + ") AND exp_gestiones.FFin is null ORDER BY exp_gestiones.FSeguir";
            }
            else
            {
                sqlSelect = "SELECT exp_gestiones.IdGestión AS Id, exp_gestiones.IdTarea, com_comunidades.Referencia AS Ref, ctos_urendes.Usuario,exp_tareas.Descripción AS Tareas, exp_gestiones.Descripción, ctos_entidades.Entidad AS `Espera de`, exp_tipogestion.Descripcion AS `Tipo Gestión`, exp_gestiones.Importante AS I, exp_gestiones.FIni, exp_gestiones.FSeguir AS FAgenda, exp_gestiones.FMax AS `FLímite`, exp_gestiones.FFin FROM(com_comunidades RIGHT JOIN(ctos_urendes INNER JOIN((exp_gestiones INNER JOIN exp_tareas ON exp_gestiones.IdTarea = exp_tareas.IdTarea) LEFT JOIN ctos_entidades ON exp_gestiones.IdEntidad = ctos_entidades.IDEntidad) ON ctos_urendes.IdURD = exp_gestiones.IdUser) ON com_comunidades.IdEntidad = exp_tareas.IdEntidad) LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE ((com_comunidades.FBaja) Is Null) AND (exp_gestiones.IdUser = " + Login.getId() + ") AND (exp_gestiones.FSeguir > '" + DateTime.Now.ToString("yyyy-MM-dd") + "') AND exp_gestiones.FFin is null ORDER BY exp_gestiones.FSeguir";                
            }
            comboBoxResponsable.SelectedValue = Login.getId();
            tablaGestiones = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewGestiones.DataSource = tablaGestiones;
            labelCount.Text = "Elementos: " + tablaGestiones.Rows.Count.ToString();
            ajustarDatagrid();
        }

        private void ajustarDatagrid()
        {
            if (dataGridViewGestiones.Rows.Count > 0)
            {
                dataGridViewGestiones.Columns["Id"].Width = 45;
                dataGridViewGestiones.Columns["Usuario"].Visible = false;
                dataGridViewGestiones.Columns["IdTarea"].Visible = false;
                dataGridViewGestiones.Columns["Descripción"].Width = 240;
                dataGridViewGestiones.Columns["Ref"].Width = 30;
                dataGridViewGestiones.Columns["Tareas"].Width = 300;
                dataGridViewGestiones.Columns["Tipo Gestión"].Visible = false;
                dataGridViewGestiones.Columns["I"].Width = 30;
                dataGridViewGestiones.Columns["I"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridViewGestiones.Columns["FIni"].Width = 70;
                dataGridViewGestiones.Columns["FAgenda"].Width = 70;
                dataGridViewGestiones.Columns["Flímite"].Width = 70;
                dataGridViewGestiones.Columns["FFin"].Width = 70;
                dataGridViewGestiones.Columns["Espera de"].Width = 200;
            }
        }

        private void RellenarComboBox()
        {
            DataTable tipos;
            String sqlComboTipo = "SELECT exp_tipogestion.IdTipoGestion, exp_tipogestion.Descripcion FROM exp_tipogestion";
            tipos = Persistencia.SentenciasSQL.select(sqlComboTipo);
            DataRow filatodas = tipos.NewRow();

            filatodas["Descripcion"] = "Todos";
            filatodas["IdTipoGestion"] = 0;
            tipos.Rows.InsertAt(filatodas, 0);
            comboBox_Tipo.DataSource = tipos;
            comboBox_Tipo.DisplayMember = "Descripcion";
            comboBox_Tipo.ValueMember = "IdTipoGestion";


            List<String> estados = new List<String> { "Todas", "Abierta", "Cerrada" };
            comboBox_Estado.DataSource = estados;
            comboBox_Estado.SelectedIndex = 1;

            DataTable admins;
            String sqlComboAdm = "SELECT ctos_urendes.IdURD, ctos_urendes.Usuario FROM ctos_urendes WHERE(((ctos_urendes.FBaja)Is Null))";
            admins = Persistencia.SentenciasSQL.select(sqlComboAdm);
            DataRow admtodas = admins.NewRow();

            admtodas["Usuario"] = "Todos";
            admtodas["IdURD"] = 0;
            admins.Rows.InsertAt(admtodas, 0);
            comboBoxResponsable.DataSource = admins;
            comboBoxResponsable.DisplayMember = "Usuario";
            comboBoxResponsable.ValueMember = "IdURD";
        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {

            String sqlSelect = "";
            //CHECKBOX
            String importante = "0";
            if (checkBoxImportante.Checked) importante = "1";
            //FECHAS
            String fechaInicio1 = "";
            String fechaInicio2 = "";
            String fechaMax1 = "";
            String fechaMax2 = "";
            try
            {
                if (maskedTextBox_FIni1.Text.ToString() != "  /  /") fechaInicio1 = (Convert.ToDateTime(maskedTextBox_FIni1.Text)).ToString("yyyy-MM-dd");
                if (maskedTextBox_FIni2.Text.ToString() != "  /  /") fechaInicio2 = (Convert.ToDateTime(maskedTextBox_FIni2.Text)).ToString("yyyy-MM-dd");
                if (maskedTextBox_FMax1.Text.ToString() != "  /  /") fechaMax1 = (Convert.ToDateTime(maskedTextBox_FMax1.Text)).ToString("yyyy-MM-dd");
                if (maskedTextBox_FMax2.Text.ToString() != "  /  /") fechaMax2 = (Convert.ToDateTime(maskedTextBox_FMax2.Text)).ToString("yyyy-MM-dd");
            }
            catch
            {
                MessageBox.Show("Comprueba las fechas");
                return;
            }
            String tipo = comboBox_Tipo.SelectedValue.ToString();
            String estado = comboBox_Estado.SelectedIndex.ToString();
            String responsable = comboBoxResponsable.SelectedValue.ToString();



            //sqlSelect = "SELECT exp_gestiones.IdGestión AS Id, exp_gestiones.IdTarea, com_comunidades.Referencia AS Ref, ctos_urendes.Usuario, exp_tareas.Descripción as Tareas, exp_gestiones.Descripción, ctos_entidades.Entidad AS `Espera de`, exp_tipogestion.Descripcion AS `Tipo Gestión`, exp_gestiones.Importante AS I, exp_gestiones.FIni, exp_gestiones.FSeguir AS FAgenda, exp_gestiones.FMax AS `FLímite`, exp_gestiones.FFin FROM ctos_urendes INNER JOIN ((((exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion) INNER JOIN exp_tareas ON exp_gestiones.IdTarea = exp_tareas.IdTarea) RIGHT JOIN com_comunidades ON exp_tareas.IdEntidad = com_comunidades.IdEntidad) LEFT JOIN ctos_entidades ON exp_gestiones.IdEntidad = ctos_entidades.IDEntidad) ON ctos_urendes.IdURD = exp_gestiones.IdUser WHERE ((com_comunidades.FBaja) Is Null)";

            sqlSelect = "SELECT exp_gestiones.IdGestión AS Id, exp_gestiones.IdTarea, com_comunidades.Referencia AS Ref, ctos_urendes.Usuario,exp_tareas.Descripción AS Tareas, exp_gestiones.Descripción, ctos_entidades.Entidad AS `Espera de`, exp_tipogestion.Descripcion AS `Tipo Gestión`, exp_gestiones.Importante AS I, exp_gestiones.FIni, exp_gestiones.FSeguir AS FAgenda, exp_gestiones.FMax AS `FLímite`, exp_gestiones.FFin FROM(com_comunidades RIGHT JOIN(ctos_urendes INNER JOIN((exp_gestiones INNER JOIN exp_tareas ON exp_gestiones.IdTarea = exp_tareas.IdTarea) LEFT JOIN ctos_entidades ON exp_gestiones.IdEntidad = ctos_entidades.IDEntidad) ON ctos_urendes.IdURD = exp_gestiones.IdUser) ON com_comunidades.IdEntidad = exp_tareas.IdEntidad) LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE ((com_comunidades.FBaja) Is Null)";

            
            if (idEntidad != null)
            {
                sqlSelect += " AND (exp_tareas.IdEntidad = " + idEntidad + ")";
            }
            if (idEntidadEspera != null)
            {
                sqlSelect += " AND (exp_gestiones.IdEntidad = " + idEntidadEspera + ")";
            }
            //CHECKBOX
            if (importante == "1")
            {
                sqlSelect += " AND (exp_gestiones.Importante = -1)";
            }
            //FECHAS
            if (fechaInicio1 != "")
            {
                sqlSelect += " AND (exp_gestiones.FIni >= '" + fechaInicio1 + "')";
            }
            if (fechaInicio2 != "")
            {
                sqlSelect += " AND (exp_gestiones.FIni <= '" + fechaInicio2 + "')";
            }
            if (fechaMax1 != "")
            {
                sqlSelect += " AND (exp_gestiones.FFin >= '" + fechaMax1 + "') AND (exp_gestiones.FFin Is Not Null)";
            }
            if (fechaMax2 != "")
            {
                sqlSelect += " AND (exp_gestiones.FFin <= '" + fechaMax2 + "')";
                if (fechaMax1 == "") sqlSelect += " AND (exp_gestiones.FFin Is Not Null)";
            }
            //COMBOBOX
            if (tipo != "0")
            {
                sqlSelect += " AND (exp_gestiones.IdTipoGestion = " + tipo + ")";
            }
            if (estado != "0")
            {
                //ABIERTAS
                if (estado == "1")
                {
                    sqlSelect += " AND (exp_gestiones.FFin Is Null)";
                }
                //CERRADAS
                else if (estado == "2")
                {
                     sqlSelect += " AND (exp_gestiones.FFin Is Not Null)";
                }
            }
            if (responsable != "0" && idEntidad == null)
            {
                sqlSelect += " AND (exp_gestiones.IdUser = " + responsable + ")";
            }



            sqlSelect += " ORDER BY exp_gestiones.FSeguir ASC";

            tablaGestiones = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewGestiones.DataSource = tablaGestiones;
            labelCount.Text = "Elementos: " + tablaGestiones.Rows.Count.ToString();
            ajustarDatagrid();

        }
        

        private void maskedTextBoxRefComunidad_Leave(object sender, EventArgs e)
        {
            if (maskedTextBoxRefComunidad.Text != "")
            {
                try
                {
                    textBox_Entidad.Text = nombreReferencia();
                    textBox_Entidad.ForeColor = Color.Black;
                    comboBox_Tipo.Focus();
                    comboBox_Tipo.SelectAll();
                }
                catch
                {
                    maskedTextBoxRefComunidad.Text = "";
                    maskedTextBoxRefComunidad.Focus();
                }
            }
        }

        private String nombreReferencia()
        {
            //URENDES
            if (maskedTextBoxRefComunidad.Text == "000" || maskedTextBoxRefComunidad.Text == "00" || maskedTextBoxRefComunidad.Text == "0")
            {
                idEntidad = "1178";
                CargarGestiones();
                return "ADMINISTRACIONES URENDES, S.L.";
            }
            else
            {
                String sql = "SELECT ctos_entidades.Entidad,ctos_entidades.IdEntidad FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.Referencia) = " + maskedTextBoxRefComunidad.Text + "))";

                DataTable entidad = Persistencia.SentenciasSQL.select(sql);
                idEntidad = entidad.Rows[0][1].ToString();
                CargarGestiones();
                return entidad.Rows[0][0].ToString();
            }
        }

        private void textBoxEnEsperaDe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Space || e.KeyChar == (Char)Keys.Enter)
            {
                Entidades nueva = new Entidades(this, this.Name);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar_nombre.Select();
                nueva.Show();
            }
        }

        public void recibirEntidad(String id_entidad)
        {
            idEntidadEspera = id_entidad;
            String nombre = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IdEntidad = " + id_entidad)).Rows[0][0].ToString();
            textBoxEnEsperaDe.Text = nombre;
            textBoxEnEsperaDe.ForeColor = Color.Black;
        }

        private void verTareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewGestiones.SelectedCells.Count > 0)
            {
                string idTarea = dataGridViewGestiones.SelectedRows[0].Cells["IdTarea"].Value.ToString();

                FormVerTarea nueva = new FormVerTarea(idTarea);
                nueva.Show();
            }
        }

        private void dataGridViewGestiones_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                toolStripTextBoxFiltro.Text = "";
                var hti = dataGridViewGestiones.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    dataGridViewGestiones.ClearSelection();
                    dataGridViewGestiones.Rows[hti.RowIndex].Selected = true;
                    dataGridViewGestiones.Columns[hti.ColumnIndex].Selected = true;
                    dataGridViewGestiones.CurrentCell = this.dataGridViewGestiones[hti.ColumnIndex, hti.RowIndex];
                    nombre_columna = dataGridViewGestiones.CurrentCell.OwningColumn.Name;
                    if (nombre_columna != "Fini" && nombre_columna != "Ffin")
                    {
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }
            }
        }

        private void toolStripTextBoxFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Tab || e.KeyChar == (Char)Keys.Enter)
            {
                contextMenuStrip1.Close();
            }
        }

        private void toolStripTextBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            String filtro;
            if (toolStripTextBoxFiltro.TextLength == 1)
            {
                DataTable busqueda = tablaGestiones;
                busqueda.DefaultView.RowFilter = string.Empty;
                this.dataGridViewGestiones.DataSource = busqueda;
                labelCount.Text = "Elementos: " + busqueda.Rows.Count.ToString();


                if (nombre_columna != "Id")
                {
                    filtro = "`" + nombre_columna + "` like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%'";

                }
                else
                {
                    filtro = string.Format("[{0}] >= '{1}'", nombre_columna, toolStripTextBoxFiltro.Text.ToUpper().ToString());
                }
                busqueda.DefaultView.RowFilter = filtro;
                this.dataGridViewGestiones.DataSource = busqueda;
                labelCount.Text = "Elementos: " + busqueda.Rows.Count.ToString();
                ajustarDatagrid();
            }
            else if (toolStripTextBoxFiltro.TextLength > 1)
            {
                DataTable busqueda = tablaGestiones;

                if (nombre_columna != "Id")
                {
                    filtro = "`" + nombre_columna + "` like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%'";

                }
                else
                {
                    filtro = string.Format("[{0}] >= '{1}'", nombre_columna, toolStripTextBoxFiltro.Text.ToUpper().ToString());
                }
                busqueda.DefaultView.RowFilter = filtro;
                this.dataGridViewGestiones.DataSource = busqueda;
                labelCount.Text = "Elementos: " + busqueda.Rows.Count.ToString();
                ajustarDatagrid();
            }
        }

        private void buttonRuta_Click(object sender, EventArgs e)
        {
            String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
            String ruta = "";
            String sqlSelect = "SELECT exp_tareas.Ruta FROM exp_tareas INNER JOIN exp_gestiones ON exp_tareas.IdTarea = exp_gestiones.IdTarea WHERE(((exp_gestiones.IdGestión) = " + idGestion + "))";
            ruta = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            ruta = limpiaRuta(ruta);
            if ( ruta != "") System.Diagnostics.Process.Start(@ruta);
            else
            {
                MessageBox.Show("No se encuentra la carpeta de la tarea");
            }
        }

        private void buttonAplazar_Click(object sender, EventArgs e)
        {
            if (textBoxEnEsperaDe.Text != "")
            {
                String idGestion = dataGridViewGestiones.SelectedRows[0].Cells["Id"].Value.ToString();
                DateTime fechaAgenda = Convert.ToDateTime(dataGridViewGestiones.SelectedRows[0].Cells["FAgenda"].Value);
                fechaAgenda = fechaAgenda.AddDays(Int32.Parse(maskedTextBoxAplazarDias.Text));
                String sqlUpdate = "UPDATE exp_gestiones SET FSeguir = '" + fechaAgenda.ToString("yyyy-MM-dd") + "' WHERE IdGestión = " + idGestion;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                CargarGestiones();
                textBoxEnEsperaDe.Text = "";
            }
        }

        private void buttonEditarGestion_Click(object sender, EventArgs e)
        {
            string idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
            String sqlSelect = "SELECT exp_gestiones.IdTarea FROM exp_gestiones WHERE(((exp_gestiones.IdGestión) = " + idGestion + "))";
            String idTarea = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            FormInsertarGestion nueva = new FormInsertarGestion(idGestion, idTarea);
            nueva.Show();
        }

        private String limpiaRuta(String r)
        {
            String ruta;
            if (r.Contains("#"))
            {
                ruta = r.Split('#', '#')[1];
                return ruta;
            }
            return r;
        }

        private void dataGridViewGestiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dataGridViewGestiones.SelectedCells.Count > 0)
                {
                    string idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
                    FormInsertarGestion nueva = new FormInsertarGestion(idGestion);
                    nueva.Show();
                }
            }
        }

        private void toolStripMenuItemSeguimiento_Click(object sender, EventArgs e)
        {
            string idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
            FormInsertarSeguimiento nueva = new FormInsertarSeguimiento(idGestion);
            nueva.Show();

        }

        private void toolStripMenuItemCerrar_Click(object sender, EventArgs e)
        {
            string idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
            String sqlUpdate = "UPDATE exp_gestiones SET FFin = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE IdGestión = " + idGestion;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            CargarGestiones();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            DataTable busqueda = tablaGestiones;
            busqueda.DefaultView.RowFilter = string.Empty;
            this.dataGridViewGestiones.DataSource = busqueda;
            labelCount.Text = "Elementos: " + busqueda.Rows.Count.ToString();
            ajustarDatagrid();
        }
    }
}
