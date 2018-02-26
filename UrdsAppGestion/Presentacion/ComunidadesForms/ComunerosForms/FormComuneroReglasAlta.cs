using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    public partial class FormComuneroReglasAlta : Form
    {
        String id_comunero = "0";
        String id_regla = "0";
        DataTable tabla_regla;
        FormComuneroReglas form_anterior;

        public FormComuneroReglasAlta(FormComuneroReglas form_anterior,String id_comunero, String id_regla) {
            InitializeComponent();
            this.id_comunero = id_comunero;
            this.id_regla = id_regla;
            this.form_anterior = form_anterior;
        }

        public FormComuneroReglasAlta(FormComuneroReglas form_anterior, String id_comunero) {
            InitializeComponent();
            this.id_comunero = id_comunero;
            this.form_anterior = form_anterior;
        }

        private void FormComuneroReglasAlta_Load(object sender, EventArgs e)  {
            cargarDatos();
        }

        public void cargarDatos () {

            String sql = "SELECT ctos_entidades.Entidad, ctos_entidades.IdEntidad FROM com_comuneros INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE (((com_comuneros.IdComunero) = " + id_comunero + " ));";
            textBox_Entidad.Text = (Persistencia.SentenciasSQL.select(sql)).Rows[0][0].ToString();
            textBox_Entidad.Enabled = false;
            
            String sqlFormasPago1 = "SELECT IdFormaPago, FormaPago FROM aux_formapago";
            comboBox_FPago.DataSource = Persistencia.SentenciasSQL.select(sqlFormasPago1);
            comboBox_FPago.DisplayMember = "FormaPago";
            comboBox_FPago.ValueMember = "IdFormaPago";

            String id_entidad = (Persistencia.SentenciasSQL.select("SELECT IdEntidad FROM com_comuneros WHERE IdComunero = " + id_comunero)).Rows[0][0].ToString();

            String sqlCuentas1 = "SELECT IdCuenta, Descripcion FROM ctos_detbancos WHERE IdEntidad =  " + id_entidad;

            comboBox_Cuenta.DataSource = Persistencia.SentenciasSQL.select(sqlCuentas1);
            comboBox_Cuenta.DisplayMember = "Descripcion";
            comboBox_Cuenta.ValueMember = "IdCuenta";

            if (id_regla != "0") {
                
                String sqlFormasPago = "SELECT IdFormaPago, FormaPago FROM aux_formapago";
                comboBox_FPago.DataSource = Persistencia.SentenciasSQL.select(sqlFormasPago);
                comboBox_FPago.DisplayMember = "FormaPago";
                comboBox_FPago.ValueMember = "IdFormaPago";

                String sqlCuentas = "SELECT IdCuenta, Descripcion FROM ctos_detbancos WHERE IdEntidad =  " + (Persistencia.SentenciasSQL.select(sql)).Rows[0][1].ToString();

                comboBox_Cuenta.DataSource = Persistencia.SentenciasSQL.select(sqlCuentas);
                comboBox_Cuenta.DisplayMember = "Descripcion";
                comboBox_Cuenta.ValueMember = "IdCuenta";


                String referencia = "SELECT IdReglaRec, RefRegla, Descripcion, IdFormaPago, IdCC, Activa FROM com_reglasrec WHERE IdReglaRec = " + id_regla;

                tabla_regla = Persistencia.SentenciasSQL.select(referencia);

                textBox_descripcion.Text = tabla_regla.Rows[0]["Descripcion"].ToString();
                textBox_Regla.Text = tabla_regla.Rows[0]["RefRegla"].ToString();

                if (tabla_regla.Rows.Count > 0) {
                    if (tabla_regla.Rows[0][3].ToString() != "")
                        comboBox_FPago.SelectedValue = tabla_regla.Rows[0]["IdFormaPago"].ToString();
                    if (tabla_regla.Rows[0][3].ToString() != "")
                        comboBox_Cuenta.SelectedValue = tabla_regla.Rows[0]["IdCC"].ToString();
                    if (tabla_regla.Rows[0]["Activa"].ToString() == "True") checkBox_Activa.Checked = true;


                }
            }
        }
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String activo = "0";
            String sqlInsertar, sqlActualizar;
            if (checkBox_Activa.Checked) activo = "-1";

            if (id_regla != "0") {

                if (textBox_descripcion.Text != "")  {
                    sqlActualizar = "UPDATE com_reglasrec SET RefRegla = '" + textBox_Regla.Text + "' , Descripcion = '" + textBox_descripcion.Text + "' , IdComunero = " + id_comunero + ", IdFormaPago = " + comboBox_FPago.SelectedValue.ToString() + ", IdCC = " + comboBox_Cuenta.SelectedValue.ToString() + " , Activa = " + activo + " WHERE IdReglaRec = "+ id_regla;
                }
                else {
                    sqlActualizar = "UPDATE com_reglasrec SET RefRegla = '" + textBox_Regla.Text + "', IdComunero = " + id_comunero + ", IdFormaPago = " + comboBox_FPago.SelectedValue.ToString() + ", IdCC = " + comboBox_Cuenta.SelectedValue.ToString() + " , Activa = " + activo + " WHERE IdReglaRec = " + id_regla;
                }

                Persistencia.SentenciasSQL.InsertarGenerico(sqlActualizar);
                form_anterior.cargarDatagrid();
                this.Close();
            }
            else {

                if (textBox_descripcion.Text != "")  {
                    sqlInsertar = "INSERT INTO com_reglasrec (RefRegla, Descripcion, IdComunero, IdFormaPago, IdCC, Activa) VALUES ('" + textBox_Regla.Text + "','" + textBox_descripcion.Text + "'," + id_comunero + ", " + comboBox_FPago.SelectedValue.ToString() + " , " + comboBox_Cuenta.SelectedValue.ToString() + "," + activo + ")";
                }else {
                    sqlInsertar = "INSERT INTO com_reglasrec (RefRegla, IdComunero, IdFormaPago, IdCC, Activa) VALUES ('" + textBox_Regla.Text + "'," + id_comunero + ", " + comboBox_FPago.SelectedValue.ToString() + " , " + comboBox_Cuenta.SelectedValue.ToString() + "," + activo + ")";
                }

                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertar);
                form_anterior.cargarDatagrid();
                this.Close();
                
            }
        }
    }
}
