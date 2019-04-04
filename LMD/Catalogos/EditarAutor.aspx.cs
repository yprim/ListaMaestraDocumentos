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
    public partial class EditarAutor : System.Web.UI.Page
    {
        #region variables globales
        AutorServicios autorServicios = new AutorServicios();
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
                Autor autor = (Autor)Session["AutorEditar"];
                txtNombreAutor.Text = autor.nombre;
                txtNombreAutor.Attributes.Add("oninput", "validarTexto(this)");
            }
        }

        #endregion

        #region logica


        /// <summary>
        /// Priscilla Mena Monge
        /// 04/04/2019
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

            #region validacion Nombre Autor

            String nombreAutor = txtNombreAutor.Text;

            if (nombreAutor.Trim() == "")
            {
                txtNombreAutor.CssClass = "form-control alert-danger";
                divNombreAutorIncorrecto.Style.Add("display", "block");
                lblNombreAutorIncorrecto.Visible = true;

                validados = false;
            }
            #endregion

            return validados;
        }

        #endregion

        #region eventos
        /// <summary>
        /// Priscilla Mena Monge
        /// 04/04/2019
        /// Efecto:Metodo que se activa cuando se cambia el nombre
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void txtNombreAutor_Changed(object sender, EventArgs e)
        {
            txtNombreAutor.CssClass = "form-control";
            lblNombreAutor.Visible = false;
        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 04/04/2019
        /// Efecto: Metodo que se activa cuando se le da click al boton de actualizar
        ///valida que todos los campos se hayan ingresado correctamente y guarda los datos en la base de datos
        ///redireccion a la pantalla de Administracion de Autores
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
                Autor autor = (Autor)Session["AutorEditar"];
                autor.nombre = txtNombreAutor.Text;

                autorServicios.actualizarAutor(autor);

                String url = Page.ResolveUrl("~/Catalogos/AdministrarAutor.aspx");
                Response.Redirect(url);
            }


        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 04/04/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Autores
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Catalogos/AdministrarAutor.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}