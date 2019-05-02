using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMD.DocumentosExternos
{
    public partial class AdministrarDocumentoExterno : System.Web.UI.Page
    {
        #region variables globales
        DocumentoExternoServicios documentoExternoServicios = new DocumentoExternoServicios();
        public static int rol = 0;
        #endregion
        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
            //si no tiene permiso de ver la pagina se redirecciona a login
            // 9 significa asistente y 2 significa administrador
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
                Session["listaDocumentosExternos"] = null;
                Session["documentoExternoEditar"] = null;
                Session["documentoExternoEliminar"] = null;
                cargarDatosTblDocumentosExternos();

            }
        }
        #endregion
        #region logica
        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 02/05/2019
        /// Efecto: Metodo para llenar los datos de la tabla con los DocumentosExternos que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblDocumentosExternos()
        {
            List<DocumentoExterno> listaDocumentosExternos = new List<DocumentoExterno>();
            Sistema sistema = new Sistema();
            sistema = (Sistema)Session["sistema"];
            listaDocumentosExternos = documentoExternoServicios.getDocumentosExternos(sistema.idSistema);
            rpDocumentoExterno.DataSource = listaDocumentosExternos;
            rpDocumentoExterno.DataBind();

            Session["listaDocumentosExternos"] = listaDocumentosExternos;

        }


        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 02/05/2019
        /// Efecto: oculta los botones de editar y eliminar para los usuarios que son  tipo asistente
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>

        protected void rpDocumentoExterno_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
        /// 02/05/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo DocumentoExterno,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/DocumentosExternos/NuevoDocumentoExterno.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 02/05/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un DocumentoExterno,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idDocumentoExterno = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<DocumentoExterno> listaDocumentosExternos = (List<DocumentoExterno>)Session["listaDocumentosExternos"];

            DocumentoExterno documentoExternoEditar = new DocumentoExterno();

            foreach (DocumentoExterno documentoExterno in listaDocumentosExternos)
            {
                if (documentoExterno.idDocumentoExterno == idDocumentoExterno)
                {
                    documentoExternoEditar = documentoExterno;
                    break;
                }
            }

            Session["documentoExternoEditar"] = documentoExternoEditar;

            String url = Page.ResolveUrl("~/DocumentosExternos/EditarDocumentoExterno.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge MONGE
        /// 02/05/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un documentoExterno,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idDocumentoExterno = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<DocumentoExterno> listaDocumentosExternos = (List<DocumentoExterno>)Session["listaDocumentosExternos"];

            DocumentoExterno documentoExternoEliminar = new DocumentoExterno();

            foreach (DocumentoExterno documentoExterno in listaDocumentosExternos)
            {
                if (documentoExterno.idDocumentoExterno == idDocumentoExterno)
                {
                    documentoExternoEliminar = documentoExterno;
                    break;
                }
            }

            Session["documentoExternoEliminar"] = documentoExternoEliminar;

            String url = Page.ResolveUrl("~/DocumentosExternos/EliminarDocumentoExterno.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 02/05/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un documentoExterno,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idDocumentoExterno = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<DocumentoExterno> listaDocumentosExternos = (List<DocumentoExterno>)Session["listaDocumentosExternos"];

            DocumentoExterno documentoExternoVer = new DocumentoExterno();

            foreach (DocumentoExterno documentoExterno in listaDocumentosExternos)
            {
                if (documentoExterno.idDocumentoExterno == idDocumentoExterno)
                {
                    documentoExternoVer = documentoExterno;
                    break;
                }
            }

            Session["documentoExternoVer"] = documentoExternoVer;

            String url = Page.ResolveUrl("~/DocumentosExternos/VerDocumentoExterno.aspx");
            Response.Redirect(url);

        }



        #endregion
    }
}