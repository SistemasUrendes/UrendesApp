using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms
{
    public partial class FormEntradasFondos : Form
    {
        String idDetalleFondo;
        String idComunidad;
        double sumImporte = 0.00;
        double sumPendiente = 0.00;

        public FormEntradasFondos(String idComunidad, String idDetalleFondo)
        {
            InitializeComponent();
            this.idDetalleFondo = idDetalleFondo;
            this.idComunidad = idComunidad;
        }

        private void FormEntradasFondos_Load(object sender, EventArgs e)
        {
            cargarDatagrid();

            for (int a = 0; a < dataGridView_entradas.Rows.Count; a++) {
                sumImporte += Convert.ToDouble(dataGridView_entradas.Rows[a].Cells[3].Value);
                sumPendiente += Convert.ToDouble(dataGridView_entradas.Rows[a].Cells[4].Value);
            }

            textBox_importe.Text = sumImporte.ToString() + " €";
            textBox_pendiente.Text = sumPendiente.ToString() + " €";
            
        }
        private void cargarDatagrid() {
            String sqlSelect = "SELECT com_operaciones.IdOp, ctos_entidades.Entidad, com_operaciones.Descripcion, com_operaciones.ImpOp, com_operaciones.ImpOpPte FROM((com_operaciones INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion WHERE(((com_operaciones.IdSubCuenta) = 70000 Or(com_operaciones.IdSubCuenta) = 70001 Or(com_operaciones.IdSubCuenta) = 70002) AND((com_liquidaciones.IdDetalleFondo) = " + idDetalleFondo + ") AND((com_operaciones.IdComunidad) = " + idComunidad + "));";

            dataGridView_entradas.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);

            dataGridView_entradas.Columns["ImpOp"].DefaultCellStyle.Format = "c";
            dataGridView_entradas.Columns["ImpOpPte"].DefaultCellStyle.Format = "c";

        }

        private void dataGridView_entradas_DoubleClick(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView_entradas.SelectedRows[0].Cells[0].Value.ToString(), 0);
            nueva.Show();
        }
    }
}
