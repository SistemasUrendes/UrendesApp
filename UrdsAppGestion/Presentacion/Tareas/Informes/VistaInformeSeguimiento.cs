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
        public VistaInformeSeguimiento(String idEntidad,String nombreComunidad,DataTable tabla,String Fini1,String Fini2,String FFin1,String FFin2,String Acuerdo,String Importante,String Proxima,  String Seguro)
        {
            InitializeComponent();
            this.idEntidad = idEntidad;
            this.tabla = tabla;
            //String comm1 = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tipostareas.TipoTarea, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni,  DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin, exp_tareas.AcuerdoJunta, exp_tareas.Importante, exp_tareas.ProximaJunta, (SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea=exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado, exp_tareas.Seguro FROM exp_tareas INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE((exp_tareas.IdEntidad) = " + idEntidad + ")";
            

            //bindingSource1.DataSource = null;
            //tabla = Persistencia.SentenciasSQL.select(comm1);

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
        /*
        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            String fechaInicio1 = maskedTextBox_FIni1.Text;
            String fechaInicio2 = maskedTextBox_FIni2.Text;
            String fechaFin1 = maskedTextBox_FFin1.Text;
            String fechaFin2 = maskedTextBox_FFin2.Text;
            String fechaInicio = "";
            String fechaFin = "";
            Boolean AcuerdoJunta = checkBoxAcuerdoJunta.Checked;
            Boolean Importante = checkBoxImportante.Checked;
            Boolean ProximaJunta = checkBoxProximaJunta.Checked;
            Boolean Seguro = checkBoxSeguro.Checked;
            String fechaFin1Conv;
            String fechaFin2Conv;
            String fechaInicio1Conv;
            String fechaInicio2Conv;

            if (fechaInicio1 != "  /  /" && fechaInicio2 != "  /  /" && fechaFin1 != "  /  /" && fechaFin2 != "  /  /")
            {
                try
                {
                    fechaFin1Conv = (Convert.ToDateTime(maskedTextBox_FFin1.Text)).ToString("yyyy-MM-dd");
                    fechaFin2Conv = (Convert.ToDateTime(maskedTextBox_FFin2.Text)).ToString("yyyy-MM-dd");
                    fechaInicio1Conv = (Convert.ToDateTime(maskedTextBox_FIni1.Text)).ToString("yyyy-MM-dd");
                    fechaInicio2Conv = (Convert.ToDateTime(maskedTextBox_FIni2.Text)).ToString("yyyy-MM-dd");
                }
                catch
                {
                    MessageBox.Show("Comprueba la fecha");
                    return;
                }
                fechaFin = "F.Fin " + fechaFin1 + " a " + fechaFin2;
                fechaInicio = "F.Inicio " + fechaInicio1 + " a " + fechaInicio2;

                String comm1 = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tipostareas.TipoTarea, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni,  DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin, exp_tareas.AcuerdoJunta, exp_tareas.Importante, exp_tareas.ProximaJunta, (SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea=exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado, exp_tareas.Seguro FROM exp_tareas INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE((exp_tareas.IdEntidad) = " + idEntidad + ") AND ((exp_tareas.FFin) >= '" + fechaFin1Conv + "' And(exp_tareas.FFin) <= '" + fechaFin2Conv + "') AND  ((exp_tareas.FIni) >= '" + fechaInicio1Conv + "' And(exp_tareas.FIni) <= '" + fechaInicio2Conv + "')";

                bindingSource1.DataSource = null;
                tabla = Persistencia.SentenciasSQL.select(comm1);
                bindingSource1.DataSource = tabla;
                this.reportViewer1.RefreshReport();
            }
            else if (fechaFin1 != "  /  /" && fechaFin2 != "  /  /")
            {
                try
                {
                    fechaFin1Conv = (Convert.ToDateTime(maskedTextBox_FFin1.Text)).ToString("yyyy-MM-dd");
                    fechaFin2Conv = (Convert.ToDateTime(maskedTextBox_FFin2.Text)).ToString("yyyy-MM-dd");
                }
                catch
                {
                    MessageBox.Show("Comprueba la fecha");
                    return;
                }
                fechaFin = "F.Fin" + fechaFin1 + " a " + fechaFin2;
                String comm1 = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tipostareas.TipoTarea, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni,  DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin, exp_tareas.AcuerdoJunta, exp_tareas.Importante, exp_tareas.ProximaJunta, (SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea=exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado, exp_tareas.Seguro FROM exp_tareas INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE((exp_tareas.IdEntidad) = " + idEntidad + ") AND ((exp_tareas.FFin) >= '" + fechaFin1Conv + "' And(exp_tareas.FFin) <= '" + fechaFin2Conv + "')";

                bindingSource1.DataSource = null;
                tabla = Persistencia.SentenciasSQL.select(comm1);
                bindingSource1.DataSource = tabla;
                this.reportViewer1.RefreshReport();
            }
            else if (fechaInicio1 != "  /  /" && fechaInicio2 != "  /  /")
            {
                try
                {
                    fechaInicio1Conv = (Convert.ToDateTime(maskedTextBox_FIni1.Text)).ToString("yyyy-MM-dd");
                    fechaInicio2Conv = (Convert.ToDateTime(maskedTextBox_FIni2.Text)).ToString("yyyy-MM-dd");
                }
                catch
                {
                    MessageBox.Show("Comprueba la fecha");
                    return;
                }
                fechaInicio = "F.Inicio " + fechaInicio1 + " a " + fechaInicio2;
                String comm1 = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tipostareas.TipoTarea, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni,  DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin, exp_tareas.AcuerdoJunta, exp_tareas.Importante, exp_tareas.ProximaJunta, (SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea=exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado, exp_tareas.Seguro FROM exp_tareas INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE((exp_tareas.IdEntidad) = " + idEntidad + ") AND ((exp_tareas.FIni) >= '" + fechaInicio1Conv + "' And(exp_tareas.FIni) <= '" + fechaInicio2Conv + "')";

                bindingSource1.DataSource = null;
                tabla = Persistencia.SentenciasSQL.select(comm1);
                bindingSource1.DataSource = tabla;
                this.reportViewer1.RefreshReport();
            }
            else
            {
                //ABIERTAS
                if (comboBoxEstado.SelectedIndex == 1)
                {
                    String comm1 = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tipostareas.TipoTarea, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni,  DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin, exp_tareas.AcuerdoJunta, exp_tareas.Importante, exp_tareas.ProximaJunta, (SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea=exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado, exp_tareas.Seguro FROM exp_tareas INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE((exp_tareas.IdEntidad) = " + idEntidad + ") AND (exp_tareas.FFin) Is Null";
                    fechaInicio = "Tareas Abiertas";
                    bindingSource1.DataSource = null;
                    tabla = Persistencia.SentenciasSQL.select(comm1);
                    bindingSource1.DataSource = tabla;
                    this.reportViewer1.RefreshReport();

                }
                //CERRADAS
                else if (comboBoxEstado.SelectedIndex == 2)
                {
                    String comm1 = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tipostareas.TipoTarea, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni,  DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin, exp_tareas.AcuerdoJunta, exp_tareas.Importante, exp_tareas.ProximaJunta, (SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea=exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado, exp_tareas.Seguro FROM exp_tareas INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE((exp_tareas.IdEntidad) = " + idEntidad + ") AND (exp_tareas.FFin) Is Not Null";
                    fechaInicio = "Tareas Cerradas";
                    bindingSource1.DataSource = null;
                    tabla = Persistencia.SentenciasSQL.select(comm1);
                    bindingSource1.DataSource = tabla;
                    this.reportViewer1.RefreshReport();

                }
                //TODAS
                else
                {
                    String comm1 = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción, exp_tipostareas.TipoTarea, DATE_FORMAT(Coalesce(exp_tareas.FIni,'ok'),'%d/%m/%Y') AS FIni,  DATE_FORMAT(Coalesce(exp_tareas.FFin,'ok'),'%d/%m/%Y') AS FFin, exp_tareas.AcuerdoJunta, exp_tareas.Importante, exp_tareas.ProximaJunta, (SELECT exp_tipogestion.Descripcion FROM exp_gestiones LEFT JOIN exp_tipogestion ON exp_gestiones.IdTipoGestion = exp_tipogestion.IdTipoGestion WHERE exp_gestiones.IdTarea=exp_tareas.IdTarea ORDER BY exp_gestiones.FIni DESC LIMIT 1 ) AS Estado, exp_tareas.Seguro FROM exp_tareas INNER JOIN exp_tipostareas ON exp_tareas.IdTipoTarea = exp_tipostareas.IdTipoTarea WHERE((exp_tareas.IdEntidad) = " + idEntidad + ")";
                    bindingSource1.DataSource = null;
                    tabla = Persistencia.SentenciasSQL.select(comm1);
                    bindingSource1.DataSource = tabla;
                    this.reportViewer1.RefreshReport();
                }
            }
            
            filtro = tabla;
            bindingSource1.DataSource = tabla;
            String cadenaFiltro = "";
            if (AcuerdoJunta == true)
            {
                cadenaFiltro = "AcuerdoJunta <> 0";
                bindingSource1.DataSource = filtro;
            }
            if (Importante == true)
            {

                if (AcuerdoJunta == true)
                {
                    cadenaFiltro += " AND ";
                }
                cadenaFiltro += "Importante <> 0";
            }
            if (ProximaJunta == true)
            {
                if (AcuerdoJunta == true || Importante == true)
                {
                    cadenaFiltro += " AND ";
                }
                cadenaFiltro += "ProximaJunta <> 0";
            }
            if (Seguro == true)
            {
                if (AcuerdoJunta == true || Importante == true || ProximaJunta == true)
                {
                    cadenaFiltro += " AND ";
                }
                cadenaFiltro += "Seguro <> 0";
            }
            filtro.DefaultView.RowFilter = cadenaFiltro;
            bindingSource1.DataSource = filtro;

            ReportParameter parametroini = new ReportParameter("fechaini", fechaInicio);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametroini });

            ReportParameter parametrofin = new ReportParameter("fechafin", fechaFin);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametrofin });

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
        */
    }
}
