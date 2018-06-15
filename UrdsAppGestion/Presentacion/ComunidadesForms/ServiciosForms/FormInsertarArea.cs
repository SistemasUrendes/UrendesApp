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
        String idServicio;
        String idCategoria;       

        public FormInsertarArea(FormServiciosConfiguracion form)
        {
            InitializeComponent();
            this.form = form;
        }
        
        public FormInsertarArea(FormServiciosConfiguracion form,String idServicio)
        {
            InitializeComponent();
            this.form = form;
            this.idServicio = idServicio;
        }

        private void FormInsertarArea_Load(object sender, EventArgs e)
        {
            if (idServicio != null)
            {
                String sqlSelect = "SELECT exp_detElemento.Nombre, exp_detElemento.Descripcion, exp_catElemento.Nombre, exp_catElemento.IdCatElemento FROM exp_detElemento INNER JOIN exp_catElemento ON exp_detElemento.IdCatElemento = exp_catElemento.IdCatElemento WHERE(((exp_detElemento.IdDetElemento) = '" + idServicio + "'))";
                DataTable tablaArea = Persistencia.SentenciasSQL.select(sqlSelect);

                textBoxNombre.Text = tablaArea.Rows[0][0].ToString();
                textBoxDescripcion.Text = tablaArea.Rows[0][1].ToString();
                textBoxCategoria.Text = tablaArea.Rows[0][2].ToString();
                idCategoria = tablaArea.Rows[0][3].ToString();

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
                if (idServicio != null)
                {
                    String sqlUpdate = "UPDATE exp_detElemento SET Nombre = '" + nombre + "',Descripcion = '" + descripcion + "' WHERE IdDetElemento = '" + idServicio + "'";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                    form.cargarTodasAreas();
                    this.Close();
                }
                else
                {
                    String sqlInsert = "INSERT INTO exp_detElemento (Nombre,Descripcion,IdCatElemento) VALUES ('" + nombre + "','" + descripcion + "','" + idCategoria + "')";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                    MessageBox.Show("Servicio insertada correctamente");
                    form.cargarTodasAreas();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Selecciona Categoría");
            }
        }
        
        public void recibirCategoria(String categoria, String idCategoria)
        {
            textBoxCategoria.Text = categoria;
            this.idCategoria = idCategoria;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (idCategoria != null) return;
                FormSeleccionarCategoria nueva = new FormSeleccionarCategoria(this);
                nueva.Show();
            }
        }
    }
}
