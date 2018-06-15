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
    public partial class FormCrearStock : Form
    {
        String idFondo;

        public FormCrearStock(String idFondo)
        {
            InitializeComponent();
            this.idFondo = idFondo;
        }

        private void button_crear_Click(object sender, EventArgs e)
        {
            String sqlInsert = "INSERT INTO com_stockFondo (IdFondo, Nombre, Valor) VALUES (" + idFondo + ",'" + textBox_nombre.Text + "','" + textBox_valor.Text + "')";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            cargarDatagrid();
        }

        private void FormCrearStock_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        private void cargarDatagrid() {
            String sqlSelect = "SELECT com_stockFondo.IdStockFondo, com_stockFondo.Nombre, com_stockFondo.Valor FROM com_stockFondo WHERE com_stockFondo.IdFondo = " + idFondo;

            dataGridView_stocks.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
