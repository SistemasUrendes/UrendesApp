using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrdsAppGestión.Logica
{
    class FuncionesAvanzadas
    {
        public static void cambiarEntidadOperacion(String id_op) {

            ////REALIZAR EL ABONO DEL PENDIENTE A LA OPERACION PASADA
            //String sqlInsertAbono = "INSERT INTO com_opdetalles (IdOp, IdEntidad, Fecha, FechaPrev, Importe, ImpOpDetMov, ImpOpDetPte, NumMov, IdEstado) VALUES(" + id_op + "," + id_entidad + ",'" + fecha_hoy + "','" + fecha_hoy + "'," + importePte + "," + importePte + ",0,[value-8],3)";


            //CREO UNA OPERACION DE ABONO CON EL PENDIENTE DE LA OTRA Y ME GUARDO EL ID DE OPERACION.

            //CREO LA NUEVA OPERACION CON LA NUEVA ENTIDAD Y EL IMPORTE PENDIENTE
        }
    }
}
