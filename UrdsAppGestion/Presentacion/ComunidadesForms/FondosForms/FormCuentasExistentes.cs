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
    public partial class FormCuentasExistentes : Form
    {
        Form form_anterior;
        String nombre_formulario_anterior;
        String idComunidad;

        public FormCuentasExistentes(Form form_anterior, String nombre_formulario_anterior, String idComunidad)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.nombre_formulario_anterior = nombre_formulario_anterior;
            this.idComunidad = idComunidad;
        }

        private void FormCuentasExistentes_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        public void cargarDatagrid()
        {
            if (nombre_formulario_anterior == "FormProvisionesAlta")
            {
                String sqlCuentas = "SELECT IdSubcuenta, `TIT SUBCTA` FROM com_subcuentas WHERE IdSubcuenta >= 52000 AND IdSubcuenta <= 52099";
                dataGridView_cuentas.DataSource = Persistencia.SentenciasSQL.select(sqlCuentas);
                dataGridView_cuentas.Columns[1].Width = 195;

            }else if (nombre_formulario_anterior == "FormFondosAlta") {
                String sqlCuentas = "SELECT com_fondos.IdSubCuenta, com_fondos.TITSUBCTA FROM com_fondos GROUP BY com_fondos.IdSubCuenta, com_fondos.TITSUBCTA, com_fondos.IdComunidad HAVING com_fondos.IdComunidad = " + idComunidad;


                dataGridView_cuentas.DataSource = Persistencia.SentenciasSQL.select(sqlCuentas);
                dataGridView_cuentas.Columns[1].Width = 195;
            }
        }
        private void dataGridView_cuentas_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Enter)
            {
                enviarOtroForm();
                this.Close();
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (nombre_formulario_anterior.Contains("Fondos"))
            {
                FormNuevaSubcuenta nueva = new FormNuevaSubcuenta(this, "fondo",idComunidad);
                nueva.Show();
            }else {
                FormNuevaSubcuenta nueva = new FormNuevaSubcuenta(this, "provision", idComunidad);
                nueva.Show();
            }
        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            enviarOtroForm();
            this.Close();
        }
        private void enviarOtroForm()
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_formulario_anterior)).SingleOrDefault<Form>();
            if (existe != null)
            {
                if (nombre_formulario_anterior == "FormProvisionesAlta")
                {
                    FormProvisionesAlta nuevo = (FormProvisionesAlta)existe;
                    nuevo.recogerCuenta(dataGridView_cuentas.SelectedCells[0].Value.ToString(), dataGridView_cuentas.SelectedCells[1].Value.ToString());
                }

                if (nombre_formulario_anterior == "FormFondosAlta")
                {
                    FondosForms.FormFondosAlta nuevo = (FondosForms.FormFondosAlta)existe;
                    nuevo.recogerSubcuenta(dataGridView_cuentas.SelectedCells[0].Value.ToString(), dataGridView_cuentas.SelectedCells[1].Value.ToString());
                }
            }
        }
    }
}
