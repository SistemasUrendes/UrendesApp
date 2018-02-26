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
    public partial class FormSalidasFondos : Form
    {
        String idComunidad;
        String idDetalleFondo;
        double sumImporte = 0.00;
        double sumPendiente = 0.00;

        public FormSalidasFondos(String idComunidad, String idDetalleFondo)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idDetalleFondo = idDetalleFondo;
        }
        public void cargarDatagrid() {
            String sqlSelect = "SELECT com_operaciones.IdOp, ctos_entidades.Entidad, com_operaciones.Descripcion, com_operaciones.ImpOp, com_operaciones.ImpOpPte FROM((com_operaciones INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion WHERE(((com_operaciones.IdSubCuenta) >= 60000 And(com_operaciones.IdSubCuenta) <= 69999) AND((com_liquidaciones.IdDetalleFondo) = " + idDetalleFondo + ") AND((com_operaciones.IdComunidad) = " + idComunidad + "));";

            dataGridView_salidas.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);

            dataGridView_salidas.Columns["ImpOp"].DefaultCellStyle.Format = "c";
            dataGridView_salidas.Columns["ImpOpPte"].DefaultCellStyle.Format = "c";

        }

        private void FormSalidasFondos_Load(object sender, EventArgs e)
        {
            cargarDatagrid();

            for (int a = 0; a < dataGridView_salidas.Rows.Count; a++)
            {
                sumImporte += Convert.ToDouble(dataGridView_salidas.Rows[a].Cells[3].Value);
                sumPendiente += Convert.ToDouble(dataGridView_salidas.Rows[a].Cells[4].Value);
            }

            textBox_importe.Text = sumImporte.ToString() + " €";
            textBox_pendiente.Text = sumPendiente.ToString() + " €";
        }

        private void dataGridView_salidas_DoubleClick(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView_salidas.SelectedRows[0].Cells[0].Value.ToString(),0);
            nueva.Show();
        }
    }
}
