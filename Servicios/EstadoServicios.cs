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
    /// Priscilla Mena
    /// 01/04/2019
    /// Clase para administrar los servicios de Estado
    /// </summary>
    public class EstadoServicios
    {
        #region variables
        EstadoDatos estadoDatos = new EstadoDatos();
        #endregion

        #region servicios
        /// <summary>
        /// Priscilla Mena
        /// 01/04/2019
        /// Efecto: devuelve una lista con todos los Estados
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Estados
        /// </summary>
        /// <returns></returns>
        public List<Estado> getEstados()
        {

            return estadoDatos.getEstados();
        }

        /// <summary>
        /// Priscilla Mena
        /// 01/04/2019
        /// Efecto: inserta en la base de datos un estado
        /// Requiere: estado
        /// Modifica: -
        /// Devuelve: id del estado insertado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public int insertarEstado(Estado estado)
        {
            return estadoDatos.insertarEstado(estado);
        }

        /// <summary>
        /// Priscilla Mena
        /// 01/04/2019
        /// Efecto: actualiza un estado
        /// Requiere: estado a modificar
        /// Modifica: estado
        /// Devuelve: -
        /// </summary>
        /// <param name="estado"></param>
        public void actualizarEstado(Estado estado)
        {
            estadoDatos.actualizarEstado(estado);
        }

        /// <summary>
        /// Priscilla Mena
        /// 01/04/2019
        /// Efecto: Elimina un estado 
        /// Requiere: estado
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param name="estado"></param>
        public void eliminarEstado(Estado estado)
        {
            estadoDatos.eliminarEstado(estado);
        }

        #endregion
    }
}
