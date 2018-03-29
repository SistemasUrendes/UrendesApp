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
        public VistaInformeSeguimiento(String idEntidad,String nombreComunidad)
        {
            InitializeComponent();

            String comm1 = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tipostareas.TipoTarea, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni, DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin FROM exp_tareas INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tareas.IdEntidad) = " + idEntidad + ") AND((exp_tareas.Importante) = -1)) ORDER BY exp_tareas.FIni";
            
            bindingSource1.DataSource = null;
            bindingSource1.DataSource = Persistencia.SentenciasSQL.select(comm1);

            ReportParameter parametro = new ReportParameter("nombreComunidad", nombreComunidad);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

            this.reportViewer1.RefreshReport();

        }

        private void VistaInformeSeguimiento_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
