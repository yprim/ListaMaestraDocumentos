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
    public partial class EliminarUbicacion : System.Web.UI.Page
    {
        #region variables globales
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
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
                Ubicacion ubicacion = (Ubicacion)Session["UbicacionEliminar"];
                txtNombreUbicacion.Text = ubicacion.nombre;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Priscilla Mena Monge
        /// 22/04/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de Ubicaciones
        /// elimina el ubicacion de la base de datos
        /// redireccion a la pantalla de Administracion de Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Ubicacion ubicacion = (Ubicacion)Session["UbicacionEliminar"];

            try
            {
                ubicacionServicios.eliminarUbicacion(ubicacion);
                String url = Page.ResolveUrl("~/Catalogos/AdministrarUbicacion.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {

                //  (this.Master as Site).Mensaje("El ubicacion no puede ser eliminado ya que está siendo utilizado por otra reunión", "¡Alerta!");
            }
        }


        /// <summary>
        /// Priscilla Mena Monge
        /// 22/04/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarUbicacion.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}