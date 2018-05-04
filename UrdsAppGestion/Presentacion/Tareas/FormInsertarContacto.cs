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

            if (idContacto == null)
            {
                String sqlInsert = "INSERT INTO exp_contactos (Nombre,Tel,Correo,IdTarea) VALUES ('" + nombre + "'," + telefono + ",'" + correo + "'," + idTarea + ")";
                idContacto = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
            }
            else
            {
                String sqlUpdate = "UPDATE exp_contactos SET Nombre = '" + nombre + "',Tel = " + telefono + ",Correo = '" + correo + "' WHERE IdDetEntTarea = " + idContacto;
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

        public void recibirEntidad(String id_entidad)
        {
            String sqlSelectCorreo = "SELECT ctos_entidades.Entidad, ctos_detemail.Email FROM ctos_detemail RIGHT JOIN ctos_entidades ON ctos_detemail.IdEntidad = ctos_entidades.IDEntidad WHERE(((ctos_entidades.IDEntidad) = " + id_entidad + ") AND((ctos_detemail.Ppal) = -1))";
            DataTable tablaCorreo = Persistencia.SentenciasSQL.select(sqlSelectCorreo);
            String sqlSelectTlf = "SELECT ctos_entidades.Entidad, ctos_dettelf.Telefono FROM ctos_entidades INNER JOIN ctos_dettelf ON ctos_entidades.IDEntidad = ctos_dettelf.IdEntidad WHERE(((ctos_dettelf.Ppal) = -1) AND((ctos_entidades.IDEntidad) = " + id_entidad + "))";
            DataTable tablatlf = Persistencia.SentenciasSQL.select(sqlSelectTlf);

            textBoxNombre.Text = "";
            maskedTextBoxTelefono.Text = "";
            textBoxCorreo.Text = "";

            if (tablatlf.Rows.Count > 0)
            {
                textBoxNombre.Text = tablatlf.Rows[0][0].ToString();
                maskedTextBoxTelefono.Text = tablatlf.Rows[0][1].ToString();
            }
            if (tablaCorreo.Rows.Count > 0)
            {
                textBoxNombre.Text = tablaCorreo.Rows[0][0].ToString();
                textBoxCorreo.Text = tablaCorreo.Rows[0][1].ToString();
            }
            if (tablatlf.Rows.Count == 0 && tablaCorreo.Rows.Count == 0)
            {
                MessageBox.Show("El contacto no tiene ni teléfono ni correo!");
                return;
            }
            entidad = true;

            //BLOQUEO EDICIÓN
            textBoxCorreo.Enabled = false;
            textBoxNombre.Enabled = false;
            maskedTextBoxTelefono.Enabled = false;

        }

        public void recibirProveedor (String idProveedor)
        {
            //String sqlSelect = "SELECT ctos_entidades.Entidad, ctos_detemail.Email, ctos_dettelf.Telefono FROM((com_proveedores INNER JOIN ctos_entidades ON com_proveedores.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_detemail ON ctos_entidades.IDEntidad = ctos_detemail.IdEntidad) INNER JOIN ctos_dettelf ON ctos_entidades.IDEntidad = ctos_dettelf.IdEntidad WHERE(((com_proveedores.IdProveedor) = " + idProveedor + ") AND ((ctos_detemail.Ppal) = -1) AND((ctos_dettelf.Ppal) = -1) )";

            textBoxNombre.Text = "";
            maskedTextBoxTelefono.Text = "";
            textBoxCorreo.Text = "";

            String sqlSelectCorreo = "SELECT ctos_entidades.Entidad, ctos_detemail.Email FROM(ctos_entidades INNER JOIN ctos_detemail ON ctos_entidades.IDEntidad = ctos_detemail.IdEntidad) INNER JOIN com_proveedores ON ctos_entidades.IDEntidad = com_proveedores.IdEntidad WHERE(((com_proveedores.IdProveedor) = " + idProveedor + ") AND((ctos_detemail.Ppal) = -1))";
            DataTable tablaCorreo = Persistencia.SentenciasSQL.select(sqlSelectCorreo);
            String sqlSelectTlf = "SELECT ctos_entidades.Entidad, ctos_dettelf.Telefono FROM(ctos_entidades INNER JOIN com_proveedores ON ctos_entidades.IDEntidad = com_proveedores.IdEntidad) INNER JOIN ctos_dettelf ON ctos_entidades.IDEntidad = ctos_dettelf.IdEntidad WHERE(((com_proveedores.IdProveedor) = " + idProveedor + ") AND((ctos_dettelf.Ppal) = -1))";
            DataTable tablatlf = Persistencia.SentenciasSQL.select(sqlSelectTlf);

            if (tablatlf.Rows.Count > 0)
            {
                textBoxNombre.Text = tablatlf.Rows[0][0].ToString();
                maskedTextBoxTelefono.Text = tablatlf.Rows[0][1].ToString();
            }
            if (tablaCorreo.Rows.Count > 0)
            {
                textBoxNombre.Text = tablaCorreo.Rows[0][0].ToString();
                textBoxCorreo.Text = tablaCorreo.Rows[0][1].ToString();
            }
            if (tablatlf.Rows.Count == 0 && tablaCorreo.Rows.Count == 0)
            {
                MessageBox.Show("El contacto no tiene ni teléfono ni correo!");
                return;
            }

            proveedor = true;

            //BLOQUEO EDICIÓN
            textBoxCorreo.Enabled = false;
            textBoxNombre.Enabled = false;
            maskedTextBoxTelefono.Enabled = false;
        }

        public void recibirComunero (String idComunero)
        {
            //String sqlSelect = "SELECT ctos_entidades.Entidad, ctos_detemail.Email, ctos_dettelf.Telefono FROM((ctos_entidades INNER JOIN ctos_detemail ON ctos_entidades.IDEntidad = ctos_detemail.IdEntidad) INNER JOIN ctos_dettelf ON ctos_entidades.IDEntidad = ctos_dettelf.IdEntidad) INNER JOIN com_comuneros ON ctos_entidades.IDEntidad = com_comuneros.IdEntidad WHERE(((com_comuneros.IdComunero) = " + idComunero + ") AND ((ctos_detemail.Ppal) = -1) AND((ctos_dettelf.Ppal) = -1) )";

            textBoxNombre.Text = "";
            maskedTextBoxTelefono.Text = "";
            textBoxCorreo.Text = "";

            String sqlSelectCorreo = "SELECT ctos_entidades.Entidad, ctos_detemail.Email FROM(com_comuneros INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_detemail ON com_comuneros.IdEmail = ctos_detemail.IdEmail WHERE(((ctos_detemail.Ppal) = -1) AND((com_comuneros.IdComunero) = " + idComunero + "))";
            DataTable tablaCorreo = Persistencia.SentenciasSQL.select(sqlSelectCorreo);
            String sqlSelectTlf = "SELECT ctos_entidades.Entidad, ctos_dettelf.Telefono FROM(com_comuneros INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_dettelf ON com_comuneros.IdEntidad = ctos_dettelf.IdEntidad WHERE(((com_comuneros.IdComunero) = " + idComunero + ") AND((ctos_dettelf.Ppal) = -1))";
            DataTable tablatlf = Persistencia.SentenciasSQL.select(sqlSelectTlf);

            if (tablatlf.Rows.Count > 0)
            {
                textBoxNombre.Text = tablatlf.Rows[0][0].ToString();
                maskedTextBoxTelefono.Text = tablatlf.Rows[0][1].ToString();
            }
            if (tablaCorreo.Rows.Count > 0)
            {
                textBoxNombre.Text = tablaCorreo.Rows[0][0].ToString();
                textBoxCorreo.Text = tablaCorreo.Rows[0][1].ToString();
            }
            if (tablatlf.Rows.Count == 0 && tablaCorreo.Rows.Count == 0)
            {
                MessageBox.Show("El contacto no tiene ni teléfono ni correo!");
                return;
            }

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
            //nueva.textBox_buscar.Select();
            nueva.Show();
        }

        private void buttonComuneros_Click(object sender, EventArgs e)
        {
            ComunidadesForms.Comuneros nueva = new ComunidadesForms.Comuneros(this, "FormInsertarContacto", idComunidad);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            //nueva.textBox_buscar.Select();
            nueva.Show();
        }
        
    }
}
