using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms
{
    public partial class FormGastosReparto : Form
    {
        String id_comunidad;
        String id_liquidacion_pasado;
        DataTable operaciones;

        public FormGastosReparto(String id_comunidad, String id_liquidacion_pasado)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.id_liquidacion_pasado = id_liquidacion_pasado;
        }

        private void FormGastosReparto_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
            calcularTotal();
        }
        private void cargarDatagrid() {
            String sqlSelect = "SELECT com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.IdSubCuenta,  com_operaciones.IdTipoReparto, com_operaciones.Fecha,ctos_entidades.Entidad, com_operaciones.Documento, com_operaciones.Descripcion, com_subcuentas.`TIT SUBCTA`, ImpOp*If(com_subcuentas.ES=1,-1,1) AS ImporteOp, Sum(com_opdetliquidacion.Importe*If(com_subcuentas.ES=1,-1,1)) AS ImpLiq, (ImpOp*If(com_subcuentas.ES=1,-1,1))-Sum(com_opdetliquidacion.Importe*If(com_subcuentas.ES=1,-1,1)) AS Dif FROM((com_operaciones INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad GROUP BY com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_operaciones.IdOp, com_operaciones.IdEntidad, com_operaciones.IdTipoReparto, com_operaciones.Fecha, com_operaciones.Documento, com_operaciones.Descripcion, com_subcuentas.`TIT SUBCTA`, impOp* If(com_subcuentas.ES= 1,-1,1), com_operaciones.IdSubCuenta, ctos_entidades.Entidad HAVING(((com_opdetliquidacion.IdLiquidacion)=" + id_liquidacion_pasado + ") AND ((com_operaciones.IdSubCuenta) Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900)) ORDER BY com_operaciones.IdOp, com_operaciones.Fecha;";

            operaciones = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_gastos.DataSource = operaciones;

            ajustarDatagrid();
        }
        private void ajustarDatagrid() {
            dataGridView_gastos.Columns["IdComunidad"].Visible = false;
            dataGridView_gastos.Columns["IdLiquidacion"].Visible = false;
            dataGridView_gastos.Columns["IdEntidad"].Visible = false;
            dataGridView_gastos.Columns["IdTipoReparto"].Visible = false;
            dataGridView_gastos.Columns["TIT SUBCTA"].Visible = false;
            dataGridView_gastos.Columns["Dif"].Visible = false;

            dataGridView_gastos.Columns["Descripcion"].Width = 200;
            dataGridView_gastos.Columns["Entidad"].Width = 200;
        }
        private void calcularTotal() {
            double suma = 0.00;
            for (int a = 0; a < dataGridView_gastos.Rows.Count; a++) {
                    suma = suma + Convert.ToDouble(dataGridView_gastos.Rows[a].Cells[12].Value.ToString());
            }
            textBox_total.Text = suma.ToString("N2");
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_buscar.TextLength < 2)
            {
                DataTable busqueda = operaciones;
                busqueda.DefaultView.RowFilter = "Entidad like '%%'";
                this.dataGridView_gastos.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = operaciones;
                busqueda.DefaultView.RowFilter = "Entidad like '%" + textBox_buscar.Text + "%'";
                this.dataGridView_gastos.DataSource = busqueda;
            }
        }

        private void dataGridView_gastos_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView_gastos.SelectedRows.Count > 0)     {
                OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView_gastos.SelectedRows[0].Cells[2].Value.ToString(), 2);
                nueva.Show();
            }
        }
    }
}
