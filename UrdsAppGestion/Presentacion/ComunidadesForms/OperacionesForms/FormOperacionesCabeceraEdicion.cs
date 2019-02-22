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
    public partial class FormOperacionesCabeceraEdicion : Form
    {
        String id_comunidad_cargado = "0";
        String id_operacion_cargado = "0";
        String id_entidad_nuevo;
        FromOperacionesVer form_anterior;

        public FormOperacionesCabeceraEdicion(FromOperacionesVer form_anterior, String id_comunidad_cargado, String id_operacion_cargado)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_operacion_cargado = id_operacion_cargado;
        }
        public FormOperacionesCabeceraEdicion(FromOperacionesVer form_anterior, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.id_comunidad_cargado = id_comunidad_cargado;
        }
        public FormOperacionesCabeceraEdicion(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private BindingSource NewMethod(String mas)
        {
            DataTable table;
            if (mas == "mas") {               
                 table = Persistencia.SentenciasSQL.select("SELECT IdSubcuenta, com_subcuentas.`TIT SUBCTA` FROM com_subcuentas");
            }
            else {
                table = Persistencia.SentenciasSQL.select("SELECT IdSubcuenta, com_subcuentas.`TIT SUBCTA` FROM com_subcuentas WHERE IdSubcuenta > 59999 AND IdSubcuenta < 70000;");
            }

            DataRowCollection rows = table.Rows;

            object[] cell;
            Dictionary<int, string> dic = new Dictionary<int, string>();
            BindingSource binding = new BindingSource();

            foreach (DataRow item in rows)
            {
                cell = item.ItemArray;

                dic.Add(Convert.ToInt32(cell[0]), cell[0].ToString() + " - " + cell[1].ToString());

                cell = null;
            }

            binding.DataSource = dic;
            return binding;
        }
        private void FormOperacionesCabeceraEdicion_Load(object sender, EventArgs e)
        {
            comboBox_cuenta_gastos.DataSource = NewMethod("no");

            comboBox_cuenta_gastos.ValueMember = "Key";
            comboBox_cuenta_gastos.DisplayMember = "Value";

            comboBox_cuenta_gastos.AutoCompleteCustomSource = LoadAutoComplete("no");

            comboBox_cuenta_gastos.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox_cuenta_gastos.AutoCompleteSource = AutoCompleteSource.CustomSource;


            comboBox_porcentage_retencion.DataSource = Persistencia.SentenciasSQL.select("SELECT aux_retencion.IdRetencion, aux_retencion.`%Retencion` FROM aux_retencion;");
            comboBox_porcentage_retencion.ValueMember = "IdRetencion";
            comboBox_porcentage_retencion.DisplayMember = "%Retencion";

            comboBox_tipo_reparto.DataSource = Persistencia.SentenciasSQL.select("SELECT IDTipoReparto, TipoReparto FROM com_tiporepartos");
            comboBox_tipo_reparto.ValueMember = "IDTipoReparto";
            comboBox_tipo_reparto.DisplayMember = "TipoReparto";
            textBox_entidad.Select();

            textBox_base_retencion.Text = "0";
            textBox_retencion.Text = "0";

            maskedTextBox_fecha.Text = (Convert.ToDateTime(DateTime.Now)).ToString("dd-MM-yyyy");

            if (id_operacion_cargado != "0") {
                String sqlSelect = "SELECT IdOp, IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdRetencion, BaseRet, Retencion, Notas, IdEstado, IdCuota, IdDivision, IdExpte, IdOpCrea, IdMovCrea, Aux, IdDivPar, ImpOp, ImpOpPte, NumMov, IdURD, FAct FROM com_operaciones WHERE IdOp = " + id_operacion_cargado;
                DataTable fila = Persistencia.SentenciasSQL.select(sqlSelect);
                textBox_entidad.Text = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IDEntidad = " + fila.Rows[0]["IdEntidad"].ToString())).Rows[0][0].ToString();
                this.id_entidad_nuevo = fila.Rows[0]["IdEntidad"].ToString();
                textBox_importe.Text = fila.Rows[0]["ImpOp"].ToString();

                if (Convert.ToInt32(fila.Rows[0]["IdSubCuenta"].ToString()) > 69999 || Convert.ToInt32(fila.Rows[0]["IdSubCuenta"].ToString()) < 60000) {
                        comboBox_cuenta_gastos.DataSource = NewMethod("mas");
                        comboBox_cuenta_gastos.ValueMember = "Key";
                        comboBox_cuenta_gastos.DisplayMember = "Value";
                        comboBox_cuenta_gastos.SelectedValue = fila.Rows[0]["IdSubCuenta"];
                        comboBox_cuenta_gastos.Enabled = false;
                }else {
                    comboBox_cuenta_gastos.SelectedValue = fila.Rows[0]["IdSubCuenta"];
                }

                comboBox_porcentage_retencion.SelectedValue = fila.Rows[0]["IdRetencion"].ToString();
                maskedTextBox_fecha.Text = fila.Rows[0]["Fecha"].ToString();
                textBox_descripcion.Text = fila.Rows[0]["Descripcion"].ToString();
                textBox_documento.Text = fila.Rows[0]["Documento"].ToString();
                textBox_base_retencion.Text = fila.Rows[0]["BaseRet"].ToString();
                textBox_retencion.Text = fila.Rows[0]["Retencion"].ToString();
                textBox_notas.Text = fila.Rows[0]["Notas"].ToString();

                comboBox_tipo_reparto.SelectedValue = fila.Rows[0]["IdTipoReparto"].ToString();
            }
        }

        private void textBox_entidad_DoubleClick(object sender, EventArgs e)
        {
            Entidades nueva = new Entidades(this, this.Name);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void recibirEntidad(String id_entidad)
        {
            id_entidad_nuevo = id_entidad;
            String nombre = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IdEntidad = " + id_entidad)).Rows[0][0].ToString();
            textBox_entidad.Text = nombre;
        }

        private void button_prov_Click(object sender, EventArgs e)
        {
            FormOperacionesListadoProveedores nueva = new FormOperacionesListadoProveedores(this,this.Name,id_comunidad_cargado);
            nueva.Show();
        }

        private void button_com_Click(object sender, EventArgs e)
        {
            Comuneros nueva = new Comuneros(this,this.Name,id_comunidad_cargado);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void recibirComunero(String id_comunero) {
            id_entidad_nuevo = id_comunero;
            String nombre = (Persistencia.SentenciasSQL.select("SELECT Entidad FROM ctos_entidades WHERE IdEntidad = " + id_comunero)).Rows[0][0].ToString();
            textBox_entidad.Text = nombre;
        }
        public void recibirProveedor(String id_entidad,String Nombre) {
            id_entidad_nuevo = id_entidad;
            textBox_entidad.Text = Nombre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cabecera de edicion aqui
            //id_comunidad_cargado + "," + id_entidad_nuevo + "," + comboBox_cuenta_gastos.SelectedValue.ToString() + "," + comboBox_tipo_reparto.SelectedValue.ToString() + ",'" + fechaInicio + "','" + textBox_documento.Text + "','" + textBox_descripcion.Text + "'," + comboBox_porcentage

            if (maskedTextBox_fecha.Text == "  /  /" )
            {
                MessageBox.Show("La fecha no puede estar vacía");
                maskedTextBox_fecha.Text = (Convert.ToDateTime(DateTime.Now)).ToString("dd-MM-yyyy");
                return;
            }
            if(id_entidad_nuevo == null)
            {
                MessageBox.Show("La identidad no puede estar vacía");
                return;
            }
            if (textBox_documento.Text == "")
            {
                MessageBox.Show("El Documento no puede estar vacío");
                return;
            }
            if (textBox_importe.Text == "")
            {
                MessageBox.Show("El Importe no puede estar vacío");
                return;
            }
            String fechaInicio = (Convert.ToDateTime(maskedTextBox_fecha.Text)).ToString("yyyy-MM-dd");
            String fecha_actualizacion = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd hh:mm:ss");

            if (id_operacion_cargado != "0") {
                if (textBox_expediente.Text != "")
                {
                    String sqlUpdate = "UPDATE com_operaciones SET IdEntidad=" + id_entidad_nuevo + ",IdSubCuenta=" + comboBox_cuenta_gastos.SelectedValue.ToString() + ", IdTipoReparto = " + comboBox_tipo_reparto.SelectedValue.ToString() + ",Fecha='" + fechaInicio + "',Documento='" + textBox_documento.Text + "',Descripcion='" + textBox_descripcion.Text + "',IdRetencion=" + comboBox_porcentage_retencion.SelectedValue.ToString() + ",BaseRet=" + textBox_base_retencion.Text.Replace(',', '.') + ",IdExpte= " + textBox_expediente.Text + " , Retencion=" + textBox_retencion.Text.Replace(',', '.') + ",Notas='" + textBox_notas.Text + "',ImpOp=" + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ",ImpOpPte = " + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ", IdURD = " + Presentacion.Login.getId() + ",FAct = '" + fecha_actualizacion + "'  WHERE IdOp = " + id_operacion_cargado;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }else {
                    String sqlUpdate = "UPDATE com_operaciones SET IdEntidad=" + id_entidad_nuevo + ",IdSubCuenta=" + comboBox_cuenta_gastos.SelectedValue.ToString() + ", IdTipoReparto = " + comboBox_tipo_reparto.SelectedValue.ToString() + ",Fecha='" + fechaInicio + "',Documento='" + textBox_documento.Text + "',Descripcion='" + textBox_descripcion.Text + "',IdRetencion=" + comboBox_porcentage_retencion.SelectedValue.ToString() + ",BaseRet=" + textBox_base_retencion.Text.Replace(',', '.') + ",Retencion=" + textBox_retencion.Text.Replace(',', '.') + ",Notas='" + textBox_notas.Text + "',ImpOp=" + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ",ImpOpPte = " + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ", IdURD = " + Presentacion.Login.getId() + ",FAct = '" + fecha_actualizacion + "'  WHERE IdOp = " + id_operacion_cargado;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                form_anterior.cargarOperacion(id_operacion_cargado);
                this.Close();
            }else {
                int idop;
                if (textBox_expediente.Text != "")
                {
                    String sqlInsert = "INSERT INTO com_operaciones(IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdRetencion, BaseRet, Retencion, Notas, IdEstado, IdExpte, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + id_comunidad_cargado + "," + id_entidad_nuevo + "," + comboBox_cuenta_gastos.SelectedValue.ToString() + "," + comboBox_tipo_reparto.SelectedValue.ToString() + ",'" + fechaInicio + "','" + textBox_documento.Text + "','" + textBox_descripcion.Text + "'," + comboBox_porcentage_retencion.SelectedValue.ToString() + "," + textBox_base_retencion.Text + "," + textBox_retencion.Text + ",'" + textBox_notas.Text + "','1'," + textBox_expediente.Text + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ",0,'No'," + Presentacion.Login.getId() + ",'" + fecha_actualizacion + "')";

                    idop = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert);
                }else {
                    String sqlInsert = "INSERT INTO com_operaciones(IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdRetencion, BaseRet, Retencion, Notas, IdEstado, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + id_comunidad_cargado + "," + id_entidad_nuevo + "," + comboBox_cuenta_gastos.SelectedValue.ToString() + "," + comboBox_tipo_reparto.SelectedValue.ToString() + ",'" + fechaInicio + "','" + textBox_documento.Text + "','" + textBox_descripcion.Text + "'," + comboBox_porcentage_retencion.SelectedValue.ToString() + "," + textBox_base_retencion.Text + "," + textBox_retencion.Text + ",'" + textBox_notas.Text + "','1'," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ",0,'No'," + Presentacion.Login.getId() + ",'" + fecha_actualizacion + "')";

                    idop = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert);
                }
                if (Convert.ToDouble(textBox_retencion.Text) > 0.00)
                    tieneRetencion(idop.ToString());

                FormOperacionesAddIVA nueva = new FormOperacionesAddIVA(id_comunidad_cargado, idop.ToString(), textBox_importe.Text.Replace('.',','));
                nueva.Show();
                this.Close();
            }
        }

        private void maskedTextBox_fecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'd' || e.KeyChar == 'D') {
                maskedTextBox_fecha.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void textBox_entidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter || e.KeyChar == (Char)Keys.Space) {
                Entidades nueva = new Entidades(this, this.Name);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar_nombre.Select();
                nueva.textBox_buscar_nombre.Location = new Point(nueva.textBox_buscar_nombre.Location.X + 230, nueva.textBox_buscar_nombre.Location.Y + 60);
                nueva.label2.Location = new Point(label2.Location.X + 870, nueva.label2.Location.Y + 60);
                nueva.label3.Visible = false;
                nueva.label4.Visible = false;
                nueva.label5.Visible = false;
                nueva.textBox_correo_buscar.Visible = false;
                nueva.textBox_categoria.Visible = false;
                nueva.textBox_telefono_buscar.Visible = false;
                nueva.dataGridView1.TabIndex = 2;
                nueva.textBox_buscar_nombre.TabIndex = 1;
                nueva.Show();
            }
        }

        private void textBox_importe_TextChanged(object sender, EventArgs e)
        {
            //textBox_importe.Text = Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text);
        }

        private void comboBox_porcentage_retencion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            double baseRetencion;
            int porcetaje;
            if (double.TryParse(textBox_base_retencion.Text.ToString().Replace('.',','),out baseRetencion) && int.TryParse(comboBox_porcentage_retencion.Text, out porcetaje)) {
                double total = baseRetencion * porcetaje / 100;
                textBox_retencion.Text = total.ToString().Replace(',', '.');
            }
        }

        private void comboBox_porcentage_retencion_TextChanged(object sender, EventArgs e)
        {
            double baseRetencion;
            int porcetaje;
            if (double.TryParse(textBox_base_retencion.Text.ToString().Replace('.', ','), out baseRetencion) && int.TryParse(comboBox_porcentage_retencion.Text, out porcetaje))
            {
                double total = baseRetencion * porcetaje / 100;
                textBox_retencion.Text = total.ToString().Replace(',','.');
            }
        }

        public static AutoCompleteStringCollection LoadAutoComplete(String mas)
        {
            DataTable table;

            if (mas == "mas")
                table = Persistencia.SentenciasSQL.select("SELECT IdSubcuenta, com_subcuentas.`TIT SUBCTA` FROM com_subcuentas");
            else
                table = Persistencia.SentenciasSQL.select("SELECT IdSubcuenta, com_subcuentas.`TIT SUBCTA` FROM com_subcuentas WHERE IdSubcuenta > 59999 AND IdSubcuenta < 70000;");

            DataTable dt = table;

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                stringCol.Add(Convert.ToString(row["IdSubcuenta"]) + " - " + Convert.ToString(row["TIT SUBCTA"]));
            }

            return stringCol;
        }

        private void maskedTextBox_fecha_Leave(object sender, EventArgs e)
        {
            string sPattern = "^\\d{2}/\\d{2}/$";
            string sPattern1 = "^\\d{2}/\\d{2}/\\d{4}$";

            if (Regex.IsMatch(maskedTextBox_fecha.Text, sPattern))
            {
                maskedTextBox_fecha.Text = maskedTextBox_fecha.Text + DateTime.Now.Year;
            }
            else if (Regex.IsMatch(maskedTextBox_fecha.Text, sPattern1))
            {
                textBox_documento.SelectAll();
            }
            else
            {
                //maskedTextBox_fecha.Focus();
                //maskedTextBox_fecha.Select();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tieneRetencion(String idOpNueva) {

            //COMPRUEBO QUE TIENE NIF ESA OERACIÓN
            String sqlNIF = "SELECT ctos_entidades.CIF FROM ctos_entidades WHERE ctos_entidades.IDEntidad =" + id_entidad_nuevo;
            DataTable nif = Persistencia.SentenciasSQL.select(sqlNIF);
            if (nif.Rows.Count > 0) {
                if (nif.Rows[0][0].ToString() == "")
                    MessageBox.Show("ESA ENTIDAD NO TIENE NIF Y LE HAS PUESTO RETENCIÓN. DEBES PONERLE EL NIF");
                EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad(Convert.ToInt32(id_entidad_nuevo));
                nueva.Show();
            }

            //BUSCO EL PERIODO QUE LE PERTENECE DE IVA Y SI ESTA CERRADO LE PONGO EL SIGUIENTE
            String sqlFechas = "SELECT com_ivaImpuestos.FIni, com_ivaImpuestos.FFin, com_ivaImpuestos.IdIvaImpuestos, com_ivaImpuestos.Cerrada, com_ivaImpuestos.Orden FROM com_ivaImpuestos WHERE IdComunidad = " + id_comunidad_cargado;
            String fecha;
            DataTable periodos = Persistencia.SentenciasSQL.select(sqlFechas);

            for (int i=0;i<periodos.Rows.Count; i++) {
                fecha = maskedTextBox_fecha.Text;

                String fechaInicio = (Convert.ToDateTime(periodos.Rows[i][0] + "-" + DateTime.Now.Year.ToString())).ToString();
                String fechaFin = (Convert.ToDateTime(periodos.Rows[i][1] + "-" + DateTime.Now.Year.ToString())).ToString();

                if (Convert.ToDateTime(fechaInicio) <= Convert.ToDateTime(maskedTextBox_fecha.Text) && Convert.ToDateTime(fechaFin) >= Convert.ToDateTime(maskedTextBox_fecha.Text)) {

                    if (periodos.Rows[i][3].ToString() != "True")
                    {
                        //MessageBox.Show(fecha + " | " + fechaInicio + " | " + fechaFin);
                        String sqlUpdateOperacion = "UPDATE com_operaciones SET IdPeridoIVA=" + periodos.Rows[i][2] + " WHERE IdOp = " + idOpNueva;
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateOperacion);
                    }else {
                        int actual = Convert.ToInt32(periodos.Rows[i][4].ToString());
                        if (actual == 4) actual = 1;
                        else actual++;

                        String sqlSelect = "SELECT IdIvaImpuestos FROM com_ivaImpuestos WHERE IdComunidad = " + id_comunidad_cargado + " AND Orden = " + actual;
                        DataTable periodoNuevo = Persistencia.SentenciasSQL.select(sqlSelect);
                        if (periodoNuevo.Rows.Count > 0) {
                            String sqlUpdateOperacion = "UPDATE com_operaciones SET IdPeridoIVA=" + periodoNuevo.Rows[0][0] + " WHERE IdOp = " + idOpNueva;
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateOperacion);
                        }
                    }
                }
            }
        }
    }
}
