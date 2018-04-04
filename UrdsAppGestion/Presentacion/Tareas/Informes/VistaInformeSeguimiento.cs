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
        DataTable filtro;
        public VistaInformeSeguimiento(String idEntidad,String nombreComunidad)
        {
            InitializeComponent();
            this.idEntidad = idEntidad;
            //String comm1 = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tipostareas.TipoTarea, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni, DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin FROM exp_tareas INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE(((exp_tareas.IdEntidad) = " + idEntidad + ") AND((exp_tareas.Importante) = -1)) ORDER BY exp_tareas.FIni";

            String comm1 = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tipostareas.TipoTarea, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni,  DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin, exp_tareas.AcuerdoJunta, exp_tareas.Importante, exp_tareas.ProximaJunta, exp_tareas.Seguro FROM exp_tareas INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE((exp_tareas.IdEntidad) = " + idEntidad + ")";
            
            bindingSource1.DataSource = null;
            tabla = Persistencia.SentenciasSQL.select(comm1);
            bindingSource1.DataSource = tabla;

            ReportParameter parametro = new ReportParameter("nombreComunidad", nombreComunidad);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });
            
            ReportParameter parametro2 = new ReportParameter("fecha", "Sin filtro fecha");
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro2 });

            this.reportViewer1.RefreshReport();

        }

        private void VistaInformeSeguimiento_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        
        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            String fechaInicio = maskedTextBox_inicio.Text;
            String fechaFin = maskedTextBox_fin.Text;
            String fecha = "Sin filtro de fecha";
            Boolean AcuerdoJunta = checkBoxAcuerdoJunta.Checked;
            Boolean Importante = checkBoxImportante.Checked;
            Boolean ProximaJunta = checkBoxProximaJunta.Checked;
            Boolean Seguro = checkBoxSeguro.Checked;
            String filtroBusqueda = "";
            
            if (fechaInicio != "  /  /" && fechaFin != "  /  /")
            {
                String fechaInicioConv;
                String fechaFinConv;
                try
                {
                    fechaInicioConv = (Convert.ToDateTime(maskedTextBox_inicio.Text)).ToString("yyyy-MM-dd");
                    fechaFinConv = (Convert.ToDateTime(maskedTextBox_fin.Text)).ToString("yyyy-MM-dd");

                }
                catch
                {
                    MessageBox.Show("Comprueba la fecha");
                    return;
                }
                fecha = "Entre " + fechaInicio + " y " + fechaFin;
                String comm1 = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tipostareas.TipoTarea, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni,  DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin, exp_tareas.AcuerdoJunta, exp_tareas.Importante, exp_tareas.ProximaJunta, exp_tareas.Seguro FROM exp_tareas INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE((exp_tareas.IdEntidad) = " + idEntidad + ") AND ((exp_tareas.FIni) >= '" + fechaInicioConv + "' And(exp_tareas.FIni) <= '" + fechaFinConv + "') AND((exp_tareas.FFin)Is Null And((exp_tareas.FFin) <= '" + fechaFinConv + "' Or(exp_tareas.FFin) Is Null))";

                bindingSource1.DataSource = null;
                tabla = Persistencia.SentenciasSQL.select(comm1);
                bindingSource1.DataSource = tabla;
                this.reportViewer1.RefreshReport();

            }
            if (fechaInicio == "  /  /" || fechaFin == "  /  /" )
            {
                if (AcuerdoJunta == true || Importante == true || ProximaJunta == true || Seguro == true) filtroBusqueda += "Filtro ";
            }
            filtro = tabla;
            bindingSource1.DataSource = tabla;
            String cadenaFiltro = "";
            if (AcuerdoJunta == true || Importante == true || ProximaJunta == true || Seguro == true) filtroBusqueda += "con ";
            if (AcuerdoJunta == true)
            {
                filtroBusqueda += "Acuerdo Junta";
                cadenaFiltro = "AcuerdoJunta <> 0";
                bindingSource1.DataSource = filtro;
            }
            if (Importante == true)
            {

                if (AcuerdoJunta == true)
                {
                    cadenaFiltro += " AND ";
                    filtroBusqueda += " y ";
                }
                filtroBusqueda += "Seguimiento"; 
                cadenaFiltro += "Importante <> 0";
            }
            if (ProximaJunta == true)
            {
                if (AcuerdoJunta == true || Importante == true)
                {
                    cadenaFiltro += " AND ";
                    filtroBusqueda += " y ";
                }
                filtroBusqueda += "Próxima Junta";
                cadenaFiltro += "ProximaJunta <> 0";
            }
            if (Seguro == true)
            {
                if (AcuerdoJunta == true || Importante == true || ProximaJunta == true)
                {
                    filtroBusqueda += " y ";
                    cadenaFiltro += " AND ";
                }
                filtroBusqueda += "Seguro";
                cadenaFiltro += "Seguro <> 0";
            }
            filtro.DefaultView.RowFilter = cadenaFiltro;
            bindingSource1.DataSource = filtro;


            ReportParameter parametro = new ReportParameter("fecha", fecha);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

            ReportParameter parametro1 = new ReportParameter("facuerdoJunta", AcuerdoJunta.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro1 });

            ReportParameter parametro2 = new ReportParameter("fimportante", Importante.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro2 });

            ReportParameter parametro3 = new ReportParameter("fproximaJunta", ProximaJunta.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro3 });

            ReportParameter parametro4 = new ReportParameter("fseguro", Seguro.ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro4 });

            this.reportViewer1.RefreshReport();
            
        }
    }
}
