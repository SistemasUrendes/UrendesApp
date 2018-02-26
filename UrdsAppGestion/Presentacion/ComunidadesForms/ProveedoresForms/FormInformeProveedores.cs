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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProveedoresForms
{
    public partial class FormInformeProveedores : Form
    {

        public FormInformeProveedores(DataTable datos_proveedores,String idComunidad)
        {
            InitializeComponent();

            ReportParameter[] parametros = new ReportParameter[1];

            String nombreComunidad = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Entidad FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + idComunidad + "));")).Rows[0][0].ToString();

            parametros[0] = new ReportParameter("nombreComunidad", nombreComunidad);

            ProveedoresBindingSource.DataSource = datos_proveedores;

            this.reportViewer1.LocalReport.SetParameters(parametros);
        }

        private void FormInformeProveedores_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
