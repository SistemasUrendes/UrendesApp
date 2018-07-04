using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión;
using UrdsAppGestión.Presentacion.EntidadesForms;
using UrdsAppGestión.Presentacion;
using System.Deployment.Application;

namespace UrdsAppGestión {
    public partial class FormPrincipal : Form
    {
        private FormPrincipal instance;

        public FormPrincipal() {
            InitializeComponent();
            instance = this;
        }

        public int DimensionesPantallaAlto() {
            return (int)(this.Size.Height);
        }
        public int DimensionesPantallaAncho() {
            return (int)(this.Size.Width);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.Hide();
            Login nueva = new Login(this);
            nueva.TopMost = true;
            nueva.Show();

            PanelControl newMDIChild = new PanelControl();
            newMDIChild.MdiParent = this;
            newMDIChild.WindowState = FormWindowState.Maximized;
            newMDIChild.Show();
        }

        private void queRolSoyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rol : " + Presentacion.Login.getRol());
        }

        private void entidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "Entidades").SingleOrDefault<Form>();
            if (existe != null)  {
                //existe.Activate();
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
               
            }
            else  {
                Entidades newMDIChild = new Entidades();
                newMDIChild.MdiParent = this;
                newMDIChild.Size = new Size(DimensionesPantallaAncho(), DimensionesPantallaAlto());
                newMDIChild.Show();
            }
        }

        private void comunidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "Comunidades").SingleOrDefault<Form>();
            if (existe != null)  {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else  {
                Comunidades newMDIChild = new Comunidades();
                newMDIChild.MdiParent = this;
                newMDIChild.Size = new Size(DimensionesPantallaAncho(), DimensionesPantallaAlto());
                newMDIChild.Show();
            }
        }

        private void versiónToolStripMenuItem_Click(object sender, EventArgs e)  {
            MessageBox.Show("UrdsAppGestión " + ApplicationDeployment.CurrentDeployment.CurrentVersion.Major.ToString() + "." + ApplicationDeployment.CurrentDeployment.CurrentVersion.Minor.ToString() + "." + ApplicationDeployment.CurrentDeployment.CurrentVersion.Build.ToString() + "." + ApplicationDeployment.CurrentDeployment.CurrentVersion.Revision.ToString());
        }

        private void conexiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConexion nueva = new FormConexion(this);
            nueva.Show();
        }

        private void cambiarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Login nueva = new Login(this);
            nueva.TopMost = true;
            nueva.Show();
        }

        private void panelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                PanelControl newMDIChild = new PanelControl();
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void comunicadosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "Envios").SingleOrDefault<Form>();
            if (existe != null)  {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else  {
                Presentacion.ComunidadesForms.EnviosForms.Envios newMDIChild = new Presentacion.ComunidadesForms.EnviosForms.Envios();
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
            
        }

        private void planContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "Plan Contable").SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                FormPlanContable newMDIChild = new FormPlanContable();
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMantenimiento nuevo = new FormMantenimiento();
            nuevo.Show();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            PanelControl existe = Application.OpenForms.OfType<PanelControl>().Where(pre => pre.Name == "PanelControl").SingleOrDefault<PanelControl>();
            if (existe != null)
            {
                if (existe.dataGridView_tareas.RowCount > 0) {
                    MessageBox.Show("Hay un envio en curso y no se puede cerrar la aplicaión");
                    e.Cancel = true;
                }else {
                    e.Cancel = false;
                }
            }

        }

        private void verTareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Text.Contains("Urendes - [Tareas]")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Presentacion.Tareas.FormTareasPrincipal newMDIChild = new Presentacion.Tareas.FormTareasPrincipal();
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void verGestionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "FormGestionesPrincipal").SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Presentacion.Tareas.FormGestionesPrincipal newMDIChild = new Presentacion.Tareas.FormGestionesPrincipal();
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }
        
        private void mttoTareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "FormTareasConfiguracion").SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Presentacion.Tareas.FormTareasConfiguracion newMDIChild = new Presentacion.Tareas.FormTareasConfiguracion();
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void mttoServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "FormServiciosConfiguracion").SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Presentacion.Tareas.FormServiciosConfiguracion newMDIChild = new Presentacion.Tareas.FormServiciosConfiguracion();
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void mttoGestionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "FormGestionesConfiguracion").SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Presentacion.Tareas.FormGestionesConfirguracion newMDIChild = new Presentacion.Tareas.FormGestionesConfirguracion();
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }
    }
}
