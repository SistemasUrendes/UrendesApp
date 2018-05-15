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
    public partial class ContenedorComunidad : Form  {
        String nombre_comunidad = "";
        int id_comunidad = 0;
   
        public ContenedorComunidad(String nombre_comunidad,int id_comunidad)  {
            InitializeComponent();
            this.nombre_comunidad = nombre_comunidad;
            this.id_comunidad = id_comunidad;
            String referencia = (Persistencia.SentenciasSQL.select("SELECT Referencia FROM com_comunidades WHERE IdComunidad = " + id_comunidad)).Rows[0][0].ToString();
            this.Text = " [" + referencia + "] " + nombre_comunidad ;
        }

        private void fichaToolStripMenuItem_Click(object sender, EventArgs e)  {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "Comunidades").SingleOrDefault<Form>();
            FormFicha nueva = new FormFicha((Comunidades)existe,id_comunidad,nombre_comunidad);
            nueva.Show();
        }

        private void divisionesToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void enviosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void admnistraciónToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void liquidacionesToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void listadoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "FormDivisiones").SingleOrDefault<Form>();
            if (existe != null) {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else {
                Divisiones newMDIChild = new Divisiones(id_comunidad);
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "Comuneros").SingleOrDefault<Form>();

                if (existe != null && existe.Parent.Text.Contains(nombre_comunidad))  {
                    existe.WindowState = FormWindowState.Maximized;
                    existe.BringToFront();
                }
                else {
                    Comuneros newMDIChild = new Comuneros(id_comunidad.ToString());
                    newMDIChild.MdiParent = this;
                    newMDIChild.WindowState = FormWindowState.Maximized;
                    newMDIChild.Show();
                }
            }
            catch (InvalidOperationException) {
                Comuneros newMDIChild = new Comuneros(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }       
        }

        private void cuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains("Tesoreria" + nombre_comunidad)).SingleOrDefault<Form>();
            if (existe != null) {
                //existe.Close();
                //FormAccesoTesoreria nueva = new FormAccesoTesoreria(nombre_comunidad, id_comunidad);
                //nueva.Show();
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else {
                FormAccesoTesoreria nueva = new FormAccesoTesoreria(nombre_comunidad, id_comunidad);
                nueva.Show();
            }
        }

        private void bloquesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Bloques")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                BloquesForms.Bloques newMDIChild = new BloquesForms.Bloques(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void ejerciciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Ejercicios")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                EjerciciosForms.Ejercicios newMDIChild = new EjerciciosForms.Ejercicios(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void liquidacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Liquidaciones")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                LiquidacionesForms.Liquidaciones newMDIChild = new LiquidacionesForms.Liquidaciones(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void cuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Cuotas")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                CuotasForms.Cuotas newMDIChild = new CuotasForms.Cuotas(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void fondosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Fondos")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                FondosForms.FormFondos newMDIChild = new FondosForms.FormFondos(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void provisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Provisiones")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                FormProvisiones.FormProvisiones newMDIChild = new FormProvisiones.FormProvisiones(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Cargos")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                CargosForms.FormCargos newMDIChild = new CargosForms.FormCargos(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void listadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " ListadoProveedores")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                OperacionesForms.FormOperacionesListadoProveedores newMDIChild = new OperacionesForms.FormOperacionesListadoProveedores(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void compensaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " FormTesoreriaCompesaciones")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                TesoreriaForms.FormTesoreriaCompesaciones newMDIChild = new TesoreriaForms.FormTesoreriaCompesaciones(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void operacionesProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void operacionesComunerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void operacionesDivisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void recibosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " FormRecibos ")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                ComunerosForms.FormRecibos newMDIChild = new ComunerosForms.FormRecibos(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void remesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void operacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Operaciones_proveedores ")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Operaciones_proveedores newMDIChild = new Operaciones_proveedores(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void vencimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Operaciones_comuneros ")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Operaciones_comuneros newMDIChild = new Operaciones_comuneros(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void deudasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DivisionesForms.FormDivisionesCuotas nueva = new DivisionesForms.FormDivisionesCuotas(id_comunidad.ToString());
            nueva.Show();
        }

        private void cuentasBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Cuentas Bancos ")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                CargosForms.CuentasBanco newMDIChild = new CargosForms.CuentasBanco(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void remesasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " FormRemesas ")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                RemesasForms.FormRemesas newMDIChild = new RemesasForms.FormRemesas(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void documentosYComunicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Envios")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                EnviosForms.Envios newMDIChild = new EnviosForms.Envios(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void liquidacionesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Liquidaciones")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                LiquidacionesForms.Liquidaciones newMDIChild = new LiquidacionesForms.Liquidaciones(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void cuotasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Cuotas")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                CuotasForms.Cuotas newMDIChild = new CuotasForms.Cuotas(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void ejerciciosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Ejercicios")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
                //this.Size = new Size(862, 685);
            }
            else
            {
                EjerciciosForms.Ejercicios newMDIChild = new EjerciciosForms.Ejercicios(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
                //this.Size = new Size(862,685);
            }
        }

        private void gestiónDeudasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DivisionesForms.FormDivisionesCuotas nueva = new DivisionesForms.FormDivisionesCuotas(id_comunidad.ToString());
            nueva.Show();
        }

        private void anticiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Anticipos ")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                ComunerosForms.Anticipos newMDIChild = new ComunerosForms.Anticipos(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void informesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Informes ")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Informes.InformeDeudasComunero.FormInformeDeudasComunero newMDIChild = new Informes.InformeDeudasComunero.FormInformeDeudasComunero(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void tareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Tareas ")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                Tareas.FormTareasPrincipal newMDIChild = new Tareas.FormTareasPrincipal(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }
        }

        private void elementosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Elementos.FormElementos nueva = new Elementos.FormElementos(id_comunidad);
            nueva.Show();
        }

        private void rutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlRuta = "SELECT ctos_entidades.Ruta FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad GROUP BY com_comunidades.IdComunidad, ctos_entidades.Ruta HAVING(((com_comunidades.IdComunidad) = " + id_comunidad + "));";
            DataTable ruta = Persistencia.SentenciasSQL.select(sqlRuta);
            if (ruta.Rows.Count > 0) {
                String Ruta = ruta.Rows[0][0].ToString().Trim('#');
                System.Diagnostics.Process.Start(@Ruta);
            }
        }

        private void anticiposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name.Contains(nombre_comunidad + " Anticipos Proveedores ")).SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Maximized;
                existe.BringToFront();
            }
            else
            {
                ProveedoresForms.FormAnticiposProveedores newMDIChild = new ProveedoresForms.FormAnticiposProveedores(id_comunidad.ToString());
                newMDIChild.MdiParent = this;
                newMDIChild.WindowState = FormWindowState.Maximized;
                newMDIChild.Show();
            }

        }
    }
}
