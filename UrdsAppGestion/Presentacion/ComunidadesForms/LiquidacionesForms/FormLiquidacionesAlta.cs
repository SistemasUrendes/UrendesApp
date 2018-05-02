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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms
{
    public partial class FormLiquidacionesAlta : Form
    {
        Liquidaciones form_anterior;
        String id_comunidad_cargado;
        String id_liquidacion_cargado = "0";

        public FormLiquidacionesAlta(Liquidaciones form_anterior, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        public FormLiquidacionesAlta(Liquidaciones form_anterior, String id_comunidad_cargado, String id_liquidacion_cargado)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_liquidacion_cargado = id_liquidacion_cargado;
        }

        private void FormLiquidacionesAlta_Load(object sender, EventArgs e)
        {
            String fechaHoy = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd");

            String sqlEjercicio = "SELECT com_ejercicios.IdEjercicio, com_ejercicios.Ejercicio FROM com_ejercicios WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + ") AND((com_ejercicios.C) <> -1));";
            comboBox_Ejercicio.DataSource = Persistencia.SentenciasSQL.select(sqlEjercicio);
            comboBox_Ejercicio.DisplayMember = "Ejercicio";
            comboBox_Ejercicio.ValueMember = "IdEjercicio";

            String sqlTipo = "SELECT aux_tipoliquidacion.IdTipoLiq, aux_tipoliquidacion.TipoLiq FROM aux_tipoliquidacion;";
            comboBox_TipoLiquiacion.DataSource = Persistencia.SentenciasSQL.select(sqlTipo);
            comboBox_TipoLiquiacion.DisplayMember = "TipoLiq";
            comboBox_TipoLiquiacion.ValueMember = "IdTipoLiq";
            
            //CON FECHAS FILTRO FONDOS ELIMINADO POR AHORA
            //String fondo = "SELECT com_detallesfondo.IdDetalleFondo, com_fondos.NombreFondo FROM(com_detallesfondo INNER JOIN com_fondos ON com_detallesfondo.IdFondo = com_fondos.IdFondo) INNER JOIN com_ejercicios ON com_detallesfondo.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_fondos.IdComunidad) = " + id_comunidad_cargado + ") AND((com_ejercicios.FIni) <= '" + fechaHoy + "') AND ((com_ejercicios.FFin) >= '" + fechaHoy + "' ));";

            String fondo = "SELECT com_detallesfondo.IdDetalleFondo, com_fondos.NombreFondo FROM(com_detallesfondo INNER JOIN com_fondos ON com_detallesfondo.IdFondo = com_fondos.IdFondo) INNER JOIN com_ejercicios ON com_detallesfondo.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_fondos.IdComunidad) = " + id_comunidad_cargado + "));";

            comboBox_Fondo.DataSource = Persistencia.SentenciasSQL.select(fondo);
            comboBox_Fondo.DisplayMember = "NombreFondo";
            comboBox_Fondo.ValueMember = "IdDetalleFondo";


            if (id_liquidacion_cargado != "0")
            {
                cargarDatos();
            }
            else { //comboBox_Fondo.Enabled = false;
            }
        }
        private void cargarDatos() {
            String sqlLiquidacion = "SELECT com_liquidaciones.IdLiquidacion, com_liquidaciones.LiqLargo, com_liquidaciones.FIni, com_liquidaciones.FFin, com_liquidaciones.Ppal, com_liquidaciones.IdTipoLiq, com_liquidaciones.IdFondo, com_liquidaciones.IdEjercicio, com_liquidaciones.liquidacion FROM com_liquidaciones WHERE(((com_liquidaciones.IdLiquidacion) = " + id_liquidacion_cargado + "));";

            DataTable fila_liquidacion = Persistencia.SentenciasSQL.select(sqlLiquidacion);
            textBox_liquidacion.Text = fila_liquidacion.Rows[0][1].ToString();
            textBox_FIni.Text = fila_liquidacion.Rows[0][2].ToString();
            textBox_FFin.Text = fila_liquidacion.Rows[0][3].ToString();
            textBox_liq_corto.Text = fila_liquidacion.Rows[0][8].ToString();

            if (fila_liquidacion.Rows[0][4].ToString() == "True") checkBox_Ppal.Checked = true;

            if (fila_liquidacion.Rows[0][7].ToString() != "") comboBox_Ejercicio.SelectedValue = fila_liquidacion.Rows[0][7].ToString();

            if (fila_liquidacion.Rows[0][5].ToString() == "1") {
                comboBox_TipoLiquiacion.SelectedValue = fila_liquidacion.Rows[0][5].ToString();
                comboBox_Fondo.Enabled = false;
            }

            else if (fila_liquidacion.Rows[0][5].ToString() == "2")  {
                if (fila_liquidacion.Rows[0][6].ToString() != "") comboBox_Fondo.SelectedValue = fila_liquidacion.Rows[0][6].ToString();
                comboBox_TipoLiquiacion.SelectedValue = fila_liquidacion.Rows[0][5].ToString();
                checkBox_Ppal.Enabled = false;
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_TipoLiquiacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox tipo = (ComboBox)sender;

            if (tipo.SelectedValue.ToString() == "2") {
                //comboBox_Fondo.Enabled = true;
                checkBox_Ppal.Checked = false;
                checkBox_Ppal.Enabled = false;
            }
            else {
                //comboBox_Fondo.Enabled = false;
                checkBox_Ppal.Enabled = true;
            }
        }
        private void button_Guardar_Click(object sender, EventArgs e) {
            String principal = "0";
            if (checkBox_Ppal.Checked) principal = "-1";

            String fechaInicio = (Convert.ToDateTime(textBox_FIni.Text)).ToString("yyyy-MM-dd");
            String fechaFin = (Convert.ToDateTime(textBox_FFin.Text)).ToString("yyyy-MM-dd");

            if (checkBox_Ppal.Checked) 
                quitar_principal();

            if (id_liquidacion_cargado != "0" && (comboBox_Fondo.Enabled && comboBox_Fondo.SelectedValue.ToString() != ""))  {
                String sqlUpdate = "UPDATE com_liquidaciones SET IdEjercicio=" + comboBox_Ejercicio.SelectedValue.ToString() + ", Liquidacion= '" + textBox_liq_corto.Text + "', LiqLargo='" + textBox_liquidacion.Text + "', FIni='" + fechaInicio + "', FFin='" + fechaFin + "', Ppal =" + principal + ", IdTipoLiq = " + comboBox_TipoLiquiacion.SelectedValue.ToString() + ", IdDetalleFondo = " + comboBox_Fondo.SelectedValue.ToString() + " WHERE IdLiquidacion = " + id_liquidacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            else if (id_liquidacion_cargado != "0" && ( !comboBox_Fondo.Enabled || comboBox_Fondo.SelectedValue.ToString() == "")){
                String sqlUpdate = "UPDATE com_liquidaciones SET IdEjercicio=" + comboBox_Ejercicio.SelectedValue.ToString() + ", Liquidacion= '" + textBox_liq_corto.Text + "', LiqLargo='" + textBox_liquidacion.Text + "', FIni='" + fechaInicio + "', FFin='" + fechaFin + "', Ppal =" + principal + ", IdTipoLiq = " + comboBox_TipoLiquiacion.SelectedValue.ToString() + " WHERE IdLiquidacion = " + id_liquidacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }else if (id_liquidacion_cargado == "0" && (comboBox_Fondo.Enabled && comboBox_Fondo.SelectedValue.ToString() != "")) {
                String sqlInsert = "INSERT INTO com_liquidaciones (IdEjercicio, Liquidacion, LiqLargo, FIni, FFin, Ppal, IdTipoLiq, IdDetalleFondo) VALUES(" + comboBox_Ejercicio.SelectedValue.ToString() + ",'" + textBox_liq_corto.Text + "','" + textBox_liquidacion.Text + "','" + fechaInicio + "','" + fechaFin + "'," + principal + "," + comboBox_TipoLiquiacion.SelectedValue.ToString() + "," + comboBox_Fondo.SelectedValue.ToString() + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
            else if (id_liquidacion_cargado == "0" && (!comboBox_Fondo.Enabled || comboBox_Fondo.SelectedValue.ToString() == "")) {
                String sqlInsert = "INSERT INTO com_liquidaciones (IdEjercicio, Liquidacion, LiqLargo, FIni, FFin, Ppal, IdTipoLiq) VALUES(" + comboBox_Ejercicio.SelectedValue.ToString() + ",'" + textBox_liq_corto.Text + "','" + textBox_liquidacion.Text + "','" + fechaInicio + "','" + fechaFin + "'," + principal + "," + comboBox_TipoLiquiacion.SelectedValue.ToString() + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
            form_anterior.cargarDatagrid();
            this.Close();
        }
        
        private void quitar_principal() {
            String sqlPrincipal = "UPDATE com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio SET com_liquidaciones.Ppal = 0 WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + "));";

            Persistencia.SentenciasSQL.InsertarGenerico(sqlPrincipal);
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
                comboBox_TipoLiquiacion.Select();
            }
            else
            {
                textBox_FFin.Focus();
                textBox_FFin.Select();
            }
        }
    }
}
