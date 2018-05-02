using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    public partial class Anticipos : Form
    {
        String id_Comunidad_cargado;
        String id_Entidad;
        DataTable operaciones;

        public Anticipos(String id_Comunidad_cargado)
        {
            InitializeComponent();
            this.id_Comunidad_cargado = id_Comunidad_cargado;
            maskedTextBox_inicio.Text = "01-01-" + DateTime.Now.Year;

            maskedTextBox_fin.Text = DateTime.Now.ToShortDateString();
        }
        public Anticipos(String id_Comunidad_cargado, String id_Entidad)
        {
            InitializeComponent();
            this.id_Comunidad_cargado = id_Comunidad_cargado;
            this.id_Entidad = id_Entidad;
            maskedTextBox_inicio.Text = "01-01-" + DateTime.Now.Year;
            maskedTextBox_fin.Text = DateTime.Now.ToShortDateString();
        }

        private void Anticipos_Load(object sender, EventArgs e)
        {
            if (id_Entidad != "" && id_Entidad != null)   {
                maskedTextBox_inicio.Text = "";
                maskedTextBox_fin.Text = "";
                String sqlSelect = "SELECT com_opdetalles.IdOp, com_opdetalles.IdOpDet, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_subcuentas.IdSubcuenta, com_subcuentas.`TIT SUBCTA`, com_opdetalles.Fecha, com_operaciones.Documento, com_operaciones.Descripcion, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte FROM((com_opdetalles INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE com_subcuentas.IdSubcuenta >= 43800 AND com_subcuentas.IdSubcuenta <= 46000 AND com_opdetalles.IdEntidad = " + id_Entidad + " AND com_operaciones.IdComunidad =" + id_Comunidad_cargado + " ORDER BY com_opdetalles.Fecha DESC;";
                
                operaciones = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_anticipos.DataSource = operaciones;
                ajustarDatagrid();
            }
            else  {
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

                String sqlSelect = "SELECT com_opdetalles.IdOp, com_opdetalles.IdOpDet, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_subcuentas.IdSubcuenta, com_subcuentas.`TIT SUBCTA`, com_opdetalles.Fecha, com_operaciones.Documento, com_operaciones.Descripcion, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte FROM((com_opdetalles INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE com_subcuentas.IdSubcuenta >= 43800 AND com_subcuentas.IdSubcuenta <= 46000 AND com_opdetalles.Fecha >= '" + fechaInicio + "' AND com_opdetalles.Fecha <='" + fechaFin + "' AND com_operaciones.IdComunidad =" + id_Comunidad_cargado + " ORDER BY com_opdetalles.Fecha DESC;";

                operaciones = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_anticipos.DataSource = operaciones;
                ajustarDatagrid();
            }
        }
        private void ajustarDatagrid() {
            dataGridView_anticipos.Columns["IdEntidad"].Visible = false;
            dataGridView_anticipos.Columns["IdOp"].Width = 50;
            dataGridView_anticipos.Columns["IdOpDet"].Width = 50;
            dataGridView_anticipos.Columns["Entidad"].Width = 250;
            dataGridView_anticipos.Columns["IdSubCuenta"].Width = 50;
            dataGridView_anticipos.Columns["Fecha"].Width = 70;
            dataGridView_anticipos.Columns["Documento"].Width = 70;
            dataGridView_anticipos.Columns["TIT SUBCTA"].Width = 170;
            dataGridView_anticipos.Columns["Descripcion"].Width = 250;
            dataGridView_anticipos.Columns["Importe"].Width = 80;
            dataGridView_anticipos.Columns["Importe"].DefaultCellStyle.Format = "c";
            dataGridView_anticipos.Columns["ImpOpDetPte"].Width = 70;
            dataGridView_anticipos.Columns["ImpOpDetPte"].DefaultCellStyle.Format = "c";
            dataGridView_anticipos.Columns["Importe"].HeaderText = "A ingresar";
            dataGridView_anticipos.Columns["ImpOpDetPte"].HeaderText = "Pendiente";
            dataGridView_anticipos.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView_anticipos.Columns["ImpOpDetPte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void button_saldo_Click(object sender, EventArgs e)
        {
            if (button_saldo.Text != "Todos")
            {
                DataTable busqueda = operaciones;
                busqueda.DefaultView.RowFilter = "ImpOpDetPte < 0";
                dataGridView_anticipos.DataSource = busqueda;
                button_saldo.Text = "Todos";
            }else {
                DataTable busqueda = operaciones;
                busqueda.DefaultView.RowFilter = "";
                dataGridView_anticipos.DataSource = busqueda;
                button_saldo.Text = "Con Saldo";
            }
        }
    }
}
