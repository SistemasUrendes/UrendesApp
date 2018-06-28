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
    public partial class FormBloquesJunta : Form
    {
        String idComunidad;
        DataTable datos;

        public FormBloquesJunta(String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
        }

        private void FormBloquesJunta_Load(object sender, EventArgs e)
        {
            listBox_bloques.DataSource = Persistencia.SentenciasSQL.select("SELECT com_bloques.IdBloque, com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdTipoBloque) = 1) AND((com_bloques.IdComunidad) = " + idComunidad + "));");
            listBox_bloques.DisplayMember = "Descripcion";
            listBox_bloques.ValueMember = "IdBloque";

            DataTable bloqueGeneral = Persistencia.SentenciasSQL.select("SELECT com_bloques.IdBloque FROM com_bloques WHERE(((com_bloques.IdTipoBloque) = 1) AND((com_bloques.IdComunidad) = " + idComunidad + ") AND((com_bloques.GG) = -1));");     
            if (bloqueGeneral.Rows.Count > 0) {
                listBox_bloques.SelectedValue = bloqueGeneral.Rows[0][0].ToString();
            }

            //FORMA DE PAGO
            DataTable formasPago = Persistencia.SentenciasSQL.select("SELECT aux_formapago.IdFormaPago, aux_formapago.FormaPago FROM aux_formapago;");

            DataRow filatodas = formasPago.NewRow();
            filatodas["FormaPago"] = "Todos";
            filatodas["IdFormaPago"] = 0;
            formasPago.Rows.InsertAt(filatodas, 0);

            comboBox_formaPago.DataSource = formasPago;
            comboBox_formaPago.DisplayMember = "FormaPago";
            comboBox_formaPago.ValueMember = "IdFormaPago";
            comboBox_formaPago.SelectedValue = 0;

            //ASOCIACIÓN
            DataTable asociacion = Persistencia.SentenciasSQL.select("SELECT IdTipoAsoc, `TipoAsociación` FROM com_tipoasociacion");

            DataRow filatodas2 = asociacion.NewRow();
            filatodas2["TipoAsociación"] = "Todos";
            filatodas2["IdTipoAsoc"] = 0;
            asociacion.Rows.InsertAt(filatodas2, 0);

            comboBox_asociacion.DataSource = asociacion;
            comboBox_asociacion.DisplayMember = "TipoAsociación";
            comboBox_asociacion.ValueMember = "IdTipoAsoc";
            comboBox_asociacion.SelectedValue = 0;

            comboBox_asociacion.SelectedValue = 1;
            comboBox_asociacion.Enabled = false;

            cargarDatagrid();
        }
        private void cargarDatagrid() {

            // String sqlSelectTodo = "SELECT com_comuneros.IdComunero, ctos_entidades.IDEntidad, ctos_entidades.Entidad, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_comuneros.EnvioEmail, com_comuneros.EnvioPostal, aux_formapago.FormaPago, aux_formapago.IdFormaPago, ( IF((SELECT ctos_dettelf.Telefono FROM ctos_dettelf WHERE ctos_dettelf.IdEntidad = ctos_entidades.IDEntidad AND ctos_dettelf.Ppal = -1) !='' ,(SELECT ctos_dettelf.Telefono FROM ctos_dettelf WHERE ctos_dettelf.IdEntidad = ctos_entidades.IDEntidad AND ctos_dettelf.Ppal = -1),'')) AS Telefono, ctos_detemail.Email FROM(((((((com_comuneros INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_tipocopia ON com_comuneros.IdTipoCopia = com_tipocopia.IdTipoCopia) LEFT JOIN ctos_detdirecent ON com_comuneros.IdDireccion = ctos_detdirecent.IdDireccion) LEFT JOIN ctos_detemail ON com_comuneros.IdEmail = ctos_detemail.IdEmail) INNER JOIN aux_formapago ON com_comuneros.IdFormaPago = aux_formapago.IdFormaPago) INNER JOIN com_asociacion ON com_comuneros.IdComunero = com_asociacion.IdComunero) INNER JOIN com_divisiones ON com_asociacion.IdDivision = com_divisiones.IdDivision) INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision GROUP BY com_comuneros.IdComunero, ctos_entidades.IDEntidad, ctos_entidades.Entidad, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_comuneros.EnvioEmail, com_comuneros.EnvioPostal, aux_formapago.FormaPago, ctos_detemail.Email, com_comuneros.IdComunidad, com_subcuotas.IdBloque, com_comuneros.IdTipoCopia, com_comuneros.EnvioPostal, com_comuneros.EnvioEmail, com_comuneros.Activo, com_asociacion.Ppal HAVING(((com_comuneros.IdComunidad) = " + idComunidad + ") AND((com_subcuotas.IdBloque) = " + listBox_bloques.SelectedValue + ") AND((com_comuneros.Activo) = -1) AND ((com_asociacion.Ppal) = -1));";

            String sqlSelectTodo = "SELECT com_comuneros.IdComunero, ctos_entidades.IDEntidad, ctos_entidades.Entidad, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_comuneros.EnvioEmail, com_comuneros.EnvioPostal, aux_formapago.FormaPago, aux_formapago.IdFormaPago,( IF((SELECT ctos_dettelf.Telefono FROM ctos_dettelf WHERE ctos_dettelf.IdEntidad = ctos_entidades.IDEntidad AND ctos_dettelf.Ppal = -1) !='' ,(SELECT ctos_dettelf.Telefono FROM ctos_dettelf WHERE ctos_dettelf.IdEntidad = ctos_entidades.IDEntidad AND ctos_dettelf.Ppal = -1),'')) AS Telefono, ctos_detemail.Email, com_asociacion.IdTipoAsoc FROM((((((com_comuneros INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN ctos_detdirecent ON com_comuneros.IdDireccion = ctos_detdirecent.IdDireccion) LEFT JOIN ctos_detemail ON com_comuneros.IdEmail = ctos_detemail.IdEmail) INNER JOIN aux_formapago ON com_comuneros.IdFormaPago = aux_formapago.IdFormaPago) INNER JOIN com_asociacion ON com_comuneros.IdComunero = com_asociacion.IdComunero) INNER JOIN com_divisiones ON com_asociacion.IdDivision = com_divisiones.IdDivision) INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision GROUP BY com_comuneros.IdComunero, ctos_entidades.IDEntidad, ctos_entidades.Entidad, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_comuneros.EnvioEmail, com_comuneros.EnvioPostal, aux_formapago.FormaPago, aux_formapago.IdFormaPago, ctos_detemail.Email, com_asociacion.IdTipoAsoc, com_comuneros.IdComunidad, com_subcuotas.IdBloque, com_comuneros.Activo, com_asociacion.FechaBaja, com_asociacion.Ppal HAVING(((com_asociacion.IdTipoAsoc) = 1) AND((com_comuneros.IdComunidad) =  " + idComunidad + ") AND((com_subcuotas.IdBloque) = " + listBox_bloques.SelectedValue + ") AND((com_comuneros.Activo) = -1) AND((com_asociacion.FechaBaja)Is Null) AND((com_asociacion.Ppal) = -1));";


            datos = Persistencia.SentenciasSQL.select(sqlSelectTodo);
            dataGridView_lista.DataSource = datos;

            ajustarDatagrid();
            label6.Text = "Registros: " + dataGridView_lista.Rows.Count.ToString();
        }
        private void ajustarDatagrid() {
            dataGridView_lista.Columns["IdFormaPago"].Visible = false;
            dataGridView_lista.Columns["IdTipoAsoc"].Visible = false;
            dataGridView_lista.Columns["IdComunero"].Width = 45;
            dataGridView_lista.Columns["IDEntidad"].Width = 45;
            dataGridView_lista.Columns["Entidad"].Width = 200;
            dataGridView_lista.Columns["Direccion"].Width = 200;
            dataGridView_lista.Columns["CP"].Width = 50;
            dataGridView_lista.Columns["EnvioEmail"].Width = 20;
            dataGridView_lista.Columns["EnvioEmail"].HeaderText = "E";
            dataGridView_lista.Columns["EnvioPostal"].HeaderText = "P";
            dataGridView_lista.Columns["EnvioPostal"].Width = 20;
            dataGridView_lista.Columns["Email"].Width = 160;
            dataGridView_lista.Columns["FormaPago"].Width = 75;
            dataGridView_lista.Columns["Provincia"].Width = 70;
            dataGridView_lista.Columns["Telefono"].Width = 65;
        }

        private void button_mostrar_Click(object sender, EventArgs e)
        {
            DataTable busqueda;
            if (comboBox_asociacion.SelectedValue.ToString() != "0" && comboBox_asociacion.SelectedValue.ToString() != "1")
            {
                String sqlStringInquilinos = "SELECT com_comuneros.IdComunero, ctos_entidades.IDEntidad, ctos_entidades.Entidad, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_comuneros.EnvioEmail, com_comuneros.EnvioPostal, aux_formapago.FormaPago, aux_formapago.IdFormaPago, ( IF((SELECT ctos_dettelf.Telefono FROM ctos_dettelf WHERE ctos_dettelf.IdEntidad = ctos_entidades.IDEntidad AND ctos_dettelf.Ppal = -1) !='' ,(SELECT ctos_dettelf.Telefono FROM ctos_dettelf WHERE ctos_dettelf.IdEntidad = ctos_entidades.IDEntidad AND ctos_dettelf.Ppal = -1),'')) AS Telefono, ctos_detemail.Email, com_asociacion.IdTipoAsoc FROM((((((com_comuneros INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN ctos_detdirecent ON com_comuneros.IdDireccion = ctos_detdirecent.IdDireccion) LEFT JOIN ctos_detemail ON com_comuneros.IdEmail = ctos_detemail.IdEmail) INNER JOIN aux_formapago ON com_comuneros.IdFormaPago = aux_formapago.IdFormaPago) INNER JOIN com_asociacion ON com_comuneros.IdComunero = com_asociacion.IdComunero) INNER JOIN com_divisiones ON com_asociacion.IdDivision = com_divisiones.IdDivision) INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision GROUP BY com_comuneros.IdComunero, ctos_entidades.IDEntidad, ctos_entidades.Entidad, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_comuneros.EnvioEmail, com_comuneros.EnvioPostal, aux_formapago.FormaPago, aux_formapago.IdFormaPago, ctos_detemail.Email, com_asociacion.IdTipoAsoc, com_comuneros.IdComunidad, com_subcuotas.IdBloque, com_comuneros.Activo HAVING(((com_asociacion.IdTipoAsoc) = " + comboBox_asociacion.SelectedValue.ToString() + ") AND((com_comuneros.IdComunidad) = " + idComunidad + ") AND((com_subcuotas.IdBloque) = " + listBox_bloques.SelectedValue + ") AND((com_comuneros.Activo) = -1));";

                busqueda = Persistencia.SentenciasSQL.select(sqlStringInquilinos);
            }
            else
            {
                cargarDatagrid();
                busqueda = datos;
            }

            if (comboBox_formaPago.SelectedValue.ToString() == "1")
                busqueda.DefaultView.RowFilter = "IdFormaPago = 1";
            else if (comboBox_formaPago.SelectedValue.ToString() == "2")
                busqueda.DefaultView.RowFilter = "IdFormaPago = 2";
            else if (comboBox_formaPago.SelectedValue.ToString() == "3")
                busqueda.DefaultView.RowFilter = "IdFormaPago = 3";

            if (checkBox_envioEmail.Checked && checkBox_envioPapel.Checked)
                busqueda.DefaultView.RowFilter = "EnvioEmail = True AND EnvioPostal = True";
            else if (checkBox_envioEmail.Checked) 
                busqueda.DefaultView.RowFilter = "EnvioEmail = True";
            else if (checkBox_envioPapel.Checked)
                busqueda.DefaultView.RowFilter = "EnvioPostal = True";

            this.dataGridView_lista.DataSource = busqueda;
            label6.Text = "Registros: " + dataGridView_lista.Rows.Count.ToString();
        }

        private void dataGridView_lista_DoubleClick(object sender, EventArgs e)
        {
            Presentacion.EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad((int)dataGridView_lista.SelectedRows[0].Cells[1].Value);
            nueva.Show();
        }

        private void button_seleccionarTodos_Click(object sender, EventArgs e)
        {
            dataGridView_lista.SelectAll();
            CopyToClipboardWithHeaders(dataGridView_lista);
        }
        public void CopyToClipboardWithHeaders(DataGridView _dgv)
        {
            _dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DataObject dataObj = _dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void textBox_buscar_TextChanged(object sender, EventArgs e)
        {
            if (textBox_buscar.TextLength < 2)
            {
                DataTable busqueda = (DataTable)dataGridView_lista.DataSource;
                busqueda.DefaultView.RowFilter = "Entidad like '%%'";
                this.dataGridView_lista.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = (DataTable)dataGridView_lista.DataSource; ;
                busqueda.DefaultView.RowFilter = "Entidad like '%" + textBox_buscar.Text + "%'";
                this.dataGridView_lista.DataSource = busqueda;
            }

        }

        private void buttonInformeJunta_Click(object sender, EventArgs e)
        {
            FormVerInformeJunta nueva = new FormVerInformeJunta(listBox_bloques.SelectedValue.ToString(),idComunidad, listBox_bloques.GetItemText(listBox_bloques.SelectedItem));
            nueva.Show();
            this.Close();
        }
    }
}
