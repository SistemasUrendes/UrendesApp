using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.EjerciciosForms
{
    public partial class FormEjerciciosAlta : Form
    {
        String id_comunidad_cargado = "0";
        String id_ejercicio_cargado = "0";
        Ejercicios form_anterior;
        DataTable ejercicio;

        public FormEjerciciosAlta(Ejercicios form_anterior, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        public FormEjerciciosAlta(Ejercicios form_anterior, String id_comunidad_cargado, String id_ejercicio_cargado)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_ejercicio_cargado = id_ejercicio_cargado;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEjerciciosAlta_Load(object sender, EventArgs e)
        {
            cargaCombos();
            if (id_ejercicio_cargado != "0" ) {
                String sqlSelect = "SELECT com_ejercicios.IdEjercicio, com_ejercicios.Ejercicio, com_ejercicios.FIni, com_ejercicios.FFin, com_ejercicios.C, com_ejercicios.Ppal, com_ejercicios.IdMetodoCuota, com_ejercicios.IdFrecCuota, com_ejercicios.IdFrecLiquidacion FROM com_ejercicios WHERE(((com_ejercicios.IdEjercicio) = " + id_ejercicio_cargado + "));";
                ejercicio = Persistencia.SentenciasSQL.select(sqlSelect);
                textBox_Ejercicio.Text = ejercicio.Rows[0][1].ToString();
                textBox_FIni.Text = ejercicio.Rows[0][2].ToString();
                textBox_FFin.Text = ejercicio.Rows[0][3].ToString();

                if (ejercicio.Rows[0][5].ToString() == "True") checkBox_Ppal.Checked = true;

                if (ejercicio.Rows[0][6].ToString() != "")
                    comboBox_Metodo.SelectedValue = ejercicio.Rows[0][6].ToString();

                if (ejercicio.Rows[0][7].ToString() != "")
                    comboBox_Cuotas.SelectedValue = ejercicio.Rows[0][7].ToString(); 

                if (ejercicio.Rows[0][8].ToString() != "")
                    comboBox_Liquidacion.SelectedValue = ejercicio.Rows[0][8].ToString();
            }
        }
        private void cargaCombos() {
            String sqlCombo1 = "SELECT com_metodoscuotas.IdMetodoCuota, com_metodoscuotas.Método FROM com_metodoscuotas;";
            comboBox_Metodo.DataSource = Persistencia.SentenciasSQL.select(sqlCombo1);
            comboBox_Metodo.DisplayMember = "Método";
            comboBox_Metodo.ValueMember = "IdMetodoCuota";

            String sqlCombo2 = "SELECT com_frecuencias.IdFrec, com_frecuencias.Frecuencia FROM com_frecuencias;";
            comboBox_Cuotas.DataSource = Persistencia.SentenciasSQL.select(sqlCombo2);
            comboBox_Cuotas.DisplayMember = "Frecuencia";
            comboBox_Cuotas.ValueMember = "IdFrec";

            comboBox_Liquidacion.DataSource = Persistencia.SentenciasSQL.select(sqlCombo2);
            comboBox_Liquidacion.DisplayMember = "Frecuencia";
            comboBox_Liquidacion.ValueMember = "IdFrec";
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String fechaInicio = (Convert.ToDateTime(textBox_FIni.Text)).ToString("yyyy-MM-dd");
            String fechaFin = (Convert.ToDateTime(textBox_FFin.Text)).ToString("yyyy-MM-dd");
            String principal = "0";
            if (checkBox_Ppal.Checked) principal = "-1"; 
            if (id_ejercicio_cargado != "0")  {
                String sqlUpdate = "UPDATE com_ejercicios SET Ejercicio='" + textBox_Ejercicio.Text + "', FIni='" + fechaInicio + "', FFin='" + fechaFin + "', Ppal=" + principal + ",IdMetodoCuota=" + comboBox_Metodo.SelectedValue.ToString() + ", IdFrecCuota=" + comboBox_Cuotas.SelectedValue.ToString() + ", IdFrecLiquidacion=" + comboBox_Liquidacion.SelectedValue.ToString() + " WHERE IdEjercicio = " + id_ejercicio_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                form_anterior.cargarDatagrid();
                this.Close();
            }
            else {
                String sqlInsert = "INSERT INTO com_ejercicios(IdComunidad, Ejercicio, FIni, FFin, Ppal, IdMetodoCuota, IdFrecCuota, IdFrecLiquidacion) VALUES (" + id_comunidad_cargado + ",'" + textBox_Ejercicio.Text + "','" + fechaInicio + "','" + fechaFin + "'," + principal + "," +  comboBox_Metodo.SelectedValue.ToString() + "," + comboBox_Cuotas.SelectedValue.ToString() + "," + comboBox_Liquidacion.SelectedValue.ToString() + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                form_anterior.cargarDatagrid();
                this.Close();
            }

        }

        private void textBox_FIni_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(textBox_FIni.Text, sPattern))
            {
                textBox_FIni.Text = textBox_FIni.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(textBox_FIni.Text, sPattern1))
            {
                textBox_FFin.SelectAll();
            }
            else
            {
                textBox_FIni.Focus();
                textBox_FIni.Select();
            }
        }

        private void textBox_FFin_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(textBox_FFin.Text, sPattern))
            {
                textBox_FFin.Text = textBox_FFin.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(textBox_FFin.Text, sPattern1))
            {
                comboBox_Metodo.Select();
            }
            else
            {
                textBox_FFin.Focus();
                textBox_FFin.Select();
            }
        }
    }
}
