using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.Impuestos
{
    public partial class FormImpuestos : Form
    {
        String idComunidad;
        String idEjercicio = "";
        String anyo;

        public FormImpuestos(String idComunidad,String idEjercicio, String anyo)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idEjercicio = idEjercicio;
            this.anyo = anyo;
        }

        public void cargarDatagrid() {

            String fechaInicio = (Convert.ToDateTime("01/01/" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
            String fechaFin = (Convert.ToDateTime("30/03/" + DateTime.Now.Year)).ToString("yyyy-MM-dd");

            String sqlSelect = "SELECT com_operaciones.IdOp, com_operaciones.Documento, ctos_entidades.Entidad, ctos_entidades.CIF, com_operaciones.Descripcion, DATE_FORMAT(Coalesce(com_opdetalles.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_operaciones.Retencion, com_operaciones.BaseRet, aux_retencion.`%Retencion` AS Retención, com_operaciones.ImpuestoLiquidado AS Informado FROM aux_retencion INNER JOIN (ctos_entidades INNER JOIN(com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) ON ctos_entidades.IDEntidad = com_operaciones.IdEntidad) ON aux_retencion.IdRetencion = com_operaciones.IdRetencion GROUP BY com_operaciones.IdOp, com_operaciones.Documento, ctos_entidades.Entidad, ctos_entidades.CIF, com_operaciones.Descripcion, com_opdetalles.Fecha, com_operaciones.Retencion, com_operaciones.BaseRet, aux_retencion.`%Retencion`, com_operaciones.ImpuestoLiquidado, com_operaciones.IdComunidad HAVING(((com_opdetalles.Fecha) >'" + fechaInicio + "' AND (com_opdetalles.Fecha) < '" + fechaFin + "') AND ((com_operaciones.Retencion)>0) AND ((com_operaciones.IdComunidad)=" + idComunidad + "));";

            DataTable impuestos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_impuestos.DataSource = impuestos;
            ajustarDatagrid();
        }

        private void FormImpuestos_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
            comboBox_liquidaciones.SelectedItem = 0;
        }

        private void comboBox_liquidaciones_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String fechaInicio = "0";
            String fechaFin = "0";

            if (comboBox_liquidaciones.SelectedIndex == 0) {
                fechaInicio = (Convert.ToDateTime("01/01/"+ DateTime.Now.Year)).ToString("yyyy-MM-dd");
                fechaFin = (Convert.ToDateTime("30/03/" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
            }
            else if (comboBox_liquidaciones.SelectedIndex == 1)
            {
                fechaInicio = (Convert.ToDateTime("01/04/" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
                fechaFin = (Convert.ToDateTime("30/06/" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
            }
            else if (comboBox_liquidaciones.SelectedIndex == 3)
            {
                fechaInicio = (Convert.ToDateTime("01/07/" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
                fechaFin = (Convert.ToDateTime("30/09/" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
            }
            else if (comboBox_liquidaciones.SelectedIndex == 4)
            {
                fechaInicio = (Convert.ToDateTime("01/10/" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
                fechaFin = (Convert.ToDateTime("30/12/" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
            }


            String sqlSelect = "SELECT com_operaciones.IdOp, com_operaciones.Documento, ctos_entidades.Entidad, ctos_entidades.CIF, com_operaciones.Descripcion,  DATE_FORMAT(Coalesce(com_opdetalles.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_operaciones.Retencion, com_operaciones.BaseRet, aux_retencion.`%Retencion` AS Retención, com_operaciones.ImpuestoLiquidado AS Informado FROM aux_retencion INNER JOIN (ctos_entidades INNER JOIN(com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) ON ctos_entidades.IDEntidad = com_operaciones.IdEntidad) ON aux_retencion.IdRetencion = com_operaciones.IdRetencion GROUP BY com_operaciones.IdOp, com_operaciones.Documento, ctos_entidades.Entidad, ctos_entidades.CIF, com_operaciones.Descripcion, com_opdetalles.Fecha, com_operaciones.Retencion, com_operaciones.BaseRet, aux_retencion.`%Retencion`, com_operaciones.ImpuestoLiquidado, com_operaciones.IdComunidad HAVING(((com_opdetalles.Fecha) >'" + fechaInicio + "' AND (com_opdetalles.Fecha) < '" + fechaFin + "') AND ((com_operaciones.Retencion)>0) AND ((com_operaciones.IdComunidad)=" + idComunidad + "));";

            DataTable impuestos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_impuestos.DataSource = impuestos;
            ajustarDatagrid();
        }
        private void ajustarDatagrid() {
            dataGridView_impuestos.Columns["Entidad"].Width = 200;
            dataGridView_impuestos.Columns["Descripcion"].Width = 200;
            dataGridView_impuestos.Columns["IdOp"].Width = 60;
            dataGridView_impuestos.Columns["Informado"].Width = 50;
            dataGridView_impuestos.Columns["Retención"].HeaderText = "%";
            dataGridView_impuestos.Columns["BaseRet"].DefaultCellStyle.Format = "c";
            dataGridView_impuestos.Columns["Retencion"].DefaultCellStyle.Format = "c";
            dataGridView_impuestos.Columns["Retencion"].Width = 60;
        }

        private void marcarComoLiquidableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlUpdate;
            if (dataGridView_impuestos.SelectedRows[0].Cells[9].Value.ToString() == "-1") {
                sqlUpdate = "UPDATE com_operaciones SET ImpuestoLiquidado = 0 WHERE IdOp = " + dataGridView_impuestos.SelectedRows[0].Cells[0].Value.ToString();
            }
            else {
                sqlUpdate = "UPDATE com_operaciones SET ImpuestoLiquidado = -1 WHERE IdOp = " + dataGridView_impuestos.SelectedRows[0].Cells[0].Value.ToString();
            }

            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            MessageBox.Show("Marcada");
            cargarDatagrid();
        }

        private void dataGridView_impuestos_DoubleClick(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView_impuestos.SelectedRows[0].Cells[0].Value.ToString(),0);
            nueva.Show();
        }

        private void dataGridView_impuestos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_impuestos.HitTest(e.X, e.Y);
                dataGridView_impuestos.ClearSelection();
                dataGridView_impuestos.Rows[hti.RowIndex].Selected = true;
                verTodasDeToolStripMenuItem.Text = "Ver todas de: " + dataGridView_impuestos.SelectedRows[0].Cells[2].Value;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void verTodasDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Impuestos.FormImpuestoDetalle nueva = new FormImpuestoDetalle(dataGridView_impuestos.SelectedRows[0].Cells[0].Value.ToString(),(DataTable)dataGridView_impuestos.DataSource);
            nueva.Show();
        }

        private void comboBox_informes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_informes.SelectedIndex == 0) {
                Informes.FormVerInforme nueva = new Informes.FormVerInforme((DataTable)dataGridView_impuestos.DataSource);
                nueva.Show();
            }
        }
    }
}
