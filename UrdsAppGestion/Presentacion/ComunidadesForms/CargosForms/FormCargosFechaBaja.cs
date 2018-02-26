using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    public partial class FormCargosFechaBaja : Form
    {
        String id_cargo_cargado = "0";
        FormCargos form_anterior;

        public FormCargosFechaBaja(FormCargos form_anterior, String id_cargo_cargado)
        {
            InitializeComponent();
            this.id_cargo_cargado = id_cargo_cargado;
            this.form_anterior = form_anterior;
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (id_cargo_cargado != "0") {
                String fechaFin = (Convert.ToDateTime(maskedTextBox_fecha.Text)).ToString("yyyy-MM-dd");
                String sqlUpdate = "UPDATE com_cargoscom SET FFin='" + fechaFin + "' WHERE IdCargoCom = " + id_cargo_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                form_anterior.cargardatagrid();
                this.Close();
            }
        }

        private void CargosFormFechaBaja_Load(object sender, EventArgs e)
        {
            maskedTextBox_fecha.Text = DateTime.Now.ToShortDateString();
        }
    }
}
