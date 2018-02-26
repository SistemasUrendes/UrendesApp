using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    public partial class FormCrearCuentaComunidad : Form
    {
        String id_comunidad_cargado;
        FormAccesoTesoreria form_anterior;
        String entidad_nueva = "0";

        public FormCrearCuentaComunidad(FormAccesoTesoreria form_anterior, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkBox_ajuste_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ajuste.Checked)
            {
                checkBox_compesacion.Checked = false;
                textBox_num_cuenta.Enabled = false;
                textBox_entidad_bancaria.Enabled = false;
            }
        }
        private void checkBox_compesacion_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_compesacion.Checked)
            {
                checkBox_ajuste.Checked = false;
                textBox_num_cuenta.Enabled = false;
                textBox_entidad_bancaria.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tipoCuenta = "Normal";

            if (checkBox_compesacion.Checked)
                tipoCuenta = "Compesacion";
            if (checkBox_ajuste.Checked)
                tipoCuenta = "Ajuste";

            if (tipoCuenta == "Normal") {
                if (checkBox_ppal.Checked) {
                    //COMPRUEBO QUE NO EXISTA OTRA PRINCIPAL
                    DataTable sqlCuentaPrincipal = Persistencia.SentenciasSQL.select("SELECT IdCuenta FROM com_cuentas WHERE IdComunidad = " + id_comunidad_cargado + " AND Ppal = -1");
                    if (sqlCuentaPrincipal.Rows.Count > 0) {
                        MessageBox.Show("Ya existe una cuenta principal.");
                        return;
                    }else {
                        String sqlCuentaPrincipalAceptada = "INSERT INTO com_cuentas (IdComunidad, IdEntidad, Descripcion, NumCuenta, Ppal) VALUES(" + id_comunidad_cargado + "," + entidad_nueva + ",'" + textBox_descripcion.Text + "','" + textBox_num_cuenta.Text + "',-1)";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlCuentaPrincipalAceptada);
                    }
                }else {
                    String sqlCuentaAceptada = "INSERT INTO com_cuentas (IdComunidad, IdEntidad, Descripcion, NumCuenta, Ppal) VALUES(" + id_comunidad_cargado + "," + entidad_nueva + ",'" + textBox_descripcion.Text + "','" + textBox_num_cuenta.Text + "',0)";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlCuentaAceptada);
                }
            } else if (tipoCuenta == "Compesacion") {
                    //COMPRUEBO QUE NO EXISTA OTRA COMPESACIONES
                    DataTable sqlCuentaPrincipal = Persistencia.SentenciasSQL.select("SELECT IdCuenta FROM com_cuentas WHERE IdComunidad = " + id_comunidad_cargado + " AND C = -1");
                    if (sqlCuentaPrincipal.Rows.Count > 0) {
                        MessageBox.Show("Ya existe una cuenta Compesaciones.");
                        return;
                    }else {
                    if (entidad_nueva == "0") { 
                        entidad_nueva = (Persistencia.SentenciasSQL.select("SELECT IdEntidad FROM com_comunidades WHERE IdComunidad = " + id_comunidad_cargado)).Rows[0][0].ToString();
                    }
                        String sqlCuentaPrincipalAceptada = "INSERT INTO com_cuentas (IdComunidad, IdEntidad, Descripcion, NumCuenta, C) VALUES(" + id_comunidad_cargado + "," + entidad_nueva + ",'" + textBox_descripcion.Text + "','00000000000000000000',-1)";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlCuentaPrincipalAceptada);
                    }
            }else if (tipoCuenta == "Ajuste")
            {
                //COMPRUEBO QUE NO EXISTA OTRA AJUSTE
                DataTable sqlCuentaPrincipal = Persistencia.SentenciasSQL.select("SELECT IdCuenta FROM com_cuentas WHERE IdComunidad = " + id_comunidad_cargado + " AND A = -1");
                if (sqlCuentaPrincipal.Rows.Count > 0)
                {
                    MessageBox.Show("Ya existe una cuenta Ajuste.");
                    return;
                }
                else
                {
                    if (entidad_nueva == "0")
                    {
                        entidad_nueva = (Persistencia.SentenciasSQL.select("SELECT IdEntidad FROM com_comunidades WHERE IdComunidad = " + id_comunidad_cargado)).Rows[0][0].ToString();
                    }
                    String sqlCuentaPrincipalAceptada = "INSERT INTO com_cuentas (IdComunidad, IdEntidad, Descripcion, NumCuenta, A) VALUES(" + id_comunidad_cargado + "," + entidad_nueva + ",'" + textBox_descripcion.Text + "','00000000000000000000',-1)";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlCuentaPrincipalAceptada);
                }
            }

            form_anterior.cargarDatagrid();
            this.Close();
        }

        private void textBox_entidad_bancaria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Space) {
                Entidades nueva = new Entidades(this, this.Name);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar_nombre.Select();
                nueva.dataGridView1.TabIndex = 2;
                nueva.textBox_buscar_nombre.TabIndex = 1;
                nueva.Show();
            }
        }
        public void recibirEntidad(String id_entidad, String nombreEntidad)
        {
            textBox_entidad_bancaria.Text = nombreEntidad;
            entidad_nueva = id_entidad;
        }

        private void FormCrearCuentaComunidad_Load(object sender, EventArgs e)
        {
            textBox_entidad_bancaria.SelectAll();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ppal.Checked)
            {
                checkBox_compesacion.Checked = false;
                checkBox_ajuste.Checked = false;
                checkBox_compesacion.Enabled = false;
                checkBox_ajuste.Enabled = false;
            }else {
                checkBox_compesacion.Enabled = true;
                checkBox_ajuste.Enabled = true;
            }
        }
    }
}
