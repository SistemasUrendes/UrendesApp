using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CuotasForms
{
    public partial class FormCuotasPlantillaPptoDetalle : Form
    {
        String id_comunidad_cargado;
        FormCuotasPlantillas form_anterior;
        String id_plantilla_cargado = "0";

        public FormCuotasPlantillaPptoDetalle(FormCuotasPlantillas form_anterior,String id_comunidad_cargado,String id_plantilla_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
            this.id_plantilla_cargado = id_plantilla_cargado;
        }

        private void FormCuotasPlantillaPptoDetalle_Load(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT Descripcion, Activa FROM com_plantillacuotas WHERE IdPlantillaCuota = " + id_plantilla_cargado;
            DataTable fila = Persistencia.SentenciasSQL.select(sqlSelect);
            textBox_Plantilla.Text = fila.Rows[0][0].ToString();
            
            if (fila.Rows[0][1].ToString() == "True") {
                checkBox_activa.Checked = true;
            }
            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String sqlSelect = "SELECT com_detplantillacuotas.IdDetPlantCuota, com_bloques.Descripcion, com_detplantillacuotas.Importe FROM com_detplantillacuotas INNER JOIN com_bloques ON com_detplantillacuotas.IdBloque = com_bloques.IdBloque WHERE(((com_detplantillacuotas.IdPlantillaCuota) = " + id_plantilla_cargado + "));";
            dataGridView_DetallePlantilla.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
        }

        private void button_Añadir_Click(object sender, EventArgs e)
        {
            FormCuotasPlantillaPptoAlta nueva = new FormCuotasPlantillaPptoAlta(this,id_plantilla_cargado,id_comunidad_cargado);
            nueva.Show();
        }

        private void button_Editar_Click(object sender, EventArgs e)
        {
            FormCuotasPlantillaPptoAlta nueva = new FormCuotasPlantillaPptoAlta(this, id_plantilla_cargado, id_comunidad_cargado,dataGridView_DetallePlantilla.SelectedCells[0].Value.ToString());
            nueva.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String principal = "0";
            if (checkBox_activa.Checked) principal = "-1";
            String sqlUpdate = "UPDATE com_plantillacuotas SET Descripcion='" + textBox_Plantilla.Text + "', Activa=" + principal + " WHERE IdPlantillaCuota = " + id_plantilla_cargado;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            form_anterior.cargarDatagrid();
            form_anterior.cargarPrefiltro();
            this.Close(); 
        }

        private void button_Borrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta Plantilla ?", "Borrar Plantilla", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM com_detplantillacuotas WHERE IdDetPlantCuota =  " + dataGridView_DetallePlantilla.SelectedCells[0].Value.ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargarDatagrid();
            }
        }
    }
}
