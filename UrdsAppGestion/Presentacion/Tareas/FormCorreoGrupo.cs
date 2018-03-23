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
            String sqlSelect = "SELECT exp_contactos.Correo FROM exp_catcontactos INNER JOIN exp_contactos ON exp_catcontactos.IdGrupo = exp_contactos.IdCat WHERE(((exp_catcontactos.IdGrupo) = " + idGrupo +"))"; 
            DataTable tablaMail = Persistencia.SentenciasSQL.select(sqlSelect);
            for (int i = 0; i < tablaMail.Rows.Count; i++)
            {
                mail += tablaMail.Rows[i][0].ToString();
                if (i < tablaMail.Rows.Count - 1) mail += ",";
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
            String sqlComboGrupo = "SELECT exp_catcontactos.Nombre, exp_catcontactos.IdGrupo FROM exp_catcontactos";
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
