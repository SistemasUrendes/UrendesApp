using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Presentacion;

namespace UrdsAppGestión.Presentacion
{
    public partial class Login : Form
    {
        static string rol_usuario = null;
        static string nombre_usuario = null;
        static string id_usuario_conectado;
        static string email_usuario_conectado;
        static Boolean remoto = false;
        Boolean logueado = false;

        private FormPrincipal form1Handler;

        public static Boolean getRemoto()
        {
            return remoto;
        }

        public Login(FormPrincipal form1)
        {
            InitializeComponent();
            form1Handler = form1;
        }

        private void button_entrar_Click(object sender, EventArgs e)
        {
            ComprobarLogin();
        }
        public static string getRol() {
            return rol_usuario;
        }

        public static string getId() {
            return id_usuario_conectado;
        }

        public static string getemail() {
            return email_usuario_conectado;
        }
        public static string getnombre() {
            return nombre_usuario;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox_password.Focus();
            textBox_password.Enabled = true;
        }
        public void ComprobarLogin() {
            DataTable resultado = null;
            MySqlConnection conexion = null;
            String ip = "";
            try
            {
                if (checkBox1.Checked)
                {
                    //ip local
                    ip = "10.8.0.1";                    
                    remoto = true;

                    try
                    {
                        //datos para pruebas locales
                        string datos = "server=" + ip + ";user=gestor;password=gestorurds;database=users;port=3306";

                        conexion = new MySqlConnection(datos);
                        conexion.Open();
                    }catch {
                        /* //ESTA PREPARADO PARA CONECTARSE AL NAS SI FALLASE EL SERVIDOR LOCAL * 
                            ip = "urendes-nas.ddns.net";
                            string datos = "server=" + ip + ";user=gestor;password=gestorurds;database=acceso;port=3307";
                            conexion = new MySqlConnection(datos);
                            conexion.Open();
                        */
                    }

                }else {
                    ip = "192.168.0.20";
                    string datos = "server=" + ip + ";user=gestor;password=gestorurds;database=acceso;port=3307";

                    conexion = new MySqlConnection(datos);
                    conexion.Open();
                }
                string sql = "SELECT * FROM usuarioAppAdmin WHERE password = '" +  this.textBox_password.Text + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
                DataSet ds = new DataSet();

                da.Fill(ds);
                resultado = ds.Tables[0];
                conexion.Close();

                if (resultado.Rows.Count > 0) {
                    rol_usuario = resultado.Rows[0]["rol"].ToString();
                    id_usuario_conectado = resultado.Rows[0][0].ToString();
                    email_usuario_conectado = resultado.Rows[0]["email"].ToString();

                    if (rol_usuario == "Admin") {
                        foreach (ToolStripMenuItem item in form1Handler.menuStrip1.Items) {
                            foreach (ToolStripMenuItem item1 in item.DropDownItems) {
                                if (item1.Text == "Conexión" || item1.Text == "Mtto. General" || item1.Text == "Mtto. Procedimientos" || item1.Text == "Mtto. Gestiones" || item1.Text == "Mtto. Servicios") {
                                    item1.Enabled = true;
                                }
                            }
                        }

                    }
                    else {
                        foreach (ToolStripMenuItem item in form1Handler.menuStrip1.Items)
                        {
                            foreach (ToolStripMenuItem item1 in item.DropDownItems)
                            {
                                if (item1.Text == "Conexión" || item1.Text == "Mtto. General" || item1.Text == "Mtto. Procedimientos" || item1.Text == "Mtto. Gestiones" || item1.Text == "Mtto. Servicios")
                                    item1.Enabled = false;
                            }
                        }
                    }

                    nombre_usuario = resultado.Rows[0]["nombre"].ToString();
                    logueado = true;
                    this.Close();
                    form1Handler.Visible = true;
                    form1Handler.menuStrip1.Visible = true;
                    form1Handler.barrar_abajo_nombre.Text = " [ Usuario : " + nombre_usuario.ToString() + " ] ";
                    form1Handler.barra_abajo_bbdd.Text = " [ Conectado a " + Persistencia.conexion_bd.Database.ToString() + " ] ";
                    form1Handler.barra_abajo_rol.Text = " [ Rol: " + Presentacion.Login.getRol().ToString() + " ] ";
                }
                else {
                    MessageBox.Show("Contraseña Incorrecta.");
                }
            }
            catch (Exception e) { MessageBox.Show("Error de Conexion\n" + e.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        private void textBox_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
                ComprobarLogin();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!logueado)
                Application.Exit();
        }
    }
}