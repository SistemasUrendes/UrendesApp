using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    public partial class FormCambiarEstadoDivision : Form
    {
        List<String> lista_operaciones = new List<String>();
        FormDivisionesCuotas form_anterior;
        String deDondeVengo;

        public FormCambiarEstadoDivision(FormDivisionesCuotas form_anterior, List<String> lista_operaciones, String deDondeVengo)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.lista_operaciones = lista_operaciones;
            this.deDondeVengo = deDondeVengo;
        }

        private void FormCambiarEstadoDivision_Load(object sender, EventArgs e)
        {
            if (deDondeVengo == "Estado")
            {
                label2.Text = "Se van a cambiar " + lista_operaciones.Count.ToString() + " operaciones.";

                comboBox1.DataSource = Persistencia.SentenciasSQL.select("SELECT IdEstadoCuota, Descripcion FROM com_estadosCuotas");
                comboBox1.ValueMember = "IdEstadoCuota";
                comboBox1.DisplayMember = "Descripcion";
            }else {
                comboBox1.Visible = false;
                label1.Visible = false;
                label3.Text = "Fecha Certificado";
            }
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            String fecha;
            if (maskedTextBox_fecha.Text != null || maskedTextBox_fecha.Text != "") {
                try
                {
                    fecha = (Convert.ToDateTime(maskedTextBox_fecha.Text)).ToString("yyyy-MM-dd");
                }catch {
                    MessageBox.Show("Debes de escribir una fecha.");
                    return;
                }
            }else {
                MessageBox.Show("Debes de escribir una fecha.");
                return;
            }
            
            if (deDondeVengo == "Estado")
            {

                for (int a = 0; a < lista_operaciones.Count; a++)
                {
                    String sqlUpdate = "UPDATE com_operaciones SET IdEstadoCuota = " + comboBox1.SelectedValue.ToString() + ", FEstadoCuota='" + fecha + "' WHERE IdOp = " + lista_operaciones[a].ToString();

                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
            }else {
                for (int a = 0; a < lista_operaciones.Count; a++)
                {
                    String sqlUpdate = "UPDATE com_operaciones SET FCertificado='" + fecha + "' WHERE IdOp = " + lista_operaciones[a].ToString();

                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
            }

            form_anterior.aplicarFiltro();
            form_anterior.dataGridView_operacionesComuneros.ClearSelection();
            MessageBox.Show("Actualizado");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
