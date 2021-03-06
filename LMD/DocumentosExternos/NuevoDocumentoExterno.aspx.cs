﻿using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMD.DocumentosExternos
{
    public partial class NuevoDocumentoExterno : System.Web.UI.Page
    {
        #region variables globales
        DocumentoExternoServicios documentoExternoServicios = new DocumentoExternoServicios();
        ProcedimientoServicios procedimientoServicios = new ProcedimientoServicios();
        AutorServicios autorServicios = new AutorServicios();
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
        DocumentoExternoAutorServicios documentoExternoAutorServicios =  new DocumentoExternoAutorServicios();
        DocumentoExternoProcedimientoServicios documentoExternoProcedimientoServicios = new DocumentoExternoProcedimientoServicios();
        DocumentoExternoUbicacionServicios documentoExternoUbicacionServicios = new DocumentoExternoUbicacionServicios();
        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {

            //controla los menus q se muestran y las pantallas que se muestras segun el rol que tiene 
            //si no tiene permiso de ver la pagina se redirecciona a login
            int[] rolesPermitidos = { 2 };
            Utilidades.escogerMenu(Page, rolesPermitidos);

            if (!IsPostBack)
            {

                Session["documentoExternoNuevo"] = null;
                Session["listaProcedimientosNoAsociados"] = null;
                Session["listaProcedimientosAsociados"] = null;
                Session["idProcedimientoDesasociar"] = null;
                Session["listaAutoresNoAsociados"] = null;
                Session["listaAutoresAsociados"] = null;
                Session["idAutorDesasociar"] = null;
                Session["listaUbicacionesNoAsociadas"] = null;
                Session["listaUbicacionesAsociadas"] = null;
                Session["idUbicacionDesasociar"] = null;


                llenarDatos();

                txtAnno.Text = Convert.ToString(DateTime.Now.Year);


            }


        }
        #endregion


        #region logica

       


        /// <summary>
        /// Priscilla Mena
        /// 3/6/2019
        /// Efecto:Metodo que carga todos los datos que son asignados al nuevo documento externo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public void llenarDatos()
        {
            DocumentoExterno documentoExterno = (DocumentoExterno)Session["documentoExternoNuevo"];
            if (documentoExterno == null)
            {
                documentoExterno = new DocumentoExterno();
            }


            /*
             * se llena la lista con los procedimientos que NO estan asociados al documento externo
             */

            List<Procedimiento> listaProcedimientosNoAsociados = new List<Procedimiento>();

            if (Session["listaProcedimientosNoAsociados"] == null)
            {
                listaProcedimientosNoAsociados = procedimientoServicios.getProcedimientosNoEstanEnDocumentoExterno(documentoExterno);
            }
            else
            {
                listaProcedimientosNoAsociados = (List<Procedimiento>)Session["listaProcedimientosNoAsociados"];
            }

            Session["listaProcedimientosNoAsociados"] = listaProcedimientosNoAsociados;

            rpProcedimientoSinAsociar.DataSource = listaProcedimientosNoAsociados;
            rpProcedimientoSinAsociar.DataBind();

            /*
             * se llena la tabla de procedimientos que estan asociados al documento externo
             */

            List<Procedimiento> listaProcedimientosAsociados = new List<Procedimiento>();

            if (Session["listaProcedimientosAsociados"] == null)
            {

                listaProcedimientosAsociados = procedimientoServicios.getProcedimientosEstanEnDocumentoExterno(documentoExterno);

                Session["listaProcedimientosAsociados"] = listaProcedimientosAsociados;
            }
            else
            {
                listaProcedimientosAsociados = (List<Procedimiento>)Session["listaProcedimientosAsociados"];
            }

            rpProcedimiento.DataSource = listaProcedimientosAsociados;
            rpProcedimiento.DataBind();

            /*
           * se llena la lista con los autores que NO estan asociados al documento externo
           */

            List<Autor> listaAutoresNoAsociados = new List<Autor>();

            if (Session["listaAutoresNoAsociados"] == null)
            {
                listaAutoresNoAsociados = autorServicios.getAutoresNoEstanEnDocumentoExterno(documentoExterno);
            }
            else
            {
                listaAutoresNoAsociados = (List<Autor>)Session["listaAutoresNoAsociados"];
            }

            Session["listaAutoresNoAsociados"] = listaAutoresNoAsociados;

            rpAutorSinAsociar.DataSource = listaAutoresNoAsociados;
            rpAutorSinAsociar.DataBind();

            /*
             * se llena la tabla de autores que estan asociados al documento externo
             */

            List<Autor> listaAutoresAsociados = new List<Autor>();

            if (Session["listaAutoresAsociados"] == null)
            {

                listaAutoresAsociados = autorServicios.getAutoresEstanEnDocumentoExterno(documentoExterno);

                Session["listaAutoresAsociados"] = listaAutoresAsociados;
            }
            else
            {
                listaAutoresAsociados = (List<Autor>)Session["listaAutoresAsociados"];
            }

            rpAutor.DataSource = listaAutoresAsociados;
            rpAutor.DataBind();

            /*
         * se llena la lista con los ubicaciones que NO estan asociadas al documento externo
         */

            List<Ubicacion> listaUbicacionesNoAsociadas = new List<Ubicacion>();

            if (Session["listaUbicacionesNoAsociadas"] == null)
            {
                listaUbicacionesNoAsociadas = ubicacionServicios.getUbicacionesNoEstanEnDocumentoExterno(documentoExterno);
            }
            else
            {
                listaUbicacionesNoAsociadas = (List<Ubicacion>)Session["listaUbicacionesNoAsociadas"];
            }

            Session["listaUbicacionesNoAsociadas"] = listaUbicacionesNoAsociadas;

            rpUbicacionSinAsociar.DataSource = listaUbicacionesNoAsociadas;
            rpUbicacionSinAsociar.DataBind();

            /*
             * se llena la tabla de ubicaciones que estan asociadas al documento externo
             */

            List<Ubicacion> listaUbicacionesAsociadas = new List<Ubicacion>();

            if (Session["listaUbicacionesAsociadas"] == null)
            {

                listaUbicacionesAsociadas = ubicacionServicios.getUbicacionesEstanEnDocumentoExterno(documentoExterno);

                Session["listaUbicacionesAsociadas"] = listaUbicacionesAsociadas;
            }
            else
            {
                listaUbicacionesAsociadas = (List<Ubicacion>)Session["listaUbicacionesAsociadas"];
            }

            rpUbicacion.DataSource = listaUbicacionesAsociadas;
            rpUbicacion.DataBind();

        

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

            txtNombreDocumento.CssClass = "form-control";
            divNombreDocumentoIncorrecto.Style.Add("display", "none");
            txtVersion.CssClass = "form-control";
            divVersionIncorrecto.Style.Add("display", "none");


            #region validacion Nombre Procedimiento

            String nombreProcedimiento = txtNombreDocumento.Text;
            String version = txtVersion.Text;

            if (nombreProcedimiento.Trim() == "")
            {
                txtNombreDocumento.CssClass = "form-control alert-danger";
                divNombreDocumentoIncorrecto.Style.Add("display", "block");

                validados = false;

            }
           
            if (version.Trim() == "")
            {
                txtVersion.CssClass = "form-control alert-danger";
                divVersionIncorrecto.Style.Add("display", "block");

                validados = false;


          

            }

            if (!validados)
            {
                /*para que se quede en el tab  donde no puso datos*/
                liDocumentoExterno.Attributes["class"] = "active";
                liProcedimiento.Attributes["class"] = "";
                liAutor.Attributes["class"] = "";
                liUbicacion.Attributes["class"] = "";


                ViewUbicacion.Style.Add("display", "none");
                ViewDocumentoExterno.Style.Add("display", "block");
                ViewAutor.Style.Add("display", "none");
                ViewProcedimiento.Style.Add("display", "none");

            }
          
            #endregion

            return validados;
        }


        #endregion



        #region eventos


        /// <summary>
        /// Priscilla Mena
        /// 3/06/2019
        /// Efecto:Metodo que se activa cuando se le da click al boton de asociar, y asocia un procedimiento al documento externo
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnAsociar_Click(object sender, EventArgs e)
        {
            DocumentoExterno documentoExterno = new DocumentoExterno();

            

            List<Procedimiento> listaProcedimientosNoAsociados = (List<Procedimiento>)Session["listaProcedimientosNoAsociados"];
            List<Procedimiento> listaProcedimientosSeleccionados = new List<Procedimiento>();

            int idProcedimiento = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            Procedimiento procedimiento = new Procedimiento();

            foreach (Procedimiento procedimientoLista in listaProcedimientosNoAsociados)
            {
                if (procedimientoLista.idProcedimiento == idProcedimiento)
                {
                    procedimiento = procedimientoLista;

                    break;
                }
            }

            listaProcedimientosSeleccionados.Add(procedimiento);

            List<Procedimiento> listaProcedimientoAsociados = (List<Procedimiento>)Session["listaProcedimientosAsociados"];

            foreach (Procedimiento procedimientoLista in listaProcedimientosSeleccionados)
            {
                listaProcedimientoAsociados.Add(procedimientoLista);
            }

            List<Procedimiento> listaProcedimientoNoAsociadosTemp = new List<Procedimiento>();

            foreach (Procedimiento procedimientoNoAsociado in listaProcedimientosNoAsociados)
            {
                Boolean asociar = true;
                foreach (Procedimiento procedimientoLista in listaProcedimientosSeleccionados)
                {
                    if (procedimientoLista.idProcedimiento == procedimientoNoAsociado.idProcedimiento)
                    {
                        asociar = false;
                        break;
                    }
                }

                if (asociar)
                {
                    listaProcedimientoNoAsociadosTemp.Add(procedimientoNoAsociado);
                }

            }

            Session["listaProcedimientosNoAsociados"] = listaProcedimientoNoAsociadosTemp;
            Session["listaProcedimientosAsociados"] = listaProcedimientoAsociados;

            llenarDatos();

            /*para que se quede en el tab de Procedimiento despues del posback*/
            liDocumentoExterno.Attributes["class"] = "";
            liAutor.Attributes["class"] = "";
            liUbicacion.Attributes["class"] = "";
            liProcedimiento.Attributes["class"] = "active";


            ViewProcedimiento.Style.Add("display", "block");
            ViewUbicacion.Style.Add("display", "none");
            ViewDocumentoExterno.Style.Add("display", "none");
            ViewAutor.Style.Add("display", "none");


            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModalProcedimiento();", true);
        }



        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de asociar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnAsociarAutor_Click(object sender, EventArgs e)
        {
            DocumentoExterno DocumentoExterno = new DocumentoExterno();

            List<Autor> listaAutoresNoAsociados = (List<Autor>)Session["listaAutoresNoAsociados"];
            List<Autor> listaAutorsSeleccionados = new List<Autor>();

            int idAutor = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            Autor Autor = new Autor();

            foreach (Autor autorLista in listaAutoresNoAsociados)
            {
                if (autorLista.idAutor == idAutor)
                {
                    Autor = autorLista;

                    break;
                }
            }

            listaAutorsSeleccionados.Add(Autor);

            List<Autor> listaAutorAsociados = (List<Autor>)Session["listaAutoresAsociados"];

            foreach (Autor autorLista in listaAutorsSeleccionados)
            {
                listaAutorAsociados.Add(autorLista);
            }

            List<Autor> listaAutorNoAsociadosTemp = new List<Autor>();

            foreach (Autor autorNoAsociado in listaAutoresNoAsociados)
            {
                Boolean asociar = true;
                foreach (Autor autorLista in listaAutorsSeleccionados)
                {
                    if (autorLista.idAutor == autorNoAsociado.idAutor)
                    {
                        asociar = false;
                        break;
                    }
                }

                if (asociar)
                {
                    listaAutorNoAsociadosTemp.Add(autorNoAsociado);
                }

            }

            Session["listaAutoresNoAsociados"] = listaAutorNoAsociadosTemp;
            Session["listaAutoresAsociados"] = listaAutorAsociados;

            llenarDatos();

            /*para que se quede en el tab de Autors despues del posback*/
            liDocumentoExterno.Attributes["class"] = "";
            liProcedimiento.Attributes["class"] = "";
            liUbicacion.Attributes["class"] = "";
            liAutor.Attributes["class"] = "active";


            ViewAutor.Style.Add("display", "block");
            ViewDocumentoExterno.Style.Add("display", "none");
            ViewUbicacion.Style.Add("display", "none");
            ViewProcedimiento.Style.Add("display", "none");


            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModalAutor();", true);
        }


        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de asociar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnAsociarUbicacion_Click(object sender, EventArgs e)
        {
            DocumentoExterno DocumentoExterno = new DocumentoExterno();

            List<Ubicacion> listaUbicacionesNoAsociadas = (List<Ubicacion>)Session["listaUbicacionesNoAsociadas"];
            List<Ubicacion> listaUbicacionsSeleccionados = new List<Ubicacion>();

            int idUbicacion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            Ubicacion Ubicacion = new Ubicacion();

            foreach (Ubicacion ubicacionLista in listaUbicacionesNoAsociadas)
            {
                if (ubicacionLista.idUbicacion == idUbicacion)
                {
                    Ubicacion = ubicacionLista;

                    break;
                }
            }

            listaUbicacionsSeleccionados.Add(Ubicacion);

            List<Ubicacion> listaUbicacionesAsociadas = (List<Ubicacion>)Session["listaUbicacionesAsociadas"];

            foreach (Ubicacion ubicacionLista in listaUbicacionsSeleccionados)
            {
                listaUbicacionesAsociadas.Add(ubicacionLista);
            }

            List<Ubicacion> listaUbicacionNoAsociadosTemp = new List<Ubicacion>();

            foreach (Ubicacion ubicacionNoAsociado in listaUbicacionesNoAsociadas)
            {
                Boolean asociar = true;
                foreach (Ubicacion ubicacionLista in listaUbicacionsSeleccionados)
                {
                    if (ubicacionLista.idUbicacion == ubicacionNoAsociado.idUbicacion)
                    {
                        asociar = false;
                        break;
                    }
                }

                if (asociar)
                {
                    listaUbicacionNoAsociadosTemp.Add(ubicacionNoAsociado);
                }

            }

            Session["listaUbicacionesNoAsociadas"] = listaUbicacionNoAsociadosTemp;
            Session["listaUbicacionesAsociadas"] = listaUbicacionesAsociadas;

            llenarDatos();

            /*para que se quede en el tab de Ubicacions despues del posback*/
            liDocumentoExterno.Attributes["class"] = "";
            liProcedimiento.Attributes["class"] = "";
            liAutor.Attributes["class"] = "";
            liUbicacion.Attributes["class"] = "active";


            ViewUbicacion.Style.Add("display", "block");
            ViewDocumentoExterno.Style.Add("display", "none");
            ViewProcedimiento.Style.Add("display", "none");
            ViewAutor.Style.Add("display", "none");


            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModalUbicacion();", true);
        }



        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto:Metodo que se activa modal de confirmacion para desasociar procedimientos a revisar
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnDesasociar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModalDesasociarProcedimientos();", true);

            int idProcedimiento = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            Session["idProcedimientoDesasociar"] = idProcedimiento;

            List<Procedimiento> listaProcedimientoAsociados = (List<Procedimiento>)Session["listaProcedimientosAsociados"];

            List<Procedimiento> listaProcedimientosSeleccionados = new List<Procedimiento>();

            foreach (Procedimiento procedimiento in listaProcedimientoAsociados)
            {
                if (procedimiento.idProcedimiento == idProcedimiento)
                {
                    lblDesasociarProcedimiento.Text = "Se desasociará el procedimiento: " + procedimiento.nombreDocumento + " <br /> ¿está de acuerdo?";
                }
            }

            /*para que se quede en el tab de Procedimiento despues del posback*/
            liDocumentoExterno.Attributes["class"] = "";
            liAutor.Attributes["class"] = "";
            liUbicacion.Attributes["class"] = "";
            liProcedimiento.Attributes["class"] = "active";


            ViewProcedimiento.Style.Add("display", "block");
            ViewDocumentoExterno.Style.Add("display", "none");
            ViewAutor.Style.Add("display", "none");
            ViewUbicacion.Style.Add("display", "none");

        }

        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto:Metodo que se activa modal de confirmacion para desasociar autors
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnDesasociarAutor_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModalDesasociarAutores();", true);

            int idAutor = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            Session["idAutorDesasociar"] = idAutor;

            List<Autor> listaAutorAsociados = (List<Autor>)Session["listaAutoresAsociados"];

            List<Autor> listaAutorsSeleccionados = new List<Autor>();

            foreach (Autor Autor in listaAutorAsociados)
            {
                if (Autor.idAutor == idAutor)
                {
                    lblDesasociarAutor.Text = "Se desasociará el Autor: " + Autor.nombre + " <br /> ¿está de acuerdo?";
                }
            }

            /*para que se quede en el tab de Autor despues del posback*/
            liDocumentoExterno.Attributes["class"] = "";
            liProcedimiento.Attributes["class"] = "";
            liAutor.Attributes["class"] = "active";
            liUbicacion.Attributes["class"] = "";


            ViewAutor.Style.Add("display", "block");
            ViewProcedimiento.Style.Add("display", "none");
            ViewDocumentoExterno.Style.Add("display", "none");
            ViewUbicacion.Style.Add("display", "none");
        }

        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto:Metodo que se activa modal de confirmacion para desasociar ubicaciones
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnDesasociarUbicacion_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "activar", "activarModalDesasociarUbicaciones();", true);

            int idUbicacion = Convert.ToInt32((((LinkButton)(sender)).CommandArgument).ToString());

            Session["idUbicacionDesasociar"] = idUbicacion;

            List<Ubicacion> listaUbicacionesAsociadas = (List<Ubicacion>)Session["listaUbicacionesAsociadas"];

            List<Ubicacion> listaUbicacionsSeleccionados = new List<Ubicacion>();

            foreach (Ubicacion Ubicacion in listaUbicacionesAsociadas)
            {
                if (Ubicacion.idUbicacion == idUbicacion)
                {
                    lblDesasociarUbicacion.Text = "Se desasociará el Ubicacion: " + Ubicacion.nombre + " <br /> ¿está de acuerdo?";
                }
            }

            /*para que se quede en el tab de Ubicacion despues del posback*/
            liDocumentoExterno.Attributes["class"] = "";
            liProcedimiento.Attributes["class"] = "";
            liAutor.Attributes["class"] = "";
            liUbicacion.Attributes["class"] = "active";


            ViewUbicacion.Style.Add("display", "block");
            ViewProcedimiento.Style.Add("display", "none");
            ViewAutor.Style.Add("display", "none");
            ViewDocumentoExterno.Style.Add("display", "none");

        }


        /// <summary>
        /// Priscilla Mena
        /// 18/10/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de cancelar
        /// redireccion a la pantalla de Administracion de DocumentoExternos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/DocumentosExternos/AdministrarDocumentoExterno.aspx");
            Response.Redirect(url);
        }

        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto: Desasocia un elemento a revisar de la documentoExterno 
        /// y elimina el registro en la base de datos
        /// vuelve a levantar el modal
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnDesasociarProcedimientoConfirmar_Click(object sender, EventArgs e)
        {
            int idProcedimiento = (int)Session["idProcedimientoDesasociar"];

            Procedimiento procedimiento = new Procedimiento();

            procedimiento.idProcedimiento = idProcedimiento;

            List<Procedimiento> listaProcedimientosAsociados = (List<Procedimiento>)Session["listaProcedimientosAsociados"];

            List<Procedimiento> listaProcedimientosSeleccionados = new List<Procedimiento>();

            foreach (Procedimiento procedimientos in listaProcedimientosAsociados)
            {
                if (procedimientos.idProcedimiento == procedimiento.idProcedimiento)
                {
                    listaProcedimientosSeleccionados.Add(procedimientos);
                }
            }

            List<Procedimiento> listaProcedimientosNoAsociados = (List<Procedimiento>)Session["listaProcedimientosNoAsociados"];
            List<Procedimiento> listaProcedimientosAsociadosTemp = new List<Procedimiento>();

            foreach (Procedimiento Procedimientos in listaProcedimientosSeleccionados)
            {
                listaProcedimientosNoAsociados.Add(Procedimientos);
            }

            foreach (Procedimiento ProcedimientoAsociado in listaProcedimientosAsociados)
            {
                Boolean asociar = true;
                foreach (Procedimiento Procedimientos in listaProcedimientosSeleccionados)
                {
                    if (ProcedimientoAsociado.idProcedimiento == Procedimientos.idProcedimiento)
                    {
                        asociar = false;
                        break;
                    }
                }

                if (asociar)
                {
                    listaProcedimientosAsociadosTemp.Add(ProcedimientoAsociado);
                }
            }

            Session["listaProcedimientosAsociados"] = listaProcedimientosAsociadosTemp;
            Session["listaProcedimientosNoAsociados"] = listaProcedimientosNoAsociados;

            llenarDatos();

            /*para que se quede en el tab de Procedimientos despues del posback*/
            liDocumentoExterno.Attributes["class"] = "";
            liAutor.Attributes["class"] = "";
            liProcedimiento.Attributes["class"] = "active";


            ViewProcedimiento.Style.Add("display", "block");
            ViewDocumentoExterno.Style.Add("display", "none");
            ViewAutor.Style.Add("display", "none");

        }


        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto: Desasocia autor de la documentoExterno 
        /// y elimina el registro en la base de datos
        /// vuelve a levantar el modal
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnDesasociarAutorConfirmar_Click(object sender, EventArgs e)
        {
            int idAutor = (int)Session["idAutorDesasociar"];

            Autor Autor = new Autor();

            Autor.idAutor = idAutor;

            List<Autor> listaAutoresAsociados = (List<Autor>)Session["listaAutoresAsociados"];

            List<Autor> listaAutorsSeleccionados = new List<Autor>();

            foreach (Autor Autors in listaAutoresAsociados)
            {
                if (Autors.idAutor == Autor.idAutor)
                {
                    listaAutorsSeleccionados.Add(Autors);
                }
            }

            List<Autor> listaAutoresNoAsociados = (List<Autor>)Session["listaAutoresNoAsociados"];
            List<Autor> listaAutoresAsociadosTemp = new List<Autor>();

            foreach (Autor Autors in listaAutorsSeleccionados)
            {
                listaAutoresNoAsociados.Add(Autors);
            }

            foreach (Autor AutorAsociado in listaAutoresAsociados)
            {
                Boolean asociar = true;
                foreach (Autor Autors in listaAutorsSeleccionados)
                {
                    if (AutorAsociado.idAutor == Autors.idAutor)
                    {
                        asociar = false;
                        break;
                    }
                }

                if (asociar)
                {
                    listaAutoresAsociadosTemp.Add(AutorAsociado);
                }
            }

            Session["listaAutoresAsociados"] = listaAutoresAsociadosTemp;
            Session["listaAutoresNoAsociados"] = listaAutoresNoAsociados;

            llenarDatos();

            /*para que se quede en el tab de Autors despues del posback*/
            liDocumentoExterno.Attributes["class"] = "";
            liProcedimiento.Attributes["class"] = "";
            liAutor.Attributes["class"] = "active";
          

            ViewAutor.Style.Add("display", "block");
            ViewDocumentoExterno.Style.Add("display", "none");
            ViewProcedimiento.Style.Add("display", "none");
        }


        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto: Desasocia ubicacion del documentoExterno 
        /// y elimina el registro en la base de datos
        /// vuelve a levantar el modal
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnDesasociarUbicacionConfirmar_Click(object sender, EventArgs e)
        {
            int idUbicacion = (int)Session["idUbicacionDesasociar"];

            Ubicacion Ubicacion = new Ubicacion();

            Ubicacion.idUbicacion = idUbicacion;

            List<Ubicacion> listaUbicacionesAsociadas = (List<Ubicacion>)Session["listaUbicacionesAsociadas"];

            List<Ubicacion> listaUbicacionsSeleccionados = new List<Ubicacion>();

            foreach (Ubicacion Ubicacions in listaUbicacionesAsociadas)
            {
                if (Ubicacions.idUbicacion == Ubicacion.idUbicacion)
                {
                    listaUbicacionsSeleccionados.Add(Ubicacions);
                }
            }

            List<Ubicacion> listaUbicacionesNoAsociadas = (List<Ubicacion>)Session["listaUbicacionesNoAsociadas"];
            List<Ubicacion> listaUbicacionesAsociadasTemp = new List<Ubicacion>();

            foreach (Ubicacion Ubicacions in listaUbicacionsSeleccionados)
            {
                listaUbicacionesNoAsociadas.Add(Ubicacions);
            }

            foreach (Ubicacion UbicacionAsociado in listaUbicacionesAsociadas)
            {
                Boolean asociar = true;
                foreach (Ubicacion Ubicacions in listaUbicacionsSeleccionados)
                {
                    if (UbicacionAsociado.idUbicacion == Ubicacions.idUbicacion)
                    {
                        asociar = false;
                        break;
                    }
                }

                if (asociar)
                {
                    listaUbicacionesAsociadasTemp.Add(UbicacionAsociado);
                }
            }

            Session["listaUbicacionesAsociadas"] = listaUbicacionesAsociadasTemp;
            Session["listaUbicacionesNoAsociadas"] = listaUbicacionesNoAsociadas;

            llenarDatos();

            /*para que se quede en el tab de Ubicacions despues del posback*/
            liDocumentoExterno.Attributes["class"] = "";
            liProcedimiento.Attributes["class"] = "";
            liAutor.Attributes["class"] = "";
            liUbicacion.Attributes["class"] = "active";


            ViewUbicacion.Style.Add("display", "block");
            ViewDocumentoExterno.Style.Add("display", "none");
            ViewAutor.Style.Add("display", "none");
            ViewProcedimiento.Style.Add("display", "none");
        }


        /// <summary>
        /// Priscilla Mena
        /// 27/09/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de guardar
        /// y guarda un registro en la base de datos
        /// redireccion a la pantalla de Administracion de DocumentoExternos
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


                DocumentoExterno documentoExterno = new DocumentoExterno();
                documentoExterno.presentacion = ddlPresentacion.SelectedItem.Text;
                documentoExterno.annoEmision = txtAnno.Text;
                documentoExterno.activo = "1";
                documentoExterno.nombreDocumento = txtNombreDocumento.Text;
                documentoExterno.version = txtVersion.Text;
                documentoExterno.sistema = sistema;



                documentoExterno.idDocumentoExterno = documentoExternoServicios.insertarDocumentoExterno(documentoExterno);


                /*----------------------Asociar procedimientos ----------------------------------------*/

                List<Procedimiento> listaProcedimientosAsociados = (List<Procedimiento>)Session["listaProcedimientosAsociados"];

                foreach (Procedimiento procedimiento in listaProcedimientosAsociados)
                {
                    if (!documentoExternoProcedimientoServicios.procedimientoAsociadoADocumentoExterno(documentoExterno, procedimiento))
                    {
                        documentoExternoProcedimientoServicios.insertarDocumentoExternoProcedimiento(documentoExterno, procedimiento);
                    }
                }

                List<Procedimiento> listaProcedimientosNoAsociados = (List<Procedimiento>)Session["listaProcedimientosNoAsociados"];

                foreach (Procedimiento Procedimiento in listaProcedimientosNoAsociados)
                {
                    if (documentoExternoProcedimientoServicios.procedimientoAsociadoADocumentoExterno(documentoExterno, Procedimiento))
                    {
                        documentoExternoProcedimientoServicios.eliminarDocumentoExternoProcedimiento(documentoExterno, Procedimiento);
                    }
                }

                /*--------------------- Fin-Asociar Procedimientos----------------------------------------*/

                /*----------------------Asociar autores----------------------------------------*/

                List<Autor> listaAutoresAsociados = (List<Autor>)Session["listaAutoresAsociados"];

                foreach (Autor Autor in listaAutoresAsociados)
                {
                    if (!documentoExternoAutorServicios.autorAsociadoADocumentoExterno(documentoExterno, Autor))
                    {
                        documentoExternoAutorServicios.insertarDocumentoExternoAutor(documentoExterno, Autor);
                    }
                }

                List<Autor> listaAutoresNoAsociados = (List<Autor>)Session["listaAutoresNoAsociados"];

                foreach (Autor autor in listaAutoresNoAsociados)
                {
                    if (documentoExternoAutorServicios.autorAsociadoADocumentoExterno(documentoExterno, autor))
                    {
                        documentoExternoAutorServicios.eliminarDocumentoExternoAutor(documentoExterno, autor);
                    }
                }

                /*--------------------- Fin-Asociar Autores----------------------------------------*/

                /*----------------------Asociar ubicaciones----------------------------------------*/

                List<Ubicacion> listaUbicacionesAsociadas = (List<Ubicacion>)Session["listaUbicacionesAsociadas"];

                foreach (Ubicacion Ubicacion in listaUbicacionesAsociadas)
                {
                    if (!documentoExternoUbicacionServicios.ubicacionAsociadaADocumentoExterno(documentoExterno, Ubicacion))
                    {
                        documentoExternoUbicacionServicios.insertarDocumentoExternoUbicacion(documentoExterno, Ubicacion);
                    }
                }

                List<Ubicacion> listaUbicacionesNoAsociadas = (List<Ubicacion>)Session["listaUbicacionesNoAsociadas"];

                foreach (Ubicacion ubicacion in listaUbicacionesNoAsociadas)
                {
                    if (documentoExternoUbicacionServicios.ubicacionAsociadaADocumentoExterno(documentoExterno, ubicacion))
                    {
                        documentoExternoUbicacionServicios.eliminarDocumentoExternoUbicacion(documentoExterno, ubicacion);
                    }
                }

                /*--------------------- Fin-Asociar Ubicaciones----------------------------------------*/




                String url = Page.ResolveUrl("~/DocumentosExternos/AdministrarDocumentoExterno.aspx");
                Response.Redirect(url);
            }

        }


        /// <summary>
        /// Priscilla Mena
        /// 18/10/2018
        /// Efecto:Metodo que se activa cuando se le da click al boton de cancelar
        /// redireccion a la pantalla de Administracion de DocumentoExternos
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            String url = Page.ResolveUrl("~/DocumentosExternos/AdministrarDocumentoExterno.aspx");
            Response.Redirect(url);
        }

       #endregion

    }

}