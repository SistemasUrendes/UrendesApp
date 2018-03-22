using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrdsAppGestión.Persistencia;

namespace UrdsAppGestión.Persistencia
{
    class SentenciasSQL {

        public static readonly string[] SQL = {
            //Form de Entidades.Hay más SQL dentro pero necesitan datos del formulario.
            "SELECT IdCategoria, IdGrupoCat,Descripcion FROM ctos_catentidades ORDER BY Descripcion;",

            "SELECT ctos_entidades.IDEntidad, ctos_entidades.Entidad, ctos_entidades.NombreCorto, ctos_entidades.CIF, ctos_detallecat.IdCategoria, ctos_entidades.EntidadSinAcentos FROM ctos_entidades LEFT JOIN ctos_detallecat ON ctos_entidades.IDEntidad = ctos_detallecat.IdEntidad ORDER BY ctos_entidades.Entidad;",

            "SELECT IdCategoria, IdGrupoCat,Descripcion FROM ctos_catentidades ORDER BY Descripcion;", 
            //#############################################################################

            //ctos_entidades.Entidad
            "SELECT com_comunidades.IdComunidad, com_comunidades.Referencia, ctos_entidades.NombreCorto, ctos_entidades.CIF, ctos_detdirecent.Direccion, ctos_detdirecent.CP, ctos_detdirecent.Poblacion, ctos_entidades.Ruta, ctos_urendes.IdURD, ctos_urendes_1.IdURD AS id_gestor, ctos_urendes.Usuario, ctos_urendes_1.Usuario, com_comunidades.IdEntidad, com_comunidades.FBaja, com_comunidades.IdGestor, com_comunidades.IdGestor2, com_comunidades.IdContabilidad, ctos_urendes_2.Usuario FROM ((((com_comunidades INNER JOIN ctos_entidades ON com_comunidades.IdEntidad = ctos_entidades.IDEntidad) INNER JOIN ctos_urendes ON com_comunidades.IdGestor = ctos_urendes.IdURD) INNER JOIN ctos_detdirecent ON com_comunidades.IdEntidad = ctos_detdirecent.IdEntidad) LEFT JOIN ctos_urendes AS ctos_urendes_1 ON com_comunidades.IdGestor2 = ctos_urendes_1.IdURD) LEFT JOIN ctos_urendes AS ctos_urendes_2 ON com_comunidades.IdContabilidad = ctos_urendes_2.IdURD ORDER BY com_comunidades.Referencia;"
            };

        public static DataTable select (String sql) {
            DataTable dt = null;
            try {
                //Abro la conexión con la función que se encuentra en otra clase.
                MySqlConnection conn = Persistencia.conexion_bd.abrir();
                conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];

                conn.ClearAllPoolsAsync();
                conn.Dispose();
                Persistencia.conexion_bd.cerrar(conn);

                return dt;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return dt;
            }
        }
        public static int InsertEntidad(String entidad,String nombreCorto,String CIF,String Notas, String entidad_sinAcentos) {

            MySqlConnection conn = Persistencia.conexion_bd.abrir();
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO ctos_entidades(Entidad,NombreCorto,CIF,Notas,EntidadSinAcentos) VALUES(@entidad, @NombreCorto,@CIF,@Notas,@SinAcentos)";

            comm.Parameters.AddWithValue("@entidad", entidad);
            comm.Parameters.AddWithValue("@NombreCorto", nombreCorto);
            comm.Parameters.AddWithValue("@CIF", CIF);
            comm.Parameters.AddWithValue("@Notas", Notas);
            comm.Parameters.AddWithValue("@SinAcentos", entidad_sinAcentos);
            comm.ExecuteNonQuery();

            conn.ClearAllPoolsAsync();
            conn.Dispose();
            conn.Close();

            return (int)comm.LastInsertedId;
        }

        public static void InsertRuta(String IdTipoDoc,String fecha,String GeneralComunidades, String Descripcion, String Ruta) {

            MySqlConnection conn = Persistencia.conexion_bd.abrir();
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO com_Documentos(IdTipoDocumento, FechaCreacion, GeneralComunidades, Descripcion, Ruta) VALUES(@idtipodoc, @fecha, @comunidades, @descripcion, @ruta)";

            comm.Parameters.AddWithValue("@idtipodoc", IdTipoDoc);
            comm.Parameters.AddWithValue("@fecha", fecha);
            comm.Parameters.AddWithValue("@comunidades", GeneralComunidades);
            comm.Parameters.AddWithValue("@descripcion", Descripcion);
            comm.Parameters.AddWithValue("@ruta", Ruta);
            comm.ExecuteNonQuery();

            conn.ClearAllPoolsAsync();
            conn.Dispose();
            conn.Close();
        }
        public static void InsertRuta2(String IdTipoDoc,String fecha,String IdBloque, String IdComunidad, String Descripcion, String Ruta) {

            MySqlConnection conn = Persistencia.conexion_bd.abrir();
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText =  "INSERT INTO com_Documentos (IdTipoDocumento, FechaCreacion, IdComunidad, IdBloque, Descripcion, Ruta) VALUES(@idtipodoc, @fecha,@idcomunidad,@idbloque,@descripcion, @ruta)";

            comm.Parameters.AddWithValue("@idtipodoc", IdTipoDoc);
            comm.Parameters.AddWithValue("@fecha", fecha);
            comm.Parameters.AddWithValue("@idcomunidad", IdComunidad);
            comm.Parameters.AddWithValue("@idbloque", IdBloque);
            comm.Parameters.AddWithValue("@descripcion", Descripcion);
            comm.Parameters.AddWithValue("@ruta", Ruta);
            comm.ExecuteNonQuery();

            conn.ClearAllPoolsAsync();
            conn.Dispose();
            conn.Close();
        }
        public static int InsertarGenericoID(String sql)
        {

            MySqlConnection conn = Persistencia.conexion_bd.abrir();
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = sql;

            comm.ExecuteNonQuery();

            conn.ClearAllPoolsAsync();
            conn.Dispose();
            conn.Close();

            return (int)comm.LastInsertedId;
        }
        public static Boolean ActualizarEntidad(int idEntidad,String entidad, String nombreCorto, String CIF, String Notas) {
            try
            {
                MySqlConnection conn = Persistencia.conexion_bd.abrir();
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "UPDATE ctos_entidades SET Entidad = @entidad,NombreCorto = @NombreCorto,CIF = @CIF,Notas = @Notas WHERE IDEntidad = @idEntidad";
                comm.Parameters.AddWithValue("@idEntidad", idEntidad);
                comm.Parameters.AddWithValue("@entidad", entidad);
                comm.Parameters.AddWithValue("@NombreCorto", nombreCorto);
                comm.Parameters.AddWithValue("@CIF", CIF);
                comm.Parameters.AddWithValue("@Notas", Notas);
                comm.ExecuteNonQuery();
                return true;

            }catch (Exception e) {
                MessageBox.Show("Error al actualizar Entidad" + e.Message);
                return false;
            }
        }
        public static Boolean InsertarGenerico(String sql) {
            try
            {
                MySqlConnection conn = Persistencia.conexion_bd.abrir();
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandTimeout = 0;
                comm.CommandText = sql;
                comm.ExecuteNonQuery();
                conn.ClearAllPoolsAsync();
                conn.Dispose();
                conn.Close();
                return true;
            }
            catch (Exception e) {
                MessageBox.Show("Ha habido un error al insertar en el generico" + e.Message);
                return false;
            }
        }
    }
}
