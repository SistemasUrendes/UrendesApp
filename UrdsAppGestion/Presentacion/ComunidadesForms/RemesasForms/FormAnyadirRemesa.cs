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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.RemesasForms
{
    public partial class FormAnyadirRemesa : Form
    {
        String id_comunidad;
        FormRemesas form_anterior;
        
        public FormAnyadirRemesa(FormRemesas form_anterior, String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.form_anterior = form_anterior;
        }

        private void FormAnyadirRemesa_Load(object sender, EventArgs e)
        {
            //CARGO COMBOS
            String sqlSelectTipo = "SELECT IdTipoRemesa, Tipo FROM com_tiporemesa";
            comboBox_tipoRemesa.DataSource = Persistencia.SentenciasSQL.select(sqlSelectTipo);
            comboBox_tipoRemesa.DisplayMember = "Tipo";
            comboBox_tipoRemesa.ValueMember = "IdTipoRemesa";

            String sqlSelectCuenta = "SELECT IdCuenta, Descripcion FROM com_cuentas WHERE IdComunidad = " + id_comunidad;
            comboBox_cuenta.DataSource = Persistencia.SentenciasSQL.select(sqlSelectCuenta);
            comboBox_cuenta.DisplayMember = "Descripcion";
            comboBox_cuenta.ValueMember = "IdCuenta";
        }

        private void button_anyadir_Click(object sender, EventArgs e)
        {
            String fechaEnvio;// fechaCargo, fechaEfectiva;

            try
            {
                //QUITO DOS FECHAS Y GUARDO FEENVIO 3 VECES.
                fechaEnvio = (Convert.ToDateTime(maskedTextBox_envio.Text)).ToString("yyyy-MM-dd");
                //fechaCargo = (Convert.ToDateTime(maskedTextBox_cargo.Text)).ToString("yyyy-MM-dd");
                //fechaEfectiva = (Convert.ToDateTime(maskedTextBox_efectiva.Text)).ToString("yyyy-MM-dd");

            }catch {
                MessageBox.Show("Alguna fecha esta mal");
                return;
            }

            String sqlInsertRemesa = "INSERT INTO com_remesas (IdComunidad, IdCuenta, Remesa, IdTipoRemesa, FEnvio, FCargo, FCobro, Sufijo, IdEstado) VALUES (" + id_comunidad + "," + comboBox_cuenta.SelectedValue.ToString() + ",'" + textBox_referencia.Text + "'," + comboBox_tipoRemesa.SelectedValue.ToString() + ",'" + fechaEnvio + "','" + fechaEnvio + "','" + fechaEnvio + "','" + textBox_sufijo.Text + "',1)";

            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertRemesa);

            MessageBox.Show("Remesa Insertada");

            form_anterior.cargarDatagrid("5");
            this.Close();


        }

        private void maskedTextBox_envio_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBox_envio.Text, sPattern))
            {
                maskedTextBox_envio.Text = maskedTextBox_envio.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBox_envio.Text, sPattern1))
            {
                textBox_sufijo.Select();
            }
            else
            {
                maskedTextBox_envio.Focus();
                maskedTextBox_envio.Select();
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
