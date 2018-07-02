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
        String notas;
        String importante;
        String idEntidad;
        String nombreComunidad;
        int idComunidad;
        String referencia;
        private CheckBox checkBoxContactos;
        private CheckBox checkBoxExpedientes;
        private Button buttonCancelar;
        private Button buttonDuplicar;
        String idTarea;
        

        public FormDuplicarTarea(FormTareasPrincipal form_anterior,String idTipoTarea, String fIni, String descripcion, String coste, String seguro, String acuerdoJunta, String fechaActaAcordado, String proximaJunta, String refSiniestro, String notas, String importante, String idEntidad, String nombreComunidad, int idComunidad, String Referencia,String idTarea)
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
            this.notas = notas;
            this.importante = importante;
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
            FormVerTarea nueva = new FormVerTarea(form_anterior,idTipoTarea, fIni, descripcion, coste, seguro, acuerdoJunta, fechaActaAcordado, proximaJunta, refSiniestro, notas, importante, idEntidad, nombreComunidad, idComunidad, referencia, idTarea,contactos,expedientes);
            nueva.ControlBox = true;
            nueva.WindowState = FormWindowState.Normal;
            nueva.StartPosition = FormStartPosition.CenterScreen;
            nueva.Show();
            this.Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDuplicarTarea));
            this.checkBoxContactos = new System.Windows.Forms.CheckBox();
            this.checkBoxExpedientes = new System.Windows.Forms.CheckBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonDuplicar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxContactos
            // 
            this.checkBoxContactos.AutoSize = true;
            this.checkBoxContactos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxContactos.Location = new System.Drawing.Point(76, 18);
            this.checkBoxContactos.Name = "checkBoxContactos";
            this.checkBoxContactos.Size = new System.Drawing.Size(99, 21);
            this.checkBoxContactos.TabIndex = 2;
            this.checkBoxContactos.Text = "Contactos";
            this.checkBoxContactos.UseVisualStyleBackColor = true;
            // 
            // checkBoxExpedientes
            // 
            this.checkBoxExpedientes.AutoSize = true;
            this.checkBoxExpedientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxExpedientes.Location = new System.Drawing.Point(76, 53);
            this.checkBoxExpedientes.Name = "checkBoxExpedientes";
            this.checkBoxExpedientes.Size = new System.Drawing.Size(115, 21);
            this.checkBoxExpedientes.TabIndex = 3;
            this.checkBoxExpedientes.Text = "Expedientes";
            this.checkBoxExpedientes.UseVisualStyleBackColor = true;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(197, 96);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 4;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonDuplicar
            // 
            this.buttonDuplicar.Location = new System.Drawing.Point(116, 96);
            this.buttonDuplicar.Name = "buttonDuplicar";
            this.buttonDuplicar.Size = new System.Drawing.Size(75, 23);
            this.buttonDuplicar.TabIndex = 5;
            this.buttonDuplicar.Text = "Duplicar";
            this.buttonDuplicar.UseVisualStyleBackColor = true;
            this.buttonDuplicar.Click += new System.EventHandler(this.buttonDuplicar_Click);
            // 
            // FormDuplicarTarea
            // 
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.buttonDuplicar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.checkBoxExpedientes);
            this.Controls.Add(this.checkBoxContactos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDuplicarTarea";
            this.Text = "DuplicarTarea";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
    }
}
