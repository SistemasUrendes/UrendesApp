using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Logica;
using UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticular;

namespace UrdsAppGestión.Presentacion
{
    public partial class PanelControl : Form
    {
        int numero_procesos = 0;
        int proc1 = 0;
        int proc2 = 0;
        int proc3 = 0;
        int numero_Correos = 0;
        String from = "info@urendes.com";

        private void UpdateText1(string text) {
                dataGridView_tareas.Rows[0].Cells[2].Value = text + "%";
        }

        private void UpdateText2(string text) {
            if (dataGridView_tareas.Rows.Count == 1 )
            {
                UpdateText1(text);
            }
            else
            {
                dataGridView_tareas.Rows[1].Cells[2].Value = text + "%";
            }
        }
        private void UpdateText3(string text)
        {
            if (dataGridView_tareas.Rows.Count == 1 || numero_procesos == 1)
            {
                UpdateText1(text);
            }
            else if (dataGridView_tareas.Rows.Count == 2 || numero_procesos == 2) {
                UpdateText2(text);
            }
            else
            {
                dataGridView_tareas.Rows[2].Cells[2].Value = text + "%";
            }
        }
        public delegate void UpdateTextCallback(string text);


        public PanelControl()
        {
            InitializeComponent();
        }

        public int DimensionesPantallaAlto()
        {
            return (int)(this.Size.Height);
        }
        public int DimensionesPantallaAncho()
        {
            return (int)(this.Size.Width);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime start = DateTime.Now;
            int enviosCorrectos = 0;
            String mensajeError = "";
            e.Result = "";

            List<object> genericlist = e.Argument as List<object>;
            List<EnvioCorreo> lista_correos = (List<EnvioCorreo>)genericlist[0];

            String asunto = (String)genericlist[1];
            String cuerpo = (String)genericlist[2];
            List<String> adjuntos = (List<String>)genericlist[3];
            String id_tipoDoc = (String)genericlist[4];
            String id_Doc = (String)genericlist[5];

            if (Thread.CurrentThread.Name == null)
            Thread.CurrentThread.Name = numero_procesos.ToString();

            MessageBox.Show("Numero de Correos que se van a Enviar : " + lista_correos.Count.ToString());

            String fechaAltaLote = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd hh:mm:ss");
            String sqlLote = "INSERT INTO com_enviosLote (Fecha, Descripcion) VALUES ('" + fechaAltaLote + "','" + cuerpo.Replace("'","`") + "')";
            int num_lote = Persistencia.SentenciasSQL.InsertarGenericoID(sqlLote);
            
            //Boolean encontrado = false;

            for (int i = 0; i < lista_correos.Count; i++)  {

               //String destinatario = "sistemas@urendes.com";
               String destinatario = lista_correos[i].Correo;

                //if (destinatario != "sandrapenavinuesa@hotmail.com" && !encontrado) {
                //    continue;
                //}
                //else if (destinatario == "sandrapenavinuesa@hotmail.com") {
                //    encontrado = true;
                //    MessageBox.Show(destinatario);
                //    continue;
                //}
                //destinatario = "sistemas@urendes.com";

                //GUARDO EL CORREO POR SI FALLA MAS TARDE
                String sqlUpdate2 = "UPDATE com_enviosLote SET UltimoCorreo='" + destinatario + "' WHERE IdLote = " + num_lote;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate2);

                try  {
                    EnviarCorreo(destinatario, asunto, cuerpo, adjuntos, from);
                    //EnviarCorreo(destinatario, asunto + "-" + lista_correos[i].Correo, cuerpo, adjuntos,from);
                    enviosCorrectos++;
                }catch (Exception es){
                    mensajeError = es.Message;
                }
                

                String fechaRegistro = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd hh:mm:ss");
                String sql;

                if (id_Doc == "")
                {
                    sql = "INSERT INTO com_EnvSe (IdComunidad, TipoDocumento, IdLote, Medio, IdEntidad, IdDireccion, FechaEnvio, Descripcion) VALUES (" + lista_correos[i].IdComunidad1 + "," + id_tipoDoc + "," + num_lote + ",'Email'," + lista_correos[i].IdEntidad1 + "," + lista_correos[i].IdEmail1 + ",'" + fechaRegistro + "','" + asunto.Replace("'"," ") + "')";
                }
                else
                {
                    sql = "INSERT INTO com_EnvSe (IdComunidad, TipoDocumento, IdDocumento, IdLote, Medio, IdEntidad, IdDireccion, FechaEnvio, Descripcion) VALUES (" + lista_correos[i].IdComunidad1 + "," + id_tipoDoc + "," + id_Doc + "," + num_lote + ",'Email'," + lista_correos[i].IdEntidad1 + "," + lista_correos[i].IdEmail1 + ",'" + fechaRegistro + "','" + asunto.Replace("'", " ") + "')";
                }
                Persistencia.SentenciasSQL.InsertarGenerico(sql);

                if (i == lista_correos.Count - 1)   {
                    backgroundWorker1.ReportProgress(100, DateTime.Now);
                    if (enviosCorrectos == lista_correos.Count) {
                        String sqlUpdate = "UPDATE com_enviosLote SET Completo = 'Si', UltimoCorreo='-' WHERE IdLote = " + num_lote;
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                    }else {
                        String sqlUpdate = "UPDATE com_enviosLote SET Completo='No', Error='" + mensajeError + "' WHERE IdLote = " + num_lote;
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                    }
                }
                else
                    backgroundWorker1.ReportProgress((100 * i) / lista_correos.Count, DateTime.Now);

                if (backgroundWorker1.CancellationPending) {
                    e.Cancel = true;
                    return;
                }
            }

