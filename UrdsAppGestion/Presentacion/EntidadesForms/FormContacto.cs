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
    public partial class FormContacto : Form
    {
        VerEntidad form_entidad;
        int id_entidad_cargado;
        String id_contacto = "0";

        public FormContacto(VerEntidad form_entidad,int id_entidad_cargado,String id_contacto)
        {
            InitializeComponent();
            this.form_entidad = form_entidad;
            this.id_entidad_cargado = id_entidad_cargado;
            this.id_contacto = id_contacto;
        }
        public FormContacto(VerEntidad form_entidad, int id_entidad_cargado)
        {
            InitializeComponent();
            this.form_entidad = form_entidad;
            this.id_entidad_cargado = id_entidad_cargado;
        }

        private void FormContacto_Load(object sender, EventArgs e)
        {
            if (id_contacto != "0" ) {

                DataTable contactos = Persistencia.SentenciasSQL.select("SELECT * FROM ctos_detcontent WHERE IDContacto = " + id_contacto);
                textBox_nombre.Text = contactos.Rows[0][2].ToString();
                textBox_cargo.Text = contactos.Rows[0][5].ToString();
                textBox_mobil1.Text = contactos.Rows[0][3].ToString();
                textBox_email.Text = contactos.Rows[0][4].ToString();
                textBox_extension.Text = contactos.Rows[0][7].ToString();
                textBox_teldirecto.Text = contactos.Rows[0][6].ToString();
                textBox_notas.Text = contactos.Rows[0][8].ToString();

            }
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (id_contacto != "0")
            {
                String sql = "UPDATE ctos_detcontent SET Nombre ='" + textBox_nombre.Text + "', IdEntidad='" + id_entidad_cargado + "', Movil1='" + textBox_mobil1.Text + "', Email='" + textBox_email.Text + "', Cargo='" + textBox_cargo.Text+ "', TelDirecto = '" + textBox_teldirecto.Text + "', Notas= '" + textBox_notas.Text + "', Extension = '" + textBox_extension.Text +  "'  WHERE IDContacto = " + id_contacto;

                Persistencia.SentenciasSQL.InsertarGenerico(sql);
            }
            else
            {
                String sql = "INSERT INTO ctos_detcontent(IdEntidad,Nombre,Movil1,Email,Cargo,TelDirecto,Extension,Notas) VALUES (" + id_entidad_cargado + ",'" + textBox_nombre.Text + "','" + textBox_mobil1.Text + "','" + textBox_email.Text + "','" + textBox_cargo.Text + "','" + textBox_teldirecto.Text + "','" + textBox_extension.Text + "','" + textBox_notas.Text + "')";

                Persistencia.SentenciasSQL.InsertarGenerico(sql);
            }
            form_entidad.cargoContactos();
            this.Close();
        }
    }
}
