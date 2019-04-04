using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace LMD { 
internal static class Utilidades
{
    public static Dictionary<int, string> roles { get; set; }
    public static List<System.Web.UI.WebControls.HyperLink> aplicaciones { get; set; }
    public static string path = "\\\\issac\\AppFiles\\ReunionesRevisionDireccion\\Pruebas\\";
    public static string logs_path = path + "logs";


    public static void MensajeBox(string mensaje, string tipo, ClientScriptManager ClientScript, System.Web.UI.Page pag)
    { //Tipo de mensaje puede ser alert,confirm o popup
        string message = mensaje;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append(tipo);
        sb.Append("('");
        sb.Append(message);
        sb.Append("');");
        sb.Append("</script>");
        ClientScript.RegisterClientScriptBlock(pag.GetType(), "alert", sb.ToString());
    }

    public static void ErrorBitacora(string e, string m)
    {
        Directory.SetCurrentDirectory(logs_path);
        FileStream archivo = new FileStream("Error.log", FileMode.Open, FileAccess.Write);
        archivo.Seek(0, SeekOrigin.End);
        StreamWriter sw = new StreamWriter(archivo);
        sw.WriteLine("");
        sw.WriteLine("**************************");
        sw.WriteLine(System.DateTime.Now.ToString());
        sw.WriteLine("**************************");
        sw.WriteLine("(######)   " + m + "   (######)");
        sw.WriteLine(e);
        sw.Close();
        archivo.Close();
    }

    public static void SetLogDirectory()
    {
        if (Directory.Exists(logs_path))
        {
            Directory.SetCurrentDirectory(logs_path);
        }
        else
        {
            Directory.CreateDirectory(logs_path);
            Directory.SetCurrentDirectory(logs_path);
        }
        FileStream archivo = new FileStream("Error.log", FileMode.OpenOrCreate);
        archivo.Close();

    }

    public static bool IsPDF(string txt)
    {
        return txt.Substring(txt.Length - 4, 4).Equals(".pdf") || txt.Substring(txt.Length - 4, 4).Equals(".PDF");

    }

    public static int SaveFile(HttpPostedFile file, int year, String nombreArchivo, String carpeta)
    {
        // Path del directorio donde vamos a guardar el archivo
        String pathToCheck = path + year;

        //Verificamos si existe el directorio, sino existe se crea
        if (!Directory.Exists(pathToCheck))
        {
            Directory.CreateDirectory(pathToCheck);
        }

        // Path de la carpeta dentro del directorio en donde se va a guardar el archivo
        pathToCheck = pathToCheck + "\\" + carpeta;

        // Verificamos si ya existe la carpeta dentro del directorio, si no existe entonces se crea
        if (!Directory.Exists(pathToCheck))
        {
            Directory.CreateDirectory(pathToCheck);
        }

        // Crear la ruta y el nombre del archivo para comprobar si hay duplicados.
        pathToCheck = pathToCheck + "\\" + nombreArchivo;

        // Compruebe si ya existe un archivo con el
        // mismo nombre que el archivo que desea cargar .       
        if ((System.IO.File.Exists(pathToCheck)))
        {
            return 1; //El archivo existe
        }
        else
        {
            // Llame al método SaveAs para guardar el archivo
            // guardado en el directorio especificado.
            file.SaveAs(pathToCheck);
            return 0;
        }
    }

    // Retorna 1 si logro sobreescribir, 0 si no habia archivo, por lo que no sobreecribio, solo creo un nuevo archivo.
    public static int OverWriteFile(System.Web.UI.WebControls.FileUpload FileUpload1, int year, string TextConsecutivo, string nuevoTextConsecutivo)
    {
        // Path del directorio donde vamos a guardar el archivo
        string pathToCheck = path + year;

        //Verificamos si existe el directorio, sino existe se crea
        if (!Directory.Exists(pathToCheck))
        {
            Directory.CreateDirectory(pathToCheck);
        }

        // Crear la ruta y el nombre del archivo para comprobar si hay duplicados.
        string olFile = pathToCheck + "\\" + TextConsecutivo + ".PDF";
        string newFile = pathToCheck + "\\" + nuevoTextConsecutivo + ".PDF";

        // Compruebe si ya existe un archivo con el
        // mismo nombre que el archivo que desea cargar .       
        if ((System.IO.File.Exists(olFile)))
        {
            System.IO.File.Move(olFile, newFile);
            return 1; //El archivo existe
        }
        else
        {
            // Llame al método SaveAs para guardar el archivo.
            FileUpload1.SaveAs(newFile);
            return 0;
        }
    }

    public static bool existeArchivo(string nombre_archivo, int year)
    {
        bool existe = false;

        string pathToCheck = path + year;

        if (Directory.Exists(pathToCheck))
        {
            pathToCheck = pathToCheck + "\\" + nombre_archivo + ".PDF";

            if ((System.IO.File.Exists(pathToCheck)))
            {
                existe = true;
            }

        }

        return existe;
    }

    public static List<string> buscarEnLista(string prefixText, List<string> li)
    {
        List<string> result = new List<string>();
        foreach (string s in li)
        {
            if (s.Contains(prefixText) || s.Contains(prefixText.ToUpper()) || s.Contains(prefixText.ToLower()))
            {
                result.Add(s);
            }
        }

        return result;

    }

       
        /// <summary>
        /// Priscilla Mena Monge
        /// 18/03/2019
        /// Efecto: escoge el menu segun el rol del usuario, si el usuario no tiene ningun permiso en esta aplicacion lo redirecciona al login
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: *
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rolesPermitidos"></param>
        public static void escogerMenu(Page page, int[] rolesPermitidos)
    {
        int rol = Int32.Parse(page.Session["rol"].ToString());
        if (page.Session["nombreCompleto"] == null)
        {
            page.Session.RemoveAll();
            page.Session.Abandon();
            page.Session.Clear();
            String url = page.ResolveUrl("~/login.aspx");
            page.Response.Redirect(url);
        }
        else if (rol == 2)
        {
            if (rolesPermitidos.Contains(rol))
            {
                page.Master.FindControl("MenuAdministrador").Visible = true;
                page.Master.FindControl("MenuAsistente").Visible = false;
            }
            else
            {
                page.Session.RemoveAll();
                page.Session.Abandon();
                page.Session.Clear();
                String url = page.ResolveUrl("~/login.aspx");
                page.Response.Redirect(url);
            }
        }
        else if (rol == 9)
        {
            if (rolesPermitidos.Contains(rol))
            {
                page.Master.FindControl("MenuAdministrador").Visible = false;
                page.Master.FindControl("MenuAsistente").Visible = true;
            }
            else
            {
                page.Session.RemoveAll();
                page.Session.Abandon();
                page.Session.Clear();
                String url = page.ResolveUrl("~/login.aspx");
                page.Response.Redirect(url);
            }
        }
        else
        {
            page.Session.RemoveAll();
            page.Session.Abandon();
            page.Session.Clear();
            String url = page.ResolveUrl("~/login.aspx");
            page.Response.Redirect(url);
        }
    }

}

}