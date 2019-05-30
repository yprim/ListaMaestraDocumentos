using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class DocumentoExternoProcedimientoServicios
    {

        #region variables
        private DocumentoExternoProcedimientoDatos documentoExternoProcedimientoDatos = new DocumentoExternoProcedimientoDatos();
        #endregion

        #region servicios
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
            documentoExternoProcedimientoDatos.insertarDocumentoExternoProcedimiento(documentoExterno, procedimiento);
          
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
            documentoExternoProcedimientoDatos.eliminarDocumentoExternoProcedimiento(documentoExterno, procedimiento);

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


            return documentoExternoProcedimientoDatos.procedimientoAsociadoADocumentoExterno(documentoExterno, procedimiento);


            #endregion
        }
}
