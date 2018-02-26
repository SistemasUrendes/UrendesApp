using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.ComunidadesForms
{
    public partial class FormAccesoTesoreria : Form
    {
        String nombre_comunidad = "";
        int id_comunidad = 0;
        public FormAccesoTesoreria(String nombre_comunidad,int id_comunidad)
        {
            InitializeComponent();
            this.nombre_comunidad = nombre_comunidad;
            this.id_comunidad = id_comunidad;
            label_comunidad.Text = nombre_comunidad;
        }

        private void FormAccesoTesoreria_Load(object sender, EventArgs e)
        {
            cargarDatagrid();
        }
        public void cargarDatagrid() {
            String sql = "SELECT IdCuenta, IdComunidad, Descripcion, Ppal, C FROM com_cuentas WHERE com_cuentas.IdComunidad = " + id_comunidad + " ORDER BY com_cuentas.Ppal;";
            DataTable cuentas = Persistencia.SentenciasSQL.select(sql);

            listBox_cuentas.DataSource = cuentas;
            listBox_cuentas.DisplayMember = "Descripcion";
            listBox_cuentas.ValueMember = "IdCuenta";
        }

        private void button_abrir_tesoreria_Click(object sender, EventArgs e)
        {
            //Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains("Tesoreria" + nombre_comunidad)).SingleOrDefault<Form>();

            //if (existe != null )
            //{
            //    existe.WindowState = FormWindowState.Maximized;
            //    existe.BringToFront();
            //}
            //else
            //{
                Tesoreria newMDIChild = new Tesoreria(nombre_comunidad,id_comunidad,(int)listBox_cuentas.SelectedValue);

                Form existe2 = Application.OpenForms.OfType<Form>().Where(pre => pre.Text.Contains(" " + nombre_comunidad)).SingleOrDefault<Form>();
                existe2.Show();
                existe2.Activate();

                newMDIChild.MdiParent = existe2;
                newMDIChild.Name = "Tesoreria" + nombre_comunidad;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            //}
            this.Close();
        }

        private void listBox_cuentas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains("Tesoreria" + nombre_comunidad)).SingleOrDefault<Form>();

            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Tesoreria newMDIChild = new Tesoreria(nombre_comunidad, id_comunidad, (int)listBox_cuentas.SelectedValue);

                Form existe2 = Application.OpenForms.OfType<Form>().Where(pre => pre.Text.Contains(" " + nombre_comunidad)).SingleOrDefault<Form>();
                existe2.Show();
                existe2.Activate();

                newMDIChild.MdiParent = existe2;
                newMDIChild.Name = "Tesoreria" + nombre_comunidad;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TesoreriaForms.FormCrearCuentaComunidad nueva = new TesoreriaForms.FormCrearCuentaComunidad(this, id_comunidad.ToString());
            nueva.Show();
        }
    }
}
