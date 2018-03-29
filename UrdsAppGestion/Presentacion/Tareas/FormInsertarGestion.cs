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
    public partial class FormInsertarGestion : Form
    {
        String idTarea;
        String idGestion;
        String fInicio;
        String idEntidad;
        DataTable infoGestion;
        FormVerTarea form_anterior;

        public FormInsertarGestion(FormVerTarea form_anterior,String idTarea,String fInicio)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idTarea = idTarea;
            this.fInicio = fInicio;
        }

        public FormInsertarGestion(FormVerTarea form_anterior, String idTarea, String idGestion, String fInicio)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idTarea = idTarea;
            this.idGestion = idGestion;
            this.fInicio = fInicio;
        }

        public FormInsertarGestion(FormVerTarea form_anterior, String idGestion)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idGestion = idGestion;
        }


        private void FormInsertarGestion_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
            maskedTextBoxFInicio.Text = fInicio;
            //NUEVA GESTIÓN
            if (idGestion == null)
            {
                habilitarEdicion();
                comboBoxUsuario.SelectedValue = Login.getId();
            }
            //VER GESTIÓN
            else if (idTarea == null)
            {
                cargarGestion();
                bloquearEdicion();
            }
            //EDITAR GESTIÓN    
            else
            {
                habilitarEdicion();
                cargarGestion();
            }
        }

        public void rellenarComboBox()
        {
            String sqlComboUser = "SELECT ctos_urendes.IdURD, ctos_urendes.Usuario, ctos_urendes.FBaja FROM ctos_urendes WHERE(((ctos_urendes.FBaja)Is Null))";
            comboBoxUsuario.DataSource = Persistencia.SentenciasSQL.select(sqlComboUser);
            comboBoxUsuario.DisplayMember = "Usuario";
            comboBoxUsuario.ValueMember = "IdURD";
            
            String SqlComboTipo = "SELECT exp_tipogestion.Descripcion, exp_tipogestion.IdTipoGestion FROM exp_tipogestion";
            comboBoxTipoGestion.DataSource = Persistencia.SentenciasSQL.select(SqlComboTipo);
            comboBoxTipoGestion.DisplayMember = "Descripcion";
            comboBoxTipoGestion.ValueMember = "IdTipoGestion";
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            guardarGestion();
        }

        private void cargarGestion()
        {
            
            String sqlSelect = "SELECT exp_gestiones.Descripción, exp_gestiones.IdUser, exp_gestiones.FIni, exp_gestiones.FSeguir, exp_gestiones.FMax, exp_gestiones.FFin, exp_gestiones.Importante, ctos_entidades.Entidad, exp_gestiones.IdTipoGestion FROM exp_gestiones LEFT JOIN ctos_entidades ON exp_gestiones.IdEntidad = ctos_entidades.IDEntidad WHERE(((exp_gestiones.IdGestión) = " + idGestion + "))";
            infoGestion = Persistencia.SentenciasSQL.select(sqlSelect);

            textBoxDescripcion.Text = infoGestion.Rows[0][0].ToString();
            comboBoxUsuario.SelectedValue = infoGestion.Rows[0][1].ToString();
            maskedTextBoxFInicio.Text = infoGestion.Rows[0][2].ToString();
            maskedTextBoxFSeguir.Text = infoGestion.Rows[0][3].ToString();
            maskedTextBoxFMax.Text = infoGestion.Rows[0][4].ToString();
            maskedTextBoxFFin.Text = infoGestion.Rows[0][5].ToString();
            checkBoxImportante.Checked = bool.Parse(infoGestion.Rows[0][6].ToString());
            textBoxEspera.Text = infoGestion.Rows[0][7].ToString();
            if (infoGestion.Rows[0][8].ToString() != "" )comboBoxTipoGestion.SelectedValue = infoGestion.Rows[0][8].ToString();
        }

        private void bloquearEdicion()
        {
            textBoxDescripcion.ReadOnly = true;
            comboBoxUsuario.Enabled = false;
            maskedTextBoxFInicio.ReadOnly = true;
            if (maskedTextBoxFInicio.Text == "  /  /") maskedTextBoxFInicio.Mask = "";
            maskedTextBoxFSeguir.ReadOnly = true;
            if (maskedTextBoxFSeguir.Text == "  /  /") maskedTextBoxFSeguir.Mask = "";
            maskedTextBoxFMax.ReadOnly = true;
            if (maskedTextBoxFMax.Text == "  /  /") maskedTextBoxFMax.Mask = "";
            maskedTextBoxFFin.ReadOnly = true;
            if (maskedTextBoxFFin.Text == "  /  /") maskedTextBoxFFin.Mask = "";
            checkBoxImportante.AutoCheck = false;
            comboBoxTipoGestion.Enabled = false;
            buttonGuardar.Visible = false;
            buttonEntidad.Visible = false;
            buttonEditar.Visible = true;
        }

        private void habilitarEdicion()
        {
            textBoxDescripcion.ReadOnly = false;
            comboBoxUsuario.Enabled = true;
            maskedTextBoxFInicio.ReadOnly = false;
            maskedTextBoxFSeguir.ReadOnly = false;
            maskedTextBoxFMax.ReadOnly = false;
            maskedTextBoxFFin.ReadOnly = false;
            checkBoxImportante.AutoCheck = true;
            comboBoxTipoGestion.Enabled = true;
            buttonGuardar.Visible = true;
            buttonEntidad.Visible = true;
            buttonEditar.Visible = false;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBoxFInicio_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBoxFInicio.Text, sPattern))
            {
                maskedTextBoxFInicio.Text = maskedTextBoxFInicio.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBoxFInicio.Text, sPattern1))
            {
                maskedTextBoxFSeguir.SelectAll();
            }
            else
            {
                if (maskedTextBoxFInicio.Text != "  /  /" && maskedTextBoxFInicio.Text != "")
                {
                    maskedTextBoxFInicio.Focus();
                    maskedTextBoxFInicio.SelectAll();
                }
            }
        }

        private void maskedTextBoxFMax_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBoxFMax.Text, sPattern))
            {
                maskedTextBoxFMax.Text = maskedTextBoxFMax.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBoxFMax.Text, sPattern1))
            {
                maskedTextBoxFFin.SelectAll();
            }
            else
            {
                if (maskedTextBoxFMax.Text != "  /  /" && maskedTextBoxFMax.Text != "")
                {
                    maskedTextBoxFMax.Focus();
                    maskedTextBoxFMax.SelectAll();
                }
            }
        }

        private void maskedTextBoxFSeguir_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBoxFSeguir.Text, sPattern))
            {
                maskedTextBoxFSeguir.Text = maskedTextBoxFSeguir.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBoxFSeguir.Text, sPattern1))
            {
                maskedTextBoxFMax.SelectAll();
            }
            else
            {
                if (maskedTextBoxFSeguir.Text != "  /  /" && maskedTextBoxFSeguir.Text != "")
                {
                    maskedTextBoxFSeguir.Focus();
                    maskedTextBoxFSeguir.SelectAll();
                }
            }
        }

        private void maskedTextBoxFFin_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBoxFFin.Text, sPattern))
            {
                maskedTextBoxFFin.Text = maskedTextBoxFFin.Text + DateTime.Now.Year;
            }
            else if (!Regex.IsMatch(maskedTextBoxFFin.Text, sPattern1))
            {
                if (maskedTextBoxFFin.Text != "  /  /" && maskedTextBoxFFin.Text != "")
                {
                    maskedTextBoxFFin.Focus();
                    maskedTextBoxFFin.SelectAll();
                }
            }
        }
        

        private void guardarGestion()
        {
            //VALORES DE LA QUERY DE INSERCIÓN
            String descripcion = textBoxDescripcion.Text;
            String usuario = comboBoxUsuario.SelectedValue.ToString();
            String fInicio = null;
            String fSeguir = null;
            String fMax = null;
            String fFin = null;
            if (maskedTextBoxFInicio.Text != "  /  /" && maskedTextBoxFInicio.Text != "") fInicio = Convert.ToDateTime(maskedTextBoxFInicio.Text).ToString("yyyy-MM-dd");
            if (maskedTextBoxFSeguir.Text != "  /  /" && maskedTextBoxFSeguir.Text != "") fSeguir = Convert.ToDateTime(maskedTextBoxFSeguir.Text).ToString("yyyy-MM-dd");
            if (maskedTextBoxFMax.Text != "  /  /" && maskedTextBoxFMax.Text != "" && maskedTextBoxFMax.Text != "00/00/0000") fMax = Convert.ToDateTime(maskedTextBoxFMax.Text).ToString("yyyy-MM-dd");
            if (maskedTextBoxFFin.Text != "  /  /" && maskedTextBoxFFin.Text != "") fFin = Convert.ToDateTime(maskedTextBoxFFin.Text).ToString("yyyy-MM-dd");
            String importante = "0";
            if (checkBoxImportante.Checked) importante = "1";
            String tipo = comboBoxTipoGestion.SelectedValue.ToString();
            String sqlInsert = "";
            String sqlUpdate = "";
            if (idGestion != null)
            {
                sqlUpdate = "UPDATE exp_gestiones SET IdTarea = " + idTarea + ",Descripción = '" + descripcion + "',IdUser = " + usuario + ",Importante = " + importante + ",IdTipoGestion = " + tipo + " WHERE IdGestión = " + idGestion;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                if (fInicio != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FIni = '" + fInicio + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (fSeguir != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FSeguir = '" + fSeguir + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (fMax != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FMax = '" + fMax + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (fFin != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FFin = '" + fFin + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (idEntidad != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET IdEntidad = " + idEntidad + " WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (importante == "1")
                {
                    tareaImportante();
                    
                }
            }
            else
            {
                sqlInsert = "INSERT INTO exp_gestiones (IdTarea,Descripción,IdUser,Importante,IdTipoGestion) VALUES (" + idTarea + ",'" + descripcion + "'," + usuario + "," + importante + "," + tipo + ")";

                idGestion = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
                if (fInicio != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FIni = '" + fInicio + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (fSeguir != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FSeguir = '" + fSeguir + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (fMax != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FMax = '" + fMax + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (fFin != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FFin = '" + fFin + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (idEntidad != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET IdEntidad = " + idEntidad + " WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (importante == "1")
                {
                    tareaImportante();
                }

            }

            //ACTUALIZAR DATAGRID GESTIONES DE FormVerTarea
            form_anterior.cargarGestiones();
            this.Close();

        }

        private void buttonEntidad_Click(object sender, EventArgs e)
        {
            Entidades nueva = new Entidades(this, this.Name);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.textBox_buscar_nombre.Select();
            nueva.Show();
        }

        public void recibirEntidad(String id_entidad)
        {
            idEntidad = id_entidad;
            String sqlSelect = "SELECT ctos_entidades.Entidad FROM ctos_entidades WHERE(((ctos_entidades.IDEntidad) = " + id_entidad + "))";
            textBoxEspera.Text = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
        }
    
        private void tareaImportante()
        {
            String sqlUpdate = "UPDATE exp_tareas SET Importante = -1 WHERE IdTarea = " + idTarea;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            form_anterior.tareaImportanteGestion();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            habilitarEdicion();
        }
    }
}
