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
    public partial class FormCertificadoDeudasDivision : Form
    {
        String idDivision;

        public FormCertificadoDeudasDivision(String idDivision)
        {
            InitializeComponent();
            this.idDivision = idDivision;

        }

        private void FormCertificadoDeudasDivision_Load(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_operaciones.IdDivision, com_opdetalles.IdOp, com_operaciones.Fecha, com_operaciones.Descripcion AS Concepto, com_operaciones.IdEntidad AS Titular, ctos_entidades_1.Entidad AS NTitular, com_opdetalles.IdOpDet, com_opdetalles.IdRecibo, com_opdetalles.IdEntidad AS Pagador, ctos_entidades.Entidad AS NPagador, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte FROM(((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_entidades AS ctos_entidades_1 ON com_operaciones.IdEntidad = ctos_entidades_1.IDEntidad) LEFT JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota WHERE(((com_operaciones.IdDivision) = " + idDivision + ") AND((com_opdetalles.ImpOpDetPte) <> 0) AND((com_opdetalles.IdEstado) < 3));";

            dataGridView_dedudasCertificado.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            ajustarDatagrid();

        }
        private void ajustarDatagrid () {

            dataGridView_dedudasCertificado.Columns["IdOp"].Width = 50;
            dataGridView_dedudasCertificado.Columns["Fecha"].Width = 70;
            dataGridView_dedudasCertificado.Columns["Concepto"].Width = 150;
            dataGridView_dedudasCertificado.Columns["NTitular"].Width = 150;
            dataGridView_dedudasCertificado.Columns["NPagador"].Width = 150;
            dataGridView_dedudasCertificado.Columns["Importe"].DefaultCellStyle.Format = "c";
            dataGridView_dedudasCertificado.Columns["ImpOpDetPte"].DefaultCellStyle.Format = "c";

            dataGridView_dedudasCertificado.Columns["IdDivision"].Visible = false;
            dataGridView_dedudasCertificado.Columns["Titular"].Visible = false;
            dataGridView_dedudasCertificado.Columns["IdOpDet"].Visible = false;
            dataGridView_dedudasCertificado.Columns["IdRecibo"].Visible = false;
            dataGridView_dedudasCertificado.Columns["Pagador"].Visible = false;
        }
    }
}
