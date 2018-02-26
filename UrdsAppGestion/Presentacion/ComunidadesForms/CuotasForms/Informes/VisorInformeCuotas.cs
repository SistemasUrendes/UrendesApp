using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms.Informes
{
    public partial class VisorInformeCuotas : Form
    {

        public VisorInformeCuotas(String id_cuota)
        {
            InitializeComponent();
            String sql1 = "SELECT com_opdetalles.IdOpDet, com_opdetalles.IdOp, com_divisiones.Division, com_operaciones.Descripcion, com_opdetalles.IdRecibo, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte, com_recibos.ImpRbo FROM(com_divisiones INNER JOIN(com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) ON com_divisiones.IdDivision = com_operaciones.IdDivision) INNER JOIN com_recibos ON com_opdetalles.IdRecibo = com_recibos.IdRecibo WHERE(((com_operaciones.IdCuota) = " + id_cuota + ")) ORDER BY com_divisiones.Division;";

            VencimientosCuotaBindingSource.DataSource = Persistencia.SentenciasSQL.select(sql1);

        }

        private void VisorInformeCuotas_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
