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
    public partial class FormOperacionesListadoProveedores : Form
    {
        String id_comunidad_cargado;
        DataTable proveedores;
        String nombre_form_cargado = "";
        Form form_anterior = null;
        DataTable newTable = new DataTable();

        public FormOperacionesListadoProveedores(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        public FormOperacionesListadoProveedores(Form form_anterior, String nombre_form_cargado, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.nombre_form_cargado = nombre_form_cargado;
            this.form_anterior = form_anterior;
        }

        private void FormOperacionesListadoProveedores_Load(object sender, EventArgs e)
        {
            if (nombre_form_cargado != "")
                button_enviar.Visible = true;

            cargarDatagrid();
        }
        public void cargarDatagrid()
        {
            newTable = new DataTable();
            String sqlSelectProveedores = "SELECT ctos_entidades.IDEntidad, com_bloques.Descripcion AS Bloque, ctos_catentidades.Descripcion, ctos_entidades.Entidad, com_proveedores.Servicio, ctos_dettelf.Telefono, ctos_detemail.Email, com_proveedores.IdProveedor FROM((((ctos_entidades INNER JOIN com_proveedores ON ctos_entidades.IDEntidad = com_proveedores.IdEntidad) INNER JOIN ctos_catentidades ON com_proveedores.IdCategoria = ctos_catentidades.IdCategoria) INNER JOIN ctos_dettelf ON ctos_entidades.IDEntidad = ctos_dettelf.IdEntidad) LEFT JOIN ctos_detemail ON ctos_entidades.IDEntidad = ctos_detemail.IdEntidad) LEFT JOIN com_bloques ON com_proveedores.IdBloque = com_bloques.IdBloque WHERE(((com_proveedores.IdComunidad) = " + id_comunidad_cargado + ") AND((ctos_dettelf.Ppal) = -1)) ORDER BY ctos_entidades.Entidad;";

            proveedores = Persistencia.SentenciasSQL.select(sqlSelectProveedores);

            DataTable correos = Persistencia.SentenciasSQL.select("SELECT IdEntidad, Email FROM ctos_detemail");


            var query =
                from tbl1 in proveedores.AsEnumerable()
                join tbl2 in correos.AsEnumerable() on tbl1["IDEntidad"] equals tbl2["IdEntidad"]
                group tbl1 by tbl1.Field<int>("IDEntidad") into IdGroup
                let row = IdGroup.First()
                select new
                {
                    ID = IdGroup.Key,
                    Field1 = row["Descripcion"],
                    Field2 = row["Entidad"],
                    Field3 = row["Servicio"],
                    Field4 = (row["Telefono"].ToString() == "" ? "No" : row["Telefono"]),
                    Field5 = (row["Email"].ToString() == "" ? "No" : row["Email"]),
                    Field6 = row["Bloque"],
                    Field7 = row["IdProveedor"]
                };

            newTable.Columns.Add("IdEntidad", typeof(int));
            newTable.Columns.Add("Bloque", typeof(string));
            newTable.Columns.Add("Descripcion", typeof(string));
            newTable.Columns.Add("Entidad", typeof(string));
            newTable.Columns.Add("Servicio", typeof(string));
            newTable.Columns.Add("Telefono", typeof(string));
            newTable.Columns.Add("Email", typeof(string));
            newTable.Columns.Add("IdProveedor", typeof(int));


            foreach (var rowInfo in query)
                newTable.Rows.Add(rowInfo.ID, rowInfo.Field6, rowInfo.Field1, rowInfo.Field2, rowInfo.Field3, rowInfo.Field4, rowInfo.Field5, rowInfo.Field7);

            dataGridView_proveedores.DataSource = newTable;

            dataGridView_proveedores.Columns[0].Width = 40;
            dataGridView_proveedores.Columns[1].Width = 100;
            dataGridView_proveedores.Columns[2].Width = 180;
            dataGridView_proveedores.Columns[3].Width = 250;
            dataGridView_proveedores.Columns[4].Width = 270;
            dataGridView_proveedores.Columns[6].Width = 200;
            dataGridView_proveedores.Columns[7].Visible = false;


            
            //dataGridView_proveedores.DataSource = proveedores;
        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            enviarAotroForm();
        }
        private void enviarAotroForm()
        {

            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_form_cargado)).SingleOrDefault<Form>();
            if (existe != null)
            {
                if (nombre_form_cargado == "FormOperacionesCabeceraEdicion")
                {
                    OperacionesForms.FormOperacionesCabeceraEdicion nuevo = (OperacionesForms.FormOperacionesCabeceraEdicion)existe;
                    nuevo.recibirProveedor(dataGridView_proveedores.SelectedCells[0].Value.ToString(), dataGridView_proveedores.SelectedCells[2].Value.ToString());
                }
                if (nombre_form_cargado == "FormOperacionesVencimientos")
                {
                    OperacionesForms.FormOperacionesVencimientos nuevo = (OperacionesForms.FormOperacionesVencimientos)existe;
                    nuevo.recibirProveedor(dataGridView_proveedores.SelectedCells[0].Value.ToString(), dataGridView_proveedores.SelectedCells[2].Value.ToString());
                }
            }
            this.Close();
        }
        private void dataGridView_proveedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter && dataGridView_proveedores.SelectedRows.Count > 0 && button_enviar.Visible)
            {
                dataGridView_proveedores.Rows[dataGridView_proveedores.CurrentRow.Index - 1].Selected = true;
                enviarAotroForm();
            }
        }

        private void textBox_buscar_TextChanged(object sender, EventArgs e)
        {
            if (textBox_buscar.TextLength < 2)
            {
                DataTable busqueda = newTable;
                busqueda.DefaultView.RowFilter = "Entidad like '%%'";
                this.dataGridView_proveedores.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = newTable;
                busqueda.DefaultView.RowFilter = "Bloque like '%" + textBox_buscar.Text + "%' OR Entidad like '%" + textBox_buscar.Text + "%' OR Servicio like '%" + textBox_buscar.Text + "%' OR Descripcion like '%" + textBox_buscar.Text + "%' ";
                this.dataGridView_proveedores.DataSource = busqueda;
            }
        }

        private void dataGridView_proveedores_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_proveedores.HitTest(e.X, e.Y);
                dataGridView_proveedores.ClearSelection();
                dataGridView_proveedores.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void añadirBloqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BloquesForms.Bloques nueva = new BloquesForms.Bloques(this, this.Name, id_comunidad_cargado);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void recogerBloque(String idBloque) {
            String sqlUpdate = "UPDATE com_proveedores SET IdBloque=" + idBloque + " WHERE IdProveedor = " + dataGridView_proveedores.SelectedRows[0].Cells[7].Value.ToString();
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            cargarDatagrid();
        }

        private void comboBox_informes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_informes.SelectedIndex == 0) {
                ProveedoresForms.FormInformeProveedores nueva = new ProveedoresForms.FormInformeProveedores(newTable,id_comunidad_cargado);
                nueva.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProveedoresForms.FormAnyadirProveedor nuevo = new ProveedoresForms.FormAnyadirProveedor(id_comunidad_cargado,this);
            nuevo.Show();
        }

        private void eliminarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlDelete = "DELETE FROM com_proveedores WHERE IdProveedor = " + dataGridView_proveedores.SelectedRows[0].Cells[7].Value.ToString();
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
            MessageBox.Show("Proveedor Eliminado");
            cargarDatagrid();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProveedoresForms.FormAnyadirProveedor nuevo = new ProveedoresForms.FormAnyadirProveedor(id_comunidad_cargado, this, dataGridView_proveedores.SelectedRows[0].Cells[7].Value.ToString());
            nuevo.Show();
        }

        private void verEntidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad((int)dataGridView_proveedores.SelectedRows[0].Cells[0].Value);
            nueva.Show();
        }
    }
}
