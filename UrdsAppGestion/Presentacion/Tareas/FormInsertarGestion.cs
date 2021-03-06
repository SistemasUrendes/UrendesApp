﻿using System;
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
        String sfInicio;
        String sfSeguir;
        String sfMax;
        String sfFin;
        String oldEntidad;
        int idComunidad;
        String esperade;

        public FormInsertarGestion(FormVerTarea form_anterior,String idTarea,String fInicio,int idComunidad)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idTarea = idTarea;
            this.fInicio = fInicio;
            this.idComunidad = idComunidad;
        }

        public FormInsertarGestion(FormVerTarea form_anterior, String idTarea, String idGestion, String fInicio, int idComunidad)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idTarea = idTarea;
            this.idGestion = idGestion;
            this.fInicio = fInicio;
            this.idComunidad = idComunidad;
        }

        public FormInsertarGestion(FormVerTarea form_anterior, String idGestion,int idComunidad)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idGestion = idGestion;
            this.idComunidad = idComunidad;
        }

        public FormInsertarGestion(String idGestion,String idTarea,int idComunidad)
        {
            InitializeComponent();
            this.idTarea = idTarea;
            this.idGestion = idGestion;
            this.idComunidad = idComunidad;
        }

        public FormInsertarGestion(String idGestion,int idComunidad)
        {
            InitializeComponent();
            this.idGestion = idGestion;
            this.idComunidad = idComunidad;
        }

        public FormInsertarGestion(String idGestion)
        {
            InitializeComponent();
            this.idGestion = idGestion;
            idComunidad = 0;
        }



        private void FormInsertarGestion_Load(object sender, EventArgs e)
        {
            
            rellenarComboBox();
            maskedTextBoxFInicio.Text = DateTime.Now.ToShortDateString();
            maskedTextBoxFSeguir.Text = DateTime.Now.ToShortDateString();
            //NUEVA GESTIÓN
            if (idGestion == null)
            {
                habilitarEdicion();
                comboBoxUsuario.SelectedValue = Login.getId();
                this.Name = "FormInsertarGestion 0" ;
            }
            //VER GESTIÓN
            else if (idTarea == null)
            {
                cargarGestion();
                bloquearEdicion();           
                this.Name = "FormInsertarGestion " + idGestion;
            }
            //EDITAR GESTIÓN    
            else
            {
                habilitarEdicion();
                cargarGestion();
                this.Name = "FormInsertarGestion " + idGestion;
            }
            monthCalendar1.MaxSelectionCount = 1;
        }

        public void rellenarComboBox()
        {
            String sqlComboUser = "SELECT ctos_urendes.IdURD, ctos_urendes.Usuario, ctos_urendes.FBaja FROM ctos_urendes WHERE(((ctos_urendes.FBaja)Is Null))";
            comboBoxUsuario.DataSource = Persistencia.SentenciasSQL.select(sqlComboUser);
            comboBoxUsuario.DisplayMember = "Usuario";
            comboBoxUsuario.ValueMember = "IdURD";

            if (idTarea == null)
            {
                String sqlSelect = "SELECT exp_gestiones.IdTarea FROM exp_gestiones WHERE(((exp_gestiones.IdGestión) = " + idGestion + "))";
                idTarea = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();

            }
            //String SqlComboTipo = "SELECT exp_tipogestion.Descripcion, exp_tipogestion.IdTipoGestion FROM exp_tipogestion";
            String SqlComboTipo = "SELECT exp_tipogestion.Descripcion, exp_tipogestion.IdTipoGestion FROM exp_tareas INNER JOIN (exp_tipogestion INNER JOIN exp_gestionEstado ON exp_tipogestion.IdTipoGestion = exp_gestionEstado.IdTipoGestion) ON exp_tareas.IdTipoTarea = exp_gestionEstado.IdTipoTarea WHERE(((exp_tareas.IdTarea) = " + idTarea + "))";
            comboBoxTipoGestion.DataSource = Persistencia.SentenciasSQL.select(SqlComboTipo);
            comboBoxTipoGestion.DisplayMember = "Descripcion";
            comboBoxTipoGestion.ValueMember = "IdTipoGestion";

            comboBoxEspera.SelectedIndex = 0;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            guardarGestion();
        }

        private void cargarGestion()
        {
            String sqlSelect = "SELECT exp_gestiones.Descripción, exp_gestiones.IdUser, exp_gestiones.FIni, exp_gestiones.FSeguir, exp_gestiones.FMax, exp_gestiones.FFin, exp_gestiones.Importante, If(exp_gestiones.TipoContacto = 'GOB',exp_categoriaContactos.Nombre,ctos_entidades.Entidad) AS Espera, exp_gestiones.IdTipoGestion FROM(exp_gestiones LEFT JOIN ctos_entidades ON exp_gestiones.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN exp_categoriaContactos ON exp_gestiones.IdEntidad = exp_categoriaContactos.IdGrupo WHERE(((exp_gestiones.IdGestión) = " + idGestion + "))";

            infoGestion = Persistencia.SentenciasSQL.select(sqlSelect);

            textBoxDescripcion.Text = infoGestion.Rows[0][0].ToString();
            comboBoxUsuario.SelectedValue = infoGestion.Rows[0][1].ToString();
            maskedTextBoxFInicio.Text = infoGestion.Rows[0][2].ToString();
            maskedTextBoxFSeguir.Text = infoGestion.Rows[0][3].ToString();
            maskedTextBoxFMax.Text = infoGestion.Rows[0][4].ToString();
            maskedTextBoxFFin.Text = infoGestion.Rows[0][5].ToString();
            checkBoxImportante.Checked = bool.Parse(infoGestion.Rows[0][6].ToString());
            textBoxEspera.Text = infoGestion.Rows[0][7].ToString();
            oldEntidad = infoGestion.Rows[0][7].ToString();
            if (infoGestion.Rows[0][8].ToString() != "" )comboBoxTipoGestion.SelectedValue = infoGestion.Rows[0][8].ToString();
            sfInicio = infoGestion.Rows[0][2].ToString();
            sfSeguir = infoGestion.Rows[0][3].ToString();
            if (infoGestion.Rows[0][4].ToString() != "00/00/0000") sfMax = infoGestion.Rows[0][4].ToString();
            else sfMax = "";
            sfFin = maskedTextBoxFFin.Text = infoGestion.Rows[0][5].ToString();

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
            comboBoxEspera.Visible = false;
            buttonEspera.Visible = false;
            buttonEditar.Visible = true;
            textBoxEspera.ReadOnly = true;
            monthCalendar1.Visible = false;
            buttonFAgenda.Visible = false;
            buttonFIni.Visible = false;
            buttonFFin.Visible = false;
            buttonFLimite.Visible = false;
        }

        private void habilitarEdicion()
        {
            textBoxDescripcion.ReadOnly = false;
            comboBoxUsuario.Enabled = true;
            maskedTextBoxFInicio.ReadOnly = false;
            maskedTextBoxFInicio.Mask = "00/00/0000";
            maskedTextBoxFSeguir.ReadOnly = false;
            maskedTextBoxFSeguir.Mask = "00/00/0000";
            maskedTextBoxFMax.ReadOnly = false;
            maskedTextBoxFMax.Mask = "00/00/0000";
            maskedTextBoxFFin.ReadOnly = false;
            maskedTextBoxFFin.Mask = "00/00/0000";
            checkBoxImportante.AutoCheck = true;
            comboBoxTipoGestion.Enabled = true;
            buttonGuardar.Visible = true;
            comboBoxEspera.Visible = true;
            buttonEspera.Visible = true;
            buttonEditar.Visible = false;
            textBoxEspera.ReadOnly = false;
            monthCalendar1.Visible = true;
            buttonFAgenda.Visible = true;
            buttonFIni.Visible = true;
            buttonFFin.Visible = true;
            buttonFLimite.Visible = true;

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
            if (maskedTextBoxFInicio.Text != "  /  /" && maskedTextBoxFInicio.Text != "" && maskedTextBoxFInicio.Text != "00/00/0000") fInicio = Convert.ToDateTime(maskedTextBoxFInicio.Text).ToString("yyyy-MM-dd");
            
            if (maskedTextBoxFSeguir.Text != "  /  /" && maskedTextBoxFSeguir.Text != "" && maskedTextBoxFSeguir.Text != "00/00/0000") fSeguir = Convert.ToDateTime(maskedTextBoxFSeguir.Text).ToString("yyyy-MM-dd");
            if (maskedTextBoxFMax.Text != "  /  /" && maskedTextBoxFMax.Text != "" && maskedTextBoxFMax.Text != "00/00/0000") fMax = Convert.ToDateTime(maskedTextBoxFMax.Text).ToString("yyyy-MM-dd");
            if (maskedTextBoxFFin.Text != "  /  /" && maskedTextBoxFFin.Text != "" && maskedTextBoxFFin.Text != "00/00/0000") fFin = Convert.ToDateTime(maskedTextBoxFFin.Text).ToString("yyyy-MM-dd");
            String importante = "0";
            if (checkBoxImportante.Checked) importante = "1";
            String tipo = comboBoxTipoGestion.SelectedValue.ToString();
            String sqlInsert = "";
            String sqlUpdate = "";
            
            if (idGestion != null)
            {
                sqlUpdate = "UPDATE exp_gestiones SET Descripción = '" + descripcion + "',IdUser = " + usuario + ",Importante = " + importante + ",IdTipoGestion = " + tipo + " WHERE IdGestión = " + idGestion;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                if (fInicio != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FIni = '" + fInicio + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                else if (sfInicio != "")
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FIni = NULL WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (fSeguir != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FSeguir = '" + fSeguir + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                else if (sfSeguir != "")
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FSeguir = NULL WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (fMax != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FMax = '" + fMax + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                else if (sfMax != "")
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FMax = NULL WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (fFin != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FFin = '" + fFin + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                else if (sfFin != "")
                {
                    sqlUpdate = "UPDATE exp_gestiones SET FFin = NULL WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if ((idEntidad != null && textBoxEspera.Text == "") || (oldEntidad != "" && textBoxEspera.Text == ""))
                {
                    sqlUpdate = "UPDATE exp_gestiones SET IdEntidad = null WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                else if (idEntidad != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET IdEntidad = " + idEntidad + " WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (esperade != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET TipoContacto = '" + esperade + "' WHERE IdGestión = " + idGestion;
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
                if (esperade != null)
                {
                    sqlUpdate = "UPDATE exp_gestiones SET TipoContacto = '" + esperade + "' WHERE IdGestión = " + idGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                if (importante == "1")
                {
                    tareaImportante();
                }

            }

            //ACTUALIZAR DATAGRID GESTIONES DE FormVerTarea
            if (form_anterior != null )form_anterior.cargarGestiones();
            this.Close();

        }
        
        public void recibirEntidad(String id_entidad,String nombre)
        {
            idEntidad = id_entidad;
            esperade = "ENT";
            textBoxEspera.Text = nombre;
        }
    
        private void tareaImportante()
        {
            String sqlUpdate = "UPDATE exp_tareas SET Importante = -1 WHERE IdTarea = " + idTarea;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            if (form_anterior != null) form_anterior.tareaImportanteGestion();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            habilitarEdicion();
        }
        
        private void buttonAgenda5_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxFSeguir.Text == "  /  /")
            {
                maskedTextBoxFSeguir.Text = DateTime.Now.AddDays(5).ToShortDateString();
            }
            else
            {
                DateTime dateini = Convert.ToDateTime(maskedTextBoxFSeguir.Text);
                maskedTextBoxFSeguir.Text = dateini.AddDays(5).ToShortDateString();
            }
        }

        private void buttonLimite5_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxFMax.Text == "  /  /")
            {
                maskedTextBoxFMax.Text = DateTime.Now.AddDays(5).ToShortDateString();
            }
            else
            {
                DateTime dateini = Convert.ToDateTime(maskedTextBoxFMax.Text);
                maskedTextBoxFMax.Text = dateini.AddDays(5).ToShortDateString();
            }
        }
        
        private void buttonAgenda15_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxFSeguir.Text == "  /  /")
            {
                maskedTextBoxFSeguir.Text = DateTime.Now.AddDays(15).ToShortDateString();
            }
            else
            {
                DateTime dateini = Convert.ToDateTime(maskedTextBoxFSeguir.Text);
                maskedTextBoxFSeguir.Text = dateini.AddDays(15).ToShortDateString();
            }
        }

        private void buttonLimite15_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxFMax.Text == "  /  /")
            {
                maskedTextBoxFMax.Text = DateTime.Now.AddDays(15).ToShortDateString();
            }
            else
            {
                DateTime dateini = Convert.ToDateTime(maskedTextBoxFMax.Text);
                maskedTextBoxFMax.Text = dateini.AddDays(15).ToShortDateString();
            }
        }

        private void buttonAgenda30_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxFSeguir.Text == "  /  /")
            {
                maskedTextBoxFSeguir.Text = DateTime.Now.AddDays(30).ToShortDateString();
            }
            else
            {
                DateTime dateini = Convert.ToDateTime(maskedTextBoxFSeguir.Text);
                maskedTextBoxFSeguir.Text = dateini.AddDays(30).ToShortDateString();
            }
        }

        private void buttonLimite30_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxFMax.Text == "  /  /")
            {
                maskedTextBoxFMax.Text = DateTime.Now.AddDays(30).ToShortDateString();
            }
            else
            {
                DateTime dateini = Convert.ToDateTime(maskedTextBoxFMax.Text);
                maskedTextBoxFMax.Text = dateini.AddDays(30).ToShortDateString();
            }
        }

        private void buttonFinNow_Click(object sender, EventArgs e)
        {
            maskedTextBoxFFin.Text = DateTime.Now.ToShortDateString();
        }
       
        public void recibirComunero (String idEntidad,String nombre)
        {
            this.idEntidad = idEntidad;
            esperade = "COM";
            textBoxEspera.Text = nombre;
        }

        public void recibirProveedor(String idEntidad,String nombre)
        {
            this.idEntidad = idEntidad;
            esperade = "PRO";
            textBoxEspera.Text = nombre;
        }

        public void recibirContacto(String idContacto,String nombre)
        {
            this.idEntidad = idContacto;
            esperade = "TMP";
            textBoxEspera.Text = nombre;
        }

        public void recibirOrgano(String idEntidad)
        {
            this.idEntidad = idEntidad;
            esperade = "CAR";
            
            String sqlSelect = "SELECT com_cargos.Cargo FROM com_cargos INNER JOIN(com_comuneros INNER JOIN com_cargoscom ON com_comuneros.IdComunero = com_cargoscom.IdComunero) ON com_cargos.IdCargo = com_cargoscom.IdCargo WHERE(((com_comuneros.IdEntidad) = '" + idEntidad + "') AND((com_cargoscom.FFin)Is Null))";

            textBoxEspera.Text = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
        }
        
        public void recibirGrupo(String idGrupo, String nombre)
        {
            this.idEntidad = idGrupo;
            esperade = "GOB";
            textBoxEspera.Text = nombre;
        }

        private void buttonEspera_Click(object sender, EventArgs e)
        {
            //ENTIDAD
            if (comboBoxEspera.SelectedIndex == 0)
            {
                Entidades nueva = new Entidades(this, this.Name);
                nueva.ControlBox = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar_nombre.Select();
                nueva.Show();
            }
            //COMUNERO
            else if (comboBoxEspera.SelectedIndex == 1)
            {
                if (idComunidad == 0)
                {
                    MessageBox.Show("Solo hay comuneros en una comunidad!");
                }
                else
                {
                    ComunidadesForms.Comuneros nueva = new ComunidadesForms.Comuneros(this, "FormInsertarGestion", idComunidad.ToString());
                    nueva.ControlBox = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    nueva.Show();
                }
            }
            //PROVEEDOR
            else if (comboBoxEspera.SelectedIndex == 2)
            {
                if (idComunidad == 0)
                {
                    MessageBox.Show("Solo hay proveedores en una comunidad!");
                }
                else
                {
                    ComunidadesForms.OperacionesForms.FormOperacionesListadoProveedores nueva = new ComunidadesForms.OperacionesForms.FormOperacionesListadoProveedores(this, "FormInsertarGestion", idComunidad.ToString());
                    nueva.ControlBox = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    nueva.Show();
                }
            }
            //CARGOS GOBIERNO
            else if (comboBoxEspera.SelectedIndex == 3)
            {
                if (idComunidad == 0)
                {
                    MessageBox.Show("Solo hay Organos de Gobierno en una comunidad!");
                }
                else
                {
                    ComunidadesForms.CargosForms.FormCargos nueva = new ComunidadesForms.CargosForms.FormCargos(this,idComunidad.ToString());
                    nueva.ControlBox = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    nueva.Show();
                }
            }
            //CONTACTOS
            else if (comboBoxEspera.SelectedIndex == 4)
            {
                if (idTarea == null)
                {
                    String sqlSelect = "SELECT exp_gestiones.IdTarea FROM exp_gestiones WHERE(((exp_gestiones.IdGestión) = " + idGestion + "))";
                    idTarea = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();

                }
                FormVerContactos nueva = new FormVerContactos(this,"FormInsertarGestion",idTarea,idComunidad.ToString());
                nueva.ControlBox = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
            //ORGANOS GOBIERNO
            else if (comboBoxEspera.SelectedIndex == 5)
            {
                if (idTarea == null)
                {
                    String sqlSelect = "SELECT exp_gestiones.IdTarea FROM exp_gestiones WHERE(((exp_gestiones.IdGestión) = " + idGestion + "))";
                    idTarea = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
                }
                ComunidadesForms.CargosForms.FormListadoOrganos nueva = new ComunidadesForms.CargosForms.FormListadoOrganos(this, idComunidad.ToString());
                nueva.ControlBox = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
        }

        private void buttonFIni_Click(object sender, EventArgs e)
        {
            maskedTextBoxFInicio.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
        }

        private void buttonFAgenda_Click(object sender, EventArgs e)
        {
            maskedTextBoxFSeguir.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
        }

        private void buttonFLimite_Click(object sender, EventArgs e)
        {
            maskedTextBoxFMax.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
        }

        private void buttonFFin_Click(object sender, EventArgs e)
        {
            maskedTextBoxFFin.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
        }
        
    }
}
