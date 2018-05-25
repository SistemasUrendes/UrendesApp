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
    public partial class FormTelefono : Form
    {
        private VerEntidad m_frm;
        public int id_entidad;
        public int id_telefono = 0;

        public FormTelefono(VerEntidad frm,int id_entidad)
        {
            InitializeComponent();
            m_frm = frm;
            this.id_entidad = id_entidad;
        }
        public FormTelefono(VerEntidad frm, int id_entidad,int id_telefono)
        {
            InitializeComponent();
            m_frm = frm;
            this.id_entidad = id_entidad;
            this.id_telefono = id_telefono;
            this.button1.Text = "Actualizar";
        }

        private void FormTelefono_Load(object sender, EventArgs e)
        {
            maskedTextBox_telefono.Mask = "000000000";

            //Relleno el formulario para modificar
            if (id_telefono != 0) {
                String sql = "SELECT IdDetTelf,IdEntidad, Descripcion, Telefono, Ppal FROM ctos_dettelf WHERE IdDetTelf = " + id_telefono;
                DataTable telefono = Persistencia.SentenciasSQL.select(sql);
                this.textBox_descripcion.Text = telefono.Rows[0][2].ToString();

                this.maskedTextBox_telefono.Text = telefono.Rows[0][3].ToString();

                if (telefono.Rows[0][4].ToString() == "True")
                    this.checkBox_principal.Checked = true;
                else
                    this.checkBox_principal.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int principal = 0;
            if (checkBox_principal.Checked == true)
                principal = -1;

            if (!maskedTextBox_telefono.MaskFull) {
                MessageBox.Show("El teléfono no es correcto");
                return;
            } 

            //Inserto uno nuevo
            if (id_telefono == 0)
            {
                String sqlInsertTele = "INSERT INTO  ctos_dettelf (IdEntidad,Descripcion,Telefono,Ppal) VALUES (" + id_entidad + ",'" + textBox_descripcion.Text + "','" + maskedTextBox_telefono.Text + "'," + principal + ");";

                if (Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertTele))
                {
                    if (principal == -1)
                        comprobarTelefonoPrincipal();

                    MessageBox.Show("Telefono insertado");
                    this.Close();
                }
                else
                    MessageBox.Show("No se ha podido insertar el telefono");
            }
            else {
                String sqlInsertTele = "UPDATE ctos_dettelf SET Descripcion = '"+ textBox_descripcion.Text + "' ,Telefono = '" + maskedTextBox_telefono.Text +  "',Ppal = " + principal + " WHERE IdDetTelf = " + id_telefono;

                if (Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertTele)) {
                    if (principal == -1)
                        comprobarTelefonoPrincipal();
                    MessageBox.Show("Telefono actualizado");
                    this.Close();
                }
                else
                    MessageBox.Show("No se ha podido actualizar el telefono");
            }
            MessageBox.Show("Asegurate de cambiarlo, si es necesario ,en el Comunero.");
            m_frm.cargaTelefonos();

        }
        public void comprobarTelefonoPrincipal()
        {
            for (int a = 0; a < m_frm.dataGridView_telefonos.Rows.Count; a++)
            {
                if (m_frm.dataGridView_telefonos.Rows[a].Cells[4].Value.ToString() == "True")
                {
                    String actualizarPrincipal = "UPDATE ctos_dettelf SET Ppal = 0 WHERE IdDetTelf = " + (int)m_frm.dataGridView_telefonos.Rows[a].Cells[0].Value;
                    if (Persistencia.SentenciasSQL.InsertarGenerico(actualizarPrincipal))
                    {
                        //MessageBox.Show("cambiado");
                    }

                }
            }
        }
    }
}
