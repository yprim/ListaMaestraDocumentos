using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class AprobadorServicios
    {
        #region variables
        AprobadorDatos aprobadorDatos = new AprobadorDatos();
        #endregion

        #region servicios
        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: devuelve una lista con todos los Aprobadores
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Aprobadores
        /// </summary>
        /// <returns></returns>
        public List<Aprobador> getAprobadores()
        {

                return aprobadorDatos.getAprobadores();
        }

        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: inserta en la base de datos un aprobador
        /// Requiere: aprobador
        /// Modifica: inserta un aprobador en la base de datos
        /// Devuelve: id del aprobador insertado
        /// </summary>
        /// <param name="aprobador"></param>
        /// <returns></returns>
        public int insertarAprobador(Aprobador aprobador)
        {

            return aprobadorDatos.insertarAprobador(aprobador);
        }

        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: actualiza un aprobador
        /// Requiere: aprobador a modificar
        /// Modifica: actualiza un aprobador de la base de datos
        /// Devuelve: -
        /// </summary>
        /// <param name="aprobador"></param>
        public void actualizarAprobador(Aprobador aprobador)
        {

            aprobadorDatos.actualizarAprobador(aprobador);
        }


        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: Elimina un aprobador 
        /// Requiere: aprobador
        /// Modifica: elimina un aprobador de la Base de datos
        /// Devuelve: -
        /// </summary>
        /// <param name="aprobador"></param>
        public void eliminarAprobador(Aprobador aprobador)
        {

            aprobadorDatos.eliminarAprobador(aprobador);
        }
        #endregion



    }
}
