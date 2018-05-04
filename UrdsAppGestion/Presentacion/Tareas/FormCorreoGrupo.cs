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
    public partial class FormCorreoGrupo : Form
    {
        String idGestion;
        String idEntidad;
        String idTarea;
        String descripcion;

        public FormCorreoGrupo(String idGestion,String idEntidad, String idTarea, String descripcion)
        {
            InitializeComponent();
            this.idGestion = idGestion;
            this.idEntidad = idEntidad;
            this.idTarea = idTarea;
            this.descripcion = descripcion;
        }

        private void FormCorreoGrupo_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            String idGrupo = comboBoxGrupo.SelectedValue.ToString();
            String mail = "";
            DataTable grupoContactos = null;
            String sqlContactos = "SELECT ctos_detemail.Email AS Correo FROM((exp_categoriaContactos INNER JOIN exp_catcontactos ON exp_categoriaContactos.IdGrupo = exp_catcontactos.IdCategoria) INNER JOIN exp_contactos ON exp_catcontactos.IdContacto = exp_contactos.IdDetEntTarea) INNER JOIN ctos_detemail ON exp_contactos.IdEntidad = ctos_detemail.IdEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((exp_categoriaContactos.IdGrupo) = " + comboBoxGrupo.SelectedValue + ") AND ((exp_catcontactos.TipoContacto) = 'T'))";
            grupoContactos = Persistencia.SentenciasSQL.select(sqlContactos);

            String sqlProveedores = "SELECT ctos_detemail.Email AS Correo FROM(((exp_categoriaContactos INNER JOIN exp_catcontactos ON exp_categoriaContactos.IdGrupo = exp_catcontactos.IdCategoria) INNER JOIN com_proveedores ON exp_catcontactos.IdContacto = com_proveedores.IdProveedor) INNER JOIN ctos_entidades ON com_proveedores.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_detemail ON ctos_entidades.IDEntidad = ctos_detemail.IdEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((exp_categoriaContactos.IdGrupo) = " + comboBoxGrupo.SelectedValue + ") AND ((exp_catcontactos.TipoContacto) = 'P'))";
            grupoContactos.Merge(Persistencia.SentenciasSQL.select(sqlProveedores));

            String sqlCargos = "SELECT ctos_detemail.Email AS Correo FROM ctos_detemail INNER JOIN ((((exp_categoriaContactos INNER JOIN exp_catcontactos ON exp_categoriaContactos.IdGrupo = exp_catcontactos.IdCategoria) INNER JOIN com_cargos ON exp_catcontactos.IdContacto = com_cargos.IdCargo) INNER JOIN com_cargoscom ON com_cargos.IdCargo = com_cargoscom.IdCargo) INNER JOIN com_comuneros ON com_cargoscom.IdComunero = com_comuneros.IdComunero) ON ctos_detemail.IdEntidad = com_comuneros.IdEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((exp_categoriaContactos.IdGrupo) = " + comboBoxGrupo.SelectedValue + ") AND ((com_cargos.Baja) = 0) AND((exp_catcontactos.TipoContacto) = 'O'))";
            grupoContactos.Merge(Persistencia.SentenciasSQL.select(sqlCargos));

            String sqlComuneros = "SELECT ctos_detemail.Email AS Correo FROM((exp_categoriaContactos INNER JOIN exp_catcontactos ON exp_categoriaContactos.IdGrupo = exp_catcontactos.IdCategoria) INNER JOIN (ctos_detemail INNER JOIN com_comuneros ON ctos_detemail.IdEntidad = com_comuneros.IdEntidad) ON exp_catcontactos.IdContacto = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((exp_categoriaContactos.IdGrupo) = " + comboBoxGrupo.SelectedValue + ") AND((exp_catcontactos.TipoContacto) = 'C'))";
            grupoContactos.Merge(Persistencia.SentenciasSQL.select(sqlComuneros));
            
            for (int i = 0; i < grupoContactos.Rows.Count; i++)
            {
                mail += grupoContactos.Rows[i][0].ToString();
                if (i < grupoContactos.Rows.Count - 1) mail += ",";
            }

            System.Diagnostics.Process.Start("thunderbird", "-compose \"to=\'" + mail + "\',subject=\'" + generaAsunto() + "\'");
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rellenarComboBox()
        {
            String sqlComboGrupo = "SELECT exp_categoriaContactos.Nombre, exp_categoriaContactos.IdGrupo FROM exp_categoriaContactos";
            comboBoxGrupo.DataSource = Persistencia.SentenciasSQL.select(sqlComboGrupo);
            comboBoxGrupo.DisplayMember = "Nombre";
            comboBoxGrupo.ValueMember = "IdGrupo";
        }

        private String generaAsunto()
        {
            String sqlSelect = "SELECT ctos_entidades.NombreCorto, com_comunidades.Referencia FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + idEntidad + "))";
            DataTable comunidad = Persistencia.SentenciasSQL.select(sqlSelect);

            String asunto = "";
            asunto += comunidad.Rows[0][0].ToString();//Nombre corto
            asunto += " - ( Ref. " + comunidad.Rows[0][1].ToString(); //Referencia comunidad
            asunto += " / " + idTarea; //IdTarea
            asunto += ") " + descripcion; //Descripción

            return asunto;
        }
    }
}
