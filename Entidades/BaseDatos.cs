using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class BaseDatos
    {
        public String baseLogin { get; set; }
        public String servidorLogin { get; set; }
        public String usuarioLogin { get; set; }
        public String contrasenaLogin { get; set; }

        public String baseLMD { get; set; }
        public String servidorLMD { get; set; }
        public String usuarioLMD { get; set; }
        public String contrasenaLMD { get; set; }
    }
}
