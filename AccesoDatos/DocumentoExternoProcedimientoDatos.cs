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
    /// 24/05/2019
    //////Clase para administrar consultas de Procedimientos de documentos externos
    /// </summary>
    public class DocumentoExternoProcedimientoDatos
    {
        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Priscilla Mena
        /// 30/05/2019
        /// Efecto: guarda en la base de datos una asociación entre el documento externo y procedimiento
        /// Requiere: Procedimiento, Documento Externo
        /// Modifica: inserta en la base de datos un registro de Documento_Externo_Procedimiento
        /// Devuelve: -
        /// <param name="documentoExterno"></param>
        /// <param name="procedimiento"></param>
        /// </summary>
        /// <returns></returns>
        public void insertarDocumentoExternoProcedimiento(DocumentoExterno documentoExterno, Procedimiento procedimiento)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("INSERT Documento_Externo_Procedimiento (id_documento_externo, id_procedimiento) " +
                "values(@id_documento_externo,@id_procedimiento);", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_documento_externo", documentoExterno.idDocumentoExterno);
            sqlCommand.Parameters.AddWithValue("@id_procedimiento", procedimiento.idProcedimiento);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }

        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: método que elimina de la base de datos una asociación entre el documento externo y procedimiento
        /// Requiere: Procedimiento, Documento Externo
        /// Modifica: elimina  en la base de datos un registro de Documento_Externo_Procedimiento
        /// Devuelve: -
        /// <param name="documentoExterno"></param>
        /// <param name="procedimiento"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarDocumentoExternoProcedimiento(DocumentoExterno documentoExterno, Procedimiento procedimiento)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("DELETE Documento_Externo_Procedimiento WHERE id_documento_externo = @id_documento_externo and id_procedimiento = @id_procedimiento", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_documento_externo", documentoExterno.idDocumentoExterno);
            sqlCommand.Parameters.AddWithValue("@id_procedimiento", procedimiento.idProcedimiento);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }



        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: metodo que devuelve true si existe  una asociación entre el documento externo y el procedimiento
        /// Requiere: Procedimiento, Documento Externo
        /// Modifica:-
        /// Devuelve: true si existe  una asociación entre el documento externo y la ubicacióno false si no está asociado
        /// <param name="documentoExterno"></param>
        /// <param name="procedimiento"></param>
        /// </summary>
        /// <returns></returns>
        public Boolean procedimientoAsociadoADocumentoExterno(DocumentoExterno documentoExterno, Procedimiento procedimiento)
        {
            Boolean existe = false;

            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand(@"select D.id_documento_externo from Documento_Externo_Procedimiento D 
                where D.id_documento_externo = @id_documento_externo and D.id_procedimiento = @id_procedimiento;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_documento_externo", documentoExterno.idDocumentoExterno);
            sqlCommand.Parameters.AddWithValue("@id_procedimiento", procedimiento.idProcedimiento);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                existe = true;
            }

            sqlConnection.Close();

            return existe;
        }

       
        #endregion
    }
}
