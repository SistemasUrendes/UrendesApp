using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    public partial class FormReglasPago : Form
    {
        String idDivision;
        String nombreDivision;
        String idComunidad;

        public FormReglasPago(String idDivision, String nombreDivision, String idComunidad)
        {
            InitializeComponent();
            this.idDivision = idDivision;
            this.nombreDivision = nombreDivision;
            this.idComunidad = idComunidad;
        }

        private void FormReglasPago_Load(object sender, EventArgs e)
        {
            cargarRepartos();
            if (dataGridView_repartos.SelectedRows.Count > 0)
                cargarDetallesRepartos();



            this.Text = "Reglas de pago División : " + nombreDivision;
        }
        public void existeReparto() {
            if (dataGridView_repartos.Rows.Count == 0)
                button_anyadirReparto.Enabled = true;
            else
                button_anyadirReparto.Enabled = false;
        }
        public void cargarRepartos() {

            //CARGAR REGLAS SEGUN LA DIVISIÓN
            String sqlSelect = "SELECT com_repartos.IdReparto, com_repartos.Descripcion, com_tipocuotas.TipoCuota, com_repartos.Act FROM com_repartos INNER JOIN com_tipocuotas ON com_repartos.IdTipoCuota = com_tipocuotas.IdTipoCuota WHERE(((com_repartos.IdDivision) = " + idDivision + "));";

            dataGridView_repartos.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_repartos.Columns["IdReparto"].Width = 50;
            dataGridView_repartos.Columns["Descripcion"].Width = 250;
            dataGridView_repartos.Columns["Act"].Width = 50;
            
            existeReparto();
        }
        public void cargarDetallesRepartos() {
            String sqlSelect = "SELECT com_detrepartos.IdDetReparto ,ctos_entidades.Entidad, com_detrepartos.Porcentaje, com_detrepartos.ImporteFijo FROM(com_detrepartos INNER JOIN com_comuneros ON com_detrepartos.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_detrepartos.IdReparto) = " + dataGridView_repartos.SelectedRows[0].Cells[0].Value.ToString() + "));";

            dataGridView_detalles_regla.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);

            dataGridView_detalles_regla.Columns["IdDetReparto"].Visible = false;
            dataGridView_detalles_regla.Columns["Entidad"].Width = 315;
            dataGridView_detalles_regla.Columns["Porcentaje"].Width = 70;
            dataGridView_detalles_regla.Columns["ImporteFijo"].Width = 70;
            dataGridView_detalles_regla.Columns["Porcentaje"].DefaultCellStyle.Format = "p";
            dataGridView_detalles_regla.Columns["Porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_detalles_regla.Columns["ImporteFijo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_detalles_regla.Columns["ImporteFijo"].DefaultCellStyle.Format = "c";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView_repartos.Rows.Count == 0)
            {
                ReglasPago.FormAnyadirRegla nueva = new ReglasPago.FormAnyadirRegla(this, idDivision, nombreDivision);
                nueva.Show();
            }else {
                MessageBox.Show("Ya existe un regla para esa división");
            }
        }

        private void dataGridView_repartos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_repartos.HitTest(e.X, e.Y);
                dataGridView_repartos.ClearSelection();
                dataGridView_repartos.Rows[hti.RowIndex].Selected = true;

                String sqlSelect = "SELECT Act FROM com_repartos WHERE IdReparto = " + dataGridView_repartos.SelectedRows[0].Cells[0].Value.ToString();
                DataTable activa = Persistencia.SentenciasSQL.select(sqlSelect);

                if (activa.Rows.Count > 0) {
                    if (activa.Rows[0][0].ToString() == "True") {
                        desactivarReglaToolStripMenuItem.Visible = true;
                        activarReglaToolStripMenuItem.Visible = false;
                    }
                    else {
                        activarReglaToolStripMenuItem.Visible = true;
                        desactivarReglaToolStripMenuItem.Visible = false;
                    }
                }
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void activarReglaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlUpdate = "UPDATE com_repartos SET Act='-1' WHERE IdReparto = " + dataGridView_repartos.SelectedRows[0].Cells[0].Value;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            int indice = dataGridView_repartos.SelectedRows[0].Index;
            cargarRepartos();
            dataGridView_repartos.Rows[indice].Selected = true;
        }

        private void desactivarReglaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlUpdate = "UPDATE com_repartos SET Act='0' WHERE IdReparto = " + dataGridView_repartos.SelectedRows[0].Cells[0].Value;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            int indice = dataGridView_repartos.SelectedRows[0].Index;
            cargarRepartos();
            dataGridView_repartos.Rows[indice].Selected = true;
        }

        private void eliminarReglaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String sqlDelete = "DELETE FROM com_repartos WHERE IdReparto = " + dataGridView_repartos.SelectedRows[0].Cells[0].Value;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
            cargarRepartos();

            if (dataGridView_repartos.Rows.Count == 0)
            {
                dataGridView_detalles_regla.DataSource = null;
                dataGridView_repartos.DataSource = null;
            }
            else
            {
                cargarRepartos();
                cargarDetallesRepartos();
            }
        }

        private void añadirDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_repartos.Rows.Count == 1)
            {
                ReglasPago.FormAnyadirReglaDetalle nueva = new ReglasPago.FormAnyadirReglaDetalle(this, dataGridView_repartos.SelectedRows[0].Cells[0].Value.ToString(),idComunidad);
                nueva.Show();
            }else {
                MessageBox.Show("Selecciona una regla primero");
            }
        }

        private void dataGridView_detalles_regla_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_detalles_regla.HitTest(e.X, e.Y);
                dataGridView_detalles_regla.ClearSelection();
                dataGridView_detalles_regla.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_repartos.Rows.Count == 1)
            {
                ReglasPago.FormAnyadirReglaDetalle nueva = new ReglasPago.FormAnyadirReglaDetalle(this, dataGridView_repartos.SelectedRows[0].Cells[0].Value.ToString(), idComunidad,dataGridView_detalles_regla.SelectedRows[0].Cells[0].Value.ToString());
                nueva.Show();
            }
            else
            {
                MessageBox.Show("Selecciona una regla primero");
            }
        }

        private void eliminarDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlDelete = "DELETE FROM com_detrepartos WHERE IdDetReparto = " + dataGridView_detalles_regla.SelectedRows[0].Cells[0].Value.ToString();
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
            cargarDetallesRepartos();
        }
    }
}

