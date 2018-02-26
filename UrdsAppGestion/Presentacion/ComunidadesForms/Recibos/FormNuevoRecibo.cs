using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.Recibos
{
    public partial class FormNuevoRecibo : Form
    {
        String id_comunidad_cargado;
        String id_entidad_nuevo;

        public FormNuevoRecibo(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }       
        public FormNuevoRecibo(String id_comunidad_cargado, String id_comunero)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void textBox_pagador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Space) {
                Entidades nueva = new Entidades(this, this.Name);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar_nombre.Select();
                nueva.textBox_buscar_nombre.Location = new Point(nueva.textBox_buscar_nombre.Location.X, nueva.textBox_buscar_nombre.Location.Y + 60);
                nueva.label2.Location = new Point(label2.Location.X + 870, nueva.label2.Location.Y + 60);
                nueva.label3.Visible = false;
                nueva.label4.Visible = false;
                nueva.textBox_correo_buscar.Visible = false;
                nueva.textBox_telefono_buscar.Visible = false;
                nueva.dataGridView1.TabIndex = 2;
                nueva.textBox_buscar_nombre.TabIndex = 1;
                nueva.Show();
            }
        }
        public void recibirEntidad(String id_entidad)
        {
            id_entidad_nuevo = id_entidad;
            String nombre = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IdEntidad = " + id_entidad)).Rows[0][0].ToString();
            textBox_pagador.Text = nombre;
            cargarBanco();
        }

        private void FormNuevoRecibo_Load(object sender, EventArgs e)
        {
            textBox_pagador.SelectAll();
            textBox_fecha.Text = DateTime.Now.ToShortDateString();
        }
        private void cargarBanco() {
            String sqlBanco = "SELECT IdCuenta, Descripcion FROM ctos_detbancos WHERE IdEntidad = " + id_entidad_nuevo;
            comboBox_cuenta.DataSource = Persistencia.SentenciasSQL.select(sqlBanco);
            comboBox_cuenta.ValueMember = "IdCuenta";
            comboBox_cuenta.DisplayMember = "Descripcion";
            if (comboBox_cuenta.Items.Count > 0)
            {
                comboBox_cuenta.SelectedIndex = 0;
                cambiarCC();
            }
            cargarDatagrid();
        }
        private void cargarDatagrid() {
            String sqlVencimientos = "SELECT com_opdetalles.IdOpDet, com_opdetalles.Fecha, com_operaciones.Descripcion, com_opdetalles.Importe FROM com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp WHERE(((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ") AND((com_opdetalles.IdEntidad) =" + id_entidad_nuevo + ") AND ((com_opdetalles.IdRecibo) Is Null) AND((com_operaciones.IdSubCuenta)Between 10000 And 700001));";
            dataGridView_vencimientos.DataSource = Persistencia.SentenciasSQL.select(sqlVencimientos);
            dataGridView_vencimientos.Columns["IdOpDet"].Width = 50;
        }
        private void cambiarCC() {
            String sqlCC = "SELECT CC FROM ctos_detbancos WHERE IdCuenta = " + comboBox_cuenta.SelectedValue.ToString();
            textBox_cc.Text = (Persistencia.SentenciasSQL.select(sqlCC)).Rows[0][0].ToString();
        }

        private void comboBox_cuenta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cambiarCC();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (id_entidad_nuevo != null && textBox_referencias.Text != "" && dataGridView_vencimientos.SelectedRows.Count > 0 ) {
                double varSumImp = 0.00;
                double varImp = 0.00;
                int varSignoAnt = 0;
                int varSigno;
                String fecha = (Convert.ToDateTime(textBox_fecha.Text)).ToString("yyyy-MM-dd");

                int cont = 1;

                for (int a = 0; a< dataGridView_vencimientos.SelectedRows.Count;a++) {
                    varImp = Convert.ToDouble(dataGridView_vencimientos.SelectedRows[a].Cells[3].Value);
                    if  (varImp > 0) {
                        if (cont == 1) varSignoAnt = 1;
                        varSigno = 1;
                        varSumImp = varSumImp + varImp;
                    }else {
                        if (cont == 1) varSignoAnt = -1;
                        varSigno = -1;
                        varSumImp = varSumImp + varImp;
                    }
                    if (varSigno != varSignoAnt)  {
                        MessageBox.Show("Debes seleccionar vtos del mismo signo");
                        return;
                    }
                    cont++;
                }
                int num_recibo = Logica.FuncionesTesoreria.CreoReciboID(id_comunidad_cargado,id_entidad_nuevo, fecha, varSumImp.ToString(), varSumImp.ToString(), textBox_referencias.Text);

                for (int a = 0;a<dataGridView_vencimientos.SelectedRows.Count;a++) {
                    String varVto = dataGridView_vencimientos.SelectedRows[a].Cells[0].Value.ToString();
                    String strActVtosRbo = "UPDATE com_opdetalles SET com_opdetalles.IdRecibo = " + num_recibo + " WHERE (((com_opdetalles.IdOpDet)=" + varVto + "));";
                    Persistencia.SentenciasSQL.InsertarGenerico(strActVtosRbo);
                }
                MessageBox.Show("Recibo Listo");
            }
            else {
                MessageBox.Show("Revise los datos");
            }
            this.Close();
        }
    }
}
