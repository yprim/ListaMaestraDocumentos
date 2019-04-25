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
        ///22/04/2019
        /// Efecto: devuelve una lista con todos los Procedimientos que están asignados a la opcion de sistema que está utilizando
        /// Requiere: idDistema esto puede ser el sistema para laboratorio de ensayos, unidad de puentes o laboratorio de fuerza
        /// Modifica: -
        /// Devuelve: lista de Procedimientos
        /// </summary>
        /// <returns></returns>
        public List<Procedimiento> getProcedimientos( int idSistema)
        {

            List<Procedimiento> listaProcedimientos = new List<Procedimiento>();

            SqlConnection sqlConnexion = conexion.conexionLMD();

            String consulta = @"Select * from  Aprobador a , Responsable r ,Estado e, Procedimiento p, Sistema s
                                                    where p.id_aprobador = a.id_aprobador and
                                                    p.id_estado = e.id_estado and
                                                    p.id_responsable = r.id_responsable and
                                                     p.id_sistema = s.id_sistema
                                                     and s.id_sistema = @id_sistema";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnexion);
            sqlCommand.Parameters.AddWithValue("@id_sistema", idSistema);

            SqlDataReader reader;
            sqlConnexion.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Procedimiento procedimiento = new Procedimiento();
                Aprobador aprobador = new Aprobador();
                Responsable responsable = new Responsable();
                Estado estado = new Estado();
                Sistema sistema = new Sistema();

                //recupera procedimiento
                procedimiento.idProcedimiento = Convert.ToInt32(reader["id_procedimiento"].ToString());
                procedimiento.nombreDocumento = reader["nombre_documento_procedimiento"].ToString();
                procedimiento.codigo = reader["codigo"].ToString();
                procedimiento.acreditado = reader["acreditado"].ToString();
                procedimiento.version = reader["version"].ToString();
                procedimiento.rigeDesde = Convert.ToDateTime(reader["rige_desde"].ToString());
                procedimiento.sustituyeA= reader["sustituye_a"].ToString();
                procedimiento.distribuidoA = reader["distribuido_a"].ToString();
                procedimiento.referenciaAdicional = reader["referencia_adicional"].ToString();
                procedimiento.activo = reader["activo"].ToString();

                //recupera aprobador

                aprobador.idAprobador= Convert.ToInt32(reader["id_aprobador"].ToString());
                aprobador.nombre = reader["nombre_aprobador"].ToString();

                //recupera responsable
                responsable.idResponsable= Convert.ToInt32(reader["id_responsable"].ToString());
                responsable.nombre = reader["nombre_responsable"].ToString();

                //recupera estado
                estado.idEstado= Convert.ToInt32(reader["id_estado"].ToString());
                estado.nombre = reader["nombre_estado"].ToString();

                //recupera sistema
                sistema.idSistema= Convert.ToInt32(reader["id_sistema"].ToString());
                sistema.nombre = reader["nombre_sistema"].ToString();
                procedimiento.aprobador = aprobador;
                procedimiento.responsable = responsable;
                procedimiento.estado = estado;
                procedimiento.sistema = sistema;
          
                listaProcedimientos.Add(procedimiento);

            }

            sqlConnexion.Close();

            return listaProcedimientos;
        }

        /// <summary>
        /// Priscilla Mena
        /// 25/04/2019
        /// Efecto: Inserta un procedimiento en la base de datos
        /// Requiere: Procedimiento 
        /// Modifica: Procedimientos
        /// Devuelve: idProcedimiento insertado
        /// </summary>
        /// <param name="procedimiento"></param>
        /// <returns>idProcedimiento</returns>
        public int insertarProcedimiento(Procedimiento procedimiento)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            string consulta = @"INSERT INTO Procedimiento
           (nombre_documento_procedimiento ,codigo ,acreditado,version ,rige_desde,id_aprobador ,sustituye_a,distribuido_a,referencia_adicional
           ,id_responsable,id_estado,id_sistema,activo)
            VALUES
           (@nombre_documento_procedimiento,
           @codigo, 
           @acreditado, 
           @version, 
           @rige_desde,
           @id_aprobador,
           @sustituye_a, 
           @distribuido_a, 
           @referencia_adicional, 
           @id_responsable,
           @id_estado,
           @id_sistema,
           @activo);
            SELECT SCOPE_IDENTITY();";


            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
       
            sqlCommand.Parameters.AddWithValue("@nombre_documento_procedimiento", procedimiento.nombreDocumento);
            sqlCommand.Parameters.AddWithValue("@codigo", procedimiento.codigo);
            sqlCommand.Parameters.AddWithValue("@acreditado", procedimiento.acreditado);
            sqlCommand.Parameters.AddWithValue("@version", procedimiento.version);
            sqlCommand.Parameters.AddWithValue("@rige_desde", procedimiento.rigeDesde);
            sqlCommand.Parameters.AddWithValue("@distribuido_a", procedimiento.distribuidoA);
            sqlCommand.Parameters.AddWithValue("@sustituye_a", procedimiento.sustituyeA);
            sqlCommand.Parameters.AddWithValue("@referencia_adicional", procedimiento.referenciaAdicional);
            sqlCommand.Parameters.AddWithValue("@id_responsable", procedimiento.responsable.idResponsable);
            sqlCommand.Parameters.AddWithValue("@id_estado", procedimiento.estado.idEstado);
            sqlCommand.Parameters.AddWithValue("@id_aprobador", procedimiento.aprobador.idAprobador);
            sqlCommand.Parameters.AddWithValue("@id_sistema", procedimiento.sistema.idSistema);
            sqlCommand.Parameters.AddWithValue("@activo", procedimiento.activo);

            sqlConnection.Open();


            int idProcedimiento = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idProcedimiento;
        }



        #endregion
    }
}
