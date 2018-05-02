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
    public partial class FormCompensarAnticipos : Form
    {
        String id_operacion_pasado;
        String id_det_op;
        String entidad;
        String id_entidad;
        String descripcion_operacion;
        String id_subcuenta;
        String nombre_subcuenta;
        String importe;
        String importePte;
        String fecha;
        String id_comunidad;
        DataTable pagos;
        Operaciones_comuneros form_anterior;

        public FormCompensarAnticipos(Operaciones_comuneros form_anterior, String id_operacion_pasado, String id_det_op, String entidad, String descripcion_operacion, String id_subcuenta, String nombre_subcuenta, String importe, String importePte, String fecha, String id_comunidad, String id_entidad)
        {
            InitializeComponent();
            this.id_operacion_pasado = id_operacion_pasado;
            this.entidad = entidad;
            this.id_entidad = id_entidad;
            this.descripcion_operacion = descripcion_operacion;
            this.id_subcuenta = id_subcuenta;
            this.nombre_subcuenta = nombre_subcuenta;
            this.importe = importe;
            this.importePte = importePte;
            this.fecha = fecha;
            this.id_comunidad = id_comunidad;
            this.id_det_op = id_det_op;
            this.form_anterior = form_anterior;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (((id_subcuenta == "43801" && Convert.ToDouble(importe) < 0) || id_subcuenta == "43812" && Convert.ToDouble(importe) > 0) || ((id_subcuenta == "70000" || id_subcuenta == "70001") &&     Convert.ToDouble(importe) < 0) || ((Convert.ToInt32(id_subcuenta) >= 60000 || Convert.ToInt32(id_subcuenta) <= 69999 ) && Convert.ToDouble(importe) > 0) ) {
                String strDesc;
                String fechaCompesacion = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");

                if (id_subcuenta == "43801" || id_subcuenta == "43812")
                    strDesc = "Comp. Salida AC M" + (Persistencia.SentenciasSQL.select("SELECT IdMovCrea FROM com_operaciones WHERE IdOp = " + id_operacion_pasado)).Rows[0][0].ToString();
                else 
                    strDesc = "Comp. Vto. Entrada M" + (Persistencia.SentenciasSQL.select("SELECT IdMovCrea FROM com_operaciones WHERE IdOp = " + id_operacion_pasado)).Rows[0][0].ToString();

                String CuentaCompesacion = Logica.FuncionesTesoreria.CuentaCompesaciones(id_comunidad);
                if (CuentaCompesacion == "No") {
                    MessageBox.Show("Esa comunidad no tiene cuenta de compesaciones");
                    return;
                }
                        
                //CREO LA CABECERA MOVIMIENTO
                int varMovSal = Logica.FuncionesTesoreria.CreaMovimiento(Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad, fechaCompesacion), CuentaCompesacion, "15", id_entidad, fechaCompesacion, strDesc);

                ////CREO EL DETALLE DEL MOVIMIENTO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(varMovSal.ToString(), id_det_op, Logica.FuncionesGenerales.ArreglarImportes(textBox_asignado.Text));

                for (int a = 0; a < dataGridView_pagos.Rows.Count; a++)
                {
                    if (dataGridView_pagos.Rows[a].Cells[10].Value != null && Convert.ToDouble(dataGridView_pagos.Rows[a].Cells[10].Value) > 0)
                    {
                        //CREO LA CABECERA MOVIMIENTO
                        int varMovEnt = Logica.FuncionesTesoreria.CreaMovimientoCA(Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad, fechaCompesacion), CuentaCompesacion, "16", id_entidad, fechaCompesacion, strDesc, varMovSal.ToString());

                        //CREO EL DETALLE DEL MOVIMIENTO
                        Logica.FuncionesTesoreria.CreaDetalleMovimiento(varMovEnt.ToString(), dataGridView_pagos.Rows[a].Cells[1].Value.ToString(), Logica.FuncionesGenerales.ArreglarImportes(dataGridView_pagos.Rows[a].Cells[10].Value.ToString()));

                        //ACTUALIZO CA EN MOVSAL
                        Logica.FuncionesTesoreria.ActualizaMovCA(varMovEnt.ToString(), varMovSal.ToString());
                    }
                }

            }else if (id_subcuenta == "43801" || (id_subcuenta == "43812" && Convert.ToDouble(importe) < 0) || ((id_subcuenta == "70000" || id_subcuenta == "70001") && Convert.ToDouble(importe) > 0) || ((Convert.ToInt32(id_subcuenta) >= 60000 || Convert.ToInt32(id_subcuenta) <= 69999) && Convert.ToDouble(importe) < 0))  {

                String fechaCompesacion = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
                String strDescEnt = "Comp. Entrada AC M" + (Persistencia.SentenciasSQL.select("SELECT IdMovCrea FROM com_operaciones WHERE IdOp = " + id_operacion_pasado)).Rows[0][0].ToString();

                String CuentaCompesacion = Logica.FuncionesTesoreria.CuentaCompesaciones(id_comunidad);
                if (CuentaCompesacion == "No")
                {
                    MessageBox.Show("Esa comunidad no tiene cuenta de compesaciones");
                    return;
                }

                //CREO LA CABECERA MOVIMIENTO
                int varMovEnt = Logica.FuncionesTesoreria.CreaMovimiento(Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad, fechaCompesacion), CuentaCompesacion, "16", id_entidad, fechaCompesacion, strDescEnt);

                //CREO EL DETALLE DEL MOVIMIENTO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(varMovEnt.ToString(), id_det_op, Logica.FuncionesGenerales.ArreglarImportes(textBox_asignado.Text));

                    for (int a = 0; a < dataGridView_pagos.Rows.Count; a++)  {
                        if (dataGridView_pagos.Rows[a].Cells[10].Value != null && Convert.ToDouble(dataGridView_pagos.Rows[a].Cells[10].Value) > 0)
                        {
                            //CREO LA CABECERA MOVIMIENTO
                            int varMovSal = Logica.FuncionesTesoreria.CreaMovimientoCA(Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad, fechaCompesacion), CuentaCompesacion, "15", id_entidad, fechaCompesacion, strDescEnt, varMovEnt.ToString());
                            //CREO EL DETALLE DEL MOVIMIENTO
                            Logica.FuncionesTesoreria.CreaDetalleMovimiento(varMovSal.ToString(), dataGridView_pagos.Rows[a].Cells[1].Value.ToString(), Logica.FuncionesGenerales.ArreglarImportes(dataGridView_pagos.Rows[a].Cells[10].Value.ToString()));
                            //ACTUALIZO CA EN MOVSAL
                            Logica.FuncionesTesoreria.ActualizaMovCA(varMovEnt.ToString(), varMovSal.ToString());
                        }
                    }
            }
            //form_anterior.cargardatagrid();
            form_anterior.aplicarFiltro();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCompensarAnticipos_Load(object sender, EventArgs e)
        {
            cargarCabecera();
            cargarDatagrid(id_entidad);
            label10.Text = "Vencimientos Compensables : " + entidad;
        }
        private void cargarCabecera() {

            textBox_entidad.Text = entidad;
            textBox_num_op.Text = id_operacion_pasado;
            textBox_descrip_op.Text = descripcion_operacion;
            textBox_num_subcuenta.Text = id_subcuenta;
            textBox_subcuenta.Text = nombre_subcuenta;

            if (Convert.ToDouble(importePte) < 0) {
                textBox_pendiente.Text = (Convert.ToDouble(importePte) * -1).ToString();
                textBox_importe.Text = (Convert.ToDouble(importe) * -1).ToString();
                textBox_disponible.Text = (Convert.ToDouble(importePte) * -1).ToString();
            }else {
                textBox_pendiente.Text = Convert.ToDouble(importePte).ToString();
                textBox_importe.Text = Convert.ToDouble(importe).ToString();
                textBox_disponible.Text = Convert.ToDouble(importePte).ToString();
            }
            
            textBox_asignado.Text = "0.00";
            textBox_movimiento.Text = (Persistencia.SentenciasSQL.select("SELECT IdMovCrea FROM com_operaciones WHERE IdOp = " + id_operacion_pasado)).Rows[0][0].ToString();
            textBox_fecha_mov.Text = fecha;
        }
        private void cargarDatagrid(String idEntidad) {
            
            String sqlSelectPagos = "SELECT com_opdetalles.IdOp, com_opdetalles.IdOpDet, ctos_entidades.Entidad, com_opdetalles.IdRecibo, com_operaciones.Descripcion, com_opdetalles.Fecha, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte, com_operaciones.IdSubCuenta FROM(com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_operaciones.IdComunidad) = " + id_comunidad + ") AND((com_opdetalles.IdEntidad) = " + idEntidad + ") AND((com_opdetalles.IdEstado) <> 3));";
            pagos = Persistencia.SentenciasSQL.select(sqlSelectPagos);

            if (((id_subcuenta == "43801" && Convert.ToDouble(importe) < 0) || id_subcuenta == "43812" && Convert.ToDouble(importe) > 0) || ((id_subcuenta == "70000" || id_subcuenta == "70001") && Convert.ToDouble(importe) < 0) || ((Convert.ToInt32(id_subcuenta) >= 60000 || Convert.ToInt32(id_subcuenta) <= 69999) && Convert.ToDouble(importe) > 0))
            {

                DataTable busqueda = pagos;
                busqueda.DefaultView.RowFilter = "(IdSubCuenta = 43801 AND ImpOpDetPte > 0) OR (IdSubCuenta = 43812 AND ImpOpDetPte < 0) OR (IdSubCuenta > 59999 AND IdSubCuenta < 70000 AND ImpOpDetPte < 0) OR (IdSubCuenta = 70000 AND ImpOpDetPte > 0) OR (IdSubCuenta = 70001 AND ImpOpDetPte > 0) OR (IdSubCuenta >= 70001 AND IdSubCuenta < 72000 AND ImpOpDetPte > 0)";
                this.dataGridView_pagos.DataSource = busqueda;
            }
            else if (id_subcuenta == "43801" || (id_subcuenta == "43812" && Convert.ToDouble(importe) < 0) || ((id_subcuenta == "70000" || id_subcuenta == "70001") && Convert.ToDouble(importe) > 0) || ((Convert.ToInt32(id_subcuenta) >= 60000 || Convert.ToInt32(id_subcuenta) <= 69999) && Convert.ToDouble(importe) < 0))
            {
                DataTable busqueda = pagos;
                busqueda.DefaultView.RowFilter = "(IdSubCuenta = 43801 AND ImpOpDetPte < 0) OR (IdSubCuenta = 43812 AND ImpOpDetPte > 0) OR (IdSubCuenta > 59999 AND IdSubCuenta < 70000 AND ImpOpDetPte > 0) OR (IdSubCuenta = 70000 AND ImpOpDetPte < 0) OR (IdSubCuenta = 70001 AND ImpOpDetPte < 0)";
                this.dataGridView_pagos.DataSource = busqueda;
            }

            dataGridView_pagos.Columns["IdRecibo"].Visible = false;
            dataGridView_pagos.Columns["Importe"].Visible = false;
            dataGridView_pagos.Columns["Entidad"].Visible = false;
            dataGridView_pagos.Columns["IdSubCuenta"].Visible = false;

            dataGridView_pagos.Columns["IdOp"].Width = 60;
            dataGridView_pagos.Columns["IdOpDet"].Width = 60;
            dataGridView_pagos.Columns["Descripcion"].Width = 260;


            dataGridView_pagos.Columns["ImpOpDetPte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_pagos.Columns["ImpOpDetPte"].DefaultCellStyle.Format = "c";

            DataGridViewTextBoxColumn espacio = new DataGridViewTextBoxColumn();
            espacio.HeaderText = "";
            espacio.Name = "Vacio";
            espacio.Width = 10;
            espacio.DefaultCellStyle.BackColor = Color.Gray;
            dataGridView_pagos.Columns.Add(espacio);
            //9

            DataGridViewTextBoxColumn cuanto = new DataGridViewTextBoxColumn();
            cuanto.HeaderText = "Cantidad";
            cuanto.Name = "Cantidad";
            cuanto.Width = 80;
            cuanto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_pagos.Columns.Add(cuanto);
            //10

            DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
            boton.HeaderText = "";
            boton.Name = "Pagar";
            boton.Width = 30;
            dataGridView_pagos.Columns.Add(boton);
            //11

        }

        private void dataGridView_pagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = this.dataGridView_pagos.CurrentCell.ColumnIndex;
            int row = this.dataGridView_pagos.CurrentCell.RowIndex;

            if (e.ColumnIndex == 11)
            {
                if (dataGridView_pagos.Rows[row].Cells[10].Value == null)
                {
                    if (Convert.ToDouble(textBox_disponible.Text) < Convert.ToDouble(dataGridView_pagos.Rows[row].Cells[7].Value))
                    {
                        if (Convert.ToDouble(textBox_disponible.Text) > 0)
                            dataGridView_pagos.Rows[row].Cells[10].Value = Convert.ToDouble(textBox_disponible.Text);
                        else
                            MessageBox.Show("No hay mas disponible");
                    }
                    else
                    {
                        if (Convert.ToDouble(textBox_disponible.Text) > 0)
                            dataGridView_pagos.Rows[row].Cells[10].Value = dataGridView_pagos.Rows[row].Cells[7].Value;
                        else
                            MessageBox.Show("No hay mas disponible");
                    }
                    textBox_disponible.Text = (Convert.ToDouble(textBox_disponible.Text) - Convert.ToDouble(dataGridView_pagos.Rows[row].Cells[10].Value)).ToString();
                }
                else {
                    textBox_disponible.Text = (Convert.ToDouble(textBox_disponible.Text) + Convert.ToDouble(dataGridView_pagos.Rows[row].Cells[10].Value)).ToString();
                    dataGridView_pagos.Rows[row].Cells[10].Value = null;
                }
            }
        }

        private void dataGridView_pagos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            double valor_acumulado = 0.00;

            for (int a = 0; a < dataGridView_pagos.Rows.Count; a++) {
                if (Convert.ToDouble(dataGridView_pagos.Rows[a].Cells[10].Value) > 0 && dataGridView_pagos.Rows[a].Cells[10].Value != null )
                        valor_acumulado = valor_acumulado + Convert.ToDouble(dataGridView_pagos.Rows[a].Cells[10].Value);
            }
            textBox_asignado.Text = valor_acumulado.ToString();
        }

        private void button_abrir_comuneros_Click(object sender, EventArgs e)
        {
            Comuneros nueva = new Comuneros(this, this.Name, id_comunidad);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void recibirEntidad(String id_entidad,String nombre_entidad)
        {
            label10.Text = "Vencimientos Compensables : " + nombre_entidad;
            dataGridView_pagos.Columns.Remove(dataGridView_pagos.Columns["Vacio"]);
            dataGridView_pagos.Columns.Remove(dataGridView_pagos.Columns["Cantidad"]);
            dataGridView_pagos.Columns.Remove(dataGridView_pagos.Columns["Pagar"]);
            cargarDatagrid(id_entidad);
            
        }
    }
}
