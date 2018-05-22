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
        String idCategoria;
        public FormInsertarArea(FormServiciosConfiguracion form)
        {
            InitializeComponent();
            this.form = form;
        }
        
        public FormInsertarArea(FormServiciosConfiguracion form,String idCategoria)
        {
            InitializeComponent();
            this.form = form;
            this.idCategoria = idCategoria;
        }

        private void FormInsertarArea_Load(object sender, EventArgs e)
        {
            if (idCategoria != null)
            {
                String sqlSelect = "SELECT Nombre,Descripcion FROM exp_catElemento WHERE IdCatElemento = '" + idCategoria + "'";
                DataTable tablaArea = Persistencia.SentenciasSQL.select(sqlSelect);

                textBoxNombre.Text = tablaArea.Rows[0][0].ToString();
                textBoxDescripcion.Text = tablaArea.Rows[0][1].ToString();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String nombre = textBoxNombre.Text;
            String descripcion = textBoxDescripcion.Text;

            if (idCategoria != null)
            {
                String sqlUpdate = "UPDATE exp_catElemento SET Nombre = '" + nombre + "',Descripcion = '" + descripcion + "' WHERE IdCatElemento = '" + idCategoria + "'";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                form.cargarCategorias();
                this.Close();
            }
            else
            {
                String sqlInsert = "INSERT INTO exp_catElemento (Nombre,Descripcion) VALUES ('" + nombre + "','" + descripcion + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                MessageBox.Show("Area insertada correctamente");
                form.cargarCategorias();
                this.Close();
            }
        }

    }
}
