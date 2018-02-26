using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    public partial class BusquedaAvanzada : Form
    {
        Divisiones form_anterior;
        public BusquedaAvanzada(Divisiones form_anterior)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
        }
    }
}
