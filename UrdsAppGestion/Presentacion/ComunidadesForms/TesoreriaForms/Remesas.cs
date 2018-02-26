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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    public partial class Remesas : Form
    {
        String idComunidad;
        String idCuenta;
        String tipoRemesa;
        Tesoreria form_anterior;

        public Remesas(Tesoreria form_anterior, String idComunidad,String idCuenta, String tipoRemesa)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.idCuenta = idCuenta;
            this.tipoRemesa = tipoRemesa;
            this.form_anterior = form_anterior;
        }

        private void Remesas_Load(object sender, EventArgs e)
        {
            textBox_comunidad.Text = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Entidad FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + idComunidad + "));")).Rows[0][0].ToString();

            
            textBox_cuenta.Text = idCuenta + " - " + (Persistencia.SentenciasSQL.select("SELECT Descripcion FROM com_cuentas WHERE IdCuenta = " + idCuenta)).Rows[0][0].ToString();

            textBox_tipo.Text = tipoRemesa;

            DataGridViewTextBoxColumn importe = new DataGridViewTextBoxColumn();
            importe.HeaderText = "Importe";
            importe.Name = "Importe";
            importe.Width = 70;
            importe.DefaultCellStyle.Format = "c";
            importe.ReadOnly = true;
            dataGridView_remesas.Columns.Add(importe);

            cargarDatagrid();

        }
        private void cargarDatagrid() {
            String tipo = "1";
            if (tipoRemesa.Contains("Abono")) tipo = "2";

            String remesas = "SELECT com_remesas.IdRemesa, com_remesas.IdTipoRemesa, com_remesas.FEnvio, com_remesas.Remesa FROM com_remesas GROUP BY com_remesas.IdRemesa, com_remesas.IdTipoRemesa, com_remesas.FEnvio, com_remesas.Remesa, com_remesas.IdComunidad, com_remesas.IdEstado, com_remesas.IdCuenta HAVING(((com_remesas.IdTipoRemesa) = " + tipo + ") AND((com_remesas.IdComunidad) = " + idComunidad + ") AND((com_remesas.IdEstado) <> 3) AND((com_remesas.IdCuenta) = " + idCuenta + "));";


            DataTable remesasActivas = Persistencia.SentenciasSQL.select(remesas);
            dataGridView_remesas.DataSource = remesasActivas;

            dataGridView_remesas.Columns["IdTipoRemesa"].Visible = false;

            dataGridView_remesas.Columns["Importe"].DisplayIndex = 4;
            dataGridView_remesas.Columns["Importe"].DefaultCellStyle.Format = "c";

            dataGridView_remesas.Columns["Remesa"].Width = 250;

            for (int a = 0; a < remesasActivas.Rows.Count; a++) {
                String SumaRemesa = "SELECT com_detremesa.IdRemesa, Sum(com_detremesa.Importe) AS SumaDeImporte FROM com_detremesa GROUP BY com_detremesa.IdRemesa HAVING(((com_detremesa.IdRemesa) = " + remesasActivas.Rows[a][0].ToString() + "));";

                DataTable SumaRemesaTable = Persistencia.SentenciasSQL.select(SumaRemesa);
                if (SumaRemesaTable.Rows.Count > 0)
                {
                    if (dataGridView_remesas.Rows[a].Cells[1].Value.ToString() == SumaRemesaTable.Rows[0][0].ToString())
                        dataGridView_remesas.Rows[a].Cells[0].Value = Convert.ToDouble(SumaRemesaTable.Rows[0][1].ToString());
                }
            }
            dataGridView_remesas.Columns["Importe"].DefaultCellStyle.Format = "c";
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            button_aceptar.Enabled = false;
            button_cancelar.Enabled = false;
            progressBar1.Visible = true;
            label_progress.Visible = true;
         

            String varTipoMov;
            DateTime fechaRemesa;
            String fechaInicio;
            String idEjercicioActivo = "";

            if (dataGridView_remesas.SelectedRows.Count > 0 ) {

                if (DateTime.TryParse(maskedTextBox_fecha_apunte.Text, out fechaRemesa)) {
                    if (tipoRemesa == "Remesa de Ingreso") {
                        varTipoMov = "7";
                        try
                        {
                            fechaInicio = (Convert.ToDateTime(fechaRemesa.ToShortDateString())).ToString("yyyy-MM-dd");
                            idEjercicioActivo = Logica.FuncionesTesoreria.ejercicioActivo(idComunidad, fechaInicio);
                        }catch (Exception ex) {
                            MessageBox.Show("No existe el ejercicio Activo " + ex);
                            return;
                        }

                        pteDifRemesa(idEjercicioActivo,varTipoMov, fechaInicio);
                        pteIgualRemesa(idEjercicioActivo, varTipoMov, fechaInicio);
                    }
                    else {
                        varTipoMov = "22";
                        try
                        {
                            fechaInicio = (Convert.ToDateTime(fechaRemesa.ToShortDateString())).ToString("yyyy-MM-dd");
                            idEjercicioActivo = Logica.FuncionesTesoreria.ejercicioActivo(idComunidad, fechaInicio);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No existe el ejercicio Activo " + ex);
                            return;
                        }

                        pteDifRemesa(idEjercicioActivo, varTipoMov, fechaInicio);
                        pteIgualRemesa(idEjercicioActivo, varTipoMov, fechaInicio);
                    }
                }
                else {
                    MessageBox.Show("Fecha Incorrecta");
                    button_aceptar.Enabled = true;
                    button_cancelar.Enabled = true;
                    return;
                }
            }else {
                MessageBox.Show("Debes seleccionar una Remesa");
                button_aceptar.Enabled = true;
                button_cancelar.Enabled = true;
                progressBar1.Visible = false;
                return;
            }

            form_anterior.cargarDatagrid();
            MessageBox.Show(this,"Remesa Ingresada");
            button_aceptar.Enabled = true;
            button_cancelar.Enabled = true;
            this.Close();
        }

        private void pteDifRemesa(String ejercicio, String tipoMov, String fechaRemesa) {
            Double importeBucle;
            String idRecibo;
            String importeDet;
            String importeAsignado;
    
            String sqlRemesa = "SELECT com_detremesa.IdRemesa,com_recibos.IdEntidad, com_detremesa.IdRecibo, com_detremesa.Importe FROM (com_detremesa INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa) INNER JOIN com_recibos ON com_detremesa.IdRecibo = com_recibos.IdRecibo WHERE (((com_detremesa.IdRemesa)=" + dataGridView_remesas.SelectedRows[0].Cells[1].Value.ToString() + ") AND ((com_detremesa.Importe) <> com_recibos.ImpRboPte));";

            DataTable remesa = Persistencia.SentenciasSQL.select(sqlRemesa);

            //MessageBox.Show("Hay " + remesa.Rows.Count + "DIFERENTES");

            for (int a = 0;a < remesa.Rows.Count; a++) {

                importeBucle = Convert.ToDouble(remesa.Rows[a][3].ToString());

                //CREO EL MOVIMIENTO
                int mov = Logica.FuncionesTesoreria.CreaMovimientoRemesa(ejercicio, idCuenta, tipoMov, remesa.Rows[a][1].ToString(), fechaRemesa, tipoRemesa + " " + remesa.Rows[a][0].ToString(), remesa.Rows[a][0].ToString());
                idRecibo = remesa.Rows[a][2].ToString();
    
                String sqlRecibos = "SELECT com_opdetalles.IdRecibo, com_opdetalles.IdOpDet, com_opdetalles.impopdetpte FROM com_opdetalles WHERE com_opdetalles.IdRecibo = " + idRecibo;

                DataTable recibos = Persistencia.SentenciasSQL.select(sqlRecibos);

                for (int b = 0; b < recibos.Rows.Count; b++) {
                    if( tipoMov == "22") {
                        importeDet = recibos.Rows[b][2].ToString().Substring(1);
                    }else {
                        importeDet = recibos.Rows[b][2].ToString();
                    }
                    if (Convert.ToDouble(importeDet) <= importeBucle) {
                        importeAsignado = importeDet;
                        importeBucle = importeBucle - Convert.ToDouble(importeAsignado);
                    }else {
                        importeAsignado = importeBucle.ToString();
                        importeBucle = 0;
                    }
                    
                    if (importeAsignado != "0,00") {
                        Logica.FuncionesTesoreria.CreaDetalleMovimiento(mov.ToString(), recibos.Rows[b][1].ToString(), Logica.FuncionesGenerales.ArreglarImportes(importeAsignado));
                    }
                }
                if (importeBucle >= 0.01)  {
                    if (tipoMov == "22")
                        Logica.FuncionesTesoreria.AbonoComunero(idComunidad, remesa.Rows[a][1].ToString(), fechaRemesa, importeBucle, mov);
                    else
                        Logica.FuncionesTesoreria.AnticipoComunero(idComunidad, remesa.Rows[a][1].ToString(), fechaRemesa, importeBucle, mov);
                }
            }          
        }
        private void pteIgualRemesa(String ejercicio, String tipoMov, String fechaRemesa)
        {
            
            String sqlAddDetMovs;
            try
            {
                String sqlRemesa = "INSERT INTO com_movimientos ( IdEjercicio, IdCuenta, Fecha, IdDetTipoMov, IdRemesa, IdEntidad, Detalle, Aux ) SELECT " + ejercicio + " AS Ejercicio, " + idCuenta + " AS CuentaIngreso , '" + fechaRemesa + "' As FIngreso, " + tipoMov + " AS TipoMov, com_detremesa.IdRemesa, com_recibos.IdEntidad, '" + tipoRemesa + " " + dataGridView_remesas.SelectedRows[0].Cells[1].Value.ToString() + " ' AS MiDesc, com_detremesa.IdRecibo FROM (com_detremesa INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa) INNER JOIN com_recibos ON com_detremesa.IdRecibo = com_recibos.IdRecibo WHERE (com_detremesa.IdRemesa =" + dataGridView_remesas.SelectedRows[0].Cells[1].Value.ToString() + ") AND (com_detremesa.Importe = com_recibos.ImpRboPte);";

                Persistencia.SentenciasSQL.InsertarGenerico(sqlRemesa);

                if (tipoMov == "22")
                {
                    String sqlSelect = "SELECT com_opdetalles.IdOpDet, com_opdetalles.ImpOpDetPte, com_movimientos.IdMov FROM com_opdetalles INNER JOIN com_movimientos ON com_opdetalles.IdRecibo = com_movimientos.Aux WHERE (((com_movimientos.IdRemesa)=" + dataGridView_remesas.SelectedRows[0].Cells[1].Value.ToString() + "));";
                    
                    DataTable filas = Persistencia.SentenciasSQL.select(sqlSelect);
                    progressBar1.Maximum = filas.Rows.Count;
                    if (filas.Rows.Count > 700) MessageBox.Show("El proceso tardará sobre 3 minutos. ");
                    this.Cursor = Cursors.WaitCursor;
                    for (int a = 0; a < filas.Rows.Count; a++)
                    {
                        sqlAddDetMovs = "INSERT INTO com_detmovs ( IdOpDet, Importe, ImpDetMovSale, ImpDetMovNeto, IdMov ) VALUES (" + filas.Rows[a][0].ToString() + ", -" + Logica.FuncionesGenerales.ArreglarImportes(filas.Rows[a][1].ToString()) + ",-" + Logica.FuncionesGenerales.ArreglarImportes(filas.Rows[a][1].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(filas.Rows[a][1].ToString()) + " ," + filas.Rows[a][2].ToString() + " )";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlAddDetMovs);
                        progressBar1.Value = a;
                    }
                }
                else
                {
                    String sqlSelect = "SELECT com_opdetalles.IdOpDet, com_opdetalles.ImpOpDetPte, com_movimientos.IdMov FROM com_opdetalles INNER JOIN com_movimientos ON com_opdetalles.IdRecibo = com_movimientos.Aux WHERE (((com_movimientos.IdRemesa)=" + dataGridView_remesas.SelectedRows[0].Cells[1].Value.ToString() + "));";

                    DataTable filas = Persistencia.SentenciasSQL.select(sqlSelect);
                    progressBar1.Maximum = filas.Rows.Count;
                    if (filas.Rows.Count > 700) MessageBox.Show("El proceso tardará sobre 3 minutos. ");
                    this.Cursor = Cursors.WaitCursor;

                    for (int a = 0; a < filas.Rows.Count; a++)
                    {
                        sqlAddDetMovs = "INSERT INTO com_detmovs ( IdOpDet, Importe, ImpDetMovEntra, ImpDetMovNeto, IdMov ) VALUES (" + filas.Rows[a][0].ToString() + ", " + Logica.FuncionesGenerales.ArreglarImportes(filas.Rows[a][1].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(filas.Rows[a][1].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(filas.Rows[a][1].ToString()) + " ," + filas.Rows[a][2].ToString() + " )";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlAddDetMovs);
                        progressBar1.Value = a;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al pagar Remesa " + ex);
                return;
            }
            this.Cursor = Cursors.Arrow;
            String strActRem = "UPDATE com_remesas SET com_remesas.IdEstado = 3 WHERE (((com_remesas.IdRemesa)=" + dataGridView_remesas.SelectedRows[0].Cells[1].Value.ToString() + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(strActRem);
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBox_fecha_apunte_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBox_fecha_apunte.Text, sPattern))
            {
                maskedTextBox_fecha_apunte.Text = maskedTextBox_fecha_apunte.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBox_fecha_apunte.Text, sPattern1))
            {
                button_aceptar.Select();
            }
            else
            {
                maskedTextBox_fecha_apunte.Focus();
                maskedTextBox_fecha_apunte.Select();
            }
        }
    }
}
