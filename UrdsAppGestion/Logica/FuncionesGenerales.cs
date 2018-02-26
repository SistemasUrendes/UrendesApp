using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrdsAppGestión.Logica
{
    public class FuncionesGenerales
    {
        //FUNCION PARA BUSCAR CON ACENTOS EN EL DATAGRID
        public static void buscarConAcentos(String texto, String campoAbuscar)
        {
            //String filtro = "";
            for (int a = 0; a < texto.Length; a++)
            {
                if (texto[a] == 'a' || texto[a] == 'e' || texto[a] == 'i' || texto[a] == 'o' || texto[a] == 'u')
                {
                    //filtro = campoAbuscar + "like '%" + 
                }
            }
        }
        public static String ArreglarImportes(String Importe) {
            if (Importe.Contains(".")) return Importe;
            else
               return Importe.Replace(',', '.');
        }
    }
}
