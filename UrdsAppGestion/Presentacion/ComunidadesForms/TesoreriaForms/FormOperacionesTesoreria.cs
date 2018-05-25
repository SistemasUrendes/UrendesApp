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
    public partial class FormOperacionesTesoreria : Form
    {
        String id_comunidad_cargado;
        String id_cuenta_cargado;
        String tipoOperacion;
        Double total_acumulado = 0.00;
        String fecha_arrastrar = null;
        DataTable datos_datagrid;
        String id_entidad_pasado = "0";
        String importe_operacion_pasado;
        String fecha_operacion_pasado;
        Tesoreria form_anterior;
        Boolean acabadoDeCargar = false;
        int numColumnaBoton;
        int celdaAsignado;
        int fechaasignacion;
        int importeOp;
        int fechaOp;

        public FormOperacionesTesoreria(String id_comunidad_cargado, String id_cuenta_cargado, String tipoOperacion, String id_entidad_pasado, String fecha_operacion_pasado, String importe_operacion_pasado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_cuenta_cargado = id_cuenta_cargado;
            this.tipoOperacion = tipoOperacion;
            this.id_entidad_pasado = id_entidad_pasado;
            this.fecha_operacion_pasado = fecha_operacion_pasado;
            this.importe_operacion_pasado = importe_operacion_pasado;
        }
        public FormOperacionesTesoreria(Tesoreria form_anterior, String id_comunidad_cargado, String id_cuenta_cargado, String tipoOperacion)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_cuenta_cargado = id_cuenta_cargado;
            this.tipoOperacion = tipoOperacion;
            this.form_anterior = form_anterior;
        }

        private void FormOperacionesTesoreria_Load(object sender, EventArgs e)
        {
            this.Text = tipoOperacion + " - " + (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.NombreCorto FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_cargado + "));")).Rows[0][0].ToString();

            label_cuenta.Text = (Persistencia.SentenciasSQL.select("SELECT com_cuentas.Descripcion FROM com_cuentas WHERE IdCuenta = " + id_cuenta_cargado)).Rows[0][0].ToString().ToUpper();

            label_fcierre.Text = (Persistencia.SentenciasSQL.select("SELECT com_cuentas.FCierre FROM com_cuentas WHERE IdCuenta = " + id_cuenta_cargado)).Rows[0][0].ToString();
            textBox_total_acumulado.Text = string.Format("{0:0.00}", 0.00);
            cargarDatagrid();

            if (id_entidad_pasado != "0")
            {
                label7.Visible = true;
                textBox_importe_operacion.Visible = true;
                textBox_importe_operacion.Text = string.Format("{0:0.00}", importe_operacion_pasado);
                label6.Visible = true;
                textBox_operacion_disponible.Text = string.Format("{0:0.00}", importe_operacion_pasado);
                textBox_operacion_disponible.Visible = true;
                label1.Visible = true;
                textBox_FECHA.Text = fecha_operacion_pasado;
                textBox_FECHA.Visible = true;

                label8.Visible = true;
                label9.Visible = true;
                label9.Text = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IDEntidad = " + id_entidad_pasado)).Rows[0][0].ToString();
            }
            acabadoDeCargar = true;
            dataGridView_general.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        public void cargarDatagrid() {
            String sqlSelect = "";
            if (id_entidad_pasado != "0" && tipoOperacion == "Salida a Comuneros" )
            {
                sqlSelect = "SELECT com_opdetalles.IdOpDet, com_operaciones.IdOp, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_operaciones.Documento, com_operaciones.Descripcion,com_opdetalles.Fecha, -1 * com_opdetalles.ImpOpDetPte AS ImpOpDetPte ,  -1 * com_opdetalles.Importe AS Importe FROM(com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad WHERE ((Not (com_opdetalles.IdRecibo) Is Null) AND ((com_opdetalles.IdEntidad)=" + id_entidad_pasado + ") AND ((com_opdetalles.ImpOpDetPte)<0) AND ((com_operaciones.IdComunidad)=" + id_comunidad_cargado + ") AND ((com_opdetalles.IdEstado)<3) AND ((com_operaciones.IdSubCuenta) Between 70000 And 700001)) OR (((com_opdetalles.IdEntidad)=" + id_entidad_pasado + ") AND ((com_opdetalles.ImpOpDetPte)<0) AND ((com_operaciones.IdComunidad)=" + id_comunidad_cargado + ") AND ((com_operaciones.IdSubCuenta)=43801)) ORDER BY com_operaciones.Fecha;";

                datos_datagrid = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_general.DataSource = datos_datagrid;

                dataGridView_general.Columns["Entidad"].Width = 250;
                dataGridView_general.Columns["Entidad"].ReadOnly = true;
                dataGridView_general.Columns["Documento"].Width = 90;
                dataGridView_general.Columns["Documento"].ReadOnly = true;
                dataGridView_general.Columns["IdOpDet"].Visible = false;
                dataGridView_general.Columns["IdOp"].Visible = false;
                dataGridView_general.Columns["IdEntidad"].Visible = false;
                dataGridView_general.Columns["Importe"].Visible = false;

                dataGridView_general.Columns["Descripcion"].Width = 300;
                dataGridView_general.Columns["Descripcion"].ReadOnly = true;
                dataGridView_general.Columns["Fecha"].Width = 70;
                dataGridView_general.Columns["Fecha"].ReadOnly = true;
                dataGridView_general.Columns["ImpOpDetPte"].Width = 80;
                dataGridView_general.Columns["ImpOpDetPte"].ReadOnly = true;
                dataGridView_general.Columns["ImpOpDetPte"].DefaultCellStyle.Format = "c";
                dataGridView_general.Columns["ImpOpDetPte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            else if (id_entidad_pasado != "0" && tipoOperacion == "Ingreso a Comuneros") {
                sqlSelect = "SELECT com_opdetalles.IdOpDet,com_opdetalles.IdEntidad, com_opdetalles.IdOp, com_opdetalles.Fecha, com_operaciones.Descripcion, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte,com_opdetalles.IdRecibo FROM com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE(((com_opdetalles.IdEntidad) = " + id_entidad_pasado + ") AND((com_opdetalles.ImpOpDetPte) > 0) AND((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ") AND((com_operaciones.IdSubCuenta) >= 70000 AND ((com_operaciones.IdSubCuenta) <= 79999) Or(com_operaciones.IdSubCuenta) = 43801) AND((com_opdetalles.IdEstado) <> 3)) OR(((com_opdetalles.IdEntidad) = " + id_entidad_pasado + ") AND((com_opdetalles.ImpOpDetPte) > 0) AND((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ") AND((com_operaciones.IdSubCuenta) = 43801) AND((com_opdetalles.IdEstado) <> 3));";
                datos_datagrid = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_general.DataSource = datos_datagrid;

                dataGridView_general.Columns["IdEntidad"].Visible = false;
                dataGridView_general.Columns["IdRecibo"].Visible = false;
                dataGridView_general.Columns["IdOpDet"].ReadOnly = true;
                dataGridView_general.Columns["IdOp"].ReadOnly = true;
                dataGridView_general.Columns["Descripcion"].ReadOnly = true;
                dataGridView_general.Columns["Importe"].ReadOnly = true;
                dataGridView_general.Columns["Fecha"].ReadOnly = true;
                dataGridView_general.Columns["IdEntidad"].ReadOnly = true;
                dataGridView_general.Columns["IdRecibo"].ReadOnly = true;
                dataGridView_general.Columns["ImpOpDetPte"].ReadOnly = true;

            }
            else if (id_entidad_pasado != "0" && tipoOperacion == "Entrada a Proveedor") {

                sqlSelect = "SELECT com_opdetalles.IdOpDet, com_opdetalles.IdOp, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_operaciones.Documento, com_operaciones.Descripcion, -`com_opdetalles`.`Importe` AS Importe, com_opdetalles.Fecha, -`com_opdetalles`.`impopdetpte` AS ImpOpDetPte FROM (com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad WHERE (((com_operaciones.IdComunidad)= " + id_comunidad_cargado + ") AND ((com_opdetalles.Importe)<0) AND ((com_opdetalles.ImpOpDetPte)<0) AND ((com_operaciones.IdSubCuenta) Between 60000 And 69999) AND ((com_opdetalles.IdEstado)<>3)) OR (((com_operaciones.IdComunidad)=" + id_comunidad_cargado + ") AND ((com_opdetalles.Importe)<0) AND ((com_opdetalles.ImpOpDetPte)<0) AND ((com_operaciones.IdSubCuenta)=43812));";

                datos_datagrid = Persistencia.SentenciasSQL.select(sqlSelect);
                datos_datagrid.DefaultView.RowFilter = "IdEntidad = " + id_entidad_pasado;
                dataGridView_general.DataSource = datos_datagrid;
                dataGridView_general.Columns["IdEntidad"].Visible = false;
                dataGridView_general.Columns["Entidad"].Visible = false;
                dataGridView_general.Columns["Importe"].Visible = false;
                dataGridView_general.Columns["IdEntidad"].ReadOnly = true;

            }else if (tipoOperacion == "Otras Salidas") {
                sqlSelect = "SELECT com_operaciones.IdComunidad, com_opdetalles.IdOpDet, com_opdetalles.IdOp, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_operaciones.Documento, com_operaciones.Descripcion, com_opdetalles.Fecha, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte FROM((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ") AND((com_opdetalles.ImpOpDetPte) > 0) AND((com_operaciones.IdSubCuenta)Between 10000 And 43799) AND((com_subcuentas.ES) = 2)) OR(((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ") AND((com_opdetalles.ImpOpDetPte) > 0) AND((com_operaciones.IdSubCuenta)Between 43813 And 59999) AND((com_subcuentas.ES) = 2)) OR(((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ") AND((com_opdetalles.ImpOpDetPte) > 0) AND((com_operaciones.IdSubCuenta)Between 70002 And 79999) AND((com_subcuentas.ES) = 2)) OR(((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ") AND((com_opdetalles.ImpOpDetPte) > 0) AND((com_operaciones.IdSubCuenta)Between 80000 And 99999) AND((com_subcuentas.ES) = 2));";

                datos_datagrid = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_general.DataSource = datos_datagrid;
                dataGridView_general.Columns["Entidad"].Width = 250;
                dataGridView_general.Columns["Entidad"].ReadOnly = true;
                dataGridView_general.Columns["Documento"].Width = 90;
                dataGridView_general.Columns["Documento"].ReadOnly = true;
                dataGridView_general.Columns["IdOpDet"].Visible = false;
                dataGridView_general.Columns["IdOp"].Visible = false;
                dataGridView_general.Columns["IdEntidad"].Visible = false;
                dataGridView_general.Columns["Importe"].Visible = false;
                dataGridView_general.Columns["IdComunidad"].Visible = false;

                dataGridView_general.Columns["Descripcion"].Width = 300;
                dataGridView_general.Columns["Descripcion"].ReadOnly = true;
                dataGridView_general.Columns["Fecha"].Width = 70;
                dataGridView_general.Columns["Fecha"].ReadOnly = true;
                dataGridView_general.Columns["ImpOpDetPte"].Width = 80;
                dataGridView_general.Columns["ImpOpDetPte"].ReadOnly = true;
                dataGridView_general.Columns["ImpOpDetPte"].DefaultCellStyle.Format = "c";
                dataGridView_general.Columns["ImpOpDetPte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }else if (tipoOperacion == "Otras Entradas")
            {
                sqlSelect = "SELECT com_operaciones.IdComunidad, com_opdetalles.IdOpDet, com_opdetalles.IdOp, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_operaciones.Documento, com_operaciones.Descripcion, com_opdetalles.Fecha, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte FROM ((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad WHERE (((com_operaciones.IdComunidad)=" + id_comunidad_cargado + ") AND ((com_opdetalles.ImpOpDetPte)>0) AND ((com_operaciones.IdSubCuenta) Between 10000 And 43799) AND ((com_subcuentas.`ES`)=1)) OR (((com_operaciones.IdComunidad)=" + id_comunidad_cargado + ") AND ((com_opdetalles.ImpOpDetPte)>0) AND ((com_operaciones.IdSubCuenta) Between 43813 And 59999) AND ((com_subcuentas.`ES`)=1)) OR (((com_operaciones.IdComunidad)=" + id_comunidad_cargado + ") AND ((com_opdetalles.ImpOpDetPte)>0) AND ((com_operaciones.IdSubCuenta) Between 70002 And 79999) AND ((com_subcuentas.`ES`)=1)) OR (((com_operaciones.IdComunidad)=" + id_comunidad_cargado + ") AND ((com_opdetalles.ImpOpDetPte)>0) AND ((com_operaciones.IdSubCuenta) Between 80000 And 99999) AND ((com_subcuentas.`ES`)=1));";


                datos_datagrid = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_general.DataSource = datos_datagrid;
                dataGridView_general.Columns["Entidad"].Width = 250;
                dataGridView_general.Columns["Entidad"].ReadOnly = true;
                dataGridView_general.Columns["Documento"].Width = 90;
                dataGridView_general.Columns["Documento"].ReadOnly = true;
                dataGridView_general.Columns["IdOpDet"].Visible = false;
                dataGridView_general.Columns["IdOp"].Visible = false;
                dataGridView_general.Columns["IdEntidad"].Visible = false;
                dataGridView_general.Columns["Importe"].Visible = false;
                dataGridView_general.Columns["IdComunidad"].Visible = false;

                dataGridView_general.Columns["Descripcion"].Width = 300;
                dataGridView_general.Columns["Descripcion"].ReadOnly = true;
                dataGridView_general.Columns["Fecha"].Width = 70;
                dataGridView_general.Columns["Fecha"].ReadOnly = true;
                dataGridView_general.Columns["ImpOpDetPte"].Width = 80;
                dataGridView_general.Columns["ImpOpDetPte"].ReadOnly = true;
                dataGridView_general.Columns["ImpOpDetPte"].DefaultCellStyle.Format = "c";
                dataGridView_general.Columns["ImpOpDetPte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            else {
                sqlSelect = "SELECT com_opdetalles.IdOpDet, com_operaciones.IdOp, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_operaciones.Documento, com_operaciones.Descripcion,com_opdetalles.Fecha, com_opdetalles.ImpOpDetPte, com_opdetalles.Importe FROM(com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_opdetalles.ImpOpDetPte) > 0) AND((com_operaciones.IdSubCuenta)Between 60000 And 69999) AND((com_opdetalles.IdEstado) <> 3) AND ((com_operaciones.IdComunidad)=" + id_comunidad_cargado + ")) OR (((com_opdetalles.ImpOpDetPte)>0) AND ((com_operaciones.IdComunidad)=" + id_comunidad_cargado + ") AND ((com_operaciones.IdSubCuenta)=43801)) ORDER BY ctos_entidades.Entidad;";

                datos_datagrid = Persistencia.SentenciasSQL.select(sqlSelect);

                if (tipoOperacion == "Pago a Proveedor")
                    datos_datagrid.DefaultView.RowFilter = "IdEntidad = " + id_entidad_pasado;

                dataGridView_general.DataSource = datos_datagrid;
                dataGridView_general.Columns["Entidad"].Width = 250;
                dataGridView_general.Columns["Entidad"].ReadOnly = true;
                dataGridView_general.Columns["Documento"].Width = 90;
                dataGridView_general.Columns["Documento"].ReadOnly = true;
                dataGridView_general.Columns["IdOpDet"].Visible = false;
                dataGridView_general.Columns["IdOp"].Visible = false;
                dataGridView_general.Columns["IdEntidad"].Visible = false;
                dataGridView_general.Columns["Importe"].Visible = false;

                dataGridView_general.Columns["Descripcion"].Width = 300;
                dataGridView_general.Columns["Descripcion"].ReadOnly = true;
                dataGridView_general.Columns["Fecha"].Width = 70;
                dataGridView_general.Columns["Fecha"].ReadOnly = true;
                dataGridView_general.Columns["ImpOpDetPte"].Width = 80;
                dataGridView_general.Columns["ImpOpDetPte"].ReadOnly = true;
                dataGridView_general.Columns["ImpOpDetPte"].DefaultCellStyle.Format = "c";
                dataGridView_general.Columns["ImpOpDetPte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            }
            dataGridView_general.Columns["Descripcion"].Width = 300;
            importeOp = dataGridView_general.Columns["ImpOpDetPte"].Index;
            fechaOp = dataGridView_general.Columns["Fecha"].Index;
            ////dataGridView_general.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            ////dataGridView_general.Columns["Importe"].DefaultCellStyle.Format = "c";


            DataGridViewTextBoxColumn espacio = new DataGridViewTextBoxColumn();
            espacio.HeaderText = "";
            espacio.Name = "Vacio";
            espacio.Width = 10;
            espacio.DefaultCellStyle.BackColor = Color.Gray;
            dataGridView_general.Columns.Add(espacio);

            DataGridViewTextBoxColumn cuanto = new DataGridViewTextBoxColumn();
            cuanto.HeaderText = "Cantidad";
            cuanto.Name = "Cantidad";
            cuanto.Width = 80;
            //cuanto.DefaultCellStyle.Format = "c";
            cuanto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_general.Columns.Add(cuanto);
            celdaAsignado = dataGridView_general.Columns["Cantidad"].Index;

            DataGridViewTextBoxColumn fecha = new DataGridViewTextBoxColumn();
            fecha.HeaderText = "Fecha";
            fecha.Name = "FechaAsig";
            fecha.Width = 70;
            fecha.DefaultCellStyle.Format = "dd/MM/yyyy";
            fecha.ReadOnly = false;
            dataGridView_general.Columns.Add(fecha);
            fechaasignacion = dataGridView_general.Columns["FechaAsig"].Index;

            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.HeaderText = "A";
            check.Width = 30;
            check.Name = "Unir";
            dataGridView_general.Columns.Add(check);

            DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
            boton.HeaderText = "";
            boton.Name = "Pagar";
            boton.Width = 30;
            dataGridView_general.Columns.Add(boton);
            numColumnaBoton = dataGridView_general.Columns["Pagar"].Index;


            for (int a = 0; a < dataGridView_general.Rows.Count; a++)
            {
                dataGridView_general.Rows[a].Cells["Pagar"].Value = "P";
                dataGridView_general.Rows[a].Cells["Cantidad"].Value = 0.00;
            }
        }

        private void dataGridView_general_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = this.dataGridView_general.CurrentCell.ColumnIndex;
            int row = this.dataGridView_general.CurrentCell.RowIndex;

            if (e.ColumnIndex == numColumnaBoton)
            {

                if (Convert.ToDouble(dataGridView_general.Rows[row].Cells[celdaAsignado].Value.ToString()) == 0.00 )
                {
                    //COLOCO LA FECHA EN LA CASILLA
                        if (fecha_arrastrar == null)
                        {
                            if (id_entidad_pasado != "0")
                                dataGridView_general.Rows[row].Cells[fechaasignacion].Value = fecha_operacion_pasado;
                            else
                                dataGridView_general.Rows[row].Cells[fechaasignacion].Value = dataGridView_general.Rows[row].Cells[fechaOp].Value;
                        }
                        else
                        {
                            dataGridView_general.Rows[row].Cells[fechaasignacion].Value = fecha_arrastrar;
                        }
                    //PONGO EL IMPORTE
                    if (id_entidad_pasado != "0") {

                        if (Convert.ToDouble(textBox_operacion_disponible.Text.ToString().Replace('.',',')) > Convert.ToDouble(dataGridView_general.Rows[row].Cells[importeOp].Value))
                            dataGridView_general.Rows[row].Cells[celdaAsignado].Value = dataGridView_general.Rows[row].Cells[importeOp].Value.ToString().Replace(',','.');
                        else if (Convert.ToDouble(textBox_operacion_disponible.Text) == 0) {
                            MessageBox.Show("No hay mas saldo que asignar");
                            dataGridView_general.Rows[row].Cells[fechaasignacion].Value = null;
                        }
                        else
                            dataGridView_general.Rows[row].Cells[celdaAsignado].Value = Convert.ToDouble(textBox_operacion_disponible.Text.ToString().Replace('.',','));
                    }else
                        dataGridView_general.Rows[row].Cells[celdaAsignado].Value = dataGridView_general.Rows[row].Cells[importeOp].Value;


                    if (id_entidad_pasado != "0")
                    {
                        //MessageBox.Show((Convert.ToDouble(textBox_operacion_disponible.Text.Replace('.',',')) - Convert.ToDouble(dataGridView_general.Rows[row].Cells[celdaAsignado].Value)).ToString());

                        //textBox_operacion_disponible.Text = (Convert.ToDouble(textBox_operacion_disponible.Text.Replace('.', ',')) - Convert.ToDouble(dataGridView_general.Rows[row].Cells[celdaAsignado].Value)).ToString();
                    }
                }
                else {
                    if (id_entidad_pasado != "0")
                        textBox_operacion_disponible.Text = string.Format("{0:0.00}", (Convert.ToDouble(textBox_operacion_disponible.Text) + (Convert.ToDouble(dataGridView_general.Rows[row].Cells[celdaAsignado].Value))));

                    dataGridView_general.Rows[row].Cells[celdaAsignado].Value = 0.00;
                    dataGridView_general.Rows[row].Cells[fechaasignacion].Value = null;
                }
                
            }
            if (e.ColumnIndex == fechaasignacion)
            {
                if (dataGridView_general.Rows[row].Cells[fechaasignacion].Value != null && dataGridView_general.Rows[row].Cells[fechaasignacion].Value.ToString() != "")
                {
                    fecha_arrastrar = dataGridView_general.Rows[row].Cells[fechaasignacion].Value.ToString();
                }
            }
        }

        private void dataGridView_general_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            total_acumulado = 0;
            if (e.ColumnIndex == celdaAsignado)
            {
                for (int a = 0; a < dataGridView_general.Rows.Count; a++)
                {
                    if (Convert.ToDouble(Logica.FuncionesGenerales.ArreglarImportes(dataGridView_general.Rows[a].Cells[celdaAsignado].Value.ToString())) != 0)
                    {
                        total_acumulado = total_acumulado + Convert.ToDouble(dataGridView_general.Rows[a].Cells[celdaAsignado].Value.ToString());
                        //MessageBox.Show(Convert.ToDouble(dataGridView_general.Rows[a].Cells[celdaAsignado].Value.ToString().Replace('.', ',')).ToString());
                    }
                }
            }

            int row = this.dataGridView_general.CurrentCell.RowIndex;

            if (e.ColumnIndex == fechaasignacion && acabadoDeCargar)
            {
                if (dataGridView_general.Rows[row].Cells[fechaasignacion].Value != null && dataGridView_general.Rows[row].Cells[fechaasignacion].Value.ToString() != "" && id_entidad_pasado == "0")
                {
                    fecha_arrastrar = dataGridView_general.Rows[row].Cells[fechaasignacion].Value.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_buscar.TextLength < 2)
            {
                DataTable busqueda = datos_datagrid;
                busqueda.DefaultView.RowFilter = "Entidad like '%%'";
                this.dataGridView_general.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = datos_datagrid;
                busqueda.DefaultView.RowFilter = "Entidad like '%" + textBox_buscar.Text + "%' OR Descripcion like '%" + textBox_buscar.Text + "%'";
                this.dataGridView_general.DataSource = busqueda;
            }

            for (int a = 0; a < dataGridView_general.Rows.Count; a++)
            {
                dataGridView_general.Rows[a].Cells["Pagar"].Value = "P";
                dataGridView_general.Rows[a].Cells["Cantidad"].Value = 0.00;
            }
        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {
            String fechaMov = "";
            int numMov = 0;
            Boolean crearAnticipo = false;
            if (tipoOperacion == "Ingreso a Comuneros" || tipoOperacion == "Entrada a Proveedor" || tipoOperacion == "Pago a Proveedor" || tipoOperacion == "Salida a Comuneros") {
                //PREGUNTO SI EL USUARIO QUIERE CREAR UN ANTICIPO ANTES DE HACER NADA
                if (Convert.ToDouble(textBox_operacion_disponible.Text) > 0) {
                    try { fechaMov = (Convert.ToDateTime(fecha_operacion_pasado)).ToString("yyyy-MM-dd"); }
                    catch { MessageBox.Show("Introduce una fecha valida en un pago"); return; }

                    DialogResult resultado_message;
                    resultado_message = MessageBox.Show("Hay más saldo disponible (" + textBox_operacion_disponible.Text + "€) ¿Deseas crear un Anticipo ?", "Crear Anticipo", MessageBoxButtons.OKCancel);
                    if (resultado_message == System.Windows.Forms.DialogResult.OK) {
                        crearAnticipo = true;
                    } else {
                        crearAnticipo = false;
                        return;
                    }
                }
            }

            if (tipoOperacion == "Ingreso a Comuneros")
            {
                //COJO LA FECHA
                try { fechaMov = (Convert.ToDateTime(fecha_operacion_pasado)).ToString("yyyy-MM-dd"); }
                catch { MessageBox.Show("Introduce una fecha valida en un pago"); return; }

                //BUSCO EL EJERCICIO ACTIVO
                String idEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaMov);

                //CREO CABECERA DEL MOVIMIENTO
                numMov = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, id_cuenta_cargado, "2", id_entidad_pasado, fechaMov, "Ingreso");

            }
            else if (tipoOperacion == "Salida a Comuneros") {
                //BUSCO EL EJERCICIO ACTIVO
                String idEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaMov);

                //CREO CABECERA DEL MOVIMIENTO
                numMov = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, id_cuenta_cargado, "11", id_entidad_pasado, fechaMov, "Salida a Comunero");
            }
            else if (tipoOperacion == "Entrada a Proveedor")
            {
                //COJO LA FECHA
                try { fechaMov = (Convert.ToDateTime(fecha_operacion_pasado)).ToString("yyyy-MM-dd"); }
                catch { MessageBox.Show("Introduce una fecha valida en un pago"); return; }

                //BUSCO EL EJERCICIO ACTIVO
                String idEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaMov);

                //CREO CABECERA DEL MOVIMIENTO
                numMov = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, id_cuenta_cargado, "2", id_entidad_pasado, fechaMov, "Ingreso a Proveedor");

            }
            for (int a = 0; a < dataGridView_general.Rows.Count;a++) {
                if (Convert.ToDouble(dataGridView_general.Rows[a].Cells[celdaAsignado].Value) != 0 && (Convert.ToDouble(dataGridView_general.Rows[a].Cells[celdaAsignado].Value) > 0)) {
                    if (tipoOperacion == "Pago")
                        pagarProveedor(a);
                    else if (tipoOperacion == "Ingreso a Comuneros") {
                        ingresoComunero(a,"Ingreso", numMov, fechaMov);
                    }
                    else if (tipoOperacion == "Salida a Comuneros") {
                       pagarComunero(a, numMov, fechaMov);
                    }
                    else if (tipoOperacion == "Entrada a Proveedor") {
                        ingresoComunero(a, "Ingreso a Proveedor", numMov, fechaMov);
                    } else if (tipoOperacion == "Pago a Proveedor") {
                        pagarProveedor(a);
                    }else if (tipoOperacion == "Otras Entradas") {
                        pagarOtrosIngresos(a);
                    }
                }
            }

            if (tipoOperacion == "Ingreso a Comuneros" && crearAnticipo || tipoOperacion == "Salida a Comuneros" && crearAnticipo)
                AnticipoResto(numMov);

            if ((tipoOperacion == "Pago a Proveedor" || tipoOperacion == "Entrada a Proveedor") && crearAnticipo)
                AnticipoRestoSalidaProveedor(numMov);

            if (form_anterior != null)
            {
                form_anterior.cargarDatagrid();
            }else {
                try
                {
                    Tesoreria existe = Application.OpenForms.OfType<Tesoreria>().Where(pre => pre.Name.Contains("Tesoreria" + (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.NombreCorto FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_cargado + " ));")).Rows[0][0].ToString())).SingleOrDefault<Tesoreria>();
                    if (existe != null)
                    {
                        existe.cargarDatagrid();
                    }
                }catch {
                    MessageBox.Show("Actualiza Tesorería");
                }

            }
            this.Close();
        }
        private void pagarComunero(int indice, int numMov, String fechaMov)
        {
            //ANTICIPO SI QUEDA ALGO PENDIENTE
            double importeReal = Convert.ToDouble(dataGridView_general.Rows[indice].Cells[importeOp].Value);
            double importeAsignado = Convert.ToDouble(dataGridView_general.Rows[indice].Cells[celdaAsignado].Value.ToString().Replace('.', ','));
            double importeAcuenta = importeAsignado - importeReal;

            if (importeAcuenta > 0)
            {
                //ANTICIPO A COMUNERO
                Logica.FuncionesTesoreria.AnticipoComunero(id_comunidad_cargado, dataGridView_general.Rows[indice].Cells[1].Value.ToString(), fechaMov, importeAcuenta, numMov);

                //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE ENTERO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), dataGridView_general.Rows[indice].Cells[0].Value.ToString(), Logica.FuncionesGenerales.ArreglarImportes(dataGridView_general.Rows[indice].Cells[importeOp].Value.ToString()));
            }
            else if (importeAcuenta < 0)
            {
                //CREO EL DETALLE DEL MOVIMIENTO CON EL ACUMULADO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), dataGridView_general.Rows[indice].Cells[0].Value.ToString(), Logica.FuncionesGenerales.ArreglarImportes(dataGridView_general.Rows[indice].Cells[celdaAsignado].Value.ToString()));
            }
            else if (importeAcuenta == 0)
            {
                //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE ENTERO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), dataGridView_general.Rows[indice].Cells[0].Value.ToString(), Logica.FuncionesGenerales.ArreglarImportes(dataGridView_general.Rows[indice].Cells[importeOp].Value.ToString()));
            }

        }
        private void AnticipoRestoSalidaProveedor(int numMov) {

            String fechaMov = "";
            try { fechaMov = (Convert.ToDateTime(fecha_operacion_pasado)).ToString("yyyy-MM-dd"); }
            catch { MessageBox.Show("Introduce una fecha valida en un pago"); return; }
            double importeAsignado = Convert.ToDouble(textBox_operacion_disponible.Text.ToString().Replace('.', ','));

            //ANTICIPO A PROVEEDOR
            Logica.FuncionesTesoreria.AnticipoProveedor(id_comunidad_cargado, id_entidad_pasado, fechaMov, importeAsignado, numMov);
        }

        private void AnticipoResto(int numMov)
        {
                String fechaMov = "";
                    try { fechaMov = (Convert.ToDateTime(fecha_operacion_pasado)).ToString("yyyy-MM-dd"); }
                    catch { MessageBox.Show("Introduce una fecha valida en un pago"); return; }

                    //BUSCO EL EJERCICIO ACTIVO
                    String idEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaMov);

                    double importeAsignado = Convert.ToDouble(textBox_operacion_disponible.Text.ToString().Replace('.', ','));

                    //ANTICIPO A COMUNERO
                    Logica.FuncionesTesoreria.AnticipoComunero(id_comunidad_cargado, id_entidad_pasado, fechaMov, importeAsignado, numMov);
        }

        private void ingresoComunero(int indice,String descripcion,int num_mov_nuevo, String fecha) {

            double importeReal = Convert.ToDouble(dataGridView_general.Rows[indice].Cells[importeOp].Value);
            double importeAsignado = Convert.ToDouble(dataGridView_general.Rows[indice].Cells[celdaAsignado].Value.ToString().Replace('.',','));
            double importeAcuenta = importeAsignado - importeReal;

            if (importeAcuenta > 0)
            {
                //ANTICIPO A COMUNERO
                Logica.FuncionesTesoreria.AnticipoComunero(id_comunidad_cargado, dataGridView_general.Rows[indice].Cells[1].Value.ToString(), fecha, importeAcuenta, num_mov_nuevo);

                //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE ENTERO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(num_mov_nuevo.ToString(), dataGridView_general.Rows[indice].Cells[0].Value.ToString(), Logica.FuncionesGenerales.ArreglarImportes(dataGridView_general.Rows[indice].Cells[importeOp].Value.ToString()));
            }
            else if (importeAcuenta < 0)
            {
                //CREO EL DETALLE DEL MOVIMIENTO CON EL ACUMULADO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(num_mov_nuevo.ToString(), dataGridView_general.Rows[indice].Cells[0].Value.ToString(), Logica.FuncionesGenerales.ArreglarImportes(dataGridView_general.Rows[indice].Cells[celdaAsignado].Value.ToString()));
            }
            else if (importeAcuenta == 0)
            {
                //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE ENTERO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(num_mov_nuevo.ToString(), dataGridView_general.Rows[indice].Cells[0].Value.ToString(), Logica.FuncionesGenerales.ArreglarImportes(dataGridView_general.Rows[indice].Cells[importeOp].Value.ToString()));
            }
        }
        private void pagarProveedor(int indice) {

            //COJO LA FECHA ASIGNADA
            String fechaMov;
            try
            {
                //COMPRUEBO QUE ESTA DENTRO DE LA FECHA DE CIERRE
                String fechaCierre = (Persistencia.SentenciasSQL.select("SELECT FCierre FROM com_cuentas WHERE IdCuenta = " + id_cuenta_cargado)).Rows[0][0].ToString();
                if (fechaCierre != "" || fechaCierre != null)
                {
                    if (Convert.ToDateTime(dataGridView_general.Rows[indice].Cells[fechaasignacion].Value.ToString()) < Convert.ToDateTime(fechaCierre))  {
                        MessageBox.Show("El banco esta cerrado a esa fecha y el pago de " + dataGridView_general.Rows[indice].Cells[5].Value.ToString() + " no se ha realizado.");
                        return;
                    }
                    
                }

                fechaMov = (Convert.ToDateTime(dataGridView_general.Rows[indice].Cells[fechaasignacion].Value.ToString())).ToString("yyyy-MM-dd");

            }
            catch {
                MessageBox.Show("Introduce una fecha valida en un pago");
                return;
            }
                //BUSCO EL EJERCICIO ACTIVO
                String idEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaMov);
                    
                //CREO CABECERA DEL MOVIMIENTO
                int numMov = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, id_cuenta_cargado, "8", dataGridView_general.Rows[indice].Cells[2].Value.ToString(), fechaMov, "Pagos");

                double importeReal = Convert.ToDouble(dataGridView_general.Rows[indice].Cells[importeOp].Value);
                double importeAsignado = Convert.ToDouble(dataGridView_general.Rows[indice].Cells[celdaAsignado].Value.ToString().Replace('.', ','));
                double importeAcuenta = importeAsignado - importeReal;

            if (importeAcuenta > 0)
            {
                //ANTICIPO A PROVEEDOR
                Logica.FuncionesTesoreria.AnticipoProveedor(id_comunidad_cargado, dataGridView_general.Rows[indice].Cells[2].Value.ToString(), fechaMov, importeAcuenta, numMov);

                //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE ENTERO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), dataGridView_general.Rows[indice].Cells[0].Value.ToString(), dataGridView_general.Rows[indice].Cells[importeOp].Value.ToString().Replace(',', '.'));
            }
            else if (importeAcuenta < 0)
            {
                //CREO EL DETALLE DEL MOVIMIENTO CON EL ACUMULADO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), dataGridView_general.Rows[indice].Cells[0].Value.ToString(), dataGridView_general.Rows[indice].Cells[celdaAsignado].Value.ToString().Replace(',', '.'));
            }
            else if (importeAcuenta == 0)
            {
                //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE ENTERO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), dataGridView_general.Rows[indice].Cells[0].Value.ToString(), dataGridView_general.Rows[indice].Cells[importeOp].Value.ToString().Replace(',', '.'));
            }

        }

        private void dataGridView_general_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            total_acumulado = 0;
            if (acabadoDeCargar)
            {
                for (int a = 0; a < dataGridView_general.Rows.Count; a++)
                {
                    if (dataGridView_general.Rows[a].Cells[celdaAsignado].Value != null && Convert.ToDouble(dataGridView_general.Rows[a].Cells[celdaAsignado].Value.ToString()) > 0)
                    {
                        total_acumulado = total_acumulado + Convert.ToDouble(dataGridView_general.Rows[a].Cells[celdaAsignado].Value.ToString().Replace('.',','));
                        //MessageBox.Show(Convert.ToDouble(dataGridView_general.Rows[a].Cells[celdaAsignado].Value.ToString().Replace('.', ',')).ToString());
                    }
                }
                textBox_total_acumulado.Text = total_acumulado.ToString();
                if (id_entidad_pasado != "0")
                {
                    textBox_operacion_disponible.Text = Math.Round((Convert.ToDouble(importe_operacion_pasado.Replace('.', ',')) - total_acumulado), 2).ToString();
                    if (Math.Round((Convert.ToDouble(importe_operacion_pasado.Replace('.', ',')) - total_acumulado), 2) < 0 ) {
                        textBox_operacion_disponible.Text = "0.00";
                    }
                }
                if (e.ColumnIndex == fechaasignacion)
                {
                    if (dataGridView_general.CurrentCell.Value.ToString().Length == 8)
                    {
                        dataGridView_general.CurrentCell.Value = dataGridView_general.CurrentCell.Value.ToString().Substring(0, 2) + "/" + dataGridView_general.CurrentCell.Value.ToString().Substring(2, 2) + "/" + dataGridView_general.CurrentCell.Value.ToString().Substring(4, 4);
                    }
                }
            }
        }

        private void dataGridView_general_Sorted(object sender, EventArgs e)
        {
            for (int a = 0; a < dataGridView_general.Rows.Count; a++)
            {
                    dataGridView_general.Rows[a].Cells["Pagar"].Value = "P";
                    dataGridView_general.Rows[a].Cells["Cantidad"].Value = 0.00; 
            }
        }

        private void dataGridView_general_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == fechaasignacion && (dataGridView_general.CurrentCell.Value != null ) )
            {
                string sPattern = "^\\d{2}/\\d{2}$";
                string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

                if (Regex.IsMatch(dataGridView_general.CurrentCell.Value.ToString(), sPattern))
                {
                    dataGridView_general.CurrentCell.Value = dataGridView_general.CurrentCell.Value.ToString() + "/" + DateTime.Now.Year;
                    fecha_arrastrar = dataGridView_general.CurrentCell.Value.ToString();
                }
                else if (!Regex.IsMatch(dataGridView_general.CurrentCell.Value.ToString(), sPattern1) && !Regex.IsMatch(dataGridView_general.CurrentCell.Value.ToString(), sPattern))  {
                }
            }
        }
        private void pagarOtrosIngresos(int indice) {

            String fechaMov;
            try
            {
                //COMPRUEBO QUE ESTA DENTRO DE LA FECHA DE CIERRE
                String fechaCierre = (Persistencia.SentenciasSQL.select("SELECT FCierre FROM com_cuentas WHERE IdCuenta = " + id_cuenta_cargado)).Rows[0][0].ToString();
                if (fechaCierre != "" || fechaCierre != null)
                {
                    if (Convert.ToDateTime(dataGridView_general.Rows[indice].Cells[fechaasignacion].Value.ToString()) < Convert.ToDateTime(fechaCierre))
                    {
                        MessageBox.Show("El banco esta cerrado a esa fecha y el pago de " + dataGridView_general.Rows[indice].Cells[5].Value.ToString() + " no se ha realizado.");
                        return;
                    }

                }

                fechaMov = (Convert.ToDateTime(dataGridView_general.Rows[indice].Cells[fechaasignacion].Value.ToString())).ToString("yyyy-MM-dd");

            }
            catch
            {
                MessageBox.Show("Introduce una fecha valida en un pago");
                return;
            }

            //BUSCO EL EJERCICIO ACTIVO
            String idEjercicio = Logica.FuncionesTesoreria.ejercicioActivo(id_comunidad_cargado, fechaMov);

            //CREO CABECERA DEL MOVIMIENTO
            int numMov = Logica.FuncionesTesoreria.CreaMovimiento(idEjercicio, id_cuenta_cargado, "2", dataGridView_general.Rows[indice].Cells[3].Value.ToString(), fechaMov, "Otros Vtos");

            double importeReal = Convert.ToDouble(dataGridView_general.Rows[indice].Cells[importeOp].Value);
            double importeAsignado = Convert.ToDouble(dataGridView_general.Rows[indice].Cells[celdaAsignado].Value.ToString().Replace('.', ','));
            double importeAcuenta = importeAsignado - importeReal;

            if (importeAcuenta > 0)
            {
                //ANTICIPO A PROVEEDOR
                Logica.FuncionesTesoreria.AnticipoProveedor(id_comunidad_cargado, dataGridView_general.Rows[indice].Cells[3].Value.ToString(), fechaMov, importeAcuenta, numMov);

                //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE ENTERO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), dataGridView_general.Rows[indice].Cells[1].Value.ToString(), dataGridView_general.Rows[indice].Cells[importeOp].Value.ToString().Replace(',', '.'));
            }
            else if (importeAcuenta < 0)
            {
                //CREO EL DETALLE DEL MOVIMIENTO CON EL ACUMULADO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), dataGridView_general.Rows[indice].Cells[1].Value.ToString(), dataGridView_general.Rows[indice].Cells[celdaAsignado].Value.ToString().Replace(',', '.'));
            }
            else if (importeAcuenta == 0)
            {
                //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE ENTERO
                Logica.FuncionesTesoreria.CreaDetalleMovimiento(numMov.ToString(), dataGridView_general.Rows[indice].Cells[1].Value.ToString(), dataGridView_general.Rows[indice].Cells[importeOp].Value.ToString().Replace(',', '.'));
            }

        }
    }
}
