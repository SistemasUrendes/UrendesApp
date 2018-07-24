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
        String idGrupo;
        Boolean edicion;
        FormVerContactos form_anterior2;
        FormVerTarea form_anterior;
        DataTable infoContacto;
        bool entidad;
        bool comunero;
        bool proveedor;
        bool cargo;
        bool organo;


        public FormInsertarContacto(FormVerTarea form_anterior,String idTarea, String idComunidad)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idTarea = idTarea;
            this.idComunidad = idComunidad;
        }

        public FormInsertarContacto(FormVerContactos form_anterior2,String idTarea, String idComunidad)
        {
            InitializeComponent();
            this.idTarea = idTarea;
            this.idComunidad = idComunidad;
            this.form_anterior2 = form_anterior2;
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
            organo = false;
            cargo = false;
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
            buttonCargo.Visible = false;
            buttonOrgano.Visible = false;


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
            buttonCargo.Visible = true;
            buttonOrgano.Visible = true;

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
            String tipoContacto = "";
            if (entidad)
            {
                tipoContacto = "ENT";
            }
            else if (proveedor)
            {
                tipoContacto = "PRO";
            }
            else if (comunero)
            {
                tipoContacto = "COM";
            }
            else if (cargo)
            {
                tipoContacto = "CAR";
            }
            else
            {
                tipoContacto = "TMP";
            }

            if (telefono == "" && correo == "" && !organo)
            {
                MessageBox.Show("Introduce un Correo o Teléfono.");
                return; 
            }
            if (idContacto == null)
            {
                if (organo)
                {
                    String sqlInsert = "INSERT INTO exp_contactos (Nombre,IdTarea,TipoContacto,IdEntidad) VALUES ('" + nombre + "','" + idTarea + "','GOB','" + idGrupo + "')";
                    idContacto = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
                }
                else if (telefono != "" && correo != "")
                {
                    String sqlInsert = "INSERT INTO exp_contactos (Nombre,Tel,Correo,IdTarea,TipoContacto) VALUES ('" + nombre + "','" + telefono + "','" + correo + "','" + idTarea + "','" + tipoContacto + "')";
                    idContacto = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
                }
                else if ( telefono != "")
                {
                    String sqlInsert = "INSERT INTO exp_contactos (Nombre,Tel,IdTarea,TipoContacto) VALUES ('" + nombre + "','" + telefono + "','" + idTarea + "','" + tipoContacto + "')";
                    idContacto = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
                }
                else
                {
                    String sqlInsert = "INSERT INTO exp_contactos (Nombre,Correo,IdTarea,TipoContacto) VALUES ('" + nombre + "','" + correo + "','" + idTarea + "','" + tipoContacto + "')";
                    idContacto = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
                }
            }
            else
            {
                String sqlUpdate = "UPDATE exp_contactos SET Nombre = '" + nombre + "',Tel = '" + telefono + "',Correo = '" + correo + "' WHERE IdDetEntTarea = " + idContacto;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            if (notas != null)  
            {
                String sqlUpdate = "UPDATE exp_contactos SET Notas = '" + notas + "' WHERE IdDetEntTarea = " + idContacto;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            //ACTUALIZAR DATAGRID SEGUIMIENTOS DE FormVerTarea
            if (form_anterior != null) form_anterior.cargarContactos();
            else if (form_anterior2 != null) form_anterior2.cargarContactos();
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

        public void recibirProveedor (String nombre,String correo, String tlf,String tipo)
        {
            textBoxNombre.Text = nombre;
            maskedTextBoxTelefono.Text = tlf;
            textBoxCorreo.Text = correo;
            textBoxNotas.Text = tipo;
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

        public void recibirCargo(String idEntidad,String nombre,String cargo)
        {
            textBoxNombre.Text = nombre;
            textBoxNotas.Text = cargo;

            String sqlSelectMail= "SELECT ctos_detemail.Email FROM ctos_entidades LEFT JOIN ctos_detemail ON ctos_entidades.IDEntidad = ctos_detemail.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + idEntidad + ") AND((ctos_detemail.Ppal) = -1))";

            DataTable tablaMail= Persistencia.SentenciasSQL.select(sqlSelectMail);

            textBoxCorreo.Text = "";

            if (tablaMail.Rows.Count > 0)
            {
                textBoxCorreo.Text = tablaMail.Rows[0][0].ToString();
            }

            String sqlSelectTlf = "SELECT ctos_dettelf.Telefono FROM ctos_entidades INNER JOIN ctos_dettelf ON ctos_entidades.IDEntidad = ctos_dettelf.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + idEntidad + ") AND((ctos_dettelf.Orden) = 1))";
            DataTable tablatlf = Persistencia.SentenciasSQL.select(sqlSelectTlf);

            maskedTextBoxTelefono.Text = "";

            if (tablatlf.Rows.Count > 0)
            {
                maskedTextBoxTelefono.Text = tablatlf.Rows[0][0].ToString();
            }
            
            this.cargo = true;

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

        private void buttonCargo_Click(object sender, EventArgs e)
        {
            if (idComunidad == null)
            {
                MessageBox.Show("Solo hay Organos de Gobierno en una comunidad!");
            }
            else
            {
                ComunidadesForms.CargosForms.FormCargos nueva = new ComunidadesForms.CargosForms.FormCargos(this, idComunidad.ToString());
                nueva.ControlBox = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
        }

        private void buttonOrgano_Click(object sender, EventArgs e)
        {
            ComunidadesForms.CargosForms.FormListadoOrganos nueva = new ComunidadesForms.CargosForms.FormListadoOrganos(this, idComunidad.ToString());
            nueva.ControlBox = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        public void recibirGrupo(String idGrupo, String nombre)
        {
            organo = true;
            textBoxNombre.Text = nombre;

            this.idGrupo = idGrupo;

            //BLOQUEO EDICIÓN
            textBoxCorreo.Enabled = false;
            textBoxNombre.Enabled = false;
            maskedTextBoxTelefono.Enabled = false;
        }
    }
}
