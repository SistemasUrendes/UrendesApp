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
    public partial class FormOrganos : Form
    {
        String id_comunidad_cargado;
        public FormOrganos(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void FormAñadirOrgano_Load(object sender, EventArgs e)
        {
            cargarOrganos();
        }
        public void cargarOrganos() {
            String sqlSelect = "SELECT IdOrgano, Nombre, Activo FROM com_organos WHERE IdComunidad = " + id_comunidad_cargado;
            DataTable tablaOrganos = Persistencia.SentenciasSQL.select(sqlSelect);

            dataGridView_organos.DataSource = tablaOrganos;
            dataGridView_organos.Columns["Nombre"].Width = 200;
            dataGridView_organos.Columns["IdOrgano"].Width = 50;
            dataGridView_organos.Columns["Activo"].Width = 60;
            
        }

        private void dataGridView_organos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)   {
                desactivarToolStripMenuItem.Visible = false;
                activarToolStripMenuItem.Visible = false;

                var hti = dataGridView_organos.HitTest(e.X, e.Y);
                dataGridView_organos.ClearSelection();
                dataGridView_organos.Rows[hti.RowIndex].Selected = true;
                if (dataGridView_organos.SelectedRows[0].Cells[2].Value.ToString() == "-1") {
                    desactivarToolStripMenuItem.Visible = true;
                }else {
                    activarToolStripMenuItem.Visible = true;
                }

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void activarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_organos.SelectedRows.Count > 0)  {
                String sqlActivar = "UPDATE com_organos SET Activo = -1 WHERE IdOrgano = " + dataGridView_organos.SelectedRows[0].Cells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlActivar);
            }else {
                MessageBox.Show("Selecciona un cargo de la lista");
            }
            cargarOrganos();
        }

        private void desactivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_organos.SelectedRows.Count > 0)  {
                String sqlActivar = "UPDATE com_organos SET Activo = 0 WHERE IdOrgano = " + dataGridView_organos.SelectedRows[0].Cells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlActivar);
            }
            else  {
                MessageBox.Show("Selecciona un cargo de la lista");
            }
            cargarOrganos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAnyadirOrgano nueva = new FormAnyadirOrgano(this,id_comunidad_cargado);
            nueva.Show();
        }
    }
}
