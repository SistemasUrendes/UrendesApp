using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace UrdsAppGestión.Presentacion.Tareas
{
    public partial class FormTareasPrincipal : Form
    {
        DataTable tareas;
        String id_entidad;
        String nombre_columna;
        String id_comunidad;
        Form form_anterior;
        String form_ant;
        String idAreaBloque;
        String ordFIni;
        String ordFFin;
        Boolean boolContCom;
        String filtro;
        String filtroConcat;
        String busquedaConcat;
        String codigoCat;
        String ordDescripcion;

        public FormTareasPrincipal(String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            textBoxTarea.Select();
        }
        
        public FormTareasPrincipal(Form form_anterior,String form_ant,String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.form_anterior = form_anterior;
            textBoxTarea.Select();
            this.form_ant = form_ant;
        }

        public FormTareasPrincipal(Form form_anterior, String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.form_anterior = form_anterior;
            textBoxTarea.Select();
        }

        public FormTareasPrincipal()
        {
            InitializeComponent();
            maskedTextBoxRefComunidad.Select();
        }
        private void FormTareasPrincipal_Load(object sender, EventArgs e)
        {
            RellenarComboBox();
            CargarTareas();
            if (id_comunidad != null)
            {
                filtroComunidad();
                boolContCom = true;
            }
            else
            {
                boolContCom = false;
            }
            if (form_anterior != null) {
                button_enviar.Visible = true;
                labelMostrar.Visible = true;
                textBoxMostrar.Visible = true;
                labelIdTarea.Visible = false;
                textBoxTarea.Visible = false;
            }

        }

        public void CargarTareas()
        {
            String sqlSelect;
            if (id_comunidad == null && id_entidad == null)  {
                
                sqlSelect = "SELECT exp_tareas.IdTarea AS Id, exp_tareas.IDTareaCorto AS IdNuevo , ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.Corto AS T,If ((SELECT Count(*) FROM(com_bloques INNER JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea))) > 1, 'VARIOS BLOQ.' ,(SELECT com_bloques.Descripcion FROM(com_bloques LEFT JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea)))) AS Bloque, exp_tareas.Descripción, exp_tareas.DescripcionSinAcentos,(SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea = exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado, DATE_FORMAT(Coalesce(exp_tareas.FIni, 'ok'), '%d/%m/%Y') AS FIni, DATE_FORMAT(Coalesce(exp_tareas.FFin, 'ok'), '%d/%m/%Y') AS FFin, ctos_entidades.IDEntidad, exp_tareas.AcuerdoJunta AS A, exp_tareas.Importante AS I, exp_tareas.ProximaJunta AS P, exp_tareas.RefSiniestro AS Seguro FROM((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) LEFT JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE (((com_comunidades.FBaja)Is Null) AND((com_comunidades.IdGestor = " + Login.getId() + ") OR((com_comunidades.IdGestor2) = " + Login.getId() + "))) AND exp_tareas.FFin is null GROUP BY exp_tareas.IdTarea ORDER BY exp_tareas.FIni ASC";
                
                comboBoxAdmComunidad.SelectedValue = Login.getId();
                if (comboBoxAdmComunidad.SelectedValue == null)
                {
                    comboBoxAdmComunidad.SelectedValue = 0;
                    sqlSelect = "SELECT exp_tareas.IdTarea AS Id, exp_tareas.IDTareaCorto AS IdNuevo , ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.Corto AS T,If ((SELECT Count(*) FROM(com_bloques INNER JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea))) > 1, 'VARIOS BLOQ.' ,(SELECT com_bloques.Descripcion FROM(com_bloques LEFT JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea)))) AS Bloque, exp_tareas.Descripción, exp_tareas.DescripcionSinAcentos,(SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea=exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni, DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin,  ctos_entidades.IDEntidad, exp_tareas.AcuerdoJunta AS A, exp_tareas.Importante AS I, exp_tareas.ProximaJunta AS P, exp_tareas.RefSiniestro AS Seguro FROM ((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) LEFT JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE((com_comunidades.FBaja) Is Null) AND exp_tareas.FFin is null GROUP BY exp_tareas.IdTarea ORDER BY exp_tareas.FIni ASC";
                }
            }
            else if (id_entidad != null)
            {
                sqlSelect = "SELECT exp_tareas.IdTarea AS Id, exp_tareas.IDTareaCorto AS IdNuevo , ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.Corto AS T,If ((SELECT Count(*) FROM(com_bloques INNER JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea))) > 1, 'VARIOS BLOQ.' ,(SELECT com_bloques.Descripcion FROM(com_bloques LEFT JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea)))) AS Bloque, exp_tareas.Descripción, exp_tareas.DescripcionSinAcentos,(SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea=exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado,DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni, DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin,  ctos_entidades.IDEntidad, exp_tareas.AcuerdoJunta AS A, exp_tareas.Importante AS I, exp_tareas.ProximaJunta as P, exp_tareas.RefSiniestro AS Seguro FROM ((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) WHERE (ctos_entidades.IDEntidad = " + id_entidad + ") AND exp_tareas.FFin is null GROUP BY exp_tareas.IdTarea ORDER BY exp_tareas.FIni ASC";
            }
            
            else
            {
                sqlSelect = "SELECT exp_tareas.IdTarea AS Id, exp_tareas.IDTareaCorto AS IdNuevo , ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.Corto AS T,If ((SELECT Count(*) FROM(com_bloques INNER JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea))) > 1, 'VARIOS BLOQ.' ,(SELECT com_bloques.Descripcion FROM(com_bloques LEFT JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea)))) AS Bloque, exp_tareas.Descripción, exp_tareas.DescripcionSinAcentos,(SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea=exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado,DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni, DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin,  ctos_entidades.IDEntidad, exp_tareas.AcuerdoJunta AS A, exp_tareas.Importante AS I, exp_tareas.ProximaJunta as P, exp_tareas.RefSiniestro AS Seguro FROM((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) LEFT JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad  WHERE(com_comunidades.IdComunidad = " + id_comunidad + ") AND exp_tareas.FFin is null GROUP BY exp_tareas.IdTarea ORDER BY exp_tareas.FIni ASC";
            }
            tareas = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_tareas.DataSource = tareas;
            labelCount.Text = "Elementos: " + tareas.Rows.Count.ToString();
            ajustarDatagrid();
        }

        public void ajustarDatagrid()
        {
            if (dataGridView_tareas.Rows.Count > 0)
            {
                dataGridView_tareas.ShowCellToolTips = true;
                dataGridView_tareas.Columns["Id"].Width = 60;
                dataGridView_tareas.Columns["IdNuevo"].Width = 60;
                dataGridView_tareas.Columns["Entidad"].Width = 110;
                dataGridView_tareas.Columns["T"].Width = 17;
                dataGridView_tareas.Columns["T"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_tareas.Columns["Descripción"].Width = 300;
                dataGridView_tareas.Columns["DescripcionSinAcentos"].Visible = false;
                dataGridView_tareas.Columns["Estado"].Width = 120;
                dataGridView_tareas.Columns["FIni"].Width = 90;
                dataGridView_tareas.Columns["FIni"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView_tareas.Columns["FIni"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView_tareas.Columns["FFin"].Width = 90;
                dataGridView_tareas.Columns["FFin"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView_tareas.Columns["FFin"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView_tareas.Columns["A"].Width = 20;
                dataGridView_tareas.Columns["I"].Width = 20;
                dataGridView_tareas.Columns["P"].Width = 20;
                dataGridView_tareas.Columns["Seguro"].Width = 100;
                dataGridView_tareas.Columns["IDEntidad"].Visible = false;
                dataGridView_tareas.Columns["A"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView_tareas.Columns["I"].SortMode = DataGridViewColumnSortMode.Automatic;
                dataGridView_tareas.Columns["P"].SortMode = DataGridViewColumnSortMode.Automatic;



                
            }
        }

        public void RellenarComboBox()
        {
            DataTable tipos;
            String sqlComboTipo = "SELECT exp_tipostareas.TipoTarea, exp_tipostareas.IdTipoTarea FROM exp_tipostareas";
            tipos = Persistencia.SentenciasSQL.select(sqlComboTipo);
            DataRow filatodas = tipos.NewRow();

            filatodas["TipoTarea"] = "Todos";
            filatodas["IdTipoTarea"] = 0;
            tipos.Rows.InsertAt(filatodas, 0);
            comboBox_Tipo.DataSource = tipos;
            comboBox_Tipo.DisplayMember = "TipoTarea";
            comboBox_Tipo.ValueMember = "IdTipoTarea";
            

            List<String> estados = new List<String> { "Todas","Abierta","Cerrada" };
            comboBox_Estado.DataSource = estados;
            comboBox_Estado.SelectedIndex = 1;

            DataTable admins;
            String sqlComboAdm = "SELECT ctos_urendes.IdURD, ctos_urendes.Usuario FROM ctos_urendes WHERE(((ctos_urendes.FBaja)Is Null) AND((ctos_urendes.IdGrupoURD) = 4 Or(ctos_urendes.IdGrupoURD) = 2))";
            admins = Persistencia.SentenciasSQL.select(sqlComboAdm);
            DataRow admtodas = admins.NewRow();

            admtodas["Usuario"] = "Todos";
            admtodas["IdURD"] = 0;
            admins.Rows.InsertAt(admtodas, 0);
            comboBoxAdmComunidad.DataSource = admins;
            comboBoxAdmComunidad.DisplayMember = "Usuario";
            comboBoxAdmComunidad.ValueMember = "IdURD";

        }
        
        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            aplicarFiltroTabla();
        }
        
        public void aplicarFiltroTabla()
        {
            String sqlSelect = "";
            //FECHAS
            String fechaInicio1 = "";
            String fechaInicio2 = "";
            String fechaFin1 = "";
            String fechaFin2 = "";
            try
            {
                if (maskedTextBox_FIni1.Text.ToString() != "  /  /") fechaInicio1 = (Convert.ToDateTime(maskedTextBox_FIni1.Text)).ToString("yyyy-MM-dd");
                if (maskedTextBox_FIni2.Text.ToString() != "  /  /") fechaInicio2 = (Convert.ToDateTime(maskedTextBox_FIni2.Text)).ToString("yyyy-MM-dd");
                if (maskedTextBox_FFin1.Text.ToString() != "  /  /") fechaFin1 = (Convert.ToDateTime(maskedTextBox_FFin1.Text)).ToString("yyyy-MM-dd");
                if (maskedTextBox_FFin2.Text.ToString() != "  /  /") fechaFin2 = (Convert.ToDateTime(maskedTextBox_FFin2.Text)).ToString("yyyy-MM-dd");
            }
            catch
            {
                MessageBox.Show("Comprueba las fechas");
                return;
            }
            //CHECKBOX
            String acuerdo = "0";
            if (checkBoxAcuerdoJunta.Checked) acuerdo = "1";
            String seguro = "0";
            if (checkBoxSeguro.Checked) seguro = "1";
            String importante = "0";
            if (checkBoxImportante.Checked) importante = "1";
            String proxJunta = "0";
            if (checkBoxProxJunta.Checked) proxJunta = "1";
            //COMBOBOX
            String tipo = comboBox_Tipo.SelectedValue.ToString() ;
            String estado = comboBox_Estado.SelectedIndex.ToString();
            String gestor = comboBoxAdmComunidad.SelectedValue.ToString();
            
            sqlSelect = "SELECT exp_tareas.IdTarea AS Id, exp_tareas.IDTareaCorto AS IdNuevo, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.Corto AS T,If ((SELECT Count(*) FROM(com_bloques INNER JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea))) > 1, 'VARIOS BLOQ.' ,(SELECT com_bloques.Descripcion FROM(com_bloques LEFT JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea)))) AS Bloque,exp_tareas.Descripción, exp_tareas.DescripcionSinAcentos,(SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea=exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni, DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin,  ctos_entidades.IDEntidad, exp_tareas.AcuerdoJunta AS A, exp_tareas.Importante AS I, exp_tareas.ProximaJunta as P, exp_tareas.RefSiniestro AS Seguro FROM((com_comunidades RIGHT JOIN((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) ON com_comunidades.IdEntidad = exp_tareas.IdEntidad) LEFT JOIN exp_areaTarea ON exp_tareas.IdTarea = exp_areaTarea.IdTarea) LEFT JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea WHERE(((com_comunidades.FBaja)Is Null))";

            if (id_comunidad != null)
            {
                sqlSelect += " AND (com_comunidades.IdComunidad = " + id_comunidad + ")";
            }
            else if (id_entidad != null)
            {
                sqlSelect += " AND (ctos_entidades.IDEntidad = " + id_entidad  + ")";
            }
            //FECHAS
            if (fechaInicio1 != "")
            {
                sqlSelect += " AND (exp_tareas.FIni >= '" + fechaInicio1  + "')";
            }
            if (fechaInicio2 != "")
            {
                sqlSelect += " AND (exp_tareas.FIni <= '" + fechaInicio2 + "')";
            }
            if (fechaFin1 != "")
            {
                sqlSelect += " AND (exp_tareas.FFin >= '" + fechaFin1 + "') AND (exp_tareas.FFin Is Not Null)";
            }
            if (fechaFin2 != "")
            {
                sqlSelect += " AND (exp_tareas.FFin <= '" + fechaFin2 + "')";
                if (fechaFin1 == "") sqlSelect += " AND (exp_tareas.FFin Is Not Null)";
            }
            //CHECKBOX
            if(acuerdo == "1")
            {
                sqlSelect += " AND (exp_tareas.AcuerdoJunta = -1)";
            }
            if(seguro == "1")
            {
               sqlSelect += " AND ((exp_tareas.Seguro = -1) OR (exp_tareas.RefSiniestro Is Not Null))";
            }
            if(importante == "1")
            {
                sqlSelect += " AND (exp_tareas.Importante = -1)";
            }
            if(proxJunta == "1")
            {
                sqlSelect += " AND (exp_tareas.ProximaJunta = -1)";
            }
            //COMBOBOX
            if (tipo != "0")
            {
                sqlSelect += " AND (exp_tareas.IdTipoTarea = " + tipo + ")";
            }
            if (estado != "0")
            {
                //ABIERTAS
                if (estado == "1")
                {
                    sqlSelect += " AND (exp_tareas.FFin Is Null)";
                }
                //CERRADAS
                else if (estado == "2")
                {
                    sqlSelect += " AND (exp_tareas.FFin Is Not Null)";
                }
            }
            if (gestor != "0" && id_comunidad == null && id_entidad == null)
            {
                sqlSelect += " AND (com_comunidades.IdGestor = " + gestor + " OR com_comunidades.IdGestor2 = " + gestor + ")";
            }
            if (idAreaBloque != null)
            {
                sqlSelect += " AND (exp_areaTarea.IdArea = " + idAreaBloque + ")";
            }
            if (codigoCat != null)
            {
                sqlSelect += " AND (exp_area.codigoArea Like '%" + codigoCat + "%')";
            }
            sqlSelect += " GROUP BY exp_tareas.IdTarea";
            if (ordFIni == null && ordFFin == null && ordDescripcion == null)
            {
                sqlSelect += " ORDER BY exp_tareas.FIni ASC";
            }
            else if (ordFIni != null)
            {
                sqlSelect += " ORDER BY exp_tareas.FIni " + ordFIni;
            }
            else if (ordFFin != null)
            {
                sqlSelect += " ORDER BY exp_tareas.FFin " + ordFFin;
            }
            else if (ordDescripcion != null)
            {
                sqlSelect += " ORDER BY exp_tareas.Descripción " + ordDescripcion;
            }
            
            tareas = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_tareas.DataSource = tareas;
            labelCount.Text = "Elementos: " + tareas.Rows.Count.ToString();
            ajustarDatagrid();

        }

        private void dataGridView_tareas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                toolStripTextBoxFiltro.Text = "";
                var hti = dataGridView_tareas.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    dataGridView_tareas.ClearSelection();
                    dataGridView_tareas.Rows[hti.RowIndex].Selected = true;
                    dataGridView_tareas.Columns[hti.ColumnIndex].Selected = true;
                    dataGridView_tareas.CurrentCell = this.dataGridView_tareas[hti.ColumnIndex, hti.RowIndex];
                    nombre_columna = dataGridView_tareas.CurrentCell.OwningColumn.Name;
                    if (nombre_columna != "Fini" && nombre_columna != "Ffin")
                    {
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }
            }
        }
        

        private void dataGridView_tareas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dataGridView_tareas.SelectedCells.Count > 0)
                {
                    string idTarea = dataGridView_tareas.SelectedRows[0].Cells[0].Value.ToString();
                    
                    Tareas.FormVerTarea nueva = new FormVerTarea(this, idTarea);
                    nueva.ControlBox = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    nueva.Show();
                    
                }
            }
        }

        private void buttonNuevaTarea_Click(object sender, EventArgs e)
        {
            Tareas.FormVerTarea nueva = new FormVerTarea(this);
            nueva.ControlBox = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        

        private void toolStripMenuItemBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView_tareas.SelectedCells.Count > 0)
            {
                string idTarea = dataGridView_tareas.SelectedRows[0].Cells[0].Value.ToString();

                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar esta Tarea ?", "Borrar Tarea", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    String sqlBorrar = "DELETE FROM exp_tareas WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    CargarTareas();
                }
            }
        }
        

        private String nombreReferencia()
        {
            //URENDES
            if (maskedTextBoxRefComunidad.Text == "000" || maskedTextBoxRefComunidad.Text == "00" || maskedTextBoxRefComunidad.Text == "0")
            {
                id_entidad = "1178";
                CargarTareas();
                return "ADMINISTRACIONES URENDES, S.L.";
            }
            else
            {
                String sql = "SELECT ctos_entidades.Entidad, com_comunidades.IdComunidad FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.Referencia) = " + maskedTextBoxRefComunidad.Text + "))";

                DataTable entidad = Persistencia.SentenciasSQL.select(sql);
                id_comunidad = entidad.Rows[0][1].ToString();
                CargarTareas();
                return entidad.Rows[0][0].ToString();
            }
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

        private void toolStripTextBoxFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Tab || e.KeyChar == (Char)Keys.Enter)
                {
                if (filtroConcat != null && filtroConcat.Length > 0) filtroConcat += " AND " + filtro;
                else filtroConcat = filtro;
                if (busquedaConcat != null && busquedaConcat.Length > 0) busquedaConcat += "; " + toolStripTextBoxFiltro.Text;
                else
                {
                busquedaConcat += toolStripTextBoxFiltro.Text;
                }
                labelBusqueda.Text = "Buscando : " + busquedaConcat;
                contextMenuStrip1.Close();
                }
        }

        private void filtroComunidad()
        {
            String sqlSelect = "SELECT com_comunidades.Referencia FROM com_comunidades WHERE(((com_comunidades.IdComunidad) = " + id_comunidad + "))";
            String referencia = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            maskedTextBoxRefComunidad.Text = referencia;
            textBox_Entidad.Text = nombreReferencia();
        }
        
        private Boolean existeTarea(String idTarea)
        {
            String sqlSelect = "SELECT exp_tareas.IdTarea FROM exp_tareas WHERE(((exp_tareas.IdTarea) = " + idTarea + ") OR (exp_tareas.IdTareaCorto) = '" + idTarea + "')";
            DataTable tarea = Persistencia.SentenciasSQL.select(sqlSelect);
            if (tarea.Rows.Count == 0)
                return false;           
            return true;       
        }

        private void textBoxTarea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                String idTarea = textBoxTarea.Text.ToString();
                if (existeTarea(idTarea))
                {
                    if (idTarea.Contains("/"))
                    {
                        String tareaViejo = idTareaViejo(idTarea);
                        Tareas.FormVerTarea nueva = new FormVerTarea(this, tareaViejo);
                        nueva.ControlBox = true;
                        nueva.WindowState = FormWindowState.Normal;
                        nueva.StartPosition = FormStartPosition.CenterScreen;
                        nueva.Show();
                    }
                    else
                    {
                        Tareas.FormVerTarea nueva = new FormVerTarea(this, idTarea);
                        nueva.ControlBox = true;
                        nueva.WindowState = FormWindowState.Normal;
                        nueva.StartPosition = FormStartPosition.CenterScreen;
                        nueva.Show();
                    }
                }
                else
                {
                    MessageBox.Show("La tarea " + idTarea + " no existe!");
                }
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            filtro = "";
            filtroConcat = "";
            busquedaConcat = "";
            labelBusqueda.Text = "";
            DataTable busqueda = tareas;
            busqueda.DefaultView.RowFilter = string.Empty;
            this.dataGridView_tareas.DataSource = busqueda;
            labelCount.Text = "Elementos: " + busqueda.Rows.Count.ToString();
            ajustarDatagrid();
        }
        

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            aplicarFiltroTabla();
            if (maskedTextBoxRefComunidad.Text != "")
            {
                String fIni1 = "";
                if (maskedTextBox_FIni1.Text.ToString() != "  /  /") fIni1 = maskedTextBox_FIni1.Text;
                String fIni2 = "";
                if (maskedTextBox_FIni2.Text.ToString() != "  /  /") fIni2 = maskedTextBox_FIni2.Text;
                String fFin1 = "";
                if (maskedTextBox_FFin1.Text.ToString() != "  /  /") fFin1 = maskedTextBox_FFin1.Text;
                String fFin2 = "";
                if (maskedTextBox_FFin2.Text.ToString() != "  /  /") fFin2 = maskedTextBox_FFin2.Text;
                String acuerdo = "0";
                if (checkBoxAcuerdoJunta.Checked) acuerdo = "1";
                String seguro = "0";
                if (checkBoxSeguro.Checked) seguro = "1";
                String importante = "0";
                if (checkBoxImportante.Checked) importante = "1";
                String proxJunta = "0";
                if (checkBoxProxJunta.Checked) proxJunta = "1";


                String sqlSelect = "SELECT ctos_entidades.IDEntidad, ctos_entidades.Entidad FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.Referencia) = " + maskedTextBoxRefComunidad.Text + "))";
                DataTable comunidad = Persistencia.SentenciasSQL.select(sqlSelect);
                String idEntidad = comunidad.Rows[0][0].ToString();
                String nombreComunidad = comunidad.Rows[0][1].ToString();
                Informes.VistaInformeSeguimiento nueva = new Informes.VistaInformeSeguimiento(idEntidad, nombreComunidad, tareas, fIni1, fIni2, fFin1, fFin2, acuerdo, importante, proxJunta, seguro);
                nueva.Show();
            }
            else
            {
                MessageBox.Show("Selecciona una comunidad para mostrar el informe");
            }
            
        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(form_anterior.Name)).SingleOrDefault<Form>();
            if (existe != null)
            {
                if (form_anterior.Name == "FromOperacionesVer")
                {
                    ComunidadesForms.OperacionesForms.FromOperacionesVer nuevo = (ComunidadesForms.OperacionesForms.FromOperacionesVer)existe;
                    nuevo.recibirTarea(dataGridView_tareas.SelectedCells[0].Value.ToString());
                }
                if (form_anterior.Name.Contains("FormVerTarea")) 
                {
                    FormVerTarea nuevo = (FormVerTarea)existe;
                    nuevo.recibirTarea(dataGridView_tareas.SelectedCells[0].Value.ToString());
                }
            }
            this.Close();
        }

        private void maskedTextBoxRefComunidad_DoubleClick(object sender, EventArgs e)
        {
            Tareas.FormReferenciaComunidad nueva = new FormReferenciaComunidad(this);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        
        public void recibirReferencia(String referencia)
        {
            id_entidad = null;
            maskedTextBoxRefComunidad.Text = referencia;
            textBox_Entidad.Text = nombreReferencia();
        }

        private void textBoxMostrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                String idTarea = textBoxMostrar.Text.ToString();
                if (existeTarea(idTarea))
                {
                    String sqlSelect = "SELECT exp_tareas.IdTarea AS Id, exp_tareas.IDTareaCorto AS IdNuevo , ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.Corto AS T,If ((SELECT Count(*) FROM(com_bloques INNER JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea))) > 1, 'VARIOS BLOQ.' ,(SELECT com_bloques.Descripcion FROM(com_bloques LEFT JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque) INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((com_bloques.IdTipoBloque) = 1) AND((exp_areaTarea.IdTarea) = exp_tareas.IdTarea)))) AS Bloque, exp_tareas.Descripción, exp_tareas.DescripcionSinAcentos,(SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea = exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado, DATE_FORMAT(Coalesce(exp_tareas.FIni, 'ok'), '%d/%m/%Y') AS FIni, DATE_FORMAT(Coalesce(exp_tareas.FFin, 'ok'), '%d/%m/%Y') AS FFin, ctos_entidades.IDEntidad, exp_tareas.AcuerdoJunta AS A, exp_tareas.Importante AS I, exp_tareas.ProximaJunta as P, exp_tareas.RefSiniestro AS Seguro FROM ((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) WHERE exp_tareas.IdTarea = " + idTarea + " OR exp_tareas.IdTareaCorto = '" + idTarea + "' GROUP BY exp_tareas.IdTarea ";
                    dataGridView_tareas.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
                }
                else
                {
                    MessageBox.Show("La tarea " + idTarea + " no existe!");
                }
            }
        }

        private String idTareaViejo(String idTareaNuevo)
        {
            String sqlSelect = "SELECT exp_tareas.IdTarea FROM exp_tareas WHERE exp_tareas.IdTareaCorto = '" + idTareaNuevo + "'";
            return Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString(); ;
        }

        private void textBoxEntidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!boolContCom)
            {
                if (e.KeyChar == (Char)Keys.Space || e.KeyChar == (Char)Keys.Enter)
                {
                    maskedTextBoxRefComunidad.Text = "";
                    this.Name = "FormGeneralTareasPrincipal";
                    Entidades nueva = new Entidades(this, this.Name);
                    nueva.ControlBox = true;
                    nueva.TopMost = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    nueva.textBox_buscar_nombre.Select();
                    nueva.Show();
                }
            }
        }
        
        public void recibirEntidad(String idEntidad,String nombre)
        {
            this.id_entidad = idEntidad;
            textBox_Entidad.Text = nombre;
            aplicarFiltroTabla();
        }

        private void dataGridView_tareas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                if ((bool)e.Value)
                {
                    dataGridView_tareas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Wheat;
                }
            }
        }

        private void toolStripTextBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBoxFiltro.TextLength == 1)
            {
                DataTable busqueda = tareas;
                busqueda.DefaultView.RowFilter = string.Empty;
                this.dataGridView_tareas.DataSource = busqueda;


                if (nombre_columna == "Descripción")
                {
                    filtro = " ( Descripción like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%' OR DescripcionSinAcentos  like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%' ) ";
                }
                else if (nombre_columna != "Id")
                {
                    filtro =  " ( " +nombre_columna + " like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%' ) ";
                }

                if (filtroConcat != null && filtroConcat.Length > 0) busqueda.DefaultView.RowFilter = filtroConcat + " AND " + filtro;
                else busqueda.DefaultView.RowFilter = filtro;
                dataGridView_tareas.DataSource = busqueda;
                ajustarDatagrid();
            }
            else if (toolStripTextBoxFiltro.TextLength > 1)
            {
                DataTable busqueda = tareas;

                if (nombre_columna == "Descripción")
                {
                    filtro = " ( Descripción like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%' OR DescripcionSinAcentos  like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%' ) ";
                }
                else if (nombre_columna != "Id")
                {
                    filtro = " ( " + nombre_columna + " like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%' ) ";
                }
                if (filtroConcat != null && filtroConcat.Length > 0) busqueda.DefaultView.RowFilter = filtroConcat + " AND " + filtro;
                else busqueda.DefaultView.RowFilter = filtro;
                dataGridView_tareas.DataSource = busqueda;
                ajustarDatagrid();
            }
        }

        private void buttonBloque_Click(object sender, EventArgs e)
        {
            if (id_comunidad != null)
            {
                FormSeleccionarBloque nueva = new FormSeleccionarBloque(this,id_comunidad);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
            else
            {
                MessageBox.Show("Selecciona una comunidad para elegir su bloque");
            }
        }

        public void recibirBloque(String idAreaBloque, String nombre)
        {
            textBoxBloque.Text = nombre;
            this.idAreaBloque = idAreaBloque;
        }

        private void textBoxBloque_DoubleClick(object sender, EventArgs e)
        {
            textBoxBloque.Text = "";
            this.idAreaBloque = null;
        }
        

        private void dataGridView_tareas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_tareas.Columns["FIni"].Index)
            {
                if (ordFIni == null || ordFIni == "DESC")
                {
                    ordFIni = "ASC";
                    ordFFin = null;
                }
                else
                {
                    ordFIni = "DESC";
                    ordFFin = null;
                }
                ordDescripcion = null;
                aplicarFiltroTabla();
            }
            else if (e.ColumnIndex == dataGridView_tareas.Columns["FFin"].Index)
            {
                if (ordFFin == null || ordFFin == "DESC")
                {
                    ordFIni = null;
                    ordFFin = "ASC";
                }
                else
                {
                    ordFIni = null;
                    ordFFin = "DESC";
                }
                ordDescripcion = null;
                aplicarFiltroTabla();
            }
            else if (e.ColumnIndex == dataGridView_tareas.Columns["Descripción"].Index)
            {
                if (ordDescripcion != null && ordDescripcion == "ASC") ordDescripcion = "DESC";
                else ordDescripcion = "ASC";
                ordFFin = null;
                ordFIni = null;
            }

        }

        private void textBox_Entidad_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.id_comunidad = null;
            this.id_entidad = null;
            maskedTextBoxRefComunidad.Text = "";
            textBox_Entidad.Text = "";
            aplicarFiltroTabla();
        }

        public void filtroNombre()
        {
            DataTable busqueda = tareas;
            busqueda.DefaultView.RowFilter = string.Empty;
            this.dataGridView_tareas.DataSource = busqueda;
            busqueda.DefaultView.RowFilter = filtro;
            this.dataGridView_tareas.DataSource = busqueda;
            ajustarDatagrid();
        }

        private void buttonServicio_Click(object sender, EventArgs e)
        {
            if (idAreaBloque != null)
            {
                FormSeleccionarCategoria nueva = new FormSeleccionarCategoria(this);
                nueva.Show();
            }
            else
            {
                FormSeleccionarCategoria nueva = new FormSeleccionarCategoria(this,idAreaBloque);
                nueva.Show();
            }
        }

        public void recibirCategoria(String nombreCategoria,String codigoCategoria)
        {
            textBoxServicio.Text = nombreCategoria;
            codigoCat = "S" + codigoCategoria;
        }

        private void textBoxServicio_DoubleClick(object sender, EventArgs e)
        {
            textBoxServicio.Text = "";
            this.codigoCat = null;
        }
        
    }
}
