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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.Informes
{
    public partial class FormListadoJuntasBloque : Form
    {

        DataTable tabla;

        public FormListadoJuntasBloque(String nombreComunidad,String bloque, DataTable tabla, String comuneros, String cuota)
        {
            InitializeComponent();
            this.tabla = tabla;
            dataSetListadoJuntasBloqueBindingSource.DataSource = tabla;

            ReportParameter parametro = new ReportParameter("nombreComunidad", nombreComunidad);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

            ReportParameter parametro2 = new ReportParameter("bloque", "Bloque : " + bloque);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro2 });

            ReportParameter parametro3 = new ReportParameter("comuneros", comuneros);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro3 });

            ReportParameter parametro4 = new ReportParameter("cuota", cuota);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro4 });

        }

        private void FormListadoJuntasBloque_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

    }
}
