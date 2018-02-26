using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Presentacion
{
    public partial class FormMantenimiento : Form
    {
        DataTable tabla_revisar;


        public FormMantenimiento()
        {
            InitializeComponent();
        }

        private void button_fusionar_Click(object sender, EventArgs e)
        {
            fusionarEntidades();
        }
        private void fusionarEntidades() {
            int idViejo;
            int idNuevo = 0;
            String sqlSelect;
            List<String> tablas_afectadas = new List<String>();
            String todas_tablas_mostrar = "";

            if (int.TryParse(textBox_fusionar_viejo.Text,out idViejo) && int.TryParse(textBox_fusionar_nuevo.Text, out idNuevo)) {

                sqlSelect = "SELECT IdBloque FROM com_bloques WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0) {
                    tablas_afectadas.Add("com_bloques");
                }

                sqlSelect = "SELECT IdRefCert FROM com_certificados WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0) {
                    tablas_afectadas.Add("com_certificados");
                }

                sqlSelect = "SELECT IdComunero FROM com_comuneros WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_comuneros");
                }

                sqlSelect = "SELECT IdCuenta FROM com_cuentas WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_cuentas");
                }

                sqlSelect = "SELECT IdEnvSeg FROM com_EnvSe WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_EnvSe");
                }

                sqlSelect = "SELECT IdMov FROM com_movimientos WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_movimientos");
                }

                sqlSelect = "SELECT IdOpDet FROM com_opdetalles WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_opdetalles");
                }

                sqlSelect = "SELECT IdOpBloque FROM com_opdetbloques WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_opdetbloques");
                }

                sqlSelect = "SELECT IdOp FROM com_operaciones WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_operaciones");
                }

                sqlSelect = "SELECT IdProveedor FROM com_proveedores WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_proveedores");
                }

                sqlSelect = "SELECT IdRecibo FROM com_recibos WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_recibos");
                }

                sqlSelect = "SELECT IdDetalleCat FROM ctos_detallecat WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("ctos_detallecat");
                }

                sqlSelect = "SELECT IdCuenta FROM ctos_detbancos WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("ctos_detbancos");
                }

                sqlSelect = "SELECT IDContacto FROM ctos_detcontent WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("ctos_detbancos");
                }


                sqlSelect = "SELECT IdDireccion FROM ctos_detdirecent WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("ctos_detdirecent");
                }

                sqlSelect = "SELECT IdEmail FROM ctos_detemail WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("ctos_detemail");
                }

                sqlSelect = "SELECT IdDetTelf FROM ctos_dettelf WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("ctos_dettelf");
                }

                sqlSelect = "SELECT IdDocumento FROM com_Documentos WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_Documentos");
                }

                sqlSelect = "SELECT IdComunidad FROM com_comunidades WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_comunidades");
                }

                sqlSelect = "SELECT IdURD FROM ctos_urendes WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("ctos_urendes");
                }

                sqlSelect = "SELECT IdDetEntTarea FROM exp_contactos WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("exp_contactos");
                }

                sqlSelect = "SELECT `IdGestión` FROM exp_gestiones WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("exp_gestiones");
                }

                sqlSelect = "SELECT IdTarea FROM exp_tareas WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("exp_tareas");
                }


                sqlSelect = "SELECT IdProveedor FROM prov_proveedoresAut WHERE IdEntidad = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("prov_proveedoresAut");
                }

                sqlSelect = "SELECT IdLiqReparto FROM com_liqreparto WHERE IdTitular = " + idViejo;
                tabla_revisar = Persistencia.SentenciasSQL.select(sqlSelect);
                if (tabla_revisar.Rows.Count > 0)
                {
                    tablas_afectadas.Add("com_liqreparto");
                }


            }

            if (tablas_afectadas.Count > 0) {
                foreach (String var in tablas_afectadas) {
                    todas_tablas_mostrar = todas_tablas_mostrar + var + "\n";
                }

                DialogResult resultado_message;
                resultado_message = MessageBox.Show("Las siguientes tablas tienen vinculada esa Entidad: \n" + todas_tablas_mostrar + "\n¿Desea seguir con la fusión ?", "Fusionar Entidades", MessageBoxButtons.OKCancel);

                if (resultado_message == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (String var in tablas_afectadas)
                    {
                        if (var == "com_liqreparto")
                        {
                            String sqlUpdate = "UPDATE " + var + " SET IdTitular = " + idNuevo + "  WHERE IdTitular = " + idViejo;
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                        }
                        else
                        {
                            String sqlUpdate = "UPDATE " + var + " SET IdEntidad = " + idNuevo + "  WHERE IdEntidad = " + idViejo;
                            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                        }
                    }
                }
            }

            //REVISAR TELEFONO PRINCIPAL, CORREO, DIRECCIÓN Y BANCO

            //TELEFONO
            String SelectTel = "SELECT IdDetTelf FROM ctos_dettelf WHERE IdEntidad = " + idNuevo + " AND Ppal = -1";
            DataTable telefonosActivos = Persistencia.SentenciasSQL.select(SelectTel);
            if (telefonosActivos.Rows.Count > 1)  {
                for (int a = 1; a < telefonosActivos.Rows.Count; a++)
                {
                    String UpdateTelPpal = "UPDATE ctos_dettelf SET Ppal = 0 WHERE IdDetTelf = " + telefonosActivos.Rows[a][0].ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(UpdateTelPpal);
                }
            }

            //EMAIL
            String SelectEmail = "SELECT IdEmail FROM ctos_detemail WHERE IdEntidad = " + idNuevo + " AND Ppal = -1";
            DataTable emailsActivos = Persistencia.SentenciasSQL.select(SelectEmail);

            if (emailsActivos.Rows.Count > 1)  {
                for (int a = 1; a < emailsActivos.Rows.Count; a++)
                {
                    String UpdateEmailPpal = "UPDATE ctos_detemail SET Ppal = 0 WHERE IdEmail = " + emailsActivos.Rows[a][0].ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(UpdateEmailPpal);
                }
            }

            //DIRECCION
            String SelectDireccion = "SELECT IdDireccion FROM ctos_detdirecent WHERE IdEntidad = " + idNuevo + " AND Ppal = -1";
            DataTable DireccionActivos = Persistencia.SentenciasSQL.select(SelectDireccion);

            if (DireccionActivos.Rows.Count > 1)   {
                for (int a = 1; a < DireccionActivos.Rows.Count; a++)  {
                    String UpdateDireccionPpal = "UPDATE ctos_detdirecent SET Ppal = 0 WHERE IdDireccion = " + DireccionActivos.Rows[a][0].ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(UpdateDireccionPpal);
                }
            }

            //BANCO
            String Selectbanco = "SELECT IdCuenta FROM ctos_detbancos WHERE IdEntidad = " + idNuevo + " AND Ppal = -1";
            DataTable BancosActivos = Persistencia.SentenciasSQL.select(Selectbanco);

            if (BancosActivos.Rows.Count > 1)  {
                for (int a = 1; a < BancosActivos.Rows.Count; a++)  {
                    String UpdateBancoPpal = "UPDATE ctos_detbancos SET Ppal = 0 WHERE IdCuenta = " + BancosActivos.Rows[a][0].ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(UpdateBancoPpal);
                }
            }

            //BORRO LA ENTIDAD VIEJA
            String sqlBorrar = "DELETE FROM ctos_entidades WHERE IDEntidad = " + idViejo;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrar);

            MessageBox.Show("Entidad fusionada.\n\nRevisa la entidad nueva para comprobar teléfonos, emails , etc.","Fusión Realizada");

            EntidadesForms.VerEntidad nueva = new EntidadesForms.VerEntidad(idNuevo);
            nueva.Show();
        }
        private void button_borradoMultiple_Click(object sender, EventArgs e)
        {
            MantenimientoForms.FormBorradoMultiple nueva = new MantenimientoForms.FormBorradoMultiple();
            nueva.Show();
        }
    }
}
