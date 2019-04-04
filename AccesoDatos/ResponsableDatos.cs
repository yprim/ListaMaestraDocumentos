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
    ///04/04/2019
    ///Clase para administrar las consultas sql para la entidad de Responsable
    /// </summary>
    public class ResponsableDatos
    {
        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Priscilla Mena Monge
        ///04/04/2019
        /// Efecto: devuelve una lista con todos los Responsables
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Responsables
        /// </summary>
        /// <returns></returns>
        public List<Responsable> getResponsables()
        {

            List<Responsable> listaResponsables = new List<Responsable>();

            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("select r.* from  Responsable r order by nombre_responsable;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Responsable responsable = new Responsable();

                responsable.idResponsable = Convert.ToInt32(reader["id_responsable"].ToString());
                responsable.nombre = reader["nombre_responsable"].ToString();

                listaResponsables.Add(responsable);
            }

            sqlConnection.Close();

            return listaResponsables;
        }

        /// <summary>
        /// Priscilla Mena Monge
        ///04/04/2019
        /// Efecto: inserta en la base de datos un responsable
        /// Requiere: responsable
        /// Modifica: -
        /// Devuelve: id del responsable insertado
        /// </summary>
        /// <param name="responsable"></param>
        /// <returns></returns>
        public int insertarResponsable(Responsable responsable)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand(@"insert into responsable(nombre_responsable)
                                                    values(@nombre_responsable);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre_responsable", responsable.nombre);


            sqlConnection.Open();
            int idResponsable = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idResponsable;
        }

        /// <summary>
        /// Priscilla Mena Monge
        ///04/04/2019
        /// Efecto: actualiza un responsable
        /// Requiere: responsable a modificar
        /// Modifica: responsable
        /// Devuelve: -
        /// </summary>
        /// <param name="responsable"></param>
        public void actualizarResponsable(Responsable responsable)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("Update responsable " +
                                                    "set nombre_responsable = @nombre_responsable " +
                                                    "where id_responsable = @id_responsable;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_responsable", responsable.idResponsable);
            sqlCommand.Parameters.AddWithValue("@nombre_responsable", responsable.nombre);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }


        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: Elimina un responsable 
        /// Requiere: responsable
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="responsable"></param>
        public void eliminarResponsable(Responsable responsable)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("Delete responsable " +
                                               "where id_responsable = @id_responsable;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_responsable", responsable.idResponsable);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }
        #endregion
    }
}
