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
    ///Clase para administrar consultas de Autores de documentos externos
    /// </summary>
    public class DocumentoExternoAutorDatos
    {
        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Priscilla Mena
        /// 30/05/2019
        /// Efecto: guarda en la base de datos una asociación entre el documento externo y autor
        /// Requiere: Autor, Documento Externo
        /// Modifica: inserta en la base de datos un registro de Documento_Externo_Autor
        /// Devuelve: -
        /// <param name="documentoExterno"></param>
        /// <param name="autor"></param>
        /// </summary>
        /// <returns></returns>
        public void insertarDocumentoExternoAutor(DocumentoExterno documentoExterno, Autor autor)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("INSERT Documento_Externo_Autor (id_documento_externo, id_autor) " +
                "values(@id_documento_externo,@id_autor);", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_documento_externo", documentoExterno.idDocumentoExterno);
            sqlCommand.Parameters.AddWithValue("@id_autor", autor.idAutor);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }

        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: método que elimina de la base de datos una asociación entre el documento externo y autor
        /// Requiere: Autor, Documento Externo
        /// Modifica: elimina  en la base de datos un registro de Documento_Externo_Autor
        /// Devuelve: -
        /// <param name="documentoExterno"></param>
        /// <param name="autor"></param>
        /// </summary>
        /// <returns></returns>
        public void eliminarDocumentoExternoAutor(DocumentoExterno documentoExterno, Autor autor)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("DELETE Documento_Externo_Autor WHERE id_documento_externo = @id_documento_externo and id_autor = @id_autor", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_documento_externo", documentoExterno.idDocumentoExterno);
            sqlCommand.Parameters.AddWithValue("@id_autor", autor.idAutor);
            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }



        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: metodo que devuelve true si existe  una asociación entre el documento externo y el autor
        /// Requiere: Autor, Documento Externo
        /// Modifica:-
        /// Devuelve: true si existe  una asociación entre el documento externo y la ubicacióno false si no está asociado
        /// <param name="documentoExterno"></param>
        /// <param name="autor"></param>
        /// </summary>
        /// <returns></returns>
        public Boolean autorAsociadoADocumentoExterno(DocumentoExterno documentoExterno, Autor autor)
        {
            Boolean existe = false;

            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("select D.id_documento_externo" +
                "from Documento_Externo_Autor D " +
                "where D.id_documento_externo = @id_documento_externo and D.id_autor = @id_autor;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_documento_externo", documentoExterno.idDocumentoExterno);
            sqlCommand.Parameters.AddWithValue("@id_autor", autor.idAutor);

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
