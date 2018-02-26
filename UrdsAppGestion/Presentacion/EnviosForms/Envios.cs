using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Presentacion;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.EnviosForms
{
    public partial class Envios : Form
    {
        String id_comunidad_cargado = "0";
        DataTable documentos;

        public Envios(String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
        }
        public Envios()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (id_comunidad_cargado != "0")
            {
                ComunidadesForms.EnviosForms.CompletarEnvioForm nueva = new ComunidadesForms.EnviosForms.CompletarEnvioForm(dataGridView_documentos.SelectedCells[0].Value.ToString(),dataGridView_documentos.SelectedCells[6].Value.ToString(),dataGridView_documentos.SelectedCells[5].Value.ToString(), dataGridView_documentos.SelectedCells[4].Value.ToString(), dataGridView_documentos.SelectedCells[3].Value.ToString(),id_comunidad_cargado,"com");
                nueva.Show();
            }else {
                ComunidadesForms.EnviosForms.CompletarEnvioForm nueva = new ComunidadesForms.EnviosForms.CompletarEnvioForm(dataGridView_documentos.SelectedCells[0].Value.ToString(), dataGridView_documentos.SelectedCells[1].Value.ToString(), dataGridView_documentos.SelectedCells[6].Value.ToString(), dataGridView_documentos.SelectedCells[7].Value.ToString(), dataGridView_documentos.SelectedCells[8].Value.ToString(),"panel");
                nueva.Show();
            }
        }

        private void Envios_Load(object sender, EventArgs e)  {
            cargarEnvios();
            comboBox_filtro.SelectedIndex = 0;
            //pintarDatagrig();
        }
        public void cargarEnvios() {
            if (id_comunidad_cargado != "0")  {
                String sql = "SELECT IdDocumento, com_tipoDocumento.Descripcion as TipoDocumento, com_bloques.Descripcion as Bloque, com_Documentos.IdBloque, com_Documentos.Descripcion as Asunto, com_Documentos.Ruta, com_Documentos.IdTipoDocumento FROM (com_Documentos INNER JOIN com_tipoDocumento ON com_Documentos.IdTipoDocumento = com_tipoDocumento.IdTipoDocumento) INNER JOIN com_bloques ON com_Documentos.IdBloque = com_bloques.IdBloque WHERE(((com_Documentos.IdComunidad) = " + id_comunidad_cargado + ")) ORDER BY IdDocumento DESC LIMIT 5; ";

                
                documentos = Persistencia.SentenciasSQL.select(sql);
                dataGridView_documentos.DataSource = documentos;
                AjustarDatagrid();

            }
            else {
                  String sql2 = "SELECT IdDocumento, IdTipoDocumento, FechaCreacion, IdComunidad, IdBloque, IdEntidad, GeneralComunidades, Descripcion, Ruta FROM com_Documentos WHERE GeneralComunidades <> ''";
                dataGridView_documentos.DataSource = Persistencia.SentenciasSQL.select(sql2);
                dataGridView_documentos.Columns["IdComunidad"].Visible = false;
                dataGridView_documentos.Columns["IdBloque"].Visible = false;
                dataGridView_documentos.Columns["IdEntidad"].Visible = false;
            }
        }
        private void AjustarDatagrid() {
            dataGridView_documentos.Columns["IdTipoDocumento"].Visible = false;
            dataGridView_documentos.Columns["IdBloque"].Visible = false;
            dataGridView_documentos.Columns["Ruta"].Width = 300;
            dataGridView_documentos.Columns["Asunto"].Width = 250;
            dataGridView_documentos.Columns["Bloque"].Width = 200;
        }

        private void pintarDatagrig() {
            for (int a = 0; a < dataGridView_documentos.Rows.Count; a++)
            {
                String sqlSelectLote = "SELECT com_enviosLote.Completo FROM com_enviosLote INNER JOIN com_EnvSe ON com_enviosLote.IdLote = com_EnvSe.IdLote WHERE(((com_EnvSe.IdDocumento) = " + dataGridView_documentos.Rows[a].Cells[0].Value.ToString() + "));";

                DataTable filasPintadas = Persistencia.SentenciasSQL.select(sqlSelectLote);

                if (filasPintadas.Rows.Count > 0 && filasPintadas.Rows[0][0].ToString() == "No")
                {
                    dataGridView_documentos.Rows[a].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView_documentos.Rows[a].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (id_comunidad_cargado != "0") {
                Presentacion.EnviosForms.Documentos nueva = new Presentacion.EnviosForms.Documentos(this,id_comunidad_cargado);
                nueva.Show();
            }
            else {
                Presentacion.EnviosForms.Documentos nueva = new Presentacion.EnviosForms.Documentos(this);
                nueva.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este Registro de Documento ?", "Borrar Registro", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_Documentos WHERE IdDocumento = " + dataGridView_documentos.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarEnvios();
            }
        }

        private void verRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presentacion.EnviosForms.RegistroEnvios nueva = new Presentacion.EnviosForms.RegistroEnvios(dataGridView_documentos.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void dataGridView_documentos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_documentos.HitTest(e.X, e.Y);
                dataGridView_documentos.ClearSelection();
                dataGridView_documentos.Rows[hti.RowIndex].Selected = true;
                //comprueboReenvio();
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        //private void comprueboReenvio() {
        //    String sqlSelectLote = "SELECT com_enviosLote.Completo FROM com_enviosLote INNER JOIN com_EnvSe ON com_enviosLote.IdLote = com_EnvSe.IdLote WHERE(((com_EnvSe.IdDocumento) = " + dataGridView_documentos.SelectedCells[0].Value.ToString() + "));";
        //    DataTable loteCompleto = Persistencia.SentenciasSQL.select(sqlSelectLote);
        //    if (loteCompleto.Rows.Count > 0)
        //    {
        //        String cond = (Persistencia.SentenciasSQL.select(sqlSelectLote)).Rows[0][0].ToString();
        //        if (cond != "No")
        //            rToolStripMenuItem.Enabled = false;
        //        else
        //            rToolStripMenuItem.Enabled = true;
        //    }else {
        //        rToolStripMenuItem.Enabled = false;
        //    }

        //}
        private void verCuerpoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sql = "SELECT com_EnvSe.IdLote FROM com_EnvSe GROUP BY com_EnvSe.IdDocumento, com_EnvSe.IdLote HAVING(((com_EnvSe.IdDocumento) = " + dataGridView_documentos.SelectedCells[0].Value.ToString() + "));";
            if (Persistencia.SentenciasSQL.select(sql).Rows.Count > 0) {
                String id_lote = (Persistencia.SentenciasSQL.select(sql)).Rows[0][0].ToString();

                Presentacion.EnviosForms.FormVerCuerpoMensaje nuevo = new Presentacion.EnviosForms.FormVerCuerpoMensaje(id_lote);
                nuevo.Show();
            }else {
                MessageBox.Show("No existe el Cuerpo");
            }
        }

        private void dataGridView_documentos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //pintarDatagrig();
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompletarEnvioForm nueva = new CompletarEnvioForm(dataGridView_documentos.SelectedCells[0].Value.ToString(), dataGridView_documentos.SelectedCells[6].Value.ToString(), dataGridView_documentos.SelectedCells[5].Value.ToString(), dataGridView_documentos.SelectedCells[4].Value.ToString(), dataGridView_documentos.SelectedCells[3].Value.ToString(), id_comunidad_cargado, "fallo");
            nueva.Show();
        }

        private void abrirDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@dataGridView_documentos.SelectedCells[5].Value.ToString());
        }

        private void comboBox_filtro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String sql = "";

            if (comboBox_filtro.SelectedIndex == 0) {
                sql = "SELECT IdDocumento, com_tipoDocumento.Descripcion as TipoDocumento, com_bloques.Descripcion as Bloque, com_Documentos.IdBloque, com_Documentos.Descripcion as Asunto, com_Documentos.Ruta, com_Documentos.IdTipoDocumento FROM (com_Documentos INNER JOIN com_tipoDocumento ON com_Documentos.IdTipoDocumento = com_tipoDocumento.IdTipoDocumento) INNER JOIN com_bloques ON com_Documentos.IdBloque = com_bloques.IdBloque WHERE(((com_Documentos.IdComunidad) = " + id_comunidad_cargado + ")) LIMIT 5; ";
            }
            else if (comboBox_filtro.SelectedIndex == 1) {
                sql = "SELECT IdDocumento, com_tipoDocumento.Descripcion as TipoDocumento, com_bloques.Descripcion as Bloque, com_Documentos.IdBloque, com_Documentos.Descripcion as Asunto, com_Documentos.Ruta, com_Documentos.IdTipoDocumento FROM (com_Documentos INNER JOIN com_tipoDocumento ON com_Documentos.IdTipoDocumento = com_tipoDocumento.IdTipoDocumento) INNER JOIN com_bloques ON com_Documentos.IdBloque = com_bloques.IdBloque WHERE(((com_Documentos.IdComunidad) = " + id_comunidad_cargado + ")) LIMIT 10; ";

            }
            else if (comboBox_filtro.SelectedIndex == 2) {
                sql = "SELECT IdDocumento, com_tipoDocumento.Descripcion as TipoDocumento, com_bloques.Descripcion as Bloque, com_Documentos.IdBloque, com_Documentos.Descripcion as Asunto, com_Documentos.Ruta, com_Documentos.IdTipoDocumento FROM (com_Documentos INNER JOIN com_tipoDocumento ON com_Documentos.IdTipoDocumento = com_tipoDocumento.IdTipoDocumento) INNER JOIN com_bloques ON com_Documentos.IdBloque = com_bloques.IdBloque WHERE(((com_Documentos.IdComunidad) = " + id_comunidad_cargado + ")) LIMIT 20; ";

            }
            else if (comboBox_filtro.SelectedIndex == 3) {
                sql = "SELECT IdDocumento, com_tipoDocumento.Descripcion as TipoDocumento, com_bloques.Descripcion as Bloque, com_Documentos.IdBloque, com_Documentos.Descripcion as Asunto, com_Documentos.Ruta, com_Documentos.IdTipoDocumento FROM (com_Documentos INNER JOIN com_tipoDocumento ON com_Documentos.IdTipoDocumento = com_tipoDocumento.IdTipoDocumento) INNER JOIN com_bloques ON com_Documentos.IdBloque = com_bloques.IdBloque WHERE(((com_Documentos.IdComunidad) = " + id_comunidad_cargado + ")); ";

            }

            documentos = Persistencia.SentenciasSQL.select(sql);
            dataGridView_documentos.DataSource = documentos;
            AjustarDatagrid();

        }
    }
}