            TimeSpan duration = DateTime.Now - start;
            e.Result = "Duration: " + duration.TotalMilliseconds.ToString() + " ms.";
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DateTime time = Convert.ToDateTime(e.UserState);

            if (Thread.CurrentThread.Name == "1") {
                dataGridView_tareas.Invoke(new UpdateTextCallback(this.UpdateText1), new object[] { e.ProgressPercentage.ToString() });
            }
            if (Thread.CurrentThread.Name == "2") {
                dataGridView_tareas.Invoke(new UpdateTextCallback(this.UpdateText2),
                                  new object[] { e.ProgressPercentage.ToString() });
            }
            if (Thread.CurrentThread.Name == "3") {
                dataGridView_tareas.Invoke(new UpdateTextCallback(this.UpdateText3),
                                  new object[] { e.ProgressPercentage.ToString() });
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("The task has been cancelled");
            else if (e.Error != null)
                MessageBox.Show("Error. Details: " + (e.Error as Exception).ToString());
            else
            {
                MessageBox.Show("La tarea ha finalizado. " + e.Result.ToString());
                                dataGridView_tareas.Rows.RemoveAt(0);
                numero_procesos--;
            }
        }
        private void EnviarCorreo(String destinatario, String Asunto, String Cuerpo, List<String> adjuntos,String from)
        {
            //destinatario = "alex.cremeria@gmail.com";

            //Sustituir \n por <br>
            Cuerpo = Cuerpo.Replace("\n", "<br>");

            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(destinatario));
            email.Bcc.Add(new MailAddress("no-reply@envios.urendes.com"));
            email.From = new MailAddress(from);
            email.Subject = Asunto;
            String cabecera = "<!DOCTYPE html PUBLIC ' -//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html><head><meta http-equiv='Content-Type' content='text/html;UTF-8' /> </head><body style='margin: 0px; background-color: #F4F3F4; font-family: Helvetica, Arial, sans-serif; font-size:12px;' text='#444444' bgcolor='#F4F3F4' link='#21759B' alink='#21759B' vlink='#21759B' marginheight='0' topmargin='0' marginwidth='0' leftmargin='0'> <table border='0' width='100%' cellspacing='0' cellpadding='0' bgcolor='#F4F3F4'><tbody><tr><td style='padding: 15px;'><center><table width='550' cellspacing='0' cellpadding='0' align='center' bgcolor='#ffffff'><tbody><tr><td align='left'> 	<div style='border: solid 1px #d9d9d9;'><table id='header' style='line-height: 1.6; font-size: 12px; font-family: Helvetica, Arial, sans-serif; border: solid 1px #FFFFFF; color: #444;' border='0' width='100%' cellspacing='0' cellpadding='0' bgcolor='#ffffff'><tbody><tr><td style='color: #ffffff;' colspan='2' valign='bottom' height='30'>.</td></tr><tr> 	<td style='line-height: 32px; padding-left: 0px;' valign='baseline'><center><p><img class='aligncenter  wp-image-11' src='https://urendes.com/wp-content/uploads/2016/09/Logo-Urendes.png' alt='LOGO' width='220' height='47'/></p><h2><span style='color: #999999;'>  Administración de Fincas</span></h2></center></td></tr></tbody></table> 				 <table id='content' style='margin-top: 15px; margin-right: auto; margin-left: auto; color: #444; line-height: 1.6; font-size: 12px; font-family: Arial, sans-serif;' border='0' width='490' cellspacing='0' cellpadding='0' bgcolor='#ffffff'><tbody><tr><td style='border-top: solid 1px #d9d9d9;' colspan='2'><div style='padding: 15px 0;'>";

