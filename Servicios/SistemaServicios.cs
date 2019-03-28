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
    /// 28/03/2019
    /// clase para manejar los servicios de sistema
    /// </summary>
    public class SistemaServicios
    {

        #region variables globales
        SistemaDatos sistemaDatos = new SistemaDatos();
        #endregion

        /// <summary>
        /// Priscilla Mena
        /// 28/03/2018
        /// Efecto: Retorna entidad sistema para obtener el id de Unidad de puentes,
        /// Laboratorio de ensayos o Laboratorio de fuerza según sea el caso
        /// Requiere: nombre del sistema
        /// Modifica: -
        /// Devuelve:  devuelve el objeto sistema
        /// </summary>
        /// <param name="nombreSistema"></param>
        /// <returns></returns>
        public Sistema getSistema(String nombreSistema)
        {

            return sistemaDatos.getSistema(nombreSistema);
        }



    }
}