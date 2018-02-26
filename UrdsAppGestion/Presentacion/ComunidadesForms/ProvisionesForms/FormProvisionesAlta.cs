using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProvisionesForms
{
    public partial class FormProvisionesAlta : Form
    {
        String id_comunidad_cargado;
        String id_provision_cargado = "0";
        String id_bloque_pasado;

        FormProvisiones.FormProvisiones form_anterior;

        public FormProvisionesAlta(FormProvisiones.FormProvisiones form_anterior,String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
        }

        public FormProvisionesAlta(FormProvisiones.FormProvisiones form_anterior,String id_comunidad_cargado, String id_provision_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
            this.id_provision_cargado = id_provision_cargado;
        }

        private void FormProvisionesAlta_Load(object sender, EventArgs e)
        {
            if (id_provision_cargado != "0") {
                String sqlSelect = "SELECT Nombre, IdSubCuenta, IdBloque FROM com_provisiones WHERE IdProvision = " + id_provision_cargado;
                DataTable fila = Persistencia.SentenciasSQL.select(sqlSelect);
                textBox_NombreProvision.Text = fila.Rows[0][0].ToString();
                maskedTextBox1.Text = fila.Rows[0][1].ToString();
                id_bloque_pasado = fila.Rows[0][2].ToString(); ;

                textBox_bloques.Text = (Persistencia.SentenciasSQL.select("SELECT Descripcion FROM com_bloques WHERE IdBloque = " + fila.Rows[0][2].ToString())).Rows[0][0].ToString();

            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (id_provision_cargado != "0") {
                String sqlUpdate = "UPDATE com_provisiones SET Nombre = '" + textBox_NombreProvision.Text + "', IdSubCuenta='" + maskedTextBox1.Text + "', IdBloque=" + id_bloque_pasado+ " WHERE IdProvision = " + id_provision_cargado;

                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                form_anterior.cargarDatagrid();
                this.Close();
            }
            else {
                String sqlInsert = "INSERT INTO com_provisiones (IdComunidad, Nombre, IdSubCuenta, IdBloque, SaldoActual, SaldoAnterior) VALUES (" + id_comunidad_cargado + ",'" + textBox_NombreProvision.Text + "','" + maskedTextBox1.Text + "'," + id_bloque_pasado + ",0,0)";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                form_anterior.cargarDatagrid();
                this.Close();
            }
        }

        private void textBox_bloques_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Space) {
                BloquesForms.Bloques nueva = new BloquesForms.Bloques(this, this.Name, id_comunidad_cargado);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
        }
        public void recogerBloque(String id_bloque, String nombre_bloque)
        {
            id_bloque_pasado = id_bloque;
            textBox_bloques.Text = nombre_bloque;
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        public void recogerCuenta (String id, String descripcion) {
            maskedTextBox1.Text = id;
            textBox_NombreProvision.Text = descripcion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCuentasExistentes nueva = new FormCuentasExistentes(this,this.Name,id_comunidad_cargado);
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
    }
}
