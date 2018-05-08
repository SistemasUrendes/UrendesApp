using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.EjerciciosForms
{
    public partial class Ejercicios : Form
    {
        String id_comunidad = "0";
        public Ejercicios(String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
        }

        private void Ejercicios_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String SelectSql = @"SELECT com_ejercicios.IdEjercicio, com_ejercicios.Ejercicio, com_frecuencias.Frecuencia AS Liquidaciones, com_frecuencias.Frecuencia AS FrecCuota, com_metodoscuotas.Método AS MetodoCuotas, com_ejercicios.FIni, com_ejercicios.FFin, com_ejercicios.C, com_ejercicios.Ppal FROM (com_frecuencias RIGHT JOIN (com_ejercicios LEFT JOIN com_metodoscuotas ON com_ejercicios.IdMetodoCuota = com_metodoscuotas.IdMetodoCuota) ON com_frecuencias.IdFrec = com_ejercicios.IdFrecCuota) LEFT JOIN com_frecuencias AS com_frecuencias_1 ON com_ejercicios.IdFrecLiquidacion = com_frecuencias_1.IdFrec WHERE (((com_ejercicios.IdComunidad)=" + id_comunidad + ")) ORDER BY com_ejercicios.IdEjercicio DESC;";

            dataGridView_Ejercicios.DataSource = Persistencia.SentenciasSQL.select(SelectSql);
            dataGridView_Ejercicios.Columns["IdEjercicio"].Width = 50;
            dataGridView_Ejercicios.Columns["Ejercicio"].Width = 120;
            dataGridView_Ejercicios.Columns["Ppal"].Width = 32;
            dataGridView_Ejercicios.Columns["C"].Width = 30;
        }

        private void button_Añadir_Click(object sender, EventArgs e)
        {
            FormEjerciciosAlta nueva = new FormEjerciciosAlta(this,id_comunidad);
            nueva.Show();
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            FormEjerciciosAlta nueva = new FormEjerciciosAlta(this, id_comunidad,dataGridView_Ejercicios.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este Ejercicio ?", "Borrar Ejercicio", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_ejercicios WHERE IdEjercicio =  " + dataGridView_Ejercicios.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarDatagrid();
            }
        }

        private void cerrarEjercicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlUpdate = "UPDATE com_ejercicios SET C=-1 WHERE IdEjercicio = " + dataGridView_Ejercicios.SelectedRows[0].Cells[0].Value.ToString();
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            cargarDatagrid();
        }

        private void dataGridView_Ejercicios_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_Ejercicios.HitTest(e.X, e.Y);
                dataGridView_Ejercicios.ClearSelection();
                dataGridView_Ejercicios.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }

        }

        private void impuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Impuestos.FormImpuestos nueva = new Impuestos.FormImpuestos(id_comunidad, dataGridView_Ejercicios.SelectedRows[0].Cells[0].Value.ToString(), (Convert.ToDateTime(dataGridView_Ejercicios.SelectedRows[0].Cells[5].Value.ToString()).Year).ToString());
            nueva.ControlBox = true;
            nueva.Show();
        }
    }
}
