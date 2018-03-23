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

namespace UrdsAppGestión.Presentacion.Tareas
{
    public partial class FormVerTarea : Form
    {
        String idTarea;
        String ruta;
        String idEntidad;
        String idGestion;
        String fInicio;
        DataTable tarea;
        DataTable gestion;
        DataTable seguimiento;
        DataTable contactos;
        FormTareasPrincipal form_anterior;

        public FormVerTarea(FormTareasPrincipal form_anterior, String idTarea)
        {
            InitializeComponent();
            this.idTarea = idTarea;
            this.form_anterior = form_anterior;
        }

        public FormVerTarea(FormTareasPrincipal form_anterior)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
        }

        private void FormVerTarea_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
            //VER TAREA
            if (idTarea != null)
            {
                cargarCabecera();
                cargarGestiones();
                cargarContactos();
                bloquearEdicion();
            }
            //NUEVA TAREA
            if (idTarea == null)
            {
                habilitarEdicion();
            }
        }


        public void cargarCabecera()
        {

            String sqlSelect = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tareas.IdEntidad, exp_tareas.Notas, exp_tareas.Ruta, exp_tareas.IdTipoTarea, exp_tareas.FFin, exp_tareas.FIni, exp_tareas.Coste, exp_tareas.Presupuesto, exp_tareas.RefSiniestro, exp_tareas.Seguro, exp_tareas.AcuerdoJunta, exp_tareas.FechaActaAcordado, exp_tareas.ProximaJunta , com_comunidades.Referencia , ctos_entidades.Entidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((exp_tareas.IdTarea) = " + idTarea + "))";

            tarea = Persistencia.SentenciasSQL.select(sqlSelect);
            
            textBoxIdTarea.Text = tarea.Rows[0][0].ToString();
            textBoxDescripcion.Text = tarea.Rows[0][1].ToString();
            idEntidad = tarea.Rows[0][2].ToString();
            textBoxNotas.Text = tarea.Rows[0][3].ToString();
            ruta = tarea.Rows[0][4].ToString().Trim('#');
            textBoxRuta.Text = ruta;
            comboBoxTipo.SelectedValue = tarea.Rows[0][5].ToString();
            maskedTextBoxFFin.Text = tarea.Rows[0][6].ToString();
            maskedTextBoxFIni.Text = tarea.Rows[0][7].ToString();
            fInicio = tarea.Rows[0][7].ToString();
            textBoxCoste.Text = tarea.Rows[0][8].ToString();
            textBoxPtto.Text = tarea.Rows[0][9].ToString();
            textBoxSiniestro.Text = tarea.Rows[0][10].ToString();
            checkBoxSeguro.Checked = bool.Parse(tarea.Rows[0][11].ToString());
            checkBoxAcuerdoJunta.Checked = bool.Parse(tarea.Rows[0][12].ToString());
            if (tarea.Rows[0][13].ToString() != "00/00/0000") maskedTextBoxFechaActa.Text = tarea.Rows[0][13].ToString();
            checkBoxProxJunta.Checked = bool.Parse(tarea.Rows[0][14].ToString());
            maskedTextBoxReferencia.Text = tarea.Rows[0][15].ToString();
            textBoxEntidad.Text = tarea.Rows[0][16].ToString();
            
            
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
            textBoxPtto.ReadOnly = true;
            textBoxSiniestro.ReadOnly = true;
            checkBoxSeguro.AutoCheck = false;
            checkBoxAcuerdoJunta.AutoCheck = false;
            maskedTextBoxFechaActa.ReadOnly = true;
            if (maskedTextBoxFechaActa.Text == "  /  /") maskedTextBoxFechaActa.Mask = "";
            checkBoxProxJunta.AutoCheck = false;
            buttonEditar.Enabled = true;
            buttonGuardar.Enabled = false;
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
            textBoxPtto.ReadOnly = false;
            textBoxSiniestro.ReadOnly = false;
            checkBoxSeguro.AutoCheck = true;
            checkBoxAcuerdoJunta.AutoCheck = true;
            maskedTextBoxFechaActa.ReadOnly = false;
            maskedTextBoxFechaActa.Mask = "00/00/0000";
            checkBoxProxJunta.AutoCheck = true;
            buttonEditar.Enabled = false;
            buttonGuardar.Enabled = true;
            if (textBoxEntidad.Text == "")
            {
                textBoxEntidad.Text = "Pulsa espacio para Seleccionar Entidad";
                textBoxEntidad.ForeColor = Color.Gray;
            }
        }

        public void rellenarComboBox()
        {
            String sqlComboTipo = "SELECT exp_tipostareas.IdTipoTarea, exp_tipostareas.TipoTarea FROM exp_tipostareas";
            comboBoxTipo.DataSource = Persistencia.SentenciasSQL.select(sqlComboTipo);
            comboBoxTipo.DisplayMember = "TipoTarea";
            comboBoxTipo.ValueMember = "IdTipoTarea";

            
        }
        
        public void cargarGestiones()
        {
            //String sqlSelect = "SELECT exp_gestiones.IdGestión as Id, exp_gestiones.Orden as Ord, ctos_urendes.Usuario, exp_gestiones.Descripción, exp_gestiones.Importante, exp_gestiones.FIni, exp_gestiones.FMax, exp_gestiones.FSeguir, exp_gestiones.FFin, exp_niveles.Nivel, exp_gestiones.Predecesoras FROM(exp_gestiones INNER JOIN ctos_urendes ON exp_gestiones.IdUser = ctos_urendes.IdURD) INNER JOIN exp_niveles ON exp_gestiones.IdNivel = exp_niveles.IdNivel WHERE(((exp_gestiones.IdTarea) = " + idTarea  + "))";

            String sqlSelect = "SELECT exp_gestiones.IdGestión AS Id, exp_gestiones.Orden AS Ord, ctos_urendes.Usuario, exp_gestiones.Descripción, exp_gestiones.Importante, exp_gestiones.FIni, exp_gestiones.FMax, exp_gestiones.FSeguir, exp_gestiones.FFin, exp_niveles.Nivel, ctos_entidades.Entidad AS `Espera de` FROM((exp_gestiones INNER JOIN ctos_urendes ON exp_gestiones.IdUser = ctos_urendes.IdURD) INNER JOIN exp_niveles ON exp_gestiones.IdNivel = exp_niveles.IdNivel) LEFT JOIN ctos_entidades ON exp_gestiones.IdEntidad = ctos_entidades.IDEntidad WHERE(((exp_gestiones.IdTarea) = " + idTarea + "))";


            gestion = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewGestiones.DataSource = gestion;
            ajustarDatagridGestiones();
        }

        public void cargarSeguimientos()
        {
            String sqlSelect = "SELECT exp_notas.IdNota, exp_notas.IdGestión, exp_tiposeguimiento.`Tipo Seguimiento`, exp_notas.Fecha, ctos_urendes.Usuario, exp_notas.Notas FROM(exp_tiposeguimiento INNER JOIN exp_notas ON exp_tiposeguimiento.IdTipoSeg = exp_notas.IdTipoSeg) INNER JOIN ctos_urendes ON exp_notas.IdURD = ctos_urendes.IdURD WHERE(((exp_notas.IdGestión) = " + idGestion + ")) ORDER BY exp_notas.Fecha DESC";

            seguimiento = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewSeguimientos.DataSource = seguimiento;
        }

        private void dataGridViewGestiones_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridViewGestiones.SelectedCells.Count > 0)
            {
                idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
                    
                cargarSeguimientos();
            }
                
        }

        private void textBoxRuta_Click(object sender, EventArgs e)
        {
            if (ruta != null)
            {
                System.Diagnostics.Process.Start(@ruta);
            }
        }

        public void ajustarDatagridGestiones()
        {
            if (dataGridViewGestiones.Rows.Count > 0)
            {
                dataGridViewGestiones.Columns["Id"].Width = 40;
                dataGridViewGestiones.Columns["Ord"].Width = 25;
                dataGridViewGestiones.Columns["Usuario"].Width = 45;
                dataGridViewGestiones.Columns["Descripción"].Width = 90;
                dataGridViewGestiones.Columns["Importante"].Width = 40;
                dataGridViewGestiones.Columns["FIni"].Width = 60;
                dataGridViewGestiones.Columns["FMax"].Width = 60;
                dataGridViewGestiones.Columns["FSeguir"].Width = 60;
                dataGridViewGestiones.Columns["FFin"].Width = 60;
                dataGridViewGestiones.Columns["Nivel"].Width = 40;
                dataGridViewGestiones.Columns["Espera de"].Width = 60; 
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxReferencia.Text != "")idEntidad = entidadReferencia();
            addTarea();
            textBoxIdTarea.Text = idTarea;
            bloquearEdicion();
            form_anterior.CargarTareas();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            habilitarEdicion();
        }

        private void buttonAddGestion_Click(object sender, EventArgs e)
        {
            if (idTarea == null)
            {
                MessageBox.Show("Guarda la tarea para poder añadir una Gestión");
            }
            else
            {
                Tareas.FormInsertarGestion nueva = new FormInsertarGestion(this, idTarea, fInicio);
                nueva.Show();
            }
        }

        private void buttonAddSeguimiento_Click(object sender, EventArgs e)
        {
            try
            {
                String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
                Tareas.FormInsertarSeguimiento nueva = new FormInsertarSeguimiento(this, idGestion);
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
            }
        }

        private void dataGridViewGestiones_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewGestiones.HitTest(e.X, e.Y);
                dataGridViewGestiones.ClearSelection();
                dataGridViewGestiones.Rows[hti.RowIndex].Selected = true;
                dataGridViewGestiones.Columns[hti.ColumnIndex].Selected = true;
                dataGridViewGestiones.CurrentCell = this.dataGridViewGestiones[hti.ColumnIndex, hti.RowIndex];
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void dataGridViewSeguimientos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewSeguimientos.HitTest(e.X, e.Y);
                dataGridViewSeguimientos.ClearSelection();
                dataGridViewSeguimientos.Rows[hti.RowIndex].Selected = true;
                dataGridViewSeguimientos.Columns[hti.ColumnIndex].Selected = true;
                dataGridViewSeguimientos.CurrentCell = this.dataGridViewSeguimientos[hti.ColumnIndex, hti.RowIndex];
                contextMenuStrip2.Show(Cursor.Position);
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
            Tareas.FormInsertarGestion nueva = new FormInsertarGestion(this, idTarea,idGestion,fInicio);
            nueva.Show();
        }

        private void toolStripMenuItemEditarSeguimiento_Click(object sender, EventArgs e)
        {
            String idSeguimiento = dataGridViewSeguimientos.SelectedRows[0].Cells[0].Value.ToString();
            Tareas.FormInsertarSeguimiento nueva = new FormInsertarSeguimiento(this, idGestion, idSeguimiento);
            nueva.Show();
        }

        private void dataGridViewGestiones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Tareas.FormInsertarGestion nueva = new FormInsertarGestion(this,idGestion);
            nueva.Show();
        }

        private void dataGridViewSeguimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String idSeguimiento = dataGridViewSeguimientos.SelectedRows[0].Cells[0].Value.ToString();

            Tareas.FormInsertarSeguimiento nueva = new FormInsertarSeguimiento(this,idGestion,idSeguimiento,false);
            nueva.Show();
        }

        private void buttonRuta_Click(object sender, EventArgs e)
        {
            if (ruta == null)
            {
                if (maskedTextBoxReferencia.Text != "") idEntidad = entidadReferencia();
                addTarea();
                textBoxIdTarea.Text = idTarea;
                form_anterior.CargarTareas();

                String tarea = idTarea + " " + textBoxDescripcion.Text;
                String rutaCheck = rutaEntidad().Trim('#');
                ruta = @rutaCheck + @"\EXPEDIENTES\" + tarea;
                

                
                //LA CARPETA DE LA RUTA YA ESTÁ CREADA
                if (System.IO.Directory.Exists(ruta))
                {
                    MessageBox.Show("La Carpeta de la tarea ya existe!");
                    textBoxRuta.Text = ruta;
                }
                //LA CARPETA DE LA COMUNIDAD EXISTE
                else if (System.IO.Directory.Exists(rutaCheck))
                {
                    System.IO.Directory.CreateDirectory(ruta);
                    textBoxRuta.Text = ruta;
                    addTarea();
                }
                //LA CARPETA DE LA COMUNIDAD NO EXISTE
                else
                {
                    MessageBox.Show("No se encuentra la carpeta de la comunidad, contacte con el administrador");
                    ruta = "";
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
                    textBoxPtto.SelectAll();
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
                    textBoxPtto.SelectAll();
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
            String idTipoTarea = comboBoxTipo.SelectedValue.ToString();
            String fIni = null;
            fInicio = maskedTextBoxFIni.Text;
            if (maskedTextBoxFIni.Text != "  /  /" && maskedTextBoxFIni.Text != "") fIni = Convert.ToDateTime(maskedTextBoxFIni.Text).ToString("yyyy-MM-dd");
            String descripcion = "";
            if (textBoxDescripcion.Text != "") descripcion = textBoxDescripcion.Text;
            String presupuesto = DBNull.Value.ToString();
            if (textBoxPtto.Text != "") presupuesto = textBoxPtto.Text;
            String coste = "";
            if (textBoxCoste.Text != "") coste = textBoxCoste.Text;
            String seguro = "0";
            if (checkBoxSeguro.Checked) seguro = "1";
            String acuerdoJunta = "0";
            if (checkBoxAcuerdoJunta.Checked) acuerdoJunta = "1";
            String fechaActaAcordado = null;
            if (maskedTextBoxFechaActa.Text != "  /  /" && maskedTextBoxFechaActa.Text != "") fechaActaAcordado = Convert.ToDateTime(maskedTextBoxFechaActa.Text).ToString("yyyy-MM-dd");
            String proximaJunta = "0";
            if (checkBoxProxJunta.Checked) proximaJunta = "1";
            String refSiniestro = textBoxSiniestro.Text;
            String fFin = null;
            if (maskedTextBoxFFin.Text != "  /  /" && maskedTextBoxFFin.Text != "") fFin = Convert.ToDateTime(maskedTextBoxFFin.Text).ToString("yyyy-MM-dd");
            String ruta = textBoxRuta.Text;
            String notas = textBoxNotas.Text;

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
                if (coste != "")
                {
                    sqlUpdate = "UPDATE exp_tareas SET Coste = " + coste + " WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (presupuesto != "")
                {
                    sqlUpdate = "UPDATE exp_tareas SET Presupuesto = " + presupuesto + " WHERE IdTarea = " + idTarea;
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

            }
            //AÑADIR NUEVA TAREA
            else
            {
                String sqlInsert = "INSERT INTO exp_tareas (IdEntidad,IdRbleTarea,IdTipoTarea,Descripción,Seguro,AcuerdoJunta,ProximaJunta,RefSiniestro,Notas) VALUES (" + idEntidad + "," + Login.getId() + "," + idTipoTarea + ",'" + descripcion + "'," + seguro + "," + acuerdoJunta + "," + proximaJunta + ",'" + refSiniestro + "','" + notas + "')";
                idTarea = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();

                if (fIni != null)
                {
                    sqlInsert = "UPDATE exp_tareas SET FIni = '" + fIni + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                if (fFin != null)
                {
                    sqlInsert = "UPDATE exp_tareas SET FFin = '" + fFin + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                if (coste != "")
                {
                    sqlInsert = "UPDATE exp_tareas SET Coste = " + coste + " WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                if (presupuesto != "")
                {
                    sqlInsert = "UPDATE exp_tareas SET Presupuesto = " + presupuesto + " WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                if (fechaActaAcordado != null)
                {
                    sqlInsert = "UPDATE exp_tareas SET FechaActaAcordado = '" + fechaActaAcordado + "' WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
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
            String sql = "SELECT ctos_entidades.Entidad FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.Referencia) = " + maskedTextBoxReferencia.Text + "))";
            DataTable entidad = Persistencia.SentenciasSQL.select(sql);
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
            String nombre = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IdEntidad = " + id_entidad)).Rows[0][0].ToString();
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
                    textBoxNotas.Focus();
                    textBoxNotas.SelectAll();
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
            if (maskedTextBoxFFin.Text != "  /  /" && maskedTextBoxFFin.Text != "")
            {
                string sPattern = "^\\d{2}/\\d{2}/$";
                string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

                if (Regex.IsMatch(maskedTextBoxFechaActa.Text, sPattern))
                {
                    maskedTextBoxFechaActa.Text = maskedTextBoxFechaActa.Text + DateTime.Now.Year;
                }
                else if (Regex.IsMatch(maskedTextBoxFechaActa.Text, sPattern1))
                {
                    checkBoxProxJunta.Focus();
                }
                else
                {
                    maskedTextBoxFechaActa.Focus();
                    maskedTextBoxFechaActa.SelectAll();
                }
            }
        }

        public void cargarContactos()
        {
            //String sqlSelect = "SELECT exp_contactos.IdDetEntTarea,If(exp_contactos.IdEntidad is Not Null,ctos_entidades.Entidad,exp_contactos.Nombre) AS Nombre , If (exp_contactos.IdEntidad is Not Null,ctos_dettelf.Telefono,exp_contactos.Tel) AS Teléfono, If (exp_contactos.IdEntidad is Not Null,ctos_detemail.Email,exp_contactos.Correo) AS Correo FROM((exp_contactos LEFT JOIN ctos_entidades ON exp_contactos.IdEntidad = ctos_entidades.IDEntidad)  LEFT JOIN ctos_detemail ON exp_contactos.IdMail = ctos_detemail.IdEmail) LEFT JOIN ctos_dettelf ON exp_contactos.IdTelf = ctos_dettelf.IdDetTelf WHERE(((exp_contactos.IdTarea) = " + idTarea + "))";
            String sqlSelect = "SELECT exp_contactos.IdDetEntTarea, exp_contactos.Nombre, exp_contactos.Tel AS Teléfono, exp_contactos.Correo FROM exp_contactos WHERE(((exp_contactos.IdTarea) = " + idTarea + "))";

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
                dataGridViewContactos.Columns["Nombre"].Width = 255;
                dataGridViewContactos.Columns["Teléfono"].Width = 75;
                dataGridViewContactos.Columns["Correo"].Width = 180;
            }
        }

        private void buttonEnviarMail_Click(object sender, EventArgs e)
        {
            try //(dataGridViewContactos.SelectedRows[0].Cells[3] != null)
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
                Tareas.FormInsertarContacto nueva = new FormInsertarContacto(this, idTarea);
                nueva.Show();
            }
        }

        private void dataGridViewContactos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String idContacto = dataGridViewContactos.SelectedRows[0].Cells[0].Value.ToString();
            Tareas.FormInsertarContacto nueva = new FormInsertarContacto(this, idTarea, idContacto,false);
            nueva.Show();
        }

        private void dataGridViewContactos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewContactos.HitTest(e.X, e.Y);
                dataGridViewContactos.ClearSelection();
                dataGridViewContactos.Rows[hti.RowIndex].Selected = true;
                dataGridViewContactos.Columns[hti.ColumnIndex].Selected = true;
                dataGridViewContactos.CurrentCell = this.dataGridViewContactos[hti.ColumnIndex, hti.RowIndex];
                contextMenuStrip3.Show(Cursor.Position);
            }
        }

        private void toolStripMenuItemEditarContacto_Click(object sender, EventArgs e)
        {
            String idContacto = dataGridViewContactos.SelectedRows[0].Cells[0].Value.ToString();
            Tareas.FormInsertarContacto nueva = new FormInsertarContacto(this, idTarea, idContacto);
            nueva.Show();
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
            String mail = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            System.Diagnostics.Process.Start("thunderbird", "-compose \"to=\"" + mail + ",subject=\"" + generaAsunto() + "\"");
        }

        private void toolStripMenuItemCorreoSeguir_Click(object sender, EventArgs e)
        {
            String idGestion = dataGridViewGestiones.SelectedRows[0].Cells[0].Value.ToString();
            
            String sqlSelect = "SELECT ctos_detemail.Email FROM exp_gestiones INNER JOIN ctos_detemail ON exp_gestiones.IdEntidad = ctos_detemail.IdEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((exp_gestiones.IdGestión) = " + idGestion + "))";
            String mail = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            System.Diagnostics.Process.Start("thunderbird", "-compose \"to=\"" + mail + ",subject=\"" + generaAsunto() + "\"" );
        }

        private String generaAsunto()
        {
            String sqlSelect = "SELECT ctos_entidades.NombreCorto, com_comunidades.Referencia FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + idEntidad + "))";
            DataTable comunidad = Persistencia.SentenciasSQL.select(sqlSelect);

            String asunto = "";
            asunto += comunidad.Rows[0][0].ToString();//Nombre corto
            asunto += " - ( Ref. " + comunidad.Rows[0][1].ToString(); //Referencia comunidad
            asunto += " / " + idTarea; //IdTarea
            asunto += ") " + textBoxDescripcion.Text; //Descripción

            return asunto;
        }
    }
}
