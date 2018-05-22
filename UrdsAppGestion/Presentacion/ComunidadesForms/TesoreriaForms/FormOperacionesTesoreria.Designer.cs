namespace UrdsAppGestión.Presentacion.ComunidadesForms.TesoreriaForms
{
    partial class FormOperacionesTesoreria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOperacionesTesoreria));
            this.dataGridView_general = new System.Windows.Forms.DataGridView();
            this.textBox_total_acumulado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_confirmar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_cuenta = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_fcierre = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_buscar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_operacion_disponible = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_importe_operacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_FECHA = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_general)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_general
            // 
            this.dataGridView_general.AllowUserToAddRows = false;
            this.dataGridView_general.AllowUserToDeleteRows = false;
            this.dataGridView_general.AllowUserToOrderColumns = true;
            this.dataGridView_general.AllowUserToResizeRows = false;
            this.dataGridView_general.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_general.Location = new System.Drawing.Point(13, 115);
            this.dataGridView_general.Name = "dataGridView_general";
            this.dataGridView_general.RowHeadersVisible = false;
            this.dataGridView_general.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_general.Size = new System.Drawing.Size(1047, 467);
            this.dataGridView_general.TabIndex = 0;
            this.dataGridView_general.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_general_CellClick);
            this.dataGridView_general.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_general_CellEndEdit);
            this.dataGridView_general.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_general_CellValidated);
            this.dataGridView_general.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView_general_CellValidating);
            this.dataGridView_general.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_general_CellValueChanged);
            this.dataGridView_general.Sorted += new System.EventHandler(this.dataGridView_general_Sorted);
            // 
            // textBox_total_acumulado
            // 
            this.textBox_total_acumulado.Location = new System.Drawing.Point(959, 83);
            this.textBox_total_acumulado.Name = "textBox_total_acumulado";
            this.textBox_total_acumulado.ReadOnly = true;
            this.textBox_total_acumulado.Size = new System.Drawing.Size(100, 20);
            this.textBox_total_acumulado.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(855, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Importe Disponible : ";
            this.label1.Visible = false;
            // 
            // button_confirmar
            // 
            this.button_confirmar.Location = new System.Drawing.Point(867, 23);
            this.button_confirmar.Name = "button_confirmar";
            this.button_confirmar.Size = new System.Drawing.Size(94, 23);
            this.button_confirmar.TabIndex = 3;
            this.button_confirmar.Text = "Confirmar";
            this.button_confirmar.UseVisualStyleBackColor = true;
            this.button_confirmar.Click += new System.EventHandler(this.button_confirmar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(963, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox1.Controls.Add(this.button_confirmar);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(-4, 595);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(1077, 63);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cuenta : ";
            // 
            // label_cuenta
            // 
            this.label_cuenta.AutoSize = true;
            this.label_cuenta.Location = new System.Drawing.Point(95, 48);
            this.label_cuenta.Name = "label_cuenta";
            this.label_cuenta.Size = new System.Drawing.Size(51, 13);
            this.label_cuenta.TabIndex = 7;
            this.label_cuenta.Text = "CUENTA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha Cierre : ";
            // 
            // label_fcierre
            // 
            this.label_fcierre.AutoSize = true;
            this.label_fcierre.Location = new System.Drawing.Point(95, 74);
            this.label_fcierre.Name = "label_fcierre";
            this.label_fcierre.Size = new System.Drawing.Size(47, 13);
            this.label_fcierre.TabIndex = 9;
            this.label_fcierre.Text = "CIERRE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Buscar : ";
            // 
            // textBox_buscar
            // 
            this.textBox_buscar.Location = new System.Drawing.Point(397, 48);
            this.textBox_buscar.Name = "textBox_buscar";
            this.textBox_buscar.Size = new System.Drawing.Size(196, 20);
            this.textBox_buscar.TabIndex = 11;
            this.textBox_buscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(855, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Importe Asignado : ";
            // 
            // textBox_operacion_disponible
            // 
            this.textBox_operacion_disponible.Location = new System.Drawing.Point(959, 60);
            this.textBox_operacion_disponible.Name = "textBox_operacion_disponible";
            this.textBox_operacion_disponible.ReadOnly = true;
            this.textBox_operacion_disponible.Size = new System.Drawing.Size(100, 20);
            this.textBox_operacion_disponible.TabIndex = 12;
            this.textBox_operacion_disponible.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(855, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Importe Operación : ";
            this.label6.Visible = false;
            // 
            // textBox_importe_operacion
            // 
            this.textBox_importe_operacion.Location = new System.Drawing.Point(959, 38);
            this.textBox_importe_operacion.Name = "textBox_importe_operacion";
            this.textBox_importe_operacion.ReadOnly = true;
            this.textBox_importe_operacion.Size = new System.Drawing.Size(100, 20);
            this.textBox_importe_operacion.TabIndex = 14;
            this.textBox_importe_operacion.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(855, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Fecha :";
            this.label7.Visible = false;
            // 
            // textBox_FECHA
            // 
            this.textBox_FECHA.Location = new System.Drawing.Point(959, 15);
            this.textBox_FECHA.Name = "textBox_FECHA";
            this.textBox_FECHA.ReadOnly = true;
            this.textBox_FECHA.Size = new System.Drawing.Size(100, 20);
            this.textBox_FECHA.TabIndex = 17;
            this.textBox_FECHA.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Entidad :";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(95, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "ENTIDAD";
            this.label9.Visible = false;
            // 
            // FormOperacionesTesoreria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 653);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_FECHA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_importe_operacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_operacion_disponible);
            this.Controls.Add(this.textBox_buscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_fcierre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_cuenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_total_acumulado);
            this.Controls.Add(this.dataGridView_general);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOperacionesTesoreria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tesoreria";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormOperacionesTesoreria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_general)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_general;
        private System.Windows.Forms.TextBox textBox_total_acumulado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_confirmar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_cuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_fcierre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_buscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_operacion_disponible;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_importe_operacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_FECHA;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}