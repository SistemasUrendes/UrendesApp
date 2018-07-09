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
        String idComunidad;
        String idContacto;
        String idTarea;
        Boolean edicion;
        FormVerTarea form_anterior;
        DataTable infoContacto;
        bool entidad;
        bool comunero;
        bool proveedor;


        public FormInsertarContacto(FormVerTarea form_anterior,String idTarea, String idComunidad)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idTarea = idTarea;
            this.idComunidad = idComunidad;
        }

        public FormInsertarContacto(String idTarea, String idComunidad)
        {
            InitializeComponent();
            this.idTarea = idTarea;
            this.idComunidad = idComunidad;
        }

        public FormInsertarContacto(FormVerTarea form_anterior, String idTarea, String idContacto, String idComunidad)
        {
            InitializeComponent();
            this.idContacto = idContacto;
            this.form_anterior = form_anterior;
            this.idTarea = idTarea;
            edicion = true;
            this.idComunidad = idComunidad;
        }

        public FormInsertarContacto(FormVerTarea form_anterior, String idTarea, String idContacto, String idComunidad, Boolean edicion)
        {
            InitializeComponent();
            this.idContacto = idContacto;
            this.edicion = edicion;
            this.form_anterior = form_anterior;
            this.idTarea = idTarea;
            this.idComunidad = idComunidad; 
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
            entidad = false;
            comunero = false;
            proveedor = false;
        }

        private void bloquearEdicion()
        {
            textBoxCorreo.Enabled = false;
            textBoxNombre.Enabled = false;
            textBoxNotas.Enabled = false;
            maskedTextBoxTelefono.Enabled = false;
            buttonGuardar.Visible = false;
            buttonEntidad.Visible = false;
            buttonComuneros.Visible = false;
            buttonProveedores.Visible = false;
           
            
        }

        private void habilitarEdicion()
        {
            textBoxCorreo.Enabled = true;
            textBoxNombre.Enabled = true;
            textBoxNotas.Enabled = true;
            maskedTextBoxTelefono.Enabled = true;
            buttonGuardar.Visible = true;
            buttonEntidad.Visible = true;
            buttonComuneros.Visible = true;
            buttonProveedores.Visible = true;

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
            telefono = telefono.Replace(" ", "");
            String correo = textBoxCorreo.Text;
            String notas = textBoxNotas.Text;

            if (telefono == "" && correo == "")
            {
                MessageBox.Show("Introduce un Correo o Teléfono.");
                return; 
            }
            if (idContacto == null)
            {
                if (telefono != "" && correo != "")
                {
                    String sqlInsert = "INSERT INTO exp_contactos (Nombre,Tel,Correo,IdTarea) VALUES ('" + nombre + "','" + telefono + "','" + correo + "','" + idTarea + "')";
                    idContacto = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
                }
                else if ( telefono != "")
                {
                    String sqlInsert = "INSERT INTO exp_contactos (Nombre,Tel,IdTarea) VALUES ('" + nombre + "','" + telefono + "','" + idTarea + "')";
                    idContacto = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
                }
                else
                {
                    String sqlInsert = "INSERT INTO exp_contactos (Nombre,Correo,IdTarea) VALUES ('" + nombre + "','" + correo + "','" + idTarea + "')";
                    idContacto = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
                }
            }
            else
            {
                String sqlUpdate = "UPDATE exp_contactos SET Nombre = '" + nombre + "',Tel = '" + telefono + "',Correo = '" + correo + "' WHERE IdDetEntTarea = " + idContacto;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            //TIPO CONTACTO
            if(entidad)
            {
                String sqlUpdate = "UPDATE exp_contactos SET Entidad = -1 WHERE IdDetEntTarea = " + idContacto;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            if (proveedor)
            {
                String sqlUpdate = "UPDATE exp_contactos SET Proveedor = -1 WHERE IdDetEntTarea = " + idContacto;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            if (comunero)
            {
                String sqlUpdate = "UPDATE exp_contactos SET Comunero = -1 WHERE IdDetEntTarea = " + idContacto;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            if (notas != null)  
            {
                String sqlUpdate = "UPDATE exp_contactos SET Notas = '" + notas + "' WHERE IdDetEntTarea = " + idContacto;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }


            //ACTUALIZAR DATAGRID SEGUIMIENTOS DE FormVerTarea
            if (form_anterior != null) form_anterior.cargarContactos();
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarContacto()
        {
            String sqlSelect = "SELECT exp_contactos.Nombre, exp_contactos.Tel, exp_contactos.Correo, exp_contactos.Notas FROM exp_contactos WHERE(((exp_contactos.IdDetEntTarea) = " + idContacto + "))";
            infoContacto = Persistencia.SentenciasSQL.select(sqlSelect);
            

            textBoxNombre.Text = infoContacto.Rows[0][0].ToString();
            maskedTextBoxTelefono.Text = infoContacto.Rows[0][1].ToString();
            textBoxCorreo.Text = infoContacto.Rows[0][2].ToString();
            textBoxNotas.Text = infoContacto.Rows[0][3].ToString();
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

        public void recibirEntidad(String nombre, String correo, String tlf)
        {
            textBoxNombre.Text = nombre;
            maskedTextBoxTelefono.Text = tlf;
            textBoxCorreo.Text = correo;
            entidad = true;

            //BLOQUEO EDICIÓN
            textBoxCorreo.Enabled = false;
            textBoxNombre.Enabled = false;
            maskedTextBoxTelefono.Enabled = false;

        }

        public void recibirProveedor (String nombre,String correo, String tlf)
        {
            textBoxNombre.Text = nombre;
            maskedTextBoxTelefono.Text = tlf;
            textBoxCorreo.Text = correo;
            
            proveedor = true;

            //BLOQUEO EDICIÓN
            textBoxCorreo.Enabled = false;
            textBoxNombre.Enabled = false;
            maskedTextBoxTelefono.Enabled = false;
        }

        public void recibirComunero (String idComunero,String nombre,String correo)
        {
            

            String sqlSelectTlf = "SELECT ctos_dettelf.Telefono FROM(com_comuneros INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_dettelf ON com_comuneros.IdEntidad = ctos_dettelf.IdEntidad WHERE(((com_comuneros.IdComunero) = " + idComunero + ") AND((ctos_dettelf.Ppal) = -1))";
            DataTable tablatlf = Persistencia.SentenciasSQL.select(sqlSelectTlf);

            maskedTextBoxTelefono.Text = "";

            if (tablatlf.Rows.Count > 0)
            {
                maskedTextBoxTelefono.Text = tablatlf.Rows[0][0].ToString();
            }

            textBoxNombre.Text = nombre;
            textBoxCorreo.Text = correo;
            comunero = true;

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

        private void buttonProveedores_Click(object sender, EventArgs e)
        {
            ComunidadesForms.OperacionesForms.FormOperacionesListadoProveedores nueva = new ComunidadesForms.OperacionesForms.FormOperacionesListadoProveedores(this,"FormInsertarContacto",idComunidad);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void buttonComuneros_Click(object sender, EventArgs e)
        {
            ComunidadesForms.Comuneros nueva = new ComunidadesForms.Comuneros(this, "FormInsertarContacto", idComunidad);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        
    }
}
