using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMD
{
    public partial class Menu : System.Web.UI.Page
    {
        #region variables globales
        SistemaServicios sistemaServicios = new SistemaServicios();
        public static int rol = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene 
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPermitidos = { 2, 9 };
            Utilidades.escogerMenu(Page, rolesPermitidos);

            Page.Master.FindControl("menu").Visible = false;
            Session["tituloSistema"] = "";
        }

        /// <summary>
        /// Priscilla Mena Monge
        ///25/03/2019
        /// Efecto:Metodo que se activa cuando se le da click al enlace de laboratorio de Ensayos
        /// cambia las variables del sistema a laboratorio de ensayos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void laboratorio_Ensayos_Click(object sender, EventArgs e)
        {
            Session["tituloSistema"] = " para laboratorio de ensayos";
            String url = Page.ResolveUrl("~/Inicio.aspx");
            Sistema sistema = sistemaServicios.getSistema("laboratorio de ensayos");
            Session["idSistema"] = sistema.idSistema;
            Session["nombreSistema"] = sistema.nombre;
            Response.Redirect(url);
        }


        /// <summary>
        /// Priscilla Mena Monge
        /// 25/03/2019
        /// Efecto:Metodo que se activa cuando se le da click al enlace de laboratorio de fuerza
        /// cambia las variables del sistema a laboratorio de fuerza
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void laboratorio_Fuerza_Click(object sender, EventArgs e)
        {
            Session["tituloSistema"] = " para laboratorio de fuerza";
            String url = Page.ResolveUrl("~/Inicio.aspx");
            Sistema sistema = sistemaServicios.getSistema("laboratorio de fuerza");
            Session["idSistema"] = sistema.idSistema;
            Session["nombreSistema"] = sistema.nombre;
            Response.Redirect(url);
        }


        /// <summary>
        /// Priscilla Mena Monge
        /// 25/03/2019
        /// Efecto:Metodo que se activa cuando se le da click al enlace de unidad de puentes
        /// cambia las variables del sistema a unidad de puentes
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void unidad_Puentes_Click(object sender, EventArgs e)
        {
            Session["tituloSistema"] = " para unidad de puentes";
            String url = Page.ResolveUrl("~/Inicio.aspx");
            Sistema sistema = sistemaServicios.getSistema("unidad de puentes");
            Session["idSistema"] = sistema.idSistema;
            Session["nombreSistema"] = sistema.nombre;
            Response.Redirect(url);
        }
    }
}