using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.BloquesForms
{
    public partial class FormBloquesAlta : Form
    {
        Bloques form_anterior;
        String id_comunidad_cargado;
        String id_bloque = "0";
        String descripcion;
        String generales;
        String baja;
        String fisica;
        String tipoCalculo;

        public FormBloquesAlta(Bloques form_anterior,String id_comunidad_cargado, String id_bloque,String descripcion, String generales, String baja, String tipoCalculo, String fisica)
        {
            InitializeComponent();
            this.id_bloque = id_bloque;
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.descripcion = descripcion;
            this.generales = generales;
            this.baja = baja;
            this.tipoCalculo = tipoCalculo;
            this.form_anterior = form_anterior;
            this.fisica = fisica;
        }
        public FormBloquesAlta(Bloques form_anterior,String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormBloquesAlta_Load(object sender, EventArgs e)
        {
            String sqlCombo = "SELECT com_tipoSubcuota.IdTipoSubcuota, com_tipoSubcuota.Descripcion FROM com_tipoSubcuota;";
            comboBox_tipoCalculo.DataSource = Persistencia.SentenciasSQL.select(sqlCombo);
            comboBox_tipoCalculo.DisplayMember = "Descripcion";
            comboBox_tipoCalculo.ValueMember = "IdTipoSubcuota";

            if (id_bloque != "0") {
                textBox_Bloque.Text = descripcion;
                if (generales == "True") checkBox_GG.Checked = true;
                if (baja == "False") checkBox_Desactivado.Checked = false;
                else checkBox_Desactivado.Checked = true;
                if (fisica == "True") checkBox_fisico.Checked = true;
                comboBox_tipoCalculo.SelectedValue = tipoCalculo;
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            String general = "0";

            String baja = "0";
            String fisico = "0";

            if (checkBox_GG.Checked)  {
                general = "-1";
                comprueba_generales();
            }

            if (checkBox_Desactivado.Checked) baja = "-1";
            if (checkBox_fisico.Checked) fisico = "-1";


            if (id_bloque != "0") {

                String sql = "UPDATE com_bloques SET Descripcion = '" + textBox_Bloque.Text + "', GG = " + general + ", Baja = " + baja + ", Fisica = " + fisico + ", IdTipoSubcuota =" + comboBox_tipoCalculo.SelectedValue + " WHERE com_bloques.IdBloque = " + id_bloque;

                Persistencia.SentenciasSQL.InsertarGenerico(sql);
                form_anterior.cargarBloques();
                this.Close();
            }else {
                String sql = "INSERT INTO com_bloques (IdComunidad, Descripcion, IdTipoBloque, GG, Baja, IdTipoSubcuota, Fisica) VALUES(" + id_comunidad_cargado + ",'" + textBox_Bloque.Text + "',1," + general + "," + baja + "," + comboBox_tipoCalculo.SelectedValue + ", " + fisico + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(sql);
                form_anterior.cargarBloques();
                this.Close();
            }
        }
        private void comprueba_generales()  {
            String sql = "UPDATE com_bloques SET com_bloques.GG = 0 WHERE (((com_bloques.IdComunidad) = " + id_comunidad_cargado + ") AND ((com_bloques.IdTipoBloque) = 1));";

            Persistencia.SentenciasSQL.InsertarGenerico(sql);

        }

        private void checkBox_GG_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_GG.Checked) checkBox_Desactivado.Enabled = false;
            else {
                checkBox_Desactivado.Enabled = true;
            }
        }
    }
}
