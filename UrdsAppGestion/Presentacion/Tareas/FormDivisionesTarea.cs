using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.Tareas
{
    public partial class FormDivisionesTarea : Form
    {
        String idTarea;
        DataTable divisiones;
        FormVerTarea formAnt;
        public FormDivisionesTarea(FormVerTarea formAnt,String idTarea)
        {
            InitializeComponent();
            this.idTarea = idTarea;
            this.formAnt = formAnt;
        }

        private void FormDivisionesTarea_Load(object sender, EventArgs e)
        {
            cargarDivisiones();
        }


        private void cargarDivisiones()
        {
            String sqlSelect = "SELECT com_divisiones.IdDivision, exp_areaTarea.IdArea, com_divisiones.Division, com_tipodivs.TipoDivision,If((SELECT Count(*) FROM exp_areaTarea WHERE (((exp_areaTarea.IdArea)=com_divisiones.IdDivision) AND ((exp_areaTarea.IdTarea)= " + idTarea + "))) > 0,'true','false') AS Selected FROM((com_divisiones INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision) INNER JOIN (exp_areaTarea INNER JOIN exp_area ON exp_areaTarea.IdArea = exp_area.IdArea) ON com_subcuotas.IdBloque = exp_area.IdBloque) INNER JOIN com_tipodivs ON com_divisiones.IdTipoDiv = com_tipodivs.IdTipoDiv WHERE(((exp_areaTarea.IdTarea) = " + idTarea + ")) GROUP BY com_divisiones.IdDivision ORDER BY com_divisiones.IdDivision";
            divisiones = Persistencia.SentenciasSQL.select(sqlSelect);
                           
            dataGridViewServicios.DataSource = divisiones;
            
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Sel";
            checkColumn.HeaderText = "Sel";
            checkColumn.Width = 50;
            checkColumn.ReadOnly = false;
            checkColumn.FillWeight = 10;
            dataGridViewServicios.Columns.Add(checkColumn);

            ajustarDatagridServicios();
            
        }

        private void ajustarDatagridServicios()
        {
            if (dataGridViewServicios.Rows.Count > 0)
            {
                dataGridViewServicios.Columns["IdDivision"].Visible = false;
                dataGridViewServicios.Columns["IdArea"].Visible = false;
                dataGridViewServicios.Columns["Division"].Width = 200;
                dataGridViewServicios.Columns["TipoDivision"].Width = 200;
                dataGridViewServicios.Columns["Selected"].Visible = false;


                dataGridViewServicios.Columns["Division"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewServicios.Columns["TipoDivision"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridViewServicios.Columns["Sel"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewRow row in dataGridViewServicios.Rows)
            {
                row.Cells["Sel"].Value = row.Cells["Selected"].Value;
            }
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            String sqlSelectAntiguos = "SELECT exp_areaTarea.IdAreaTarea FROM com_divisiones INNER JOIN exp_areaTarea ON com_divisiones.IdDivision = exp_areaTarea.IdArea WHERE(((exp_areaTarea.IdTarea) = " + idTarea + ") AND((exp_areaTarea.TipoArea) = 'D'))";
            DataTable antiguo = Persistencia.SentenciasSQL.select(sqlSelectAntiguos);

            foreach (DataRow rowAnt in antiguo.Rows)
            {
                String sqlBorrar = "DELETE FROM exp_areaTarea WHERE (exp_areaTarea.IdAreaTarea = '" + rowAnt[0].ToString() + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
            }

            foreach (DataRow row in divisiones.Rows)
            {
                if (row["Selected"].ToString() == "true")
                {
                    String sqlInsert = "INSERT INTO exp_areaTarea (IdArea,IdTarea,TipoArea) VALUES ('" + row[0] + "','" + idTarea + "','D')";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                }
            }
            formAnt.cargarDivisiones();
            formAnt.recibirDivisiones();
            this.Close();
        }

        private void cambiarSeleccionFila()
        {
            if (dataGridViewServicios.SelectedRows[0].Index > -1)
            {
                if (dataGridViewServicios.SelectedRows[0].Cells["Sel"].Value.ToString() == "false")
                {
                    dataGridViewServicios.SelectedRows[0].Cells["Sel"].Value = "true";
                    divisiones.Rows[indiceTabla(dataGridViewServicios.SelectedRows[0].Cells[0].Value.ToString())]["Selected"] = "true";
                }
                else if (dataGridViewServicios.SelectedRows[0].Cells["Sel"].Value.ToString() == "true")
                {
                    dataGridViewServicios.SelectedRows[0].Cells["Sel"].Value = "false";
                    divisiones.Rows[indiceTabla(dataGridViewServicios.SelectedRows[0].Cells[0].Value.ToString())]["Selected"] = "false";
                }
            }
        }

        private int indiceTabla(String idServicio)
        {
            int i = 0;
            foreach (DataRow row in divisiones.Rows)
            {
                if (row[0].ToString() == idServicio) return i;
                i++;
            }
            return -1;
        }

        private void dataGridViewServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cambiarSeleccionFila();
        }
    }
}
