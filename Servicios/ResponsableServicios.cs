using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ResponsableServicios
    {
        #region variables
        ResponsableDatos responsableDatos = new ResponsableDatos();
        #endregion

        #region servicios
        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: devuelve una lista con todos los Responsables
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Responsables
        /// </summary>
        /// <returns></returns>
        public List<Responsable> getResponsables()
        {

            return responsableDatos.getResponsables();
        }

        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: inserta en la base de datos un responsable
        /// Requiere: responsable
        /// Modifica: inserta un responsable en la base de datos
        /// Devuelve: id del responsable insertado
        /// </summary>
        /// <param name="responsable"></param>
        /// <returns></returns>
        public int insertarResponsable(Responsable responsable)
        {

            return responsableDatos.insertarResponsable(responsable);
        }

        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: actualiza un responsable
        /// Requiere: responsable a modificar
        /// Modifica: actualiza un responsable de la base de datos
        /// Devuelve: -
        /// </summary>
        /// <param name="responsable"></param>
        public void actualizarResponsable(Responsable responsable)
        {

            responsableDatos.actualizarResponsable(responsable);
        }


        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: Elimina un responsable 
        /// Requiere: responsable
        /// Modifica: elimina un responsable de la Base de datos
        /// Devuelve: -
        /// </summary>
        /// <param name="responsable"></param>
        public void eliminarResponsable(Responsable responsable)
        {

            responsableDatos.eliminarResponsable(responsable);
        }
        #endregion

    }
}
