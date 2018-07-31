using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProveedoresForms
{
    public partial class FormAnyadirProveedor : Form
    {
        OperacionesForms.FormOperacionesListadoProveedores form_anterior;
        String idComunidad;
        String id_entidad_nuevo;
        String idProveedor;

        public FormAnyadirProveedor(String idComunidad, OperacionesForms.FormOperacionesListadoProveedores form_anterior)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.form_anterior = form_anterior;
        }
        public FormAnyadirProveedor(String idComunidad, OperacionesForms.FormOperacionesListadoProveedores form_anterior, String idProveedor)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.form_anterior = form_anterior;
            this.idProveedor = idProveedor;
        }

        private void FormAnyadirProveedor_Load(object sender, EventArgs e)
        {
            comboBox_bloque.DataSource = Persistencia.SentenciasSQL.select("SELECT com_bloques.IdBloque, com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdTipoBloque) = 1) AND((com_bloques.Baja) <> -1) AND((com_bloques.IdComunidad) = " + idComunidad + "));");
            comboBox_bloque.ValueMember = "IdBloque";
            comboBox_bloque.DisplayMember = "Descripcion";

            comboBox_categoria.DataSource = Persistencia.SentenciasSQL.select("SELECT ctos_catentidades.IdCategoria, ctos_catentidades.Descripcion FROM ctos_catentidades ORDER BY ctos_catentidades.Descripcion;");
            comboBox_categoria.ValueMember = "IdCategoria";
            comboBox_categoria.DisplayMember = "Descripcion";
            
            if (idProveedor != null) {
                String sqlSelect = "SELECT com_proveedores.IdBloque, com_proveedores.IdEntidad, ctos_entidades.Entidad, com_proveedores.IdCategoria, com_proveedores.Servicio, com_proveedores.RefContrato FROM com_proveedores INNER JOIN ctos_entidades ON com_proveedores.IdEntidad = ctos_entidades.IDEntidad WHERE com_proveedores.IdProveedor = " + idProveedor + " AND com_proveedores.IdComunidad = " + idComunidad;
                DataTable proveedor = Persistencia.SentenciasSQL.select(sqlSelect);
                
                if (proveedor.Rows[0][0].ToString() != "")
                    comboBox_bloque.SelectedValue = proveedor.Rows[0][0].ToString();

                if (proveedor.Rows[0][3].ToString() != "")
                    comboBox_categoria.SelectedValue = proveedor.Rows[0][3].ToString();

                id_entidad_nuevo = proveedor.Rows[0][1].ToString();
                textBox_entidad.Text = proveedor.Rows[0][2].ToString();
                textBox_descripcion.Text = proveedor.Rows[0][4].ToString();
                textBox_ref.Text = proveedor.Rows[0][5].ToString();

            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_entidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter || e.KeyChar == (Char)Keys.Space)
            {
                Entidades nueva = new Entidades(this, this.Name);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.textBox_buscar_nombre.Select();
                nueva.textBox_buscar_nombre.Location = new Point(nueva.textBox_buscar_nombre.Location.X+230, nueva.textBox_buscar_nombre.Location.Y + 60);
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
        public void recibirEntidad(String id_entidad, String Nombre)
        {
            id_entidad_nuevo = id_entidad;
            textBox_entidad.Text = Nombre;
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            try {
                if (idProveedor != null)
                {
                    String sqlUpdate = "UPDATE com_proveedores SET IdBloque =" + comboBox_bloque.SelectedValue + ", IdEntidad=" + id_entidad_nuevo + ", IdCategoria=" + comboBox_categoria.SelectedValue + ", Servicio='" + textBox_descripcion.Text + "', RefContrato = '" + textBox_ref.Text + "' WHERE IdProveedor = " + idProveedor;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                    form_anterior.cargarDatagrid();
                    this.Close();
                }
                else
                {
                    String sqlInsertProveedor = "INSERT INTO com_proveedores (IdComunidad, IdBloque, IdEntidad, IdCategoria, Servicio, RefContrato ) VALUES (" + idComunidad + "," + comboBox_bloque.SelectedValue + "," + id_entidad_nuevo + "," + comboBox_categoria.SelectedValue + ",'" + textBox_descripcion.Text + "','" + textBox_ref.Text + "')";

                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertProveedor);
                    form_anterior.cargarDatagrid();
                    this.Close();
                }
            }catch (Exception) {
                MessageBox.Show("Falta algun dato");
            }
        }
    }
}
