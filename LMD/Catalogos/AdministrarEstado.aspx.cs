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
    public partial class AdministrarEstado : System.Web.UI.Page
    {
        #region variables globales
        EstadoServicios estadoServicios = new EstadoServicios();
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
                ///si el rol es de asistente (9) se desabilita el boton de nueva reunion
                rol = (int)Session["rol"];

                if (rol == 9)
                {
                    btnNuevo.Visible = false;
                }
                Session["listaEstados"] = null;
                Session["estadoEditar"] = null;
                Session["estadoEliminar"] = null;
                cargarDatosTblEstados();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena
        /// 01/04/2019
        /// Efecto: Metodo para llenar los datos de la tabla con los Estados que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblEstados()
        {
            List<Estado> listaEstados = new List<Estado>();
            listaEstados = estadoServicios.getEstados();
            rpEstado.DataSource = listaEstados;
            rpEstado.DataBind();

            Session["listaEstados"] = listaEstados;

        }
        #endregion

        #region eventos

        /// <summary>
        /// Priscilla Mena
        /// 01/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo Estado,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/NuevoEstado.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 01/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un Estado,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idEstado = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Estado> listaEstados = (List<Estado>)Session["listaEstados"];

            Estado estadoEditar = new Estado();

            foreach (Estado estado in listaEstados)
            {
                if (estado.idEstado == idEstado)
                {
                    estadoEditar = estado;
                    break;
                }
            }

            Session["estadoEditar"] = estadoEditar;

            String url = Page.ResolveUrl("~/Catalogos/EditarEstado.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 01/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un Estado,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEstado = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Estado> listaEstados = (List<Estado>)Session["listaEstados"];

            Estado estadoEliminar = new Estado();

            foreach (Estado estado in listaEstados)
            {
                if (estado.idEstado == idEstado)
                {
                    estadoEliminar = estado;
                    break;
                }
            }

            Session["estadoEliminar"] = estadoEliminar;

            String url = Page.ResolveUrl("~/Catalogos/EliminarEstado.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Priscilla Mena
        /// 01/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un Estado,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idEstado = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Estado> listaEstados = (List<Estado>)Session["listaEstados"];

            Estado estadoVer = new Estado();

            foreach (Estado estado in listaEstados)
            {
                if (estado.idEstado == idEstado)
                {
                    estadoVer = estado;
                    break;
                }
            }

            Session["estadoVer"] = estadoVer;

            String url = Page.ResolveUrl("~/Catalogos/VerEstado.aspx");
            Response.Redirect(url);

        }


        /// <summary>
        /// Priscilla Mena
        /// 01/04/2019
        /// Efecto: oculta los botones de editar y eliminar para los usuarios que son  tipo asistente
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>

        protected void rpEstado_ItemDataBound(object sender, RepeaterItemEventArgs e)
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


    }
}