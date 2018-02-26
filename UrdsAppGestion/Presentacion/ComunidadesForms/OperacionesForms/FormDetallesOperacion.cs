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
    public partial class FormDetallesOperacion : Form
    {
        String id_det_operacion;
        public FormDetallesOperacion(String id_det_operacion)
        {
            InitializeComponent();
            this.id_det_operacion = id_det_operacion;
        }

        private void FormDetallesOperacion_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String sqlVencimiento = "SELECT com_movimientos.IdMov, com_detmovs.IdDetMov, com_detmovs.IdOpDet, com_movimientos.Fecha, com_movimientos.Detalle, com_detmovs.ImpDetMovEntra AS Entrada, com_detmovs.ImpDetMovSale AS Salida FROM com_detmovs INNER JOIN com_movimientos ON com_detmovs.IdMov = com_movimientos.IdMov WHERE(((com_detmovs.IdOpDet) = " + id_det_operacion + "));";

            dataGridView_vencimietos.DataSource = Persistencia.SentenciasSQL.select(sqlVencimiento);
            ajustarDatagrid();
        }
        private void ajustarDatagrid() {
            dataGridView_vencimietos.Columns["IdMov"].Width = 60;
            dataGridView_vencimietos.Columns["IdDetMov"].Width = 60;
            dataGridView_vencimietos.Columns["IdOpDet"].Width = 60;
            dataGridView_vencimietos.Columns["Fecha"].Width = 80;
            dataGridView_vencimietos.Columns["Detalle"].Width = 250;
            dataGridView_vencimietos.Columns["Entrada"].DefaultCellStyle.Format = "c";
            dataGridView_vencimietos.Columns["Salida"].DefaultCellStyle.Format = "c";
            dataGridView_vencimietos.Columns["Entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_vencimietos.Columns["Salida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_vencimietos.Columns["Detalle"].Width = 250;
        }
    }
}
