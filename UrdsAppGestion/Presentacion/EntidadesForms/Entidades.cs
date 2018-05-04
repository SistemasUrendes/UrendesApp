using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Persistencia;
using UrdsAppGestión.Presentacion;

namespace UrdsAppGestión.Presentacion
{
    public partial class Entidades : Form
    {
        DataTable resultado = null;
        static DataTable general = null;
        static DataTable busqueda;
        int columnaSeleccionaPortaPapeles = 0;
        Form form_ant = null;
        String nombre_form_anterior;
        String IdPasado;
        DataTable newTable = new DataTable();

        public Entidades()
        {
            InitializeComponent();
        }
        public Entidades(Form form_ant,String nombre_form_anterior)
        {
            InitializeComponent();
            this.form_ant = form_ant;
            this.nombre_form_anterior = nombre_form_anterior;
        }
        public Entidades(Form form_ant, String nombre_form_anterior, String Id)
        {
            InitializeComponent();
            this.form_ant = form_ant;
            this.nombre_form_anterior = nombre_form_anterior;
            this.IdPasado = Id;
        }

        private void Entidades_Load(object sender, EventArgs e)
        {
            if (form_ant != null)  {
                button_enviar.Visible = true;
            }

            resultado = Persistencia.SentenciasSQL.select(SentenciasSQL.SQL[0]);
            listBox_categoria.DisplayMember = "Descripcion";
            listBox_categoria.ValueMember = "IdCategoria";
            this.listBox_categoria.DataSource = resultado;

            general = Persistencia.SentenciasSQL.select(SentenciasSQL.SQL[1]);

            DataTable telefonos = Persistencia.SentenciasSQL.select("SELECT ctos_dettelf.IdEntidad, ctos_dettelf.Telefono FROM ctos_dettelf WHERE (((ctos_dettelf.Ppal)=-1)) GROUP BY ctos_dettelf.IdEntidad;");

            DataTable emails = Persistencia.SentenciasSQL.select("SELECT ctos_detemail.IdEntidad,ctos_detemail.Descripcion, ctos_detemail.Email FROM ctos_detemail WHERE (((ctos_detemail.Ppal)= -1 ))  GROUP BY ctos_detemail.IdEntidad");

            var result = from x in general.AsEnumerable()
                         join y in telefonos.AsEnumerable() on x.Field<int>("IDEntidad") equals y.Field<int>("IdEntidad")
                         into xy
                         from y in xy.DefaultIfEmpty()
                         select new {
                             CustID = x.Field<int>("IDEntidad"),
                             ColX = x.Field<string>("Entidad"),
                             nombreCorto = x.Field<string>("NombreCorto"),
                             entSinAcento = x.Field<string>("EntidadSinAcentos"),
                             ColY = (y == null) ? null : y.Field<string>("Telefono"),
                             cate = (x.Field<int?>("IdCategoria") == null) ? null : x.Field<int?>("IdCategoria")
                         };

            newTable = new DataTable();
            newTable.Columns.Add("IDEntidad", typeof(int));
            newTable.Columns.Add("Entidad", typeof(string));
            newTable.Columns.Add("Telefono", typeof(string));
            newTable.Columns.Add("IdCategoria", typeof(int));
            newTable.Columns.Add("EntidadSinAcentos", typeof(string));
            newTable.Columns.Add("NombreCorto", typeof(string));

            foreach (var rowInfo in result)
                newTable.Rows.Add(rowInfo.CustID, rowInfo.ColX, rowInfo.ColY,rowInfo.cate, rowInfo.entSinAcento,rowInfo.nombreCorto);

            var result1 = from x in newTable.AsEnumerable()
                         join y in emails.AsEnumerable() on x.Field<int>("IDEntidad") equals y.Field<int>("IdEntidad")
                         into xy
                         from y in xy.DefaultIfEmpty()
                         select new
                         {
                             CustID = x.Field<int>("IDEntidad"),
                             ColX = x.Field<string>("Entidad"),
                             nombreCorto = x.Field<string>("NombreCorto"),
                             entSinAcento = x.Field<string>("EntidadSinAcentos"),
                             tel = x.Field<string>("Telefono"),
                             correo = (y == null) ? null : y.Field<string>("Email"),
                             cate = (x.Field<int?>("IdCategoria") == null) ? null : x.Field<int?>("IdCategoria")
                         };

            newTable = new DataTable();
            newTable.Columns.Add("IDEntidad", typeof(int));
            newTable.Columns.Add("Entidad", typeof(string));
            newTable.Columns.Add("Email", typeof(string));
            newTable.Columns.Add("Telefono", typeof(string));
            newTable.Columns.Add("IdCategoria", typeof(int));
            newTable.Columns.Add("EntidadSinAcentos", typeof(string));
            newTable.Columns.Add("NombreCorto", typeof(string));

            foreach (var rowInfo in result1)
                newTable.Rows.Add(rowInfo.CustID, rowInfo.ColX, rowInfo.correo,rowInfo.tel, rowInfo.cate,rowInfo.entSinAcento,rowInfo.nombreCorto);

            dataGridView1.DataSource = newTable;
            general = newTable;

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

        }
        private void enviarOtroForm() {

            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_form_anterior)).SingleOrDefault<Form>();
            if (existe != null)
            {
                if (nombre_form_anterior == "FormAltaComunero") {
                    Presentacion.ComunidadesForms.ComunerosForms.FormAltaComunero nuevo = (Presentacion.ComunidadesForms.ComunerosForms.FormAltaComunero) existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString());
                }

