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
        DataTable tablaBloques;
        DataTable tablaAreas;

        public FormServiciosConfiguracion()
        {
            InitializeComponent();
            
        }

        private void FormServiciosConfiguracion_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
            cargarCategorias();
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
           
            String sqlSelect = "SELECT com_bloques.IdBloque,com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdTipoBloque) = 1) AND((com_bloques.IdComunidad) = " + idComunidad + "))";
            tablaBloques = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewBloque.DataSource = tablaBloques;

            if (dataGridViewBloque.Rows.Count > 0)
            {
                dataGridViewBloque.Columns["IdBloque"].Visible = false;
                dataGridViewBloque.Columns["Descripcion"].Width = 350;
            }
        }

        public void cargarBloques()
        {
            String sqlSelect = "SELECT com_bloques.IdBloque,com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdTipoBloque) = 1) AND ((com_bloques.Baja) = 0) AND((com_bloques.IdComunidad) = " + this.idComunidad + "))";
            tablaBloques = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewBloque.DataSource = tablaBloques;

            if (dataGridViewBloque.Rows.Count > 0)
            {
                dataGridViewBloque.Columns["IdBloque"].Visible = false;
                dataGridViewBloque.Columns["Descripcion"].Width = 350;
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
            /*
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
            */
        }

        private void buttonAddArea_Click(object sender, EventArgs e)
        {
            FormInsertarArea nueva = new FormInsertarArea(this);
            nueva.Show();
        }

        private void textBoxFiltroBloque_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = tablaBloques;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroBloque.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewBloque.DataSource = busqueda;
        }

        private void dataGridViewBloque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewBloque.SelectedRows[0].Index > -1)
            {
                FormArbolAreasBloque nueva = new FormArbolAreasBloque(this, dataGridViewBloque.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloque.SelectedRows[0].Cells[1].Value.ToString(), comboBoxComunidades.Text.ToString());
                nueva.Show();
            }
        }

        public void cargarCategorias()
        {
            String sqlSelect = "SELECT IdCatElemento,Nombre,NombreCorto AS 'Abr.',Descripcion FROM exp_catElemento";
            tablaAreas = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewAreas.DataSource = tablaAreas;
            if (dataGridViewAreas.Rows.Count > 0)
            {
                dataGridViewAreas.Columns["IdCatElemento"].Visible = false;
                dataGridViewAreas.Columns["Nombre"].Width = 100;
                dataGridViewAreas.Columns["Abr."].Width = 50;
                dataGridViewAreas.Columns["Descripcion"].Width = 130;
            }
        }

        private void textBoxAreas_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = tablaAreas;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxAreas.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewAreas.DataSource = busqueda;
        }

        private void dataGridViewAreas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String nombre = dataGridViewAreas.SelectedRows[0].Cells[1].Value.ToString() + " (" + dataGridViewAreas.SelectedRows[0].Cells[2].Value.ToString() + ")";
            ComunidadesForms.Elementos.FormElementos nueva = new ComunidadesForms.Elementos.FormElementos(this,dataGridViewAreas.SelectedRows[0].Cells[0].Value.ToString(), nombre);
            nueva.Show();
        }

        private void cambiarNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInsertarArea nueva = new FormInsertarArea(this, dataGridViewAreas.SelectedRows[0].Cells[0].Value.ToString());
            nueva.Show();
        }

        private void borrarCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta Categoría ?", "Borrar Categoría", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM exp_catElemento WHERE IdCatElemento = " + dataGridViewAreas.SelectedRows[0].Cells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarCategorias();
            }
        }

        private void dataGridViewAreas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewAreas.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    dataGridViewAreas.ClearSelection();
                    dataGridViewAreas.Rows[hti.RowIndex].Selected = true;
                    dataGridViewAreas.Columns[hti.ColumnIndex].Selected = true;
                    contextMenuStrip2.Show(Cursor.Position);
                }
            }
        }

        private void buttonActualizarClave_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT exp_area.IdArea, exp_area.codigoArea FROM exp_area";
            DataTable claveOld = Persistencia.SentenciasSQL.select(sqlSelect);
            int count = 0;
            foreach ( DataRow row in claveOld.Rows)
            {
                String sqlUpdate = "UPDATE exp_area SET codigoArea = '0" + row[1] + "' WHERE IdArea = '" + row[0] + "'";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                count++;
            }

            MessageBox.Show(count + "Bloques actualizados");

        }
    }
}
