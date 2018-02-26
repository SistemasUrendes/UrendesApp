using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.EnviosForms
{
    public partial class Documentos : Form
    {
        String id_comunidad_cargado = "0";
        Presentacion.ComunidadesForms.EnviosForms.Envios form_anterior;

        public Documentos(Presentacion.ComunidadesForms.EnviosForms.Envios form_anterior, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
        }

        public Documentos(Presentacion.ComunidadesForms.EnviosForms.Envios form_anterior)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
        }

        private void Documentos_Load(object sender, EventArgs e)
        {
            String sqlCombo = "SELECT IdTipoDocumento, Descripcion FROM com_tipoDocumento";
            comboBox_documento.DataSource = Persistencia.SentenciasSQL.select(sqlCombo);
            comboBox_documento.ValueMember = "IdTipoDocumento";
            comboBox_documento.DisplayMember = "Descripcion";

            if (id_comunidad_cargado != "0")
            {
                cargarBloques();
            }
            else
            {
                cargarLista();
            }
        }
        private void cargarLista() {
            String sql = "SELECT com_comunidades.IdComunidad, ctos_entidades.NombreCorto, com_comunidades.FBaja FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.FBaja)Is Null));";
            listBox1.DataSource = Persistencia.SentenciasSQL.select(sql);
            listBox1.ValueMember = "IdComunidad";
            listBox1.DisplayMember = "NombreCorto";
        }
        private void cargarBloques () {
            String sql = "SELECT com_bloques.IdBloque, com_bloques.Descripcion FROM com_bloques GROUP BY com_bloques.IdBloque, com_bloques.Descripcion, com_bloques.IdComunidad, com_bloques.IdTipoBloque HAVING (((com_bloques.IdComunidad) = " + id_comunidad_cargado + ") AND((com_bloques.IdTipoBloque) = 1));";
            listBox1.DataSource = Persistencia.SentenciasSQL.select(sql);
            listBox1.ValueMember = "IdBloque";
            listBox1.DisplayMember = "Descripcion";
            comboBox1.Visible = false;
            listBox1.SelectionMode = SelectionMode.One;
            label4.Visible = false;
            button_seleccion.Visible = false;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            if (senderComboBox.SelectedItem.ToString() == "Todas")
                cargarLista();

            if (senderComboBox.SelectedItem.ToString() == "Activas") {
                String sql = "SELECT com_comunidades.IdComunidad, ctos_entidades.NombreCorto FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE (((com_comunidades.FBaja)Is Null));";

                listBox1.DataSource = Persistencia.SentenciasSQL.select(sql);
                listBox1.ValueMember = "IdComunidad";
                listBox1.DisplayMember = "NombreCorto";
            }

            if (senderComboBox.SelectedItem.ToString() == "Bajas") {
                String sql = "SELECT com_comunidades.IdComunidad, ctos_entidades.NombreCorto FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.FBaja)Is Not Null));";
                listBox1.DataSource = Persistencia.SentenciasSQL.select(sql);
                listBox1.ValueMember = "IdComunidad";
                listBox1.DisplayMember = "NombreCorto";
            }
        }

        private void textBox_ruta_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            String ruta = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Ruta FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_cargado + "));")).Rows[0][0].ToString();

            openFileDialog1.InitialDirectory = ruta.Trim('#');

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sFileName = openFileDialog1.FileName;
                textBox_ruta.Text = sFileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fechaInicio = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd hh:mm:ss");
            if (id_comunidad_cargado != "0") {

                Persistencia.SentenciasSQL.InsertRuta2(comboBox_documento.SelectedValue.ToString(), fechaInicio, listBox1.SelectedValue.ToString(),id_comunidad_cargado,textBox_descripcion.Text, textBox_ruta.Text);
            }
            else {
                String comunidadesSeleccionadas = "";

                foreach (object element in listBox1.SelectedItems)  {
                    DataRowView row = (DataRowView)element;
                    comunidadesSeleccionadas += row[0].ToString() + ",";
                }

                Persistencia.SentenciasSQL.InsertRuta(comboBox_documento.SelectedValue.ToString(),fechaInicio, comunidadesSeleccionadas, textBox_descripcion.Text, textBox_ruta.Text);
            }

            form_anterior.cargarEnvios();
            this.Close();
        }

        private void button_seleccion_Click(object sender, EventArgs e)
        {
            for (int a = 0;a < listBox1.Items.Count;a++) {
                listBox1.SetSelected(a, true);
            }
        }
    }
}