                //if (nombre_form_anterior == "FormAltaAsociacion") {
                //    Presentacion.ComunidadesForms.DivisionesForms.FormAltaAsociacion nuevo = (Presentacion.ComunidadesForms.DivisionesForms.FormAltaAsociacion) existe;
                //    nuevo.recogerEntidad(dataGridView1.SelectedCells[0].Value.ToString());
                //}
                if (nombre_form_anterior == "FormOperacionesCabeceraEdicion")
                {
                    Presentacion.ComunidadesForms.OperacionesForms.FormOperacionesCabeceraEdicion nuevo = (Presentacion.ComunidadesForms.OperacionesForms.FormOperacionesCabeceraEdicion)existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString());
                }
                if (nombre_form_anterior == "FormOperacionesVencimientos")
                {
                    ComunidadesForms.OperacionesForms.FormOperacionesVencimientos nuevo = (ComunidadesForms.OperacionesForms.FormOperacionesVencimientos)existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString());
                }
                if (nombre_form_anterior == "FormOperacionesEditReparto")
                {
                    ComunidadesForms.OperacionesForms.FormOperacionesEditReparto nuevo = (ComunidadesForms.OperacionesForms.FormOperacionesEditReparto)existe;
                    nuevo.recogerBloque(dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString());
                }

                if (nombre_form_anterior == "FormAccesoOperacionesTesoreria")
                {
                    ComunidadesForms.TesoreriaForms.FormAccesoOperacionesTesoreria nuevo = (ComunidadesForms.TesoreriaForms.FormAccesoOperacionesTesoreria)existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString());
                }
                if (nombre_form_anterior == "FormCrearCuentaComunidad")
                {
                    ComunidadesForms.TesoreriaForms.FormCrearCuentaComunidad nuevo = (ComunidadesForms.TesoreriaForms.FormCrearCuentaComunidad)existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString());
                }

                if (nombre_form_anterior == "FormReasignarOperacion")
                {
                    ComunidadesForms.DivisionesForms.FormReasignarPagador nuevo = (ComunidadesForms.DivisionesForms.FormReasignarPagador)existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString());
                }

                if (nombre_form_anterior == "FormNuevoRecibo")
                {
                    ComunidadesForms.Recibos.FormNuevoRecibo nuevo = (ComunidadesForms.Recibos.FormNuevoRecibo)existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString());
                }
                if (nombre_form_anterior == "FormIngresoFondo")
                {
                    ComunidadesForms.OperacionesForms.FormIngresoFondo nuevo = (ComunidadesForms.OperacionesForms.FormIngresoFondo)existe;
                    nuevo.recibirComunero(dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString());
                }
                if (nombre_form_anterior == "FormAnyadirProveedor")
                {
                    ComunidadesForms.ProveedoresForms.FormAnyadirProveedor nuevo = (ComunidadesForms.ProveedoresForms.FormAnyadirProveedor)existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString());
                }
                if (nombre_form_anterior == "FormVerTarea")
                {
                    Tareas.FormVerTarea nuevo = (Tareas.FormVerTarea)existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString());
                }
                if (nombre_form_anterior == "FormInsertarContacto")
                {
                    Tareas.FormInsertarContacto nuevo = (Tareas.FormInsertarContacto)existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString());
                }
                if (nombre_form_anterior.Contains("Gestion") && form_ant.Tag.ToString() == IdPasado)
                {
                    Tareas.FormInsertarGestion nuevo = (Tareas.FormInsertarGestion)existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString());
                }
                if (nombre_form_anterior == "FormGestionesPrincipal")
                {
                    Tareas.FormGestionesPrincipal nuevo = (Tareas.FormGestionesPrincipal)existe;
                    nuevo.recibirEntidad(dataGridView1.SelectedCells[0].Value.ToString());
                }
            }
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) && (textBox_buscar.TextLength < 2)) {
                resultado = Persistencia.SentenciasSQL.select(SentenciasSQL.SQL[2]);
                listBox_categoria.DisplayMember = "Descripcion";
                listBox_categoria.ValueMember = "IdCategoria";
                listBox_categoria.DataSource = resultado;
            }
            else
            {
                busqueda = resultado;
                //busqueda.CaseSensitive = false;
                busqueda.DefaultView.RowFilter = "Descripcion like '%" + textBox_buscar.Text + "%'";
                listBox_categoria.DisplayMember = "Descripcion";
                listBox_categoria.ValueMember = "IdCategoria";
                this.listBox_categoria.DataSource = busqueda;
            }
        }

        private void button_mostrar_Click(object sender, EventArgs e)
        {
            busqueda = general;
            string filtro = "";
            int count = 0;
            foreach (object element in listBox_categoria.SelectedItems) {
                DataRowView row = (DataRowView)element;
                //MessageBox.Show(row[0].ToString());
                filtro = filtro + "IdCategoria = " + row[0].ToString();
                if (count != listBox_categoria.SelectedItems.Count -1 ) {
                    filtro = filtro + " OR ";
                }
                count++;
            }

            busqueda.DefaultView.RowFilter = filtro;
            dataGridView1.DataSource = busqueda;

        }
        private void ajustarDatagrid() {
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            //dataGridView1.Columns["EntidadSinAcentos"].Visible = false;

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 420;
            dataGridView1.Columns[5].Width = 270;
            dataGridView1.Columns[7].Width = 106;
        }

        private void textBox_buscar_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            busqueda = general;
            busqueda.DefaultView.RowFilter = "EntidadSinAcentos like '%" + textBox_buscar_nombre.Text + "%' OR NombreCorto like '%" + textBox_buscar_nombre.Text + "%' OR Entidad like '%" + textBox_buscar_nombre.Text + "%'";

            dataGridView1.DataSource = busqueda;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;

            if (e.KeyChar == (Char)Keys.Enter) {
                if (dataGridView1.SelectedRows.Count == 1)
                    enviarOtroForm();
            }

        }

        private void textBox_correo_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox_telefono_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox_telefono_buscar.TextLength > 0)
            {
                busqueda = general;
                DataTable telefonos = Persistencia.SentenciasSQL.select("SELECT ctos_dettelf.IdEntidad,ctos_dettelf.Telefono FROM ctos_dettelf WHERE (((ctos_dettelf.Telefono) Like '%" + textBox_telefono_buscar.Text + "%')) GROUP BY ctos_dettelf.IdEntidad;");

                var query =
                    from tbl1 in busqueda.AsEnumerable()
                    join tbl2 in telefonos.AsEnumerable() on tbl1["IDEntidad"] equals tbl2["IdEntidad"]
                    group tbl1 by tbl1.Field<int>("IDEntidad") into IdGroup
                    let row = IdGroup.First()
                    select new
                    {
                        ID = IdGroup.Key,
                        Field1 = row["Entidad"],
                        Field2 = row["Email"],
                        Field3 = row["Telefono"]
                    };

                DataTable newTable = new DataTable();
                newTable.Columns.Add("ID", typeof(int));
                newTable.Columns.Add("Entidad", typeof(string));
                newTable.Columns.Add("Email", typeof(string));
                newTable.Columns.Add("Telefono", typeof(string));

                foreach (var rowInfo in query)
                    newTable.Rows.Add(rowInfo.ID, rowInfo.Field1, rowInfo.Field2, rowInfo.Field3);

                dataGridView1.DataSource = newTable;

                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 400;
                dataGridView1.Columns[2].Width = 250;
                dataGridView1.Columns[3].Width = 100;
            }
        else {
                dataGridView1.DataSource = null;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[hti.RowIndex].Selected = true;
                MenuContextual.Items.Clear();
                MenuContextual.Items.Add("Copiar a Portapapeles");
                MenuContextual.Items.Add(new ToolStripSeparator());
                columnaSeleccionaPortaPapeles = hti.ColumnIndex;
                MenuContextual.Items[0].Click += new EventHandler(this.copiarAlPortapapelesToolStripMenuItem_Click);
                MenuContextual.Items.Add("Telefonos");
                MenuContextual.Items[2].Enabled = false;

                DataTable telefonos = Persistencia.SentenciasSQL.select(" SELECT ctos_dettelf.IdEntidad, ctos_dettelf.Descripcion, ctos_dettelf.Telefono FROM ctos_dettelf WHERE(((ctos_dettelf.IdEntidad) = " + dataGridView1.SelectedCells[0].Value.ToString() + " ));");
                for (int a = 0;a< telefonos.Rows.Count;a++) {
                    MenuContextual.Items.Add(telefonos.Rows[a][1].ToString() + " : " + telefonos.Rows[a][2].ToString());
                }
                //Menu.Items.Add(this.dataGridView1.SelectedCells[0].Value.ToString());
                MenuContextual.Show(Cursor.Position);
            }
        }

        private void textBox_telefono_buscar_Click(object sender, EventArgs e)
        {
            textBox_buscar_nombre.Text = "";
            textBox_correo_buscar.Text = "";
        }

        private void textBox_correo_buscar_Click(object sender, EventArgs e)
        {
            textBox_buscar_nombre.Text = "";
            textBox_telefono_buscar.Text = "";
        }

        private void textBox_buscar_nombre_Click(object sender, EventArgs e)
        {
            textBox_telefono_buscar.Text = "";
            textBox_correo_buscar.Text = "";
        }

        private void button_añadir_entidad_Click(object sender, EventArgs e)
        {
            Presentacion.EntidadesForms.ComprobarEntidad nueva = new EntidadesForms.ComprobarEntidad(general);
            nueva.Show();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad((int)dataGridView1.SelectedCells[0].Value);
            nueva.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad((int)dataGridView1.SelectedCells[0].Value);
            nueva.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta Entidad?", "Borrar Entidad", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                //MessageBox.Show(dataGridView1.SelectedCells[0].Value.ToString());
                String sqlBorrar = "DELETE FROM `ctos_entidades` WHERE `IDEntidad` = " + dataGridView1.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);

                general = Persistencia.SentenciasSQL.select(SentenciasSQL.SQL[1]);
                dataGridView1.DataSource = general;
            }
        }

        public static void setGeneral()
        {
           // MessageBox.Show("hola");
            general = Persistencia.SentenciasSQL.select(SentenciasSQL.SQL[1]);
        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            enviarOtroForm();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (nombre_form_anterior != "")
                {
                    e.SuppressKeyPress = true;
                    //dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Selected = true;
                    enviarOtroForm();
                }
            }
        }

        private void textBox_correo_buscar_TextChanged(object sender, EventArgs e)
        {
            if (textBox_correo_buscar.TextLength > 3)
            {
                //general = Persistencia.SentenciasSQL.select(SentenciasSQL.SQL[1]);
                busqueda = general;

                DataTable telefonos = Persistencia.SentenciasSQL.select("SELECT ctos_detemail.IdEntidad,ctos_detemail.Descripcion, ctos_detemail.Email FROM ctos_detemail WHERE (((ctos_detemail.Email) Like '%" + textBox_correo_buscar.Text + "%')) GROUP BY ctos_detemail.IdEntidad");

                var query =
                    from tbl1 in busqueda.AsEnumerable()
                    join tbl2 in telefonos.AsEnumerable() on tbl1["IDEntidad"] equals tbl2["IdEntidad"]
                    group tbl1 by tbl1.Field<int>("IDEntidad") into IdGroup
                    let row = IdGroup.First()
                    select new
                    {
                        ID = IdGroup.Key,
                        Field1 = row["Entidad"],
                        Field2 = row["Email"],
                        Field3 = row["Telefono"]
                    };

                DataTable newTable = new DataTable();
                newTable.Columns.Add("IDEntidad", typeof(int));
                newTable.Columns.Add("Entidad", typeof(string));
                newTable.Columns.Add("Email", typeof(string));
                newTable.Columns.Add("Telefono", typeof(string));

                foreach (var rowInfo in query)
                    newTable.Rows.Add(rowInfo.ID, rowInfo.Field1, rowInfo.Field2, rowInfo.Field3);

                dataGridView1.DataSource = newTable;

                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 400;
                dataGridView1.Columns[2].Width = 250;
                dataGridView1.Columns[3].Width = 100;
            }
            else
            {
                dataGridView1.DataSource = general;
                dataGridView1.Columns[4].Visible = false;
                //ajustarDatagrid();
            }
        }

        private void copiarAlPortapapelesToolStripMenuItem_Click(object sender, EventArgs ey)
        {
            if (columnaSeleccionaPortaPapeles == 0)
                Clipboard.SetDataObject("Nombre:"+ dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "| Correo :" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "| Teléfono:" + dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            else if (columnaSeleccionaPortaPapeles == 1)
                Clipboard.SetDataObject(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            else if (columnaSeleccionaPortaPapeles == 2)
                Clipboard.SetDataObject(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            else if (columnaSeleccionaPortaPapeles == 3)
                Clipboard.SetDataObject(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());

        }

        private void buttonAddGrupo_Click(object sender, EventArgs e)
        {
            EntidadesForms.FormInsertarGrupo nueva = new EntidadesForms.FormInsertarGrupo();
            nueva.Show();
        }
        
    }
}