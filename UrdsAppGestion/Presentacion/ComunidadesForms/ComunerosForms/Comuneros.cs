using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    public partial class Comuneros : Form
    {
        String id_comunidad;
        DataTable comuneros;
        Form form_anterior = null;
        Boolean cargado = false;
        String nombre_form_anterior = "0";

        public Comuneros(String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
        }

        public Comuneros(Form form_anterior, String nombre_form_anterior, String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.form_anterior = form_anterior;
            this.nombre_form_anterior = nombre_form_anterior;
        }

        private void Comuneros_Load(object sender, EventArgs e)
        {
            cargarComuneros();
            if (nombre_form_anterior != "0") {
                button4.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                comboBox_operaciones.Visible = false;
                comboBox2.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
            }
            textBox_buscar.Select();
        }
        public void cargarComuneros() {
            String sql = "SELECT com_comuneros.IdComunero,com_comuneros.IdEntidad, ctos_entidades.Entidad,com_comuneros.Activo, com_comuneros.Notas, com_comuneros.IdFormaPago, com_comuneros.IdDireccion, com_comuneros.IdCC, com_comuneros.IdEmail, com_comuneros.IdTipoCopia,com_divisiones.Division, com_comuneros.Asociaciones, com_comuneros.EnvioPostal, com_comuneros.EnvioEmail, com_comuneros.IVA, ctos_entidades.EntidadSinAcentos FROM(com_comuneros INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN com_divisiones ON com_comuneros.IdDivPpal = com_divisiones.IdDivision WHERE(((com_comuneros.IdComunidad) = " + id_comunidad + ")) ORDER BY ctos_entidades.Entidad;";

            comuneros = Persistencia.SentenciasSQL.select(sql);
            dataGridView_comuneros.DataSource = comuneros;

            ajustarDatagrid();
            cargarDetalles();
        }
        public void ajustarDatagrid() {
            dataGridView_comuneros.Columns["IdFormaPago"].Visible = false;
            dataGridView_comuneros.Columns["IdDireccion"].Visible = false;
            dataGridView_comuneros.Columns["IdCC"].Visible = false;
            dataGridView_comuneros.Columns["IdEmail"].Visible = false;
            dataGridView_comuneros.Columns["IdTipoCopia"].Visible = false;
            dataGridView_comuneros.Columns["EnvioPostal"].Visible = false;
            dataGridView_comuneros.Columns["EnvioEmail"].Visible = false;
            dataGridView_comuneros.Columns["IVA"].Visible = false;
            dataGridView_comuneros.Columns["Notas"].Visible = false;
            dataGridView_comuneros.Columns["EntidadSinAcentos"].Visible = false;

            dataGridView_comuneros.Columns["IdComunero"].Width = 50;
            dataGridView_comuneros.Columns["IdEntidad"].Width = 50;
            dataGridView_comuneros.Columns["Entidad"].Width = 350;
            dataGridView_comuneros.Columns["Activo"].Width = 50;

            dataGridView_comuneros.Columns["Division"].Width = 100;
            dataGridView_comuneros.Columns["Asociaciones"].Width = 170;
        }
        public void cargarDetalles () {
            if (dataGridView_comuneros.SelectedRows.Count > 0)
            {
                textBox_Comunero.Text = dataGridView_comuneros.SelectedCells[2].Value.ToString();
                textBox_Divppal.Text = dataGridView_comuneros.SelectedCells[10].Value.ToString();
                textBox_Notas.Text = dataGridView_comuneros.SelectedCells[4].Value.ToString();

                if (dataGridView_comuneros.SelectedCells[3].Value.ToString() == "True")
                    checkBox_Activo.Checked = true;

                //MessageBox.Show(dataGridView_comuneros.SelectedCells[12].Value.ToString());

                if (dataGridView_comuneros.SelectedCells[13].Value.ToString() == "True")
                    checkBox_EMail.Checked = true;
                else
                    checkBox_EMail.Checked = false;

                if (dataGridView_comuneros.SelectedCells[12].Value.ToString() == "True")
                    checkBox_papel.Checked = true;
                else
                    checkBox_papel.Checked = false;

                if (dataGridView_comuneros.SelectedCells[14].Value.ToString() == "-1")
                    checkBox_IVA.Checked = true;
                else
                    checkBox_IVA.Checked = false;

                numerosCuenta();
                direccion();
                formaPago();
                email();
            }
        }

        private void dataGridView_comuneros_Click(object sender, EventArgs e)
        {
            cargarDetalles();
        }
        private void numerosCuenta() {
            if (dataGridView_comuneros.SelectedCells[7].Value.ToString() == "")
                textBox_NumCuenta.Text = "";
            else {
                    String sql = "SELECT IdCuenta, IdEntidad, Descripcion, CC, Ppal FROM ctos_detbancos WHERE IdCuenta = " + dataGridView_comuneros.SelectedCells[7].Value.ToString() + ";";
                    DataTable cuentas = Persistencia.SentenciasSQL.select(sql);
                    if (cuentas.Rows.Count > 0) {
                        textBox_NumCuenta.Text = cuentas.Rows[0][3].ToString();
                    }
            }
        }
        private void direccion() {
            if (dataGridView_comuneros.SelectedCells[6].Value.ToString() == "")
                textBox_Direccion.Text = "";
            else
            {
                String sql = "SELECT ctos_detdirecent.IdDireccion, ctos_detdirecent.IDEntidad, ctos_detdirecent.Descripcion, ctos_detdirecent.Ppal FROM ctos_detdirecent WHERE(((ctos_detdirecent.IdDireccion) =" + dataGridView_comuneros.SelectedCells[6].Value.ToString() + "));";

                DataTable direcciones = Persistencia.SentenciasSQL.select(sql);
                if (direcciones.Rows.Count > 0)
                {
                    textBox_Direccion.Text = direcciones.Rows[0][2].ToString();
                }
            }
        }
        private void formaPago() {
            if (dataGridView_comuneros.SelectedCells[5].Value.ToString() == "")
                textBox_FPago.Text = "";
            else
            {
                String sql = "SELECT aux_formapago.IdFormaPago, aux_formapago.FormaPago FROM aux_formapago WHERE aux_formapago.IdFormaPago = " + dataGridView_comuneros.SelectedCells[5].Value.ToString();
                DataTable formasPago = Persistencia.SentenciasSQL.select(sql);
                if (formasPago.Rows.Count > 0)
                {
                    textBox_FPago.Text = formasPago.Rows[0][1].ToString();
                }
            }
        }
        private void email() {
            if (dataGridView_comuneros.SelectedCells[8].Value.ToString() == "")
                textBox_EMail.Text = "";
            else
            {
                if (dataGridView_comuneros.SelectedCells[8].Value.ToString() != "")
                {
                    String sql = "SELECT ctos_detemail.IdEmail, ctos_detemail.IdEntidad, ctos_detemail.Descripcion, ctos_detemail.Email, ctos_detemail.Ppal FROM ctos_detemail WHERE(((ctos_detemail.IdEmail) = " + dataGridView_comuneros.SelectedCells[8].Value.ToString() + " ));";

                    DataTable emails = Persistencia.SentenciasSQL.select(sql);
                    if (emails.Rows.Count > 0)
                    {
                        textBox_EMail.Text = emails.Rows[0][3].ToString();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComunerosForms.FormAltaComunero nueva = new ComunerosForms.FormAltaComunero(this, id_comunidad);
            nueva.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ComunerosForms.FormAltaComunero nueva = new ComunerosForms.FormAltaComunero(this,dataGridView_comuneros.SelectedCells[0].Value.ToString(),dataGridView_comuneros.SelectedCells[1].Value.ToString(),id_comunidad,dataGridView_comuneros.SelectedRows[0].Index);
            nueva.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este comunero ?", "Borrar Comunero", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_comuneros WHERE IdComunero = " + dataGridView_comuneros.SelectedCells[0].Value;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarComuneros();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ComunerosForms.FormComuneroAsociaciones nueva = new ComunerosForms.FormComuneroAsociaciones(dataGridView_comuneros.SelectedCells[2].Value.ToString() ,dataGridView_comuneros.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void dataGridView_comuneros_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_comuneros.HitTest(e.X, e.Y);
                dataGridView_comuneros.ClearSelection();
                dataGridView_comuneros.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void reglasRecibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComunerosForms.FormComuneroReglas nueva = new ComunerosForms.FormComuneroReglas(dataGridView_comuneros.SelectedCells[2].Value.ToString(),dataGridView_comuneros.SelectedCells[0].Value.ToString());

            nueva.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ComunerosForms.FormAltaComunero nueva = new ComunerosForms.FormAltaComunero(this, id_comunidad);
            nueva.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ComunerosForms.FormAltaComunero nueva = new ComunerosForms.FormAltaComunero(this, dataGridView_comuneros.SelectedCells[0].Value.ToString(), dataGridView_comuneros.SelectedCells[1].Value.ToString(), id_comunidad,dataGridView_comuneros.SelectedRows[0].Index);
            nueva.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            enviarOtroForm();
        }
        private void enviarOtroForm() {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_form_anterior)).SingleOrDefault<Form>();
            if (existe != null)
            {
                if (nombre_form_anterior == "FormOperacionesCabeceraEdicion")
                {
                    OperacionesForms.FormOperacionesCabeceraEdicion nuevo = (OperacionesForms.FormOperacionesCabeceraEdicion)existe;
                    nuevo.recibirComunero(dataGridView_comuneros.SelectedCells[1].Value.ToString());
                }
                if (nombre_form_anterior == "FormOperacionesVencimientos")
                {
                    OperacionesForms.FormOperacionesVencimientos nuevo = (OperacionesForms.FormOperacionesVencimientos)existe;
                    nuevo.recibirComunero(dataGridView_comuneros.SelectedCells[1].Value.ToString());
                }
                if (nombre_form_anterior == "FormReasignarOperacion")
                {
                    DivisionesForms.FormReasignarPagador nuevo = (DivisionesForms.FormReasignarPagador)existe;
                    nuevo.recibirEntidad(dataGridView_comuneros.SelectedCells[1].Value.ToString(), dataGridView_comuneros.SelectedCells[2].Value.ToString());
                }

                if (nombre_form_anterior == "FormAltaAsociacion")
                {
                    DivisionesForms.FormAltaAsociacion nuevo = (DivisionesForms.FormAltaAsociacion)existe;
                    nuevo.recibirComunero(dataGridView_comuneros.SelectedCells[1].Value.ToString());
                }

                if (nombre_form_anterior == "FormAccesoOperacionesTesoreria")
                {
                    TesoreriaForms.FormAccesoOperacionesTesoreria nuevo = (TesoreriaForms.FormAccesoOperacionesTesoreria)existe;
                    nuevo.recibirEntidad(dataGridView_comuneros.SelectedCells[1].Value.ToString(), dataGridView_comuneros.SelectedCells[2].Value.ToString());
                }
                if (nombre_form_anterior == "FormIngresoFondo")
                {
                    OperacionesForms.FormIngresoFondo nuevo = (OperacionesForms.FormIngresoFondo)existe;
                    nuevo.recibirComunero(dataGridView_comuneros.SelectedCells[1].Value.ToString(), dataGridView_comuneros.SelectedCells[2].Value.ToString());
                }
                if (nombre_form_anterior == "FormCompensarAnticipos")
                {
                    OperacionesForms.FormCompensarAnticipos nuevo = (OperacionesForms.FormCompensarAnticipos)existe;
                    nuevo.recibirEntidad(dataGridView_comuneros.SelectedCells[1].Value.ToString(), dataGridView_comuneros.SelectedCells[2].Value.ToString());
                }
                if (nombre_form_anterior == "FormAnyadirReglaDetalle")
                {
                    DivisionesForms.ReglasPago.FormAnyadirReglaDetalle nuevo = (DivisionesForms.ReglasPago.FormAnyadirReglaDetalle)existe;
                    nuevo.recibirComunero(dataGridView_comuneros.SelectedCells[0].Value.ToString(), dataGridView_comuneros.SelectedCells[2].Value.ToString());
                }
                if (nombre_form_anterior == "FormCargosAlta")
                {
                    CargosForms.FormCargosAlta nuevo = (CargosForms.FormCargosAlta)existe;
                    nuevo.recibirComunero(dataGridView_comuneros.SelectedCells[0].Value.ToString(), dataGridView_comuneros.SelectedCells[2].Value.ToString(), dataGridView_comuneros.SelectedCells[1].Value.ToString());
                }
                if (nombre_form_anterior == "FormAbonarVencimiento")
                {
                    OperacionesForms.FormAbonarVencimiento nuevo = (OperacionesForms.FormAbonarVencimiento)existe;
                    nuevo.recibirComunero(dataGridView_comuneros.SelectedCells[1].Value.ToString(), dataGridView_comuneros.SelectedCells[2].Value.ToString());
                }
                if (nombre_form_anterior == "FormInsertarContacto")
                {
                    Tareas.FormInsertarContacto nuevo = (Tareas.FormInsertarContacto)existe;
                    nuevo.recibirComunero(dataGridView_comuneros.SelectedCells[0].Value.ToString(),dataGridView_comuneros.SelectedCells[2].Value.ToString(), textBox_EMail.Text);
                }
                if (nombre_form_anterior == "FormInsertarGestion")
                {
                    Tareas.FormInsertarGestion nuevo = (Tareas.FormInsertarGestion)existe;
                    nuevo.recibirComunero(dataGridView_comuneros.SelectedCells[1].Value.ToString(), dataGridView_comuneros.SelectedCells[2].Value.ToString());
                }
            }
            this.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cargado = false;
            if (textBox_buscar.TextLength < 2)
            {
                DataTable busqueda = comuneros;
                busqueda.DefaultView.RowFilter = "EntidadSinAcentos like '%%'";
                this.dataGridView_comuneros.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = comuneros;
                busqueda.DefaultView.RowFilter = "EntidadSinAcentos like '%" + textBox_buscar.Text + "%' OR Division like '%" + textBox_buscar.Text + "%' OR Entidad like '%" + textBox_buscar.Text + "%' OR Asociaciones like '%" + textBox_buscar.Text + "%'";
                this.dataGridView_comuneros.DataSource = busqueda;
            }
            cargado = true;
            if (dataGridView_comuneros.Rows.Count > 0)
            {
                dataGridView_comuneros.Rows[0].Selected = true;
                cargarDetalles();
            }
        }

        private void dataGridView_comuneros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView_comuneros.SelectedRows.Count > 0)
            {
                e.SuppressKeyPress = true;
                enviarOtroForm();
            }
        }

        private void verEntidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad(Convert.ToInt32(dataGridView_comuneros.SelectedRows[0].Cells[1].Value));
            nueva.Show();
        }

        private void dataGridView_comuneros_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cargado)
                cargarDetalles();
        }

        private void Comuneros_Shown(object sender, EventArgs e)
        {
            cargado = true;
        }
        public void recargoFiltro()
        {
            cargado = false;
            String sql = "SELECT com_comuneros.IdComunero,com_comuneros.IdEntidad, ctos_entidades.Entidad,com_comuneros.Activo, com_comuneros.Notas, com_comuneros.IdFormaPago, com_comuneros.IdDireccion, com_comuneros.IdCC, com_comuneros.IdEmail, com_comuneros.IdTipoCopia,com_divisiones.Division, com_comuneros.Asociaciones, com_comuneros.EnvioPostal, com_comuneros.EnvioEmail, com_comuneros.IVA,ctos_entidades.EntidadSinAcentos FROM(com_comuneros INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN com_divisiones ON com_comuneros.IdDivPpal = com_divisiones.IdDivision WHERE(((com_comuneros.IdComunidad) = " + id_comunidad + ")) ORDER BY ctos_entidades.Entidad;"; 

            comuneros = Persistencia.SentenciasSQL.select(sql);
            dataGridView_comuneros.DataSource = comuneros;

            ajustarDatagrid();

            if (textBox_buscar.TextLength < 2)
            {
                DataTable busqueda = comuneros;
                busqueda.DefaultView.RowFilter = "Entidad like '%%'";
                this.dataGridView_comuneros.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = comuneros;
                busqueda.DefaultView.RowFilter = "Entidad like '%" + textBox_buscar.Text + "%' OR Division like '%" + textBox_buscar.Text + "%'";
                this.dataGridView_comuneros.DataSource = busqueda;
            }
            cargado = true;
            if (dataGridView_comuneros.Rows.Count > 0)
            {
                dataGridView_comuneros.Rows[0].Selected = true;
                cargarDetalles();
            }
            cargarDetalles();
        }

        private void comboBox_operaciones_SelectionChangeCommitted(object sender, EventArgs e)
        {
           if (comboBox_operaciones.SelectedIndex == 0)  {
                ComunerosForms.Anticipos nueva = new ComunerosForms.Anticipos(id_comunidad, dataGridView_comuneros.SelectedRows[0].Cells[1].Value.ToString());
                nueva.ControlBox = true;
                nueva.Show();
            }
           else if (comboBox_operaciones.SelectedIndex == 1) {
                ComunerosForms.FormMovimientosComunero nueva = new ComunerosForms.FormMovimientosComunero(id_comunidad, dataGridView_comuneros.SelectedRows[0].Cells[1].Value.ToString(),dataGridView_comuneros.SelectedRows[0].Cells[2].Value.ToString());
                nueva.Show();
            }
           else if (comboBox_operaciones.SelectedIndex == 2) {
                OperacionesForms.FormOperacionesComuneros nueva = new OperacionesForms.FormOperacionesComuneros(id_comunidad, dataGridView_comuneros.SelectedRows[0].Cells[1].Value.ToString());
                nueva.ControlBox = true;
                nueva.Show();
            }
           else if (comboBox_operaciones.SelectedIndex == 3) {
                ComunerosForms.FormRecibos nueva = new ComunerosForms.FormRecibos(id_comunidad, dataGridView_comuneros.SelectedRows[0].Cells[1].Value.ToString());
                nueva.ControlBox = true;
                nueva.Show();
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            if (comboBox2.SelectedIndex < 3)
            {
                ComunerosForms.VistaInforme nueva = new ComunerosForms.VistaInforme(dataGridView_comuneros.SelectedRows[0].Cells[0].Value.ToString(), id_comunidad, dataGridView_comuneros.SelectedRows[0].Cells[1].Value.ToString());
                nueva.Show();
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                ComunerosForms.Informes.FormDivisionesAsociaciones nueva = new ComunerosForms.Informes.FormDivisionesAsociaciones(id_comunidad);
                nueva.Show();
            }
        }
    }
}
