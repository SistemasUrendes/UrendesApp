using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    public partial class Divisiones : Form
    {
        int id_comunidad = 0;
        DataTable divisiones;
        String nombre_columna;
        List<String> sin_represe = new List<String>();
        String donde = "";
        Form form_anterior;
        Boolean cargado = false;
        String idTarea;
        String idBloque;

        public Divisiones(int id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
        }
        public Divisiones(int id_comunidad,String donde,Form form_anterior)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.donde = donde;
            this.form_anterior = form_anterior;
        }
        public Divisiones(int id_comunidad, String donde,String idBloque, Form form_anterior)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.donde = donde;
            this.form_anterior = form_anterior;
            this.idBloque = idBloque;
        }

        public Divisiones (Form form_anterior,String donde,String idTarea)
        {
            InitializeComponent();
            this.idTarea = idTarea;
            this.form_anterior = form_anterior;
            this.donde = donde;
        }

        private void FormDivisiones_Load(object sender, EventArgs e)
        {
            if (!this.IsMdiChild) this.ControlBox = true;
            if (idTarea != null)
            {
                button_enviar.Visible = true;
                dataGridView_divisiones.MultiSelect = true;
                cargarDivisionesTarea();
            }
            else if (idBloque != null)
            {
                button_enviar.Visible = true;
                dataGridView_divisiones.MultiSelect = false;
                cargarDivisionesBloque();
            }
            else
            {
                if (donde != "")
                {
                    button_enviar.Visible = true;
                    dataGridView_divisiones.MultiSelect = true;
                }

                cargarDivisiones();

                if (divisiones.Rows.Count > 0)
                {
                    cargarDetallesDivisiones();
                }
                else
                    MessageBox.Show("No hay divisiones");
            }
        }
        public void cargarDivisiones () {
            cargado = false;
            String sql = "SELECT com_divisiones.IdDivision, com_divisiones.IdComunidad, com_divisiones.Division, com_divisiones.Finca, com_divisiones.Orden, com_divisiones.IdTipoDiv, com_tipodivs.TipoDivision, com_divisiones.Cuota, com_divisiones.Excluido, com_divisiones.Notas, IF((SELECT ctos_entidades.Entidad FROM(com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE com_asociacion.IdDivision = com_divisiones.IdDivision AND com_asociacion.Ppal = -1) <> '',(SELECT ctos_entidades.Entidad FROM (com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE com_asociacion.IdDivision = com_divisiones.IdDivision AND com_asociacion.Ppal = -1),'' ) as Representante FROM com_divisiones INNER JOIN com_tipodivs ON com_divisiones.IdTipoDiv = com_tipodivs.IdTipoDiv GROUP BY com_divisiones.IdDivision, com_divisiones.IdComunidad, com_divisiones.Division, com_divisiones.Finca, com_divisiones.Orden, com_divisiones.IdTipoDiv, com_tipodivs.TipoDivision, com_divisiones.Cuota, com_divisiones.Excluido, com_divisiones.Notas, com_divisiones.Division, com_divisiones.IdComunidad HAVING(((com_divisiones.IdComunidad) = " + id_comunidad + ")) ORDER BY com_divisiones.Orden, com_divisiones.Division;";


            divisiones = Persistencia.SentenciasSQL.select(sql);

            if (divisiones.Rows.Count > 0)  {
                dataGridView_divisiones.DataSource = divisiones;
                label4.Text = "Total: " + divisiones.Rows.Count;
                ajustarDatagrid();
                cargado = true;
                //comprobarRepresentante();

            }
            else {
                dataGridView_divisiones.DataSource = null;
            }
        }

        public void cargarDivisionesBloque()
        {
            cargado = false;
            String sql = "SELECT com_divisiones.IdDivision, com_divisiones.IdComunidad, com_divisiones.Division, com_divisiones.Finca, com_divisiones.Orden, com_divisiones.IdTipoDiv, com_tipodivs.TipoDivision, com_divisiones.Cuota, com_divisiones.Excluido, com_divisiones.Notas, IF((SELECT ctos_entidades.Entidad FROM(com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE com_asociacion.IdDivision = com_divisiones.IdDivision AND com_asociacion.Ppal = -1) <> '',(SELECT ctos_entidades.Entidad FROM (com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE com_asociacion.IdDivision = com_divisiones.IdDivision AND com_asociacion.Ppal = -1),'' ) as Representante FROM(com_divisiones INNER JOIN com_tipodivs ON com_divisiones.IdTipoDiv = com_tipodivs.IdTipoDiv) INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision GROUP BY com_divisiones.IdDivision, com_divisiones.IdComunidad, com_divisiones.Division, com_divisiones.Finca, com_divisiones.Orden, com_divisiones.IdTipoDiv, com_tipodivs.TipoDivision, com_divisiones.Cuota, com_divisiones.Excluido, com_divisiones.Notas, com_divisiones.Division, com_divisiones.IdComunidad, com_subcuotas.IdBloque HAVING(((com_divisiones.IdComunidad) = " + id_comunidad + ") AND((com_subcuotas.IdBloque) = " + idBloque + ")) ORDER BY com_divisiones.Orden, com_divisiones.Division";

            divisiones = Persistencia.SentenciasSQL.select(sql);

            if (divisiones.Rows.Count > 0)
            {
                dataGridView_divisiones.DataSource = divisiones;
                label4.Text = "Total: " + divisiones.Rows.Count;
                ajustarDatagrid();
                cargado = true;
            }
            else
            {
                dataGridView_divisiones.DataSource = null;
            }
        }


        public void cargarDetallesDivisiones() {
            if (divisiones.Rows.Count > 0)
            {
                if (dataGridView_divisiones.SelectedRows.Count == 0) {
                    dataGridView_divisiones.Rows[0].Selected = true;
                }

                String sql = "SELECT com_asociacion.IdDivision, com_asociacion.IdAsociacion, ctos_entidades.Entidad, com_tipoasociacion.TipoAsociación, com_asociacion.Participacion, com_asociacion.FechaAlta, com_asociacion.FechaBaja, com_asociacion.Ppal, ctos_entidades.IDEntidad, com_asociacion.IdComunero FROM((com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_tipoasociacion ON com_asociacion.IdTipoAsoc = com_tipoasociacion.IdTipoAsoc WHERE(((com_asociacion.IdDivision)= " + dataGridView_divisiones.SelectedRows[0].Cells[0].Value + "));";

                dataGridView_detalles_divisiones.DataSource = Persistencia.SentenciasSQL.select(sql);
                dataGridView_detalles_divisiones.Columns[0].Visible = false;
                dataGridView_detalles_divisiones.Columns["Entidad"].Width = 200;
                dataGridView_detalles_divisiones.Columns[1].Visible = false;
                dataGridView_detalles_divisiones.Columns["IdComunero"].Visible = false;
                dataGridView_detalles_divisiones.Columns[3].HeaderText = "TipoAsociacion";
                dataGridView_detalles_divisiones.Columns["IDEntidad"].Visible = false;
                dataGridView_detalles_divisiones.Columns["Participacion"].DefaultCellStyle.Format = "p";

                textBox_Division.Text = dataGridView_divisiones.SelectedRows[0].Cells[2].Value.ToString();

            }
        }
        public void cambiarTextBox(int indice) {
            textBox_Division.Text = dataGridView_divisiones.Rows[indice].Cells[2].Value.ToString();
        }

        public void ajustarDatagrid() {
            if (divisiones.Rows.Count > 0) {
                dataGridView_divisiones.Columns[0].Visible = false;
                dataGridView_divisiones.Columns[1].Visible = false;
                dataGridView_divisiones.Columns[3].Visible = false;
                dataGridView_divisiones.Columns[5].Visible = false;
                dataGridView_divisiones.Columns[6].Width = 200;
                dataGridView_divisiones.Columns[10].Width = 235;
                dataGridView_divisiones.Columns[7].Visible = false;
                dataGridView_divisiones.Columns[9].Visible = false;
                dataGridView_divisiones.Columns["Cuota"].DefaultCellStyle.Format = "p";
            }
        }
        private void dataGridView_divisiones_Click(object sender, EventArgs e) {
            cargardetalles();
        }
        private void cargardetalles()
        {
            cargarDetallesDivisiones();
            //textBox_Division.Text = dataGridView_divisiones.SelectedCells[2].Value.ToString();
        }
        private void dataGridView_divisiones_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                toolStripTextBox2.Text = "";
                var hti = dataGridView_divisiones.HitTest(e.X, e.Y);
                dataGridView_divisiones.ClearSelection();
                dataGridView_divisiones.Rows[hti.RowIndex].Selected = true;
                cargarDetallesDivisiones();
                dataGridView_divisiones.Columns[hti.ColumnIndex].Selected = true;
                dataGridView_divisiones.CurrentCell = this.dataGridView_divisiones[hti.ColumnIndex, hti.RowIndex];
                nombre_columna = dataGridView_divisiones.CurrentCell.OwningColumn.Name;
                //buscarToolStripMenuItem.Text = "Buscar en " + nombre_columna;
                if ( nombre_columna != "Cuota" ) {
                  if (nombre_columna != "Excluido") {
                        contextMenuStrip2.Show(Cursor.Position);
                        //toolStripTextBox2.Focus();
                    }
                }
            }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e) {
           //MessageBox.Show(dataGridView_divisiones.CurrentCell.OwningColumn.Name.ToString());
        }

        private void reglasDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox2.TextLength == 0)
            {
                DataTable busqueda = divisiones;
                busqueda.DefaultView.RowFilter = nombre_columna + " like '%%' ";
                this.dataGridView_divisiones.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = divisiones;
                String filtro = nombre_columna + " like '%" + toolStripTextBox2.Text.ToUpper().ToString() + "%'";
                busqueda.DefaultView.RowFilter = filtro;
                this.dataGridView_divisiones.DataSource = busqueda;
            }
        }

        private void filtroAvanzadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusquedaAvanzada nueva = new BusquedaAvanzada(this);
            nueva.Show();
        }

        private void button_Añadir_Click(object sender, EventArgs e)
        {
            FormAltaDivisiones nueva = new FormAltaDivisiones(this,id_comunidad);
            nueva.Show();
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            FormAltaDivisiones nueva = new FormAltaDivisiones(this,id_comunidad, (int)dataGridView_divisiones.SelectedCells[0].Value,dataGridView_divisiones.SelectedRows[0].Index);
            nueva.Show();
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta Division ?", "Borrar Division", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_divisiones WHERE IdDivision = " + dataGridView_divisiones.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarDivisiones();
            }
        }
        private void button_editaasociacion_Click(object sender, EventArgs e)
        {
            FormAltaAsociacion nueva = new FormAltaAsociacion(this,id_comunidad,(int)dataGridView_detalles_divisiones.SelectedCells[1].Value, (int)dataGridView_divisiones.SelectedCells[0].Value,dataGridView_divisiones.CurrentCell.RowIndex);
            nueva.Show();
        }

        private void button_addasociacion_Click(object sender, EventArgs e)
        {
            FormAltaAsociacion nueva = new FormAltaAsociacion(this, (int)dataGridView_divisiones.SelectedCells[0].Value,id_comunidad, dataGridView_divisiones.CurrentCell.RowIndex);
            nueva.Show();
        }
        
        private void comboBox_Filtro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;

            if (senderComboBox.SelectedItem.ToString() == "Ver Todas")  {
                cargarDivisiones();
            }else if (senderComboBox.SelectedItem.ToString() == "Con Reglas") {
                cargarDetallesReglas();
            }
        }
        private void cargarDetallesReglas() {
            String sqlSelect = " SELECT com_divisiones.IdDivision, com_divisiones.IdComunidad, com_divisiones.Division, com_divisiones.Finca, com_divisiones.Orden, com_divisiones.IdTipoDiv, com_tipodivs.TipoDivision, com_divisiones.Cuota, com_divisiones.Excluido, com_divisiones.Notas FROM(com_divisiones INNER JOIN com_tipodivs ON com_divisiones.IdTipoDiv = com_tipodivs.IdTipoDiv) INNER JOIN com_repartos ON com_divisiones.IdDivision = com_repartos.IdDivision GROUP BY com_divisiones.IdDivision, com_divisiones.IdComunidad, com_divisiones.Division, com_divisiones.Finca, com_divisiones.Orden, com_divisiones.IdTipoDiv, com_tipodivs.TipoDivision, com_divisiones.Cuota, com_divisiones.Excluido, com_divisiones.Notas, com_divisiones.Division, com_divisiones.IdComunidad HAVING(((com_divisiones.IdComunidad) = " + id_comunidad + ")) ORDER BY com_divisiones.Orden, com_divisiones.Division;";

            divisiones = Persistencia.SentenciasSQL.select(sqlSelect);

            if (divisiones.Rows.Count > 0)
            {
                dataGridView_divisiones.DataSource = divisiones;
                label4.Text = "Total: " + divisiones.Rows.Count;
                ajustarDatagrid();
                //comprobarRepresentante();
            }
            else
            {
                dataGridView_divisiones.DataSource = null;
            }

        }
        private void comprobarRepresentante() {
            int num_sin_repre = 0;

            for (int a = 0; a < dataGridView_divisiones.Rows.Count; a++)  {

                String sql = "SELECT com_divisiones.IdDivision, com_asociacion.Ppal, com_divisiones.IdComunidad FROM com_divisiones INNER JOIN com_asociacion ON com_divisiones.IdDivision = com_asociacion.IdDivision WHERE(((com_asociacion.Ppal) = -1) AND ((com_divisiones.IdDivision) = " + dataGridView_divisiones.Rows[a].Cells[0].Value + "));";

                DataTable filas = Persistencia.SentenciasSQL.select(sql);
                if (filas.Rows.Count == 0) {
                    num_sin_repre++;
                    sin_represe.Add(dataGridView_divisiones.Rows[a].Cells[0].Value.ToString());
                }
            }
            button_num_representantes.Text = "s/Rpe: " + num_sin_repre;
            if (num_sin_repre == 0) {
                button_num_representantes.Enabled = false;
                button_num_representantes.BackColor = Color.Transparent;
                button_num_representantes.ForeColor = Color.Black;
            }
            else {
                button_num_representantes.BackColor = Color.Red;
                button_num_representantes.ForeColor = Color.Black;
                button_num_representantes.Enabled = true;
            }
        }

        private void button_num_representantes_Click(object sender, EventArgs e)
        {
            comprobarRepresentante();
            DataTable busqueda = divisiones;
            String filtro = "";

            for (int a = 0; a < sin_represe.Count; a++) {              
                if (a == 0) {
                    filtro = "IdDivision = " + sin_represe[a];
                }else {
                    filtro = filtro + " OR  IdDivision = " + sin_represe[a];
                }
            }
            busqueda.DefaultView.RowFilter = filtro;
            filtro = "";
            dataGridView_divisiones.DataSource = busqueda;
        }

        private void button_borrarasociacion_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta Asociacion ?", "Borrar Asociacion", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_asociacion WHERE IdAsociacion = " + dataGridView_detalles_divisiones.SelectedCells[1].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarDivisiones();
                cargarDetallesDivisiones();
            }
        }
        private void button_enviar_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(donde)).SingleOrDefault<Form>();    
            if (existe != null) {
                if (donde.Contains("FormBloquesDetalles"))
                {
                    List<String> listaEnviar = new List<String>();
                    DataGridViewSelectedRowCollection Seleccionados = dataGridView_divisiones.SelectedRows;

                    foreach (DataGridViewRow item in Seleccionados) {
                        listaEnviar.Add(item.Cells[0].Value.ToString());
                    }

                    BloquesForms.FormBloquesDetalles nueva = (BloquesForms.FormBloquesDetalles)existe;
                    nueva.recibirDivision(listaEnviar);
                    nueva.BringToFront();
                    this.Close();
                }
                if (donde.Contains("FormCuotasPlantillaManualDetalle"))
                {
                    List<String> listaEnviar = new List<String>();
                    DataGridViewSelectedRowCollection Seleccionados = dataGridView_divisiones.SelectedRows;

                    foreach (DataGridViewRow item in Seleccionados)
                    {
                        listaEnviar.Add(item.Cells[0].Value.ToString());
                    }

                    CuotasForms.FormCuotasPlantillaManualDetalle nueva = (CuotasForms.FormCuotasPlantillaManualDetalle)existe;
                    nueva.recibirDivision(listaEnviar);
                    nueva.BringToFront();
                    this.Close();
                }

                if (donde.Contains("FormOperacionesEditReparto")) {
                    OperacionesForms.FormOperacionesEditReparto nueva = (OperacionesForms.FormOperacionesEditReparto) existe;
                    nueva.recogerBloque(dataGridView_divisiones.SelectedCells[0].Value.ToString(),dataGridView_divisiones.SelectedCells[2].Value.ToString());
                    this.Close();
                }
                if (donde.Contains("FormDivisionesCuotas")) {
                    FormDivisionesCuotas nueva = (FormDivisionesCuotas) existe;
                    nueva.recogerBloque(dataGridView_divisiones.SelectedCells[0].Value.ToString());
                    this.Close();
                }
                if (donde.Contains("FormVerTarea"))
                {
                    Tareas.FormVerTarea nueva = (Tareas.FormVerTarea)existe;
                    nueva.recibirDivisiones(tablaSeleccionados());
                    this.Close();
                }
                if (donde.Contains("FormTareasPrincipal"))
                {
                    Tareas.FormTareasPrincipal nueva = (Tareas.FormTareasPrincipal)existe;
                    nueva.recibirDivision(dataGridView_divisiones.SelectedRows[0].Cells[0].Value.ToString(), dataGridView_divisiones.SelectedRows[0].Cells[2].Value.ToString());
                    this.Close();
                }
                if (donde.Contains("FormGestionesPrincipal"))
                {
                    Tareas.FormGestionesPrincipal nueva = (Tareas.FormGestionesPrincipal)existe;
                    nueva.recibirDivision(dataGridView_divisiones.SelectedRows[0].Cells[0].Value.ToString(), dataGridView_divisiones.SelectedRows[0].Cells[2].Value.ToString());
                    this.Close();
                }
            }
        }
        private void cuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDivisionesCuotas nueva = new FormDivisionesCuotas(id_comunidad.ToString(), dataGridView_divisiones.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        public void buscar_text() {
            DataTable busqueda;
            if (textBox_buscar.TextLength < 1)  {
                busqueda = divisiones;
                busqueda.DefaultView.RowFilter = "Division like '%%'";
                this.dataGridView_divisiones.DataSource = busqueda;
            }
            else
            {
                busqueda = divisiones;
                busqueda.DefaultView.RowFilter = "Division like '%" + textBox_buscar.Text + "%' OR Representante like '%" + textBox_buscar.Text + "%'";
                this.dataGridView_divisiones.DataSource = busqueda;
            }

            if (dataGridView_divisiones.Rows.Count > 0)
                cargardetalles();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buscar_text();
        }

        private void dataGridView_detalles_divisiones_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_detalles_divisiones.HitTest(e.X, e.Y);
                dataGridView_detalles_divisiones.ClearSelection();
                dataGridView_detalles_divisiones.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void verEntidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad((int)dataGridView_detalles_divisiones.SelectedCells[8].Value);
            nueva.Show();
        }

        private void dataGridView_divisiones_SelectionChanged(object sender, EventArgs e)
        {
             cargardetalles();
        }

        private void dataGridView_divisiones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Up || e.KeyChar == (Char)Keys.Down) {
                cargardetalles();
            }
        }

        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReglasPago nueva = new FormReglasPago(dataGridView_divisiones.SelectedRows[0].Cells[0].Value.ToString(), dataGridView_divisiones.SelectedRows[0].Cells[2].Value.ToString(),id_comunidad.ToString());
            nueva.Show();
        }

        private void certificadoDeDeudasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormCertificadoDeudasDivision nueva = new FormCertificadoDeudasDivision(id_comunidad.ToString(),dataGridView_detalles_divisiones.Rows[0].Cells[0].Value.ToString(),dataGridView_divisiones.SelectedRows[0].Cells[2].Value.ToString(), dataGridView_divisiones.SelectedRows[0].Cells[6].Value.ToString(),nombreEntidadPpal(dataGridView_detalles_divisiones.Rows[0].Cells[0].Value.ToString()));
            nueva.Show();
        }

        private void dataGridView_divisiones_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            label4.Text = "Total :" + dataGridView_divisiones.Rows.Count;
        }

        public double sumaParticipacion() {
            double total = 0.00;
            for (int a = 0; a < dataGridView_detalles_divisiones.Rows.Count; a++) {
                total += Convert.ToDouble(dataGridView_detalles_divisiones.Rows[a].Cells[4].Value.ToString());
            }
            return total;
        }

        public String nombreEntidadPpal(String idDivision)
        {
            String sql = "SELECT ctos_entidades.Entidad FROM ctos_entidades INNER JOIN (com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) ON ctos_entidades.IDEntidad = com_comuneros.IdEntidad WHERE(((com_asociacion.IdDivision) = " + idDivision + ") AND((com_asociacion.Ppal) = -1));";
            DataTable id = Persistencia.SentenciasSQL.select(sql);
            return id.Rows[0][0].ToString();
        }

        private void comboBox_informes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_informes.SelectedIndex == 0)
            {
                DivisionesForms.Informes.FormRangoFechasCuotasEmitidas nueva = new DivisionesForms.Informes.FormRangoFechasCuotasEmitidas(dataGridView_divisiones.SelectedRows[0].Cells[0].Value.ToString(),id_comunidad.ToString(),dataGridView_divisiones.SelectedRows[0].Cells[2].Value.ToString());
                nueva.Show();

            }
            else if (comboBox_informes.SelectedIndex == 1) {
                FormBloquesJunta nueva = new FormBloquesJunta(id_comunidad.ToString());
                nueva.Show();
            }
            else if (comboBox_informes.SelectedIndex == 2)
            {
                DivisionesForms.Informes.FormVerInformeConfirmaciónDatos nueva = new DivisionesForms.Informes.FormVerInformeConfirmaciónDatos(id_comunidad.ToString(),dataGridView_detalles_divisiones.Rows[0].Cells[9].Value.ToString(),dataGridView_divisiones.SelectedRows[0].Cells[0].Value.ToString(),dataGridView_divisiones.SelectedRows[0].Cells[2].Value.ToString(), dataGridView_divisiones.SelectedRows[0].Cells[6].Value.ToString(), dataGridView_detalles_divisiones.SelectedRows[0].Cells[8].Value.ToString());
                nueva.Show();
            }
        }

        private void dataGridView_divisiones_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cargado && divisiones.Rows.Count > 0)
                cargardetalles();
        }

        private void Divisiones_Shown(object sender, EventArgs e)
        {
            cargado = true;
        }

        private void cargarDivisionesTarea()
        {
            cargado =  false;
            String sqlSelect = "SELECT com_divisiones.IdDivision, com_divisiones.IdComunidad, com_divisiones.Division, com_divisiones.Finca, com_divisiones.Orden, com_divisiones.IdTipoDiv, com_tipodivs.TipoDivision, com_divisiones.Cuota, com_divisiones.Excluido, com_divisiones.Notas, IF((SELECT ctos_entidades.Entidad FROM(com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE com_asociacion.IdDivision = com_divisiones.IdDivision AND com_asociacion.Ppal = -1) <> '',(SELECT ctos_entidades.Entidad FROM (com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE com_asociacion.IdDivision = com_divisiones.IdDivision AND com_asociacion.Ppal = -1),'' ) as Representante FROM((com_divisiones INNER JOIN com_tipodivs ON com_divisiones.IdTipoDiv = com_tipodivs.IdTipoDiv) INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision) INNER JOIN (exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea) ON com_subcuotas.IdBloque = exp_area.IdBloque GROUP BY com_divisiones.IdDivision, com_divisiones.IdComunidad, com_divisiones.Division, com_divisiones.Finca, com_divisiones.Orden, com_divisiones.IdTipoDiv, com_tipodivs.TipoDivision, com_divisiones.Cuota, com_divisiones.Excluido, com_divisiones.Notas, com_divisiones.Division, com_divisiones.IdComunidad, exp_area.IdAreaPrevio, exp_areaTarea.IdTarea HAVING(((exp_area.IdAreaPrevio) = 0) AND((exp_areaTarea.IdTarea) = " + idTarea + ")) ORDER BY com_divisiones.Orden, com_divisiones.Division";

            divisiones = Persistencia.SentenciasSQL.select(sqlSelect);

            if (divisiones.Rows.Count > 0)
            {
                dataGridView_divisiones.DataSource = divisiones;
                label4.Text = "Total: " + divisiones.Rows.Count;
                ajustarDatagrid();
                cargado = true;
            }
            else
            {
                dataGridView_divisiones.DataSource = null;
            }

        }
        

        private DataTable tablaSeleccionados()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdDivision");
            for (int i = 0; i < dataGridView_divisiones.SelectedRows.Count; i++)
            {
                dt.Rows.Add();
                dt.Rows[i][0] = dataGridView_divisiones.SelectedRows[i].Cells[0].Value;
            }
            return dt;
        }

        private void verAsociacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComunerosForms.FormComuneroAsociaciones nueva = new ComunerosForms.FormComuneroAsociaciones(dataGridView_detalles_divisiones.SelectedRows[0].Cells[2].Value.ToString(), dataGridView_detalles_divisiones.SelectedRows[0].Cells[9].Value.ToString());
            nueva.Show();
        }
    }
}

