using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    public partial class FormDivisionesCuotas : Form
    {
        String id_comunidad_cargado;
        String id_division_cargado = null;
        DataTable cuotasDivision;

        public FormDivisionesCuotas(String id_comunidad_cargado, String id_division_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_division_cargado = id_division_cargado;
        }

        public FormDivisionesCuotas(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void FormOperacionesComuneros_Load(object sender, EventArgs e)
        {
            
            comboBoxestado.DataSource = Persistencia.SentenciasSQL.select("SELECT IdEstadoCuota, Descripcion FROM com_estadosCuotas");
            comboBoxestado.ValueMember = "IdEstadoCuota";
            comboBoxestado.DisplayMember = "Descripcion";

            comboBoxestado.SelectedValue = "6";
            comboBox_filtrofecha.SelectedItem = "Operaciones";
            cargarDatagrid();
        }
        public void cargarDatagrid() {

            String fechaInicio;
            String fechaFin;

            try
            {
                fechaInicio = (Convert.ToDateTime("1-1-" + DateTime.Now.Year)).ToString("yyyy-MM-dd");
                fechaFin = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
            }
            catch
            {
                MessageBox.Show("La fecha no es correcta.Revisala");
                return;
            }

            if (id_division_cargado != null)
            {
                String sqlSelect = "SELECT com_operaciones.IdDivision, com_operaciones.Descripcion, com_operaciones.ImpOp, com_operaciones.ImpOpPte, com_opdetalles.IdRecibo, com_estadosCuotas.Descripcion, com_operaciones.FCertificado, com_operaciones.IdOp FROM(com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) LEFT JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota WHERE(((com_operaciones.IdDivision) = " + id_division_cargado + ") AND((com_operaciones.ImpOpPte) <> 0));";

                cuotasDivision = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_operacionesComuneros.DataSource = cuotasDivision;
                ajustarDatagrid();

            }else if (comboBox_filtrofecha.SelectedItem.ToString() == "Operaciones") {
                String sqlSelect = "SELECT com_operaciones.IdOp, ctos_entidades.Entidad, com_divisiones.Division, com_operaciones.Descripcion, com_operaciones.Fecha, com_operaciones.ImpOpPte, com_estadosCuotas.Descripcion, com_operaciones.FCertificado, com_operaciones.FEstadoCuota, com_operaciones.IdSubCuenta,com_operaciones.IdEstadoCuota, ctos_entidades.IDEntidad FROM((com_operaciones LEFT JOIN com_divisiones ON com_operaciones.IdDivision = com_divisiones.IdDivision) LEFT JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota) INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_operaciones.Fecha) >= '" + fechaInicio + "' And (com_operaciones.Fecha) <= '" + fechaFin + "' ) AND (((com_operaciones.IdSubCuenta)=70000) Or (com_operaciones.IdSubCuenta)=70001) AND ((com_operaciones.IdComunidad)=" + id_comunidad_cargado + "))ORDER BY com_operaciones.Fecha ASC;";

                cuotasDivision = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_operacionesComuneros.DataSource = cuotasDivision;
                dataGridView_operacionesComuneros.Columns["Descripcion1"].HeaderText = "Estado Cuota";
                dataGridView_operacionesComuneros.Columns["Descripcion"].Width = 220;
                dataGridView_operacionesComuneros.Columns["Entidad"].Width = 250;

                dataGridView_operacionesComuneros.Columns["IdSubCuenta"].Visible = false;
                dataGridView_operacionesComuneros.Columns["IdEstadoCuota"].Visible = false;

                dataGridView_operacionesComuneros.Columns["IDEntidad"].Visible = false;

            }
            else if (comboBox_filtrofecha.SelectedItem.ToString() == "Certificados")
            {
                String sqlSelect = "SELECT com_operaciones.IdOp, ctos_entidades.Entidad, com_divisiones.Division, com_operaciones.Descripcion, com_operaciones.Fecha, com_operaciones.ImpOpPte, com_estadosCuotas.Descripcion, com_operaciones.FCertificado, com_operaciones.FEstadoCuota, com_operaciones.IdSubCuenta,com_operaciones.IdEstadoCuota, ctos_entidades.IDEntidad FROM((com_operaciones LEFT JOIN com_divisiones ON com_operaciones.IdDivision = com_divisiones.IdDivision) LEFT JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota) INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_operaciones.FCertificado) >= '" + fechaInicio + "' And (com_operaciones.FCertificado) <= '" + fechaFin + "' ) AND (((com_operaciones.IdSubCuenta)=70000) Or (com_operaciones.IdSubCuenta)=70001) AND ((com_operaciones.IdComunidad)=" + id_comunidad_cargado + "))ORDER BY com_operaciones.FCertificado ASC;";

                cuotasDivision = Persistencia.SentenciasSQL.select(sqlSelect);
                dataGridView_operacionesComuneros.DataSource = cuotasDivision;
                dataGridView_operacionesComuneros.Columns["Descripcion1"].HeaderText = "Estado Cuota";
                dataGridView_operacionesComuneros.Columns["Descripcion"].Width = 220;
                dataGridView_operacionesComuneros.Columns["Entidad"].Width = 250;
                dataGridView_operacionesComuneros.Columns["IdSubCuenta"].Visible = false;
                dataGridView_operacionesComuneros.Columns["IdEstadoCuota"].Visible = false;
                dataGridView_operacionesComuneros.Columns["IDEntidad"].Visible = false;
            }

            comboBox_estado.SelectedItem = "Todo";
            comboBox_certificado.SelectedItem = "Todas";
            dataGridView_operacionesComuneros.Columns["ImpOpPte"].DefaultCellStyle.Format = "c";

            label_registros.Text = dataGridView_operacionesComuneros.Rows.Count.ToString() + " Registros";
            maskedTextBox_inicio.Text = Convert.ToDateTime("1-1-" + DateTime.Now.Year).ToShortDateString();
            maskedTextBox_fin.Text = Convert.ToDateTime(DateTime.Now).ToShortDateString();
        }
        private void ajustarDatagrid() {
            dataGridView_operacionesComuneros.Columns[1].Width = 310;
            dataGridView_operacionesComuneros.Columns[0].Visible = false;
            dataGridView_operacionesComuneros.Columns[7].Visible = false;
            dataGridView_operacionesComuneros.Columns["ImpOpPte"].DefaultCellStyle.Format = "c";
            dataGridView_operacionesComuneros.Columns["ImpOp"].DefaultCellStyle.Format = "c";
            dataGridView_operacionesComuneros.Columns[5].HeaderText = "Estado";
        
        }
        public void aplicarFiltro() {
            String fechaInicio;
            String fechaFin;
            String sqlSelect = "";
            dataGridView_operacionesComuneros.DataSource = null;

            try
            {
                fechaInicio = (Convert.ToDateTime(maskedTextBox_inicio.Text)).ToString("yyyy-MM-dd");
                fechaFin = (Convert.ToDateTime(maskedTextBox_fin.Text)).ToString("yyyy-MM-dd");
            }
            catch
            {
                MessageBox.Show("La fecha no es correcta.Revisala");
                return;
            }

            if (id_division_cargado != null)
            {
                if (comboBox_estado.SelectedItem.ToString() == "Pendiente")
                {
                    sqlSelect = "SELECT com_divisiones.IdDivision, com_operaciones.Descripcion, com_operaciones.ImpOp, com_operaciones.ImpOpPte, com_opdetalles.IdRecibo, com_estadosCuotas.Descripcion, com_operaciones.FCertificado, com_operaciones.IdOp FROM(((com_opdetbloques INNER JOIN com_divisiones ON com_opdetbloques.IdDivision = com_divisiones.IdDivision) INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota WHERE(((com_divisiones.IdDivision) = " + id_division_cargado + ") AND((com_operaciones.Fecha) >= '" + fechaInicio + "' And (com_operaciones.Fecha) <= '" + fechaFin + "') And (ImpOpPte > 0));";
                }
                else if (comboBox_estado.SelectedItem.ToString() == "Cerrado")
                {
                    sqlSelect = "SELECT com_divisiones.IdDivision, com_operaciones.Descripcion, com_operaciones.ImpOp, com_operaciones.ImpOpPte, com_opdetalles.IdRecibo, com_estadosCuotas.Descripcion, com_operaciones.FCertificado, com_operaciones.IdOp FROM(((com_opdetbloques INNER JOIN com_divisiones ON com_opdetbloques.IdDivision = com_divisiones.IdDivision) INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota WHERE(((com_divisiones.IdDivision) = " + id_division_cargado + ") AND((com_operaciones.Fecha) >= '" + fechaInicio + "' And (com_operaciones.Fecha) <= '" + fechaFin + "') And (ImpOpPte = 0));";
                }
                else if (comboBox_estado.SelectedItem.ToString() == "Todo")
                {
                    sqlSelect = "SELECT com_divisiones.IdDivision, com_operaciones.Descripcion, com_operaciones.ImpOp, com_operaciones.ImpOpPte, com_opdetalles.IdRecibo, com_estadosCuotas.Descripcion, com_operaciones.FCertificado, com_operaciones.IdOp FROM(((com_opdetbloques INNER JOIN com_divisiones ON com_opdetbloques.IdDivision = com_divisiones.IdDivision) INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota WHERE(((com_divisiones.IdDivision) = " + id_division_cargado + ") AND((com_operaciones.Fecha) >= '" + fechaInicio + "' And (com_operaciones.Fecha) <= '" + fechaFin + "'));";
                }
                //ajustarDatagrid();
            }
            if (comboBox_filtrofecha.SelectedItem.ToString() == "Operaciones")
            {
                if (comboBoxestado.SelectedValue.ToString() != "6")
                {
                    sqlSelect = "SELECT com_operaciones.IdOp, ctos_entidades.Entidad, com_divisiones.Division, com_operaciones.Descripcion, com_operaciones.Fecha, com_operaciones.ImpOpPte, com_estadosCuotas.Descripcion, com_operaciones.FCertificado, com_operaciones.FEstadoCuota, com_operaciones.IdSubCuenta,com_operaciones.IdEstadoCuota, ctos_entidades.IDEntidad FROM((com_operaciones LEFT JOIN com_divisiones ON com_operaciones.IdDivision = com_divisiones.IdDivision) LEFT JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota) INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad WHERE( (com_operaciones.IdEstadoCuota = " + comboBoxestado.SelectedValue.ToString() + ") AND ((com_operaciones.Fecha) >= '" + fechaInicio + "' And (com_operaciones.Fecha) <= '" + fechaFin + "' ) AND (((com_operaciones.IdSubCuenta)=70000) Or (com_operaciones.IdSubCuenta)=70001) AND ((com_operaciones.IdComunidad)=" + id_comunidad_cargado + ")) ORDER BY com_operaciones.Fecha ASC;";
                }
                else
                {
                    sqlSelect = "SELECT com_operaciones.IdOp, ctos_entidades.Entidad, com_divisiones.Division, com_operaciones.Descripcion, com_operaciones.Fecha, com_operaciones.ImpOpPte, com_estadosCuotas.Descripcion, com_operaciones.FCertificado, com_operaciones.FEstadoCuota, com_operaciones.IdSubCuenta, com_operaciones.IdEstadoCuota ,ctos_entidades.IDEntidad FROM((com_operaciones LEFT JOIN com_divisiones ON com_operaciones.IdDivision = com_divisiones.IdDivision) LEFT JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota) INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_operaciones.Fecha) >= '" + fechaInicio + "' And (com_operaciones.Fecha) <= '" + fechaFin + "' ) AND (((com_operaciones.IdSubCuenta)=70000) Or (com_operaciones.IdSubCuenta)=70001) AND ((com_operaciones.IdComunidad)=" + id_comunidad_cargado + "))ORDER BY com_operaciones.Fecha ASC;";
                }
            }
            else if (comboBox_filtrofecha.SelectedItem.ToString() == "Certificados") {
                if (comboBoxestado.SelectedValue.ToString() != "6")
                {
                    sqlSelect = "SELECT com_operaciones.IdOp, ctos_entidades.Entidad, com_divisiones.Division, com_operaciones.Descripcion, com_operaciones.Fecha, com_operaciones.ImpOpPte, com_estadosCuotas.Descripcion, com_operaciones.FCertificado, com_operaciones.FEstadoCuota, com_operaciones.IdSubCuenta,com_operaciones.IdEstadoCuota, ctos_entidades.IDEntidad FROM((com_operaciones LEFT JOIN com_divisiones ON com_operaciones.IdDivision = com_divisiones.IdDivision) LEFT JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota) INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad WHERE( (com_operaciones.IdEstadoCuota = " + comboBoxestado.SelectedValue.ToString() + ") AND ((com_operaciones.FCertificado) >= '" + fechaInicio + "' And (com_operaciones.FCertificado) <= '" + fechaFin + "' ) AND (((com_operaciones.IdSubCuenta)=70000) Or (com_operaciones.IdSubCuenta)=70001) AND ((com_operaciones.IdComunidad)=" + id_comunidad_cargado + ")) ORDER BY com_operaciones.FCertificado ASC;";
                }
                else
                {
                    sqlSelect = "SELECT com_operaciones.IdOp, ctos_entidades.Entidad, com_divisiones.Division, com_operaciones.Descripcion, com_operaciones.Fecha, com_operaciones.ImpOpPte, com_estadosCuotas.Descripcion, com_operaciones.FCertificado, com_operaciones.FEstadoCuota, com_operaciones.IdSubCuenta, com_operaciones.IdEstadoCuota ,ctos_entidades.IDEntidad FROM((com_operaciones LEFT JOIN com_divisiones ON com_operaciones.IdDivision = com_divisiones.IdDivision) LEFT JOIN com_estadosCuotas ON com_operaciones.IdEstadoCuota = com_estadosCuotas.IdEstadoCuota) INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_operaciones.FCertificado) >= '" + fechaInicio + "' And (com_operaciones.FCertificado) <= '" + fechaFin + "' ) AND (((com_operaciones.IdSubCuenta)=70000) Or (com_operaciones.IdSubCuenta)=70001) AND ((com_operaciones.IdComunidad)=" + id_comunidad_cargado + "))ORDER BY com_operaciones.FCertificado ASC;";
                }
            }

            cuotasDivision = Persistencia.SentenciasSQL.select(sqlSelect);
            this.dataGridView_operacionesComuneros.DataSource = cuotasDivision;
            dataGridView_operacionesComuneros.Columns["Entidad"].Width = 250;

            DataTable busqueda = cuotasDivision;

            if (comboBox_estado.SelectedItem.ToString() == "Pendiente" && textBox_buscar.Text != "")
            {
                if (comboBox_certificado.SelectedItem.ToString() == "Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "(Division like '%" + textBox_buscar.Text + "%' OR Entidad like '%" + textBox_buscar.Text +  "%') AND ImpOpPte > 0 AND FCertificado is not NULL";
                }
                else if (comboBox_certificado.SelectedItem.ToString() == "No Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "(Division like '%" + textBox_buscar.Text + "%' OR Entidad like '%" + textBox_buscar.Text + "%') AND ImpOpPte > 0 AND FCertificado is NULL";
                }else {
                    busqueda.DefaultView.RowFilter = "(Division like '%" + textBox_buscar.Text + "%' OR Entidad like '%" + textBox_buscar.Text + "%') AND ImpOpPte > 0";
                }
            }
            else if (comboBox_estado.SelectedItem.ToString() == "Pendiente" && textBox_buscar.Text == "")
            {
                if (comboBox_certificado.SelectedItem.ToString() == "Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "ImpOpPte > 0 AND FCertificado is not NULL";
                }
                else if (comboBox_certificado.SelectedItem.ToString() == "No Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "ImpOpPte > 0 AND FCertificado is NULL";
                }else {
                    busqueda.DefaultView.RowFilter = "ImpOpPte > 0";
                }
            }
            else if (comboBox_estado.SelectedItem.ToString() == "Cerrado" && textBox_buscar.Text != "")
            {
                if (comboBox_certificado.SelectedItem.ToString() == "Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "(Division like '%" + textBox_buscar.Text + "%' OR Entidad like '%" + textBox_buscar.Text + "%') AND ImpOpPte = 0 AND FCertificado is not NULL";
                }
                else if (comboBox_certificado.SelectedItem.ToString() == "No Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "(Division like '%" + textBox_buscar.Text + "%' OR Entidad like '%" + textBox_buscar.Text + "%') AND ImpOpPte = 0 AND FCertificado is NULL";
                }else {
                    busqueda.DefaultView.RowFilter = "(Division like '%" + textBox_buscar.Text + "%' OR Entidad like '%" + textBox_buscar.Text + "%') AND ImpOpPte = 0";
                }
            }
            else if (comboBox_estado.SelectedItem.ToString() == "Pendiente" && textBox_buscar.Text == "")
            {
                if (comboBox_certificado.SelectedItem.ToString() == "Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "ImpOpPte = 0 AND FCertificado is not NULL";
                }
                else if (comboBox_certificado.SelectedItem.ToString() == "No Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "ImpOpPte = 0 AND FCertificado is NULL";
                }else {
                    busqueda.DefaultView.RowFilter = "ImpOpPte = 0";
                }
            }
            else if (comboBox_estado.SelectedItem.ToString() == "Todo" && textBox_buscar.Text != "")
            {
                if (comboBox_certificado.SelectedItem.ToString() == "Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "(Division like '%" + textBox_buscar.Text + "%' OR Entidad like '%" + textBox_buscar.Text + "%') AND FCertificado is not NULL ";
                }
                else if (comboBox_certificado.SelectedItem.ToString() == "No Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "(Division like '%" + textBox_buscar.Text + "%' OR Entidad like '%" + textBox_buscar.Text + "%') AND FCertificado is NULL ";
                }else {
                    busqueda.DefaultView.RowFilter = "(Division like '%" + textBox_buscar.Text + "%' OR Entidad like '%" + textBox_buscar.Text + "%')";
                }
                
            } else if (comboBox_estado.SelectedItem.ToString() == "Todo" && textBox_buscar.Text == "") {
                
                if (comboBox_certificado.SelectedItem.ToString() == "Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "FCertificado is not NULL ";
                }
                else if (comboBox_certificado.SelectedItem.ToString() == "No Certificadas")
                {
                    busqueda.DefaultView.RowFilter = "FCertificado is NULL ";
                }
            }

            label_registros.Text = dataGridView_operacionesComuneros.Rows.Count.ToString() + " Registros";
            dataGridView_operacionesComuneros.DataSource = busqueda;

            dataGridView_operacionesComuneros.Columns["Descripcion1"].HeaderText = "Estado Cuota";
            dataGridView_operacionesComuneros.Columns["Descripcion"].Width = 220;
            dataGridView_operacionesComuneros.Columns["Entidad"].Width = 250;

            dataGridView_operacionesComuneros.Columns["IdSubCuenta"].Visible = false;
            dataGridView_operacionesComuneros.Columns["IdEstadoCuota"].Visible = false;
            dataGridView_operacionesComuneros.Columns["IDEntidad"].Visible = false;

            dataGridView_operacionesComuneros.Columns["ImpOpPte"].DefaultCellStyle.Format = "c";
            label_registros.Text = dataGridView_operacionesComuneros.Rows.Count.ToString() + " Registros";
        }
        private void button_filtrar_Click(object sender, EventArgs e)
        {
            aplicarFiltro();
        }

        private void comboBox_estado_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void dataGridView_operacionesComuneros_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_operacionesComuneros.HitTest(e.X, e.Y);
                dataGridView_operacionesComuneros.ClearSelection();
                dataGridView_operacionesComuneros.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void textBox_buscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView_operacionesComuneros.SelectedRows.Count > 0)
            {
                List<String> lista_operaciones = new List<String> ();

                for (int a = 0; a < dataGridView_operacionesComuneros.SelectedRows.Count; a++)
                {
                    if (id_division_cargado != null)
                         lista_operaciones.Add(dataGridView_operacionesComuneros.SelectedRows[a].Cells[7].Value.ToString());
                    else
                        lista_operaciones.Add(dataGridView_operacionesComuneros.SelectedRows[a].Cells[0].Value.ToString());
                }

                FormCambiarEstadoDivision nueva = new FormCambiarEstadoDivision(this, lista_operaciones,"Estado");
                nueva.Show();
            }else {
                MessageBox.Show("Selecciona una fila");
            }
        }

        private void abrirOperacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView_operacionesComuneros.SelectedCells[7].Value.ToString(),2);
            nueva.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (dataGridView_operacionesComuneros.SelectedRows.Count > 0)
            {
                List<String> lista_operaciones = new List<String>();

                for (int a = 0; a < dataGridView_operacionesComuneros.SelectedRows.Count; a++)
                {
                    if (id_division_cargado != null)
                        lista_operaciones.Add(dataGridView_operacionesComuneros.SelectedRows[a].Cells[7].Value.ToString());
                    else
                        lista_operaciones.Add(dataGridView_operacionesComuneros.SelectedRows[a].Cells[0].Value.ToString());
                }

                FormCambiarEstadoDivision nueva = new FormCambiarEstadoDivision(this, lista_operaciones, "Certificado");
                nueva.Show();
            }
            else
            {
                MessageBox.Show("Selecciona una fila");
            }
        }

        private void reasignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Divisiones nueva = new Divisiones(Convert.ToInt32(id_comunidad_cargado), this.Name, this);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void recogerBloque(String id_division)
        {
            String sqlUPDATE = "UPDATE com_operaciones SET com_operaciones.IdDivision = " + id_division + " WHERE (((com_operaciones.IdOp) = " + dataGridView_operacionesComuneros.SelectedCells[0].Value.ToString() + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUPDATE);
            cargarDatagrid();
            aplicarFiltro();
        }

        private void dataGridView_operacionesComuneros_DoubleClick(object sender, EventArgs e)
        {
            OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(dataGridView_operacionesComuneros.SelectedCells[7].Value.ToString(),2);
            nueva.Show();
        }

        private void reasignarOperaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_operacionesComuneros.SelectedRows.Count == 1)
            {
                if (dataGridView_operacionesComuneros.Rows.Count > 1)
                {
                    FormReasignarPagador nueva = new FormReasignarPagador(this, id_comunidad_cargado, dataGridView_operacionesComuneros.SelectedCells[0].Value.ToString(), dataGridView_operacionesComuneros.SelectedCells[1].Value.ToString(), dataGridView_operacionesComuneros.SelectedCells[11].Value.ToString(), dataGridView_operacionesComuneros.SelectedCells[5].Value.ToString(), dataGridView_operacionesComuneros.SelectedRows[0].Index);
                    nueva.Show();
                }else if (dataGridView_operacionesComuneros.Rows.Count == 1) {
                    FormReasignarPagador nueva = new FormReasignarPagador(this, id_comunidad_cargado, dataGridView_operacionesComuneros.SelectedCells[0].Value.ToString(), dataGridView_operacionesComuneros.SelectedCells[1].Value.ToString(), dataGridView_operacionesComuneros.SelectedCells[11].Value.ToString(), dataGridView_operacionesComuneros.SelectedCells[5].Value.ToString());
                    nueva.Show();
                }
            }else {
                MessageBox.Show("Selecciona solo una operación ");
            }
        }

        private void borrarFechaCertificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dataGridView_operacionesComuneros.SelectedRows[0].Index;
            
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este la fecha de certificación a " + dataGridView_operacionesComuneros.SelectedRows.Count + " operaciones ?", "Borrar Fecha", MessageBoxButtons.OKCancel);

            if (resultado_message == System.Windows.Forms.DialogResult.OK)  {
                for (int a = 0; a < dataGridView_operacionesComuneros.SelectedRows.Count; a++)  {
                    String sql = "UPDATE com_operaciones SET FCertificado = Null WHERE IdOp = " + dataGridView_operacionesComuneros.SelectedRows[a].Cells[0].Value.ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(sql);
                    MessageBox.Show("Operaciones Actualizadas");
                    aplicarFiltro();
                    dataGridView_operacionesComuneros.ClearSelection();
                    dataGridView_operacionesComuneros.Rows[filaSeleccionada].Selected = true;
                }
            }
        }

        private void liquidarFondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ProvisionesForms.FormProvisionesDotarAplicar1 nueva = new ProvisionesForms.FormProvisionesDotarAplicar1(id_comunidad_cargado, comboBox1.SelectedItem.ToString());
            //nueva.Show();
        }
    }
}
