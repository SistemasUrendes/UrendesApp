using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.MantenimientoForms
{
    public partial class FormBorradoMultiple : Form
    {
        DataTable filas_pegadas = new DataTable();
        public FormBorradoMultiple()
        {
            InitializeComponent();
            label3.Visible = false;
        }

        private void dataGridView_idBorrar_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.V)
            {
                filas_pegadas.Columns.Clear();
                filas_pegadas.Columns.Add(textBox_campo.Text);

                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');

                foreach (string line in lines)
                {
                    DataRow row2 = filas_pegadas.NewRow();
                    if (line.Length > 0)
                    {
                        string[] cells = line.Split('\t');
                        for (int i = 0; i < cells.GetLength(0); ++i)
                        {
                            row2[i] = cells[i];
                        }
                    }
                    else
                    {
                        break;
                    }
                    filas_pegadas.Rows.Add(row2);
                }
            }
            dataGridView_idBorrar.DataSource = filas_pegadas;
            label3.Visible = true;
            label3.Text = dataGridView_idBorrar.Rows.Count.ToString();

        }
        private void button_borrar_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = dataGridView_idBorrar.Rows.Count;

            if (textBox_campo.Text != "" && textBox_nombre_tabla.Text != "") {
                for (int a = 0; a < dataGridView_idBorrar.Rows.Count; a++) {

                    String sqlDelete = "DELETE FROM " + textBox_nombre_tabla.Text + " WHERE " + textBox_campo.Text + " = " + dataGridView_idBorrar.Rows[a].Cells[0].Value.ToString().Replace("\r","");

                    //MessageBox.Show(sqlDelete);
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
                    progressBar1.Value = a;
                }
            }else {
                MessageBox.Show("Rellena los dos campos");
            }
        }
    }
}
