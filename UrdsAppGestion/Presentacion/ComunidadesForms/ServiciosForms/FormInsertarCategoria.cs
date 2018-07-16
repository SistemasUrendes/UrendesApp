using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ServiciosForms
{
    public partial class FormInsertarCategoria : Form
    {
        Tareas.FormServiciosConfiguracion form;
        String idCategoria;

        public FormInsertarCategoria()
        {
            InitializeComponent();
        }

        
        public FormInsertarCategoria(Tareas.FormServiciosConfiguracion form)
        {
            InitializeComponent();
            this.form = form;
        }

        public FormInsertarCategoria(Tareas.FormServiciosConfiguracion form, String idCategoria)
        {
            InitializeComponent();
            this.form = form;
            this.idCategoria = idCategoria;
        }
        
        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            String nombre = textBoxNombre.Text;
            String nombreCorto = textBoxNombreCorto.Text;
            String descripcion = textBoxDescripcion.Text;


            if (idCategoria != null)
            {
                String sqlUpdate = "UPDATE exp_catElemento SET Nombre = '" + nombre + "',NombreCorto = '" + nombreCorto + "',Descripcion = '" + descripcion + "' WHERE IdCatElemento = '" + idCategoria + "'";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                form.cargarCategorias();
                this.Close();
            }
            else
            {
                String sqlInsert = "INSERT INTO exp_catElemento (Nombre,NombreCorto,Descripcion) VALUES ('" + nombre + "','" + nombreCorto + "','" + descripcion + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                MessageBox.Show("Categoría insertada correctamente");
                form.cargarCategorias();
                this.Close();
            }
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInsertarCategoria_Load(object sender, EventArgs e)
        {
            if (idCategoria != null)
            {
                String sqlSelect = "SELECT Nombre,NombreCorto,Descripcion FROM exp_catElemento WHERE IdCatElemento = '" + idCategoria + "'";
                DataTable tablaArea = Persistencia.SentenciasSQL.select(sqlSelect);

                textBoxNombre.Text = tablaArea.Rows[0][0].ToString();
                textBoxNombreCorto.Text = tablaArea.Rows[0][1].ToString();
                textBoxDescripcion.Text = tablaArea.Rows[0][2].ToString();
            }
        }
    }
}

