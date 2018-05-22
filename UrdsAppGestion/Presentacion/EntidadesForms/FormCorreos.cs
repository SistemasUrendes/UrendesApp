using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    public partial class FormCorreos : Form
    {
        private VerEntidad m_frm;
        public int id_entidad;
        public int id_correo = 0;

        public FormCorreos(VerEntidad frm, int id_entidad)
        {
            InitializeComponent();
            m_frm = frm;
            this.id_entidad = id_entidad;
        }
        public FormCorreos(VerEntidad frm, int id_entidad, int id_correo)
        {
            InitializeComponent();
            m_frm = frm;

            this.id_entidad = id_entidad;
            this.id_correo = id_correo;
            this.button1.Text = "Actualizar";
        }

        private void FormCorreos_Load(object sender, EventArgs e)
        {

            //Relleno el formulario para modificar
            if (id_correo != 0)
            {

                String sql = "SELECT * FROM ctos_detemail WHERE IdEmail = " + id_correo;

                DataTable correos = Persistencia.SentenciasSQL.select(sql);
                this.textBox_descripcion.Text = correos.Rows[0][2].ToString();
                this.textBox_correo.Text = correos.Rows[0][3].ToString();

                if (correos.Rows[0][4].ToString() == "True")
                    this.checkBox_principal.Checked = true;
                else
                    this.checkBox_principal.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string[] row1 = new string[] { textBox1.Text,maskedTextBox1.Text, checkBox1.Checked.ToString()};
            //m_frm.dataGridView_telefonos.Rows.Add(row1);

            int principal = 0;
            if (checkBox_principal.Checked == true)
                principal = -1;

            //Inserto uno nuevo
            if (id_correo == 0)
            {
                String sqlInsertCorreo = "INSERT INTO ctos_detemail (IdEntidad,Descripcion,Email,Ppal) VALUES (" + id_entidad + ",'" + textBox_descripcion.Text + "','" + textBox_correo.Text + "'," + principal + ");";

                if (Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertCorreo))
                {
                    if (principal == -1)
                        comprobarCorreoPrincipal();

                    MessageBox.Show("Correo insertado");
                    this.Close();
                }
                else
                    MessageBox.Show("No se ha podido insertar el correo");
            }
            else
            {
                String sqlInsertCorreo = "UPDATE ctos_detemail SET Descripcion = '" + textBox_descripcion.Text + "' ,Email = '" + textBox_correo.Text + "',Ppal = " + principal + " WHERE IdEmail = " + id_correo;

                if (Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertCorreo))
                {
                    if (principal == -1)
                        comprobarCorreoPrincipal();
                    MessageBox.Show("Correo actualizado");
                    this.Close();
                }
                else
                    MessageBox.Show("No se ha podido actualizar el correo");
            }
            MessageBox.Show("Asegurate de cambiarlo, si es necesario, en el Comunero.");
            m_frm.cargaCorreos();

        }
        public void comprobarCorreoPrincipal()
        {
            for (int a = 0; a < m_frm.dataGridView_correos.Rows.Count; a++)
            {
                if (m_frm.dataGridView_correos.Rows[a].Cells[4].Value.ToString() == "True" && m_frm.dataGridView_correos.Rows[a].Cells[0].Value.ToString() != id_correo.ToString())
                {
                    String actualizarPrincipal = "UPDATE ctos_detemail SET Ppal = False WHERE IdEmail = " + (int)m_frm.dataGridView_correos.Rows[a].Cells[0].Value;
                    if (Persistencia.SentenciasSQL.InsertarGenerico(actualizarPrincipal))
                    {
                        //MessageBox.Show("cambiado");
                    }

                }
            }
        }

        private void textBox_correo_Leave(object sender, EventArgs e)
        {
            if (ComprobarFormatoEmail(textBox_correo.Text)) {
                textBox_correo.BackColor = Color.LightGreen;
                button1.Enabled = true;
            }else {
                textBox_correo.BackColor = Color.Red;
                MessageBox.Show("Introduce un correo valido");
                textBox_correo.SelectAll();
                button1.Enabled = false;
            }
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
    }
}
