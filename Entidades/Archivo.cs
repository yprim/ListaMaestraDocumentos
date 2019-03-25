using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{

    [Serializable]
    public class Archivo
    {
        string ruta = System.AppDomain.CurrentDomain.BaseDirectory + "ArchivoBaseDatos.txt";

   
        /// <summary>
        /// Priscilla Mena
        /// 21/03/2019
        /// Efecto: Metodo que guarda en un archivo los datos de la base de datos
        /// Requiere: baseDatos
        /// Modifica: -
        /// Devuelve: -
        /// <paramref name="baseDatos"/>
        /// </summary>
        /// <returns></returns>
        public void guardarArchivo(BaseDatos baseDatos)
        {

            FileStream stream = new FileStream(ruta, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(baseDatos.GetType());
            serializer.Serialize(stream, baseDatos);
            stream.Close();
        }

       
        /// <summary>
        /// Priscilla Mena
        /// 21/03/2019
        /// Efecto:el archivo y devuelve la entidad de BaseDatos con los datos guardados de la conexiones de las bases de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: BaseDatos
        /// </summary>
        /// <returns></returns>
        public BaseDatos leerArchivo()
        {
            FileStream stream = new FileStream(ruta, FileMode.Open);
            BaseDatos baseDatos = new BaseDatos();
            try
            {

                XmlSerializer serializer = new XmlSerializer(baseDatos.GetType());
                baseDatos = (BaseDatos)serializer.Deserialize(stream);
                stream.Close();
                return baseDatos;
            }
            catch
            {
                stream.Close();
                return baseDatos;
            }
        }
    }
}
