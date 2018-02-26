using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    public partial class FormOperacionesComuneros : Form
    {
        String id_comunidad_cargado;
        String id_entidad_cargado;
        DataTable operacionesEntidad;

        public FormOperacionesComuneros(String id_comunidad_cargado, String id_entidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_entidad_cargado = id_entidad_cargado;
        }

        private void FormOperacionesComuneros_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String fechaInicio;
            String fechaFin;

            try
            {
                fechaInicio = (Convert.ToDateTime("1-1-" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
                fechaFin = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
            }catch {
                MessageBox.Show("La fecha no es correcta.Revisala");
                return;
            }

            String sqlSelect = "SELECT com_opdetalles.IdOp, com_opdetalles.Fecha, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte, com_opdetalles.IdRecibo FROM ctos_entidades INNER JOIN com_opdetalles ON ctos_entidades.IDEntidad = com_opdetalles.IdEntidad WHERE (((ctos_entidades.IDEntidad) = " + id_entidad_cargado + ") AND ((com_opdetalles.Fecha) <= '" + fechaFin + "' And (com_opdetalles.Fecha) >= '" + fechaInicio + "'));";

            operacionesEntidad = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_operacionesComuneros.DataSource = operacionesEntidad;
            comboBox_estado.SelectedItem = "Todo";

            maskedTextBox_inicio.Text = Convert.ToDateTime("1-1-" + DateTime.Now.Year).ToShortDateString();
            maskedTextBox_fin.Text = Convert.ToDateTime(DateTime.Now).ToShortDateString();
        }

        private void button_filtrar_Click(object sender, EventArgs e)
        {
            String fechaInicio;
            String fechaFin;
            String sqlSelect = "";

            try
            {
                fechaInicio = (Convert.ToDateTime(maskedTextBox_inicio.Text)).ToString("yyyy-MM-dd");
                fechaFin = (Convert.ToDateTime(maskedTextBox_fin.Text)).ToString("yyyy-MM-dd");
            }
            catch
            {
                MessageBox.Show("La fecha no es correcta.Revisala");
                return;
            }

            if (comboBox_estado.SelectedItem.ToString() == "Pendiente")
            {
                sqlSelect = "SELECT com_opdetalles.IdOp, com_opdetalles.Fecha, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte, com_opdetalles.IdRecibo FROM ctos_entidades INNER JOIN com_opdetalles ON ctos_entidades.IDEntidad = com_opdetalles.IdEntidad WHERE (((ctos_entidades.IDEntidad) = " + id_entidad_cargado + ") AND ((com_opdetalles.Fecha) <= '" + fechaFin + "' And (com_opdetalles.Fecha) >= '" + fechaInicio + "') AND (ImpOpDetPte > 0) );";
            }
            else if (comboBox_estado.SelectedItem.ToString() == "Cerrado")
            {
                sqlSelect = "SELECT com_opdetalles.IdOp, com_opdetalles.Fecha, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte, com_opdetalles.IdRecibo FROM ctos_entidades INNER JOIN com_opdetalles ON ctos_entidades.IDEntidad = com_opdetalles.IdEntidad WHERE (((ctos_entidades.IDEntidad) = " + id_entidad_cargado + ") AND ((com_opdetalles.Fecha) <= '" + fechaFin + "' And (com_opdetalles.Fecha) >= '" + fechaInicio + "') AND (ImpOpDetPte = 0));";
            }
            else if (comboBox_estado.SelectedItem.ToString() == "Todo")
            {
                sqlSelect = "SELECT com_opdetalles.IdOp, com_opdetalles.Fecha, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte, com_opdetalles.IdRecibo FROM ctos_entidades INNER JOIN com_opdetalles ON ctos_entidades.IDEntidad = com_opdetalles.IdEntidad WHERE (((ctos_entidades.IDEntidad) = " + id_entidad_cargado + ") AND ((com_opdetalles.Fecha) <= '" + fechaFin + "' And (com_opdetalles.Fecha) >= '" + fechaInicio + "'));";
            }

            operacionesEntidad = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_operacionesComuneros.DataSource = operacionesEntidad;
        }

        private void comboBox_estado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            if (combo.SelectedText == "Pendiente")
            {
                DataTable busqueda = operacionesEntidad;
                busqueda.DefaultView.RowFilter = "ImpOpDetPte > 0";
                this.dataGridView_operacionesComuneros.DataSource = busqueda;
            }
            else if (combo.SelectedText == "Cerrado")
            {
                DataTable busqueda = operacionesEntidad;
                busqueda.DefaultView.RowFilter = "ImpOpDetPte = 0";
                this.dataGridView_operacionesComuneros.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = operacionesEntidad;
                busqueda.DefaultView.RowFilter = "ImpOpDetPte = 0 OR ImpOpDetPte > 0 OR ImpOpDetPte < 0 ";
                this.dataGridView_operacionesComuneros.DataSource = busqueda;
            }
        }

        private void dataGridView_operacionesComuneros_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_operacionesComuneros.HitTest(e.X, e.Y);
                dataGridView_operacionesComuneros.ClearSelection();
                dataGridView_operacionesComuneros.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