            String pie = "</div></td></tr></tbody ></table><table id = 'footer' style = 'line-height: 1.5; font-size: 12px; font-family: Arial, sans-serif; margin-right: auto; margin-left: auto;' border = '0' width = '490' cellspacing = '0' cellpadding = '0' bgcolor = '#ffffff' ><tbody><tr style ='font-size: 11px; color: #999999;' ><td style = 'border-top: solid 1px #d9d9d9;' colspan = '2'><div style ='padding-top: 15px; padding-bottom: 1px;' ><img style = 'vertical-align:middle;' src = 'https://urendes.com/wp-admin/images/date-button.gif' alt = 'Fecha' width = '13' height = '13' /> Email enviado el " + DateTime.Now + " <a href = 'https://urendes.com' >[ VISITAR WEB ]</a></div><div><img style='vertical-align: middle;' src= 'https://urendes.com/wp-admin/images/comment-grey-bubble.png' alt='Contacto' width='12' height ='12' /> Para cualquier problema, por favor contacta con <a href='mailto:sistemas@urendes.com'> sistemas@urendes.com </a></div></td></tr><tr><td style='color: #ffffff;' colspan ='2' height = '15' >.</td></tr></tbody></table></div></td></tr></tbody></table></center></td></tr></tbody></table></body></html>";

            email.Body = cabecera + Cuerpo + pie;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            for (int a = 0; a < adjuntos.Count; a++)
                if (System.IO.File.Exists(@adjuntos[a]))
                    email.Attachments.Add(new Attachment(@adjuntos[a]));


            SmtpClient smtp = new SmtpClient();
            smtp.Host = "hl316.hosteurope.es";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("admin@envios.urendes.com", "#.Urds16");

            /*SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.urendes.com";
            smtp.Port = 26;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("sistemas@urendes.com", "#.Urds16");*/

            /*SmtpClient smtp = new SmtpClient();
            smtp.Host = "cp5023.webempresa.eu";
            smtp.Port = 465;
            //smtp.EnableTls = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("sistemas@urendes.com", "#.Urds16");*/

            try
            {
                smtp.Send(email);
                numero_Correos++;
                if (numero_Correos == 10)
                {
                    Thread.Sleep(20000);
                    numero_Correos = 0;
                }

                Thread.Sleep(20000);
                email.Dispose();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                Thread.Sleep(50000);
                smtp.Send(email);
                email.Dispose();
            }
        }

