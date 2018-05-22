﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.Elementos
{
    public partial class FormElementos : Form
    {
        String idCategoria; 
        List<String> idElementosAtras;
        List<String> nombreElementosAtras;
        String nombreServicio;
        Tareas.FormServiciosConfiguracion form_anterior;
        

        public FormElementos(Tareas.FormServiciosConfiguracion form_anterior, String idCategoria, String nombreServicio)
        {
            InitializeComponent();
            idElementosAtras = new List<String>();
            nombreElementosAtras = new List<String>();
            this.idCategoria = idCategoria;
            this.form_anterior = form_anterior;
            this.nombreServicio = nombreServicio;
        }

        private void FormElementos_Load(object sender, EventArgs e)
        {
            rellenarTreeViewInicio();
            labelServicio.Text = nombreServicio;
        }


        public void rellenarTreeViewInicio()
        {
            updateRuta();
            treeViewElementos.Nodes.Clear();
            DataTable elementos;
            String sqlSelect = "SELECT exp_detElemento.IdDetElemento, exp_detElemento.IdDetElementoPrev, exp_detElemento.Nombre, exp_detElemento.Descripcion FROM exp_detElemento WHERE(((exp_detElemento.IdDetElementoPrev) = 0) AND((exp_detElemento.IdCatElemento) = " + idCategoria + "))";
            elementos = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach (DataRow row in elementos.Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["Nombre"].ToString() + " : " + row["Descripcion"].ToString();
                node.Tag = row["IdDetElemento"].ToString();
                treeViewElementos.Nodes.Add(node);
                rellenarSubElementos((int)row["IdDetElemento"], node);
            }
        }

        public void rellenarTreeView(String idElemento)
        {
            treeViewElementos.Nodes.Clear();
            DataTable elementos;
            String sqlSelect = "SELECT exp_detElemento.IdDetElemento, exp_detElemento.IdDetElementoPrev, exp_detElemento.Nombre, exp_detElemento.Descripcion FROM exp_detElemento WHERE(((exp_detElemento.IdDetElementoPrev) = " + idElemento + ") AND((exp_detElemento.IdCatElemento) = " + idCategoria + "))";
            elementos = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach (DataRow row in elementos.Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["Nombre"].ToString() + " : " + row["Descripcion"].ToString();
                node.Tag = row["IdDetElemento"];
                treeViewElementos.Nodes.Add(node);
                rellenarSubElementos((int)row["IdDetElemento"], node);
            }
        }

        private void rellenarSubElementos(int idElemento, TreeNode node)
        {
            DataTable subElementos;
            String sqlSelect = "SELECT exp_detElemento.IdDetElemento, exp_detElemento.IdDetElementoPrev, exp_detElemento.Nombre, exp_detElemento.Descripcion FROM exp_detElemento WHERE(((exp_detElemento.IdDetElementoPrev) = " + idElemento + ") AND((exp_detElemento.IdCatElemento) = " + idCategoria + "))";
            subElementos = Persistencia.SentenciasSQL.select(sqlSelect);

            if (subElementos.Rows.Count == 0) { return; }

            foreach (DataRow row in subElementos.Rows)
            {
                TreeNode subNode = new TreeNode();
                subNode.Text = row["Nombre"].ToString() + " : " + row["Descripcion"].ToString();
                subNode.Tag = row["IdDetElemento"].ToString();
                node.Nodes.Add(subNode);
            }
        }
        
        private void treeViewElementos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String sqlSelect = "SELECT exp_detElemento.IdDetElemento, exp_detElemento.IdDetElementoPrev, exp_detElemento.Nombre, exp_detElemento.Descripcion FROM exp_detElemento WHERE(((exp_detElemento.IdDetElementoPrev) = " + e.Node.Tag.ToString() + ") AND((exp_detElemento.IdCatElemento) = " + idCategoria + "))";
            DataTable subElementos = Persistencia.SentenciasSQL.select(sqlSelect);
            if (subElementos.Rows.Count > 0)
            {
                idElementosAtras.Add(e.Node.Tag.ToString());
                nombreElementosAtras.Add(e.Node.Text.ToString());
                rellenarTreeView(e.Node.Tag.ToString());
                updateRuta();
            }
        }

        private void buttonAtras_Click(object sender, EventArgs e)
        {
            if (idElementosAtras.Count > 1)
            {
                idElementosAtras.RemoveAt(idElementosAtras.Count - 1);
                nombreElementosAtras.RemoveAt(nombreElementosAtras.Count - 1);
                rellenarTreeView(idElementosAtras.ElementAt(idElementosAtras.Count - 1));
                updateRuta();
            }
            else
            {
                if (idElementosAtras.Count == 1)
                {
                    idElementosAtras.RemoveAt(idElementosAtras.Count - 1);
                    nombreElementosAtras.RemoveAt(nombreElementosAtras.Count - 1);
                    updateRuta();
                }
                rellenarTreeViewInicio();
            }
        }

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            idElementosAtras.Clear();
            nombreElementosAtras.Clear();
            rellenarTreeViewInicio();
        }

        private void treeViewElementos_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeViewElementos.SelectedNode = e.Node;
                if (e.Node != null)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }


        /*
        private void buttonAddElementoPrincipal_Click(object sender, EventArgs e)
        {
            if (idElementosAtras.Count > 0)
            {
                int idElementoAnt = Int32.Parse(idElementosAtras.ElementAt(idElementosAtras.Count - 1));
                String nombrecompleto = nombreElementosAtras.ElementAt(nombreElementosAtras.Count - 1);
                String nombre = nombrecompleto.Substring(0, nombrecompleto.IndexOf(":"));
                Tareas.FormInsertarElemento nueva = new Tareas.FormInsertarElemento(this, idElementoAnt, idComunidad, nombre);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
            else
            {
                Tareas.FormInsertarElemento nueva = new Tareas.FormInsertarElemento(this, 0, idComunidad, "Inicio");
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                
                nueva.Show();
            }

        }
        */

        private void añadirElementoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idElementoAnt = Int32.Parse(treeViewElementos.SelectedNode.Tag.ToString());
            String nombrecompleto = treeViewElementos.SelectedNode.Text.ToString();
            String nombre = nombrecompleto.Substring(0, nombrecompleto.IndexOf(":"));
            Tareas.FormInsertarElemento nueva = new Tareas.FormInsertarElemento(this, idElementoAnt, idCategoria, nombre);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void updateRuta()
        {
            String ruta = "Inicio";

            foreach (String nombrecompleto in nombreElementosAtras)
            {
                String nombre = nombrecompleto.Substring(0, nombrecompleto.IndexOf(":"));
                ruta += " > " + nombre;
            }
            if (ruta.Length > 100)
            {
                String ruta2 = ruta;
                ruta = ".../";
                ruta += ruta.Substring(ruta.Length - 90);
            }
            labelRuta.Text = ruta;
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            /*
            TreeNode node = treeViewElementos.SelectedNode;
            if (node != null)
            {
                String nombrecompleto = node.Text.ToString();
                String nombre = nombrecompleto.Substring(0, nombrecompleto.IndexOf(":"));
                if (form_anterior1 != null) form_anterior1.recibirElemento(node.Tag.ToString(),nombre);
                if (form_anterior2 != null) form_anterior2.recibirElemento(node.Tag.ToString(),nombre);
                if (form_anterior3 != null) form_anterior3.recibirElemento(node.Tag.ToString(), nombre);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para poder añadirlo a la tarea");
            }
            */
            
        }
        

        private void treeViewElementos_MouseDown(object sender, MouseEventArgs e)
        {
            if (treeViewElementos.GetNodeAt(e.X, e.Y) == null)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    contextMenuStrip2.Show(Cursor.Position);
                }
            }
            
        }

        private void addElementoPrintoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idElementosAtras.Count > 0)
            {
                int idElementoAnt = Int32.Parse(idElementosAtras.ElementAt(idElementosAtras.Count - 1));
                String nombrecompleto = nombreElementosAtras.ElementAt(nombreElementosAtras.Count - 1);
                String nombre = nombrecompleto.Substring(0, nombrecompleto.IndexOf(":"));
                Tareas.FormInsertarElemento nueva = new Tareas.FormInsertarElemento(this, idElementoAnt, idCategoria, nombre);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
            else
            {
                Tareas.FormInsertarElemento nueva = new Tareas.FormInsertarElemento(this, 0, idCategoria, "Inicio");
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;

                nueva.Show();
            }
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewElementos.SelectedNode;
            if (node != null)
            {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar este Elemento ?", "Borrar Elemento", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    String sqlBorrar = "DELETE FROM exp_detElemento WHERE IdDetElemento = " + node.Tag;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    rellenarTreeViewInicio();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para poder borrarlo");
            }
        }

        private void toolStripMenuItemEditar_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewElementos.SelectedNode;
            int idElementoAnt = Int32.Parse(treeViewElementos.SelectedNode.Tag.ToString());
            if (node != null)
            {
                Tareas.FormInsertarElemento nueva = new Tareas.FormInsertarElemento(this, node.Tag.ToString(),idElementoAnt);
                nueva.Show();
            }      
        }

        private void ToolStripMenuItemBorrar_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewElementos.SelectedNode;
            if (node != null)
            {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar este Elemento ?", "Borrar Elemento", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    String sqlBorrar = "DELETE FROM exp_detElemento WHERE IdDetElemento = " + node.Tag;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    rellenarTreeViewInicio();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para poder borrarlo");
            }
        }
    }
}