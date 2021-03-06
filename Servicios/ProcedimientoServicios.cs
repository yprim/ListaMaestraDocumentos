﻿using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    /// Priscilla Mena
    /// 25/04/2019
    /// Clase para administrar los servicios de Procedimiento
    /// </summary>
    public class ProcedimientoServicios
    {
        #region variables
        ProcedimientoDatos procedimientoDatos = new ProcedimientoDatos();
        #endregion

        #region servicios

        /// <summary>
        /// Priscilla Mena Monge
        ///25/04/2019
        /// Efecto: devuelve una lista con todos los Procedimientos que están asignados a la opcion de sistema que está utilizando
        /// Requiere: idDistema esto puede ser el sistema para laboratorio de ensayos, unidad de puentes o laboratorio de fuerza
        /// Modifica: -
        /// Devuelve: lista de Procedimientos
        /// </summary>
        /// <returns></returns>
        public List<Procedimiento> getProcedimientos(int idSistema)
        {
            return procedimientoDatos.getProcedimientos(idSistema);
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
            return procedimientoDatos.insertarProcedimiento(procedimiento);
        }


        /// <summary>
        /// Priscilla Mena
        /// 30/05/2019
        /// Efecto: recupera todos los procedimientoes que no estan asociados al documento externo
        /// Requiere: documentoExterno
        /// Modifica: -
        /// Devuelve: lista de procedimientoes
        /// </summary>
        /// <param name="documentoExterno"></param>
        public List<Procedimiento> getProcedimientosNoEstanEnDocumentoExterno(DocumentoExterno documentoExterno)
        {
           

            return procedimientoDatos.getProcedimientosNoEstanEnDocumentoExterno(documentoExterno);

        }

        /// <summary>
        /// Priscilla Mena
        /// 30/05/2019
        /// Efecto: recupera todos los procedimientoes que ya están asociadas al documento externo
        /// Requiere: documentoExterno
        /// Modifica: -
        /// Devuelve: lista de procedimientoes
        /// </summary>
        /// <param name="documentoExterno"></param>
        public List<Procedimiento> getProcedimientosEstanEnDocumentoExterno(DocumentoExterno documentoExterno)
        {
           

            return procedimientoDatos.getProcedimientosEstanEnDocumentoExterno(documentoExterno);

        }
        #endregion

    }
}
