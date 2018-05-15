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
        private String idElemento;
        private String idCategoria;
        private String nombreAnt;
        private ComunidadesForms.Elementos.FormElementos form_anterior;
        private FormVerTarea form_anterior2;
        Boolean actualizar;

        public FormInsertarElemento(ComunidadesForms.Elementos.FormElementos form_anterior, int idElementoAnt, String idCategoria, String nombreAnt)
        {
            InitializeComponent();
            this.idElementoAnt = idElementoAnt;
            this.idCategoria = idCategoria;
            this.nombreAnt = nombreAnt;
            this.form_anterior = form_anterior;
            actualizar = false;
        }

        public FormInsertarElemento(FormVerTarea form_anterior, int idElementoAnt, String idCategoria, String nombreAnt)
        {
            InitializeComponent();
            this.idElementoAnt = idElementoAnt;
            this.idCategoria = idCategoria;
            this.nombreAnt = nombreAnt;
            this.form_anterior2 = form_anterior;
            actualizar = false;
        }

        public FormInsertarElemento(ComunidadesForms.Elementos.FormElementos form_anterior, String idElemento, int idElementoAnt)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            actualizar = true;
            this.idElemento = idElemento;
            this.idElementoAnt = idElementoAnt;
        }

        private void FormInsertarElemento_Load(object sender, EventArgs e)
        {
            if ( actualizar)
            {
                cargarElemento();
            }
            else
            {
                 labelPrevio.Text = "Añadir elemento nuevo en : " + nombreAnt;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String nombre = textBoxNombre.Text;
            String descripcion = textBoxDescripción.Text;

            if (actualizar)
            {
                String sqlUpdate = "UPDATE exp_detElemento SET Nombre = '" + nombre + "',Descripcion = '" + descripcion + "' WHERE IdDetElemento = " + idElemento ;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            else
            {
                String sqlInsert = "INSERT INTO exp_detElemento (IdDetElementoPrev,IdCatElemento,Nombre,Descripcion) VALUES (" + idElementoAnt + "," + idCategoria + ",'" + nombre + "','" + descripcion + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
            if (form_anterior != null) form_anterior.rellenarTreeView(idElementoAnt.ToString());

            this.Close();
        }

        private void cargarElemento()
        {
            String sqlSelect = "SELECT exp_detElemento.Nombre, exp_detElemento.Descripcion FROM exp_detElemento WHERE(((exp_detElemento.IdDetElemento) = " + idElemento + "))";
            DataTable elemento = Persistencia.SentenciasSQL.select(sqlSelect);

            textBoxNombre.Text = elemento.Rows[0][0].ToString();
            textBoxDescripción.Text = elemento.Rows[0][1].ToString();
        }


    }
}
