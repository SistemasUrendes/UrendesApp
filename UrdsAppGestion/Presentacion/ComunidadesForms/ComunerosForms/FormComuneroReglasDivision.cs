using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ComunerosForms
{
    public partial class FormComuneroReglasDivision : Form
    {
        String id_division_cargado;
        String id_comunero_cargado;
        String id_asociacion;
        String nombre_division_cargado;

        FormComuneroReglas form_anterior;

        public FormComuneroReglasDivision(FormComuneroReglas form_anterior, String id_division_cargado, String nombre_division_cargado, String id_comunero_cargado, String id_asociacion)
        {
            InitializeComponent();
            this.id_division_cargado = id_division_cargado;
            this.form_anterior = form_anterior;
            this.nombre_division_cargado = nombre_division_cargado;
            this.id_comunero_cargado = id_comunero_cargado;
            this.id_asociacion = id_asociacion;

            textBox_Division.Text = nombre_division_cargado;
        }


        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormComuneroReglasDivision_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
            textBox_Regla.Text = dataGridView_ListaReglasActivas.SelectedCells[0].Value.ToString();
        }
        public void cargarDatagrid() {

            String sql = "SELECT com_reglasrec.IdReglaRec, com_reglasrec.RefRegla, com_reglasrec.Descripcion, ctos_entidades.NombreCorto, aux_formapago.FormaPago, ctos_detbancos.Descripcion FROM ctos_detbancos INNER JOIN (((com_reglasrec INNER JOIN com_comuneros ON com_reglasrec.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN aux_formapago ON com_reglasrec.IdFormaPago = aux_formapago.IdFormaPago) ON ctos_detbancos.IdCuenta = com_reglasrec.IdCC WHERE(((com_reglasrec.IdComunero) = " + id_comunero_cargado + ") AND((com_reglasrec.Activa) = -1));";

            dataGridView_ListaReglasActivas.DataSource = Persistencia.SentenciasSQL.select(sql);
            dataGridView_ListaReglasActivas.Columns["IdReglaRec"].Width = 50;
            dataGridView_ListaReglasActivas.Columns["RefRegla"].Width = 50;

        }

        private void dataGridView_ListaReglasActivas_Click(object sender, EventArgs e)
        {
            textBox_Regla.Text = dataGridView_ListaReglasActivas.SelectedCells[0].Value.ToString();
        }

        private void button_AsignarRegla_Click(object sender, EventArgs e)
        {
            String UpdateSql = "UPDATE com_asociacion SET IdReglaRec = " + dataGridView_ListaReglasActivas.SelectedCells[0].Value.ToString() + " WHERE IdAsociacion = " + id_asociacion;

            Persistencia.SentenciasSQL.InsertarGenerico(UpdateSql);
            MessageBox.Show("Regla Insertada");
            form_anterior.cargarDatagrid();
            this.Close();
        }

        private void button_SinRegla_Click(object sender, EventArgs e)
        {
            String UpdateSql = "UPDATE com_asociacion SET IdReglaRec = NULL WHERE IdAsociacion = " + id_asociacion;

            Persistencia.SentenciasSQL.InsertarGenerico(UpdateSql);
            MessageBox.Show("Regla Borrada");
            form_anterior.cargarDatagrid();
            this.Close();
        }
    }
}
