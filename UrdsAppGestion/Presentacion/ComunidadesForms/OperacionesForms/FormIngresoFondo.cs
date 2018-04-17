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
    public partial class FormIngresoFondo : Form
    {
        String id_comunidad;
        String id_entidad_nueva = "";
        Operaciones_comuneros form_anterior;
        DataTable fondos;

        public FormIngresoFondo(Operaciones_comuneros form_anterior, String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
            this.form_anterior = form_anterior;
        }

        private void FormIngresoFondo_Load(object sender, EventArgs e)
        {
            cargarCombos();
            if (fondos.Rows.Count > 0)
            {
                comboBox_fondos.SelectedIndex = 0;
                comboBox_liquidación.SelectedIndex = 0;
                cargarLiquidaciones();
            }else {
                checkBox_fondo.Checked = false;
            }
        }
        private void cargarCombos() {
            String sqlSelectFondo = "SELECT IdFondo, NombreFondo FROM com_fondos WHERE IdComunidad = " + id_comunidad;
            fondos = Persistencia.SentenciasSQL.select(sqlSelectFondo);
            comboBox_fondos.DataSource = fondos;
            comboBox_fondos.DisplayMember = "NombreFondo";
            comboBox_fondos.ValueMember = "IdFondo";
        }

        private void cargarLiquidaciones () {

            String sqlSelectLiq = "SELECT com_liquidaciones.IdLiquidacion, com_liquidaciones.Liquidacion FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad + ") AND((com_ejercicios.C) <> -1) AND((com_liquidaciones.Cerrada) <> -1));";

            DataTable liquidaciones = Persistencia.SentenciasSQL.select(sqlSelectLiq);
            comboBox_liquidación.DataSource = liquidaciones;
            comboBox_liquidación.DisplayMember = "Liquidacion";
            comboBox_liquidación.ValueMember = "IdLiquidacion";
        }
        private void comboBox_fondos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarLiquidaciones();
        }

        private void textBox_comunero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Space || e.KeyChar == (Char)Keys.Enter) {
                Comuneros nueva = new Comuneros(this, this.Name, id_comunidad);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar.Select();
                nueva.Show();
            }else if (e.KeyChar == (Char)Keys.E || e.KeyChar == 'e') {
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
        public void recibirComunero(String id_entidad, String nombre_entidad) {
            textBox_comunero.Text = nombre_entidad;
            id_entidad_nueva = id_entidad;
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            creoOperacion();
        }
        
        private void creoOperacion () {
            
            String fecha = (Convert.ToDateTime(maskedTextBox_fecha.Text)).ToString("yyyy-MM-dd");
            String fecha_actualizacion = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd hh:mm:ss");
            
            //CREO OPERACIÓN
            String sqlInsertOp = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Descripcion, IdEstado, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + id_comunidad + "," + id_entidad_nueva + "," + comboBox_subcuenta.SelectedItem.ToString().Split('-')[0] + ",1,'" + fecha + "','" + textBox_descripcion.Text + "',1," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ",0,'No'," + Presentacion.Login.getId() + ",'" + fecha_actualizacion + "')";

            int op = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOp);

            String sqlInsertIva = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + op + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ",1,0)";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertIva);

            String sqlSelectBloqueFondo = (Persistencia.SentenciasSQL.select("SELECT IdBloque FROM com_fondos WHERE IdFondo = " + comboBox_fondos.SelectedValue.ToString())).Rows[0][0].ToString();

            String sqlInsertReparto = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES (" + op + "," + sqlSelectBloqueFondo + ",1," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ")";

            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertReparto);

            String sqlInsertVencimiento = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte, NumMov, IdEstado) VALUES (" + op + "," + id_entidad_nueva + ",'" + fecha + "','" + fecha + "'," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + "," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ",0,1)";

            int opdet = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertVencimiento);

            String sqlInsertDetLiq = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + op + "," + comboBox_liquidación.SelectedValue.ToString() + ",1," + Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text) + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertDetLiq);

            int Idrecibo = Logica.FuncionesTesoreria.CreoReciboID(id_comunidad, id_entidad_nueva, fecha, Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text), Logica.FuncionesGenerales.ArreglarImportes(textBox_importe.Text), textBox_descripcion.Text);

            Logica.FuncionesTesoreria.ActualizoIdReciboVencimiento(Idrecibo.ToString(), opdet.ToString());

            form_anterior.cargardatagrid();
            this.Close();
            MessageBox.Show("Se ha generado el Recibo y debes informarlo");
            
            

            FromOperacionesVer nueva = new FromOperacionesVer(op.ToString(), 1, id_comunidad);
            nueva.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                button_guardar.Select();
            }
            else
            {
                maskedTextBox_fecha.Focus();
                maskedTextBox_fecha.Select();
            }
        }
    }
}
