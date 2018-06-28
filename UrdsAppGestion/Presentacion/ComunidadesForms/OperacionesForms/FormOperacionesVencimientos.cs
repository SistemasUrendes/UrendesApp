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

namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    public partial class FormOperacionesVencimientos : Form
    {
        String id_comunidad_cargado;
        String id_operacion_cargado = "0";
        FromOperacionesVer form_anterior = null;
        String importe_cargado;
        String guardado = "no";
        Boolean vengoDePantallaVer = false;

        List<String> filas_eliminadas = new List<String>();

        public FormOperacionesVencimientos(FromOperacionesVer form_anterior, String id_comunidad_cargado, String id_operacion_cargado,String importe_cargado,Boolean vengoDePantallaVer)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_operacion_cargado = id_operacion_cargado;
            this.importe_cargado = importe_cargado;
            this.vengoDePantallaVer = vengoDePantallaVer;
        }

        public FormOperacionesVencimientos(String id_comunidad_cargado, String id_operacion_cargado,String importe_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_operacion_cargado = id_operacion_cargado;
            this.importe_cargado = importe_cargado;
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormOperacionesVencimientos_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.HeaderText = "ID";

            DataGridViewTextBoxColumn Entidad = new DataGridViewTextBoxColumn();
            id.HeaderText = "Entidad";
            Entidad.ReadOnly = true;
        
            DataGridViewTextBoxColumn IdEntidad = new DataGridViewTextBoxColumn();
            id.HeaderText = "IdEntidad";

            DataGridViewTextBoxColumn fecha = new DataGridViewTextBoxColumn();
            fecha.HeaderText = "Fecha";
            fecha.DefaultCellStyle.Format = "d";
            fecha.ReadOnly = false;

            DataGridViewTextBoxColumn importe = new DataGridViewTextBoxColumn();
            importe.HeaderText = "Importe";
            importe.ReadOnly = false;

            DataGridViewTextBoxColumn importePte = new DataGridViewTextBoxColumn();
            importePte.HeaderText = "Importe Pte";
            importePte.ReadOnly = true;

            DataGridViewTextBoxColumn IdRecibo = new DataGridViewTextBoxColumn();
            IdRecibo.HeaderText = "IdRecibo";
            IdRecibo.ReadOnly = true;

            dataGridView_vencimientos.Columns.Add(id);
            dataGridView_vencimientos.Columns.Add(fecha);
            dataGridView_vencimientos.Columns.Add(Entidad);
            dataGridView_vencimientos.Columns.Add(importe);
            dataGridView_vencimientos.Columns.Add(importePte);
            dataGridView_vencimientos.Columns.Add(IdRecibo);
            dataGridView_vencimientos.Columns.Add(IdEntidad);

            dataGridView_vencimientos.Columns[0].Name = "ID";
            dataGridView_vencimientos.Columns[1].Name = "Fecha Emisión";
            dataGridView_vencimientos.Columns[2].Name = "Entidad";
            dataGridView_vencimientos.Columns[3].Name = "Importe";
            dataGridView_vencimientos.Columns[4].Name = "ImportePte";
            dataGridView_vencimientos.Columns[5].Name = "IdRecibo";
            dataGridView_vencimientos.Columns[6].Name = "IdEntidad";

            dataGridView_vencimientos.Columns[6].Visible = false;
            dataGridView_vencimientos.Columns[0].Visible = false;
            dataGridView_vencimientos.Columns[6].Visible = false;
            dataGridView_vencimientos.Columns["Entidad"].Width = 250;
            dataGridView_vencimientos.Columns[1].DefaultCellStyle.Format = "d";

            textBox_importe_op.Text = importe_cargado;

            cargarvencimientos();
            if (form_anterior == null) {
                String sqlSacarInfo = "SELECT com_operaciones.Fecha, com_operaciones.IdEntidad, ctos_entidades.Entidad, com_operaciones.ImpOp, com_operaciones.ImpOpPte , com_operaciones.IdRetencion , com_operaciones.Retencion FROM com_operaciones INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_operaciones.IdOp) = " + id_operacion_cargado + "));";

                DataTable operacion = Persistencia.SentenciasSQL.select(sqlSacarInfo);

                DataGridViewRow row = (DataGridViewRow)dataGridView_vencimientos.Rows[0].Clone();
                //ID
                row.Cells[0].Value = null;
                //Fecha
                row.Cells[1].Value = operacion.Rows[0][0].ToString();
                //Entidad
                row.Cells[2].Value = operacion.Rows[0][2].ToString();
                //Importe
                row.Cells[3].Value = operacion.Rows[0][3].ToString(); 

                //ImportePte
                row.Cells[4].Value = operacion.Rows[0][3].ToString();
                row.Cells[6].Value = operacion.Rows[0][1].ToString();
                dataGridView_vencimientos.Rows.Add(row);

                //AÑADO OTRA FILA SI LLEVA RETENCION
                if (operacion.Rows[0][5].ToString() != "1")
                {
                    DataGridViewRow row1 = (DataGridViewRow)dataGridView_vencimientos.Rows[0].Clone();
                    //ID
                    row1.Cells[0].Value = null;
                    //Fecha
                    row1.Cells[1].Value = operacion.Rows[0][0].ToString();
                    //Entidad
                    row1.Cells[2].Value = "AEAT (Hacienda)";
                    //Importe
                    row1.Cells[3].Value = operacion.Rows[0][6].ToString();
                    //ImportePte
                    row1.Cells[4].Value = operacion.Rows[0][6].ToString();
                    //IdEntidad
                    row1.Cells[6].Value = 1216;

                    dataGridView_vencimientos.Rows.Add(row1);
                }

                double total = 0.00, imp = 0.00;
                for (int a = 0; a<dataGridView_vencimientos.Rows.Count-1;a++) {
                    if (double.TryParse(dataGridView_vencimientos.Rows[a].Cells[3].Value.ToString(), out imp))
                        total = total + imp;
                    
                }
                textBox_importe_actual.Text = total.ToString();
                button_guardar.Select();
            }
        }
        public void cargarvencimientos() {
            decimal importeActual = Convert.ToDecimal(0.00);
            if (id_operacion_cargado != "0") {

                String sqlSelectVencimientos = "SELECT com_opdetalles.IdOpDet, com_opdetalles.Fecha, ctos_entidades.IDEntidad, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte, com_opdetalles.IdRecibo, ctos_entidades.Entidad FROM com_opdetalles INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_opdetalles.IdOp) = " + id_operacion_cargado + " ));";

                DataTable vencimientos = Persistencia.SentenciasSQL.select(sqlSelectVencimientos);
                for (int a = 0; a < vencimientos.Rows.Count; a++)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView_vencimientos.Rows[0].Clone();
                    row.Cells[0].Value = vencimientos.Rows[a][0].ToString();
                    row.Cells[1].Value = vencimientos.Rows[a][1];
                    row.Cells[6].Value = vencimientos.Rows[a][2];
                    row.Cells[3].Value = vencimientos.Rows[a][3];
                    row.Cells[4].Value = vencimientos.Rows[a][4];
                    row.Cells[5].Value = vencimientos.Rows[a][5];
                    row.Cells[2].Value = vencimientos.Rows[a][6];
                    if (vencimientos.Rows[a][5] != null)
                    {
                        if (ComprobarVencimiento(vencimientos.Rows[a][0].ToString()))
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.White;
                            row.Cells[1].ReadOnly = true;
                            row.Cells[2].ReadOnly = true;
                            row.Cells[3].ReadOnly = true;
                            row.Cells[5].ReadOnly = true;
                            button_guardar.Enabled = false;
                            dataGridView_vencimientos.Rows[a].Selected = false;
                        }else {
                            row.DefaultCellStyle.BackColor = Color.White;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                            row.Cells[1].ReadOnly = false;
                            row.Cells[2].ReadOnly = false;
                            row.Cells[3].ReadOnly = false;
                            row.Cells[5].ReadOnly = false;
                            button_guardar.Enabled = true;
                        }
                    }else {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.Cells[1].ReadOnly = true;
                        row.Cells[2].ReadOnly = true;
                        row.Cells[3].ReadOnly = true;
                        row.Cells[5].ReadOnly = true;
                        dataGridView_vencimientos.Rows[a].Selected = false;
                    }

                    dataGridView_vencimientos.Rows.Add(row);

                    importeActual = importeActual + Convert.ToDecimal(string.Format("{0:F2}", vencimientos.Rows[a][3].ToString()));
                }
                textBox_importe_actual.Text = importeActual.ToString("N2");

            }
        }
        private Boolean ComprobarVencimiento(String id_OpDet) {
            String sql = "SELECT IdDetMov FROM com_detmovs WHERE IdOpDet = " + id_OpDet;
            DataTable filas = Persistencia.SentenciasSQL.select(sql);
            if (filas.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void dataGridView_vencimientos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_vencimientos.HitTest(e.X, e.Y);
                dataGridView_vencimientos.ClearSelection();
                dataGridView_vencimientos.Rows[hti.RowIndex].Selected = true;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void entidadToolStripMenuItem_Click(object sender, EventArgs e)
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
        public void recibirEntidad(String id_entidad,String nombreEntidad) {
            dataGridView_vencimientos.ClearSelection();
           // dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[1].Value = DateTime.Now.ToShortDateString();
            dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[2].Value = nombreEntidad;
            dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[6].Value = id_entidad;
            dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[2].Selected = true;
            
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comprobarImporte())
                {
                    for (int a = 0; a < dataGridView_vencimientos.Rows.Count; a++)
                    {
                        if (filas_eliminadas.Count > 0)
                        {
                            eliminar_filas();
                        }
                        if (dataGridView_vencimientos.Rows[a].Cells[3].Value != null && dataGridView_vencimientos.Rows[a].Cells[0].Value != null && !dataGridView_vencimientos.Rows[a].IsNewRow)
                        {
                            actualizar_filas(dataGridView_vencimientos.Rows[a].Cells[0].Value.ToString(), dataGridView_vencimientos.Rows[a].Cells[6].Value.ToString(), dataGridView_vencimientos.Rows[a].Cells[1].Value.ToString(), dataGridView_vencimientos.Rows[a].Cells[3].Value.ToString());
                        }
                        else if (dataGridView_vencimientos.Rows[a].Cells[3].Value != null && dataGridView_vencimientos.Rows[a].Cells[3].Value.ToString() != "0.00" && dataGridView_vencimientos.Rows[a].Cells[0].Value == null && !dataGridView_vencimientos.Rows[a].IsNewRow)
                        {
                            insertar_filas(dataGridView_vencimientos.Rows[a].Cells[6].Value.ToString(), dataGridView_vencimientos.Rows[a].Cells[1].Value.ToString(), dataGridView_vencimientos.Rows[a].Cells[3].Value.ToString());
                        }
                    }
                    if (vengoDePantallaVer)
                    {
                        form_anterior.cargarOperacion(id_operacion_cargado);
                    }
                    else
                    {
                        FormOperacionesLiquidacion nueva = new FormOperacionesLiquidacion(id_comunidad_cargado, id_operacion_cargado, textBox_importe_actual.Text);
                        nueva.Show();
                    }
                    guardado = "si";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Revise los importes, el total es : " + textBox_importe_actual.Text + " y debe ser " + textBox_importe_op.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revisa los datos : " + ex.Message);
            }

        }
        public Boolean comprobarImporte()
        {
            //MessageBox.Show(textBox_importe_op.Text);
            //double ImporteOperacion;
            //if (textBox_importe_op.Text.Contains('.'))
            //{
            //    ImporteOperacion = Convert.ToDouble(textBox_importe_op.Text);
            //}else if (textBox_importe_op.Text.Contains(',')) {
            //    ImporteOperacion = Convert.ToDouble(textBox_importe_op.Text);
            //}else {
            //    return false;
            //}

            //double ImporteActual = Convert.ToDouble(textBox_importe_actual.Text);

            //MessageBox.Show(ImporteOperacion + "-" + ImporteActual);
            Double ImpOp = Convert.ToDouble(textBox_importe_op.Text.ToString().Replace('.', ','));
            Double ImpActual = Convert.ToDouble(textBox_importe_op.Text.ToString().Replace('.', ','));

            if (ImpOp.Equals(ImpActual)) { return true; }
            else { return false; }

        }
        private void actualizar_filas(String id_opdet, String id_entidad, String fecha, String importe)
        {
            if (importe != "0")
            {
                String fechaInicio = (Convert.ToDateTime(fecha)).ToString("yyyy-MM-dd");
                String fechaPrev = (Convert.ToDateTime(fecha)).AddDays(30).ToString("yyyy-MM-dd");


                String sqlUpdate = "UPDATE com_opdetalles SET IdEntidad=" + id_entidad + ", Fecha='" + fechaInicio + "', FechaPrev='" + fechaPrev + "', Importe=" + Logica.FuncionesGenerales.ArreglarImportes(importe) + ", ImpOpDetPte=" + Logica.FuncionesGenerales.ArreglarImportes(importe) + ", NumMov=0 WHERE IdOpDet = " + id_opdet;

                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
        }
        private void eliminar_filas()
        {
            for (int a = 0; a < filas_eliminadas.Count; a++)
            {
                String sqlDelete = "DELETE FROM com_opdetalles WHERE IdOpDet = " + filas_eliminadas[a];
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
            }
        }
        private void insertar_filas(String id_entidad, String fecha, String importe)
        {
            if (importe != "0")
            {
                String fechaInicio = (Convert.ToDateTime(fecha)).ToString("yyyy-MM-dd");
                String fechaPrev = (Convert.ToDateTime(fecha)).AddDays(30).ToString("yyyy-MM-dd");

                String sqlInsert = "INSERT INTO com_opdetalles(IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte, NumMov) VALUES(" + id_operacion_cargado + ", " + id_entidad + ", '" + fechaInicio +"', '" + fechaPrev + "', " + Logica.FuncionesGenerales.ArreglarImportes(importe) + ", " + Logica.FuncionesGenerales.ArreglarImportes(importe) + ", 0)";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }
        }

        private void dataGridView_vencimientos_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            calcularImporte(e.ColumnIndex);

            //RELLENO FECHA
            if (e.ColumnIndex == 1)
            {
                string sPattern = "^\\d{2}/\\d{2}/$";
                string sPattern2 = "^\\d{2}/\\d{2}$";
                string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

                if (!dataGridView_vencimientos.CurrentRow.IsNewRow && dataGridView_vencimientos.SelectedCells[0].Value != null && Regex.IsMatch(dataGridView_vencimientos.SelectedCells[0].Value.ToString(), sPattern))
                {
                    dataGridView_vencimientos.SelectedCells[0].Value = dataGridView_vencimientos.SelectedCells[0].Value.ToString() + DateTime.Now.Year;
                }
                else if (!dataGridView_vencimientos.CurrentRow.IsNewRow && Regex.IsMatch(dataGridView_vencimientos.SelectedCells[0].Value.ToString(), sPattern2))
                {
                    dataGridView_vencimientos.SelectedCells[0].Value = dataGridView_vencimientos.SelectedCells[0].Value.ToString() + "/" + DateTime.Now.Year;
                }
                else if (!dataGridView_vencimientos.CurrentRow.IsNewRow && Regex.IsMatch(dataGridView_vencimientos.SelectedCells[0].Value.ToString(), sPattern1)) {
                    return;
                }
                else
                {
                    MessageBox.Show("Introduce una fecha correcta");
                    dataGridView_vencimientos.Rows[e.RowIndex].Cells[0].Selected = true;
                }

            }
        }
        private void calcularImporte(int indice) {
            try
            {
                double importeActual = Convert.ToDouble(0.00);
                if (indice == 3)
                {
                    for (int a = 0; a < dataGridView_vencimientos.Rows.Count; a++)
                    {
                        if (!dataGridView_vencimientos.Rows[a].IsNewRow)
                        {
                            if (dataGridView_vencimientos.Rows[a].Cells[3].Value != null)
                            {
                                double importe = Convert.ToDouble(dataGridView_vencimientos.Rows[a].Cells[3].Value.ToString().Replace('.',','));
                                dataGridView_vencimientos.Rows[a].Cells[3].Value = importe.ToString();
                                dataGridView_vencimientos.Rows[a].Cells[4].Value = importe.ToString();
                                importeActual = importeActual + importe;
                            }
                            else
                            {
                                importeActual = importeActual + 0;
                            }
                        }
                    }
                    textBox_importe_actual.Text = importeActual.ToString();
                }
            } catch {
                return;
            }
        }

        private void comuneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comuneros nueva = new Comuneros(this, this.Name, id_comunidad_cargado);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void recibirComunero(String id_entidad)
        {
            String nombre = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IdEntidad = " + id_entidad)).Rows[0][0].ToString();

            dataGridView_vencimientos.ClearSelection();
            //dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[1].Value = DateTime.Now.ToShortDateString();
            dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[2].Value = nombre;
            dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[6].Value = id_entidad;
            dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[2].Selected = true;

        }

        public void recibirProveedor(String id_entidad,String nombre)
        {
            dataGridView_vencimientos.ClearSelection();
            //dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[1].Value = DateTime.Now.ToShortDateString();
            dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[2].Value = nombre;
            dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[6].Value = id_entidad;
            dataGridView_vencimientos.Rows[dataGridView_vencimientos.CurrentRow.Index].Cells[3].Selected = true;
        }
        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOperacionesListadoProveedores nueva = new FormOperacionesListadoProveedores(this, this.Name, id_comunidad_cargado);
            nueva.Show();
        }

        private void dataGridView_vencimientos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Tab)
            {
                if (dataGridView_vencimientos.CurrentRow.IsNewRow == true && dataGridView_vencimientos.Rows.Count > 1 )
                {
                    //COMENTO POR ERROR AL TABULAR HASTA LA ULTIMA CELDA DEL DATAGRID
                    dataGridView_vencimientos.ClearSelection();
                    //button_guardar.Select();
                }
            }else if (e.KeyChar == 'e' || e.KeyChar == 'E' || e.KeyChar == (Char)Keys.Space || e.KeyChar == (Char)Keys.Enter)
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
            else if (e.KeyChar == 'p' || e.KeyChar == 'P')
            {
                FormOperacionesListadoProveedores nueva = new FormOperacionesListadoProveedores(this, this.Name, id_comunidad_cargado);
                nueva.Show();
            }
            else if (e.KeyChar == 'c' || e.KeyChar == 'C')
            {
                Comuneros nueva = new Comuneros(this, this.Name, id_comunidad_cargado);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
        }
        private void dataGridView_vencimientos_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            filas_eliminadas.Add(e.Row.Cells[0].Value.ToString());
        }

        private void dataGridView_vencimientos_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dataGridView_vencimientos.Rows.Count == 1 && dataGridView_vencimientos.Rows[0].IsNewRow)
            {
                textBox_importe_actual.Text = "0.00";
            }
            else if (dataGridView_vencimientos.Rows.Count > 0)
            {
                calcularImporte(3);
            }
        }

        private void CerrarborrarOperacionEnCurso()   {

            if (!vengoDePantallaVer)  {

                //BORRO LOS IVAS
                String sqlDeleteIVA = "DELETE FROM com_opdetiva WHERE IdOp = " + id_operacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteIVA);

                //BORRO EL REPARTO
                String sqlDeleteReparto = "DELETE FROM com_opdetbloques WHERE IdOp = " + id_operacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteReparto);

                //TENGO QUE BORRAR LO ANTERIOR
                String sqlDelete = "DELETE FROM com_operaciones WHERE IdOp = " + id_operacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);

                MessageBox.Show("Operación Borrada");
            }

        }

        private void FormOperacionesVencimientos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (guardado == "no")
                CerrarborrarOperacionEnCurso();
        }
    }
}
