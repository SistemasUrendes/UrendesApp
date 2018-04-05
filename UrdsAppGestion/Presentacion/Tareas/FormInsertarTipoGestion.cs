using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.Tareas
{
    public partial class FormInsertarTipoGestion : Form
    {
        public FormInsertarTipoGestion()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxNombre.Text != "" && maskedTextBoxPlazo.Text != "")
            {
                //VALORES DE LA QUERY DE INSERCIÓN
                String descripcion = textBoxNombre.Text;
                String plazo = maskedTextBoxPlazo.Text;
                
                String sqlInsert = "INSERT INTO exp_tipogestion (Descripcion,Plazo) VALUES ('" + descripcion + "'," + plazo + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                MessageBox.Show("Tipo Gestion añadido correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Introduzca valores en los campos Nombre y Plazo");
            }
        }
    }
}
