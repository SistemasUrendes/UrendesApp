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
    public partial class FormOperacionesEditReparto : Form
    {
        String id_comunidad_cargado = "0";
        String id_operacion_cargado = "0";
        String id_tipo_reparto_cargado = "0";
        decimal importe_total_cargado = Convert.ToDecimal(0.00);
        String importe_pasado = "";
        Boolean vengoDePantallaVer = false;
        String guardada = "no";
        List<String> filas_eliminadas = new List<String>();

        FromOperacionesVer form_anterior;

        public FormOperacionesEditReparto(FromOperacionesVer form_anterior, String id_comunidad_cargado, String id_operacion_cargado, String id_tipo_reparto_cargado) {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
            this.id_operacion_cargado = id_operacion_cargado;
            this.id_tipo_reparto_cargado = id_tipo_reparto_cargado;

        }

        public FormOperacionesEditReparto(FromOperacionesVer form_anterior, String id_comunidad_cargado, String id_operacion_cargado, String id_tipo_reparto_cargado, String importe_pasado, Boolean vengoDePantallaVer)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
            this.id_operacion_cargado = id_operacion_cargado;
            this.id_tipo_reparto_cargado = id_tipo_reparto_cargado;
            this.importe_pasado = importe_pasado;
            this.vengoDePantallaVer = vengoDePantallaVer;
        }
        public FormOperacionesEditReparto(String id_comunidad_cargado, String id_operacion_cargado, String id_tipo_reparto_cargado, String importe_pasado) {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_operacion_cargado = id_operacion_cargado;
            this.id_tipo_reparto_cargado = id_tipo_reparto_cargado;
            this.importe_pasado = importe_pasado;
        }

        private void FormOperacionesEditReparto_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn nombre = new DataGridViewTextBoxColumn();
            if (id_tipo_reparto_cargado == "1")  {  //BLOQUE
                nombre.HeaderText = "Bloque";
            }
            else if (id_tipo_reparto_cargado == "2")  { //DIVISION
                nombre.HeaderText = "Division";
            }
            else if (id_tipo_reparto_cargado == "3")  { //ENTIDAD
                nombre.HeaderText = "Entidad";
            }
            nombre.ReadOnly = true;

            DataGridViewTextBoxColumn porcentaje = new DataGridViewTextBoxColumn();
            porcentaje.HeaderText = "%";
            DataGridViewTextBoxColumn importe = new DataGridViewTextBoxColumn();
            importe.HeaderText = "Importe";
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.HeaderText = "ID";
            DataGridViewTextBoxColumn idBloque = new DataGridViewTextBoxColumn();
            id.HeaderText = "IdBloque";

            dataGridView_reparto.Columns.Add(id);
            dataGridView_reparto.Columns.Add(nombre);
            dataGridView_reparto.Columns.Add(porcentaje);
            dataGridView_reparto.Columns.Add(importe);
            dataGridView_reparto.Columns.Add(idBloque);

            dataGridView_reparto.Columns[0].Name = "ID";
            dataGridView_reparto.Columns[1].Name = "Nombre";
            dataGridView_reparto.Columns[2].Name = "%";
            dataGridView_reparto.Columns[3].Name = "Importe";
            dataGridView_reparto.Columns[4].Name = "IdBloque";

            dataGridView_reparto.Columns[0].Visible = false;
            dataGridView_reparto.Columns[1].Width = 150;
            dataGridView_reparto.Columns[4].Visible = false;
            textBox_importe_op.Text = importe_pasado;

            cargarReparto();

        }
        public void cargarReparto() {
            if (id_operacion_cargado != "0")  {
                if (id_tipo_reparto_cargado == "1")  {
                    String sqlSelectBloque = "SELECT com_opdetbloques.IdOpBloque, com_bloques.Descripcion, com_opdetbloques.Porcentaje, com_opdetbloques.Importe, com_opdetbloques.IdBloque FROM com_opdetbloques INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque WHERE(((com_opdetbloques.IdOp) = " + id_operacion_cargado + "));";

                    DataTable repartos = Persistencia.SentenciasSQL.select(sqlSelectBloque);

                    for (int a = 0; a < repartos.Rows.Count; a++)
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView_reparto.Rows[0].Clone();
                        row.Cells[0].Value = repartos.Rows[a][0].ToString();
                        row.Cells[1].Value = repartos.Rows[a][1];
                        row.Cells[4].Value = repartos.Rows[a][4];

                        decimal porcentaje = Convert.ToDecimal(string.Format("{0:F2}", repartos.Rows[a][2].ToString())) * 100;
                        row.Cells[2].Value = porcentaje.ToString();

                        row.Cells[3].Value = repartos.Rows[a][3].ToString();
                        dataGridView_reparto.Rows.Add(row);

                        importe_total_cargado = importe_total_cargado + Convert.ToDecimal(string.Format("{0:F2}", repartos.Rows[a][3].ToString()));

                    }
                    textBox_importe_actual.Text = importe_total_cargado.ToString();
                }
                else if (id_tipo_reparto_cargado == "2")
                {
                    String sqlSelectDivision = "SELECT com_opdetbloques.IdOpBloque, com_divisiones.Division, com_opdetbloques.Porcentaje, com_opdetbloques.Importe, com_opdetbloques.IdDivision FROM com_opdetbloques INNER JOIN com_divisiones ON com_opdetbloques.IdDivision = com_divisiones.IdDivision WHERE(((com_opdetbloques.IdOp) = " + id_operacion_cargado + "));";

                    DataTable repartos = Persistencia.SentenciasSQL.select(sqlSelectDivision);

                    for (int a = 0; a < repartos.Rows.Count; a++)
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView_reparto.Rows[0].Clone();
                        row.Cells[0].Value = repartos.Rows[a][0].ToString();
                        row.Cells[1].Value = repartos.Rows[a][1];
                        row.Cells[4].Value = repartos.Rows[a][4];

                        decimal porcentaje = Convert.ToDecimal(string.Format("{0:F2}", repartos.Rows[a][2].ToString())) * 100;
                        row.Cells[2].Value = porcentaje.ToString();

                        row.Cells[3].Value = repartos.Rows[a][3].ToString();
                        dataGridView_reparto.Rows.Add(row);
                        importe_total_cargado = importe_total_cargado + Convert.ToDecimal(string.Format("{0:F2}", repartos.Rows[a][3].ToString()));
                    }
                    textBox_importe_actual.Text = importe_total_cargado.ToString();
                }
                else if (id_tipo_reparto_cargado == "3")
                {
                    String sqlSelectEntidad = "SELECT com_opdetbloques.IdOpBloque, ctos_entidades.Entidad, com_opdetbloques.Porcentaje, com_opdetbloques.Importe, com_opdetbloques.IdEntidad FROM com_opdetbloques INNER JOIN ctos_entidades ON com_opdetbloques.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_opdetbloques.IdOp) = " + id_operacion_cargado + "));";

                    DataTable repartos = Persistencia.SentenciasSQL.select(sqlSelectEntidad);

                    for (int a = 0; a < repartos.Rows.Count; a++)
                    {
                        DataGridViewRow row = (DataGridViewRow)dataGridView_reparto.Rows[0].Clone();
                        row.Cells[0].Value = repartos.Rows[a][0].ToString();
                        row.Cells[1].Value = repartos.Rows[a][1];
                        row.Cells[4].Value = repartos.Rows[a][4];

                        decimal porcentaje = Convert.ToDecimal(string.Format("{0:F2}", repartos.Rows[a][2].ToString())) * 100;
                        row.Cells[2].Value = porcentaje.ToString();

                        row.Cells[3].Value = repartos.Rows[a][3].ToString();
                        dataGridView_reparto.Rows.Add(row);
                        importe_total_cargado = importe_total_cargado + Convert.ToDecimal(string.Format("{0:F2}", repartos.Rows[a][3].ToString()));
                    }
                    textBox_importe_actual.Text = importe_total_cargado.ToString();
                }
            }
        }
        private void dataGridView_reparto_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            decimal importe_total_cargado2 = Convert.ToDecimal(0.00);
            if (e.ColumnIndex == 2)
            {
                if (dataGridView_reparto.Rows[e.RowIndex].Cells[2].Value != null && dataGridView_reparto.Rows[e.RowIndex].Cells[2].Value.ToString() != "")
                {
                    decimal porcentaje = Convert.ToDecimal(dataGridView_reparto.Rows[e.RowIndex].Cells[2].Value);
                    decimal importe = Convert.ToDecimal(string.Format("{0:F2}", importe_pasado));
                    decimal total = Convert.ToDecimal(string.Format("{0:F2}", importe * porcentaje / 100));

                    dataGridView_reparto.Rows[e.RowIndex].Cells[3].Value = total;
                }
            }else if (e.ColumnIndex == 3) {
                decimal celda = Convert.ToDecimal(dataGridView_reparto.Rows[e.RowIndex].Cells[3].Value.ToString().Replace(".",","));
                decimal importe = Convert.ToDecimal(string.Format("{0:F2}", importe_pasado));
                decimal total = Convert.ToDecimal(string.Format("{0:F2}", celda * 100 / importe));
                dataGridView_reparto.Rows[e.RowIndex].Cells[2].Value = total;
            }


           
            for (int a = 0; a < dataGridView_reparto.Rows.Count; a++) {
                if (dataGridView_reparto.Rows[a].Cells[3].Value != null) {
                    importe_total_cargado2 = importe_total_cargado2 + Convert.ToDecimal(dataGridView_reparto.Rows[a].Cells[3].Value.ToString().Replace('.',','));
                    textBox_importe_actual.Text = importe_total_cargado2.ToString().Replace('.',',');
                }
            }
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (filas_eliminadas.Count > 0)
            {
                eliminar_filas();
            }
            if (comprobarImporte())  {
                for (int a = 0; a < dataGridView_reparto.Rows.Count; a++) {
                    if (dataGridView_reparto.Rows[a].Cells[3].Value != null && dataGridView_reparto.Rows[a].Cells[0].Value != null) {
                        actualizar_filasReparto(dataGridView_reparto.Rows[a].Cells[0].Value.ToString(), dataGridView_reparto.Rows[a].Cells[4].Value.ToString(), dataGridView_reparto.Rows[a].Cells[2].Value.ToString(), dataGridView_reparto.Rows[a].Cells[3].Value.ToString());
                    }
                    else if (dataGridView_reparto.Rows[a].Cells[3].Value != null && dataGridView_reparto.Rows[a].Cells[0].Value == null)
                    {
                        insertar_filasReparto(dataGridView_reparto.Rows[a].Cells[4].Value.ToString(),dataGridView_reparto.Rows[a].Cells[2].Value.ToString(), dataGridView_reparto.Rows[a].Cells[3].Value.ToString());
                    }
                }
                if (vengoDePantallaVer)
                {
                    form_anterior.cargarOperacion(id_operacion_cargado);
                }
                else
                {
                    FormOperacionesVencimientos nueva = new FormOperacionesVencimientos(id_comunidad_cargado, id_operacion_cargado, textBox_importe_actual.Text);
                    nueva.Show();
                }
                guardada = "si";
                this.Close();
            }else {
                MessageBox.Show("Revise los importes, el total es : " + textBox_importe_actual.Text + " y debe ser " + textBox_importe_op.Text);
            }
        }
       
        private void insertar_filasReparto(String id, String porcentaje, String importe)
        {
            if (importe != "0")
            {
                decimal porcentaje_2 = Convert.ToDecimal(string.Format("{0:F2}", porcentaje));
                decimal porcentaje_1 = porcentaje_2 / 100;

                if (id_tipo_reparto_cargado == "1") {
                    String sqlInsert = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES(" + id_operacion_cargado + ", " + id + ", " + Logica.FuncionesGenerales.ArreglarImportes(porcentaje_1.ToString()) + ", " + Logica.FuncionesGenerales.ArreglarImportes(importe) + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }else if (id_tipo_reparto_cargado == "2") {
                    String sqlInsert = "INSERT INTO com_opdetbloques (IdOp, IdDivision, Porcentaje, Importe) VALUES(" + id_operacion_cargado + ", " + id + ", " + Logica.FuncionesGenerales.ArreglarImportes(porcentaje_1.ToString()) + ", " + Logica.FuncionesGenerales.ArreglarImportes(importe) + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
                else if (id_tipo_reparto_cargado == "3") {
                    String sqlInsert = "INSERT INTO com_opdetbloques (IdOp, IdEntidad, Porcentaje, Importe) VALUES(" + id_operacion_cargado + ", " + id + ", " + Logica.FuncionesGenerales.ArreglarImportes(porcentaje_1.ToString()) + ", " + Logica.FuncionesGenerales.ArreglarImportes(importe) + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
            }
        }

        private void actualizar_filasReparto(String id_reparto, String id, String porcentaje, String importe)
        {
            if (importe != "0")
            {
                decimal porcentaje_2 = Convert.ToDecimal(string.Format("{0:F2}", porcentaje));
                decimal porcentaje_1 = porcentaje_2 / 100;
                if (id_tipo_reparto_cargado == "1") {
                    String sqlUpdate = "UPDATE com_opdetbloques SET IdBloque=" + id + ",Porcentaje=" + Logica.FuncionesGenerales.ArreglarImportes((porcentaje_1).ToString()) + ", Importe=" + Logica.FuncionesGenerales.ArreglarImportes(importe) + " WHERE IdOpBloque = " + id_reparto;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }else if (id_tipo_reparto_cargado == "2") {
                    String sqlUpdate = "UPDATE com_opdetbloques SET IdDivision=" + id + ",Porcentaje=" + Logica.FuncionesGenerales.ArreglarImportes((porcentaje_1).ToString()) + ", Importe=" + Logica.FuncionesGenerales.ArreglarImportes(importe) + " WHERE IdOpBloque = " + id_reparto;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                else if (id_tipo_reparto_cargado == "3") {
                    String sqlUpdate = "UPDATE com_opdetbloques SET IdEntidad=" + id + ",Porcentaje=" + Logica.FuncionesGenerales.ArreglarImportes((porcentaje_1).ToString()) + ", Importe=" + Logica.FuncionesGenerales.ArreglarImportes(importe) + " WHERE IdOpBloque = " + id_reparto;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
            }
        }
        private void eliminar_filas()
        {
            for (int a = 0; a < filas_eliminadas.Count; a++)
            {
                String sqlDelete = "DELETE FROM com_opdetbloques WHERE IdOpBloque = " + filas_eliminadas[a];
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
            }
        }
        public Boolean comprobarImporte() {
            if (Convert.ToDouble(textBox_importe_actual.Text).Equals(Convert.ToDouble(textBox_importe_op.Text)))
                return true;
            else
                return false;
        }
        public void recogerBloque(String id_bloque,String nombre_bloque) {
            dataGridView_reparto.Rows[dataGridView_reparto.CurrentRow.Index].Cells[1].Value = nombre_bloque;
            dataGridView_reparto.Rows[dataGridView_reparto.CurrentRow.Index].Cells[2].Value = 100;
            dataGridView_reparto.Rows[dataGridView_reparto.CurrentRow.Index].Cells[3].Value = importe_pasado;
            dataGridView_reparto.Rows[dataGridView_reparto.CurrentRow.Index].Cells[4].Value = id_bloque;
            button_guardar.Select();
        }

        private void dataGridView_reparto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            abrirSubformulario();
        }
        private void abrirSubformulario() {
            if (dataGridView_reparto.CurrentCell.ColumnIndex == 1)
            {
                if (id_tipo_reparto_cargado == "1")
                {
                    id_comunidad_cargado = (Persistencia.SentenciasSQL.select("SELECT IdComunidad FROM com_operaciones WHERE com_operaciones.IdOp = " + id_operacion_cargado + ";")).Rows[0][0].ToString();

                    BloquesForms.Bloques nueva = new BloquesForms.Bloques(this, this.Name, id_comunidad_cargado);
                    nueva.ControlBox = true;
                    nueva.TopMost = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    dataGridView_reparto.ClearSelection();
                    dataGridView_reparto.Rows[dataGridView_reparto.CurrentRow.Index].Selected = true;
                    nueva.Show();

                }
                else if (id_tipo_reparto_cargado == "2")
                {
                    Divisiones nueva = new Divisiones(Convert.ToInt32(id_comunidad_cargado), this.Name, this);
                    nueva.ControlBox = true;
                    nueva.TopMost = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    dataGridView_reparto.ClearSelection();
                    dataGridView_reparto.Rows[dataGridView_reparto.CurrentRow.Index].Selected = true;
                    nueva.Show();
                }
                else if (id_tipo_reparto_cargado == "3")
                {
                    Entidades nueva = new Entidades(this, this.Name);
                    nueva.ControlBox = true;
                    nueva.TopMost = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    nueva.textBox_buscar_nombre.Select();
                    nueva.dataGridView1.TabIndex = 2;
                    nueva.textBox_buscar_nombre.TabIndex = 1;
                    nueva.Show();
                }
            }
        }

        private void dataGridView_reparto_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            filas_eliminadas.Add(e.Row.Cells[0].Value.ToString());
        }

        private void dataGridView_reparto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Tab)
            {
                if (dataGridView_reparto.CurrentRow.IsNewRow == true && dataGridView_reparto.Rows.Count > 1)
                {
                    dataGridView_reparto.ClearSelection();
                    button_guardar.Select();
                }
            }else if (e.KeyChar == (Char)Keys.Space || e.KeyChar == (Char)Keys.Enter) {
                abrirSubformulario();
            }
        }
        private void CerrarborrarOperacionEnCurso() {
            if (!vengoDePantallaVer)
            {
                //BORRO LOS IVAS
                String sqlDeleteIVA = "DELETE FROM com_opdetiva WHERE IdOp = " + id_operacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteIVA);


                //TENGO QUE BORRAR LO ANTERIOR
                String sqlDelete = "DELETE FROM com_operaciones WHERE IdOp = " + id_operacion_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
                MessageBox.Show("Operación Borrada");
            }

        }
        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormOperacionesEditReparto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (guardada == "no")
                CerrarborrarOperacionEnCurso();
        }
    }
}
