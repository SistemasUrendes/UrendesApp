using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.DivisionesForms.ReglasPago
{
    public partial class FormAnyadirReglaDetalle : Form
    {
        String idReglaReparto;
        String idComunidad;
        String idComunero;
        String idReglaDetalle = "";
        FormReglasPago form_anterior;

        public FormAnyadirReglaDetalle(FormReglasPago form_anterior, String idReglaReparto,String idComunidad)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idReglaReparto = idReglaReparto;
            this.idComunidad = idComunidad;
        }
        public FormAnyadirReglaDetalle(FormReglasPago form_anterior, String idReglaReparto,String idComunidad, String idReglaDetalle)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idReglaReparto = idReglaReparto;
            this.idComunidad = idComunidad;
            this.idReglaDetalle = idReglaDetalle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAnyadirReglaDetalle_Load(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_divisiones.Division, com_tipocuotas.TipoCuota, com_repartos.Descripcion FROM(com_repartos INNER JOIN com_divisiones ON com_repartos.IdDivision = com_divisiones.IdDivision) INNER JOIN com_tipocuotas ON com_repartos.IdTipoCuota = com_tipocuotas.IdTipoCuota WHERE(((com_repartos.IdReparto) = " + idReglaReparto + "));";

            DataTable reparto = Persistencia.SentenciasSQL.select(sqlSelect);

            if (reparto.Rows.Count > 0) {
                textBox_division.Text = reparto.Rows[0][0].ToString();
                textBox_tipo_reparto.Text = reparto.Rows[0][1].ToString();
                textBox_reparto.Text = reparto.Rows[0][2].ToString();
            }

            if (idReglaDetalle != "") {
                String sqlSelecDetalle = "SELECT com_detrepartos.Porcentaje, com_detrepartos.ImporteFijo, ctos_entidades.Entidad, com_detrepartos.IdComunero FROM(com_detrepartos INNER JOIN com_comuneros ON com_detrepartos.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_detrepartos.IdDetReparto) = " + idReglaDetalle + ")); ";

                DataTable detallesReparto = Persistencia.SentenciasSQL.select(sqlSelecDetalle);

                if (detallesReparto.Rows[0][0].ToString() != "0")  {
                    double porcentaje = Convert.ToDouble(detallesReparto.Rows[0][0].ToString().Replace(".",","));
                    porcentaje = porcentaje * 100;
                    textBox_porcentaje.Text = porcentaje.ToString();
                    
                }

                if (detallesReparto.Rows[0][1].ToString() != "0")
                    textBox_importe.Text = detallesReparto.Rows[0][1].ToString();

                textBox_comunero.Text = detallesReparto.Rows[0][2].ToString();
                idComunero = detallesReparto.Rows[0][3].ToString();

            }
        }

        private void textBox_comunero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Comuneros nueva = new Comuneros(this, this.Name, idComunidad);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
        }
        public void recibirComunero(String id_comunero, String nombre)
        {
            idComunero = id_comunero;
            textBox_comunero.Text = nombre;
        }

        private void textBox_porcentaje_Enter(object sender, EventArgs e)
        {
            textBox_importe.Text = "";
        }

        private void textBox_importe_Enter(object sender, EventArgs e)
        {
            textBox_porcentaje.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double porcentaje;
            double importe;
            String sqlInsert;

            if (textBox_porcentaje.Text != "")
            {
                if (textBox_porcentaje.Text.Contains(".")) textBox_porcentaje.Text = textBox_porcentaje.Text.Replace(".", ",");
                if (double.TryParse(textBox_porcentaje.Text, out porcentaje))
                {
                    
                    porcentaje = porcentaje / 100;

                    if (!compruebaPorcentajeDetalles(porcentaje))
                    {
                        MessageBox.Show("La suma de todos los detalles supera el 100%");
                        return;
                    }

                    if (idReglaDetalle != "")
                        sqlInsert = "UPDATE com_detrepartos SET IdComunero=" + idComunero + ", Porcentaje=" + Logica.FuncionesGenerales.ArreglarImportes(porcentaje.ToString()) + " WHERE IdDetReparto = " + idReglaDetalle;
                    else
                        sqlInsert = "INSERT INTO com_detrepartos (IdReparto, IdComunero, Porcentaje) VALUES (" + idReglaReparto + "," + idComunero + "," + Logica.FuncionesGenerales.ArreglarImportes(porcentaje.ToString()) + ")";

                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                    porcentaje = 0.00;
                    form_anterior.cargarDetallesRepartos();
                }
            }
            else if (textBox_importe.Text != "")
            {
                if (textBox_importe.Text.Contains(".")) textBox_importe.Text = textBox_importe.Text.Replace(".", ",");
                if (double.TryParse(textBox_importe.Text, out importe))
                {
                    if (idReglaDetalle != "")
                        sqlInsert = "UPDATE com_detrepartos SET IdComunero=" + idComunero + ", ImporteFijo=" + Logica.FuncionesGenerales.ArreglarImportes(importe.ToString()) + "  WHERE IdDetReparto = " + idReglaDetalle;
                    else
                        sqlInsert = "INSERT INTO com_detrepartos (IdReparto, IdComunero, ImporteFijo) VALUES (" + idReglaReparto + "," + idComunero + "," + Logica.FuncionesGenerales.ArreglarImportes(importe.ToString()) + ")";

                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
                    importe = 0.00;
                    form_anterior.cargarDetallesRepartos();
                }
            }
            this.Close();
        }

        private void textBox_porcentaje_Leave(object sender, EventArgs e)
        {
           if (Convert.ToDouble(textBox_porcentaje.Text.Replace(".",",")) > 100 || Convert.ToDouble(textBox_porcentaje.Text.Replace(".", ",")) < 0) {
                MessageBox.Show("Introduce un valor entre 0 y 100");
            }
        }
        private bool compruebaPorcentajeDetalles(double porcentaje) {
            double total;

            String sqlSelectPor = "SELECT com_detrepartos.Porcentaje FROM com_detrepartos WHERE com_detrepartos.IdReparto = " + idReglaReparto + ";";
            DataTable sumaDetalles = Persistencia.SentenciasSQL.select(sqlSelectPor);
            if (sumaDetalles.Rows.Count == 0) return true;
            else {
                double porcentajeOtro = Convert.ToDouble(sumaDetalles.Rows[0][0].ToString());
                total = (porcentajeOtro + porcentaje);
                if (total > 1)
                    return false;
                else
                    return true;
            }
        }
    }
}
