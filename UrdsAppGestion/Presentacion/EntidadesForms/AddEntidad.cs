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
    public partial class AddEntidad : Form
    {
        int id_entidad = 0;
        String nombre_largo;
        String nombre_corto;

        public AddEntidad(String nombre_largo,String nombre_corto)
        {
            this.nombre_largo = nombre_largo;
            this.nombre_corto = nombre_corto;
            InitializeComponent();
        }
        public AddEntidad(int id_entidad)
        {
            this.id_entidad = id_entidad;
            InitializeComponent();
            this.button_guardar.Text = "Actualizar";
        }

        private void AddEntidad_Load(object sender, EventArgs e)
        {
            if (id_entidad == 0)
            {
                textBox_nombre_largo.Text = this.nombre_largo;
                textBox_nombre_corto.Text = this.nombre_corto;
            }else {
                String sql = "SELECT Entidad,NombreCorto,CIF,Notas,Ruta FROM ctos_entidades WHERE IDEntidad = " + id_entidad;
                DataTable entidad_modificar = Persistencia.SentenciasSQL.select(sql);
                if (entidad_modificar.Rows.Count > 0)
                {
                    textBox_nombre_largo.Text = entidad_modificar.Rows[0]["Entidad"].ToString();
                    textBox_nombre_corto.Text = entidad_modificar.Rows[0]["NombreCorto"].ToString();
                    textbox_cif.Text = entidad_modificar.Rows[0]["CIF"].ToString();
                    textBox_notas.Text = entidad_modificar.Rows[0]["NOTAS"].ToString();
                    textBox_ruta.Text = entidad_modificar.Rows[0]["Ruta"].ToString();
                }
                else
                    MessageBox.Show("Ha ocurrido un error al cargar la entidad");
            }
        }
        private String quitaAcentos(String inputString)
        {
            var normalizedString = inputString.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                var uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(normalizedString[i]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));

        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (id_entidad == 0)
            {
                if (comprobarCampos())
                {
                    int id = Persistencia.SentenciasSQL.InsertEntidad(textBox_nombre_largo.Text, textBox_nombre_corto.Text, textbox_cif.Text, textBox_notas.Text,quitaAcentos(textBox_nombre_largo.Text), textBox_ruta.Text);
                    VerEntidad nueva = new VerEntidad(id);
                    this.Close();
                    nueva.Show();
                }
                else
                    MessageBox.Show("Revisa los campos de Entidad y Nombre Corto.\n\nNo pueden estar vacios.");
            }else {
                if (comprobarCampos()) {
                    if (Persistencia.SentenciasSQL.ActualizarEntidad(id_entidad,textBox_nombre_largo.Text, textBox_nombre_corto.Text, textbox_cif.Text, textBox_notas.Text,textBox_ruta.Text)) {
                        VerEntidad nueva = new VerEntidad(id_entidad);
                        MessageBox.Show("Actualizado");
                        this.Close();
                        nueva.Show();
                    }
                }else {
                    MessageBox.Show("Falta por rellenar el nombre");
                }
            }

            
        }
        public Boolean comprobarCampos() {

            if (textBox_nombre_largo.Text == "" || textBox_nombre_largo.TextLength < 2)
                return false;

            //if (textBox_nombre_corto.Text == "" )
            //    return false;

            //if (textbox_cif.Text != "")
            //    cif = textbox_cif.Text;

            //if (textBox_notas.Text != "")
            //    notas = textBox_notas.Text;

            return true;
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
