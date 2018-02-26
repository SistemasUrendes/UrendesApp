using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.BloquesForms
{
    public partial class CambiarSubcuota : Form
    {
        String subcuota;
        FormBloquesDetalles form_anterior;

        public CambiarSubcuota(FormBloquesDetalles form_anterior, String subcuota)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.subcuota = subcuota;
            textBox1.Text = subcuota;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String valor = textBox1.Text;
            form_anterior.recogerValorSubcuota(valor);
            this.Close();
        }
    }
}
