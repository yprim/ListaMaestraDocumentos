using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMD
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Master.FindControl("menu").Visible = false;
            Session["nombreSistema"] = "";
        }

        /// <summary>
        /// Priscilla Mena
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
            Session["nombreSistema"] = " para laboratorio de ensayos";
            String url = Page.ResolveUrl("~/Inicio.aspx");
            Response.Redirect(url);
        }


        /// <summary>
        /// Priscilla Mena
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
            Session["nombreSistema"] = " para laboratorio de fuerza";
            String url = Page.ResolveUrl("~/Inicio.aspx");
            Response.Redirect(url);
        }


        /// <summary>
        /// Priscilla Mena
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
            Session["nombreSistema"] = " para unidad de puentes";
            String url = Page.ResolveUrl("~/Inicio.aspx");
            Response.Redirect(url);
        }

    }
}