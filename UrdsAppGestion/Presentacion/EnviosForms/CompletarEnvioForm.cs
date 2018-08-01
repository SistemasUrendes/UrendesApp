using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Logica;
using System.Text.RegularExpressions;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.EnviosForms
{
    public partial class CompletarEnvioForm : Form
    {
        String ruta;
        String asunto;
        String cuerpo;
        String id_bloque;
        public String id_comunidad;
        String id_tipo;
        String comunidades = "0";
        String donde;
        String id_documento;
        String correoFallo = "";

        List<EnvioCorreo> EntidadesBien = new List<EnvioCorreo>();

        public CompletarEnvioForm(String id_documento, String id_tipo, String ruta, String asunto, String id_bloque, String id_comunidad, String donde)
        {
            InitializeComponent();
            this.ruta = ruta;
            this.asunto = asunto;
            this.id_bloque = id_bloque;
            this.id_comunidad = id_comunidad;
            this.donde = donde;
            this.id_tipo = id_tipo;
            textBox_asusnto.Text = asunto;
            this.id_documento = id_documento;
            textBox_adjunto_1.Text = id_documento;
        }
        public CompletarEnvioForm(String id_documento, String id_tipo, String comunidades, String asunto,String ruta,String donde)
        {
            InitializeComponent();
            this.ruta = ruta;
            this.asunto = asunto;
            this.id_tipo = id_tipo;
            this.comunidades = comunidades;
            this.donde = donde;
            this.id_documento = id_documento;
            textBox_asusnto.Text = asunto;
            textBox_adjunto_1.Text = id_documento;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cuerpo = textBox_cuerpo.Text;
            asunto = textBox_asusnto.Text;

            List<EnvioCorreo> EntidadesBien = new List<EnvioCorreo>();
            List<EnvioCorreo> EntidadesMal = new List<EnvioCorreo>();

            if (donde == "com")
            {
                ComprobarCorreos();
            } else if (donde == "fallo") {
                correoFallo = (Persistencia.SentenciasSQL.select("SELECT com_enviosLote.UltimoCorreo FROM com_EnvSe INNER JOIN com_enviosLote ON com_EnvSe.IdLote = com_enviosLote.IdLote WHERE(((com_EnvSe.IdDocumento) = " + id_documento + "));")).Rows[0][0].ToString();

                ComprobarCorreos();
            }
             else {
                EnviarCorreosComunidades();
            }
                
        }
        public static bool ComprobarFormatoEmail(string sEmailAComprobar) {
            String sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(sEmailAComprobar, sFormato))  {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        private void EnviarCorreosComunidades()
        {
            String[] comunidades_array = comunidades.Split(',');
            List<EnvioCorreo> EntidadesBien = new List<EnvioCorreo>();
            List<EnvioCorreo> EntidadesMal = new List<EnvioCorreo>();

            for (int a = 0; a < comunidades_array.Length; a++)
            {
                if (comunidades_array[a].ToString() != "")
                {

                    String sql = "SELECT com_comuneros.IdComunero, com_comuneros.IdEntidad, com_comuneros.IdEmail, ctos_detemail.Email, com_comuneros.EnvioEmail, com_asociacion.Ppal, com_comuneros.EmailCopia FROM(com_comuneros INNER JOIN ctos_detemail ON com_comuneros.IdEmail = ctos_detemail.IdEmail) INNER JOIN com_asociacion ON com_comuneros.IdComunero = com_asociacion.IdComunero GROUP BY com_comuneros.IdComunero, com_comuneros.IdEntidad, com_comuneros.IdEmail, ctos_detemail.Email, com_comuneros.EnvioEmail, com_comuneros.IdComunidad, com_asociacion.Ppal HAVING(((com_comuneros.EnvioEmail) = -1) AND((com_comuneros.IdComunidad) = " + comunidades_array[a].ToString() + ") AND ((com_asociacion.Ppal) = -1));";

                    DataTable tabla_envios_comunidades = Persistencia.SentenciasSQL.select(sql);
                    for (int b = 0; b < tabla_envios_comunidades.Rows.Count; b++)
                    {
                        if (ComprobarFormatoEmail(tabla_envios_comunidades.Rows[b]["Email"].ToString()))
                        {
                            EnvioCorreo envio = new EnvioCorreo(comunidades_array[a], tabla_envios_comunidades.Rows[b]["IdEntidad"].ToString(), tabla_envios_comunidades.Rows[b]["IdEmail"].ToString(), tabla_envios_comunidades.Rows[b]["Email"].ToString(), tabla_envios_comunidades.Rows[a]["EmailCopia"].ToString());
                            EntidadesBien.Add(envio);
                        }
                        else
                        {
                            EnvioCorreo envio = new EnvioCorreo(comunidades_array[a], tabla_envios_comunidades.Rows[b]["IdEntidad"].ToString(), tabla_envios_comunidades.Rows[b]["IdEmail"].ToString(), tabla_envios_comunidades.Rows[b]["Email"].ToString(), tabla_envios_comunidades.Rows[a]["EmailCopia"].ToString());
                            EntidadesMal.Add(envio);
                        }
                    }
                }
            }
            if (EntidadesMal.Count > 0)
            {
                String entidadesMal = "";
                foreach (EnvioCorreo item in EntidadesMal)
                {
                    entidadesMal += item.IdEntidad1.ToString() + "\n";
                }

                DialogResult resultado_message;
                resultado_message = MessageBox.Show("Se han detectado correos incorrectos en las siguientes entidades:\n" + entidadesMal + "\n¿Quieres seguir enviado los " + EntidadesBien.Count.ToString() + " bien?", "Error Correos", MessageBoxButtons.YesNo);

                if (resultado_message == System.Windows.Forms.DialogResult.Yes)
                {
                    PanelControl existe = Application.OpenForms.OfType<PanelControl>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<PanelControl>();
                    if (existe != null)
                    {
                        existe.WindowState = FormWindowState.Normal;
                        existe.BringToFront();

                        List<String> adjuntos = new List<string>();
                        if (textBox_adjunto_1.Text == "")
                        {
                            ruta = "No";
                            adjuntos.Add(@ruta);
                        }
                        else
                        {
                            String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_1.Text;
                            ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                            adjuntos.Add(@ruta);
                        }
                        if (textBox_adjunto_2.Text != "")
                        {
                            String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_2.Text;
                            ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                            adjuntos.Add(@ruta);
                        }

                        if (textBox_adjunto_3.Text != "")
                        {
                            String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_3.Text;
                            ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                            adjuntos.Add(@ruta);
                        }
                        if (textBox_adjunto_4.Text != "")
                        {
                            String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_4.Text;
                            ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                            adjuntos.Add(@ruta);
                        }

                        existe.EjecutarEnvio(EntidadesBien, textBox_asusnto.Text, textBox_cuerpo.Text, adjuntos, "Correos Comunidades", id_tipo, textBox_adjunto_1.Text);
                        this.Close();
                    }
                }
            }
            else
            {
                PanelControl existe = Application.OpenForms.OfType<PanelControl>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<PanelControl>();
                if (existe != null)
                {
                    existe.WindowState = FormWindowState.Normal;
                    existe.BringToFront();

                    List<String> adjuntos = new List<string>();
                    if (textBox_adjunto_1.Text == "")
                    {
                        ruta = "No";
                        adjuntos.Add(@ruta);
                    }
                    else
                    {
                        String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_1.Text;
                        ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                        adjuntos.Add(@ruta);
                    }
                    if (textBox_adjunto_2.Text != "")
                    {
                        String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_2.Text;
                        ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                        adjuntos.Add(@ruta);
                    }

                    if (textBox_adjunto_3.Text != "")
                    {
                        String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_3.Text;
                        ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                        adjuntos.Add(@ruta);
                    }
                    if (textBox_adjunto_4.Text != "")
                    {
                        String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_4.Text;
                        ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                        adjuntos.Add(@ruta);
                    }

                    for (int a = 0; a < adjuntos.Count; a++)
                    {
                        MessageBox.Show(adjuntos[a]);
                    }

                    existe.EjecutarEnvio(EntidadesBien, textBox_asusnto.Text, textBox_cuerpo.Text, adjuntos, "Correos Comunidades", id_tipo, textBox_adjunto_1.Text);
                    this.Close();
                }
            }
        }
        private void ComprobarCorreos() {

            List<EnvioCorreo> EntidadesMal = new List<EnvioCorreo>();
            List<EnvioCorreo> EntidadesBien = new List<EnvioCorreo>();
            String sql = "SELECT com_subcuotas.IdBloque, com_asociacion.IdComunero, ctos_entidades.IDEntidad, com_asociacion.IdTipoAsoc, com_asociacion.Ppal, com_comuneros.IdDireccion, com_comuneros.IdEmail, com_comuneros.EnvioPostal, com_comuneros.EnvioEmail, com_divisiones.IdComunidad,com_comuneros.EmailCopia FROM(((com_subcuotas LEFT JOIN com_divisiones ON com_subcuotas.IdDivision = com_divisiones.IdDivision) LEFT JOIN com_asociacion ON com_divisiones.IdDivision = com_asociacion.IdDivision) LEFT JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) LEFT JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad GROUP BY com_subcuotas.IdBloque, com_asociacion.IdComunero, ctos_entidades.Entidad, com_asociacion.IdTipoAsoc, com_asociacion.Ppal, com_comuneros.IdDireccion, com_comuneros.IdEmail, com_comuneros.EnvioPostal, com_comuneros.EnvioEmail, com_divisiones.IdComunidad HAVING(((com_subcuotas.IdBloque) = " + id_bloque + ") AND((com_asociacion.IdTipoAsoc) = 1) AND((com_asociacion.Ppal) = -1) AND((com_comuneros.EnvioEmail) = -1));";

            DataTable correos = Persistencia.SentenciasSQL.select(sql);
            for (int a = 0; a < correos.Rows.Count; a++)
            {        
                    if (correos.Rows[a]["IdEmail"].ToString() != "" || correos.Rows[a]["IdEmail"] != null)
                    {
                        String Sql = "SELECT Email FROM ctos_detemail WHERE IdEntidad = " + correos.Rows[a]["IDEntidad"] + " AND Ppal = -1";
                        DataTable correo;

                        try {
                            correo = Persistencia.SentenciasSQL.select(Sql);

                            if (!ComprobarFormatoEmail(correo.Rows[0][0].ToString())) {
                                EnvioCorreo envio = new EnvioCorreo(correos.Rows[a]["IdComunidad"].ToString(), correos.Rows[a]["IDEntidad"].ToString(), correos.Rows[a]["IdEmail"].ToString(), correo.Rows[0][0].ToString(), correos.Rows[a]["EmailCopia"].ToString());
                                EntidadesMal.Add(envio);
                            }
                            else {
                                EnvioCorreo envio = new EnvioCorreo(correos.Rows[a]["IdComunidad"].ToString(), correos.Rows[a]["IDEntidad"].ToString(), correos.Rows[a]["IdEmail"].ToString(), correo.Rows[0][0].ToString(), correos.Rows[a]["EmailCopia"].ToString());
                                EntidadesBien.Add(envio);
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            EnvioCorreo envio = new EnvioCorreo(correos.Rows[a]["IdComunidad"].ToString(), correos.Rows[a]["IDEntidad"].ToString(), correos.Rows[a]["IdEmail"].ToString());
                            EntidadesMal.Add(envio);
                        }
                    }
            }
            if (EntidadesMal.Count > 0)  {
                String entidadesMal ="";
                foreach (EnvioCorreo item in EntidadesMal)
                {
                    entidadesMal += item.IdEntidad1.ToString() + "\n";
                }

                DialogResult resultado_message;
                resultado_message = MessageBox.Show("Se han detectado correos incorrectos en las siguientes entidades:\n" + entidadesMal + "\n¿Quieres seguir enviado los " + EntidadesBien.Count.ToString() + " bien?", "Error Correos", MessageBoxButtons.YesNo);

                if (resultado_message == System.Windows.Forms.DialogResult.Yes)
                {
                    PanelControl existe = Application.OpenForms.OfType<PanelControl>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<PanelControl>();
                    if (existe != null)
                    {
                        existe.WindowState = FormWindowState.Normal;
                        existe.BringToFront();

                        List<String> adjuntos = new List<string>();
                        if (textBox_adjunto_1.Text == "") {
                            ruta = "No";
                            adjuntos.Add(@ruta);
                        }else {
                            String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_1.Text;
                            ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                            adjuntos.Add(@ruta);
                        }
                        if (textBox_adjunto_2.Text != "")
                        {
                            String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_2.Text;
                            ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                            adjuntos.Add(@ruta);
                        }

                        if (textBox_adjunto_3.Text != "")
                        {
                            String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_3.Text;
                            ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                            adjuntos.Add(@ruta);
                        }
                        if (textBox_adjunto_4.Text != "")
                        {
                            String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_4.Text;
                            ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                            adjuntos.Add(@ruta);
                        }
                        if (donde == "fallo")  {
                            int hasta = 0;
                            for (int a = 0; a < EntidadesBien.Count; a++)  {
                                if (EntidadesBien[a].Correo.ToString() == correoFallo)
                                    hasta = a;
                            }
                            EntidadesBien.RemoveRange(0, hasta + 1);
                        }
                        existe.EjecutarEnvio(EntidadesBien, textBox_asusnto.Text, textBox_cuerpo.Text, adjuntos, "Correos " + id_comunidad, id_tipo, textBox_adjunto_1.Text);
                        this.Close();
                    }
                }
            } else {
                PanelControl existe = Application.OpenForms.OfType<PanelControl>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<PanelControl>();
                if (existe != null)
                {
                    existe.WindowState = FormWindowState.Normal;
                    existe.BringToFront();
                    List<String> adjuntos = new List<string>();
                    if (textBox_adjunto_1.Text == "")
                    {
                        ruta = "No";
                        adjuntos.Add(@ruta);
                    }
                    else
                    {
                        String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_1.Text;
                        ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                        adjuntos.Add(@ruta);
                    }
                    if (textBox_adjunto_2.Text != "")
                    {
                        String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_2.Text;
                        ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                        adjuntos.Add(@ruta);
                    }

                    if (textBox_adjunto_3.Text != "")
                    {
                        String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_3.Text;
                        ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                        adjuntos.Add(@ruta);
                    }
                    if (textBox_adjunto_4.Text != "")
                    {
                        String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_4.Text;
                        ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                        adjuntos.Add(@ruta);
                    }
                    String referencia = (Persistencia.SentenciasSQL.select("SELECT Referencia FROM com_comunidades WHERE IdComunidad = " + id_comunidad)).Rows[0][0].ToString();
                    
                    if (donde == "fallo")  {
                        int hasta = 0;
                        for (int a = 0; a < EntidadesBien.Count; a++) {
                            if (EntidadesBien[a].Correo.ToString() == correoFallo) {
                                hasta = a;
                            }
                        }
                        EntidadesBien.RemoveRange(0, hasta+1);
                    }

                    existe.EjecutarEnvio(EntidadesBien, textBox_asusnto.Text, textBox_cuerpo.Text, adjuntos, "[ " + referencia + " ] Correos", id_tipo, textBox_adjunto_1.Text);
                    this.Close();
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            List<String> adjuntos = new List<string>();
            if (textBox_adjunto_1.Text == "")
            {
                ruta = "No";
                adjuntos.Add(@ruta);
            }
            else
            {
                String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_1.Text;
                ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                adjuntos.Add(@ruta);
            }
            if (textBox_adjunto_2.Text != "")
            {
                String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_2.Text;
                ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                adjuntos.Add(@ruta);
            }

            if (textBox_adjunto_3.Text != "")
            {
                String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_3.Text;
                ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                adjuntos.Add(@ruta);
            }
            if (textBox_adjunto_4.Text != "")
            {
                String buscarRuta = "SELECT Ruta FROM com_Documentos WHERE IdDocumento = " + textBox_adjunto_4.Text;
                ruta = (Persistencia.SentenciasSQL.select(buscarRuta)).Rows[0][0].ToString();
                adjuntos.Add(@ruta);
            }
            EnviarCorreo(textBox_test.Text,textBox_asusnto.Text,textBox_cuerpo.Text, adjuntos);
            MessageBox.Show("Mensaje de prueba enviado");
        }
        private void EnviarCorreo(String destinatario, String Asunto, String Cuerpo, List<String> adjuntos)  {
            //Sustituir \n por <br>
            Cuerpo = Cuerpo.Replace("\n", "<br>");

            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(destinatario));
            email.From = new MailAddress("info@urendes.com");
            email.Subject = Asunto;
            String cabecera = "<!DOCTYPE html PUBLIC ' -//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html><head><meta http-equiv = 'Content-Type' content ='text/html;UTF-8'/></head><body style = 'text-align: justify;margin: 0px; background-color: '#F4F3F4'; font-family: Helvetica, Arial, sans-serif; font-size:12px;' text = '#444444' bgcolor = '#F4F3F4' link='#21759B' alink='#21759B' vlink='#21759B' marginheight='0' topmargin='0' marginwidth='0' leftmargin='0'><table border='0' width='100%' cellspacing='0' cellpadding = '0' bgcolor = '#F4F3F4' ><tbody><tr><td style='padding: 15px;' ><center><table width='550' cellspacing='0' cellpadding='0' align = 'center' bgcolor = '#ffffff' ><tbody><tr><td align = 'left'><div style = 'border: solid 1px #d9d9d9;'><table id = 'header' style = 'line-height: 1.6; font-size: 12px; font-family: Helvetica, Arial, sans-serif; border: solid 1px #FFFFFF; color: #444;' border='0' width='100%' cellspacing='0' cellpadding='0' bgcolor = '#ffffff'><tbody><tr><td style='color: #ffffff;' colspan='2' valign = 'bottom' height = '30' >.</td></tr><tr style='padding-left: 30px;'><td style = 'line-height: 32px; padding-left: 0px;' valign='baseline'><center><p><img src='http://urendes.com/wp-content/uploads/2016/09/Logo-Urendes.png' alt='LOGO' width='220' height='47' /></p><h2><span style = 'color: #999999;' > Administración de Fincas</span></h2></td></center></tr></tbody></table ><table id= 'content' style= 'margin-top: 15px; margin-right: 30px; margin-left: 30px; color: #444; line-height: 1.6; font-size: 12px; font-family: Arial, sans-serif;' border= '0' width= '490' cellspacing= '0' cellpadding= '0' bgcolor= '#ffffff' ><tbody><tr><td style= 'text-align:justify;border-top: solid 1px #d9d9d9;' colspan='2' ><div style= 'padding: 15px 0;' >";

            String pie = "</div></td></tr></tbody></table><table id= 'footer' style= 'line-height: 1.5; font-size: 12px; font-family: Arial, sans-serif; margin-right: 30px; margin-left: 30px;' border= '0' width= '490' cellspacing= '0' cellpadding= '0' bgcolor= '#ffffff'><tbody><tr style= 'font-size: 11px; color: #999999;'><td style= 'border-top: solid 1px #d9d9d9;' colspan= '2'><div style='padding-top: 15px; padding-bottom: 1px;'><img style= 'vertical-align:middle;' src='http://urendes.com/wp-admin/images/date-button.gif' alt= 'Fecha' width= '13' height= '13' /> Email enviado el " + DateTime.Now + "  <a href='http://urendes.com'>[ VISITAR WEB ]</a></div><div><img style = 'vertical-align: middle;' src= 'http://urendes.com/wp-admin/images/comment-grey-bubble.png' alt= 'Contacto' width='12' height='12' /> Para cualquier problema, por favor contacta con <a href='mailto:sistemas@urendes.com'>sistemas@urendes.com</a></div></td></tr><tr><td style='color: #ffffff;' colspan='2' height='15' >.</td></tr></tbody></table></div></td></tr></tbody></table></center></td></tr></tbody></table></body></html>";


            email.Body = cabecera + Cuerpo + pie;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            for (int a = 0; a < adjuntos.Count; a++)
                if (System.IO.File.Exists(@adjuntos[a]))
                    email.Attachments.Add(new Attachment(@adjuntos[a]));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "urendes.com";
            smtp.Port = 26;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("no-replay@envios.urendes.com", "TwTtdo3T[Sw&");

            try
            {
                smtp.Send(email);
                email.Dispose();
            }
            catch (Exception)
            {
                Thread.Sleep(5000);
                smtp.Send(email);
                email.Dispose();
            }
        }
        private void textBox_adjunto_2_DoubleClick(object sender, EventArgs e)
        {
            Presentacion.EnviosForms.SeleccionAdjuntos nueva = new Presentacion.EnviosForms.SeleccionAdjuntos(this,id_comunidad,"2");
            nueva.Show();
        }
        public void insertarDoc(String id_doc,String donde) {
            
            if (donde =="2") {
                textBox_adjunto_2.Text = id_doc;
            }
            if (donde =="3") {
                textBox_adjunto_3.Text = id_doc;
            }
            if (donde =="4") {
                textBox_adjunto_4.Text = id_doc;
            }
        
        }
        private void textBox_adjunto_3_DoubleClick(object sender, EventArgs e)
        {
            Presentacion.EnviosForms.SeleccionAdjuntos nueva = new Presentacion.EnviosForms.SeleccionAdjuntos(this, id_comunidad, "3");
            nueva.Show();
        }
        private void textBox_adjunto_4_DoubleClick(object sender, EventArgs e)
        {
            Presentacion.EnviosForms.SeleccionAdjuntos nueva = new Presentacion.EnviosForms.SeleccionAdjuntos(this, id_comunidad, "4");
            nueva.Show();
        }
        private void CompletarEnvioForm_Load(object sender, EventArgs e)
        {
            textBox_test.Text = Login.getemail();

            String [] comunidadesArray = comunidades.Split(',');
            for (int a = 0; a < comunidadesArray.Length-1; a++) {
                String FechaBajaComunidad = (Persistencia.SentenciasSQL.select("SELECT FBaja FROM com_comunidades WHERE IdComunidad = " + comunidadesArray[a])).Rows[0][0].ToString();
                if (FechaBajaComunidad != "")
                {
                    MessageBox.Show("Esa Comunidad esta dada de baja y no se puede entrar\n          Contacte con el Administrador");
                    this.Close();
                }
            }


            String sqlCuerpo = "SELECT com_enviosLote.Descripcion FROM com_EnvSe INNER JOIN com_enviosLote ON com_EnvSe.IdLote = com_enviosLote.IdLote WHERE(((com_EnvSe.IdDocumento) = " + id_documento + "));";

            DataTable tablaCuerpo = Persistencia.SentenciasSQL.select(sqlCuerpo);
            if (tablaCuerpo.Rows.Count > 0) {
                textBox_cuerpo.Text = tablaCuerpo.Rows[0][0].ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Presentacion.EnviosForms.FormSeleccionPlantillas nueva = new Presentacion.EnviosForms.FormSeleccionPlantillas(this);
            nueva.Show();
        }
        public void recogerText(String texto) {
            textBox_cuerpo.Text = texto;
        }
    }
}
