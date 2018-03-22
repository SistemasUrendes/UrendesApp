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
    public partial class FormInsertarContacto : Form
    {
        String idContacto;
        String idTarea;
        Boolean edicion;
        FormVerTarea form_anterior;
        DataTable infoContacto;


        public FormInsertarContacto(FormVerTarea form_anterior,String idTarea)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idTarea = idTarea;
        }

        public FormInsertarContacto(FormVerTarea form_anterior, String idTarea, String idContacto)
        {
            InitializeComponent();
            this.idContacto = idContacto;
            this.form_anterior = form_anterior;
            this.idTarea = idTarea;
            edicion = true;
        }

        public FormInsertarContacto(FormVerTarea form_anterior, String idTarea, String idContacto,Boolean edicion)
        {
            InitializeComponent();
            this.idContacto = idContacto;
            this.edicion = edicion;
            this.form_anterior = form_anterior;
            this.idTarea = idTarea;
        }
        private void FormInsertarContacto_Load(object sender, EventArgs e)
        {
            //NUEVO CONTACTO
            if (idContacto == null)
            {
                habilitarEdicion();
            }
            //EDITAR CONTACTO
            else if (edicion)
            {
                cargarContacto();
                habilitarEdicion();
            }
            //VER CONTACTO
            else
            {
                cargarContacto();
                bloquearEdicion();
            }
        }

        private void bloquearEdicion()
        {
            textBoxCorreo.Enabled = false;
            textBoxNombre.Enabled = false;
            maskedTextBoxTelefono.Enabled = false;
            buttonGuardar.Visible = false;
            buttonEntidad.Visible = false;
        }

        private void habilitarEdicion()
        {
            textBoxCorreo.Enabled = true;
            textBoxNombre.Enabled = true;
            maskedTextBoxTelefono.Enabled = true;
            buttonGuardar.Visible = true;
            buttonEntidad.Visible = true;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            guardarContacto();
        }

        private void guardarContacto()
        {
            //VALORES DE LA QUERY DE INSERCIÓN
            String nombre = textBoxNombre.Text;
            String telefono = maskedTextBoxTelefono.Text.Replace("-", "");
            String correo = textBoxCorreo.Text;

            if (idContacto == null)
            {
                String sqlInsert = "INSERT INTO exp_contactos (Nombre,Tel,Correo,IdTarea) VALUES ('" + nombre + "'," + telefono + ",'" + correo + "'," + idTarea + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
            else
            {
                String sqlUpdate = "UPDATE exp_contactos SET Nombre = '" + nombre + "',Tel = " + telefono + ",Correo = '" + correo + "' WHERE IdDetEntTarea = " + idContacto;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }

            //ACTUALIZAR DATAGRID SEGUIMIENTOS DE FormVerTarea
            form_anterior.cargarContactos();
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarContacto()
        {
            
            String sqlSelect = "SELECT exp_contactos.Nombre, exp_contactos.Tel, exp_contactos.Correo FROM exp_contactos WHERE(((exp_contactos.IdDetEntTarea) = " + idContacto + "))";
            infoContacto = Persistencia.SentenciasSQL.select(sqlSelect);
            

            textBoxNombre.Text = infoContacto.Rows[0][0].ToString();
            maskedTextBoxTelefono.Text = infoContacto.Rows[0][1].ToString();
            textBoxCorreo.Text = infoContacto.Rows[0][2].ToString();
            
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
            String sqlSelect = "SELECT ctos_entidades.Entidad, ctos_detemail.Email, ctos_dettelf.Telefono FROM ctos_detemail LEFT JOIN(ctos_dettelf LEFT JOIN ctos_entidades ON ctos_dettelf.IdEntidad = ctos_entidades.IDEntidad) ON ctos_detemail.IdEntidad = ctos_entidades.IDEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((ctos_dettelf.Ppal) = -1) AND((ctos_entidades.IDEntidad) = " + id_entidad + "))";
            infoContacto = Persistencia.SentenciasSQL.select(sqlSelect);
            textBoxNombre.Text = infoContacto.Rows[0][0].ToString();
            textBoxCorreo.Text = infoContacto.Rows[0][1].ToString();
            maskedTextBoxTelefono.Text = infoContacto.Rows[0][2].ToString();
            

            //BLOQUEO EDICIÓN
            textBoxCorreo.Enabled = false;
            textBoxNombre.Enabled = false;
            maskedTextBoxTelefono.Enabled = false;

        }

        private void textBoxCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                guardarContacto();
            }
        }
    }
}
