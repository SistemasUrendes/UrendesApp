using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    public partial class FormAltaAsociacion : Form
    {
        String id_entidad;
        Divisiones form_anterior;
        int id_asociacion_cargado = 0;
        int id_division = 0;
        int id_comunidad_cargado = 0;
        String id_comunidad_cargado1 = "0";
        DataTable fila;
        int indiceSel;

        public FormAltaAsociacion(Divisiones form_anterior, int id_division, String id_comunidad_cargado1, int indiceSel)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado1 = id_comunidad_cargado1;
            this.id_division = id_division;
            this.indiceSel = indiceSel;
        }
        public FormAltaAsociacion(Divisiones form_anterior, int id_comunidad_cargado,int id_asociacion_cargado, int id_division, int indiceSel)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_asociacion_cargado = id_asociacion_cargado; this.id_division = id_division;
            this.indiceSel = indiceSel;
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public String NombreEntidad(String id_entidad) {
            String sql = "SELECT Entidad FROM ctos_entidades WHERE IDEntidad = " + id_entidad;
            DataTable nombre = Persistencia.SentenciasSQL.select(sql);
            return nombre.Rows[0][0].ToString();
        }
        public String ComuneroEntidad(String id_comunero) {
            String sql = "SELECT IdEntidad FROM com_comuneros WHERE IdComunero = " + id_comunero;
            DataTable id = Persistencia.SentenciasSQL.select(sql);
            return id.Rows[0][0].ToString();
        }
        public String EntidadComunero(String id_entidad)
        {
            String sql = "SELECT IdComunero FROM com_comuneros WHERE IdEntidad = " + id_entidad;
            DataTable id = Persistencia.SentenciasSQL.select(sql);
            try
            {
                return id.Rows[0][0].ToString();
            }
            catch {
                MessageBox.Show("Esa entidad no es un comunero");
                return "";
            }
        }

        private void FormAltaAsociacion_Load(object sender, EventArgs e)
        {
            String sql = "SELECT IdTipoAsoc,TipoAsociación FROM com_tipoasociacion";
            comboBox_tipoasociacion.DataSource = Persistencia.SentenciasSQL.select(sql);
            comboBox_tipoasociacion.DisplayMember = "TipoAsociación";
            comboBox_tipoasociacion.ValueMember = "IdTipoAsoc";

            if (id_asociacion_cargado != 0) {

                String sql2 = "SELECT com_asociacion.IdDivision, com_asociacion.IdComunero, com_asociacion.IdTipoAsoc, com_tipoasociacion.`TipoAsociación`, com_asociacion.Participacion, com_asociacion.FechaAlta, com_asociacion.FechaBaja, com_asociacion.Ppal FROM com_asociacion INNER JOIN com_tipoasociacion ON com_asociacion.IdTipoAsoc = com_tipoasociacion.IdTipoAsoc WHERE(((com_asociacion.IdAsociacion) = " + +id_asociacion_cargado + " ));";
                fila = Persistencia.SentenciasSQL.select(sql2);

                comboBox_tipoasociacion.SelectedValue = fila.Rows[0]["IdTipoAsoc"].ToString();
                textBox_porcentaje.Text = fila.Rows[0]["Participacion"].ToString();
                textBox_fechaalta.Text = fila.Rows[0]["FechaAlta"].ToString();
                textBox_fechabaja.Text = fila.Rows[0]["FechaBaja"].ToString();
                id_entidad = ComuneroEntidad(fila.Rows[0]["IdComunero"].ToString());
                textBox_Comunero.Text = NombreEntidad(id_entidad);

                if (fila.Rows[0]["Ppal"].ToString() == "True")
                    checkBox_representante.Checked = true;

                if (checkBox_representante.Checked) {
                    //textBox_fechabaja.Enabled = false;
                    //label_fechadebaja.Enabled = false;
                    //checkBox_representante.Enabled = false;
                }else {
                    textBox_fechabaja.Enabled = true;
                    label_fechadebaja.Enabled = true;
                    checkBox_representante.Enabled = true;
                }
            }
            else {
                textBox_fechabaja.Enabled = true;
                label_fechadebaja.Enabled = true;
            }
        }
        private void button_guardar_Click(object sender, EventArgs e)
        {
            String sql;
            String ppal = "0";
            String fechaAlta;
            String fechaBaja;

            if (checkBox_representante.Checked == true)
                ppal = "-1";
            String participacion = textBox_porcentaje.Text.Replace(",",".");

            if (textBox_fechaalta.MaskFull)
            {
                fechaAlta = (Convert.ToDateTime(textBox_fechaalta.Text)).ToString("yyyy-MM-dd");
            }else {
                MessageBox.Show("Debes ingresar una fecha de Alta correcta");
                return;
            }

            if (id_asociacion_cargado != 0) {
                if (textBox_fechabaja.MaskFull)
                {
                    String sqlSelectRegla = "SELECT com_repartos.Descripcion FROM(com_divisiones INNER JOIN com_tipodivs ON com_divisiones.IdTipoDiv = com_tipodivs.IdTipoDiv) INNER JOIN com_repartos ON com_divisiones.IdDivision = com_repartos.IdDivision GROUP BY com_divisiones.IdDivision, com_divisiones.IdComunidad, com_repartos.Descripcion HAVING(((com_divisiones.IdDivision) = " + id_division + ") AND((com_divisiones.IdComunidad) = " + id_comunidad_cargado + "));";

                    DataTable reglas = Persistencia.SentenciasSQL.select(sqlSelectRegla);

                    if (reglas.Rows.Count > 0) {
                        MessageBox.Show("¡ATENCIÓN ! Tiene una regla de pago esta división " + reglas.Rows[0][0].ToString());
                    }

                    fechaBaja = (Convert.ToDateTime(textBox_fechabaja.Text)).ToString("yyyy-MM-dd");
                    if (EntidadComunero(id_entidad) != null) {
                        sql = "UPDATE com_asociacion SET IdComunero = " + EntidadComunero(id_entidad) + ", IdTipoAsoc = " + comboBox_tipoasociacion.SelectedValue.ToString() + ", Participacion = " + participacion + ", FechaAlta= '" + fechaAlta + "', FechaBaja= '" + fechaBaja + "', Ppal= " + ppal + " WHERE IdAsociacion =" + id_asociacion_cargado;
                        Persistencia.SentenciasSQL.InsertarGenerico(sql);
                    }
                }
                else if (textBox_fechabaja.Text.Replace("/","").Replace(" ", "") == "") { //ELIMINAR FECHA DE BAJA
                    if (EntidadComunero(id_entidad) != null)
                    {
                        sql = "UPDATE com_asociacion SET IdComunero = " + EntidadComunero(id_entidad) + ", IdTipoAsoc = " + comboBox_tipoasociacion.SelectedValue.ToString() + ", Participacion = " + participacion + ", FechaAlta= '" + fechaAlta + "', FechaBaja= NULL, Ppal= " + ppal + " WHERE IdAsociacion =" + id_asociacion_cargado;
                        Persistencia.SentenciasSQL.InsertarGenerico(sql);
                    }
                }
                else {

                    if (ppal == "-1") {
                        comprobarOtrosRepresentante(id_division);
                    }

                    sql = "UPDATE com_asociacion SET IdComunero = " + EntidadComunero(id_entidad) + ", IdTipoAsoc = " + comboBox_tipoasociacion.SelectedValue.ToString() + ", Participacion = " + participacion + ", FechaAlta= '" + fechaAlta + "', Ppal= " + ppal + " WHERE IdAsociacion =" + id_asociacion_cargado;
                    Persistencia.SentenciasSQL.InsertarGenerico(sql);
                }   
            }
            else {
                if (textBox_fechabaja.MaskFull)
                {
                    try
                    {
                        fechaBaja = (Convert.ToDateTime(textBox_fechabaja.Text)).ToString("yyyy-MM-dd");
                    }catch {
                        MessageBox.Show("Introduce una fecha de baja correcta");
                        return;
                    }

                    sql = "INSERT INTO com_asociacion(IdDivision, IdComunero , IdTipoAsoc, Participacion, FechaAlta, FechaBaja, Ppal) VALUES(" + id_division + "," + EntidadComunero(id_entidad) + "," + comboBox_tipoasociacion.SelectedValue.ToString() + "," + textBox_porcentaje.Text + ",'" + fechaAlta + "','" + fechaBaja + "'," + ppal + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sql);
                }else {

                    if (ppal == "-1"){
                        comprobarOtrosRepresentante(id_division);
                    }

                    sql = "INSERT INTO com_asociacion(IdDivision, IdComunero , IdTipoAsoc, Participacion, FechaAlta, Ppal) VALUES(" + id_division + "," + EntidadComunero(id_entidad) + "," + comboBox_tipoasociacion.SelectedValue.ToString() + "," + textBox_porcentaje.Text + ",'" + fechaAlta + "'," + ppal + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sql);
                }
            }

            form_anterior.cargarDivisiones();
            form_anterior.dataGridView_divisiones.CurrentCell = form_anterior.dataGridView_divisiones[2, indiceSel];
            form_anterior.buscar_text();
            form_anterior.cargarDetallesDivisiones();
            this.Close();
        }

        private void textBox_fechaalta_Enter(object sender, EventArgs e)
        {
            if (textBox_fechaalta.Text != "")
                textBox_fechaalta.Text = DateTime.Today.ToShortDateString();
        }

        private void comboBox_tipoasociacion_SelectionChangeCommitted(object sender, EventArgs e) {
            if (id_asociacion_cargado != 0)
            {
                if (comboBox_tipoasociacion.SelectedValue.ToString() != "1" && (fila.Rows[0]["Ppal"].ToString() == "False"))
                {
                    checkBox_representante.Enabled = false;
                    checkBox_representante.Checked = false;
                }
                else if ((fila.Rows[0]["Ppal"].ToString() == "True") && (comboBox_tipoasociacion.SelectedValue.ToString() != "1"))
                {
                    checkBox_representante.Enabled = false;
                    checkBox_representante.Checked = false;
                }
                else if ((fila.Rows[0]["Ppal"].ToString() == "False") && (comboBox_tipoasociacion.SelectedValue.ToString() == "1"))
                {
                    checkBox_representante.Enabled = true;
                    checkBox_representante.Checked = false;
                }
                else if ((fila.Rows[0]["Ppal"].ToString() == "True") && (comboBox_tipoasociacion.SelectedValue.ToString() == "1"))
                {
                    checkBox_representante.Enabled = false;
                    checkBox_representante.Checked = true;
                }
                else
                {
                    checkBox_representante.Enabled = false;
                }
            }else {
                if (comboBox_tipoasociacion.SelectedValue.ToString() != "1")
                {
                    checkBox_representante.Enabled = false;
                    checkBox_representante.Checked = false;
                }
                else {
                    checkBox_representante.Enabled = false;
                    checkBox_representante.Checked = false;
                }
            }
        }

        private void checkBox_representante_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox_fechabaja.MaskFull) {
                MessageBox.Show("No puede tener fecha de baja un representante");
                checkBox_representante.Enabled = false;
            }
        }

        private void comprobarOtrosRepresentante(int id_division) {

                    String sql_cambiar = "UPDATE com_asociacion SET com_asociacion.Ppal = 0 WHERE com_asociacion.IdDivision = " + id_division.ToString() + ";";
                    Persistencia.SentenciasSQL.InsertarGenerico(sql_cambiar);
        }

        private void textBox_Comunero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Space) {
                Comuneros nueva = new Comuneros(this, this.Name, id_comunidad_cargado1);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
        }
        public void recibirComunero(String id_comunero)
        {
            id_entidad = id_comunero;
            String nombre = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IdEntidad = " + id_comunero)).Rows[0][0].ToString();
            textBox_Comunero.Text = nombre;
        }
    }
}