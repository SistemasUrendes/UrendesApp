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
    public partial class FormInsertarServicioBloque : Form
    {
        FormArbolAreasBloque formAnt;
        String nombrePrevio;
        String idPrevio;
        String idBloque;
        String idServicio;

        public FormInsertarServicioBloque(FormArbolAreasBloque formAnt, String idPrevio, String idBloque , String nombrePrevio)
        {
            InitializeComponent();
            this.formAnt = formAnt;
            this.nombrePrevio = nombrePrevio;
            this.idPrevio = idPrevio;
            this.idBloque = idBloque;
        }
        public FormInsertarServicioBloque(FormArbolAreasBloque formAnt, String idServicio)
        {
            InitializeComponent();
            this.formAnt = formAnt;
            this.idServicio = idServicio;
        }

        private void FormInsertarServicioBloque_Load(object sender, EventArgs e)
        {
            //EDICIÓN
            if (idServicio != null)
            {
                cargarServicio();
            }
            //NUEVO
            else
            {
                labelPrevio.Text = "Insertar en : " + nombrePrevio;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String nombre = textBoxNombre.Text;
            String descripcion = textBoxDescripción.Text;

            if (idServicio != null)
            {
                String sqlUpdate = "UPDATE exp_area SET Nombre = '" + nombre + "',Descripcion = '" + descripcion + "' WHERE IdArea = " + idServicio;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            else
            {
                String sqlInsert = "INSERT INTO exp_area (IdAreaPrevio,IdBloque,Nombre,Descripcion) VALUES (" + idPrevio + "," + idBloque + ",'" + nombre + "','" + descripcion + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
            if (formAnt != null) formAnt.rellenarTreeViewInicio();

            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarServicio()
        {
            String sqlSelect = "SELECT exp_area.Nombre, exp_area.Descripcion FROM exp_area WHERE(((exp_area.IdArea) = " + idServicio + "))";
            DataTable servicio = Persistencia.SentenciasSQL.select(sqlSelect);
            textBoxNombre.Text = servicio.Rows[0][0].ToString();
            textBoxDescripción.Text = servicio.Rows[0][1].ToString();
        }
    }
}
