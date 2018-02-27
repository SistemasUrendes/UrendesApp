using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.MantenimientoForms
{
    public partial class FormInsertarPendientes : Form
    {

        DataTable filas_pegadas = new DataTable();
        
        public FormInsertarPendientes()
        {
            InitializeComponent();
        }


        //INICIALIZA LOS DropDownList
        private void FormInsertarPendientes_Load(object sender, EventArgs e)
        {
            String sqlComboCom = "SELECT ctos_entidades.NombreCorto, com_comunidades.IdComunidad, com_comunidades.FBaja FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.FBaja)Is Null))";
            comboBox_IdComunidad.DataSource = Persistencia.SentenciasSQL.select(sqlComboCom);
            comboBox_IdComunidad.DisplayMember = "NombreCorto";
            comboBox_IdComunidad.ValueMember = "IdComunidad";

            filas_pegadas.Columns.Clear();
            filas_pegadas.Columns.Add("Fecha");
            filas_pegadas.Columns.Add("Concepto");
            filas_pegadas.Columns.Add("ID");
            filas_pegadas.Columns.Add("Descripción");
            filas_pegadas.Columns.Add("Importe");
            dataGridView_Insertar.DataSource = filas_pegadas;
        }

        private void button_insertar_Click(object sender, EventArgs e)
        {
            String sqlInsert;

            int rows = dataGridView_Insertar.RowCount;
            for (int i = 0; i < rows; i++)
            {
                progressBar_insert.Maximum = rows;
                //VALORES DE LA CONSULTA SQL
                int idCom = (int)comboBox_IdComunidad.SelectedValue;
                int id_op;
                int idBloque = (int)comboBox_IdBloque.SelectedValue;
                int idLiquid = (int)comboBox_liquid.SelectedValue;
                int idCuota = (int)comboBox_cuota.SelectedValue;
                String fechaAhora = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd hh:mm:ss");
                String idEntidad;
                String idComunidad = dataGridView_Insertar.Rows[i].Cells[2].Value.ToString();
                String fecha = Convert.ToDateTime(dataGridView_Insertar.Rows[i].Cells[0].Value.ToString()).ToString("yyyy-MM-dd");
                String impOp = dataGridView_Insertar.Rows[i].Cells[4].Value.ToString().Replace(',', '.');
                impOp = impOp.Substring(0, impOp.LastIndexOf(".") + 3);
                String descripcion = dataGridView_Insertar.Rows[i].Cells[3].Value.ToString();

                //CONSULTA PARA OBTENER IdEntidad CON IDComunidad SELECCIONADA DEL comboBox
                String sqlIdEntidad = "SELECT com_comuneros.IdEntidad FROM((com_divisiones INNER JOIN com_asociacion ON com_divisiones.IdDivision = com_asociacion.IdDivision) INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_divisiones.IdDivision) = " + idComunidad + ") AND((com_divisiones.IdComunidad) = " + idCom + "))";
                DataTable dt = Persistencia.SentenciasSQL.select(sqlIdEntidad);

                //COMPRUEBA QUE idEntiedad EXISTA EN idComunidad
                if (dt.Rows.Count > 0)
                {
                    idEntidad = dt.Rows[0][0].ToString();
                    sqlInsert = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Descripcion, IdEstado,IdCuota,IdDivision,ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES " + "(" + comboBox_IdComunidad.SelectedValue + "," + idEntidad + "," + 70000 + "," + 1 + ",'" + fecha + "','" + descripcion + "',1," + idCuota + "," + idComunidad + "," + impOp + "," + impOp + ",0,'Si'," + Login.getId() + ",'" + fechaAhora + "')";
                    id_op = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert);
                    //MessageBox.Show(sqlInsert);
                    //return;
                    //CREAMOS IVA
                    String sqlInsertIva = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + id_op + "," + impOp + "," + 1 + "," + 0 + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertIva);


                    //CREAMOS REPARTO (Falta comprobar que tenga seleccionado idBloque en el comboBox)
                    String sqlInsertReparto = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES (" + id_op + "," + idBloque + "," + 1 + "," + impOp + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertReparto);


                    //CREAMOS VENCIMIENTOS
                    String sqlInsertVencimiento = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, Importe, ImpOpDetPte) VALUES (" + id_op + "," + idEntidad + ",'" + fecha + "'," + impOp + "," + impOp + ")";
                    int idVenc = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertVencimiento);


                    //LIQUIDACIONES (Falta comprobar que tenga seleccionado idBloque en el comboBox)
                    String sqlInsertarLiquidacionDet = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + id_op + "," + idLiquid + "," + 1 + "," + impOp + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertarLiquidacionDet);


                    //GENERAMOS RECIBO
                    String sqlRecibo = "INSERT INTO com_recibos (IdComunidad, IdEntidad, Fecha, ImpRbo, ImpRboPte, Referencia,IdCuota) VALUES(" + idCom.ToString() + "," + idEntidad + ",'" + fecha + "'," + impOp + "," + impOp + ",'" + descripcion + "'," + idCuota + ")";
                    int recibo = Persistencia.SentenciasSQL.InsertarGenericoID(sqlRecibo);
                    Logica.FuncionesTesoreria.ActualizoIdReciboVencimiento(recibo.ToString(), idVenc.ToString());

                    //PROGRESS BAR ITEMS
                    progressBar_insert.Visible = true;
                    progressBar_insert.Increment(1);


                    if (i == dataGridView_Insertar.RowCount - 1)
                    {
                        MessageBox.Show(i + 1 + " Operaciones completadas satisfactoriamente");
                        progressBar_insert.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se puede realizar la operación porque no se encuentra la entidad con la comunidad " + idComunidad);
                    return;
                }
            }
            if (rows == 0)
            {
                MessageBox.Show("No hay ningún elemento añadido en la tabla");
            }

        }

        private void dataGridView_Insertar_KeyDown(object sender, KeyEventArgs e)
        {
            filas_pegadas.Columns.Clear();
            filas_pegadas.Columns.Add("Fecha");
            filas_pegadas.Columns.Add("Concepto");
            filas_pegadas.Columns.Add("ID");
            filas_pegadas.Columns.Add("Descripción");
            filas_pegadas.Columns.Add("Importe");

            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject d = dataGridView_Insertar.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                double total = 0.00;
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');

                foreach (string line in lines)
                {
                    DataRow row2 = filas_pegadas.NewRow();
                    if (line.Length > 0)
                    {
                        string[] cells = line.Split('\t');
                        for (int i = 0; i < cells.GetLength(0); ++i)
                        {
                            row2[i] = cells[i];

                            //CALCULO DEL TOTAL AJUSTANDO EL STRING A DOUBLE
                            if (i == 4)
                            {
                                String cantidad = cells[i].ToString().Replace('.', ',');
                                cantidad = cantidad.Substring(0, cantidad.LastIndexOf(",") + 3);
                                total += Convert.ToDouble(cantidad);
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                    filas_pegadas.Rows.Add(row2);
                }
                dataGridView_Insertar.DataSource = filas_pegadas;

                //ACTUALIZAR LABELS
                labelElementos.Text = dataGridView_Insertar.RowCount + " Elementos";
                labelTotal.Text = "Total: " + total.ToString(".##");

            }
        }

        //ACTUALIZA EL comboBox_IdBloque Y comboBox_liquid SEGÚN VALOR DE comboBox_IdComunidad
        private void comboBox_IdComunidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idCom = (int)comboBox_IdComunidad.SelectedValue;
            String sqlComboBloque = "SELECT com_bloques.IdBloque, com_bloques.Descripcion FROM com_bloques WHERE com_bloques.IdComunidad = " + idCom;
            comboBox_IdBloque.DataSource = Persistencia.SentenciasSQL.select(sqlComboBloque);
            comboBox_IdBloque.DisplayMember = "Descripcion";
            comboBox_IdBloque.ValueMember = "IdBloque";

            String sqlComboLiquid = "SELECT com_liquidaciones.IdLiquidacion, com_liquidaciones.Liquidacion FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_ejercicios.IdComunidad) = " + idCom + "))";
            comboBox_liquid.DataSource = Persistencia.SentenciasSQL.select(sqlComboLiquid);
            comboBox_liquid.DisplayMember = "Liquidacion";
            comboBox_liquid.ValueMember = "IdLiquidacion";




        }

        //ACTUALIZA EL comboBox_cuota SEGÚN VALOR DE comboBox_liquid
        private void comboBox_liquid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idLiq = (int)comboBox_liquid.SelectedValue;
            String sqlComboCuotas = "SELECT com_cuotas.Descripcion, com_cuotas.IdCuota FROM com_cuotas WHERE com_cuotas.IdLiquidacion = " + idLiq;
            comboBox_cuota.DataSource = Persistencia.SentenciasSQL.select(sqlComboCuotas);
            comboBox_cuota.DisplayMember = "Descripcion";
            comboBox_cuota.ValueMember = "IdCuota";
        }

        private void dataGridView_Insertar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
