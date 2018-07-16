using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularReciboIVA
{
    public partial class FormVerInformeLiquidacionIVA : Form
    {
        public FormVerInformeLiquidacionIVA(DataTable data1)
        {
            InitializeComponent();
            DivisionLiquidacionBindingSource.DataSource = data1;
        }

        private void FormVerInformeLiquidacionIVA_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
