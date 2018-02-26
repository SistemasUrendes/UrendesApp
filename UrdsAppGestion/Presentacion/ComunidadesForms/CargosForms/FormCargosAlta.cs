using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.CargosForms
{
    public partial class FormCargosAlta : Form
    {
        String id_comunidad_cargado = "0";
        FormCargos form_anterior;
        String id_entidad_nuevo;

        public FormCargosAlta(FormCargos form_anterior, String id_comunidad_cargado)
        {
            InitializeComponent();
            this.id_comunidad_cargado = id_comunidad_cargado;
            this.form_anterior = form_anterior;
        }

        private void FormCargosAlta_Load(object sender, EventArgs e)
        {
            cargardatagrid();
        }
        public void cargardatagrid() {
            if (id_comunidad_cargado != "0" ) {
                String sqlSelect = "SELECT IdCargo,Cargo FROM com_cargos WHERE IdComunidad = " + id_comunidad_cargado + " and Baja <> -1";
                comboBox_cargo.DataSource = Persistencia.SentenciasSQL.select(sqlSelect);
                comboBox_cargo.ValueMember = "IdCargo";
                comboBox_cargo.DisplayMember = "Cargo";
                if (comboBox_cargo.Items.Count > 0)
                {
                    String sqlSelectComunero = "SELECT IdComunero FROM com_cargoscom WHERE IdComunidad = " + id_comunidad_cargado + " and IdCargo = " + comboBox_cargo.SelectedValue.ToString() + " and FFin is null";
                    DataTable fila = Persistencia.SentenciasSQL.select(sqlSelectComunero);

                    if (fila.Rows.Count > 0)
                    {
                        String nombreComunero = "SELECT ctos_entidades.Entidad FROM com_comuneros INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comuneros.IdComunero) = " + fila.Rows[0][0].ToString() + "));";
                        textBox1.Text = (Persistencia.SentenciasSQL.select(nombreComunero)).Rows[0][0].ToString();
                    }
                    else
                        textBox1.Text = "Nadie ocupa este cargo";
                }
            }
             
        }

        private void comboBox_cargo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cargo = (ComboBox)sender;
            String sqlSelectComunero = "SELECT IdComunero FROM com_cargoscom WHERE IdComunidad = " + id_comunidad_cargado + " and IdCargo = " + comboBox_cargo.SelectedValue.ToString() + " and FFin is null";
            DataTable fila = Persistencia.SentenciasSQL.select(sqlSelectComunero);
            if (fila.Rows.Count > 0) {
                String nombreComunero = "SELECT ctos_entidades.Entidad FROM com_comuneros INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comuneros.IdComunero) = " + fila.Rows[0][0].ToString() + "));";
                textBox1.Text = (Persistencia.SentenciasSQL.select(nombreComunero)).Rows[0][0].ToString();
            }
            else {
                textBox1.Text = "Nadie ocupa este cargo";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Nadie ocupa este cargo") {
                //Dar de baja al anterior
                String fechaFin = (Convert.ToDateTime(maskedTextBox1.Text).AddDays(-1)).ToString("yyyy-MM-dd");
                String sqlUpdate = "UPDATE com_cargoscom SET FFin='" + fechaFin + "' WHERE IdCargo = " + comboBox_cargo.SelectedValue.ToString() + "";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            String fechaInicio = (Convert.ToDateTime(maskedTextBox1.Text)).ToString("yyyy-MM-dd");

            String sqlInsert = "INSERT INTO com_cargoscom (IdComunidad, IdComunero, IdCargo, FInicio) VALUES (" + id_comunidad_cargado + "," + id_entidad_nuevo + "," + comboBox_cargo.SelectedValue.ToString() + ",'" + fechaInicio + "')";

            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            form_anterior.cargardatagrid();
            this.Close();
        }
        private void textBox_comunero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter || e.KeyChar == (Char)Keys.Space)
            {
                Comuneros nueva = new Comuneros(this, this.Name, id_comunidad_cargado);
                nueva.ControlBox = true;
                nueva.TopMost = true;
                nueva.WindowState = FormWindowState.Normal;
                nueva.StartPosition = FormStartPosition.CenterScreen;
                nueva.Show();
            }
        }

        public void recibirComunero(String id_comunero,String nombre)
        {
            id_entidad_nuevo = id_comunero;
            textBox_comunero.Text = nombre;
        }
    }
}
