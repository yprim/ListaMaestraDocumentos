using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMD.Procedimientos
{
    public partial class AdministrarProcedimiento : System.Web.UI.Page
    {
        #region variables globales
        ProcedimientoServicios procedimientoServicios = new ProcedimientoServicios();
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
                Session["listaProcedimientos"] = null;
                Session["procedimientoEditar"] = null;
                Session["procedimientoEliminar"] = null;
                cargarDatosTblProcedimientos();

            }
        }
        #endregion

        #region logica
        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 25/04/2019
        /// Efecto: Metodo para llenar los datos de la tabla con los Procedimientos que se encuentran en la base de datos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        private void cargarDatosTblProcedimientos()
        {
            List<Procedimiento> listaProcedimientos = new List<Procedimiento>();
            Sistema sistema = new Sistema();
            sistema = (Sistema)Session["sistema"];
            listaProcedimientos = procedimientoServicios.getProcedimientos(sistema.idSistema);
            rpProcedimiento.DataSource = listaProcedimientos;
            rpProcedimiento.DataBind();

            Session["listaProcedimientos"] = listaProcedimientos;

        }


        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 25/04/2019
        /// Efecto: oculta los botones de editar y eliminar para los usuarios que son  tipo asistente
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>

        protected void rpProcedimiento_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
        /// 25/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ingresa un nuevo Procedimiento,
        /// se activa cuando se presiona el boton de nuevo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Procedimientos/NuevoProcedimiento.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 25/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se edita un Procedimiento,
        /// se activa cuando se presiona el boton de editar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idProcedimiento = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Procedimiento> listaProcedimientos = (List<Procedimiento>)Session["listaProcedimientos"];

            Procedimiento procedimientoEditar = new Procedimiento();

            foreach (Procedimiento procedimiento in listaProcedimientos)
            {
                if (procedimiento.idProcedimiento == idProcedimiento)
                {
                    procedimientoEditar = procedimiento;
                    break;
                }
            }

            Session["procedimientoEditar"] = procedimientoEditar;

            String url = Page.ResolveUrl("~/Procedimientos/EditarProcedimiento.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena Monge MONGE
        /// 25/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se elimina un procedimiento,
        /// se activa cuando se presiona el boton de eliminar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idProcedimiento = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Procedimiento> listaProcedimientos = (List<Procedimiento>)Session["listaProcedimientos"];

            Procedimiento procedimientoEliminar = new Procedimiento();

            foreach (Procedimiento procedimiento in listaProcedimientos)
            {
                if (procedimiento.idProcedimiento == idProcedimiento)
                {
                    procedimientoEliminar = procedimiento;
                    break;
                }
            }

            Session["procedimientoEliminar"] = procedimientoEliminar;

            String url = Page.ResolveUrl("~/Procedimientos/EliminarProcedimiento.aspx");
            Response.Redirect(url);

        }

        /// <summary>
        /// Priscilla Mena Monge Monge
        /// 25/04/2019
        /// Efecto: Metodo que redirecciona a la pagina donde se ve un procedimiento,
        /// se activa cuando se presiona el boton de ver
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnVer_Click(object sender, EventArgs e)
        {
            int idProcedimiento = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            List<Procedimiento> listaProcedimientos = (List<Procedimiento>)Session["listaProcedimientos"];

            Procedimiento procedimientoVer = new Procedimiento();

            foreach (Procedimiento procedimiento in listaProcedimientos)
            {
                if (procedimiento.idProcedimiento == idProcedimiento)
                {
                    procedimientoVer = procedimiento;
                    break;
                }
            }

            Session["procedimientoVer"] = procedimientoVer;

            String url = Page.ResolveUrl("~/Procedimientos/VerProcedimiento.aspx");
            Response.Redirect(url);

        }



        #endregion
    }
}