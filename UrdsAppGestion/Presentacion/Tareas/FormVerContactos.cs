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
    public partial class FormVerContactos : Form
    {
        String idTarea;
        String idComunidad;
        DataTable contactos;
        Form form_anterior;
        String nombre_form_anterior;
        public FormVerContactos(Form form_anterior, String nombre_form_anterior ,String idTarea,String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idTarea = idTarea;
            this.form_anterior = form_anterior;
            this.nombre_form_anterior = nombre_form_anterior;
        }

        private void FormVerContactos_Load(object sender, EventArgs e)
        {
            cargarContactos();
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            if (dataGridViewContactos.Rows.Count > 0)
            {
                Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_form_anterior)).SingleOrDefault<Form>();
                if (nombre_form_anterior == "FormInsertarGestion")
                {
                    FormInsertarGestion nuevo = (FormInsertarGestion)existe;
                    nuevo.recibirContacto(dataGridViewContactos.SelectedCells[0].Value.ToString(), dataGridViewContactos.SelectedCells[1].Value.ToString());
                }
                this.Close();
            }
        }

        private void buttonAddContacto_Click(object sender, EventArgs e)
        {
            Tareas.FormInsertarContacto nueva = new FormInsertarContacto(this,idTarea, idComunidad);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        public void cargarContactos()
        {
            String sqlSelect = "SELECT exp_contactos.IdDetEntTarea, exp_contactos.Nombre, exp_contactos.Tel AS Teléfono, exp_contactos.Correo, exp_contactos.TipoContacto AS Tipo FROM exp_contactos WHERE(((exp_contactos.IdTarea) = " + idTarea + "))";

            contactos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewContactos.DataSource = contactos;
            ajustarDatagridContactos();
        }

        private void ajustarDatagridContactos()
        {

            //FORMATEO EL TELEFONO CON ESPACIOS PARA QUE SE PUEDA VER MEJOR
            for (int a = 0; a < dataGridViewContactos.RowCount; a++)
            {
                try
                {
                    String telefono = dataGridViewContactos.Rows[a].Cells[2].Value.ToString().Replace(" ", "");
                    dataGridViewContactos.Rows[a].Cells[2].Value = String.Format("{0:###-###-###}", double.Parse(telefono));
                }
                catch (Exception)
                {
                    MessageBox.Show("Hay un teléfono incorrecto. ¡Revisar!");
                    continue;
                }
            }

            if (dataGridViewContactos.Rows.Count > 0)
            {
                dataGridViewContactos.Columns[0].Visible = false;
                dataGridViewContactos.Columns["Nombre"].Width = 255;
                dataGridViewContactos.Columns["Teléfono"].Width = 75;
                dataGridViewContactos.Columns["Correo"].Width = 200;
                dataGridViewContactos.Columns["Tipo"].Width = 60;
            }
        }
    }
}
