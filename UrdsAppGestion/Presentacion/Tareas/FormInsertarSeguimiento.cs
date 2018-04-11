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
    public partial class FormInsertarSeguimiento : Form
    {
        String idGestion;
        String idSeguimiento;
        Boolean edicion;
        String fechaCompleta;
        FormVerTarea form_anterior;
        DataTable infoSeguimiento;

        public FormInsertarSeguimiento(FormVerTarea form_anterior,String idGestion)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idGestion = idGestion;
            edicion = true;
        }

        public FormInsertarSeguimiento(FormVerTarea form_anterior, String idGestion,String idSeguimiento)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idGestion = idGestion;
            this.idSeguimiento = idSeguimiento;
            edicion = true;
        }

        public FormInsertarSeguimiento(FormVerTarea form_anterior, String idGestion, String idSeguimiento, Boolean edicion)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idGestion = idGestion;
            this.idSeguimiento = idSeguimiento;
            this.edicion = edicion;
        }



        private void FormInsertarSeguimiento_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
            //NUEVO SEGUIMIENTO
            if (idSeguimiento == null)
            {
                habilitarEdicion();
                comboBoxUsuario.SelectedValue = Login.getId();
                //maskedTextBoxFecha.Text = string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
                maskedTextBoxFecha.Text = DateTime.Now.ToShortDateString();
            }
            //EDITAR SEGUIMIENTO
            else if (edicion)
            {
                habilitarEdicion();
                cargarSeguimiento();
            }
            //VER SEGUIMIENTO
            else
            {
                cargarSeguimiento();
                bloquearEdicion();
            }
        }

        public void rellenarComboBox()
        {
            String sqlComboUser = "SELECT ctos_urendes.IdURD, ctos_urendes.Usuario, ctos_urendes.FBaja FROM ctos_urendes WHERE(((ctos_urendes.FBaja)Is Null))";
            comboBoxUsuario.DataSource = Persistencia.SentenciasSQL.select(sqlComboUser);
            comboBoxUsuario.DisplayMember = "Usuario";
            comboBoxUsuario.ValueMember = "IdURD";
            
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

            //VALORES DE LA QUERY DE INSERCIÓN
            String notas = textBoxNotas.Text;
            String usuario = comboBoxUsuario.SelectedValue.ToString();
            //String fecha = Convert.ToDateTime(maskedTextBoxFecha.Text).ToString("yyyy-MM-dd HH:mm:ss");
            String fecha = Convert.ToDateTime(maskedTextBoxFecha.Text).ToString("yyyy-MM-dd");
            if (idSeguimiento == null)
            {
                String sqlInsert = "INSERT INTO exp_notas (IdGestión,Fecha,IdURD,Notas) VALUES (" + idGestion + ",'" + fecha + "'," + usuario + ",'" + notas + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
            else
            {
                String sqlUpdate = "UPDATE exp_notas SET Notas = '" + notas + "',IdURD = " + usuario + ",Fecha = '" + fecha + "' WHERE IdNota = " + idSeguimiento;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }    

            //ACTUALIZAR DATAGRID SEGUIMIENTOS DE FormVerTarea
            form_anterior.cargarSeguimientos();
            this.Close();
        }

        private void cargarSeguimiento()
        {
            String sqlSelect = "SELECT exp_notas.Fecha, exp_notas.IdURD, exp_notas.Notas FROM exp_notas WHERE(((exp_notas.IdNota) = " + idSeguimiento + "))";
            infoSeguimiento = Persistencia.SentenciasSQL.select(sqlSelect);

            
            maskedTextBoxFecha.Text = Convert.ToDateTime(infoSeguimiento.Rows[0][0]).ToString("dd-MM-yyyy");
            comboBoxUsuario.SelectedValue = infoSeguimiento.Rows[0][1].ToString();
            textBoxNotas.Text = infoSeguimiento.Rows[0][2].ToString();
        }

        private void bloquearEdicion()
        {
            comboBoxUsuario.Enabled = false;
            maskedTextBoxFecha.ReadOnly = true;
            textBoxNotas.ReadOnly = true;
            buttonEditar.Visible = true;
            buttonGuardar.Visible = false;

        }

        private void habilitarEdicion()
        {
            comboBoxUsuario.Enabled = true;
            maskedTextBoxFecha.ReadOnly = false;
            textBoxNotas.ReadOnly = false;
            buttonEditar.Visible = false;
            buttonGuardar.Visible = true;

        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            habilitarEdicion();
        }

        private void maskedTextBoxFecha_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBoxFecha.Text, sPattern))
            {
                maskedTextBoxFecha.Text = maskedTextBoxFecha.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBoxFecha.Text, sPattern1))
            {
                textBoxNotas.Focus();
                textBoxNotas.SelectAll();
            }
            else
            {
                if (maskedTextBoxFecha.Text != "  /  /" && maskedTextBoxFecha.Text != "")
                {
                    maskedTextBoxFecha.Focus();
                    maskedTextBoxFecha.SelectAll();
                }
            }
        }
    }
}
