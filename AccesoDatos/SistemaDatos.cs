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
    ///Clase para administrar las consultas sql para la entidad de Sistema
    /// </summary>
    public class SistemaDatos
    {
        private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Priscilla Mena
        /// 28/03/2018
        /// Efecto: Retorna entidad sistema para obtener el id de Unidad de puentes,
        /// Laboratorio de ensayos o Laboratorio de fuerza según sea el caso
        /// Requiere: nombre del sistema
        /// Modifica: -
        /// Devuelve:  devuelve el objeto sistema
        /// </summary>
        /// <param name="nombreSistema"></param>
        /// <returns></returns>
        public Sistema getSistema(String nombreSistema)
        {
            Sistema sistemaSalida = new Sistema();
            SqlConnection connection = conexion.conexionLMD();

            String consulta
                = @"SELECT id_sistema,nombre_sistema FROM Sistema WHERE nombre_sistema =@nombreSistema";

            SqlCommand command = new SqlCommand(consulta, connection);
            command.Parameters.AddWithValue("@nombreSistema", nombreSistema);

            SqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();

            if (reader.Read())
            {
                sistemaSalida.idSistema = Convert.ToInt32(reader["id_sistema"].ToString());
                sistemaSalida.nombre = reader["nombre_sistema"].ToString();
            }

            connection.Close();

            return sistemaSalida;
        }
    }
}
