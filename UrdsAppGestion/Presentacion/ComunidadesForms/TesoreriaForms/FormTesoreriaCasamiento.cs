using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.OperacionesForms
{
    public partial class FormTesoreriaCasamiento : Form
    {
        String id_comunidad_cargado;
        DataTable vencimientos;
        DataTable bancos;

        public FormTesoreriaCasamiento(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void FormTesoreriaCasamiento_Load(object sender, EventArgs e)
        {
            cargarDataGridBanco();
            cargarDataGridVencimientos();
        }
        private void cargarDataGridBanco() {

            DataGridViewTextBoxColumn ColumnaEntidad = new DataGridViewTextBoxColumn();
            ColumnaEntidad.HeaderText = "Entidad";
            ColumnaEntidad.Name = "Entidad";
            ColumnaEntidad.Width = 245;
            //dataGridView_datos_bancos.Columns.Add(ColumnaEntidad);

            DataGridViewTextBoxColumn ColumnaFecha = new DataGridViewTextBoxColumn();
            ColumnaFecha.HeaderText = "Fecha";
            ColumnaFecha.Name = "Fecha";
            ColumnaFecha.Width = 70;
            //dataGridView_datos_bancos.Columns.Add(ColumnaFecha); 

            DataGridViewTextBoxColumn ColumnaImporte = new DataGridViewTextBoxColumn();
            ColumnaImporte.HeaderText = "Importe";
            ColumnaImporte.Name = "Importe";
            ColumnaImporte.Width = 80;
            //dataGridView_datos_bancos.Columns.Add(ColumnaImporte);
        }
        private void cargarDataGridVencimientos() {
            String sqlSelect = "SELECT com_opdetalles.IdOpDet, com_operaciones.IdOp, com_opdetalles.IdEntidad, ctos_entidades.Entidad, com_operaciones.Documento, com_operaciones.Descripcion, com_opdetalles.FechaPrev,com_opdetalles.Fecha, com_opdetalles.ImpOpDetPte, com_opdetalles.Importe FROM(com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN ctos_entidades ON com_operaciones.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_opdetalles.ImpOpDetPte) > 0) AND((com_operaciones.IdSubCuenta)Between 60000 And 69999) AND((com_opdetalles.IdEstado) <> 3) AND((com_operaciones.IdComunidad) = " + id_comunidad_cargado + ")) OR(((com_opdetalles.ImpOpDetPte) > 0) AND((com_operaciones.IdSubCuenta) = 43812)) ORDER BY com_operaciones.Fecha;";
            
            vencimientos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridView_vencimientos.DataSource = vencimientos;
            ajustarDatagridVencimientos();

        }
        private void LLenarGrid(string archivo, string hoja)
        {
           OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "Select * from [" + hoja + "$]";

            //esta cadena es para archivos excel 2007 y 2010
            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";

            //para archivos de 97-2003 usar la siguiente cadena
            //string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo + "';Extended Properties=Excel 8.0;";
            if (string.IsNullOrEmpty(hoja))
            {
                MessageBox.Show("No hay una hoja para leer");
            }
            else
            {
                try
                {
                    //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                    conexion.Open(); //abrimos la conexion
                    dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
                    dataSet = new DataSet(); // creamos la instancia del objeto DataSet
                    dataAdapter.Fill(dataSet, hoja);//llenamos el dataset
                    bancos = dataSet.Tables[0];
                    bancos.Rows[0].Delete();
                    bancos.Rows[1].Delete();
                    bancos.Rows[2].Delete();
                    bancos.Rows[3].Delete();
                    bancos.Rows[4].Delete();
                    //bancos.Columns.RemoveAt(6);

                
                    dataGridView_datos_bancos.DataSource = bancos; //le asignamos al DataGridView el contenido del dataSet
                    ajustarDatagridBanco();
                    conexion.Close();//cerramos la conexion
                    dataGridView_datos_bancos.AllowUserToAddRows = false;       //eliminamos la ultima fila del datagridview que se autoagrega
                }
                catch (Exception ex)
                {
                    //en caso de haber una excepcion que nos mande un mensaje de error
                    MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", ex.Message);
                }
            }
        }
        private void ajustarDatagridBanco()
        {
            dataGridView_datos_bancos.Columns[2].Visible = false;
            dataGridView_datos_bancos.Columns[4].Visible = false;
            dataGridView_datos_bancos.Columns[5].Visible = false;
            dataGridView_datos_bancos.Columns[6].Visible = false;
            dataGridView_datos_bancos.Columns[0].HeaderText = "Fecha";
            dataGridView_datos_bancos.Columns[0].Name = "Fecha";
            dataGridView_datos_bancos.Columns[1].HeaderText = "Concepto";
            dataGridView_datos_bancos.Columns[1].Name = "Concepto";
            dataGridView_datos_bancos.Columns[3].HeaderText = "Importe";
            dataGridView_datos_bancos.Columns[3].Name = "Importe";

            dataGridView_datos_bancos.Columns["Fecha"].Width = 70;
            dataGridView_datos_bancos.Columns["Concepto"].Width = 400;
            dataGridView_datos_bancos.Columns["Importe"].Width = 100;
        }

        private void ajustarDatagridVencimientos()
        {
            dataGridView_vencimientos.Columns[0].Visible = false;
            dataGridView_vencimientos.Columns[3].Width = 250;
            dataGridView_vencimientos.Columns[1].Width = 70;
            dataGridView_vencimientos.Columns[2].Visible = false;
            dataGridView_vencimientos.Columns[6].Visible = false;
            //dataGridView_vencimientos.Columns[9].Visible = false;
            dataGridView_vencimientos.Columns[5].Width = 250;
        }

        private void button_importarBanco_Click(object sender, EventArgs e)
        {

            //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
                                                                             //solo los archivos excel

            dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana

            dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            //si al seleccionar el archivo damos Ok
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //el nombre del archivo sera asignado al textbox
                //txtArchivo.Text = dialog.FileName;
                //hoja = txtHoja.Text; //la variable hoja tendra el valor del textbox donde colocamos el nombre de la hoja
                LLenarGrid(dialog.FileName, "1"); //se manda a llamar al metodo
            }
        }

        private void dataGridView_datos_bancos_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(dataGridView_datos_bancos.CurrentRow.Cells[3].Value) > 0)
            {
                DataTable busqueda = vencimientos;
                busqueda.DefaultView.RowFilter = "Importe = " + Convert.ToDouble(dataGridView_datos_bancos.CurrentRow.Cells[3].Value) + "";
                this.dataGridView_vencimientos.DataSource = busqueda;
            }
        }
    }
}
