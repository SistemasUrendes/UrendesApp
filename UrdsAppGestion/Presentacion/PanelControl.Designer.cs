namespace UrdsAppGestión.Presentacion
{
    partial class PanelControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelControl));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridView_tareas = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tareas)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(945, 126);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // dataGridView_tareas
            // 
            this.dataGridView_tareas.AllowUserToAddRows = false;
            this.dataGridView_tareas.AllowUserToDeleteRows = false;
            this.dataGridView_tareas.AllowUserToResizeRows = false;
            this.dataGridView_tareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tareas.Location = new System.Drawing.Point(864, 12);
            this.dataGridView_tareas.Name = "dataGridView_tareas";
            this.dataGridView_tareas.RowHeadersVisible = false;
            this.dataGridView_tareas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_tareas.Size = new System.Drawing.Size(279, 102);
            this.dataGridView_tareas.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(574, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Prueba";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // PanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1155, 635);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_tareas);
            this.Controls.Add(this.monthCalendar1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PanelControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User: " + Persistencia.conexion_bd.User + "; Database: " + Persistencia.conexion_bd.Database + "; IP: " + Persistencia.conexion_bd.Ip_servidor + ":" + Persistencia.conexion_bd.Port;
            this.Load += new System.EventHandler(this.PanelControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tareas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.DataGridView dataGridView_tareas;
        private System.Windows.Forms.Button button1;
    }
}