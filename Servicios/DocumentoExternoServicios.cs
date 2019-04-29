﻿using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class DocumentoExternoServicios
    {
        #region variables
        DocumentoExternoDatos documentoExternoDatos = new DocumentoExternoDatos();

        #endregion
        #region servicios

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
            return documentoExternoDatos.getDocumentosExternos(idSistema);
        }
        #endregion
    }
}
