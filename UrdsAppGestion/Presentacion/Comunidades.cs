using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion
{
    public partial class Comunidades : Form
    {
        static DataTable comunidades;//= Persistencia.SentenciasSQL.select(Persistencia.SentenciasSQL.SQL[3]);
        public Comunidades()
        {
            InitializeComponent();

            //PRUEBA GIT!
        }

        private void Comunidades_Load(object sender, EventArgs e)
        {
            cargarComunidades();

        }
        public void cargarComunidades() {
            comunidades = Persistencia.SentenciasSQL.select(Persistencia.SentenciasSQL.SQL[3]);
            dataGridView_comunidades.DataSource = comunidades;
            dataGridView_comunidades.Columns[0].Visible = false;
            dataGridView_comunidades.Columns[1].HeaderText = "#";
            //dataGridView_comunidades.Columns[2].Visible = false;
            dataGridView_comunidades.Columns[7].Visible = false;
            dataGridView_comunidades.Columns[8].Visible = false;
            dataGridView_comunidades.Columns[9].Visible = false;

            dataGridView_comunidades.Columns[12].Visible = false;
            dataGridView_comunidades.Columns["FBaja"].Visible = false;

            dataGridView_comunidades.Columns[11].HeaderText = "Gestor";
            dataGridView_comunidades.Columns[11].Width = 80;
            dataGridView_comunidades.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_comunidades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView_comunidades.Columns[17].HeaderText = "Contabilidad";
            dataGridView_comunidades.Columns[17].Width = 80;
            dataGridView_comunidades.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_comunidades.Columns[10].HeaderText = "Administrador";
            dataGridView_comunidades.Columns[10].Width = 80;
            dataGridView_comunidades.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView_comunidades.Columns[1].Width = 40;
            dataGridView_comunidades.Columns[2].Width = 200;
            dataGridView_comunidades.Columns[4].Width = 400;
            dataGridView_comunidades.Columns[6].Width = 140;

            dataGridView_comunidades.Columns["IdGestor"].Visible = false;
            dataGridView_comunidades.Columns["IdGestor2"].Visible = false;
            dataGridView_comunidades.Columns["IdContabilidad"].Visible = false;

            DataTable administradores = Persistencia.SentenciasSQL.select("SELECT IdURD, Usuario FROM ctos_urendes WHERE IdGrupoURD = 2 and FBaja is Null ");
            comboBox_administrador.DataSource = administradores;
            comboBox_administrador.DisplayMember = "Usuario";
            comboBox_administrador.ValueMember = "IdURD";

            comboBox_gestor.DataSource = Persistencia.SentenciasSQL.select("SELECT Usuario,IdURD FROM ctos_urendes WHERE IdGrupoURD = 1 and FBaja is Null ");
            comboBox_gestor.DisplayMember = "Usuario";
            comboBox_gestor.ValueMember = "IdURD";

            comboBox_contabilidad.DataSource = Persistencia.SentenciasSQL.select("SELECT Usuario,IdURD FROM ctos_urendes WHERE IdGrupoURD = 5 and FBaja is Null ");
            comboBox_contabilidad.DisplayMember = "Usuario";
            comboBox_contabilidad.ValueMember = "IdURD";

            comboBox_estado.SelectedItem = "Alta";

            DataTable busqueda = comunidades;
            
            busqueda.DefaultView.RowFilter = " ( FBaja is Null AND IdGestor = " + Login.getId() + " ) OR (FBaja is Null AND IdGestor2 = " + Login.getId() + ") OR (FBaja is Null AND IdContabilidad = " + Login.getId() + ")";
            this.dataGridView_comunidades.DataSource = busqueda;


        }
        private void button_ver_entidad_Click(object sender, EventArgs e)
        {
            Presentacion.EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad((int)dataGridView_comunidades.SelectedCells[12].Value);
            nueva.Show();
        }

        private void dataGridView_comunidades_DoubleClick(object sender, EventArgs e)
        {
            String FechaBajaComunidad = (Persistencia.SentenciasSQL.select("SELECT FBaja FROM com_comunidades WHERE IdComunidad = " + dataGridView_comunidades.SelectedCells[0].Value.ToString())).Rows[0][0].ToString();

            //if (FechaBajaComunidad == "")
            //{

                Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Text.Contains(" " + dataGridView_comunidades.SelectedCells[2].Value.ToString())).SingleOrDefault<Form>();
                if (existe != null)
                {
                    //existe.WindowState = FormWindowState.Maximized;
                    existe.BringToFront();
                }
                else
                {
                    Presentacion.ComunidadesForms.ContenedorComunidad nueva = new ComunidadesForms.ContenedorComunidad(dataGridView_comunidades.SelectedCells[2].Value.ToString(), (int)dataGridView_comunidades.SelectedCells[0].Value);
                    nueva.Show();
                }
            //}else {
            //    MessageBox.Show("Esa Comunidad esta dada de baja y no se puede entrar\n          Contacte con el Administrador");
            //}
        }

        private void button_gestiones_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Text.Contains(" " + dataGridView_comunidades.SelectedCells[2].Value.ToString())).SingleOrDefault<Form>();
            if (existe != null)
            {
                //existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Presentacion.ComunidadesForms.ContenedorComunidad nueva = new ComunidadesForms.ContenedorComunidad(dataGridView_comunidades.SelectedCells[2].Value.ToString(), (int)dataGridView_comunidades.SelectedCells[0].Value);
                nueva.Show();
            }
        }

        private void textBox_nombre_corto_TextChanged(object sender, EventArgs e)
        {
            if (textBox_nombre_corto.TextLength < 2)
            {
                DataTable busqueda = comunidades;
                busqueda.DefaultView.RowFilter = "NombreCorto like '%%'";
                this.dataGridView_comunidades.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = comunidades;
                busqueda.DefaultView.RowFilter = "NombreCorto like '%" + textBox_nombre_corto.Text + "%'";
                this.dataGridView_comunidades.DataSource = busqueda;
            }
        }


        private void textBox_poblacion_TextChanged(object sender, EventArgs e)
        {
            if (textBox_poblacion.TextLength < 2)
            {
                DataTable busqueda = comunidades;
                busqueda.DefaultView.RowFilter = "Poblacion like '%%'";
                this.dataGridView_comunidades.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = comunidades;
                busqueda.DefaultView.RowFilter = "Poblacion like '%" + textBox_poblacion.Text + "%'";
                this.dataGridView_comunidades.DataSource = busqueda;
            }
        }

        private void textBox_referencia_TextChanged(object sender, EventArgs e)
        {
            if (textBox_referencia.TextLength == 0)
            {
                DataTable busqueda = comunidades;
                busqueda.DefaultView.RowFilter = "Referencia like '%%' ";
                this.dataGridView_comunidades.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = comunidades;
                busqueda.DefaultView.RowFilter = "Referencia like '%" + textBox_referencia.Text + "%'";
                this.dataGridView_comunidades.DataSource = busqueda;
            }
        }
        private void comboBox_administrador_SelectedValueChanged(object sender, EventArgs e)
        {
            DataTable busqueda = comunidades;
            busqueda.DefaultView.RowFilter = "FBaja is Null AND IdURD = " + comboBox_administrador.SelectedValue;
            this.dataGridView_comunidades.DataSource = busqueda;
        }

        private void comboBox_gestor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable busqueda = comunidades;
            busqueda.DefaultView.RowFilter = "FBaja is Null AND id_gestor = " + comboBox_gestor.SelectedValue;
            this.dataGridView_comunidades.DataSource = busqueda;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comunidades = Persistencia.SentenciasSQL.select(Persistencia.SentenciasSQL.SQL[3]);
            comunidades.DefaultView.RowFilter = "FBaja is Null";
            dataGridView_comunidades.DataSource = comunidades;
        }

        private void button_ruta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si no funciona quitar almohadillas de la base de datos");
            
            System.Diagnostics.Process.Start(@dataGridView_comunidades.SelectedCells[7].Value.ToString());
        }

        private void dataGridView_comunidades_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_comunidades.HitTest(e.X, e.Y);
                dataGridView_comunidades.ClearSelection();
                dataGridView_comunidades.Rows[hti.RowIndex].Selected = true;
                
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Text.Contains(dataGridView_comunidades.SelectedCells[2].Value.ToString())).SingleOrDefault<Form>();

            //MessageBox.Show(existe.Text);

            if (existe != null)
            {
                //existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Presentacion.ComunidadesForms.ContenedorComunidad nueva = new ComunidadesForms.ContenedorComunidad(dataGridView_comunidades.SelectedCells[2].Value.ToString(), (int)dataGridView_comunidades.SelectedCells[0].Value);
                nueva.Show();
            }
        }

        private void entidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad((int)dataGridView_comunidades.SelectedCells[12].Value);
            nueva.Show();
        }

        private void rutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Ruta = dataGridView_comunidades.SelectedCells[7].Value.ToString().Trim('#');
            System.Diagnostics.Process.Start(@Ruta);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Presentacion.ComunidadesForms.FormFicha nueva = new ComunidadesForms.FormFicha(this,(int)dataGridView_comunidades.SelectedCells[0].Value, dataGridView_comunidades.SelectedCells[2].Value.ToString());
            nueva.Show();
        }

        private void fichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.ComunidadesForms.FormFicha nueva = new ComunidadesForms.FormFicha(this,(int)dataGridView_comunidades.SelectedCells[0].Value, dataGridView_comunidades.SelectedCells[2].Value.ToString());
            nueva.Show();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox estado = (ComboBox)sender;
            DataTable busqueda = comunidades;

            if (estado.SelectedItem.ToString() == "Alta") {
                busqueda.DefaultView.RowFilter = "FBaja is Null";
            }else if (estado.SelectedItem.ToString() == "Baja") {
                busqueda.DefaultView.RowFilter = "FBaja IS NOT NULL";
            }
            else if (estado.SelectedItem.ToString() == "Todas") {
                busqueda.DefaultView.RowFilter = "FBaja is Null OR FBaja IS NOT NULL";
            }

            this.dataGridView_comunidades.DataSource = busqueda;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Login.getRol() == "Admin")
            {
                String nombreComunidadBorrar = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.NombreCorto FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.IdComunidad) = " + dataGridView_comunidades.SelectedCells[0].Value.ToString() + "));")).Rows[0][0].ToString();

                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Estas seguro de borrar " + nombreComunidadBorrar + " ? ", "!!ATENCIÓN!!", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    Logica.FormEnvioCorreoSeguridad nueva = new Logica.FormEnvioCorreoSeguridad(dataGridView_comunidades.SelectedCells[0].Value.ToString());
                    nueva.Show();
                   
                }
            }
        }

        private void comboBox_contabilidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable busqueda = comunidades;
            busqueda.DefaultView.RowFilter = "FBaja is Null AND IdContabilidad = " + comboBox_contabilidad.SelectedValue;
            this.dataGridView_comunidades.DataSource = busqueda;
        }

        private void copiarNIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dataGridView_comunidades.SelectedRows[0].Cells[3].Value.ToString());
        }
    }
}
