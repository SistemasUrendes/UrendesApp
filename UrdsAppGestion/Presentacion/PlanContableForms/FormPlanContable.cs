using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion
{
    public partial class FormPlanContable : Form
    {
        public FormPlanContable()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlanContableForms.FormPlanContableAlta nueva = new PlanContableForms.FormPlanContableAlta(this);
            nueva.Show();
        }

        private void FormPlanContable_Load(object sender, EventArgs e)
        {
            cargarDataGrid();
        }
        public void cargarDataGrid() {
            String sqlSelect = "SELECT IdPlanContable, Titulo, Cuenta, TipoES FROM com_plancontable";
            dataGridView_Cuentas.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlanContableForms.FormPlanContableAlta nueva = new PlanContableForms.FormPlanContableAlta(this,dataGridView_Cuentas.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este Plan Contable ?", "Borrar Plan Contable", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_plancontable WHERE IdPlanContable =  " + dataGridView_Cuentas.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarDataGrid();
            }
        }
    }
}
