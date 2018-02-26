using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    public partial class FormFicha : Form
    {
        Comunidades form_anterior;
        int id_comunidad_cargado = 0;
        String nombre_comunidad = "";
 
        public FormFicha(Comunidades form_anterior,int id_comunidad_cargado,String nombre_comunidad)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.nombre_comunidad = nombre_comunidad;
            this.Text = "Ficha " + nombre_comunidad;
            this.form_anterior = form_anterior;
            
        }

        private void FormFicha_Load(object sender, EventArgs e)
        {
            comboBox_metodo_cuotas.DataSource = Persistencia.SentenciasSQL.select("SELECT com_metodoscuotas.IdMetodoCuota,com_metodoscuotas.Método FROM com_metodoscuotas;");
            comboBox_metodo_cuotas.DisplayMember = "Método";
            comboBox_metodo_cuotas.ValueMember = "IdMetodoCuota";


            comboBox_liquidaciones.DataSource = Persistencia.SentenciasSQL.select("SELECT IdFrec, Frecuencia FROM com_frecuencias;");
            comboBox_liquidaciones.ValueMember = "IdFrec";
            comboBox_liquidaciones.DisplayMember = "Frecuencia";

            comboBox_cuotas.DataSource = Persistencia.SentenciasSQL.select("SELECT IdFrec, Frecuencia FROM com_frecuencias;");
            comboBox_cuotas.ValueMember = "IdFrec";
            comboBox_cuotas.DisplayMember = "Frecuencia";

            comboBox_recibos.Items.Insert(0, "Agrupar Divisiones");
            comboBox_recibos.Items.Insert(1, "Sin Agrupar Divisiones");

            comboBox_administrador.DataSource = Persistencia.SentenciasSQL.select("SELECT IdURD, Usuario, IdGrupoURD FROM ctos_urendes WHERE(((IdGrupoURD) = 2));");
            comboBox_administrador.ValueMember = "IdURD";
            comboBox_administrador.DisplayMember = "Usuario";

            comboBox_diaEmision.DataSource = Persistencia.SentenciasSQL.select("SELECT IdDiaEmision, Valor FROM com_diaemision");
            comboBox_diaEmision.ValueMember = "IdDiaEmision";
            comboBox_diaEmision.DisplayMember = "Valor";

            comboBox_contabilidad.DataSource = Persistencia.SentenciasSQL.select("SELECT IdURD, Usuario, IdGrupoURD FROM ctos_urendes WHERE(((IdGrupoURD) = 5));");
            comboBox_contabilidad.ValueMember = "IdURD";
            comboBox_contabilidad.DisplayMember = "Usuario";

            comboBox_tipoInforme.DataSource = Persistencia.SentenciasSQL.select("SELECT IdTipoInformeLiq, Descripcion FROM com_tipoInformeLiq");
            comboBox_tipoInforme.ValueMember = "IdTipoInformeLiq";
            comboBox_tipoInforme.DisplayMember = "Descripcion";

            comboBox_gestor.DataSource = Persistencia.SentenciasSQL.select("SELECT ctos_urendes.IdURD, ctos_urendes.Usuario, ctos_urendes.IdGrupoURD, ctos_urendes.FBaja FROM ctos_urendes WHERE(((ctos_urendes.IdGrupoURD) <> 2) AND((ctos_urendes.FBaja)Is Null));");
            comboBox_gestor.ValueMember = "IdURD";
            comboBox_gestor.DisplayMember = "Usuario";

            String sql = "SELECT com_comunidades.*, ctos_entidades.Entidad, com_comunidades.IdComunidad FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_cargado + " ));";

            DataTable datos = Persistencia.SentenciasSQL.select(sql);
            if (datos.Rows.Count > 0)
            {
                textBox_FAlta.Text = datos.Rows[0]["FAlta"].ToString();
                textBox_FBaja.Text = datos.Rows[0]["FBaja"].ToString();
                label_entidad.Text = datos.Rows[0]["Entidad"].ToString();
                textBox_referencias.Text = datos.Rows[0]["Referencia"].ToString();
                textBox_fecha_const.Text = ((datos.Rows[0]["FechaConst"].ToString()).Split(' '))[0];
                textBox_superficie.Text = datos.Rows[0]["Superficie"].ToString();
                comboBox_metodo_cuotas.SelectedValue = (int)datos.Rows[0]["MétodoCuotas"];
                comboBox_recibos.SelectedIndex = (int)datos.Rows[0]["Recibos"]-1;
                comboBox_cuotas.SelectedValue = (int)datos.Rows[0]["FrecRemesas"];
                comboBox_liquidaciones.SelectedValue = (int)datos.Rows[0]["FrecLiq"];
                comboBox_gestor.SelectedValue = (int)datos.Rows[0]["IdGestor2"];
                comboBox_administrador.SelectedValue = (int)datos.Rows[0]["IdGestor"];
                comboBox_diaEmision.SelectedValue = (int)datos.Rows[0]["DiaEmisionRecibos"];
                comboBox_tipoInforme.SelectedValue = (int)datos.Rows[0]["IdTipoInformeLiq"];
            }
            else {
                MessageBox.Show(id_comunidad_cargado + "-" + datos.Rows.Count);
            }
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //com_comunidades.FechaConst = '" + (Convert.ToDateTime(textBox_fecha_const.Text)).ToShortDateString() + "',
        private void button_guardar_Click(object sender, EventArgs e)
        {

            if (textBox_FBaja.Text != "")  {
                String fechaBaja = (Convert.ToDateTime(textBox_FBaja.Text)).ToString("yyyy-MM-dd");
                String sqlFechaBaja = "UPDATE com_comunidades SET FBaja ='" + fechaBaja + "' WHERE IdComunidad = " + id_comunidad_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlFechaBaja);
            }
            else  {
                String sqlFechaBaja = "UPDATE com_comunidades SET FBaja=NULL WHERE IdComunidad = " + id_comunidad_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlFechaBaja);
            }


            if (textBox_FAlta.Text != "")
            {
                String fechaAlta = (Convert.ToDateTime(textBox_FAlta.Text)).ToString("yyyy-MM-dd");
                String sqlFechaAlta = "UPDATE com_comunidades SET FAlta ='" + fechaAlta + "' WHERE IdComunidad = " + id_comunidad_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlFechaAlta);
            }
            else
            {
                String sqlFechaAlta = "UPDATE com_comunidades SET FAlta=NULL WHERE IdComunidad = " + id_comunidad_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlFechaAlta);
            }

            String sql;
            if (textBox_superficie.Text != "")
            {
                sql = "UPDATE com_comunidades SET com_comunidades.Referencia = " + textBox_referencias.Text + ", com_comunidades.FrecRemesas = " + comboBox_cuotas.SelectedValue + ", com_comunidades.FrecLiq = " + comboBox_liquidaciones.SelectedValue + ", com_comunidades.MétodoCuotas = " + comboBox_metodo_cuotas.SelectedValue + ",com_comunidades.FechaConst = '" + (Convert.ToDateTime(textBox_fecha_const.Text)).ToString("yyyy-MM-dd") + "', com_comunidades.Superficie = " + Convert.ToDouble(textBox_superficie.Text) + ", com_comunidades.Recibos = " + ((int)(comboBox_recibos.SelectedIndex) + 1) + ", com_comunidades.IdGestor = " + comboBox_administrador.SelectedValue + ", com_comunidades.IdGestor2 = " + comboBox_gestor.SelectedValue + ", DiaEmisionRecibos = " + comboBox_diaEmision.SelectedValue + ", IdTipoInformeLiq = " + comboBox_tipoInforme.SelectedValue + " WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_cargado + "));";
            }else {
                if (textBox_fecha_const.Text != "") {
                    sql = "UPDATE com_comunidades SET com_comunidades.Referencia = " + textBox_referencias.Text + ", com_comunidades.FrecRemesas = " + comboBox_cuotas.SelectedValue + ", com_comunidades.FrecLiq = " + comboBox_liquidaciones.SelectedValue + ", com_comunidades.MétodoCuotas = " + comboBox_metodo_cuotas.SelectedValue + ", com_comunidades.FechaConst = '" + (Convert.ToDateTime(textBox_fecha_const.Text)).ToString("yyyy-MM-dd") + "',com_comunidades.Recibos = " + ((int)(comboBox_recibos.SelectedIndex) + 1) + ", com_comunidades.IdGestor = " + comboBox_administrador.SelectedValue + ", com_comunidades.IdGestor2 = " + comboBox_gestor.SelectedValue + ",DiaEmisionRecibos = " + comboBox_diaEmision.SelectedValue + ",IdTipoInformeLiq = " + comboBox_tipoInforme.SelectedValue + " WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_cargado + "));";
                }else {
                    sql = "UPDATE com_comunidades SET com_comunidades.Referencia = " + textBox_referencias.Text + ", com_comunidades.FrecRemesas = " + comboBox_cuotas.SelectedValue + ", com_comunidades.FrecLiq = " + comboBox_liquidaciones.SelectedValue + ", com_comunidades.MétodoCuotas = " + comboBox_metodo_cuotas.SelectedValue + ", com_comunidades.Recibos = " + ((int)(comboBox_recibos.SelectedIndex) + 1) + ", com_comunidades.IdGestor = " + comboBox_administrador.SelectedValue + ", com_comunidades.IdGestor2 = " + comboBox_gestor.SelectedValue + ",DiaEmisionRecibos = " + comboBox_diaEmision.SelectedValue + ", IdTipoInformeLiq = " + comboBox_tipoInforme.SelectedValue + " WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_cargado + "));";
                }
            }

            String sqlUpdateConta = "UPDATE com_comunidades SET IdContabilidad=" + comboBox_contabilidad.SelectedValue.ToString() + " WHERE IdComunidad = " + id_comunidad_cargado;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateConta);

            Persistencia.SentenciasSQL.InsertarGenerico(sql);
            form_anterior.cargarComunidades();
            this.Close();
        }
    }
}
