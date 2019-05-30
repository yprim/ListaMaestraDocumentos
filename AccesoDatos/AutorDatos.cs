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
    ///Clase para administrar las consultas sql para la entidad de Autor
    /// </summary>
    public class AutorDatos
    {
        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas
        /// <summary>
        /// Priscilla Mena Monge
        ///04/04/2019
        /// Efecto: devuelve una lista con todos los Autores
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Autores
        /// </summary>
        /// <returns></returns>
        public List<Autor> getAutores()
        {

            List<Autor> listaAutores = new List<Autor>();

            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("select a.* from  Autor a order by nombre_autor;", sqlConnection);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Autor autor = new Autor();

                autor.idAutor = Convert.ToInt32(reader["id_autor"].ToString());
                autor.nombre = reader["nombre_autor"].ToString();

                listaAutores.Add(autor);
            }

            sqlConnection.Close();

            return listaAutores;
        }

        /// <summary>
        /// Priscilla Mena Monge
        ///04/04/2019
        /// Efecto: inserta en la base de datos un autor
        /// Requiere: autor
        /// Modifica: -
        /// Devuelve: id del autor insertado
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        public int insertarAutor(Autor autor)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand(@"insert into autor(nombre_autor)
                                                    values(@nombre_autor);
                                                    SELECT SCOPE_IDENTITY();", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre_autor", autor.nombre);


            sqlConnection.Open();
            int idAutor = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idAutor;
        }

        /// <summary>
        /// Priscilla Mena Monge
        ///04/04/2019
        /// Efecto: actualiza un autor
        /// Requiere: autor a modificar
        /// Modifica: autor
        /// Devuelve: -
        /// </summary>
        /// <param name="autor"></param>
        public void actualizarAutor(Autor autor)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("Update autor " +
                                                    "set nombre_autor = @nombre_autor " +
                                                    "where id_autor = @id_autor;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_autor", autor.idAutor);
            sqlCommand.Parameters.AddWithValue("@nombre_autor", autor.nombre);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }


        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: Elimina un autor 
        /// Requiere: autor
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="autor"></param>
        public void eliminarAutor(Autor autor)
        {
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand("Delete autor " +
                                               "where id_autor = @id_autor;", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_autor", autor.idAutor);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();

        }

        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: recupera todos los autores que no estan asociados al documento externo
        /// Requiere: documentoExterno
        /// Modifica: -
        /// Devuelve: lista de autores
        /// </summary>
        /// <param name="documentoExterno"></param>
        public List<Autor> getAutoresNoEstanEnDocumentoExterno(DocumentoExterno documentoExterno)
        {
            List<Autor> listaElementos = new List<Autor>();
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand(@"select A.id_autor,A.nombre_autor
               from Autor A
                 where   A.id_autor not in (select DA.id_autor 
                 from Documento_Externo_Autor DA 
                 where DA.id_documento_externo = @id_documento_externo ) 
             order by A.nombre_autor;", sqlConnection);

            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@id_documento_externo", documentoExterno.idDocumentoExterno);

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {

                Autor autor = new Autor();

                autor.idAutor = Convert.ToInt32(reader["id_autor"].ToString());
                autor.nombre = reader["nombre_autor"].ToString();
                listaElementos.Add(autor);
            }

            sqlConnection.Close();

            return listaElementos;

        }

        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: recupera todos los autores que ya están asociadas al documento externo
        /// Requiere: documentoExterno
        /// Modifica: -
        /// Devuelve: lista de autores
        /// </summary>
        /// <param name="documentoExterno"></param>
        public List<Autor> getAutoresEstanEnDocumentoExterno(DocumentoExterno documentoExterno)
        {
            List<Autor> listaAutores = new List<Autor>();
            SqlConnection sqlConnection = conexion.conexionLMD();

            SqlCommand sqlCommand = new SqlCommand(@"select A.id_autor,U.nombre_autor
               from Autor A,Documento_Externo_Autor DA 
                where DA.id_documento_externo = @id_documento_externo  and A.id_autor = DA.id_autor
                 order by A.nombre_autor;", sqlConnection);

            SqlDataReader reader;

            sqlCommand.Parameters.AddWithValue("@id_documento_externo", documentoExterno.idDocumentoExterno);

            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {

                Autor autor = new Autor();

                autor.idAutor = Convert.ToInt32(reader["id_autor"].ToString());
                autor.nombre = reader["nombre_autor"].ToString();
                listaAutores.Add(autor);
            }

            sqlConnection.Close();

            return listaAutores;

        }


        #endregion
    }
}
