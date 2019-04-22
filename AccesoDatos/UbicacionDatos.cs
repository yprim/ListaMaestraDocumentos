using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    /// <summary>
    /// Priscilla Mena Monge
    ///08/04/2019
    ///Clase para administrar las consultas sql para la entidad de Ubicacion
    /// </summary>
    public class UbicacionDatos
    {
        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Priscilla Mena Monge
        ///08/04/2019
        /// Efecto: devuelve una lista con todos los Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Ubicaciones
        /// </summary>
        /// <returns></returns>
        public List<Ubicacion> getUbicaciones()
        {

            List<Ubicacion> listaUbicaciones = new List<Ubicacion>();

            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("select u.* from  Ubicacion u order by nombre_ubicacion;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Ubicacion ubicacion = new Ubicacion();

                ubicacion.idUbicacion = Convert.ToInt32(reader["id_ubicacion"].ToString());
                ubicacion.nombre = reader["nombre_ubicacion"].ToString();

                listaUbicaciones.Add(ubicacion);
            }

            sqlConnection.Close();

            return listaUbicaciones;
        }

        /// <summary>
        /// Priscilla Mena Monge
        ///08/04/2019
        /// Efecto: inserta en la base de datos una ubicacion
        /// Requiere: ubicacion
        /// Modifica: -
        /// Devuelve: id del ubicacion insertado
        /// </summary>
        /// <param name="ubicacion"></param>
        /// <returns></returns>
        public int insertarUbicacion(Ubicacion ubicacion)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand(@"insert into ubicacion(nombre_ubicacion)
                                                    values(@nombre_ubicacion);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre_ubicacion", ubicacion.nombre);


            sqlConnection.Open();
            int idUbicacion = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idUbicacion;
        }

        /// <summary>
        /// Priscilla Mena Monge
        ///08/04/2019
        /// Efecto: actualiza una ubicacion
        /// Requiere: ubicacion a modificar
        /// Modifica: ubicacion
        /// Devuelve: -
        /// </summary>
        /// <param name="ubicacion"></param>
        public void actualizarUbicacion(Ubicacion ubicacion)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("Update ubicacion " +
                                                    "set nombre_ubicacion = @nombre_ubicacion " +
                                                    "where id_ubicacion = @id_ubicacion;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_ubicacion", ubicacion.idUbicacion);
            sqlCommand.Parameters.AddWithValue("@nombre_ubicacion", ubicacion.nombre);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }


        /// <summary>
        /// Priscilla Mena
        ///08/04/2019
        /// Efecto: Elimina una ubicacion 
        /// Requiere: ubicacion
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="ubicacion"></param>
        public void eliminarUbicacion(Ubicacion ubicacion)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("Delete ubicacion " +
                                               "where id_ubicacion = @id_ubicacion;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_ubicacion", ubicacion.idUbicacion);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }
        #endregion
    }
}
