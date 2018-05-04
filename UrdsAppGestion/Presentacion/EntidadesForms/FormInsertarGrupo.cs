using System;
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
    public partial class FormInsertarGrupo : Form
    {
        DataTable contactos;
        DataTable grupoContactos;
        DataTable oldGrupoContactos;
        String idGrupo;

        public FormInsertarGrupo()
        {
            InitializeComponent();

        }

        private void FormInsertarGrupo_Load(object sender, EventArgs e)
        {
            rellenarCombobox();
            cargarDatagrid();

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (dataGridViewGrupo.Rows.Count > 0)
            {
                if (textBoxNombre.Text != "")
                {
                    String nombre = textBoxNombre.Text;
                    String idComunidad = comboBoxComunidad.SelectedValue.ToString();
                    String sqlInsert = "INSERT INTO exp_categoriaContactos (Nombre,IdComunidad) VALUES ('" + nombre + "'," + idComunidad + ")";
                    idGrupo = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
                    String sqlInsertContacto;
                    String idContacto;
                    String tipo;
                    for (int i = 0; i < dataGridViewGrupo.Rows.Count; i++)
                    {
                        if (dataGridViewGrupo.Rows[i].Cells[0].Value != null)
                        {
                            idContacto = dataGridViewGrupo.Rows[i].Cells[0].Value.ToString();
                            tipo = dataGridViewGrupo.Rows[i].Cells[3].Value.ToString();
                            sqlInsertContacto = "INSERT INTO exp_catcontactos (IdCategoria,IdContacto,TipoContacto) VALUES ('" + idGrupo + "','" + idContacto + "','" + tipo + "')";
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertContacto);
                        }
                    }
                    MessageBox.Show("Grupo " + nombre + " creado correctamente");
                }
                else
                {
                    idGrupo = comboBoxGrupos.SelectedValue.ToString();
                    String idComunidad = comboBoxComunidad.SelectedValue.ToString();
                    
                    String sqlInsertContacto;
                    String idContacto;
                    String tipo;
                    foreach(DataRow row in oldGrupoContactos.Rows)
                    {
                        String sqlBorrar = "DELETE FROM exp_catcontactos WHERE IdContacto = " + row[0].ToString() + " AND IdCategoria = " + idGrupo;
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);
                    }
                    for (int i = 0; i < dataGridViewGrupo.Rows.Count; i++)
                    {
                        if (dataGridViewGrupo.Rows[i].Cells[0].Value != null)
                        {
                            idContacto = dataGridViewGrupo.Rows[i].Cells[0].Value.ToString();
                            tipo = dataGridViewGrupo.Rows[i].Cells[3].Value.ToString();
                            sqlInsertContacto = "INSERT INTO exp_catcontactos (IdCategoria,IdContacto,TipoContacto) VALUES ('" + idGrupo + "','" + idContacto + "','" + tipo + "')";
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertContacto);
                        }
                    }

                    MessageBox.Show("Grupo actualizado correctamente");
                }
            }
            else
            {
                MessageBox.Show("El grupo debe tener mínimo un Contacto");
            }

        }

        private void rellenarCombobox()
        {
            String sqlComboCom = "SELECT ctos_entidades.NombreCorto, com_comunidades.IdComunidad, com_comunidades.FBaja FROM com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad WHERE(((com_comunidades.FBaja)Is Null))";
            comboBoxComunidad.DataSource = Persistencia.SentenciasSQL.select(sqlComboCom);
            comboBoxComunidad.DisplayMember = "NombreCorto";
            comboBoxComunidad.ValueMember = "IdComunidad";
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (dataGridViewContactos.SelectedCells.Count > 0)
            {
                addContactoGrupo();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewGrupo.SelectedCells.Count > 0)
            {
                removeContactoGrupo();
            }
        }

        public void cargarDatagrid()
        {
            String sqlSelect = "SELECT exp_contactos.IdDetEntTarea, exp_contactos.Nombre, exp_contactos.Correo,'T' AS T  FROM exp_contactos";
            contactos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewContactos.DataSource = contactos;
            ajustarDatagridContactos();
        }

        public void ajustarDatagridContactos()
        {
            if (dataGridViewContactos.Rows.Count > 0)
            {
                dataGridViewContactos.Columns[0].Visible = false;
                dataGridViewContactos.Columns["Nombre"].Width = 200;
                dataGridViewContactos.Columns["Correo"].Width = 100;
                dataGridViewContactos.Columns["T"].Width = 20;
            }
        }

        private void dataGridViewContactos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewContactos.SelectedCells.Count > 0)
            {
                addContactoGrupo();
            }
        }

        private void dataGridViewGrupo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewGrupo.SelectedCells.Count > 0)
            {
                removeContactoGrupo();
            }
        }

        private void addContactoGrupo()
        {
            dataGridViewGrupo.AllowUserToAddRows = true;
            //SI EL DATAGRID ESTÁ VACÍO CREA LAS COLUMNAS ANTES DE AÑADIR
            if (dataGridViewGrupo.Columns.Count == 0)
            {
                foreach (DataGridViewColumn col in dataGridViewContactos.Columns)
                {
                    dataGridViewGrupo.Columns.Add(col.Clone() as DataGridViewColumn);
                }
            }
            if (!yaExisteEnGrupo())
            {
                if (grupoContactos == null)
                {
                    //CLONA LA LÍNEA SELECCIONADA PARA AÑADIR EN EL GRUPO
                    DataGridViewRow row = new DataGridViewRow();
                    row = (DataGridViewRow)dataGridViewContactos.SelectedRows[0].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dataGridViewContactos.SelectedRows[0].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dataGridViewGrupo.Rows.Add(row);
                    dataGridViewGrupo.Refresh();
                }
                else
                {
                    DataTable table = dataGridViewContactos.DataSource as DataTable;
                    DataRow row = table.NewRow();
                    row = ((DataRowView)dataGridViewContactos.SelectedRows[0].DataBoundItem).Row;
                    DataRow newRow = grupoContactos.NewRow();
                    newRow.ItemArray= row.ItemArray.Clone() as object[];  
                    grupoContactos.Rows.Add(newRow);
                    dataGridViewGrupo.Refresh();
                    
                }
            }
            dataGridViewGrupo.AllowUserToAddRows = false;
        }

        private void removeContactoGrupo()
        {
            dataGridViewGrupo.Rows.RemoveAt(dataGridViewGrupo.SelectedRows[0].Index);
        }

        //COMPRUEBA SI YA ESTÁ AÑADIDO EL CONTACTO EN EL GRUPO (true = ya existe // false = no existe)
        private Boolean yaExisteEnGrupo()
        {
            for (int i = 0; i < dataGridViewGrupo.Rows.Count; i++)
            {
                if (dataGridViewGrupo.Rows[i].Cells[0].Value != null)
                {
                    if (dataGridViewGrupo.Rows[i].Cells[0].Value.ToString() == dataGridViewContactos.SelectedRows[0].Cells[0].Value.ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void comboBoxComunidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String sqlComboGrupo = "SELECT exp_categoriaContactos.Nombre, exp_categoriaContactos.IdGrupo FROM exp_categoriaContactos WHERE (exp_categoriaContactos.IdComunidad) = " + comboBoxComunidad.SelectedValue ;
            comboBoxGrupos.DataSource = Persistencia.SentenciasSQL.select(sqlComboGrupo);
            comboBoxGrupos.DisplayMember = "Nombre";
            comboBoxGrupos.ValueMember = "IdGrupo";
        }
        

        private void textBoxfiltroTodas_TextChanged(object sender, EventArgs e)
        {
            DataTable busqueda = contactos;
            busqueda.DefaultView.RowFilter = "Nombre like '%" + textBoxfiltroTodas.Text + "%' OR Correo like '%" + textBoxfiltroTodas.Text + "%'";
            dataGridViewContactos.DataSource = busqueda;
        }

        private void comboBoxGrupos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            grupoContactos = null;
            String sqlContactos = "SELECT exp_contactos.IdDetEntTarea,exp_contactos.Nombre,ctos_detemail.Email AS Correo,'T' AS T FROM((exp_categoriaContactos INNER JOIN exp_catcontactos ON exp_categoriaContactos.IdGrupo = exp_catcontactos.IdCategoria) INNER JOIN exp_contactos ON exp_catcontactos.IdContacto = exp_contactos.IdDetEntTarea) INNER JOIN ctos_detemail ON exp_contactos.IdEntidad = ctos_detemail.IdEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((exp_categoriaContactos.IdGrupo) = " + comboBoxGrupos.SelectedValue + ") AND ((exp_catcontactos.TipoContacto) = 'T'))";
            grupoContactos = Persistencia.SentenciasSQL.select(sqlContactos);

            String sqlProveedores = "SELECT com_proveedores.IdProveedor,ctos_entidades.Entidad AS Nombre, ctos_detemail.Email AS Correo, 'P' AS T FROM(((exp_categoriaContactos INNER JOIN exp_catcontactos ON exp_categoriaContactos.IdGrupo = exp_catcontactos.IdCategoria) INNER JOIN com_proveedores ON exp_catcontactos.IdContacto = com_proveedores.IdProveedor) INNER JOIN ctos_entidades ON com_proveedores.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_detemail ON ctos_entidades.IDEntidad = ctos_detemail.IdEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((exp_categoriaContactos.IdGrupo) = " + comboBoxGrupos.SelectedValue + ") AND ((exp_catcontactos.TipoContacto) = 'P'))";
            grupoContactos.Merge(Persistencia.SentenciasSQL.select(sqlProveedores));

            String sqlCargos = "SELECT com_cargos.IdCargo,com_cargos.Cargo AS Nombre, ctos_detemail.Email AS Correo, 'O' AS T FROM ctos_detemail INNER JOIN ((((exp_categoriaContactos INNER JOIN exp_catcontactos ON exp_categoriaContactos.IdGrupo = exp_catcontactos.IdCategoria) INNER JOIN com_cargos ON exp_catcontactos.IdContacto = com_cargos.IdCargo) INNER JOIN com_cargoscom ON com_cargos.IdCargo = com_cargoscom.IdCargo) INNER JOIN com_comuneros ON com_cargoscom.IdComunero = com_comuneros.IdComunero) ON ctos_detemail.IdEntidad = com_comuneros.IdEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((exp_categoriaContactos.IdGrupo) = " + comboBoxGrupos.SelectedValue + ") AND ((com_cargos.Baja) = 0) AND((exp_catcontactos.TipoContacto) = 'O'))";

            grupoContactos.Merge(Persistencia.SentenciasSQL.select(sqlCargos));

            String sqlComuneros = "SELECT com_comuneros.IdComunero,ctos_entidades.Entidad AS Nombre, ctos_detemail.Email AS Correo, 'C' AS T FROM((exp_categoriaContactos INNER JOIN exp_catcontactos ON exp_categoriaContactos.IdGrupo = exp_catcontactos.IdCategoria) INNER JOIN (ctos_detemail INNER JOIN com_comuneros ON ctos_detemail.IdEntidad = com_comuneros.IdEntidad) ON exp_catcontactos.IdContacto = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((exp_categoriaContactos.IdGrupo) = " + comboBoxGrupos.SelectedValue + ") AND((exp_catcontactos.TipoContacto) = 'C'))";
            grupoContactos.Merge(Persistencia.SentenciasSQL.select(sqlComuneros));

            oldGrupoContactos = grupoContactos.Copy();
            dataGridViewGrupo.DataSource = grupoContactos;

            if (dataGridViewGrupo.Rows.Count > 0)
            {
                dataGridViewGrupo.Columns[0].Visible = false;
                dataGridViewGrupo.Columns["Nombre"].Width = 130;
                dataGridViewGrupo.Columns["Correo"].Width = 120;
                dataGridViewGrupo.Columns["T"].Width = 50;
            }
        }

        private void buttonNuevoGrupo_Click(object sender, EventArgs e)
        {
            labelGrupo.Visible = true;
            textBoxNombre.Visible = true;
            dataGridViewGrupo.DataSource = null;
            oldGrupoContactos = null;
            grupoContactos = null;
            buttonNuevoGrupo.Visible = false;

        }

        private void buttonOrgGobierno_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_cargos.IdCargo, com_cargos.Cargo AS Nombre, ctos_detemail.Email AS Correo, 'O' AS T FROM((com_cargos INNER JOIN com_cargoscom ON com_cargos.IdCargo = com_cargoscom.IdCargo) INNER JOIN com_comuneros ON com_cargoscom.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_detemail ON com_comuneros.IdEmail = ctos_detemail.IdEmail WHERE(((com_cargos.Baja) = 0) AND((com_cargos.IdComunidad) = " + comboBoxComunidad.SelectedValue + "))";
            contactos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewContactos.DataSource = contactos;
            ajustarDatagridContactos();
        }
        


        private void buttonComuneros_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_comuneros.IdComunero, ctos_entidades.Entidad AS Nombre, ctos_detemail.Email AS Correo,'C' AS T FROM(com_comuneros INNER JOIN ctos_detemail ON com_comuneros.IdEmail = ctos_detemail.IdEmail) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad WHERE(((ctos_detemail.Ppal) = -1) AND((com_comuneros.IdComunidad) = " + comboBoxComunidad.SelectedValue +"))";
            contactos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewContactos.DataSource = contactos;
            ajustarDatagridContactos();
        }

        private void buttonProveedores_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT com_proveedores.IdProveedor, ctos_entidades.Entidad AS Nombre, ctos_detemail.Email AS Correo, 'P' AS T FROM ctos_detemail INNER JOIN(com_proveedores INNER JOIN ctos_entidades ON com_proveedores.IdEntidad = ctos_entidades.IDEntidad) ON ctos_detemail.IdEntidad = com_proveedores.IdEntidad WHERE(((com_proveedores.FBaja)Is Null) AND((ctos_detemail.Ppal) = -1) AND((com_proveedores.IdComunidad) = " + comboBoxComunidad.SelectedValue + "))";
            contactos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewContactos.DataSource = contactos;
            ajustarDatagridContactos();
        }

        private void buttonContactos_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT exp_contactos.IdDetEntTarea, exp_contactos.Nombre, exp_contactos.Correo,'T' AS T FROM exp_contactos";
            contactos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewContactos.DataSource = contactos;
            ajustarDatagridContactos();
        }
        
    }
}
