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
    public partial class FromOperacionesVer : Form
    {
        String id_comunidad_cargado = "0";
        String id_operacion_cargado = "0";
        String tipo_reparto;
        String textobuscar;
        int deDondeVengo;

        public FromOperacionesVer(String id_operacion_cargado, int deDondeVengo)
        {
            InitializeComponent();
            this.id_operacion_cargado = id_operacion_cargado;
            this.deDondeVengo = deDondeVengo;
        }       

        public FromOperacionesVer(String id_operacion_cargado, int deDondeVengo, String id_comunidad_cargado,String textobuscar)
        {
            InitializeComponent();
            this.id_operacion_cargado = id_operacion_cargado;
            this.deDondeVengo = deDondeVengo;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.textobuscar = textobuscar;
            
        }
        public FromOperacionesVer(String id_operacion_cargado, int deDondeVengo, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_operacion_cargado = id_operacion_cargado;
            this.deDondeVengo = deDondeVengo;
            this.id_comunidad_cargado = id_comunidad_cargado;
            
        }
        public FromOperacionesVer(String id_comunidad_cargado, String id_operacion_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_operacion_cargado = id_operacion_cargado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id_operacion_cargado != "0") {
                FormOperacionesCabeceraEdicion nueva = new FormOperacionesCabeceraEdicion(this, id_comunidad_cargado,id_operacion_cargado);
                nueva.Show();
            }
            else {
                FormOperacionesCabeceraEdicion nueva = new FormOperacionesCabeceraEdicion(this,id_comunidad_cargado);
                nueva.Show();
            }
        }

        private void FromOperacionesVer_Load(object sender, EventArgs e)
        {
            if (deDondeVengo == 1) {
                button_cancelar.Visible = true;
                button_guardar.Visible = true;
                label_advertencia.Visible = true;
            }

            comboBox_cuenta_gastos.DataSource = Persistencia.SentenciasSQL.select("SELECT IdSubcuenta FROM com_subcuentas;");
            comboBox_cuenta_gastos.ValueMember = "IdSubcuenta";
            comboBox_cuenta_gastos.DisplayMember = "IdSubcuenta";

            comboBox_porcentage_retencion.DataSource = Persistencia.SentenciasSQL.select("SELECT aux_retencion.IdRetencion, aux_retencion.`%Retencion` FROM aux_retencion;");
            comboBox_porcentage_retencion.ValueMember = "IdRetencion";
            comboBox_porcentage_retencion.DisplayMember = "%Retencion";

            if (id_operacion_cargado != "0") {
                cargarOperacion(id_operacion_cargado);
            }
            if (label_advertencia.Visible) {
                button_guardar.Select();
            }
            if (Login.getRol() == "Admin")
            {
                button_revisarPte.Enabled = true;
            }
        }
        public void cargarOperacion(String id_operacion) {

            /////////////////////CARGA DE CABECERA ///////////////////////////////////////
            String sqlSelect = "SELECT IdOp, IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdRetencion, BaseRet, Retencion, Notas, IdEstado, IdCuota, IdDivision, IdExpte, IdOpCrea, IdMovCrea, Aux, IdDivPar, ImpOp, ImpOpPte, NumMov, IdURD, FAct FROM com_operaciones WHERE IdOp = " + id_operacion ;
            id_operacion_cargado = id_operacion;
            DataTable fila = Persistencia.SentenciasSQL.select(sqlSelect);
            if (fila.Rows.Count > 0)
            {
                label12.Visible = true;
                textBox2.Visible = true;
                textBox2.Text = fila.Rows[0]["IdOp"].ToString();
                textBox_entidad.Text = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IDEntidad = " + fila.Rows[0]["IdEntidad"].ToString())).Rows[0][0].ToString();
                textBox_importe.Text = fila.Rows[0]["ImpOp"].ToString();
                textBox_imppte.Text = fila.Rows[0]["ImpOpPte"].ToString();
                comboBox_cuenta_gastos.SelectedValue = fila.Rows[0]["IdSubCuenta"].ToString();
                textBox_descripcion_cuenta.Text = (Persistencia.SentenciasSQL.select("SELECT `TIT SUBCTA` FROM com_subcuentas WHERE IdSubcuenta = " + fila.Rows[0]["IdSubCuenta"].ToString())).Rows[0][0].ToString();

                comboBox_porcentage_retencion.SelectedValue = fila.Rows[0]["IdRetencion"].ToString();
                maskedTextBox_fecha.Text = fila.Rows[0]["Fecha"].ToString();
                textBox_descripcion.Text = fila.Rows[0]["Descripcion"].ToString();
                textBox_documento.Text = fila.Rows[0]["Documento"].ToString();
                textBox_base_retencion.Text = fila.Rows[0]["BaseRet"].ToString();
                textBox1.Text = fila.Rows[0]["Retencion"].ToString();
                textBox_notas.Text = fila.Rows[0]["Notas"].ToString();
                textBox_ultima_modificacion.Text = fila.Rows[0]["FAct"].ToString();
                textBox_expediente.Text = fila.Rows[0]["IdExpte"].ToString();
                
                //CARGO LOS EXPEDIENTES
                cargarExpedientes();

                try
                {
                    textBox_usuario.Text = (Persistencia.SentenciasSQL.select("SELECT Usuario FROM ctos_urendes WHERE IdURD = " + fila.Rows[0]["IdURD"].ToString())).Rows[0][0].ToString();
                }
                catch
                {
                    textBox_usuario.Text = "1";
                }

                tipo_reparto = fila.Rows[0]["IdTipoReparto"].ToString();

                String sqlSelectReparto = "SELECT TipoReparto FROM com_tiporepartos WHERE IDTipoReparto = " + fila.Rows[0]["IdTipoReparto"].ToString();
                textBox_reparto.Text = (Persistencia.SentenciasSQL.select(sqlSelectReparto)).Rows[0][0].ToString();

                //////////////////////////CARGA DE IVA///////////////////////////////////

                String sqlSelectIVA = "SELECT com_opdetiva.IdDetOpIVA, com_opdetiva.Base, aux_iva.`%IVA`, com_opdetiva.IVA FROM aux_iva INNER JOIN com_opdetiva ON aux_iva.IdIVA = com_opdetiva.IdIVA WHERE(((com_opdetiva.IdOp) = " + id_operacion_cargado + "));";

                DataTable ivas = Persistencia.SentenciasSQL.select(sqlSelectIVA);
                dataGridView_iva.DataSource = ivas;

                dataGridView_iva.Columns[0].Visible = false;

                dataGridView_iva.Columns["Base"].DefaultCellStyle.Format = "c";
                dataGridView_iva.Columns["IVA"].DefaultCellStyle.Format = "c";

                ///////////////////CARGA BLOQUES/////////////////////////////////

                if (fila.Rows[0]["IdTipoReparto"].ToString() == "1")
                {
                    String sqlSelectBloque = "SELECT com_opdetbloques.IdOpBloque, com_bloques.Descripcion, com_opdetbloques.Porcentaje, com_opdetbloques.Importe FROM com_opdetbloques INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque WHERE(((com_opdetbloques.IdOp) = " + id_operacion_cargado + "));";
                    dataGridView_reparto.DataSource = Persistencia.SentenciasSQL.select(sqlSelectBloque);
                    dataGridView_reparto.Columns["Porcentaje"].DefaultCellStyle.Format = "p2";
                    dataGridView_reparto.Columns["Porcentaje"].Width = 60;
                    dataGridView_reparto.Columns["Descripcion"].Width = 250;

                    dataGridView_reparto.Columns["Importe"].DefaultCellStyle.Format = "c";
                    dataGridView_reparto.Columns[0].Visible = false;
                }
                else if (fila.Rows[0]["IdTipoReparto"].ToString() == "2")
                {
                    String sqlSelectDivision = "SELECT com_opdetbloques.IdOpBloque, com_divisiones.Division, com_opdetbloques.Porcentaje, com_opdetbloques.Importe FROM com_opdetbloques INNER JOIN com_divisiones ON com_opdetbloques.IdDivision = com_divisiones.IdDivision WHERE(((com_opdetbloques.IdOp) = " + id_operacion_cargado + "));";
                    dataGridView_reparto.DataSource = Persistencia.SentenciasSQL.select(sqlSelectDivision);
                    dataGridView_reparto.Columns["Porcentaje"].DefaultCellStyle.Format = "p2";
                    dataGridView_reparto.Columns["Porcentaje"].Width = 60;
                    dataGridView_reparto.Columns["Division"].Width = 250;
                    dataGridView_reparto.Columns["Importe"].DefaultCellStyle.Format = "c";
                    dataGridView_reparto.Columns[0].Visible = false;
                    if (Convert.ToDouble(fila.Rows[0]["IdSubCuenta"].ToString()) == 70001) 
                        button_70001.Visible = true;

                }
                else if (fila.Rows[0]["IdTipoReparto"].ToString() == "3")
                {
                    String sqlSelectEntidad = "SELECT com_opdetbloques.IdOpBloque, ctos_entidades.Entidad, com_opdetbloques.Porcentaje, com_opdetbloques.Importe FROM com_opdetbloques INNER JOIN ctos_entidades ON com_opdetbloques.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_opdetbloques.IdOp) = " + id_operacion_cargado + ")); ";
                    dataGridView_reparto.DataSource = Persistencia.SentenciasSQL.select(sqlSelectEntidad);
                    dataGridView_reparto.Columns["Porcentaje"].DefaultCellStyle.Format = "p2";
                    dataGridView_reparto.Columns["Porcentaje"].Width = 60;
                    dataGridView_reparto.Columns["Entidad"].Width = 250;
                    dataGridView_reparto.Columns["Importe"].DefaultCellStyle.Format = "c";
                    dataGridView_reparto.Columns[0].Visible = false;
                    if (Convert.ToDouble(fila.Rows[0]["IdSubCuenta"].ToString()) == 70001)
                        button_70001.Visible = true;
                }

                ////////////////CARGO DE VENCIMIENTOS////////////////////////////////

                String sqlSelectVencimientos = "SELECT com_opdetalles.IdOpDet, ctos_entidades.Entidad, com_opdetalles.Fecha, com_opdetalles.Importe, com_opdetalles.ImpOpDetPte, com_opdetalles.IdRecibo FROM com_opdetalles INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_opdetalles.IdOp) = " + id_operacion_cargado + " ));";

                dataGridView_vencimientos.DataSource = Persistencia.SentenciasSQL.select(sqlSelectVencimientos);
                dataGridView_vencimientos.Columns["IdOpDet"].Visible = false;
                dataGridView_vencimientos.Columns["Entidad"].Width = 240;
                dataGridView_vencimientos.Columns["Importe"].DefaultCellStyle.Format = "c";
                dataGridView_vencimientos.Columns["Importe"].Width = 80;
                dataGridView_vencimientos.Columns["ImpOpDetPte"].Width = 80;
                dataGridView_vencimientos.Columns["IdRecibo"].Width = 70;
                dataGridView_vencimientos.Columns["Fecha"].Width = 67;
                dataGridView_vencimientos.Columns["ImpOpDetPte"].DefaultCellStyle.Format = "c";

                /////////////CARGO LIQUIDACION/////////////////////////////////////

                String sqlSelectLiquidacion = "SELECT com_opdetliquidacion.IdDetOpLiq, com_liquidaciones.Liquidacion, com_opdetliquidacion.Porcentaje, com_opdetliquidacion.Importe FROM com_opdetliquidacion INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion WHERE(((com_opdetliquidacion.IdOp) = " + id_operacion_cargado + "));";

                dataGridView_liquidacion.DataSource = Persistencia.SentenciasSQL.select(sqlSelectLiquidacion);
                dataGridView_liquidacion.Columns["Porcentaje"].DefaultCellStyle.Format = "p2";
                dataGridView_liquidacion.Columns["IdDetOpLiq"].Visible = false;
                dataGridView_liquidacion.Columns["Importe"].DefaultCellStyle.Format = "c";
                dataGridView_liquidacion.Columns["Porcentaje"].Width = 65;
            }else {
                MessageBox.Show("No existe esa Operación");
                this.Close();
            }
        }

        private void button_add_iva_Click(object sender, EventArgs e)
        {
            FormOperacionesAddIVA nueva = new FormOperacionesAddIVA(this, id_comunidad_cargado, id_operacion_cargado, textBox_importe.Text,true);
            nueva.Show();
        }

        private void button_add_reparto_Click(object sender, EventArgs e)
        {
            FormOperacionesEditReparto nueva = new FormOperacionesEditReparto(this, id_comunidad_cargado, id_operacion_cargado,tipo_reparto,textBox_importe.Text,true);
            nueva.Show();
        }

        private void button_add_vencimiento_Click(object sender, EventArgs e)
        {
            FormOperacionesVencimientos nueva = new FormOperacionesVencimientos(this,id_comunidad_cargado,id_operacion_cargado,textBox_importe.Text, true);
            nueva.Show();
        }

        private void button_add_liquidacion_Click(object sender, EventArgs e)
        {
            FormOperacionesLiquidacion nueva = new FormOperacionesLiquidacion(this,id_comunidad_cargado,id_operacion_cargado, textBox_importe.Text, true);
            nueva.Show();
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            String sqlGuardarOperacion = "UPDATE com_operaciones SET Guardada='Si' WHERE IdOp = " + id_operacion_cargado;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlGuardarOperacion);

            button_guardar.BackColor = SystemColors.Control;
            button_guardar.ForeColor = Color.Black;
            label_advertencia.Visible = false;
            button_cancelar.Text = "Cerrar";
            button_guardar.Visible = false;
            button_cancelar.Location = new Point(button_cancelar.Location.X + 85, button_cancelar.Location.Y);

            try
            {
                String nombre_comunidad = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.NombreCorto FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE (((com_comunidades.IdComunidad) = " + id_comunidad_cargado + "));")).Rows[0][0].ToString();

                Operaciones_proveedores existe = Application.OpenForms.OfType<Operaciones_proveedores>().Where(pre => pre.Text.Contains("Proveedores")).SingleOrDefault<Operaciones_proveedores>();
                existe.cargarFiltro();
            }
            catch {
                return;
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void FromOperacionesVer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Borrar Todo
            if (label_advertencia.Visible == true)
            {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿La operación no esta guardada. ¿Desea salir sin guardar ?", "Salir de la Operación", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {

                    String sqlDeleteLiquidacion = "DELETE FROM com_opdetliquidacion WHERE IdOp = " + id_operacion_cargado;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteLiquidacion);

                    //BORRANDO CABECERA
                    String sqlDeleteOpCabecera = "DELETE FROM com_operaciones WHERE IdOp = " + id_operacion_cargado;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteOpCabecera);

                    String sqlDeleteIVA = "DELETE FROM com_opdetiva WHERE IdOp = " + id_operacion_cargado;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteIVA);

                    String sqlDeleteBloques = "DELETE FROM com_opdetbloques WHERE IdOp = " + id_operacion_cargado;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteBloques);

                    String sqlDeleteVencimiento = "DELETE FROM com_opdetalles WHERE IdOp = " + id_operacion_cargado;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteVencimiento);

                }
                else
                {
                    e.Cancel = true;
                }
            }
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

        private void verMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDetallesOperacion nueva = new FormDetallesOperacion(dataGridView_vencimientos.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            FormOperacionesCabeceraEdicion nueva = new FormOperacionesCabeceraEdicion(id_comunidad_cargado);
            nueva.Show();
        }

        private void button_nuevaOperacion_Click(object sender, EventArgs e)
        {
            this.Close();
            
            FormOperacionesAjustarFavorita existe = Application.OpenForms.OfType<FormOperacionesAjustarFavorita>().Where(pre => pre.Name.Contains("FormOperacionesAjustarFavorita")).SingleOrDefault<FormOperacionesAjustarFavorita>();

            if (existe != null)  {
                existe.Close();
                FormOperacionesEleccionFavorita nueva = new FormOperacionesEleccionFavorita(id_comunidad_cargado,textobuscar);
                nueva.Show();
            }
            else  {
                FormOperacionesEleccionFavorita nueva = new FormOperacionesEleccionFavorita(id_comunidad_cargado, textobuscar);
                nueva.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!label_advertencia.Visible)
            {
                try
                {
                    if (comprobarValidaFavorita(textBox2.Text))
                    {
                        String fecha = (Convert.ToDateTime(maskedTextBox_fecha.Text)).ToString("yyyy-MM-dd");
                        String sqlFavorita = "INSERT INTO com_opfavoritas (IdOp, NomFavo, FechaFavo, DocFavo, ImpFavo, IdComunidad) VALUES (" + textBox2.Text + ",'" + textBox_descripcion.Text + "','" + fecha + "','" + textBox_documento.Text + "'," + textBox_importe.Text.Replace(',', '.') + "," + id_comunidad_cargado + ")";

                        Persistencia.SentenciasSQL.InsertarGenerico(sqlFavorita);
                        MessageBox.Show("Guardada como favorita");
                    }
                }
                catch
                {
                    MessageBox.Show("Fallo al guardar como favorita");
                    return;
                }
            }else {
                MessageBox.Show("Antes debes guardar la operación.");
            }
        }
        private Boolean comprobarValidaFavorita(String id_op_marcada_favorita)
        {
            String sqlLiquidacion = "SELECT IdDetOpLiq FROM com_opdetliquidacion WHERE IdOp = " + id_op_marcada_favorita;
            DataTable Liquifav = Persistencia.SentenciasSQL.select(sqlLiquidacion);
            if (Liquifav.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Existe más de una fila en Liquidacion, no se puede guardar como favorita");
                return false;
            }
        }

        private void button_70001_Click(object sender, EventArgs e)
        {
            String OPCrea = "SELECT IdOpCrea FROM com_operaciones WHERE IdOp = " + id_operacion_cargado;
            DataTable OPCreaDT = Persistencia.SentenciasSQL.select(OPCrea);
            if (OPCreaDT.Rows.Count > 0 && OPCreaDT.Rows[0][0].ToString() != "")
            {
                FromOperacionesVer nueva = new FromOperacionesVer(OPCreaDT.Rows[0][0].ToString(), 3);
                nueva.Show();
            }
        }

        private void button_revisarPte_Click(object sender, EventArgs e)
        {
            calcularPteVto();
            MessageBox.Show("Recalculado");
            cargarOperacion(id_operacion_cargado);
        }
        private void calcularPteVto()  {
            
            double totalDetOp = 0.00;
            
            for (int a = 0; a < dataGridView_vencimientos.Rows.Count; a++)
            {
                String sqlPteCorrecto = "SELECT com_opdetalles.IdOpDet, com_movimientos.ImpMovEnt, com_movimientos.ImpMovSal, com_dettiposmov.IdTipoMov FROM(((com_movimientos INNER JOIN com_detmovs ON com_movimientos.IdMov = com_detmovs.IdMov) INNER JOIN com_opdetalles ON com_detmovs.IdOpDet = com_opdetalles.IdOpDet) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_dettiposmov ON com_movimientos.IdDetTipoMov = com_dettiposmov.IdDetTipoMov WHERE(((com_opdetalles.IdOpDet) = " + dataGridView_vencimientos.Rows[a].Cells[0].Value.ToString() + "));";

                DataTable Pte = Persistencia.SentenciasSQL.select(sqlPteCorrecto);

                if (Pte.Rows.Count > 0) {
                    for (int b = 0; b < Pte.Rows.Count;b++ ) {
                        if (Pte.Rows[b][3].ToString() == "1")
                            totalDetOp = totalDetOp + Convert.ToDouble(Pte.Rows[b][1].ToString()) + Convert.ToDouble(Pte.Rows[b][2].ToString());
                        else
                            totalDetOp = totalDetOp + Convert.ToDouble(Pte.Rows[b][1].ToString()) - Convert.ToDouble(Pte.Rows[b][2].ToString());
                    }
                    //ACTUALIZO LA LINEA DEL VENCIMIENTO
                    String insertarPte = "UPDATE com_opdetalles SET ImpOpDetPte=com_opdetalles.Importe - " + totalDetOp.ToString().Replace(",",".") + " WHERE IdOpDet = " + dataGridView_vencimientos.Rows[a].Cells[0].Value.ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(insertarPte);
                }
            }
            //ACTUALIZO EL PTE DE OP
            String sqlUpdate = "UPDATE com_operaciones SET ImpOpPte=com_operaciones.ImpOp - " + totalDetOp.ToString().Replace(",",".") + " WHERE IdOp = " + id_operacion_cargado;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
        }

        private void button_añadirExpedientes_Click(object sender, EventArgs e)
        {
            Tareas.FormTareasPrincipal nueva = new Tareas.FormTareasPrincipal(this,id_comunidad_cargado);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void recibirTarea(String id_tarea)
        {
            //GUARDO EN LA TABLA OPERACIONES_TAREAS LA NUEVA TAREA.
            String sqlInsert = "INSERT INTO exp_operacionTarea (IdTarea, IdOperacion) VALUES (" + id_tarea + "," + id_operacion_cargado + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            cargarExpedientes();
        }
        public void cargarExpedientes() {

            String sqlExpedientes = "SELECT exp_tareas.IdTarea, exp_tareas.Descripción FROM exp_operacionTarea INNER JOIN exp_tareas ON exp_operacionTarea.IdTarea = exp_tareas.IdTarea WHERE (((exp_operacionTarea.IdOperacion) = " + id_operacion_cargado + "));";

            DataTable expedientes = Persistencia.SentenciasSQL.select(sqlExpedientes);
            if (expedientes.Rows.Count > 0)
            {
                dataGridView_expedientes.DataSource = expedientes;
            }
        }
    }
}
