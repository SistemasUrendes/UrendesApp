using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.RemesasForms
{
    public partial class FormRemesas : Form
    {
        String id_comunidad_cargado;
        DataTable remesas;

        public FormRemesas(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void FormRemesas_Load(object sender, EventArgs e)
        {
            cargarDatagrid("5");
            comboBox_filtro.SelectedIndex = 1;
        }
        public void cargarDatagrid(String limiteCarga) {
            
            String sqlString = "SELECT com_remesas.IdRemesa, com_remesas.Remesa, com_cuentas.Descripcion, com_tiporemesa.Tipo, com_remesas.FEnvio, com_remesas.FCargo, com_remesas.FCobro, com_remesas.Sufijo, com_remesas.IdEstado, Sum(com_detremesa.Importe) AS SumaDeImporte FROM((com_remesas INNER JOIN com_tiporemesa ON com_remesas.IdTipoRemesa = com_tiporemesa.IdTipoRemesa) INNER JOIN com_cuentas ON com_remesas.IdCuenta = com_cuentas.IdCuenta) LEFT JOIN com_detremesa ON com_remesas.IdRemesa = com_detremesa.IdRemesa GROUP BY com_remesas.IdRemesa, com_remesas.Remesa, com_cuentas.Descripcion, com_tiporemesa.Tipo, com_remesas.FEnvio, com_remesas.FCargo, com_remesas.FCobro, com_remesas.Sufijo, com_remesas.IdEstado, com_remesas.IdComunidad HAVING(((com_remesas.IdComunidad) = " + id_comunidad_cargado + ")) ORDER BY com_remesas.IdRemesa DESC LIMIT " + limiteCarga + ";";

            remesas = Persistencia.SentenciasSQL.select(sqlString);
            dataGridView_remesas.DataSource = remesas;

            dataGridView_remesas.Columns["Descripcion"].HeaderText = "Cuenta";
            dataGridView_remesas.Columns["SumaDeImporte"].HeaderText = "Importe";
            dataGridView_remesas.Columns["SumaDeImporte"].DefaultCellStyle.Format = "c";
            dataGridView_remesas.Columns["SumaDeImporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView_remesas.Columns["Remesa"].Width = 220;   
             
        }

        private void button_detalles_Click(object sender, EventArgs e)
        {
            if (dataGridView_remesas.SelectedRows.Count > 0)
            {
                FormDetalleRemesa nueva = new FormDetalleRemesa(this,dataGridView_remesas.SelectedCells[0].Value.ToString(), dataGridView_remesas.SelectedCells[8].Value.ToString(), id_comunidad_cargado);
                nueva.Show();
            }else {
                MessageBox.Show("Debe seleccionar un fila");
            }
        }

        private void button_anyadir_Click(object sender, EventArgs e)
        {
            FormAnyadirRemesa nueva = new FormAnyadirRemesa(this,id_comunidad_cargado);
            nueva.Show();
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            if( dataGridView_remesas.SelectedRows[0].Cells[8].Value.ToString() == "1") {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar esta Remesa ?", "Borrar Remesa", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    String sqlDelete = "DELETE FROM com_remesas WHERE IdRemesa = " + dataGridView_remesas.SelectedRows[0].Cells[0].Value.ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
                    cargarDatagrid("5");
                }
               
            }else {
                MessageBox.Show("La remesa no se puede cerrar por el Estado");
            }
        }

        private void comboBox_filtro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_filtro.SelectedIndex == 0) {
                cargarDatagrid("5");
            }else if (comboBox_filtro.SelectedIndex == 1) {
                cargarDatagrid("10");
            }else if (comboBox_filtro.SelectedIndex == 2) {
                cargarDatagrid("20");
            } else if (comboBox_filtro.SelectedIndex == 3) { 
                cargarDatagrid("1000");
            }
        }

        private void dataGridView_remesas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_remesas.HitTest(e.X, e.Y);
                dataGridView_remesas.ClearSelection();
                dataGridView_remesas.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Items.Clear();
                contextMenuStrip1.Items.Add("Eliminar");
                contextMenuStrip1.Items.Add("Ver Detalles");

                contextMenuStrip1.Items[0].Click += new EventHandler(this.button_eliminar_Click);
                contextMenuStrip1.Items[1].Click += new EventHandler(this.button_detalles_Click);


                contextMenuStrip1.Show(Cursor.Position);

            }
        }
    }
}
