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
    public partial class FormOrdenarTelefonos : Form
    {
        String idEntidad;
        String nombre;
        DataTable telefonos;
        VerEntidad formAnt;
        public FormOrdenarTelefonos(VerEntidad formAnt,String idEntidad,String nombre)
        {
            InitializeComponent();
            this.idEntidad = idEntidad;
            this.nombre = nombre;
            this.formAnt = formAnt;
        }

        private void FormOrdenarTelefonos_Load(object sender, EventArgs e)
        {
            cargarTelefonos();
            labelEntidad.Text = "Entidad: " + nombre;
        }


        private void cargarTelefonos()
        {
            String sqlTelefonos = "SELECT IdDetTelf,Descripcion,Telefono,Orden FROM ctos_dettelf WHERE ctos_dettelf.IdEntidad = '" + idEntidad + "' ORDER BY Orden";
            telefonos = Persistencia.SentenciasSQL.select(sqlTelefonos);
            
            dataGridView_telefonos.DataSource = telefonos;

            dataGridView_telefonos.Columns[0].Visible = false;
            dataGridView_telefonos.Columns[1].Width = 300;
            dataGridView_telefonos.Columns[2].Width = 90;
            dataGridView_telefonos.Columns[3].Width = 40;

            //FORMATEO EL TELEFONO CON ESPACIOS PARA QUE SE PUEDA VER MEJOR
            for (int a = 0; a < dataGridView_telefonos.RowCount; a++)
            {
                try
                {
                    String telefono = dataGridView_telefonos.Rows[a].Cells[2].Value.ToString().Replace(" ", "");
                    dataGridView_telefonos.Rows[a].Cells[2].Value = String.Format("{0:###-###-###}", double.Parse(telefono));
                }
                catch (Exception)
                {
                    MessageBox.Show("Hay un teléfono incorrecto. ¡Revisar!");
                    continue;
                }
            }
        }

        private void buttonSubir_Click(object sender, EventArgs e)
        {
            //PRIMERO
            if (dataGridView_telefonos.SelectedRows[0].Cells["Orden"].Value.ToString() == "1") return;
            //SEGUNDO
            else if (dataGridView_telefonos.SelectedRows[0].Cells["Orden"].Value.ToString() == "2")
            {
                quitarPrincipal(dataGridView_telefonos.Rows[0].Cells[0].Value.ToString());
                ponerPrincipal(dataGridView_telefonos.Rows[1].Cells[0].Value.ToString());
                cargarTelefonos();
                formAnt.cargaTelefonos();
                dataGridView_telefonos.ClearSelection();
                dataGridView_telefonos.Rows[0].Selected = true;
            }
            //GENERAL
            else
            {
                String ordenAnt = dataGridView_telefonos.SelectedRows[0].Cells["Orden"].Value.ToString();
                int ordenN = Int32.Parse(ordenAnt) - 1;
                actualizarOrden(dataGridView_telefonos.Rows[ordenN-1].Cells["IdDetTelf"].Value.ToString(), ordenAnt);
                actualizarOrden(dataGridView_telefonos.SelectedRows[0].Cells["IdDetTelf"].Value.ToString(), ordenN.ToString());
                cargarTelefonos();
                formAnt.cargaTelefonos();
                dataGridView_telefonos.ClearSelection();
                dataGridView_telefonos.Rows[ordenN-1].Selected = true;
            }
        }

        private void buttonBajar_Click(object sender, EventArgs e)
        {
            //ÚLTIMO
            if (dataGridView_telefonos.SelectedRows[0].Cells["Orden"].Value.ToString() == (dataGridView_telefonos.Rows.Count).ToString() ) return;
            //PRIMERO
            else if (dataGridView_telefonos.SelectedRows[0].Cells["Orden"].Value.ToString() == "1")
            {
                quitarPrincipal(dataGridView_telefonos.Rows[0].Cells[0].Value.ToString());
                ponerPrincipal(dataGridView_telefonos.Rows[1].Cells[0].Value.ToString());
                cargarTelefonos();
                formAnt.cargaTelefonos();
                dataGridView_telefonos.ClearSelection();
                dataGridView_telefonos.Rows[1].Selected = true;
            }
            //GENERAL
            else
            {
                String ordenAnt = dataGridView_telefonos.SelectedRows[0].Cells["Orden"].Value.ToString();
                int ordenN = Int32.Parse(ordenAnt) + 1;
                actualizarOrden(dataGridView_telefonos.Rows[Int32.Parse(ordenAnt)].Cells["IdDetTelf"].Value.ToString(), ordenAnt);
                actualizarOrden(dataGridView_telefonos.SelectedRows[0].Cells["IdDetTelf"].Value.ToString(), ordenN.ToString());
                cargarTelefonos();
                formAnt.cargaTelefonos();
                dataGridView_telefonos.ClearSelection();
                dataGridView_telefonos.Rows[Int32.Parse(ordenAnt)].Selected = true;
            }
        }

        private void quitarPrincipal(String idDetTelf)
        {
            String sqlUpdate = "UPDATE ctos_dettelf SET Ppal = 0,Orden = 2 WHERE IdDetTelf = " + idDetTelf;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
        }

        private void ponerPrincipal(String idDetTelf)
        {
            String sqlUpdate = "UPDATE ctos_dettelf SET Ppal = -1,Orden = 1 WHERE IdDetTelf = " + idDetTelf;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
        }

        private void actualizarOrden(String idDetTelf, String orden)
        {
            String sqlUpdate = "UPDATE ctos_dettelf SET Orden = '" + orden + "' WHERE IdDetTelf = " + idDetTelf;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
        }
    }
}
