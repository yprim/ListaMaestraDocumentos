using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class AutorServicios
    {
        #region variables
        AutorDatos autorDatos = new AutorDatos();
        #endregion

        #region servicios
        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: devuelve una lista con todos los Autores
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Autores
        /// </summary>
        /// <returns></returns>
        public List<Autor> getAutores()
        {

            return autorDatos.getAutores();
        }

        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: inserta en la base de datos un autor
        /// Requiere: autor
        /// Modifica: inserta un autor en la base de datos
        /// Devuelve: id del autor insertado
        /// </summary>
        /// <param name="autor"></param>
        /// <returns></returns>
        public int insertarAutor(Autor autor)
        {

            return autorDatos.insertarAutor(autor);
        }

        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: actualiza un autor
        /// Requiere: autor a modificar
        /// Modifica: actualiza un autor de la base de datos
        /// Devuelve: -
        /// </summary>
        /// <param name="autor"></param>
        public void actualizarAutor(Autor autor)
        {

            autorDatos.actualizarAutor(autor);
        }


        /// <summary>
        /// Priscilla Mena
        ///04/04/2019
        /// Efecto: Elimina un autor 
        /// Requiere: autor
        /// Modifica: elimina un autor de la Base de datos
        /// Devuelve: -
        /// </summary>
        /// <param name="autor"></param>
        public void eliminarAutor(Autor autor)
        {

            autorDatos.eliminarAutor(autor);
        }


        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: recupera todos los autores que no estan asociados al documento externo
        /// Requiere: documentoExterno
        /// Modifica: -
        /// Devuelve: lista de autores
        /// </summary>
        /// <param name="documentoExterno"></param>
        public List<Autor> getAutoresNoEstanEnDocumentoExterno(DocumentoExterno documentoExterno)
        {
            
         return autorDatos.getAutoresNoEstanEnDocumentoExterno(documentoExterno);

        }

        /// <summary>
        /// Priscilla Mena
        /// 27/05/2019
        /// Efecto: recupera todos los autores que ya están asociados al documento externo
        /// Requiere: documentoExterno
        /// Modifica: -
        /// Devuelve: lista de autores
        /// </summary>
        /// <param name="documentoExterno"></param>
        public List<Autor> getAutoresEstanEnDocumentoExterno(DocumentoExterno documentoExterno)
        {
          

            return autorDatos.getAutoresEstanEnDocumentoExterno(documentoExterno);

        }
        #endregion

    }
}
