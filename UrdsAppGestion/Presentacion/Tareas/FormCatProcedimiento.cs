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
    public partial class FormCatProcedimiento : Form
    {
        FormTareasConfiguracion formAnt;
        String idCategoria;
        String nombre;
        public FormCatProcedimiento(FormTareasConfiguracion formAnt)
        {
            InitializeComponent();
            this.formAnt = formAnt;
        }

        public FormCatProcedimiento(FormTareasConfiguracion formAnt, String idCategoria,String nombre)
        {
            InitializeComponent();
            this.formAnt = formAnt;
            this.idCategoria = idCategoria;
            this.nombre = nombre;
        }

        private void FormCatProcedimiento_Load(object sender, EventArgs e)
        {
            if (idCategoria != null)
            {
                textBoxNombre.Text = nombre;
            }
        }


        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if ( idCategoria != null)
            {
                String sqlUpdate = "UPDATE exp_catTareas SET Nombre = '" + textBoxNombre.Text + "' WHERE idCatTareas = '" + idCategoria + "'";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                formAnt.cargarCategorias();
                this.Close();
            }
            else
            {
                String sqlInsert = "INSERT INTO exp_catTareas (Nombre) VALUES ('" + textBoxNombre.Text + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                formAnt.cargarCategorias();
                this.Close();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
