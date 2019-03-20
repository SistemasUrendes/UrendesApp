using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.Prueba
{
    public partial class Prueba : Form
    {
        static DataTable Pruebas;

        public Prueba()
        {
            InitializeComponent();
        }

        private void pruebaLoad(object sender, EventArgs e)
        {
            cargarPruebas();
        }

        private void cargarPruebas()
        {
            Pruebas = Persistencia.SentenciasSQL.select(Persistencia.SentenciasSQL.SQL[3]);

            dataGridView1.DataSource = Pruebas;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "#";
            //dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            //dataGridView1.Columns[9].Visible = false;


            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns["FBaja"].Visible = false;

            dataGridView1.Columns[11].HeaderText = "Gestor";
            dataGridView1.Columns[11].Width = 80;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[17].HeaderText = "Contabilidad";
            dataGridView1.Columns[17].Width = 80;
            dataGridView1.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[10].HeaderText = "Administrador";
            dataGridView1.Columns[10].Width = 80;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[1].Width = 40;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[6].Width = 140;

            dataGridView1.Columns["IdGestor"].Visible = false;
            dataGridView1.Columns["IdGestor2"].Visible = false;
            dataGridView1.Columns["IdContabilidad"].Visible = false;
        }

        private void dataGridView1_DoubleClick(Object sender, EventArgs e)
        {
            String gestor = "" +
                "SELECT Frecuencia " +
                "FROM com_frecuencias " +
                "WHERE idFrec = " + dataGridView1.SelectedCells[9].Value.ToString();
            String res = Persistencia.SentenciasSQL.select(gestor).Rows[0][0].ToString();
            Presentacion.Prueba.Prueba nueva = new Presentacion.Prueba.Prueba();
            nueva.Show();
        }
    }
}
