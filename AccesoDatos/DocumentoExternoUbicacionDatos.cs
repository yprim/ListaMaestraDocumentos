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
    //////Clase para administrar consultas de ubicaciones asignadas a documentos externos
    /// </summary>
    public class DocumentoExternoUbicacionDatos
    {
        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: guarda en la base de datos una asociación entre el documento externo y la ubicación
        /// Requiere: Ubicacion, Documento Externo
        /// Modifica: inserta en la base de datos un registro de Documento_Externo_Ubicacion
        /// Devuelve: -
        /// <param name="documentoExterno"></param>
        /// <param name="ubicacion"></param>
        /// </summary>
        /// <returns></returns>
        public void insertarDocumentoExternoUbicacion(DocumentoExterno documentoExterno, Ubicacion ubicacion)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("INSERT Documento_Externo_Ubicacion (id_documento_externo, id_ubicacion) " +
                "values(@id_documento_externo,@id_ubicacion);", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_documento_externo", documentoExterno.idDocumentoExterno);
            sqlCommand.Parameters.AddWithValue("@id_ubicacion", ubicacion.idUbicacion);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }

        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: método que elimina de la base de datos una asociación entre el documento externo y la ubicación
        /// Requiere: Ubicacion, Documento Externo
        /// Modifica: elimina  en la base de datos un registro de Documento_Externo_Ubicacion
        /// Devuelve: -
        /// <param name="documentoExterno"></param>
        /// <param name="ubicacion"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarDocumentoExternoUbicacion(DocumentoExterno documentoExterno, Ubicacion ubicacion)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("DELETE Documento_Externo_Ubicacion WHERE id_documento_externo = @id_documento_externo and id_ubicacion = @id_ubicacion", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_documento_externo", documentoExterno.idDocumentoExterno);
            sqlCommand.Parameters.AddWithValue("@id_ubicacion", ubicacion.idUbicacion);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }



        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: metodo que devuelve true si existe  una asociación entre el documento externo y la ubicación
        /// Requiere: Ubicacion, Documento Externo
        /// Modifica:-
        /// Devuelve: true si existe  una asociación entre el documento externo y la ubicacióno false si no está asociado
        /// <param name="documentoExterno"></param>
        /// <param name="ubicacion"></param>
        /// </summary>
        /// <returns></returns>
        public Boolean ubicacionAsociadaADocumentoExterno(DocumentoExterno documentoExterno, Ubicacion ubicacion)
        {
            Boolean existe = false;

            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand(@"select D.id_documento_externo from Documento_Externo_Ubicacion D 
            where D.id_documento_externo = @id_documento_externo and D.id_ubicacion = @id_ubicacion;", sqlConnection);


            sqlCommand.Parameters.AddWithValue("@id_documento_externo", documentoExterno.idDocumentoExterno);
            sqlCommand.Parameters.AddWithValue("@id_ubicacion", ubicacion.idUbicacion);

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
