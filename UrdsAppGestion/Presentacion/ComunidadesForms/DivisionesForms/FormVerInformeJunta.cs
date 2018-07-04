using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms
{
    public partial class FormVerInformeJunta : Form
    {
        String idComunidad;
        String idBloque;
        String bloque;
        DataTable comuneros;
        DataTable divisiones;

        public FormVerInformeJunta(String idBloque, String idComunidad,String bloque)
        {
            InitializeComponent();
            this.idBloque = idBloque;
            this.idComunidad = idComunidad;
            this.bloque = bloque;
        }

        private void FormVerInformeJunta_Load(object sender, EventArgs e)
        {
            labelBloque.Text = bloque;
            cargarPropietarios();
        }

        private void buttonImprimirInforme_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT ctos_entidades.NombreCorto FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.IdComunidad) = " + idComunidad + "))";
            String comunidad = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            Informes.FormListadoJuntasBloque nueva = new Informes.FormListadoJuntasBloque(comunidad, bloque, comuneros, labelElementos.Text.ToString(), labelCuotaTotal.Text.ToString());
            nueva.Show();
        }
        
        private void cargarPropietarios()
        {
            String sqlSelect = "SELECT com_divisiones.Division AS División, ctos_entidades.Entidad,ctos_entidades.IDEntidad FROM com_bloques INNER JOIN ((((com_divisiones INNER JOIN com_asociacion ON com_divisiones.IdDivision = com_asociacion.IdDivision) INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision) ON com_bloques.IdBloque = com_subcuotas.IdBloque WHERE (((com_divisiones.IdComunidad) = '" + idComunidad + "') AND((com_bloques.IdBloque) = '" + idBloque + "') AND ((com_asociacion.FechaBaja) Is Null) AND ((com_asociacion.Ppal)=-1)) GROUP BY ctos_entidades.Entidad ORDER BY com_divisiones.Division";
            comuneros = Persistencia.SentenciasSQL.select(sqlSelect);
            
            String sqlSelectDiv = "SELECT ctos_entidades.IDEntidad, com_divisiones.Division, com_subcuotas.Subcuota, com_subcuotas.IdBloque, com_asociacion.IdTipoAsoc FROM(((com_comuneros INNER JOIN com_asociacion ON com_comuneros.IdComunero = com_asociacion.IdComunero) INNER JOIN com_divisiones ON com_asociacion.IdDivision = com_divisiones.IdDivision) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_subcuotas ON com_divisiones.IdDivision = com_subcuotas.IdDivision WHERE(((com_comuneros.IdComunidad) = '" + idComunidad + "') AND((com_asociacion.IdTipoAsoc) <= 2) AND((com_asociacion.FechaBaja)Is Null)) ORDER BY ctos_entidades.IDEntidad, com_divisiones.IdTipoDiv, com_divisiones.Division";
            divisiones = Persistencia.SentenciasSQL.select(sqlSelectDiv);

            comuneros.Columns.Add("Asociaciones", typeof(String));
            comuneros.Columns.Add("Cuotas", typeof(Double));

            Double totalCuota = 0.0;

            foreach (DataRow row in comuneros.Rows)
            {
                String divs = "";
                Double cuotas = 0.0;
                foreach (DataRow rowDiv in divisiones.Rows)
                {
                    if (rowDiv["IDEntidad"].ToString() == row["IDEntidad"].ToString())
                    {
                        if (divs.Length > 0)
                        {
                            if (!divs.Contains(rowDiv["Division"].ToString()))
                            {
                                divs += ", " + rowDiv["Division"];
                                if (rowDiv["IdTipoAsoc"].ToString() == "1") divs += "(p)";
                                else if (rowDiv["IdTipoAsoc"].ToString() == "2") divs += "(i)";
                                else if (rowDiv["IdTipoAsoc"].ToString() == "3") divs += "(o)";
                            }
                        }
                        else
                        {
                            divs = rowDiv["Division"].ToString();
                            if (rowDiv["IdTipoAsoc"].ToString() == "1") divs += "(p)";
                            else if (rowDiv["IdTipoAsoc"].ToString() == "2") divs += "(i)";
                            else if (rowDiv["IdTipoAsoc"].ToString() == "3") divs += "(o)";
                        }
                        if (rowDiv["IdBloque"].ToString() == idBloque) cuotas += Double.Parse(rowDiv["Subcuota"].ToString());
                    }
                }
                row["Asociaciones"] = divs;
                row["Cuotas"] = cuotas;
                totalCuota += cuotas;
            }

            dataGridViewInforme.DataSource = comuneros;

            if (dataGridViewInforme.Rows.Count > 0 )
            {
                dataGridViewInforme.Columns["División"].Width = 60;
                dataGridViewInforme.Columns["Entidad"].Width = 350;
                dataGridViewInforme.Columns["Asociaciones"].Width = 350;
                dataGridViewInforme.Columns["Cuotas"].Width = 100;
                dataGridViewInforme.Columns["Cuotas"].DefaultCellStyle.Format = "P";
                dataGridViewInforme.Columns["IdEntidad"].Visible = false;

            }
            totalCuota = totalCuota * 100;
            totalCuota = Math.Truncate(100 * totalCuota) / 100;

            labelCuotaTotal.Text = "Cuota: " + totalCuota + " %";
            labelElementos.Text = "Comuneros : " + dataGridViewInforme.Rows.Count;
        }

        private void buttonCopiarPortapapeles_Click(object sender, EventArgs e)
        {
            dataGridViewInforme.SelectAll();
            CopyToClipboardWithHeaders(dataGridViewInforme);
        }
        public void CopyToClipboardWithHeaders(DataGridView _dgv)
        {
            _dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DataObject dataObj = _dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
    
    }
}
