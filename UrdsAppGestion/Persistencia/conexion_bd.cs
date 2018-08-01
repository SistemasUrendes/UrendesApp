using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace UrdsAppGestión.Persistencia {
    class conexion_bd {
        private static String ip_servidor = "192.168.0.20";
        private static String user = "gestor";
        private static String password = "gestorurds";
        private static String database = "prueba";
        private static String port = "3307";

        public static string Ip_servidor
        {
            get
            {
                return ip_servidor;
            }

            set
            {
                ip_servidor = value;
            }
        }

        public static string User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public static string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public static string Database
        {
            get
            {
                return database;
            }

            set
            {
                database = value;
            }
        }

        public static string Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        //Metodo que abre la conexión con los datos descritos.
        public static MySqlConnection abrir() {
            try {
                if (Presentacion.Login.getRemoto()) {
                    ip_servidor = "10.8.0.1";
                }
                string datos = "server=" + ip_servidor + ";user=" + user + ";password=" + password + ";database=" + database + ";port=" + port + ";Allow Zero Datetime=True;CHARSET=utf8;ConnectionTimeout=900";
                MySqlConnection conexion = new MySqlConnection(datos);
                
                return conexion;
            }
            catch (Exception e) {
                MessageBox.Show("Error de Conexion\n" + e.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void cerrar(MySqlConnection cnn) {
            try {
                cnn.Close();
            }
            catch (Exception e) {
                MessageBox.Show("Error de Conexion\n" + e.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
