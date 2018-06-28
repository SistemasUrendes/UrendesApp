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
    public partial class FormFondosAlta : Form
    {
        String id_comunidad_cargado;
        FondosForms.FormFondos form_anterior;
        String id_fondo_cargado = "0";
        String id_bloque_nuevo;

        public FormFondosAlta(FormFondos form_anterior, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
        }

        public FormFondosAlta(FormFondos form_anterior, String id_comunidad_cargado, String id_fondo_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
            this.id_fondo_cargado = id_fondo_cargado;
        }

        private void FormFondosAlta_Load(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT IdTipoCuota, TipoCuota FROM com_tipocuotas";
            comboBox_tipoFondo.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            comboBox_tipoFondo.DisplayMember = "TipoCuota";
            comboBox_tipoFondo.ValueMember = "IdTipoCuota";

            if (id_fondo_cargado != "0") {
                String sqlSelect1 = "SELECT NombreFondo, IdBloque, IdSubCuenta, TipoFondo FROM com_fondos WHERE IdFondo = " + id_fondo_cargado;
                DataTable fila = Persistencia.SentenciasSQL.select(sqlSelect1);
                textBox_nombre.Text = fila.Rows[0][0].ToString();
                maskedTextBox_idsucuenta.Text = fila.Rows[0][2].ToString();
                id_bloque_nuevo = fila.Rows[0][1].ToString();
                textBox_bloque.Text = (Persistencia.SentenciasSQL.select("SELECT Descripcion FROM com_bloques WHERE IdBloque = " + id_bloque_nuevo)).Rows[0][0].ToString();
                comboBox_tipoFondo.SelectedValue = fila.Rows[0][3].ToString();
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String stock = "0";

            if (checkBox_stock.Checked) stock = "1";

            if (id_fondo_cargado != "0")  {
                String sqlUpdate = "UPDATE com_fondos SET NombreFondo='" + textBox_nombre.Text + "', IdSubCuenta=" + maskedTextBox_idsucuenta.Text + ", IdBloque=" + id_bloque_nuevo + ", TITSUBCTA = '" + textBox_subcuenta.Text + "', TipoFondo = " + comboBox_tipoFondo.SelectedValue.ToString() + ", Stock = '" + stock + "' WHERE IdFondo = " + id_fondo_cargado;

                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                form_anterior.cargarDatagrid();
                this.Close();

            }
            else {

                String sqlInsert = "INSERT INTO com_fondos (IdComunidad, TipoFondo, NombreFondo, IdSubCuenta, IdBloque, TITSUBCTA, Stock ) VALUES (" + id_comunidad_cargado + "," + comboBox_tipoFondo.SelectedValue.ToString() + ",'" + textBox_nombre.Text + "'," + maskedTextBox_idsucuenta.Text + "," + id_bloque_nuevo + ",'" + textBox_subcuenta.Text  + "', '" + stock + "' )";

                int idFondo = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert);
                
                if (comboBox_tipoFondo.SelectedValue.ToString() == "2") { 

                //CREO LIQUIDACIÓN 
                //COMPRUEBO QUE NO HAY NINGUNA LIQUIDACION CREADA PARA ESE FONDO
                String sqlSelectLiq = "SELECT IdLiquidacion FROM com_liquidaciones WHERE IdFondo = " + idFondo;
                DataTable LiqFondo = Persistencia.SentenciasSQL.select(sqlSelectLiq);

                    if (LiqFondo.Rows.Count == 0)
                    {
                        String fechaHoy = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
                        String idEjercicioActivo = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaHoy);
                        String sqlFechas = "SELECT FIni, FFin FROM com_ejercicios WHERE IdEjercicio = " + idEjercicioActivo;
                        DataTable fechasEjer = Persistencia.SentenciasSQL.select(sqlFechas);

                        String sqlInsertLiqui = "INSERT INTO com_liquidaciones (IdEjercicio, Liquidacion, LiqLargo, FIni, FFin, IdTipoLiq, IdFondo) VALUES (" + idEjercicioActivo + ",'" + textBox_nombre.Text + "','" + textBox_nombre.Text + "','" + (Convert.ToDateTime(fechasEjer.Rows[0][0].ToString())).ToString("yyyy-MM-dd") + "','" + (Convert.ToDateTime(fechasEjer.Rows[0][1].ToString())).ToString("yyyy-MM-dd") + "',2," + idFondo + ")";

                        int liqNueva = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertLiqui);

                        //MessageBox.Show("Se ha creado una liquidación pasa ese fondo");

                        //REVISAR IdMetodo
                        //CREO UNA CUOTA
                        //String sqlInsertCuota = "INSERT INTO com_cuotas (Descripcion, IdLiquidacion, IdTipoCuota, IdFondo, IdMetodo, FIni, FFin, FEmision, FVto, IdEstado) VALUES ('" + textBox_nombre.Text + "'," + liqNueva + ",2," + idFondo + ",2,'" + (Convert.ToDateTime(fechasEjer.Rows[0][0].ToString())).ToString("yyyy-MM-dd") + "','" + (Convert.ToDateTime(fechasEjer.Rows[0][1].ToString())).ToString("yyyy-MM-dd") + "','" + (Convert.ToDateTime(fechasEjer.Rows[0][0].ToString())).ToString("yyyy-MM-dd") + "','" + (Convert.ToDateTime(fechasEjer.Rows[0][1].ToString())).ToString("yyyy-MM-dd") + "',1)";
                        //Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertCuota);

                        //MessageBox.Show("Se ha creado una CUOTA pasa ese fondo");

                        if (checkBox_stock.Checked)
                        {
                            //SI ES STOCK CREO UNA FILA POR CADA VALOR QUE SE QUIERA
                            FormCrearStock nueva = new FormCrearStock(idFondo.ToString());
                            nueva.Show();
                        }
                    }

                }

                form_anterior.cargarDatagrid();
                this.Close();
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_seleccionar_boton_Click(object sender, EventArgs e)
        {
            ProvisionesForms.FormCuentasExistentes nueva = new ProvisionesForms.FormCuentasExistentes(this,this.Name,id_comunidad_cargado);
            nueva.Show();
        }
        public void recogerSubcuenta(String id_cuenta, String nombre_cuenta)
        {
            maskedTextBox_idsucuenta.Text = id_cuenta;
            textBox_subcuenta.Text = nombre_cuenta;
        }

        private void button_seleccionarbloque_Click(object sender, EventArgs e)
        {
            BloquesForms.Bloques nueva = new BloquesForms.Bloques(this, this.Name, id_comunidad_cargado);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void recogerBloque(String id_bloque, String nombre_bloque) {
            id_bloque_nuevo = id_bloque;
            textBox_bloque.Text = nombre_bloque;
        }
    }
}
