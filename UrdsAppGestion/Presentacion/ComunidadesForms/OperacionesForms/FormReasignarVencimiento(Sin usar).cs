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
    public partial class FormReasignarVencimiento : Form
    {
        Operaciones_comuneros form_anterior;
        String titular_vencimiento;
        String id_op_det;

        public FormReasignarVencimiento(Operaciones_comuneros form_anterior, String titular_vencimiento, String id_op_det)
        {
            this.form_anterior = form_anterior;
            this.titular_vencimiento = titular_vencimiento;
            this.id_op_det = id_op_det;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormReasignarVencimiento_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos() {

            String sqlSelectOp = "SELECT com_opdetalles.IdOp, com_operaciones.Descripcion, ctos_entidades.Entidad, com_opdetalles.Fecha, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte, com_opdetalles.IdRecibo FROM(com_operaciones INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp WHERE(((com_opdetalles.IdOpDet) = " + id_op_det + "));";

            DataTable vencimientoDetalles = Persistencia.SentenciasSQL.select(sqlSelectOp);

            textBox_idop.Text = vencimientoDetalles.Rows[0][0].ToString();
            textBox_descrip.Text = vencimientoDetalles.Rows[0][1].ToString();
            textBox_titular.Text = vencimientoDetalles.Rows[0][2].ToString();
            textBox_fecha.Text = vencimientoDetalles.Rows[0][3].ToString();
            textBox_importe.Text = vencimientoDetalles.Rows[0][4].ToString();
            textBox_importepte.Text = vencimientoDetalles.Rows[0][5].ToString();
            textBox_recibo.Text = vencimientoDetalles.Rows[0][6].ToString();
            textBox_pagador.Text = titular_vencimiento;
            textBox_idopdet.Text = id_op_det;

        }

        private void textBox_nuevo_pagador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'e' || e.KeyChar == 'E' || e.KeyChar == (Char)Keys.Space)
            {
                Entidades nueva = new Entidades(this, this.Name);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar_nombre.Select();
                nueva.dataGridView1.TabIndex = 2;
                nueva.textBox_buscar_nombre.TabIndex = 1;
                nueva.Show();
            }
        }
    }
}
