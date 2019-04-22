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
    public partial class AdministrarUbicacion : System.Web.UI.Page
    {
        #region variables globales
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
        public static int rol = 0;
        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            ///controla los menus q se muestran y las pantallas que se muestras según el rol que tiene el usuario
            ///si no tiene permiso de ver la pagina se redirecciona a login
            /// 9 significa asistente y 2 significa administrador
            int[] rolesPeromitidos = { 2, 9 };
            Utilidades.escogerMenu(Page, rolesPeromitidos);
            if (!Page.IsPostBack)
            {
                ///si el rol es de asistente (9) se desabilita el boton de nuevo
                rol = (int)Session["rol"];

                if (rol == 9)
                {
                    btnNuevo.Visible = false;
                }
                Session["listaUbicaciones"] = null;
                Session["ubicacionEditar"] = null;
                Session["ubicacionEliminar"] = null;
                cargarDatosTblUbicaciones();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 22/04/2019
        /// Efecto: Metodo para llenar los datos de la tabla con las Ubicaciones que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblUbicaciones()
        {
            List<Ubicacion> listaUbicaciones = new List<Ubicacion>();
            listaUbicaciones = ubicacionServicios.getUbicaciones();
            rpUbicacion.DataSource = listaUbicaciones;
            rpUbicacion.DataBind();

            Session["listaUbicaciones"] = listaUbicaciones;

        }


        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 22/04/2019
        /// Efecto: oculta los botones de editar y eliminar para los usuarios que son  tipo asistente
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>

        protected void rpUbicacion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton btnEditar = e.Item.FindControl("btnEditar") as LinkButton;
                LinkButton btnEliminar = e.Item.FindControl("btnEliminar") as LinkButton;

                if (rol == 9)
                {
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                }

            }

        }
        #endregion

        #region eventos

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 22/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa una nueva Ubicacion,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/NuevaUbicacion.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 22/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita una Ubicacion,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idUbicacion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Ubicacion> listaUbicaciones = (List<Ubicacion>)Session["listaUbicaciones"];

            Ubicacion ubicacionEditar = new Ubicacion();

            foreach (Ubicacion ubicacion in listaUbicaciones)
            {
                if (ubicacion.idUbicacion == idUbicacion)
                {
                    ubicacionEditar = ubicacion;
                    break;
                }
            }

            Session["ubicacionEditar"] = ubicacionEditar;

            String url = Page.ResolveUrl("~/Catalogos/EditarUbicacion.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge MONGE
        /// 22/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina una ubicacion,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idUbicacion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Ubicacion> listaUbicaciones = (List<Ubicacion>)Session["listaUbicaciones"];

            Ubicacion ubicacionEliminar = new Ubicacion();

            foreach (Ubicacion ubicacion in listaUbicaciones)
            {
                if (ubicacion.idUbicacion == idUbicacion)
                {
                    ubicacionEliminar = ubicacion;
                    break;
                }
            }

            Session["ubicacionEliminar"] = ubicacionEliminar;

            String url = Page.ResolveUrl("~/Catalogos/EliminarUbicacion.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 22/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve una ubicacion,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idUbicacion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Ubicacion> listaUbicaciones = (List<Ubicacion>)Session["listaUbicaciones"];

            Ubicacion ubicacionVer = new Ubicacion();

            foreach (Ubicacion ubicacion in listaUbicaciones)
            {
                if (ubicacion.idUbicacion == idUbicacion)
                {
                    ubicacionVer = ubicacion;
                    break;
                }
            }

            Session["ubicacionVer"] = ubicacionVer;

            String url = Page.ResolveUrl("~/Catalogos/VerUbicacion.aspx");
            Response.Redirect(url);

        }



        #endregion
    }
}