        public void EjecutarEnvio(List<EnvioCorreo> direcciones,String asunto,String cuerpo, List<String> adjuntos, String descripcion,String id_tipoDoc, String id_Doc)
        {
            //ATENCIÓN
            //ESTO LO USO PARA CAMBIAR EL CORREO DE ENVIO (FROM) DE info@urendes.com a otro.
            //SE DEBE HACER GENERICO 
            String id_comunidad_Envio = (Persistencia.SentenciasSQL.select("SELECT IdComunidad FROM com_Documentos WHERE IdDocumento = " + id_Doc)).Rows[0][0].ToString();
            //34 = XFRAGIL
            if (id_comunidad_Envio == "34")  {
                EnviosForms.FormSeleccionFromEnvio nuevo = new EnviosForms.FormSeleccionFromEnvio(this);
                nuevo.Show();
            }
            else
                from = "info@urendes.com";
            /////////////////////////////////////////////////////////////////////////////////

            if (numero_procesos == 2)
                MessageBox.Show("Se ha superado el limite de tareas.Espere a que finalice alguna");
            else
            {
                if (dataGridView_tareas.Rows.Count == 0)
                {
                    proc1++;
                    string[] row = new string[] { proc1.ToString(), descripcion, "0%" };
                    dataGridView_tareas.Rows.Add(row);
                }
                else if (dataGridView_tareas.Rows.Count == 1)
                {
                    proc2 = 2;
                    string[] row = new string[] { proc2.ToString(), descripcion, "0%" };
                    dataGridView_tareas.Rows.Add(row);
                }
                else if (dataGridView_tareas.Rows.Count == 2)
                {
                    proc3 = 3;
                    string[] row = new string[] { proc3.ToString(), descripcion, "0%" };
                    dataGridView_tareas.Rows.Add(row);
                }

                List<object> arguments = new List<object>();
                arguments.Add(direcciones);
                arguments.Add(asunto);
                arguments.Add(cuerpo);
                arguments.Add(adjuntos);
                arguments.Add(id_tipoDoc);
                arguments.Add(id_Doc);

                var tarea = new BackgroundWorker()
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };

                numero_procesos++;

                tarea.DoWork += backgroundWorker1_DoWork;
                tarea.ProgressChanged += backgroundWorker1_ProgressChanged;
                tarea.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
                tarea.RunWorkerAsync(arguments);
            }
        }
        //VERSIÓN ANTIGUA PARA CREAR PDF 
        public void CrearPDFLiquidacion (DataTable PdfCrear, String idComunidad, String idLiquidacion,String Ruta, String nombreCortoLiqPasado) {
            proc1++;
            string[] row = new string[] { proc1.ToString(), "Creación PDF : " + nombreCortoLiqPasado, "0%" };
            dataGridView_tareas.Rows.Add(row);

            List<object> arguments = new List<object>();
            arguments.Add(PdfCrear);
            arguments.Add(idComunidad);
            arguments.Add(idLiquidacion);
            arguments.Add(Ruta);
            arguments.Add(nombreCortoLiqPasado);

            var tarea = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            tarea.DoWork += backgroundWorkerPdfLiq_DoWork;
            tarea.ProgressChanged += backgroundWorker1_ProgressChanged;
            tarea.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            numero_procesos++;
            tarea.RunWorkerAsync(arguments);

        }
        private void backgroundWorkerPdfLiq_DoWork(object sender, DoWorkEventArgs e)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            String anteriorEntidad = "";

            List<object> genericlist = e.Argument as List<object>;
            DataTable PdfCrear = (DataTable)genericlist[0];
            String idcomunidad = (String)genericlist[1];
            String idLiquidacion = (String)genericlist[2];
            String Ruta = (String)genericlist[3];
            String nombreCortoLiqPasado = (String)genericlist[4];

            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = numero_procesos.ToString();

            for (int a = 0; a < PdfCrear.Rows.Count; a++)
                {
                    String idEntidad = PdfCrear.Rows[a][0].ToString();
                    if (anteriorEntidad != idEntidad)
                    {
                    try
                    {
                        FormVerInformeParticular nueva = new FormVerInformeParticular(idcomunidad, idLiquidacion, idEntidad);

                        byte[] bytes = nueva.reportViewer1.LocalReport.Render(
                            "PDF", null, out mimeType, out encoding, out filenameExtension,
                            out streamids, out warnings);

                        String nombre = "L" + idLiquidacion + "-" + PdfCrear.Rows[a][0] + " " + nombreCortoLiqPasado + " " + PdfCrear.Rows[a][1] + ".pdf";
                        using (FileStream fs = new FileStream(Ruta + "/" + nombre, FileMode.Create))
                        {
                            fs.Write(bytes, 0, bytes.Length);
                            fs.Dispose();
                        }
                        nueva.Close();
                        anteriorEntidad = PdfCrear.Rows[a][0].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al crear el PDF => " + ex.Message);
                    }
                }
                backgroundWorker1.ReportProgress((100 * a) / PdfCrear.Rows.Count, DateTime.Now);
            }
            e.Result = "Creación de PDF Completada";
        }

        //VERSIÓN NUEVA PARA CREAR LIQUIDACIÓN
        public void CrearPDFLiquidacionNuevo (DataTable PdfCrear, String idComunidad, String idLiquidacion,String Ruta, String nombreCortoLiqPasado) {
            proc1++;
            string[] row = new string[] { proc1.ToString(), "Creación PDF : " + nombreCortoLiqPasado, "0%" };
            dataGridView_tareas.Rows.Add(row);

            List<object> arguments = new List<object>();
            arguments.Add(PdfCrear);
            arguments.Add(idComunidad);
            arguments.Add(idLiquidacion);
            arguments.Add(Ruta);
            arguments.Add(nombreCortoLiqPasado);

            var tarea1 = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            tarea1.DoWork += backgroundWorkerPdfLiqNueva_DoWork;
            tarea1.ProgressChanged += backgroundWorker1_ProgressChanged;
            tarea1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            numero_procesos++;
            tarea1.RunWorkerAsync(arguments);

        }
        private void backgroundWorkerPdfLiqNueva_DoWork(object sender, DoWorkEventArgs e)
        {

            List<object> genericlist = e.Argument as List<object>;
            DataTable PdfCrear = (DataTable)genericlist[0];
            String idcomunidad = (String)genericlist[1];
            String idLiquidacion = (String)genericlist[2];
            String Ruta = (String)genericlist[3];
            String nombreCortoLiqPasado = (String)genericlist[4];

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            String anteriorEntidad = "";

            if (Thread.CurrentThread.Name == null)
            {
                Thread.CurrentThread.Name = numero_procesos.ToString();
            }

            for (int a = 0; a < PdfCrear.Rows.Count; a++)
            {
                String idEntidad = PdfCrear.Rows[a][0].ToString();
                String Entidad = PdfCrear.Rows[a][1].ToString();
                if (anteriorEntidad != idEntidad)
                {
                    try
                    {
                        String sqlIdRecibos = "SELECT com_opdetalles.IdRecibo, Sum(com_operaciones.ImpOp) AS SumaDeImpOp FROM(((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_cuotas ON com_operaciones.IdCuota = com_cuotas.IdCuota) INNER JOIN com_recibos ON com_opdetalles.IdRecibo = com_recibos.IdRecibo GROUP BY com_opdetalles.IdRecibo, com_operaciones.IdCuota, com_operaciones.IdEntidad, com_opdetliquidacion.IdLiquidacion, com_cuotas.IdTipoCuota, com_recibos.ImpRboPte HAVING((Not(com_operaciones.IdCuota) Is Null) AND((com_operaciones.IdEntidad) = " + idEntidad + ") AND((com_opdetliquidacion.IdLiquidacion) = " + idLiquidacion + ") AND((com_cuotas.IdTipoCuota) = 1) AND((com_recibos.ImpRboPte) > 0));";

                        DataTable Recibos = Persistencia.SentenciasSQL.select(sqlIdRecibos);

                        for (int b = 0; b < Recibos.Rows.Count; b++)
                        {

                            //COMPRUEBO EL PAGADOR ES EL MISMO QUE LA ENTIDAD RECIBIDA
                            String sqlIdEntidadPagador = "SELECT com_recibos.IdEntidad, ctos_entidades.Entidad FROM com_recibos INNER JOIN ctos_entidades ON com_recibos.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_recibos.IdRecibo) = " + Recibos.Rows[b][0].ToString() + " ));";

                            DataTable Pagadores = Persistencia.SentenciasSQL.select(sqlIdEntidadPagador);

                            if (Pagadores.Rows[0][0].ToString() != idEntidad)
                            {
                                idEntidad = Pagadores.Rows[0][0].ToString();
                                Entidad = Pagadores.Rows[0][1].ToString();
                            }

                            String Liquidacion = (Persistencia.SentenciasSQL.select("SELECT LiqLargo FROM com_liquidaciones WHERE IdLiquidacion = " + idLiquidacion)).Rows[0][0].ToString();                   

                            ComunidadesForms.LiquidacionesForms.InformeParticularRecibo.FormVerInformeParticularRecibo nueva = new ComunidadesForms.LiquidacionesForms.InformeParticularRecibo.FormVerInformeParticularRecibo(idLiquidacion, idcomunidad, idEntidad, Recibos.Rows[b][0].ToString(), Liquidacion);

                            byte[] bytes = nueva.reportViewer1.LocalReport.Render(
                                "PDF", null, out mimeType, out encoding, out filenameExtension,
                                out streamids, out warnings);

                            String nombre = "L" + idLiquidacion + "-R" + Recibos.Rows[b][0].ToString() + "-" + idEntidad + " " + nombreCortoLiqPasado + " " + Entidad + ".pdf";
                        
                            using (FileStream fs = new FileStream(Ruta + @"\" + nombre, FileMode.Create))
                            {
                                fs.Write(bytes, 0, bytes.Length);
                                fs.Dispose();
                            }

                            nueva.Close();
                        }
                        anteriorEntidad = idEntidad;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al crear el PDF => " + ex.Message);
                    }
                }
                backgroundWorker1.ReportProgress((100 * a) / PdfCrear.Rows.Count, DateTime.Now);

            }
            e.Result = "Creación de PDF Completada";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }


        private void PanelControl_Load(object sender, EventArgs e)
        {
            this.monthCalendar1.Location = new Point((DimensionesPantallaAncho()) - (monthCalendar1.Size.Width) - 25, (DimensionesPantallaAlto() / 2));

            dataGridView_tareas.Location = new Point((DimensionesPantallaAncho()) - (dataGridView_tareas.Size.Width) - 25,10);

            dataGridView_tareas.ColumnCount = 3;
            dataGridView_tareas.Columns[0].Name = "Id";
            dataGridView_tareas.Columns[1].Name = "Tarea";
            dataGridView_tareas.Columns[2].Name = "%";

            dataGridView_tareas.Columns[0].Width = 25;
            dataGridView_tareas.Columns[1].Width = 220;
            dataGridView_tareas.Columns[2].Width = 30;

        }
        public void recibirFrom(String correo) {
            from = correo;
        }
        public void envioLiquidaciones(String strComunidad, String strLiquidacion, String idLiquidacion, List<String> Rutas) {

            proc1++;
            string[] row = new string[] { proc1.ToString(), "Envío PDF Liq: " + idLiquidacion, "0%" };
            dataGridView_tareas.Rows.Add(row);

            List<object> arguments = new List<object>();
            arguments.Add(strComunidad);
            arguments.Add(strLiquidacion);
            arguments.Add(idLiquidacion);
            arguments.Add(Rutas);

            var tarea = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            tarea.DoWork += backgroundWorkerEnvLiq_DoWork;
            tarea.ProgressChanged += backgroundWorker1_ProgressChanged;
            tarea.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            numero_procesos++;
            tarea.RunWorkerAsync(arguments);

        }
        public void imprimirRecibos(DataTable RecibosParaCrear, String idComunidad, String Ruta)
        {
            proc1++;
            string[] row = new string[] { proc1.ToString(), "Creación PDF Rbo :", "0%" };
            dataGridView_tareas.Rows.Add(row);

            List<object> arguments = new List<object>();
            arguments.Add(RecibosParaCrear);
            arguments.Add(idComunidad);
            arguments.Add(Ruta);

            var tarea1 = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            tarea1.DoWork += backgroundWorkerimprimirRecibos_DoWork;
            tarea1.ProgressChanged += backgroundWorker1_ProgressChanged;
            tarea1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            numero_procesos++;
            tarea1.RunWorkerAsync(arguments);
        }

        public void enviarRecibos(DataTable RecibosParaEnviar, String idComunidad, String Ruta)
        {
            proc1++;
            string[] row = new string[] { proc1.ToString(), "Enviando Rbos :", "0%" };
            dataGridView_tareas.Rows.Add(row);

            List<object> arguments = new List<object>();
            arguments.Add(RecibosParaEnviar);
            arguments.Add(idComunidad);
            arguments.Add(Ruta);

            var tarea1 = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            tarea1.DoWork += backgroundWorkerEnvRbo_DoWork;
            tarea1.ProgressChanged += backgroundWorker1_ProgressChanged;
            tarea1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            numero_procesos++;
            tarea1.RunWorkerAsync(arguments);
        }
        private void backgroundWorkerimprimirRecibos_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> genericlist = e.Argument as List<object>;
            DataTable PdfRecibos = (DataTable)genericlist[0];
            String idcomunidad = (String)genericlist[1];
            String Ruta = (String)genericlist[2];

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            if (Thread.CurrentThread.Name == null)
            {
                Thread.CurrentThread.Name = numero_procesos.ToString();
            }

            for (int a = 0; a < PdfRecibos.Rows.Count; a++)
            {
                try
                {
                    EntidadesForms.VerReporte nueva = new EntidadesForms.VerReporte(PdfRecibos.Rows[a][0].ToString(), PdfRecibos.Rows[a][2].ToString(), idcomunidad);

                    byte[] bytes = nueva.reportViewer1.LocalReport.Render(
                        "PDF", null, out mimeType, out encoding, out filenameExtension,
                        out streamids, out warnings);

                    String nombre = "R" + PdfRecibos.Rows[a][0].ToString() + "-" + PdfRecibos.Rows[a][2].ToString() + " " + PdfRecibos.Rows[a][5].ToString() + "-" + PdfRecibos.Rows[a][3].ToString() + ".pdf";
                    nombre = nombre.Replace(@"/", "-");

                    using (FileStream fs = new FileStream(Ruta + "/" + nombre, FileMode.Create))
                        fs.Write(bytes, 0, bytes.Length);
                    nueva.Close();
                }
                catch (Exception ex)    {
                    MessageBox.Show("Error al crear el PDF => " + ex.Message);
                }
                backgroundWorker1.ReportProgress((100 * a) / PdfRecibos.Rows.Count, DateTime.Now);
            }
            e.Result = "Creación de PDF Completada";

        }
        private void backgroundWorkerEnvRbo_DoWork(object sender, DoWorkEventArgs e)    {
            List<object> genericlist = e.Argument as List<object>;
            DataTable PdfRecibos = (DataTable)genericlist[0];
            String strComunidad = (String)genericlist[1];
            String Ruta = (String)genericlist[2];

            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = numero_procesos.ToString();

            DirectoryInfo di = new DirectoryInfo(Ruta.ToString());

            int IdEntidad;

            List<String> fallos = new List<String>();
            int a = 0;
            foreach (var fi in di.GetFiles("R*"))
            {
                //PREPARO EL IDENTIDAD PARA VER QUE TIPO DE ENVIO
                String nombreFichero = fi.Name;
                String idEntidad = fi.Name.Split('-')[1];
                String Entidad = fi.Name.Split('-')[3];
                idEntidad = idEntidad.Split(' ')[0];

                //BUSCO COMO QUIERE EL ENVIO
                if (int.TryParse(idEntidad, out IdEntidad))
                {
                    String sqltipoEnvio = "SELECT com_comuneros.EnvioPostal, com_comuneros.EnvioEmail, com_comuneros.IdEmail, com_comuneros.IdComunero FROM com_comuneros WHERE(((com_comuneros.IdEntidad) = " + IdEntidad + "));";
                    DataTable tipoEnvio = Persistencia.SentenciasSQL.select(sqltipoEnvio);

                    if (tipoEnvio.Rows.Count == 1)
                    {
                        if ((tipoEnvio.Rows[0][1].ToString() == "True"))
                        {
                            //ENVIO CORREO
                            String destinatario = "SELECT ctos_detemail.Email FROM ctos_detemail WHERE ctos_detemail.IdEmail = " + tipoEnvio.Rows[0][2].ToString();
                            DataTable correo = Persistencia.SentenciasSQL.select(destinatario);
                            if (correo.Rows.Count == 1)
                            {
                                destinatario = correo.Rows[0][0].ToString();
                                if (ComprobarFormatoEmail(destinatario))
                                {
                                    String asunto = strComunidad + " (C" + tipoEnvio.Rows[0][3].ToString() + ") - " + Entidad;

                                    String cuerpo = "Estimado vecino:\n Adjunto en este correo encontrará documentos de su interés.\n\nAtentamente,\nAdministraciones Urendes, S.L.\nTelf. 96 123 70 13 - admin@urendes.com";

                                    List<String> lista = new List<string>();
                                    lista.Add(fi.FullName);

                                    EnviarCorreo(destinatario, asunto, cuerpo, lista, "info@urendes.com");
                                }
                                else
                                {
                                    fallos.Add(IdEntidad.ToString());
                                }
                            }
                            else
                            {
                                fallos.Add(IdEntidad.ToString());
                            }
                        }
                        
                    }
                }
                else
                {
                    fallos.Add(IdEntidad.ToString());
                }
                backgroundWorker1.ReportProgress((100 * a) / di.GetFiles("R*").Length, DateTime.Now);
                a++;
            }

            //MUESTRO LOS FALLOS
            if (fallos.Count > 0)
            {
                String total = "";
                foreach (var fallo in fallos)
                {
                    total = total + "\n" + fallo.ToString();
                }
                e.Result = "Fallo al enviar Liquidación: \nIdEntidades: " + total;
            }
            else
                e.Result = "Recibos enviados";

        }

        private void backgroundWorkerEnvLiq_DoWork(object sender, DoWorkEventArgs e) {

            List<object> genericlist = e.Argument as List<object>;
            String strComunidad = (String)genericlist[0];
            String strLiquidacion = (String)genericlist[1];
            String idLiquidacion = (String)genericlist[2];
            List<String> Rutas = (List<String>)genericlist[3];
            //Boolean encontrado = false;

            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = numero_procesos.ToString();

            DirectoryInfo di = new DirectoryInfo(Rutas[0].ToString());

            int IdEntidad;

            List<String> fallos = new List<String>();
            int a = 0;
            foreach (var fi in di.GetFiles("L" + idLiquidacion + "*"))
            {
                //PREPARO EL IDENTIDAD PARA VER QUE TIPO DE ENVIO
                String nombreFichero = fi.Name;
                String entidad = fi.Name.Split('-')[2];
                entidad = entidad.Split(' ')[0];

                //if (entidad != "2137" && !encontrado)
                //{
                //    continue;
                //}
                //else if (entidad == "2137") {
                //    encontrado = true;
                //    MessageBox.Show(entidad);
                //    continue;
                //}

                //BUSCO COMO QUIERE EL ENVIO
                if (entidad != "" && int.TryParse(entidad, out IdEntidad))
                {
                    String sqltipoEnvio = "SELECT com_comuneros.EnvioPostal, com_comuneros.EnvioEmail, com_comuneros.IdEmail, com_comuneros.IdComunero FROM com_comuneros WHERE(((com_comuneros.IdEntidad) = " + IdEntidad + "));";
                    DataTable tipoEnvio = Persistencia.SentenciasSQL.select(sqltipoEnvio);

                    if (tipoEnvio.Rows.Count == 1)
                    {
                        if ((tipoEnvio.Rows[0][1].ToString() == "True") && (tipoEnvio.Rows[0][0].ToString() == "True"))
                        {
                        //ENVIO CORREO
                        String destinatario = "SELECT ctos_detemail.Email FROM ctos_detemail WHERE ctos_detemail.IdEmail = " + tipoEnvio.Rows[0][2].ToString();
                        DataTable correo = Persistencia.SentenciasSQL.select(destinatario);
                        if (correo.Rows.Count == 1) {
                            destinatario = correo.Rows[0][0].ToString();
                            if (ComprobarFormatoEmail(destinatario))
                            {
                                String asunto = strComunidad + " (C" + tipoEnvio.Rows[0][3].ToString() + ") - " + strLiquidacion;

                                    String cuerpo = "Estimado vecino:\n Adjunto en este correo encontrará documentos de su interés.\n\nAtentamente,\nAdministraciones Urendes, S.L.\nTelf. 96 123 70 13 - admin@urendes.com";

                                    List<String> lista = new List<string>();
                                lista.Add(fi.FullName);
                                
                               EnviarCorreo(destinatario, asunto, cuerpo, lista, "info@urendes.com");
                            }else {
                                fallos.Add(IdEntidad.ToString());
                            }
                        }
                        else {
                            fallos.Add(IdEntidad.ToString());
                        }

                        //ENVIO POSTAL
                        EnvioPostal(IdEntidad.ToString(), Rutas[0].ToString(), fi.Name, fi.FullName);
                        }
                        else if (tipoEnvio.Rows[0][1].ToString() == "True")
                        {
                            //ENVIO CORREO
                            String destinatario = "SELECT ctos_detemail.Email FROM ctos_detemail WHERE ctos_detemail.IdEmail = " + tipoEnvio.Rows[0][2].ToString();
                            DataTable correo = Persistencia.SentenciasSQL.select(destinatario);
                            if (correo.Rows.Count == 1)
                            {
                                destinatario = correo.Rows[0][0].ToString();
                                if (ComprobarFormatoEmail(destinatario))   {
                                    String asunto = strComunidad + " (C" + tipoEnvio.Rows[0][3].ToString() + ") - " + strLiquidacion;

                                    String cuerpo = "Estimado vecino:\n Adjunto en este correo encontrará documentos de su interés.\n\nAtentamente,\nAdministraciones Urendes, S.L.\nTelf. 96 123 70 13 - admin@urendes.com";

                                    List<String> lista = new List<string>();
                                    lista.Add(fi.FullName);

                                    EnviarCorreo(destinatario, asunto, cuerpo, lista, "info@urendes.com");
                                }
                                else  {
                                    fallos.Add(IdEntidad.ToString());
                                }
                            }
                            else  {
                                fallos.Add(IdEntidad.ToString());
                            }

                        }
                        else if (tipoEnvio.Rows[0][0].ToString() == "True")
                        {
                            EnvioPostal(IdEntidad.ToString(), Rutas[0].ToString(),fi.Name, fi.FullName);
                        }
                        else
                        {
                            // LO METO EN FALLOS
                        }
                    }
                }
                else
                {
                    // LO METO EN FALLOS
                }
            backgroundWorker1.ReportProgress((100 * a) / di.GetFiles("L" + idLiquidacion + "*").Length, DateTime.Now);
            a++;
            }

            //MUESTRO LOS FALLOS
            if (fallos.Count > 0) {
                String total = "";
                foreach (var fallo in fallos) {
                    total = total + "\n" + fallo.ToString();
                }
                e.Result = "Fallo al enviar Liquidación: \nIdEntidades: " + total;
            }
            else
                e.Result = "Liquidación enviada";

        }
        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        private void EnvioPostal(String IdEntidad,String Raiz,String nombreFichero, String Ruta)
        {
            if (!Directory.Exists(Raiz+@"\Postal")) {
                DirectoryInfo di = Directory.CreateDirectory(Raiz + @"\Postal");
            }
            File.Copy(Ruta, Raiz + @"\Postal\" + nombreFichero , true);
        }
    }
}
