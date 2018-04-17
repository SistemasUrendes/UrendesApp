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
    public partial class FormReferenciaComunidad : Form
    {
        FormTareasPrincipal form_anterior;

        public FormReferenciaComunidad(FormTareasPrincipal form_anterior)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
        }

        private void FormReferenciaComunidad_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
        }

        private void rellenarComboBox()
        {
            //RELLENAR
            DataTable comunidades;
            String sqlComboTipo = "SELECT com_comunidades.Referencia, ctos_entidades.NombreCorto FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.FBaja)Is Null))";
            comunidades = Persistencia.SentenciasSQL.select(sqlComboTipo);
            DataRow filatodas = comunidades.NewRow();

            filatodas["NombreCorto"] = "URENDES ING";
            filatodas["Referencia"] = 000;
            comunidades.Rows.InsertAt(filatodas, 0);
            comboBoxComunidades.DataSource = comunidades;
            comboBoxComunidades.DisplayMember = "NombreCorto";
            comboBoxComunidades.ValueMember = "Referencia";

        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            form_anterior.recibirReferencia(textBoxReferencia.Text);
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxComunidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBoxReferencia.Text = comboBoxComunidades.SelectedValue.ToString();
        }
        
    }
}
