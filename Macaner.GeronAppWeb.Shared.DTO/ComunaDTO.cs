using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Macaner.GeronAppWeb.Shared.DTO
{
    public class ComunaDTO
    {
        public int IdComuna { get; set; }
        public int IdRegion { get; set; }
        public string CodigoComuna { get; set; }
        public string Nombre { get; set; }        
        public string NombreRegion { get; set; }
    }
}
