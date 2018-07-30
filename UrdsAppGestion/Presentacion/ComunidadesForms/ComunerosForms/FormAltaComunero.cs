using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    public partial class FormAltaComunero : Form
    {
        Comuneros form_anterior;
        String id_entidad_cargado = "0";
        String id_entidad_nuevo;
        String id_comunero_cargado = "0";
        String id_comunidad_cargado;
        int indice = 0;
        DataTable comunero;

        public FormAltaComunero(Comuneros form_anterior, String id_comunero_cargado, String id_entidad_cargado, String id_comunidad_cargado,int indice)  {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunero_cargado = id_comunero_cargado;
            this.id_entidad_cargado = id_entidad_cargado;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.indice = indice;
        }
        public FormAltaComunero(Comuneros form_anterior, String id_comunidad_cargado)  {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void FormAltaComunero_Load(object sender, EventArgs e)  {
            if (id_comunero_cargado != "0")
            {
                textBox_Entidad.Text = Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IDEntidad = " + id_entidad_cargado).Rows[0][0].ToString();
                textBox_Entidad.ReadOnly = true;

                cargarCombos(id_entidad_cargado);

                String sqlComunero = "SELECT IdComunero, IdEntidad, IdDivPpal, IdFormaPago, IdDireccion, IdCC, IdEmail, IdTipoCopia, EnvioPostal, EnvioEmail, IVA, Notas, EmailCopia FROM com_comuneros WHERE IdComunero = " + id_comunero_cargado;

                comunero = Persistencia.SentenciasSQL.select(sqlComunero);

                if (comunero.Rows[0]["IdFormaPago"].ToString() != "")
                    comboBox_FormadePago.SelectedValue = comunero.Rows[0]["IdFormaPago"].ToString();

                if (comunero.Rows[0]["IdDireccion"].ToString() != "")
                    comboBox_Direccion.SelectedValue = comunero.Rows[0]["IdDireccion"].ToString();

                if (comunero.Rows[0]["IdEmail"].ToString() != "")       
                    comboBox_Email.SelectedValue = comunero.Rows[0]["IdEmail"].ToString();

                if (comunero.Rows[0]["IdCC"].ToString() != "")
                    comboBox_cc.SelectedValue = comunero.Rows[0]["IdCC"].ToString();

                if (comunero.Rows[0]["EmailCopia"].ToString() != "")
                    textBox_copiaEmail.Text = comunero.Rows[0]["EmailCopia"].ToString();

                textBox_Notas.Text = comunero.Rows[0]["Notas"].ToString();

                if (comunero.Rows[0]["EnvioEmail"].ToString() == "True") checkBox_EMail.Checked = true;
                if (comunero.Rows[0]["EnvioPostal"].ToString() == "True") checkBox_Postal.Checked = true;
                if (comunero.Rows[0]["IVA"].ToString() == "-1") checkBox_Iva.Checked = true;
            }
            else {
                textBox_Entidad.ReadOnly = false;
            }

        }
        private void cargarCombos(String id_entidad_f) {

            String sqldirecciones = "SELECT IdEntidad, IdDireccion, Descripcion FROM ctos_detdirecent WHERE IdEntidad = " + id_entidad_f;
            comboBox_Direccion.DataSource = Persistencia.SentenciasSQL.select(sqldirecciones);
            comboBox_Direccion.DisplayMember = "Descripcion";
            comboBox_Direccion.ValueMember = "IdDireccion";

            String sqlcorreos = "SELECT IdEntidad, IdEmail, Descripcion FROM ctos_detemail WHERE IdEntidad = " + id_entidad_f;
            comboBox_Email.DataSource = Persistencia.SentenciasSQL.select(sqlcorreos);

            comboBox_Email.DisplayMember = "Descripcion";
            comboBox_Email.ValueMember = "IdEmail";

            String sqlFormasPago = "SELECT IdFormaPago, FormaPago FROM aux_formapago";
            comboBox_FormadePago.DataSource = Persistencia.SentenciasSQL.select(sqlFormasPago);
            comboBox_FormadePago.DisplayMember = "FormaPago";
            comboBox_FormadePago.ValueMember = "IdFormaPago";

            String sqlCuentas = "SELECT IdCuenta, Descripcion FROM ctos_detbancos WHERE IdEntidad =  " + id_entidad_f;
            comboBox_cc.DataSource = Persistencia.SentenciasSQL.select(sqlCuentas);
            comboBox_cc.DisplayMember = "Descripcion";
            comboBox_cc.ValueMember = "IdCuenta";
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String Envio_email = "0";
            String EnvioPostal = "0";
            String IVA = "0";
            String comboDireccion = "";
            String idCorreo = "";
            String IdCC = "";

            String sqlUpdate;
            String sqlInsertar;

            if (checkBox_EMail.Checked && comboBox_Email.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un email.");
                return;
            }

            if (textBox_copiaEmail.Text != "" && !EntidadesForms.FormCorreos.ComprobarFormatoEmail(textBox_copiaEmail.Text))
            {
                MessageBox.Show("Comprueba que el E-mail Copia es correcto");
                return;
            }

            else if (comboBox_Email.SelectedValue != null)
            {
                idCorreo = comboBox_Email.SelectedValue.ToString();             
                if (checkBox_EMail.Checked) Envio_email = "-1";
            }
            else if (!checkBox_EMail.Checked && comboBox_Email.SelectedValue == null)
            {
                idCorreo = "NULL";
            }

            if (comboBox_Direccion.SelectedValue == null) {
                comboDireccion = "NULL";
            }else {
                comboDireccion = comboBox_Direccion.SelectedValue.ToString();
            }

            if (comboBox_FormadePago.SelectedValue.ToString() == "1") {
                if (comboBox_cc.SelectedValue != null)
                    IdCC = comboBox_cc.SelectedValue.ToString();
                else
                    IdCC = "NULL";
            }
            else if (comboBox_FormadePago.SelectedValue.ToString() == "2" && comboBox_cc.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una cuenta");
                return;
            }
            else if (comboBox_FormadePago.SelectedValue.ToString() == "2" && comboBox_cc.SelectedValue != null)
            {
                IdCC = comboBox_cc.SelectedValue.ToString();
            }

            if (checkBox_Postal.Checked) EnvioPostal = "-1";
            if (checkBox_Iva.Checked) IVA = "-1";

            if (id_comunero_cargado != "0") {
                if (textBox_Notas.Text != "") {
                    sqlUpdate = "UPDATE com_comuneros SET IdFormaPago=" + comboBox_FormadePago.SelectedValue.ToString() + ", IdDireccion=" + comboDireccion + ", IdCC=" + IdCC + ", IdEmail=" + idCorreo + ", EnvioPostal =" + EnvioPostal + ", EnvioEmail=" + Envio_email + ", IVA=" + IVA + ", Notas='" + textBox_Notas.Text + "' , EmailCopia = '" + textBox_copiaEmail.Text + "' WHERE IdComunero = " + id_comunero_cargado;
                }
                else {
                    sqlUpdate = "UPDATE com_comuneros SET IdFormaPago=" + comboBox_FormadePago.SelectedValue.ToString() + ", IdDireccion=" + comboDireccion + ", IdCC=" + IdCC + ", IdEmail=" + idCorreo + ", EnvioPostal =" + EnvioPostal + ", EnvioEmail=" + Envio_email + ", IVA=" + IVA + ", Notas='', EmailCopia = '" + textBox_copiaEmail.Text + "' WHERE IdComunero = " + id_comunero_cargado;
                }
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                form_anterior.recargoFiltro();
                form_anterior.dataGridView_comuneros.Rows[indice].Selected = true;
                form_anterior.cargarDetalles();
                this.Close();
            }
            else {
                if (textBox_Notas.Text != "") {
                        sqlInsertar = "INSERT INTO com_comuneros (IdComunidad, IdEntidad, IdFormaPago, IdDireccion, IdCC, IdEmail, EnvioPostal, EnvioEmail, IVA, Notas, EmailCopia) VALUES (" + id_comunidad_cargado + "," + id_entidad_nuevo + "," + comboBox_FormadePago.SelectedValue.ToString() + "," + comboDireccion + "," + IdCC + "," + idCorreo + "," + EnvioPostal + "," + Envio_email + "," + IVA + ",'" + textBox_Notas.Text + "','" + textBox_copiaEmail.Text + "')";
                }else {

                    sqlInsertar = "INSERT INTO com_comuneros (IdComunidad, IdEntidad, IdFormaPago, IdDireccion, IdCC, IdEmail, EnvioPostal, EnvioEmail, IVA, EmailCopia) VALUES (" + id_comunidad_cargado + "," + id_entidad_nuevo + "," + comboBox_FormadePago.SelectedValue.ToString() + "," + comboBox_Direccion.SelectedValue.ToString() + "," + IdCC + "," + idCorreo + "," + EnvioPostal + "," + Envio_email + "," + IVA + ",'" + textBox_copiaEmail.Text + "')";
                }

                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertar);
                form_anterior.recargoFiltro();
                form_anterior.dataGridView_comuneros.Rows[indice].Selected = true;
                form_anterior.cargarDetalles();
                this.Close();
            }
        }
        private void textBox_Entidad_DoubleClick(object sender, EventArgs e)
        {
            Entidades nueva = new Entidades(this,this.Name);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void recibirEntidad(String id_entidad) {
            id_entidad_nuevo = id_entidad;
            String nombre = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IdEntidad = " + id_entidad)).Rows[0][0].ToString();
            textBox_Entidad.Text = nombre;
            cargarCombos(id_entidad);
        }

        private void textBox_Entidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter || e.KeyChar == (Char)Keys.Space)
            {
                Entidades nueva = new Entidades(this, this.Name);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar_nombre.Select();
                nueva.textBox_buscar_nombre.Location = new Point(nueva.textBox_buscar_nombre.Location.X, nueva.textBox_buscar_nombre.Location.Y + 60);
                nueva.label2.Location = new Point(nueva.label2.Location.X + 870, nueva.label2.Location.Y + 60);
                nueva.label3.Visible = false;
                nueva.label4.Visible = false;
                nueva.textBox_correo_buscar.Visible = false;
                nueva.textBox_telefono_buscar.Visible = false;
                nueva.dataGridView1.TabIndex = 2;
                nueva.textBox_buscar_nombre.TabIndex = 1;
                nueva.Show();
            }
        }
    }
}
