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
    public partial class EditarUbicacion : System.Web.UI.Page
    {
        #region variables globales
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
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
                Ubicacion ubicacion = (Ubicacion)Session["UbicacionEditar"];
                txtNombreUbicacion.Text = ubicacion.nombre;
                txtNombreUbicacion.Attributes.Add("oninput", "validarTexto(this)");
            }
        }

        #endregion

        #region logica


        /// <summary>
        /// Priscilla Mena Monge
        /// 22/04/2019
        /// Efecto:Metodo que valida los campos que debe ingresar el usuario
        /// devuelve true si todos los campos esta con datos correctos
        /// sino devuelve false y marcar lo campos para que el usuario vea cuales son los campos que se encuntran mal
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: Boolean
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean validarCampos()
        {
            Boolean validados = true;

            #region validacion Nombre Ubicacion

            String nombreUbicacion = txtNombreUbicacion.Text;

            if (nombreUbicacion.Trim() == "")
            {
                txtNombreUbicacion.CssClass = "form-control alert-danger";
                divNombreUbicacionIncorrecto.Style.Add("display", "block");
                lblNombreUbicacionIncorrecto.Visible = true;

                validados = false;
            }
            #endregion

            return validados;
        }

        #endregion

        #region eventos
        /// <summary>
        /// Priscilla Mena Monge
        /// 22/04/2019
        /// Efecto:Metodo que se activa cuando se cambia el nombre
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void txtNombreUbicacion_Changed(object sender, EventArgs e)
        {
            txtNombreUbicacion.CssClass = "form-control";
            lblNombreUbicacion.Visible = false;
        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 22/04/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de actualizar
        ///valida que todos los campos se hayan ingresado correctamente y guarda los datos en la base de datos
        ///redireccion a la pantalla de Administracion de Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnActualiza_Click(object sender, EventArgs e)
        {
            //se validan los campos antes de actualizar los datos en la base de datos
            if (validarCampos())
            {
                Ubicacion ubicacion = (Ubicacion)Session["UbicacionEditar"];
                ubicacion.nombre = txtNombreUbicacion.Text;

                ubicacionServicios.actualizarUbicacion(ubicacion);

                String url = Page.ResolveUrl("~/Catalogos/AdministrarUbicacion.aspx");
                Response.Redirect(url);
            }


        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 22/04/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarUbicacion.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}