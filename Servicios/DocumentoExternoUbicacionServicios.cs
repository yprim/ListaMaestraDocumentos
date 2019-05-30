using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class DocumentoExternoUbicacionServicios
    {
        #region variables
        private DocumentoExternoUbicacionDatos documentoExternoUbicacionDatos = new DocumentoExternoUbicacionDatos();
        #endregion

        #region servicios
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
            documentoExternoUbicacionDatos.insertarDocumentoExternoUbicacion(documentoExterno, ubicacion);
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
            documentoExternoUbicacionDatos.eliminarDocumentoExternoUbicacion(documentoExterno, ubicacion);
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
            return documentoExternoUbicacionDatos.ubicacionAsociadaADocumentoExterno(documentoExterno, ubicacion);
        }

        #endregion
    }
}
