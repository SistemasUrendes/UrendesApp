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
    public partial class FormInsertarBloque : Form
    {
        FormServiciosConfiguracion form_anterior;
        String idComunidad;

        public FormInsertarBloque(FormServiciosConfiguracion form_anterior, String idComunidad)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idComunidad = idComunidad;
        }
        

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String nombre = textBoxNombre.Text;
            String descripcion = textBoxDescripción.Text;

            String sqlInsert = "INSERT INTO exp_elementos (IdElementoAnt,IdComunidad,Nombre,Descripcion) VALUES (0," + idComunidad + ",'" + nombre + "','" + descripcion + "')";

            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            if (form_anterior != null) form_anterior.cargarBloques(idComunidad);
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
