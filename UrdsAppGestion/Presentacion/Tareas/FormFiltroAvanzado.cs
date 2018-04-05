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
    public partial class FormFiltroAvanzado : Form
    {
        public FormFiltroAvanzado()
        {
            InitializeComponent();
        }
        
        private void FormFiltroAvanzado_Load(object sender, EventArgs e)
        {

            maskedTextBox_inicio.Text = "01-01-" + DateTime.Now.Year;
            maskedTextBox_fin.Text = DateTime.Now.ToShortDateString();
        }

        private void cargarComboBox()
        {
            DataTable admins;
            String sqlComboAdm = "SELECT ctos_urendes.IdURD, ctos_urendes.Usuario FROM ctos_urendes WHERE(((ctos_urendes.FBaja)Is Null) AND((ctos_urendes.IdGrupoURD) = 1 Or(ctos_urendes.IdGrupoURD) = 2))";
            admins = Persistencia.SentenciasSQL.select(sqlComboAdm);
            DataRow admtodas = admins.NewRow();

            admtodas["Usuario"] = "Todos";
            admtodas["IdURD"] = 0;
            admins.Rows.InsertAt(admtodas, 0);
            comboBoxAdmComunidad.DataSource = admins;
            comboBoxAdmComunidad.DisplayMember = "Usuario";
            comboBoxAdmComunidad.ValueMember = "IdURD";

        }
        private void comboBoxAdmComunidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String sqlSelect;
            if (comboBoxAdmComunidad.SelectedValue.ToString() == "0")
            {
                sqlSelect = "SELECT exp_tareas.IdTarea AS Id, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tareas.FFin)Is Null)) ORDER BY exp_tareas.IdTarea DESC";
            }
            else
            {
                sqlSelect = "SELECT exp_tareas.IdTarea AS Id, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((exp_tareas.FFin)Is Null) AND((com_comunidades.IdGestor) = " + comboBoxAdmComunidad.SelectedValue.ToString() + ") OR ((com_comunidades.IdGestor2) = " + comboBoxAdmComunidad.SelectedValue.ToString() + ")) ORDER BY exp_tareas.IdTarea DESC";
            }
            //tareas = Persistencia.SentenciasSQL.select(sqlSelect);
            //dataGridView_tareas.DataSource = tareas;
            //ajustarDatagrid();
        }

    }
}
