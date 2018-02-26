using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion
{
    public partial class FormConexion : Form
    {
        FormPrincipal form1Handler;
        public FormConexion(FormPrincipal form1Handler)
        {
            InitializeComponent();
            this.form1Handler = form1Handler;
        }

        private void FormConexion_Load(object sender, EventArgs e)
        {
            textBox_base_datos.Text = Persistencia.conexion_bd.Database;
            textBox_ip.Text = Persistencia.conexion_bd.Ip_servidor;
            textBox_puerto.Text = Persistencia.conexion_bd.Port;
            textBox_user.Text = Persistencia.conexion_bd.User;
            textBox_password.Text = Persistencia.conexion_bd.Password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Persistencia.conexion_bd.Database = textBox_base_datos.Text;
            Persistencia.conexion_bd.Port = textBox_puerto.Text;
            Persistencia.conexion_bd.User = textBox_user.Text;
            Persistencia.conexion_bd.Password = textBox_password.Text;
            Persistencia.conexion_bd.Ip_servidor = textBox_ip.Text;
            form1Handler.barra_abajo_bbdd.Text = " [ Conectado a " + Persistencia.conexion_bd.Database.ToString() + " ] ";
            this.Close();
        }
    }
}
