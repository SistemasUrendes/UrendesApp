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
    public partial class FormTareasPrincipal : Form
    {
        DataTable tareas;
        String id_entidad;
        String nombre_columna;
        String id_comunidad;
        Form form_anterior;

        public FormTareasPrincipal(String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            
            RellenarComboBox();
            CargarTareas();
            filtroComunidad();
            textBoxTarea.Select();
                
        }
        
        public FormTareasPrincipal(Form form_anterior,String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;

            this.form_anterior = form_anterior;
            RellenarComboBox();
            CargarTareas();
            filtroComunidad();
            textBoxTarea.Select();

        }
        
        public FormTareasPrincipal()
        {
            InitializeComponent();
            RellenarComboBox();
            CargarTareas();
            maskedTextBoxRefComunidad.Select();
        }
        
        

        public void CargarTareas()
        {
            String sqlSelect;
            if (id_comunidad == null)
            {
                sqlSelect = "SELECT exp_tareas.IdTarea AS Id, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.Corto AS T, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin,  ctos_entidades.IDEntidad, exp_tareas.AcuerdoJunta AS A, exp_tareas.Importante AS I, exp_tareas.ProximaJunta AS P, exp_tareas.RefSiniestro FROM((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((exp_tareas.FFin)Is Null) AND((com_comunidades.IdGestor) = " + Login.getId() + ") OR ((com_comunidades.IdGestor2) = " + Login.getId() + ")) ORDER BY exp_tareas.IdTarea DESC";
                comboBoxAdmComunidad.SelectedValue = Login.getId();
            }
            else
            {
                sqlSelect = "SELECT exp_tareas.IdTarea AS Id, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.Corto AS T, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin,  ctos_entidades.IDEntidad, exp_tareas.AcuerdoJunta AS A, exp_tareas.Importante AS I, exp_tareas.ProximaJunta as P, exp_tareas.RefSiniestro FROM((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((exp_tareas.FFin)Is Null) AND((com_comunidades.IdComunidad) = " + id_comunidad + ")) ORDER BY exp_tareas.IdTarea DESC";
            }
            tareas = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_tareas.DataSource = tareas;
            ajustarDatagrid();
        }

        public void ajustarDatagrid()
        {
            if (dataGridView_tareas.Rows.Count > 0)
            {
                dataGridView_tareas.Columns["Id"].Width = 60;
                dataGridView_tareas.Columns["Entidad"].Width = 230;
                dataGridView_tareas.Columns["T"].Width = 17;
                dataGridView_tareas.Columns["T"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_tareas.Columns["Descripción"].Width = 410;
                dataGridView_tareas.Columns["FIni"].Width = 90;
                dataGridView_tareas.Columns["FFin"].Width = 90;
                dataGridView_tareas.Columns["A"].Width = 20;
                dataGridView_tareas.Columns["I"].Width = 20;
                dataGridView_tareas.Columns["P"].Width = 20;
                dataGridView_tareas.Columns["RefSiniestro"].Width = 150;
                dataGridView_tareas.Columns["IDEntidad"].Visible = false;
            }
        }

        public void RellenarComboBox()
        {
            DataTable tipos;
            String sqlComboTipo = "SELECT exp_tipostareas.TipoTarea, exp_tipostareas.IdTipoTarea FROM exp_tipostareas";
            tipos = Persistencia.SentenciasSQL.select(sqlComboTipo);
            DataRow filatodas = tipos.NewRow();

            filatodas["TipoTarea"] = "Todos";
            filatodas["IdTipoTarea"] = 0;
            tipos.Rows.InsertAt(filatodas, 0);
            comboBox_Tipo.DataSource = tipos;
            comboBox_Tipo.DisplayMember = "TipoTarea";
            comboBox_Tipo.ValueMember = "IdTipoTarea";
            

            List<String> estados = new List<String> { "Todas","Abierta","Cerrada" };
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
            aplicarFiltroTabla();
        }
        
        public void aplicarFiltroTabla()
        {
            String sqlSelect = "";
            //FECHAS
            String fechaInicio1 = "";
            String fechaInicio2 = "";
            String fechaFin1 = "";
            String fechaFin2 = "";
            try
            {
                if (maskedTextBox_FIni1.Text.ToString() != "  /  /") fechaInicio1 = (Convert.ToDateTime(maskedTextBox_FIni1.Text)).ToString("yyyy-MM-dd");
                if (maskedTextBox_FIni2.Text.ToString() != "  /  /") fechaInicio2 = (Convert.ToDateTime(maskedTextBox_FIni2.Text)).ToString("yyyy-MM-dd");
                if (maskedTextBox_FFin1.Text.ToString() != "  /  /") fechaFin1 = (Convert.ToDateTime(maskedTextBox_FFin1.Text)).ToString("yyyy-MM-dd");
                if (maskedTextBox_FFin2.Text.ToString() != "  /  /") fechaFin2 = (Convert.ToDateTime(maskedTextBox_FFin2.Text)).ToString("yyyy-MM-dd");
            }
            catch
            {
                MessageBox.Show("Comprueba las fechas");
                return;
            }
            //CHECKBOX
            String acuerdo = "0";
            if (checkBoxAcuerdoJunta.Checked) acuerdo = "1";
            String seguro = "0";
            if (checkBoxSeguro.Checked) seguro = "1";
            String importante = "0";
            if (checkBoxImportante.Checked) importante = "1";
            String proxJunta = "0";
            if (checkBoxProxJunta.Checked) proxJunta = "1";
            //COMBOBOX
            String tipo = comboBox_Tipo.SelectedValue.ToString() ;
            String estado = comboBox_Estado.SelectedIndex.ToString();
            String gestor = comboBoxAdmComunidad.SelectedValue.ToString();
            
            sqlSelect = "SELECT exp_tareas.IdTarea AS Id, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.Corto AS T, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin,  ctos_entidades.IDEntidad, exp_tareas.AcuerdoJunta AS A, exp_tareas.Importante AS I, exp_tareas.ProximaJunta as P, exp_tareas.RefSiniestro FROM com_comunidades INNER JOIN ((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) ON com_comunidades.IdEntidad = exp_tareas.IdEntidad";

            if (id_comunidad != null)
            {
                sqlSelect += " WHERE (com_comunidades.IdComunidad = " + id_comunidad + ")";
            }
            if (id_comunidad == null && (fechaInicio1 != "" || fechaInicio2 != "" || fechaFin1 != "" || fechaFin2 != "" || acuerdo != "0" || seguro != "0" || importante != "0" || proxJunta != "0" || tipo != "0" || estado != "0" || gestor != "0" ))
            {
                sqlSelect += " WHERE ";
            }
            //FECHAS
            if (fechaInicio1 != "")
            {
                if (id_comunidad != null) sqlSelect += " AND ";
                sqlSelect += "(exp_tareas.FIni >= '" + fechaInicio1  + "')";
            }
            if (fechaInicio2 != "")
            {
                if (id_comunidad != null || fechaInicio1 != "") sqlSelect += " AND ";
                sqlSelect += "(exp_tareas.FIni <= '" + fechaInicio2 + "')";
            }
            if (fechaFin1 != "")
            {
                if (id_comunidad != null || fechaInicio1 != "" || fechaInicio2 != "") sqlSelect += " AND ";
                sqlSelect += "(exp_tareas.FFin >= '" + fechaFin1 + "') AND (exp_tareas.FFin Is Not Null)";
            }
            if (fechaFin2 != "")
            {
                if (id_comunidad != null || fechaInicio1 != "" || fechaInicio2 != "" || fechaFin1 != "") sqlSelect += " AND ";
                sqlSelect += "(exp_tareas.FFin <= '" + fechaFin2 + "')";
                if (fechaFin1 == "") sqlSelect += " AND (exp_tareas.FFin Is Not Null)";
            }
            //CHECKBOX
            if(acuerdo == "1")
            {
                if (id_comunidad != null || fechaInicio1 != "" || fechaInicio2 != "" || fechaFin1 != "" || fechaFin2 != "") sqlSelect += " AND ";
                sqlSelect += "(exp_tareas.AcuerdoJunta = -1)";
            }
            if(seguro == "1")
            {
                if (id_comunidad != null || fechaInicio1 != "" || fechaInicio2 != "" || fechaFin1 != "" || fechaFin2 != "" || acuerdo != "0") sqlSelect += " AND ";
                sqlSelect += "((exp_tareas.Seguro = -1) OR (exp_tareas.RefSiniestro Is Not Null))";
            }
            if(importante == "1")
            {
                if (id_comunidad != null || fechaInicio1 != "" || fechaInicio2 != "" || fechaFin1 != "" || fechaFin2 != "" || acuerdo != "0" || seguro != "0") sqlSelect += " AND ";
                sqlSelect += "(exp_tareas.Importante = -1)";
            }
            if(proxJunta == "1")
            {
                if (id_comunidad != null || fechaInicio1 != "" || fechaInicio2 != "" || fechaFin1 != "" || fechaFin2 != "" || acuerdo != "0" || seguro != "0" || importante != "0") sqlSelect += " AND ";
                sqlSelect += "(exp_tareas.ProximaJunta = -1)";
            }
            //COMBOBOX
            if (tipo != "0")
            {
                if (id_comunidad != null || fechaInicio1 != "" || fechaInicio2 != "" || fechaFin1 != "" || fechaFin2 != "" || acuerdo != "0" || seguro != "0" || importante != "0" || proxJunta != "0") sqlSelect += " AND ";
                sqlSelect += "(exp_tareas.IdTipoTarea = " + tipo + ")";
            }
            if (estado != "0")
            {
                //ABIERTAS
                if (estado == "1")
                {
                    if (id_comunidad != null || fechaInicio1 != "" || fechaInicio2 != "" || fechaFin1 != "" || fechaFin2 != "" || acuerdo != "0" || seguro != "0" || importante != "0" || proxJunta != "0" || tipo != "0") sqlSelect += " AND ";
                    sqlSelect += "(exp_tareas.FFin Is Null)";
                }
                //CERRADAS
                else if (estado == "2")
                {
                    if (id_comunidad != null || fechaInicio1 != "" || fechaInicio2 != "" || fechaFin1 != "" || fechaFin2 != "" || acuerdo != "0" || seguro != "0" || importante != "0" || proxJunta != "0" || tipo != "0") sqlSelect += " AND ";
                    sqlSelect += "(exp_tareas.FFin Is Not Null)";
                }
            }
            if (gestor != "0")
            {
                if (id_comunidad != null || fechaInicio1 != "" || fechaInicio2 != "" || fechaFin1 != "" || fechaFin2 != "" || acuerdo != "0" || seguro != "0" || importante != "0" || proxJunta != "0" || tipo != "0" || estado != "0") sqlSelect += " AND ";
                sqlSelect += "(com_comunidades.IdGestor = " + gestor + " OR com_comunidades.IdGestor2 = " + gestor + ")";
            }

            sqlSelect += " ORDER BY exp_tareas.IdTarea DESC";

            //sqlSelect = "SELECT exp_tareas.IdTarea AS Id, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((exp_tareas.FFin)Is Null) AND((com_comunidades.IdComunidad) = " + id_comunidad + ")) ORDER BY exp_tareas.IdTarea DESC";

            tareas = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_tareas.DataSource = tareas;
            ajustarDatagrid();

        }


        //public void aplicarFiltroTabla()
        //{
        //    //String fechaInicio;
        //    //String fechaFin;
        //    String tipoTarea = comboBox_Tipo.SelectedValue.ToString();
        //    String proxJunta = "0";
        //    if (checkBoxProxJunta.Checked) proxJunta = "-1";
        //    String seguro = "0";
        //    if (checkBoxSeguro.Checked) seguro = "-1";

        //    /*
        //    try
        //    {
        //        fechaInicio = (Convert.ToDateTime(maskedTextBox_inicio.Text)).ToString("yyyy-MM-dd");
        //        fechaFin = (Convert.ToDateTime(maskedTextBox_fin.Text)).ToString("yyyy-MM-dd");

        //    }
        //    catch
        //    {
        //        MessageBox.Show("Comprueba la fecha");
        //        return;
        //    }
        //    */
        //    if (id_entidad_nuevo != null) {
        //        String sqlSelect = "";
        //        //ESTADO "ABIERTA"
        //        if (comboBox_Estado.SelectedIndex == 1)
        //        {
        //            //TIPO ESPECÍFICO DE TAREA
        //            if (tipoTarea != "0")
        //            {
        //                //sqlSelect = "SELECT exp_tareas.IdTarea AS Id, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tareas.FIni) >= '" + fechaInicio + "' And(exp_tareas.FIni) <= '" + fechaFin + "') AND((exp_tareas.FFin)Is Null And((exp_tareas.FFin) <= '" + fechaFin + "' Or(exp_tareas.FFin) Is Null)) AND((ctos_entidades.IDEntidad) = " + id_entidad_nuevo + ") AND((exp_tipostareas.IdTipoTarea) = " + tipoTarea + ") AND((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ")) ORDER BY exp_tareas.IdTarea DESC";

        //                sqlSelect = "SELECT exp_tareas.IdTarea AS Id, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((ctos_entidades.IDEntidad) = " + id_entidad_nuevo + ") AND((exp_tipostareas.IdTipoTarea) = " + tipoTarea + ") AND((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ") AND (exp_tareas.FFin) Is Null) ORDER BY exp_tareas.IdTarea DESC";
        //            }
        //            //TODOS LOS TIPOS DE TAREA
        //            else
        //            {
        //                sqlSelect = "SELECT exp_tareas.IdTarea AS Id, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((ctos_entidades.IDEntidad) = " + id_entidad_nuevo + ") AND((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ") AND (exp_tareas.FFin) Is Null) ORDER BY exp_tareas.IdTarea DESC";
        //            }

        //        }
        //        //ESTADO "CERRADA"
        //        else if (comboBox_Estado.SelectedIndex == 2)
        //        {
        //            if (tipoTarea != "0")
        //            {
        //                sqlSelect = "SELECT exp_tareas.IdTarea as Id, ctos_entidades.NombreCorto as Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ") AND (exp_tareas.FFin) Is not Null) ORDER BY exp_tareas.IdTarea DESC";
        //            }
        //            else
        //            {
        //                sqlSelect = "SELECT exp_tareas.IdTarea as Id, ctos_entidades.NombreCorto as Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((ctos_entidades.IDEntidad) = " + id_entidad_nuevo + ") AND((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ") AND (exp_tareas.FFin) Is Not Null) ORDER BY exp_tareas.IdTarea DESC";
        //            }
        //        }
        //        //ESTADO "TODAS"
        //        else
        //        {
        //            if (tipoTarea != "0")
        //            {
        //                sqlSelect = "SELECT exp_tareas.IdTarea as Id, ctos_entidades.NombreCorto as Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni,exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((ctos_entidades.IDEntidad) = " + id_entidad_nuevo + ") AND((exp_tipostareas.IdTipoTarea) = " + tipoTarea + ") AND((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ")) ORDER BY exp_tareas.IdTarea DESC ";
        //            }
        //            else
        //            {
        //                sqlSelect = "SELECT exp_tareas.IdTarea as Id, ctos_entidades.NombreCorto as Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni,exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((ctos_entidades.IDEntidad) = " + id_entidad_nuevo + ") AND((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ")) ORDER BY exp_tareas.IdTarea DESC ";
        //            }
        //        }
        //        tareas = Persistencia.SentenciasSQL.select(sqlSelect);
        //        dataGridView_tareas.DataSource = tareas;
        //        ajustarDatagrid();
        //    }
        //    else
        //    {
        //        String sqlSelect = "";
        //        //ESTADO "ABIERTA"
        //        if (comboBox_Estado.SelectedIndex == 1)
        //        {
        //            //TIPO ESPECÍFICO DE TAREA
        //            if (tipoTarea != "0")
        //            {
        //                sqlSelect = "SELECT exp_tareas.IdTarea as Id, ctos_entidades.NombreCorto as Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tipostareas.IdTipoTarea) = " + tipoTarea + ") AND((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ") AND (exp_tareas.FFin) Is Null) ORDER BY exp_tareas.IdTarea DESC";
        //            }
        //            //TODOS LOS TIPOS DE TAREA
        //            else
        //            {
        //                sqlSelect = "SELECT exp_tareas.IdTarea as Id, ctos_entidades.NombreCorto as Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ") AND (exp_tareas.FFin) Is Null) ORDER BY exp_tareas.IdTarea DESC";
        //            }
        //        }
        //        //ESTADO "CERRADA"
        //        else if (comboBox_Estado.SelectedIndex == 2)
        //        {
        //            if (tipoTarea != "0")
        //            {
        //                sqlSelect = "SELECT exp_tareas.IdTarea as Id, ctos_entidades.NombreCorto as Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tipostareas.IdTipoTarea) = " + tipoTarea + ") AND ((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ") AND (exp_tareas.FFin) Is Not Null) ORDER BY exp_tareas.IdTarea DESC";
        //            }
        //            else
        //            {
        //                sqlSelect = "SELECT exp_tareas.IdTarea as Id, ctos_entidades.NombreCorto as Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tareas.ProximaJunta) = " + proxJunta + ") AND ((exp_tareas.Seguro) = " + seguro + ") AND (exp_tareas.FFin) Is Not Null) ORDER BY exp_tareas.IdTarea DESC";
        //            }
        //        }
        //        //ESTADO "TODAS"
        //        else
        //        {
        //            if (tipoTarea != "0")
        //            {
        //                sqlSelect = "SELECT exp_tareas.IdTarea as Id, ctos_entidades.NombreCorto as Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni,exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tipostareas.IdTipoTarea) = " + tipoTarea + ") AND ((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ")) ORDER BY exp_tareas.IdTarea DESC ";
        //            }
        //            else
        //            {
        //                sqlSelect = "SELECT exp_tareas.IdTarea as Id, ctos_entidades.NombreCorto as Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni,exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tareas.ProximaJunta) = " + proxJunta + ") AND((exp_tareas.Seguro) = " + seguro + ")) ORDER BY exp_tareas.IdTarea DESC ";
        //            }
        //        }
        //        tareas = Persistencia.SentenciasSQL.select(sqlSelect);
        //        dataGridView_tareas.DataSource = tareas;
        //        ajustarDatagrid();
        //        //tareas.DefaultView.RowFilter = "Entidad like '%" + textBox_Entidad.Text + "%' OR Descripción like '%" + textBox_Entidad.Text + "%'";
        //    }
        //}

        private void dataGridView_tareas_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                toolStripTextBoxFiltro.Text = "";
                var hti = dataGridView_tareas.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    dataGridView_tareas.ClearSelection();
                    dataGridView_tareas.Rows[hti.RowIndex].Selected = true;
                    dataGridView_tareas.Columns[hti.ColumnIndex].Selected = true;
                    dataGridView_tareas.CurrentCell = this.dataGridView_tareas[hti.ColumnIndex, hti.RowIndex];
                    nombre_columna = dataGridView_tareas.CurrentCell.OwningColumn.Name;
                    if (nombre_columna != "Fini" && nombre_columna != "Ffin")
                    {
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }
            }
        }

        private void toolStripTextBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            String filtro;
            if (toolStripTextBoxFiltro.TextLength == 1)
            {
                DataTable busqueda = tareas;
                busqueda.DefaultView.RowFilter = string.Empty;
                this.dataGridView_tareas.DataSource = busqueda;
                
                if (nombre_columna != "Id")
                {
                    filtro = nombre_columna + " like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%'";

                }
                else
                {
                    filtro = string.Format("[{0}] >= '{1}'", nombre_columna, toolStripTextBoxFiltro.Text.ToUpper().ToString());
                }
                busqueda.DefaultView.RowFilter = filtro;
                this.dataGridView_tareas.DataSource = busqueda;
            }
            else if (toolStripTextBoxFiltro.TextLength > 1)
            {
                DataTable busqueda = tareas;

                if (nombre_columna != "Id")
                {
                    filtro = nombre_columna + " like '%" + toolStripTextBoxFiltro.Text.ToUpper().ToString() + "%'";
                    
                }
                else
                {
                    filtro = string.Format("[{0}] >= '{1}'", nombre_columna, toolStripTextBoxFiltro.Text.ToUpper().ToString());
                }
                busqueda.DefaultView.RowFilter = filtro;
                this.dataGridView_tareas.DataSource = busqueda;
            }
        }

        private void textBox_Entidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            tareas.DefaultView.RowFilter = "Entidad like '%" + textBox_Entidad.Text + "%' OR Descripción like '%" + textBox_Entidad.Text + "%'";
            
        }

        private void dataGridView_tareas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_tareas.SelectedCells.Count > 0)
            {
                string idTarea = dataGridView_tareas.SelectedRows[0].Cells[0].Value.ToString(); 

                Tareas.FormVerTarea nueva = new FormVerTarea(this,idTarea);
                nueva.Show();
            }
        }

        private void buttonNuevaTarea_Click(object sender, EventArgs e)
        {
            Tareas.FormVerTarea nueva = new FormVerTarea(this);
            nueva.Show();
        }
        

        private void toolStripMenuItemBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView_tareas.SelectedCells.Count > 0)
            {
                string idTarea = dataGridView_tareas.SelectedRows[0].Cells[0].Value.ToString();

                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar esta Tarea ?", "Borrar Tarea", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    String sqlBorrar = "DELETE FROM exp_tareas WHERE IdTarea = " + idTarea;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    CargarTareas();
                }
            }
        }
        

        private String nombreReferencia()
        {
            String sql = "SELECT ctos_entidades.Entidad, com_comunidades.IdEntidad, com_comunidades.IdComunidad FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.Referencia) = " + maskedTextBoxRefComunidad.Text + "))";
            
            DataTable entidad = Persistencia.SentenciasSQL.select(sql);
            id_entidad= entidad.Rows[0][1].ToString();
            id_comunidad = entidad.Rows[0][2].ToString();
            CargarTareas();

            return entidad.Rows[0][0].ToString();
        }

        private void maskedTextBoxRefComunidad_Leave(object sender, EventArgs e)
        {
            if (maskedTextBoxRefComunidad.Text != "")
            {
                try
                {
                    textBox_Entidad.Text = nombreReferencia();
                    textBox_Entidad.ForeColor = Color.Black;
                    comboBox_Tipo.Focus();
                    comboBox_Tipo.SelectAll();
                }
                catch
                {
                    maskedTextBoxRefComunidad.Text = "";
                    maskedTextBoxRefComunidad.Focus();
                }
            }
        }

        private void toolStripTextBoxFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Tab || e.KeyChar == (Char)Keys.Enter)
                {
                    contextMenuStrip1.Close();
                }
        }

        private void buttonGrupo_Click(object sender, EventArgs e)
        {
            Tareas.FormInsertarGrupo nueva = new FormInsertarGrupo();
            nueva.Show();
        }

        private void filtroComunidad()
        {
            String sqlSelect = "SELECT com_comunidades.Referencia FROM com_comunidades WHERE(((com_comunidades.IdComunidad) = " + id_comunidad + "))";
            String referencia = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            maskedTextBoxRefComunidad.Text = referencia;
            textBox_Entidad.Text = nombreReferencia();
        }
        
        private Boolean existeTarea(String idTarea)
        {
            String sqlSelect = "SELECT exp_tareas.IdTarea FROM exp_tareas WHERE(((exp_tareas.IdTarea) = " + idTarea + "))";
            DataTable tarea = Persistencia.SentenciasSQL.select(sqlSelect);
            if (tarea.Rows.Count == 0)
                return false;           
            return true;       
        }

        private void textBoxTarea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                String idTarea = textBoxTarea.Text.ToString();
                if (existeTarea(idTarea))
                {
                    Tareas.FormVerTarea nueva = new FormVerTarea(this, idTarea);
                    nueva.Show();
                }
                else
                {
                    MessageBox.Show("La tarea " + idTarea + " no existe!");
                }
            }
        }

        private void comboBoxInformes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT ctos_entidades.IDEntidad, ctos_entidades.Entidad FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.Referencia) = " + maskedTextBoxRefComunidad.Text + "))";
            DataTable comunidad = Persistencia.SentenciasSQL.select(sqlSelect);
            String idEntidad = comunidad.Rows[0][0].ToString();
            String nombreComunidad = comunidad.Rows[0][1].ToString();
            Tareas.Informes.VistaInformeSeguimiento nueva = new Informes.VistaInformeSeguimiento(idEntidad, nombreComunidad);
            nueva.Show();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            DataTable busqueda = tareas;
            busqueda.DefaultView.RowFilter = string.Empty;
            this.dataGridView_tareas.DataSource = busqueda;
        }
        
        private void tareasImportantes()
        {
            String sqlSelect;
            if (id_comunidad == null)
            {
                sqlSelect = "SELECT exp_tareas.IdTarea AS Id, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM(exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tareas.FFin)Is Null)) ORDER BY exp_tareas.Importante, exp_tareas.FIni";
            }
            else
            {
                sqlSelect = "SELECT exp_tareas.IdTarea AS Id, ctos_entidades.NombreCorto AS Entidad, exp_tipostareas.TipoTarea, exp_tareas.Descripción, exp_tareas.FIni, exp_tareas.FFin, exp_tareas.RefSiniestro, ctos_entidades.IDEntidad FROM((exp_tareas INNER JOIN ctos_entidades ON exp_tareas.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea) INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((exp_tareas.FFin)Is Null) AND((com_comunidades.IdComunidad) = " + id_comunidad + ")) ORDER BY exp_tareas.Importante, exp_tareas.FIni";
            }
            tareas = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_tareas.DataSource = tareas;
            ajustarDatagrid();
        }

        private void buttonImportantes_Click(object sender, EventArgs e)
        {
            tareasImportantes();
        }

        private void buttonAvanzada_Click(object sender, EventArgs e)
        {
            Tareas.FormFiltroAvanzado nueva = new FormFiltroAvanzado();
            nueva.Show();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT ctos_entidades.IDEntidad, ctos_entidades.Entidad FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.Referencia) = " + maskedTextBoxRefComunidad.Text + "))";
            DataTable comunidad = Persistencia.SentenciasSQL.select(sqlSelect);
            String idEntidad = comunidad.Rows[0][0].ToString();
            String nombreComunidad = comunidad.Rows[0][1].ToString();
            Tareas.Informes.VistaInformeSeguimiento nueva = new Informes.VistaInformeSeguimiento(idEntidad, nombreComunidad);
            nueva.Show();
        }
    }
}
