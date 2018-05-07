using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.Tareas
{
    public partial class FormTareasConfiguracion : Form
    {
        public FormTareasConfiguracion()
        {
            InitializeComponent();
        }

        private void FormTareasConfiguracion_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddGestion_Click(object sender, EventArgs e)
        {
            Tareas.FormInsertarTipoGestion nueva = new FormInsertarTipoGestion();
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

    }
}
