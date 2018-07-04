using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms.Informes
{
    public partial class FormDivisionesAsociaciones : Form
    {
        String idComunidad;
        DataTable comuneros;
        public FormDivisionesAsociaciones(String idComunidad)
        {
            InitializeComponent();
            this.idComunidad = idComunidad;
        }

        private void FormDivisionesAsociaciones_Load(object sender, EventArgs e)
        {
            //String sqlSelect = "SELECT com_divisiones.Division, com_tipoasociacion.TipoAsociación AS Asociacion, ctos_entidades.Entidad, ctos_detemail.Email, ctos_dettelf.Telefono AS Telefono1 FROM(((((com_asociacion RIGHT JOIN com_divisiones ON com_asociacion.IdDivision = com_divisiones.IdDivision) LEFT JOIN com_tipoasociacion ON com_asociacion.IdTipoAsoc = com_tipoasociacion.IdTipoAsoc) LEFT JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) LEFT JOIN ctos_detemail ON com_comuneros.IdEmail = ctos_detemail.IdEmail) LEFT JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN ctos_dettelf ON ctos_entidades.IDEntidad = ctos_dettelf.IdEntidad WHERE(((com_divisiones.IdComunidad) = '" + idComunidad + "') AND((com_asociacion.FechaBaja)Is Null) AND((ctos_dettelf.Orden) = 1)) ORDER BY com_divisiones.Division, com_tipoasociacion.TipoAsociación DESC";
            String sqlSelect = "SELECT com_divisiones.Division, com_tipoasociacion.TipoAsociación AS Asociacion, ctos_entidades.Entidad, ctos_dettelf.Telefono AS Telefono1 FROM((((com_asociacion RIGHT JOIN com_divisiones ON com_asociacion.IdDivision = com_divisiones.IdDivision) LEFT JOIN com_tipoasociacion ON com_asociacion.IdTipoAsoc = com_tipoasociacion.IdTipoAsoc) LEFT JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) LEFT JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN ctos_dettelf ON ctos_entidades.IDEntidad = ctos_dettelf.IdEntidad WHERE(((com_divisiones.IdComunidad) = '" + idComunidad + "') AND((com_asociacion.FechaBaja)Is Null)) AND (((ctos_dettelf.Orden) = 1) OR((ctos_dettelf.Orden)Is Null)) ORDER BY com_divisiones.Division, com_tipoasociacion.TipoAsociación DESC";
            comuneros = Persistencia.SentenciasSQL.select(sqlSelect);

            comuneros.Columns.Add("Telefono2", typeof(String));

            String sqlSelect2tlf = "SELECT ctos_entidades.Entidad,ctos_dettelf.Telefono FROM(((((com_asociacion RIGHT JOIN com_divisiones ON com_asociacion.IdDivision = com_divisiones.IdDivision) LEFT JOIN com_tipoasociacion ON com_asociacion.IdTipoAsoc = com_tipoasociacion.IdTipoAsoc) LEFT JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) LEFT JOIN ctos_detemail ON com_comuneros.IdEmail = ctos_detemail.IdEmail) LEFT JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) LEFT JOIN ctos_dettelf ON ctos_entidades.IDEntidad = ctos_dettelf.IdEntidad WHERE(((com_divisiones.IdComunidad) = '" + idComunidad + "') AND((com_asociacion.FechaBaja)Is Null) AND((ctos_dettelf.Orden) = 2))";
            DataTable segTlf = Persistencia.SentenciasSQL.select(sqlSelect2tlf);

            foreach (DataRow row in segTlf.Rows)
            {
                String entidad = row["Entidad"].ToString();
                foreach ( DataRow rowcom in comuneros.Rows)
                {
                    if (row["Entidad"].ToString() == rowcom["Entidad"].ToString())
                    {
                        rowcom["Telefono2"] = row["Telefono"].ToString();
                    }
                }
            }

            dataSetDivisionesAsociacionesBindingSource.DataSource = comuneros;

            String sqlSelectCom = "SELECT ctos_entidades.NombreCorto, com_comunidades.Referencia FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = '" + idComunidad + "'))";
            DataTable comun = Persistencia.SentenciasSQL.select(sqlSelectCom);


            ReportParameter parametro = new ReportParameter("nombrecomunidad", "Comunidad : " + comun.Rows[0][1].ToString() + " - " + comun.Rows[0][0].ToString());
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parametro });

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
