using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    public partial class FormOperacionesLiquidacion : Form
    {
        String id_comunidad_cargado;
        String id_operacion_cargado = "0";
        String importe_cargado;
        String guardada = "no";
        FromOperacionesVer form_anterior;
        Boolean vengoDePantallaVer = false;

        List<String> filas_eliminadas = new List<String>();

        public FormOperacionesLiquidacion(FromOperacionesVer form_anterior, String id_comunidad_cargado, String id_operacion_cargado,String importe_cargado , Boolean vengoDePantallaVer)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_operacion_cargado = id_operacion_cargado;
            this.importe_cargado = importe_cargado;
            this.vengoDePantallaVer = vengoDePantallaVer;
        }

        public FormOperacionesLiquidacion(String id_comunidad_cargado, String id_operacion_cargado,String importe_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_operacion_cargado = id_operacion_cargado;
            this.importe_cargado = importe_cargado;
        }

        private void FormOperacionesLiquidacion_Load(object sender, EventArgs e)
        {

            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.HeaderText = "ID";

            DataGridViewTextBoxColumn idLiquidacion = new DataGridViewTextBoxColumn();
            idLiquidacion.HeaderText = "IdLiquidacion";

            DataGridViewTextBoxColumn liquidacion = new DataGridViewTextBoxColumn();
            liquidacion.HeaderText = "Liquidacion";
            liquidacion.ReadOnly = true;

            DataGridViewTextBoxColumn porcentaje = new DataGridViewTextBoxColumn();
            porcentaje.HeaderText = "%";

            DataGridViewTextBoxColumn importe = new DataGridViewTextBoxColumn();
            importe.HeaderText = "Importe";

            dataGridView_liquidacion.Columns.Add(id);
            dataGridView_liquidacion.Columns.Add(liquidacion);
            dataGridView_liquidacion.Columns.Add(porcentaje);
            dataGridView_liquidacion.Columns.Add(importe);
            dataGridView_liquidacion.Columns.Add(idLiquidacion);

            dataGridView_liquidacion.Columns[0].Name = "ID";
            dataGridView_liquidacion.Columns[1].Name = "Liquidacion";
            dataGridView_liquidacion.Columns[2].Name = "%";
            dataGridView_liquidacion.Columns[3].Name = "Importe";
            dataGridView_liquidacion.Columns[4].Name = "IdLiquidacion";

            dataGridView_liquidacion.Columns[0].Visible = false;
            dataGridView_liquidacion.Columns[4].Visible = false;

            textBox_importe_op.Text = importe_cargado.ToString();

            cargarLiquidaciones();
        }
        public void cargarLiquidaciones() {
            decimal importeActual = Convert.ToDecimal(0.00);

            if (id_operacion_cargado != "0")
            {
                String sqlSelectLiquidacion = "SELECT com_opdetliquidacion.IdDetOpLiq, com_liquidaciones.Liquidacion, com_opdetliquidacion.Porcentaje, com_opdetliquidacion.Importe, com_opdetliquidacion.IdLiquidacion FROM com_opdetliquidacion INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion WHERE(((com_opdetliquidacion.IdOp) = " + id_operacion_cargado + "));";

                DataTable liquidaciones = Persistencia.SentenciasSQL.select(sqlSelectLiquidacion);
                if (liquidaciones.Rows.Count > 0)
                {
                    for (int a = 0; a < liquidaciones.Rows.Count; a++)
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView_liquidacion.Rows[0].Clone();
                        row.Cells[0].Value = liquidaciones.Rows[a][0].ToString();
                        row.Cells[1].Value = liquidaciones.Rows[a][1];

                        decimal porcentaje2 = Convert.ToDecimal(string.Format("{0:F2}", liquidaciones.Rows[a][2].ToString())) * 100;
                        row.Cells[2].Value = porcentaje2.ToString();

                        row.Cells[3].Value = liquidaciones.Rows[a][3].ToString();
                        row.Cells[4].Value = liquidaciones.Rows[a][4].ToString();

                        if (comprobarLiquidacionCerrada(liquidaciones.Rows[a][4].ToString())) {
                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.ReadOnly = true;
                            row.DefaultCellStyle.ForeColor = Color.White;
                            dataGridView_liquidacion.Enabled = false;
                            button_guardar.Enabled = false;
                        }
                        dataGridView_liquidacion.Rows.Add(row);

                        importeActual = importeActual + Convert.ToDecimal(string.Format("{0:F2}", liquidaciones.Rows[a][3].ToString()));
                    }
                }
                textBox_importe_actual.Text = importeActual.ToString("N2");
            }

            //LIQUIDACION POR DEFECTO
            if (!vengoDePantallaVer)
            {
                String sqlSelect = "SELECT com_liquidaciones.IdLiquidacion, com_liquidaciones.Liquidacion FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_liquidaciones.Ppal) = -1) AND((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + ") AND((com_liquidaciones.Cerrada) <> -1));";
                DataTable liquidacionActiva = Persistencia.SentenciasSQL.select(sqlSelect);
                if (liquidacionActiva.Rows.Count > 0) {

                    DataGridViewRow row = (DataGridViewRow)dataGridView_liquidacion.Rows[0].Clone();
                    row.Cells[1].Value = liquidacionActiva.Rows[0][1].ToString();
                    row.Cells[4].Value = liquidacionActiva.Rows[0][0].ToString();
                    row.Cells[2].Value = 100;
                    row.Cells[3].Value = importe_cargado;
                    dataGridView_liquidacion.Rows.Add(row);
                    textBox_importe_actual.Text = importe_cargado.ToString();
                }
                button_guardar.Select();
            }
        }
        private Boolean comprobarLiquidacionCerrada(String idLiquidacion) {
            if ((Persistencia.SentenciasSQL.select("SELECT com_liquidaciones.Cerrada FROM com_liquidaciones WHERE(((com_liquidaciones.IdLiquidacion) = " + idLiquidacion + ")); ")).Rows[0][0].ToString() == "True")
                return true;
            else
                return false;
        }
        private void dataGridView_liquidacion_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            double importeActual = Convert.ToDouble(0.00);

            if (e.ColumnIndex == 2 && !dataGridView_liquidacion.Rows[e.RowIndex].IsNewRow)
            {
                if (dataGridView_liquidacion.Rows[e.RowIndex].Cells[2].Value != null && dataGridView_liquidacion.Rows[e.RowIndex].Cells[2].Value.ToString() != "")  {
                    decimal porcentaje = Convert.ToDecimal(string.Format("{0:F2}",dataGridView_liquidacion.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    decimal importe = Convert.ToDecimal(string.Format("{0:F2}", importe_cargado));
                    decimal total = Convert.ToDecimal(string.Format("{0:F2}", importe * porcentaje / 100));

                    dataGridView_liquidacion.Rows[e.RowIndex].Cells[3].Value = total;
                }
            }else if (e.ColumnIndex == 3 && !dataGridView_liquidacion.Rows[e.RowIndex].IsNewRow) {

                double importe = Convert.ToDouble(importe_cargado);
                double importeS = Convert.ToDouble(dataGridView_liquidacion.Rows[e.RowIndex].Cells[3].Value.ToString().Replace(".",","));
                        double total = Convert.ToDouble(importeS / importe);

                dataGridView_liquidacion.Rows[e.RowIndex].Cells[2].Value = Math.Truncate(total*100).ToString("N2");
                dataGridView_liquidacion.Rows[e.RowIndex].Cells[3].Value = dataGridView_liquidacion.Rows[e.RowIndex].Cells[3].Value.ToString().Replace(".",",");
            }

                for (int a = 0; a < dataGridView_liquidacion.Rows.Count; a++)
            {
                if (dataGridView_liquidacion.Rows[a].Cells[3].Value != null)
                {
                    double importeS = Convert.ToDouble(dataGridView_liquidacion.Rows[a].Cells[3].Value);
                    importeActual = importeActual + importeS;
                    textBox_importe_actual.Text = importeActual.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (comprobarImporte())
            {
                for (int a = 0; a < dataGridView_liquidacion.Rows.Count; a++)
                {
                    if (filas_eliminadas.Count > 0) {
                        eliminar_filas();
                    }
                    if (dataGridView_liquidacion.Rows[a].Cells[3].Value != null && dataGridView_liquidacion.Rows[a].Cells[0].Value != null) {
                        actualizar_filasReparto(dataGridView_liquidacion.Rows[a].Cells[0].Value.ToString(), dataGridView_liquidacion.Rows[a].Cells[4].Value.ToString(), dataGridView_liquidacion.Rows[a].Cells[2].Value.ToString(), dataGridView_liquidacion.Rows[a].Cells[3].Value.ToString());
                    }
                    else if (dataGridView_liquidacion.Rows[a].Cells[3].Value != null && dataGridView_liquidacion.Rows[a].Cells[0].Value == null)  {
                        insertar_filasReparto(dataGridView_liquidacion.Rows[a].Cells[4].Value.ToString(), dataGridView_liquidacion.Rows[a].Cells[2].Value.ToString(), dataGridView_liquidacion.Rows[a].Cells[3].Value.ToString());
                    }
                }

                //Si el Tipo de Reparto es <> 1 - > generar operación de ingreso 7001. La op de ingreso se registra en IdOpCrea
                //Para cada liquidación, crear operaciones para cada reparto

                bool varliquidable;
                String TipoReparto = (Persistencia.SentenciasSQL.select("SELECT IdTipoReparto FROM com_operaciones WHERE IdOp = " + id_operacion_cargado)).Rows[0][0].ToString();
                String TipoSubcuenta = (Persistencia.SentenciasSQL.select("SELECT IdSubCuenta FROM com_operaciones WHERE IdOp = " + id_operacion_cargado)).Rows[0][0].ToString();

                if ((Convert.ToInt32(TipoSubcuenta) >= 60000 && Convert.ToInt32(TipoSubcuenta) <= 69999 ) || (Convert.ToInt32(TipoSubcuenta) >= 70100 && Convert.ToInt32(TipoSubcuenta) <= 76900))
                    varliquidable = true;
                else
                    varliquidable = false;

                if (TipoReparto != "1" && varliquidable) {

                    String varOpCrea = (Persistencia.SentenciasSQL.select("SELECT IdOpCrea FROM com_operaciones WHERE IdOp = " + id_operacion_cargado)).Rows[0][0].ToString();

                    String sqlBloqsOp = "SELECT com_opdetbloques.IdOp, com_opdetbloques.IdDivision, com_opdetbloques.IdEntidad, com_opdetbloques.Porcentaje From com_opdetbloques WHERE com_opdetbloques.IdOp = " + id_operacion_cargado;
                    DataTable BloqsOp = Persistencia.SentenciasSQL.select(sqlBloqsOp);

                    String sqlLiqsOp = "SELECT com_opdetliquidacion.IdOp, com_opdetliquidacion.IdLiquidacion, com_opdetliquidacion.Porcentaje, com_opdetliquidacion.Importe From com_opdetliquidacion WHERE com_opdetliquidacion.IdOp = " + id_operacion_cargado;
                    DataTable LiqsOp = Persistencia.SentenciasSQL.select(sqlLiqsOp);

                    int TotalLiqs = LiqsOp.Rows.Count;
                    int CuentaLiqs = 1;
                    
                    for (int a = 0; a < LiqsOp.Rows.Count; a++) {
                        for (int b = 0; b < LiqsOp.Rows.Count; b++)  {
                            String varImpReparto = (Convert.ToDouble(LiqsOp.Rows[a][3].ToString()) * Convert.ToDouble(LiqsOp.Rows[a][2].ToString())).ToString();
                            String strCuentaLiqs = CuentaLiqs + "/" + TotalLiqs;

                            if (strCuentaLiqs == "1/1")
                                strCuentaLiqs = "";

                            if (TipoReparto == "2")
                            {
                                Logica.FuncionesTesoreria.CreaOP_PartDiv(id_comunidad_cargado, BloqsOp.Rows[b][1].ToString(), LiqsOp.Rows[a][1].ToString(), varImpReparto.Replace(",","."), id_operacion_cargado, strCuentaLiqs);

                            }
                        }
                        CuentaLiqs++;
                    }

                }
                if (vengoDePantallaVer) {
                    form_anterior.cargarOperacion(id_operacion_cargado);
                }else {
                    FromOperacionesVer nueva = new FromOperacionesVer(id_operacion_cargado, 1,id_comunidad_cargado);
                    nueva.Show();
                }
                guardada = "si";
                this.Close();
            }
            else
            {
                MessageBox.Show("Revise los importes, el total es : " + textBox_importe_actual.Text + " y debe ser " + textBox_importe_op.Text);
            }
        }
        private void eliminar_filas() {
            for (int a = 0; a < filas_eliminadas.Count; a++) {
                String sqlDelete = "DELETE FROM com_opdetliquidacion WHERE IdDetOpLiq = " + filas_eliminadas[a];
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
            }
        }
        private void insertar_filasReparto(String id_liquidacion, String porcentaje, String importe)
        {
            if (importe != "0")
            {
                decimal porcentaje_2 = Convert.ToDecimal(string.Format("{0:F2}", porcentaje));
                decimal porcentaje_1 = porcentaje_2 / 100;

                String sqlInsert = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES(" + id_operacion_cargado + "," + id_liquidacion + "," + Logica.FuncionesGenerales.ArreglarImportes(porcentaje_1.ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(importe) + ")";


                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
        }

        private void actualizar_filasReparto(String id_liquidaciondet, String id_liquidacion, String porcentaje, String importe)
        {
            if (importe != "0")  {
                decimal porcentaje_2 = Convert.ToDecimal(string.Format("{0:F2}", porcentaje));
                decimal porcentaje_1 = porcentaje_2 / 100;

                String sqlUpdate = "UPDATE com_opdetliquidacion SET IdLiquidacion=" + id_liquidacion + ", Porcentaje=" + Logica.FuncionesGenerales.ArreglarImportes(porcentaje_1.ToString()) + ", Importe=" + Logica.FuncionesGenerales.ArreglarImportes(importe) + " WHERE IdDetOpLiq = " + id_liquidaciondet;

                 Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
        }

        public Boolean comprobarImporte()
        {
            if (Convert.ToDouble(textBox_importe_actual.Text).Equals(Convert.ToDouble(textBox_importe_op.Text)))
                return true;
            else
                return false;
        }

        private void dataGridView_liquidacion_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        private void dataGridView_liquidacion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView_liquidacion.CurrentCell.ColumnIndex == 1)
            {
                id_comunidad_cargado = (Persistencia.SentenciasSQL.select("SELECT IdComunidad FROM com_operaciones WHERE com_operaciones.IdOp = " + id_operacion_cargado + ";")).Rows[0][0].ToString();
                LiquidacionesForms.Liquidaciones nueva = new LiquidacionesForms.Liquidaciones(this, this.Name, id_comunidad_cargado);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                var hti = dataGridView_liquidacion.HitTest(e.X, e.Y);
                dataGridView_liquidacion.ClearSelection();
                dataGridView_liquidacion.Rows[hti.RowIndex].Selected = true;
                nueva.comboBox_filtro.Visible = false;
                nueva.comboBox_informes.Visible = false;
                nueva.label1.Visible = false;
                nueva.label2.Visible = false;
                nueva.Show();
            }
        }
        public void recogerBloque(String id_liquidacion, String nombre_liquidacion)
        {
            dataGridView_liquidacion.SelectedCells[1].Value = nombre_liquidacion;
            dataGridView_liquidacion.SelectedCells[4].Value = id_liquidacion;

            //COMPRUEBO QUE SI ES DE STOCK, INTRODUZCAN LOS VALORES PERTINENTES.
            String sqlSelect = "SELECT com_fondos.IdFondo, com_fondos.Stock FROM com_fondos INNER JOIN com_liquidaciones ON com_fondos.IdFondo = com_liquidaciones.IdFondo WHERE com_liquidaciones.IdLiquidacion =" + id_liquidacion;

            DataTable esStock = Persistencia.SentenciasSQL.select(sqlSelect);

            if (esStock.Rows.Count > 0) {
               if (esStock.Rows[0][1].ToString() == "True" ) {
                    FondosForms.FormModificarStock nueva = new FondosForms.FormModificarStock(esStock.Rows[0][0].ToString(),"+");
                    nueva.Show();
                }
            }

        }

        private void dataGridView_liquidacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Tab)
            {
                if (dataGridView_liquidacion.CurrentRow.IsNewRow == true && dataGridView_liquidacion.Rows.Count > 1)
                {
                    dataGridView_liquidacion.ClearSelection();
                    button_guardar.Select();
                }
            }
            else if (e.KeyChar == (Char)Keys.Enter)  {
                if (dataGridView_liquidacion.CurrentCell.ColumnIndex == 1)  {

                    id_comunidad_cargado = (Persistencia.SentenciasSQL.select("SELECT IdComunidad FROM com_operaciones WHERE com_operaciones.IdOp = " + id_operacion_cargado + ";")).Rows[0][0].ToString();

                    LiquidacionesForms.Liquidaciones nueva = new LiquidacionesForms.Liquidaciones(this, this.Name, id_comunidad_cargado);
                    nueva.ControlBox = true;
                    nueva.TopMost = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    dataGridView_liquidacion.ClearSelection();
                    dataGridView_liquidacion.Rows[dataGridView_liquidacion.CurrentRow.Index].Selected = true;
                    nueva.Show();
                }
            }

        }

        private void dataGridView_liquidacion_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            filas_eliminadas.Add(e.Row.Cells[0].Value.ToString());
        }

        private void FormOperacionesLiquidacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (guardada == "no")
                CerrarborrarOperacionEnCurso();
        }

        private void CerrarborrarOperacionEnCurso()  {

            if (!vengoDePantallaVer)  {

                //BORRO LOS IVAS
                String sqlDeleteIVA = "DELETE FROM com_opdetiva WHERE IdOp = " + id_operacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteIVA);

                //BORRO EL REPARTO
                String sqlDeleteReparto = "DELETE FROM com_opdetbloques WHERE IdOp = " + id_operacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteReparto);

                //BORRO VENCIMIENTOS
                String sqlVencimientos = "DELETE FROM com_opdetalles WHERE IdOp = " + id_operacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlVencimientos);

                //TENGO QUE BORRAR LO ANTERIOR
                String sqlDelete = "DELETE FROM com_operaciones WHERE IdOp = " + id_operacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);

                String sqlDeleteRecibo = "DELETE FROM com_recibos WHERE IdOpCrea = " + id_operacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteRecibo);

                MessageBox.Show("Operación Borrada");
            }

        }
    }
}
