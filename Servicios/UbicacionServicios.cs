using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    /// <summary>
    /// Priscilla Mena Monge
    ///22/04/2019
    ///Clase para administrar los servicios para la entidad Ubicacion
    /// </summary>
    public class UbicacionServicios
    {
        #region variables
        UbicacionDatos ubicacionDatos = new UbicacionDatos();
        #endregion

        #region servicios
        /// <summary>
        /// Priscilla Mena Monge
        ///22/04/2019
        /// Efecto: devuelve una lista con todas las Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Ubicaciones
        /// </summary>
        /// <returns></returns>
        public List<Ubicacion> getUbicaciones()
        {
          return ubicacionDatos.getUbicaciones();
        }

        /// <summary>
        /// Priscilla Mena Monge
        ///22/04/2019
        /// Efecto: inserta en la base de datos una ubicacion
        /// Requiere: ubicacion
        /// Modifica: -
        /// Devuelve: id del ubicacion insertado
        /// </summary>
        /// <param name="ubicacion"></param>
        /// <returns></returns>
        public int insertarUbicacion(Ubicacion ubicacion)
        {
            return ubicacionDatos.insertarUbicacion(ubicacion);
        }

        /// <summary>
        /// Priscilla Mena Monge
        ///22/04/2019
        /// Efecto: actualiza una ubicacion
        /// Requiere: ubicacion a modificar
        /// Modifica: ubicacion
        /// Devuelve: -
        /// </summary>
        /// <param name="ubicacion"></param>
        public void actualizarUbicacion(Ubicacion ubicacion)
        {
            ubicacionDatos.actualizarUbicacion(ubicacion);

        }


        /// <summary>
        /// Priscilla Mena
        ///22/04/2019
        /// Efecto: Elimina una ubicacion 
        /// Requiere: ubicacion
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="ubicacion"></param>
        public void eliminarUbicacion(Ubicacion ubicacion)
        {
            ubicacionDatos.eliminarUbicacion(ubicacion);
        }
        #endregion
    }
}
