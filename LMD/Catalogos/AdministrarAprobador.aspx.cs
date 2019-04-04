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

    public partial class AdministrarAprobador : System.Web.UI.Page
    {
        #region variables globales
        AprobadorServicios aprobadorServicios = new AprobadorServicios();
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
                Session["listaAprobadores"] = null;
                Session["aprobadorEditar"] = null;
                Session["aprobadorEliminar"] = null;
                cargarDatosTblAprobadores();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 04/04/2019
        /// Efecto: Metodo para llenar los datos de la tabla con los Aprobadores que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblAprobadores()
        {
            List<Aprobador> listaAprobadores = new List<Aprobador>();
            listaAprobadores = aprobadorServicios.getAprobadores();
            rpAprobador.DataSource = listaAprobadores;
            rpAprobador.DataBind();

            Session["listaAprobadores"] = listaAprobadores;

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

        protected void rpAprobador_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo Aprobador,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/NuevoAprobador.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 04/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un Aprobador,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idAprobador = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Aprobador> listaAprobadores = (List<Aprobador>)Session["listaAprobadores"];

            Aprobador aprobadorEditar = new Aprobador();

            foreach (Aprobador aprobador in listaAprobadores)
            {
                if (aprobador.idAprobador == idAprobador)
                {
                    aprobadorEditar = aprobador;
                    break;
                }
            }

            Session["aprobadorEditar"] = aprobadorEditar;

            String url = Page.ResolveUrl("~/Catalogos/EditarAprobador.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge MONGE
        /// 04/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un aprobador,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idAprobador = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Aprobador> listaAprobadores = (List<Aprobador>)Session["listaAprobadores"];

            Aprobador aprobadorEliminar = new Aprobador();

            foreach (Aprobador aprobador in listaAprobadores)
            {
                if (aprobador.idAprobador == idAprobador)
                {
                    aprobadorEliminar = aprobador;
                    break;
                }
            }

            Session["aprobadorEliminar"] = aprobadorEliminar;

            String url = Page.ResolveUrl("~/Catalogos/EliminarAprobador.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 04/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un aprobador,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idAprobador = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Aprobador> listaAprobadores = (List<Aprobador>)Session["listaAprobadores"];

            Aprobador aprobadorVer = new Aprobador();

            foreach (Aprobador aprobador in listaAprobadores)
            {
                if (aprobador.idAprobador == idAprobador)
                {
                    aprobadorVer = aprobador;
                    break;
                }
            }

            Session["aprobadorVer"] = aprobadorVer;

            String url = Page.ResolveUrl("~/Catalogos/VerAprobador.aspx");
            Response.Redirect(url);

        }



        #endregion
    }
}