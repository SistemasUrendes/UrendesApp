using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.Impuestos
{
    public partial class FormImpuestos : Form
    {
        String idComunidad;
        String anyo;
        String orden = "1";
        DataTable impuestos;
        String sqlSelect;
        String NombreComunidad;
        int numColumnaCheck;

        public FormImpuestos(String idComunidad, String anyo)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.anyo = anyo;

        }

        public void cargarDatagrid() {

            sqlSelect = "SELECT com_operaciones.IdComunidad, com_operaciones.IdOp, com_operaciones.Documento, ctos_entidades.Entidad, ctos_entidades.CIF, com_operaciones.Descripcion,  DATE_FORMAT(Coalesce(com_operaciones.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_operaciones.Retencion, com_operaciones.BaseRet, aux_retencion.`%Retencion` AS Retención, com_ivaImpuestos.Orden, com_ivaImpuestos.Cerrada FROM com_ivaImpuestos INNER JOIN (aux_retencion INNER JOIN(ctos_entidades INNER JOIN com_operaciones ON ctos_entidades.IDEntidad = com_operaciones.IdEntidad) ON aux_retencion.IdRetencion = com_operaciones.IdRetencion) ON com_ivaImpuestos.IdIvaImpuestos = com_operaciones.IdPeridoIVA GROUP BY com_operaciones.IdComunidad, com_operaciones.IdOp, com_operaciones.Documento, ctos_entidades.Entidad, ctos_entidades.CIF, com_operaciones.Descripcion, com_operaciones.Fecha, com_operaciones.Retencion, com_operaciones.BaseRet, aux_retencion.`%Retencion`, com_ivaImpuestos.Orden HAVING(((com_operaciones.Retencion) > 0) AND((com_operaciones.IdComunidad) = " + idComunidad + "));";

            impuestos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_impuestos.DataSource = impuestos;

            if (dataGridView_impuestos.Columns.Contains("Vacio"))
                dataGridView_impuestos.Columns.RemoveAt(dataGridView_impuestos.Columns["Vacio"].Index);

            DataGridViewTextBoxColumn espacio = new DataGridViewTextBoxColumn();
            espacio.HeaderText = "";
            espacio.Name = "Vacio";
            espacio.Width = 10;
            espacio.DefaultCellStyle.BackColor = Color.Gray;
            dataGridView_impuestos.Columns.Add(espacio);


            if (dataGridView_impuestos.Columns.Contains("Unir"))
                dataGridView_impuestos.Columns.RemoveAt(dataGridView_impuestos.Columns["Unir"].Index);

            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.HeaderText = "A";
            check.Width = 30;
            check.Name = "Unir";
            check.ReadOnly = false;
            dataGridView_impuestos.Columns.Add(check);
            numColumnaCheck = dataGridView_impuestos.Columns["Unir"].Index;

            for (int a = 0; a < dataGridView_impuestos.Columns.Count - 2; a++)
                dataGridView_impuestos.Columns[a].ReadOnly = true;

            dataGridView_impuestos.EditMode = DataGridViewEditMode.EditOnEnter;
            DataTable busqueda = impuestos;
            busqueda.DefaultView.RowFilter = "Orden = " + orden;
            this.dataGridView_impuestos.DataSource = busqueda;

            ajustarDatagrid();
            pintarDatagrid();

            NombreComunidad = Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Entidad FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + idComunidad + "));").Rows[0][0].ToString();

        }

        private void FormImpuestos_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
            comboBox_liquidaciones.SelectedIndex = 0;
        }

        private void comboBox_liquidaciones_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_liquidaciones.SelectedIndex == 0)
                orden = "1";
            else if (comboBox_liquidaciones.SelectedIndex == 1)
                orden = "2";
            else if (comboBox_liquidaciones.SelectedIndex == 2)
                orden = "3";
            else if (comboBox_liquidaciones.SelectedIndex == 3)
                orden = "4";

            DataTable busqueda = impuestos;
            busqueda.DefaultView.RowFilter = "Orden = " + orden;
            this.dataGridView_impuestos.DataSource = busqueda;
            pintarDatagrid();

        }
        private void ajustarDatagrid() {
            dataGridView_impuestos.Columns["Entidad"].Width = 200;
            dataGridView_impuestos.Columns["Descripcion"].Width = 200;
            dataGridView_impuestos.Columns["IdOp"].Width = 60;
            dataGridView_impuestos.Columns["Retención"].HeaderText = "%";
            dataGridView_impuestos.Columns["BaseRet"].DefaultCellStyle.Format = "c";
            dataGridView_impuestos.Columns["Retencion"].DefaultCellStyle.Format = "c";
            dataGridView_impuestos.Columns["Retencion"].Width = 70;
            dataGridView_impuestos.Columns["Orden"].Visible = false;
            dataGridView_impuestos.Columns["IdComunidad"].Visible = false;
            dataGridView_impuestos.Columns["Cerrada"].Width = 50;
            dataGridView_impuestos.Columns["Retención"].Width = 40;

        }

        private void dataGridView_impuestos_DoubleClick(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView_impuestos.SelectedRows[0].Cells[1].Value.ToString(), 2);
            nueva.Show();
        }

        private void comboBox_informes_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (comboBox_informes.SelectedIndex == 0) {
                Informes.FormVerInforme nueva = new Informes.FormVerInforme((DataTable)dataGridView_impuestos.DataSource, NombreComunidad);
                nueva.Show();
            }else if (comboBox_informes.SelectedIndex == 1) {

               String sqlSelectTodas = "SELECT com_operaciones.IdComunidad, com_operaciones.IdOp, com_operaciones.Documento, ctos_entidades.Entidad, ctos_entidades.CIF, com_operaciones.Descripcion,  DATE_FORMAT(Coalesce(com_operaciones.Fecha,'ok'),'%d/%m/%Y') AS Fecha, com_operaciones.Retencion, com_operaciones.BaseRet, aux_retencion.`%Retencion` AS Retención, com_ivaImpuestos.Orden FROM com_ivaImpuestos INNER JOIN (aux_retencion INNER JOIN(ctos_entidades INNER JOIN com_operaciones ON ctos_entidades.IDEntidad = com_operaciones.IdEntidad) ON aux_retencion.IdRetencion = com_operaciones.IdRetencion) ON com_ivaImpuestos.IdIvaImpuestos = com_operaciones.IdPeridoIVA GROUP BY com_operaciones.IdComunidad, com_operaciones.IdOp, com_operaciones.Documento, ctos_entidades.Entidad, ctos_entidades.CIF, com_operaciones.Descripcion, com_operaciones.Fecha, com_operaciones.Retencion, com_operaciones.BaseRet, aux_retencion.`%Retencion`, com_ivaImpuestos.Orden HAVING(((com_operaciones.Retencion) > 0) AND((com_operaciones.IdComunidad) = " + idComunidad + "));";

                DataTable impuestosTodos = Persistencia.SentenciasSQL.select(sqlSelectTodas);
                Informes.FormVerInforme nueva = new Informes.FormVerInforme(impuestosTodos, NombreComunidad);
                nueva.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nombre = "Nada";

            for (int a = 0; a < dataGridView_impuestos.Rows.Count; a++) {
                if (button1.Text == "Sel.Todos")    {
                    dataGridView_impuestos.Rows[a].Cells[numColumnaCheck].Value = true;
                    nombre = "Des. Todos";
                }else {
                    dataGridView_impuestos.Rows[a].Cells[numColumnaCheck].Value = false;
                    nombre = "Sel.Todos";
                }
            }
            button1.Text = nombre;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if (crearPeriodos()) {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea cerrar el " + comboBox_liquidaciones.SelectedItem + " ?", "Cerrar Impuestos", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK) {
                    for (int a = 0; a < dataGridView_impuestos.Rows.Count; a++) {
                        if ((Boolean)dataGridView_impuestos.Rows[a].Cells[numColumnaCheck].Value == false)
                            cambiarPeriodoImpuestos(dataGridView_impuestos.Rows[a].Cells[1].Value.ToString());
                    }
                    String sqlUpdate = "UPDATE com_ivaImpuestos SET Cerrada= -1 WHERE Orden = " + orden + " AND IdComunidad = " + idComunidad;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);

                    //Informes.FormVerInforme nueva = new Informes.FormVerInforme((DataTable)dataGridView_impuestos.DataSource,NombreComunidad);
                    //nueva.Show();

                    cargarDatagrid();
                }
            }
        }
        private void pintarDatagrid() {
            for (int a = 0; a<dataGridView_impuestos.Rows.Count; a++) {
                String sqlSelect = "SELECT com_ivaImpuestos.IdIvaImpuestos FROM com_operaciones INNER JOIN com_ivaImpuestos ON com_operaciones.IdPeridoIVA = com_ivaImpuestos.IdIvaImpuestos WHERE(((com_operaciones.IdOp) = " + dataGridView_impuestos.Rows[a].Cells[1].Value.ToString() + ") AND((com_ivaImpuestos.Cerrada) = -1));";
                if (Persistencia.SentenciasSQL.select(sqlSelect).Rows.Count > 0)    {
                    dataGridView_impuestos.Rows[a].DefaultCellStyle.ForeColor = Color.White;
                    dataGridView_impuestos.Rows[a].DefaultCellStyle.BackColor = Color.Red;
                }
            }
           // dataGridView_impuestos.Enabled = false;
            dataGridView_impuestos.ReadOnly = false;
        }
        private void cambiarPeriodoImpuestos (String idOp) {

            String orden2;
            if (orden == "4") orden2 = "1";
            else orden2 = (Convert.ToInt32(orden) + 1).ToString();

            String sqlSelect = "SELECT com_ivaImpuestos.IdIvaImpuestos FROM com_ivaImpuestos WHERE com_ivaImpuestos.Orden = " + orden2 + " AND com_ivaImpuestos.IdComunidad =" + idComunidad;

            DataTable ivamas1 = Persistencia.SentenciasSQL.select(sqlSelect);
            if (ivamas1.Rows.Count > 0)     {
                String sqlUpdate = "UPDATE com_operaciones SET IdPeridoIVA=" + ivamas1.Rows[0][0].ToString() + " WHERE IdOp = " + idOp;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
        }
        private Boolean crearPeriodos() {

            String sql = "SELECT IdIvaImpuestos FROM com_ivaImpuestos WHERE IdComunidad = " + idComunidad;
            DataTable lineas = Persistencia.SentenciasSQL.select(sql);
            if (lineas.Rows.Count != 4) {

                String sqlDelete = "DELETE FROM com_ivaImpuestos WHERE IdComunidad = " + idComunidad;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);

                String sql1 = "INSERT INTO  com_ivaImpuestos (IdComunidad ,Descripcion, DescripcionCorta, FIni, FFin, Orden ,Cerrada) VALUES (" + idComunidad + ", '1º Trimestre IVA', '1TIVA', '01-01', '30-03', '1', '0')";
                Persistencia.SentenciasSQL.InsertarGenerico(sql1);
                String sql2 = "INSERT INTO  com_ivaImpuestos (IdComunidad ,Descripcion, DescripcionCorta, FIni, FFin, Orden ,Cerrada) VALUES (" + idComunidad + ", '2º Trimestre IVA', '2TIVA', '01-04', '30-06', '2', '0')";
                Persistencia.SentenciasSQL.InsertarGenerico(sql2);
                String sql3 = "INSERT INTO  com_ivaImpuestos (IdComunidad ,Descripcion, DescripcionCorta, FIni, FFin, Orden ,Cerrada) VALUES (" + idComunidad + ", '3º Trimestre IVA', '3TIVA', '01-07', '30-09', '3', '0')";
                Persistencia.SentenciasSQL.InsertarGenerico(sql3);
                String sql4 = "INSERT INTO  com_ivaImpuestos (IdComunidad ,Descripcion, DescripcionCorta, FIni, FFin, Orden ,Cerrada) VALUES (" + idComunidad + ", '4º Trimestre IVA', '4TIVA', '01-10', '30-12', '4', '0')";
                Persistencia.SentenciasSQL.InsertarGenerico(sql4);

                return true;
            }else {
                return true;
            }
        }
    }
}
