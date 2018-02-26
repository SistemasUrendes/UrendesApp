using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    public partial class ComprobarEntidad : Form
    {
        DataTable datos = null;
        public ComprobarEntidad(DataTable datos)
        {
            this.datos = Persistencia.SentenciasSQL.select(Persistencia.SentenciasSQL.SQL[1]);
            //this.datos = datos;
            //MessageBox.Show(datos.Rows.Count.ToString());
            InitializeComponent();
        }

        private void ajustarDatagrid()
        {
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[2].Visible = true;
            //dataGridView1.Columns[6].Visible = false;
            //dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 415;
            //dataGridView1.Columns[5].Visible = false;
            //dataGridView1.Columns[7].Visible = false;
        }

        private void button_añadir_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0) {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("Existe alguna entidad con un nombre parecido. \n\n¿Desea continuar?", "Existe Entidad", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK) {      
                    AddEntidad nueva = new AddEntidad(this.textBox_nombre.Text, this.textBox_nombrecorto.Text);
                    this.Close();
                    nueva.Show();
                }
            }
            else {
                AddEntidad nueva = new AddEntidad(this.textBox_nombre.Text,this.textBox_nombrecorto.Text);
                this.Close();   
                nueva.Show();
            }
        }

        private void textBox_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            String[] nombres_separados_largo = textBox_nombre.Text.Split(' ');

            if (e.KeyChar == Convert.ToChar(Keys.Back) && textBox_nombre.TextLength == 1)
            {
                this.dataGridView1.DataSource = null;
            }
            else if (textBox_nombre.TextLength > 2)
            {

                this.dataGridView1.DataSource = null;
                DataTable busqueda = datos;

                if (nombres_separados_largo.Length == 3)
                {
                    busqueda.DefaultView.RowFilter = "Entidad like '%" + nombres_separados_largo[0] + "%' OR Entidad like '%" + nombres_separados_largo[1] + "%' OR Entidad like '%" + nombres_separados_largo[2] + "%'";
                }
                else if (nombres_separados_largo.Length == 2)
                {
                    busqueda.DefaultView.RowFilter = "Entidad like '%" + nombres_separados_largo[0] + "%' OR Entidad like '%" + nombres_separados_largo[1] + "%'";
                }
                else if (nombres_separados_largo.Length == 1)
                {
                    busqueda.DefaultView.RowFilter = "Entidad like '%" + nombres_separados_largo[0] + "%'";
                }
                this.dataGridView1.DataSource = busqueda;
                ajustarDatagrid();
            }
        }

        private void textBox_nombrecorto_KeyPress(object sender, KeyPressEventArgs e)
        {
            String[] nombres_separados = textBox_nombrecorto.Text.Split(' ');

            if (e.KeyChar == Convert.ToChar(Keys.Back) && textBox_nombrecorto.TextLength == 1)
            {
                this.dataGridView1.DataSource = null;
            }
            else if (textBox_nombrecorto.TextLength > 2)
            {
                if (textBox_nombre.TextLength > 2)
                {
                    this.dataGridView1.DataSource = null;
                        DataTable busqueda = datos;

                        if (nombres_separados.Length == 3)
                        {
                            busqueda.DefaultView.RowFilter = "NombreCorto like '%" + nombres_separados[0] + "%' OR NombreCorto like '%" + nombres_separados[1] + "%' OR NombreCorto like '%" + nombres_separados[2] + "%'";
                        }
                        else if (nombres_separados.Length == 2)
                        {
                            busqueda.DefaultView.RowFilter = "NombreCorto like '%" + nombres_separados[0] + "%' OR NombreCorto like '%" + nombres_separados[1] + "%'";
                        }
                        else if (nombres_separados.Length == 1)
                        {
                            busqueda.DefaultView.RowFilter = "NombreCorto like '%" + nombres_separados[0] + "%'";
                        }
                        this.dataGridView1.DataSource = busqueda;
                        ajustarDatagrid();
                }
                else
                {
                    DataTable busqueda = datos;

                    if (nombres_separados.Length == 3) {
                        busqueda.DefaultView.RowFilter = "NombreCorto like '%" + nombres_separados[0] + "%' OR NombreCorto like '%" + nombres_separados[1] + "%' OR NombreCorto like '%" + nombres_separados[2] + "%'";
                    }
                    else if (nombres_separados.Length == 2) {
                        busqueda.DefaultView.RowFilter = "NombreCorto like '%" + nombres_separados[0] + "%' OR NombreCorto like '%" + nombres_separados[1] + "%'";
                    }else if (nombres_separados.Length == 1) {
                        busqueda.DefaultView.RowFilter = "NombreCorto like '%" + nombres_separados[0] + "%'";
                    }
                        this.dataGridView1.DataSource = busqueda;
                        ajustarDatagrid();
                }
            }
        }

        private void button_abrir_Click(object sender, EventArgs e)
        {
            VerEntidad ver = new VerEntidad((int)dataGridView1.SelectedCells[0].Value);
            ver.Show();
        }


        private void textBox_nombre_Leave(object sender, EventArgs e)
        {
            textBox_nombrecorto.Text = textBox_nombre.Text;
            textBox_nombrecorto.SelectAll();
        }

        private void ComprobarEntidad_Load(object sender, EventArgs e)
        {
            //this.datos = Persistencia.SentenciasSQL.select(Persistencia.SentenciasSQL.SQL[1]);
            //dataGridView1.DataSource = datos;
        }

        private void textBox_nombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
