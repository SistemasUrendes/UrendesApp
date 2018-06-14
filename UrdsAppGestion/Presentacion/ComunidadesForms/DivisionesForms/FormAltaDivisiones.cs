using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Persistencia;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    public partial class FormAltaDivisiones : Form
    {
        int id_comunidad = 0;
        int id_division_cargado = 0;
        DataTable division;
        Divisiones form_anterior;
        int indice = 0;

        public FormAltaDivisiones(Divisiones form_anterior,int id_comunidad, int id_division_cargado,int indice)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.id_division_cargado = id_division_cargado;
            this.form_anterior = form_anterior;
            this.indice = indice;
        }
        public FormAltaDivisiones(Divisiones form_anterior,int id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.form_anterior = form_anterior;
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAltaDivisiones_Load(object sender, EventArgs e)  {

            String sql2 = "SELECT IdTipoDiv,TipoDivision FROM com_tipodivs";
            DataTable tipo_divisiones = SentenciasSQL.select(sql2);
            comboBox_Tipo.DataSource = tipo_divisiones;
            comboBox_Tipo.ValueMember = "IdTipoDiv";
            comboBox_Tipo.DisplayMember = "TipoDivision";
           
            if (id_division_cargado != 0) {
               
                 String sql = "SELECT IdDivision, IdComunidad, Division, Finca, Orden, IdTipoDiv, Cuota, Excluido, Notas, ReferenciaRecibos FROM com_divisiones WHERE IdDivision = " + id_division_cargado;

                division = Persistencia.SentenciasSQL.select(sql);

                textBox_Nombre.Text = division.Rows[0]["Division"].ToString();
                textBox_Cuota.Text = ((double)division.Rows[0]["Cuota"]).ToString("p");
                textBox_Notas.Text = division.Rows[0]["Notas"].ToString();
                textBox_ref_recibos.Text = division.Rows[0]["ReferenciaRecibos"].ToString();
                textBox_Orden.Text = division.Rows[0]["Orden"].ToString();
                comboBox_Tipo.SelectedValue = division.Rows[0]["IdTipoDiv"].ToString();

                if (division.Rows[0]["Excluido"].ToString() == "False") {
                    checkBox_Excluido.Checked = false;
                }
            }
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            String excluido = "0";
            String sql;

            if (checkBox_Excluido.Checked == true)
                excluido = "-1";

            //Arreglo la cuota para la bbdd
            String cuota = textBox_Cuota.Text.TrimEnd('%');
            cuota.Trim();
            double cuota2 = Convert.ToDouble(cuota) / 100.00;


            if (id_division_cargado != 0) {

                if (textBox_Orden.Text != "")
                {
                    sql = "UPDATE com_divisiones SET Division = '" + textBox_Nombre.Text + "', Orden = " + textBox_Orden.Text + ", IdTipoDiv = " + comboBox_Tipo.SelectedValue.ToString() + ", Cuota = " + cuota2.ToString().Replace(",", ".") + ", Excluido = " + excluido + " , Notas = '" + textBox_Notas.Text.ToString() + "', ReferenciaRecibos ='" + textBox_ref_recibos.Text.ToString() + "' WHERE IdDivision = " + id_division_cargado.ToString();
                }else {
                    sql = "UPDATE com_divisiones SET Division = '" + textBox_Nombre.Text + "', IdTipoDiv = " + comboBox_Tipo.SelectedValue.ToString() + ", Cuota = " + cuota2.ToString().Replace(",", ".") + ", Excluido = " + excluido + " , Notas = '" + textBox_Notas.Text.ToString() + "', ReferenciaRecibos ='" + textBox_ref_recibos.Text.ToString() + "' WHERE IdDivision = " + id_division_cargado.ToString();
                }
                SentenciasSQL.InsertarGenerico(sql);
                form_anterior.cargarDivisiones();
                form_anterior.dataGridView_divisiones.Rows[indice].Selected = true;
                form_anterior.cargarDetallesDivisiones();
                this.Close();
            }
            else {
                if (textBox_Orden.Text != "") {
                    sql = "INSERT INTO com_divisiones (IdComunidad, Division, Orden, IdTipoDiv, Cuota, Excluido, Notas, ReferenciaRecibos) VALUES (" + id_comunidad.ToString() + ",'" + textBox_Nombre.Text + "'," + textBox_Orden.Text + "," + comboBox_Tipo.SelectedValue.ToString() + "," + cuota2.ToString().Replace(",", ".") + "," + excluido + ",'" + textBox_Notas.Text.ToString() + "','" + textBox_ref_recibos.Text.ToString() + "')";
                }else {
                    sql = "INSERT INTO com_divisiones (IdComunidad, Division, IdTipoDiv, Cuota, Excluido, Notas, ReferenciaRecibos) VALUES (" + id_comunidad.ToString() + ",'" + textBox_Nombre.Text + "'," + comboBox_Tipo.SelectedValue.ToString() + "," + cuota2.ToString().Replace(",", ".") + "," + excluido + ",'" + textBox_Notas.Text.ToString() + "','" + textBox_ref_recibos.Text.ToString() + "')";
                }

                SentenciasSQL.InsertarGenerico(sql);
                form_anterior.cargarDivisiones();
                form_anterior.dataGridView_divisiones.Rows[indice].Selected = true;
                form_anterior.cargarDetallesDivisiones();
                this.Close();
            }
        }
    }
}
