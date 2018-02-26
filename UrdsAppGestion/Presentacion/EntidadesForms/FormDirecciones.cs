using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    public partial class FormDirecciones : Form
    {
        VerEntidad form_entidad;
        public String id_direccion = "0";
        public int id_entidad_cargado;
        public Boolean lectura;        

        public FormDirecciones(VerEntidad form_entidad,String id_direccion,int id_entidad_cargado)
        {
            InitializeComponent();
            this.id_direccion = id_direccion;
            this.form_entidad = form_entidad;
            this.id_entidad_cargado = id_entidad_cargado;
        }
        public FormDirecciones(VerEntidad form_entidad,String id_direccion,int id_entidad_cargado, Boolean lectura)
        {
            InitializeComponent();
            this.id_direccion = id_direccion;
            this.form_entidad = form_entidad;
            this.id_entidad_cargado = id_entidad_cargado;
            this.lectura = lectura;
        }
        public FormDirecciones(VerEntidad form_entidad,int id_entidad_cargado)
        {
            InitializeComponent();
            this.form_entidad = form_entidad;
            this.id_entidad_cargado = id_entidad_cargado;
        }
        private void FormDirecciones_Load(object sender, EventArgs e)
        {
            if (id_direccion != "0")
            {
                DataTable direcciones = Persistencia.SentenciasSQL.select("SELECT * FROM ctos_detdirecent WHERE IdDireccion = " + id_direccion);

                if (direcciones.Rows[0]["Ppal"].ToString() == "True") checkBox_principal.Checked = true;

                textBox_descripcion.Text = direcciones.Rows[0][2].ToString();
                textBox_contacto.Text = direcciones.Rows[0][4].ToString();
                textBox_direccion.Text = direcciones.Rows[0][5].ToString();
                textBox_cp.Text = direcciones.Rows[0][6].ToString();
                textBox_poblacion.Text = direcciones.Rows[0][7].ToString();
                textBox_provincia.Text = direcciones.Rows[0][8].ToString();

                if (lectura) {
                    textBox_descripcion.ReadOnly = true;
                    textBox_contacto.ReadOnly = true;
                    textBox_direccion.ReadOnly = true;
                    textBox_cp.ReadOnly = true;
                    textBox_poblacion.ReadOnly = true;
                    textBox_provincia.ReadOnly = true;
                    checkBox_principal.Enabled = false;
                    button1.Enabled = false;
                }                
            }
            else {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String principal = "0";
            if (checkBox_principal.Checked) principal = "-1";

            if (id_direccion != "0")
            {
                String sql = "UPDATE ctos_detdirecent SET Descripcion='" + textBox_descripcion.Text + "', Ppal=" + principal + ", Contacto='" + textBox_contacto.Text + "', Direccion='" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(textBox_direccion.Text) + "', CP='" + textBox_cp.Text + "', Poblacion='" + textBox_poblacion.Text + "', Provincia='" + textBox_provincia.Text + "' WHERE IdDireccion = " + id_direccion;

                Persistencia.SentenciasSQL.InsertarGenerico(sql);
                compruebaPrincipal(id_direccion, principal);

            }
            else {
                String sql = "INSERT INTO ctos_detdirecent (IdEntidad,Descripcion, Ppal, Contacto, Direccion, CP, Poblacion, Provincia) VALUES (" + id_entidad_cargado + ",'" + textBox_descripcion.Text + "'," + principal + ",'" + textBox_contacto.Text + "','" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(textBox_direccion.Text) + "','" + textBox_cp.Text + "','" + textBox_poblacion.Text + "','" + textBox_provincia.Text + "')";

                int ultimo_id = Persistencia.SentenciasSQL.InsertarGenericoID(sql);

                compruebaPrincipal(ultimo_id.ToString(), principal);
            }
            form_entidad.cargoDirecciones();
            this.Close();
        }
        private void compruebaPrincipal(String id_direccion, String principal) {
           // String sql2; //= "SELECT Ppal,IdDireccion FROM ctos_detdirecent";
            
            if (principal == "-1") {
                String sql2 = "UPDATE ctos_detdirecent SET Ppal = 0 WHERE IdDireccion <> " + id_direccion + " AND IdEntidad = " + id_entidad_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sql2);
            }
            if (principal == "0") {
                String sql2 = "SELECT Ppal,IdDireccion FROM ctos_detdirecent WHERE IdEntidad = " + id_entidad_cargado;
                DataTable res = Persistencia.SentenciasSQL.select(sql2);
                if (res.Rows.Count > 0)
                {
                    for (int a = 0; a < res.Rows.Count; a++)
                    {
                        // MessageBox.Show(res.Rows[a][1].ToString() + "->" + id_direccion);
                        if (res.Rows[a][1].ToString() != id_direccion)
                        {
                            String sql = "UPDATE ctos_detdirecent SET Ppal = -1 WHERE IdDireccion = " + res.Rows[a][1].ToString();
                            Persistencia.SentenciasSQL.InsertarGenerico(sql);

                        }
                    }
                }else {
                    String sql = "UPDATE ctos_detdirecent SET Ppal = -1 WHERE IdDireccion = " + id_direccion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sql);
                }
            }
        }
    }
}
