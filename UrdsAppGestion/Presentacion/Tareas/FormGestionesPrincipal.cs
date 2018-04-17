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
    public partial class FormGestionesPrincipal : Form
    {
        DataTable tablaGestiones;
        public FormGestionesPrincipal()
        {
            InitializeComponent();
        }

        private void FormGestionesPrincipal_Load(object sender, EventArgs e)
        {
            CargarGestiones();
            RellenarComboBox();
        }


        public void CargarGestiones()
        {
            String sqlSelect = "SELECT exp_gestiones.IdGestión AS Id, exp_gestiones.Orden AS Ord, ctos_urendes.Usuario, exp_gestiones.Descripción, exp_tipogestion.Descripcion AS `Tipo Gestión`, exp_gestiones.Importante AS S, exp_gestiones.FIni, exp_gestiones.FSeguir AS FAgenda, exp_gestiones.FMax AS `Fecha Límite`, exp_gestiones.FFin, ctos_entidades.Entidad AS `Espera de` FROM(((exp_gestiones INNER JOIN ctos_urendes ON exp_gestiones.IdUser = ctos_urendes.IdURD) INNER JOIN exp_niveles ON exp_gestiones.IdNivel = exp_niveles.IdNivel) LEFT JOIN ctos_entidades ON exp_gestiones.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE (exp_gestiones.IdUser = " + Login.getId() + " AND (exp_gestiones.FSeguir = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'))";
            //String sqlSelect = "SELECT exp_gestiones.IdGestión AS Id, exp_gestiones.Orden AS Ord, ctos_urendes.Usuario, exp_gestiones.Descripción, exp_tipogestion.Descripcion AS `Tipo Gestión`, exp_gestiones.Importante AS S, exp_gestiones.FIni, exp_gestiones.FSeguir AS FAgenda, exp_gestiones.FMax AS `Fecha Límite`, exp_gestiones.FFin, ctos_entidades.Entidad AS `Espera de` FROM(((exp_gestiones INNER JOIN ctos_urendes ON exp_gestiones.IdUser = ctos_urendes.IdURD) INNER JOIN exp_niveles ON exp_gestiones.IdNivel = exp_niveles.IdNivel) LEFT JOIN ctos_entidades ON exp_gestiones.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE (exp_gestiones.IdUser = 20 AND (exp_gestiones.FSeguir = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'))";
            tablaGestiones = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewGestiones.DataSource = tablaGestiones;
            ajustarDatagrid();
        }

        private void ajustarDatagrid()
        {
            if (dataGridViewGestiones.Rows.Count > 0)
            {
                dataGridViewGestiones.Columns["Id"].Width = 50;
                dataGridViewGestiones.Columns["Ord"].Visible = false;
                dataGridViewGestiones.Columns["Usuario"].Visible = false;
                dataGridViewGestiones.Columns["Descripción"].Width = 300;
                dataGridViewGestiones.Columns["Tipo Gestión"].Width = 120;
                dataGridViewGestiones.Columns["S"].Width = 30;
                dataGridViewGestiones.Columns["FIni"].Width = 90;
                dataGridViewGestiones.Columns["FAgenda"].Width = 90;
                dataGridViewGestiones.Columns["Fecha límite"].Width = 95;
                dataGridViewGestiones.Columns["FFin"].Width = 90;
                dataGridViewGestiones.Columns["Espera de"].Width = 260;
            }
        }

        private void RellenarComboBox()
        {
            DataTable tipos;
            String sqlComboTipo = "SELECT exp_tipogestion.IdTipoGestion, exp_tipogestion.Descripcion FROM exp_tipogestion";
            tipos = Persistencia.SentenciasSQL.select(sqlComboTipo);
            DataRow filatodas = tipos.NewRow();

            filatodas["Descripcion"] = "Todos";
            filatodas["IdTipoGestion"] = 0;
            tipos.Rows.InsertAt(filatodas, 0);
            comboBox_Tipo.DataSource = tipos;
            comboBox_Tipo.DisplayMember = "Descripcion";
            comboBox_Tipo.ValueMember = "IdTipoGestion";


            List<String> estados = new List<String> { "Todas", "Abierta", "Cerrada" };
            comboBox_Estado.DataSource = estados;

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

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonNuevaGestion_Click(object sender, EventArgs e)
        {

        }
    }
}
