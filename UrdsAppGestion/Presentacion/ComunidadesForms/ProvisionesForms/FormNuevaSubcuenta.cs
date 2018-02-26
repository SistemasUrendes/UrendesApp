using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProvisionesForms
{
    public partial class FormNuevaSubcuenta : Form
    {
        FormCuentasExistentes form_anterior;
        String tipo_operacion;
        String id_comunidad;

        public FormNuevaSubcuenta(FormCuentasExistentes form_anterior,String tipo_operacion, String id_comunidad)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.tipo_operacion = tipo_operacion;
            this.id_comunidad = id_comunidad;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipo = 2;
            if (tipo_operacion == "fondo") tipo = 1;

            String sqlInsertSubcuenta = "INSERT INTO com_subcuentas (IdSubcuenta, `TIT SUBCTA`, ES) VALUES (" + maskedTextBox1.Text + ",'" + textBox1.Text + "'," + tipo + ")";

            //"INSERT INTO com_subcuentasFondos (IdComunidad, IdSubcuenta, `TIT SUBCTA`) VALUES(" + id_comunidad + "," + maskedTextBox1.Text + ",'" + textBox1.Text + "')";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertSubcuenta);
            form_anterior.cargarDatagrid();
            this.Close();
        }

        private void FormNuevaSubcuenta_Load(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT IdTipoFondo, TipoFondo FROM com_tipofondos";
            comboBox2.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            comboBox2.DisplayMember = "TipoFondo";
            comboBox2.ValueMember = "IdTipoFondo";

            if (tipo_operacion == "fondo")
            {
                comboBox2.Visible = true;
                label3.Visible = true;
                maskedTextBox1.Mask = @"1\0999";
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            if (combo.SelectedValue.ToString() == "10")
                maskedTextBox1.Mask = @"1\0999";

            if (combo.SelectedValue.ToString() == "11")
                maskedTextBox1.Mask = "11999";
            if (combo.SelectedValue.ToString() == "12")
                maskedTextBox1.Mask = "12999";
            
            if (combo.SelectedValue.ToString() == "13")
                maskedTextBox1.Mask = "13999";
        }
    }
}
