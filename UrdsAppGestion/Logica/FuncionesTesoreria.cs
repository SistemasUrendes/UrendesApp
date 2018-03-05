using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrdsAppGestión.Logica
{
    public class FuncionesTesoreria
    {
        public static String ejercicioActivo(String id_comunidad, String fecha)
        {
            //BUSCO EL EJERCICIO ACTIVO
            String SelectEjercicio = "SELECT IdEjercicio FROM com_ejercicios WHERE IdComunidad = " + id_comunidad + " AND FIni <= '" + fecha + "' AND FFin >= '" + fecha + "'";
            return Persistencia.SentenciasSQL.select(SelectEjercicio).Rows[0][0].ToString();
        }
        public static int CreaMovimiento(String ejercicio, String id_cuenta, String tipoMov, String id_entidad, String fecha, String detalles)
        {
            //CREO CABECERA DEL MOVIMIENTO
            String sqlInsertMov = "INSERT INTO com_movimientos (IdEjercicio, IdCuenta, IdDetTipoMov, IdEntidad, Fecha, Detalle) VALUES (" + ejercicio + "," + id_cuenta + "," + tipoMov + "," + id_entidad + ",'" + fecha + "','" + detalles + "')";
            return Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertMov);
        }
        public static int CreaMovimientoRemesa(String ejercicio, String id_cuenta, String tipoMov, String id_entidad, String fecha, String detalles, String idRemesa)
        {
            //CREO CABECERA DEL MOVIMIENTO
            String sqlInsertMov = "INSERT INTO com_movimientos (IdEjercicio, IdCuenta, IdDetTipoMov, IdEntidad, Fecha, Detalle, IdRemesa) VALUES (" + ejercicio + "," + id_cuenta + "," + tipoMov + "," + id_entidad + ",'" + fecha + "','" + detalles + "'," + idRemesa + ")";
            return Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertMov);
        }

        public static int CreaMovimientoCA(String ejercicio, String id_cuenta, String tipoMov, String id_entidad, String fecha, String detalles, String MovCA)
        {
            //CREO CABECERA DEL MOVIMIENTO
            String sqlInsertMov = "INSERT INTO com_movimientos (IdEjercicio, IdCuenta, IdDetTipoMov, IdEntidad, Fecha, Detalle, MovCA) VALUES (" + ejercicio + "," + id_cuenta + "," + tipoMov + "," + id_entidad + ",'" + fecha + "','" + detalles + "'," + MovCA + ")";
            return Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertMov);
        }
        public static void CreaDetalleMovimiento(String numMov, String id_op_det, String importe)
        {

            //CREO EL DETALLE DEL MOVIMIENTO CON EL IMPORTE ENTERO
            String varTipoMov = (Persistencia.SentenciasSQL.select("SELECT IdDetTipoMov FROM com_movimientos WHERE IdMov = " + numMov)).Rows[0][0].ToString();
            String varTipoES = (Persistencia.SentenciasSQL.select("SELECT IdTipoMov FROM com_dettiposmov WHERE IdDetTipoMov = " + varTipoMov)).Rows[0][0].ToString();

            if (varTipoES == "1")
            {
                String InsertDetMovEntero = "INSERT INTO com_detmovs (IdMov, IdOpDet, Importe, ImpDetMovEntra, ImpDetMovNeto) VALUES (" + numMov + "," + id_op_det + "," + importe + "," + importe + "," + importe + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(InsertDetMovEntero);
            }
            else if (varTipoES == "2")
            {
                String InsertDetMovEntero = "INSERT INTO com_detmovs (IdMov, IdOpDet, Importe, ImpDetMovSale, ImpDetMovNeto) VALUES (" + numMov + "," + id_op_det + "," + importe + "," + importe + ",-" + importe + ")";
                Persistencia.SentenciasSQL.InsertarGenerico(InsertDetMovEntero);
            }

        }
        public static String LiquidacionActiva(String id_comunidad)
        {
            return (Persistencia.SentenciasSQL.select("SELECT com_liquidaciones.IdLiquidacion FROM com_liquidaciones INNER JOIN com_ejercicios ON com_liquidaciones.IdEjercicio = com_ejercicios.IdEjercicio WHERE(((com_ejercicios.IdComunidad) = " + id_comunidad + ") AND((com_liquidaciones.Ppal) = -1) AND((com_liquidaciones.IdTipoLiq) = 1));")).Rows[0][0].ToString();
        }
        public static String CuentaCompesaciones(String id_comunidad)
        {
            String sqlSelect = "SELECT IdCuenta FROM com_cuentas WHERE IdComunidad = " + id_comunidad + " and C = -1";
            try
            {
                return Persistencia.SentenciasSQL.select(sqlSelect).Rows[0][0].ToString();
            }
            catch
            {
                return "No";
            }

        }
        public static void AnticipoProveedor(String id_comunidad, String id_Entidad, String fecha, double importeAcuenta, int id_mov)
        {
            String fecha_actualizacion = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd hh:mm:ss");
            //OPERACION SACP

            String sqlInsertOperacionAC = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdMovCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + id_comunidad + "," + id_Entidad + ",43812,3,'" + fecha + "','SACP - M" + id_mov + "','Salida AC Proveedor M" + id_mov + "'," + id_mov + "," + importeAcuenta.ToString().Replace(',', '.') + "," + importeAcuenta.ToString().Replace(',', '.') + ",'Si'," + Presentacion.Login.getId() + ",'" + fecha_actualizacion + "')";

            int opAC = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacionAC);

            //INSERTO EL IVA EN LA OPERACION ANTERIOR
            String sqlIVA = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + opAC + "," + importeAcuenta.ToString().Replace(',', '.') + ",1,0)";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA);

            //INSERTO EL REPARTO EN LA OPERACION ANTERIOR
            String sqlBloq = "INSERT INTO com_opdetbloques (IdOp, IdEntidad, Porcentaje, Importe) VALUES (" + opAC + "," + id_Entidad + ",1," + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq);

            //INSERTO EL VENCIMIENTO EN LA OPERACION ANTERIOR
            String sqlDetOp = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + opAC + "," + id_Entidad + ",'" + fecha + "','" + fecha + "'," + importeAcuenta.ToString().Replace(',', '.') + "," + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDetOp);

            //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
            String sqlLiq = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + opAC + "," + LiquidacionActiva(id_comunidad) + ",1," + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq);

            //CREO DETALLE DEL MOVIMIENTO SACP
            String varDetOp = (Persistencia.SentenciasSQL.select("SELECT IdOpDet FROM com_opdetalles WHERE IdOp = " + opAC)).Rows[0][0].ToString();
            CreaDetalleMovimiento(id_mov.ToString(), varDetOp, importeAcuenta.ToString().Replace(',', '.'));


            //OPERACION EACP
            String sqlInsertOperacionCA = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdMovCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + id_comunidad + "," + id_Entidad + ",43812,3,'" + fecha + "','EACP - M" + id_mov + "','Entrada AC Proveedor M " + id_mov + "'," + id_mov + ",-" + importeAcuenta.ToString().Replace(',', '.') + ",-" + importeAcuenta.ToString().Replace(',', '.') + ",'Si'," + Presentacion.Login.getId() + ",'" + fecha_actualizacion + "')";

            int opCA = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacionCA);
            //INSERTO EL IVA EN LA OPERACION ANTERIOR

            String sqlIVA2 = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + opCA + ",-" + importeAcuenta.ToString().Replace(',', '.') + ",1,0)";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA2);

            //INSERTO EL REPARTO EN LA OPERACION ANTERIOR
            String sqlBloq2 = "INSERT INTO com_opdetbloques (IdOp, IdEntidad, Porcentaje, Importe) VALUES (" + opCA + "," + id_Entidad + ",1,-" + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq2);

            //INSERTO EL VENCIMIENTO EN LA OPERACION ANTERIOR
            String sqlDetOp2 = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + opCA + "," + id_Entidad + ",'" + fecha + "','" + fecha + "',-" + importeAcuenta.ToString().Replace(',', '.') + ",-" + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDetOp2);

            //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
            String sqlLiq2 = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + opCA + "," + LiquidacionActiva(id_comunidad) + ",1,-" + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq2);

        }
        public static void AnticipoComunero(String id_comunidad, String id_Entidad, String fecha, double importeAcuenta, int id_mov)
        {
            String fecha_actualizacion = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd hh:mm:ss");

            //OPERACION SACP
            String sqlInsertOperacionAC = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdMovCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + id_comunidad + "," + id_Entidad + ",43801,3,'" + fecha + "','SAC - M" + id_mov + "','Salida AC Comunero M" + id_mov + "'," + id_mov + "," + importeAcuenta.ToString().Replace(',', '.') + "," + importeAcuenta.ToString().Replace(',', '.') + ",'Si'," + Presentacion.Login.getId() + ",'" + fecha_actualizacion + "')";

            int opAC = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacionAC);

            //INSERTO EL IVA EN LA OPERACION ANTERIOR
            String sqlIVA = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + opAC + "," + importeAcuenta.ToString().Replace(',', '.') + ",1,0)";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA);

            //INSERTO EL REPARTO EN LA OPERACION ANTERIOR
            String sqlBloq = "INSERT INTO com_opdetbloques (IdOp, IdEntidad, Porcentaje, Importe) VALUES (" + opAC + "," + id_Entidad + ",1," + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq);

            //INSERTO EL VENCIMIENTO EN LA OPERACION ANTERIOR
            String sqlDetOp = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + opAC + "," + id_Entidad + ",'" + fecha + "','" + fecha + "'," + importeAcuenta.ToString().Replace(',', '.') + "," + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDetOp);

            //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
            String sqlLiq = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + opAC + "," + LiquidacionActiva(id_comunidad) + ",1," + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq);

            //CREO DETALLE DEL MOVIMIENTO SACP
            String varDetOp = (Persistencia.SentenciasSQL.select("SELECT IdOpDet FROM com_opdetalles WHERE IdOp = " + opAC)).Rows[0][0].ToString();
            CreaDetalleMovimiento(id_mov.ToString(), varDetOp, importeAcuenta.ToString().Replace(',', '.'));


            //OPERACION EACP
            String sqlInsertOperacionCA = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdMovCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + id_comunidad + "," + id_Entidad + ",43801,3,'" + fecha + "','EAC - M" + id_mov + "','Entrada AC Comunero M" + id_mov + "'," + id_mov + ",-" + importeAcuenta.ToString().Replace(',', '.') + ",-" + importeAcuenta.ToString().Replace(',', '.') + ",'Si'," + Presentacion.Login.getId() + ",'" + fecha_actualizacion + "')";

            int opCA = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacionCA);
            //INSERTO EL IVA EN LA OPERACION ANTERIOR

            String sqlIVA2 = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + opCA + ",-" + importeAcuenta.ToString().Replace(',', '.') + ",1,0)";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA2);

            //INSERTO EL REPARTO EN LA OPERACION ANTERIOR
            String sqlBloq2 = "INSERT INTO com_opdetbloques (IdOp, IdEntidad, Porcentaje, Importe) VALUES (" + opCA + "," + id_Entidad + ",1,-" + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq2);

            //INSERTO EL VENCIMIENTO EN LA OPERACION ANTERIOR
            String sqlDetOp2 = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + opCA + "," + id_Entidad + ",'" + fecha + "','" + fecha + "',-" + importeAcuenta.ToString().Replace(',', '.') + ",-" + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDetOp2);

            //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
            String sqlLiq2 = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + opCA + "," + LiquidacionActiva(id_comunidad) + ",1,-" + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq2);
        }
        public static void AbonoComunero(String id_comunidad, String id_Entidad, String fecha, double importeAcuenta, int id_mov)
        {
            String fecha_actualizacion = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd hh:mm:ss");

            //OPERACION AC
            String sqlInsertOperacionAC = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdMovCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + id_comunidad + "," + id_Entidad + ",43801,3,'" + fecha + "','EAC - M" + id_mov + "','Entrada AC M" + id_mov + "'," + id_mov + "," + importeAcuenta.ToString().Replace(',', '.') + "," + importeAcuenta.ToString().Replace(',', '.') + ",'Si'," + Presentacion.Login.getId() + ",'" + fecha_actualizacion + "')";

            int opAC = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacionAC);

            //INSERTO EL IVA EN LA OPERACION ANTERIOR
            String sqlIVA = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + opAC + "," + importeAcuenta.ToString().Replace(',', '.') + ",1,0)";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA);

            //INSERTO EL REPARTO EN LA OPERACION ANTERIOR
            String sqlBloq = "INSERT INTO com_opdetbloques (IdOp, IdEntidad, Porcentaje, Importe) VALUES (" + opAC + "," + id_Entidad + ",1," + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq);

            //INSERTO EL VENCIMIENTO EN LA OPERACION ANTERIOR
            String sqlDetOp = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + opAC + "," + id_Entidad + ",'" + fecha + "','" + fecha + "'," + importeAcuenta.ToString().Replace(',', '.') + "," + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDetOp);

            //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
            String sqlLiq = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + opAC + "," + LiquidacionActiva(id_comunidad) + ",1," + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq);



            //OPERACION EACP
            String sqlInsertOperacionCA = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdMovCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + id_comunidad + "," + id_Entidad + ",43801,3,'" + fecha + "','SAC - M" + id_mov + "','Salida AC M" + id_mov + "'," + id_mov + ",-" + importeAcuenta.ToString().Replace(',', '.') + ",-" + importeAcuenta.ToString().Replace(',', '.') + ",'Si'," + Presentacion.Login.getId() + ",'" + fecha_actualizacion + "')";

            int opCA = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacionCA);
            //INSERTO EL IVA EN LA OPERACION ANTERIOR

            String sqlIVA2 = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + opCA + ",-" + importeAcuenta.ToString().Replace(',', '.') + ",1,0)";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA2);

            //INSERTO EL REPARTO EN LA OPERACION ANTERIOR
            String sqlBloq2 = "INSERT INTO com_opdetbloques (IdOp, IdEntidad, Porcentaje, Importe) VALUES (" + opCA + "," + id_Entidad + ",1,-" + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq2);

            //INSERTO EL VENCIMIENTO EN LA OPERACION ANTERIOR
            String sqlDetOp2 = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + opCA + "," + id_Entidad + ",'" + fecha + "','" + fecha + "',-" + importeAcuenta.ToString().Replace(',', '.') + ",-" + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDetOp2);

            //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
            String sqlLiq2 = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + opCA + "," + LiquidacionActiva(id_comunidad) + ",1,-" + importeAcuenta.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq2);

            ////CREO DETALLE DEL MOVIMIENTO SACP
            String varDetOp = (Persistencia.SentenciasSQL.select("SELECT IdOpDet FROM com_opdetalles WHERE IdOp = " + opCA)).Rows[0][0].ToString();
            CreaDetalleMovimiento(id_mov.ToString(), varDetOp, importeAcuenta.ToString().Replace(',', '.'));
        }
        public static void ActualizaMovCA(String id_movActulizar, String dato)
        {
            String sqlActMovCA = "UPDATE com_movimientos SET com_movimientos.MovCA = " + dato + " WHERE (((com_movimientos.IdMov)=" + id_movActulizar + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlActMovCA);
        }
        public static void ActualizaMovDevol(String id_movActulizar, String dato)
        {
            String sqlActMovCA = "UPDATE com_movimientos SET com_movimientos.MovDevol = " + dato + " WHERE (((com_movimientos.IdMov)=" + id_movActulizar + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlActMovCA);
        }
        public static int CreoVencimientoID(String id_op, String id_entidad, String fecha, String importe, String importePto)
        {
            //CREO VENCIMIENTO
            String sqlDetOp = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetPte) VALUES (" + id_op + "," + id_entidad + ",'" + fecha + "','" + fecha + "'," + importe + ", " + importePto + ")";

            return Persistencia.SentenciasSQL.InsertarGenericoID(sqlDetOp);
        }
        public static int CreoReciboID(String idComunidad, String idEntidad, String fecha, String impRbo, String impRboPte, String referencia)
        {
            String sqlInsert = "INSERT INTO com_recibos (IdComunidad, IdEntidad, Fecha, ImpRbo, ImpRboPte, Referencia) VALUES(" + idComunidad + "," + idEntidad + ",'" + fecha + "'," + Logica.FuncionesGenerales.ArreglarImportes(impRbo) + "," + Logica.FuncionesGenerales.ArreglarImportes(impRboPte) + ",'" + referencia + "')";
            return Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert);
        }
        public static void ActualizoIdReciboVencimiento(String id_recibo, String id_opdet)
        {
            String sqlUpdate = "UPDATE com_opdetalles SET IdRecibo=" + id_recibo + " WHERE IdOpDet = " + id_opdet;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlUpdate);
        }
        public static String TipoMovimiento(String idMovimiento)
        {
            String sqlUpdate = "SELECT IdDetTipoMov FROM com_movimientos WHERE IdMov = " + idMovimiento;
            return (Persistencia.SentenciasSQL.select(sqlUpdate)).Rows[0][0].ToString();
        }
        public static Boolean MovimientoDevuelto(String idMovimiento)
        {

            String sqlUpdate = "SELECT MovDevol FROM com_movimientos WHERE IdMov = " + idMovimiento;
            DataTable fila = Persistencia.SentenciasSQL.select(sqlUpdate);
            if (fila.Rows.Count == 1 && fila.Rows[0][0].ToString() == "")
                return false;
            else
                return true;
        }
        public static void BorrarMoviento(String idMovimiento)
        {
            //BORRAR DETALLES DEL MOVIENTO PRIMERO
            String sqlDeleteDetalles = "DELETE FROM com_detmovs WHERE ((com_detmovs.IdMov) = " + idMovimiento + ");";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteDetalles);

            //BORRO EL MOVIENTO
            String sqlDeleteMovimiento = "DELETE FROM com_movimientos WHERE IdMov = " + idMovimiento;
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteMovimiento);
        }

        public static Boolean FechaCierreAceptado(String idMovimiento)
        {
            try
            {
                DateTime fechaCierreCuenta = Convert.ToDateTime((Persistencia.SentenciasSQL.select("SELECT com_cuentas.FCierre FROM com_cuentas INNER JOIN com_movimientos ON com_cuentas.IdCuenta = com_movimientos.IdCuenta WHERE (((com_movimientos.IdMov) = " + idMovimiento + "));")).Rows[0][0].ToString());

                DateTime fechaMovimiento = Convert.ToDateTime((Persistencia.SentenciasSQL.select("SELECT Fecha FROM com_movimientos WHERE IdMov = " + idMovimiento)).Rows[0][0].ToString());


                if (fechaMovimiento > fechaCierreCuenta)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }
        public static int CreaOpGastoDevolucionParticular(String id_comunidad, String EntidadBanco, String id_Entidad, String fecha, String baseIva, String iva, String tipoiva, String CreaMov, String FCreaMov)
        {

            String fechaAct = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
            double importe = double.Parse(baseIva.Replace('.', ',')) + double.Parse(iva.Replace('.', ','));

            //OPERACION 
            String sqlInsertOperacion = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdMovCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + id_comunidad + "," + id_Entidad + ",62600,3,'" + fecha + "','DMOV " + CreaMov + "', 'Gastos Devolución M" + CreaMov + " - " + FCreaMov + "'," + CreaMov + "," + importe.ToString().Replace(',', '.') + "," + importe.ToString().Replace(',', '.') + ",'Si'," + Presentacion.Login.getId() + ",'" + fechaAct + "')";

            int opCA = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacion);

            //INSERTO EL IVA EN LA OPERACION
            String sqlIVA2 = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + opCA + "," + baseIva + "," + tipoiva + "," + iva.Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA2);

            //INSERTO EL REPARTO EN LA OPERACION
            String sqlBloq2 = "INSERT INTO com_opdetbloques (IdOp, IdEntidad, Porcentaje, Importe) VALUES (" + opCA + "," + id_Entidad + ",1," + importe.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq2);

            //INSERTO EL VENCIMIENTO EN LA OPERACION
            String sqlDetOp2 = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + opCA + "," + id_Entidad + ",'" + fecha + "','" + fecha + "'," + importe.ToString().Replace(',', '.') + "," + importe.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDetOp2);

            //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
            String sqlLiq2 = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + opCA + "," + LiquidacionActiva(id_comunidad) + ",1," + importe.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq2);

            return opCA;

        }
        public static int CreaOpGastoDevolucion(String id_comunidad, String EntidadBanco, String fecha, String baseIva, String iva, String tipoiva, String CreaMov, String FCreaMov)
        {

            String fechaAct = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
            double importe = double.Parse(baseIva.Replace('.', ',')) + double.Parse(iva.Replace('.', ','));

            String idBloqueGG = (Persistencia.SentenciasSQL.select("SELECT IdBloque FROM com_bloques WHERE IdComunidad = 7 and GG = -1")).Rows[0][0].ToString();

            //OPERACION 
            String sqlInsertOperacion = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdMovCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + id_comunidad + "," + EntidadBanco + ",62600,1,'" + fecha + "','DMOV " + CreaMov + "', 'Gastos Devolución M" + CreaMov + " - " + FCreaMov + "'," + CreaMov + "," + importe.ToString().Replace(',', '.') + "," + importe.ToString().Replace(',', '.') + ",'Si'," + Presentacion.Login.getId() + ",'" + fechaAct + "')";

            int opCA = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacion);

            //INSERTO EL IVA EN LA OPERACION
            String sqlIVA2 = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + opCA + "," + baseIva + "," + tipoiva + "," + iva.Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA2);

            //INSERTO EL REPARTO EN LA OPERACION
            String sqlBloq2 = "INSERT INTO com_opdetbloques (IdOp, IdBloque, Porcentaje, Importe) VALUES (" + opCA + "," + idBloqueGG + ",1," + importe.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq2);

            //INSERTO EL VENCIMIENTO EN LA OPERACION
            String sqlDetOp2 = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + opCA + "," + EntidadBanco + ",'" + fecha + "','" + fecha + "'," + importe.ToString().Replace(',', '.') + "," + importe.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlDetOp2);

            //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
            String sqlLiq2 = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + opCA + "," + LiquidacionActiva(id_comunidad) + ",1," + importe.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq2);

            return opCA;

        }
        public static int CreaOpPagoGastoDevolucionPart(String id_comunidad, String id_Entidad, String fecha_pasada, String baseIva, String iva, String tipoiva, String CreaMov, String OpCrea, String FCreaMov)
        {

            String fecha = (Convert.ToDateTime(fecha_pasada)).ToString("yyyy-MM-dd");
            String fechaAct = (Convert.ToDateTime(DateTime.Now.ToShortDateString())).ToString("yyyy-MM-dd");
            double importe = double.Parse(baseIva.Replace('.', ',')) + double.Parse(iva.Replace('.', ','));
            String descripRecibo = "Gastos Devolución M" + CreaMov + " - " + FCreaMov;

            //OPERACION 
            String sqlInsertOperacion = "INSERT INTO com_operaciones (IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdOpCrea, IdMovCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES (" + id_comunidad + "," + id_Entidad + ",70001,3,'" + fecha + "','DMOV " + CreaMov + "', '" + descripRecibo + "' ," + OpCrea + "," + CreaMov + "," + importe.ToString().Replace(',', '.') + "," + importe.ToString().Replace(',', '.') + ",'Si'," + Presentacion.Login.getId() + ",'" + fechaAct + "')";

            int opCA = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOperacion);

            //INSERTO EL IVA EN LA OPERACION
            String sqlIVA2 = "INSERT INTO com_opdetiva (IdOp, Base, IdIVA, IVA) VALUES (" + opCA + "," + baseIva + "," + tipoiva + "," + iva.Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA2);

            //INSERTO EL REPARTO EN LA OPERACION
            String sqlBloq2 = "INSERT INTO com_opdetbloques (IdOp, IdEntidad, Porcentaje, Importe) VALUES (" + opCA + "," + id_Entidad + ",1," + importe.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBloq2);

            //INSERTO EL VENCIMIENTO EN LA OPERACION
            String sqlDetOp2 = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + opCA + "," + id_Entidad + ",'" + fecha + "','" + fecha + "'," + importe.ToString().Replace(',', '.') + "," + importe.ToString().Replace(',', '.') + ")";
            int varVto = Persistencia.SentenciasSQL.InsertarGenericoID(sqlDetOp2);

            //INSERTO LA LIQUIDACION EN LA OPERACION ANTERIOR
            String sqlLiq2 = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) VALUES (" + opCA + "," + LiquidacionActiva(id_comunidad) + ",1," + importe.ToString().Replace(',', '.') + ")";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq2);

            int idRecibo = Logica.FuncionesTesoreria.CreoReciboID(id_comunidad, id_Entidad, fecha, importe.ToString().Replace(',', '.'), importe.ToString().Replace(',', '.'), descripRecibo);

            String sqlActVtoRbo = "UPDATE com_opdetalles SET com_opdetalles.IdRecibo = " + idRecibo + " WHERE (((com_opdetalles.IdOpDet)=" + varVto + "));";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlActVtoRbo);

            return opCA;

        }
        public static int CreaMovimientoDevol(String ejercicio, String id_cuenta, String tipoMov, String id_entidad, String fecha, String detalles, String MovDevol)
        {
            //CREO CABECERA DEL MOVIMIENTO
            String sqlInsertMov = "INSERT INTO com_movimientos (IdEjercicio, IdCuenta, IdDetTipoMov, IdEntidad, Fecha, Detalle, MovDevol) VALUES (" + ejercicio + "," + id_cuenta + "," + tipoMov + "," + id_entidad + ",'" + fecha + "','" + detalles + "'," + MovDevol + ")";
            return Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertMov);
        }
        public static void CreoRecibosAgrupados(String id_comunidad, String id_cuota)
        {
            try
            {
                //CUIDADO : CORTO LA CADENA FXN Y COJO LA REGLA DE RECIBO Y LA PONGO EN SU COLUMNA
                String sqlCreoRecibos = "INSERT INTO com_recibos ( IdCuota, IdComunidad, IdEntidad, Fecha, ImpRbo, ImpRboPte, FXN, Referencia, IdReglaRec,IdCC ) SELECT com_operaciones.IdCuota, com_operaciones.IdComunidad, com_opdetalles.IdEntidad, com_opdetalles.Fecha, Sum(com_opdetalles.Importe) AS SumaDeImporte, Sum(com_opdetalles.Importe)AS SumaDeImporte1, com_opdetalles.FXN, com_operaciones.Descripcion,IF((SELECT SUBSTRING_INDEX(com_opdetalles.FXN, '-', -1) <> ''),(SELECT SUBSTRING_INDEX(com_opdetalles.FXN, '-', -1)),NULL), IF((SELECT SUBSTRING_INDEX(com_opdetalles.FXN, '-', -1) = ''),(SELECT com_comuneros.IdCC FROM com_comuneros WHERE com_comuneros.IdEntidad = com_opdetalles.IdEntidad AND com_comuneros.IdComunidad = com_operaciones.IdComunidad),(SELECT com_reglasrec.IdCC FROM com_reglasrec WHERE com_reglasrec.IdReglaRec=SUBSTRING_INDEX(com_opdetalles.FXN, '-', -1))) FROM((com_opdetalles INNER JOIN com_operaciones ON com_opdetalles.IdOp = com_operaciones.IdOp) INNER JOIN ctos_entidades ON com_opdetalles.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN com_cuotas ON com_operaciones.IdCuota = com_cuotas.IdCuota GROUP BY com_operaciones.IdCuota, com_operaciones.IdComunidad, com_opdetalles.IdEntidad, com_opdetalles.Fecha, com_opdetalles.FXN, com_cuotas.Descripcion HAVING(((com_operaciones.IdCuota) = " + id_cuota + "));";

                Persistencia.SentenciasSQL.InsertarGenerico(sqlCreoRecibos);
            }
            catch (Exception e)
            {
                Console.WriteLine("---" + e.Message);
            }

            String sqlCasarIdRecibo = "UPDATE com_opdetalles INNER JOIN com_recibos ON com_opdetalles.FXN = com_recibos.FXN SET com_opdetalles.IdRecibo = com_recibos.IdRecibo WHERE(((com_recibos.IdCuota) = " + id_cuota + "));";

            Persistencia.SentenciasSQL.InsertarGenerico(sqlCasarIdRecibo);
        }

        public static void CreaOP_PartDiv(String idComunidad, String idDivision, String idLiquidacion, String Importe, String Op_Crea, String strCuentaLiqs)
        {

            String fecha_actualizacion = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd hh:mm:ss");
            String txtdescripcion;

            String idEntidad = "SELECT com_comuneros.IdEntidad FROM((com_divisiones INNER JOIN com_asociacion ON com_divisiones.IdDivision = com_asociacion.IdDivision) INNER JOIN com_comuneros ON com_asociacion.IdComunero = com_comuneros.IdComunero) INNER JOIN ctos_entidades ON com_comuneros.IdEntidad = ctos_entidades.IDEntidad GROUP BY com_divisiones.IdComunidad, com_divisiones.IdDivision, com_divisiones.Division, com_asociacion.IdComunero, com_comuneros.IdEntidad, ctos_entidades.Entidad, com_asociacion.FechaBaja, com_asociacion.IdTipoAsoc, com_asociacion.Ppal HAVING(((com_divisiones.IdDivision) = " + idDivision + ") AND((com_asociacion.FechaBaja)Is Null) AND((com_asociacion.IdTipoAsoc) = 1) AND((com_asociacion.Ppal) = -1));";
            idEntidad = (Persistencia.SentenciasSQL.select(idEntidad)).Rows[0][0].ToString();

            txtdescripcion = (Persistencia.SentenciasSQL.select("SELECT Descripcion FROM com_operaciones WHERE IdOp = " + Op_Crea)).Rows[0][0].ToString();
            String documento = (Persistencia.SentenciasSQL.select("SELECT Documento FROM com_operaciones WHERE IdOp = " + Op_Crea)).Rows[0][0].ToString();
            String fecha = (Convert.ToDateTime((Persistencia.SentenciasSQL.select("SELECT Fecha FROM com_operaciones WHERE IdOp = " + Op_Crea)).Rows[0][0].ToString())).ToString("yyyy-MM-dd");

            if (strCuentaLiqs != "")
                txtdescripcion = strCuentaLiqs + " " + txtdescripcion;

            String sqlInsertOP = "INSERT INTO com_operaciones(IdComunidad, IdEntidad, IdSubCuenta, IdTipoReparto, Fecha, Documento, Descripcion, IdDivision, IdOpCrea, ImpOp, ImpOpPte, Guardada, IdURD, FAct) VALUES(" + idComunidad + "," + idEntidad + ",70001,2,'" + fecha + "','" + documento + "','" + txtdescripcion + "'," + idDivision + "," + Op_Crea + "," + FuncionesGenerales.ArreglarImportes(Importe) + "," + FuncionesGenerales.ArreglarImportes(Importe) + ",'Si'," + Presentacion.Login.getId() + ",'" + fecha_actualizacion + "')";

            int nuevaOP = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsertOP);

            String sqlReparto = "INSERT INTO com_opdetbloques ( IdOp, IdDivision, Porcentaje, Importe ) SELECT " + nuevaOP + " AS Op, " + idDivision + " AS Division, 1 AS Porcentaje, '" + FuncionesGenerales.ArreglarImportes(Importe) + "' AS Importe;";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlReparto);

            String sqlIVA = "INSERT INTO com_opdetiva ( IdOp, Base, idIVA, IVA) SELECT " + nuevaOP + " AS Op, '" + FuncionesGenerales.ArreglarImportes(Importe) + "' AS Base, 1 AS IdIVA, 0 as IVA;";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlIVA);

            String sqlLiq = "INSERT INTO com_opdetliquidacion (IdOp, IdLiquidacion, Porcentaje, Importe) SELECT " + nuevaOP + " AS op, " + idLiquidacion + " As IdLiquidacion, 1 as Porcentaje, '" + FuncionesGenerales.ArreglarImportes(Importe) + "' as importe;";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlLiq);

            String sqlReglas = "SELECT com_repartos.IdDivision, com_repartos.Act, com_comuneros.IdEntidad, com_detrepartos.Porcentaje, com_detrepartos.ImporteFijo FROM (com_detrepartos INNER JOIN com_repartos ON com_detrepartos.IdReparto = com_repartos.IdReparto) INNER JOIN com_comuneros ON com_detrepartos.IdComunero = com_comuneros.IdComunero WHERE (((com_repartos.IdDivision)=" + idDivision + ") AND ((com_repartos.idtipocuota)=1) AND ((com_repartos.Act)=-1));";
            DataTable reglas = Persistencia.SentenciasSQL.select(sqlReglas);

            String varEnt;
            String varImp;
            Double varImpPte;
            Double varImpAsig = 0.00;

            if (Convert.ToDouble(Importe) < 0 || reglas.Rows.Count < 1)
            {
                varEnt = idEntidad;
                varImp = Importe;
                String sqlidReciboNuevo;
                int idReciboNuevo;


                String sqlDetOp = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + nuevaOP + "," + idEntidad + ",'" + fecha + "','" + fecha + "'," + FuncionesGenerales.ArreglarImportes(Importe) + "," + FuncionesGenerales.ArreglarImportes(Importe) + ")";
                int nuevoIdOpDet = Persistencia.SentenciasSQL.InsertarGenericoID(sqlDetOp);

                String idCC = "SELECT IdCC FROM com_comuneros WHERE IdComunidad = " + idComunidad + " and IdEntidad = " + idEntidad + " and IdFormaPago = 2";
                DataTable cuentas = Persistencia.SentenciasSQL.select(idCC);

                if (cuentas.Rows.Count > 0)
                {
                    idCC = cuentas.Rows[0][0].ToString();
                    sqlidReciboNuevo = "INSERT INTO com_recibos (IdComunidad, IdEntidad, Fecha, ImpRbo, ImpRboPte, Referencia,IdCC,IdOpCrea) VALUES (" + idComunidad + "," + idEntidad + ",'" + fecha + "'," + FuncionesGenerales.ArreglarImportes(Importe) + "," + FuncionesGenerales.ArreglarImportes(Importe) + ",'" + txtdescripcion + "'," + idCC + "," + Op_Crea + ")";
                    idReciboNuevo = Persistencia.SentenciasSQL.InsertarGenericoID(sqlidReciboNuevo);
                }
                else
                {
                    idReciboNuevo = FuncionesTesoreria.CreoReciboID(idComunidad, idEntidad, fecha, FuncionesGenerales.ArreglarImportes(Importe), FuncionesGenerales.ArreglarImportes(Importe), txtdescripcion);

                }
                FuncionesTesoreria.ActualizoIdReciboVencimiento(idReciboNuevo.ToString(), nuevoIdOpDet.ToString());

            }
            else
            {
                varImpPte = Convert.ToDouble(Importe);
                for (int a = 0; a < reglas.Rows.Count; a++)
                {
                    varEnt = idEntidad;
                    if (Convert.ToDouble(reglas.Rows[a][4].ToString()) == 0)
                    {
                        varImpAsig = Math.Round(Convert.ToDouble(Importe) * Convert.ToDouble(reglas.Rows[a][3].ToString()));
                        varImpPte = varImpPte - varImpAsig;
                    }
                    else
                    {
                        varImpAsig = Convert.ToDouble(reglas.Rows[a][4].ToString());
                        varImpPte = varImpPte - varImpAsig;
                    }
                    //CREO OPDETALLES
                    String sqlDetOp = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + nuevaOP + "," + idEntidad + ",'" + fecha + "','" + fecha + "'," + varImpAsig.ToString().Replace(",", ".") + "," + varImpAsig.ToString().Replace(",", ".") + ")";
                    int nuevoIdOpDet = Persistencia.SentenciasSQL.InsertarGenericoID(sqlDetOp);

                    //CREO EL RECIBO
                    String idCC = (Persistencia.SentenciasSQL.select("SELECT IdCC FROM com_comuneros WHERE IdComunidad = " + idComunidad + " and IdEntidad = " + idEntidad + " and IdFormaPago = 2")).Rows[0][0].ToString();
                    String idReciboNuevo = "INSERT INTO com_recibos (IdComunidad, IdEntidad, Fecha, ImpRbo, ImpRboPte, Referencia,IdCC,IdOpCrea) VALUES (" + idComunidad + "," + idEntidad + ",'" + fecha + "'," + FuncionesGenerales.ArreglarImportes(Importe) + "," + FuncionesGenerales.ArreglarImportes(Importe) + ",'" + txtdescripcion + "'," + idCC + "," + Op_Crea + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(idReciboNuevo);
                    //ACTUALIZO EL ID
                    FuncionesTesoreria.ActualizoIdReciboVencimiento(idReciboNuevo, nuevoIdOpDet.ToString());
                }

                if (varImpPte > 0)
                {
                    String sqlDetOp = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe,ImpOpDetPte) VALUES (" + nuevaOP + "," + idEntidad + ",'" + fecha + "','" + fecha + "'," + varImpAsig.ToString().Replace(",", ".") + "," + varImpAsig.ToString().Replace(",", ".") + ")";
                    int nuevoIdOpDet = Persistencia.SentenciasSQL.InsertarGenericoID(sqlDetOp);

                    //CREO EL RECIBO
                    String idCC = (Persistencia.SentenciasSQL.select("SELECT IdCC FROM com_comuneros WHERE IdComunidad = " + idComunidad + " and IdEntidad = " + idEntidad + " and IdFormaPago = 2")).Rows[0][0].ToString();
                    String idReciboNuevo = "INSERT INTO com_recibos (IdComunidad, IdEntidad, Fecha, ImpRbo, ImpRboPte, Referencia,IdCC,IdOpCrea) VALUES (" + idComunidad + "," + idEntidad + ",'" + fecha + "'," + FuncionesGenerales.ArreglarImportes(Importe) + "," + FuncionesGenerales.ArreglarImportes(Importe) + ",'" + txtdescripcion + "'," + idCC + "," + Op_Crea + ")";
                    Persistencia.SentenciasSQL.InsertarGenerico(idReciboNuevo);

                    //ACTUALIZO EL VENCIMIENTO
                    FuncionesTesoreria.ActualizoIdReciboVencimiento(idReciboNuevo, nuevoIdOpDet.ToString());
                }
            }
        }
        public static void BorrarRecibo(String idRecibo)
        {
            Persistencia.SentenciasSQL.InsertarGenerico("DELETE FROM com_recibos WHERE IdRecibo = " + idRecibo);
        }
        public static void BorrarOperacion(String idOperacion)
        {
            Persistencia.SentenciasSQL.InsertarGenerico("DELETE FROM com_operaciones WHERE IdOp =  " + idOperacion);
        }
        public static void BorrarMovDevol(String idMovimiento)
        {
            String sqlActMovs, sqlBorraDets, sqlBorraMov;

            sqlActMovs = "UPDATE com_movimientos SET com_movimientos.MovDevol = Null WHERE com_movimientos.MovDevol =" + idMovimiento + ";";
            //Borrar los detalles
            sqlBorraDets = "DELETE FROM com_detmovs WHERE com_detmovs.IdMov =" + idMovimiento + ";";
            Persistencia.SentenciasSQL.InsertarGenerico(sqlBorraDets);

            sqlBorraMov = "DELETE FROM com_movimientos WHERE com_movimientos.IdMov =" + idMovimiento + ";";

            Persistencia.SentenciasSQL.InsertarGenerico(sqlActMovs);

            Persistencia.SentenciasSQL.InsertarGenerico(sqlBorraMov);
        }
        public static void EntradaAbonoRemesa(String idMovimiento, String idEjercicio, String idCuenta, String idEntidad, String fecha, String importe, String detalle, String idUser)
        {
            String IdOpDet = "";
            String fechaHoy = (Convert.ToDateTime(DateTime.Now)).ToString("yyyy-MM-dd");

            String sqlidOpDet = "SELECT IdOpDet FROM com_detmovs WHERE IdMov = " + idMovimiento;
            DataTable IdOpDetTodos = Persistencia.SentenciasSQL.select(sqlidOpDet);
            if (IdOpDetTodos.Rows.Count > 0)
            {
                IdOpDet = IdOpDetTodos.Rows[0][0].ToString();
            }

            String sqlInsert = "INSERT INTO com_movimientos (IdEjercicio, IdCuenta, IdDetTipoMov, IdEntidad, Fecha, Importe, Detalle, Fuser, IdUser, ImpMovEnt, ImpMovSal, ImpMovNeto) VALUES (" + idEjercicio + ", " + idCuenta + ",6," + idEntidad + ",'" + fecha + "'," + (Convert.ToDouble(importe) * -1).ToString().Replace(",", ".") + ",'" + detalle + "','" + fechaHoy + "'," + idUser + ",0.00,0.00,0.00)";

            int idMov = Persistencia.SentenciasSQL.InsertarGenericoID(sqlInsert);

            CreaDetalleMovimiento(idMov.ToString(), IdOpDet, (Convert.ToDouble(importe) * -1).ToString().Replace(",", "."));
        }
    }
}
