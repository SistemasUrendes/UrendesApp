using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.Impuestos
{
    public partial class FormImpuestoDetalle : Form
    {
        String idEntidad;
        DataTable datos;

        public FormImpuestoDetalle(String idEntidad, DataTable datos)
        {
            InitializeComponent();
        }
    }
}
