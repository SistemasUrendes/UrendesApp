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
        FormTareasConfiguracion form;
        String idTipoGestion;
        public FormInsertarTipoGestion(FormTareasConfiguracion form)
        {
            InitializeComponent();
            this.form = form;
        }
        public FormInsertarTipoGestion(FormTareasConfiguracion form,String idTipoGestion)
        {
            InitializeComponent();
            this.form = form;
            this.idTipoGestion = idTipoGestion;
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

                if (idTipoGestion != null)
                {
                    String sqlUpdate = "UPDATE exp_tipogestion SET Descripcion = '" + descripcion + "',Plazo = '" + plazo + "' WHERE IdTipoGestion = " + idTipoGestion;
                    //String sqlInsert = "INSERT INTO exp_tipogestion (Descripcion,Plazo) VALUES ('" + descripcion + "'," + plazo + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                    form.cargarTiposGestion();
                    MessageBox.Show("Tipo Gestion actualizado correctamente");
                    this.Close();
                }
                else
                {
                    String sqlInsert = "INSERT INTO exp_tipogestion (Descripcion,Plazo) VALUES ('" + descripcion + "'," + plazo + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                    form.cargarTiposGestion();
                    MessageBox.Show("Tipo Gestion añadido correctamente");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Introduzca valores en los campos Nombre y Plazo");
            }
        }

        private void FormInsertarTipoGestion_Load(object sender, EventArgs e)
        {
            if (idTipoGestion != null)
            {
                cargarTipoTarea();
            }
        }

        private void cargarTipoTarea()
        {
            String sqlSelect = "SELECT Descripcion,Plazo FROM exp_tipogestion WHERE IdTipoGestion = " + idTipoGestion;
            DataTable tipoGestion = Persistencia.SentenciasSQL.select(sqlSelect);
            textBoxNombre.Text = tipoGestion.Rows[0][0].ToString();
            maskedTextBoxPlazo.Text = tipoGestion.Rows[0][1].ToString();

        }
    }
}
