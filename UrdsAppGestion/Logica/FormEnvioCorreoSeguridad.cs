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

namespace UrdsAppGestión.Logica
{
    public partial class FormEnvioCorreoSeguridad : Form
    {
        String id_comunidad_cargado;
        String clave;
        public FormEnvioCorreoSeguridad(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox_clave.Text == clave) {
                Logica.FormLogBorrarComunidad nueva = new Logica.FormLogBorrarComunidad(id_comunidad_cargado);
                nueva.Show();
                this.Close();
            }else {
                MessageBox.Show("La clave no es correcta");
            }
        }

        private void FormEnvioCorreoSeguridad_Load(object sender, EventArgs e)
        {
            clave = crearClave();
            String cuerpo = "El usuario " + Presentacion.Login.getnombre() + " quiere eliminar la comunidad con Id : " + id_comunidad_cargado + ".<br>Asegurese que es correcto<br>Código de Seguridad : " + clave;
            EnviarCorreo("sistemas@urendes.com", "Solicitud de Borrado Comunidad desde APP", cuerpo);
            MessageBox.Show("Se ha enviado la clave por correo al administrador");
        }
        private void EnviarCorreo(String destinatario, String Asunto, String Cuerpo)
        {

            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(destinatario));
            email.From = new MailAddress("info@urendes.com");
            email.Subject = Asunto;
            String cabecera = "<!DOCTYPE html PUBLIC ' -//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html><head><meta http-equiv = 'Content-Type' content ='text/html;UTF-8'/></head><body style = 'margin: 0px; background-color: '#F4F3F4'; font-family: Helvetica, Arial, sans-serif; font-size:12px;' text = '#444444' bgcolor = '#F4F3F4' link='#21759B' alink='#21759B' vlink='#21759B' marginheight='0' topmargin='0' marginwidth='0' leftmargin='0'><table border='0' width='100%' cellspacing='0' cellpadding = '0' bgcolor = '#F4F3F4' ><tbody><tr><td style='padding: 15px;' ><center><table width='550' cellspacing='0' cellpadding='0' align = 'center' bgcolor = '#ffffff' ><tbody><tr><td align = 'left'><div style = 'border: solid 1px #d9d9d9;'><table id = 'header' style = 'line-height: 1.6; font-size: 12px; font-family: Helvetica, Arial, sans-serif; border: solid 1px #FFFFFF; color: #444;' border='0' width='100%' cellspacing='0' cellpadding='0' bgcolor = '#ffffff'><tbody><tr><td style='color: #ffffff;' colspan='2' valign = 'bottom' height = '30' >.</td></tr><tr style='padding-left: 30px;'><td style = 'line-height: 32px; padding-left: 0px;' valign='baseline'><center><p><img src='http://urendes.com/wp-content/uploads/2016/09/Logo-Urendes.png' alt='LOGO' width='220' height='47' /></p><h2><span style = 'color: #999999;' > Administración de Fincas</span></h2></td></center></tr></tbody></table ><table id= 'content' style= 'margin-top: 15px; margin-right: 30px; margin-left: 30px; color: #444; line-height: 1.6; font-size: 12px; font-family: Arial, sans-serif;' border= '0' width= '490' cellspacing= '0' cellpadding= '0' bgcolor= '#ffffff' ><tbody><tr><td style= 'border-top: solid 1px #d9d9d9;' colspan='2' ><div style= 'padding: 15px 0;' >";

            String pie = "</div></td></tr></tbody></table><table id= 'footer' style= 'line-height: 1.5; font-size: 12px; font-family: Arial, sans-serif; margin-right: 30px; margin-left: 30px;' border= '0' width= '490' cellspacing= '0' cellpadding= '0' bgcolor= '#ffffff'><tbody><tr style= 'font-size: 11px; color: #999999;'><td style= 'border-top: solid 1px #d9d9d9;' colspan= '2'><div style='padding-top: 15px; padding-bottom: 1px;'><img style= 'vertical-align:middle;' src='http://urendes.com/wp-admin/images/date-button.gif' alt= 'Fecha' width= '13' height= '13' /> Email enviado el " + DateTime.Now + "  <a href='http://urendes.com'>[ VISITAR WEB ]</a></div><div><img style = 'vertical-align: middle;' src= 'http://urendes.com/wp-admin/images/comment-grey-bubble.png' alt= 'Contacto' width='12' height='12' /> Para cualquier problema, por favor contacta con <a href='mailto:sistemas@urendes.com'>sistemas@urendes.com</a></div></td></tr><tr><td style='color: #ffffff;' colspan='2' height='15' >.</td></tr></tbody></table></div></td></tr></tbody></table></center></td></tr></tbody></table></body></html>";

            email.Body = cabecera + Cuerpo + pie;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;


            SmtpClient smtp = new SmtpClient();
            smtp.Host = "hl316.hosteurope.es";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("admin@envios.urendes.com", "#.Urds16");
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
        private String crearClave() {
            Random obj = new Random();
            string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = posibles.Length;
            char letra;
            int longitudnuevacadena = 8;
            string nuevacadena = "";
            for (int i = 0; i < longitudnuevacadena; i++)
            {
                letra = posibles[obj.Next(longitud)];
                nuevacadena += letra.ToString();
            }
            return nuevacadena;
        }
    }
}
