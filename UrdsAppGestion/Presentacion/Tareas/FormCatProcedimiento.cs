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
        public FormCatProcedimiento(FormTareasConfiguracion formAnt)
        {
            InitializeComponent();
            this.formAnt = formAnt;
        }

        public FormCatProcedimiento(FormTareasConfiguracion formAnt, String idCategoria)
        {
            InitializeComponent();
            this.formAnt = formAnt;
            this.idCategoria = idCategoria;
        }

        private void FormCatProcedimiento_Load(object sender, EventArgs e)
        {
            if (idCategoria != null)
            {
                String sqlSelect = "SELECT Nombre FROM exp_catTareas WHERE IdCatTareas = '" + idCategoria + "'";
                textBoxNombre.Text = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
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
