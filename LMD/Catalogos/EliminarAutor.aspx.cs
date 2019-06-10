using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMD.Catalogos
{
    public partial class EliminarAutor : System.Web.UI.Page
    {
        #region variables globales
        AutorServicios autorServicios = new AutorServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPeromitidos = { 2 };
            Utilidades.escogerMenu(Page, rolesPeromitidos);

            if (!IsPostBack)
            {
                Autor autor = (Autor)Session["AutorEliminar"];
                txtNombreAutor.Text = autor.nombre;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Priscilla Mena Monge
        /// 01/04/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de Autores
        /// elimina el autor de la base de datos
        /// redireccion a la pantalla de Administracion de Autores
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Autor autor = (Autor)Session["AutorEliminar"];

            try
            {
                autorServicios.eliminarAutor(autor);
                String url = Page.ResolveUrl("~/Catalogos/AdministrarAutor.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {

                  (this.Master as SiteMaster).Mensaje("El autor no puede ser eliminado ya que está siendo utilizado por otro registro", "¡Alerta!");
            }
        }


        /// <summary>
        /// Priscilla Mena Monge
        /// 01/04/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Autores
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarAutor.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}