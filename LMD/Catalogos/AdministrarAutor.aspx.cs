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
    public partial class AdministrarAutor : System.Web.UI.Page
    {
        #region variables globales
        AutorServicios autorServicios = new AutorServicios();
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
                Session["listaAutores"] = null;
                Session["autorEditar"] = null;
                Session["autorEliminar"] = null;
                cargarDatosTblAutores();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 04/04/2019
        /// Efecto: Metodo para llenar los datos de la tabla con los Autores que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblAutores()
        {
            List<Autor> listaAutores = new List<Autor>();
            listaAutores = autorServicios.getAutores();
            rpAutor.DataSource = listaAutores;
            rpAutor.DataBind();

            Session["listaAutores"] = listaAutores;

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

        protected void rpAutor_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo Autor,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/NuevoAutor.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 04/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un Autor,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idAutor = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Autor> listaAutores = (List<Autor>)Session["listaAutores"];

            Autor autorEditar = new Autor();

            foreach (Autor autor in listaAutores)
            {
                if (autor.idAutor == idAutor)
                {
                    autorEditar = autor;
                    break;
                }
            }

            Session["autorEditar"] = autorEditar;

            String url = Page.ResolveUrl("~/Catalogos/EditarAutor.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge MONGE
        /// 04/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un autor,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idAutor = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Autor> listaAutores = (List<Autor>)Session["listaAutores"];

            Autor autorEliminar = new Autor();

            foreach (Autor autor in listaAutores)
            {
                if (autor.idAutor == idAutor)
                {
                    autorEliminar = autor;
                    break;
                }
            }

            Session["autorEliminar"] = autorEliminar;

            String url = Page.ResolveUrl("~/Catalogos/EliminarAutor.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 04/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un autor,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idAutor = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Autor> listaAutores = (List<Autor>)Session["listaAutores"];

            Autor autorVer = new Autor();

            foreach (Autor autor in listaAutores)
            {
                if (autor.idAutor == idAutor)
                {
                    autorVer = autor;
                    break;
                }
            }

            Session["autorVer"] = autorVer;

            String url = Page.ResolveUrl("~/Catalogos/VerAutor.aspx");
            Response.Redirect(url);

        }



        #endregion
    }
}