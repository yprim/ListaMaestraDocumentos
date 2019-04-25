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
    public partial class NuevoProcedimiento : System.Web.UI.Page
    {
        #region variables globales
        ProcedimientoServicios procedimientoServicios = new ProcedimientoServicios();
        EstadoServicios estadoServicios = new EstadoServicios();
        AprobadorServicios aprobadorServicios = new AprobadorServicios();
        ResponsableServicios responsableServicios = new ResponsableServicios();
        #endregion

        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene el usuario
            //si no tiene permiso de ver la pagina se redirecciona a login
            //2 significa administrador
            int[] rolesPermitidos = { 2 };
            Utilidades.escogerMenu(Page, rolesPermitidos);

            if (!IsPostBack)
            {
                txtNombreProcedimiento.Attributes.Add("oninput", "validarTexto(this)");
                txtCodigo.Attributes.Add("oninput", "validarTexto(this)");
                txtVersion.Attributes.Add("oninput", "validarTexto(this)");
                txtsustituyeA.Attributes.Add("oninput", "validarTexto(this)");
                txtdistribuidoA.Attributes.Add("oninput", "validarTexto(this)");
                txtReferenciaAdicional.Attributes.Add("oninput", "validarTexto(this)");
                llenarDdlEstados();
                llenarDdlAprobadores();
                llenarDdlResponsables();
            }

        }

        #endregion


        #region logica

        /// <summary>
        /// Priscilla Mena
        /// 25/04/2018
        /// Efecto:Metodo que carga todos los estados en el DropDownList
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void llenarDdlEstados()
        {
            List<Estado> listaEstados = estadoServicios.getEstados();
            ddlEstados.DataSource = listaEstados;
            ddlEstados.DataTextField = "nombre";
            ddlEstados.DataValueField = "idEstado";
            ddlEstados.DataBind();
        }

        /// <summary>
        /// Priscilla Mena
        /// 25/04/2018
        /// Efecto:Metodo que carga todos los aprobadores en el DropDownList
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void llenarDdlAprobadores()
        {
            List<Aprobador> listaAprobadores = aprobadorServicios.getAprobadores();
            ddlAprobadores.DataSource = listaAprobadores;
            ddlAprobadores.DataTextField = "nombre";
            ddlAprobadores.DataValueField = "idAprobador";
            ddlAprobadores.DataBind();
        }

        /// <summary>
        /// Priscilla Mena
        /// 25/04/2018
        /// Efecto:Metodo que carga todos los responsables en el DropDownList
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void llenarDdlResponsables()
        {
            List<Responsable> listaresponsables = responsableServicios.getResponsables();
            ddlResponsables.DataSource = listaresponsables;
            ddlResponsables.DataTextField = "nombre";
            ddlResponsables.DataValueField = "idResponsable";
            ddlResponsables.DataBind();
        }

        /// <summary>
        /// Priscilla Mena Monge
        /// 25/04/2019
        /// Efecto:Metodo que valida los campos que debe ingresar el usuario
        /// devuelve true si todos los campos esta con datos correctos
        /// sino devuelve false y marcar lo campos para que el usuario vea cuales son los campos que se encuentran mal
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public Boolean validarCampos()
        {
            Boolean validados = true;

            txtNombreProcedimiento.CssClass = "form-control";
            divNombreProcedimientoIncorrecto.Style.Add("display", "none");
            txtCodigo.CssClass = "form-control";
            divCodigoIncorrecto.Style.Add("display", "none");


            #region validacion Nombre Procedimiento

            String nombreProcedimiento = txtNombreProcedimiento.Text;
            String codigo = txtCodigo.Text;
            String version = txtVersion.Text;

            if (nombreProcedimiento.Trim() == "")
            {
                txtNombreProcedimiento.CssClass = "form-control alert-danger";
                divNombreProcedimientoIncorrecto.Style.Add("display", "block");

                validados = false;
            }
            if (codigo.Trim() == "")
            {
                txtCodigo.CssClass= "form-control alert-danger";
                divCodigoIncorrecto.Style.Add("display", "block");

                validados = false;

            }
            if (codigo.Trim() == "")
            {
                txtVersion.CssClass = "form-control alert-danger";
                divVersionIncorrecto.Style.Add("display", "block");

                validados = false;

            }
            if (codigo.Trim() == "")
            {
                txtsustituyeA.CssClass = "form-control alert-danger";
                divsustituyeAIncorrecto.Style.Add("display", "block");

                validados = false;

            }
            if (codigo.Trim() == "")
            {
                txtdistribuidoA.CssClass = "form-control alert-danger";
                divdistribuidoAIncorrecto.Style.Add("display", "block");

                validados = false;

            }
            if (codigo.Trim() == "")
            {
                txtReferenciaAdicional.CssClass = "form-control alert-danger";
                divReferenciaAdicionalIncorrecto.Style.Add("display", "block");

                validados = false;

            }
            #endregion

            return validados;
        }

        #endregion

        #region eventos
        /// <summary>
        /// Priscilla Mena Monge
        /// 25/04/2019
        /// Efecto:Metodo que se activa cuando se cambia el nombre
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void txtNombreProcedimiento_TextChanged(object sender, EventArgs e)
        {
            txtNombreProcedimiento.CssClass = "form-control";
            lblNombreProcedimientoIncorrecto.Visible = false;
        }


        /// <summary>
        /// Priscilla Mena Monge
        /// 25/04/2019
        /// Efecto:Metodo que se activa cuando se da click al boton de guardar
        /// valida que todos los campos se hayan ingrsado correctamente 
        /// y guarda los datos en la base de datos 
        /// redirecciona a la pantalla de administacion de Procedimientos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //se validan los campos antes de guardar los datos en la base de datos
            if (validarCampos())
            {
                
                Sistema sistema = new Sistema();
                sistema = (Sistema)Session["sistema"];

                Aprobador aprobador = new Aprobador();
                aprobador.idAprobador = Convert.ToInt32(ddlAprobadores.SelectedValue);
                aprobador.nombre = ddlResponsables.SelectedItem.Text;

                Responsable responsable = new Responsable();
                responsable.idResponsable= Convert.ToInt32(ddlResponsables.SelectedValue);
                responsable.nombre = ddlResponsables.SelectedItem.Text;

                Estado estado = new Estado();
                estado.idEstado = Convert.ToInt32(ddlEstados.SelectedValue);
                estado.nombre = ddlEstados.SelectedItem.Text;

                Procedimiento procedimiento = new Procedimiento();
                procedimiento.nombreDocumento = txtNombreProcedimiento.Text;
                procedimiento.codigo = txtCodigo.Text;
                procedimiento.acreditado = ddlAcreditado.SelectedItem.Text;
                procedimiento.version = txtVersion.Text;
                DateTime fecha = Convert.ToDateTime(txtFecha.Text);
                procedimiento.rigeDesde = fecha;
                procedimiento.aprobador = aprobador;
                procedimiento.sustituyeA = txtsustituyeA.Text;
                procedimiento.distribuidoA = txtdistribuidoA.Text;
                procedimiento.referenciaAdicional = txtReferenciaAdicional.Text;
                procedimiento.responsable = responsable;
                procedimiento.estado = estado;
                procedimiento.sistema = sistema;
                procedimiento.activo = "true";

                procedimientoServicios.insertarProcedimiento(procedimiento);


                String url = Page.ResolveUrl("~/Procedimientos/AdministrarProcedimiento.aspx");
                Response.Redirect(url);
            }
        }


        /// <summary>
        /// Priscilla Mena Monge
        /// 25/04/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton cancelar 
        /// redirecciona a la pantalla de adminstracion de Procedimientos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/Procedimientos/AdministrarProcedimiento.aspx");
            Response.Redirect(url);
        }

        #endregion
    }
}