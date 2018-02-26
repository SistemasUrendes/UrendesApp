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
    public partial class FormDevolucionAbonoCuota : Form
    {
        String idMovimiento;
        String idEjercicio;
        String idCuenta;
        String idEntidad;
        String Importe;
        Tesoreria form_anterior;

        public FormDevolucionAbonoCuota(Tesoreria form_anterior, String idMovimiento, String idEjercicio, String idCuenta, String idEntidad, String Importe)
        {
            InitializeComponent();
            this.idMovimiento = idMovimiento;
            this.idEjercicio = idEjercicio;
            this.idCuenta = idCuenta;
            this.idEntidad = idEntidad;
            this.Importe = Importe;
            this.form_anterior = form_anterior;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           String fecha =  (Convert.ToDateTime(maskedTextBox_fecha.Text)).ToString("yyyy-MM-dd");

            Logica.FuncionesTesoreria.EntradaAbonoRemesa(idMovimiento, idEjercicio, idCuenta, idEntidad, fecha, (Convert.ToDouble(Importe) * -1).ToString(), textBox1.Text, Login.getId());

            MessageBox.Show("Abono Ingresado");
            form_anterior.cargarDatagrid();
            this.Close();
            
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
                button1.Select();
            }
            else
            {
                maskedTextBox_fecha.Focus();
                maskedTextBox_fecha.Select();
            }
        }
    }
}
