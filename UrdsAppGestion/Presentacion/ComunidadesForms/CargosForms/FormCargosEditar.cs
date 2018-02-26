using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    public partial class FormCargosEditar : Form
    {
        String id_comunidad_cargado = "0";

        public FormCargosEditar(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        private void FormCargosEditar_Load(object sender, EventArgs e)
        {
            cargardatagrid();
        }
        public void cargardatagrid()
        {
            if (id_comunidad_cargado != "0")
            {
                String sqlSelect = "SELECT com_cargos.IdCargo, com_cargos.Cargo, com_organos.Nombre, com_cargos.Baja FROM com_organos RIGHT JOIN com_cargos ON com_organos.IdOrgano = com_cargos.IdOrgano WHERE(((com_cargos.IdComunidad) = " + id_comunidad_cargado + "));";

                dataGridView1.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id_comunidad_cargado != "0" && dataGridView1.SelectedRows.Count > 0)
            {
                String sqlUpdate = "UPDATE com_cargos SET Baja = -1 WHERE IdCargo = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                cargardatagrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id_comunidad_cargado != "0" && dataGridView1.SelectedRows.Count > 0)
            {
                String sqlUpdate = "UPDATE com_cargos SET Baja = 0 WHERE IdCargo = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                cargardatagrid();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormNuevoCargos nueva = new FormNuevoCargos(this,id_comunidad_cargado);
            nueva.Show();
        }
    }
}
