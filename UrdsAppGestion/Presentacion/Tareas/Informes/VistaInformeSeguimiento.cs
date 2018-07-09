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

namespace UrdsAppGestión.Presentacion.Tareas.Informes
{
    public partial class VistaInformeSeguimiento : Form
    {
        String idEntidad;
        DataTable tabla;
        public VistaInformeSeguimiento(String idEntidad,String nombreComunidad,DataTable tabla,String Fini1,String Fini2,String FFin1,String FFin2,String Acuerdo,String Importante,String Proxima,  String Seguro)
        {
            InitializeComponent();
            this.idEntidad = idEntidad;
            this.tabla = tabla;
            bindingSource1.DataSource = tabla;
            updateParametros(nombreComunidad,Fini1,Fini2,FFin1,FFin2,Acuerdo,Importante,Proxima,Seguro);
            
            this.reportViewer1.RefreshReport();

        }

        private void VistaInformeSeguimiento_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void updateParametros(String nombreComunidad,String Fini1, String Fini2, String FFin1, String FFin2, String Acuerdo, String Importante, String Proxima, String Seguro)
        {

            ReportParameter parametro = new ReportParameter("nombreComunidad", nombreComunidad);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });
            
            ReportParameter parametro1 = new ReportParameter("ffechaini1", Fini1);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro1 });

            if (Fini2 == "") Fini2 = DateTime.Now.ToShortDateString();
            ReportParameter parametro2 = new ReportParameter("ffechaini2", Fini2);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro2 });
            
            ReportParameter parametro3 = new ReportParameter("ffechafin1", FFin1);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro3 });

            ReportParameter parametro4 = new ReportParameter("ffechafin2", FFin2);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro4 });
            
            ReportParameter parametro5 = new ReportParameter("facuerdoJunta", Acuerdo);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro5 });

            ReportParameter parametro6 = new ReportParameter("fimportante", Importante);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro6 });

            ReportParameter parametro7 = new ReportParameter("fproximaJunta", Proxima);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro7 });

            ReportParameter parametro8 = new ReportParameter("fseguro", Seguro);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro8 });
            
        }
    }
}
