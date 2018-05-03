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
    public partial class FormDuplicarTarea : Form
    {
        FormTareasPrincipal form_anterior;
        String idTipoTarea;
        String fIni;
        String descripcion;
        String coste;
        String seguro;
        String acuerdoJunta;
        String fechaActaAcordado;
        String proximaJunta;
        String refSiniestro;
        String fFin;
        String ruta;
        String notas;
        String importante;
        String nombreElemento;
        String idElemento;
        String idEntidad;
        String nombreComunidad;
        int idComunidad;
        String referencia;
        String idTarea;
        

        public FormDuplicarTarea(FormTareasPrincipal form_anterior,String idTipoTarea, String fIni, String descripcion, String coste, String seguro, String acuerdoJunta, String fechaActaAcordado, String proximaJunta, String refSiniestro, String fFin, String ruta, String notas, String importante, String nombreElemento, String idElemento, String idEntidad, String nombreComunidad, int idComunidad, String Referencia,String idTarea)
        {
            InitializeComponent();
            this.form_anterior = form_anterior;
            this.idTipoTarea = idTipoTarea;
            this.fIni = fIni;
            this.descripcion = descripcion;
            this.coste = coste;
            this.seguro = seguro;
            this.acuerdoJunta = acuerdoJunta;
            this.fechaActaAcordado = fechaActaAcordado;
            this.proximaJunta = proximaJunta ;
            this.refSiniestro = refSiniestro;
            this.fFin = fFin;
            this.ruta = ruta;
            this.notas = notas;
            this.importante = importante;
            this.nombreElemento = nombreComunidad;
            this.idElemento = idElemento;
            this.idEntidad = idEntidad;
            this.nombreComunidad = nombreComunidad;
            this.idComunidad = idComunidad;
            this.referencia = Referencia;
            this.idTarea = idTarea;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDuplicar_Click(object sender, EventArgs e)
        {
            Boolean contactos = checkBoxContactos.Checked;
            Boolean expedientes = checkBoxExpedientes.Checked;
            FormVerTarea nueva = new FormVerTarea(form_anterior,idTipoTarea, fIni, descripcion, coste, seguro, acuerdoJunta, fechaActaAcordado, proximaJunta, refSiniestro, fFin, ruta, notas, importante, nombreElemento, idElemento, idEntidad, nombreComunidad, idComunidad, referencia, idTarea,contactos,expedientes);
            nueva.ControlBox = true;
            nueva.TopMost = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
            this.Close();
        }
    }
}
