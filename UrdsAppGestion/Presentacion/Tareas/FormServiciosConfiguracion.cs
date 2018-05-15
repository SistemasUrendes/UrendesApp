﻿using System;
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
    public partial class FormServiciosConfiguracion : Form
    {
        String idComunidad;
        DataTable tablaBloques;
        DataTable tablaAreas;

        public FormServiciosConfiguracion()
        {
            InitializeComponent();
            
        }

        private void FormServiciosConfiguracion_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
            cargarAreas();
        }

        private void rellenarComboBox()
        {
            DataTable comunidades;
            String sqlComboTipo = "SELECT com_comunidades.IdComunidad, ctos_entidades.NombreCorto FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.FBaja)Is Null))";
            comunidades = Persistencia.SentenciasSQL.select(sqlComboTipo);

            comboBoxComunidades.DataSource = comunidades;
            comboBoxComunidades.DisplayMember = "NombreCorto";
            comboBoxComunidades.ValueMember = "IdComunidad";
        }

        private void buttonAddBloque_Click(object sender, EventArgs e)
        {
            FormInsertarBloque nueva = new FormInsertarBloque(this, comboBoxComunidades.SelectedValue.ToString());
            nueva.Show();
        }

        private void comboBoxComunidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idComunidad = comboBoxComunidades.SelectedValue.ToString();
            cargarBloques();
        }

        public void cargarBloques(String idComunidad)
        {
           
            String sqlSelect = "SELECT com_bloques.IdBloque,com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdTipoBloque) = 1) AND((com_bloques.IdComunidad) = " + idComunidad + "))";
            tablaBloques = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewBloque.DataSource = tablaBloques;

            if (dataGridViewBloque.Rows.Count > 0)
            {
                dataGridViewBloque.Columns["IdBloque"].Visible = false;
                dataGridViewBloque.Columns["Descripcion"].Width = 350;
            }
        }

        public void cargarBloques()
        {
            
            String sqlSelect = "SELECT com_bloques.IdBloque,com_bloques.Descripcion FROM com_bloques WHERE(((com_bloques.IdTipoBloque) = 1) AND((com_bloques.IdComunidad) = " + this.idComunidad + "))";
            tablaBloques = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewBloque.DataSource = tablaBloques;

            if (dataGridViewBloque.Rows.Count > 0)
            {
                dataGridViewBloque.Columns["IdBloque"].Visible = false;
                dataGridViewBloque.Columns["Descripcion"].Width = 350;
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este Bloque ?", "Borrar Bloque", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM exp_elementos WHERE IdElemento = " + dataGridViewBloque.SelectedRows[0].Cells[0].Value.ToString() ;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarBloques();
            }
        }
        
        private void dataGridViewBloque_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridViewBloque.HitTest(e.X, e.Y);
                if (hti.RowIndex > -1)
                {
                    dataGridViewBloque.ClearSelection();
                    dataGridViewBloque.Rows[hti.RowIndex].Selected = true;
                    dataGridViewBloque.Columns[hti.ColumnIndex].Selected = true;
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void buttonAddArea_Click(object sender, EventArgs e)
        {
            FormInsertarArea nueva = new FormInsertarArea(this);
            nueva.Show();
        }

        private void textBoxFiltroBloque_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = tablaBloques;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroBloque.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewBloque.DataSource = busqueda;
        }

        private void dataGridViewBloque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormAreasBloque nueva = new FormAreasBloque(this, dataGridViewBloque.SelectedRows[0].Cells[0].Value.ToString(), dataGridViewBloque.SelectedRows[0].Cells[1].Value.ToString());
            nueva.Show();
        }

        public void cargarAreas()
        {
            String sqlSelect = "SELECT IdCatElemento,Nombre, Descripcion FROM exp_catElemento";
            tablaAreas = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewAreas.DataSource = tablaAreas;
            if (dataGridViewAreas.Rows.Count > 0)
            {
                dataGridViewAreas.Columns["IdCatElemento"].Visible = false;
                dataGridViewAreas.Columns["Nombre"].Width = 100;
                dataGridViewAreas.Columns["Descripcion"].Width = 190;
            }
        }

        private void textBoxAreas_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = tablaAreas;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxAreas.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewAreas.DataSource = busqueda;
        }
    }
}
