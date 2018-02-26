using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms
{
    public partial class Liquidaciones : Form
    {
        String id_comunidad_cargado;
        Form form_anterior = null;
        String nombre_form_anterior = "";
        DataTable liquidaciones;

        public Liquidaciones(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        public Liquidaciones(Form form_anterior, String nombre_form_anterior, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
            this.nombre_form_anterior = nombre_form_anterior;
        }
        private void enviarOtroForm()
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_form_anterior)).SingleOrDefault<Form>();
            if (existe != null)
            {
                if (nombre_form_anterior == "FormOperacionesLiquidacion")
                {
                    OperacionesForms.FormOperacionesLiquidacion nuevo = (OperacionesForms.FormOperacionesLiquidacion)existe;
                    nuevo.recogerBloque(dataGridView_Liquidaciones.SelectedCells[0].Value.ToString(), dataGridView_Liquidaciones.SelectedCells[8].Value.ToString());
                }

                if (nombre_form_anterior == "FormProvisionesDotarAplicar2")
                {
                    ProvisionesForms.FormProvisionesDotarAplicar2 nuevo = (ProvisionesForms.FormProvisionesDotarAplicar2)existe;
                    nuevo.recogerBloque(dataGridView_Liquidaciones.SelectedCells[0].Value.ToString(), dataGridView_Liquidaciones.SelectedCells[8].Value.ToString());
                }
            }
            this.Close();
        }
        private void Liquidaciones_Load(object sender, EventArgs e)
        {
            if (nombre_form_anterior != "") {
                button_enviar.Visible = true;
                button_Borrar.Visible = false;
                button_Añadir.Visible = false;
                button_Editar.Visible = false;
            }
            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String sql = "SELECT com_liquidaciones.IdLiquidacion, com_fondos.NombreFondo, com_ejercicios.Ejercicio, com_liquidaciones.LiqLargo, com_liquidaciones.Liquidacion, com_liquidaciones.FIni, com_liquidaciones.FFin, aux_tipoliquidacion.TipoLiq, com_liquidaciones.Ppal, com_liquidaciones.Cerrada FROM(((com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio) INNER JOIN aux_tipoliquidacion ON com_liquidaciones.IdTipoLiq = aux_tipoliquidacion.IdTipoLiq) LEFT JOIN com_detallesfondo ON com_liquidaciones.IdDetalleFondo = com_detallesfondo.IdDetalleFondo) LEFT JOIN com_fondos ON com_detallesfondo.IdFondo = com_fondos.IdFondo WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + ")) ORDER BY com_liquidaciones.IdLiquidacion DESC;";

            liquidaciones = Persistencia.SentenciasSQL.select(sql);
            dataGridView_Liquidaciones.DataSource = liquidaciones;
            dataGridView_Liquidaciones.Columns["FIni"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView_Liquidaciones.Columns["FFin"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView_Liquidaciones.Columns["Cerrada"].Width = 50;
            dataGridView_Liquidaciones.Columns["Ppal"].Width = 40;
            dataGridView_Liquidaciones.Columns["IdLiquidacion"].Width = 60;
            dataGridView_Liquidaciones.Columns["LiqLargo"].Width = 208;
            dataGridView_Liquidaciones.Columns["FIni"].Width = 70;
            dataGridView_Liquidaciones.Columns["FFin"].Width = 70;
            dataGridView_Liquidaciones.Columns["Ejercicio"].Visible = false;
            //dataGridView_Liquidaciones.Columns["Liquidacion"].Visible = false;

            DataTable busqueda = liquidaciones;
            busqueda.DefaultView.RowFilter = "Cerrada = 'False'";
            this.dataGridView_Liquidaciones.DataSource = busqueda;

            comboBox_filtro.SelectedItem = "Abiertas";


        }

        private void button_Añadir_Click(object sender, EventArgs e)
        {
            FormLiquidacionesAlta nueva = new FormLiquidacionesAlta(this,id_comunidad_cargado);
            nueva.Show();
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            FormLiquidacionesAlta nueva = new FormLiquidacionesAlta(this, id_comunidad_cargado,dataGridView_Liquidaciones.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta Liquidación ?", "Borrar Liquidación", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_liquidaciones WHERE IdLiquidacion =  " + dataGridView_Liquidaciones.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarDatagrid();
            }
        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            enviarOtroForm();
        }

        private void comboBox_filtro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //  """CerradasAbiertasTodas""""
            
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedItem.ToString() == "Cerradas") {
                DataTable busqueda = liquidaciones;
                busqueda.DefaultView.RowFilter = "Cerrada = 'True'";
                this.dataGridView_Liquidaciones.DataSource = busqueda;
            }
           else if (combo.SelectedItem.ToString() == "Abiertas") {
                DataTable busqueda = liquidaciones;
                busqueda.DefaultView.RowFilter = "Cerrada = 'False'";
                this.dataGridView_Liquidaciones.DataSource = busqueda;
            }
           else if (combo.SelectedItem.ToString() == "Todas") {
                DataTable busqueda = liquidaciones;
                busqueda.DefaultView.RowFilter = "Cerrada = 'True' OR Cerrada = 'False'";
                this.dataGridView_Liquidaciones.DataSource = busqueda;
            }
        }

        private void dataGridView_Liquidaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter && dataGridView_Liquidaciones.SelectedRows.Count > 0)
            {
                if (dataGridView_Liquidaciones.Rows.Count > 1) {
                    dataGridView_Liquidaciones.Rows[dataGridView_Liquidaciones.CurrentRow.Index - 1].Selected = true;
                }else if (dataGridView_Liquidaciones.Rows.Count == 1) {
                    dataGridView_Liquidaciones.Rows[dataGridView_Liquidaciones.CurrentRow.Index].Selected = true;
                }else if (dataGridView_Liquidaciones.Rows.Count == 0) {
                    MessageBox.Show("No hay liquidaciones creadas debes crear una primero");
                    this.Close();
                }
                    enviarOtroForm();
            }
        }

        private void verGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGastosReparto nueva = new FormGastosReparto(id_comunidad_cargado,dataGridView_Liquidaciones.SelectedRows[0].Cells[0].Value.ToString());
            nueva.Show();
        }

        private void verRepartoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLiquidacionReparto nueva = new FormLiquidacionReparto(id_comunidad_cargado, dataGridView_Liquidaciones.SelectedRows[0].Cells[0].Value.ToString(), dataGridView_Liquidaciones.SelectedRows[0].Cells[9].Value.ToString(), dataGridView_Liquidaciones.SelectedRows[0].Cells[4].Value.ToString());
            nueva.Show();
        }

        private void dataGridView_Liquidaciones_MouseClick(object sender, MouseEventArgs e)
        {
            //SOLO MOSTRAR LOS NECESARIOS
            quitarPrincipalToolStripMenuItem.Visible = false;
            establecerPrincipalToolStripMenuItem.Visible = false;
            abrirLiquidaciónToolStripMenuItem.Visible = false;
            cerrarLiquidaciónToolStripMenuItem.Visible = false;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_Liquidaciones.HitTest(e.X, e.Y);
                dataGridView_Liquidaciones.ClearSelection();
                try
                {
                    dataGridView_Liquidaciones.Rows[hti.RowIndex].Selected = true;
                }catch {
                    dataGridView_Liquidaciones.Rows[0].Selected = true;
                }

                //PRINCIPAL
                if (dataGridView_Liquidaciones.SelectedRows[0].Cells[8].Value.ToString() == "True") {
                    establecerPrincipalToolStripMenuItem.Visible = false;
                }
                else {
                    establecerPrincipalToolStripMenuItem.Visible = true;
                }

                //CERRAR
                if (dataGridView_Liquidaciones.SelectedRows[0].Cells[9].Value.ToString() == "True")  {
                    abrirLiquidaciónToolStripMenuItem.Visible = true;
                }
                else  {
                    cerrarLiquidaciónToolStripMenuItem.Visible = true;
                }

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void establecerPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Liquidaciones.SelectedRows.Count > 0) {
                String sqlCuentaPal = "SELECT Count(com_liquidaciones.IdLiquidacion) AS CuentaDeIdLiquidacion FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio GROUP BY com_ejercicios.IdComunidad, com_liquidaciones.Ppal HAVING(((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + ") AND((com_liquidaciones.Ppal) = -1));";
                DataTable lipal = Persistencia.SentenciasSQL.select(sqlCuentaPal);
                if (lipal.Rows.Count > 0)
                {
                    String numPal = lipal.Rows[0][0].ToString();
                    if (numPal != "0")
                    {
                        DialogResult resultado_message;
                        resultado_message = MessageBox.Show("Existe otra liquidacion como principal. ¿ Desea continuar ? ", "¿ Continuar ?", MessageBoxButtons.OKCancel);
                        if (resultado_message == System.Windows.Forms.DialogResult.OK)
                        {
                            String sqlUpdateTodas = "UPDATE com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio SET com_liquidaciones.Ppal = 0 WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad_cargado + "));";
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateTodas);

                            String sqlUpdatePal = "UPDATE com_liquidaciones SET Ppal = -1 WHERE IdLiquidacion = " + dataGridView_Liquidaciones.SelectedRows[0].Cells[0].Value.ToString();
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdatePal);
                        }
                    }
                    else
                    {
                        String sqlUpdatePal = "UPDATE com_liquidaciones SET Ppal = -1 WHERE IdLiquidacion = " + dataGridView_Liquidaciones.SelectedRows[0].Cells[0].Value.ToString();
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdatePal);
                    }
                }
                this.cargarDatagrid();
            }else {
                MessageBox.Show("Selecciona una liquidación");
            }
        }

        private void cerrarLiquidaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Liquidaciones.SelectedRows.Count > 0)
            {
                //String sqlCerrada = "SELECT com_liquidaciones.IdLiquidacion FROM com_liquidaciones WHERE(((com_liquidaciones.IdLiquidacion) = " + dataGridView_Liquidaciones.SelectedRows[0].Cells[0].Value.ToString() + ") AND((com_liquidaciones.Ppal) = -1));";

                //DataTable CerradaPal = Persistencia.SentenciasSQL.select(sqlCerrada);

                //if (CerradaPal.Rows.Count > 0) {
                //    MessageBox.Show("No se puede cerrar porque esta como principal. Seleccione otra como principal");
                //}else {
                    String sqlCerrar = "UPDATE com_liquidaciones SET com_liquidaciones.Cerrada = -1 WHERE(((com_liquidaciones.IdLiquidacion) = " + dataGridView_Liquidaciones.SelectedRows[0].Cells[0].Value.ToString() + "));";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlCerrar);
                //}
                cargarDatagrid();
            }
        }

        private void abrirLiquidaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlAbrirLiquidacion = "UPDATE com_liquidaciones SET Cerrada= 0 WHERE IdLiquidacion = " + dataGridView_Liquidaciones.SelectedRows[0].Cells[0].Value.ToString();
            Persistencia.SentenciasSQL.InsertarGenerico(sqlAbrirLiquidacion);
            cargarDatagrid();
        }

        private void comboBox_informes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_informes.SelectedIndex == 0) {
                Informes.FormVerInformeResumen nueva = new Informes.FormVerInformeResumen(id_comunidad_cargado, dataGridView_Liquidaciones.SelectedRows[0].Cells[0].Value.ToString());
                nueva.Show();
            }
            else if (comboBox_informes.SelectedIndex == 1) {
                Informes.FormVerInformeDetallado nueva = new Informes.FormVerInformeDetallado(dataGridView_Liquidaciones.SelectedRows[0].Cells[0].Value.ToString());
                nueva.Show();
            }
        }

        private void añadirNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAnyadirNotaLiq nueva = new FormAnyadirNotaLiq(dataGridView_Liquidaciones.SelectedRows[0].Cells[0].Value.ToString());
            nueva.Show();
        }
    }
}
    