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
    public partial class FormIndenxarLiquidacion : Form
    {
        String idComunidad;
        String idDetalleFondo;
        String idEjercicio;

        public FormIndenxarLiquidacion(String idComunidad, String idDetalleFondo, String idEjercicio)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idDetalleFondo = idDetalleFondo;
            this.idEjercicio = idEjercicio;
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            String sqlUpdate = "UPDATE com_liquidaciones SET IdDetalleFondo = " + idDetalleFondo + " WHERE IdLiquidacion = " + comboBox_liquidacion.SelectedValue;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            MessageBox.Show("Listo");
            this.Close();
        }

        private void FormIndenxarLiquidacion_Load(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_liquidaciones.IdLiquidacion, com_liquidaciones.Liquidacion FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE (((com_ejercicios.IdEjercicio) = " + idEjercicio + ") AND((com_ejercicios.IdComunidad) = " + idComunidad + "));";
            comboBox_liquidacion.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            comboBox_liquidacion.ValueMember = "IdLiquidacion";
            comboBox_liquidacion.DisplayMember = "Liquidacion";
        }
    }
}
