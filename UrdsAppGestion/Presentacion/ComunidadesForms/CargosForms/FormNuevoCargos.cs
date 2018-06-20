using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    public partial class FormNuevoCargos : Form
    {
        String id_comunidad_cargado;
        String idBloque;
        FormCargosEditar form_anterior;
        
        public FormNuevoCargos(FormCargosEditar form_anterior, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
        }

        private void FormNuevoCargos_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            String sqlSelectOrganos = "SELECT IdOrgano, Nombre FROM com_organos WHERE IdComunidad = " + id_comunidad_cargado + " AND Activo = -1";
            DataTable organos = Persistencia.SentenciasSQL.select(sqlSelectOrganos);
            comboBox_organo.DataSource = organos;
            comboBox_organo.DisplayMember = "Nombre";
            comboBox_organo.ValueMember = "IdOrgano";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_nuevo.Enabled = false;
            comboBox_sugerencia.Enabled = true;
            radioButton1.Checked = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_nuevo.Enabled = true;
            comboBox_sugerencia.Enabled = false;
            radioButton2.Checked = false;
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String idOrgano = "NULL";

            if (comboBox_organo.SelectedValue != null && comboBox_organo.SelectedValue.ToString() != "") {
                idOrgano = comboBox_organo.SelectedValue.ToString();
            }
            String sqlInsert = "";
            if (radioButton1.Checked)
                sqlInsert = "INSERT INTO com_cargos (IdComunidad, IdOrgano, Cargo, Baja,IdBloque) VALUES (" + id_comunidad_cargado + "," + idOrgano + ",'" + textBox_nuevo.Text  + "',0," + idBloque + ")";
            else if (radioButton2.Checked) {
                sqlInsert = "INSERT INTO com_cargos (IdComunidad, IdOrgano, Cargo, Baja,IdBloque) VALUES (" + id_comunidad_cargado + "," + idOrgano + ",'" + comboBox_sugerencia.SelectedItem.ToString() + "',0," + idBloque + ")";
            }

            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            MessageBox.Show("Cargo Insertado");
            form_anterior.cargardatagrid();
            this.Close();
        
        }

        private void buttonSeleccionarBloque_Click(object sender, EventArgs e)
        {
            BloquesForms.Bloques nueva = new BloquesForms.Bloques(this, "FormNuevoCargos", id_comunidad_cargado);
            nueva.TopMost = true;
            nueva.ControlBox = true;
            nueva.Show();
        }

        public void recogerBloque(String idBloque, String bloque)
        {
            this.idBloque = idBloque;
            textBoxBloque.Text = bloque;
        }
    }
}
