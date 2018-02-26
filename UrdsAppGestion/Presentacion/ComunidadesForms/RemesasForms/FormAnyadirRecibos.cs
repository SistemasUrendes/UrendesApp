using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Logica;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.RemesasForms
{
    public partial class FormAnyadirRecibos : Form
    {
        String id_comunidad;
        String id_remesa;
        FormDetalleRemesa form_anterior;
        int celdaAsignado, celdaBoton;
        int celdaImpRemesa = 0;

        DataTable recibos;
        double totalRecibos = 0.00;
        Boolean PantallaAsignado = false;
        Boolean cargadoDatagrid = false;

        List<ReciboRemesa> aRemesa = new List<ReciboRemesa>();

        public FormAnyadirRecibos(FormDetalleRemesa form_anterior, String id_comunidad, String id_remesa)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad = id_comunidad;
            this.id_remesa = id_remesa;
        }

        private void AnyadirRecibos_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
            cargadoDatagrid = true;

            //CARGO COMBOBOX CUOTAS
            String comboCuotas = "SELECT com_cuotas.IdCuota, com_cuotas.Descripcion, com_cuotas.IdEstado FROM(com_cuotas INNER JOIN com_liquidaciones ON com_cuotas.IdLiquidacion = com_liquidaciones.IdLiquidacion) INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad + ") AND((com_cuotas.IdEstado) > 0)) ORDER BY com_cuotas.IdCuota DESC LIMIT 5;";
            
            DataTable dataCombo = Persistencia.SentenciasSQL.select(comboCuotas);

            comboBox_cuota.DataSource = Persistencia.SentenciasSQL.select(comboCuotas);
            comboBox_cuota.DisplayMember = "Descripcion";
            comboBox_cuota.ValueMember = "IdCuota";
            comboBox_formaPago.SelectedIndex = 2;

        }
        private void cargarDatagrid() {

            String tipoRemesa = "SELECT IdTipoRemesa FROM com_remesas WHERE IdRemesa = " + id_remesa;
            tipoRemesa = Persistencia.SentenciasSQL.select(tipoRemesa).Rows[0][0].ToString();
        
            if (tipoRemesa == "2") {//PAGO

                //CUIDADO: HAGO BASTANTES COSAS CON ESTA SQL.
                //MIRO SI HAY IMPORTE EN OTRAS REMESAS Y SI ES IGUAL AL PENDEINTE NO MUESTRO ESE RECIBO
                //MIRO SI EXISTE UN IDCC EN EL RECIBO Y SI HAY MUESTRO ESE SINO MUESTRO EL PRINCIPAL DEL COMUNERO
                String sqlSelectRecibos = "SELECT com_recibos.IdComunidad, com_recibos.IdRecibo, com_recibos.Fecha, com_recibos.Referencia, com_recibos.IdEntidad, ctos_entidades.Entidad, com_comuneros.IdFormaPago, aux_formapago.FormaPago, If(com_recibos.IdCC <> '',com_recibos.IdCC,com_comuneros.IdCC) AS IdCC, ctos_detbancos.CC, com_recibos.ImpRbo, com_recibos.ImpRboPte AS Pte, com_recibos.IdCuota, If(Exists (SELECT * FROM com_detremesa INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa WHERE (((com_detremesa.IdRecibo) = com_recibos.IdRecibo) AND ((com_remesas.IdEstado)<3))),(SELECT Sum(Importe) FROM com_detremesa INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa WHERE com_detremesa.IdRecibo=com_recibos.IdRecibo AND com_remesas.IdEstado < 3 ),0) AS RemesaPte FROM(((com_recibos LEFT JOIN com_comuneros ON(com_recibos.IdEntidad = com_comuneros.IdEntidad) AND(com_recibos.IdComunidad = com_comuneros.IdComunidad)) INNER JOIN ctos_entidades ON com_recibos.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN aux_formapago ON com_comuneros.IdFormaPago = aux_formapago.IdFormaPago) LEFT JOIN ctos_detbancos ON If(com_recibos.IdCC <> '',com_recibos.IdCC,com_comuneros.IdCC) = ctos_detbancos.IdCuenta WHERE(((com_recibos.IdComunidad) = " + id_comunidad + ") AND((com_comuneros.IdFormaPago) <= 2) AND(Not(com_comuneros.IdCC) Is Null) AND((com_recibos.ImpRboPte) < 0) AND (If(Exists (SELECT * FROM com_detremesa INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa WHERE (((com_detremesa.IdRecibo) = com_recibos.IdRecibo) AND ((com_remesas.IdEstado)<3))),(SELECT Sum(Importe) FROM com_detremesa INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa WHERE com_detremesa.IdRecibo=com_recibos.IdRecibo AND com_remesas.IdEstado < 3 ),0) <> com_recibos.ImpRboPte) ) ORDER BY com_recibos.Fecha DESC, com_recibos.IdEstado;";

                recibos = Persistencia.SentenciasSQL.select(sqlSelectRecibos);
                dataGridView_recibos.DataSource = recibos;
            }
            else if (tipoRemesa == "1")  {//COBRO
            
                //CUIDADO: HAGO BASTANTES COSAS CON ESTA SQL.
                //MIRO SI HAY IMPORTE EN OTRAS REMESAS Y SI ES IGUAL AL PENDIENTE NO MUESTRO ESE RECIBO
                //MIRO SI EXISTE UN IDCC EN EL RECIBO Y SI HAY MUESTRO ESE, SINO MUESTRO EL PRINCIPAL DEL COMUNERO
                String sqlSelectRecibos = "SELECT com_recibos.IdComunidad, com_recibos.IdRecibo, com_recibos.Fecha, com_recibos.Referencia, com_recibos.IdEntidad, ctos_entidades.Entidad, com_comuneros.IdFormaPago, aux_formapago.FormaPago, If(com_recibos.IdCC <> '',com_recibos.IdCC,com_comuneros.IdCC) AS IdCC, ctos_detbancos.CC, com_recibos.ImpRbo, com_recibos.ImpRboPte AS Pte, com_recibos.IdCuota, If(Exists (SELECT * FROM com_detremesa INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa WHERE (((com_detremesa.IdRecibo) = com_recibos.IdRecibo) AND ((com_remesas.IdEstado)<3))),(SELECT Sum(Importe) FROM com_detremesa INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa WHERE com_detremesa.IdRecibo=com_recibos.IdRecibo AND com_remesas.IdEstado < 3 ),0) AS RemesaPte FROM(((com_recibos LEFT JOIN com_comuneros ON(com_recibos.IdEntidad = com_comuneros.IdEntidad) AND(com_recibos.IdComunidad = com_comuneros.IdComunidad)) INNER JOIN ctos_entidades ON com_recibos.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN aux_formapago ON com_comuneros.IdFormaPago = aux_formapago.IdFormaPago) LEFT JOIN ctos_detbancos ON If(com_recibos.IdCC <> '',com_recibos.IdCC,com_comuneros.IdCC) = ctos_detbancos.IdCuenta WHERE(((com_recibos.IdComunidad) = " + id_comunidad + ") AND((com_comuneros.IdFormaPago) <= 2) AND(Not(com_comuneros.IdCC) Is Null) AND((com_recibos.ImpRboPte) > 0) AND (If(Exists (SELECT * FROM com_detremesa INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa WHERE (((com_detremesa.IdRecibo) = com_recibos.IdRecibo) AND ((com_remesas.IdEstado)<3))),(SELECT Sum(Importe) FROM com_detremesa INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa WHERE com_detremesa.IdRecibo=com_recibos.IdRecibo AND com_remesas.IdEstado < 3 ),0) <> com_recibos.ImpRboPte) ) ORDER BY com_recibos.Fecha DESC, com_recibos.IdEstado;";

                recibos = Persistencia.SentenciasSQL.select(sqlSelectRecibos);
                dataGridView_recibos.DataSource = recibos;
            }

           
            DataGridViewTextBoxColumn espacio = new DataGridViewTextBoxColumn();
            espacio.HeaderText = "";
            espacio.Name = "Vacio";
            espacio.Width = 10;
            espacio.DefaultCellStyle.BackColor = Color.Gray;
            dataGridView_recibos.Columns.Add(espacio);

            DataGridViewTextBoxColumn cuanto = new DataGridViewTextBoxColumn();
            cuanto.HeaderText = "Cantidad";
            cuanto.Name = "Cantidad";
            cuanto.Width = 80;
            cuanto.DefaultCellStyle.Format = "N";
            cuanto.DefaultCellStyle.NullValue = "0";
            cuanto.ReadOnly = false;
            cuanto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_recibos.Columns.Add(cuanto);
            celdaAsignado = dataGridView_recibos.Columns["Cantidad"].Index;

            //DataGridViewTextBoxColumn ImpRemesa = new DataGridViewTextBoxColumn();
            //ImpRemesa.DisplayIndex = espacio.Index;
            //ImpRemesa.HeaderText = "ImpRemesa";
            //ImpRemesa.Name = "ImpRemesa";
            //ImpRemesa.Width = 80;
            //ImpRemesa.DefaultCellStyle.Format = "N";
            //ImpRemesa.DefaultCellStyle.NullValue = "0";
            //ImpRemesa.ReadOnly = true;
            //ImpRemesa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView_recibos.Columns.Add(ImpRemesa);
            //celdaImpRemesa = dataGridView_recibos.Columns["ImpRemesa"].Index;

            DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
            boton.HeaderText = "";
            boton.Name = "Pagar";
            boton.Width = 30;
            boton.DefaultCellStyle.NullValue = "P";
            dataGridView_recibos.Columns.Add(boton);
            celdaBoton = dataGridView_recibos.Columns["Pagar"].Index;

            for (int a = 0; a < dataGridView_recibos.Columns.Count-3; a++) {
                dataGridView_recibos.Columns[a].ReadOnly = true;
            }

            for (int a = 0; a < dataGridView_recibos.Rows.Count; a++) {
                dataGridView_recibos.Rows[a].Cells[celdaAsignado].Value = 0;
            }

            dataGridView_recibos.EditMode = DataGridViewEditMode.EditOnEnter;
            ajustarDatagrid();
            //existeEnRemesa();
        }
        private void existeEnRemesa() {
            for (int a = 0; a< dataGridView_recibos.Rows.Count; a++) {
                
                String sqlIf = (Persistencia.SentenciasSQL.select("SELECT IF (EXISTS(SELECT * FROM com_detremesa WHERE IdRecibo = " + dataGridView_recibos.Rows[a].Cells[1].Value.ToString() + " ),(SELECT SUM(Importe) FROM com_detremesa WHERE IdRecibo = " + dataGridView_recibos.Rows[a].Cells[1].Value.ToString() + "),0)")).Rows[0][0].ToString();
                
                if (sqlIf != "0") {
                    if (sqlIf == string.Format(dataGridView_recibos.Rows[a].Cells[11].Value.ToString(),"N2"))  {
                        this.dataGridView_recibos.CurrentCell = null;
                        this.dataGridView_recibos.Rows[a].Visible = false;
                    }
                    else  {
                        dataGridView_recibos.Rows[a].Cells[celdaImpRemesa].Value = sqlIf;
                        dataGridView_recibos.Rows[a].Cells[celdaImpRemesa].Style.BackColor = Color.Red;
                        dataGridView_recibos.Rows[a].Cells[celdaImpRemesa].Style.ForeColor = Color.White;
                    }
                }
            }
        }
        private void dataGridView_recibos_CellClick(object sender, DataGridViewCellEventArgs e)  {
            if (dataGridView_recibos.SelectedRows[0].Cells[11].Value == dataGridView_recibos.SelectedRows[0].Cells[celdaImpRemesa].Value){
                MessageBox.Show("Cuidado que ese pago ya existe en una remesa");
            }
            if (e.ColumnIndex == celdaBoton) {
                if (dataGridView_recibos.SelectedRows[0].Cells[celdaAsignado].Value.ToString() == "0") {
                    dataGridView_recibos.SelectedRows[0].Cells[celdaAsignado].Value = dataGridView_recibos.SelectedRows[0].Cells[11].Value;

                    ReciboRemesa nuevo = new ReciboRemesa(dataGridView_recibos.SelectedRows[0].Cells[1].Value.ToString(), dataGridView_recibos.SelectedRows[0].Cells[8].Value.ToString(), dataGridView_recibos.SelectedRows[0].Cells[9].Value.ToString(), dataGridView_recibos.SelectedRows[0].Cells[celdaAsignado].Value.ToString());
                    aRemesa.Add(nuevo);
                    totalRecibos = totalRecibos + Convert.ToDouble(nuevo.Importe);
                }
                else {
                    totalRecibos = totalRecibos - Convert.ToDouble(dataGridView_recibos.SelectedRows[0].Cells[celdaAsignado].Value);
                    dataGridView_recibos.SelectedRows[0].Cells[celdaAsignado].Value = 0;
                    aRemesa.RemoveAll((x => x.IdRecibo.Contains(dataGridView_recibos.SelectedRows[0].Cells[1].Value.ToString())));
                }
                textBox_total_recibos.Text = Math.Round(totalRecibos, 2).ToString();
            }
        }

        private void button_lanzar_Click(object sender, EventArgs e)
        {
            String sqlSelectTipo = "SELECT com_remesas.IdTipoRemesa FROM com_remesas WHERE(((com_remesas.IdRemesa) = " + id_remesa + "));";
            DataTable tipo = Persistencia.SentenciasSQL.select(sqlSelectTipo);

            if (tipo.Rows.Count > 0)
            {
                String idTipo = tipo.Rows[0][0].ToString();
                 if (idTipo == "1")
                {
                    foreach (ReciboRemesa var in aRemesa)
                    {
                        String sqlInsert = "INSERT INTO com_detremesa (IdRemesa, IdRecibo, IdCuenta, Cuenta, Importe) VALUES (" + id_remesa + "," + var.IdRecibo + "," + var.IdCuenta1 + ",'" + var.Cuenta1 + "'," + var.Importe.Replace(',', '.') + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                    }
                }
                else
                {
                    foreach (ReciboRemesa var in aRemesa)
                    {
                        String sqlInsert = "INSERT INTO com_detremesa (IdRemesa, IdRecibo, IdCuenta, Cuenta , Importe) VALUES (" + id_remesa + "," + var.IdRecibo + "," + var.IdCuenta1 + ",'" + var.Cuenta1 + "'," + var.Importe.Replace(',', '.') + ")";
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                    }
                }
            }
            form_anterior.WindowState = FormWindowState.Normal;
            form_anterior.cargarDatagrid();
            this.Close();
        }

        private void textBox_buscar_entidad_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void ajustarDatagrid() {
            dataGridView_recibos.Columns["IdComunidad"].Visible = false;
            dataGridView_recibos.Columns["IdEntidad"].Visible = false;
            dataGridView_recibos.Columns["IdCuota"].Visible = false;
            dataGridView_recibos.Columns["IdCC"].Visible = false;
            dataGridView_recibos.Columns["IdFormaPago"].Visible = false;

            dataGridView_recibos.Columns["RemesaPte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_recibos.Columns["RemesaPte"].DefaultCellStyle.Format = "c";

            dataGridView_recibos.Columns["ImpRbo"].DefaultCellStyle.Format = "c";
            dataGridView_recibos.Columns["ImpRbo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_recibos.Columns["Pte"].DefaultCellStyle.Format = "c";
            dataGridView_recibos.Columns["Pte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView_recibos.Columns["IdRecibo"].Width = 70 ;
            dataGridView_recibos.Columns["Fecha"].Width = 80 ;
            dataGridView_recibos.Columns["Referencia"].Width = 150;
            dataGridView_recibos.Columns["Entidad"].Width = 250 ;
            dataGridView_recibos.Columns["FormaPago"].Width = 80 ;
            dataGridView_recibos.Columns["CC"].Width = 173 ;
            dataGridView_recibos.Columns["ImpRbo"].Width = 90 ;
            dataGridView_recibos.Columns["ImpRbo"].Width = 90 ;
        }

        private void comboBox_formaPago_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (comboBox_formaPago.SelectedIndex == 0) {
            //    DataTable busqueda = recibos;
            //    busqueda.DefaultView.RowFilter = "IdFormaPago = 1";
            //    this.dataGridView_recibos.DataSource = busqueda;
            //}else if (comboBox_formaPago.SelectedIndex == 1) {
            //    DataTable busqueda = recibos;
            //    busqueda.DefaultView.RowFilter = "IdFormaPago = 2";
            //    this.dataGridView_recibos.DataSource = busqueda;
            //}

        }

        private void comboBox_cuota_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //DataTable busqueda = recibos;
            //busqueda.DefaultView.RowFilter = "IdCuota = " + comboBox_cuota.SelectedValue.ToString();
            //this.dataGridView_recibos.DataSource = busqueda;

            checkBox_cuenta.Checked = true;
        }
        private void AplicarFiltro() {
            DataTable busqueda = recibos;
            String filtro = "";

            if (comboBox_cuota.SelectedValue.ToString() != null)  {
                if (checkBox_cuenta.Checked)  {
                    filtro = filtro + "IdCuota = " + comboBox_cuota.SelectedValue.ToString();
                    if (comboBox_formaPago.SelectedIndex != 2)  {
                        if (comboBox_formaPago.SelectedIndex == 0)  {
                            filtro = filtro + " AND (Referencia like '%" + textBox_buscar_entidad.Text + "%' OR Entidad like '%" + textBox_buscar_entidad.Text + "%') AND IdFormaPago = 1";
                        }
                        else if (comboBox_formaPago.SelectedIndex == 1)  {
                            filtro = filtro + " AND (Referencia like '%" + textBox_buscar_entidad.Text + "%' OR Entidad like '%" + textBox_buscar_entidad.Text + "%') AND IdFormaPago = 2";
                        }
                    }
                    else  {
                        filtro = filtro + " AND (Referencia like '%" + textBox_buscar_entidad.Text + "%' OR Entidad like '%" + textBox_buscar_entidad.Text + "%')";
                    }
                }
                else if (!checkBox_cuenta.Checked) {
                    if (comboBox_formaPago.SelectedIndex != 2)  {
                        if (comboBox_formaPago.SelectedIndex == 0)  {
                            filtro = filtro + "(Referencia like '%" + textBox_buscar_entidad.Text + "%' OR Entidad like '%" + textBox_buscar_entidad.Text + "%') AND IdFormaPago = 1";
                        }
                        else if (comboBox_formaPago.SelectedIndex == 1)  {
                            filtro = filtro + "(Referencia like '%" + textBox_buscar_entidad.Text + "%' OR Entidad like '%" + textBox_buscar_entidad.Text + "%') AND IdFormaPago = 2";
                        }
                    }
                    else  {
                        filtro = filtro + "(Referencia like '%" + textBox_buscar_entidad.Text + "%' OR Entidad like '%" + textBox_buscar_entidad.Text + "%')";
                    }
                }
            }

            busqueda.DefaultView.RowFilter = filtro;
            this.dataGridView_recibos.DataSource = busqueda;

            for (int a = 0; a < dataGridView_recibos.Rows.Count; a++)
            {
                if (aRemesa.Count > 0)
                {
                    for (int b = 0; b < aRemesa.Count; b++)
                    {
                        if (dataGridView_recibos.Rows[a].Cells[1].Value.ToString() == aRemesa[b].IdRecibo)
                        {
                            dataGridView_recibos.Rows[a].Cells[celdaAsignado].Value = aRemesa[b].Importe;
                            break;
                        }
                        else
                            dataGridView_recibos.Rows[a].Cells["Cantidad"].Value = 0;
                    }
                }
                else
                {
                    dataGridView_recibos.Rows[a].Cells["Cantidad"].Value = 0;
                }
            }
        }

        private void button_filtro_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void dataGridView_recibos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == this.dataGridView_recibos.Columns["RemesaPte"].Index) && e.Value != null)
            {      
                DataGridViewCell cell = this.dataGridView_recibos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (!e.Value.Equals("0.00"))  {

                    String msg = "";
                    String sqlRmesas = "SELECT com_remesas.IdRemesa, com_remesas.Remesa FROM com_detremesa INNER JOIN com_remesas ON com_detremesa.IdRemesa = com_remesas.IdRemesa WHERE(((com_detremesa.IdRecibo) = " + this.dataGridView_recibos.Rows[e.RowIndex].Cells[1].Value.ToString() + ") AND((com_remesas.IdEstado) < 3));";

                    DataTable remesas = Persistencia.SentenciasSQL.select(sqlRmesas);

                    if (remesas.Rows.Count > 0) {
                        for (int a = 0; a < remesas.Rows.Count; a++) {
                            msg = msg + remesas.Rows[a][0].ToString() + " => " + remesas.Rows[a][1].ToString() + "\n";
                        }
                        cell.ToolTipText = msg;
                    }
                }
            }
        }

        private void dataGridView_recibos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (cargadoDatagrid)
            {
                if (dataGridView_recibos.SelectedRows[0].Cells[11].Value == dataGridView_recibos.SelectedRows[0].Cells[11].Value)
                    MessageBox.Show("Cuidado que ese pago ya existe en una remesa");

                if (dataGridView_recibos.Rows[e.RowIndex].Cells[celdaAsignado].Value == null)
                    dataGridView_recibos.Rows[e.RowIndex].Cells[celdaAsignado].Value = 0.00;

                if (e.ColumnIndex == celdaAsignado)
                {

                    if (dataGridView_recibos.Rows[e.RowIndex].Cells[celdaAsignado].Value != null && dataGridView_recibos.Rows[e.RowIndex].Cells[celdaAsignado].Value.ToString() != "0")
                    {
                        if (aRemesa.Exists((x => x.IdRecibo.Contains(dataGridView_recibos.Rows[e.RowIndex].Cells[1].Value.ToString())))) {
                            ReciboRemesa importe = aRemesa.Find((x => x.IdRecibo.Contains(dataGridView_recibos.Rows[e.RowIndex].Cells[1].Value.ToString())));
                            
                            totalRecibos = totalRecibos - Convert.ToDouble(importe.Importe);
                            aRemesa.RemoveAll((x => x.IdRecibo.Contains(dataGridView_recibos.Rows[e.RowIndex].Cells[1].Value.ToString())));
                        }

                        ReciboRemesa nuevo = new ReciboRemesa(dataGridView_recibos.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView_recibos.Rows[e.RowIndex].Cells[8].Value.ToString(), dataGridView_recibos.Rows[e.RowIndex].Cells[9].Value.ToString(), dataGridView_recibos.Rows[e.RowIndex].Cells[celdaAsignado].Value.ToString());

                        aRemesa.Add(nuevo);
                        totalRecibos = totalRecibos + Convert.ToDouble(nuevo.Importe.ToString().Replace('.', ','));
                    }
                    else
                    {
                        totalRecibos = totalRecibos - Convert.ToDouble(dataGridView_recibos.Rows[e.RowIndex].Cells[celdaAsignado].Value.ToString().Replace('.',','));
                        dataGridView_recibos.Rows[e.RowIndex].Cells[celdaAsignado].Value = 0;
                        aRemesa.RemoveAll((x => x.IdRecibo.Contains(dataGridView_recibos.Rows[e.RowIndex].Cells[1].Value.ToString())));
                    }
                    textBox_total_recibos.Text = Math.Round(totalRecibos, 2).ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!PantallaAsignado)
            {
                button3.Text = "Desasignar Pantalla";
                for (int a = 0; a < dataGridView_recibos.Rows.Count; a++)
                {
                    dataGridView_recibos.Rows[a].Cells[celdaAsignado].Value = dataGridView_recibos.Rows[a].Cells[11].Value;

                    ReciboRemesa nuevo = new ReciboRemesa(dataGridView_recibos.Rows[a].Cells[1].Value.ToString(), dataGridView_recibos.SelectedRows[0].Cells[8].Value.ToString(), dataGridView_recibos.Rows[a].Cells[9].Value.ToString(), dataGridView_recibos.Rows[a].Cells[celdaAsignado].Value.ToString());
                    aRemesa.Add(nuevo);
                    totalRecibos = totalRecibos + Convert.ToDouble(nuevo.Importe);
                    PantallaAsignado = true;
                }
            }
            else  {
                button3.Text = "Asignar Pantalla";
                for (int a = 0; a < dataGridView_recibos.Rows.Count; a++)   {
                    totalRecibos = totalRecibos - Convert.ToDouble(dataGridView_recibos.Rows[a].Cells[celdaAsignado].Value.ToString().Replace('.',','));
                    dataGridView_recibos.Rows[a].Cells[celdaAsignado].Value = 0;
                    aRemesa.RemoveAll((x => x.IdRecibo.Contains(dataGridView_recibos.Rows[a].Cells[1].Value.ToString())));
                    PantallaAsignado = false;
                }
            }
            textBox_total_recibos.Text = Math.Round(totalRecibos,2).ToString();
        }
    }
}