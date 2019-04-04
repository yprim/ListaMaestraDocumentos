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
    public partial class AdministrarResponsable : System.Web.UI.Page
    {
        #region variables globales
        ResponsableServicios responsableServicios = new ResponsableServicios();
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
                Session["listaResponsables"] = null;
                Session["responsableEditar"] = null;
                Session["responsableEliminar"] = null;
                cargarDatosTblResponsables();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 04/04/2019
        /// Efecto: Metodo para llenar los datos de la tabla con los Responsables que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblResponsables()
        {
            List<Responsable> listaResponsables = new List<Responsable>();
            listaResponsables = responsableServicios.getResponsables();
            rpResponsable.DataSource = listaResponsables;
            rpResponsable.DataBind();

            Session["listaResponsables"] = listaResponsables;

        }


        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 04/04/2019
        /// Efecto: oculta los botones de editar y eliminar para los usuarios que son  tipo asistente
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>

        protected void rpResponsable_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
        /// 04/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo Responsable,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/NuevoResponsable.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 04/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un Responsable,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idResponsable = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Responsable> listaResponsables = (List<Responsable>)Session["listaResponsables"];

            Responsable responsableEditar = new Responsable();

            foreach (Responsable responsable in listaResponsables)
            {
                if (responsable.idResponsable == idResponsable)
                {
                    responsableEditar = responsable;
                    break;
                }
            }

            Session["responsableEditar"] = responsableEditar;

            String url = Page.ResolveUrl("~/Catalogos/EditarResponsable.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge MONGE
        /// 04/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un responsable,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idResponsable = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Responsable> listaResponsables = (List<Responsable>)Session["listaResponsables"];

            Responsable responsableEliminar = new Responsable();

            foreach (Responsable responsable in listaResponsables)
            {
                if (responsable.idResponsable == idResponsable)
                {
                    responsableEliminar = responsable;
                    break;
                }
            }

            Session["responsableEliminar"] = responsableEliminar;

            String url = Page.ResolveUrl("~/Catalogos/EliminarResponsable.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 04/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un responsable,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idResponsable = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Responsable> listaResponsables = (List<Responsable>)Session["listaResponsables"];

            Responsable responsableVer = new Responsable();

            foreach (Responsable responsable in listaResponsables)
            {
                if (responsable.idResponsable == idResponsable)
                {
                    responsableVer = responsable;
                    break;
                }
            }

            Session["responsableVer"] = responsableVer;

            String url = Page.ResolveUrl("~/Catalogos/VerResponsable.aspx");
            Response.Redirect(url);

        }



        #endregion
    }
}