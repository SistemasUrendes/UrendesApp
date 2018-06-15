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
    public partial class FormModificarStock : Form
    {
        String idFondo;
        String tipoOp;

        public FormModificarStock(String idFondo, String tipoOp)
        {
            InitializeComponent();
            this.idFondo = idFondo;
            this.tipoOp = tipoOp;
        }

        private void FormModificarStock_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }

        private void cargarDatagrid()
        {
            String sqlSelect = "SELECT com_stockFondo.IdStockFondo, com_stockFondo.Nombre FROM com_stockFondo WHERE com_stockFondo.IdFondo = " + idFondo;
            dataGridView_stock.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);

            DataGridViewTextBoxColumn cuanto = new DataGridViewTextBoxColumn();
            cuanto.HeaderText = "Cantidad";
            cuanto.Name = "Cantidad";
            cuanto.Width = 80;
            cuanto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_stock.Columns.Add(cuanto);
            dataGridView_stock.Columns["IdStockFondo"].Visible = false;
            dataGridView_stock.Columns["Nombre"].ReadOnly = true;

        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            int cantidad = 0;
            for (int a = 0; a < dataGridView_stock.Rows.Count; a++) {
                try {
                    cantidad = Convert.ToInt32(dataGridView_stock.Rows[a].Cells["Cantidad"].Value);
                }
                catch (Exception) {
                    MessageBox.Show("Valor introducido no correcto");
                    return;
                }

                String sqlUpdate = "UPDATE com_stockFondo SET Valor=Valor " + tipoOp + cantidad.ToString() + " WHERE IdStockFondo = " + dataGridView_stock.Rows[a].Cells["IdStockFondo"].Value.ToString();

                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            this.Close();
        }
    }
}
