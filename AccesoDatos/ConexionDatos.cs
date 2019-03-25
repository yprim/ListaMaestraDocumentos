using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ConexionDatos
    {
        BaseDatos baseDatos = new BaseDatos();
        Archivo archivo = new Archivo();

        public SqlConnection conexionLogin()
        {
            baseDatos = archivo.leerArchivo();
            SqlConnection conn = new SqlConnection();

            String connectionString
                = @"Data Source=" + baseDatos.servidorLogin
                + ";Initial Catalog=" + baseDatos.baseLogin
                + ";User ID=" + baseDatos.usuarioLogin
                + ";Password=" + baseDatos.contrasenaLogin
                + ";Trusted_Connection=False;";

            conn.ConnectionString = connectionString;

            return conn;
        }

        public SqlConnection conexionLMD()
        {
            baseDatos = archivo.leerArchivo();
            SqlConnection conn = new SqlConnection();

            String connectionString
                = @"Data Source=" + baseDatos.servidorLMD
                + ";Initial Catalog=" + baseDatos.baseLMD
                + ";User ID=" + baseDatos.usuarioLMD
                + ";Password=" + baseDatos.contrasenaLMD
                + ";Trusted_Connection=False;";

            conn.ConnectionString = connectionString;

            return conn;
        }

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
            object[] rolNombreCompleto = new object[2];
            SqlConnection sqlConnection = conexionLogin();
            SqlCommand sqlCommand = new SqlCommand("select R.id_rol, U.nombre_completo from " +
                "Rol R, Usuario U, Aplicacion A, Usuario_Rol_Aplicacion URA " +
                "where A.nombre_aplicacion='ReunionesRevisionDireccion' and U.usuario=@usuario and URA.id_aplicacion=A.id_aplicacion and " +
                "URA.id_usuario = u.id_usuario and R.id_rol = URA.id_rol ;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@usuario", usuario.ToLower());
            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {

                int rol = Int32.Parse(reader.GetValue(0).ToString());
                String nombreCompleto = reader.GetValue(1).ToString();

                rolNombreCompleto[0] = rol;
                rolNombreCompleto[1] = nombreCompleto;
            }

            sqlConnection.Close();

            return rolNombreCompleto;
        }
    }
}