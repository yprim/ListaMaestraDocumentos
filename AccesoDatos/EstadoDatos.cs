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
    /// Priscilla Mena
    ///28/03/2019
    ///Clase para administrar las consultas sql para la entidad de Estado
    /// </summary>
    public class EstadoDatos
    {
        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas


        /// <summary>
        /// Priscilla Mena
        ///28/03/2019
        /// Efecto: devuelve una lista con todos los Estados
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Estados
        /// </summary>
        /// <returns></returns>
        public List<Estado> getEstados()
        {

            List<Estado> listaEstados = new List<Estado>();

            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("select e.* from  estado e order by nombre_estado;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Estado estado = new Estado();

                estado.idEstado = Convert.ToInt32(reader["id_estado"].ToString());
                estado.nombre = reader["nombre_estado"].ToString();

                listaEstados.Add(estado);
            }

            sqlConnection.Close();

            return listaEstados;
        }

        /// <summary>
        /// Priscilla Mena
        ///28/03/2019
        /// Efecto: inserta en la base de datos un estado
        /// Requiere: estado
        /// Modifica: -
        /// Devuelve: id del estado insertado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public int insertarEstado(Estado estado)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand(@"insert into estado(nombre_estado)
                                                    values(@nombre_estado);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre_estado", estado.nombre);


            sqlConnection.Open();
            int idEstado = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idEstado;
        }

        /// <summary>
        /// Priscilla Mena
        ///28/03/2019
        /// Efecto: actualiza un estado
        /// Requiere: estado a modificar
        /// Modifica: estado
        /// Devuelve: -
        /// </summary>
        /// <param name="estado"></param>
        public void actualizarEstado(Estado estado)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("Update estado " +
                                                    "set nombre_estado = @nombre_estado " +
                                                    "where id_estado = @id_estado;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_estado", estado.idEstado);
            sqlCommand.Parameters.AddWithValue("@nombre_estado", estado.nombre);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }


        /// <summary>
        /// Priscilla Mena
        ///28/03/2019
        /// Efecto: Elimina un estado 
        /// Requiere: estado
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="estado"></param>
        public void eliminarEstado(Estado estado)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("Delete estado " +
                                               "where id_estado = @id_estado;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_estado", estado.idEstado);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }
    }
    #endregion
}
