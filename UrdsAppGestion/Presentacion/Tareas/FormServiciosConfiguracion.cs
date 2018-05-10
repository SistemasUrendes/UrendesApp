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
    public partial class FormServiciosConfiguracion : Form
    {
        String idComunidad;
        public FormServiciosConfiguracion()
        {
            InitializeComponent();
        }

        private void FormServiciosConfiguracion_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
        }

        private void rellenarComboBox()
        {
            DataTable comunidades;
            String sqlComboTipo = "SELECT com_comunidades.IdComunidad, ctos_entidades.NombreCorto FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.FBaja)Is Null))";
            comunidades = Persistencia.SentenciasSQL.select(sqlComboTipo);

            comboBoxComunidades.DataSource = comunidades;
            comboBoxComunidades.DisplayMember = "NombreCorto";
            comboBoxComunidades.ValueMember = "IdComunidad";
        }

        private void buttonAddBloque_Click(object sender, EventArgs e)
        {
            FormInsertarBloque nueva = new FormInsertarBloque(this, comboBoxComunidades.SelectedValue.ToString());
            nueva.Show();
        }

        private void comboBoxComunidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idComunidad = comboBoxComunidades.SelectedValue.ToString();
            cargarBloques();
        }

        public void cargarBloques(String idComunidad)
        {
            DataTable bloques;
            String sqlSelect = "SELECT exp_elementos.IdElemento, exp_elementos.Nombre, exp_elementos.Descripcion FROM exp_elementos WHERE(((exp_elementos.IdComunidad) = " + idComunidad + "))";
            bloques = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewBloque.DataSource = bloques;

            if (dataGridViewBloque.Rows.Count > 0)
            {
                dataGridViewBloque.Columns["IdElemento"].Visible = false;
                dataGridViewBloque.Columns["Nombre"].Width = 100;
                dataGridViewBloque.Columns["Descripcion"].Width = 250;
            }
        }

        public void cargarBloques()
        {
            DataTable bloques;
            String sqlSelect = "SELECT exp_elementos.IdElemento, exp_elementos.Nombre, exp_elementos.Descripcion FROM exp_elementos WHERE(((exp_elementos.IdComunidad) = " + this.idComunidad + "))";
            bloques = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewBloque.DataSource = bloques;

            if (dataGridViewBloque.Rows.Count > 0)
            {
                dataGridViewBloque.Columns["IdElemento"].Visible = false;
                dataGridViewBloque.Columns["Nombre"].Width = 100;
                dataGridViewBloque.Columns["Descripcion"].Width = 250;
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este Bloque ?", "Borrar Bloque", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM exp_elementos WHERE IdElemento = " + dataGridViewBloque.SelectedRows[0].Cells[0].Value.ToString() ;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarBloques();
            }
        }
        
        private void dataGridViewBloque_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewBloque.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    dataGridViewBloque.ClearSelection();
                    dataGridViewBloque.Rows[hti.RowIndex].Selected = true;
                    dataGridViewBloque.Columns[hti.ColumnIndex].Selected = true;
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void buttonAddArea_Click(object sender, EventArgs e)
        {

        }
    }
}
