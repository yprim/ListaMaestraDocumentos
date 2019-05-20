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
        UbicacionServicios ubicacionServicios = new UbicacionServicios();
        AutorServicios autorServicios = new AutorServicios();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
          

        }
    }
}