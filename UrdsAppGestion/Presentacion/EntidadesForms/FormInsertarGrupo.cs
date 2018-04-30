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
                    String sqlInsert = "INSERT INTO exp_catcontactos (Nombre,IdComunidad) VALUES ('" + nombre + "'," + idComunidad + ")";
                    idGrupo = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert).ToString();
                    String sqlUpdate;
                    String idContacto;
                    for (int i = 0; i < dataGridViewGrupo.Rows.Count; i++)
                    {
                        if (dataGridViewGrupo.Rows[i].Cells[0].Value != null)
                        {
                            idContacto = dataGridViewGrupo.Rows[i].Cells[0].Value.ToString();
                            sqlUpdate = "UPDATE exp_contactos SET IdCat = " + idGrupo + " WHERE IdDetEntTarea = " + idContacto;
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                        }
                    }
                    MessageBox.Show("Grupo " + nombre + " creado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Introduce un nombre para el grupo");
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
            String sqlSelect = "SELECT exp_contactos.IdDetEntTarea, exp_contactos.Nombre, exp_contactos.Tel AS Teléfono, exp_contactos.Correo FROM exp_contactos";
            contactos = Persistencia.SentenciasSQL.select(sqlSelect);
            dataGridViewContactos.DataSource = contactos;
            ajustarDatagridContactos();

        }

        public void ajustarDatagridContactos()
        {
            //FORMATEO EL TELEFONO CON ESPACIOS PARA QUE SE PUEDA VER MEJOR
            for (int a = 0; a < dataGridViewContactos.RowCount; a++)
            {
                try
                {
                    String telefono = dataGridViewContactos.Rows[a].Cells[2].Value.ToString().Replace(" ", "");
                    dataGridViewContactos.Rows[a].Cells[2].Value = String.Format("{0:###-###-###}", double.Parse(telefono));
                }
                catch
                {
                    continue;
                }
            }

            if (dataGridViewContactos.Rows.Count > 0)
            {
                dataGridViewContactos.Columns[0].Visible = false;
                dataGridViewContactos.Columns["Nombre"].Width = 150;
                //dataGridViewContactos.Columns["Teléfono"].Width = 70;
                dataGridViewContactos.Columns["Teléfono"].Visible = false;
                dataGridViewContactos.Columns["Correo"].Width = 150;
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
        
    }
}
