using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    public partial class FormAccesoOperacionesTesoreria : Form
    {
        String id_comunidad_cargado;
        String id_cuenta_cargado;
        String tipo_operacion;
        String id_entidad_nuevo;

        public FormAccesoOperacionesTesoreria(String id_comunidad_cargado, String id_cuenta_cargado, String tipo_operacion)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_cuenta_cargado = id_cuenta_cargado;
            this.tipo_operacion = tipo_operacion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id_entidad_nuevo != null)
            {
                FormOperacionesTesoreria nueva = new FormOperacionesTesoreria(id_comunidad_cargado, id_cuenta_cargado, tipo_operacion, id_entidad_nuevo, maskedTextBox_fecha.Text, Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text));
                nueva.Show();
                this.Close();
            }else {
                MessageBox.Show("Indica una Entidad");
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAccesoOperacionesTesoreria_Load(object sender, EventArgs e)
        {
            cargar_datagrid();
        }
        private void cargar_datagrid() {
            textBox_cuenta.Text = id_cuenta_cargado;
            textBox_nombre_cuenta.Text = (Persistencia.SentenciasSQL.select("SELECT Descripcion FROM com_cuentas WHERE IdCuenta = " + id_cuenta_cargado)).Rows[0][0].ToString();
            textBox_tipo_operacion.Text = tipo_operacion;
            textBox_entidad.Text = "Pulse espacio o doble click";
            if (tipo_operacion == "Entrada a Proveedor") {
                label6.Visible = true;
            }
        }

        private void textBox_entidad_DoubleClick(object sender, EventArgs e)
        {
            if (tipo_operacion == "Entrada a Proveedor")
            {
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
            else
            {
                Comuneros nueva = new Comuneros(this, this.Name, id_comunidad_cargado);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar.Select();
                nueva.Show();
            }
        }
        public void recibirEntidad(String id_entidad, String nombreEntidad)
        {
            id_entidad_nuevo = id_entidad;
            textBox_entidad.Text = nombreEntidad;
        }

        private void textBox_entidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.E || e.KeyChar == 'e') {
                Entidades nueva = new Entidades(this, this.Name);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar_nombre.Select();
                nueva.dataGridView1.TabIndex = 2;
                nueva.textBox_buscar_nombre.TabIndex = 1;
                nueva.Show();
            }else if (e.KeyChar == (Char)Keys.Space)
            {
                if (tipo_operacion == "Entrada a Proveedor")
                {
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
                else
                {
                    Comuneros nueva = new Comuneros(this, this.Name, id_comunidad_cargado);
                    nueva.ControlBox = true;
                    nueva.TopMost = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    nueva.textBox_buscar.Select();
                    nueva.Show();
                }
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            Double importe;

            if (!Double.TryParse(textBox_importe.Text,out importe)) {
                MessageBox.Show("El importe no es un número.Revisalo.");
                textBox_importe.Select();
            }
        }

        private void maskedTextBox_fecha_Validated(object sender, EventArgs e)
        {
            String fechaCierre = (Persistencia.SentenciasSQL.select("SELECT FCierre FROM com_cuentas WHERE IdCuenta = " + id_cuenta_cargado)).Rows[0][0].ToString();

            if (maskedTextBox_fecha.Text == "  /  /" || maskedTextBox_fecha.Text == null)
            {
                String fecha = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("dd-MM-yyyy");
                maskedTextBox_fecha.Text = fecha;
            }

            if (fechaCierre != "" || fechaCierre != null)
            {
                if (Convert.ToDateTime(maskedTextBox_fecha.Text) < Convert.ToDateTime(fechaCierre))
                {
                    MessageBox.Show("El banco esta cerrado a esa fecha. Cambia la fecha");
                    maskedTextBox_fecha.Focus();
                    maskedTextBox_fecha.Select();
                    return;
                }
            }
        }

        private void maskedTextBox_fecha_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBox_fecha.Text, sPattern))
            {
                maskedTextBox_fecha.Text = maskedTextBox_fecha.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBox_fecha.Text, sPattern1))
            {
                textBox_importe.Select();
            }
            else
            {
                maskedTextBox_fecha.Focus();
                maskedTextBox_fecha.Select();
            }
        }
    }
}
