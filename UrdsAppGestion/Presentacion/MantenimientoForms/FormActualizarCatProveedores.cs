using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Persistencia;

namespace UrdsAppGestión.Presentacion.MantenimientoForms
{
    public partial class FormActualizarCatProveedores : Form
    {
        DataTable resultado;

        public FormActualizarCatProveedores()
        {
            InitializeComponent();
        }

        private void FormActualizarCatProveedores_Load(object sender, EventArgs e)
        {
            cargarCategorias();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editarCategoria();
        }

        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInsertarCategoria nueva = new FormInsertarCategoria(this);
            nueva.Show();
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategorias.SelectedCells.Count > 0)
            {
                String idCategoria = dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString();
                String nombre = dataGridViewCategorias.SelectedRows[0].Cells[2].Value.ToString();
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar esta Categoría ?", "Borrar Categoría", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    String sqlBorrar = "DELETE FROM ctos_catentidades WHERE IdCategoria = " + idCategoria;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    cargarCategorias();
                }
                quitarPalabraClave(nombre);
            }
        }
        
        public void cargarCategorias()
        {
            resultado = Persistencia.SentenciasSQL.select(SentenciasSQL.SQL[0]);
            this.dataGridViewCategorias.DataSource = resultado;

            dataGridViewCategorias.Columns["IdCategoria"].Visible = false;
            dataGridViewCategorias.Columns["IdGrupoCat"].Visible = false;
        }
        
        private void quitarPalabraClave(String nombreBase)
        {
            String sqlSelect = "SELECT ctos_entidades.IDEntidad, ctos_entidades.PalabrasClave FROM ctos_entidades WHERE(((ctos_entidades.PalabrasClave) Like '%" + nombreBase + "%'))";
            DataTable entidades = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach (DataRow row in entidades.Rows)
            {
                String palabrasClaveUpdate = "";
                String sqlSelectPre = "SELECT ctos_entidades.PalabrasClave AS Categoría FROM ctos_entidades WHERE ctos_entidades.IDEntidad = " + row[0].ToString();
                String palabrasClave = Persistencia.SentenciasSQL.select(sqlSelectPre).Rows[0][0].ToString();
                if (palabrasClave.Length != nombreBase.Length)
                {
                    if (palabrasClave.IndexOf(nombreBase) == 0)
                    {
                        int tamaño = palabrasClave.Length - palabrasClave.IndexOf(";") - 1;
                        palabrasClaveUpdate = palabrasClave.Substring(palabrasClave.IndexOf(";") + 1, tamaño);
                    }
                    else
                    {
                        int tamaño = palabrasClave.Length - palabrasClave.IndexOf(nombreBase) - nombreBase.Length - 1;

                        if (tamaño > 0)
                        {
                            String palabrasClavePre = palabrasClave.Substring(0, palabrasClave.IndexOf(nombreBase));
                            palabrasClaveUpdate += palabrasClavePre;
                            String palabrasClavePost = palabrasClave.Substring(palabrasClave.IndexOf(nombreBase) + nombreBase.Length + 1, tamaño);
                            palabrasClaveUpdate += palabrasClavePost;
                        }
                        else
                        {
                            String palabrasClavePre = palabrasClave.Substring(0, palabrasClave.IndexOf(nombreBase) - 1);
                            palabrasClaveUpdate += palabrasClavePre;
                        }
                    }
                }
                
                String sqlUpdate = "UPDATE ctos_entidades SET PalabrasClave = '" + palabrasClaveUpdate + "' WHERE IDEntidad = " + row[0].ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
        }

        private void dataGridViewCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarCategoria();
        }

        private void editarCategoria()
        {
            if (dataGridViewCategorias.SelectedCells.Count > 0)
            {
                FormInsertarCategoria nueva = new FormInsertarCategoria(this, dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString());
                nueva.Show();
            }
        }

        private void dataGridViewCategorias_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewCategorias.HitTest(e.X, e.Y);
                //EVITAR QUE COJA LA CABECERA
                if (hti.RowIndex > -1)
                {
                    dataGridViewCategorias.ClearSelection();
                    dataGridViewCategorias.Rows[hti.RowIndex].Selected = true;
                    dataGridViewCategorias.Columns[hti.ColumnIndex].Selected = true;
                    dataGridViewCategorias.CurrentCell = this.dataGridViewCategorias[hti.ColumnIndex, hti.RowIndex];
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }
    }
}
