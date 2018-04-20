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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes
{
    public partial class FormRangoFechasCuotasEmitidas : Form
    {
        String idDivision;
        String idComunidad;
        String nombreDivision;

        public FormRangoFechasCuotasEmitidas(String idDivision,String idComunidad, String nombreDivision)
        {
            InitializeComponent();
            this.idDivision = idDivision;
            this.idComunidad = idComunidad;
            this.nombreDivision = nombreDivision;
            this.Text = "Cuotas Emitidas [ " + nombreDivision + " ]";
        }

        private void maskedTextBox_fini_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBox_fini.Text, sPattern))
            {
                maskedTextBox_fini.Text = maskedTextBox_fini.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBox_fini.Text, sPattern1))
            {
                maskedTextBox_ffin.SelectAll();
            }
        }

        private void maskedTextBox_ffin_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBox_ffin.Text, sPattern))
            {
                maskedTextBox_ffin.Text = maskedTextBox_ffin.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBox_ffin.Text, sPattern1))
            {
                button_ver.Select();
            }
        }

        private void button_ver_Click(object sender, EventArgs e)
        {
            FormVerInformeDivisionesCuotas nueva = new FormVerInformeDivisionesCuotas(idDivision, idComunidad.ToString(),maskedTextBox_fini.Text,maskedTextBox_ffin.Text, nombreDivision);
            nueva.Show();
            this.Close();
        }
    }
}
