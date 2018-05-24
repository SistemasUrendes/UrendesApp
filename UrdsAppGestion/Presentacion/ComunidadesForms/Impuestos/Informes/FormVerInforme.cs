using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.Impuestos.Informes
{
    public partial class FormVerInforme : Form
    {
        DataTable datosImpuestos;

        public FormVerInforme(DataTable datosImpuestos, String NombreComunidad)
        {
            InitializeComponent();
            this.datosImpuestos = datosImpuestos;
            ImpuestosBindingSource.DataSource = datosImpuestos;

            ReportParameter parametro = new ReportParameter("ReportParameter1", NombreComunidad);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

        }

        private void FormVerInforme_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
