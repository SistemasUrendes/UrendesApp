using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.FormProvisiones
{
    public partial class FormProvisiones : Form
    {
        String id_comunidad_cargado;
        DataTable provisiones;

        public FormProvisiones(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void FormProvisiones_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
            comboBox_Filtro.SelectedItem = "Todas";
        }
        public void cargarDatagrid() {
            String sqlSelect = "SELECT com_provisiones.IdProvision, com_provisiones.Nombre, com_provisiones.IdSubCuenta, com_bloques.Descripcion, com_provisiones.SaldoActual, com_provisiones.SaldoAnterior FROM com_provisiones INNER JOIN com_bloques ON com_provisiones.IdBloque = com_bloques.IdBloque WHERE(((com_provisiones.IdComunidad) = " + id_comunidad_cargado + "));";

            provisiones = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_Provisiones.DataSource = provisiones;
            dataGridView_Provisiones.Columns["Descripcion"].HeaderText = "Bloque";
            dataGridView_Provisiones.Columns[1].Width = 200;
            dataGridView_Provisiones.Columns[3].Width = 200;

        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            ProvisionesForms.FormProvisionesAlta nueva = new ProvisionesForms.FormProvisionesAlta(this,id_comunidad_cargado);
            nueva.Show();
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            ProvisionesForms.FormProvisionesAlta nueva = new ProvisionesForms.FormProvisionesAlta(this, id_comunidad_cargado,dataGridView_Provisiones.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta Provision ?", "Borrar Provision", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_provisiones WHERE IdProvision =  " + dataGridView_Provisiones.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarDatagrid();
            }
        }

        private void comboBox_Filtro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox filtro = (ComboBox)sender;

            if (filtro.SelectedItem.ToString() == "Todas")
            {
                cargarDatagrid();
            }
            else if (filtro.SelectedItem.ToString() == "Con Saldo")
            {
                DataTable busqueda = provisiones;
                busqueda.DefaultView.RowFilter = "SaldoActual > 0";
                dataGridView_Provisiones.DataSource = busqueda;
            }
            else if (filtro.SelectedItem.ToString() == "Sin Saldo")
            {
                DataTable busqueda = provisiones;
                busqueda.DefaultView.RowFilter = "SaldoActual = 0";
                dataGridView_Provisiones.DataSource = busqueda;
            }
        }
    }
}
