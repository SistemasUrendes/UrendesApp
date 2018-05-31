using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.Tareas
{
    public partial class FormInsertarTipoGestion : Form
    {
        FormTareasConfiguracion form;
        String idTipoGestion;
        public FormInsertarTipoGestion(FormTareasConfiguracion form)
        {
            InitializeComponent();
            this.form = form;
        }
        public FormInsertarTipoGestion(FormTareasConfiguracion form,String idTipoGestion)
        {
            InitializeComponent();
            this.form = form;
            this.idTipoGestion = idTipoGestion;
        }

        private void FormInsertarTipoGestion_Load(object sender, EventArgs e)
        {
            rellenarComboBox();
            if (idTipoGestion != null)
            {
                cargarTipoTarea();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxNombre.Text != "" && maskedTextBoxPlazo.Text != "")
            {
                //VALORES DE LA QUERY DE INSERCIÓN
                String descripcion = textBoxNombre.Text;
                String plazo = maskedTextBoxPlazo.Text;
                String idGrupo = comboBoxResponsable.SelectedValue.ToString();
                Double horas = 0.0;
                if (maskedTextBoxHoras.Text != "") horas = Int32.Parse(maskedTextBoxHoras.Text);
                if (maskedTextBoxMinutos.Text != "") horas += minAHora(maskedTextBoxMinutos.Text);
                
                if (idTipoGestion != null)
                {
                    String sqlUpdate = "UPDATE exp_tipogestion SET Descripcion = '" + descripcion + "',Plazo = '" + plazo + "',IdGrupo = " + idGrupo + ",HorasDeTrabajo = " + horas.ToString().Replace(",",".") + "  WHERE IdTipoGestion = " + idTipoGestion;
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                    form.cargarTiposGestion();
                    MessageBox.Show("Tipo Gestion actualizado correctamente");
                    this.Close();
                }
                else
                {
                    String sqlInsert = "INSERT INTO exp_tipogestion (Descripcion,Plazo,IdGrupo,HorasDeTrabajo) VALUES ('" + descripcion + "','" + plazo + "'," + idGrupo + "," + horas.ToString().Replace(",", ".") + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                    form.cargarTiposGestion();
                    MessageBox.Show("Tipo Gestion añadido correctamente");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Introduzca valores en los campos Nombre y Plazo");
            }
        }


        private void cargarTipoTarea()
        {
            String sqlSelect = "SELECT Descripcion,Plazo,IdGrupo,HorasDeTrabajo FROM exp_tipogestion WHERE IdTipoGestion = " + idTipoGestion;
            DataTable tipoGestion = Persistencia.SentenciasSQL.select(sqlSelect);
            textBoxNombre.Text = tipoGestion.Rows[0][0].ToString();
            maskedTextBoxPlazo.Text = tipoGestion.Rows[0][1].ToString();
            if (tipoGestion.Rows[0][2].ToString() != "0") comboBoxResponsable.SelectedValue = tipoGestion.Rows[0][2].ToString();
            Double horas = Double.Parse(tipoGestion.Rows[0][3].ToString());
            int hora = (int)horas;
            horas = horas-hora;
            horas = horas * 60;
            int minutos = (int)horas;
            maskedTextBoxHoras.Text = hora.ToString();
            maskedTextBoxMinutos.Text = minutos.ToString();


        }

        private void rellenarComboBox()
        {
            String sqlComboRol = "SELECT ctos_gruposurd.Grupo, ctos_gruposurd.IdGrupoURD FROM ctos_gruposurd WHERE ctos_gruposurd.IdGrupoURD > 1";
            comboBoxResponsable.DataSource = Persistencia.SentenciasSQL.select(sqlComboRol);
            comboBoxResponsable.DisplayMember = "Grupo";
            comboBoxResponsable.ValueMember = "IdGrupoURD";
        }
        
        private double minAHora(String minutos)
        {
            double mins = Int32.Parse(minutos);
            mins = mins / 60;
            return mins;
        }
    }
}
