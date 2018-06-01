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

        private void FormMantenimiento_Load(object sender, EventArgs e)
        {

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

        private void button_insertarPendientes_Click(object sender, EventArgs e)
        {
            MantenimientoForms.FormInsertarPendientes nueva = new MantenimientoForms.FormInsertarPendientes();
            nueva.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT IDEntidad, Entidad FROM ctos_entidades";
            DataTable tablaEntidades = Persistencia.SentenciasSQL.select(sqlSelect);
            
            for (int a = 0; a < tablaEntidades.Rows.Count; a++ ) {
                String nombre = quitaAcentos(tablaEntidades.Rows[a][1].ToString());

                String sqlUpdate = "UPDATE ctos_entidades SET EntidadSinAcentos='" + nombre.Replace("'","`") + "' WHERE IDEntidad = " + tablaEntidades.Rows[a][0].ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            MessageBox.Show("Fin");
            
        }
        private String quitaAcentos(String inputString)
        {
            var normalizedString = inputString.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                var uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(normalizedString[i]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;

            String sqlLiqudaciones = "SELECT com_liquidaciones.IdLiquidacion FROM com_liquidaciones;";
            DataTable todas = Persistencia.SentenciasSQL.select(sqlLiqudaciones);
            
            for (int i = 0; i < todas.Rows.Count; i++)
            {
                progressBar1.Maximum = todas.Rows.Count;

                String sql = "(SELECT SUM(ImpLiq) FROM (SELECT Sum(com_opdetliquidacion.Importe * If(com_subcuentas.ES = 1, -1, 1)) AS ImpLiq FROM(com_operaciones INNER JOIN com_opdetliquidacion ON com_operaciones.IdOp = com_opdetliquidacion.IdOp) INNER JOIN com_subcuentas ON com_operaciones.IdSubCuenta = com_subcuentas.IdSubcuenta GROUP BY com_operaciones.IdOp, com_opdetliquidacion.IdLiquidacion, com_operaciones.IdSubCuenta, com_opdetliquidacion.Importe HAVING(((com_opdetliquidacion.IdLiquidacion) = " + todas.Rows[i][0].ToString() + ") AND((com_operaciones.IdSubCuenta)Between 60000 And 69999 Or(com_operaciones.IdSubCuenta) Between 70100 And 76900)) ORDER BY com_operaciones.IdOp) total); ";

                DataTable total = Persistencia.SentenciasSQL.select(sql);

                if (total.Rows[0][0].ToString().Replace(',', '.') != "")
                {
                    String sqlUpdate = "UPDATE com_liquidaciones SET Total=" + total.Rows[0][0].ToString().Replace(',', '.') + " WHERE IdLiquidacion = " + todas.Rows[i][0].ToString() + ";";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                progressBar1.Value = i;

            }
            progressBar1.Visible = false;
            MessageBox.Show("Fin");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String sqlComunidades = "SELECT com_comunidades.IdComunidad FROM com_comunidades WHERE(((com_comunidades.FBaja)Is Null));";
            DataTable comunidades = Persistencia.SentenciasSQL.select(sqlComunidades);

            for (int b = 0; b < comunidades.Rows.Count; b++)
            {
                String idComunidad =comunidades.Rows[b][0].ToString();

                String sqlSelectBloques = "SELECT com_bloques.IdBloque, com_bloques.Descripcion FROM com_bloques WHERE com_bloques.IdComunidad = " + idComunidad + " AND com_bloques.IdTipoBloque = 1 AND Fisica = -1 AND com_bloques.Baja <> -1; ";
                DataTable bloquesComunidad = Persistencia.SentenciasSQL.select(sqlSelectBloques);

                for (int a = 0; a < bloquesComunidad.Rows.Count; a++)
                {
                    int id = Int32.Parse(bloquesComunidad.Rows[a][0].ToString());
                    String codigo = "";
                    if ( id < 10)
                    {
                        codigo += "000" + id;
                    }
                    else if (id < 100)
                    {
                        codigo += "00" + id;
                    }
                    else if (id < 1000)
                    {
                        codigo += "0" + id;
                    }
                    else
                    {
                        codigo = id.ToString();
                    }
                    String sqlInsertar = "INSERT INTO exp_area (IdAreaPrevio,IdBloque, Nombre, Descripcion, codigoArea) VALUES(0,'" + bloquesComunidad.Rows[a][0].ToString() + "','" + bloquesComunidad.Rows[a][1].ToString() + "','Bloque físico','" + codigo + "')";
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlInsertar);

                }
            }
            MessageBox.Show("Fin.");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int contTarea = 0;
            String fecha = "";
            String fechaAnterior="";
            String sqlUpdate;
            progressBar1.Visible = true;

            String sqlString = "SELECT IdTarea, FIni, FFin FROM exp_tareas ORDER BY FIni";
            DataTable tareas = Persistencia.SentenciasSQL.select(sqlString);
            progressBar1.Maximum = tareas.Rows.Count;

            for (int a = 0; a < tareas.Rows.Count;a++) {
                contTarea++;
                progressBar1.Value = a;
                if (tareas.Rows[a][1].ToString() != "") {
                    fecha = (Convert.ToDateTime(tareas.Rows[a][1].ToString()).Year).ToString().Substring(2, 2) + "/";
                    if (fechaAnterior != fecha) contTarea = 1;
                    sqlUpdate = "UPDATE exp_tareas SET IdTareaCorto='" + fecha + contTarea.ToString("D4") + "' WHERE IdTarea = " + tareas.Rows[a][0].ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                else if (tareas.Rows[a][1].ToString() == "" && tareas.Rows[a][2].ToString() != "") {
                    fecha = (Convert.ToDateTime(tareas.Rows[a][2].ToString()).Year).ToString().Substring(2,2) + "/";
                    if (fechaAnterior != fecha) contTarea = 1;
                    sqlUpdate = "UPDATE exp_tareas SET IdTareaCorto='" + fecha + contTarea.ToString("D4") + "' WHERE IdTarea = " + tareas.Rows[a][0].ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }
                else if (tareas.Rows[a][1].ToString() != "" && tareas.Rows[a][2].ToString() != "")
                {
                    fecha = "00/";
                    if (fechaAnterior != fecha) contTarea = 1;
                    sqlUpdate = "UPDATE exp_tareas SET IdTareaCorto='" + fecha + contTarea.ToString("D4") + "' WHERE IdTarea = " + tareas.Rows[a][0].ToString();
                    Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
                }

                fechaAnterior = fecha;

            }
            MessageBox.Show("Fin");
            progressBar1.Visible = false;
        }

        private void buttonActualizarCategoriasEntidad_Click(object sender, EventArgs e)
        {

            String sqlSelect = "SELECT ctos_entidades.IDEntidad, ctos_catentidades.Descripcion FROM ctos_catentidades INNER JOIN (ctos_entidades INNER JOIN ctos_detallecat ON ctos_entidades.IDEntidad = ctos_detallecat.IdEntidad) ON ctos_catentidades.IdCategoria = ctos_detallecat.IdCategoria";
            DataTable table = Persistencia.SentenciasSQL.select(sqlSelect);
            
            
            foreach (DataRow row in table.Rows)
            {
                String sqlSelect2 = "SELECT ctos_entidades.PalabrasClave AS Categoría FROM ctos_entidades WHERE ctos_entidades.IDEntidad = " + row[0].ToString();
                String palabrasClave = Persistencia.SentenciasSQL.select(sqlSelect2).Rows[0][0].ToString();
                if (palabrasClave.Length > 0) palabrasClave += ";" + quitaAcentos(row[1].ToString());
                else palabrasClave += quitaAcentos(row[1].ToString());
                String sqlUpdate = "UPDATE ctos_entidades SET PalabrasClave = '" + palabrasClave + "' WHERE IDEntidad = " + row[0].ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
                
            /*


            String sqlSelect = "SELECT ctos_entidades.IDEntidad, ctos_entidades.PalabrasClave FROM ctos_entidades WHERE((Not(ctos_entidades.PalabrasClave) = ''))";
            DataTable table = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach (DataRow row in table.Rows)
            {
                String sqlUpdate = "UPDATE ctos_entidades SET PalabrasClave = '' WHERE IDEntidad = " + row[0].ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
            }
            */
            MessageBox.Show(table.Rows.Count.ToString() + " Registros Actualizados");
        }

        private void buttonActualizarBloqueTareas_Click(object sender, EventArgs e)
        {
            String sqlSelect = "SELECT exp_area.IdArea, exp_tareas.IdTarea, com_bloques.Descripcion FROM((exp_tareas INNER JOIN exp_elementos ON exp_tareas.IdElemento = exp_elementos.IdElemento) INNER JOIN com_bloques ON exp_elementos.IdComunidad = com_bloques.IdComunidad) INNER JOIN exp_area ON com_bloques.IdBloque = exp_area.IdBloque WHERE (((com_bloques.Descripcion) = exp_elementos.Nombre) AND((exp_area.IdAreaPrevio) = 0))";
            DataTable tablaAntigua = Persistencia.SentenciasSQL.select(sqlSelect);

            foreach(DataRow row in tablaAntigua.Rows)
            {
                String sqlInsert = "INSERT INTO exp_areaTarea (IdArea,IdTarea) VALUES ('" + row[0] + "','" + row[1] + "')";
                Persistencia.SentenciasSQL.InsertarGenerico(sqlInsert);
            }

            MessageBox.Show("Actualizado correctamente");
        }

        private void buttonActualizarCategoriasProv_Click(object sender, EventArgs e)
        {
            MantenimientoForms.FormActualizarCatProveedores nueva = new MantenimientoForms.FormActualizarCatProveedores();
            nueva.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String idComunidad = "2";

            String sqlSelect = "SELECT com_operaciones.IdComunidad, com_opdetalles.IdOpDet, com_opdetalles.NumMov, com_opdetalles.ImpOpDetPte, Count(com_detmovs.IdDetMov) AS CuentaDeIdDetMov FROM(com_opdetalles LEFT JOIN com_detmovs ON com_opdetalles.IdOpDet = com_detmovs.IdOpDet) INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp GROUP BY com_operaciones.IdComunidad, com_opdetalles.IdOpDet, com_opdetalles.NumMov, com_opdetalles.ImpOpDetPte HAVING(((com_operaciones.IdComunidad) = " + idComunidad + ") AND((com_opdetalles.ImpOpDetPte) = 0) AND((Count(com_detmovs.IdDetMov)) = 0));";

            DataTable vencimientos = Persistencia.SentenciasSQL.select(sqlSelect);
            for (int a = 0; a < vencimientos.Rows.Count; a++) {

            }
            
        }
    }
}
