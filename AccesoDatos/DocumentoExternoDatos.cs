using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
   public class DocumentoExternoDatos
    {
        #region variables
        private ConexionDatos conexion = new ConexionDatos();
        #endregion

        #region consultas

        /// <summary>
        /// Priscilla Mena Monge
        ///29/04/2019
        /// Efecto: devuelve una lista con todos los Documentos Externos que están asignados a la opcion de sistema que está utilizando
        /// Requiere: idDistema esto puede ser el sistema para laboratorio de ensayos, unidad de puentes o laboratorio de fuerza
        /// Modifica: -
        /// Devuelve: lista de Documentos Externos
        /// </summary>
        /// <returns></returns>
        public List<DocumentoExterno> getDocumentosExternos(int idSistema)
        {

            List<DocumentoExterno> listaDocumentosExternos = new List<DocumentoExterno>();

            SqlConnection sqlConnexion = conexion.conexionLMD();

            String consulta = @"SELECT d.id_documento_externo
                                  ,d.id_sistema
                                  ,d.nombre_documento_externo
                                  ,d.anno_emision
                                  ,d.version
                                  ,d.presentacion
                                  ,d.activo
                                  ,s.id_sistema
                                  ,s.nombre_sistema
                              FROM Documento_Externo d, Sistema s
                              WHERE d.id_sistema=s.id_sistema and s.id_sistema=@id_sistema";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnexion);
            sqlCommand.Parameters.AddWithValue("@id_sistema", idSistema);

            SqlDataReader reader;
            sqlConnexion.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                DocumentoExterno documentoExterno = new DocumentoExterno();
                Sistema sistema = new Sistema();

                //recupera documentoExterno
                documentoExterno.idDocumentoExterno = Convert.ToInt32(reader["id_documento_externo"].ToString());
                documentoExterno.nombreDocumento = reader["nombre_documento_externo"].ToString();
                documentoExterno.annoEmision = reader["anno_emision"].ToString();
                documentoExterno.version = reader["version"].ToString();
                documentoExterno.activo = reader["activo"].ToString();


                //recupera sistema
                sistema.idSistema = Convert.ToInt32(reader["id_sistema"].ToString());
                sistema.nombre = reader["nombre_sistema"].ToString();
                documentoExterno.sistema = sistema;

                listaDocumentosExternos.Add(documentoExterno);

            }

            sqlConnexion.Close();

            return listaDocumentosExternos;
        }

        #endregion

    }
}
