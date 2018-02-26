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
    public partial class RegistroEnvios : Form
    {
        String id_documento_cargado = "0";
        public RegistroEnvios(String id_documento_cargado)
        {
            InitializeComponent();
            this.id_documento_cargado = id_documento_cargado;
        }

        private void RegistroEnvios_Load(object sender, EventArgs e)
        {
            if (id_documento_cargado != "0") {
                String sqlSelect = "SELECT com_EnvSe.IdEnvSeg, com_EnvSe.IdLote, com_tipoDocumento.Descripcion, com_EnvSe.Medio, ctos_entidades.Entidad, ctos_detemail.Email, com_EnvSe.FechaEnvio, com_EnvSe.Descripcion FROM((com_tipoDocumento INNER JOIN com_EnvSe ON com_tipoDocumento.IdTipoDocumento = com_EnvSe.TipoDocumento) INNER JOIN ctos_entidades ON com_EnvSe.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_detemail ON (ctos_detemail.IdEmail = com_EnvSe.IdDireccion) AND(ctos_entidades.IDEntidad = ctos_detemail.IdEntidad) WHERE(((com_EnvSe.IdDocumento) = " + id_documento_cargado + "));";

                dataGridView_registro.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            }
        }
        public void cargardatagrid() {
            if (id_documento_cargado != "0") {
                String sqlSelect = "SELECT com_EnvSe.IdEnvSeg, com_EnvSe.IdLote, com_tipoDocumento.Descripcion, com_EnvSe.Medio, ctos_entidades.Entidad, ctos_detemail.Email, com_EnvSe.FechaEnvio, com_EnvSe.Descripcion FROM((com_tipoDocumento INNER JOIN com_EnvSe ON com_tipoDocumento.IdTipoDocumento = com_EnvSe.TipoDocumento) INNER JOIN ctos_entidades ON com_EnvSe.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_detemail ON (ctos_detemail.IdEmail = com_EnvSe.IdDireccion) AND(ctos_entidades.IDEntidad = ctos_detemail.IdEntidad) WHERE(((com_EnvSe.IdDocumento) = " + id_documento_cargado + "));";

                dataGridView_registro.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
            }
        }
    }
}
