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
    public partial class FormActualizarFechaCierre : Form
    {
        Tesoreria form_anterior;
        String id_cuenta;
        public FormActualizarFechaCierre(Tesoreria form_anterior, String id_cuenta)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_cuenta = id_cuenta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fecha = (Convert.ToDateTime(maskedTextBox1.Text)).ToString("yyyy-MM-dd");
            String sqlCerrar = "UPDATE com_cuentas SET FCierre='" + fecha + "' WHERE IdCuenta  = " + id_cuenta;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlCerrar);
            form_anterior.cargarDatagrid();
            this.Close();
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBox1.Text, sPattern))
            {
                maskedTextBox1.Text = maskedTextBox1.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBox1.Text, sPattern1))
            {
                button1.Select();
            }
            else
            {
                maskedTextBox1.Focus();
                maskedTextBox1.Select();
            }
        }
    }
}
