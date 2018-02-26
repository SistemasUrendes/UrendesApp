namespace UrdsAppGestión.Presentacion.ComunidadesForms.RemesasForms
{
    partial class FormAnyadirRecibos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnyadirRecibos));
            this.dataGridView_recibos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_buscar_entidad = new System.Windows.Forms.TextBox();
            this.comboBox_cuota = new System.Windows.Forms.ComboBox();
            this.textBox_total_recibos = new System.Windows.Forms.TextBox();
            this.button_lanzar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_formaPago = new System.Windows.Forms.ComboBox();
            this.button_filtro = new System.Windows.Forms.Button();
            this.checkBox_cuenta = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_recibos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_recibos
            // 
            this.dataGridView_recibos.AllowUserToAddRows = false;
            this.dataGridView_recibos.AllowUserToDeleteRows = false;
            this.dataGridView_recibos.AllowUserToResizeRows = false;
            this.dataGridView_recibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_recibos.Location = new System.Drawing.Point(12, 115);
            this.dataGridView_recibos.MultiSelect = false;
            this.dataGridView_recibos.Name = "dataGridView_recibos";
            this.dataGridView_recibos.RowHeadersVisible = false;
            this.dataGridView_recibos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_recibos.Size = new System.Drawing.Size(1234, 454);
            this.dataGridView_recibos.TabIndex = 0;
            this.dataGridView_recibos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_recibos_CellClick);
            this.dataGridView_recibos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_recibos_CellLeave);
            this.dataGridView_recibos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_recibos_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cuota : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buscar : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1086, 578);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total : ";
            // 
            // textBox_buscar_entidad
            // 
            this.textBox_buscar_entidad.Location = new System.Drawing.Point(98, 79);
            this.textBox_buscar_entidad.Name = "textBox_buscar_entidad";
            this.textBox_buscar_entidad.Size = new System.Drawing.Size(190, 20);
            this.textBox_buscar_entidad.TabIndex = 4;
            this.textBox_buscar_entidad.TextChanged += new System.EventHandler(this.textBox_buscar_entidad_TextChanged);
            // 
            // comboBox_cuota
            // 
            this.comboBox_cuota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cuota.FormattingEnabled = true;
            this.comboBox_cuota.Location = new System.Drawing.Point(98, 11);
            this.comboBox_cuota.Name = "comboBox_cuota";
            this.comboBox_cuota.Size = new System.Drawing.Size(190, 21);
            this.comboBox_cuota.TabIndex = 5;
            this.comboBox_cuota.SelectionChangeCommitted += new System.EventHandler(this.comboBox_cuota_SelectionChangeCommitted);
            // 
            // textBox_total_recibos
            // 
            this.textBox_total_recibos.Location = new System.Drawing.Point(1132, 575);
            this.textBox_total_recibos.Name = "textBox_total_recibos";
            this.textBox_total_recibos.Size = new System.Drawing.Size(114, 20);
            this.textBox_total_recibos.TabIndex = 13;
            this.textBox_total_recibos.Text = "0";
            this.textBox_total_recibos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button_lanzar
            // 
            this.button_lanzar.Location = new System.Drawing.Point(1132, 86);
            this.button_lanzar.Name = "button_lanzar";
            this.button_lanzar.Size = new System.Drawing.Size(114, 23);
            this.button_lanzar.TabIndex = 19;
            this.button_lanzar.Text = "A Remesa";
            this.button_lanzar.UseVisualStyleBackColor = true;
            this.button_lanzar.Click += new System.EventHandler(this.button_lanzar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1132, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Asignar Pantalla";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Forma Pago : ";
            // 
            // comboBox_formaPago
            // 
            this.comboBox_formaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_formaPago.FormattingEnabled = true;
            this.comboBox_formaPago.Items.AddRange(new object[] {
            "Tranferencia",
            "Domiciliado",
            "Todos"});
            this.comboBox_formaPago.Location = new System.Drawing.Point(98, 45);
            this.comboBox_formaPago.Name = "comboBox_formaPago";
            this.comboBox_formaPago.Size = new System.Drawing.Size(96, 21);
            this.comboBox_formaPago.TabIndex = 22;
            this.comboBox_formaPago.SelectionChangeCommitted += new System.EventHandler(this.comboBox_formaPago_SelectionChangeCommitted);
            // 
            // button_filtro
            // 
            this.button_filtro.Location = new System.Drawing.Point(330, 27);
            this.button_filtro.Name = "button_filtro";
            this.button_filtro.Size = new System.Drawing.Size(57, 55);
            this.button_filtro.TabIndex = 23;
            this.button_filtro.Text = "Filtrar";
            this.button_filtro.UseVisualStyleBackColor = true;
            this.button_filtro.Click += new System.EventHandler(this.button_filtro_Click);
            // 
            // checkBox_cuenta
            // 
            this.checkBox_cuenta.AutoSize = true;
            this.checkBox_cuenta.Location = new System.Drawing.Point(294, 15);
            this.checkBox_cuenta.Name = "checkBox_cuenta";
            this.checkBox_cuenta.Size = new System.Drawing.Size(15, 14);
            this.checkBox_cuenta.TabIndex = 24;
            this.checkBox_cuenta.UseVisualStyleBackColor = true;
            // 
            // FormAnyadirRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 601);
            this.Controls.Add(this.checkBox_cuenta);
            this.Controls.Add(this.button_filtro);
            this.Controls.Add(this.comboBox_formaPago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_lanzar);
            this.Controls.Add(this.textBox_total_recibos);
            this.Controls.Add(this.comboBox_cuota);
            this.Controls.Add(this.textBox_buscar_entidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_recibos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAnyadirRecibos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Añadir Recibos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AnyadirRecibos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_recibos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_recibos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_buscar_entidad;
        private System.Windows.Forms.ComboBox comboBox_cuota;
        private System.Windows.Forms.TextBox textBox_total_recibos;
        private System.Windows.Forms.Button button_lanzar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_formaPago;
        private System.Windows.Forms.Button button_filtro;
        private System.Windows.Forms.CheckBox checkBox_cuenta;
    }
}