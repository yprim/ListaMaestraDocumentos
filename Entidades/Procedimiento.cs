using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    /// <summary>
    /// Priscilla Mena
    /// 22/04/2019
    /// clase para administrar la entidad  Procedimiento
     /// </summary>
    public class Procedimiento
    {
        public int idProcedimiento { get; set; }
        public String nombreDocumento { get; set; }
        public String codigo { get; set; }
        public String acreditado { get; set; }
        public String version { get; set; }
        public DateTime rigeDesde { get; set; }
        public Aprobador aprobador { get; set; }
        public String  sustituyeA { get; set; }
        public String distribuidoA { get; set; }
        public String referenciaAdicional { get; set; }
        public Responsable responsable { get; set; }
        public Estado estado { get; set; }
        public Sistema sistema { get; set; }
        public String activo { get; set; }


    }
}
