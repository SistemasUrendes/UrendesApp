﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion.EntidadesForms
{
    public partial class VerEntidad : Form
    {
        public int id_entidad_cargado = 0;
        String ruta = "";
        DataTable categorias;
        Boolean editado = false;

        public VerEntidad(int id_entidad_cargado)
        {
            this.id_entidad_cargado = id_entidad_cargado;
            InitializeComponent();
        }
        public VerEntidad()
        {
            InitializeComponent();
        }

        private void AddEntidad_Load(object sender, EventArgs e)
        {
            if (id_entidad_cargado != 0)
            {
                //Cargo entidades
                cargoCabecera();
                //Cargo Telefonos
                cargaTelefonos();
                //Cargo correos
                cargaCorreos();
                //Cargo direcciones
                cargoDirecciones();
                //Cargo bancos
                cargoBanco();
                //Cargo categoria
                //cargoCategorias();
                //Cargo Contactos
                cargoContactos();
                cargarCategorias();
                cargarCategoriasEntidad();
            }
            else
            {
                //Preparo DATAGRIDVIEW
                dataGridView_telefonos.ColumnCount = 3;
                dataGridView_telefonos.ColumnHeadersVisible = true;
                DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
                columnHeaderStyle.BackColor = Color.Beige;
                columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
                dataGridView_telefonos.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
                dataGridView_telefonos.Columns[0].Name = "Referencia";
                dataGridView_telefonos.Columns[1].Name = "Email";
                dataGridView_telefonos.Columns[2].Name = "Principal";
            }

            this.Text = this.Text + " [ Id : " + id_entidad_cargado + "]";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FormTelefono nueva = new FormTelefono(this, id_entidad_cargado);
            nueva.Show();
            editado = true;
        }
        private void button_editar_cabecera_Click(object sender, EventArgs e)
        {
            AddEntidad editar = new AddEntidad(id_entidad_cargado);
            editado = true;
            this.Close();
            editar.Show();
        }
        public void cargaTelefonos()
        {
            String sqlTelefonos = "SELECT IdDetTelf,IdEntidad,Descripcion,Telefono,Ppal, Orden FROM ctos_dettelf WHERE ctos_dettelf.IdEntidad = '" + id_entidad_cargado + "' ORDER BY Orden";
            DataTable telefonos = Persistencia.SentenciasSQL.select(sqlTelefonos);
            dataGridView_telefonos.DataSource = telefonos;

            dataGridView_telefonos.Columns[0].Visible = false;
            dataGridView_telefonos.Columns[1].Visible = false;
            dataGridView_telefonos.Columns[2].Width = 265;
            dataGridView_telefonos.Columns[3].Width = 172;
            dataGridView_telefonos.Columns[4].Visible = false;
            dataGridView_telefonos.Columns[5].Width = 65;

            //FORMATEO EL TELEFONO CON ESPACIOS PARA QUE SE PUEDA VER MEJOR
            for (int a = 0; a < dataGridView_telefonos.RowCount;a++) {
                try
                {
                    String telefono = dataGridView_telefonos.Rows[a].Cells[3].Value.ToString().Replace(" ", "");
                    dataGridView_telefonos.Rows[a].Cells[3].Value = String.Format("{0:###-###-###}", double.Parse(telefono));
                }catch (Exception) {
                    MessageBox.Show("Hay un teléfono incorrecto. ¡Revisar!");
                    continue;
                }
            }

        }
        public void cargoCabecera()
        {
            String sqlCabecera = "SELECT Entidad,NombreCorto,CIF,Notas,FechaRevision,UserRevision,Ruta FROM ctos_entidades WHERE IDEntidad = " + id_entidad_cargado;
            DataTable entidad = Persistencia.SentenciasSQL.select(sqlCabecera);
            if (entidad.Rows.Count > 0)
            {
                label_entidad.Text = entidad.Rows[0]["Entidad"].ToString();
                label_nombrecorto.Text = entidad.Rows[0]["NombreCorto"].ToString();
                label_cif.Text = entidad.Rows[0]["CIF"].ToString();
                label_revision.Text = entidad.Rows[0]["FechaRevision"].ToString() + " - " + entidad.Rows[0]["UserRevision"].ToString();
                if (entidad.Rows[0]["NOTAS"].ToString() != "NULL")
                    textBox_notas.Text = entidad.Rows[0]["NOTAS"].ToString();

                if (entidad.Rows[0]["Ruta"].ToString() != "NULL")  {
                    textBox_ruta.Text = entidad.Rows[0]["Ruta"].ToString().Trim('#');
                    ruta = entidad.Rows[0]["Ruta"].ToString().Trim('#');
                }

            }
            else
                MessageBox.Show("No existe esa entidad en la base de datos");
        }
        public void cargaCorreos()
        {
            String sqlCorreos = "SELECT * FROM ctos_detemail WHERE IdEntidad = " + id_entidad_cargado;
            DataTable correos = Persistencia.SentenciasSQL.select(sqlCorreos);
            dataGridView_correos.DataSource = correos;

            dataGridView_correos.Columns[0].Visible = false;
            dataGridView_correos.Columns[1].Visible = false;
            dataGridView_correos.Columns[2].Width = 200;
            dataGridView_correos.Columns[3].Width = 237;
            dataGridView_correos.Columns[4].Width = 65;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTelefono nueva = new FormTelefono(this, id_entidad_cargado, (int)dataGridView_telefonos.SelectedCells[0].Value);
            nueva.Show();
            editado = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView_telefonos.SelectedRows.Count > 0)
            {
                DialogResult resultado_message;
                //int id_actualizar_principal = 0;
                resultado_message = MessageBox.Show("¿Desea borrar este teléfono?", "Borrar Teléfono", MessageBoxButtons.OKCancel);
                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    /*
                    if (dataGridView_telefonos.Rows.Count > 0 && dataGridView_telefonos.SelectedCells[4].Value.ToString() == "True")
                        id_actualizar_principal = (int)dataGridView_telefonos.Rows[0].Cells[0].Value;
                    String sqlBorrarTel = "DELETE FROM ctos_dettelf WHERE IdDetTelf = " + (int)dataGridView_telefonos.SelectedCells[0].Value;

                    if (Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarTel))
                    {
                        if (id_actualizar_principal != 0)
                        {
                            String actualizarPrincipal = "UPDATE ctos_dettelf SET Ppal = -1 WHERE IdDetTelf = " + id_actualizar_principal;
                            if (Persistencia.SentenciasSQL.InsertarGenerico(actualizarPrincipal)) { }
                        }
                        MessageBox.Show("Borrado");

                    }
                    */
                    //ÚLTIMO TELÉFONO
                    if (dataGridView_telefonos.SelectedRows[0].Cells[5].Value.ToString() == dataGridView_telefonos.Rows.Count.ToString())
                    {
                        String sqlBorrarTel = "DELETE FROM ctos_dettelf WHERE IdDetTelf = " + dataGridView_telefonos.SelectedRows[0].Cells[0].Value;
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarTel);
                    }
                    //TELÉFONO 1 ( PRINCIPAL)
                    else if (dataGridView_telefonos.SelectedRows[0].Cells[5].Value.ToString() == "1")
                    {
                        String sqlBorrarTel = "DELETE FROM ctos_dettelf WHERE IdDetTelf = " + dataGridView_telefonos.SelectedRows[0].Cells[0].Value;
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarTel);

                        String sqlSelect = "SELECT ctos_dettelf.IdDetTelf, ctos_dettelf.Orden FROM ctos_dettelf WHERE(((ctos_dettelf.Orden) > 1) AND((ctos_dettelf.IdEntidad) = " + id_entidad_cargado + "))";
                        DataTable tlfs = Persistencia.SentenciasSQL.select(sqlSelect);
                        int i = 2;
                        foreach(DataRow row in tlfs.Rows)
                        {
                            String sqlUpdate = "";
                            if (row[1].ToString() == "2")
                            {
                                sqlUpdate = "UPDATE ctos_dettelf SET Ppal = -1, Orden = 1 WHERE IdDetTelf = " + row[0];
                            }
                            else
                            {
                                sqlUpdate = "UPDATE ctos_dettelf SET Orden = " + i + " WHERE IdDetTelf = " + row[0];
                                i++;
                            }
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                        }
                    }
                    //RESTO TELÉFONOS
                    else
                    {
                        String ordenBorrado = dataGridView_telefonos.SelectedRows[0].Cells[5].Value.ToString();
                        String sqlBorrarTel = "DELETE FROM ctos_dettelf WHERE IdDetTelf = " + dataGridView_telefonos.SelectedRows[0].Cells[0].Value;
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarTel);

                        String sqlSelect = "SELECT ctos_dettelf.IdDetTelf, ctos_dettelf.Orden FROM ctos_dettelf WHERE(((ctos_dettelf.Orden) > " + ordenBorrado + ") AND((ctos_dettelf.IdEntidad) = " + id_entidad_cargado + "))";
                        DataTable tlfs = Persistencia.SentenciasSQL.select(sqlSelect);
                        foreach (DataRow row in tlfs.Rows)
                        {
                            String sqlUpdate = "UPDATE ctos_dettelf SET Orden = " + ordenBorrado + " WHERE IdDetTelf = " + row[0];
                            ordenBorrado = (Int32.Parse(ordenBorrado)+1).ToString();
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                        }
                    }

                    cargaTelefonos();
                    editado = true;
                }
            }
            else
            {
                MessageBox.Show("No hay telefono para borrar");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormCorreos nueva = new FormCorreos(this, id_entidad_cargado);
            nueva.Show();
            editado = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FormCorreos nueva = new FormCorreos(this, id_entidad_cargado, (int)dataGridView_correos.SelectedCells[0].Value);
            nueva.Show();
            editado = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            int id_actualizar_principal = 0;
            resultado_message = MessageBox.Show("¿Desea borrar este correo?", "Borrar Correo", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                if (dataGridView_correos.Rows.Count > 0 && dataGridView_correos.SelectedCells[4].Value.ToString() == "True")
                    id_actualizar_principal = (int)dataGridView_correos.Rows[0].Cells[0].Value;
                String sqlBorrarCorreo = "DELETE FROM ctos_detemail WHERE IdEmail = " + (int)dataGridView_correos.SelectedCells[0].Value;
                //MessageBox.Show(sqlBorrarCorreo);
                if (Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarCorreo))
                {
                    if (id_actualizar_principal != 0)
                    {
                        String actualizarPrincipal = "UPDATE ctos_detemail SET Ppal = -1 WHERE IdEmail = " + id_actualizar_principal;
                        if (Persistencia.SentenciasSQL.InsertarGenerico(actualizarPrincipal)) { }
                    }
                    MessageBox.Show("Borrado");
                    cargaCorreos();
                }
                editado = true;
            }
        }
        public void cargoBanco()
        {
            DataTable bancos = Persistencia.SentenciasSQL.select("SELECT * FROM ctos_detbancos WHERE IdEntidad = " + id_entidad_cargado);
            dataGridView_bancos.DataSource = bancos;
            dataGridView_bancos.Columns[0].Visible = false;
            dataGridView_bancos.Columns[1].Visible = false;
            dataGridView_bancos.Columns[4].Visible = false;

            dataGridView_bancos.Columns[2].Width = 200;
            dataGridView_bancos.Columns[3].Width = 253;
            dataGridView_bancos.Columns[5].Width = 40;

        }
        /*
        public void cargoCategorias()
        {
            int positionx = 50;
            String sql = "SELECT Descripcion, IdEntidad, ctos_detallecat.IdDetalleCat FROM ctos_detallecat INNER JOIN ctos_catentidades ON ctos_detallecat.IdCategoria = ctos_catentidades.IdCategoria WHERE ctos_detallecat.IdEntidad = " + id_entidad_cargado;
            DataTable nueva = Persistencia.SentenciasSQL.select(sql);

            if (nueva.Rows.Count > 0)
            {
                label17.Visible = false;
                button_agregar_categoria.Location = new Point(370, 141);
                tableLayoutPanel1.Visible = true;
            }
            else
            {
                label17.Visible = true;
                button_agregar_categoria.Location = new Point(240, 82);
                tableLayoutPanel1.Visible = false;
            }
            for (int a = 0; a < nueva.Rows.Count; a++)
            {
                labeldescripcion = new System.Windows.Forms.Label();
                labeldescripcion.AutoSize = true;
                labeldescripcion.Anchor = System.Windows.Forms.AnchorStyles.Left;
                labeldescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //labeldescripcion.Location = new System.Drawing.Point((this.Width / 2) - 112, positionx);
                labeldescripcion.Size = new System.Drawing.Size(112, 18);
                labeldescripcion.Text = nueva.Rows[a][0].ToString();
                this.tabPage3.Controls.Add(labeldescripcion);
                this.tableLayoutPanel1.Controls.Add(labeldescripcion);

                boton_borrar = new System.Windows.Forms.Button();
                boton_borrar.AutoSize = true;
                boton_borrar.Anchor = System.Windows.Forms.AnchorStyles.None;
                boton_borrar.Location = new System.Drawing.Point((this.Width / 2) + 10, positionx);
                boton_borrar.Size = new System.Drawing.Size(20, 18);
                boton_borrar.Text = "X";
                boton_borrar.Name = nueva.Rows[a][2].ToString();
                boton_borrar.Click += new System.EventHandler(this.button_eliminar_categoria_Click);
                this.tableLayoutPanel1.Controls.Add(boton_borrar);
                positionx = positionx + 30;
            }
        }
        */
        public void cargoDirecciones()
        {
            DataTable direcciones = Persistencia.SentenciasSQL.select("SELECT * FROM ctos_detdirecent WHERE IdEntidad = " + id_entidad_cargado);
            dataGridView_direcciones.DataSource = direcciones;
            dataGridView_direcciones.Columns[0].Visible = false;
            dataGridView_direcciones.Columns[1].Visible = false;
            dataGridView_direcciones.Columns[4].Visible = false;
            dataGridView_direcciones.Columns[6].Visible = false;
            dataGridView_direcciones.Columns[8].Visible = false;
            dataGridView_direcciones.Columns[9].Visible = false;
            dataGridView_direcciones.Columns[10].Visible = false;
            dataGridView_direcciones.Columns[11].Visible = false;
            dataGridView_direcciones.Columns[12].Visible = false;
            dataGridView_direcciones.Columns[13].Visible = false;

            dataGridView_direcciones.Columns[2].Width = 150;
            dataGridView_direcciones.Columns[3].Width = 40;
            dataGridView_direcciones.Columns[5].Width = 252;
            dataGridView_direcciones.Columns[7].Width = 100;

            //dataGridView1.Columns[0].Width = 50;
        }
        /*
        private void button_eliminar_categoria_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            String sql = "DELETE FROM ctos_detallecat WHERE IdDetalleCat = " + boton.Name;
            Persistencia.SentenciasSQL.InsertarGenerico(sql);
            this.tableLayoutPanel1.Controls.Clear();
            cargoCategorias();

        }
        */
        private void button8_Click(object sender, EventArgs e)
        {
            FormCategoria nueva = new FormCategoria(this, id_entidad_cargado);
            nueva.Show();
        }

        private void button_editar_dir1_Click(object sender, EventArgs e)
        {
            FormDirecciones nueva = new FormDirecciones(this, dataGridView_direcciones.SelectedCells[0].Value.ToString(), id_entidad_cargado);
            nueva.Show();
            editado = true;
        }

        private void button_anyadir_Click(object sender, EventArgs e)
        {
            FormDirecciones nueva = new FormDirecciones(this, id_entidad_cargado);
            nueva.Show();
            editado = true;
        }

        private void button_borrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta dirección?", "Borrar Dirección", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM ctos_detdirecent WHERE IdDireccion = " + dataGridView_direcciones.SelectedCells[0].Value.ToString();
                comprueboPrincipalDireccion(dataGridView_direcciones.SelectedCells[0].Value.ToString());
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargoDirecciones();
                editado = true;
            }
        }
        private void comprueboPrincipalDireccion(String id_direccion)
        {
            String sql2 = "SELECT Ppal,IdDireccion FROM ctos_detdirecent WHERE IdEntidad = " + id_entidad_cargado;
            DataTable res = Persistencia.SentenciasSQL.select(sql2);
            if (res.Rows.Count > 0)
            {
                for (int a = 0; a < res.Rows.Count; a++)
                {
                    // MessageBox.Show(res.Rows[a][1].ToString() + "->" + id_direccion);
                    if (res.Rows[a][1].ToString() != id_direccion)
                    {
                        String sql = "UPDATE ctos_detdirecent SET Ppal = -1 WHERE IdDireccion = " + res.Rows[a][1].ToString();
                        Persistencia.SentenciasSQL.InsertarGenerico(sql);
                        break;

                    }
                }
            }
        }
        private void comprueboPrincipalCuenta(String id_direccion)
        {
            String sql2 = "SELECT Ppal,IdCuenta FROM ctos_detbancos WHERE IdEntidad = " + id_entidad_cargado;
            DataTable res = Persistencia.SentenciasSQL.select(sql2);
            if (res.Rows.Count > 0)
            {
                for (int a = 0; a < res.Rows.Count; a++)
                {
                    //MessageBox.Show(res.Rows[a][1].ToString() + "->" + id_direccion);
                    if (res.Rows[a][1].ToString() != id_direccion)
                    {
                        String sql = "UPDATE ctos_detbancos SET Ppal = -1 WHERE IdCuenta = " + res.Rows[a][1].ToString();
                        Persistencia.SentenciasSQL.InsertarGenerico(sql);
                        break;
                    }
                }
            }
        }

        private void button_anyadir_cuenta_Click(object sender, EventArgs e)
        {
            FormBancos nueva = new FormBancos(this,id_entidad_cargado.ToString());
            nueva.Show();
            editado = true;
        }

        private void button_editar_cuenta_Click(object sender, EventArgs e)
        {
            FormBancos nueva = new FormBancos(this, dataGridView_bancos.SelectedCells[0].Value.ToString(), id_entidad_cargado.ToString());
            nueva.Show();
            editado = true;
        }

        private void button_borrar_cuenta_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar esta cuenta?", "Borrar Dirección", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM ctos_detbancos WHERE IdCuenta = " + dataGridView_bancos.SelectedCells[0].Value.ToString();
                comprueboPrincipalCuenta(dataGridView_bancos.SelectedCells[0].Value.ToString());
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargoBanco();
                editado = true;
            }
        }
        public void cargoContactos() {
            String sql = "SELECT * FROM ctos_detcontent WHERE IdEntidad = " + id_entidad_cargado;
            DataTable contactos = Persistencia.SentenciasSQL.select(sql);
            dataGridView_contactos.DataSource = contactos;

            dataGridView_contactos.Columns[0].Visible = false;
            dataGridView_contactos.Columns[1].Visible = false;
        }

        private void button_editar_contacto_Click(object sender, EventArgs e)
        {
            FormContacto nueva = new FormContacto(this, id_entidad_cargado,this.dataGridView_contactos.SelectedCells[0].Value.ToString());
            nueva.Show();
            editado = true;
        }

        private void button_anyadir_contacto_Click(object sender, EventArgs e)
        {
            FormContacto nueva = new FormContacto(this, id_entidad_cargado);
            nueva.Show();
            editado = true;
        }

        private void button_borrar_contacto_Click(object sender, EventArgs e)
        {
            DialogResult resultado_message;
            resultado_message = MessageBox.Show("¿Desea borrar este contacto?", "Borrar Contacto", MessageBoxButtons.OKCancel);
            if (resultado_message == System.Windows.Forms.DialogResult.OK)
            {
                String sqlBorrar = "DELETE FROM ctos_detcontent WHERE IDContacto = " + dataGridView_contactos.SelectedCells[0].Value.ToString();
                comprueboPrincipalCuenta(dataGridView_contactos.SelectedCells[0].Value.ToString());
                Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                cargoContactos();
                editado = true;
            }
        }

        private void button_revisado_Click(object sender, EventArgs e)
        {
            String sql = "UPDATE ctos_entidades SET FechaRevision='" + DateTime.Today.Date.ToShortDateString() + "', UserRevision='" + Login.getnombre()+ "' WHERE IDEntidad = " + id_entidad_cargado;

            Persistencia.SentenciasSQL.InsertarGenerico(sql);
            cargoCabecera();
        }

        private void VerEntidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (editado)  {
                String sql = "UPDATE ctos_entidades SET FechaRevision='" + DateTime.Today.Date.ToShortDateString() + "', UserRevision='" + Login.getnombre() + "' WHERE IDEntidad = " + id_entidad_cargado;
                Persistencia.SentenciasSQL.InsertarGenerico(sql);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_telefonos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_telefonos.HitTest(e.X, e.Y);
                dataGridView_telefonos.ClearSelection();
                dataGridView_telefonos.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void copiarTélefonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dataGridView_telefonos.SelectedRows[0].Cells[3].Value.ToString().Replace("-",""));
        }

        private void dataGridView_correos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_correos.HitTest(e.X, e.Y);
                dataGridView_correos.ClearSelection();
                dataGridView_correos.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void copiarCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dataGridView_correos.SelectedRows[0].Cells[3].Value.ToString());
        }

        private void dataGridView_bancos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView_bancos.HitTest(e.X, e.Y);
                dataGridView_bancos.ClearSelection();
                dataGridView_bancos.Rows[hti.RowIndex].Selected = true;

                contextMenuStrip3.Show(Cursor.Position);
            }
        }

        private void copiarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dataGridView_bancos.SelectedRows[0].Cells[3].Value.ToString());
        }

        private void dataGridView_direcciones_DoubleClick(object sender, EventArgs e)
        {
            FormDirecciones nueva = new FormDirecciones(this, dataGridView_direcciones.SelectedCells[0].Value.ToString(), id_entidad_cargado,true);
            nueva.Show();
        }

        private void textBox_ruta_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@ruta);
            }
            catch
            {
                MessageBox.Show("No se encuentra la carpeta");
            }
        }

        private void cargarCategorias()
        {
            String sqlSelect = "SELECT ctos_catentidades.Descripcion as Categoría FROM ctos_catentidades";
            categorias = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewCategorias.DataSource = categorias;
            //ocultarAgregadas();
        }

        private void cargarCategoriasEntidad()
        {
            String sqlSelect = "SELECT ctos_entidades.PalabrasClave AS Categoría FROM ctos_entidades WHERE ctos_entidades.IDEntidad = " + id_entidad_cargado;
            String palabrasClave = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            DataTable catEntidad = new DataTable("Categorias");
            catEntidad.Columns.Add("Categoría", typeof(String));

            //catEntidad.Columns.Add(new DataColumn("Categorías", typeof(string)));
            int i = 0;
            while (palabrasClave.Contains(";"))
            {
                //SI EL DATAGRID ESTÁ VACÍO CREA LAS COLUMNAS ANTES DE AÑADIR
                String cat = palabrasClave.Substring(0, palabrasClave.IndexOf(";"));
                int cadena = palabrasClave.Length - palabrasClave.IndexOf(";") - 1;
                String nuevacadena = palabrasClave.Substring(palabrasClave.IndexOf(";") + 1, cadena);
                palabrasClave = nuevacadena;
                DataRow row = catEntidad.NewRow();
                row[0] = cat;
                catEntidad.Rows.InsertAt(row, i);
                i++;
            }
            if (palabrasClave.Length > 0)
            {
                DataRow row = catEntidad.NewRow();
                row[0] = palabrasClave;
                catEntidad.Rows.InsertAt(row, i);
            }
            dataGridViewCatAsig.DataSource = catEntidad;

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategorias.SelectedCells.Count > 0)
            {
                if (!yaExisteCategoria(dataGridViewCategorias.SelectedCells[0].Value.ToString()))
                {
                    addCategoriaEntidad();
                    editado = true;
                }
                else
                {
                    MessageBox.Show("¡Categoría ya agregada!");
                }
            }
        }
        
        private Boolean yaExisteCategoria(String categoria)
        {
            String sqlSelect = "SELECT ctos_entidades.PalabrasClave AS Categoría FROM ctos_entidades WHERE ctos_entidades.IDEntidad = " + id_entidad_cargado;
            String palabrasClave = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            if (palabrasClave.Contains(categoria)) return true;
            return false;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewCatAsig.SelectedCells.Count > 0)
            {
                removeCategoriaEntidad();
                editado = true;
            }
        }

        private void addCategoriaEntidad()
        {
            String sqlSelect = "SELECT ctos_entidades.PalabrasClave AS Categoría FROM ctos_entidades WHERE ctos_entidades.IDEntidad = " + id_entidad_cargado ;
            String palabrasClave = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            if(palabrasClave.Length > 0) palabrasClave += ";" + dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString();
            else palabrasClave += dataGridViewCategorias.SelectedRows[0].Cells[0].Value.ToString();
            String sqlUpdate = "UPDATE ctos_entidades SET PalabrasClave = '" + palabrasClave + "' WHERE IDEntidad = " + id_entidad_cargado;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            cargarCategoriasEntidad();
            cargarCategorias();
        }

        private void removeCategoriaEntidad()
        {
            String palabrasClaveUpdate = "";
            String clave = dataGridViewCatAsig.SelectedRows[0].Cells[0].Value.ToString();
            String sqlSelect = "SELECT ctos_entidades.PalabrasClave AS Categoría FROM ctos_entidades WHERE ctos_entidades.IDEntidad = " + id_entidad_cargado;
            String palabrasClave = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            if (palabrasClave.Length != clave.Length)
            {
                if (palabrasClave.IndexOf(clave) == 0)
                {
                    int tamaño = palabrasClave.Length - palabrasClave.IndexOf(";") - 1;
                    palabrasClaveUpdate = palabrasClave.Substring(palabrasClave.IndexOf(";")+1, tamaño);
                }
                else
                {
                    int tamaño = palabrasClave.Length - palabrasClave.IndexOf(clave) - clave.Length - 1;
                    
                    if (tamaño > 0)
                    {
                        String palabrasClavePre = palabrasClave.Substring(0, palabrasClave.IndexOf(clave));
                        palabrasClaveUpdate += palabrasClavePre;
                        String palabrasClavePost = palabrasClave.Substring(palabrasClave.IndexOf(clave) + clave.Length + 1, tamaño);
                        palabrasClaveUpdate += palabrasClavePost;
                    }
                    else
                    {
                        String palabrasClavePre = palabrasClave.Substring(0, palabrasClave.IndexOf(clave)-1);
                        palabrasClaveUpdate += palabrasClavePre;
                    }
                }
            }
            String sqlUpdate = "UPDATE ctos_entidades SET PalabrasClave = '" + palabrasClaveUpdate + "' WHERE IDEntidad = " + id_entidad_cargado;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            cargarCategoriasEntidad();
            cargarCategorias();
        }
        
        private void ocultarAgregadas()
        {
            String sqlSelect = "SELECT ctos_entidades.PalabrasClave AS Categoría FROM ctos_entidades WHERE ctos_entidades.IDEntidad = " + id_entidad_cargado;
            String palabrasClave = Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            foreach (DataGridViewRow row in dataGridViewCategorias.Rows)
            {
                if (palabrasClave.Contains(row.Cells[0].Value.ToString()))
                {
                    dataGridViewCategorias.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void textBoxFiltroCategoria_TextChanged(object sender, EventArgs e)
        {
            String filtro;
            DataTable busqueda = categorias;
            if (textBoxFiltroCategoria.TextLength == 1 || textBoxFiltroCategoria.TextLength == 0)
            {
                busqueda.DefaultView.RowFilter = string.Empty;
                this.dataGridViewCategorias.DataSource = busqueda;
            }
            else if(textBoxFiltroCategoria.TextLength > 1)
            {
                filtro = "Categoría like '%" + textBoxFiltroCategoria.Text.ToUpper().ToString() + "%'";
                busqueda.DefaultView.RowFilter = filtro;
                
            }
            this.dataGridViewCategorias.DataSource = busqueda;
        }

        private void buttonOrdenar_Click(object sender, EventArgs e)
        {
            FormOrdenarTelefonos nueva = new FormOrdenarTelefonos(this,id_entidad_cargado.ToString(), label_entidad.Text);
            nueva.Show();
        }
    }
}
