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
    public partial class SeleccionAdjuntos : Form
    {
        String idComunidad = "0";
        String quien;
        Presentacion.ComunidadesForms.EnviosForms.CompletarEnvioForm form_anterior;

        public SeleccionAdjuntos(Presentacion.ComunidadesForms.EnviosForms.CompletarEnvioForm form_anterior, String idComunidad, String quien)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
            this.quien = quien;
            this.form_anterior = form_anterior;

        }
        private void cargarDatagrid() {
            String sql = "SELECT com_Documentos.IdDocumento, com_tipoDocumento.Descripcion, com_Documentos.Ruta FROM com_Documentos INNER JOIN com_tipoDocumento ON com_Documentos.IdTipoDocumento = com_tipoDocumento.IdTipoDocumento WHERE(((com_Documentos.IdComunidad) = " + idComunidad + ")) ORDER BY  com_Documentos.IdDocumento DESC ;";

            DataTable documentos = Persistencia.SentenciasSQL.select(sql);
            dataGridView1.DataSource = documentos;
        }

        private void SeleccionAdjuntos_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            form_anterior.insertarDoc(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), quien);
            this.Close();
        }
    }
}
