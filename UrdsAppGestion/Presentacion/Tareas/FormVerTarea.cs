using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace UrdsAppGestión.Presentacion.Tareas
{
    public partial class FormVerTarea : Form
    {

        private String idTarea;
        private String ruta;
        private String idEntidad;
        private String idGestion;
        private String fInicio;
        private String fechaFin;
        private DataTable tarea;
        private DataTable gestion;
        private DataTable seguimiento;
        private DataTable contactos;
        private FormTareasPrincipal form_anterior;
        private int idComunidad;
        private String columnaContacto;
        private Boolean conBloque;
        private Boolean duplicar;
        private String idTipoTareaDupli;
        private String idTareaDupli;
        private bool contactosDupli;
        private bool expedientesDupli;
        private DataTable tablaBloque;
        private DataTable tablaFinalServicios;
        private bool edicion;

        public FormVerTarea(FormTareasPrincipal form_anterior, String idTarea)
        {
            InitializeComponent();
            this.idTarea = idTarea;
            this.form_anterior = form_anterior;
            idComunidad = 0;
            duplicar = false;
            conBloque = false;
        }

        public FormVerTarea(String idTarea)
        {
            InitializeComponent();
            this.idTarea = idTarea;
            idComunidad = 0;
            duplicar = false;
            conBloque = false;
        }

        public FormVerTarea(FormTareasPrincipal form_anterior)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            idComunidad = 0;
            duplicar = false;
            conBloque = false;
        }
        //DUPLICAR TAREA
        public FormVerTarea(FormTareasPrincipal form_anterior, String idTipoTarea,String fIni, String descripcion, String coste, String seguro, String acuerdoJunta, String fechaActaAcordado, String proximaJunta, String refSiniestro, String fFin,String notas, String importante,String idEntidad, String nombreComunidad, int idComunidad, String Referencia, String idTarea,Boolean contactos, Boolean expedientes)
        {
            InitializeComponent();
            conBloque = false;
            this.form_anterior = form_anterior;
            idTipoTareaDupli = idTipoTarea;
            textBoxDescripcion.Text = descripcion;
            textBoxNotas.Text = notas;
            comboBoxTipo.SelectedValue = idTipoTarea;
            maskedTextBoxFFin.Text = fFin;
            fechaFin = fFin;
            maskedTextBoxFIni.Text = fIni;
            fInicio = fIni;
            textBoxCoste.Text = coste;
            textBoxSiniestro.Text = refSiniestro;
            if ( seguro == "-1") checkBoxSeguro.Checked = true;
            if ( acuerdoJunta == "-1") checkBoxAcuerdoJunta.Checked = true;
            maskedTextBoxFechaActa.Text = fechaActaAcordado;
            if ( proximaJunta == "-1") checkBoxProxJunta.Checked = true;
            if ( importante == "-1") checkBoxImportante.Checked = true;
            this.idEntidad = idEntidad;
            if (idEntidad != null) conBloque = true;
            textBoxEntidad.Text = nombreComunidad;
            this.idComunidad = idComunidad;
            maskedTextBoxReferencia.Text = Referencia;
            duplicar = true;
            this.idTareaDupli = idTarea;
            this.contactosDupli = contactos;
            this.expedientesDupli = expedientes;
        }
        private void FormVerTarea_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
            //VER TAREA
            if (duplicar)
            {
                comboBoxTipo.SelectedValue = idTipoTareaDupli;
                addTarea();
                duplicarTarea();
                form_anterior.CargarTareas();
                form_anterior.aplicarFiltroTabla();
                form_anterior.filtroNombre();
            }
            if (idTarea != null)
            {
                cargarCabecera();
                comboBoxEstadoGestion.SelectedIndex = 2; //TODAS
                //cargarTodosSeguimientos();
                cargarContactos();
                cargarExpedientes();
                cargarBloque();
                bloquearEdicion();
            }
            //NUEVA TAREA
            if (idTarea == null)
            {
                habilitarEdicion();
            }
            if (ruta != "")
            {
                textBoxRuta.Cursor = Cursors.Hand;
            }
            if (duplicar) habilitarEdicion();
        }

        public void cargarCabecera()
        {
            
            String sqlSelect = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tareas.IdEntidad, exp_tareas.Notas, exp_tareas.Ruta, exp_tareas.IdTipoTarea, exp_tareas.FFin, exp_tareas.FIni, exp_tareas.Coste, exp_tareas.RefSiniestro, exp_tareas.Seguro, exp_tareas.AcuerdoJunta, exp_tareas.FechaActaAcordado, exp_tareas.ProximaJunta, com_comunidades.Referencia, ctos_entidades.Entidad, exp_tareas.Importante, exp_tareas.IdTareaCorto FROM((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad) WHERE(((exp_tareas.IdTarea) = " + idTarea + "))";
            tarea = Persistencia.SentenciasSQL.select(sqlSelect);
            
            textBoxIdTarea.Text = tarea.Rows[0][0].ToString();
            textBoxIdTareaNuevo.Text = tarea.Rows[0][17].ToString();
            textBoxDescripcion.Text = tarea.Rows[0][1].ToString();
            idEntidad = tarea.Rows[0][2].ToString();
            if (idEntidad != null) conBloque = true;
            textBoxNotas.Text = tarea.Rows[0][3].ToString();
            textBoxRuta.Text = limpiaRuta(tarea.Rows[0][4].ToString());
            comboBoxTipo.SelectedValue = tarea.Rows[0][5].ToString();
            maskedTextBoxFFin.Text = tarea.Rows[0][6].ToString();
            fechaFin = tarea.Rows[0][6].ToString();
            maskedTextBoxFIni.Text = tarea.Rows[0][7].ToString();
            fInicio = tarea.Rows[0][7].ToString();
            textBoxCoste.Text = tarea.Rows[0][8].ToString();
            textBoxSiniestro.Text = tarea.Rows[0][9].ToString();
            checkBoxSeguro.Checked = bool.Parse(tarea.Rows[0][10].ToString());
            checkBoxAcuerdoJunta.Checked = bool.Parse(tarea.Rows[0][11].ToString());
            if (tarea.Rows[0][12].ToString() != "00/00/0000") maskedTextBoxFechaActa.Text = tarea.Rows[0][12].ToString();
            checkBoxProxJunta.Checked = bool.Parse(tarea.Rows[0][13].ToString());
            maskedTextBoxReferencia.Text = tarea.Rows[0][14].ToString();
            if (maskedTextBoxReferencia.Text != "") nombreReferencia();
            textBoxEntidad.Text = tarea.Rows[0][15].ToString();
            checkBoxImportante.Checked = bool.Parse(tarea.Rows[0][16].ToString());
            this.Name = "FormVerTarea" + idTarea;
        }

        public void bloquearEdicion()
        {
            textBoxDescripcion.ReadOnly = true;
            maskedTextBoxReferencia.ReadOnly = true;
            textBoxNotas.ReadOnly = true;
            comboBoxTipo.Enabled = false;
            maskedTextBoxFFin.ReadOnly = true;
            if (maskedTextBoxFFin.Text == "  /  /") maskedTextBoxFFin.Mask = "";
            maskedTextBoxFIni.ReadOnly = true;
            if (maskedTextBoxFIni.Text == "  /  /") maskedTextBoxFIni.Mask = "";
            textBoxCoste.ReadOnly = true;
            checkBoxImportante.AutoCheck = false;
            textBoxSiniestro.ReadOnly = true;
            checkBoxSeguro.AutoCheck = false;
            checkBoxAcuerdoJunta.AutoCheck = false;
            maskedTextBoxFechaActa.ReadOnly = true;
            if (maskedTextBoxFechaActa.Text == "  /  /") maskedTextBoxFechaActa.Mask = "";
            checkBoxProxJunta.AutoCheck = false;
            buttonEditar.Enabled = true;
            buttonEliminarTarea.Enabled = true;
            buttonGuardar.Enabled = false;
            textBoxRuta.ReadOnly = true;
            labelRutaLink.Enabled = false;
            buttonBloque.Visible = false;
            buttonDuplicarTarea.Enabled = true;
            edicion = false;

        }

        public void habilitarEdicion()
        {
            textBoxDescripcion.ReadOnly = false;
            maskedTextBoxReferencia.ReadOnly = false;
            textBoxNotas.ReadOnly = false;
            comboBoxTipo.Enabled = true;
            maskedTextBoxFFin.ReadOnly = false;
            maskedTextBoxFFin.Mask = "00/00/0000";
            maskedTextBoxFIni.ReadOnly = false;
            maskedTextBoxFIni.Mask = "00/00/0000";
            textBoxCoste.ReadOnly = false;
            textBoxSiniestro.ReadOnly = false;
            checkBoxSeguro.AutoCheck = true;
            checkBoxAcuerdoJunta.AutoCheck = true;
            maskedTextBoxFechaActa.ReadOnly = false;
            maskedTextBoxFechaActa.Mask = "00/00/0000";
            checkBoxProxJunta.AutoCheck = true;
            buttonEditar.Enabled = false;
            buttonEliminarTarea.Enabled = false;
            buttonGuardar.Enabled = true;
            checkBoxImportante.AutoCheck = true;
            textBoxRuta.ReadOnly = false;
            labelRutaLink.Enabled = true;
            buttonBloque.Visible = true;
            buttonDuplicarTarea.Enabled = false;
            if (textBoxEntidad.Text == "")
            {
                textBoxEntidad.Text = "Pulsa espacio para Seleccionar Entidad";
                textBoxEntidad.ForeColor = Color.Gray;
            }
            edicion = true;
        }

        public void rellenarComboBox()
        {
            DataTable tipos;
            String sqlComboTipo = "SELECT exp_tipostareas.IdTipoTarea, exp_tipostareas.TipoTarea FROM exp_tipostareas";
            tipos = Persistencia.SentenciasSQL.select(sqlComboTipo);
            DataRow filavacio = tipos.NewRow();
            filavacio["TipoTarea"] = "";
            filavacio["IdTipoTarea"] = 0;
            tipos.Rows.InsertAt(filavacio, 0);
            comboBoxTipo.DataSource = tipos;
            comboBoxTipo.DisplayMember = "TipoTarea";
            comboBoxTipo.ValueMember = "IdTipoTarea";
            
            
        }
        
        public void cargarGestiones()
        {

            //String sqlSelect = "SELECT exp_gestiones.IdGestión AS Id, exp_gestiones.Orden AS Ord, ctos_urendes.Usuario, exp_gestiones.Descripción, exp_tipogestion.Descripcion AS `Tipo Gestión`, exp_gestiones.Importante AS S, exp_gestiones.FIni, exp_gestiones.FSeguir AS FAgenda, exp_gestiones.FMax AS `Fecha Límite`, exp_gestiones.FFin,ctos_entidades.Entidad AS `Espera de`, exp_gestiones.TipoContacto as T FROM(((exp_gestiones INNER JOIN ctos_urendes ON exp_gestiones.IdUser = ctos_urendes.IdURD) INNER JOIN exp_niveles ON exp_gestiones.IdNivel = exp_niveles.IdNivel) LEFT JOIN ctos_entidades ON exp_gestiones.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE(((exp_gestiones.IdTarea) = " + idTarea + ")";

            String sqlSelect = "SELECT exp_gestiones.IdGestión AS Id, exp_gestiones.Orden AS Ord, ctos_urendes.Usuario, exp_gestiones.Descripción, exp_tipogestion.Descripcion AS `Tipo Gestión`, exp_gestiones.Importante AS S, exp_gestiones.FIni, exp_gestiones.FSeguir AS FAgenda, exp_gestiones.FMax AS `Fecha Límite`, exp_gestiones.FFin,If(exp_gestiones.TipoContacto = 'T',exp_contactos.Nombre ,If(exp_gestiones.TipoContacto = 'G',(SELECT com_cargos.Cargo FROM com_cargos INNER JOIN (com_comuneros INNER JOIN com_cargoscom ON com_comuneros.IdComunero = com_cargoscom.IdComunero) ON com_cargos.IdCargo = com_cargoscom.IdCargo WHERE(((com_comuneros.IdEntidad) = exp_gestiones.IdEntidad)) LIMIT 1 ),ctos_entidades.Entidad)) AS `Espera de`, exp_gestiones.TipoContacto AS T FROM exp_contactos RIGHT JOIN ((((exp_gestiones INNER JOIN ctos_urendes ON exp_gestiones.IdUser = ctos_urendes.IdURD) INNER JOIN exp_niveles ON exp_gestiones.IdNivel = exp_niveles.IdNivel) LEFT JOIN ctos_entidades ON exp_gestiones.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion) ON exp_contactos.IdDetEntTarea = exp_gestiones.IdEntidad WHERE(((exp_gestiones.IdTarea) = " + idTarea + ")";

            //Abiertas
            if (comboBoxEstadoGestion.SelectedIndex == 0)
            {
                sqlSelect += " AND exp_gestiones.FFin IS Null";
            }
            //Cerradas
            else if (comboBoxEstadoGestion.SelectedIndex == 1)
            {
                sqlSelect += " AND exp_gestiones.FFin IS Not Null";
            }

            sqlSelect += ") ORDER BY exp_gestiones.FIni DESC,exp_gestiones.FFin ASC";
            gestion = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewGestiones.DataSource = gestion;
            ajustarDatagridGestiones();
        }

        public void cargarTodosSeguimientos()
        {
            String sqlSelect = "SELECT exp_notas.IdNota, exp_notas.IdGestión,CAST(exp_notas.Fecha AS DATE) AS Fecha, ctos_urendes.Usuario, exp_notas.Notas FROM exp_tareas INNER JOIN (((exp_tiposeguimiento RIGHT JOIN exp_notas ON exp_tiposeguimiento.IdTipoSeg = exp_notas.IdTipoSeg) INNER JOIN ctos_urendes ON exp_notas.IdURD = ctos_urendes.IdURD) INNER JOIN exp_gestiones ON exp_notas.IdGestión = exp_gestiones.IdGestión) ON exp_tareas.IdTarea = exp_gestiones.IdTarea WHERE(((exp_tareas.IdTarea) = " + idTarea + ")) ORDER BY exp_notas.IdNota DESC";


            seguimiento = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewSeguimientos.DataSource = seguimiento;
            ajustarDatagridSeguimientos();
        }

        public void cargarSeguimientos()
        {

            String sqlSelect = "SELECT exp_notas.IdNota,CAST(exp_notas.Fecha AS DATE) AS Fecha, exp_notas.IdGestión, ctos_urendes.Usuario, exp_notas.Notas FROM(exp_tiposeguimiento RIGHT JOIN exp_notas ON exp_tiposeguimiento.IdTipoSeg = exp_notas.IdTipoSeg) INNER JOIN ctos_urendes ON exp_notas.IdURD = ctos_urendes.IdURD WHERE(((exp_notas.IdGestión) = " + idGestion + ")) ORDER BY exp_notas.IdNota DESC";
            

            seguimiento = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewSeguimientos.DataSource = seguimiento;
            ajustarDatagridSeguimientos();
        }

        private void dataGridViewGestiones_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridViewGestiones.SelectedCells.Count > 0)
            {
                idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
                    
                cargarSeguimientos();
            }
                
        }
        private void ajustarDatagridSeguimientos()
        {
            if (dataGridViewSeguimientos.Rows.Count > 0)
            {
                dataGridViewSeguimientos.Columns[0].Visible = false;
                dataGridViewSeguimientos.Columns["IdGestión"].Width = 50;
                dataGridViewSeguimientos.Columns["Fecha"].Width = 80;
                dataGridViewSeguimientos.Columns["Usuario"].Width = 60;
                dataGridViewSeguimientos.Columns["Notas"].Width = 423;
                dataGridViewSeguimientos.Columns["Notas"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void textBoxRuta_Click(object sender, EventArgs e)
        {
            
            if (ruta != "" && ruta != null && textBoxRuta.Text == "")
            {
                try
                {
                    System.Diagnostics.Process.Start(@ruta);
                }
                catch
                {
                    MessageBox.Show("No se encuentra la carpeta");
                }
            }
            else if (textBoxRuta.Text != "")
            {
                try
                {
                    System.Diagnostics.Process.Start(@textBoxRuta.Text);
                }
                catch
                {
                    MessageBox.Show("No se encuentra la carpeta");
                }
            }
        }

        public void ajustarDatagridGestiones()
        {
            if (dataGridViewGestiones.Rows.Count > 0)
            {
                dataGridViewGestiones.Columns["Id"].Width = 70;
                dataGridViewGestiones.Columns["Ord"].Visible = false;
                dataGridViewGestiones.Columns["Usuario"].Width = 70;
                dataGridViewGestiones.Columns["Descripción"].Width = 290;
                dataGridViewGestiones.Columns["Tipo Gestión"].Width = 120;
                dataGridViewGestiones.Columns["S"].Width = 30;
                dataGridViewGestiones.Columns["FIni"].Width = 90;
                dataGridViewGestiones.Columns["FAgenda"].Width = 90;
                dataGridViewGestiones.Columns["Fecha límite"].Width = 95;
                dataGridViewGestiones.Columns["FFin"].Width = 90;
                dataGridViewGestiones.Columns["Espera de"].Width = 240;
                dataGridViewGestiones.Columns["T"].Width = 20;
                dataGridViewGestiones.Columns["T"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxDescripcion.Text != "" && comboBoxTipo.SelectedIndex != 0 && maskedTextBoxFIni.Text == "  /  /" && conBloque && (idEntidad != null || idComunidad != 0))
            {
                maskedTextBoxFIni.Text = DateTime.Now.ToShortDateString();
            }
            else if (textBoxDescripcion.Text == "" || comboBoxTipo.SelectedIndex == 0  || !conBloque || maskedTextBoxFIni.Text == "  /  /" || (idEntidad == null && idComunidad == 0))
            {
                MessageBox.Show("Los campos DESCRIPCIÓN,ENTIDAD,TIPO, BLOQUE y FECHA INICIO son obligatorios");
                return;
            }
            
                if (maskedTextBoxReferencia.Text != "") idEntidad = entidadReferencia();
                addTarea();
                textBoxIdTarea.Text = idTarea;
                textBoxIdTareaNuevo.Text = idTareaNuevo(idTarea);
                bloquearEdicion();
                if (form_anterior != null)
                {
                    form_anterior.CargarTareas();
                    form_anterior.aplicarFiltroTabla();
                    form_anterior.filtroNombre();
                }

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            habilitarEdicion();
        }

        private void buttonAddGestion_Click(object sender, EventArgs e)
        {
            if (idTarea == null)
            {
                if (textBoxDescripcion.Text != "" && comboBoxTipo.SelectedIndex != 0 && maskedTextBoxFIni.Text == "  /  /" && conBloque && (idEntidad != null || idComunidad != 0))
                {
                    maskedTextBoxFIni.Text = DateTime.Now.ToShortDateString();
                }
                else if (textBoxDescripcion.Text == "" || comboBoxTipo.SelectedIndex == 0 || !conBloque || maskedTextBoxFIni.Text == "  /  /" || (idEntidad == null && idComunidad == 0))
                {
                    MessageBox.Show("Los campos DESCRIPCIÓN,ENTIDAD,TIPO, BLOQUE y FECHA INICIO son obligatorios.");
                    return;
                }
                    
                if (maskedTextBoxReferencia.Text != "") idEntidad = entidadReferencia();
                addTarea();
                textBoxIdTarea.Text = idTarea;
                textBoxIdTareaNuevo.Text = idTareaNuevo(idTarea);
                comboBoxEstadoGestion.SelectedIndex = 2;
                bloquearEdicion();
                if (form_anterior != null)
                {
                    form_anterior.CargarTareas();
                    form_anterior.aplicarFiltroTabla();
                    form_anterior.filtroNombre();
                }
                Tareas.FormInsertarGestion nueva = new FormInsertarGestion(this, idTarea, fInicio,idComunidad);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
            else
            {
                addTarea();
                bloquearEdicion();
                comboBoxEstadoGestion.SelectedIndex = 2;
                Tareas.FormInsertarGestion nueva = new FormInsertarGestion(this, idTarea, fInicio, idComunidad);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
        }

        private void buttonAddSeguimiento_Click(object sender, EventArgs e)
        {
            try
            {
                String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
                Tareas.FormInsertarSeguimiento nueva = new FormInsertarSeguimiento(this, idGestion);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
            catch
            {
                MessageBox.Show("Necesitas seleccionar una gestion a la que añadir el seguimiento");
            }
        }

        private void toolStripMenuItemEliminarGestion_Click(object sender, EventArgs e)
        {
            String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
            
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta Gestión ?", "Borrar Gestion", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM exp_gestiones WHERE IdGestión = " + idGestion;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);

                cargarGestiones();
                cargarSeguimientos();
            }
        }

        private void dataGridViewGestiones_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewGestiones.HitTest(e.X, e.Y);
                //EVITAR QUE COJA LA CABECERA
                if (hti.RowIndex > -1)
                {
                    dataGridViewGestiones.ClearSelection();
                    dataGridViewGestiones.Rows[hti.RowIndex].Selected = true;
                    dataGridViewGestiones.Columns[hti.ColumnIndex].Selected = true;
                    dataGridViewGestiones.CurrentCell = this.dataGridViewGestiones[hti.ColumnIndex, hti.RowIndex];
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void dataGridViewSeguimientos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewSeguimientos.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    dataGridViewSeguimientos.ClearSelection();
                    dataGridViewSeguimientos.Rows[hti.RowIndex].Selected = true;
                    dataGridViewSeguimientos.Columns[hti.ColumnIndex].Selected = true;
                    dataGridViewSeguimientos.CurrentCell = this.dataGridViewSeguimientos[hti.ColumnIndex, hti.RowIndex];
                    contextMenuStrip2.Show(Cursor.Position);
                }
            }
        }

        private void ToolStripMenuItemEliminarSeguimiento_Click(object sender, EventArgs e)
        {
            String idSeguimiento = dataGridViewSeguimientos.SelectedRows[0].Cells[0].Value.ToString();

            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este Seguimiento ?", "Borrar Seguimiento", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM exp_notas WHERE IdNota = " + idSeguimiento;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarSeguimientos();
            }
        }

        private void maskedTextBoxFIni_Leave(object sender, EventArgs e)
        {
            if (maskedTextBoxFIni.Text == "  /  /") maskedTextBoxFIni.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);

            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBoxFIni.Text, sPattern))
            {
                maskedTextBoxFIni.Text = maskedTextBoxFIni.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBoxFIni.Text, sPattern1))
            {
                maskedTextBoxFFin.SelectAll();
            }
            else
            {
                maskedTextBoxFIni.Focus();
                maskedTextBoxFIni.SelectAll();
            }
        }

        private void toolStripMenuItemEditarGestion_Click(object sender, EventArgs e)
        {
            String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
            Tareas.FormInsertarGestion nueva = new FormInsertarGestion(this, idTarea,idGestion,fInicio, idComunidad);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void toolStripMenuItemEditarSeguimiento_Click(object sender, EventArgs e)
        {
            String idSeguimiento = dataGridViewSeguimientos.SelectedRows[0].Cells[0].Value.ToString();
            Tareas.FormInsertarSeguimiento nueva = new FormInsertarSeguimiento(this, idGestion, idSeguimiento);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void dataGridViewGestiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tareas.FormInsertarGestion nueva = new FormInsertarGestion(this,idGestion, idComunidad);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void dataGridViewSeguimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String idSeguimiento = dataGridViewSeguimientos.SelectedRows[0].Cells[0].Value.ToString();

            Tareas.FormInsertarSeguimiento nueva = new FormInsertarSeguimiento(this,idGestion,idSeguimiento,false);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void buttonRuta_Click(object sender, EventArgs e)
        {
            if (textBoxDescripcion.Text != "" && comboBoxTipo.SelectedIndex != 0 && conBloque && maskedTextBoxFIni.Text == "  /  /" && (idEntidad != null || idComunidad != 0))
            {
                maskedTextBoxFIni.Text = DateTime.Now.ToShortDateString();
            }
            else if (textBoxDescripcion.Text == "" || comboBoxTipo.SelectedIndex == 0  || !conBloque || maskedTextBoxFIni.Text == "  /  /" || (idEntidad == null && idComunidad == 0))
            {
                MessageBox.Show("Los campos DESCRIPCIÓN,ENTIDAD,TIPO, BLOQUE  y FECHA INICIO son obligatorios.");
                return;
            }

            if ((ruta == null || ruta == "") && textBoxRuta.Text == "")
            {
                if (maskedTextBoxReferencia.Text != "") idEntidad = entidadReferencia();
                addTarea();
                textBoxIdTarea.Text = idTarea;
                textBoxIdTareaNuevo.Text = idTareaNuevo(idTarea);
                if (form_anterior != null)
                {
                    form_anterior.CargarTareas();
                    form_anterior.aplicarFiltroTabla();
                    form_anterior.filtroNombre();
                }

                String tarea = idTarea + " " + textBoxDescripcion.Text;
                String rutaCheck = rutaEntidad().Trim('#');
                ruta = @rutaCheck + @"\EXPEDIENTES\" + tarea;

                //LA CARPETA DE LA RUTA YA ESTÁ CREADA
                if (System.IO.Directory.Exists(ruta))
                {
                    MessageBox.Show("La Carpeta de la tarea ya existe!");
                    textBoxRuta.Text = ruta;
                    textBoxRuta.Cursor = Cursors.Hand;
                }
                //LA CARPETA DE LA COMUNIDAD EXISTE
                else if (System.IO.Directory.Exists(rutaCheck))
                {
                    System.IO.Directory.CreateDirectory(ruta);
                    textBoxRuta.Text = ruta;
                    addTarea();
                    textBoxRuta.Cursor = Cursors.Hand;
                }
                //LA CARPETA DE LA COMUNIDAD NO EXISTE
                else
                {
                    MessageBox.Show("No se encuentra la carpeta de la comunidad, contacte con el administrador");
                    ruta = "";
                }
                
            }
            else
            {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Ya existe una ruta, desea sobreescribirla?", "Crear nueva ruta ", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    if (comboBoxTipo.SelectedValue.ToString() == "0")
                    {
                        MessageBox.Show("Selecciona un tipo de Tarea!");
                        return;
                    }
                    else
                    {
                        if (maskedTextBoxReferencia.Text != "") idEntidad = entidadReferencia();
                        addTarea();
                        textBoxIdTarea.Text = idTarea;
                        textBoxIdTareaNuevo.Text = idTareaNuevo(idTarea);
                        if (form_anterior != null)
                        {
                            form_anterior.CargarTareas();
                            form_anterior.aplicarFiltroTabla();
                            form_anterior.filtroNombre();
                        }

                        String tarea = idTarea + " " + textBoxDescripcion.Text;
                        String rutaCheck = rutaEntidad().Trim('#');
                        ruta = @rutaCheck + @"\EXPEDIENTES\" + tarea;

                        //LA CARPETA DE LA RUTA YA ESTÁ CREADA
                        if (System.IO.Directory.Exists(ruta))
                        {
                            MessageBox.Show("¡La Carpeta de la tarea ya existe!");
                            textBoxRuta.Text = ruta;
                            textBoxRuta.Cursor = Cursors.Hand;
                        }
                        //LA CARPETA DE LA COMUNIDAD EXISTE
                        else if (System.IO.Directory.Exists(rutaCheck))
                        {
                            System.IO.Directory.CreateDirectory(ruta);
                            textBoxRuta.Text = ruta;
                            addTarea();
                            textBoxRuta.Cursor = Cursors.Hand;
                        }
                        //LA CARPETA DE LA COMUNIDAD NO EXISTE
                        else
                        {
                            MessageBox.Show("No se encuentra la carpeta de la comunidad, contacte con el administrador");
                            ruta = "";
                        }
                    }
                }
            }
        }

        private void maskedTextBoxFFin_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";
            DateTime DateIni = DateTime.Parse(maskedTextBoxFIni.Text);
            DateTime DateFin;

            if (Regex.IsMatch(maskedTextBoxFFin.Text, sPattern))
            {
                maskedTextBoxFFin.Text = maskedTextBoxFFin.Text + DateTime.Now.Year;
                DateFin = DateTime.Parse(maskedTextBoxFFin.Text);
                if (DateTime.Compare(DateIni, DateFin) > 0)
                {
                    MessageBox.Show("La fecha de fin no puede ser anterior a la de inicio.");
                    maskedTextBoxFFin.Focus();
                    maskedTextBoxFFin.SelectAll();
                }
                else
                {
                    textBoxCoste.SelectAll();
                }
            }
            else if (Regex.IsMatch(maskedTextBoxFFin.Text, sPattern1))
            {
                DateFin = DateTime.Parse(maskedTextBoxFFin.Text);
                if (DateTime.Compare(DateIni, DateFin) > 0)
                {
                    MessageBox.Show("La fecha de fin no puede ser anterior a la de inicio.");
                    maskedTextBoxFFin.Focus();
                    maskedTextBoxFFin.SelectAll();
                }
                else
                {
                    textBoxCoste.SelectAll();
                }
            }
            else
            {
                if (maskedTextBoxFFin.Text != "  /  /" && maskedTextBoxFFin.Text != "")
                { 
                    maskedTextBoxFFin.Focus();
                    maskedTextBoxFFin.SelectAll();
                }
            }
        }

        //AÑADIR O EDITAR TAREA
        private void addTarea()
        {
            //if (textBoxDescripcion.Text == "" || comboBoxTipo.SelectedIndex == 0 || !conBloque || maskedTextBoxFIni.Text == "  /  /" || (idEntidad == null && idComunidad == 0))
            //{
            //    MessageBox.Show("Los campos DESCRIPCIÓN,ENTIDAD,TIPO, BLOQUE y FECHA INICIO son obligatorios.");
            //    return;
            //}
            String idTipoTarea = comboBoxTipo.SelectedValue.ToString();
            String fIni = null;
            fInicio = maskedTextBoxFIni.Text;
            if (maskedTextBoxFIni.Text != "  /  /" && maskedTextBoxFIni.Text != "") fIni = Convert.ToDateTime(maskedTextBoxFIni.Text).ToString("yyyy-MM-dd");
            String descripcion = "";
            if (textBoxDescripcion.Text != "") descripcion = textBoxDescripcion.Text;
            String coste = "";
            if (textBoxCoste.Text != "") coste = textBoxCoste.Text;
            String seguro = "0";
            if (checkBoxSeguro.Checked) seguro = "-1";
            String acuerdoJunta = "0";
            if (checkBoxAcuerdoJunta.Checked) acuerdoJunta = "-1";
            String fechaActaAcordado = null;
            if (maskedTextBoxFechaActa.Text != "  /  /" && maskedTextBoxFechaActa.Text != "") fechaActaAcordado = Convert.ToDateTime(maskedTextBoxFechaActa.Text).ToString("yyyy-MM-dd");
            String proximaJunta = "0";
            if (checkBoxProxJunta.Checked) proximaJunta = "-1";
            String refSiniestro = textBoxSiniestro.Text;
            String fFin = null;
            if (maskedTextBoxFFin.Text != "  /  /" && maskedTextBoxFFin.Text != "") fFin = Convert.ToDateTime(maskedTextBoxFFin.Text).ToString("yyyy-MM-dd");
            String ruta = textBoxRuta.Text;
            String notas = textBoxNotas.Text;
            String importante = "0";
            if (checkBoxImportante.Checked) importante = "-1";

            //EDITAR TAREA
            if (idTarea != null)
            {
                String fixRuta = ruta.Replace(@"\", @"\\");
                String sqlUpdate = "UPDATE exp_tareas SET IdEntidad = " + idEntidad + ",IdRbleTarea = " + Login.getId() + ",IdTipoTarea = " + idTipoTarea + ",Descripción = '" + descripcion + "',Seguro = " + seguro + ",AcuerdoJunta = " + acuerdoJunta + ",RefSiniestro = '" + refSiniestro + "',ProximaJunta = " + proximaJunta + ",Notas = '" + notas + "' WHERE IdTarea = " + idTarea;
                Persistencia.SentenciasSQL.InsertarGenericoID(sqlUpdate);
                if (fIni != null)
                {
                    sqlUpdate = "UPDATE exp_tareas SET FIni = '" + fIni + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (fFin != null)
                {
                    sqlUpdate = "UPDATE exp_tareas SET FFin = '" + fFin + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                else if (fechaFin != null)
                {
                    fechaFin = null;
                    sqlUpdate = "UPDATE exp_tareas SET FFin = NULL WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (coste != "")
                {
                    sqlUpdate = "UPDATE exp_tareas SET Coste = '" + coste + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (fechaActaAcordado != null)
                {
                    sqlUpdate = "UPDATE exp_tareas SET FechaActaAcordado = '" + fechaActaAcordado + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (ruta != null)
                {
                    sqlUpdate = "UPDATE exp_tareas SET Ruta = '" + fixRuta + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (idTipoTarea == "2" || importante == "-1")
                {
                    sqlUpdate = "UPDATE exp_tareas SET Importante = -1 WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if(importante == "0")
                {
                    sqlUpdate = "UPDATE exp_tareas SET Importante = 0 WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                /*
                if (idElemento != null && idElemento != "-1")
                {
                    sqlUpdate = "UPDATE exp_tareas SET IdElemento = '" + idElemento +"' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                */
            }
            //AÑADIR NUEVA TAREA
            else
            {
                String fixRuta = ruta.Replace(@"\", @"\\");
                String sqlInsert = "INSERT INTO exp_tareas (IdEntidad,IdRbleTarea,IdTipoTarea,Descripción,Seguro,AcuerdoJunta,ProximaJunta,RefSiniestro,Notas,FIni) VALUES (" + idEntidad + "," + Login.getId() + "," + idTipoTarea + ",'" + descripcion + "'," + seguro + "," + acuerdoJunta + "," + proximaJunta + ",'" + refSiniestro + "','" + notas + "','" + fIni + "')";
                idTarea = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();

                if (fFin != null)
                {
                    sqlInsert = "UPDATE exp_tareas SET FFin = '" + fFin + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                if (coste != "")
                {
                    sqlInsert = "UPDATE exp_tareas SET Coste = '" + coste + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                if (fechaActaAcordado != null)
                {
                    sqlInsert = "UPDATE exp_tareas SET FechaActaAcordado = '" + fechaActaAcordado + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                if (idTipoTarea == "2" || importante == "-1")
                {
                    sqlInsert = "UPDATE exp_tareas SET Importante = -1 WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                if (importante == "0")
                {
                    sqlInsert = "UPDATE exp_tareas SET Importante = 0 WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                if (ruta != null)
                {
                    sqlInsert = "UPDATE exp_tareas SET Ruta = '" + fixRuta + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                /*
                if (idElemento != null && idElemento != "-1")
                {
                    sqlInsert = "UPDATE exp_tareas SET IdElemento = '" + idElemento + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                */
                String Nombre = "FormVerTarea" + idTarea;

                this.Name = Nombre;
            }
        }
        public String rutaEntidad()
        {
            String sql = "SELECT ctos_entidades.Ruta FROM ctos_entidades WHERE(((ctos_entidades.IDEntidad) = " + idEntidad + ")); ";
            DataTable ruta = Persistencia.SentenciasSQL.select(sql);
            return ruta.Rows[0][0].ToString();
        }

        private String entidadReferencia()
        {
            String sql = "SELECT com_comunidades.IdEntidad FROM com_comunidades WHERE(((com_comunidades.Referencia) = " + maskedTextBoxReferencia.Text + "))";
            DataTable entidad = Persistencia.SentenciasSQL.select(sql);
            return entidad.Rows[0][0].ToString();
        }

        private String nombreReferencia()
        {
            String sql = "SELECT ctos_entidades.Entidad,com_comunidades.IdComunidad,com_comunidades.IdEntidad FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.Referencia) = " + maskedTextBoxReferencia.Text + "))";
            DataTable entidad = Persistencia.SentenciasSQL.select(sql);
            idComunidad = Int32.Parse(entidad.Rows[0][1].ToString());
            idEntidad = entidad.Rows[0][2].ToString();
            return entidad.Rows[0][0].ToString();
        }

        private void textBoxEntidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Space || e.KeyChar == (Char)Keys.Enter)
            {
                maskedTextBoxReferencia.Text = "";
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
            idEntidad = id_entidad;
            String sqlSelect = "SELECT ctos_entidades.Entidad, com_comunidades.Referencia , com_comunidades.idComunidad FROM ctos_entidades LEFT JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + id_entidad + "))";
            DataTable entidad = Persistencia.SentenciasSQL.select(sqlSelect);
            String nombre = entidad.Rows[0][0].ToString();
            if(entidad.Rows[0][1].ToString() != "")
            {
                maskedTextBoxReferencia.Text = entidad.Rows[0][1].ToString();
                idComunidad = Int32.Parse(entidad.Rows[0][2].ToString());
            }
            else
            {
                textBoxBloque.Text = "";
                conBloque = true;
            }
            textBoxEntidad.Text = nombre;
            textBoxEntidad.ForeColor = Color.Black;
        }
        

        private void maskedTextBoxReferencia_Leave(object sender, EventArgs e)
        {
            if (maskedTextBoxReferencia.Text != "")
            {
                try
                {
                    textBoxEntidad.Text = nombreReferencia();
                    textBoxEntidad.ForeColor = Color.Black;
                    buttonBloque.Focus();
                }
                catch
                {
                    maskedTextBoxReferencia.Text = "";
                    maskedTextBoxReferencia.Focus();
                }
            }
        }

        private void maskedTextBoxFechaActa_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBoxFechaActa.Text, sPattern))
            {
                maskedTextBoxFechaActa.Text = maskedTextBoxFechaActa.Text + DateTime.Now.Year;
                checkBoxProxJunta.Checked = true;
            }
            else if (Regex.IsMatch(maskedTextBoxFechaActa.Text, sPattern1))
            {
                checkBoxAcuerdoJunta.Checked = true;
            }
            else
            {
                if (maskedTextBoxFechaActa.Text != "  /  /" && maskedTextBoxFechaActa.Text != "")
                {
                    maskedTextBoxFechaActa.Focus();
                    maskedTextBoxFechaActa.SelectAll();
                }
            }
        }

        
                
    public void cargarContactos()
        {
            //String sqlSelect = "SELECT exp_contactos.IdDetEntTarea,If(exp_contactos.IdEntidad is Not Null,ctos_entidades.Entidad,exp_contactos.Nombre) AS Nombre , If (exp_contactos.IdEntidad is Not Null,ctos_dettelf.Telefono,exp_contactos.Tel) AS Teléfono, If (exp_contactos.IdEntidad is Not Null,ctos_detemail.Email,exp_contactos.Correo) AS Correo FROM((exp_contactos LEFT JOIN ctos_entidades ON exp_contactos.IdEntidad = ctos_entidades.IDEntidad)  LEFT JOIN ctos_detemail ON exp_contactos.IdMail = ctos_detemail.IdEmail) LEFT JOIN ctos_dettelf ON exp_contactos.IdTelf = ctos_dettelf.IdDetTelf WHERE(((exp_contactos.IdTarea) = " + idTarea + "))";
            String sqlSelect = "SELECT exp_contactos.IdDetEntTarea, exp_contactos.Nombre, exp_contactos.Tel AS Teléfono, exp_contactos.Correo, exp_contactos.Notas, exp_contactos.Proveedor as P, exp_contactos.Comunero as C,exp_contactos.Entidad as E  FROM exp_contactos WHERE(((exp_contactos.IdTarea) = " + idTarea + "))";

            contactos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewContactos.DataSource = contactos;
            ajustarDatagridContactos();
        }

        private void ajustarDatagridContactos()
        {
            
            //FORMATEO EL TELEFONO CON ESPACIOS PARA QUE SE PUEDA VER MEJOR
            for (int a = 0; a < dataGridViewContactos.RowCount; a++)
            {
                try
                {
                    String telefono = dataGridViewContactos.Rows[a].Cells[2].Value.ToString().Replace(" ", "");
                    dataGridViewContactos.Rows[a].Cells[2].Value = String.Format("{0:###-###-###}", double.Parse(telefono));
                }
                catch (Exception)
                {
                    MessageBox.Show("Hay un teléfono incorrecto. ¡Revisar!");
                    continue;
                }
            }

            if (dataGridViewContactos.Rows.Count > 0)
            {
                dataGridViewContactos.Columns[0].Visible = false;
                dataGridViewContactos.Columns["Nombre"].Width = 200;
                dataGridViewContactos.Columns["Teléfono"].Width = 75;
                dataGridViewContactos.Columns["Correo"].Width = 160;
                dataGridViewContactos.Columns["P"].Width = 30;
                dataGridViewContactos.Columns["C"].Width = 30;
                dataGridViewContactos.Columns["E"].Width = 30;
                dataGridViewContactos.Columns["Notas"].Width = 110;
                dataGridViewContactos.Columns["Notas"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void buttonEnviarMail_Click(object sender, EventArgs e)
        {
            try 
            {
                String mail = dataGridViewContactos.SelectedRows[0].Cells[3].Value.ToString();
                if (comprobarFormatoEmail(mail))
                {
                    System.Diagnostics.Process.Start("thunderbird", "-compose \"to=\"" + mail + ",subject=\"" + generaAsunto() + "\"");
                }
                else
                {

                    MessageBox.Show("Correo electrónico no valido");
                }
            }
            catch
            {
                MessageBox.Show("Selecciona un correo electrónico");
            }
        }

        public static bool comprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        
        private void buttonAddContacto_Click(object sender, EventArgs e)
        {
            if (idTarea == null)
            {
                MessageBox.Show("Guarda la tarea para poder añadir un Contacto");
            }
            else
            {
                Tareas.FormInsertarContacto nueva = new FormInsertarContacto(this, idTarea,idComunidad.ToString());
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
        }

        private void dataGridViewContactos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String idContacto = dataGridViewContactos.SelectedRows[0].Cells[0].Value.ToString();
            Tareas.FormInsertarContacto nueva = new FormInsertarContacto(this, idTarea, idContacto,idComunidad.ToString(), false);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void dataGridViewContactos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewContactos.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    dataGridViewContactos.ClearSelection();
                    dataGridViewContactos.Rows[hti.RowIndex].Selected = true;
                    dataGridViewContactos.Columns[hti.ColumnIndex].Selected = true;
                    dataGridViewContactos.CurrentCell = this.dataGridViewContactos[hti.ColumnIndex, hti.RowIndex];
                    columnaContacto = dataGridViewContactos.CurrentCell.OwningColumn.Name;
                    contextMenuStrip3.Show(Cursor.Position);
                }
            }
        }

        private void toolStripMenuItemEditarContacto_Click(object sender, EventArgs e)
        {
            String idContacto = dataGridViewContactos.SelectedRows[0].Cells[0].Value.ToString();
            Tareas.FormInsertarContacto nueva = new FormInsertarContacto(this, idTarea, idContacto,idComunidad.ToString());
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        
        private void toolStripMenuItemCopiarPortapapelesContacto_Click(object sender, EventArgs e)
        {
            String textSelect = dataGridViewContactos.SelectedRows[0].Cells[columnaContacto].Value.ToString();
            System.Windows.Forms.Clipboard.SetText(textSelect);
        }

        private void toolStripMenuItemEliminarContacto_Click(object sender, EventArgs e)
        {
            String idContacto = dataGridViewContactos.SelectedRows[0].Cells[0].Value.ToString();

            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este Contacto ?", "Borrar Contacto", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM exp_contactos WHERE IdDetEntTarea = " + idContacto;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarContactos();
            }
        }

        private void toolStripMenuItemCorreoResponsable_Click(object sender, EventArgs e)
        {
            String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
            
            String sqlSelect = "SELECT ctos_detemail.Email FROM(exp_gestiones INNER JOIN ctos_urendes ON exp_gestiones.IdUser = ctos_urendes.IdURD) INNER JOIN ctos_detemail ON ctos_urendes.identidad = ctos_detemail.IdEntidad WHERE(((exp_gestiones.IdGestión) = " + idGestion + "))";
            DataTable tablamail = Persistencia.SentenciasSQL.select(sqlSelect);
            if (tablamail.Rows.Count > 0)
            {
                String mail = tablamail.Rows[0][0].ToString();
                System.Diagnostics.Process.Start("thunderbird", "-compose \"to=\"" + mail + ",subject=\"" + generaAsunto() + "\",body= Este expediente requiere de su atención.");
            }
            else
            {
                MessageBox.Show("El responsable seleccionado no tiene correo asociado.");
            }
        }

        private void toolStripMenuItemCorreoSeguir_Click(object sender, EventArgs e)
        {
            if (dataGridViewGestiones.SelectedRows[0].Cells[10].Value.ToString() != "")
            {
                if (dataGridViewGestiones.SelectedRows[0].Cells[11].Value.ToString() != "T")
                {
                    String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();

                    String sqlSelect = "SELECT ctos_detemail.Email FROM exp_gestiones INNER JOIN ctos_detemail ON exp_gestiones.IdEntidad = ctos_detemail.IdEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((exp_gestiones.IdGestión) = " + idGestion + "))";
                    DataTable tablamail = Persistencia.SentenciasSQL.select(sqlSelect);
                    if (tablamail.Rows.Count > 0)
                    {
                        String mail = tablamail.Rows[0][0].ToString();
                        System.Diagnostics.Process.Start("thunderbird", "-compose \"to=\"" + mail + ",subject=\"" + generaAsunto() + "\"");
                    }

                    else
                    {
                        MessageBox.Show("La entidad seleccionada no tiene correo asociado.");
                    }
                }
                else
                {
                    String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();

                    String sqlSelect = "SELECT exp_contactos.Correo FROM exp_contactos INNER JOIN exp_gestiones ON exp_contactos.IdDetEntTarea = exp_gestiones.IdEntidad WHERE(((exp_gestiones.IdGestión) = " + idGestion + "))";
                    DataTable tablamail = Persistencia.SentenciasSQL.select(sqlSelect);
                    if (tablamail.Rows.Count > 0)
                    {
                        String mail = tablamail.Rows[0][0].ToString();
                        System.Diagnostics.Process.Start("thunderbird", "-compose \"to=\"" + mail + ",subject=\"" + generaAsunto() + "\"");
                    }

                    else
                    {
                        MessageBox.Show("El contacto selecionado no tiene correo asociado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Asigne una persona a seguir para poder enviarle un correo");
            }
        }

        private String generaAsunto()
        {
            String asunto = "";
            if (idComunidad != 0)
            {
                String sqlSelect = "SELECT ctos_entidades.NombreCorto, com_comunidades.Referencia FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + idEntidad + "))";
                DataTable comunidad = Persistencia.SentenciasSQL.select(sqlSelect);
                
                asunto += comunidad.Rows[0][0].ToString();//Nombre corto
                asunto += "- (Ref." + comunidad.Rows[0][1].ToString(); //Referencia comunidad
                asunto += "-" + idTareaNuevo(idTarea); //IdTarea
                asunto += ") " + textBoxDescripcion.Text; //Descripción
            }
            else
            {
                String sqlSelect = "SELECT ctos_entidades.NombreCorto FROM ctos_entidades WHERE(((ctos_entidades.IDEntidad) = " + idEntidad + "))";
                DataTable comunidad = Persistencia.SentenciasSQL.select(sqlSelect);
                
                asunto += comunidad.Rows[0][0].ToString();//Nombre corto
                asunto += "- (Ref.0"; //Referencia
                asunto += "-" + idTareaNuevo(idTarea); //IdTarea
                asunto += ") " + textBoxDescripcion.Text; //Descripción

            }
            return asunto;
        }

        private void buttonCerrarGestion_Click(object sender, EventArgs e)
        {
            if (idTarea == null)
            {
                MessageBox.Show("Guarda la tarea primero");
            }
            else
            {
                addTarea();
                bloquearEdicion();
                if (form_anterior != null)
                {
                    form_anterior.CargarTareas();
                    form_anterior.aplicarFiltroTabla();
                    form_anterior.filtroNombre();
                }

                if (dataGridViewGestiones.SelectedCells.Count > 0)
                {
                    String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();

                    String sqlUpdate = "UPDATE exp_gestiones SET FFin = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                    cargarGestiones();
                }

                String sqlSelect = "SELECT exp_tareas.IdTarea FROM exp_gestiones INNER JOIN exp_tareas ON exp_gestiones.IdTarea = exp_tareas.IdTarea WHERE(((exp_gestiones.FFin)Is Null) AND((exp_tareas.IdTarea) = " + idTarea + "));";

                DataTable contador = Persistencia.SentenciasSQL.select(sqlSelect);
                if (contador.Rows.Count == 0)
                {
                    DialogResult resultado_message;
                    resultado_message = MessageBox.Show("¿Desea cerrar la tarea?", "Cerrar Tarea ", MessageBoxButtons.OKCancel);
                    if (resultado_message == System.Windows.Forms.DialogResult.OK)
                    {
                        String sqlUpdate = "UPDATE exp_tareas SET FFin = '" + DateTime.Now.ToString("yyyy-MM-dd") + "',Importante = 0 WHERE IdTarea = " + idTarea;
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                        cargarCabecera();
                        if (form_anterior != null)
                        {
                            form_anterior.CargarTareas();
                            form_anterior.aplicarFiltroTabla();
                            form_anterior.filtroNombre();
                        }
                    }
                }
            }
        }

        private void buttonEliminarTarea_Click(object sender, EventArgs e)
        {
            if (idTarea != null)
            {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar esta Tarea ?", "Borrar Tarea", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    String sqlBorrar = "DELETE FROM exp_tareas WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    if (form_anterior != null)
                    {
                        form_anterior.CargarTareas();
                        form_anterior.aplicarFiltroTabla();
                        form_anterior.filtroNombre();
                    }
                    this.Close();
                }
            }
        }

        private void toolStripMenuItemCorreoGrupo_Click(object sender, EventArgs e)
        {
            String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
            
            Tareas.FormCorreoGrupo nueva = new FormCorreoGrupo(idGestion,idEntidad,idTarea, textBoxDescripcion.Text,idComunidad.ToString());
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void comboBoxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedValue.ToString() == "2")
            {
                checkBoxImportante.Checked = true;
            }
        }

        public void tareaImportanteGestion()
        {
            cargarCabecera();
            if (form_anterior != null)
            {
                form_anterior.CargarTareas();
                form_anterior.aplicarFiltroTabla();
                form_anterior.filtroNombre();
            }
        }
        
        private void textBoxSiniestro_Leave(object sender, EventArgs e)
        {
            if (textBoxSiniestro.Text != "")
            {
                checkBoxSeguro.Checked = true;
            }
        }

        private String limpiaRuta (String r)
        {
            String ruta;
            if (r.Contains("#"))
            {
                ruta = r.Split('#', '#')[1];
                this.ruta = ruta;
                return ruta;
            }
            this.ruta = r;
            return r;
        }

        private void textBoxTareaNueva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                String idTarea = textBoxTareaNueva.Text.ToString();
                if (existeTarea(idTarea))
                {
                    if (idTarea.Contains("/"))
                    {
                        Tareas.FormVerTarea nueva;
                        if (form_anterior != null) nueva = new FormVerTarea(form_anterior, idTareaViejo(idTarea));
                        else nueva = new FormVerTarea(idTareaViejo(idTarea));
                        nueva.ControlBox = true;
                        //nueva.TopMost = true;
                        nueva.WindowState = FormWindowState.Normal;
                        nueva.StartPosition = FormStartPosition.CenterScreen;
                        nueva.Show();
                        this.Close();
                    }
                    else
                    {

                        Tareas.FormVerTarea nueva;
                        if (form_anterior != null) nueva = new FormVerTarea(form_anterior, idTarea);
                        else nueva = new FormVerTarea(idTarea);
                        nueva.ControlBox = true;
                        //nueva.TopMost = true;
                        nueva.WindowState = FormWindowState.Normal;
                        nueva.StartPosition = FormStartPosition.CenterScreen;
                        nueva.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("La tarea " + idTarea + " no existe!");
                }
            }
        }

        private Boolean existeTarea(String idTarea)
        {
            String sqlSelect = "SELECT exp_tareas.IdTarea FROM exp_tareas WHERE(((exp_tareas.IdTarea) = " + idTarea + ") OR (exp_tareas.IdTareaCorto) = '" + idTarea + "')";
            DataTable tarea = Persistencia.SentenciasSQL.select(sqlSelect);
            if (tarea.Rows.Count == 0)
                return false;
            return true;
        }

        private void toolStripMenuItemInfoEntidad_Click(object sender, EventArgs e)
        {
            if (dataGridViewGestiones.SelectedRows[0].Cells[10].Value.ToString() != "")
            {
                if (dataGridViewGestiones.SelectedRows[0].Cells[11].Value.ToString() == "T")
                {
                    String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();

                    String sqlSelect = "SELECT exp_contactos.IdDetEntTarea FROM exp_contactos INNER JOIN exp_gestiones ON exp_contactos.IdDetEntTarea = exp_gestiones.IdEntidad WHERE(((exp_gestiones.IdGestión) = " + idGestion + "))";

                    String idContacto = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();

                    Tareas.FormInsertarContacto nueva = new Tareas.FormInsertarContacto(this, idTarea, idContacto, idComunidad.ToString(), false);
                    nueva.ControlBox = true;
                    nueva.TopMost = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    nueva.Show();
                }
                else
                {
                    String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();

                    String sqlSelect = "SELECT exp_gestiones.IdEntidad FROM exp_gestiones WHERE(((exp_gestiones.IdGestión) = " + idGestion + "))";

                    String idEntidad = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();

                    EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad(Int32.Parse(idEntidad));
                    nueva.ControlBox = true;
                    nueva.TopMost = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    nueva.Show();
                }
            }
            else
            {
                MessageBox.Show("Asigne una persona a seguir para poder ver la información");
            }
        }

        private void toolStripMenuItemAddSeguimiento_Click(object sender, EventArgs e)
        {
            String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
            Tareas.FormInsertarSeguimiento nueva = new FormInsertarSeguimiento(this, idGestion);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        

        private void comboBoxEstadoGestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGestiones();
        }

        private void buttonTodosSeguimientos_Click(object sender, EventArgs e)
        {
            if (idTarea != null) cargarTodosSeguimientos();
        }

        public void cargarExpedientes()
        {
            dataGridViewExpedientes.DataSource = null;
        
            String sqlExpedientes1 = "SELECT exp_tareaRel.IdTareaRel, exp_tareas.IdTarea, exp_tareas.Descripción, If(exp_tareas.FFin is not null, 'Cerrada', 'Abierta') AS Estado FROM exp_tareas INNER JOIN exp_tareaRel ON exp_tareas.IdTarea = exp_tareaRel.IdTarea_2 WHERE(((exp_tareaRel.IdTarea_1) = " + idTarea + "))";

            String sqlExpedientes2 = "SELECT exp_tareaRel.IdTareaRel, exp_tareas.IdTarea, exp_tareas.Descripción, If(exp_tareas.FFin is not null, 'Cerrada', 'Abierta') AS Estado FROM exp_tareas INNER JOIN exp_tareaRel ON exp_tareas.IdTarea = exp_tareaRel.IdTarea_1 WHERE(((exp_tareaRel.IdTarea_2) = " + idTarea + "))";

            DataTable expedientes1 = Persistencia.SentenciasSQL.select(sqlExpedientes1);
            DataTable expedientes2 = Persistencia.SentenciasSQL.select(sqlExpedientes2);
            DataTable expedientes = expedientes1;
            expedientes.Merge(expedientes2);

            if (expedientes.Rows.Count > 0)
            {
                dataGridViewExpedientes.DataSource = expedientes;
                dataGridViewExpedientes.Columns["IdTareaRel"].Visible = false;
                dataGridViewExpedientes.Columns["IdTarea"].Width = 60;
                dataGridViewExpedientes.Columns["Descripción"].Width = 520;
                dataGridViewExpedientes.Columns["Estado"].Width = 60;
            }
            if (expedientes.Rows.Count != 0) tabPageExpedientes.Text = "Expedientes (" + expedientes.Rows.Count + ")";
            else tabPageExpedientes.Text = "Expedientes";

        }
        private void buttonAddExpediente_Click(object sender, EventArgs e)
        {
            
            Tareas.FormTareasPrincipal nueva = new Tareas.FormTareasPrincipal(this, this.Name , idComunidad.ToString());
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        
        public void recibirTarea(String idTareaRecibido)
        {
            String sqlInsert = "INSERT INTO exp_tareaRel (IdTarea_1, IdTarea_2) VALUES (" + idTarea + "," + idTareaRecibido + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            cargarExpedientes();
        }

        private void dataGridViewExpedientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String idTarea = dataGridViewExpedientes.SelectedRows[0].Cells["IdTarea"].Value.ToString();
            FormVerTarea nueva = new FormVerTarea(idTarea);
            nueva.ControlBox = true;
            //nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void borrarExpedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String idTareaRel = dataGridViewExpedientes.SelectedRows[0].Cells["IdTareaRel"].Value.ToString();

            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este Expediente ?", "Borrar Expediente", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM exp_tareaRel WHERE IdTareaRel = " + idTareaRel;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);

                cargarExpedientes();
            }
        }

        private void dataGridViewExpedientes_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewExpedientes.HitTest(e.X, e.Y);
                //EVITAR QUE COJA LA CABECERA
                if (hti.RowIndex > -1)
                {
                    dataGridViewExpedientes.ClearSelection();
                    dataGridViewExpedientes.Rows[hti.RowIndex].Selected = true;
                    dataGridViewExpedientes.Columns[hti.ColumnIndex].Selected = true;
                    dataGridViewExpedientes.CurrentCell = this.dataGridViewExpedientes[hti.ColumnIndex, hti.RowIndex];
                    contextMenuStrip5.Show(Cursor.Position);
                }
            }
        }

        private void labelRutaLink_DoubleClick(object sender, EventArgs e)
        {

            if (idEntidad == null)
            {
                MessageBox.Show("Selecciona una entidad primero!");
            }
            else
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                ListBox listBox1 = new ListBox();

                String rutaCheck = rutaEntidad().Trim('#');
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.SelectedPath = rutaCheck;
                SendKeys.Send("{TAB}{TAB}{RIGHT}{RIGHT}{RIGHT}{RIGHT}");
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string foldername = folderBrowserDialog.SelectedPath;
                    textBoxRuta.Text = foldername;
                    textBoxRuta.Cursor = Cursors.Hand;
                }
            }
        }
        
        private void buttonBloque_Click(object sender, EventArgs e)
        {
            if (idComunidad != 0)
            {
                if (idTarea != null)
                {
                    comboBoxTipo.Focus();
                    FormSeleccionarBloque nueva = new FormSeleccionarBloque(this, idComunidad.ToString(), idTarea);
                    nueva.ControlBox = true;
                    nueva.TopMost = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    nueva.Show();
                }
                else
                {
                    comboBoxTipo.SelectedIndex = 2;
                    checkBoxImportante.Checked = true;
                    maskedTextBoxFIni.Text = DateTime.Now.ToShortDateString();
                    addTarea();
                    textBoxIdTarea.Text = idTarea;
                    textBoxIdTareaNuevo.Text = idTareaNuevo(idTarea);
                    comboBoxTipo.Focus();
                    FormSeleccionarBloque nueva = new FormSeleccionarBloque(this, idComunidad.ToString(), idTarea);
                    nueva.ControlBox = true;
                    nueva.TopMost = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    nueva.Show();
                }
            }
            else
            {
                MessageBox.Show("Selecciona una comunidad para elegir su bloque");
            }
        }

        private void buttonDuplicarTarea_Click(object sender, EventArgs e)
        {
            String idTipoTarea = comboBoxTipo.SelectedValue.ToString();
            String fIni = DateTime.Now.ToShortDateString();
            String descripcion = "";
            if (textBoxDescripcion.Text != "") descripcion = textBoxDescripcion.Text;
            String coste = "";
            if (textBoxCoste.Text != "") coste = textBoxCoste.Text;
            String seguro = "0";
            if (checkBoxSeguro.Checked) seguro = "-1";
            String acuerdoJunta = "0";
            if (checkBoxAcuerdoJunta.Checked) acuerdoJunta = "-1";
            String fechaActaAcordado = null;
            if (maskedTextBoxFechaActa.Text != "  /  /" && maskedTextBoxFechaActa.Text != "") fechaActaAcordado = Convert.ToDateTime(maskedTextBoxFechaActa.Text).ToString();
            String proximaJunta = "0";
            if (checkBoxProxJunta.Checked) proximaJunta = "-1";
            String refSiniestro = textBoxSiniestro.Text;
            String fFin = null;
            if (maskedTextBoxFFin.Text != "  /  /" && maskedTextBoxFFin.Text != "") fFin = Convert.ToDateTime(maskedTextBoxFFin.Text).ToString();
            String notas = textBoxNotas.Text;
            String importante = "0";
            if (checkBoxImportante.Checked) importante = "-1";
            //String nombreElemento = textBoxBloque.Text;
            //String idElemento = this.idElemento;
            int idComunidad = this.idComunidad;
            String idEntidad = this.idEntidad;
            String nombreComunidad = textBoxEntidad.Text;
            String referencia = maskedTextBoxReferencia.Text;

            FormDuplicarTarea nueva = new FormDuplicarTarea(form_anterior, idTipoTarea, fIni, descripcion, coste, seguro, acuerdoJunta, fechaActaAcordado, proximaJunta, refSiniestro, fFin, notas, importante, idEntidad, nombreComunidad, idComunidad, referencia, idTarea);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        
        private void duplicarTarea()
        {
            if (contactosDupli)
            {
                copiarContactos();
            }
            if (expedientesDupli)
            {
                copiarExpedientes();
            }
        }
        private void copiarContactos()
        {
            String sqlSelect = "SELECT exp_contactos.Nombre, exp_contactos.Tel AS Teléfono, exp_contactos.Correo, exp_contactos.Notas, exp_contactos.Proveedor as P, exp_contactos.Comunero as C,exp_contactos.Entidad as E  FROM exp_contactos WHERE(((exp_contactos.IdTarea) = " + idTareaDupli + "))";

            DataTable contactos = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach (DataRow row in contactos.Rows)
            {
                String sqlInsert = "INSERT INTO exp_contactos (Nombre,Tel,Correo,Notas,Proveedor,Comunero,Entidad,IdTarea) VALUES ('" + row["Nombre"] + "'," + row["Teléfono"] + ", '" + row["Correo"] + "','" + row["Notas"] + "','" + row["P"] + "','" + row["C"] + "','" + row["E"] + "'," + idTarea + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
        }

        private void copiarExpedientes()
        {
            String sqlExpedientes1 = "SELECT exp_tareaRel.IdTarea_1 FROM exp_tareaRel WHERE(((exp_tareaRel.IdTarea_2) = " + idTareaDupli + "))";
            DataTable expedientes1 = Persistencia.SentenciasSQL.select(sqlExpedientes1);

            foreach (DataRow row in expedientes1.Rows)
            {
                String sqlInsert = "INSERT INTO exp_tareaRel (IdTarea_1,IdTarea_2) VALUES (" + row["IdTarea_1"] + "," + idTarea + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }

            String sqlExpedientes2 = "SELECT exp_tareaRel.IdTarea_2 FROM exp_tareaRel WHERE(((exp_tareaRel.IdTarea_1) = " + idTareaDupli + "))";
            DataTable expedientes2 = Persistencia.SentenciasSQL.select(sqlExpedientes2);

            foreach (DataRow row in expedientes2.Rows)
            {
                String sqlInsert = "INSERT INTO exp_tareaRel (IdTarea_2,IdTarea_1) VALUES (" + row["IdTarea_2"] + "," + idTarea + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
            
        }

        private String idTareaViejo(String idTareaNuevo)
        {
            String sqlSelect = "SELECT exp_tareas.IdTarea FROM exp_tareas WHERE exp_tareas.IdTareaCorto = '" + idTareaNuevo + "'";
            return Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString(); ;
        }

        private String idTareaNuevo(String idTareaViejo)
        {
            String sqlSelect = "SELECT exp_tareas.IdTareaCorto FROM exp_tareas WHERE exp_tareas.IdTarea = '" + idTareaViejo + "'";
            return Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString(); ;
        }
        
        public void cargarBloque()
        {
            String sqlSelect = "SELECT exp_area.IdArea, exp_area.IdAreaPrevio, exp_area.Nombre, exp_area.Descripcion FROM exp_area INNER JOIN exp_areaTarea ON exp_area.IdArea = exp_areaTarea.IdArea WHERE(((exp_areaTarea.IdTarea) = " + idTarea + ") AND((exp_area.IdAreaPrevio) = 0))";
            tablaBloque = Persistencia.SentenciasSQL.select(sqlSelect);
            if (tablaBloque.Rows.Count > 0) conBloque = true;
            String bloques = "";
            foreach( DataRow row in tablaBloque.Rows)
            {
                    if (bloques.Length > 0) bloques += " ; " + row[2];
                    else bloques = row[2].ToString();
            }
            textBoxBloque.Text = bloques;
            cargarServicios();
        }

        private void textBoxBloque_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSeleccionarBloque nueva = new FormSeleccionarBloque(this, idTarea);
            nueva.Show();
        }
        
        public void cargarServicios()
        {
            DataTable tablaServicios = null;
            tablaFinalServicios = null;
            foreach (DataRow row in tablaBloque.Rows)
            {

                String idAreaBloque = row[0].ToString();
                String nombreBloque = row[2].ToString();


                String sqlSelect = "SELECT exp_area.IdArea,'" + nombreBloque + "' AS Bloque, exp_area.Nombre AS Categoría,exp_area.Nombre AS Nombre , '' AS Previo FROM (exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea) INNER JOIN exp_area AS exp_area_1 ON exp_area.IdAreaPrevio = exp_area_1.IdArea WHERE(((exp_areaTarea.IdTarea) = " + idTarea + ") AND((exp_area.IdAreaPrevio) = " + idAreaBloque + "))";
                
                tablaServicios = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tablaFinalServicios == null) tablaFinalServicios = tablaServicios.Copy();
                else tablaFinalServicios.Merge(tablaServicios);

                String sqlSelectTodas = "SELECT exp_area.IdArea,'" + nombreBloque + "' AS Bloque, exp_area.Nombre AS Categoría,exp_area.Nombre AS Nombre , '' AS Previo FROM (exp_areaTarea RIGHT JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea) INNER JOIN exp_area AS exp_area_1 ON exp_area.IdAreaPrevio = exp_area_1.IdArea WHERE(((exp_area.IdAreaPrevio) = " + idAreaBloque + "))";

                tablaServicios = Persistencia.SentenciasSQL.select(sqlSelectTodas);

                foreach (DataRow rowSub in tablaServicios.Rows)
                {
                    DataTable subServicios = null;
                    String sqlSelectSub = "SELECT exp_area.IdArea,'" + nombreBloque + "' AS Bloque,'" + rowSub[2] + "' AS Categoría,exp_area.Nombre AS Nombre , exp_area_1.Nombre AS Previo FROM (exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea) INNER JOIN exp_area AS exp_area_1 ON exp_area.IdAreaPrevio = exp_area_1.IdArea WHERE(((exp_areaTarea.IdTarea) = " + idTarea + ") AND((exp_area.IdAreaPrevio) = " + rowSub[0] + "))";

                    subServicios = Persistencia.SentenciasSQL.select(sqlSelectSub);
                    if (subServicios.Rows.Count > 0) tablaFinalServicios.Merge(subServicios);

                    subServicios = null;
                    String sqlSelectSubTodas = "SELECT exp_area.IdArea,'" + nombreBloque + "' AS Bloque,'" + rowSub[2] + "' AS Categoría,exp_area.Nombre AS Nombre , exp_area_1.Nombre AS Previo FROM (exp_areaTarea RIGHT JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea) INNER JOIN exp_area AS exp_area_1 ON exp_area.IdAreaPrevio = exp_area_1.IdArea WHERE(((exp_area.IdAreaPrevio) = " + rowSub[0] + "))";
                    subServicios = Persistencia.SentenciasSQL.select(sqlSelectSubTodas);


                    foreach (DataRow rowSub2 in subServicios.Rows)
                    {
                        DataTable subServicios2 = null;

                        String sqlSelectSub2 = "SELECT exp_area.IdArea,'" + nombreBloque + "' AS Bloque,'" + rowSub[2] + "' AS Categoría,exp_area.Nombre AS Nombre , exp_area_1.Nombre AS Previo FROM (exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea) INNER JOIN exp_area AS exp_area_1 ON exp_area.IdAreaPrevio = exp_area_1.IdArea WHERE(((exp_areaTarea.IdTarea) = " + idTarea + ") AND((exp_area.IdAreaPrevio) = " + rowSub2[0] + "))";
                        
                        subServicios2 = Persistencia.SentenciasSQL.select(sqlSelectSub2);
                        if (subServicios2.Rows.Count > 0) tablaFinalServicios.Merge(subServicios2);
                    }
                }
            }
            dataGridViewServicios.DataSource = tablaFinalServicios;

            if (dataGridViewServicios.Rows.Count > 0)
            {
                dataGridViewServicios.Columns["IdArea"].Visible = false;
                dataGridViewServicios.Columns["Nombre"].Width = 180;
                dataGridViewServicios.Columns["Previo"].Width = 150;
                dataGridViewServicios.Columns["Bloque"].Width = 150;
                dataGridViewServicios.Columns["Categoría"].Width = 150;
            }
        }

        private void buttonAddServicio_Click(object sender, EventArgs e)
        {
            FormInsertarServicioTarea nueva = new FormInsertarServicioTarea(this, idTarea);
            nueva.Show();
        }
        
        private void FormVerTarea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (edicion)
            {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea Guardar los cambios en esta Tarea ?", "Guardar Tarea", MessageBoxButtons.YesNoCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.Yes)
                {
                    addTarea();
                    form_anterior.CargarTareas();
                    form_anterior.aplicarFiltroTabla();
                    form_anterior.filtroNombre();
                }
                else if (resultado_message == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
