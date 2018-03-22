using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.FondosForms
{
    public partial class FormFondos : Form
    {
        String id_comunidad_cargado;
        DataTable fondos;
        int curRow = -1;

        public FormFondos(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void FormFondos_Load(object sender, EventArgs e)
        {
            comboBox_Filtro.SelectedItem = "Todos";
            cargarDatagrid();

            if (dataGridView_Fondos.Rows.Count > 0) {
                cargarDatagridDetalles();
            }
        }

        private void ajustarDatagrid()
        {
            dataGridView_detallesFondos.Columns["NombreFondo"].Width = 210;
            dataGridView_detallesFondos.Columns["IdDetalleFondo"].Width = 60;

            dataGridView_detallesFondos.Columns["Entradas"].Width = 100;
            dataGridView_detallesFondos.Columns["Entradas"].DefaultCellStyle.Format = "c";

            dataGridView_detallesFondos.Columns["Salidas"].Width = 100;
            dataGridView_detallesFondos.Columns["Salidas"].DefaultCellStyle.Format = "c";

            //dataGridView_detallesFondos.Columns["PteProveedores"].Width = 100;
            //dataGridView_detallesFondos.Columns["PteProveedores"].DefaultCellStyle.Format = "c";

            //dataGridView_detallesFondos.Columns["PteComuneros"].Width = 100;
            //dataGridView_detallesFondos.Columns["PteComuneros"].DefaultCellStyle.Format = "c";

            dataGridView_detallesFondos.Columns["SaldoInicial"].Width = 100;
            dataGridView_detallesFondos.Columns["SaldoInicial"].DefaultCellStyle.Format = "c";

            dataGridView_detallesFondos.Columns["Resultado"].Width = 100;
            dataGridView_detallesFondos.Columns["Resultado"].DefaultCellStyle.Format = "c";

            dataGridView_detallesFondos.Columns["SaldoCierre"].Width = 100;
            dataGridView_detallesFondos.Columns["SaldoCierre"].DefaultCellStyle.Format = "c";

            dataGridView_detallesFondos.Columns["SaldoActual"].Width = 100;
            dataGridView_detallesFondos.Columns["SaldoActual"].DefaultCellStyle.Format = "c";
            dataGridView_detallesFondos.Columns["IdEjercicio"].Visible = false;
            dataGridView_detallesFondos.Columns["SaldoCierre"].HeaderText = "SaldoCierre";
            
        }

        public void cargarDatagrid() {
            String sqlSelect = "SELECT com_fondos.IdFondo, com_bloques.Descripcion, com_fondos.NombreFondo, com_fondos.IdSubCuenta, com_fondos.TITSUBCTA, com_fondos.Cierre FROM com_fondos INNER JOIN com_bloques ON com_fondos.IdBloque = com_bloques.IdBloque GROUP BY com_fondos.IdFondo, com_fondos.IdComunidad, com_bloques.Descripcion, com_fondos.NombreFondo, com_fondos.IdSubCuenta, com_fondos.TITSUBCTA HAVING(((com_fondos.IdComunidad) = " + id_comunidad_cargado + "));";

            fondos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_Fondos.DataSource = fondos;
            dataGridView_Fondos.Columns["Descripcion"].Width = 150;
            dataGridView_Fondos.Columns["NombreFondo"].Width = 200;
            dataGridView_Fondos.Columns["Descripcion"].HeaderText = "Bloque";
            
        }
        public void cargarDatagridDetalles()
        {
            String sqlSelect = "SELECT com_detallesfondo.IdDetalleFondo, com_fondos.NombreFondo, com_ejercicios.Ejercicio, com_detallesfondo.SaldoInicial, com_detallesfondo.Entradas, com_detallesfondo.Salidas, com_detallesfondo.SaldoActual, com_detallesfondo.Resultado, com_detallesfondo.SaldoCierre, com_ejercicios.IdEjercicio, com_detallesfondo.Cierre FROM(com_detallesfondo INNER JOIN com_fondos ON com_detallesfondo.IdFondo = com_fondos.IdFondo) INNER JOIN com_ejercicios ON com_detallesfondo.IdEjercicio = com_ejercicios.IdEjercicio WHERE com_detallesfondo.IdFondo = " + dataGridView_Fondos.SelectedRows[0].Cells[0].Value.ToString() + " ORDER BY Ejercicio DESC";

            dataGridView_detallesFondos.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            ajustarDatagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormFondosAlta nueva = new FormFondosAlta(this,id_comunidad_cargado);
            nueva.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormFondosAlta nueva = new FormFondosAlta(this, id_comunidad_cargado,dataGridView_Fondos.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este Fondo?", "Borrar Fondo", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {

                String sqlBorrarCuota = "DELETE FROM com_cuotas WHERE IdFondo = " + dataGridView_Fondos.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarCuota);

                String sqlBorrarLiquidacion = "DELETE FROM com_liquidaciones WHERE IdFondo = " + dataGridView_Fondos.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarLiquidacion);

                String sqlBorrar = "DELETE FROM com_fondos WHERE IdFondo =  " + dataGridView_Fondos.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);

                cargarDatagrid();
            }
        }

        private void comboBox_Filtro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox filtro = (ComboBox)sender;

            if (filtro.SelectedItem.ToString() == "Todos")
            {
                cargarDatagrid();
            }
            else if (filtro.SelectedItem.ToString() == "Inicial")
            {
                DataTable busqueda = fondos;
                busqueda.DefaultView.RowFilter = "IdSubCuenta like %10%";
                dataGridView_Fondos.DataSource = busqueda;
            }
            else if (filtro.SelectedItem.ToString() == "Reserva")
            {
                DataTable busqueda = fondos;
                busqueda.DefaultView.RowFilter = "IdSubCuenta like %11*%";
                dataGridView_Fondos.DataSource = busqueda;
            }
            else if (filtro.SelectedItem.ToString() == "Resultado")
            {
                DataTable busqueda = fondos;
                busqueda.DefaultView.RowFilter = "IdSubCuenta like %12*%";
                dataGridView_Fondos.DataSource = busqueda;
            }
            else if (filtro.SelectedItem.ToString() == "Voluntario")
            {
                DataTable busqueda = fondos;
                busqueda.DefaultView.RowFilter = "IdSubCuenta like %13*%";
                dataGridView_Fondos.DataSource = busqueda;
            }

        }

        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_Fondos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_Fondos.HitTest(e.X, e.Y);
                dataGridView_Fondos.ClearSelection();
                dataGridView_Fondos.Rows[hti.RowIndex].Selected = true;

                //String sqlSelect = "SELECT Count(com_detallesfondo.IdDetalleFondo) AS CuentaDeIdDetalleFondo FROM com_detallesfondo GROUP BY com_detallesfondo.IdFondo HAVING(((com_detallesfondo.IdFondo) = " + dataGridView_Fondos.SelectedRows[0].Cells[0].Value.ToString() + "));";
                //DataTable EstaIniciado = Persistencia.SentenciasSQL.select(sqlSelect);

                //if (EstaIniciado.Rows.Count > 0)
                //{
                //    String estadoIni = EstaIniciado.Rows[0][0].ToString();
                //    if (estadoIni != "0")
                //        inciarToolStripMenuItem.Visible = false;
                    
                //} else
                    inciarToolStripMenuItem.Visible = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void dataGridView_Fondos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Fondos.CurrentRow.Index != curRow)
            {
                curRow = dataGridView_Fondos.CurrentRow.Index;
                cargarDatagridDetalles();
            }
        }

        private void inciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIniciarFondo nueva = new FormIniciarFondo(this, id_comunidad_cargado, dataGridView_Fondos.SelectedRows[0].Cells[0].Value.ToString());
            nueva.Show();
        }

        private void cerrarFondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlUpdate = "UPDATE com_fondos SET Cierre = -1 WHERE IdFondo = " + dataGridView_Fondos.SelectedRows[0].Cells[0].Value.ToString();
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            cargarDatagrid();
        }

        private void dataGridView_detallesFondos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_detallesFondos.HitTest(e.X, e.Y);
                dataGridView_detallesFondos.ClearSelection();
                dataGridView_detallesFondos.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEntradasFondos nueva = new FormEntradasFondos(id_comunidad_cargado, dataGridView_detallesFondos.SelectedRows[0].Cells[0].Value.ToString());
            nueva.Show();
        }

        private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSalidasFondos nueva = new FormSalidasFondos(id_comunidad_cargado, dataGridView_detallesFondos.SelectedRows[0].Cells[0].Value.ToString());
            nueva.Show();
        }

        private void indexarLiquidaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIndenxarLiquidacion nueva = new FormIndenxarLiquidacion(id_comunidad_cargado, dataGridView_detallesFondos.SelectedRows[0].Cells[0].Value.ToString(), dataGridView_detallesFondos.SelectedRows[0].Cells[8].Value.ToString());
            nueva.Show();
        }

        private void calcularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalcularFondo(dataGridView_detallesFondos.SelectedRows[0].Cells[0].Value.ToString());
        }
        public void CalcularFondo(String idDetalleFondo) {
            double totalEntradas = 0.00;
            double totalEntradasPte = 0.00;
            double totalSalidas = 0.00;
            double totalSalidasPte = 0.00;
            double saldo = 0.00;

            //ENTRADAS
            String sqlTotalEntradas = "SELECT Sum(com_operaciones.ImpOp) AS SumaDeImpOp, Sum(com_operaciones.ImpOpPte) AS SumaDeImpOpPte FROM(com_operaciones INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion GROUP BY com_liquidaciones.IdDetalleFondo, com_operaciones.IdSubCuenta HAVING(((com_liquidaciones.IdDetalleFondo) = " + idDetalleFondo + ") AND((com_operaciones.IdSubCuenta) = 70000 Or(com_operaciones.IdSubCuenta) = 70001 Or(com_operaciones.IdSubCuenta) = 70002));";

            DataTable totalesEntradas = Persistencia.SentenciasSQL.select(sqlTotalEntradas);
            for (int a = 0; a < totalesEntradas.Rows.Count; a++) {
                totalEntradas += Convert.ToDouble(totalesEntradas.Rows[a][0].ToString());
                totalEntradasPte += Convert.ToDouble(totalesEntradas.Rows[a][1].ToString());
            }

            //SALIDAS
            String sqlTotalSalidas = "SELECT Sum(com_operaciones.ImpOp) AS SumaDeImpOp, Sum(com_operaciones.ImpOpPte) AS SumaDeImpOpPte FROM(com_operaciones INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion GROUP BY com_liquidaciones.IdDetalleFondo, com_operaciones.IdSubCuenta HAVING(((com_liquidaciones.IdDetalleFondo) = " + idDetalleFondo + ") AND ((com_operaciones.IdSubCuenta)>=60000 And (com_operaciones.IdSubCuenta)<=69999));";

            DataTable totalesSalidas = Persistencia.SentenciasSQL.select(sqlTotalSalidas);
            for (int a = 0; a < totalesSalidas.Rows.Count; a++)  {
                totalSalidas += Convert.ToDouble(totalesSalidas.Rows[a][0].ToString());
                totalSalidasPte += Convert.ToDouble(totalesSalidas.Rows[a][1].ToString());
            }

            saldo = totalEntradas - totalSalidas;

            String sqlUpdate = "UPDATE com_detallesfondo SET Entradas=" + totalEntradas.ToString().Replace(",",".") + ", Salidas=" + totalSalidas.ToString().Replace(",", ".") + ", SaldoActual=" + saldo.ToString().Replace(",", ".") + " + com_detallesfondo.SaldoInicial, Resultado=" + saldo.ToString().Replace(",", ".") + " WHERE IdDetalleFondo = " + idDetalleFondo;

            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            cargarDatagridDetalles();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar el detalle de fondo ?", "Borrar Detalle", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                //CAMBIAR A NULL EN LA TABLA DE LIQUIDACION DONDE IDETALLEFONDO A BORRAR
                String sqlUpdate = "UPDATE com_liquidaciones SET IdDetalleFondo = null WHERE IdDetalleFondo = " + dataGridView_detallesFondos.SelectedRows[0].Cells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);

                String sqlDelete = "DELETE FROM com_detallesfondo WHERE IdDetalleFondo = " + dataGridView_detallesFondos.SelectedRows[0].Cells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);

                cargarDatagridDetalles();
            }
        }

        private void iniciarConResultadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIniciarFondo nueva = new FormIniciarFondo(this, id_comunidad_cargado, dataGridView_Fondos.SelectedRows[0].Cells[0].Value.ToString(), dataGridView_detallesFondos.SelectedRows[0].Cells[6].Value.ToString().Replace(",","."), dataGridView_detallesFondos.SelectedRows[0].Cells[0].Value.ToString());
            nueva.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ACTUALIZAR RESULTADO
            String sqlUpdate = "UPDATE com_detallesfondo SET Cierre = -1 WHERE IdDetalleFondo = " + dataGridView_detallesFondos.SelectedRows[0].Cells[0].Value.ToString();
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);


            cargarDatagridDetalles();
        }

        private void informeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Informes.FormVerInformeCuentas nueva = new Informes.FormVerInformeCuentas(id_comunidad_cargado);
            nueva.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Informes.FormVerInformeCuentas nueva = new Informes.FormVerInformeCuentas(id_comunidad_cargado);
            nueva.Show();
        }
    }
}
