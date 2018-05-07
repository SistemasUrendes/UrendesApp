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
    public partial class FormImpuestos : Form
    {
        String idComunidad;

        public FormImpuestos(String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
        }
        
        public void cargarDatagrid() {
            
        }
    }
}
