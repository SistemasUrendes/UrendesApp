﻿using System;
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
    public partial class FormCargos : Form
    {
        DataTable cargos1;
        String id_comunidad_cargado;
        Tareas.FormInsertarGestion form_anterior;
        Tareas.FormInsertarContacto form_anterior2;

        public FormCargos(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }

        public FormCargos(Tareas.FormInsertarGestion form_anterior, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
        }

        public FormCargos(Tareas.FormInsertarContacto form_anterior2, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior2 = form_anterior2;
        }

        private void verFichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void FormCargos_Load(object sender, EventArgs e)
        {
            cargardatagrid();

            //MUESTRO LOS VIGENTES NADA MAS CARGAR
            DataTable busqueda = cargos1;
            busqueda.DefaultView.RowFilter = "FFin is Null";
            dataGridView_ListadeCargos.DataSource = busqueda;

            if (form_anterior != null || form_anterior2 != null)
            {
                buttonEnviar.Visible = true;
            }
        }
        public void cargardatagrid() {
            String sqlSelect = "SELECT com_cargoscom.IdCargoCom, com_cargos.Cargo, com_bloques.Descripcion AS Bloque, com_organos.Nombre AS Organo, ctos_entidades.Entidad, com_comuneros.IdEntidad, com_divisiones.Division, com_cargoscom.FInicio, com_cargoscom.FFin, com_cargos.IdCargo FROM(((((com_cargos INNER JOIN com_cargoscom ON com_cargos.IdCargo = com_cargoscom.IdCargo) INNER JOIN com_comuneros ON com_cargoscom.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN com_organos ON com_cargos.IdOrgano = com_organos.IdOrgano) LEFT JOIN com_bloques ON com_cargos.IdBloque = com_bloques.IdBloque) LEFT JOIN com_divisiones ON com_cargoscom.IdDivision = com_divisiones.IdDivision GROUP BY com_cargoscom.IdCargoCom, com_cargos.Cargo, com_organos.Nombre, ctos_entidades.Entidad, com_comuneros.IdEntidad, com_divisiones.Division, com_cargoscom.FInicio, com_cargoscom.FFin, com_cargoscom.IdComunidad, com_cargoscom.IdComunidad HAVING(((com_cargoscom.IdComunidad) = " + id_comunidad_cargado + "))";

            cargos1 = Persistencia.SentenciasSQL.select(sqlSelect);

            dataGridView_ListadeCargos.DataSource = cargos1;

            dataGridView_ListadeCargos.Columns["IdEntidad"].Visible = false;
            dataGridView_ListadeCargos.Columns["IdCargoCom"].Visible = false;
            dataGridView_ListadeCargos.Columns["Entidad"].Width = 200;
            dataGridView_ListadeCargos.Columns["IdCargo"].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable busqueda = cargos1;
            busqueda.DefaultView.RowFilter = "FFin is Null OR FFin IS NOT NULL";
            dataGridView_ListadeCargos.DataSource = busqueda;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable busqueda = cargos1;
            busqueda.DefaultView.RowFilter = "FFin is Null";
            dataGridView_ListadeCargos.DataSource = busqueda;
        }

        private void verEntidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad((int)dataGridView_ListadeCargos.SelectedCells[5].Value);
            nueva.Show();
        }

        private void dataGridView_ListadeCargos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_ListadeCargos.HitTest(e.X, e.Y);
                dataGridView_ListadeCargos.ClearSelection();
                dataGridView_ListadeCargos.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCargosFechaBaja nueva = new FormCargosFechaBaja(this, dataGridView_ListadeCargos.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCargosAlta nueva = new FormCargosAlta(this,id_comunidad_cargado);
            nueva.Show();
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este Cargo ?", "Borrar Cargo", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_cargoscom WHERE IdCargoCom =  " + dataGridView_ListadeCargos.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargardatagrid();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormCargosEditar nueva = new FormCargosEditar(id_comunidad_cargado);
            nueva.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormOrganos nueva = new FormOrganos(id_comunidad_cargado);
            nueva.Show();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Informes.FormVerInformeCargos nueva = new Informes.FormVerInformeCargos(id_comunidad_cargado);
            nueva.Show();
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            String idEntidad = dataGridView_ListadeCargos.SelectedRows[0].Cells["IdEntidad"].Value.ToString();
            if (form_anterior != null ) form_anterior.recibirOrgano(idEntidad);
            if (form_anterior2 != null) form_anterior2.recibirCargo(idEntidad, dataGridView_ListadeCargos.SelectedRows[0].Cells["Entidad"].Value.ToString(), dataGridView_ListadeCargos.SelectedRows[0].Cells["Cargo"].Value.ToString());
            this.Close();
        }
        
        private void añadirOrganoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSeleccionarOrgano nueva = new FormSeleccionarOrgano(this, id_comunidad_cargado,dataGridView_ListadeCargos.SelectedCells[9].Value.ToString());
            nueva.Show();
        }

        public void addCargoOrgano(String idOrgano, String idCargo)
        {
            String sqlUpdate = "UPDATE com_cargos SET IdOrgano = '" + idOrgano + "' WHERE IdCargo = '" + idCargo + "'";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            cargardatagrid();
        }
    }
}
