using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.PlanContableForms
{
    public partial class FormPlanContableAlta : Form
    {
        FormPlanContable form_anterior;
        String id_cuenta_contable_cargada = "0";

        public FormPlanContableAlta(FormPlanContable form_anterior)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
        }

        public FormPlanContableAlta(FormPlanContable form_anterior, String id_cuenta_contable_cargada)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_cuenta_contable_cargada = id_cuenta_contable_cargada;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int TipoES = 2;
            if (comboBox_TipoES.SelectedItem.ToString() == "Entrada") TipoES = 1;

            if (id_cuenta_contable_cargada != "0")
            {
                String sqlUpdate = "UPDATE com_plancontable SET Titulo='" + textBox_Titulo.Text + "', Cuenta='" + textBox_Cuenta.Text + "',TipoES=" + TipoES + " WHERE IdPlanContable = " + id_cuenta_contable_cargada;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                form_anterior.cargarDataGrid();
                this.Close();
            }
            else
            {
                String sqlInsert = "INSERT INTO com_plancontable(Titulo, Cuenta, TipoES) VALUES ('" + textBox_Titulo.Text + "','" + textBox_Cuenta.Text + "'," + TipoES + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                form_anterior.cargarDataGrid();
                this.Close();
            }
        }

        private void FormPlanContableAlta_Load(object sender, EventArgs e)
        {
            comboBox_TipoES.SelectedItem = "Entrada";
            if (id_cuenta_contable_cargada != "0")
            {
                String sqlSelect = "SELECT Titulo, Cuenta, TipoES FROM com_plancontable WHERE IdPlanContable = " + id_cuenta_contable_cargada;
                DataTable fila = Persistencia.SentenciasSQL.select(sqlSelect);
                textBox_Cuenta.Text = fila.Rows[0][1].ToString();
                textBox_Titulo.Text = fila.Rows[0][0].ToString();

                if (fila.Rows[0][2].ToString() == "2") comboBox_TipoES.SelectedItem = "Salida"; 
            }
        }
    }
}
