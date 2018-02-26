using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    public partial class FormOperacionesEleccionFavorita : Form
    {
        String id_comunidad = "0";
        DataTable favoritas = null;
        DataTable entidades_favo;
        String textoBuscar = "";

        public FormOperacionesEleccionFavorita(String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
        }
        public FormOperacionesEleccionFavorita(String id_comunidad,String textoBuscar)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.textoBuscar = textoBuscar;
        }

        private void FormOperacionesEleccionFavorita_Load(object sender, EventArgs e)
        {
            textBox_buscar.Select();
            cargarBloques();
            cargardatagrid();

            if (listBox_bloques.Items.Count > 0)
                listBox_bloques.SelectedIndex = 0;
            cargarFavoritas();
            if (textoBuscar != "")
                textBox_buscar.Text = textoBuscar;
        }
        public void cargardatagrid()
        {
            if (id_comunidad != "0") {
                String sqlSelect = "SELECT com_opfavoritas.IdOpFav, com_opfavoritas.NomFavo, com_opfavoritas.FechaFavo, com_opfavoritas.ImpFavo FROM com_opfavoritas WHERE(((com_opfavoritas.IdComunidad) = " + id_comunidad + ")); ";

                favoritas = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_favoritas.DataSource = favoritas;


                dataGridView_favoritas.Columns[0].Width = 40;
                dataGridView_favoritas.Columns[1].Width = 260;
                dataGridView_favoritas.Columns[3].Width = 160;
            }
        }

        public void cargarBloques()
        {
            if (id_comunidad != "0")
            {
                //String sqlSelect = "SELECT com_bloques.IdBloque, com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdComunidad) = " + id_comunidad + ") AND((com_bloques.IdTipoBloque) = 1)); ";
                //listBox_bloques.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
                //listBox_bloques.DisplayMember = "Descripcion";
                //listBox_bloques.ValueMember = "IdBloque";

                String sqlSelect = "SELECT com_operaciones.IdEntidad, ctos_entidades.Entidad FROM(com_opfavoritas INNER JOIN com_operaciones ON com_opfavoritas.IdOp = com_operaciones.IdOp) INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad GROUP BY com_operaciones.IdEntidad, ctos_entidades.Entidad, com_opfavoritas.IdComunidad HAVING(((com_opfavoritas.IdComunidad) = " + id_comunidad + "));";
                entidades_favo = Persistencia.SentenciasSQL.select(sqlSelect);
                listBox_bloques.DataSource = entidades_favo;
                listBox_bloques.DisplayMember = "Entidad";
                listBox_bloques.ValueMember = "IdEntidad";

            }
            
        }
        private void cargarFavoritas() {
            if (id_comunidad != "0" && listBox_bloques.Items.Count > 0 && !listBox_bloques.SelectedValue.ToString().Contains("System") )
            {
                String sqlSelect = "SELECT com_opfavoritas.IdOpFav, com_opfavoritas.NomFavo, com_opfavoritas.FechaFavo, com_opfavoritas.ImpFavo FROM com_opfavoritas INNER JOIN com_operaciones ON com_opfavoritas.IdOp = com_operaciones.IdOp WHERE(((com_operaciones.IdEntidad) = " + listBox_bloques.SelectedValue.ToString() + ") AND((com_opfavoritas.IdComunidad) = " + id_comunidad + "));";

                favoritas = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_favoritas.DataSource = favoritas;


                dataGridView_favoritas.Columns[0].Width = 40;
                dataGridView_favoritas.Columns[1].Width = 260;
                dataGridView_favoritas.Columns[3].Width = 160;
            }else {
                dataGridView_favoritas.DataSource = null;
            }

            if (dataGridView_favoritas.Rows.Count > 0)
            {
                dataGridView_favoritas.Rows[0].Selected = true;
            }
        }
        private void listBox_bloques_SelectedIndexChanged(object sender, EventArgs e)
        {
                 cargarFavoritas();
        }

        private void textBox_buscar_TextChanged(object sender, EventArgs e)
        {
            if (textBox_buscar.TextLength < 2)
            {
                DataTable busqueda = entidades_favo;
                busqueda.DefaultView.RowFilter = "Entidad like '%%'";
                listBox_bloques.DataSource = busqueda;
                //cargardatagrid();
                if (listBox_bloques.Items.Count > 0)
                    listBox_bloques.SelectedIndex = 0;
                cargarFavoritas();
            }
            else
            {
                DataTable busqueda = entidades_favo;
                busqueda.DefaultView.RowFilter = "Entidad like '%" + textBox_buscar.Text + "%'";
                listBox_bloques.DataSource = busqueda;
                cargarFavoritas();
            }
            if (listBox_bloques.Items.Count > 0)
                listBox_bloques.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            siguiente();
        }
        private void siguiente() {
            FormOperacionesAjustarFavorita nueva = new FormOperacionesAjustarFavorita(dataGridView_favoritas.SelectedRows[0].Cells[0].Value.ToString(),textBox_buscar.Text);
            nueva.Show();
            this.Close();
        }

        private void dataGridView_favoritas_KeyPress(object sender, KeyPressEventArgs e)
        {   

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlDelete = "DELETE FROM com_opfavoritas WHERE IdOpFav = " + dataGridView_favoritas.SelectedRows[0].Cells[0].Value.ToString();
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
            cargarFavoritas();
            MessageBox.Show("Favorita Borrada");
        }

        private void dataGridView_favoritas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_favoritas.HitTest(e.X, e.Y);
                dataGridView_favoritas.ClearSelection();
                dataGridView_favoritas.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void FormOperacionesEleccionFavorita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                siguiente();
            }
        }

        private void dataGridView_favoritas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                siguiente();
            }
        }

        private void listBox_bloques_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                siguiente();
            }
        }

        private void textBox_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                siguiente();
            }
        }
    }
}
