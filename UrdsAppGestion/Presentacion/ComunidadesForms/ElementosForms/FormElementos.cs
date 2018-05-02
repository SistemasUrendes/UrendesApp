using System;
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
        private int idComunidad;
        List<String> idElementosAtras;
        List<String> nombreElementosAtras;
        Tareas.FormVerTarea form_anterior;

        public FormElementos(int idComunidad)
        {
            InitializeComponent();
            idElementosAtras = new List<String>();
            nombreElementosAtras = new List<String>();
            this.idComunidad = idComunidad;
        }

        public FormElementos(Tareas.FormVerTarea form_anterior, int idComunidad)
        {
            InitializeComponent();
            idElementosAtras = new List<String>();
            nombreElementosAtras = new List<String>();
            this.idComunidad = idComunidad;
            this.form_anterior = form_anterior;
        }

        private void FormElementos_Load(object sender, EventArgs e)
        {
            rellenarTreeViewInicio();
            if (form_anterior != null) buttonEnviar.Visible = true;
        }


        public void rellenarTreeViewInicio()
        {
            updateRuta();
            treeViewElementos.Nodes.Clear();
            DataTable elementos;
            String sqlSelect = "SELECT exp_elementos.IdElemento, exp_elementos.IdElementoAnt, exp_elementos.Nombre, exp_elementos.Descripcion FROM exp_elementos WHERE(((exp_elementos.IdElementoAnt) = 0) AND((exp_elementos.IdComunidad) = " + idComunidad + "))";
            elementos = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach (DataRow row in elementos.Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["Nombre"].ToString() + " : " + row["Descripcion"].ToString();
                node.Tag = row["IdElemento"].ToString();
                treeViewElementos.Nodes.Add(node);
                rellenarSubElementos((int)row["IdElemento"], node);
            }
        }

        public void rellenarTreeView(String IdElemento)
        {
            treeViewElementos.Nodes.Clear();
            DataTable elementos;
            String sqlSelect = "SELECT exp_elementos.IdElemento, exp_elementos.IdElementoAnt, exp_elementos.Nombre, exp_elementos.Descripcion FROM exp_elementos WHERE(((exp_elementos.IdElementoAnt) = " + IdElemento + ") AND((exp_elementos.IdComunidad) = " + idComunidad + "))";
            elementos = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach (DataRow row in elementos.Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["Nombre"].ToString() + " : " + row["Descripcion"].ToString();
                node.Tag = row["IdElemento"];
                treeViewElementos.Nodes.Add(node);
                rellenarSubElementos((int)row["IdElemento"], node);
            }
        }

        private void rellenarSubElementos(int idElemento, TreeNode node)
        {
            DataTable subElementos;
            String sqlSelect = "SELECT exp_elementos.IdElemento, exp_elementos.IdElementoAnt, exp_elementos.Nombre, exp_elementos.Descripcion FROM exp_elementos WHERE(((exp_elementos.IdElementoAnt) = " + idElemento + ") AND((exp_elementos.IdComunidad) = " + idComunidad + "))";
            subElementos = Persistencia.SentenciasSQL.select(sqlSelect);

            if (subElementos.Rows.Count == 0) { return; }

            foreach (DataRow row in subElementos.Rows)
            {
                TreeNode subNode = new TreeNode();
                subNode.Text = row["Nombre"].ToString() + " : " + row["Descripcion"].ToString();
                subNode.Tag = row["IdElemento"].ToString();
                node.Nodes.Add(subNode);
            }
        }

        private void treeViewElementos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String sqlSelect = "SELECT exp_elementos.IdElemento, exp_elementos.IdElementoAnt, exp_elementos.Nombre, exp_elementos.Descripcion FROM exp_elementos WHERE(((exp_elementos.IdElementoAnt) = " + e.Node.Tag.ToString() + ") AND((exp_elementos.IdComunidad) = " + idComunidad + "))";
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

        private void añadirElementoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idElementoAnt = Int32.Parse(treeViewElementos.SelectedNode.Tag.ToString());
            String nombrecompleto = treeViewElementos.SelectedNode.Text.ToString();
            String nombre = nombrecompleto.Substring(0, nombrecompleto.IndexOf(":"));
            Tareas.FormInsertarElemento nueva = new Tareas.FormInsertarElemento(this, idElementoAnt, idComunidad, nombre);
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
            TreeNode node = treeViewElementos.SelectedNode;
            if (node != null)
            {
                String nombrecompleto = node.Text.ToString();
                String nombre = nombrecompleto.Substring(0, nombrecompleto.IndexOf(":"));
                form_anterior.recibirElemento(node.Tag.ToString(),nombre);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para poder añadirlo a la tarea");
            }
            
        }
    }
}
