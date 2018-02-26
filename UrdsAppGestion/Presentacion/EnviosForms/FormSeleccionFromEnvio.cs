using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.EnviosForms
{
    public partial class FormSeleccionFromEnvio : Form
    {
        PanelControl form_anterior;

        public FormSeleccionFromEnvio(PanelControl form_anterior)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
        }

        private void FormSeleccionFromEnvio_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_anterior.recibirFrom(comboBox1.SelectedItem.ToString());
            this.Close();
        }
    }
}
