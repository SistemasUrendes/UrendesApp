using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProvisionesForms
{
    public partial class FormProvisionesDotarAplicar2 : Form
    {
        String id_comunidad_cargado;
        String id_provision;
        String dedondevengo;


        public FormProvisionesDotarAplicar2(String id_comunidad_cargado, String id_provision, String dedondevengo)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.id_provision = id_provision;
            this.dedondevengo = dedondevengo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_importe.Text == textBox_acumulado.Text)
            {
                String fecha = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
                String fechaActual = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd hh:mm:ss");

                String sqlSelect = "SELECT Nombre, IdSubCuenta, IdBloque, SaldoActual FROM com_provisiones WHERE IdProvision = " + id_provision;
                DataTable filaProvision = Persistencia.SentenciasSQL.select(sqlSelect);

                String idEntidadComunidad = (Persistencia.SentenciasSQL.select("SELECT IdEntidad FROM com_comunidades WHERE IdComunidad = " + id_comunidad_cargado)).Rows[0][0].ToString();

                String sqlInsertarOP = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Descripcion, IdEstado, ImpOp, ImpOpPte, NumMov, Guardada, IdURD, FAct) VALUES (" + id_comunidad_cargado + "," + idEntidadComunidad + "," + filaProvision.Rows[0][1].ToString() + ",1,'" + fecha + "','" + filaProvision.Rows[0][0].ToString() + "','1'," + textBox_importe.Text.Replace(',', '.') + "," + textBox_importe.Text.Replace(',', '.') + ",0,'Si'," + Login.getId() + ",'" + fechaActual + "')";

                int id_opNueva = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertarOP);

                //INSERTAR BLOQUE
                String sqlBloque = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES (" + id_opNueva + "," + filaProvision.Rows[0][2].ToString() + ",1, " + textBox_importe.Text.Replace(',', '.')  + ")";

                Persistencia.SentenciasSQL.InsertarGenerico(sqlBloque);

                //INSERTAR IVA
                String sqlIVA = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + id_opNueva + ", " + textBox_importe.Text.Replace(',', '.') + " ,1,0)";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA);

                //INSERTAR VENCIMIENTO

                String sqlVencimiento = "INSERT INTO com_opdetalles ( IdOp, IdEntidad, Fecha, Importe, ImpOpDetPte, NumMov, IdEstado) VALUES(" + id_opNueva + "," + idEntidadComunidad + ",'" + fecha + "'," + textBox_importe.Text.Replace(',', '.') + "," + textBox_importe.Text.Replace(',', '.') + ",0,1)";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlVencimiento);


                for (int a = 0; a < dataGridView_liquidaciones.Rows.Count; a++)
                {
                    if (dataGridView_liquidaciones.Rows[a].Cells[3].Value != null)
                    {
                        double por = Convert.ToDouble(dataGridView_liquidaciones.Rows[a].Cells[1].Value.ToString()) / 100;
                        double importe = Convert.ToDouble(dataGridView_liquidaciones.Rows[a].Cells[2].Value.ToString());

                        String sqlInsertLiquidacion = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + id_opNueva.ToString() + "," + dataGridView_liquidaciones.Rows[a].Cells[3].Value.ToString() + "," + por.ToString().Replace(',', '.') + "," + importe.ToString().Replace(',', '.') + ")";

                        Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertLiquidacion);
                    }
                }
                
                //ACTUALIZAMOS EL SALDO DE LA PROVISION
                double anterior_provision = Convert.ToDouble(filaProvision.Rows[0][3].ToString());

                if (dedondevengo.Contains("Dotar"))
                {
                    anterior_provision = anterior_provision + Convert.ToDouble(textBox_importe.Text);
                }else {
                    anterior_provision = anterior_provision - Convert.ToDouble(textBox_importe.Text);
                }
                String sqlUpdateProvision = "UPDATE com_provisiones SET SaldoActual=" + anterior_provision.ToString().Replace(',','.') + " WHERE IdProvision = " + id_provision;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdateProvision);
                
                //ABRO LA OPERACION
                OperacionesForms.FromOperacionesVer nueva = new OperacionesForms.FromOperacionesVer(id_comunidad_cargado, id_opNueva.ToString());
                nueva.Show();
                this.Close();
            }
            else {
                MessageBox.Show("Los Importes no coinciden");
            }
        }

        private void FormProvisionesDotarAplicar2_Load(object sender, EventArgs e) {
            this.Text = "Provisiones " + dedondevengo;

            textBox_acumulado.Text = "0";

            DataGridViewTextBoxColumn idLiquidacion = new DataGridViewTextBoxColumn();
            idLiquidacion.HeaderText = "IdLiquidacion";

            DataGridViewTextBoxColumn liquidacion = new DataGridViewTextBoxColumn();
            liquidacion.HeaderText = "Liquidacion";
            liquidacion.ReadOnly = true;

            DataGridViewTextBoxColumn porcentaje = new DataGridViewTextBoxColumn();
            porcentaje.HeaderText = "%";

            DataGridViewTextBoxColumn importe = new DataGridViewTextBoxColumn();
            importe.HeaderText = "Importe";

            dataGridView_liquidaciones.Columns.Add(liquidacion);
            dataGridView_liquidaciones.Columns.Add(porcentaje);
            dataGridView_liquidaciones.Columns.Add(importe);
            dataGridView_liquidaciones.Columns.Add(idLiquidacion);

            dataGridView_liquidaciones.Columns[0].Name = "Liquidacion";
            dataGridView_liquidaciones.Columns[1].Name = "%";
            dataGridView_liquidaciones.Columns[2].Name = "Importe";
            dataGridView_liquidaciones.Columns[3].Name = "IdLiquidacion";

            dataGridView_liquidaciones.Columns[3].Visible = false;

        }
        public void recogerBloque(String id_liquidacion, String nombre_liquidacion)
        {
            dataGridView_liquidaciones.SelectedCells[0].Value = nombre_liquidacion;
            dataGridView_liquidaciones.SelectedCells[3].Value = id_liquidacion;
        }
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Space)
            {
                if (dataGridView_liquidaciones.CurrentCell.ColumnIndex == 0)
                {
                    LiquidacionesForms.Liquidaciones nueva = new LiquidacionesForms.Liquidaciones(this, this.Name, id_comunidad_cargado);
                    nueva.ControlBox = true;
                    nueva.TopMost = true;
                    nueva.WindowState = FormWindowState.Normal;
                    nueva.StartPosition = FormStartPosition.CenterScreen;
                    dataGridView_liquidaciones.ClearSelection();
                    dataGridView_liquidaciones.Rows[dataGridView_liquidaciones.CurrentRow.Index].Selected = true;
                    nueva.Show();
                }
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            double totalAcumulado = 0.0;
            if (e.ColumnIndex == 1 && dataGridView_liquidaciones.Rows[e.RowIndex].Cells[1].Value != null)
            {
                decimal porcentaje = Convert.ToDecimal(string.Format("{0:F2}", dataGridView_liquidaciones.Rows[e.RowIndex].Cells[1].Value.ToString()));
                decimal importe = Convert.ToDecimal(string.Format("{0:F2}", textBox_importe.Text));
                decimal total = Convert.ToDecimal(string.Format("{0:F2}", importe * porcentaje / 100));

                dataGridView_liquidaciones.Rows[e.RowIndex].Cells[2].Value = total;
            }
            else if ((e.ColumnIndex == 1 && dataGridView_liquidaciones.Rows[e.RowIndex].Cells[1].Value == null))
            {
                decimal importe = Convert.ToDecimal(string.Format("{0:F2}", textBox_importe.Text));
                decimal importeAcumulado = Convert.ToDecimal(string.Format("{0:F2}", textBox_acumulado.Text));
                dataGridView_liquidaciones.Rows[e.RowIndex].Cells[1].Value = 50.0;
                dataGridView_liquidaciones.Rows[e.RowIndex].Cells[2].Value = Convert.ToDecimal(string.Format("{0:F2}", importe - importeAcumulado));
            }
            if (e.ColumnIndex == 2)
            {
                for (int a = 0; a < dataGridView_liquidaciones.Rows.Count; a++)
                {
                    if (dataGridView_liquidaciones.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        totalAcumulado = totalAcumulado + Convert.ToDouble(dataGridView_liquidaciones.Rows[a].Cells[2].Value);
                    }
                }
                textBox_acumulado.Text = totalAcumulado.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
