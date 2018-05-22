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
    public partial class FormArbolAreasBloque : Form
    {
        FormServiciosConfiguracion formAnt;
        String idBloque;
        String nombreBloque;
        String nombreComunidad;
        DataTable areasTabla;
        List<String> idElementosAtras;
        List<String> nombreElementosAtras;

        public FormArbolAreasBloque(FormServiciosConfiguracion formAnt, String idBloque,String nombreBloque, String nombreComunidad)
        {
            InitializeComponent();
            this.formAnt = formAnt;
            this.idBloque = idBloque;
            this.nombreBloque = nombreBloque;
            this.nombreComunidad = nombreComunidad;
            idElementosAtras = new List<String>();
            nombreElementosAtras = new List<String>();
        }

        public FormArbolAreasBloque(String idBloque, String nombreBloque, String nombreComunidad)
        {
            InitializeComponent();
            this.idBloque = idBloque;
            this.nombreBloque = nombreBloque;
            this.nombreComunidad = nombreComunidad;
            idElementosAtras = new List<String>();
            nombreElementosAtras = new List<String>();
        }

        private void FormArbolAreasBloque_Load(object sender, EventArgs e)
        {
            labelNombre.Text = nombreComunidad + ": " + nombreBloque;
            cargarAreas();
            rellenarTreeViewInicio();
        }

        private void cargarAreas()
        {
            String sqlSelect = "SELECT IdCatElemento,Nombre, Descripcion FROM exp_catElemento";
            areasTabla = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewAllAreas.DataSource = areasTabla;
            if (dataGridViewAllAreas.Rows.Count > 0)
            {
                dataGridViewAllAreas.Columns["IdCatElemento"].Visible = false;
                dataGridViewAllAreas.Columns["Nombre"].Width = 100;
                dataGridViewAllAreas.Columns["Descripcion"].Width = 190;
            }
        }

        private void textBoxFiltroAreas_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = areasTabla;
            busqueda.DefaultView.RowFilter = string.Empty;

            String filtro = "Descripcion like '%" + textBoxFiltroAreas.Text.ToString() + "%' OR Nombre like '%" + textBoxFiltroAreas.Text.ToString() + "%'";
            busqueda.DefaultView.RowFilter = filtro;
            dataGridViewAllAreas.DataSource = busqueda;
        }

        private void dataGridViewAllAreas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            copiarServicioABloque();
        }

        private void copiarServicioABloque()
        {

            String sqlSelectBloque = "SELECT exp_area.IdArea, exp_area.IdBloque, exp_area.IdAreaPrevio FROM exp_area WHERE(((exp_area.IdBloque) = " + idBloque + ") AND((exp_area.IdAreaPrevio) = 0))";
            DataTable bloque = Persistencia.SentenciasSQL.select(sqlSelectBloque);
            int areaBloque;
            if (bloque.Rows.Count > 0) areaBloque = Int32.Parse(bloque.Rows[0][0].ToString());
            else
            {
                String insertBloque = "INSERT INTO exp_area (IdAreaPrevio,IdBloque,Nombre,Descripcion) VALUE (0,'" + idBloque + "','" + nombreBloque + "','Bloque físico')";
                areaBloque = Persistencia.SentenciasSQL.InsertarGenericoID(insertBloque);
            }
           
             
            String sqlInsertPrincipal = "INSERT INTO exp_area (IdAreaPrevio,IdBloque,Nombre,Descripcion) VALUES ('" + areaBloque + "','" + idBloque + "','" + dataGridViewAllAreas.SelectedRows[0].Cells[1].Value.ToString() + "','" + dataGridViewAllAreas.SelectedRows[0].Cells[2].Value.ToString() + "')";
            int idAreaPrincipal = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertPrincipal);
            
            String sqlSelect = "SELECT exp_detElemento.Nombre, exp_detElemento.Descripcion, exp_detElemento.IdDetElemento FROM exp_detElemento WHERE(((exp_detElemento.IdDetElementoPrev) = 0) AND((exp_detElemento.IdCatElemento) = " + dataGridViewAllAreas.SelectedRows[0].Cells[0].Value.ToString() + "))";
            DataTable servicio = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach (DataRow row in servicio.Rows)
            {
                String nombre = row[0].ToString();
                String descripcion = row[1].ToString();
                String idElementoPrev = row[2].ToString();
                String sqlInsert = "INSERT INTO exp_area (IdAreaPrevio,IdBloque,Nombre,Descripcion) VALUES ('" + idAreaPrincipal + "','" + idBloque + "','" + nombre + "','" + descripcion + "')";
                int idAreaPrev = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert);

                String sqlSelectsub = "SELECT exp_detElemento.Nombre, exp_detElemento.Descripcion FROM exp_detElemento WHERE exp_detElemento.IdDetElementoPrev = " + idElementoPrev;
                DataTable subServicio = Persistencia.SentenciasSQL.select(sqlSelectsub);

                foreach ( DataRow rowSub in subServicio.Rows)
                {
                    String nombreSub = rowSub[0].ToString();
                    String descripcionSub = rowSub[1].ToString();
                    String sqlInsertSub = "INSERT INTO exp_area (IdAreaPrevio,IdBloque,Nombre,Descripcion) VALUES ('" + idAreaPrev + "','" + idBloque + "','" + nombreSub + "','" + descripcionSub + "')";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertSub);
                }
            }
            rellenarTreeViewInicio();
        }

        public void rellenarTreeViewInicio()
        {
            updateRuta();
            treeViewElementos.Nodes.Clear();
            DataTable elementos;

            String sqlSelectPrincipal = "SELECT exp_area.IdArea, exp_area.IdAreaPrevio, exp_area.Nombre, exp_area.Descripcion FROM exp_area WHERE(((exp_area.IdBloque) = " + idBloque + ") AND((exp_area.IdAreaPrevio) = 0))";
            String areaPrincipal = Persistencia.SentenciasSQL.select(sqlSelectPrincipal).Rows[0][0].ToString();

            String sqlSelect = "SELECT exp_area.IdArea, exp_area.IdAreaPrevio, exp_area.Nombre, exp_area.Descripcion FROM exp_area WHERE(((exp_area.IdBloque) = " + idBloque + ") AND((exp_area.IdAreaPrevio) = " + areaPrincipal + "))";

            elementos = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach (DataRow row in elementos.Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["Nombre"].ToString() + " : " + row["Descripcion"].ToString();
                node.Tag = row["IdArea"].ToString();
                treeViewElementos.Nodes.Add(node);
                rellenarSubElementos((int)row["IdArea"], node);
            }
        }

        public void rellenarTreeView(String idElemento)
        {
            treeViewElementos.Nodes.Clear();
            DataTable elementos;
            String sqlSelect = "SELECT exp_area.IdArea, exp_area.IdAreaPrevio, exp_area.Nombre, exp_area.Descripcion FROM exp_area WHERE(((exp_area.IdBloque) = " + idBloque + ") AND((exp_area.IdAreaPrevio) = " + idElemento + "))";
            elementos = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach (DataRow row in elementos.Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["Nombre"].ToString() + " : " + row["Descripcion"].ToString();
                node.Tag = row["IdArea"];
                treeViewElementos.Nodes.Add(node);
                rellenarSubElementos((int)row["IdArea"], node);
            }
        }

        private void rellenarSubElementos(int idElemento, TreeNode node)
        {
            DataTable subElementos;
            String sqlSelect = "SELECT exp_area.IdArea, exp_area.IdAreaPrevio, exp_area.Nombre, exp_area.Descripcion FROM exp_area WHERE(((exp_area.IdBloque) = " + idBloque + ") AND((exp_area.IdAreaPrevio) = " + idElemento + "))";
            subElementos = Persistencia.SentenciasSQL.select(sqlSelect);

            if (subElementos.Rows.Count == 0) { return; }

            foreach (DataRow row in subElementos.Rows)
            {
                TreeNode subNode = new TreeNode();
                subNode.Text = row["Nombre"].ToString() + " : " + row["Descripcion"].ToString();
                subNode.Tag = row["IdArea"].ToString();
                node.Nodes.Add(subNode);
            }
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

        private void treeViewElementos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String sqlSelect = "SELECT exp_area.IdArea, exp_area.IdAreaPrevio, exp_area.Nombre, exp_area.Descripcion FROM exp_area WHERE(((exp_area.IdBloque) = " + idBloque + ") AND((exp_area.IdAreaPrevio) = " + e.Node.Tag.ToString() + "))";

            DataTable subElementos = Persistencia.SentenciasSQL.select(sqlSelect);
            if (subElementos.Rows.Count > 0)
            {
                idElementosAtras.Add(e.Node.Tag.ToString());
                nombreElementosAtras.Add(e.Node.Text.ToString());
                rellenarTreeView(e.Node.Tag.ToString());
                updateRuta();
            }
        }

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            idElementosAtras.Clear();
            nombreElementosAtras.Clear();
            rellenarTreeViewInicio();
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

        private void toolStripMenuItemEditar_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewElementos.SelectedNode;
            if (node != null)
            {
                Tareas.FormInsertarServicioBloque nueva = new Tareas.FormInsertarServicioBloque(this, node.Tag.ToString());
                nueva.Show();
            }
        }

        private void añadirElementoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String idElementoAnt = treeViewElementos.SelectedNode.Tag.ToString();
            String nombrecompleto = treeViewElementos.SelectedNode.Text.ToString();
            String nombre = nombrecompleto.Substring(0, nombrecompleto.IndexOf(":"));
            Tareas.FormInsertarServicioBloque nueva = new Tareas.FormInsertarServicioBloque(this, idElementoAnt, idBloque, nombre);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }

        private void ToolStripMenuItemBorrar_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewElementos.SelectedNode;
            if (node != null)
            {
                DialogResult resultado_message;
                resultado_message = MessageBox.Show("¿Desea borrar este Servicio?", "Borrar Servicio", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    String sqlBorrar = "DELETE FROM exp_area WHERE IdArea = " + node.Tag;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    rellenarTreeViewInicio();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento para poder borrarlo");
            }
        }

        private void addElementoPrintoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (idElementosAtras.Count > 0)
            {
                String idElementoAnt = idElementosAtras.ElementAt(idElementosAtras.Count - 1);
                String nombrecompleto = nombreElementosAtras.ElementAt(nombreElementosAtras.Count - 1);
                String nombre = nombrecompleto.Substring(0, nombrecompleto.IndexOf(":"));
                Tareas.FormInsertarServicioBloque nueva = new Tareas.FormInsertarServicioBloque(this, idElementoAnt, idBloque, nombre);
                nueva.ControlBox = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
            else
            {
                Tareas.FormInsertarServicioBloque nueva = new Tareas.FormInsertarServicioBloque(this, "0", idBloque, nombreBloque );
                nueva.ControlBox = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;

                nueva.Show();
            }
        }
    }
}
