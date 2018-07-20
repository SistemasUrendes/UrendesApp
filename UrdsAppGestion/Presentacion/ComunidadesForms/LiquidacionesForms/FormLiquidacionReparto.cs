using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.LiquidacionesForms
{
    public partial class FormLiquidacionReparto : Form
    {
        String id_liquidacion_pasado;
        String nombreCortoLiqPasado;
        String id_comunidad_pasado;
        String LiqCerrada;
        Double totalBloques;
        DataTable filas;
        DataTable newTable = new DataTable();
        DataTable DivisionConSubcuotas;
        Boolean InformeEspecifico = false;

        public FormLiquidacionReparto(String id_comunidad_pasado, String id_liquidacion_pasado,String LiqCerrada, String nombreCortoLiqPasado)
        {
            InitializeComponent();
            this.id_comunidad_pasado = id_comunidad_pasado;
            this.id_liquidacion_pasado = id_liquidacion_pasado;
            this.LiqCerrada = LiqCerrada;
            this.nombreCortoLiqPasado = nombreCortoLiqPasado;
        }

        private void FormLiquidacionReparto_Load(object sender, EventArgs e)
        {   if (LiqCerrada == "True") {
                button_guardar.Enabled = false;

                String sqlIf = "SELECT IF(Exists (SELECT * FROM com_cuotas WHERE IdLiquidacion = " + id_liquidacion_pasado + "),1, 0)";
                String tieneCuota = (Persistencia.SentenciasSQL.select(sqlIf)).Rows[0][0].ToString();

                if (tieneCuota == "1")
                {
                    buttonaPdf.Enabled = true;
                    button_ver_pdf.Enabled = true;
                    groupBox_liqrec.Visible = true;
                    button_verLiqRecibo.Visible = true;
                }
            }
            cargarDatagrid();
        }
        private void cargarDatagrid() {

            String sqlreparto = "SELECT com_liqreparto.IdTitular, ctos_entidades.Entidad, com_liqreparto.Nombre, com_bloques.Descripcion, com_liqreparto.CGP, Sum(com_liqreparto.Importe) AS SumaDeImporte FROM(com_liqreparto INNER JOIN ctos_entidades ON com_liqreparto.IdTitular = ctos_entidades.IDEntidad) INNER JOIN com_bloques ON com_liqreparto.IdBloque = com_bloques.IdBloque GROUP BY com_liqreparto.IdLiquidacion, com_liqreparto.IdTitular, ctos_entidades.Entidad, com_liqreparto.DivPar, com_liqreparto.IdDivPar, com_liqreparto.Nombre, com_liqreparto.IdBloque, com_bloques.Descripcion, com_liqreparto.CGP HAVING(((com_liqreparto.IdLiquidacion) = " + id_liquidacion_pasado + ")) ORDER BY com_liqreparto.IdTitular, com_liqreparto.Nombre;";

            filas = Persistencia.SentenciasSQL.select(sqlreparto);
            dataGridView2.DataSource = filas;
            dataGridView2.Columns[0].Visible = false;
            //dataGridView2.Columns[1].Visible = false;
            //dataGridView2.Columns[2].Visible = false;
            //dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[2].HeaderText = "División";
            //dataGridView2.Columns[5].HeaderText = "Importe";
            dataGridView2.Columns[4].DefaultCellStyle.Format = "p";
            dataGridView2.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[1].Width = 300;



            String sqlSelectBloques = "SELECT com_bloques.Descripcion, com_liqreparto.ImpBloque FROM com_liqreparto INNER JOIN com_bloques ON com_liqreparto.IdBloque = com_bloques.IdBloque GROUP BY com_liqreparto.IdLiquidacion, com_bloques.Descripcion, com_liqreparto.ImpBloque HAVING(((com_liqreparto.IdLiquidacion) = " + id_liquidacion_pasado + "));";
            DataTable Importebloques = Persistencia.SentenciasSQL.select(sqlSelectBloques);

            dataGridView_bloques.DataSource = Importebloques;

            dataGridView_bloques.Columns[0].HeaderText = "Bloque";
            dataGridView_bloques.Columns[0].Width = 150;
            dataGridView_bloques.Columns[1].HeaderText = "Imp.Total";
            dataGridView_bloques.Columns[1].DefaultCellStyle.Format = "c";
            dataGridView_bloques.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            label3.Text = "Registros : " + filas.Rows.Count;

            Double totalParticulares = 0.00;
            totalBloques = 0.00;
            for (int a = 0; a < dataGridView2.Rows.Count; a++)
                totalParticulares = totalParticulares + Convert.ToDouble(dataGridView2.Rows[a].Cells["SumaDeImporte"].Value);
            textBox_total.Text = Math.Round(totalParticulares, 3).ToString() + " €";

            for (int a = 0; a < dataGridView_bloques.Rows.Count; a++)
                totalBloques = totalBloques + Convert.ToDouble(dataGridView_bloques.Rows[a].Cells[1].Value);
            textBox_bloques.Text = Math.Round(totalBloques, 3).ToString() + " €";

        }
        private void calcularTotales() {
            Double totalParticulares = 0.00;
            Double totalBloques = 0.00;

            for (int a = 0; a < dataGridView2.Rows.Count; a++)
                totalParticulares = totalParticulares + Convert.ToDouble(dataGridView2.Rows[a].Cells["TotalParticular"].Value);

            textBox_total.Text = Math.Round(totalParticulares, 3).ToString() + " €";

            for (int a = 0; a < dataGridView_bloques.Rows.Count; a++)
                totalBloques = totalBloques + Convert.ToDouble(dataGridView_bloques.Rows[a].Cells[1].Value);

            textBox_bloques.Text = Math.Round(totalBloques, 3).ToString() + " €";

        }
        private void calcularReparto() {
            progressBar1.Value = 20;
            String TotalPorBloque = "SELECT com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, Round(Sum(com_opdetliquidacion.Importe*IF(com_subcuentas.ES=1,-1,1)*com_opdetbloques.Porcentaje),2) AS TotalSubCuenta, com_opdetbloques.Porcentaje FROM(((com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta WHERE(((com_operaciones.IdSubCuenta)Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900 Or(com_operaciones.IdSubCuenta) Between 52000 And 52999)) GROUP BY com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_bloques.IdTipoBloque HAVING(((com_operaciones.IdComunidad) = " + id_comunidad_pasado + ") AND((com_opdetliquidacion.IdLiquidacion) = " + id_liquidacion_pasado + ")) ORDER BY com_opdetbloques.IdBloque, com_bloques.Descripcion;";
            DataTable bloquesConImporte = Persistencia.SentenciasSQL.select(TotalPorBloque);

            DivisionConSubcuotas = Persistencia.SentenciasSQL.select("SELECT com_asociacion.IdDivision,com_divisiones.Division, com_asociacion.IdComunero, com_asociacion.IdTipoAsoc, com_asociacion.Ppal, ctos_entidades.Entidad, ctos_entidades.IdEntidad, com_comuneros.IdComunidad, com_subcuotas.Subcuota, com_subcuotas.IdBloque FROM(((com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_divisiones ON com_asociacion.IdDivision = com_divisiones.IdDivision) INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision GROUP BY com_asociacion.IdDivision, com_asociacion.IdComunero, com_asociacion.IdTipoAsoc, com_asociacion.Ppal, ctos_entidades.Entidad, com_comuneros.IdComunidad, com_subcuotas.Subcuota, com_subcuotas.IdBloque HAVING(((com_asociacion.IdTipoAsoc) = 1) AND((com_asociacion.Ppal) = -1) AND((com_comuneros.IdComunidad) = " + id_comunidad_pasado + "));");

            dataGridView_reparto.DataSource = bloquesConImporte;

            dataGridView_reparto.Columns["IdComunidad"].Visible = false;
            dataGridView_reparto.Columns["IdLiquidacion"].Visible = false;
            dataGridView_reparto.Columns["Porcentaje"].Visible = false;

            var result = from x in DivisionConSubcuotas.AsEnumerable()
                         join y in bloquesConImporte.AsEnumerable() on x.Field<int>("IdBloque") equals y.Field<int>("IdBloque")
                         into xy
                         from y in xy.DefaultIfEmpty()
                         where y != null
                         select new
                         {
                             ID = x.Field<int>("IdBloque"),
                             Field1 = x.Field<int>("IdDivision"),
                             Field2 = x.Field<string>("Entidad"),
                             Field3 = x.Field<double>("Subcuota"),
                             Field4 = (y == null) ? 0.00 : y.Field<double>("TotalSubCuenta"),
                             Field5 = Math.Round(Convert.ToDouble(x.Field<double>("Subcuota")) * ((y == null) ? 0.00 : y.Field<double>("TotalSubCuenta")), 2),
                             Field6 = x.Field<int>("IdEntidad"),
                             Field8 = y.Field<string>("Descripcion"),
                             Field7 = x.Field<string>("Division"),
                             Field9 = y.Field<double>("Porcentaje")
                         };

            newTable = new DataTable();
            newTable.Columns.Add("IdBloque", typeof(int));
            newTable.Columns.Add("IdDivision", typeof(int));
            newTable.Columns.Add("Entidad", typeof(string));
            newTable.Columns.Add("IdEntidad", typeof(string));
            newTable.Columns.Add("Subcuota", typeof(decimal));
            newTable.Columns.Add("TotaBloque", typeof(double));
            newTable.Columns.Add("TotalParticular", typeof(double));
            newTable.Columns.Add("Division", typeof(string));
            newTable.Columns.Add("Bloque", typeof(string));
            newTable.Columns.Add("CGB", typeof(string));

            foreach (var rowInfo in result)
                newTable.Rows.Add(rowInfo.ID, rowInfo.Field1, rowInfo.Field2, rowInfo.Field6, rowInfo.Field3, rowInfo.Field4, rowInfo.Field5, rowInfo.Field7, rowInfo.Field8, rowInfo.Field9);


            dataGridView2.DataSource = newTable;
            dataGridView2.Columns["IdDivision"].Visible = false;
            dataGridView2.Columns["IdEntidad"].Visible = false;
            dataGridView2.Columns["TotaBloque"].Visible = false;
            dataGridView2.Columns["CGB"].Visible = false;
            dataGridView2.Columns["IdBloque"].Visible = false;

            dataGridView2.Columns["Subcuota"].DefaultCellStyle.Format = "p";

            dataGridView2.Sort(dataGridView2.Columns[2], ListSortDirection.Ascending);

            calcularTotales();
            RepartoIVABloques();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_guardar.Enabled = false;
            progressBar1.Visible = true;
           
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("Se actualizarán los datos actuales. ¿Seguimos? ", "Actualizar Reparto", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                //LO CALCULO Y LUEGO LO GUARDO
                calcularReparto();

                cargarDatagrid();

                String sqlBorrarAnterior = "DELETE FROM com_liqreparto WHERE IdLiquidacion = " + id_liquidacion_pasado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarAnterior);
                progressBar1.Maximum = newTable.Rows.Count;

                for (int a = 0; a < newTable.Rows.Count; a++)
                {
                    String IdDivPar = id_liquidacion_pasado + "B" + newTable.Rows[a][1].ToString();
                    String sqlInsert = "INSERT INTO com_liqreparto ( IdLiquidacion, DivPar, IdDivPar, IdDivision, Nombre, IdTitular, Titular, IdBloque, Descripcion, ImpBloque, CGB, CGP, Importe ) VALUES (" + id_liquidacion_pasado + ",1,'" + IdDivPar + "'," + newTable.Rows[a][1].ToString() + ",'" + newTable.Rows[a][7].ToString() + "'," + newTable.Rows[a][3].ToString() + ",'" + newTable.Rows[a][2].ToString() + "'," + newTable.Rows[a][0].ToString() + ",'" + newTable.Rows[a][8].ToString() + "'," + Logica.FuncionesGenerales.ArreglarImportes(newTable.Rows[a][5].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(newTable.Rows[a][9].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(newTable.Rows[a][4].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(newTable.Rows[a][6].ToString()) + ")";

                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                    progressBar1.Value = a;
                }
                RepartoIVABloques();
                cargarDatagrid();
                cerrarLiquidacion();
                MessageBox.Show("El Reparto ha sido guardado.");
                progressBar1.Visible = false;
                button_guardar.Enabled = false;
            }
            else {
                button_guardar.Enabled = true;
                progressBar1.Visible = false;
            }
        }
        private void cerrarLiquidacion() {

            //CIERRO Y GUARDO EL TOTAL
            String sqlCerrar = "UPDATE com_liquidaciones SET com_liquidaciones.Cerrada = -1, com_liquidaciones.Total = " + totalBloques.ToString().Replace(',','.') + "  WHERE(((com_liquidaciones.IdLiquidacion) = " + id_liquidacion_pasado + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlCerrar);
        }


        private void RepartoIVABloques() {

            //BORRAR DETALLE IVA
            String sqlBorrarIVA = "DELETE FROM com_liqrepartoiva WHERE IdLiquidacion = " + id_liquidacion_pasado;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarIVA);

            DivisionConSubcuotas = Persistencia.SentenciasSQL.select("SELECT com_asociacion.IdDivision,com_divisiones.Division, com_asociacion.IdComunero, com_asociacion.IdTipoAsoc, com_asociacion.Ppal, ctos_entidades.Entidad, ctos_entidades.IdEntidad, com_comuneros.IdComunidad, com_subcuotas.Subcuota, com_subcuotas.IdBloque FROM(((com_asociacion INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_divisiones ON com_asociacion.IdDivision = com_divisiones.IdDivision) INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision GROUP BY com_asociacion.IdDivision, com_asociacion.IdComunero, com_asociacion.IdTipoAsoc, com_asociacion.Ppal, ctos_entidades.Entidad, com_comuneros.IdComunidad, com_subcuotas.Subcuota, com_subcuotas.IdBloque HAVING(((com_asociacion.IdTipoAsoc) = 1) AND((com_asociacion.Ppal) = -1) AND((com_comuneros.IdComunidad) = " + id_comunidad_pasado + "));");


            String liqIVA = "SELECT com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_opdetiva.IdIVA, aux_iva.`%IVA`, Sum(`com_opdetbloques`.`porcentaje`*`com_opdetiva`.`base`*`com_opdetliquidacion`.`porcentaje`*If(`com_operaciones`.`IdSubcuenta`>=70100,-1,1)) AS ImpBase, Sum(`com_opdetbloques`.`porcentaje`*`com_opdetiva`.`IVA`*`com_opdetliquidacion`.`porcentaje`*If(`com_operaciones`.`IdSubcuenta`>=70100,-1,1)) AS ImpIVA FROM((((com_operaciones INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_opdetbloques ON com_operaciones.IdOp = com_opdetbloques.IdOp) INNER JOIN com_opdetiva ON com_operaciones.IdOp = com_opdetiva.IdOp) INNER JOIN aux_iva ON com_opdetiva.IdIVA = aux_iva.IdIVA) INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque WHERE(((com_operaciones.IdSubCuenta)Between 60000 And 69999)) GROUP BY com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_opdetiva.IdIVA, aux_iva.`%IVA` HAVING(((com_opdetliquidacion.IdLiquidacion) = " + id_liquidacion_pasado + "));";

            DataTable ivas = Persistencia.SentenciasSQL.select(liqIVA);

            var result = from x in DivisionConSubcuotas.AsEnumerable()
                         join y in ivas.AsEnumerable() on x.Field<int>("IdBloque") equals y.Field<int>("IdBloque")
                         into xy
                         from y in xy.DefaultIfEmpty()
                         where y != null
                         select new
                         {
                             ID = x.Field<int>("IdBloque"),
                             Field1 = x.Field<int>("IdDivision"),
                             Field2 = x.Field<string>("Entidad"),
                             Field3 = x.Field<int>("IdEntidad"),
                             Field4 = (y == null) ? 0.00 : Math.Round(y.Field<double>("ImpIVA"),2),
                             Field5 = Math.Round(Convert.ToDouble(x.Field<double>("Subcuota")),6) * ((y == null) ? 0.00 : Math.Round(y.Field<double>("ImpIVA"),2)),
                             Field6 = y.Field<int>("IdIVA"),
                             Field7 = Math.Round(Convert.ToDouble(x.Field<double>("Subcuota")), 6) * ((y == null) ? 0.00 : Math.Round(y.Field<double>("ImpBase"),2)),
                             Field8 = Math.Round(y.Field<double>("ImpBase"),2)
                         };

            DataTable newTableIva = new DataTable();
            newTableIva.Columns.Add("IdBloque", typeof(int));
            newTableIva.Columns.Add("IdDivision", typeof(int));
            newTableIva.Columns.Add("Entidad", typeof(string));
            newTableIva.Columns.Add("IdEntidad", typeof(string));
            newTableIva.Columns.Add("TotaBloque", typeof(double));
            newTableIva.Columns.Add("TotalParticular", typeof(double));
            newTableIva.Columns.Add("IdIVA", typeof(int));
            newTableIva.Columns.Add("BaseIVA", typeof(double));
            newTableIva.Columns.Add("SumaBaseIVA", typeof(double));

            foreach (var rowInfo in result)
                newTableIva.Rows.Add(rowInfo.ID, rowInfo.Field1, rowInfo.Field2, rowInfo.Field3, rowInfo.Field4, rowInfo.Field5, rowInfo.Field6, rowInfo.Field7,rowInfo.Field8);

            for (int a = 0; a < newTableIva.Rows.Count; a++)
            {
                String IdDivPar = id_liquidacion_pasado + "B" + newTableIva.Rows[a][1].ToString();
                String sqlInsertIva = "INSERT INTO com_liqrepartoiva ( IdLiquidacion, DivPar, IdDivPar, IdDivision, IdTitular, Titular, IdIVA,`%IVA`, ImpBase, ImpIVA, BaseDivBloq, IVADivBloq) VALUES (" + id_liquidacion_pasado + ",1,'" + IdDivPar + "'," + newTableIva.Rows[a][1].ToString() + "," + newTableIva.Rows[a][3].ToString() + ",'" + newTableIva.Rows[a][2].ToString() + "'," + newTableIva.Rows[a][6].ToString() + ",(SELECT `%IVA` FROM aux_iva WHERE IdIVA = " + newTableIva.Rows[a][6].ToString() + " )," + Logica.FuncionesGenerales.ArreglarImportes(newTableIva.Rows[a][8].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(newTableIva.Rows[a][4].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(newTableIva.Rows[a][7].ToString()) + "," + Logica.FuncionesGenerales.ArreglarImportes(newTableIva.Rows[a][5].ToString()) + ")";

                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertIva);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox_buscar.TextLength < 2)  {
                DataTable busqueda = filas;
                busqueda.DefaultView.RowFilter = "Entidad like '%%'";
                this.dataGridView2.DataSource = busqueda;
            }
            else
            {
                DataTable busqueda = filas;
                busqueda.DefaultView.RowFilter = "Entidad like '%" + textBox_buscar.Text + "%' OR Nombre like '%" + textBox_buscar.Text + "%' ";
                this.dataGridView2.DataSource = busqueda;
            }
        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    if (dataGridView2.Rows.Count > 0)
        //        imprimirLiquidacion();
        //    else
        //        MessageBox.Show("No hay reparto");
        //}

        private void button1_Click_2(object sender, EventArgs e)
        {
            FolderBrowserDialog fichero = new FolderBrowserDialog();
            String RutaComunidad = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Ruta FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_pasado + "));")).Rows[0][0].ToString().Trim('#');

            String anyo = Convert.ToDateTime((Persistencia.SentenciasSQL.select("SELECT FFin FROM com_liquidaciones WHERE IdLiquidacion = " + id_liquidacion_pasado)).Rows[0][0].ToString()).Year.ToString();

            String path = @"\Liquidaciones\" + anyo + @"\";
            fichero.SelectedPath = (RutaComunidad + path);

            fichero.ShowNewFolderButton = true;

            String Ruta = "";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Ruta = fichero.SelectedPath;
            }
                PanelControl existe = Application.OpenForms.OfType<PanelControl>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<PanelControl>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Normal;
                existe.BringToFront();

                existe.CrearPDFLiquidacion((DataTable)dataGridView2.DataSource,id_comunidad_pasado,id_liquidacion_pasado,Ruta, nombreCortoLiqPasado);
                this.Close();
            }
        }

        private void button_ver_pdf_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0) {
                InformeParticular.FormVerInformeParticular nueva = new InformeParticular.FormVerInformeParticular(id_comunidad_pasado, id_liquidacion_pasado, dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                nueva.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fichero = new FolderBrowserDialog();

            List<String> Rutas = new List<String>();

            String strLiquidacion = (Persistencia.SentenciasSQL.select("SELECT com_liquidaciones.Liquidacion FROM com_liquidaciones WHERE com_liquidaciones.IdLiquidacion = " + id_liquidacion_pasado + ";")).Rows[0][0].ToString();

            String strComunidad = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.NombreCorto FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_pasado + "));")).Rows[0][0].ToString();

            String sqlSelect = "SELECT Ruta FROM com_liquidaciones WHERE IdLiquidacion = " + id_liquidacion_pasado;
            DataTable RutaLiq = Persistencia.SentenciasSQL.select(sqlSelect);

            if (RutaLiq.Rows[0][0].ToString() != "") {
                Rutas.Add(RutaLiq.Rows[0][0].ToString());
                PanelControl existe = Application.OpenForms.OfType<PanelControl>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<PanelControl>();
                if (existe != null)
                {
                    existe.WindowState = FormWindowState.Normal;
                    existe.BringToFront();

                    existe.envioLiquidaciones(strComunidad, strLiquidacion, id_liquidacion_pasado, Rutas);
                    this.Close();
                }
            }
            else {
                String RutaComunidad = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Ruta FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_pasado + "));")).Rows[0][0].ToString().Trim('#');

                String anyo = Convert.ToDateTime((Persistencia.SentenciasSQL.select("SELECT FFin FROM com_liquidaciones WHERE IdLiquidacion = " + id_liquidacion_pasado)).Rows[0][0].ToString()).Year.ToString();
                String path = @"\Liquidaciones\" + anyo + @"\";
                fichero.SelectedPath = (RutaComunidad + path);
                fichero.ShowNewFolderButton = false;

                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Rutas.Add(fichero.SelectedPath);
                    PanelControl existe = Application.OpenForms.OfType<PanelControl>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<PanelControl>();
                    if (existe != null)
                    {
                        existe.WindowState = FormWindowState.Normal;
                        existe.BringToFront();

                        existe.envioLiquidaciones(strComunidad, strLiquidacion, id_liquidacion_pasado, Rutas);
                        this.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable resumenGastos = null;
            DataTable infoComunidad = null;
            if (dataGridView2.SelectedRows.Count > 0)
            {
                String sqlIdRecibos = "SELECT com_opdetalles.IdRecibo, Sum(com_operaciones.ImpOp) AS SumaDeImpOp FROM((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_cuotas ON com_operaciones.IdCuota = com_cuotas.IdCuota GROUP BY com_opdetalles.IdRecibo, com_operaciones.IdCuota, com_operaciones.IdEntidad, com_opdetliquidacion.IdLiquidacion, com_cuotas.IdTipoCuota HAVING((Not(com_operaciones.IdCuota) Is Null) AND((com_operaciones.IdEntidad) = " + dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + ") AND((com_opdetliquidacion.IdLiquidacion) = " + id_liquidacion_pasado + ") AND((com_cuotas.IdTipoCuota) = 1 OR (com_cuotas.IdTipoCuota) = 2 ));";

                DataTable Recibos = Persistencia.SentenciasSQL.select(sqlIdRecibos);

                String Liquidacion = (Persistencia.SentenciasSQL.select("SELECT LiqLargo FROM com_liquidaciones WHERE IdLiquidacion = " + id_liquidacion_pasado)).Rows[0][0].ToString();

                //BUSCO EL RESUMEN DE GASTOS Y LO ADJUNTO A LA LIQUIDACIÓN
                resumenGastos = GenerarResumenGastos();

                //BUSCO LA INFORMACION DE LA COMUNIDAD Y SE LA PASO AL INFORME
                String sqlSelectInfoComunidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_cuentas.Descripcion, com_cuentas.NumCuenta, com_comunidades.IdComunidad FROM com_cuentas INNER JOIN (com_comunidades INNER JOIN(ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad) ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad) ON com_cuentas.IdComunidad = com_comunidades.IdComunidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_pasado + ") AND((com_cuentas.Ppal) = -1));";

                infoComunidad = Persistencia.SentenciasSQL.select(sqlSelectInfoComunidad);


                if (Recibos.Rows.Count > 0) {
                    for (int a = 0; a < Recibos.Rows.Count; a++)
                    {
                        //FILTRO POR EL IDRECIBO QUE TOCA SI ES EL INFORME ESPECIFICO
                        if (InformeEspecifico)
                            resumenGastos.DefaultView.RowFilter = "IdRecibo = " + Recibos.Rows[a][0].ToString();

                        InformeParticularRecibo.FormVerInformeParticularRecibo nueva = new InformeParticularRecibo.FormVerInformeParticularRecibo(id_liquidacion_pasado, id_comunidad_pasado, dataGridView2.SelectedRows[0].Cells[0].Value.ToString(), Recibos.Rows[a][0].ToString(), Liquidacion, resumenGastos, infoComunidad);
                        nueva.Show();
                    }
                }else {
                    MessageBox.Show("NO SE A CREADO LA CUOTA, SOLO ES UN INFORME Y NO UN RECIBO");
                    InformeParticular.FormVerInformeParticular nueva = new InformeParticular.FormVerInformeParticular(id_comunidad_pasado, id_liquidacion_pasado, dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                    nueva.Show();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable resumenGastos = null;
            DataTable infoComunidad = null;

            FolderBrowserDialog fichero = new FolderBrowserDialog();

            String RutaComunidad = (Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Ruta FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_pasado + "));")).Rows[0][0].ToString().Trim('#');

            String anyo = Convert.ToDateTime((Persistencia.SentenciasSQL.select("SELECT FFin FROM com_liquidaciones WHERE IdLiquidacion = " + id_liquidacion_pasado)).Rows[0][0].ToString()).Year.ToString();
            String path = @"\Liquidaciones\" + anyo + @"\";
            fichero.SelectedPath = (RutaComunidad + path);

            fichero.ShowNewFolderButton = true;

            String Ruta = "";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Ruta = fichero.SelectedPath;
                //GUARDO RUTA EN LA TABLA LIQUIDACIONES
                String sqlUpdate = "UPDATE com_liquidaciones SET Ruta='" + @Ruta.Replace(@"\",@"\\") + "' WHERE IdLiquidacion = " + id_liquidacion_pasado;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);

                //BUSCO EL RESUMEN DE GASTOS Y LO ADJUNTO A LA LIQUIDACIÓN
                resumenGastos = GenerarResumenGastos();

                //BUSCO LA INFORMACION DE LA COMUNIDAD Y SE LA PASO AL INFORME
                String sqlSelectInfoComunidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_cuentas.Descripcion, com_cuentas.NumCuenta, com_comunidades.IdComunidad FROM com_cuentas INNER JOIN (com_comunidades INNER JOIN(ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad) ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad) ON com_cuentas.IdComunidad = com_comunidades.IdComunidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_pasado + ") AND((com_cuentas.Ppal) = -1));";

                infoComunidad = Persistencia.SentenciasSQL.select(sqlSelectInfoComunidad);

                PanelControl existe = Application.OpenForms.OfType<PanelControl>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<PanelControl>();
                if (existe != null)
                {
                    existe.WindowState = FormWindowState.Normal;
                    existe.BringToFront();
                    existe.CrearPDFLiquidacionNuevo((DataTable)dataGridView2.DataSource, id_comunidad_pasado, id_liquidacion_pasado, Ruta, nombreCortoLiqPasado, resumenGastos, InformeEspecifico, infoComunidad);
                    this.Close();
                }
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataTable infoComunidad = null;
                DataTable datosReparto = null;
                DataTable datosRepartoIVA = null;
                DataTable datosRepartoResumenIVA = null;
                DataTable InfoEntidad = null;
                DataTable resumenGastos = null;

                String sqlSelect = "SELECT com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.Importe, com_subcuotas.Parte, com_liqreparto.IdLiquidacion, com_liqreparto.IdTitular, com_liqreparto.IdBloque FROM com_subcuotas INNER JOIN com_liqreparto ON (com_subcuotas.IdDivision = com_liqreparto.IdDivision) AND(com_subcuotas.IdBloque = com_liqreparto.IdBloque) GROUP BY com_liqreparto.IdDivision, com_liqreparto.Nombre, com_liqreparto.Descripcion, com_liqreparto.ImpBloque, com_liqreparto.CGP, com_liqreparto.Importe, com_subcuotas.Parte, com_liqreparto.IdLiquidacion, com_liqreparto.IdTitular HAVING(((com_liqreparto.IdLiquidacion) = " + id_liquidacion_pasado + ") AND((com_liqreparto.IdTitular) = " + dataGridView2.Rows[0].Cells[0].Value.ToString() + "));" ;

                datosReparto = Persistencia.SentenciasSQL.select(sqlSelect);

                //BUSCO TODOS LOS IVAS PARA LUEGO USARLO EN EL SUBINFORME Y FILTRADO.
                String sqlSelectIVA = "SELECT com_liqrepartoiva.IdDivision, com_liqrepartoiva.`%IVA` as PorIVA, Sum(com_liqrepartoiva.BaseDivBloq) AS Base, Sum(com_liqrepartoiva.IVADivBloq) AS IVA, com_liqrepartoiva.IdLiquidacion FROM com_liqrepartoiva GROUP BY com_liqrepartoiva.IdDivision, com_liqrepartoiva.`%IVA`, com_liqrepartoiva.IdLiquidacion HAVING(((com_liqrepartoiva.IdLiquidacion) = " + id_liquidacion_pasado + "));";

                datosRepartoIVA = Persistencia.SentenciasSQL.select(sqlSelectIVA);


                //BUSCO LA INFORMACION DE LA COMUNIDAD Y SE LA PASO AL INFORME
                String sqlSelectInfoComunidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia, com_cuentas.Descripcion, com_cuentas.NumCuenta, com_comunidades.IdComunidad FROM com_cuentas INNER JOIN (com_comunidades INNER JOIN(ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad) ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad) ON com_cuentas.IdComunidad = com_comunidades.IdComunidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad_pasado + ") AND((com_cuentas.Ppal) = -1));";

                infoComunidad = Persistencia.SentenciasSQL.select(sqlSelectInfoComunidad);

                //BUSCO EL TOTAL DE LOS IVAS
                String sqlSelectResumenIVA = "SELECT com_liqrepartoiva.`%IVA` AS PorIVA, Sum(com_liqrepartoiva.BaseDivBloq) AS SumaDeBase, Sum(com_liqrepartoiva.IVADivBloq) AS SumaDelIVA FROM com_liqrepartoiva GROUP BY com_liqrepartoiva.`%IVA`, com_liqrepartoiva.IdTitular, com_liqrepartoiva.IdLiquidacion HAVING(((com_liqrepartoiva.IdTitular) = " + dataGridView2.Rows[0].Cells[0].Value.ToString() + ") AND((com_liqrepartoiva.IdLiquidacion) = " + id_liquidacion_pasado + "));";

                datosRepartoResumenIVA = Persistencia.SentenciasSQL.select(sqlSelectResumenIVA);

                //BUSCO INFORMACION DE LA ENTIDAD
                String sqlSelectInfoEntidad = "SELECT ctos_entidades.Entidad, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_detdirecent.Provincia FROM ctos_entidades INNER JOIN ctos_detdirecent ON ctos_entidades.IDEntidad = ctos_detdirecent.IdEntidad WHERE(((ctos_entidades.IDEntidad) = " + dataGridView2.Rows[0].Cells[0].Value.ToString() + ") AND (ctos_detdirecent.Ppal = -1));";

                InfoEntidad = Persistencia.SentenciasSQL.select(sqlSelectInfoEntidad);

                //BUSCO EL RESUMEN DE GASTOS Y LO ADJUNTO A LA LIQUIDACIÓN
                resumenGastos = GenerarResumenGastosIVA();

                //FILTRO POR EL IDRECIBO QUE TOCA SI ES EL INFORME ESPECIFICO
                if (InformeEspecifico)
                {
                    String filtro = "IdBloque = ";
                    for (int a = 0; a < datosReparto.Rows.Count; a++)
                    {
                        if (a == datosReparto.Rows.Count - 1)
                            filtro += datosReparto.Rows[a][9].ToString();
                        else
                            filtro += datosReparto.Rows[a][9].ToString() + " OR IdBloque = ";
                    }
                    resumenGastos.DefaultView.RowFilter = filtro;
                }

                String Liquidacion = (Persistencia.SentenciasSQL.select("SELECT LiqLargo FROM com_liquidaciones WHERE IdLiquidacion = " + id_liquidacion_pasado)).Rows[0][0].ToString();

                InformeParticularReciboIVA.FormVerInformeLiquidacionIVA nueva = new InformeParticularReciboIVA.FormVerInformeLiquidacionIVA(datosReparto, datosRepartoIVA, infoComunidad, datosRepartoResumenIVA, InfoEntidad, resumenGastos, Liquidacion);
                nueva.Show();
            }
        }
        private DataTable GenerarResumenGastos () {
            //////////////////////////////RESUMEN DE GASTOS

            String sqlTipoInforme = "SELECT IdTipoInformeLiq FROM com_comunidades WHERE IdComunidad = " + id_comunidad_pasado;
            DataTable TipoInforme = Persistencia.SentenciasSQL.select(sqlTipoInforme);

            if (TipoInforme.Rows.Count > 0)
            {
                if (TipoInforme.Rows[0][0].ToString() == "1") //INFORME COMPLETO
                {

                    String ResumenLiq = "SELECT com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA` as TITSUBCTA , Sum((`com_opdetliquidacion`.`Importe`*`com_opdetbloques`.`Porcentaje`)*IF(`com_subcuentas`.`ES`=1,-1,1)) AS TotalSub, com_liquidaciones.Notas FROM((((com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion GROUP BY com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA`, com_liquidaciones.Notas, com_bloques.IdTipoBloque, com_operaciones.IdTipoReparto HAVING(((com_operaciones.IdComunidad) = " + id_comunidad_pasado + ") AND((com_opdetliquidacion.IdLiquidacion) = " + id_liquidacion_pasado + ") AND((com_operaciones.IdSubCuenta)Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900) AND((Sum((`com_opdetliquidacion`.`Importe` * `com_opdetbloques`.`Porcentaje`) * IF(`com_subcuentas`.`ES` = 1, -1, 1))) <> 0) AND((com_bloques.IdTipoBloque) = 1) AND((com_operaciones.IdTipoReparto) = 1)) ORDER BY com_opdetbloques.IdBloque, com_bloques.Descripcion, com_subcuentas.`TIT SUBCTA`;";

                    return Persistencia.SentenciasSQL.select(ResumenLiq);
                }
                else if (TipoInforme.Rows[0][0].ToString() == "2") //INFORME ESPEFICIFO BLOQUE
                {
                    InformeEspecifico = true;
                    newTable = new DataTable();

                    String ResumenLiq = "SELECT com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA` as TITSUBCTA , Sum((`com_opdetliquidacion`.`Importe`*`com_opdetbloques`.`Porcentaje`)*IF(`com_subcuentas`.`ES`=1,-1,1)) AS TotalSub, com_liquidaciones.Notas FROM((((com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion GROUP BY com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA`, com_liquidaciones.Notas, com_bloques.IdTipoBloque, com_operaciones.IdTipoReparto HAVING(((com_operaciones.IdComunidad) = " + id_comunidad_pasado + ") AND((com_opdetliquidacion.IdLiquidacion) = " + id_liquidacion_pasado + ") AND((com_operaciones.IdSubCuenta)Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900) AND((Sum((`com_opdetliquidacion`.`Importe` * `com_opdetbloques`.`Porcentaje`) * IF(`com_subcuentas`.`ES` = 1, -1, 1))) <> 0) AND((com_bloques.IdTipoBloque) = 1) AND((com_operaciones.IdTipoReparto) = 1)) ORDER BY com_opdetbloques.IdBloque, com_bloques.Descripcion, com_subcuentas.`TIT SUBCTA`;";

                    DataTable gastos = Persistencia.SentenciasSQL.select(ResumenLiq);

                    String sqlbloques = "SELECT com_liqreparto.IdLiquidacion, com_recibos.IdRecibo, com_liqreparto.IdBloque, com_recibos.IdRecibo FROM((com_recibos INNER JOIN com_opdetalles ON com_recibos.IdRecibo = com_opdetalles.IdRecibo) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN com_liqreparto ON com_operaciones.IdDivision = com_liqreparto.IdDivision GROUP BY com_liqreparto.IdLiquidacion, com_recibos.IdRecibo, com_liqreparto.IdBloque HAVING(((com_liqreparto.IdLiquidacion) = " + id_liquidacion_pasado + "));";

                    DataTable bloques = Persistencia.SentenciasSQL.select(sqlbloques);

                    var result = from x in bloques.AsEnumerable()
                                 join y in gastos.AsEnumerable() on x.Field<int>("IdBloque") equals y.Field<int>("IdBloque")
                                 into xy
                                 from y in xy.DefaultIfEmpty()
                                 select new
                                 {
                                     ID = y.Field<int>("IdBloque"),
                                     Field1 = y.Field<string>("Descripcion"),
                                     Field2 = y.Field<int>("IdSubCuenta"),
                                     Field3 = y.Field<string>("TITSUBCTA"),
                                     Field4 = y.Field<double>("TotalSub"),
                                     Field5 = x.Field<int>("IdRecibo"),
                                     Field6 = y.Field<string>("Notas")
                                 };

                    newTable.Columns.Add("IdBloque", typeof(int));
                    newTable.Columns.Add("Descripcion", typeof(string));
                    newTable.Columns.Add("IdSubCuenta", typeof(int));
                    newTable.Columns.Add("TITSUBCTA", typeof(string));
                    newTable.Columns.Add("TotalSub", typeof(double));
                    newTable.Columns.Add("IdRecibo", typeof(int));
                    newTable.Columns.Add("Notas", typeof(string));


                    foreach (var rowInfo in result)
                        newTable.Rows.Add(rowInfo.ID, rowInfo.Field1, rowInfo.Field2, rowInfo.Field3, rowInfo.Field4, rowInfo.Field5, rowInfo.Field6);

                    return newTable;
                }
            }
            return null;
        }
        private DataTable GenerarResumenGastosIVA()
        {
            //////////////////////////////RESUMEN DE GASTOS

            String sqlTipoInforme = "SELECT IdTipoInformeLiq FROM com_comunidades WHERE IdComunidad = " + id_comunidad_pasado;
            DataTable TipoInforme = Persistencia.SentenciasSQL.select(sqlTipoInforme);

            if (TipoInforme.Rows.Count > 0)
            {
                if (TipoInforme.Rows[0][0].ToString() == "1") //INFORME COMPLETO
                {

                    String ResumenLiq = "SELECT com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA` as TITSUBCTA , Sum((`com_opdetliquidacion`.`Importe`*`com_opdetbloques`.`Porcentaje`)*IF(`com_subcuentas`.`ES`=1,-1,1)) AS TotalSub, com_liquidaciones.Notas FROM((((com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion GROUP BY com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA`, com_liquidaciones.Notas, com_bloques.IdTipoBloque, com_operaciones.IdTipoReparto HAVING(((com_operaciones.IdComunidad) = " + id_comunidad_pasado + ") AND((com_opdetliquidacion.IdLiquidacion) = " + id_liquidacion_pasado + ") AND((com_operaciones.IdSubCuenta)Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900) AND((Sum((`com_opdetliquidacion`.`Importe` * `com_opdetbloques`.`Porcentaje`) * IF(`com_subcuentas`.`ES` = 1, -1, 1))) <> 0) AND((com_bloques.IdTipoBloque) = 1) AND((com_operaciones.IdTipoReparto) = 1)) ORDER BY com_opdetbloques.IdBloque, com_bloques.Descripcion, com_subcuentas.`TIT SUBCTA`;";

                    return Persistencia.SentenciasSQL.select(ResumenLiq);
                }
                else if (TipoInforme.Rows[0][0].ToString() == "2") //INFORME ESPEFICIFO BLOQUE
                {
                    InformeEspecifico = true;
                    newTable = new DataTable();

                    String ResumenLiq = "SELECT com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA` as TITSUBCTA , Sum((`com_opdetliquidacion`.`Importe`*`com_opdetbloques`.`Porcentaje`)*IF(`com_subcuentas`.`ES`=1,-1,1)) AS TotalSub, com_liquidaciones.Notas FROM((((com_opdetbloques INNER JOIN com_operaciones ON com_opdetbloques.IdOp = com_operaciones.IdOp) INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_bloques ON com_opdetbloques.IdBloque = com_bloques.IdBloque) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta) INNER JOIN com_liquidaciones ON com_opdetliquidacion.IdLiquidacion = com_liquidaciones.IdLiquidacion GROUP BY com_operaciones.IdComunidad, com_opdetliquidacion.IdLiquidacion, com_opdetbloques.IdBloque, com_bloques.Descripcion, com_operaciones.IdSubCuenta, com_subcuentas.`TIT SUBCTA`, com_liquidaciones.Notas, com_bloques.IdTipoBloque, com_operaciones.IdTipoReparto HAVING(((com_operaciones.IdComunidad) = " + id_comunidad_pasado + ") AND((com_opdetliquidacion.IdLiquidacion) = " + id_liquidacion_pasado + ") AND((com_operaciones.IdSubCuenta)Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900) AND((Sum((`com_opdetliquidacion`.`Importe` * `com_opdetbloques`.`Porcentaje`) * IF(`com_subcuentas`.`ES` = 1, -1, 1))) <> 0) AND((com_bloques.IdTipoBloque) = 1) AND((com_operaciones.IdTipoReparto) = 1)) ORDER BY com_opdetbloques.IdBloque, com_bloques.Descripcion, com_subcuentas.`TIT SUBCTA`;";

                    return Persistencia.SentenciasSQL.select(ResumenLiq);

                }
            }
            return null;
        }
    }
}