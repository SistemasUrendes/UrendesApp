using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.BloquesForms
{
    public partial class Bloques : Form
    {
        String id_comunidad_cargado;
        DataTable bloques;
        String nombre_form_cargado = "";
        Form form_anterior = null;
        
        public Bloques(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        public Bloques(Form form_anterior, String nombre_form_cargado, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
            this.nombre_form_cargado = nombre_form_cargado;
        }

        private void Bloques_Load(object sender, EventArgs e)
        {
            if (nombre_form_cargado != "") {
                button_Añadir.Visible = false;
                button_Borrar.Visible = false;
                button_EditarBloque.Visible = false;
                button_enviar.Visible = true;
            }
            cargarBloques();
            textBox_buscar.Select();
            comboBox_FiltroBloques.SelectedIndex = 0;
        }
        private void enviarOtroForm()
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_form_cargado)).SingleOrDefault<Form>();
            if (existe != null)
            {
                if (nombre_form_cargado == "FormOperacionesEditReparto")
                {
                    OperacionesForms.FormOperacionesEditReparto nuevo = (OperacionesForms.FormOperacionesEditReparto)existe;
                    nuevo.recogerBloque(dataGridView_bloques.SelectedCells[0].Value.ToString(),dataGridView_bloques.SelectedCells[1].Value.ToString());
                }

                if (nombre_form_cargado == "FormProvisionesAlta")
                {
                    ProvisionesForms.FormProvisionesAlta nuevo = (ProvisionesForms.FormProvisionesAlta)existe;
                    nuevo.recogerBloque(dataGridView_bloques.SelectedCells[0].Value.ToString(),dataGridView_bloques.SelectedCells[1].Value.ToString());
                }

                if (nombre_form_cargado == "FormFondosAlta")
                {
                    FondosForms.FormFondosAlta nuevo = (FondosForms.FormFondosAlta)existe;
                    nuevo.recogerBloque(dataGridView_bloques.SelectedCells[0].Value.ToString(),dataGridView_bloques.SelectedCells[1].Value.ToString());
                }
                if (nombre_form_cargado == "FormOperacionesListadoProveedores")
                {
                    OperacionesForms.FormOperacionesListadoProveedores nuevo = (OperacionesForms.FormOperacionesListadoProveedores)existe;
                    nuevo.recogerBloque(dataGridView_bloques.SelectedCells[0].Value.ToString());
                }
                if (nombre_form_cargado == "FormNuevoCargos")
                {
                    CargosForms.FormNuevoCargos nuevo = (CargosForms.FormNuevoCargos)existe;
                    nuevo.recogerBloque(dataGridView_bloques.SelectedCells[0].Value.ToString(), dataGridView_bloques.SelectedCells[1].Value.ToString());
                }
            }
            this.Close();
        }
        private void ajustarDatagrid() {
            dataGridView_bloques.Columns["GG"].Width = 31;
            dataGridView_bloques.Columns["Baja"].Width = 35;
            dataGridView_bloques.Columns["Fisico"].Width = 38;
            dataGridView_bloques.Columns["Descripcion"].Width = 270;
            dataGridView_bloques.Columns["Cuenta"].Width = 100;
            dataGridView_bloques.Columns["Cuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_bloques.Columns["Partes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_bloques.Columns["IdBloque"].Width = 53;
            dataGridView_bloques.Columns["CG"].DefaultCellStyle.Format = "p";
            dataGridView_bloques.Columns["CG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_bloques.Columns["CálculoSubcuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_bloques.Columns["IdBloque"].Visible = false;
            dataGridView_bloques.Columns["IdTipoSubcuota"].Visible = false;
        }
        public void cargarBloques() {
            String sql = "SELECT com_bloques.IdBloque, com_bloques.Descripcion, com_tipoSubcuota.Descripcion AS CálculoSubcuota, Sum(com_divisiones.Cuota) AS CG, Count(com_subcuotas.IdDivision) AS Cuenta, Sum(com_subcuotas.Parte) AS Partes, com_bloques.GG, com_bloques.Baja, com_bloques.IdTipoSubcuota, com_bloques.Fisica AS Fisico FROM((com_bloques LEFT JOIN com_tipoSubcuota ON com_bloques.IdTipoSubcuota = com_tipoSubcuota.IdTipoSubcuota) LEFT JOIN com_subcuotas ON com_bloques.IdBloque = com_subcuotas.IdBloque) LEFT JOIN com_divisiones ON com_subcuotas.IdDivision = com_divisiones.IdDivision GROUP BY com_bloques.IdBloque, com_bloques.Descripcion, com_tipoSubcuota.Descripcion, com_bloques.GG, com_bloques.Baja, com_bloques.IdTipoSubcuota, com_bloques.CalculoSubcuota, com_bloques.IdComunidad, com_bloques.IdTipoBloque HAVING(((com_bloques.IdComunidad) = " + id_comunidad_cargado + ") AND((com_bloques.IdTipoBloque) = 1)) ORDER BY com_bloques.Descripcion;";


            bloques = Persistencia.SentenciasSQL.select(sql);
            dataGridView_bloques.DataSource = bloques;
            DataTable busqueda = bloques;
            busqueda.DefaultView.RowFilter = "Baja = False";
            dataGridView_bloques.DataSource = busqueda;

            ajustarDatagrid();
        }
        private void comboBox_FiltroBloques_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            if (senderComboBox.SelectedItem.ToString() == "Ver Todos") {
                cargarBloques();
            }
            else if (senderComboBox.SelectedItem.ToString() == "Activados") {
                DataTable busqueda = bloques;
                busqueda.DefaultView.RowFilter = "Baja = False";
                dataGridView_bloques.DataSource = busqueda;
            }
            else if (senderComboBox.SelectedItem.ToString() == "Desactivados") {
                DataTable busqueda = bloques;
                busqueda.DefaultView.RowFilter = "Baja = True";
                dataGridView_bloques.DataSource = busqueda;
            } else if (senderComboBox.SelectedItem.ToString() == "Bloque General") {
                DataTable busqueda = bloques;
                busqueda.DefaultView.RowFilter = "GG = True";
                dataGridView_bloques.DataSource = busqueda;
            }
        }

        private void button_EditarBloque_Click(object sender, EventArgs e)
        {
            FormBloquesAlta nueva = new FormBloquesAlta(this,id_comunidad_cargado,dataGridView_bloques.SelectedCells[0].Value.ToString(),dataGridView_bloques.SelectedCells[1].Value.ToString(), dataGridView_bloques.SelectedCells[5].Value.ToString(), dataGridView_bloques.SelectedCells[7].Value.ToString(), dataGridView_bloques.SelectedCells[8].Value.ToString(), dataGridView_bloques.SelectedCells[9].Value.ToString());

            nueva.Show();
        }

        private void button_Añadir_Click(object sender, EventArgs e)
        {
            FormBloquesAlta nueva = new FormBloquesAlta(this, id_comunidad_cargado);
            nueva.Show();
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este Bloque ?", "Borrar Bloque", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_bloques WHERE IdBloque = " + dataGridView_bloques.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarBloques();
            }
        }

        private void subCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBloquesDetalles nueva = new FormBloquesDetalles(this,dataGridView_bloques.SelectedCells[0].Value.ToString(), dataGridView_bloques.SelectedCells[1].Value.ToString(),id_comunidad_cargado, dataGridView_bloques.SelectedRows[0].Cells[8].Value.ToString());
            nueva.Show();
        }

        private void dataGridView_bloques_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_bloques.HitTest(e.X, e.Y);
                dataGridView_bloques.ClearSelection();
                dataGridView_bloques.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip_Bloques.Show(Cursor.Position);
            }
        }

        private void dataGridView_bloques_DoubleClick(object sender, EventArgs e)
        {
            FormBloquesDetalles nueva = new FormBloquesDetalles(this,dataGridView_bloques.SelectedCells[0].Value.ToString(), dataGridView_bloques.SelectedCells[1].Value.ToString(),id_comunidad_cargado, dataGridView_bloques.SelectedRows[0].Cells[8].Value.ToString());
            nueva.Show();
        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            enviarOtroForm();
        }

        private void dataGridView_bloques_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter && dataGridView_bloques.SelectedRows.Count > 0) {
                dataGridView_bloques.Rows[dataGridView_bloques.CurrentRow.Index - 1].Selected = true;
                enviarOtroForm();
            }
        }

        private void dataGridView_bloques_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView_bloques.SelectedRows.Count > 0)
            {
                e.SuppressKeyPress = true;
                enviarOtroForm();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_buscar.TextLength < 1)
            {
                DataTable busqueda = bloques;
                busqueda.DefaultView.RowFilter = "Descripcion like '%%'";
                this.dataGridView_bloques.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = bloques;
                busqueda.DefaultView.RowFilter = "Descripcion like '%" + textBox_buscar.Text + "%'";
                this.dataGridView_bloques.DataSource = busqueda;
            }
        }

        private void textBox_buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dataGridView_bloques.SelectedRows.Count > 0) {
                e.SuppressKeyPress = true;
                enviarOtroForm();
            }
        }
    }
}
