using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.MantenimientoForms
{
    public partial class FormInsertarCategoria : Form
    {
        String idCategoria;
        String nombreBase;
        FormActualizarCatProveedores formAnt;
        public FormInsertarCategoria(FormActualizarCatProveedores formAnt)
        {
            InitializeComponent();
            this.formAnt = formAnt;
        }

        public FormInsertarCategoria(FormActualizarCatProveedores formAnt,String idCategoria)
        {
            InitializeComponent();
            this.idCategoria = idCategoria;
            this.formAnt = formAnt;
        }

        private void FormInsertarCategoria_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
            if (idCategoria != null)
            {
                String sqlSelect = "SELECT ctos_catentidades.Descripcion,ctos_catentidades.IdGrupoCat FROM ctos_catentidades WHERE(((ctos_catentidades.IdCategoria) = " + idCategoria + "))";
                DataTable cat = Persistencia.SentenciasSQL.select(sqlSelect);
                textBoxNombre.Text = cat.Rows[0][0].ToString();
                nombreBase = cat.Rows[0][0].ToString();
                comboBox1.SelectedValue = cat.Rows[0][1];
            }
        }

        private void rellenarComboBox()
        {
            String sqlSelect = "SELECT ctos_gruposcat.IDGrupoCat, ctos_gruposcat.GrupoCategoria FROM ctos_gruposcat WHERE(((ctos_gruposcat.Activado) = 0))";
            DataTable grupos = Persistencia.SentenciasSQL.select(sqlSelect);

            comboBox1.DataSource = grupos;
            comboBox1.DisplayMember = "GrupoCategoria";
            comboBox1.ValueMember = "IDGrupoCat";
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String nombreNuevo = textBoxNombre.Text;
            String grupo = comboBox1.SelectedValue.ToString();
            if (idCategoria != null)
            {
                String sqlUpdate = "UPDATE ctos_catentidades SET IdGrupoCat = '" + grupo + "', Descripcion = '" + nombreNuevo + "' WHERE IdCategoria = '" + idCategoria + "'";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                actualizarPalabrasClave(nombreNuevo);
            }
            else
            {
                String SqlInsert = "INSERT INTO ctos_catentidades (IdGrupoCat,Descripcion) VALUES ('" + grupo + "','" + nombreNuevo + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(SqlInsert);
            }
            formAnt.cargarCategorias();
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actualizarPalabrasClave(String nombreNuevo)
        {
            String sqlSelect = "SELECT ctos_entidades.IDEntidad, ctos_entidades.PalabrasClave FROM ctos_entidades WHERE(((ctos_entidades.PalabrasClave) Like '%" + nombreBase + "%'))";
            DataTable entidades = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach ( DataRow row in entidades.Rows)
            {
                String palabrasClaveUpdate = "";
                String sqlSelectPre = "SELECT ctos_entidades.PalabrasClave AS Categoría FROM ctos_entidades WHERE ctos_entidades.IDEntidad = " + row[0].ToString();
                String palabrasClave = Persistencia.SentenciasSQL.select(sqlSelectPre).Rows[0][0].ToString();
                if (palabrasClave.Length != nombreBase.Length)
                {
                    if (palabrasClave.IndexOf(nombreBase) == 0)
                    {
                        int tamaño = palabrasClave.Length - palabrasClave.IndexOf(";") - 1;
                        palabrasClaveUpdate = palabrasClave.Substring(palabrasClave.IndexOf(";") + 1, tamaño);
                    }
                    else
                    {
                        int tamaño = palabrasClave.Length - palabrasClave.IndexOf(nombreBase) - nombreBase.Length - 1;

                        if (tamaño > 0)
                        {
                            String palabrasClavePre = palabrasClave.Substring(0, palabrasClave.IndexOf(nombreBase));
                            palabrasClaveUpdate += palabrasClavePre;
                            String palabrasClavePost = palabrasClave.Substring(palabrasClave.IndexOf(nombreBase) + nombreBase.Length + 1, tamaño);
                            palabrasClaveUpdate += palabrasClavePost;
                        }
                        else
                        {
                            String palabrasClavePre = palabrasClave.Substring(0, palabrasClave.IndexOf(nombreBase) - 1);
                            palabrasClaveUpdate += palabrasClavePre;
                        }
                    }
                }
                
                if (palabrasClaveUpdate.Length > 0) palabrasClaveUpdate += ";" + nombreNuevo;
                else palabrasClaveUpdate += nombreNuevo;
                String sqlUpdate = "UPDATE ctos_entidades SET PalabrasClave = '" + palabrasClaveUpdate + "' WHERE IDEntidad = " + row[0].ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            
        }
    }
}
