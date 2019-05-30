using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
   public class DocumentoExternoAutorServicios
    {
        #region variables
        private DocumentoExternoAutorDatos documentoExternoAutorDatos = new DocumentoExternoAutorDatos();
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
            documentoExternoAutorDatos.insertarDocumentoExternoAutor(documentoExterno, autor);
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
            documentoExternoAutorDatos.eliminarDocumentoExternoAutor(documentoExterno, autor);
        }



        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: metodo que devuelve true si existe  una asociación entre el documento externo y la ubicación
        /// Requiere: Autor, Documento Externo
        /// Modifica:-
        /// Devuelve: true si existe  una asociación entre el documento externo y la ubicacióno false si no está asociado
        /// <param name="documentoExterno"></param>
        /// <param name="autor"></param>
        /// </summary>
        /// <returns></returns>
        public Boolean autorAsociadoADocumentoExterno(DocumentoExterno documentoExterno, Autor autor)
        {
         
            return documentoExternoAutorDatos.autorAsociadoADocumentoExterno(documentoExterno,autor);
        }

        #endregion
    }
}
