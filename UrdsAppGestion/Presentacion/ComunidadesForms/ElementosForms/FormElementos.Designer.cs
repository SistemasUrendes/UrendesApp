namespace UrdsAppGestión.Presentacion.ComunidadesForms.Elementos
{
    partial class FormElementos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormElementos));
            this.labelRuta = new System.Windows.Forms.Label();
            this.buttonInicio = new System.Windows.Forms.Button();
            this.buttonAtras = new System.Windows.Forms.Button();
            this.treeViewElementos = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.añadirElementoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addElementoPrintoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonBorrar = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRuta
            // 
            this.labelRuta.AutoSize = true;
            this.labelRuta.Location = new System.Drawing.Point(9, 41);
            this.labelRuta.Name = "labelRuta";
            this.labelRuta.Size = new System.Drawing.Size(0, 13);
            this.labelRuta.TabIndex = 20;
            // 
            // buttonInicio
            // 
            this.buttonInicio.Location = new System.Drawing.Point(12, 12);
            this.buttonInicio.Name = "buttonInicio";
            this.buttonInicio.Size = new System.Drawing.Size(75, 23);
            this.buttonInicio.TabIndex = 18;
            this.buttonInicio.Text = "Inicio";
            this.buttonInicio.UseVisualStyleBackColor = true;
            this.buttonInicio.Click += new System.EventHandler(this.buttonInicio_Click);
            // 
            // buttonAtras
            // 
            this.buttonAtras.Location = new System.Drawing.Point(93, 12);
            this.buttonAtras.Name = "buttonAtras";
            this.buttonAtras.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonAtras.Size = new System.Drawing.Size(25, 23);
            this.buttonAtras.TabIndex = 17;
            this.buttonAtras.Text = "◀";
            this.buttonAtras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAtras.UseVisualStyleBackColor = true;
            this.buttonAtras.Click += new System.EventHandler(this.buttonAtras_Click);
            // 
            // treeViewElementos
            // 
            this.treeViewElementos.Location = new System.Drawing.Point(12, 61);
            this.treeViewElementos.Name = "treeViewElementos";
            this.treeViewElementos.Size = new System.Drawing.Size(494, 438);
            this.treeViewElementos.TabIndex = 16;
            this.treeViewElementos.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewElementos_NodeMouseClick);
            this.treeViewElementos.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewElementos_NodeMouseDoubleClick);
            this.treeViewElementos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewElementos_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirElementoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 26);
            // 
            // añadirElementoToolStripMenuItem
            // 
            this.añadirElementoToolStripMenuItem.Name = "añadirElementoToolStripMenuItem";
            this.añadirElementoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.añadirElementoToolStripMenuItem.Text = "Añadir Elemento";
            this.añadirElementoToolStripMenuItem.Click += new System.EventHandler(this.añadirElementoToolStripMenuItem_Click);
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Location = new System.Drawing.Point(196, 12);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(75, 23);
            this.buttonEnviar.TabIndex = 21;
            this.buttonEnviar.Text = "Enviar";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Visible = false;
            this.buttonEnviar.Click += new System.EventHandler(this.buttonEnviar_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addElementoPrintoolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(163, 26);
            // 
            // addElementoPrintoolStripMenuItem
            // 
            this.addElementoPrintoolStripMenuItem.Name = "addElementoPrintoolStripMenuItem";
            this.addElementoPrintoolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addElementoPrintoolStripMenuItem.Text = "Añadir Elemento";
            this.addElementoPrintoolStripMenuItem.Click += new System.EventHandler(this.addElementoPrintoolStripMenuItem_Click);
            // 
            // buttonBorrar
            // 
            this.buttonBorrar.Location = new System.Drawing.Point(431, 12);
            this.buttonBorrar.Name = "buttonBorrar";
            this.buttonBorrar.Size = new System.Drawing.Size(75, 23);
            this.buttonBorrar.TabIndex = 22;
            this.buttonBorrar.Text = "Borrar";
            this.buttonBorrar.UseVisualStyleBackColor = true;
            this.buttonBorrar.Visible = false;
            this.buttonBorrar.Click += new System.EventHandler(this.buttonBorrar_Click);
            // 
            // FormElementos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 518);
            this.Controls.Add(this.buttonBorrar);
            this.Controls.Add(this.buttonEnviar);
            this.Controls.Add(this.labelRuta);
            this.Controls.Add(this.buttonInicio);
            this.Controls.Add(this.buttonAtras);
            this.Controls.Add(this.treeViewElementos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormElementos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elementos";
            this.Load += new System.EventHandler(this.FormElementos_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRuta;
        private System.Windows.Forms.Button buttonInicio;
        private System.Windows.Forms.Button buttonAtras;
        private System.Windows.Forms.TreeView treeViewElementos;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem añadirElementoToolStripMenuItem;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem addElementoPrintoolStripMenuItem;
        private System.Windows.Forms.Button buttonBorrar;
    }
}