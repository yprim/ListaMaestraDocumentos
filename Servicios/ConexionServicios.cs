using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    /*
  * Priscilla Mena
  * 21/03/2019
  * Clase para manejar los servicios de conexion
  */
    public class ConexionServicios
    {
        #region variables globales
        ConexionDatos conexionDatos = new ConexionDatos();
        #endregion

        #region metodos
     
        /// <summary>
        /// Priscilla Mena
        /// 21/03/2019
        /// Efecto: se utiliza para loguearse a la aplicacion 
        /// Requiere: usuario
        /// Modifica: -
        /// Devuelve: id del rol del usuario y el nombre completo del usuario en un vector
        /// </summary>
        /// param name="usuario"
        /// <returns></returns>
        public object[] loguearse(String usuario)
        {
            return conexionDatos.loguearse(usuario);
        }
        #endregion
    }
}
