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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    public partial class FormImprimirMovimientos : Form
    {
        String idComunidad;
        String idEntidad;
        String nombreComunero;
        public FormImprimirMovimientos(String nombreComunero, String idComunidad, String idEntidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idEntidad = idEntidad;
            this.nombreComunero = nombreComunero;
        }

        private void ButtonImprimir_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxini != null && maskedTextBoxfin != null)
            {
                ComunerosForms.Informes.VistaInformeMovimientos nueva = new ComunerosForms.Informes.VistaInformeMovimientos(nombreComunero, idComunidad, idEntidad, maskedTextBoxini.Text.ToString(), maskedTextBoxfin.Text.ToString());
                nueva.Show();
                this.Close();
            }
        }

        private void maskedTextBoxini_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBoxini.Text, sPattern))
            {
                maskedTextBoxini.Text = maskedTextBoxini.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBoxini.Text, sPattern1))
            {
                maskedTextBoxfin.SelectAll();
            }
            else
            {
                maskedTextBoxini.Focus();
                maskedTextBoxini.SelectAll();
            }
        }

        private void maskedTextBoxfin_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBoxfin.Text, sPattern))
            {
                maskedTextBoxfin.Text = maskedTextBoxfin.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBoxfin.Text, sPattern1))
            {
                ButtonImprimir.Focus();
            }
            else
            {
                maskedTextBoxfin.Focus();
                maskedTextBoxfin.SelectAll();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
