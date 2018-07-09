using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms.InformeParticularReciboIVA
{
    public partial class FormVerInformeLiquidacionIVA : Form
    {
        public FormVerInformeLiquidacionIVA(String IdLiquidacion, String IdEntidad)
        {
            InitializeComponent();
            String sqlSelect = "SELECT com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.Importe, com_subcuotas.Parte FROM com_subcuotas INNER JOIN (com_opdetliquidacion INNER JOIN com_liqreparto ON com_opdetliquidacion.IdLiquidacion = com_liqreparto.IdLiquidacion) ON(com_subcuotas.IdDivision = com_liqreparto.IdDivision) AND(com_subcuotas.IdBloque = com_liqreparto.IdBloque) GROUP BY com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.Importe, com_subcuotas.Parte, com_opdetliquidacion.IdLiquidacion, com_liqreparto.IdTitular HAVING(((com_opdetliquidacion.IdLiquidacion) = " + IdLiquidacion + ") AND((com_liqreparto.IdTitular) = " + IdEntidad + "));";

            DivisionLiquidacionBindingSource.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);


        }

        private void FormVerInformeLiquidacionIVA_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
