using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.ReglasPago
{
    public partial class FormAnyadirRegla : Form
    {
        String idDivision;
        String nombreDivision;
        FormReglasPago form_anterior;

        public FormAnyadirRegla(FormReglasPago form_anterior, String idDivision, String nombreDivision)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idDivision = idDivision;
            this.nombreDivision = nombreDivision;
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAnyadirRegla_Load(object sender, EventArgs e)
        {
            String sqlCombo = "SELECT IdTipoCuota, TipoCuota FROM com_tipocuotas LIMIT 2";
            comboBox_tipo.DataSource = Persistencia.SentenciasSQL.select(sqlCombo);
            comboBox_tipo.ValueMember = "IdTipoCuota";
            comboBox_tipo.DisplayMember = "TipoCuota";

            textBox_division.Text = nombreDivision;

        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            String activa = "0";
            if (checkBox_activa.Checked) activa = "-1";

            String sqlInsert = "INSERT INTO com_repartos (IdDivision, Descripcion, IdTipoCuota, Act) VALUES (" + idDivision + ",'" + textBox_descripcion.Text + "'," + comboBox_tipo.SelectedValue + "," + activa + ")";

            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            form_anterior.cargarRepartos();
            this.Close();

        }
    }
}
