using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrdsAppGestión.Logica
{
    class FuncionesOperaciones
    {
        public static Boolean existeRecibo(String id_op)
        {
            String sqlRecibos = "SELECT com_recibos.IdRecibo FROM(com_operaciones INNER JOIN com_opdetalles ON com_operaciones.IdOp = com_opdetalles.IdOp) INNER JOIN com_recibos ON com_opdetalles.IdRecibo = com_recibos.IdRecibo WHERE(((com_operaciones.IdOp) = " + id_op + "));";
            DataTable recibo = Persistencia.SentenciasSQL.select(sqlRecibos);
            if (recibo.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean estaLiqsCerrada(String id_op)
        {
            String sqlLiqsOp = "SELECT com_opdetliquidacion.IdLiquidacion FROM com_opdetliquidacion WHERE(((com_opdetliquidacion.IdOp) = " + id_op + "));";
            DataTable liqs = Persistencia.SentenciasSQL.select(sqlLiqsOp);
            for (int a = 0; a < liqs.Rows.Count; a++)
            {
                String sqlLiqCerrada = "SELECT com_liquidaciones.IdLiquidacion FROM com_liquidaciones WHERE(((com_liquidaciones.IdLiquidacion) = " + liqs.Rows[a][0].ToString() + ") AND((com_liquidaciones.Cerrada) = -1));";
                DataTable filasLiqs = Persistencia.SentenciasSQL.select(sqlLiqCerrada);

                if (filasLiqs.Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static Boolean numMovsOp(String id_op)
        {
            String sqlNumMovs = "SELECT NumMov FROM com_operaciones WHERE(((com_operaciones.IdOp) = " + id_op + ")); ";
            DataTable numMovimientos = Persistencia.SentenciasSQL.select(sqlNumMovs);

            if (numMovimientos.Rows[0][0].ToString() != "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static String CombrobacionesBorrarOp(String idOpBorrar)
        {
            if (!estaLiqsCerrada(idOpBorrar))
            {
                if (!numMovsOp(idOpBorrar))
                {
                    if (!existeRecibo(idOpBorrar))
                    {
                        BorrarOperacion(idOpBorrar);
                        return "true";
                    }
                    else
                    {
                        return "No se puede borrar.\nExiste un recibo.";
                    }
                }
                else
                {
                    return "No se puede borrar.\nExisten o HAN HABIDO movimientos para esa Operación.";
                }
            }
            else
            {
                return "No se puede borrar.\nLa liquidación ya esta cerrada.";
            }
        }
        public static void BorrarOperacion(String id_op)  {

                String sqlDeleteLiquidacion = "DELETE FROM com_opdetliquidacion WHERE IdOp = " + id_op;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteLiquidacion);

                //BORRANDO CABECERA
                String sqlDeleteOpCabecera = "DELETE FROM com_operaciones WHERE IdOp = " + id_op;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteOpCabecera);

                String sqlDeleteIVA = "DELETE FROM com_opdetiva WHERE IdOp = " + id_op;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteIVA);

                String sqlDeleteBloques = "DELETE FROM com_opdetbloques WHERE IdOp = " + id_op;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteBloques);

                String sqlDeleteVencimiento = "DELETE FROM com_opdetalles WHERE IdOp = " + id_op;
                Persistencia.SentenciasSQL.InsertarGenerico(sqlDeleteVencimiento);
        }
    }
}
