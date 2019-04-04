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
    ///Clase para administrar las consultas sql para la entidad de Aprobador
    /// </summary>
    public class AprobadorDatos
    {
        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Priscilla Mena Monge
        ///04/04/2019
        /// Efecto: devuelve una lista con todos los Aprobadores
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Aprobadores
        /// </summary>
        /// <returns></returns>
        public List<Aprobador> getAprobadores()
        {

            List<Aprobador> listaAprobadores = new List<Aprobador>();

            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("select a.* from  Aprobador a order by nombre_aprobador;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Aprobador aprobador = new Aprobador();

                aprobador.idAprobador = Convert.ToInt32(reader["id_aprobador"].ToString());
                aprobador.nombre = reader["nombre_aprobador"].ToString();

                listaAprobadores.Add(aprobador);
            }

            sqlConnection.Close();

            return listaAprobadores;
        }

        /// <summary>
        /// Priscilla Mena Monge
        ///04/04/2019
        /// Efecto: inserta en la base de datos un aprobador
        /// Requiere: aprobador
        /// Modifica: -
        /// Devuelve: id del aprobador insertado
        /// </summary>
        /// <param name="aprobador"></param>
        /// <returns></returns>
        public int insertarAprobador(Aprobador aprobador)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand(@"insert into aprobador(nombre_aprobador)
                                                    values(@nombre_aprobador);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre_aprobador", aprobador.nombre);


            sqlConnection.Open();
            int idAprobador = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idAprobador;
        }

        /// <summary>
        /// Priscilla Mena Monge
        ///04/04/2019
        /// Efecto: actualiza un aprobador
        /// Requiere: aprobador a modificar
        /// Modifica: aprobador
        /// Devuelve: -
        /// </summary>
        /// <param name="aprobador"></param>
        public void actualizarAprobador(Aprobador aprobador)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("Update aprobador " +
                                                    "set nombre_aprobador = @nombre_aprobador " +
                                                    "where id_aprobador = @id_aprobador;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_aprobador", aprobador.idAprobador);
            sqlCommand.Parameters.AddWithValue("@nombre_aprobador", aprobador.nombre);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }


        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: Elimina un aprobador 
        /// Requiere: aprobador
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="aprobador"></param>
        public void eliminarAprobador(Aprobador aprobador)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("Delete aprobador " +
                                               "where id_aprobador = @id_aprobador;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_aprobador", aprobador.idAprobador);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }
        #endregion
    }
}
