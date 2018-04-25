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
    public partial class FormInsertarElemento : Form
    {
        private int idElementoAnt;
        private int idComunidad;
        private String nombreAnt;
        private ComunidadesForms.Elementos.FormElementos form_anterior1;
        private FormVerTarea form_anterior2;

        public FormInsertarElemento(ComunidadesForms.Elementos.FormElementos form_anterior, int idElementoAnt, int idComunidad, String nombreAnt)
        {
            InitializeComponent();
            this.idElementoAnt = idElementoAnt;
            this.idComunidad = idComunidad;
            this.nombreAnt = nombreAnt;
            this.form_anterior1 = form_anterior;
        }

        public FormInsertarElemento(FormVerTarea form_anterior, int idElementoAnt, int idComunidad, String nombreAnt)
        {
            InitializeComponent();
            this.idElementoAnt = idElementoAnt;
            this.idComunidad = idComunidad;
            this.nombreAnt = nombreAnt;
            this.form_anterior2 = form_anterior;
        }

        private void FormInsertarElemento_Load(object sender, EventArgs e)
        {
            labelPrevio.Text = "Añadir elemento nuevo en : " + nombreAnt;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String nombre = textBoxNombre.Text;
            String descripcion = textBoxDescripción.Text;

            String sqlInsert = "INSERT INTO exp_elementos (IdElementoAnt,IdComunidad,Nombre,Descripción) VALUES (" + idElementoAnt + "," + idComunidad + ",'" + nombre + "','" + descripcion + "')";

            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            if (form_anterior1 != null) form_anterior1.rellenarTreeView(idElementoAnt.ToString());

            this.Close();
        }
        
    }
}
