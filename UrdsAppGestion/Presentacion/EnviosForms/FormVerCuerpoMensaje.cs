using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.EnviosForms
{
    public partial class FormVerCuerpoMensaje : Form
    {
        String id_lote_cargado;
        public FormVerCuerpoMensaje(String id_lote_cargado)
        {
            InitializeComponent();
            this.id_lote_cargado = id_lote_cargado;
        }

        private void FormVerCuerpoMensaje_Load(object sender, EventArgs e)
        {
            String sqlSelectBody = "SELECT Descripcion FROM com_enviosLote WHERE IdLote = " + id_lote_cargado;
            textBox1.Text = (Persistencia.SentenciasSQL.select(sqlSelectBody)).Rows[0][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
