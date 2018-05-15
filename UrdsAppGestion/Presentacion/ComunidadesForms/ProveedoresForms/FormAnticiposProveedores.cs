using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProveedoresForms
{
    public partial class FormAnticiposProveedores : Form
    {
        String idComunidad;
        String idEntidad;
        DataTable anticipos;

        public FormAnticiposProveedores(String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            maskedTextBox_inicio.Text = "01-01-" + DateTime.Now.Year;
            maskedTextBox_fin.Text = DateTime.Now.ToShortDateString();
        }
        public FormAnticiposProveedores(String idComunidad, String idEntidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idEntidad = idEntidad;
            maskedTextBox_inicio.Text = "01-01-" + DateTime.Now.Year;
            maskedTextBox_fin.Text = DateTime.Now.ToShortDateString();
        }

        private void FormAnticiposProveedores_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
        }
        private void cargarDataGrid() {

            if (idEntidad != "" && idEntidad != null)
            {
                maskedTextBox_inicio.Text = "";
                maskedTextBox_fin.Text = "";
                String sqlSelect = "SELECT com_opdetalles.IdOp, com_opdetalles.IdOpDet, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_subcuentas.IdSubcuenta, com_subcuentas.`TIT SUBCTA`, com_opdetalles.Fecha, com_operaciones.Documento, com_operaciones.Descripcion, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte FROM((com_opdetalles INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE com_subcuentas.IdSubcuenta >= 43800 AND com_subcuentas.IdSubcuenta <= 46000 AND com_opdetalles.IdEntidad = " + idEntidad + " AND com_operaciones.IdComunidad =" + idComunidad + " ORDER BY com_opdetalles.Fecha DESC;";

                anticipos = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView1.DataSource = anticipos;
                ajustarDatagrid();
            }
            else
            {
                String fechaInicio;
                String fechaFin;
                try
                {
                    fechaInicio = (Convert.ToDateTime(maskedTextBox_inicio.Text)).ToString("yyyy-MM-dd");
                    fechaFin = (Convert.ToDateTime(maskedTextBox_fin.Text)).ToString("yyyy-MM-dd");
                }
                catch
                {
                    MessageBox.Show("Comprueba la fecha");
                    return;
                }

                String sql = "SELECT com_opdetalles.IdOp, com_opdetalles.IdOpDet, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_subcuentas.IdSubcuenta, com_subcuentas.`TIT SUBCTA` AS Subcuenta, com_opdetalles.Fecha, com_operaciones.Documento, com_operaciones.Descripcion, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte FROM((com_opdetalles INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE(((com_subcuentas.IdSubcuenta) >= 43812 And(com_subcuentas.IdSubcuenta) <= 46000) AND((com_opdetalles.Fecha) >= '" + fechaInicio + "' And(com_opdetalles.Fecha) <= '" + fechaFin + "') AND((com_operaciones.IdComunidad) = " + idComunidad + ")) ORDER BY com_opdetalles.Fecha DESC;";

                anticipos = Persistencia.SentenciasSQL.select(sql);
                dataGridView1.DataSource = anticipos;
                ajustarDatagrid();
            }

        }
        private void ajustarDatagrid()
        {
            dataGridView1.Columns["IdEntidad"].Visible = false;
            dataGridView1.Columns["IdOp"].Width = 50;
            dataGridView1.Columns["IdOpDet"].Width = 50;
            dataGridView1.Columns["Entidad"].Width = 250;
            dataGridView1.Columns["IdSubCuenta"].Width = 50;
            dataGridView1.Columns["Fecha"].Width = 70;
            dataGridView1.Columns["Documento"].Width = 70;
            dataGridView1.Columns["Subcuenta"].Width = 170;
            dataGridView1.Columns["Descripcion"].Width = 250;
            dataGridView1.Columns["Importe"].Width = 80;
            dataGridView1.Columns["Importe"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["ImpOpDetPte"].Width = 70;
            dataGridView1.Columns["ImpOpDetPte"].DefaultCellStyle.Format = "c";
            dataGridView1.Columns["Importe"].HeaderText = "A ingresar";
            dataGridView1.Columns["ImpOpDetPte"].HeaderText = "Pendiente";
            dataGridView1.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["ImpOpDetPte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargarDataGrid();
        }

        private void button_saldo_Click(object sender, EventArgs e)
        {
            if (button_saldo.Text != "Todos")
            {
                DataTable busqueda = anticipos;
                busqueda.DefaultView.RowFilter = "ImpOpDetPte < 0";
                dataGridView1.DataSource = busqueda;
                button_saldo.Text = "Todos";
            }
            else
            {
                DataTable busqueda = anticipos;
                busqueda.DefaultView.RowFilter = "";
                dataGridView1.DataSource = busqueda;
                button_saldo.Text = "Con Saldo";
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), 2);
            nueva.Show();
        }
    }
}
