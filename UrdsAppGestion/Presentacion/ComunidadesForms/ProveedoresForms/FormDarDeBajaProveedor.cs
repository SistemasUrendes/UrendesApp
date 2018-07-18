using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms.ProveedoresForms
{
    public partial class FormDarDeBajaProveedor : Form
    {
        OperacionesForms.FormOperacionesListadoProveedores formAnt;
        String idProveedor;

        public FormDarDeBajaProveedor(OperacionesForms.FormOperacionesListadoProveedores formAnt,String idProveedor)
        {
            InitializeComponent();
            this.formAnt = formAnt;
            this.idProveedor = idProveedor;
        }
        
        private void FormDarDeBajaProveedor_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = DateTime.Now.ToShortDateString();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String fecha = maskedTextBox1.Text;
            if (fecha == "  /  /")
            {
                MessageBox.Show("Introduce una fecha.");
                return;
            }
            else
            {
                String sqlUpdate = "UPDATE com_proveedores SET FBaja = '" + fecha + "' WHERE IdProveedor = " + idProveedor;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                formAnt.cargarDatagrid();
                this.Close();
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
