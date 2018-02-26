using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    public partial class FormComuneroReglas : Form
    {
        String nombre_comunero;
        String id_comunero;

        public FormComuneroReglas(String nombre_comunero, String id_comunero)
        {
            InitializeComponent();
            this.nombre_comunero = nombre_comunero;
            this.id_comunero = id_comunero;
        }

        private void FormComuneroReglas_Load(object sender, EventArgs e)
        {
            textBox_Entidad.Text = nombre_comunero;
            cargarDatagrid();
        }
        public void cargarDatagrid() {

            String sql = "SELECT com_reglasrec.IdReglaRec, com_reglasrec.RefRegla, com_reglasrec.Descripcion, ctos_entidades.NombreCorto, aux_formapago.FormaPago, ctos_detbancos.Descripcion, com_reglasrec.Activa FROM (((com_reglasrec INNER JOIN com_comuneros ON com_reglasrec.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN aux_formapago ON com_reglasrec.IdFormaPago = aux_formapago.IdFormaPago) INNER JOIN ctos_detbancos ON com_reglasrec.IdCC = ctos_detbancos.IdCuenta WHERE(((com_reglasrec.IdComunero) = " + id_comunero + "));";

            dataGridView_ListaReglas.DataSource = Persistencia.SentenciasSQL.select(sql);

            String sql2 = "SELECT com_asociacion.IdAsociacion, com_divisiones.IdDivision, com_divisiones.Division, ctos_entidades.NombreCorto, `com_tipoasociacion`.`TipoAsociación`, com_asociacion.IdReglaRec FROM(((com_asociacion INNER JOIN com_tipoasociacion ON com_asociacion.IdTipoAsoc = com_tipoasociacion.IdTipoAsoc) INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_divisiones ON com_asociacion.IdDivision = com_divisiones.IdDivision WHERE(((com_asociacion.IdComunero) = " + id_comunero + " )); ";

            dataGridView_DivisionRegla.DataSource = Persistencia.SentenciasSQL.select(sql2);
            dataGridView_DivisionRegla.Columns[2].Width = 200;
            dataGridView_DivisionRegla.Columns["IdDivision"].Visible = false;
            dataGridView_DivisionRegla.Columns["NombreCorto"].Visible = false;
            dataGridView_DivisionRegla.Columns["TipoAsociación"].Visible = false;
            dataGridView_DivisionRegla.ClearSelection();
            pintarRojo();
            

        }

        private void pintarRojo() {
            for (int b = 0; b < dataGridView_DivisionRegla.Rows.Count; b++)
            {
                if (dataGridView_DivisionRegla.Rows[b].Cells["IdReglaRec"].Value.ToString() != "")
                {
                    dataGridView_DivisionRegla.Rows[b].DefaultCellStyle.BackColor = Color.Green;
                    dataGridView_DivisionRegla.Rows[b].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        private void button_Añadir_Click(object sender, EventArgs e) {
            FormComuneroReglasAlta nueva = new FormComuneroReglasAlta(this,id_comunero);
            nueva.Show();
        }
        
        private void button_Editar_Click(object sender, EventArgs e) {
            FormComuneroReglasAlta nueva = new FormComuneroReglasAlta(this,id_comunero, dataGridView_ListaReglas.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            if (dataGridView_ListaReglas.Rows.Count > 0)  {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar esta regla ?", "Borrar Regla", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    comprobarReglaEnDivisiones();
                    String sqlBorrar = "DELETE FROM com_reglasrec WHERE IdReglaRec = " + dataGridView_ListaReglas.SelectedCells[0].Value;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    cargarDatagrid();
                }
            }
        }
        private void comprobarReglaEnDivisiones() {
            String sql = "SELECT com_asociacion.IdAsociacion, com_asociacion.IdReglaRec FROM com_asociacion WHERE com_asociacion.IdReglaRec = " + dataGridView_ListaReglas.SelectedCells[0].Value;
            DataTable pendientes = Persistencia.SentenciasSQL.select(sql);
            
            
            if (pendientes.Rows.Count > 0) {
                String UpdateSql = "UPDATE com_asociacion SET IdReglaRec = NULL WHERE IdAsociacion = " + pendientes.Rows[0][0].ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(UpdateSql);
                MessageBox.Show("Limpiado de las Divisiones");
            }       

        }
        private void dataGridView_DivisionRegla_DoubleClick(object sender, EventArgs e)  {

            FormComuneroReglasDivision nueva = new FormComuneroReglasDivision(this,dataGridView_DivisionRegla.SelectedCells[1].Value.ToString(), dataGridView_DivisionRegla.SelectedCells[2].Value.ToString(),id_comunero, dataGridView_DivisionRegla.SelectedCells[0].Value.ToString());
            nueva.Show();
        }
    }
}