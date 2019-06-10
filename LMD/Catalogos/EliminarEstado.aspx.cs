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
    public partial class EliminarEstado : System.Web.UI.Page
    {

        #region variables globales
        EstadoServicios estadoServicios = new EstadoServicios();
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
                Estado estado = (Estado)Session["estadoEliminar"];
                txtNombreEstado.Text = estado.nombre;

            }

        }
        #endregion

        #region eventos


        /// <summary>
        /// Priscilla Mena Monge
        /// 01/04/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de eliminar
        /// redirecciona a la pantalla de adminstracion de Estados
        /// elimina el estado de la base de datos
        /// redireccion a la pantalla de Administracion de Estados
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Estado Estado = (Estado)Session["estadoEliminar"];

            try
            {
                estadoServicios.eliminarEstado(Estado);
                String url = Page.ResolveUrl("~/Catalogos/AdministrarEstado.aspx");
                Response.Redirect(url);
            }
            catch (Exception ex)
            {

                (this.Master as SiteMaster).Mensaje("El estado no puede ser eliminado ya que está siendo utilizado por otro registro", "¡Alerta!");
            }
        }


        /// <summary>
        /// Priscilla Mena Monge
        /// 01/04/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Estados
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarEstado.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}