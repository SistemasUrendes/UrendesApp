namespace UrdsAppGestión
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comunidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verTareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verGestionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comunicadosGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planContableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queRolSoyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mttoTareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mttoGestionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mttoServiciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.barrar_abajo_nombre = new System.Windows.Forms.ToolStripStatusLabel();
            this.barra_abajo_bbdd = new System.Windows.Forms.ToolStripStatusLabel();
            this.barra_abajo_rol = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.panelToolStripMenuItem,
            this.entidadesToolStripMenuItem,
            this.comunidadesToolStripMenuItem,
            this.tareasToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.comunicadosGeneralesToolStripMenuItem,
            this.archivoToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // panelToolStripMenuItem
            // 
            this.panelToolStripMenuItem.Name = "panelToolStripMenuItem";
            resources.ApplyResources(this.panelToolStripMenuItem, "panelToolStripMenuItem");
            this.panelToolStripMenuItem.Click += new System.EventHandler(this.panelToolStripMenuItem_Click);
            // 
            // entidadesToolStripMenuItem
            // 
            this.entidadesToolStripMenuItem.Name = "entidadesToolStripMenuItem";
            resources.ApplyResources(this.entidadesToolStripMenuItem, "entidadesToolStripMenuItem");
            this.entidadesToolStripMenuItem.Click += new System.EventHandler(this.entidadesToolStripMenuItem_Click);
            // 
            // comunidadesToolStripMenuItem
            // 
            this.comunidadesToolStripMenuItem.Name = "comunidadesToolStripMenuItem";
            resources.ApplyResources(this.comunidadesToolStripMenuItem, "comunidadesToolStripMenuItem");
            this.comunidadesToolStripMenuItem.Click += new System.EventHandler(this.comunidadesToolStripMenuItem_Click);
            // 
            // tareasToolStripMenuItem
            // 
            this.tareasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTareasToolStripMenuItem,
            this.verGestionesToolStripMenuItem});
            this.tareasToolStripMenuItem.Name = "tareasToolStripMenuItem";
            resources.ApplyResources(this.tareasToolStripMenuItem, "tareasToolStripMenuItem");
            // 
            // verTareasToolStripMenuItem
            // 
            this.verTareasToolStripMenuItem.Name = "verTareasToolStripMenuItem";
            resources.ApplyResources(this.verTareasToolStripMenuItem, "verTareasToolStripMenuItem");
            this.verTareasToolStripMenuItem.Click += new System.EventHandler(this.verTareasToolStripMenuItem_Click);
            // 
            // verGestionesToolStripMenuItem
            // 
            this.verGestionesToolStripMenuItem.Name = "verGestionesToolStripMenuItem";
            resources.ApplyResources(this.verGestionesToolStripMenuItem, "verGestionesToolStripMenuItem");
            this.verGestionesToolStripMenuItem.Click += new System.EventHandler(this.verGestionesToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            resources.ApplyResources(this.proveedoresToolStripMenuItem, "proveedoresToolStripMenuItem");
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            // 
            // comunicadosGeneralesToolStripMenuItem
            // 
            this.comunicadosGeneralesToolStripMenuItem.Name = "comunicadosGeneralesToolStripMenuItem";
            resources.ApplyResources(this.comunicadosGeneralesToolStripMenuItem, "comunicadosGeneralesToolStripMenuItem");
            this.comunicadosGeneralesToolStripMenuItem.Click += new System.EventHandler(this.comunicadosGeneralesToolStripMenuItem_Click);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planContableToolStripMenuItem,
            this.queRolSoyToolStripMenuItem,
            this.versiónToolStripMenuItem,
            this.cambiarUsuarioToolStripMenuItem,
            this.mantenimientoToolStripMenuItem,
            this.mttoTareasToolStripMenuItem,
            this.mttoGestionesToolStripMenuItem,
            this.mttoServiciosToolStripMenuItem,
            this.conexiónToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            resources.ApplyResources(this.archivoToolStripMenuItem, "archivoToolStripMenuItem");
            // 
            // planContableToolStripMenuItem
            // 
            this.planContableToolStripMenuItem.Name = "planContableToolStripMenuItem";
            resources.ApplyResources(this.planContableToolStripMenuItem, "planContableToolStripMenuItem");
            this.planContableToolStripMenuItem.Click += new System.EventHandler(this.planContableToolStripMenuItem_Click);
            // 
            // queRolSoyToolStripMenuItem
            // 
            this.queRolSoyToolStripMenuItem.Name = "queRolSoyToolStripMenuItem";
            resources.ApplyResources(this.queRolSoyToolStripMenuItem, "queRolSoyToolStripMenuItem");
            this.queRolSoyToolStripMenuItem.Click += new System.EventHandler(this.queRolSoyToolStripMenuItem_Click);
            // 
            // versiónToolStripMenuItem
            // 
            this.versiónToolStripMenuItem.Name = "versiónToolStripMenuItem";
            resources.ApplyResources(this.versiónToolStripMenuItem, "versiónToolStripMenuItem");
            this.versiónToolStripMenuItem.Click += new System.EventHandler(this.versiónToolStripMenuItem_Click);
            // 
            // cambiarUsuarioToolStripMenuItem
            // 
            this.cambiarUsuarioToolStripMenuItem.Name = "cambiarUsuarioToolStripMenuItem";
            resources.ApplyResources(this.cambiarUsuarioToolStripMenuItem, "cambiarUsuarioToolStripMenuItem");
            this.cambiarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.cambiarUsuarioToolStripMenuItem_Click);
            // 
            // mantenimientoToolStripMenuItem
            // 
            resources.ApplyResources(this.mantenimientoToolStripMenuItem, "mantenimientoToolStripMenuItem");
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.Click += new System.EventHandler(this.mantenimientoToolStripMenuItem_Click);
            // 
            // mttoTareasToolStripMenuItem
            // 
            resources.ApplyResources(this.mttoTareasToolStripMenuItem, "mttoTareasToolStripMenuItem");
            this.mttoTareasToolStripMenuItem.Name = "mttoTareasToolStripMenuItem";
            this.mttoTareasToolStripMenuItem.Click += new System.EventHandler(this.mttoTareasToolStripMenuItem_Click);
            // 
            // mttoGestionesToolStripMenuItem
            // 
            resources.ApplyResources(this.mttoGestionesToolStripMenuItem, "mttoGestionesToolStripMenuItem");
            this.mttoGestionesToolStripMenuItem.Name = "mttoGestionesToolStripMenuItem";
            this.mttoGestionesToolStripMenuItem.Click += new System.EventHandler(this.mttoGestionesToolStripMenuItem_Click);
            // 
            // mttoServiciosToolStripMenuItem
            // 
            resources.ApplyResources(this.mttoServiciosToolStripMenuItem, "mttoServiciosToolStripMenuItem");
            this.mttoServiciosToolStripMenuItem.Name = "mttoServiciosToolStripMenuItem";
            this.mttoServiciosToolStripMenuItem.Click += new System.EventHandler(this.mttoServiciosToolStripMenuItem_Click);
            // 
            // conexiónToolStripMenuItem
            // 
            resources.ApplyResources(this.conexiónToolStripMenuItem, "conexiónToolStripMenuItem");
            this.conexiónToolStripMenuItem.Name = "conexiónToolStripMenuItem";
            this.conexiónToolStripMenuItem.Click += new System.EventHandler(this.conexiónToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barrar_abajo_nombre,
            this.barra_abajo_bbdd,
            this.barra_abajo_rol});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // barrar_abajo_nombre
            // 
            this.barrar_abajo_nombre.Name = "barrar_abajo_nombre";
            resources.ApplyResources(this.barrar_abajo_nombre, "barrar_abajo_nombre");
            // 
            // barra_abajo_bbdd
            // 
            resources.ApplyResources(this.barra_abajo_bbdd, "barra_abajo_bbdd");
            this.barra_abajo_bbdd.Name = "barra_abajo_bbdd";
            // 
            // barra_abajo_rol
            // 
            this.barra_abajo_rol.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.barra_abajo_rol.Name = "barra_abajo_rol";
            resources.ApplyResources(this.barra_abajo_rol, "barra_abajo_rol");
            // 
            // FormPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queRolSoyToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem entidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comunidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarUsuarioToolStripMenuItem;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel barrar_abajo_nombre;
        public System.Windows.Forms.ToolStripStatusLabel barra_abajo_bbdd;
        public System.Windows.Forms.ToolStripStatusLabel barra_abajo_rol;
        private System.Windows.Forms.ToolStripMenuItem panelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comunicadosGeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planContableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tareasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verTareasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verGestionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mttoTareasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mttoServiciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mttoGestionesToolStripMenuItem;        
    }
}

