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
    public partial class FormInsertarArea : Form
    {
        FormServiciosConfiguracion form;
        public FormInsertarArea(FormServiciosConfiguracion form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String nombre = textBoxNombre.Text;
            String descripcion = textBoxDescripcion.Text;

            String sqlInsert = "INSERT INTO exp_catElemento (Nombre,Descripcion) VALUES ('" + nombre + "','" + descripcion + "')";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            MessageBox.Show("Area insertada correctamente");
            form.cargarCategorias();
            this.Close();
        }
    }
}
