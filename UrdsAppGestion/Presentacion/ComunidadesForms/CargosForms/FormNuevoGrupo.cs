using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    public partial class FormNuevoGrupo : Form
    {
        String idGrupo;
        FormListadoOrganos formAnt;
        String idComunidad;
        String idBloque;

        public FormNuevoGrupo(FormListadoOrganos formAnt, String idGrupo, String idComunidad)
        {
            InitializeComponent();
            this.idGrupo = idGrupo;
            this.formAnt = formAnt;
            this.idComunidad = idComunidad;
        }

        public FormNuevoGrupo(FormListadoOrganos formAnt, String idComunidad)
        {
            InitializeComponent();
            this.formAnt = formAnt;
            this.idComunidad = idComunidad;
        }

        private void FormNuevoGrupo_Load(object sender, EventArgs e)
        {
            if (idGrupo != null)
            {
                String sqlSelect = "SELECT Nombre FROM exp_categoriaContactos WHERE IdGrupo = " + idGrupo;
                textBox1.Text = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();

            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (idBloque != null)
            {
                if (idGrupo != null)
                {
                    String sqlUpdate = "UPDATE exp_categoriaContactos SET Nombre = '" + textBox1.Text + "',IdBloque = '" + idBloque + "' WHERE IdGrupo = " + idGrupo;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                else
                {
                    String sqlInsert = "INSERT INTO exp_categoriaContactos (Nombre,IdComunidad,IdBloque) VALUES ('" + textBox1.Text + "','" + idComunidad + "','" + idBloque + "')";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                formAnt.cargarGrupos();
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecciona un bloque para el Grupo.");
            }
        }

        private void buttonSelBloque_Click(object sender, EventArgs e)
        {
            Tareas.FormSeleccionarBloque nueva = new Tareas.FormSeleccionarBloque(this, idComunidad);
            nueva.Show();
        }

        public void recibirBloque(String idBloque, String bloque)
        {
            textBoxBloque.Text = bloque;
            this.idBloque = idBloque;
        }
    }
}
