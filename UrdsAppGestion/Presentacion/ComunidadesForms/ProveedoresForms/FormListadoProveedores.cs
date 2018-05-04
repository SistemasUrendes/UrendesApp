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
        DataTable newTable2 = new DataTable();

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
            newTable2 = new DataTable();

            String sqlSelectProveedores = "SELECT com_proveedores.IdProveedor, com_bloques.Descripcion as Bloque, ctos_catentidades.Descripcion, com_proveedores.IdEntidad, ctos_entidades.Entidad, com_proveedores.Servicio FROM((com_proveedores LEFT JOIN com_bloques ON com_proveedores.IdBloque = com_bloques.IdBloque) INNER JOIN ctos_entidades ON com_proveedores.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_catentidades ON com_proveedores.IdCategoria = ctos_catentidades.IdCategoria WHERE(((com_proveedores.IdComunidad) = " + id_comunidad_cargado + "));";

            proveedores = Persistencia.SentenciasSQL.select(sqlSelectProveedores);

            DataTable correos = Persistencia.SentenciasSQL.select("SELECT IdEntidad, Email FROM ctos_detemail WHERE Ppal = -1");

            var result = from x in proveedores.AsEnumerable()
                         join y in correos.AsEnumerable() on x.Field<int>("IdEntidad") equals y.Field<int>("IdEntidad")
                         into xy
                         from y in xy.DefaultIfEmpty()
                         select new
                         {
                             ID = x.Field<int>("IdProveedor"),
                             Field1 = x.Field<string>("Bloque"),
                             Field2 = x.Field<string>("Descripcion"),
                             Field3 = x.Field<int>("IdEntidad"),
                             Field4 = x.Field<string>("Entidad"),
                             Field5 = x.Field<string>("Servicio"),
                             Field6 = (y == null) ? null : y.Field<string>("Email")
                         };

            newTable.Columns.Add("IdProveedor", typeof(int));
            newTable.Columns.Add("Bloque", typeof(string));
            newTable.Columns.Add("Descripcion", typeof(string));
            newTable.Columns.Add("IdEntidad", typeof(int));
            newTable.Columns.Add("Entidad", typeof(string));
            newTable.Columns.Add("Servicio", typeof(string));
            newTable.Columns.Add("Email", typeof(string));

            foreach (var rowInfo in result)
                newTable.Rows.Add(rowInfo.ID, rowInfo.Field1, rowInfo.Field2, rowInfo.Field3, rowInfo.Field4, rowInfo.Field5, rowInfo.Field6);

            String sqlSelectTel = "SELECT ctos_dettelf.IdEntidad, ctos_dettelf.Telefono FROM ctos_dettelf WHERE(((ctos_dettelf.Ppal) = -1));";
            DataTable telefonos = Persistencia.SentenciasSQL.select(sqlSelectTel);

            var result2 = from x in newTable.AsEnumerable()
                         join y in telefonos.AsEnumerable() on x.Field<int>("IdEntidad") equals y.Field<int>("IdEntidad")
                         into xy
                         from y in xy.DefaultIfEmpty()
                         select new
                         {
                             ID = x.Field<int>("IdProveedor"),
                             Field1 = x.Field<string>("Bloque"),
                             Field2 = x.Field<string>("Descripcion"),
                             Field3 = x.Field<int>("IdEntidad"),
                             Field4 = x.Field<string>("Entidad"),
                             Field5 = x.Field<string>("Servicio"),
                             Field6 = x.Field<string>("Email"),
                             Field7 = (y == null) ? null : y.Field<string>("Telefono")
                         };

            newTable2.Columns.Add("IdProveedor", typeof(int));
            newTable2.Columns.Add("Bloque", typeof(string));
            newTable2.Columns.Add("Descripcion", typeof(string));
            newTable2.Columns.Add("IdEntidad", typeof(int));
            newTable2.Columns.Add("Entidad", typeof(string));
            newTable2.Columns.Add("Servicio", typeof(string));
            newTable2.Columns.Add("Email", typeof(string));
            newTable2.Columns.Add("Telefono", typeof(string));

            foreach (var rowInfo in result2)
                newTable2.Rows.Add(rowInfo.ID, rowInfo.Field1, rowInfo.Field2, rowInfo.Field3, rowInfo.Field4, rowInfo.Field5, rowInfo.Field6, rowInfo.Field7);

            dataGridView_proveedores.DataSource = newTable2;

            dataGridView_proveedores.Columns[0].Width = 40;
            dataGridView_proveedores.Columns[1].Width = 100;
            dataGridView_proveedores.Columns[2].Width = 180;
            dataGridView_proveedores.Columns[3].Visible = false;
            dataGridView_proveedores.Columns[4].Width = 250;
            dataGridView_proveedores.Columns[5].Width = 250;
            dataGridView_proveedores.Columns[6].Width = 180;

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
                    nuevo.recibirProveedor(dataGridView_proveedores.SelectedCells[3].Value.ToString(), dataGridView_proveedores.SelectedCells[4].Value.ToString());
                }
                if (nombre_form_cargado == "FormOperacionesVencimientos")
                {
                    OperacionesForms.FormOperacionesVencimientos nuevo = (OperacionesForms.FormOperacionesVencimientos)existe;
                    nuevo.recibirProveedor(dataGridView_proveedores.SelectedCells[3].Value.ToString(), dataGridView_proveedores.SelectedCells[4].Value.ToString());
                }
                if (nombre_form_cargado == "FormInsertarContacto")
                {
                    Tareas.FormInsertarContacto nuevo = (Tareas.FormInsertarContacto)existe;
                    nuevo.recibirProveedor(dataGridView_proveedores.SelectedCells[0].Value.ToString());
                }
                if (nombre_form_cargado == "FormInsertarGestion")
                {
                    Tareas.FormInsertarGestion nuevo = (Tareas.FormInsertarGestion)existe;
                    nuevo.recibirProveedor(dataGridView_proveedores.SelectedCells[3].Value.ToString());
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
            String sqlUpdate = "UPDATE com_proveedores SET IdBloque=" + idBloque + " WHERE IdProveedor = " + dataGridView_proveedores.SelectedRows[0].Cells[0].Value.ToString();
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            cargarDatagrid();
        }

        private void comboBox_informes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_informes.SelectedIndex == 0) {
                ProveedoresForms.FormInformeProveedores nueva = new ProveedoresForms.FormInformeProveedores(newTable2,id_comunidad_cargado);
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
            String sqlDelete = "DELETE FROM com_proveedores WHERE IdProveedor = " + dataGridView_proveedores.SelectedRows[0].Cells[0].Value.ToString();
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
            cargarDatagrid();
            MessageBox.Show("Proveedor Eliminado");
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProveedoresForms.FormAnyadirProveedor nuevo = new ProveedoresForms.FormAnyadirProveedor(id_comunidad_cargado, this, dataGridView_proveedores.SelectedRows[0].Cells[7].Value.ToString());
            nuevo.Show();
        }

        private void verEntidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad((int)dataGridView_proveedores.SelectedRows[0].Cells[3].Value);
            nueva.Show();
        }

        private void dataGridView_proveedores_DoubleClick(object sender, EventArgs e)
        {
            EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad((int)dataGridView_proveedores.SelectedRows[0].Cells[3].Value);
            nueva.Show();
        }
    }
}
