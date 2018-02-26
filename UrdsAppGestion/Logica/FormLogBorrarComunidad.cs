using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrdsAppGestión.Logica
{
    public partial class FormLogBorrarComunidad : Form
    {
        public String log = "";
        String id_comunidad;
        public FormLogBorrarComunidad(String id_comunidad)
        {
            InitializeComponent();
            this.id_comunidad = id_comunidad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////////////DESHABILITADO POR SEGURIDAD///////
            //button1.Text = "Borrando...";
            //button1.Enabled = false;
            //textBox_log.Text = textBox_log.Text + "Borrando Operaciones.....";
            //borrarOperaciones();
            //textBox_log.Text = textBox_log.Text + "..OK\r\n";
            //textBox_log.Text = textBox_log.Text + "Borrando Movimientos.....";
            //borrarMovimientos();
            //System.Threading.Thread.Sleep(1000);
            //textBox_log.Text = textBox_log.Text + "..OK\r\n";
            //textBox_log.Text = textBox_log.Text + "Borrando Cuentas y Ejercicios.....";
            //borrarCuentasYejercicios();
            //System.Threading.Thread.Sleep(1000);
            //textBox_log.Text = textBox_log.Text + "..OK\r\n";
            //textBox_log.Text = textBox_log.Text + "Borrando Recibos.....";
            //System.Threading.Thread.Sleep(1000);
            //BorrarRecibos();
            //textBox_log.Text = textBox_log.Text + "..OK\r\n";
            //textBox_log.Text = textBox_log.Text + "Borrando Comuneros y divisiones .....";
            //System.Threading.Thread.Sleep(500);
            //comuneros();
            //textBox_log.Text = textBox_log.Text + "..OK\r\n";
            //textBox_log.Text = textBox_log.Text + "Borrando Otras Tablas.....";
            //borrasOtrasTablas();
            //textBox_log.Text = textBox_log.Text + "..OK\r\n";
            //textBox_log.Text = textBox_log.Text + "Borrando Proveedores.....";
            //EliminarProveedores();
            //textBox_log.Text = textBox_log.Text + "..OK\r\n";
            //textBox_log.Text = textBox_log.Text + "Borrando Directorio.....";
            //borrardirectorio();
            //textBox_log.Text = textBox_log.Text + "..FIN\n";
            //button1.Text = "¡Listo!";
            MessageBox.Show("Deshabilitado el borrado desde código");
        }
        private void borrasOtrasTablas()
        {
            String sqlCargos = "DELETE FROM com_cargos WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlCargos);
            String sqlBloques = "DELETE FROM com_bloques WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloques);
            String sqlCargosCom = "DELETE FROM com_cargoscom WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlCargosCom);
            String sqlEnvSe = "DELETE FROM com_EnvSe WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlEnvSe);
            String sqlDoc = "DELETE FROM com_Documentos WHERE IdDocumento = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDoc);
        }
        private void EliminarProveedores () {
            String sqlEliminarProveedores = "DELETE FROM com_proveedores WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlEliminarProveedores);
        }
        private void comuneros()
        {
            List<String> lista_entidades = new List<String>();

            String sqlComuneros = "SELECT IdEntidad FROM com_comuneros WHERE IdComunidad = " + id_comunidad;
            DataTable comunerosComunidad = Persistencia.SentenciasSQL.select(sqlComuneros);

            for (int a = 0; a < comunerosComunidad.Rows.Count; a++)
            {
                String sqlUrendes = "SELECT identidad FROM ctos_urendes WHERE identidad = " + comunerosComunidad.Rows[a][0].ToString();
                DataTable urendes = Persistencia.SentenciasSQL.select(sqlUrendes);

                if (urendes.Rows.Count == 0)
                {
                    String sqlCategoria = "SELECT IdDetalleCat FROM ctos_detallecat WHERE IdEntidad = " + comunerosComunidad.Rows[a][0].ToString();
                    DataTable categorias = Persistencia.SentenciasSQL.select(sqlCategoria);
                    if (categorias.Rows.Count == 0)
                    {
                        String sqlOtrasComunidades = "SELECT IdEntidad FROM com_comuneros WHERE IdComunidad <> " + id_comunidad + " and IdEntidad = " + comunerosComunidad.Rows[a][0].ToString();
                        DataTable OtrasComunidades = Persistencia.SentenciasSQL.select(sqlOtrasComunidades);

                        if (OtrasComunidades.Rows.Count == 0)
                        {
                            lista_entidades.Add(comunerosComunidad.Rows[a][0].ToString());
                        }
                    }
                }
            }
            borrarDatos(lista_entidades);
        }
        private void borrarDatos(List<String> lista_entidades)
        {
            String sqlBorrarDivisiones = "DELETE FROM com_divisiones WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarDivisiones);

            String sqlBorrarComuneros = "DELETE FROM com_comuneros WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarComuneros);

            for (int a = 0; a < lista_entidades.Count; a++) {
                String sqlDeleteEntidad = "DELETE FROM ctos_entidades WHERE IDEntidad = " + lista_entidades[a].ToString();
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteEntidad);
                System.Threading.Thread.Sleep(500);
            }
        }

        private void borrarMovimientos()
        {
            String sqlCuentas = "SELECT IdCuenta FROM com_cuentas WHERE IdComunidad = " + id_comunidad;
            DataTable cuentas = Persistencia.SentenciasSQL.select(sqlCuentas);

            String sqlEjercicios = "SELECT IdEjercicio FROM com_ejercicios WHERE IdComunidad = " + id_comunidad;
            DataTable Ejercicios = Persistencia.SentenciasSQL.select(sqlEjercicios);

            for (int a = 0; a < cuentas.Rows.Count; a++)
            {
                for (int b = 0; b < Ejercicios.Rows.Count; b++)
                {
                    //BORRO REMESAS
                    String sql_select = "SELECT IdRemesa FROM com_remesas WHERE IdComunidad = " + id_comunidad + " AND IdCuenta = " + cuentas.Rows[a][0].ToString();
                    DataTable remesas = Persistencia.SentenciasSQL.select(sql_select);

                    if (remesas.Rows.Count > 0)
                    {
                        String sqlDeleteremsas = "DELETE FROM com_remesas WHERE IdComunidad = " + id_comunidad + " AND IdCuenta = " + cuentas.Rows[a][0].ToString();
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteremsas);
                    }

                    //BORRO PRESUPUESTOS 
                    String sql_presupuesto = "SELECT IdPresupuesto FROM com_presupuestos WHERE IdEjercicio = " + Ejercicios.Rows[b][0].ToString();
                    DataTable presupuestos = Persistencia.SentenciasSQL.select(sql_presupuesto);
                    if (presupuestos.Rows.Count > 0)
                    {
                        for (int d = 0; d < presupuestos.Rows.Count; d++)
                        {
                            String sql_deletedetalles = "DELETE FROM com_detpresupuesto WHERE IdPresupuesto = " + presupuestos.Rows[d][a].ToString();
                            Persistencia.SentenciasSQL.InsertarGenerico(sql_deletedetalles);
                        }
                        String sqlDeletePresupues = "DELETE FROM com_presupuestos WHERE IdEjercicio = " + Ejercicios.Rows[b][0].ToString();
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlDeletePresupues);
                    }

                    //BORRAR LIQUIDACION
                    String sql_delete_liquidacion = "SELECT IdLiquidacion FROM com_liquidaciones WHERE IdEjercicio = " + Ejercicios.Rows[b][0].ToString();
                    DataTable liquidaciones = Persistencia.SentenciasSQL.select(sql_delete_liquidacion);

                    if (liquidaciones.Rows.Count > 0)
                    {
                        for (int c = 0; c < liquidaciones.Rows.Count; c++)
                        {

                            //BOORAR OPDETLIQUIDACIONES
                            String opdetliquidacion = "DELETE FROM com_opdetliquidacion WHERE IdLiquidacion = " + liquidaciones.Rows[c][0].ToString();
                            Persistencia.SentenciasSQL.InsertarGenerico(opdetliquidacion);

                            //BOORAR CUOTAS
                            String sql_cuotas = "SELECT IdCuota FROM com_cuotas WHERE IdLiquidacion = " + liquidaciones.Rows[c][0].ToString();
                            DataTable cuotas = Persistencia.SentenciasSQL.select(sql_cuotas);

                            if (cuotas.Rows.Count > 0)
                            {
                                String sql_delete_cuotas = "DELETE FROM com_cuotas WHERE IdLiquidacion = " + liquidaciones.Rows[c][0].ToString();
                                Persistencia.SentenciasSQL.InsertarGenerico(sql_delete_cuotas);
                            }
                        }

                        String sql_delete_liquidacion2 = "DELETE FROM com_liquidaciones WHERE IdEjercicio = " + Ejercicios.Rows[b][0].ToString();
                        Persistencia.SentenciasSQL.InsertarGenerico(sql_delete_liquidacion2);
                    }
                }
            }
        }
        private void borrarOperaciones()
        {
            String sqlCuentas = "SELECT IdCuenta FROM com_cuentas WHERE IdComunidad = " + id_comunidad;
            DataTable cuentas = Persistencia.SentenciasSQL.select(sqlCuentas);

            String sqlEjercicios = "SELECT IdEjercicio FROM com_ejercicios WHERE IdComunidad = " + id_comunidad;
            DataTable Ejercicios = Persistencia.SentenciasSQL.select(sqlEjercicios);


            for (int a = 0; a < cuentas.Rows.Count; a++)
            {
                for (int b = 0; b < Ejercicios.Rows.Count; b++)
                {

                    String sqlSelect = "SELECT IdMov, IdEjercicio, IdCuenta FROM com_movimientos WHERE IdEjercicio = " + Ejercicios.Rows[b][0].ToString() + " and IdCuenta = " + cuentas.Rows[a][0].ToString();
                    DataTable datos = Persistencia.SentenciasSQL.select(sqlSelect);

                    if (datos.Rows.Count > 0)
                    {
                        String sqlDelete = "DELETE FROM com_movimientos WHERE IdEjercicio = " + Ejercicios.Rows[b][0].ToString() + " and IdCuenta = " + cuentas.Rows[a][0].ToString();
                        Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
                    }

                    String sql_delete_liquidacion = "SELECT IdLiquidacion FROM com_liquidaciones WHERE IdEjercicio = " + Ejercicios.Rows[b][0].ToString();
                    DataTable liquidaciones = Persistencia.SentenciasSQL.select(sql_delete_liquidacion);
                    if (liquidaciones.Rows.Count > 0)
                    {
                        for (int c = 0; c < liquidaciones.Rows.Count; c++)
                        {
                            //BORRAR REPARTO
                            String sqlReparto = "SELECT IdLiqReparto FROM com_liqreparto WHERE IdLiquidacion = " + liquidaciones.Rows[c][0].ToString();
                            DataTable reparto = Persistencia.SentenciasSQL.select(sqlReparto);
                            if (reparto.Rows.Count > 0)
                            {
                                String sqlDelete = "DELETE FROM com_liqreparto WHERE IdLiquidacion = " + liquidaciones.Rows[c][0].ToString();
                                Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete);
                            }
                        }
                    }
                }
            }
            String BorrarOperaciones = "DELETE FROM com_operaciones WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(BorrarOperaciones);
        }
        private void borrarCuentasYejercicios()
        {
            String sqlCuentas = "SELECT IdCuenta FROM com_cuentas WHERE IdComunidad = " + id_comunidad;
            DataTable cuentas = Persistencia.SentenciasSQL.select(sqlCuentas);

            String sqlEjercicios = "SELECT IdEjercicio FROM com_ejercicios WHERE IdComunidad = " + id_comunidad;
            DataTable Ejercicios = Persistencia.SentenciasSQL.select(sqlEjercicios);


            for (int a = 0; a < cuentas.Rows.Count; a++)
            {
                for (int b = 0; b < Ejercicios.Rows.Count; b++)
                {

                    //BORRO DETALLES DE CUENTAS
                    String sql_detCuentas = "SELECT IdDetCuenta FROM com_detcuentas WHERE IdEjercicio = " + Ejercicios.Rows[b][0].ToString();
                    DataTable detCuentas = Persistencia.SentenciasSQL.select(sql_detCuentas);

                    if (detCuentas.Rows.Count > 0)
                    {
                        String eliminar_detCuentas = "DELETE FROM com_detcuentas WHERE IdEjercicio = " + Ejercicios.Rows[b][0].ToString();
                        Persistencia.SentenciasSQL.InsertarGenerico(eliminar_detCuentas);
                    }

                    //BORRO DETALLES DE CUENTAS
                    String sql_detCuentas1 = "SELECT IdDetCuenta FROM com_detcuentas WHERE IdCuenta = " + cuentas.Rows[a][0].ToString();
                    DataTable detCuentas1 = Persistencia.SentenciasSQL.select(sql_detCuentas1);

                    if (detCuentas1.Rows.Count > 0)
                    {
                        String eliminar_detCuentas1 = "DELETE FROM com_detcuentas WHERE IdCuenta = " + cuentas.Rows[a][0].ToString();
                        Persistencia.SentenciasSQL.InsertarGenerico(eliminar_detCuentas1);
                    }
                }
            }

            String sqlDelete1 = "DELETE FROM com_cuentas WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDelete1);
            String sqlDelele2 = "DELETE FROM com_ejercicios WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDelele2);
        }
        private void BorrarRecibos()
        {
            String recibos = "DELETE FROM com_recibos WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(recibos);

            String sqlBorrarCertificados = "DELETE FROM com_certificados WHERE IdComunidad = " + id_comunidad;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBorrarCertificados);
        }
        private void borrardirectorio() {
            try {
                String sqlRuta = Persistencia.SentenciasSQL.select("SELECT ctos_entidades.Ruta FROM ctos_entidades INNER JOIN com_comunidades ON ctos_entidades.IDEntidad = com_comunidades.IdEntidad WHERE(((com_comunidades.IdComunidad) = " + id_comunidad + "));").Rows[0][0].ToString();
                if (sqlRuta != "")
                {
                    sqlRuta = sqlRuta.Trim('#');

                    DialogResult resultado_message;
                    resultado_message = MessageBox.Show("¿Desea borrar este Fichero (" + sqlRuta + ") ?", "Borrar Ficheros", MessageBoxButtons.OKCancel);

                    if (resultado_message == System.Windows.Forms.DialogResult.OK)
                    {
                        System.IO.Directory.Delete(@sqlRuta, true);
                    }
                }
            }
            catch {
                MessageBox.Show("No se ha podido borrar la carpeta");
            }
        }
    }
}
