using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms
{
    public partial class FormAnyadirNotaLiq : Form
    {
        String idLiquidacion;

        public FormAnyadirNotaLiq(String idLiquidacion)
        {
            InitializeComponent();
            this.idLiquidacion = idLiquidacion;
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            String sqlInsert = "UPDATE com_liquidaciones SET Notas = '" + textBox_notas.Text + "' WHERE IdLiquidacion = " + idLiquidacion;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            MessageBox.Show("Nota Insertada");
            this.Close();
        }

        private void FormAnyadirNotaLiq_Load(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT Notas FROM com_liquidaciones WHERE IdLiquidacion = " + idLiquidacion;
            DataTable notas = Persistencia.SentenciasSQL.select(sqlSelect);
            if (notas.Rows.Count > 0)
                textBox_notas.Text = notas.Rows[0][0].ToString();
        }
    }
}
