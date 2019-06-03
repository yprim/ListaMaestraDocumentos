using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Priscilla Mena
    /// 29/04/2019
    /// clase para administrar la entidad  DocumentoExterno
    /// </summary>
    public class DocumentoExterno
    {
        public int idDocumentoExterno { get; set; }
        public String nombreDocumento { get; set; }
        public String annoEmision { get; set; }
        public String version { get; set; }
        public String presentacion { get; set; }
        public Sistema sistema { get; set; }
        public String activo { get; set; }
        public List<Autor> listaAutores { get; set; }
        public List<Procedimiento> listaProcedimientos { get; set; }

    }
}
