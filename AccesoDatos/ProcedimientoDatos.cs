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
    ///22/04/2019
    ///Clase para administrar las consultas sql para la entidad de Procedimiento
    /// </summary>
    public class ProcedimientoDatos
    {

        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas

        /// <summary>
        /// Priscilla Mena Monge
        ///04/04/2019
        /// Efecto: devuelve una lista con todos los Procedimientos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Procedimientos
        /// </summary>
        /// <returns></returns>
        public List<Procedimiento> getProcedimientos()
        {

            List<Procedimiento> listaProcedimientos = new List<Procedimiento>();

            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("select r.* from  Procedimiento r order by nombre_responsable;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Procedimiento procedimiento = new Procedimiento();

                procedimiento.idProcedimiento = Convert.ToInt32(reader["id_responsable"].ToString());
                procedimiento.nombre = reader["nombre_responsable"].ToString();

                listaProcedimientos.Add(procedimiento);
            }

            sqlConnection.Close();

            return listaProcedimientos;
        }

        #endregion
    }
}
