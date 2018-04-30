using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Persistencia;

namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    public partial class FormCategoria : Form
    {
        DataTable resultado;
        int id_entidad_cargado;
        VerEntidad form_entidad;

        public FormCategoria(VerEntidad form_entidad,int id_entidad_cargado)
        {
            InitializeComponent();
            this.id_entidad_cargado = id_entidad_cargado;
            this.form_entidad = form_entidad;
        }

        private void textBox_buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) && (textBox_buscar.TextLength < 2))
            {
                resultado = Persistencia.SentenciasSQL.select(SentenciasSQL.SQL[2]);
                listBox_categorias.DisplayMember = "Descripcion";
                listBox_categorias.ValueMember = "IdCategoria";
                listBox_categorias.DataSource = resultado;
            }
            else
            {
                DataTable busqueda = resultado;
                //busqueda.CaseSensitive = false;
                busqueda.DefaultView.RowFilter = "Descripcion like '%" + textBox_buscar.Text + "%'";
                listBox_categorias.DisplayMember = "Descripcion";
                listBox_categorias.ValueMember = "IdCategoria";
                this.listBox_categorias.DataSource = busqueda;
            }
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            resultado = Persistencia.SentenciasSQL.select(SentenciasSQL.SQL[2]);
            listBox_categorias.DataSource = resultado;
            listBox_categorias.DisplayMember = "Descripcion";
            listBox_categorias.ValueMember = "IdCategoria";
        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO ctos_detallecat(IdEntidad, IdCategoria) VALUES (" + id_entidad_cargado + "," + listBox_categorias.SelectedValue+ ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sql);
            //MessageBox.Show("Insertado");
            form_entidad.tableLayoutPanel1.Controls.Clear();
            form_entidad.cargoCategorias();
            this.Close();
        }
        */
    }
}
